using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.brainstormingdiagram.wpf
{
    public interface IMindMapNodeStyle
    {
        StyleId StyleId { get; set; }
        string Shape { get; set; }
    }
}
