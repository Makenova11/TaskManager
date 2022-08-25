namespace TaskManager.Settings
{
    using System;

    using Microsoft.Extensions.Configuration;

    using Serilog;
    using Serilog.Core;
    using Serilog.Debugging;

    /// <summary>
    ///   Settings of logging.
    /// </summary>
    internal static class LogSetting
    {
        /// <summary>
        ///   Set Serilog.
        /// </summary>
        /// <param name="configuration"> Configuration with serilog settings. </param>
        /// <returns> Logger. </returns>
        public static ILogger SetSerilog(IConfigurationRoot configuration)
        {
            Log.Logger = GetLogger(configuration);

            SelfLog.Enable(s => Console.WriteLine($"Internal Error with Serilog: {s}"));

            return Log.Logger;
        }

        /// <summary>
        ///   Logger building.
        /// </summary>
        /// <param name="configuration"> Configuration with serilog settings. </param>
        /// <returns> Logger. </returns>
        private static Logger GetLogger(IConfiguration configuration)
        {
            var loggerConfiguration = new LoggerConfiguration()
                .ReadFrom
                .Configuration(configuration);
            loggerConfiguration.WriteTo.File("log.txt", fileSizeLimitBytes: null);

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
