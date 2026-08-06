using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.gridcontroldemos.wpf
{
   public class GridControlDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new GridControlProductDemos());
            return productdemos;
        }
    }

    public class GridControlProductDemos : ProductDemo
    {
        public GridControlProductDemos()
        {
            this.Product = "Grid Control";
            this.ProductCategory = "GRIDS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 0C1.11929 0 0 1.11929 0 2.5V11.5C0 12.8807 1.11929 14 2.5 14H5.5C5.77614 14 6 13.7761 6 13.5C6 13.2239 5.77614 13 5.5 13H5V10H5.5C5.77614 10 6 9.77614 6 9.5C6 9.22386 5.77614 9 5.5 9H5V5H8V7C8 7.27614 8.22386 7.5 8.5 7.5C8.77614 7.5 9 7.27614 9 7V5H13V7C13 7.27614 13.2239 7.5 13.5 7.5C13.7761 7.5 14 7.27614 14 7V2.5C14 1.11929 12.8807 0 11.5 0H2.5ZM13 4V2.5C13 1.67157 12.3284 1 11.5 1H2.5C1.67157 1 1 1.67157 1 2.5V4H13ZM4 5L4 9H1V5H4ZM1 10V11.5C1 12.3284 1.67157 13 2.5 13H4L4 10H1ZM13.1909 12.5909C13.1425 12.7006 13.1281 12.8223 13.1495 12.9402C13.1708 13.0582 13.2271 13.167 13.3109 13.2527L13.3327 13.2745C13.4003 13.3421 13.454 13.4223 13.4906 13.5106C13.5272 13.5989 13.546 13.6935 13.546 13.7891C13.546 13.8847 13.5272 13.9793 13.4906 14.0676C13.454 14.1559 13.4003 14.2361 13.3327 14.3036C13.2652 14.3713 13.185 14.4249 13.0967 14.4615C13.0084 14.4981 12.9138 14.5169 12.8182 14.5169C12.7226 14.5169 12.628 14.4981 12.5397 14.4615C12.4514 14.4249 12.3712 14.3713 12.3036 14.3036L12.2818 14.2818C12.1961 14.198 12.0873 14.1418 11.9693 14.1204C11.8513 14.099 11.7297 14.1134 11.62 14.1618C11.5124 14.2079 11.4207 14.2845 11.3561 14.382C11.2915 14.4796 11.2568 14.5939 11.2564 14.7109V14.7727C11.2564 14.9656 11.1797 15.1506 11.0434 15.287C10.907 15.4234 10.722 15.5 10.5291 15.5C10.3362 15.5 10.1512 15.4234 10.0148 15.287C9.87844 15.1506 9.80182 14.9656 9.80182 14.7727V14.74C9.799 14.6196 9.76004 14.5029 9.69 14.405C9.61996 14.3071 9.52209 14.2325 9.40909 14.1909C9.29941 14.1425 9.17775 14.1281 9.05979 14.1495C8.94182 14.1708 8.83297 14.2271 8.74727 14.3109L8.72545 14.3327C8.65791 14.4003 8.5777 14.454 8.48941 14.4906C8.40112 14.5272 8.30648 14.546 8.21091 14.546C8.11533 14.546 8.0207 14.5272 7.93241 14.4906C7.84412 14.454 7.76391 14.4003 7.69636 14.3327C7.62874 14.2652 7.5751 14.185 7.5385 14.0967C7.5019 14.0084 7.48306 13.9138 7.48306 13.8182C7.48306 13.7226 7.5019 13.628 7.5385 13.5397C7.5751 13.4514 7.62874 13.3712 7.69636 13.3036L7.71818 13.2818C7.80201 13.1961 7.85825 13.0873 7.87964 12.9693C7.90103 12.8513 7.88659 12.7297 7.83818 12.62C7.79209 12.5124 7.71555 12.4207 7.61799 12.3561C7.52043 12.2915 7.4061 12.2568 7.28909 12.2564H7.22727C7.03439 12.2564 6.8494 12.1797 6.71301 12.0434C6.57662 11.907 6.5 11.722 6.5 11.5291C6.5 11.3362 6.57662 11.1512 6.71301 11.0148C6.8494 10.8784 7.03439 10.8018 7.22727 10.8018H7.26C7.38036 10.799 7.49709 10.76 7.59502 10.69C7.69294 10.62 7.76753 10.5221 7.80909 10.4091C7.8575 10.2994 7.87194 10.1777 7.85055 10.0598C7.82916 9.94182 7.77292 9.83297 7.68909 9.74727L7.66727 9.72545C7.59965 9.65791 7.54601 9.5777 7.50941 9.48941C7.47281 9.40112 7.45397 9.30648 7.45397 9.21091C7.45397 9.11533 7.47281 9.0207 7.50941 8.93241C7.54601 8.84412 7.59965 8.76391 7.66727 8.69636C7.73482 8.62874 7.81503 8.5751 7.90332 8.5385C7.99161 8.5019 8.08624 8.48306 8.18182 8.48306C8.27739 8.48306 8.37203 8.5019 8.46032 8.5385C8.54861 8.5751 8.62882 8.62874 8.69636 8.69636L8.71818 8.71818C8.80388 8.80201 8.91273 8.85825 9.03069 8.87964C9.14866 8.90103 9.27032 8.88659 9.38 8.83818H9.40909C9.51664 8.79209 9.60837 8.71555 9.67298 8.61799C9.73759 8.52043 9.77226 8.4061 9.77273 8.28909V8.22727C9.77273 8.03439 9.84935 7.8494 9.98574 7.71301C10.1221 7.57662 10.3071 7.5 10.5 7.5C10.6929 7.5 10.8779 7.57662 11.0143 7.71301C11.1507 7.8494 11.2273 8.03439 11.2273 8.22727V8.26C11.2277 8.37701 11.2624 8.49134 11.327 8.5889C11.3916 8.68646 11.4834 8.763 11.5909 8.80909C11.7006 8.8575 11.8223 8.87194 11.9402 8.85055C12.0582 8.82916 12.167 8.77292 12.2527 8.68909L12.2745 8.66727C12.3421 8.59965 12.4223 8.54601 12.5106 8.50941C12.5989 8.47281 12.6935 8.45397 12.7891 8.45397C12.8847 8.45397 12.9793 8.47281 13.0676 8.50941C13.1559 8.54601 13.2361 8.59965 13.3036 8.66727C13.3713 8.73482 13.4249 8.81503 13.4615 8.90332C13.4981 8.99161 13.5169 9.08624 13.5169 9.18182C13.5169 9.27739 13.4981 9.37203 13.4615 9.46032C13.4249 9.54861 13.3713 9.62882 13.3036 9.69636L13.2818 9.71818C13.198 9.80388 13.1418 9.91273 13.1204 10.0307C13.099 10.1487 13.1134 10.2703 13.1618 10.38V10.4091C13.2079 10.5166 13.2845 10.6084 13.382 10.673C13.4796 10.7376 13.5939 10.7723 13.7109 10.7727H13.7727C13.9656 10.7727 14.1506 10.8494 14.287 10.9857C14.4234 11.1221 14.5 11.3071 14.5 11.5C14.5 11.6929 14.4234 11.8779 14.287 12.0143C14.1506 12.1507 13.9656 12.2273 13.7727 12.2273H13.74C13.623 12.2277 13.5087 12.2624 13.4111 12.327C13.3135 12.3916 13.237 12.4834 13.1909 12.5909ZM11.7 11.5C11.7 12.1627 11.1627 12.7 10.5 12.7C9.83726 12.7 9.3 12.1627 9.3 11.5C9.3 10.8373 9.83726 10.3 10.5 10.3C11.1627 10.3 11.7 10.8373 11.7 11.5Z"),
                Width = 15,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Grids.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The GridControl is a customizable cell-oriented control that displays tabular data. It has a rich feature set, including cell styling, formulas, importing, and more.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/GridControl.png", UriKind.RelativeOrAbsolute));
            
            List<Documentation> excelLikeUIDocumentation = new List<Documentation>();
            excelLikeUIDocumentation.Add(new Documentation { Content = "GridControl - Excel Like UI Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/real-time-applications#excel-like-ui-applications") });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Like UI", Description = "This sample showcases the following capabilities of GridControl such as Selection Frame, Floating cells, Formula cells, Markup headers and Tab sheets and it provides us interactive user experience with an Excel-like appearance and characteristics .", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(ExcelLikeUI), DemoLauchMode = DemoLauchMode.Window,ThemeMode=ThemeMode.None, Documentations = excelLikeUIDocumentation });
            this.Demos.Add(new DemoInfo() { SampleName = "Scroll Performance", Description = "This sample showcases the scrolling performance of GridControl.", GroupName = "PERFORMANCE", DemoViewType = typeof(ScrollPerformance), ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "TraderGrid Test", Description = "This sample showcases the real time updates capability of GridControl.It provides support to insert and remove rows or columns with a minimal CPU usage. It also handles very high frequency updates and refresh scenarios.", GroupName = "PERFORMANCE", DemoViewType = typeof(TraderGridTest), ThemeMode = ThemeMode.Default });
            
            List<Documentation> excelLikeDragDropDocumentation = new List<Documentation>();
            excelLikeDragDropDocumentation.Add(new Documentation { Content = "GridControl - AllowDragDrop API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridControlBase.html#Syncfusion_Windows_Controls_Grid_GridControlBase_AllowDragDrop") });
            excelLikeDragDropDocumentation.Add(new Documentation { Content = "GridControl - Excel Like Drag And Drop Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/interactive-features#excel-like---cell-drag-and-drop") });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Like Drag and Drop", Description = "This sample showcases Excel like Drag and Drop in GridControl. This feature enables you to select any range and click on any corner of the selected region to drag it and drop it anywhere into a Grid, or some other controls, in an application. You can enable this feature by setting the AllowDragDrop property of the GridControl as True.", GroupName = "EXCEL LIKE FEATURES", DemoViewType = typeof(ExcelLikeDragandDrop), ThemeMode = ThemeMode.Default, Documentations = excelLikeDragDropDocumentation });
            
            List<Documentation> excelLikeFillSelectionDocumentation = new List<Documentation>();
            excelLikeFillSelectionDocumentation.Add(new Documentation { Content = "GridControl - ExcelLikeSelectionFrame API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModelOptions.html#Syncfusion_Windows_Controls_Grid_GridModelOptions_ExcelLikeSelectionFrame") });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Like Fill Selection", Description = "This sample showcases Excel-like Fill selection in GridControl. This allows you to fill the data of selected cells by clicking and dragging the bottom right corner of the selected region. A popup button is displayed below the cell containing various options to customize how the data is to be filled in the dragged cells.", GroupName = "EXCEL LIKE FEATURES", DemoViewType = typeof(ExcelLikeFillSelection), ThemeMode = ThemeMode.Default, Documentations = excelLikeFillSelectionDocumentation });
            
            List<Documentation> floatingCellDocumentation = new List<Documentation>();
            floatingCellDocumentation.Add(new Documentation { Content = "GridControl - EnableFloatingCell API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModelOptions.html#Syncfusion_Windows_Controls_Grid_GridModelOptions_EnableFloatingCell") });
            floatingCellDocumentation.Add(new Documentation { Content = "GridControl - Floating Cells Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-layout-customization#floating") });
            this.Demos.Add(new DemoInfo() { SampleName = "Floating Cells", Description = "This sample showcases the following capability of GridControl such as to display the cell content in an adjacent cell by overlapping the next cell, when the cell content exceeds the cell width. GridControl supports this floating behavior in both display and edit mode.", GroupName = "EXCEL LIKE FEATURES", DemoViewType = typeof(FloatingCells), ThemeMode = ThemeMode.Default, Documentations = floatingCellDocumentation });
            
            List<Documentation> freezePaneDocumentation = new List<Documentation>();
            freezePaneDocumentation.Add(new Documentation { Content = "GridControl - ExcelLikeFreezePane API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModelOptions.html#Syncfusion_Windows_Controls_Grid_GridModelOptions_ExcelLikeFreezePane") });
            freezePaneDocumentation.Add(new Documentation { Content = "GridControl - Freeze Rows And Columns Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/managing-rows-and-columns#freeze-rows-and-columns") });
            this.Demos.Add(new DemoInfo() { SampleName = "Freeze Pane", Description = "This sample of GridControl showcases the Freeze Pane feature . This enables you to freeze a part of the grid on screen, so that you can see the frozen area, even when you scroll through the other part independently. The Freeze Pane feature is frequently used to keep a set of title cells in view as data scrolls through or next to it.", GroupName = "EXCEL LIKE FEATURES", DemoViewType = typeof(FreezePane), ThemeMode = ThemeMode.Default, Documentations = freezePaneDocumentation });
            
            List<Documentation> hiddenRowColumnResizingDocumentation = new List<Documentation>();
            hiddenRowColumnResizingDocumentation.Add(new Documentation { Content = "GridControl - AllowExcelLikeResizing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModelOptions.html#Syncfusion_Windows_Controls_Grid_GridModelOptions_AllowExcelLikeResizing") });
            hiddenRowColumnResizingDocumentation.Add(new Documentation { Content = "GridControl - Hide and Unhide Rows Columns Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/interactive-features#hide-and-unhide-a-rows-or-columns-during-run-time") });
            this.Demos.Add(new DemoInfo() { SampleName = "Hidden Row Column Resizing", Description = "This sample showcases the following capabilities of GridControl such as to resize and an option to hide and unhide the specified number of rows and columns. GridControl allows you to resize, hide and unhide the rows or columns by dragging the resizing cursor that appears when the mouse is hovered at the edge of the Header cells.", GroupName = "EXCEL LIKE FEATURES", DemoViewType = typeof(HiddenRowColumnResizing), ThemeMode = ThemeMode.Default, Documentations = hiddenRowColumnResizingDocumentation });
            
            List<Documentation> inputMessageDocumentation = new List<Documentation>();
            inputMessageDocumentation.Add(new Documentation { Content = "GridControl - Input Message Tip Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/input-message-tip") });
            this.Demos.Add(new DemoInfo() { SampleName = "Input Message", Description = "This sample showcases Excel-like Input tips in the GridControl, that is, GridControl displays a small pop-up that contains the custom message about a cell when that particular cell is selected.", GroupName = "EXCEL LIKE FEATURES", DemoViewType = typeof(InputMessage), ThemeMode = ThemeMode.Default, Documentations = inputMessageDocumentation });
            
            
            this.Demos.Add(new DemoInfo() { SampleName = "Selection Marker", Description = "This sample showcases a support for selection marker in GridControl, which shows the marker on the selection rectangle when the selection covers the hidden ranges.", GroupName = "EXCEL LIKE FEATURES", DemoViewType = typeof(SelectionMarker), ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Sort Column", Description = "This sample showcases the sorting of a column in a GridControl. Sorting can be easily accomplished by clicking on the appropriate column’s header cell.", GroupName = "EXCEL LIKE FEATURES", DemoViewType = typeof(SortColumn), ThemeMode = ThemeMode.Default });
            
            List<Documentation> undoRedoDocumentation = new List<Documentation>();
            undoRedoDocumentation.Add(new Documentation { Content = "GridControl - Undo/Redo Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/editing#undoredo") });
            this.Demos.Add(new DemoInfo() { SampleName = "Undo Redo", Description = "This sample showcases how to perform Undo and Redo operations in GridControl. Undo reverts the actions that are performed in GridControl and Redo reverts the undo actions.", GroupName = "EXCEL LIKE FEATURES", DemoViewType = typeof(UndoRedo), ThemeMode = ThemeMode.Default, Documentations = undoRedoDocumentation });
            
            List<Documentation> virtualCellDocumentation = new List<Documentation>();
            virtualCellDocumentation.Add(new Documentation { Content = "GridControl - Virtual Cells Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/virtualization#virtual-cells") });
            this.Demos.Add(new DemoInfo() { SampleName = "Virtual Cell", Description = "This sample showcases a Virtual Cell architecture in GridControl where the cell contents are drawn statically until a live cell is needed. ", GroupName = "GRID VIRTUALIZATION", DemoViewType = typeof(VirtualCell), ThemeMode = ThemeMode.Default, Documentations = virtualCellDocumentation });
            
            List<Documentation> virtualGridDocumentation = new List<Documentation>();
            virtualGridDocumentation.Add(new Documentation { Content = "GridControl - Virtual Mode Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/virtualization#virtual-mode") });
            this.Demos.Add(new DemoInfo() { SampleName = "Virtual Grid", Description = "This sample showcases the virtualization support in GridControl that allows you to display large data sources very quickly. The data is provided to the GridControl on demand through an event that allows you to furnish the requested data in the handler. You can also instantaneously hide or show millions of rows in a GridControl.", GroupName = "GRID VIRTUALIZATION", DemoViewType = typeof(VirtualGrid), ThemeMode = ThemeMode.Default, Documentations = virtualGridDocumentation });
            
            List<Documentation> advancedDataTemplateCellDocumentation = new List<Documentation>();
            advancedDataTemplateCellDocumentation.Add(new Documentation { Content = "GridControl - DataTemplate Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#datatemplate-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Advanced DataTemplate Cell", Description = "This sample of GridControl showcases how to load the DataTemplate into a cell. By using a DataTemplate, each cell can be customized by defining the template. In this application, some advanced controls like DataGrid, Charts, and Gauge are loaded into a cell in GridControl.", GroupName = "CELL TYPES", DemoViewType = typeof(AdvancedDataTemplateCell), ThemeMode = ThemeMode.Default, Documentations = advancedDataTemplateCellDocumentation });
            
            List<Documentation> basicCellTypeDocumentation = new List<Documentation>();
            basicCellTypeDocumentation.Add(new Documentation { Content = "GridControl - Basic Cell Type Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types") });
            this.Demos.Add(new DemoInfo() { SampleName = "Basic Cell Type", Description = "This sample showcases the following capabilities of GridControl such as to load different types of cells like TextBox, Static, Header, Checkbox, Button and Image and its contents into any cell.", GroupName = "CELL TYPES", DemoViewType = typeof(BasicCellType), ThemeMode = ThemeMode.Default, Documentations = basicCellTypeDocumentation });
            
            List<Documentation> comboBoxCellDocumentation = new List<Documentation>();
            comboBoxCellDocumentation.Add(new Documentation { Content = "GridControl - ComboBox Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#combobox-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Combo Box Cell", Description = "This sample showcases the following capabilities of GridControl such as the use of Combo Box, Drop-Down, and Multicolumn Grid list controls in Grid cells. The various options illustrated include AutoComplete functionality, getting items for the drop-down from either a string collection or a LINQ source, and using the drop-down in a foreign-key manner. For example, displaying one column from a data source in the drop-down while saving the cell value from another column in the data source.", GroupName = "CELL TYPES", DemoViewType = typeof(ComboBoxCell), ThemeMode = ThemeMode.Default, Documentations = comboBoxCellDocumentation });
            
            List<Documentation> currencyCellDocumentation = new List<Documentation>();
            currencyCellDocumentation.Add(new Documentation { Content = "GridControl - CurrencyEdit Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#currencyedit-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Currency Cell", Description = "This sample showcases the Currency-Edit cell type that provides edit experience with different currency symbols, number formats, decimal digits, number groups and number group separators, etc.", GroupName = "CELL TYPES", DemoViewType = typeof(CurrencyCell), ThemeMode = ThemeMode.Default, Documentations = currencyCellDocumentation });
            
            List<Documentation> customDataTemplateCellDocumentation = new List<Documentation>();
            customDataTemplateCellDocumentation.Add(new Documentation { Content = "Gridcontrol - Data Template Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#data-template-cells") });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Data Template Cell", Description = "This sample of GridControl showcases how to load the DataTemplate into a cell. By using a DataTemplate, each and every cell can be customized with a different look and feel, achieving a colorful appearance for the entire Grid Control.", GroupName = "CELL TYPES", DemoViewType = typeof(CustomDataTemplateCell), ThemeMode = ThemeMode.Default, Documentations = customDataTemplateCellDocumentation });
            
            List<Documentation> customDropDownDocumentation = new List<Documentation>();
            customDropDownDocumentation.Add(new Documentation { Content = "GridControl - Custom Drop-down Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#custom-drop-down-cells") });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Drop Down", Description = "This sample showcases how to create your own custom cell renderer in GridControl and demonstrates how you can easily create a Custom Drop-Down control and renderer. The Custom Drop-Down Cell Type allow you to implement you to own custom drop-downs. The drop-downs can be easily created by inheriting the GridCellDropDownControlBase and GridCellDropDownCellRenderer base classes.", GroupName = "CELL TYPES", DemoViewType = typeof(CustomDropDown), ThemeMode = ThemeMode.Default, Documentations = customDropDownDocumentation });
            
            List<Documentation> dataTemplateCellTemplateDocumentation = new List<Documentation>();
            dataTemplateCellTemplateDocumentation.Add(new Documentation { Content = "GridControl - DataTemplate Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#datatemplate-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Template Cell", Description = "This sample showcases how the GridControl provides a support to load the DataTemplate into a cell. By using a DataTemplate, each and every cell can be customized with a different look and feel, achieving a colorful appearance for the entire Grid Control.", GroupName = "CELL TYPES", DemoViewType = typeof(DataTemplateCell), ThemeMode = ThemeMode.Default, Documentations = dataTemplateCellTemplateDocumentation });
            
            List<Documentation> dateTimeCellDocumentation = new List<Documentation>();
            dateTimeCellDocumentation.Add(new Documentation { Content = "GridControl - DateTimeEdit Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#datetimeedit-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Date Time Cell", Description = "This sample showcases the DateTime cell type that provides edit experience with attractive DateTimePicker to modify the date and time value of the cell in a GridControl.", GroupName = "CELL TYPES", DemoViewType = typeof(DateTimeCell), ThemeMode = ThemeMode.Default, Documentations = dateTimeCellDocumentation });
            
            List<Documentation> doubleEditCellDocumentation = new List<Documentation>();
            doubleEditCellDocumentation.Add(new Documentation { Content = "GridControl - DoubleEdit Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#doubleedit-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Double Edit Cell", Description = "This sample showcases the Double-Edit cell type that provides edit experience with different number formats, decimal digits, number groups and number group separators, etc.", GroupName = "CELL TYPES", DemoViewType = typeof(DoubleEditCell), ThemeMode = ThemeMode.Default, Documentations = doubleEditCellDocumentation });
            
            List<Documentation> gaugeChartDocumentation = new List<Documentation>();
            gaugeChartDocumentation.Add(new Documentation { Content = "GridControl - DataTemplate Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#datatemplate-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Gauge Chart", Description = "This sample showcases how the Gauge and various Charts are loaded into a cell in GridControl. By using a DataTemplate, each cell can be customized by defining the template.", GroupName = "CELL TYPES", DemoViewType = typeof(GaugeChart), ThemeMode = ThemeMode.Default, Documentations = gaugeChartDocumentation });
            
            List<Documentation> integerEditCellDocumentation = new List<Documentation>();
            integerEditCellDocumentation.Add(new Documentation { Content = "GridControl - IntegerEdit Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#integeredit-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Integer Edit Cell", Description = "This sample showcases the Integer-Edit cell type that provides edit experience with different number formats, number groups and number group separators, etc.", GroupName = "CELL TYPES", DemoViewType = typeof(IntegerEditCell), ThemeMode = ThemeMode.Default, Documentations = integerEditCellDocumentation });
            
            List<Documentation> maskEditCellDocumentation = new List<Documentation>();
            maskEditCellDocumentation.Add(new Documentation { Content = "GridControl - MaskEdit Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#maskedit-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Mask Edit Cell", Description = "This sample showcases the Mask-Edit cell type that provides edit experience with different prompt characters, number formats, date formats, time formats, number decimal separators and number group separators, etc.", GroupName = "CELL TYPES", DemoViewType = typeof(MaskEditCell), ThemeMode = ThemeMode.Default, Documentations = maskEditCellDocumentation });
                        
            List<Documentation> nestedGridDocumentation = new List<Documentation>();
            nestedGridDocumentation.Add(new Documentation { Content = "GridControl - Nested Grid Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#nested-grid-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Nested Grid", Description = "This sample of GridControl showcases how to display nested tables in grid cells. By setting the CellType, a grid is loaded into a cell as NestedGrid.", GroupName = "CELL TYPES", DemoViewType = typeof(NestedGrid), ThemeMode = ThemeMode.Default, Documentations = nestedGridDocumentation });
            
            List<Documentation> percentEditCellDocumentation = new List<Documentation>();
            percentEditCellDocumentation.Add(new Documentation { Content = "GridControl - PercentEdit Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#percentedit-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Percent Edit Cell", Description = "This sample showcases the Percent-Edit cell type, that provides edit experience with percent symbols, decimal digits, number groups and number group separators, etc.", GroupName = "CELL TYPES", DemoViewType = typeof(PercentEditCell), ThemeMode = ThemeMode.Default, Documentations = percentEditCellDocumentation });
            
            List<Documentation> richTextBoxCellDocumentation = new List<Documentation>();
            richTextBoxCellDocumentation.Add(new Documentation { Content = "GridControl - RichTextBox Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#richtext-cell-type") }); 
            this.Demos.Add(new DemoInfo() { SampleName = "RichTextBox Cell", Description = "This sample showcases the RichTextBox cell type, that provides you with a rich edit experience. It provides the support to load the RichTextBox into a cell by setting the CellType.", GroupName = "CELL TYPES", DemoViewType = typeof(RichTextBoxCell), ThemeMode = ThemeMode.Default, Documentations = richTextBoxCellDocumentation });
            
            List<Documentation> textImageCellDocumentation = new List<Documentation>();
            textImageCellDocumentation.Add(new Documentation { Content = "GridControl - Image Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#image-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Text Image Cell", Description = "This sample of GridControl showcases how to load the images into a cell along with the text. That is, the GridControl displays both Image and text in a cell.", GroupName = "CELL TYPES", DemoViewType = typeof(TextImageCell), ThemeMode = ThemeMode.Default, Documentations = textImageCellDocumentation });
            
            List<Documentation> upDownCellDocumentation = new List<Documentation>();
            upDownCellDocumentation.Add(new Documentation { Content = "GridControl - UpDownEdit Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-types#updownedit-cell-type") });
            this.Demos.Add(new DemoInfo() { SampleName = "Up Down Cell", Description = "This sample showcases the UpDown cell type, that provides you with an edit experience with decimal digits, number groups and number group separators, etc., along with a spin button that helps to increase or decrease the value by simply pressing it.", GroupName = "CELL TYPES", DemoViewType = typeof(UpDownCell), ThemeMode = ThemeMode.Default, Documentations = upDownCellDocumentation });
            
            List<Documentation> cellStyleDocumentation = new List<Documentation>();
            cellStyleDocumentation.Add(new Documentation { Content = "GridControl - Cell Styles Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/appearance#cell-styles") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Style", Description = "This sample of GridControl showcases how to customize the appearance of each and every cell with different styles such as background, foreground, font size, font family, font styles, text orientation, and text alignment, etc.", GroupName = "APPEARANCE", DemoViewType = typeof(CellStyle), ThemeMode = ThemeMode.Default, Documentations = cellStyleDocumentation });
            
            List<Documentation> commentServiceDocumentation = new List<Documentation>();
            commentServiceDocumentation.Add(new Documentation { Content = "GridControl - Comment Tip Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/comment-tip") });
            this.Demos.Add(new DemoInfo() { SampleName = "Comment Service", Description = "This sample of GridControl showcases how to show comments in a cell as a small triangle at corners of the cell and display content via popup when mouse hover the small triangle. Comments are used to provide context to data in cells. Text in comments can be richly formatted to emphasize a comment concerning the cell.", GroupName = "APPEARANCE", DemoViewType = typeof(CommentService), ThemeMode = ThemeMode.Default, Documentations = commentServiceDocumentation });
            
            List<Documentation> coveredCellDocumentation = new List<Documentation>();
            coveredCellDocumentation.Add(new Documentation { Content = "GridControl - Covered Cells Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/cell-layout-customization#covered-cells") });
            this.Demos.Add(new DemoInfo() { SampleName = "Covered Cell ", Description = "This sample of GridControl showcases how to combine the cells in adjacent rows or columns or both. Covered Cells are cells that span over neighboring cells. The combined cells act as like they are a single cell, visually and programmatically.", GroupName = "APPEARANCE", DemoViewType = typeof(CoveredCell), ThemeMode = ThemeMode.Default, Documentations = coveredCellDocumentation });
            
            List<Documentation> gridStyleInfoDocumentation = new List<Documentation>();
            gridStyleInfoDocumentation.Add(new Documentation { Content = "GridControl - GridStyleInfo Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/appearance#gridstyleinfo-class-overview") });
            this.Demos.Add(new DemoInfo() { SampleName = "GridStyleInfo At Work", Description = "This sample showcases the following capabilities of GridControl such as the relationship between a Standard Style, Table Style, Base Style, Row Style, Column Style, and Cell Style. It lets you customize each style and allows you to choose whether you want to include the style or not.", GroupName = "APPEARANCE", DemoViewType = typeof(GridStyleInfoAtWork), ThemeMode = ThemeMode.Default, Documentations = gridStyleInfoDocumentation });

            List<Documentation> gridPropertiesDocumentation = new List<Documentation>();
            gridPropertiesDocumentation.Add(new Documentation { Content = "GridControl - QueryBaseStyles API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridControlBase.html#Syncfusion_Windows_Controls_Grid_GridControlBase_QueryBaseStyles") });
            this.Demos.Add(new DemoInfo() { SampleName = "Grid Properties", Description = "This sample showcases the following capabilities of GridControl such as how to hide the headers, gridlines and how to set the styles using QueryBaseStyles and selection behaviour like ListBoxMode Selection of grid.", GroupName = "APPEARANCE", DemoViewType = typeof(GridProperties), ThemeMode = ThemeMode.Default, Documentations = gridPropertiesDocumentation });
            
            List<Documentation> textFormatDocumentation = new List<Documentation>();
            textFormatDocumentation.Add(new Documentation { Content = "GridControl - Data Formats Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/appearance#data-formats") });
            this.Demos.Add(new DemoInfo() { SampleName = "Text Format", Description = "The sample showcases the following capabilities in GridControl such as number formatting, date-time formatting, and validating data when leaving the cell from edit mode.", GroupName = "APPEARANCE", DemoViewType = typeof(TextFormat), ThemeMode = ThemeMode.Default, Documentations = textFormatDocumentation });
            
            List<Documentation> toolTipDocumentation = new List<Documentation>();
            toolTipDocumentation.Add(new Documentation { Content = "GridControl - ToolTip Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/tooltip") });
            this.Demos.Add(new DemoInfo() { SampleName = "Tooltip", Description = "This sample of GridControl showcases how to associate the individual cells with ToolTip. ToolTip is a small pop-up box that appears when you move the mouse over a cell. It is used to display additional information about the cell. They are mainly used to display some text data. You can also display a text block with an image in the tooltip.", GroupName = "APPEARANCE", DemoViewType = typeof(Tooltip), ThemeMode = ThemeMode.Default, Documentations = toolTipDocumentation });
            
            
            this.Demos.Add(new DemoInfo() { SampleName = "Formula Range Selection", Description = "This sample showcases a helper class that enables you to use your mouse to insert range references as you enter a formula from the keyboard.", GroupName = "FORMULA SUPPORT", DemoViewType = typeof(FormulaRangeSelection), ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Formula Test Values", Description = "This sample showcases the following capability of GridControl such as how the values of a formula entered during runtime can be computed by using the formula engine. Currently, there are 370 functions that are supported by the formula engine, covering all common usage scenarios like Excel. GridControl provides support to create and use custom functions also.", GroupName = "FORMULA SUPPORT", DemoViewType = typeof(FormulaTestValues), ThemeMode = ThemeMode.Default });
            
            List<Documentation> copyToClipboardDocumentation = new List<Documentation>();
            copyToClipboardDocumentation.Add(new Documentation { Content = "GridControl - Clipboard Support Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/editing#clipboard-support") });
            this.Demos.Add(new DemoInfo() { SampleName = "Copy To Clipboard", Description = "This sample showcases the following capabilities of GridControl such as Clipboard Operations like Cut, Copy and Paste and also provides you with options to customize the behavior of the clipboard operations. This sample showcases the clipboard support within a GridControl and other applications by specifying the different CopyPaste options.", GroupName = "SELECTIONS", DemoViewType = typeof(CopyToClipboard), ThemeMode = ThemeMode.Default, Documentations = copyToClipboardDocumentation });
            
            List<Documentation> excelLikeSelectionDocumentation = new List<Documentation>();
            excelLikeSelectionDocumentation.Add(new Documentation { Content = "GridControl - ExcelLikeSelectionFrame API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModelOptions.html#Syncfusion_Windows_Controls_Grid_GridModelOptions_ExcelLikeSelectionFrame") });
            excelLikeSelectionDocumentation.Add(new Documentation { Content = "GridControl - Excel-Like Selection Frame Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/selection#excel-like-selection-frame") });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Like Selection", Description = "This sample showcases the following capabilities of GridControl such as, Excel-like Selection frame, Excel-like current cell moving when extending the selection using mouse and extending the selection by pressing Shift key, etc.", GroupName = "SELECTIONS", DemoViewType = typeof(ExcelLikeSelection),ThemeMode = ThemeMode.Default, Documentations = excelLikeSelectionDocumentation });
            
            List<Documentation> selectionDocumentation = new List<Documentation>();
            selectionDocumentation.Add(new Documentation { Content = "GridControl - AllowSelection API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModelOptions.html#Syncfusion_Windows_Controls_Grid_GridModelOptions_AllowSelection") });
            selectionDocumentation.Add(new Documentation { Content = "GridControl - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/selection") });
            this.Demos.Add(new DemoInfo() { SampleName = "Grid Control Selection", Description = "This sample showcases the various selection options in GridControl. That is single cell selection, ListBox selection, row selection and column selection. It also provides various event handlers to customize the behavior of the selection.", GroupName = "SELECTIONS", DemoViewType = typeof(GridControlSelection), ThemeMode = ThemeMode.Default, Documentations = selectionDocumentation });
            
            List<Documentation> borderPaddingCellsDocumentation = new List<Documentation>();
            borderPaddingCellsDocumentation.Add(new Documentation { Content = "GridControl - Style Properties Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/appearance#style-properties") });
            this.Demos.Add(new DemoInfo() { SampleName = "Border Padding Cells", Description = "GridControl provides support to customize the cell borders and its padding. This sample showcases the various types of border styles and border padding. Based on border padding thickness, the padding of text in a cell can also be adjusted. GridControl allows you to customize the border in each and every side of the cell.", GroupName = "GRID LAYOUT", DemoViewType = typeof(BorderPaddingCell), ThemeMode = ThemeMode.Default, Documentations = borderPaddingCellsDocumentation });
            
            List<Documentation> dragAndDropDocumentation = new List<Documentation>();
            dragAndDropDocumentation.Add(new Documentation { Content = "GridControl - AllowDragDrop API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridControlBase.html#Syncfusion_Windows_Controls_Grid_GridControlBase_AllowDragDrop") });
            dragAndDropDocumentation.Add(new Documentation { Content = "GridControl - AllowDragColumns API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridControlBase.html#Syncfusion_Windows_Controls_Grid_GridControlBase_AllowDragColumns") });
            dragAndDropDocumentation.Add(new Documentation { Content = "GridControl - Drag And Drop Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/interactive-features#drag-and-drop-columns") });
            this.Demos.Add(new DemoInfo() { SampleName = "Drag and Drop", Description = "This sample showcases how to drag and drop columns around the grid. An animated indicator denotes the place of the drop when dragging the column. It provides an event handler to customize the behavior of drag and drop.", GroupName = "GRID LAYOUT", DemoViewType = typeof(DragandDrop), ThemeMode = ThemeMode.Default, Documentations = dragAndDropDocumentation });
            
            List<Documentation> hideRowsAndColumnsDocumentation = new List<Documentation>();
            hideRowsAndColumnsDocumentation.Add(new Documentation { Content = "GridControl - Hide Rows And Columns Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/managing-rows-and-columns#hiding-rows-and-columns") });
            this.Demos.Add(new DemoInfo() { SampleName = "Hide or Show Column", Description = "This sample showcases to show or hide the set of rows and columns in GridControl.", GroupName = "GRID LAYOUT", DemoViewType = typeof(HideorShowColumn), ThemeMode = ThemeMode.Default, Documentations = hideRowsAndColumnsDocumentation });
            
            List<Documentation> resizeToFitDocumentation = new List<Documentation>();
            resizeToFitDocumentation.Add(new Documentation { Content = "GridControl - ResizeRowsToFit API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModel.html#Syncfusion_Windows_Controls_Grid_GridModel_ResizeRowsToFit_Syncfusion_Windows_Controls_Grid_GridRangeInfo_Syncfusion_Windows_Controls_Grid_GridResizeToFitOptions_") });
            resizeToFitDocumentation.Add(new Documentation { Content = "GridControl - AutoFit Cells Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/autofit-cells") });
            this.Demos.Add(new DemoInfo() { SampleName = "Resize To Fit", Description = "This sample showcases the following capability of GridControl such as to automatically customize the height or width of the row or column, based on the content loaded into the cell. And provides the various options to customize the Auto fit behavior.", GroupName = "GRID LAYOUT", DemoViewType = typeof(ResizeToFit), ThemeMode = ThemeMode.Default, Documentations = resizeToFitDocumentation });
            
            List<Documentation> excelImportDocumentation = new List<Documentation>();
            excelImportDocumentation.Add(new Documentation { Content = "GridControl - Import from Excel Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/import-from-excel") });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Import", Description = "This sample showcases the Excel Importing feature in GridControl. This Excel Importing feature allows you to import the Excel Workbook to the GridControl with the same set of features, like style, Formula, Named Ranges, Conditional Formatting, Data Validation, Freezing Pane and Bookmarks, etc.", GroupName = "IMPORT", DemoViewType = typeof(ExcelImport), DemoLauchMode = DemoLauchMode.Window, ThemeMode = ThemeMode.None, Documentations = excelImportDocumentation });
            
            List<Documentation> csvExportDocumentation = new List<Documentation>();
            csvExportDocumentation.Add(new Documentation { Content = "GridControl - ExportToCSV API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.Converter.GridModelExportExtensions.html#Syncfusion_Windows_Controls_Grid_Converter_GridModelExportExtensions_ExportToCSV_Syncfusion_Windows_Controls_Grid_GridModel_Syncfusion_Windows_Controls_Grid_GridRangeInfo_System_String_") });
            csvExportDocumentation.Add(new Documentation { Content = "GridControl - Export to CSV Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/export-to-excel#exporting-to-csv") });
            this.Demos.Add(new DemoInfo() { SampleName = "CSV Export", Description = "This sample showcases how to export the content of an entire Grid or the contents of the specified range of cells into the csv format. And it provides various event handlers to customize the behavior of exporting.", GroupName = "EXPORT", DemoViewType = typeof(CSVExport), ThemeMode = ThemeMode.Default, Documentations = csvExportDocumentation });
            
            List<Documentation> excelExportDocumentation = new List<Documentation>();
            excelExportDocumentation.Add(new Documentation { Content = "GridControl - ExportToExcel API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.Converter.GridModelExportExtensions.html#Syncfusion_Windows_Controls_Grid_Converter_GridModelExportExtensions_ExportToExcel_Syncfusion_Windows_Controls_Grid_GridModel_Syncfusion_Windows_Controls_Grid_GridRangeInfo_Syncfusion_XlsIO_IWorksheet_Syncfusion_XlsIO_IRange_Syncfusion_Windows_Controls_Grid_Converter_GridCellExportToExcelHandler_") });
            excelExportDocumentation.Add(new Documentation { Content = "GridControl - Export to Excel Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/export-to-excel") });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Export", Description = "This sample showcases how to export the content of the entire Grid or the content of the specified range of cells into the excel format. And it provides various event handlers to customize the behavior of exporting.", GroupName = "EXPORT", DemoViewType = typeof(ExcelExport), ThemeMode = ThemeMode.Default, Documentations = excelExportDocumentation });
            
            List<Documentation> pdfExportDocumentation = new List<Documentation>();
            pdfExportDocumentation.Add(new Documentation { Content = "GridControl - ExportToPdfGridDocument API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.Converter.GridPdfExportExtension.html#Syncfusion_Windows_Controls_Grid_Converter_GridPdfExportExtension_ExportToPdfGridDocument_Syncfusion_Windows_Controls_Grid_GridModel_Syncfusion_Windows_Controls_Grid_GridRangeInfo_System_String_") });
            this.Demos.Add(new DemoInfo() { SampleName = "Pdf Export", Description = "This sample showcases how to export the content of the entire Grid or the content of the specified range of cells into the pdf format. And it provides various event handlers to customize the behavior of exporting like adding header and footer.", GroupName = "EXPORT", DemoViewType = typeof(PdfExport), ThemeMode = ThemeMode.Default, Documentations = pdfExportDocumentation });
            
            List<Documentation> printingDocumentation = new List<Documentation>();
            printingDocumentation.Add(new Documentation { Content = "GridControl - Printing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/printing") });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", Description = "This sample showcases how to print the content of the entire Grid or the contents of the specified range of cells by providing various options to customize how the content is to be printed. It also provides a familiar Grid Print dialog to preview the printing.", GroupName = "PRINTING", DemoViewType = typeof(Printing), ThemeMode = ThemeMode.Default, Documentations = printingDocumentation });
            
            
            this.Demos.Add(new DemoInfo() { SampleName = "Deferred Scrolling", Description = "This sample showcases the support for deferred scrolling in GridControl, That is, the Grid remains stationary when you drag the thumb of a scrollBar and updates its view only when you release the thumb of the scrollbar.", GroupName = "SCROLLING", DemoViewType = typeof(DeferredScrolling), ThemeMode = ThemeMode.Default });
            
            List<Documentation> zoomingDocumentation = new List<Documentation>();
            zoomingDocumentation.Add(new Documentation { Content = "GridControl - Zooming Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/zooming") });
            this.Demos.Add(new DemoInfo() { SampleName = "Zooming", Description = "This sample showcases the zooming support in GridControl. User can increase or decrease the zooming level of GridControl using the ZoomScale.", GroupName = "ZOOMING", DemoViewType = typeof(Zooming),ThemeMode = ThemeMode.Default, Documentations = zoomingDocumentation });

            List<Documentation> serializationDocumentation = new List<Documentation>();
            serializationDocumentation.Add(new Documentation { Content = "GridControl - Serialization Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/gridcontrol/serialization") });
            this.Demos.Add(new DemoInfo() { SampleName = "Grid Serialization", Description = "This sample showcases the support for serialization and deserialization in GridControl. GridControl serializes the GridModel into various formats like string, xml and stream, and de-serializes from it.", GroupName = "SERIALIZATION", DemoViewType = typeof(GridSerialization), ThemeMode = ThemeMode.Default, Documentations = serializationDocumentation });
        }
    }
}


