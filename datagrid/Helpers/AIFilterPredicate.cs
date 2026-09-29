using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Represents a filter predicate applied to a specific column in a data set.
    /// </summary>
    /// <remarks>
    /// This class is used to encapsulate the details of a filter operation, including the column to which the filter applies 
    /// and the specific predicate that defines the filter criteria.
    /// </remarks>
    public class AIFilterPredicate
    {
        /// <summary>
        /// Gets or sets the name of the column to which the filter predicate is applied.
        /// </summary>
        /// <value>The name of the column.</value>
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the filter predicate that defines the criteria for filtering the data.
        /// </summary>
        /// <value>The filter predicate.</value>
        public FilterPredicate FilterPredicate { get; set; }
    }
}
