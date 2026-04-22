namespace PIHCM.Core.Interfaces
{
	/// <summary>
	/// 用户信息表业务层接口
	/// </summary>
	public interface ISysUserService
	{
		/// <summary>
		/// 获取用户信息表分页列表
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public Task<List<SysUser>> GetSysUserPageList(Pagination filter);

		/// <summary>
		/// 根据Id获取用户信息表
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<SysUser> GetSysUserById(long id);
		
		/// <summary>
		/// 新增用户信息表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Task<bool> AddSysUser(SysUser entity);

		/// <summary>
		/// 修改用户信息表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Task<bool> EditSysUser(SysUser entity);
		
		/// <summary>
		/// 删除用户信息表
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<bool> RemoveSysUserById(long id);
	}
}
  