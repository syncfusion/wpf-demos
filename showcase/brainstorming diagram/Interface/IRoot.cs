using syncfusion.brainstormingdiagram.wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.brainstormingdiagram.wpf
{
    public interface IRoot
    {
        ObservableCollection<RootChild> Children { get; set; }
        MindMapNodeStyle NodeStyle { get; set; }

    }
}
