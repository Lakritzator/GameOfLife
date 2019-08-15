using System;
using System.Windows;
using Dapplo.Addons.Bootstrapper;
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
            var applicationConfig = ApplicationConfigBuilder
                .Create()
                .WithApplicationName("GameOfLife")
                .WithMutex("DFC9D16F-9BE6-4C34-B161-ECA67E6E1855")
                .BuildApplicationConfig();

            var application = new Dapplication(applicationConfig)
            {
                ShutdownMode = ShutdownMode.OnLastWindowClose
            };
            application.Run();
        }
    }
}
