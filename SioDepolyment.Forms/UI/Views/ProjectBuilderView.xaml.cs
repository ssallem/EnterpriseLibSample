using DevExpress.Xpf.Core;
using DevExpress.Xpf.Dialogs;
using Microsoft.Practices.ServiceLocation;
using PrismEnterpriseSample.Framework;
using System.ComponentModel.Composition;
using System.Windows;

namespace SioDepolyment.Forms.UI.Views
{
    /// <summary>
    /// ProjectBuilderView.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ProjectBuilderView : ViewBaseMef
    {
        [ImportingConstructor]
        public ProjectBuilderView(IServiceLocator serviceLocator) : base(serviceLocator)
        {
            InitializeComponent();
        }

        public ProjectBuilderView()
        {
            InitializeComponent();
            ApplicationThemeHelper.ApplicationThemeName = Theme.Office2016ColorfulFullName;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private DXOpenFileDialog GetFolderBrowserDialog()
        {
            return new DXOpenFileDialog()
            {
                InitialDirectory = @"C:\",
                Title = "이동배치 솔루션(.sln) 폴더 경로 선택",
                OpenFileDialogMode = OpenFileDialogMode.Folders,
            };
        }

        private void btnDirectory_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowser = GetFolderBrowserDialog();

            if (folderBrowser.ShowDialog().Value)
            {
                txtTeamSolutionDirectory.Text = folderBrowser.FileName;
            }
        }
    }
}
