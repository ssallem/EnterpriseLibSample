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
            _logService.Write("첫 로그");
        }
    }
}
