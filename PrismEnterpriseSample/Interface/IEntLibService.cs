using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Data.Common;

namespace PrismEnterpriseSample.Interface
{
    public interface IEntLibService
    {
        TraceManager TraceMgr { get; set; }

        ExceptionManager ExceptionMgr { get; set; }

        void Process(Action action);
        void Process(Action action, string policyName);

        TResult Process<TResult>(Func<TResult> action);
        TResult Process<TResult>(Func<TResult> action, string policyName);
        void DebugTraceLog(string message);
        string DebugTraceQuery(DbCommand dbCommand);
    }
}
