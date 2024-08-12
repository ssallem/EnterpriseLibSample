using PrismEnterpriseSample.Interface;
using System.ComponentModel.Composition;
using System.Windows;

namespace PrismEnterpriseSample
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export(typeof(MainWindow))]
    public partial class MainWindow : Window
    {
        private readonly ILogService _logService;

        [ImportingConstructor]
        public MainWindow(ILogService logService)
        {
            InitializeComponent();
            _logService = logService;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            _logService.Write("Information -- Optimize", "Optimize", 3, 2000, System.Diagnostics.TraceEventType.Information);
            _logService.Write("Error -- Optimize", "Optimize", 3, 2000, System.Diagnostics.TraceEventType.Error);
            _logService.Write("Warning -- test", "Warning", 3, 2000, System.Diagnostics.TraceEventType.Warning);
        }
    }
}
