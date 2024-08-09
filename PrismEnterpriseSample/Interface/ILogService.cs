using Microsoft.Practices.Prism.Logging;

namespace PrismEnterpriseSample.Interface
{
    public interface ILogService
    {
        void Write(string message);
        void Write(string message, string categoryName);
        void Write(string message, Category category, Priority priority);

        void Write(string message, string categoryName, string workspaceName, string pid, string ipaddr, string userId);
    }
}
