using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;

namespace ViewOneModule
{
    [ModuleExport(typeof(ModuleOne),
        InitializationMode=InitializationMode.WhenAvailable)]
    [Export]
    public class ModuleOne : IModule
    {
        private readonly IRegionViewRegistry regionViewRegestry;

        [ImportingConstructor]
        public ModuleOne(IRegionViewRegistry registry)
        {
            regionViewRegestry = registry;
        }

        public void Initialize()
        {
            regionViewRegestry.RegisterViewWithRegion("ViewOne", typeof(ViewOneModule));
        }
    }
}
