using syncfusion.brainstormingdiagram.wpf.ViewModel;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.brainstormingdiagram.wpf
{
    public interface IRootChild
    {
        RootChildDirection Direction { get; }
        RootChildDirection RenderedDirection { get; set; }
        
        ObservableCollection<Child> Children { get; set; }
        MindMapNodeStyle NodeStyle { get; set; }
    }
}
