namespace HCM.Core.Controller
{
    /// <summary>
    /// 用户信息表接口层
    /// </summary>
    [ApiRoute("[controller]")]
    public class SysUserController : BaseController
    {
        private readonly ISysUserService _sysUserService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SysUserController(ISysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }

        /// <summary>
        /// 获取用户信息表分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<IActionResult> GetSysUserPageList([FromQuery] Pagination query)
        {
            var result = await _sysUserService.GetSysUserPageList(query);
            return Success(new PageResult<SysUser>
            {
                Items = result,
                Total = query.Total
            });
        }

        /// <summary>
        /// 获取用户信息表详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSysUserById(long id)
        {
            var result = await _sysUserService.GetSysUserById(id);

            return Success(result);
        }

        /// <summary>
        /// 新增用户信息表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> AddSysUser([FromBody] SysUser entity)
        {
            var result = await _sysUserService.AddSysUser(entity);

            return BoolResult(result);
        }

        /// <summary>
        /// 修改用户信息表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("edit")]
        public async Task<IActionResult> EditSysUser([FromBody] SysUser entity)
        {
            var result = await _sysUserService.EditSysUser(entity);

            return BoolResult(result);
        }

        /// <summary>
        /// 删除用户信息表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveSysUserById(long id)
        {
            var result = await _sysUserService.RemoveSysUserById(id);

            return BoolResult(result);
        }
    }
}
