using System.Windows.Controls;

using System.Windows.Markup;
using System.ComponentModel.Composition;

namespace ViewOneModule
{
    /// <summary>
    /// Interaktionslogik für ViewOneModule.xaml
    /// </summary>
    [Export]
    public partial class ViewOneModule : UserControl
    {
        public ViewOneModule()
        {
            InitializeComponent();
        }
    }
}
