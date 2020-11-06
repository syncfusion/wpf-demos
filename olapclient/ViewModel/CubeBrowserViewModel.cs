#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using System;
    using System.Linq;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Data;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Reports;
    using System.Windows;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class CubeBrowserViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private DelegateCommand<object> slicerRemoveBtnClick;
        private DelegateCommand<object> rowRemoveBtnClick;
        private DelegateCommand<object> colRemoveBtnClick;
        private DelegateCommand<object> slicerMeasureClickCmd;
        private DelegateCommand<object> rowMeasureClickCmd;
        private DelegateCommand<object> colMeasureClickCmd;
        private DelegateCommand<object> dimensionClickCmnd;
        private object selectedSlicerListItem;
        private object selectedRowListItem;
        private object selectedColumnListItem;
        private ObservableCollection<object> slicerListItems;
        private ObservableCollection<object> rowListItems;
        private ObservableCollection<object> columnListItems;
        private object selectedDimesnsion;
        private object selectedMeasure;
        private bool canShowDimButton;
        private bool canSlicerRemoveBtn;
        private bool canRowRemoveBtn;
        private bool canColRemoveBtn;
        private bool canSlicerShowMeasureBtn = true;
        private bool canRowShowMeasureBtn = true;
        private bool canColShowMeasureBtn = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CubeBrowserViewModel"/> class.
        /// </summary>
        public CubeBrowserViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = CubeBrowserModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = CubeBrowserModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            if (ConnectionString != null)
            {                
                olapDataManager = new OlapDataManager(ConnectionString);
                // Report creation
                OlapReport report = new OlapReport { Name = "Report", CurrentCubeName = olapDataManager.DataProvider.GetCubes[0].Name };
                olapDataManager.AddReport(report);
            }
        }

        #endregion

        #region Properties

        public OlapDataManager GridDataManager
        {
            get { return olapDataManager; }
            set { olapDataManager = value; }
        }

        public MeasureCollection AvailableMeasures
        {
            get
            {
                return GridDataManager.CurrentCubeSchema.Measures;
            }
        }

        public DimensionCollection AvailableDimensions
        {
            get
            {
                return GridDataManager.CurrentCubeSchema.Dimensions;
            }
        }
        public object SelectedMeasure
        {
            get
            {
                return selectedMeasure;
            }
            set
            {
                selectedMeasure = value;
                RaisePropertyChanged("SelectedMeasure");
            }
        }

        public object SelectedDimension
        {
            get
            {
                return selectedDimesnsion;
            }
            set
            {
                selectedDimesnsion = value;
                RaisePropertyChanged("SelectedDimension");
                canShowDimButton = true;
                DimensionClick.CanExecute(null);
            }
        }

        public ObservableCollection<object> ColumnItems
        {
            get
            {
                columnListItems = columnListItems ?? new ObservableCollection<object>();
                return columnListItems;
            }
            set
            {
                columnListItems = value;
                RaisePropertyChanged("ColumnItems");
            }
        }

        public ObservableCollection<object> RowItems
        {
            get
            {
                rowListItems = rowListItems ?? new ObservableCollection<object>();
                return rowListItems;
            }
            set
            {
                rowListItems = value;
                RaisePropertyChanged("RowItems");
            }
        }


        public ObservableCollection<object> SlicerItems
        {
            get
            {
                slicerListItems = slicerListItems ?? new ObservableCollection<object>();
                return slicerListItems;
            }
            set
            {
                slicerListItems = value;
                RaisePropertyChanged("SlicerItems");
            }
        }


        public object SelectedColumnItem
        {
            get
            {
                return selectedColumnListItem;
            }
            set
            {
                selectedColumnListItem = value;
                RaisePropertyChanged("SelectedColumnItem");
                canColRemoveBtn = true;
                ColRemoveClick.CanExecute(null);
            }
        }


        public object SelectedRowItem
        {
            get
            {
                return selectedRowListItem;
            }
            set
            {
                selectedRowListItem = value;
                RaisePropertyChanged("SelectedRowItem");
                canRowRemoveBtn = true;
                RowRemoveClick.CanExecute(null);
            }
        }

        public object SelectedSlicerItem
        {
            get
            {
                return selectedSlicerListItem;
            }
            set
            {
                selectedSlicerListItem = value;
                RaisePropertyChanged("SelectedSlicerItem");
                canSlicerRemoveBtn = true;
                SlicerRemoveClick.CanExecute(null);
            }
        }

        public DelegateCommand<object> DimensionClick
        {
            get
            {
                dimensionClickCmnd = dimensionClickCmnd ?? new DelegateCommand<object>(DoDimensionClickProcess, CanDimensionClick);
                return dimensionClickCmnd;
            }
            set { dimensionClickCmnd = value; }
        }

        public DelegateCommand<object> ColMeasureClick
        {
            get
            {
                colMeasureClickCmd = colMeasureClickCmd ?? new DelegateCommand<object>(DoColMeasureClickProcess, CanColMeasureClick);
                return colMeasureClickCmd;
            }
            set { colMeasureClickCmd = value; }
        }

        public DelegateCommand<object> RowMeasureClick
        {
            get
            {
                rowMeasureClickCmd = rowMeasureClickCmd ?? new DelegateCommand<object>(DoRowMeasureClickProcess, CanRowMeasureClick);
                return rowMeasureClickCmd;
            }
            set { rowMeasureClickCmd = value; }
        }

        public DelegateCommand<object> SlicerMeasureClick
        {
            get
            {
                slicerMeasureClickCmd = slicerMeasureClickCmd ?? new DelegateCommand<object>(DoSlicerMeasureClickProcess, CanSlicerMeasureClick);
                return slicerMeasureClickCmd;
            }
            set { slicerMeasureClickCmd = value; }
        }

        public DelegateCommand<object> ColRemoveClick
        {
            get
            {
                colRemoveBtnClick = colRemoveBtnClick ?? new DelegateCommand<object>(DoRemoveClickProcess, CanColRemoveClick);
                return colRemoveBtnClick;
            }
            set { colRemoveBtnClick = value; }
        }

        public DelegateCommand<object> RowRemoveClick
        {
            get
            {
                rowRemoveBtnClick = rowRemoveBtnClick ?? new DelegateCommand<object>(DoRemoveClickProcess, CanRowRemoveClick);
                return rowRemoveBtnClick;
            }
            set { rowRemoveBtnClick = value; }
        }

        public DelegateCommand<object> SlicerRemoveClick
        {
            get
            {
                slicerRemoveBtnClick = slicerRemoveBtnClick ?? new DelegateCommand<object>(DoRemoveClickProcess, CanSlicerRemoveClick);
                return slicerRemoveBtnClick;
            }
            set { slicerRemoveBtnClick = value; }
        }

        #endregion

        #region Helper Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Check whether the given element is exist in the current report
        /// </summary>
        /// <param name="currentlySelectedItem"></param>
        private bool CheckForExistance(object currentlySelectedItem)
        {
            if (IterateThroughItems(ColumnItems, currentlySelectedItem))
            {
                return true;
            }
            else if (IterateThroughItems(RowItems, currentlySelectedItem))
            {
                return true;
            }
            else if (IterateThroughItems(SlicerItems, currentlySelectedItem))
            {
                return true;
            }
            return false;
        }

        private bool IterateThroughItems(ObservableCollection<object> items, object currentlySelectedItem)
        {
            foreach (var obj in items)
            {
                if (obj is Measure && currentlySelectedItem is Measure)
                {
                    if ((obj as Measure).UniqueName == (currentlySelectedItem as Measure).UniqueName)
                        return true;
                }
                else if (obj is Dimension && currentlySelectedItem is Dimension)
                {
                    if ((obj as Dimension).UniqueName == (currentlySelectedItem as Dimension).UniqueName)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Adds the currently selected item to current report.
        /// </summary>
        /// <param name="axisType">Type of the axis.</param>
        /// <param name="currentlySelectedItem">The currently selected item.</param>
        private void addToReport(AxisType axisType, Object currentlySelectedItem)
        {
            Element element = null;
            if (currentlySelectedItem is Measure)
            {
                MeasureElements measres = new MeasureElements();
                measres.Elements.Add(new MeasureElement { Name = (currentlySelectedItem as Measure).Name });
                element = measres;
            }
            else if (currentlySelectedItem is Dimension)
            {
                Dimension tempDim = currentlySelectedItem as Dimension;
                DimensionElement dimension = new DimensionElement();
                dimension.Name = tempDim.Name;
                Hierarchy hier = GridDataManager.CurrentCubeSchema.GetHierarchyByUniqueName(tempDim.DefaultHierarchyName);
                dimension.AddLevel(hier.Name, hier.DefaultLevelName);
                element = dimension;
            }

            switch (axisType)
            {
                case AxisType.Categorical:
                    GridDataManager.CurrentReport.CategoricalElements.Add(element);
                    break;
                case AxisType.Series:
                    GridDataManager.CurrentReport.SeriesElements.Add(element);
                    break;
                case AxisType.Slicer:
                    GridDataManager.CurrentReport.SlicerElements.Add(element);
                    break;
            }
        }

        /// <summary>
        /// Removes the selected Item from the current report
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="selectedItem">The selected item.</param>
        private void RemoveItem(Items items, Object selectedItem)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var element = items[i].ElementValue;
                if (selectedItem is Measure && element is MeasureElements)
                {
                    if ((element as MeasureElements).Elements[0].UniqueName.Equals((selectedItem as Measure).UniqueName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        items.RemoveAt(i);
                        break;
                    }
                }
                else if (selectedItem is Dimension && element is DimensionElement)
                {
                    if ((element as DimensionElement).UniqueName.Equals((selectedItem as Dimension).UniqueName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        items.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks for the existence of measure in the current report
        /// </summary>
        private bool CheckForMeasure()
        {
            foreach (Item item in GridDataManager.CurrentReport.CategoricalElements)
            {
                if (item.ElementValue is MeasureElements)
                {
                    return true;
                }
            }
            foreach (Item item in GridDataManager.CurrentReport.SeriesElements)
            {
                if (item.ElementValue is MeasureElements)
                {
                    return true;
                }
            }
            foreach (Item item in GridDataManager.CurrentReport.SlicerElements)
            {
                if (item.ElementValue is MeasureElements)
                {
                    return true;
                }
            }
            return false;
        }

        private void EnableAll()
        {
            if (!CheckForMeasure())
            {
                canColShowMeasureBtn = true;
                canRowShowMeasureBtn = true;
                canSlicerShowMeasureBtn = true;
                ColMeasureClick.CanExecute(null);
                RowMeasureClick.CanExecute(null);
                SlicerMeasureClick.CanExecute(null);
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing && olapDataManager != null)
                olapDataManager.Dispose();
        }

        #endregion

        #region Command Helpers
        private void DoDimensionClickProcess(object parm)
        {
            if (SelectedDimension != null)
            {
                // Check the existence of the selected dimension in the current report 
                // and add it to the current report
                if (!CheckForExistance(SelectedDimension))
                {
                    if (parm.ToString().Equals("btnColDimension"))
                    {
                        ColumnItems.Add(SelectedDimension);
                        addToReport(AxisType.Categorical, SelectedDimension);
                    }
                    else if (parm.ToString().Equals("btnRowDimension"))
                    {
                        RowItems.Add(SelectedDimension);
                        addToReport(AxisType.Series, SelectedDimension);
                    }
                    else if (parm.ToString().Equals("btnSliceDimension"))
                    {
                        SlicerItems.Add(SelectedDimension);
                        addToReport(AxisType.Slicer, SelectedDimension);
                    }
                    SelectedDimension = null;
                    canShowDimButton = false;
                    DimensionClick.CanExecute(null);
                    GridDataManager.NotifyElementModified();
                }
                else
                {
                    MessageBox.Show("This element is already exist in the current report", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Select a Dimension to Add", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private bool CanDimensionClick(object parm)
        {
            return canShowDimButton;
        }

        private void DoColMeasureClickProcess(object parm)
        {
            if (SelectedMeasure != null)
            {
                // Check for the existence of this item in the current report
                // and add it to the current report
                if (!CheckForExistance(SelectedMeasure))
                {
                    ColumnItems.Add(SelectedMeasure);
                    addToReport(AxisType.Categorical, SelectedMeasure);
                    canColShowMeasureBtn = true;
                    canRowShowMeasureBtn = false;
                    canSlicerShowMeasureBtn = false;
                    ColMeasureClick.CanExecute(null);
                    RowMeasureClick.CanExecute(null);
                    SlicerMeasureClick.CanExecute(null);
                    GridDataManager.NotifyElementModified();
                }
                else
                {
                    MessageBox.Show("This element is already exist in the current report", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                MessageBox.Show("Select a Measure to Add", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DoRowMeasureClickProcess(object parm)
        {
            if (SelectedMeasure != null)
            {
                // Check for the existence of this item in the current report
                // and add it to the current report
                if (!CheckForExistance(SelectedMeasure))
                {
                    RowItems.Add(SelectedMeasure);
                    addToReport(AxisType.Series, SelectedMeasure);
                    canColShowMeasureBtn = false;
                    canRowShowMeasureBtn = true;
                    canSlicerShowMeasureBtn = false;
                    ColMeasureClick.CanExecute(null);
                    RowMeasureClick.CanExecute(null);
                    SlicerMeasureClick.CanExecute(null);
                    GridDataManager.NotifyElementModified();
                }
                else
                {
                    MessageBox.Show("This element is already exist in the current report", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                MessageBox.Show("Select a Measure to Add", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DoSlicerMeasureClickProcess(object parm)
        {
            if (SelectedMeasure != null)
            {
                // Check for the existence of this item in the current report
                // and add it to the current report
                if (!CheckForExistance(SelectedMeasure) && !SlicerItems.Any(i => i is Measure))
                {
                    SlicerItems.Add(SelectedMeasure);
                    addToReport(AxisType.Slicer, SelectedMeasure);
                    canColShowMeasureBtn = false;
                    canRowShowMeasureBtn = false;
                    canSlicerShowMeasureBtn = true;
                    ColMeasureClick.CanExecute(null);
                    RowMeasureClick.CanExecute(null);
                    SlicerMeasureClick.CanExecute(null);
                    GridDataManager.NotifyElementModified();
                }
                else
                {
                    MessageBox.Show("This element is already exist in the current report or more than one measure could not be sliced.", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                MessageBox.Show("Select a Measure to Add", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool CanColMeasureClick(object parm)
        {
            return canColShowMeasureBtn;
        }

        private bool CanRowMeasureClick(object parm)
        {
            return canRowShowMeasureBtn;
        }

        private bool CanSlicerMeasureClick(object parm)
        {
            return canSlicerShowMeasureBtn;
        }

        private bool CanColRemoveClick(object parm)
        {
            return canColRemoveBtn;
        }


        private bool CanRowRemoveClick(object parm)
        {
            return canRowRemoveBtn;
        }

        private bool CanSlicerRemoveClick(object parm)
        {
            return canSlicerRemoveBtn;
        }

        private void DoRemoveClickProcess(object parm)
        {
            if (parm.ToString().Equals("btnColRemove"))
            {
                if (SelectedColumnItem != null)
                {
                    RemoveItem(GridDataManager.CurrentReport.CategoricalElements, SelectedColumnItem);
                    ColumnItems.Remove(SelectedColumnItem);
                    canColRemoveBtn = false;
                    ColRemoveClick.CanExecute(null);
                    GridDataManager.NotifyElementModified();
                    EnableAll();
                }
                else
                {
                    MessageBox.Show("Select an Item to Remove", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if (parm.ToString().Equals("btnRowRemove"))
            {
                if (SelectedRowItem != null)
                {
                    RemoveItem(GridDataManager.CurrentReport.SeriesElements, SelectedRowItem);
                    RowItems.Remove(SelectedRowItem);
                    canRowRemoveBtn = false;
                    RowRemoveClick.CanExecute(null);
                    GridDataManager.NotifyElementModified();
                    EnableAll();
                }
                else
                {
                    MessageBox.Show("Select an Item to Remove", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if (parm.ToString().Equals("btnSliceRemove"))
            {
                if (SelectedSlicerItem != null)
                {
                    RemoveItem(GridDataManager.CurrentReport.SlicerElements, SelectedSlicerItem);
                    SlicerItems.Remove(SelectedSlicerItem);
                    canSlicerRemoveBtn = false;
                    SlicerRemoveClick.CanExecute(null);
                    GridDataManager.NotifyElementModified();
                    EnableAll();
                }
                else
                {
                    MessageBox.Show("Select an Item to Remove", "Cube Browser", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }
        #endregion
    }
}
