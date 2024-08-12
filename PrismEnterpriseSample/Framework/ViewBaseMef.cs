using Microsoft.Practices.ServiceLocation;
using PrismEnterpriseSample.Interface;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace PrismEnterpriseSample.Framework
{
    [Export]
    public class ViewBaseMef : UserControl, IDisposable, INotifyPropertyChanged
    {
        public ViewBaseMef() : base()
        {
        }
        public ViewBaseMef(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
            this.Loaded += ViewBaseMef_Loaded;
        }
        private void ViewBaseMef_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Loaded -= ViewBaseMef_Loaded;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //protected override void OnPropertyChanged([CallerMemberName] string key = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key));
        //}
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #region Services
        protected IServiceLocator serviceLocator;
        protected IEntLibService entLibService { get { return serviceLocator.GetInstance<IEntLibService>(); } }
        protected ILogService logService { get { return serviceLocator.GetInstance<ILogService>(); } }
        #endregion


        public void Write(string message)
        {
            entLibService.Process(() =>
            {
                this.logService.Write(message);
            });
        }
    }
}
