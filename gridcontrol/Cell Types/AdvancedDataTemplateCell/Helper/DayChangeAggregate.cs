#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Data;

namespace syncfusion.gridcontroldemos.wpf
{
    public class DayChangeAggregate : ISummaryAggregate
    {
        public DayChangeAggregate()
        {
        }

        public double DayChange
        {
            get;
            set;
        }

        #region IGridDataSummaryAggregate Members

        public Action<System.Collections.IEnumerable, string, System.ComponentModel.PropertyDescriptor> CalculateAggregateFunc()
        {
            return (items, property, pd) =>
            {
                // type cast to the underlying source, so we get to call the LINQ method directly
                var enumerableItems = items as IEnumerable<Queries.CurrentHoldings>;
                if (pd.Name == "DayChange")
                {
                    this.DayChange = enumerableItems.DayChange<Queries.CurrentHoldings>(q => q.DayChange);
                }
            };
        }

        #endregion
    }

    public static class LinqExtensions
    {
        public static double DayChange<T>(this IEnumerable<T> values, Func<T, double?> selector)
        {
            double ret = 0;
            if (values != null && values.Count() > 0)
            {
                ret = values.Select(selector).Sum(d =>
                {
                    if (d.HasValue)
                    {
                        return d.Value;
                    }
                    return 0.0;
                });
            }

            return ret;
        }
    }
}
