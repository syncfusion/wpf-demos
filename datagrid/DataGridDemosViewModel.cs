#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace syncfusion.datagriddemos.wpf
{
    public class DataGridDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new DataGridProductDemos());
            return productdemos;
        }
    }

    public class DataGridProductDemos : ProductDemo
    {
        public DataGridProductDemos()
        {
            this.Product = "DataGrid";
            this.ProductCategory = "GRIDS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M12 1H2C1.44772 1 1 1.44772 1 2V4H13V2C13 1.44772 12.5523 1 12 1ZM9 5H5V8H9V5ZM10 8V5H13V8H10ZM9 9H5V13H9V9ZM10 13V9H13V12C13 12.5523 12.5523 13 12 13H10ZM2 14C0.89543 14 0 13.1046 0 12V2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V12C14 13.1046 13.1046 14 12 14H2ZM1 5H4V8H1V5ZM1 9H4V13H2C1.44772 13 1 12.5523 1 12V9Z"),
                Width = 14,
                Height = 14,
            };
            this.Tag = Tag.Updated;
            this.Demos = new List<DemoInfo>(); 
            this.IsHighlighted = true;
            this.ControlDescription = "The DataGrid is a high-performance grid control that displays tabular and hierarchical data. It supports sorting, grouping, filtering, etc.";
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Grids.png", UriKind.RelativeOrAbsolute));
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/DataGrid.png", UriKind.RelativeOrAbsolute));
            
            List<Documentation> gettingStartedDocumentation = new List<Documentation>();
            gettingStartedDocumentation.Add(new Documentation { Content = "DataGrid - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html") });
            gettingStartedDocumentation.Add(new Documentation { Content = "DataGrid - GettingStarted Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/getting-started") });
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "GETTING STARTED", Description = "This sample showcases the basic features in SfDataGrid by simple ObservableCollection binding.", DemoViewType = typeof(GettingStarted) ,Documentations = gettingStartedDocumentation });

            List<Documentation> dataBindingDocumentation = new List<Documentation>();
            dataBindingDocumentation.Add(new Documentation { Content = "DataGrid - DataBinding Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-binding") });
            dataBindingDocumentation.Add(new Documentation { Content = "DataGrid - Binding With DataTable Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-binding#binding-with-datatable") });
            dataBindingDocumentation.Add(new Documentation { Content = "DataGrid - Binding with Dynamic Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-binding#binding-with-dynamic-data-object") });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Binding", GroupName = "DATA BINDING", Description = "This sample showcases the data binding capabilities in SfDataGrid with data sources such as DataTable and Custom Collection such as List, BindingList and ObservableCollection.", DemoViewType = typeof(DataBindingDemo), ThemeMode= ThemeMode.None, Documentations = dataBindingDocumentation });

            List<Documentation> complexAndIndexerPropertiesDocumentation = new List<Documentation>();
            complexAndIndexerPropertiesDocumentation.Add(new Documentation { Content = "DataGrid - Complex Properties Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-binding#binding-complex-properties") });
            complexAndIndexerPropertiesDocumentation.Add(new Documentation { Content = "DataGrid - Indexer Properties Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-binding#binding-indexer-properties") });
            this.Demos.Add(new DemoInfo() { SampleName = "Complex and Indexer Properties", GroupName = "DATA BINDING", Description = "This sample showcases the complex and indexer properties binding capabilities in SfDataGrid. SfDataGrid supports to bind complex and indexer properties to its columns at any level.", DemoViewType = typeof(ComplexPropertyBindingDemo), Documentations = complexAndIndexerPropertiesDocumentation });

            List<Documentation> sortingDocumentation = new List<Documentation>();
            sortingDocumentation.Add(new Documentation { Content = "DataGrid - AllowSorting API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_AllowSorting") });
            sortingDocumentation.Add(new Documentation { Content = "DataGrid - Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/sorting") });
            this.Demos.Add(new DemoInfo() { SampleName = "Sorting", GroupName = "DATA PRESENTATION", Description = "This sample showcases the sorting capabilities of data in SfDataGrid. The SfDataGrid control allows you to sort the data against one or more columns and provides some sorting functionalities like Tristate Sorting, Showing Sort Orders or Sort Numbers.", DemoViewType = typeof(SortingDemo), Documentations = sortingDocumentation });

            List<Documentation> groupingDocumentation = new List<Documentation>();
            groupingDocumentation.Add(new Documentation { Content = "DataGrid - AllowGrouping API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_AllowGrouping") });
            groupingDocumentation.Add(new Documentation { Content = "DataGrid - AllowFrozenGroupHeaders API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_AllowFrozenGroupHeaders") });
            groupingDocumentation.Add(new Documentation { Content = "DataGrid - Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/grouping") });
            this.Demos.Add(new DemoInfo() { SampleName = "Grouping", GroupName = "DATA PRESENTATION", Description = "This sample showcases the grouping capabilities of data in SfDataGrid. The SfDataGrid enables you to grouping the data by one or more columns.", DemoViewType = typeof(GroupingDemo), Documentations = groupingDocumentation });

            List<Documentation> summaryDocumentation = new List<Documentation>();
            summaryDocumentation.Add(new Documentation { Content = "Summaries Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/summaries") });
            this.Demos.Add(new DemoInfo() { SampleName = "Summaries", GroupName = "DATA PRESENTATION", Description = "This sample showcases the summary calculation capabilities of data in SfDataGrid. SfDataGrid provides three kinds of summary row collections, namely GroupSummaryRows, TableSummaryRows, and CaptionSummaryRows.", DemoViewType = typeof(SummariesDemo), Documentations = summaryDocumentation });

            List<Documentation> intervalGroupingDocumentation = new List<Documentation>();
            intervalGroupingDocumentation.Add(new Documentation { Content = "DataGrid - GroupColumnDescription_Comparer API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GroupColumnDescription.html#Syncfusion_UI_Xaml_Grid_GroupColumnDescription_Comparer") });
            intervalGroupingDocumentation.Add(new Documentation { Content = "DataGrid - GroupColumnDescription_Comparer API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GroupColumnDescription.html#Syncfusion_UI_Xaml_Grid_GroupColumnDescription_Converter") });
            this.Demos.Add(new DemoInfo() { SampleName = "Interval Grouping", GroupName = "DATA PRESENTATION", Description = "This sample showcases the interval grouping capabilities of data in SfDataGrid. The SfDataGrid Supports the interval grouping by enable the interval grouping logic.", DemoViewType = typeof(IntervalGroupingDemo), Documentations = intervalGroupingDocumentation });
            
            List<Documentation> customGroupingDocumentation = new List<Documentation>();
            customGroupingDocumentation.Add(new Documentation { Content = "DataGrid - Custom Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/grouping#custom-grouping") });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Grouping", GroupName = "DATA PRESENTATION", Description = "This sample showcases the custom grouping capabilities in SfDataGrid. The SfDataGrid supports custom grouping which enables you to implement custom grouping logic, if the standard grouping techniques does not meet your requirements.", DemoViewType = typeof(CustomGroupingDemo), Documentations = customGroupingDocumentation });

            List<Documentation> sortBySummaryDocumentation = new List<Documentation>();
            sortBySummaryDocumentation.Add(new Documentation { Content = "DataGrid - Sort by Summary Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/grouping#sorting-groups-based-on-summary-values") });
            this.Demos.Add(new DemoInfo() { SampleName = "Sort by Summary", GroupName = "DATA PRESENTATION", Description = "This sample showcases the sort by summary capabilities of data in SfDataGrid.", DemoViewType = typeof(SortBySummaryDemo), Documentations = sortBySummaryDocumentation });

            List<Documentation> filteringDocumentation = new List<Documentation>();
            filteringDocumentation.Add(new Documentation { Content = "DataGrid - ViewFilter API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Data.CollectionViewAdv.html#Syncfusion_Data_CollectionViewAdv_Filter") });
            filteringDocumentation.Add(new Documentation { Content = "DataGrid - ViewFilter Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/filtering#view-filtering") });
            this.Demos.Add(new DemoInfo() { SampleName = "Filtering", GroupName = "FILTERING", Description = "This sample showcases the filtering capabilities of data in SfDataGrid.", DemoViewType = typeof(FilteringDemo), Documentations = filteringDocumentation });

            List<Documentation> aIViewFilteringDocumentation = new List<Documentation>();
            aIViewFilteringDocumentation.Add(new Documentation { Content = "DataGrid - ViewFilter API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Data.CollectionViewAdv.html#Syncfusion_Data_CollectionViewAdv_Filter") });
            aIViewFilteringDocumentation.Add(new Documentation { Content = "DataGrid - ViewFilter Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/filtering#view-filtering") });
            this.Demos.Add(new DemoInfo() { SampleName = "AI Powered View Filtering", IsAISample = true, Tag = Tag.New, Description = "This sample demonstrates filtering the SfDataGrid based on conditions provided by an AI model. The AI processes user queries to create dynamic filter conditions, which are then applied to the SfDataGrid for real-time filtering. Below are some example queries you can use:\n\t1. Find the Design Engineers whose names start with K.\n\t2. Show the male employees whose rating is greater than 5.\n\nNote: This demo is exclusively for applying filtering-related queries.", GroupName = "FILTERING", AISampleDescription = "This sample demonstrates filtering the SfDataGrid based on natural language queries. The AI will interpret these queries to generate filtering conditions for SfDataGrid's View.", DemoViewType = typeof(AIViewFilterDemo), Documentations = aIViewFilteringDocumentation });

            List<Documentation> advanceFilteringDocumentation = new List<Documentation>();
            advanceFilteringDocumentation.Add(new Documentation { Content = "DataGrid - AllowFiltering API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_AllowFiltering") });
            advanceFilteringDocumentation.Add(new Documentation { Content = "DataGrid - AdvanceFiltering Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/filtering#advanced-filter-ui") });
            this.Demos.Add(new DemoInfo() { SampleName = "Advanced Filtering", GroupName = "FILTERING", Description = "This sample showcases the Excel inspired filtering capabilities of data in SfDataGrid.", DemoViewType = typeof(ExcelLikeFilteringDemo), ThemeMode = ThemeMode.None, Documentations = advanceFilteringDocumentation });

            List<Documentation> aiFilterPredicateDocumentation = new List<Documentation>();
            aiFilterPredicateDocumentation.Add(new Documentation { Content = "DataGrid - AllowFiltering API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_AllowFiltering") });
            aiFilterPredicateDocumentation.Add(new Documentation { Content = "DataGrid - Programmatic Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/filtering#column-filtering") });
            this.Demos.Add(new DemoInfo() { SampleName = "Smart Predicate Filtering", GroupName = "FILTERING", IsAISample = true, Tag = Tag.New, Description = "This sample demonstrates how to filter data in the SfDataGrid by applying filter predicates to specific columns. It showcases the process of defining filtering conditions, including the column names and corresponding filter predicates, with the assistance of an AI model. This approach enables dynamic and intelligent filtering based on data characteristics. Below are some example queries you can use:\n\t1. Show me all the employees who earn more than $2,500.\n\t2. Show me the female employees who are over 45 years old.\n\nNote: This demo is exclusively for applying filtering-related queries.", AISampleDescription = "This sample demonstrates how to filter the SfDataGrid using natural language queries. The AI interprets these queries to generate precise column names and filter predicates.", DemoViewType = typeof(AIFilterPredicatesDemo), Documentations = aiFilterPredicateDocumentation });

            List<Documentation> filterRowDocumentation = new List<Documentation>();
            filterRowDocumentation.Add(new Documentation { Content = "DataGrid - FilterRowPosition API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.FilterRowPosition.html") });
            filterRowDocumentation.Add(new Documentation { Content = "DataGrid - FilterRow Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/filterrow") });
            this.Demos.Add(new DemoInfo() { SampleName = "Filter Row", GroupName = "FILTERING", Description = "This sample showcases the filter row functionalities of SfDataGrid.", DemoViewType = typeof(FilterRowDemo), Documentations = filterRowDocumentation });

            this.Demos.Add(new DemoInfo() { SampleName = "Filter Status Bar", GroupName = "FILTERING", Description = "This sample showcases the Filter Status Bar at the bottom of SfDataGrid which displays the filter conditions in simple context.", DemoViewType = typeof(FilterStatusBarDemo),ThemeMode = ThemeMode.None });

            List<Documentation> customFilterRowDocumentation = new List<Documentation>();
            customFilterRowDocumentation.Add(new Documentation { Content = "DataGrid - Custom Filter Row Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/filterrow#customizing-filter-row-cell") });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Filter Row", GroupName = "FILTERING", Description = "This sample showcases the customization of filter row editors and drop-down options in SfDataGrid.", DemoViewType = typeof(CustomFilterRowDemo), Documentations = customFilterRowDocumentation });

            List<Documentation> searchDocumentation = new List<Documentation>();
            searchDocumentation.Add(new Documentation { Content = "DataGrid - Search API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SearchHelper.html#Syncfusion_UI_Xaml_Grid_SearchHelper_Search_System_String_") });
            searchDocumentation.Add(new Documentation { Content = "DataGrid - Search Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/search") });
            this.Demos.Add(new DemoInfo() { SampleName = "Search", GroupName = "FILTERING", Description = "This sample showcases the search support of SfDataGrid. This allows you to search the DataGrid with options to filter and highlight the search text in cells.", DemoViewType = typeof(SearchPanelDemo), ThemeMode = ThemeMode.None, Documentations = searchDocumentation });

            List<Documentation> masterDetailsViewDocumentation = new List<Documentation>();
            masterDetailsViewDocumentation.Add(new Documentation { Content = "DetailsViewDataGrid - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.DetailsViewDataGrid.html") });
            masterDetailsViewDocumentation.Add(new Documentation { Content = "DetailsView DataGrid - Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/master-details-view") });
            this.Demos.Add(new DemoInfo() { SampleName = "Master Details View", GroupName = "MASTER DETAIL", Description = "This sample showcases the MasterDetailsView capability of SfDataGrid. The SfDataGrid displays hierarchical data in the form of nested tables using master-detail view configuration. In a hierarchical view, all tables in the data source are interconnected by means of relations.", DemoViewType = typeof(MasterDetailsViewDemo), Documentations = masterDetailsViewDocumentation });

            List<Documentation> detailsViewTemplateDocumentation = new List<Documentation>();
            detailsViewTemplateDocumentation.Add(new Documentation { Content = "DetailsView DataGrid - TemplateViewDefinition API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.TemplateViewDefinition.html") });
            detailsViewTemplateDocumentation.Add(new Documentation { Content = "DetailsView DataGrid - DetailsView Template Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/record-template-view") });
            this.Demos.Add(new DemoInfo() { SampleName = "Details View Template", GroupName = "MASTER DETAIL", Description = "This sample showcases the SfDataGrid with a DetailsView Template. It displays major values in each row and detailed information in the details section when the row is expanded. It can be used to load specific details for each row using RowTemplate property of TemplateViewDefinition. ", DemoViewType = typeof(DetailsViewTemplateDemo), ThemeMode = ThemeMode.None, Documentations = detailsViewTemplateDocumentation });

            List<Documentation> dataTableBindingDocumentation = new List<Documentation>();
            dataTableBindingDocumentation.Add(new Documentation { Content = "DetailsView DataGrid - DataTable Binding Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-binding#binding-with-datatable") });
            this.Demos.Add(new DemoInfo() { SampleName = "DataTable Binding", GroupName = "MASTER DETAIL", Description = "This sample showcases the datatable binding capability of DetailsViewDataGrid. The DetailsViewDataGrid supports data sources such as DataTable and custom collection such as List, BindingList, ObservableCollection.", DemoViewType = typeof(DetailsViewDataTableBindingDemo), Documentations = dataTableBindingDocumentation });

            List<Documentation> stackedHeadersDocumentation = new List<Documentation>();
            stackedHeadersDocumentation.Add(new Documentation { Content = "DetailsView DataGrid - StackedHeaders Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/stacked-headers") });
            this.Demos.Add(new DemoInfo() { SampleName = "Stacked Headers", GroupName = "MASTER DETAIL", Description = "This sample showcases the stacked headers capability in DetailsViewDataGrid of SfDataGrid.", DemoViewType = typeof(DetailsViewStackedHeaderRowsDemo), Documentations = stackedHeadersDocumentation });

            List<Documentation> columnTypesDocumentation = new List<Documentation>();
            columnTypesDocumentation.Add(new Documentation { Content = "DetailsView DataGrid - ColumnTypes Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/column-types") });
            this.Demos.Add(new DemoInfo() { SampleName = "Column Types", GroupName = "MASTER DETAIL", Description = "This sample showcases the different column types capabilities in DetailsViewDataGrid. The SfDataGrid allows you to create various types of columns like Editable, Non-Editable and DropDown columns in DetailsViewDataGrid also.", DemoViewType = typeof(DetailsViewColumnTypesDemo), Documentations = columnTypesDocumentation });

            List<Documentation> conditionalFormattingDocumentation = new List<Documentation>();
            conditionalFormattingDocumentation.Add(new Documentation { Content = "DetailsView DataGrid - ConditionalFormatting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/conditional-styling") });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Formatting", GroupName = "MASTER DETAIL", Description = "This sample showcases the conditional formatting capabilities of DetailsViewDataGrid. SfDataGrid control allows you to format the styles of cells and rows based on certain conditions by using converter and StyleSelector in DetailsViewDataGrid.", DemoViewType = typeof(ConditionalFormattingDetailsViewDataGridDemo), ThemeMode= ThemeMode.None, Documentations = conditionalFormattingDocumentation });

            List<Documentation> excelEportingDocumentation = new List<Documentation>();
            excelEportingDocumentation.Add(new Documentation { Content = "DetailsView DataGrid - ExportToExcel API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.Converter.GridExcelExportExtension.html#Syncfusion_UI_Xaml_Grid_Converter_GridExcelExportExtension_ExportToExcel_Syncfusion_UI_Xaml_Grid_SfDataGrid_Syncfusion_Data_ICollectionViewAdv_Syncfusion_UI_Xaml_Grid_Converter_ExcelExportingOptions_") });
            excelEportingDocumentation.Add(new Documentation { Content = "DetailsView DataGrid - Excel Exporting Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/export-to-excel") });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Exporting", GroupName = "MASTER DETAIL", Description = "This sample showcases the excel exporting capability of MasterDetailsView in SfDataGrid.", DemoViewType = typeof(MasterDetailsExportingDemo), Documentations = excelEportingDocumentation });

            List<Documentation> dataVirtualizationDocumentation = new List<Documentation>();
            dataVirtualizationDocumentation.Add(new Documentation { Content = "DataGrid - EnableDataVirtualization API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_EnableDataVirtualization") });
            dataVirtualizationDocumentation.Add(new Documentation { Content = "DataGrid - DataVirtualization Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-virtualization") });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Virtualization", GroupName = "DATA VIRTUALIZATION", Description = "This sample showcases the data virtualization capability of SfDataGrid. Data Virtualization support enables you to work with the huge data sources. SfDataGrid control creates records on-demand by automatically enabling data virtualization when EnableDataVirtualization property set to true.", DemoViewType = typeof(DataVirtualizationDemo), Documentations = dataVirtualizationDocumentation });

            List<Documentation> dataPagingDocumentation = new List<Documentation>();
            dataPagingDocumentation.Add(new Documentation { Content = "DataGrid - SfDataPager API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Controls.DataPager.SfDataPager.html") });
            dataPagingDocumentation.Add(new Documentation { Content = "DataGrid - DataPaging Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/paging") });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Paging", GroupName = "DATA VIRTUALIZATION", Description = "This sample showcases the paging capability of SfDataGrid. Paging support is achieved by using SfDataPager control which return pages of data with entries where selection of the pages can be done using the numbered buttons. Paging loads the entire data collection to the SfDataPager and bind the PagedSource property of the SfDataPager to the ItemsSource property of SfDataGrid.", DemoViewType = typeof(DataPagingDemo), Documentations = dataPagingDocumentation });

            List<Documentation> onDemandPagingDocumentation = new List<Documentation>();
            onDemandPagingDocumentation.Add(new Documentation { Content = "DataGrid - On-DemandPaging Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/paging#load-data-in-on-demand") });
            this.Demos.Add(new DemoInfo() { SampleName = "On-Demand Paging", GroupName = "DATA VIRTUALIZATION", Description = "This sample showcases the on-demand paging capabilities of SfDataGrid. On-demand paging supports current page item source adds by on demand basis. The entire data is not needed to be fetched from the data source and we can get high performance even if there are millions of records. Also we can load millions of records in an efficient way.", DemoViewType = typeof(OnDemandPagingDemo), Documentations = onDemandPagingDocumentation });
            //this.Demos.Add(new DemoInfo() { SampleName = "Incremental Loading", GroupName = "DATA VIRTUALIZATION", Description = "This sample showcases the incremental loading capabilities of SfDataGrid. Incremental loading allows you to load a set of data from whole data source to SfDataGrid and it provides support with fast and fluid scrolling and loading the huge set of data. You can enable incremental loading in SfDataGrid by creating a data source with IncrementalList class which implements the ISupportIncrementalLoading interface internally. In this, Sorting, Filtering, Grouping and Summaries will be applied only for loaded data.", DemoViewType = typeof(IncrementalLoadingDemo) });

            List<Documentation> editingDocumentation = new List<Documentation>();
            editingDocumentation.Add(new Documentation { Content = "DataGrid - AllowEditing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_AllowEditing") });
            editingDocumentation.Add(new Documentation { Content = "DataGrid - EditTrigger API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_EditTrigger") });
            editingDocumentation.Add(new Documentation { Content = "DataGrid - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/editing") });
            this.Demos.Add(new DemoInfo() { SampleName = "Editing", GroupName = "EDITING", Description = "This sample showcases the editing capability in SfDataGrid. SfDataGrid provided options to trigger the edit mode by either with single or double click.", DemoViewType = typeof(EditingAndDataValidationDemo), Documentations = editingDocumentation });
            this.Demos.Add(new DemoInfo() { SampleName = "Editable Columns", GroupName = "EDITING", Description = "This sample showcases the editable columns capability of SfDataGrid. SfDataGrid provides different editable columns such as GridTextColumn, GridNumericColumn, GridCurrencyColumn, GridPercentColumn, GridMaskColumn, GridTimeSpanColumn, GridTemplateColumn and GridUnboundColumn.", DemoViewType = typeof(GridColumnsDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Dropdown and Read Only Columns", GroupName = "EDITING", Description = "This sample showcases the dropdown and readonly columns capability of SfDataGrid. The SfDataGrid supports various types of dropdown and readonly columns like DateTimeColumn, ComboboxColumn, MultiColumnDropDownList, TemplateColumn, ImageColumn and HyperLinkColumn.", DemoViewType = typeof(GridDropDownAndReadOnlyColumnsDemo) });

            List<Documentation> comboBoxColumnDocumentation = new List<Documentation>();
            comboBoxColumnDocumentation.Add(new Documentation { Content = "DataGrid - GridComboBoxColumn API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridComboBoxColumn.html") });
            comboBoxColumnDocumentation.Add(new Documentation { Content = "DataGrid - ComboBox Column Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/column-types#gridcomboboxcolumn") });
            this.Demos.Add(new DemoInfo() { SampleName = "ComboBox Column", GroupName = "EDITING", Description = "This sample showcases the loading of different ItemsSource for different rows in GridComboBoxColumn based on data object.", DemoViewType = typeof(ComboBoxColumnsDemo), Documentations = comboBoxColumnDocumentation });

            List<Documentation> addNewRowDocumentation = new List<Documentation>();
            addNewRowDocumentation.Add(new Documentation { Content = "DataGrid - AddNewRowPosition API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_AddNewRowPosition") });
            addNewRowDocumentation.Add(new Documentation { Content = "DataGrid - AddNewRow Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-manipulation#add-new-rows") });
            this.Demos.Add(new DemoInfo() { SampleName = "Add New Row", GroupName = "ROWS", Description = "This sample showcases adding the new record at runtime in SfDataGrid by AddNewRow feature. The AddNewRow is displayed, above or below the rows in the SfDataGrid based on AddNewRowPosition property.", DemoViewType = typeof(AddNewRowDemo), Documentations = addNewRowDocumentation });

            List<Documentation> stackedheadersDocumentation = new List<Documentation>();
            stackedheadersDocumentation.Add(new Documentation { Content = "DataGrid - StackedHeaderRow API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.StackedHeaderRow.html") });
            stackedheadersDocumentation.Add(new Documentation { Content = "DataGrid - Stacked Headers Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/stacked-headers") });
            this.Demos.Add(new DemoInfo() { SampleName = "Stacked headers", GroupName = "ROWS", Description = "This sample showcases the stacked headers capability in DetailsViewDataGrid of SfDataGrid.", DemoViewType = typeof(StackedHeaderRowsDemo), Documentations = stackedheadersDocumentation });

            List<Documentation> autoRowHeightDocumentation = new List<Documentation>();
            autoRowHeightDocumentation.Add(new Documentation { Content = "DataGrid - QueryRowHeight API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_QueryRowHeight") });
            autoRowHeightDocumentation.Add(new Documentation { Content = "DataGrid - Auto Row Height Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/row-height-customization?cs-save-lang=1&cs-lang=csharp#fit-the-row-height-based-on-its-content") });
            this.Demos.Add(new DemoInfo() { SampleName = "Auto RowHeight", GroupName = "ROWS", Description = "This sample showcases the auto row height feature of SfDataGrid which improves the readability of the content and occurs on-demand basis. It does not affect the loading performance of the SfDataGrid and provides support to change the height of the row based on its content on-demand based for all columns or certain columns of SfDataGrid.", DemoViewType = typeof(AutoRowHeightDemo), Documentations = autoRowHeightDocumentation });

            List<Documentation> unboundRowDocumentation = new List<Documentation>();
            unboundRowDocumentation.Add(new Documentation { Content = "DataGrid - UnBoundRows API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_UnBoundRows") });
            unboundRowDocumentation.Add(new Documentation { Content = "DataGrid - UnBound Rows Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/unbound-rows") });
            this.Demos.Add(new DemoInfo() { SampleName = "Unbound Row", GroupName = "ROWS", Description = "This sample showcases unbound rows support of SfDataGrid. The SfDataGrid provides support to place the Unbound Row at the top and the bottom of record rows and also have the option to place them above or below the Table summary row.", DemoViewType = typeof(UnBoundRowDemo), Documentations = unboundRowDocumentation });

            List<Documentation> unboundColumnDocumentation = new List<Documentation>();
            unboundColumnDocumentation.Add(new Documentation { Content = "DataGrid - GridUnBoundColumn API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridUnBoundColumn.html") });
            unboundColumnDocumentation.Add(new Documentation { Content = "DataGrid - UnBound Columns Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/unbound-column") });
            this.Demos.Add(new DemoInfo() { SampleName = "Unbound column", GroupName = "COLUMNS", Description = "This sample showcases the unbound column capability of SfDataGrid. SfDataGrid supports the addition of extra columns to the data source columns. These additional columns are called as unbound columns, as they do not belong to the data source. Unbound column has two features like Expression and Format and these unbound fields are used when you want to add additional or custom information to each record. An unbound column is sorted, grouped, and filtered like other GridColumns.", DemoViewType = typeof(UnBoundColumnsDemo), Documentations = unboundColumnDocumentation });

            List<Documentation> columnSizerDocumentation = new List<Documentation>();
            columnSizerDocumentation.Add(new Documentation { Content = "DataGrid - ColumnSizer API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_ColumnSizer") });
            columnSizerDocumentation.Add(new Documentation { Content = "DataGrid - Column Sizer Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/autosize-columns") });
            this.Demos.Add(new DemoInfo() { SampleName = "Column Sizer", GroupName = "COLUMNS", Description = "This sample showcases the different types of column sizer capabilities in SfDataGrid. The SfDataGrid provides in-built feature for customizing the width of the column based on the data present in the cell by defining the ColumnSizer property. This property has different ColumnSizer options like Auto, AutoWithLastColumnFill, SizeToCells, SizeToHeader, Star and None.", DemoViewType = typeof(ColumnSizerDemo), Documentations = columnSizerDocumentation });

            List<Documentation> cellMergeDocumentation = new List<Documentation>();
            cellMergeDocumentation.Add(new Documentation { Content = "DataGrid - Merge Cell Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/merge-cells") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Merge", GroupName = "COLUMNS", Description = "This sample showcases the merged cells based on data in SfDataGrid by QueryCoveredRange event.", DemoViewType = typeof(CellMergeDemo), Documentations = cellMergeDocumentation });
            this.Demos.Add(new DemoInfo() { SampleName = "Auto Cell Merge", GroupName = "COLUMNS", Description = "This sample showcases the Merged cell feature of SfDataGrid.", DemoViewType = typeof(AutoCellMergeDemo) });

            List<Documentation> dataValidationDocumentation = new List<Documentation>();
            dataValidationDocumentation.Add(new Documentation { Content = "DataGrid - DataValidation API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_GridValidationMode") });
            dataValidationDocumentation.Add(new Documentation { Content = "DataGrid - Data Validation Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-validation") });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Validation", GroupName = "DATA VALIDATION", Description = "This sample showcases the data validation capability in SfDataGrid by implementing IDataErrorInfo interface.", DemoViewType = typeof(DataValidationDemo), Documentations = dataValidationDocumentation });

            List<Documentation> customValidationDocumentation = new List<Documentation>();
            customValidationDocumentation.Add(new Documentation { Content = "DataGrid - Custom Validation Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/data-validation#custom-validation-through-events") });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Validation", GroupName = "DATA VALIDATION", Description = "This sample showcases the custom validation capability based on certain conditions in SfDataGrid.", DemoViewType = typeof(CustomValidationDemo), Documentations = customValidationDocumentation });

            List<Documentation> rowSelectionDocumentation = new List<Documentation>();
            rowSelectionDocumentation.Add(new Documentation { Content = "DataGrid - GridSelectionUnit API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridSelectionUnit.html") });
            rowSelectionDocumentation.Add(new Documentation { Content = "DataGrid - GridSelectionMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridSelectionMode.html") });
            rowSelectionDocumentation.Add(new Documentation { Content = "DataGrid - Row Selection Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/selection#row-selection") });
            this.Demos.Add(new DemoInfo() { SampleName = "Row Selection", GroupName = "SELECTIONS", Description = "This sample showcases the cell selection capability of SfDataGrid. SfDataGrid control provides an interactive support for selecting cells in different mode with smooth and ease manner by SelectionUnit as Cell or Any and NavigationMode should be Cell. SfDataGrid allows you to select more than one cell at a time by using SelectionMode property of SfDataGrid. This property provides options like Single, Multiple, Extended and None.", DemoViewType = typeof(SelectionDemo), Documentations = rowSelectionDocumentation });

            List<Documentation> cellSelectionDocumentation = new List<Documentation>();
            cellSelectionDocumentation.Add(new Documentation { Content = "DataGrid - Cell Selection Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/selection#cell-selection") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Selection", GroupName = "SELECTIONS", Description = "This sample showcases the cell selection capability of SfDataGrid. SfDataGrid control provides an interactive support for selecting cells in different mode with smooth and ease manner by SelectionUnit as Cell or Any and NavigationMode should be Cell. SfDataGrid allows you to select more than one cell at a time by using SelectionMode property of SfDataGrid. This property provides options like Single, Multiple, Extended and None.", DemoViewType = typeof(CellSelectionDemo),Documentations = cellSelectionDocumentation });

            List<Documentation> checkboxSelectoColumnDocumentation = new List<Documentation>();
            checkboxSelectoColumnDocumentation.Add(new Documentation { Content = "DataGrid - GridCheckBoxSelectorColumn API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridCheckBoxSelectorColumn.html") });
            checkboxSelectoColumnDocumentation.Add(new Documentation { Content = "DataGrid - GridCheckBoxSelector Column Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/column-types#gridcheckboxselectorcolumn") });
            this.Demos.Add(new DemoInfo() { SampleName = "CheckBox Selector Column", GroupName = "SELECTIONS", Description = "This sample showcases the DataGrid with a grid check-box-selector column. It displays check boxes for all the rows to allow users to select or deselect them by clicking on them.", DemoViewType = typeof(CheckBoxSelectorColumnDemo), Documentations = checkboxSelectoColumnDocumentation });

            this.Demos.Add(new DemoInfo() { SampleName = "Real time updates", GroupName = "PERFORMANCE", Description = "This sample showcases real time updates capability of SfDataGrid. SfDataGrid has a high performance standard, where you can make the grid to work with large amounts of data with few property settings, without a performance hit. It provides complete support for Virtual Mode, where the data will be loaded only on demand and thus saves the memory consumption and provides quick response. It also handles very high frequency updates and refresh scenarios.", DemoViewType = typeof(PerformanceDemo) });

            List<Documentation> scrollPerformanceDocumentation = new List<Documentation>();
            scrollPerformanceDocumentation.Add(new Documentation { Content = "DataGrid - Scroll Performance Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/performance#improving-scrolling-performance") });
            this.Demos.Add(new DemoInfo() { SampleName="Scroll Performance", GroupName= "PERFORMANCE", Description= "This sample illustrates the loading and scrolling performance of SfDataGrid.", DemoViewType=typeof(ScrollPerformanceDemo), Documentations = scrollPerformanceDocumentation });
           
            List<Documentation> traderGridDocumentation = new List<Documentation>();
            traderGridDocumentation.Add(new Documentation { Content = "DataGrid - ScrollMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_ScrollMode") });
            this.Demos.Add(new DemoInfo() { SampleName = "Trader Grid", GroupName = "PERFORMANCE", Description = "This sample illustrates the frequent updates that occur in random cells across the Grid, while keeping the CPU usage to a minimum in the SfDataGrid.", DemoViewType = typeof(TradingGridDemo), Documentations = traderGridDocumentation });

            List<Documentation> alternateRowStyleDocumentation = new List<Documentation>();
            alternateRowStyleDocumentation.Add(new Documentation { Content = "DataGrid - AlternateRowStyle API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_AlternatingRowStyle") });
            alternateRowStyleDocumentation.Add(new Documentation { Content = "DataGrid - Alternate RowStyle Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/styles-and-templates#alternating-row-style") });
            this.Demos.Add(new DemoInfo() { SampleName = "Alternate Row Style", GroupName = "APPEARANCE", Description = "This sample showcases the alternate row style capability of SfDataGrid. By default, the style is applied for every alternative second row and change it by using AlternationCount property.", DemoViewType = typeof(AlternateRowStyleDemo), ThemeMode = ThemeMode.None, Documentations = alternateRowStyleDocumentation });

            List<Documentation> stylingDocumentation = new List<Documentation>();
            stylingDocumentation.Add(new Documentation { Content = "DataGrid - GridLinesVisibility API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_GridLinesVisibility") });
            stylingDocumentation.Add(new Documentation { Content = "DataGrid - HeaderLineVisibility API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_HeaderLinesVisibility") });
            stylingDocumentation.Add(new Documentation { Content = "DataGrid - Styling Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/styles-and-templates") });
            this.Demos.Add(new DemoInfo() { SampleName = "Styling", GroupName = "APPEARANCE", Description = "This sample showcases the styling capability of SfDataGrid.", DemoViewType = typeof(StylingDemo), ThemeMode = ThemeMode.None, Documentations = stylingDocumentation });

            List<Documentation> freezePanesDocumentation = new List<Documentation>();
            freezePanesDocumentation.Add(new Documentation { Content = "DataGrid - FreezePanes Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/rows#freeze-panes") });
            this.Demos.Add(new DemoInfo() { SampleName = "Freeze Panes", GroupName = "APPEARANCE", Description = "This sample showcases the freeze panes capability of SfDataGrid. The SfDataGrid provides support to freeze rows and columns at the top and also at the bottom similar to Excel Freeze Panes with the help of FrozenRowCount, FooterRowsCount, FrozenColumnCount and FooterColumnCount.", DemoViewType = typeof(FreezePanesDemo), Documentations = freezePanesDocumentation });
            
            List<Documentation> conditionalCellStyleDocumentation = new List<Documentation>();
            conditionalCellStyleDocumentation.Add(new Documentation { Content = "DataGrid - Conditional CellStyle Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/conditional-styling#cell-style") });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Cell Style", GroupName = "APPEARANCE", Description = "This sample showcases the conditional formatting capability of SfDataGrid. The SfDataGrid control allows you to format the styles of cells and rows based on certain conditions by using Converter and StyleSelector.", DemoViewType = typeof(ConditionalFormattingDemo), ThemeMode= ThemeMode.None, Documentations = conditionalCellStyleDocumentation });

            List<Documentation> cellAnimationDocumentation = new List<Documentation>();
            cellAnimationDocumentation.Add(new Documentation { Content = "DataGrid - Cell Animation Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/styles-and-templates#animating-the-data-cell-when-property-changes") });
            this.Demos.Add(new DemoInfo() { SampleName = "Cell Animation", GroupName = "APPEARANCE", Description = "This sample showcases the cell animation capability to animate the cells in SfDataGrid. SfDataGrid provides support to animate the cell when the underlying property gets changed by using the behaviors with the help of ColorAnimation.", DemoViewType = typeof(CellAnimationDemo), ThemeMode = ThemeMode.None, Documentations = cellAnimationDocumentation });

            List<Documentation> conditionalRowStylesDocumentation = new List<Documentation>();
            conditionalRowStylesDocumentation.Add(new Documentation { Content = "DataGrid - Conditional RowStyle Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/conditional-styling#row-style") });
            this.Demos.Add(new DemoInfo() { SampleName = "Conditional Row Style", GroupName = "APPEARANCE", Description = "This sample showcases the row style customization in SfDataGrid by StyleSelector.", DemoViewType = typeof(RowStyleDemo), ThemeMode= ThemeMode.None, Documentations = conditionalRowStylesDocumentation });

            List<Documentation> contextMenuDocumentation = new List<Documentation>();
            contextMenuDocumentation.Add(new Documentation { Content = "DataGrid - Context Menu Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/context-menu") });
            this.Demos.Add(new DemoInfo() { SampleName = "Context Menu", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases the context menu capabilities of SfDataGrid. ContextMenu in SfDataGrid is entirely customizable menu for the extensible functionalities of the Grid. ContextMenu is enabled for various parts of the Grid with the appropriate APIs. SfDataGrid has a set of APIs that allows access to the context menu in various parts of the Grid.", DemoViewType = typeof(ContextMenuDemo), ThemeMode= ThemeMode.None, Documentations = contextMenuDocumentation });

            List<Documentation> columnChooserDocumentation = new List<Documentation>();
            columnChooserDocumentation.Add(new Documentation { Content = "DataGrid - Column Chooser Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/interactive-features#column-chooser") });
            this.Demos.Add(new DemoInfo() { SampleName = "Column Chooser", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases the column chooser capability of SfDatagrid. Column Chooser allows you to add or remove columns dynamically from the current Grid view using drag-and-drop operations.", DemoViewType = typeof(ColumnChooserDemo), DemoLauchMode = DemoLauchMode.Window, ThemeMode= ThemeMode.None, Documentations = columnChooserDocumentation });

            List<Documentation> clipBoardOperationDocumentation = new List<Documentation>();
            clipBoardOperationDocumentation.Add(new Documentation { Content = "DataGrid - GridCopyOption API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_GridCopyOption") });
            clipBoardOperationDocumentation.Add(new Documentation { Content = "DataGrid - GridPasteOption API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_GridPasteOption") });
            clipBoardOperationDocumentation.Add(new Documentation { Content = "DataGrid - ClipBoard Operation Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/clipboard-operations") });
            this.Demos.Add(new DemoInfo() { SampleName = "Clipboard Operation", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases the clipboard operation capabilities of SfDataGrid. The SfDataGrid, provides an interactive support to perform cut, copy and paste operations by using GridCopyOption and GridPasteOption properties. The GridCopyOption provides options like None, CopyData, CutData, IncludeHeaders, and IncludeFormat and the GridPasteOption provides options like None, PasteData, IncludeFirstLine.", DemoViewType = typeof(CutCopyPasteDemo), Documentations = clipBoardOperationDocumentation });

            List<Documentation> dragAndDropDocumentation = new List<Documentation>();
            dragAndDropDocumentation.Add(new Documentation { Content = "DataGrid - AllowDraggingRows API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_AllowDraggingRows") });
            dragAndDropDocumentation.Add(new Documentation { Content = "DataGrid - Drag and Drop Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/drag-and-drop") });
            this.Demos.Add(new DemoInfo() { SampleName = "Drag and Drop", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases the built-in row drag and drop capability of SfDataGrid.", DemoViewType = typeof(DragAndDropDemo), Documentations = dragAndDropDocumentation });

            List<Documentation> serializationDocumentation = new List<Documentation>();
            serializationDocumentation.Add(new Documentation { Content = "DataGrid - Serialize API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_Serialize_System_IO_Stream_") });
            serializationDocumentation.Add(new Documentation { Content = "DataGrid - Deserialize API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_Deserialize_System_IO_Stream_") });
            serializationDocumentation.Add(new Documentation { Content = "DataGrid - Serialize and Deserialize Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/serialization-and-deserialization") });
            this.Demos.Add(new DemoInfo() { SampleName = "Serialization", GroupName = "SERIALIZATION", Description = "This sample showcases the serialization and deserialization capability of SfDataGrid. By customizing SerializationController, you can serialize and deserialize derived DataGrid and custom column also.", DemoViewType = typeof(SerializationDemo), ThemeMode = ThemeMode.None, Documentations = serializationDocumentation });

            List<Documentation> excelExportingDocumentation = new List<Documentation>();
            excelExportingDocumentation.Add(new Documentation { Content = "DataGrid - ExportToExcel API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.Converter.GridExcelExportExtension.html#Syncfusion_UI_Xaml_Grid_Converter_GridExcelExportExtension_ExportToExcel_Syncfusion_UI_Xaml_Grid_SfDataGrid_Syncfusion_Data_ICollectionViewAdv_Syncfusion_UI_Xaml_Grid_Converter_ExcelExportingOptions_") });
            excelExportingDocumentation.Add(new Documentation { Content = "DataGrid - ExportToExcel Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/export-to-excel") });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel Exporting", GroupName = "EXPORT & PRINT", Description = "This sample showcases the excel exporting capability of SfDataGrid. The SfGridConverter assembly helps to provide support for exporting data from a SfDataGrid to an Excel spreadsheet. Our XlsIO libraries are used to support the conversion of the SfDataGrid contents to Excel. It also supports to export the selected ranges of SfDataGrid content to Excel.", DemoViewType = typeof(ExportingDemo), Documentations = excelExportingDocumentation });

            List<Documentation> pdfExportingDocumentation = new List<Documentation>();
            pdfExportingDocumentation.Add(new Documentation { Content = "DataGrid - ExportToPDF API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.Converter.GridPdfExportExtension.html#Syncfusion_UI_Xaml_Grid_Converter_GridPdfExportExtension_ExportToPdf_Syncfusion_UI_Xaml_Grid_SfDataGrid_") });
            pdfExportingDocumentation.Add(new Documentation { Content = "DataGrid - ExportToPDF Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/export-to-pdf") });
            this.Demos.Add(new DemoInfo() { SampleName = "PDF Exporting", GroupName = "EXPORT & PRINT", Description = "This sample showcases the PDF exporting capability of SfDataGrid. The SfGridConverter assembly helps to provide support for exporting data from a SfDataGrid to a PDF file. Our Pdf.Base libraries are used to support the conversion of the SfDataGrid contents to PDF. The exporting to PDF provides the options like Auto Column Width, Auto Row Height, Export Groups, Export Group Summaries, Export Table Summaries, Repeat Headers, Fit All Columns in one page and export all to pdf, export selected items to PDF.", DemoViewType = typeof(PdfExportingDemo), Documentations = pdfExportingDocumentation });

            List<Documentation> printingDocumentation = new List<Documentation>();
            printingDocumentation.Add(new Documentation { Content = "DataGrid - Print API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_Print") });
            printingDocumentation.Add(new Documentation { Content = "DataGrid - ShowPrintPreview API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_ShowPrintPreview") });
            printingDocumentation.Add(new Documentation { Content = "DataGrid - Printing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/printing") });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing", GroupName = "EXPORT & PRINT", Description = "This sample showcases the printing capabilities of SfDataGrid. The SfDataGrid control allows you to print the data displayed in the DataGrid. The GridPrintManager of SfDataGrid is designed to support different orientations, sizes, margins, etc. you can change print settings using the print settings property of SfDataGrid.", DemoViewType = typeof(PrintingDemo), Documentations = printingDocumentation });

            List<Documentation> printingCustomizationDocumentation = new List<Documentation>();
            printingCustomizationDocumentation.Add(new Documentation { Content = "DataGrid - GridPrintManager API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridPrintManager.html") });
            printingCustomizationDocumentation.Add(new Documentation { Content = "DataGrid - Printing Customization Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/printing#printing-customization") });
            this.Demos.Add(new DemoInfo() { SampleName = "Printing Customization", GroupName = "EXPORT & PRINT", Description = "This sample showcases the custom printing capabilities of SfDataGrid. SfDataGrid provide options to customize the content while printing by CustomPrintManager. This sample demonstrates the CustomPrintManager support to meet the required level of customization.", DemoViewType = typeof(CustomPrintingDemo), Documentations = printingCustomizationDocumentation });

            List<Documentation> localizationDocumentation = new List<Documentation>();
            localizationDocumentation.Add(new Documentation { Content = "DataGrid - Localization Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/localization") });
            this.Demos.Add(new DemoInfo() { SampleName = "Localization", GroupName = "LOCALIZATION", Description = "This sample showcases the localization capability of SfDataGrid. Localization is the process of making your application multi-lingual, by formatting content according to cultures.", DemoViewType = typeof(DataGridLocalizationDemo), Documentations = localizationDocumentation });
            
        }
    }
}
