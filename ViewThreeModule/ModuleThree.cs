using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewThreeModule
{
    [ModuleExport(typeof(ModuleThree),
       InitializationMode = InitializationMode.WhenAvailable)]
    [Export]
    public class ModuleThree : IModule
    {
         private readonly IRegionViewRegistry regionViewRegestry;

        [ImportingConstructor]
        public ModuleThree(IRegionViewRegistry registry)
        {
            regionViewRegestry = registry;
        }

        public void Initialize()
        {
            regionViewRegestry.RegisterViewWithRegion("ViewThree", typeof(ViewThreeModule));
        }
    }
}
