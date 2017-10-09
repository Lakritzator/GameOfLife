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

        private static void Start()
        {
#if DEBUG
            LogSettings.RegisterDefaultLogger<DebugLogger>(LogLevels.Verbose);
#else
            // Register a default logger which will forward all log statements to the next default logger, this way nothing is missed.
            LogSettings.RegisterDefaultLogger<ForwardingLogger>(LogLevels.Verbose);
#endif

            var application = new Dapplication("GameOfLife", "DFC9D16F-9BE6-4C34-B161-ECA67E6E1855")
            {
                ShutdownMode = ShutdownMode.OnMainWindowClose
            };
            application.Bootstrapper.FindAndLoadAssemblies("Dapplo.CaliburnMicro*");

            application.Run();
        }
    }
}
