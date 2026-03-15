using Seed.Framework.Core;
using Serilog;
using Serilog.Filters;
using Serilog.Sinks.Elasticsearch;

namespace Seed.Framework.Logger
{
    internal static class LoggerBuilder
    {
        public static ILogger CreateLogger()
        {
            var logConfig = App.GetConfig<LogConfig>(FrameworkConstant.LOG_CONFIG);
            var loggerConfiguration = InitLoggerConfiguration();

            if (logConfig.File != null && logConfig.File.Enabled)
            {
                loggerConfiguration.AddFileLog(logConfig.File);
            }

            if (logConfig.ElasticSearch != null && logConfig.ElasticSearch.Enabled)
            {
                loggerConfiguration.AddElastic(logConfig.ElasticSearch);
            }

            return loggerConfiguration.CreateLogger();
        }

        private static LoggerConfiguration InitLoggerConfiguration()
        {
            var config = new LoggerConfiguration()
              .MinimumLevel.Debug() // 捕获的最小日志级别
              .WriteTo.Console();

            return config;
        }

        private static void AddFileLog(this LoggerConfiguration loggerConfiguration, LogFileConfig fileConfig)
        {
            loggerConfiguration
                .WriteTo.File(fileConfig.FilePath,
                    rollingInterval: fileConfig.RollingInterval,
                    outputTemplate: fileConfig.OutPutTemplate,
                    retainedFileCountLimit: fileConfig.MaxRollingFiles,
                    retainedFileTimeLimit: fileConfig.RetainedTimeLimit,
                    rollOnFileSizeLimit: fileConfig.FileSizeLimitBytes != 0,
                    fileSizeLimitBytes: fileConfig.FileSizeLimitBytes
                    );
        }

        private static void AddElastic(this LoggerConfiguration loggerConfiguration, LogElasticSearchConfig elasticSearchConfig)
        {
            loggerConfiguration
              //.Enrich.FromLogContext()
              //.Enrich.WithExceptionDetails()
              //.Enrich.WithMachineName()
              //.Enrich.WithSpan()
              //.Enrich.WithClientIp()
              //.Enrich.WithCorrelationId()
              .Enrich.FromLogContext()
              .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchConfig.Url))
              {
                  AutoRegisterTemplate = true,
                  //IndexFormat = $"{serviceInfo.AssemblyName}-{serviceInfo.EnvironmentName}-{{0:yyyy.MM.dd}}",
                  ModifyConnectionSettings = t => t.BasicAuthentication(elasticSearchConfig.UserName, elasticSearchConfig.Password)
              })
              .Filter.ByExcluding(Matching.WithProperty<string>("RequestPath", x => x == "/api/health"));
        }
    }
}