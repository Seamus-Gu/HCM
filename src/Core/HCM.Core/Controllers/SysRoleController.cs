namespace HCM.Core.Controller
{
	/// <summary>
	/// 角色信息表接口层
	/// </summary>
    [ApiRoute("[controller]")]
	public class SysRoleController : BaseController
	{
		private readonly ISysRoleService _sysRoleService;
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public SysRoleController(ISysRoleService sysRoleService)
		{
			_sysRoleService = sysRoleService;
		}
		
		/// <summary>
		/// 获取角色信息表分页列表
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		[HttpGet("list")]
		public async Task<IActionResult> GetSysRolePageList([FromQuery] Pagination query)
		{
			var result = await _sysRoleService.GetSysRolePageList(query);
			return Success(new PageResult<SysRole>
            {
                Items = result,
                Total = query.Total
            });
		}
			
		/// <summary>
		/// 获取角色信息表详情信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetSysRoleById(long id)
		{
			var result = await _sysRoleService.GetSysRoleById(id);				

			return Success(result);
		}
			
		/// <summary>
		/// 新增角色信息表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPost("add")]
		public async Task<IActionResult> AddSysRole([FromBody] SysRole entity)
		{
			var result = await _sysRoleService.AddSysRole(entity);
				
			return BoolResult(result);
		}
			
		/// <summary>
		/// 修改角色信息表
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPut("edit")]
		public async Task<IActionResult> EditSysRole([FromBody] SysRole entity)
		{
			var result = await _sysRoleService.EditSysRole(entity);
			
			return BoolResult(result);
		}
			
		/// <summary>
		/// 删除角色信息表
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("remove/{id}")]
		public async Task<IActionResult> RemoveSysRoleById(long id)
		{
			var result = await _sysRoleService.RemoveSysRoleById(id);
			
			return BoolResult(result);
		}
	}
}
  