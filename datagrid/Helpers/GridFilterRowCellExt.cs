#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.UI.Xaml.Grid.RowFilter;

namespace syncfusion.datagriddemos.wpf
{
    public class GridFilterRowCellExt : GridFilterRowCell
    {
        public GridFilterRowCellExt()
            : base()
        { }

        /// <summary>
        /// Opens the FilterOptionPopup with the FilterOptionList.
        /// </summary>
        public override void OpenFilterOptionPopup()
        {
            base.OpenFilterOptionPopup();

            if (this.FilterOptionButtonVisibility == System.Windows.Visibility.Collapsed ||
                this.DataColumn.GridColumn.MappingName != "ShipAddress")
                return;
            
            var list = this.OptionsList();
            if (list.Count > 0)
            {
                this.FilterOptionsList.ItemsSource = list;
                this.FilterOptionsList.SelectedItem = GetFilterRowCondition(this.ColumnBase.GridColumn.FilterRowCondition);
            }
        }


        /// <summary>
        /// Populates the FilterOption list which will loaded in FilterOptionPopup for ShipAddress.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<string> OptionsList()
        {
            var list = new ObservableCollection<string>();
            list.Add(GridResourceWrapper.Equalss);
            list.Add(GridResourceWrapper.NotEquals);
            list.Add(GridResourceWrapper.BeginsWith);
            list.Add(GridResourceWrapper.EndsWith);
            list.Add(GridResourceWrapper.Contains);
            return list;
        }

        /// <summary>
        /// Get the FilerRowCondition for set the SelectedItem for FilterOptionsList
        /// </summary>
        /// <param name="filterType"></param>
        /// <returns></returns>
        public string GetFilterRowCondition(FilterRowCondition filterType)
        {
            if (filterType == FilterRowCondition.Equals)
                return GridResourceWrapper.Equalss;
            else if (filterType == FilterRowCondition.NotEquals)
                return GridResourceWrapper.NotEquals;
            else if (filterType == FilterRowCondition.BeginsWith)
                return GridResourceWrapper.BeginsWith;
            else if (filterType == FilterRowCondition.EndsWith)
                return GridResourceWrapper.EndsWith;
            else
                return GridResourceWrapper.Contains;
        }
    }

    public class CustomRowGenerator : RowGenerator
    {
        public CustomRowGenerator(SfDataGrid dataGrid)
            : base(dataGrid)
        {
        }

        protected override GridCell GetGridCell<T>()
        {
            if (typeof(T) == typeof(GridFilterRowCell))
                return new GridFilterRowCellExt();
            return base.GetGridCell<GridCell>();
        }
    }
}
