using System;
using System.Windows;
using Dapplo.CaliburnMicro.Dapp;
using Dapplo.Log;
using Dapplo.Log.Loggers;

namespace GameOfLife
{
    static class Startup
    {
        /// <summary>
        /// Start the application
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Start();
        }

        public static void Start()
        {
#if DEBUG
            LogSettings.RegisterDefaultLogger<DebugLogger>(LogLevels.Verbose);
#else
            // Register a default logger which will forward all log statements to the next default logger, this way nothing is missed.
            LogSettings.RegisterDefaultLogger<ForwardingLogger>(LogLevels.Verbose);
#endif

            var application = new Dapplication("GetMyLogs", "a5f6aa70-b899-4691-a9ac-94f86b7eb555")
            {
                ShutdownMode = ShutdownMode.OnMainWindowClose
            };
            application.Bootstrapper.FindAndLoadAssemblies("Dapplo.CaliburnMicro*");

            application.Run();
        }
    }
}
