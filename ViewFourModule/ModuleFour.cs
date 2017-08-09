using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace ViewFourModule
{
    [ModuleExport(typeof(ModuleFour),
        InitializationMode = InitializationMode.WhenAvailable)]
    public class ModuleFour : IModule
    {
        private readonly IRegionViewRegistry regionViewRegestry;

        [ImportingConstructor]
                public ModuleFour(IRegionViewRegistry registry)
        {
            regionViewRegestry = registry;
        }

        public void Initialize()
        {
            regionViewRegestry.RegisterViewWithRegion("ViewFour", typeof(ViewFourModule));
        }
    }
}
