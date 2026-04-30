// <author>Seamus</author>
// <date>2025/8/11 14:54:21</date>
// <description></description>

using Newtonsoft.Json;
using Ocelot.Logging;
using Ocelot.Responder;
using Polly;

namespace Seed.Gateway.Middleware
{
    public class ExceptionHandlingMiddleware : OcelotMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpResponder _responder;
        private readonly IErrorsToHttpStatusCodeMapper _codeMapper;

        public ExceptionHandlingMiddleware(
            RequestDelegate next
            , IHttpResponder responder
            , IErrorsToHttpStatusCodeMapper codeMapper
            , IOcelotLoggerFactory loggerFactory
            )
            : base(loggerFactory.CreateLogger<ExceptionHandlingMiddleware>())
        {
            _next = next;
            _responder = responder;
            _codeMapper = codeMapper;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next.Invoke(httpContext);
            if (httpContext.Response.HasStarted)
                return;

            var errors = httpContext.Items.Errors();
            if (errors.Count > 0)
            {
                var statusCode = _codeMapper.Map(errors);
                var errorMsg = string.Join(";", errors.Select(x => x.Message));
                httpContext.Response.StatusCode = statusCode;

                var response = new Result()
                {
                    Code = 400,
                    Message = errorMsg
                };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
            else
            {
                var downstreamResponse = httpContext.Items.DownstreamResponse();

                await _responder.SetResponseOnHttpContext(httpContext, downstreamResponse);
            }
        }
    }
}