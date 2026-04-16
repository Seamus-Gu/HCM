using Microsoft.AspNetCore.Mvc;

namespace Framework.Core
{
    public class ApiRouteAttribute : RouteAttribute
    {
        public ApiRouteAttribute(string template) : base($"v{{version:apiVersion}}/{template.TrimStart('/')}")
        {
        }
    }
}
