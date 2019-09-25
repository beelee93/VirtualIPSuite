using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualIPSuite.Utilities
{
    public class Logger
    {
        private static Logger _instance = null;
        public static Logger Instance {
            get {
                if (_instance == null) _instance = new Logger();
                return _instance;
            }
        }

        private readonly ILogger _logger;
        public ILogger LogWriter => _logger;

        private Logger()
        {
            var config = new LoggerConfiguration();
            config.MinimumLevel.Verbose();

            if (Settings.LogToFile)
                config.WriteTo.File(Settings.LogFileName, Serilog.Events.LogEventLevel.Information);
            config.WriteTo.Console();

            _logger = config.CreateLogger();
        }
    }
}
