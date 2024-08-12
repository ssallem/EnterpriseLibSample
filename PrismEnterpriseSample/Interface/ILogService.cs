using Microsoft.Practices.Prism.Logging;
using System.Diagnostics;

namespace PrismEnterpriseSample.Interface
{
    public interface ILogService
    {
        void Write(string message);
        void Write(string message, string categoryName);
        void Write(string message, Category category, Priority priority);

        void Write(string message, string category, int priority, int eventId, TraceEventType severity);

        void Write(string message, string categoryName, string workspaceName, string pid, string ipaddr, string userId);
    }
}
