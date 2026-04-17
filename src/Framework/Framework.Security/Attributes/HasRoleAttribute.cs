namespace Framework.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HasRoleAttribute : Attribute
    {
        public HasRoleAttribute(string[] authCodes)
        {
            this.AuthCodes = authCodes;
        }

        /// <summary>
        /// 权限代码
        /// </summary>
        public string[] AuthCodes { get; }
    }
}
