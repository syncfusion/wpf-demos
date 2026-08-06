using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagramdemo.wpf.Model
{
    public class RadialTreeModel
    {
        public string EmpId { get; set; }
        public string Imageurl { get; set; }
        public string ParentId { get; set; }
    }

    public class RadialTreeModels : ObservableCollection<RadialTreeModel>
    {

    }
}
