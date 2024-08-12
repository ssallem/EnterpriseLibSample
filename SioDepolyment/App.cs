using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Diagnostics;
using System.Windows;

namespace SioDepolyment
{
    internal class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            initialize();
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

        private void initialize()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            InitEntLib6();
        }

        private void InitEntLib6()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            Logger.SetLogWriter(new LogWriterFactory().Create());
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            ExceptionPolicyFactory exFactory = new ExceptionPolicyFactory(config);
            ExceptionPolicy.SetExceptionManager(exFactory.CreateManager());
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is System.Exception)
            {
                Debug.WriteLine(e.ExceptionObject.ToString());
            }
        }
    }
}
