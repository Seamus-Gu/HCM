namespace HCM.Core.Services
{
	/// <summary>
	/// 业务处理层
	/// </summary>
	public class SysUserService : ISysUserService, IScopeService
	{
		private readonly SysUserRepository _sysUserRepository;

		/// <summary>
		/// 构造函数
		/// </summary>
		public SysUserService(SysUserRepository sysUserRepository)
		{
			_sysUserRepository = sysUserRepository;
		}
		
		/// <summary>
		/// 获取分页列表
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public async Task<List<SysUser>> GetSysUserPageList(Pagination query)
		{
			var result = await _sysUserRepository.SelectSysUserPageList(query);
			
			return result;
		}
		
		/// <summary>
		/// 根据Id获取详细信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<SysUser> GetSysUserById(long id)
		{
			var result = await _sysUserRepository.GetByIdAsync(id);
			
			return result;
		}
		
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public async Task<bool> AddSysUser(SysUser entity)
		{
			var result = await _sysUserRepository.InsertAsync(entity);
			
			return result;			
		}
		
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public async Task<bool> EditSysUser(SysUser entity)
		{
			var result = await _sysUserRepository.UpdateAsync(entity);
			
			return result;
		}
		
		/// <summary>
		/// 根据Id删除
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<bool> RemoveSysUserById(long id)
		{
			var result = await _sysUserRepository.DeleteByIdAsync(id);
			
			return result;
		}
	}
}
 