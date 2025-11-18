using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.pivotgriddemos.wpf
{
    public class MonthComparer : IComparer
    {
        Dictionary<string, int> lookUp;
        string fmt;

        public MonthComparer(string format)
        {
            this.fmt = string.Format("{{0:{0}}}", format);
            this.lookUp = new Dictionary<string, int>();
            DateTime dt0 = DateTime.Now;
            for (int i = 1; i <= 12; ++i)
            {
                DateTime dt = dt0.AddMonths(i - dt0.Month);
                this.lookUp.Add(string.Format(this.fmt, dt), i);
            }
        }

        public int Compare(object x, object y)
        {
            DateTime x1, y1;
            if (DateTime.TryParse(x.ToString(), out x1) && DateTime.TryParse(y.ToString(), out y1))
            {
                x = string.Format(this.fmt, x1);
                y = string.Format(this.fmt, y1);
            }

            return this.lookUp[x.ToString()].CompareTo(this.lookUp[y.ToString()]);
        }
    }
}
