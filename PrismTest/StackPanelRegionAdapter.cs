using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismTest
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory factory) : base(factory)
        { }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) => 
            {
                if(e.Action == NotifyCollectionChangedAction.Add) 
                {
                    foreach(FrameworkElement element in e.NewItems) 
                    {
                        regionTarget.Children.Add(element);
                    }
                } 
            
                //implement remove missing
            };
        }

        protected override IRegion CreateRegion()
        {
            // SingleActiveRegion for one item.
            return new AllActiveRegion();
        }
    }
}
