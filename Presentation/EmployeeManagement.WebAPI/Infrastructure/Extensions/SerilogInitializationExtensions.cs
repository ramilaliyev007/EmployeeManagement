using Serilog;

namespace EmployeeManagement.WebAPI.Infrastructure.Extensions
{
    public static class SerilogInitializationExtensions
    {
        public static void AddSerilog(this WebApplicationBuilder builder)
        {
            var logger = new LoggerConfiguration().MinimumLevel.Warning()
                                                  .ReadFrom
                                                  .Configuration(builder.Configuration).Enrich
                                                  .FromLogContext()
                                                  .CreateLogger();

            builder.Logging.AddSerilog(logger);
        }

        public static void SetStartupLogger(this Serilog.ILogger logger)
        {
            Serilog.Log.Logger = new LoggerConfiguration().WriteTo.Console()
                                                          .WriteTo.File(path: "logs/startup/EmployeeManagement-.log",
                                                                        rollingInterval: RollingInterval.Day,
                                                                        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] - {Message:lj} {NewLine} {Exception} {NewLine}")
                                                           .CreateLogger();
        }
    }
}
