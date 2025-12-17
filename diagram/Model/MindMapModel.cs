using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagramdemo.wpf.Model
{
    public class MindmapEmployee
    {
        public string EmpId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public RootChildDirection Direction { get; set; }
    }

    public class MindmapEmployees : ObservableCollection<MindmapEmployee>
    {

    }
}
