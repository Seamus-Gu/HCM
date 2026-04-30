namespace HCM.Core.Controller
{
	/// <summary>
	/// 菜单权限表接口层
	/// </summary>
    [ApiRoute("[controller]")]
	public class SysMenuController : BaseController
	{
		private readonly ISysMenuService _sysMenuService;
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public SysMenuController(ISysMenuService sysMenuService)
		{
			_sysMenuService = sysMenuService;
		}
		
		/// <summary>
		/// 获取菜单权限表分页列表
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		[HttpGet("list")]
		public async Task<IActionResult> GetSysMenuPageList([FromQuery] Pagination query)
		{
			var result = await _sysMenuService.GetSysMenuPageList(query);
			return Success(new PageResult<SysMenu>
            {
                Items = result,
                Total = query.Total
            });
		}
			
		/// <summary>
		/// 获取菜单权限表详情信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetSysMenuById(long id)
		{
			var result = await _sysMenuService.GetSysMenuById(id);				

			return Success(result);
		}
			
		/// <summary>
		/// 新增菜单权限表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPost("add")]
		public async Task<IActionResult> AddSysMenu([FromBody] SysMenu entity)
		{
			var result = await _sysMenuService.AddSysMenu(entity);
				
			return BoolResult(result);
		}
			
		/// <summary>
		/// 修改菜单权限表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPut("edit")]
		public async Task<IActionResult> EditSysMenu([FromBody] SysMenu entity)
		{
			var result = await _sysMenuService.EditSysMenu(entity);
			
			return BoolResult(result);
		}
			
		/// <summary>
		/// 删除菜单权限表
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("remove/{id}")]
		public async Task<IActionResult> RemoveSysMenuById(long id)
		{
			var result = await _sysMenuService.RemoveSysMenuById(id);
			
			return BoolResult(result);
		}
	}
}
  