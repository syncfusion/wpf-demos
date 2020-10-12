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
using System.Threading.Tasks;
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;

namespace syncfusion.datagriddemos.wpf
{
   public class DataGridGroupColumnChangingBehavior : Behavior<SfDataGrid>
    {
       protected override void OnAttached()
       {
           this.AssociatedObject.GroupColumnDescriptions.CollectionChanged += GroupColumnDescriptions_CollectionChanged;
       }

       /// <summary>
       /// GroupColumnDescription collection Event Helps to Add or Remove the Columns To Grouping.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       void GroupColumnDescriptions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
       {
           if (e.NewItems != null)
           {
               var groupDesc = e.NewItems[0] as GroupColumnDescription;
                
               if (groupDesc.ColumnName == "OrderID")
               {
                   groupDesc.Converter = new GridNumericRangeConverter() { GroupInterval = 10 };
                   groupDesc.Comparer = new CustomGroupNumericComparer();
               }
               if (groupDesc.ColumnName == "CustomerID")
               {
                   groupDesc.Converter = new GridTextRangeConverter();
                   groupDesc.Comparer = new CustomGroupTextComparer();
               }               
               if (groupDesc.ColumnName == "OrderDate")
               {
                   groupDesc.Converter = new GridDateTimeRangeConverter() { GroupMode=DateGroupingMode.Month };
                   groupDesc.Comparer = new CustomGroupDateTimeComparer() { GroupMode = DateGroupingMode.Month };
               }
               if (groupDesc.ColumnName == "Freight")
               {
                   groupDesc.Converter = new GridNumericRangeConverter() { GroupInterval = 10 };
                   groupDesc.Comparer = new CustomGroupNumericComparer();
               }
           }
       }

       protected override void OnDetaching()
       {
           this.AssociatedObject.GroupColumnDescriptions.CollectionChanged -= GroupColumnDescriptions_CollectionChanged;
       }
    }
}
