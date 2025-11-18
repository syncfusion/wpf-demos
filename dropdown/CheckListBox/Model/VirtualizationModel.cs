using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.dropdowndemos.wpf
{
    public class Model
    {
        public string Name { get; set; }

        public string GroupName { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
