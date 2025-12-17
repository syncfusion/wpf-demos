using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagramdemo.wpf.Model
{
    public class MultiParentModel
    {
        public MultiParentModel(string name, string color)
        {
            this.Name = name;
            this.RatingColor = color;
        }

        public string RatingColor { get; set; }

        public string Name { get; set; }

        public List<string> ReportingPerson { get; set; }
    }

    public class MultiParentModels : ObservableCollection<MultiParentModel>
    {

    }
}
