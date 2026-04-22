namespace PIHCM.Core.Interfaces
{
	/// <summary>
	/// 角色信息表业务层接口
	/// </summary>
	public interface ISysRoleService
	{
		/// <summary>
		/// 获取角色信息表分页列表
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public Task<List<SysRole>> GetSysRolePageList(Pagination filter);

		/// <summary>
		/// 根据Id获取角色信息表
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<SysRole> GetSysRoleById(long id);
		
		/// <summary>
		/// 新增角色信息表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Task<bool> AddSysRole(SysRole entity);

		/// <summary>
		/// 修改角色信息表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Task<bool> EditSysRole(SysRole entity);
		
		/// <summary>
		/// 删除角色信息表
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<bool> RemoveSysRoleById(long id);
	}
}
  