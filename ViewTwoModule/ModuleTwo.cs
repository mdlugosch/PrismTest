using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;

namespace ViewTwoModule
{
      [ModuleExport(typeof(ModuleTwo),
        InitializationMode = InitializationMode.WhenAvailable)]
    public class ModuleTwo : IModule
    {
        private readonly IRegionViewRegistry regionViewRegestry;

        [ImportingConstructor]
        public ModuleTwo(IRegionViewRegistry registry)
        {
            regionViewRegestry = registry;
        }

        public void Initialize()
        {
            regionViewRegestry.RegisterViewWithRegion("ViewTwo", typeof(ViewTwoModule));
        }
    }
}
