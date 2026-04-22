namespace PIHCM.Core.Services
{
	/// <summary>
	/// 业务处理层
	/// </summary>
	public class SysRoleService : ISysRoleService, IScopeService
	{
		private readonly SysRoleRepository _sysRoleRepository;

		/// <summary>
		/// 构造函数
		/// </summary>
		public SysRoleService(SysRoleRepository sysRoleRepository)
		{
			_sysRoleRepository = sysRoleRepository;
		}
		
		/// <summary>
		/// 获取分页列表
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public async Task<List<SysRole>> GetSysRolePageList(Pagination query)
		{
			var result = await _sysRoleRepository.SelectSysRolePageList(query);
			
			return result;
		}
		
		/// <summary>
		/// 根据Id获取详细信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<SysRole> GetSysRoleById(long id)
		{
			var result = await _sysRoleRepository.GetByIdAsync(id);
			
			return result;
		}
		
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public async Task<bool> AddSysRole(SysRole entity)
		{
			var result = await _sysRoleRepository.InsertAsync(entity);
			
			return result;			
		}
		
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public async Task<bool> EditSysRole(SysRole entity)
		{
			var result = await _sysRoleRepository.UpdateAsync(entity);
			
			return result;
		}
		
		/// <summary>
		/// 根据Id删除
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<bool> RemoveSysRoleById(long id)
		{
			var result = await _sysRoleRepository.DeleteByIdAsync(id);
			
			return result;
		}
	}
}
 