using Microsoft.Practices.Prism.MefExtensions;
using PrismEnterpriseSample;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;

namespace SioDepolyment
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            try
            {
                //var exports = Container.GetExport<MainWindow>();
                //var exportDebugs = Container.Catalog;
                //var list = exportDebugs.GetEnumerator();

                return Container.GetExportedValue<MainWindow>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override CompositionContainer CreateContainer()
        {
            var container = base.CreateContainer();
            var batch = new CompositionBatch();
            batch.AddExportedValue(container);
            container.Compose(batch);

            return container;
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            try
            {
                // add this assembly
                AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));

                // add other assembly
                AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Services.EnterLib.LogService).Assembly));
                AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Services.EnterLib.EnterLibService).Assembly));
                AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MainWindow).Assembly));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
