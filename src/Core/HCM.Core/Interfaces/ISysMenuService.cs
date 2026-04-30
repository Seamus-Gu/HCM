namespace HCM.Core.Interfaces
{
	/// <summary>
	/// 菜单权限表业务层接口
	/// </summary>
	public interface ISysMenuService
	{
		/// <summary>
		/// 获取菜单权限表分页列表
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public Task<List<SysMenu>> GetSysMenuPageList(Pagination filter);

		/// <summary>
		/// 根据Id获取菜单权限表
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<SysMenu> GetSysMenuById(long id);
		
		/// <summary>
		/// 新增菜单权限表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Task<bool> AddSysMenu(SysMenu entity);

		/// <summary>
		/// 修改菜单权限表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Task<bool> EditSysMenu(SysMenu entity);
		
		/// <summary>
		/// 删除菜单权限表
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<bool> RemoveSysMenuById(long id);
	}
}
  