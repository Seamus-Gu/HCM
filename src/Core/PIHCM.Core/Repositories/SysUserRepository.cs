namespace PIHCM.Core.Repositories
{
	/// <summary>
	/// 用户信息表仓储层
	/// </summary>
	public class SysUserRepository : BaseRepository<SysUser>
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public SysUserRepository(ISqlSugarClient context) : base(context)
		{
		}
		
		/// <summary>
		/// 获取用户信息表分页列表
		/// </summary>
		public Task<List<SysUser>> SelectSysUserPageList(Pagination query)
		{
			var q = AsQueryable();

			return PaginationListAsync(q, query);
		}
	}
}
