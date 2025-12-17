using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagramdemo.wpf.Model
{
    public class HierarchicalLayoutModel
    {
        public string EmpId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string _Color { get; set; }
    }

    public class HierarchicalLayoutModels : ObservableCollection<HierarchicalLayoutModel>
    {

    }
}
