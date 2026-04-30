namespace HCM.Core.Repositories
{
	/// <summary>
	/// 菜单权限表仓储层
	/// </summary>
	public class SysMenuRepository : BaseRepository<SysMenu>
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public SysMenuRepository(ISqlSugarClient context) : base(context)
		{
		}
		
		/// <summary>
		/// 获取菜单权限表分页列表
		/// </summary>
		public Task<List<SysMenu>> SelectSysMenuPageList(Pagination query)
		{
			var q = AsQueryable();

			return PaginationListAsync(q, query);
		}
	}
}
