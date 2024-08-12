using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.Prism.Logging;
using PrismEnterpriseSample.Interface;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace SioDepolyment.Services.EnterLib
{
    [Export(typeof(ILogService))]
    public class LogService : ILogService
    {
        [ImportingConstructor]
        public LogService() { }

        public void Write(string message) => Logger.Writer?.Write(message);

        public void Write(string message, string categoryName) => Logger.Writer?.Write(message, categoryName);

        public void Write(string message, Category category, Priority priority) => Logger.Writer?.Write(message, category.ToString(), (int)priority);
        public void Write(string message, string category, int priority, int eventId, TraceEventType severity)
        {
            Logger.Writer?.Write(message, category, priority, eventId, severity);
        }

        public void Write(string message, string categoryName, string workspaceName, string pid, string ipaddr, string userId)
        {
            if (Logger.Writer != null)
            {
                LogEntry logEntry = new LogEntry()
                {
                    Categories = new List<string> { categoryName },
                    Priority = -1,
                    Severity = System.Diagnostics.TraceEventType.Information,

                };
            }
        }

    }
}
