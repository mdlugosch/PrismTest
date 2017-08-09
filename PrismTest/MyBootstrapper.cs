using System.Windows;


using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.ComponentModel.Composition;
using System;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace PrismTest
{
    /* Hier entscheiden wir uns für einen MefBootstrapper
     * für unseren eigenen Bootstrapper
     */ 
    public class MyBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<MainWindow>();
        }
        protected override void ConfigureAggregateCatalog()
        {
            //var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

            var assemblyCatalog = new AssemblyCatalog(typeof(MyBootstrapper).Assembly);
            AggregateCatalog.Catalogs.Add(assemblyCatalog);

            assemblyCatalog = new AssemblyCatalog(typeof(ViewOneModule.ModuleOne).Assembly);
            AggregateCatalog.Catalogs.Add(assemblyCatalog);

            assemblyCatalog = new AssemblyCatalog(typeof(ViewTwoModule.ModuleTwo).Assembly);
            AggregateCatalog.Catalogs.Add(assemblyCatalog);

            assemblyCatalog = new AssemblyCatalog(typeof(ViewThreeModule.ModuleThree).Assembly);
            AggregateCatalog.Catalogs.Add(assemblyCatalog);

            assemblyCatalog = new AssemblyCatalog(typeof(ViewFourModule.ModuleFour).Assembly);
            AggregateCatalog.Catalogs.Add(assemblyCatalog);

            base.ConfigureAggregateCatalog();
        }
        
        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (MainWindow)Shell;
            Application.Current.MainWindow.Show();          
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings regionAdapterMappings = base.ConfigureRegionAdapterMappings();
            var regionBehaviourFactory = Container.GetExportedValue<IRegionBehaviorFactory>();
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), new StackPanelRegionAdapter(regionBehaviourFactory));

            return regionAdapterMappings;
         
        }
        
    }
}
