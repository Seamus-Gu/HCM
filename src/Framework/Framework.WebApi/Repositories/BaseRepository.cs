using Framework.Core;
using SqlSugar;

namespace Framework.WebApi
{
    public class BaseRepository<TEntity> : SimpleClient<TEntity>, IRepository
           where TEntity : class, new()
    {
        protected ITenant iTenant; // 多租户事务

        public BaseRepository(ISqlSugarClient context) : base(context)
        {
            iTenant = App.GetRequiredService<ISqlSugarClient>()!.AsTenant();

            // 若实体贴有多库特性，则返回指定的连接
            if (typeof(TEntity).IsDefined(typeof(TenantAttribute), false))
            {
                base.Context = iTenant.GetConnectionScopeWithAttr<TEntity>();
                return;
            }

            //// 若实体贴有系统表特性，则返回默认的连接
            //if (typeof(T).IsDefined(typeof(SystemTableAttribute), false)) return;

            //// 若当前未登录或是默认租户Id，则返回默认的连接
            //var tenantId = App.GetRequiredService<UserManager>().TenantId;
            //if (tenantId < 1 || tenantId.ToString() == SqlSugarConst.ConfigId) return;

            //// 根据租户Id切库
            //if (!iTenant.IsAnyConnection(tenantId.ToString()))
            //{
            //    var tenant = App.GetRequiredService<SysCacheService>().Get<List<SysTenant>>(CacheConst.KeyTenant)
            //        .FirstOrDefault(u => u.Id == tenantId);
            //    iTenant.AddConnection(new ConnectionConfig()
            //    {
            //        ConfigId = tenant.Id,
            //        DbType = tenant.DbType,
            //        ConnectionString = tenant.Connection,
            //        IsAutoCloseConnection = true
            //    });
            //    SqlSugarSetup.SetDbAop(iTenant.GetConnectionScope(tenantId.ToString()));
            //}
            //base.Context = iTenant.GetConnectionScope(tenantId.ToString());

            iTenant = context.AsTenant();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="pagination"></param>
        /// <param name="mainTableAlias"> LeftJoin 场景传主表别名，如 "a"</param>
        /// <returns></returns>
        protected List<TEntity> PaginationList(
            ISugarQueryable<TEntity> queryable,
            Pagination pagination,
            string? mainTableAlias = null)
        {
            int pageTotal = 0;

            var sortField = BuildSortField(pagination.Sort, mainTableAlias);
            if (!string.IsNullOrEmpty(sortField))
            {
                var orderType = ParseOrderType(pagination.Order);

                queryable.OrderBy(OrderByModel.Create(new OrderByModel
                {
                    FieldName = sortField!,
                    OrderByType = orderType
                }));
            }

            var result = queryable.ToPageList(pagination.PageNum, pagination.PageSize, ref pageTotal);
            pagination.Total = pageTotal;

            return result.ToList();
        }

        protected async Task<List<TEntity>> PaginationListAsync(
            ISugarQueryable<TEntity> queryable,
            Pagination pagination,
            string? mainTableAlias = null)
        {
            RefAsync<int> pageTotal = 0;

            var sortField = BuildSortField(pagination.Sort, mainTableAlias);

            if (!string.IsNullOrEmpty(sortField))
            {
                var orderType = ParseOrderType(pagination.Order);

                queryable.OrderBy(OrderByModel.Create(new OrderByModel
                {
                    FieldName = sortField!,
                    OrderByType = orderType
                }));
            }

            var result = await queryable.ToPageListAsync(pagination.PageNum, pagination.PageSize, pageTotal);
            pagination.Total = pageTotal;

            return result.ToList();
        }


        private static OrderByType ParseOrderType(string? order)
        {
            return order?.ToLowerInvariant() switch
            {
                "desc" or "descending" => OrderByType.Desc,
                _ => OrderByType.Asc
            };
        }

        private static string? BuildSortField(string? sort, string? mainTableAlias)
        {
            if (string.IsNullOrEmpty(sort))
            {
                return null;
            }

            // 仅允许实体属性参与排序，避免拼接非法字段
            var prop = typeof(TEntity).GetProperty(
                sort,
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.IgnoreCase);

            if (prop == null)
            {
                return null;
            }

            var dbColumn = UtilMethods.ToUnderLine(prop.Name);

            // LeftJoin 时强制使用主表别名，避免同名字段排序歧义
            return string.IsNullOrEmpty(mainTableAlias) ? dbColumn : $"{mainTableAlias}.{dbColumn}";
        }

        //protected List<TEntity> PaginationList<T>(ISugarQueryable<TEntity> queryable, T queryDto) where T : Pagination
        //{
        //    int pageTotal = 0;

        //    if (!queryDto.Sort.IsNullOrEmpty())
        //    {
        //        var orderType = OrderByType.Asc;

        //        if (queryDto.Order == "asc")
        //        {
        //            orderType = OrderByType.Asc;
        //        }
        //        else if (queryDto.Order == "desc")
        //        {
        //            orderType = OrderByType.Desc;
        //        }

        //        List<OrderByModel> orderList = OrderByModel.Create(
        //            new OrderByModel() { FieldName = UtilMethods.ToUnderLine(queryDto.Sort), OrderByType = orderType }
        //        );

        //        queryable.OrderBy(orderList);
        //    }

        //    var result = queryable.ToPageList(queryDto.PageNum, queryDto.PageSize, ref pageTotal);

        //    queryDto.Total = pageTotal;

        //    return result.ToList();
        //}

        //protected async Task<List<TEntity>> PaginationListAsync<T>(ISugarQueryable<TEntity> queryable, T queryDto) where T : Pagination
        //{
        //    RefAsync<int> pageTotal = 0;

        //    if (!string.IsNullOrEmpty(queryDto.Sort))
        //    {
        //        var orderType = OrderByType.Asc;

        //        if (queryDto.Order == "ascending")
        //        {
        //            orderType = OrderByType.Asc;
        //        }
        //        else if (queryDto.Order == "descending")
        //        {
        //            orderType = OrderByType.Desc;
        //        }

        //        List<OrderByModel> orderList = OrderByModel.Create(
        //            new OrderByModel() { FieldName = UtilMethods.ToUnderLine(queryDto.Sort), OrderByType = orderType }
        //        );

        //        queryable.OrderBy(orderList);
        //    }

        //    var result = await queryable.ToPageListAsync(queryDto.PageNum, queryDto.PageSize, pageTotal);

        //    queryDto.Total = pageTotal.Value;

        //    return result.ToList();
        //}
    }
}