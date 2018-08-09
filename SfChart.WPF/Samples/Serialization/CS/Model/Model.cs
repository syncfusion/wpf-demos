using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class CategoryData
    {
        public CategoryData(string category, double value)
        {
            Category = category; Value = value;
        }

        public string Category
        {
            get;

            set;

        }

        public double Value
        {
            get;

            set;
        }
    }
}
