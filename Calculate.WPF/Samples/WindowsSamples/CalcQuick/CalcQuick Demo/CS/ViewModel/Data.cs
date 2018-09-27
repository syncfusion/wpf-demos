using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSample
{
    public class Data
    {
        #region BindItem
        /// <summary>
        /// Add BindItem List collection
        /// </summary>
        public List<string> BindItem()
        {
            List<string> lt=new List<string>();
            lt.Add("WidgetA");
            lt.Add("WidgetB");
            lt.Add("WidgetC");
            return lt;
        }

        #endregion

        #region BindDiscount
        /// <summary>
        /// Add BindDiscount List items
        /// </summary>
        public List<string> BindDiscount()
        {
            List<string> lt = new List<string>();
            lt.Add("1%");
            lt.Add("2%");
            lt.Add("3%");
            lt.Add("5%");
            lt.Add("10%");
            lt.Add("20%");
            return lt;
        }

        #endregion
    }
}
