#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;

namespace PortfolioManager1.Behaviors
{
    public class QueryCellInfoBehavior : Behavior<GridDataControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }

        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            var style = e.Style as GridDataStyleInfo;
            if (style != null)
            {
                var tableStyleIdentity = style.CellIdentity;
                if (tableStyleIdentity.TableCellType == GridDataTableCellType.GroupCaptionSummaryRecordCell)
                {
                    if (tableStyleIdentity.SummaryColumn != null && tableStyleIdentity.SummaryColumn.Name == "TotalRet")
                    {
                        var value = this.AssociatedObject.Model.GetGroupCaptionSummary(tableStyleIdentity.Group, tableStyleIdentity.SummaryColumn);
                        double result;
                        Double.TryParse(value["Sum"].ToString(), out result);
                        if (result < 0)
                        {
                            e.Style.Foreground = Brushes.Red;
                        }
                        else
                        {
                            e.Style.Foreground = Brushes.Green;
                        }
                    }
                    else if (tableStyleIdentity.SummaryColumn != null && tableStyleIdentity.SummaryColumn.Name == "QuoteChange")
                    {
                        var value = this.AssociatedObject.Model.GetGroupCaptionSummary(tableStyleIdentity.Group, tableStyleIdentity.SummaryColumn);
                        double result;
                        Double.TryParse(value["DayChange"].ToString(), out result);
                        if (result < 0)
                        {
                            e.Style.Foreground = Brushes.Red;
                        }
                        else
                        {
                            e.Style.Foreground = Brushes.Green;
                        }
                    }
                }
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }
    }
}
