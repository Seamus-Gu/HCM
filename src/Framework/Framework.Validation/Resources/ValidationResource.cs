using System.Resources;

namespace Framework.Validation
{
    internal class ValidationResource
    {
        private static readonly ResourceManager _resourceManager = new ResourceManager(typeof(ValidationResource));

        public static string Required => GetString(ValidationErrorEnum.Required.GetName())!;

        /// <summary>
        /// 获取对应的I18N消息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string? GetString(string code)
        {
            return _resourceManager.GetString(code);
        }
    }
}
