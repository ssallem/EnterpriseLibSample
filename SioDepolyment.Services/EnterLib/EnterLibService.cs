using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using PrismEnterpriseSample.Interface;
using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Data.Common;

namespace SioDepolyment.Services.EnterLib
{
    [Export(typeof(IEntLibService))]

    public class EnterLibService : IEntLibService
    {
        private TraceManager traceManager;

        public Microsoft.Practices.EnterpriseLibrary.Logging.TraceManager TraceMgr { get => traceManager; set => traceManager = value; }

        private ExceptionManager exceptionManager;
        public Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionManager ExceptionMgr { get => exceptionManager; set => exceptionManager = value; }

        [ImportingConstructor]
        public EnterLibService()
        {
            try
            {
                traceManager = new TraceManager(Logger.Writer);
                IConfigurationSource config = ConfigurationSourceFactory.Create();
                ExceptionPolicyFactory exFactory = new ExceptionPolicyFactory(config);
                exceptionManager = exFactory.CreateManager();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DebugTraceLog(string message)
        {
            Logger.Write(message, "Debug");
        }

        public string DebugTraceQuery(DbCommand dbCommand)
        {
            throw new NotImplementedException();
        }

        public void Process(Action action)
        {
            exceptionManager.Process(action, ConfigurationManager.AppSettings["AppDefaultExceptionPolicy"].ToString());
        }

        public void Process(Action action, string policyName)
        {
            exceptionManager.Process(action, policyName);
        }

        public TResult Process<TResult>(Func<TResult> action)
        {
            return exceptionManager.Process(action, ConfigurationManager.AppSettings["AppDefaultExceptionPolicy"].ToString());
        }

        public TResult Process<TResult>(Func<TResult> action, string policyName)
        {
            return exceptionManager.Process(action, policyName);
        }
    }
}
