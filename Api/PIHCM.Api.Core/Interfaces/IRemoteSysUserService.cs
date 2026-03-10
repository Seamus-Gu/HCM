// <author>Seamus</author>
// <date>2025/7/30 11:54:19/date>
// <description></description>

namespace Seed.Api.Core
{
    public interface IRemoteSysUserService : IRemoteService<IRemoteSysUserService>
    {
        /// <summary>
        /// 通过用户名查询用户信息
        /// </summary>
        /// <param name="username"> 用户名 </param>
        /// <returns> 用户信息 </returns>
        UnaryResult<LoginUser> GetUserInfo(string username);
    }
}