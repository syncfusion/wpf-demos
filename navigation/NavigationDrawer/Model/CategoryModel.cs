using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.navigationdemos.wpf
{
    public class Category
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private object icon;
        public object Icon
        {
            get { return icon; }
            set { icon = value; }
        }
    }
}
