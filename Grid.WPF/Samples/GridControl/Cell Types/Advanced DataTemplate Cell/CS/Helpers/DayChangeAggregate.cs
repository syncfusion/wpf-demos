using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Data;

namespace PortfolioManager1.Helpers
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
