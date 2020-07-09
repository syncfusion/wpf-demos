#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Collections.Generic;

namespace SfTreeNavigator
{
    /// <summary>
    /// Class represents the behaviour or business logic for MainWindow.xaml.
    /// </summary>
    public class ViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the list of toolKits;
        /// </summary>
        private List<Model> toolKits;

        /// <summary>
        /// Maintains the selected item.
        /// </summary>
        private object treeSelection;

        /// <summary>
        /// Initializes the new instance of <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            ToolKits = new List<Model>();
            PopulateWinRTControls();
            PopulateWPFControls();
            PopulateSilverLight();
            PopulateWindowsPhone();
            PopulateMetroStudio();
            PopulateOurBaseStudio();
        }

        /// <summary>
        /// Gets or sets the toolKits for tree navigator.<see cref="ViewModel"/> class.
        /// </summary>
        public List<Model> ToolKits
        {
            get
            {
                return toolKits;
            }
            set
            {
                toolKits = value;
                RaisePropertyChanged("ToolKits");
            }
        }

        /// <summary>
        /// Gets or sets the selected item from tree navigator <see cref="ViewModel"/> class.
        /// </summary>
        public object TreeSelection
        {
            get
            {
                return treeSelection;
            }
            set
            {
                treeSelection = value;
                RaisePropertyChanged("TreeSelection");
            }
        }

        /// <summary>
        /// Method used to populate the winrt controls.
        /// </summary>
        public void PopulateWinRTControls()
        {
            Model winrt = new Model() { Header = "WinRT (XAML)", ToolsDescription = "Essential Studio for WinRT contains all the controls you need to build line-of-business applications, including charts, gauges, maps, diagrams, and radial menus. It also includes a unique set of controls for reading and writing Excel, Word, and PDF documents in Windows store apps." };

            Model winrtChart = new Model() { Header = "Chart", ToolsDescription= "Essential Chart for WinRT is a high-performance, visually stunning charting component that is easy to use. It includes common chart types ranging from line charts to specialized financial charts. It incorporates DirectX rendering to deliver the best possible performance." };
            Model winrtGauge = new Model() { Header = "Gauge", ToolsDescription = "Essential Gauge for WinRT is a highly customizable gauge control used to visualize a given value over a circular scale. All its elements—scales, ticks, pointers, and labels—can be customized as needed." };
            Model winrtDiagram = new Model() { Header = "Diagram", ToolsDescription = "Essential Diagram for WinRT creates feature-rich diagrams for Windows store applications. It can compose diagrams and workflows visually, using touch interactions, or automatically, laying out elements according to set rules." };
            Model winrtMaps = new Model() { Header = "Maps", ToolsDescription = "Essential Maps for WinRT is a powerful data-visualization control that can be used to articulate data as a map. It is frequently used in financial dashboards for plotting sales across geography." };
            Model winrtRadialMenu = new Model() { Header = "Radial Menu", ToolsDescription = "The radial menu displays a hierarchical menu in a circular layout optimized for touch devices. Typically used as a context menu, it can expose more menu items in the same space than traditional menus." };
            Model winrtCarousel = new Model() { Header = "Carousel", ToolsDescription = "The carousel arranges items in an album-cover browser similar to iTunes. This layout is optimized for browsing a list of items on a touch device. Simply swipe to reveal the next item in a list." };
            Model winrtTabControl = new Model() { Header = "Tab Control", ToolsDescription = "The Tab control displays items as tabs, enabling better space utilization within a page. Tabs can be positioned to the top, bottom, left, or right of a page." };
            Model winrtDate = new Model() { Header = "Date Picker", ToolsDescription = "The date picker provides an interface for quickly selecting dates on touch devices." };
            Model winrtTime = new Model() { Header = "Time Picker", ToolsDescription = "The time picker provides an interface for quickly selecting time intervals on touch devices." };
            Model winrtTileView = new Model() { Header = "TileView", ToolsDescription = "The tile view displays an item in a maximized state while other items remain minimized. Each item can have a different data template for its minimized or maximized state. This control is useful for dashboards where single components need to be analyzed in detail one at a time." };
            Model winrtRating = new Model() { Header = "Rating", ToolsDescription = "The Rating control lets you quickly select a value from a group of symbols shown in sequence. The appearance and the selection behavior of the control are completely customizable. For example, you can visualize the rating control as a sequence of diamonds instead of the default star shapes, if required." };
            Model winrtSlider = new Model() { Header = "Range Slider", ToolsDescription = "The range slider extends the framework's slider control, adding the capability to select a range instead of a single value." };
            Model winrtHubTile = new Model() { Header = "HubTile", ToolsDescription = "Hub tiles, a type of content control, display live tiles within an application user interface. Content updates are shown through a variety of animations, similar to the live tile updates of the Windows 8 start screen." };
            Model winrtExtended = new Model() { Header = "Extended TextBox", ToolsDescription = "This extended text box adds several capabilities to the framework version, such as auto-complete, data validation, and watermarking." };
            Model winrtNumeric = new Model() { Header = "Numeric Text Box", ToolsDescription = "The numeric text box can restrict input to numbers, providing several options for formatting number values, such as currency or percentage." };
            Model winrtDomainUpDown = new Model() { Header = "Domain Up-Down", ToolsDescription = "The DomainUpDown control lets users select from a list of options by cycling through them one by one, using the provided up and down buttons." };
            Model winrtNumericUpDown = new Model() { Header = "Numeric Up-Down", ToolsDescription = "The NumericUpDown control lets users increase or decrease a number, one increment at a time, using the provided increment and decrement buttons." };
            Model winrtXlsIO = new Model() { Header = "Essential XlsIO", ToolsDescription = "Essential XlsIO is a powerful class library that enables Windows store applications to read and write Microsoft Excel files. It exposes a comprehensive object model that covers most of the functionality Excel itself offers, making it possible to create reports that contain advanced elements like charts and pivot tables. All versions of Excel 97-2013 are supported." };
            Model winrtDocIO = new Model() { Header = "Essential DocIO", ToolsDescription = "Essential DocIO is a class library that enables Windows store applications to read and write Microsoft Word files. Its object model covers most of the functionality Word offers. Create reports with advanced elements like headers, footers, bookmarks, styles, and tables. All versions of Word 97-2013 are supported." };
            Model winrtPDF = new Model() { Header = "Essential PDF", ToolsDescription = "Essential PDF is a class library that enables Windows store applications to read and write Adobe PDF files. It has an object model that provides most of the functionality offered in a PDF, making it possible to create reports with advanced elements like headers, footers, bookmarks, styles, and tables. It is even possible to fill form fields in existing PDF documents and secure them with a password." };

            winrt.ToolKits.Add(winrtChart);
            winrt.ToolKits.Add(winrtGauge);
            winrt.ToolKits.Add(winrtDiagram);
            winrt.ToolKits.Add(winrtMaps);
            winrt.ToolKits.Add(winrtRadialMenu);
            winrt.ToolKits.Add(winrtCarousel);
            winrt.ToolKits.Add(winrtTabControl);
            winrt.ToolKits.Add(winrtDate);
            winrt.ToolKits.Add(winrtTime);
            winrt.ToolKits.Add(winrtTileView);
            winrt.ToolKits.Add(winrtRating);
            winrt.ToolKits.Add(winrtSlider);
            winrt.ToolKits.Add(winrtHubTile);
            winrt.ToolKits.Add(winrtExtended);
            winrt.ToolKits.Add(winrtNumeric);
            winrt.ToolKits.Add(winrtDomainUpDown);
            winrt.ToolKits.Add(winrtNumericUpDown);
            winrt.ToolKits.Add(winrtXlsIO);
            winrt.ToolKits.Add(winrtDocIO);
            winrt.ToolKits.Add(winrtPDF);

            ToolKits.Add(winrt);
        }

        /// <summary>
        /// Method used to populate WPF controls.
        /// </summary>
        public void PopulateWPFControls()
        {
            Model wpf = new Model() { Header = "WPF", ToolsDescription = "Essential Studio for WPF contains all the controls that you need for building typical line-of-business web applications including grids, charts, gauges, menus, calendars, editors, and much more. It also includes some unique controls that enable your applications to read and write Excel, Word, and PDF documents." };

            Model wpfGridDataControl = new Model() { Header = "GridData Control", ToolsDescription = "The GridData control for WPF is the most advanced data grid available in the market with unmatched performance and versatility. Its advanced feature set is exposed through a powerful yet easy-to-use API with countless customization options. You can easily get started data-binding the grid to any data source; format the data with a rich selection of cell types; and enable editing, sorting, filtering, and grouping within a few minutes. The seamless editing experience rivals that of Microsoft Excel itself. The GridData control has been designed especially for the WPF platform and makes use of all the nuances the platform has to offer. It is also MVVM compatible." };
            Model wpfGridControl = new Model() { Header = "Grid Control", ToolsDescription = "The cell-oriented Grid control is a very efficient display engine for tabular data that can be customized down to the cell level. It does not make any assumptions about the structure of the data. It can be used in a virtual manner where the data is provided on demand in real time, or it can be used in a manner where the Grid control maintains the data within its own internal structures. The Grid control supports frozen rows and columns; Excel-like formulas; covered cells; various cell-control types; copy–paste; both row selections and cell-range selections; hidden rows and columns; and virtually an unlimited number of rows and columns." };
            Model wpfSpreadSheet = new Model() { Header = "SpreadSheet", ToolsDescription = "Essential Spreadsheet is a control for viewing and editing Microsoft Excel files in a familiar Excel-like interface without Excel installed. It combines some of our most popular components like our Grid control, Ribbon control, formula engine, and others to create a first of its kind offering for WPF for viewing and editing Excel files." };
            Model wpfGridTreeControl = new Model() { Header = "Grid Tree Control", ToolsDescription = "The GridTree control is a grid that displays self-referencing lists in a multicolumn tree format. The data is loaded on demand so that large lists can be quickly displayed. Direct support for a classic tree look is provided, but it also gives you the ability to easily customize the look of the tree with special glyphs and icons. Exceptional performance is possible such that thousands of nodes can be expanded or collapsed instantaneously." };
            Model wpfBIGrid = new Model() { Header = "BI Grid" , ToolsDescription = "Use Essential BI Grid to summarize, analyze, explore, and present summaries for critical enterprise data, allowing informed decisions to be made. Data source support ranges from SQL Server Analysis Services to any XMLA-compatible OLAP databases like Mondrian. With our in-memory pivot engine, you can also bind to any standard relational data sources. Use it in your web or Windows development using the variants built natively for each of these platforms: ASP.NET, ASP.NET MVC (HTML 5-enhanced), Silverlight, and WPF." };
            Model wpfBIPivotGrid = new Model() { Header = "BI PivotGrid" , ToolsDescription = "Essential BI PivotGrid is a powerful pivot table implementation for visualizing relational data in a multidimensional UI. The PivotGrid, as the name implies, pivots the data to organize it in a cross-tabulated form. The PivotGrid is just like our BI Grid, but works with relational data. Our powerful in-memory pivoting engine can transform hundreds of thousands of relational table rows into comprehensible pivot information within seconds. Along with pivoting, summarizing and grouping data are also supported." };
            Model wpfChart = new Model() { Header = "Chart", ToolsDescription = "Essential Chart for WPF is a high-performance charting component that is very easy to use and is also visually stunning. It includes 37 chart types ranging from simple column charts to specialized financial charts. It is designed especially for the WPF platform and makes use of all the nuances that the platform has to offer, such as template creation, powerful data binding, animations, and is also MVVM compatible." };
            Model wpfBIChart = new Model() { Header = "BI Chart" , ToolsDescription = "Essential BI Chart is a great way to visualize business intelligence data buried in OLAP and relational databases. This interactive control with drill-down capabilities allows you to surface big-picture data and makes it available at your fingertips. Data source support ranges from SQL Server Analysis Services to any XMLA-compatible OLAP databases like Mondrian. With our in-memory pivot engine, you can also bind to any standard relational data sources. Use it in your web or Windows development using the variants built natively for each of these platforms: ASP.NET, WPF, and Silverlight." };
            Model wpfDocking = new Model() { Header = "Docking Manager", ToolsDescription = "The docking manager provides VS.NET-style docked container support to your application. Dock panels can be docked, floated, auto-hidden, etc. Based on a proven VS.NET-style architecture, your end users can interact with it in a very intuitive fashion. The layout can be set up easily in code or in XAML." };
            Model wpfRibbon = new Model() { Header = "Ribbon", ToolsDescription = "Our collection of Office 2007-style UI controls let you create Office-style menus, toolbars, window frames, etc. Bringing your application UI on par with industry standards and leaders has never been easier." };
            Model wpfTreePackage = new Model() { Header = "Tree Package", ToolsDescription = "The TreeViewAdv control provides all the advanced capabilities that are missing in the framework version. Advanced features such as multiple columns, drag-and-drop, multi-node selection, and inline editing support are also available. It also has a feature for adding images, and it contains the built-in ability to perform item sorting on a tree view." };
            Model wpfDiagram = new Model() { Header = "Diagram", ToolsDescription = "Essential Diagram for WPF has the ability to present powerful and feature-rich diagrams. It provides an intuitive user-interaction model for creating and editing diagrams with XAML and data binding support. Its programmatic interface also places at your disposal many useful commands and methods that enable the performance of functionalities such as printing, data binding, serializing, and automatic layout algorithms. Virtualized rendering optimizes the rendering of large diagrams. It is fully localizable for any culture." };
            Model wpfRich = new Model() { Header = "Rich-Text Box", ToolsDescription = "The RichTextBox control is a Microsoft Word-like word processor control that lets users view and edit rich content like formatted text, images, lists, and tables. It can also import and export .doc, .docx, HTML, XAML, and .txt file formats." };
            Model wpfGauge = new Model() { Header = "Gauge"  , ToolsDescription = "Essential Gauge allows the use of XAML and C# code to draw gauges of various designs. It comes with sophisticated support to provide endless possibilities for customization. With Essential Gauge, users can display several data points or data ranges in a concise and compact area. Data in the control can be easily depicted and quickly understood by users of any level." };
            Model wpfSchedule = new Model() { Header = "Schedule"  , ToolsDescription = "Essential Schedule for WPF is an Outlook calendar-like scheduler control that lets you add rich scheduling capabilities to your WPF applications. It is designed especially for the WPF platform and makes use of all the nuances that the platform has to offer, such as template creation, powerful data binding, and is also MVVM compatible." };
            Model wpfMaps = new Model() { Header = "Maps"   , ToolsDescription = "Essential Maps lets you create visually stunning, interactive maps to show geographical data from an ESRI Shapefile format. It comes with built-in navigation controls along with zooming and panning features." };
            Model wpfXlsIO = new Model() { Header = "XlsIO" , ToolsDescription = "Essential XlsIO is a .NET library that can read and write Microsoft Excel files. It features a full-fledged object model similar to the Microsoft Office Automation libraries. It can be used on systems that do not have Microsoft Excel installed, making it an excellent report engine for tabular data. Essential XlsIO enables users to create document-based reports in Windows Forms, ASP.NET, WPF, MVC, and Silverlight applications." };
            Model wpfDocIO = new Model() { Header = "DocIO" , ToolsDescription = "Essential DocIO is a .NET library that can read, write, and modify Microsoft Word files. It features a full-fledged object model similar to the Microsoft Office Automation libraries. It can be used on systems that do not have Microsoft Word installed. Essential DocIO enables users to create richly formatted Microsoft Word reports in Windows Forms, ASP.NET, WPF, ASP.NET MVC, and Silverlight applications." };
            Model wpfPDF = new Model() { Header = "PDF", ToolsDescription = "Essential PDF is a .NET library that can create and modify Adobe PDF files. It does not have any external dependencies and can be used in Windows Forms, ASP.NET, WPF, ASP.NET MVC, and Silverlight applications." };
            Model wpfPDFViewer = new Model() { Header = "PDF Viewer" , ToolsDescription = "Essential PDF Viewer is a 100% managed .NET component with the ability to view and print PDF files from your WPF applications. This feature supports exporting PDF files to various image formats such as BMP, JPEG, and PNG." };
            Model wpfGantt = new Model() { Header = "Gantt", ToolsDescription = "Essential Gantt is a Microsoft Project-like viewer and editor control that is used to schedule and manage projects. Its intuitive user interface comprising table and chart views lets you visually manage tasks, task relationships, and resources. It is even possible to import and export data from Microsoft Project." };
            Model wpfReportViewer = new Model() { Header = "Report Viewer", ToolsDescription = "Essential Report Viewer is a viewer component for displaying reports defined in Microsoft's RDL format (2008 or 2008 R2) from within your WPF and Silverlight applications. Using Report Viewer, you can display tabular, graphical, or free-form reports that make use of relational, multidimensional, XML, and object data sources. With client-side reports, just refer the viewer to an RDL(C) file and a data source to allow it to process and render the report. With server reports, point the viewer to an RDL file on the SSRS server to render the report." };
            Model wpfReportDesigner = new Model() { Header = "Report Designer", ToolsDescription = "Essential Report Designer is a component for creating and previewing RDL-based reports. Using Essential Report Designer, you can quickly build the reports you need and display data in both tabular and chart formats." };
            Model wpfAutoComplete = new Model() { Header = "Auto-Complete" , ToolsDescription = "The AutoComplete control provides a common autocomplete text box to easily select values from a predefined list." };
            Model wpfCarousel = new Model() { Header = "Carousel" , ToolsDescription = "The Carousel control provides a 3-D interface for displaying objects in a rich visual manner that allows users to quickly navigate through data visually." };
            Model wpfCardView = new Model() { Header = "Card View"  , ToolsDescription = "The CardView control provides a unique display of data in the form of cards that can be grouped, sorted, filtered, and edited inline and interactively." };
            Model wpfCheckedListBox = new Model() { Header = "Checked List Box" , ToolsDescription = "The CheckedListBox control provides an efficient way to make a multi-selection list." };
            Model wpfGallery = new Model() { Header = "Gallery" , ToolsDescription = "The Gallery control is used for displaying categorized collections of objects in thumbnail views." };
            Model wpfGroupBar = new Model() { Header = "Group Bar", ToolsDescription = "The GroupBar control provides an Outlook-style navigation UI to your application's sub-sections and menu items." };
            Model wpfNotify = new Model() { Header = "Notify Icon" , ToolsDescription = "The NotifyIcon control provides an interactive icon in the notification tray of the desktop with support for different animations and shapes." };

            wpf.ToolKits.Add(wpfGridDataControl);
            wpf.ToolKits.Add(wpfGridControl);
            wpf.ToolKits.Add(wpfSpreadSheet);
            wpf.ToolKits.Add(wpfGridTreeControl);
            wpf.ToolKits.Add(wpfBIGrid);
            wpf.ToolKits.Add(wpfBIPivotGrid);
            wpf.ToolKits.Add(wpfChart);
            wpf.ToolKits.Add(wpfBIChart);
            wpf.ToolKits.Add(wpfDocking);
            wpf.ToolKits.Add(wpfRibbon);
            wpf.ToolKits.Add(wpfTreePackage);
            wpf.ToolKits.Add(wpfDiagram);
            wpf.ToolKits.Add(wpfRich);
            wpf.ToolKits.Add(wpfGauge);
            wpf.ToolKits.Add(wpfSchedule);
            wpf.ToolKits.Add(wpfMaps);
            wpf.ToolKits.Add(wpfXlsIO);
            wpf.ToolKits.Add(wpfDocIO);
            wpf.ToolKits.Add(wpfPDF);
            wpf.ToolKits.Add(wpfPDFViewer);
            wpf.ToolKits.Add(wpfGantt);
            wpf.ToolKits.Add(wpfReportViewer);
            wpf.ToolKits.Add(wpfReportDesigner);
            wpf.ToolKits.Add(wpfAutoComplete);
            wpf.ToolKits.Add(wpfCarousel);
            wpf.ToolKits.Add(wpfCardView);
            wpf.ToolKits.Add(wpfCheckedListBox);
            wpf.ToolKits.Add(wpfGallery);
            wpf.ToolKits.Add(wpfGroupBar);
            wpf.ToolKits.Add(wpfNotify);

            ToolKits.Add(wpf);
        }

        /// <summary>
        /// Method used to populate silver light controls.
        /// </summary>
        public void PopulateSilverLight()
        {
            Model silverLight = new Model() { Header = "Silverlight", ToolsDescription = "Essential Studio for Silverlight contains all the controls you need for building typical line-of-business web applications including grids, charts, gauges, menus, calendars, editors, and much more. It also includes some unique controls that enable your applications to read and write Excel, Word, and PDF documents." };

            Model silverLightGridDataControl = new Model() { Header = "Grid Data Control", ToolsDescription = "The high-performance, data-bound GridData control provides a seamless editing experience, and its cell-oriented architecture provides extensive cell-level customization options." };
            Model silverLightGridControl = new Model() { Header = "Grid Control", ToolsDescription = "The Grid control is a very efficient display engine for tabular data with a powerful formula engine and Excel-like behaviors such as formulas, freeze rows and columns, merged cells, and more. Its powerful cell rendering architecture allows you to load any control inside the grid." };
            Model silverLightSpreadsheet = new Model() { Header = "Spreadsheet", ToolsDescription = "Essential Spreadsheet is a control for viewing and editing Microsoft Excel files in a familiar Excel-like interface. It combines some of our most popular components like our Grid control, Ribbon control, formula engine, and more to create a first of its kind offering for Silverlight for viewing and editing Excel files" };
            Model silverLightGridTreeControl = new Model() { Header = "Grid Tree Control", ToolsDescription = "The GridTree control displays self-referencing lists in a multicolumn tree format. The data is loaded on demand so that large lists can be quickly displayed." };
            Model silverLightBIGrid = new Model() { Header = "BI Grid", ToolsDescription = "Essential BI Grid can be used to summarize, analyze, explore, and present summaries for critical enterprise data, allowing you to make informed decisions. Data source support ranges from SQL Server Analysis Services to any XMLA-compatible OLAP databases like Mondrian. With our in-memory pivot engine, you can also bind to any standard relational data sources. Use it in your web or Windows development using the variants built natively for each of these platforms: ASP.NET, ASP.NET MVC (HTML 5-enhanced), Silverlight, and WPF." };  
            Model silverLightBIPivotGrid = new Model() { Header = "BI PivotGrid", ToolsDescription = "Essential BI PivotGrid is a powerful pivot table implementation for visualizing relational data in a multidimensional UI. The pivot grid, as the name implies, pivots the data to organize it in a cross-tabulated form. The pivot grid is just like our OLAPGrid control, but works with relational data. Our powerful in-memory pivoting engine can transform hundreds of thousands of relational table rows into comprehensible pivot information within seconds. Along with pivoting, summarizing and grouping data is also supported." };
            Model silverLightChart = new Model() { Header = "Chart", ToolsDescription = "Essential Chart for Silverlight is a high-performance charting component that is very easy to use and is also visually stunning. It includes 35 chart types ranging from simple column charts to specialized financial charts. It is designed especially for the Silverlight platform and makes use of all the nuances that the platform has to offer, such as template creation, powerful data binding, animations, and is also MVVM compatible." };
            Model silverLightBIChart = new Model() { Header = "BI Chart", ToolsDescription = "Essential BI Chart is a great way to visualize business intelligence data buried in OLAP and relational databases. This interactive control with drill-down capabilities allows you to surface big-picture data and makes it available at your fingertips. Data source support ranges from SQL Server Analysis Services to any XMLA-compatible OLAP databases like Mondrian. With our in-memory pivot engine, you can also bind to any standard relational data sources. Use it in your web or Windows development using the variants built natively for each of these platforms: ASP.NET, WPF, and Silverlight." };
            Model silverLightDocking = new Model() { Header = "Docking Manager", ToolsDescription = "The docking manager provides VS.NET-style docked containers support to your application. Dock panels can be docked, floated, auto-hidden, and more. Based on a proven VS.NET-style architecture, your end users can interact with it in a very intuitive fashion. The layout can be set up easily in code or in XAML." };
            Model silverLightRibbon = new Model() { Header = "Ribbon-Office 2007 UI", ToolsDescription = "Our collection of Office 2007-style UI controls let you create Office-style menus, toolbars, window frames, and more. Bringing your application UI on par with industry standards and leaders has never been easier." };
            Model silverLightTree = new Model() { Header = "Tree View", ToolsDescription = "The TreeViewAdv control provides all the advanced capabilities that are missing in the framework version. Advanced features such as drag-and-drop, multi-node selection, the ability to add images to nodes, and inline editing support are also available." };
            Model silverLightDiagram = new Model() { Header = "Diagram", ToolsDescription = "Essential Diagram for Silverlight has the ability to present powerful and feature-rich diagrams. It provides an intuitive user interaction model for creating and editing diagrams with XAML support. It stores graphical objects in a node graph and renders those objects onto the screen. It explicitly lays out diagram objects, or lets the layout manager handle the job by automatically arranging the nodes using the predefined layout algorithms. Essential Diagram is fully localizable for any culture." };
            Model silverLightRich = new Model() { Header = "Rich-Text Editor", ToolsDescription = "The RichTextBoxAdv control enables users to add formatting to text such as bold, italics, and underline. Font family, font color, and images can also be added in the control." };
            Model silverLightCircular = new Model() { Header = "Circular Gauge", ToolsDescription = "The circular gauge maps a single numerical value in an interface similar to speedometers or clocks. A range of colors can be applied to the gauge to correspond with particular business logic. The gauge's pointer changes position as the gauge value changes over time." };
            Model silverLightSchedule = new Model() { Header = "Schedule", ToolsDescription = "Essential Schedule for Silverlight is an Outlook calendar-like scheduler control that lets you add rich scheduling capabilities to your Silverlight applications. It is designed especially for the Silverlight platform and makes use of all the nuances that the platform has to offer, such as template creation, powerful data binding, and is also MVVM compatible." };
            Model silverLightMaps = new Model() { Header = "Maps", ToolsDescription = "Essential Maps lets you create visually stunning and interactive maps to show geographical data from an ESRI Shapefile. It comes with built-in navigation controls along with zooming and panning features." };
            Model silverLightXlsIO = new Model() { Header = "XlsIO", ToolsDescription = "Essential XlsIO is a .NET library that can read and write Microsoft Excel files. It features a full-fledged object model similar to the Microsoft Office Automation libraries. It can be used on systems that do not have Microsoft Excel installed, making it an excellent reporting engine for tabular data. Essential XlsIO enables users to create document-based reports in Windows, web, WPF, MVC, and Silverlight applications." };
            Model silverLightDocIO = new Model() { Header = "DocIO", ToolsDescription = "Essential DocIO is a .NET library that can read, write, and modify Microsoft Word files. It features a full-fledged object model similar to the Microsoft Office Automation libraries. It can be used on systems that do not have Microsoft Word installed. Essential DocIO enables users to create richly formatted Microsoft Word reports in Windows Forms, ASP.NET, WPF, ASP.NET MVC, and Silverlight applications." };
            Model silverLightPDF = new Model() { Header = "PDF", ToolsDescription = "Essential PDF is a .NET library that can create and modify Adobe PDF files. It does not have any external dependencies and can be used in Windows Forms, ASP.NET, WPF, ASP.NET MVC, and Silverlight applications." };
            Model silverLightGantt = new Model() { Header = "Gantt", ToolsDescription = "The Gantt control is a Microsoft Project-like viewer and editor that is used to schedule and manage projects. Its intuitive user interface comprising table and chart views lets you visually manage tasks, task relationships, and resources. It is even possible to import and export data from Microsoft Project." };
            Model silverLightReportViewer = new Model() { Header = "Report Viewer", ToolsDescription = "Essential Report Viewer is a viewer component for displaying reports defined in Microsoft's RDL format (2008 or 2008 R2) from within your WPF and Silverlight applications. Using Essential Report Viewer, you can display tabular, graphical, or free-form reports that make use of relational, multidimensional, XML, and object data sources. With client-side reports, just refer the viewer to an RDL(C) file and a data source allowing it to process and render the report. With server reports, point the viewer to an RDL file on the SSRS server to render the report." };
            Model silverLightAuto = new Model() { Header = "Auto-Complete", ToolsDescription = "The AutoComplete control provides a common autocomplete text box to easily select values from a predefined list." };
            Model silverLightCarousel = new Model() { Header = "Carousel", ToolsDescription = "The Carousel control provides a 3-D interface for displaying objects in a rich visual manner that allows users to quickly navigate through data visually." };
            Model silverLightChecked = new Model() { Header = "Checked List Box", ToolsDescription = "The CheckedListBox control provides an efficient way to make a multi-selection list." };
            Model silverLightGroup = new Model() { Header = "Group Bar", ToolsDescription = "The GroupBar control provides an Outlook-style navigation UI to your application's sub-sections and menu items." };
            Model silverLightHierarchy = new Model() { Header = "Hierarchy Navigator", ToolsDescription = "The hierarchy navigator provides a bread crumb navigation interface that supports different skins such as Windows 7, Office 2010 Blue, Office 2010 Black, Office 2010 Silver, Office 2007 Blue, Office 2007 Black, Office 2007 Silver, and Blend." };
            Model silverLightRangeSlider = new Model() { Header = "Range Slider", ToolsDescription = "The RangeSlider control provides a flexible way to select a value from a specified range with an enhanced feature set." };
            Model silverLightTabControl = new Model() { Header = "Tab Control", ToolsDescription = "The TabControlAdv control provides a simple and intuitive interface for a tab-based navigation system." };
            Model silverLightTabNavigation = new Model() { Header = "Tab Navigation", ToolsDescription = "The TabNavigation control provides an elegant look and feel for implementing a rich slide show of content in your webpages." };
            Model silverLightTaskbar = new Model() { Header = "Taskbar", ToolsDescription = "The TaskBar control provides a Windows-style collapsible, grouped command item list to your UI, similar to the Windows Explorer taskbar." };

            silverLight.ToolKits.Add(silverLightGridDataControl);
            silverLight.ToolKits.Add(silverLightGridControl);
            silverLight.ToolKits.Add(silverLightSpreadsheet);
            silverLight.ToolKits.Add(silverLightGridTreeControl);
            silverLight.ToolKits.Add(silverLightBIGrid);
            silverLight.ToolKits.Add(silverLightBIPivotGrid);
            silverLight.ToolKits.Add(silverLightChart);
            silverLight.ToolKits.Add(silverLightBIChart);
            silverLight.ToolKits.Add(silverLightDocking);
            silverLight.ToolKits.Add(silverLightRibbon);
            silverLight.ToolKits.Add(silverLightTree);
            silverLight.ToolKits.Add(silverLightDiagram);
            silverLight.ToolKits.Add(silverLightRich);
            silverLight.ToolKits.Add(silverLightCircular);
            silverLight.ToolKits.Add(silverLightSchedule);
            silverLight.ToolKits.Add(silverLightMaps);
            silverLight.ToolKits.Add(silverLightXlsIO);
            silverLight.ToolKits.Add(silverLightDocIO);
            silverLight.ToolKits.Add(silverLightPDF);
            silverLight.ToolKits.Add(silverLightGantt);
            silverLight.ToolKits.Add(silverLightReportViewer);
            silverLight.ToolKits.Add(silverLightAuto);
            silverLight.ToolKits.Add(silverLightCarousel);
            silverLight.ToolKits.Add(silverLightChecked);
            silverLight.ToolKits.Add(silverLightGroup);
            silverLight.ToolKits.Add(silverLightHierarchy);
            silverLight.ToolKits.Add(silverLightRangeSlider);
            silverLight.ToolKits.Add(silverLightTabControl);
            silverLight.ToolKits.Add(silverLightTabNavigation);
            silverLight.ToolKits.Add(silverLightTaskbar);

            ToolKits.Add(silverLight);
        }

        /// <summary>
        /// Method used to populate windows phone.
        /// </summary>
        public void PopulateWindowsPhone()
        {
            Model windowsPhone = new Model() { Header = "Windows Phone", ToolsDescription = "Essential Studio for Windows Phone 7 contains all the controls you need to build line-of-business mobile applications including charts, gauges, maps, editors, and much more." };

            Model windowsPhoneChart = new Model() { Header = "Chart", ToolsDescription = "Essential Chart for Windows Phone is a high-performance charting component that is very easy to use. It includes 28 unique chart types ranging from simple column charts to specialized financial charts. It is designed specifically for the Windows Phone platform and makes use of all the nuances that platform has to offer, such as template creation and powerful data binding. It is also MVVM compatible." };
            Model windowsPhoneRich = new Model() { Header = "Rich-Text Editor", ToolsDescription = "The RichTextEditor control supports formatting—such as bold, italicized, or underlined text. It also supports different font types and colors, as well as images." };
            Model windowsPhoneCircular = new Model() { Header = "Circular Gauge", ToolsDescription = "The circular gauge can be used to represent a range of values in a circular interface. It creates sophisticated dashboards with virtual clocks and speedometers that can be employed in financial, industrial, or medical applications." };
            Model windowsPhoneMaps = new Model() { Header = "Maps", ToolsDescription = "Essential Maps lets you create visually stunning, interactive maps that show geographical data from ESRI shapefiles. It comes with built-in zooming and panning features optimized for Windows Phone." };
            Model windowsPhoneAuto = new Model() { Header = "Auto-Complete Text Box", ToolsDescription = "The AutoComplete control displays a list of items from a data source based on text being typed. Users can select an item from the list instead of completely typing a word or phrase." };
            Model windowsPhoneChecked = new Model() { Header = "Checked List Box", ToolsDescription = "The CheckedListBox control is a user interface similar to a list box, only its items have check boxes that can be selected, and multiple check boxes can be selected at the same time." };
            Model windowsPhoneRange = new Model() { Header = "Range Slider", ToolsDescription = "The range slider is a dual-thumb slider that highlights a selected range between two thumbs. This enables you to specify a range as an input value. You can set the range by dragging the thumb or clicking on the slider bar. It accepts only numeric values and can be oriented vertically or horizontally." };
            Model windowsPhoneButtonAdv = new Model() { Header = "ButtonAdv", ToolsDescription = "The ButtonAdv control is a basic button control that is used to design complex forms and applications. It also supports different sizes and it provides multiline support." };
            Model windowsPhoneColor = new Model() { Header = "Color Picker", ToolsDescription = "The color picker (palette) provides a rich visual interface for color selection. For Windows Phone it provides accent colors along with their variations." };
            Model windowsPhoneTime = new Model() { Header = "Time-Span Picker", ToolsDescription = "The time-span picker lets you select a time span in an application. It consists of four looping selectors for days, hours, minutes, and seconds. It can be customized as needed." };
            Model windowsPhoneMasked = new Model() { Header = "Masked-Edit Text Box", ToolsDescription = "The masked-edit text box is an enhanced text box that supports declarative syntax for accepting or rejecting input. It uses a single property to distinguish between proper and improper input and a validation string to perform RegEx validation." };
            Model windowsPhoneNumericUpDown = new Model() { Header = "NumericUpDown", ToolsDescription = "The NumericUpDown control is a text box with a pair of arrow buttons that increase or decrease a given value. It supports double values, and a range of values can be specified." };
            Model windowsPhoneDomainUpDown = new Model() { Header = "DomainUpDown", ToolsDescription = "The DomainUpDown control is a combination of a text box and a pair of buttons for navigating up or down in a list. The control displays a text string from a list of choices. Users can select the string by clicking the Up or Down buttons, pressing the Up or Down arrow keys on the keyboard, or by scrolling the mouse wheel." };
            Model windowsPhoneJumpList = new Model() { Header = "Jump List", ToolsDescription = "Navigating through a long list of items in a mobile application is harder than in a desktop application. A jump list makes navigation easier by grouping items into categories. You can jump to a specific category in a list instead of scrolling through the entire list. Jump buttons can be enabled or disabled based on an item's availability." };
            Model windowsPhoneToolbar = new Model() { Header = "Toolbar", ToolsDescription = "The Toolbar control lets you to add a large number of items to a page. Toolbar items act like buttons. The toolbar can be docked to the left, right, top, or bottom. This control is better than the phone's default toolbar, which can hold only four items and cannot be repositioned." };
            Model windowsPhoneTooltip = new Model() { Header = "Tooltip", ToolsDescription = "A tooltip is a common graphical user interface element that enables you to display information about a UI element when hovering over it." };
            Model windowsPhoneDialog = new Model() { Header = "Dialog", ToolsDescription = "The Dialog control allows you to display content at an arbitrary point on the screen. It acts either as a modal or as a modeless dialog. Predefined formats are used to display alert and prompt messages. The dialog control can be customized as needed." };
            Model windowsPhoneLinear = new Model() { Header = "Linear Gauge", ToolsDescription = "A linear gauge can display a range of values graphically along a linear scale. It could be described as the linear form of a circular gauge." };
            Model windowsPhoneDigital = new Model() { Header = "Digital Gauge", ToolsDescription = "A digital gauge displays values in a segmented, alpha-numeric manner that is easier to read." };
            Model windowsPhoneRolling = new Model() { Header = "Rolling Gauge", ToolsDescription = "A rolling gauge displays values in segments that change by rolling." };

            windowsPhone.ToolKits.Add(windowsPhoneChart);
            windowsPhone.ToolKits.Add(windowsPhoneRich);
            windowsPhone.ToolKits.Add(windowsPhoneCircular);
            windowsPhone.ToolKits.Add(windowsPhoneMaps);
            windowsPhone.ToolKits.Add(windowsPhoneAuto);
            windowsPhone.ToolKits.Add(windowsPhoneChecked);
            windowsPhone.ToolKits.Add(windowsPhoneRange);
            windowsPhone.ToolKits.Add(windowsPhoneButtonAdv);
            windowsPhone.ToolKits.Add(windowsPhoneColor);
            windowsPhone.ToolKits.Add(windowsPhoneTime);
            windowsPhone.ToolKits.Add(windowsPhoneMasked);
            windowsPhone.ToolKits.Add(windowsPhoneNumericUpDown);
            windowsPhone.ToolKits.Add(windowsPhoneDomainUpDown);
            windowsPhone.ToolKits.Add(windowsPhoneJumpList);
            windowsPhone.ToolKits.Add(windowsPhoneToolbar);
            windowsPhone.ToolKits.Add(windowsPhoneTooltip);
            windowsPhone.ToolKits.Add(windowsPhoneDialog);
            windowsPhone.ToolKits.Add(windowsPhoneLinear);
            windowsPhone.ToolKits.Add(windowsPhoneDigital);
            windowsPhone.ToolKits.Add(windowsPhoneRolling);

            ToolKits.Add(windowsPhone);
        }

        /// <summary>
        /// Method used to populate metro studio.
        /// </summary>
        public void PopulateMetroStudio()
        {
            Model metroStudio = new Model() { Header = "Metro Studio", ToolsDescription = "Syncfusion Metro Studio is a collection of over 1700 Metro-style icon templates that can be easily customized to create thousands of unique Metro icons." };
            ToolKits.Add(metroStudio);
        }

        /// <summary>
        /// Method used to populate ourBase studio.
        /// </summary>
        public void PopulateOurBaseStudio()
        {
            Model baseStudio = new Model() { Header = "Ourbase Studio", ToolsDescription = "Orubase is the only mobile application development framework built especially for developing complex line-of-business mobile applications targeting iOS, Android, and Windows Phone platforms in the shortest possible timeframe." };
            ToolKits.Add(baseStudio);
        }
    }
}
