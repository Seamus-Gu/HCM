// <author>Seamus</author>
// <date>2025/8/8 14:47:05</date>
// <description></description>

namespace Seed.Core.Entities
{
    /// <summary>
    /// 登录日志
    /// </summary>
    public class SysLoginInfo : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(ColumnName = "ip_address")]
        public string IPAddress { get; set; } = string.Empty;

        /// <summary>
        /// 设备类型
        /// </summary>
        public DeviceEnum DeviceType { get; set; }

        /// <summary>
        /// 登录状态 0 成功 1 失败
        /// </summary>
        public StatusEnum Status { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
    }
}