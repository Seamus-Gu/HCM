namespace HCM.Core.Repositories
{
    /// <summary>
    /// 角色信息表仓储层
    /// </summary>
    public class SysRoleRepository : BaseRepository<SysRole>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysRoleRepository(ISqlSugarClient context) : base(context)
        {
        }

        /// <summary>
        /// 获取角色信息表分页列表
        /// </summary>
        public Task<List<SysRole>> SelectSysRolePageList(Pagination query)
        {
            var q = AsQueryable();

            return PaginationListAsync(q, query);
        }
    }
}
