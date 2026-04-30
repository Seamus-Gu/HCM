namespace HCM.Core.Services
{
	/// <summary>
	/// 业务处理层
	/// </summary>
	public class SysMenuService : ISysMenuService, IScopeService
	{
		private readonly SysMenuRepository _sysMenuRepository;

		/// <summary>
		/// 构造函数
		/// </summary>
		public SysMenuService(SysMenuRepository sysMenuRepository)
		{
			_sysMenuRepository = sysMenuRepository;
		}
		
		/// <summary>
		/// 获取分页列表
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public async Task<List<SysMenu>> GetSysMenuPageList(Pagination query)
		{
			var result = await _sysMenuRepository.SelectSysMenuPageList(query);
			
			return result;
		}
		
		/// <summary>
		/// 根据Id获取详细信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<SysMenu> GetSysMenuById(long id)
		{
			var result = await _sysMenuRepository.GetByIdAsync(id);
			
			return result;
		}
		
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public async Task<bool> AddSysMenu(SysMenu entity)
		{
			var result = await _sysMenuRepository.InsertAsync(entity);
			
			return result;			
		}
		
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public async Task<bool> EditSysMenu(SysMenu entity)
		{
			var result = await _sysMenuRepository.UpdateAsync(entity);
			
			return result;
		}
		
		/// <summary>
		/// 根据Id删除
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<bool> RemoveSysMenuById(long id)
		{
			var result = await _sysMenuRepository.DeleteByIdAsync(id);
			
			return result;
		}
	}
}
 