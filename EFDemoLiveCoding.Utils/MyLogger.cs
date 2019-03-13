using System;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Utils
{
    public static class MyLogger
    {
        public static SqlCommandsObserver SqlCommandLogObserver { get; private set; }
        public static void InitializeLogger()
        {
            SqlCommandLogObserver = new SqlCommandsObserver();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Serilog.log")
                .WriteTo.Observers(events => events
                    .Subscribe(SqlCommandLogObserver))
                    .CreateLogger();
        }
    }
}
