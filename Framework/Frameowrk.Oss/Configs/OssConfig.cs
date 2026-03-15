namespace Seed.Framework.Oss
{
    public class OssConfig
    {
        /// <summary>
        /// 允许的文件扩展名
        /// </summary>
        public List<string> ValidExtensions { get; set; } = new List<string>()
        {
            ".jpeg",
            ".jpg",
            ".png",
            ".doc",
        };

        #region Minio

        /// <summary>
        /// 桶名称,可根据业务扩展多个桶
        /// </summary>
        public string Bucket { get; set; } = string.Empty;

        /// <summary>
        /// 访问地址
        /// </summary>
        public string GetUrl { get; set; } = string.Empty;

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connection { get; set; } = string.Empty;

        /// <summary>
        /// 连接服务Key
        /// </summary>
        public string AccessKey { get; set; } = string.Empty;

        /// <summary>
        /// 连接服务Secret
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;

        #endregion Minio
    }
}