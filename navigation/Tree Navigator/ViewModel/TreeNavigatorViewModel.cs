#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Class represents the behaviour or business logic for MainWindow.xaml.
    /// </summary>
    public class TreeNavigatorViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the list of toolKits;
        /// </summary>
        private List<TreeNavigatorModel> toolKits;

        /// <summary>
        /// Maintains the selected item.
        /// </summary>
        private object selectedItem;

        /// <summary>
        /// Initializes the new instance of <see cref="TreeNavigatorViewModel"/> class.
        /// </summary>
        public TreeNavigatorViewModel()
        {
            ToolKits = new List<TreeNavigatorModel>();
            PopulateWinUI();
            PopulateUWPControls();
            PopulateWindowsForms();
            PopulateWPFControls();
            PopulateMetroStudio();
            PopulateOurBaseStudio();
            SelectedItem = ToolKits[3];
        }

        /// <summary>
        /// Gets or sets the toolKits for tree navigator.<see cref="TreeNavigatorViewModel"/> class.
        /// </summary>
        public List<TreeNavigatorModel> ToolKits
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
        /// Gets or sets the selected item from tree navigator <see cref="TreeNavigatorViewModel"/> class.
        /// </summary>
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Method used to populate the winrt controls.
        /// </summary>
        public void PopulateUWPControls()
        {
            TreeNavigatorModel uWP = new TreeNavigatorModel() { Header = "UWP", Description = "Essential Studio for UWP contains all the controls you need to build line-of-business applications, including charts, gauges, maps, diagrams, and radial menus. It also includes a unique set of controls for reading and writing Excel, Word, and PDF documents in Windows store apps." };

            TreeNavigatorModel uWPChart = new TreeNavigatorModel() { Header = "Chart", Description= "Essential Chart for UWP is a high-performance, visually stunning charting component that is easy to use. It includes common chart types ranging from line charts to specialized financial charts. It incorporates DirectX rendering to deliver the best possible performance." };
            TreeNavigatorModel uWPGauge = new TreeNavigatorModel() { Header = "Gauge", Description = "Essential Gauge for UWP is a highly customizable gauge control used to visualize a given value over a circular scale. All its elements—scales, ticks, pointers, and labels—can be customized as needed." };
            TreeNavigatorModel uWPDiagram = new TreeNavigatorModel() { Header = "Diagram", Description = "Essential Diagram for UWP creates feature-rich diagrams for Windows store applications. It can compose diagrams and workflows visually, using touch interactions, or automatically, laying out elements according to set rules." };
            TreeNavigatorModel uWPMaps = new TreeNavigatorModel() { Header = "Maps", Description = "Essential Maps for WinRT is a powerful data-visualization control that can be used to articulate data as a map. It is frequently used in financial dashboards for plotting sales across geography." };
            TreeNavigatorModel uWPRadialMenu = new TreeNavigatorModel() { Header = "Radial Menu", Description = "The radial menu displays a hierarchical menu in a circular layout optimized for touch devices. Typically used as a context menu, it can expose more menu items in the same space than traditional menus." };
            TreeNavigatorModel uWPCarousel = new TreeNavigatorModel() { Header = "Carousel", Description = "The carousel arranges items in an album-cover browser similar to iTunes. This layout is optimized for browsing a list of items on a touch device. Simply swipe to reveal the next item in a list." };
            TreeNavigatorModel uWPTabControl = new TreeNavigatorModel() { Header = "Tab Control", Description = "The Tab control displays items as tabs, enabling better space utilization within a page. Tabs can be positioned to the top, bottom, left, or right of a page." };
            TreeNavigatorModel uWPDate = new TreeNavigatorModel() { Header = "Date Picker", Description = "The date picker provides an interface for quickly selecting dates on touch devices." };
            TreeNavigatorModel uWPTime = new TreeNavigatorModel() { Header = "Time Picker", Description = "The time picker provides an interface for quickly selecting time intervals on touch devices." };
            TreeNavigatorModel uWPTileView = new TreeNavigatorModel() { Header = "TileView", Description = "The tile view displays an item in a maximized state while other items remain minimized. Each item can have a different data template for its minimized or maximized state. This control is useful for dashboards where single components need to be analyzed in detail one at a time." };
            TreeNavigatorModel uWPRating = new TreeNavigatorModel() { Header = "Rating", Description = "The Rating control lets you quickly select a value from a group of symbols shown in sequence. The appearance and the selection behavior of the control are completely customizable. For example, you can visualize the rating control as a sequence of diamonds instead of the default star shapes, if required." };
            TreeNavigatorModel uWPSlider = new TreeNavigatorModel() { Header = "Range Slider", Description = "The range slider extends the framework's slider control, adding the capability to select a range instead of a single value." };
            TreeNavigatorModel uWPHubTile = new TreeNavigatorModel() { Header = "HubTile", Description = "Hub tiles, a type of content control, display live tiles within an application user interface. Content updates are shown through a variety of animations, similar to the live tile updates of the Windows 8 start screen." };
            TreeNavigatorModel uWPExtended = new TreeNavigatorModel() { Header = "Extended TextBox", Description = "This extended text box adds several capabilities to the framework version, such as auto-complete, data validation, and watermarking." };
            TreeNavigatorModel uWPNumeric = new TreeNavigatorModel() { Header = "Numeric Text Box", Description = "The numeric text box can restrict input to numbers, providing several options for formatting number values, such as currency or percentage." };
            TreeNavigatorModel uWPDomainUpDown = new TreeNavigatorModel() { Header = "Domain Up-Down", Description = "The DomainUpDown control lets users select from a list of options by cycling through them one by one, using the provided up and down buttons." };
            TreeNavigatorModel uWPNumericUpDown = new TreeNavigatorModel() { Header = "Numeric Up-Down", Description = "The NumericUpDown control lets users increase or decrease a number, one increment at a time, using the provided increment and decrement buttons." };
            TreeNavigatorModel uWPXlsIO = new TreeNavigatorModel() { Header = "Essential XlsIO", Description = "Essential XlsIO is a powerful class library that enables Windows store applications to read and write Microsoft Excel files. It exposes a comprehensive object model that covers most of the functionality Excel itself offers, making it possible to create reports that contain advanced elements like charts and pivot tables. All versions of Excel 97-2013 are supported." };
            TreeNavigatorModel uWPDocIO = new TreeNavigatorModel() { Header = "Essential DocIO", Description = "Essential DocIO is a class library that enables Windows store applications to read and write Microsoft Word files. Its object model covers most of the functionality Word offers. Create reports with advanced elements like headers, footers, bookmarks, styles, and tables. All versions of Word 97-2013 are supported." };
            TreeNavigatorModel uWPPDF = new TreeNavigatorModel() { Header = "Essential PDF", Description = "Essential PDF is a class library that enables Windows store applications to read and write Adobe PDF files. It has an object model that provides most of the functionality offered in a PDF, making it possible to create reports with advanced elements like headers, footers, bookmarks, styles, and tables. It is even possible to fill form fields in existing PDF documents and secure them with a password." };

            uWP.ToolKits.Add(uWPChart);
            uWP.ToolKits.Add(uWPGauge);
            uWP.ToolKits.Add(uWPDiagram);
            uWP.ToolKits.Add(uWPMaps);
            uWP.ToolKits.Add(uWPRadialMenu);
            uWP.ToolKits.Add(uWPCarousel);
            uWP.ToolKits.Add(uWPTabControl);
            uWP.ToolKits.Add(uWPDate);
            uWP.ToolKits.Add(uWPTime);
            uWP.ToolKits.Add(uWPTileView);
            uWP.ToolKits.Add(uWPRating);
            uWP.ToolKits.Add(uWPSlider);
            uWP.ToolKits.Add(uWPHubTile);
            uWP.ToolKits.Add(uWPExtended);
            uWP.ToolKits.Add(uWPNumeric);
            uWP.ToolKits.Add(uWPDomainUpDown);
            uWP.ToolKits.Add(uWPNumericUpDown);
            uWP.ToolKits.Add(uWPXlsIO);
            uWP.ToolKits.Add(uWPDocIO);
            uWP.ToolKits.Add(uWPPDF);

            ToolKits.Add(uWP);
        }

        /// <summary>
        /// Method used to populate WPF controls.
        /// </summary>
        public void PopulateWPFControls()
        {
            TreeNavigatorModel wpf = new TreeNavigatorModel() { Header = "WPF", Description = "Essential Studio for WPF contains all the controls that you need for building typical line-of-business web applications including grids, charts, gauges, menus, calendars, editors, and much more. It also includes some unique controls that enable your applications to read and write Excel, Word, and PDF documents." };

            TreeNavigatorModel wpfGridDataControl = new TreeNavigatorModel() { Header = "GridData Control", Description = "The GridData control for WPF is the most advanced data grid available in the market with unmatched performance and versatility. Its advanced feature set is exposed through a powerful yet easy-to-use API with countless customization options. You can easily get started data-binding the grid to any data source; format the data with a rich selection of cell types; and enable editing, sorting, filtering, and grouping within a few minutes. The seamless editing experience rivals that of Microsoft Excel itself. The GridData control has been designed especially for the WPF platform and makes use of all the nuances the platform has to offer. It is also MVVM compatible." };
            TreeNavigatorModel wpfGridControl = new TreeNavigatorModel() { Header = "Grid Control", Description = "The cell-oriented Grid control is a very efficient display engine for tabular data that can be customized down to the cell level. It does not make any assumptions about the structure of the data. It can be used in a virtual manner where the data is provided on demand in real time, or it can be used in a manner where the Grid control maintains the data within its own internal structures. The Grid control supports frozen rows and columns; Excel-like formulas; covered cells; various cell-control types; copy–paste; both row selections and cell-range selections; hidden rows and columns; and virtually an unlimited number of rows and columns." };
            TreeNavigatorModel wpfSpreadSheet = new TreeNavigatorModel() { Header = "SpreadSheet", Description = "Essential Spreadsheet is a control for viewing and editing Microsoft Excel files in a familiar Excel-like interface without Excel installed. It combines some of our most popular components like our Grid control, Ribbon control, formula engine, and others to create a first of its kind offering for WPF for viewing and editing Excel files." };
            TreeNavigatorModel wpfGridTreeControl = new TreeNavigatorModel() { Header = "Grid Tree Control", Description = "The GridTree control is a grid that displays self-referencing lists in a multicolumn tree format. The data is loaded on demand so that large lists can be quickly displayed. Direct support for a classic tree look is provided, but it also gives you the ability to easily customize the look of the tree with special glyphs and icons. Exceptional performance is possible such that thousands of nodes can be expanded or collapsed instantaneously." };
            TreeNavigatorModel wpfBIGrid = new TreeNavigatorModel() { Header = "BI Grid" , Description = "Use Essential BI Grid to summarize, analyze, explore, and present summaries for critical enterprise data, allowing informed decisions to be made. Data source support ranges from SQL Server Analysis Services to any XMLA-compatible OLAP databases like Mondrian. With our in-memory pivot engine, you can also bind to any standard relational data sources. Use it in your web or Windows development using the variants built natively for each of these platforms: ASP.NET, ASP.NET MVC (HTML 5-enhanced), Silverlight, and WPF." };
            TreeNavigatorModel wpfBIPivotGrid = new TreeNavigatorModel() { Header = "BI PivotGrid" , Description = "Essential BI PivotGrid is a powerful pivot table implementation for visualizing relational data in a multidimensional UI. The PivotGrid, as the name implies, pivots the data to organize it in a cross-tabulated form. The PivotGrid is just like our BI Grid, but works with relational data. Our powerful in-memory pivoting engine can transform hundreds of thousands of relational table rows into comprehensible pivot information within seconds. Along with pivoting, summarizing and grouping data are also supported." };
            TreeNavigatorModel wpfChart = new TreeNavigatorModel() { Header = "Chart", Description = "Essential Chart for WPF is a high-performance charting component that is very easy to use and is also visually stunning. It includes 37 chart types ranging from simple column charts to specialized financial charts. It is designed especially for the WPF platform and makes use of all the nuances that the platform has to offer, such as template creation, powerful data binding, animations, and is also MVVM compatible." };
            TreeNavigatorModel wpfBIChart = new TreeNavigatorModel() { Header = "BI Chart" , Description = "Essential BI Chart is a great way to visualize business intelligence data buried in OLAP and relational databases. This interactive control with drill-down capabilities allows you to surface big-picture data and makes it available at your fingertips. Data source support ranges from SQL Server Analysis Services to any XMLA-compatible OLAP databases like Mondrian. With our in-memory pivot engine, you can also bind to any standard relational data sources. Use it in your web or Windows development using the variants built natively for each of these platforms: ASP.NET, WPF, and Silverlight." };
            TreeNavigatorModel wpfDocking = new TreeNavigatorModel() { Header = "Docking Manager", Description = "The docking manager provides VS.NET-style docked container support to your application. Dock panels can be docked, floated, auto-hidden, etc. Based on a proven VS.NET-style architecture, your end users can interact with it in a very intuitive fashion. The layout can be set up easily in code or in XAML." };
            TreeNavigatorModel wpfRibbon = new TreeNavigatorModel() { Header = "Ribbon", Description = "Our collection of Office 2007-style UI controls let you create Office-style menus, toolbars, window frames, etc. Bringing your application UI on par with industry standards and leaders has never been easier." };
            TreeNavigatorModel wpfTreePackage = new TreeNavigatorModel() { Header = "Tree Package", Description = "The TreeViewAdv control provides all the advanced capabilities that are missing in the framework version. Advanced features such as multiple columns, drag-and-drop, multi-node selection, and inline editing support are also available. It also has a feature for adding images, and it contains the built-in ability to perform item sorting on a tree view." };
            TreeNavigatorModel wpfDiagram = new TreeNavigatorModel() { Header = "Diagram", Description = "Essential Diagram for WPF has the ability to present powerful and feature-rich diagrams. It provides an intuitive user-interaction model for creating and editing diagrams with XAML and data binding support. Its programmatic interface also places at your disposal many useful commands and methods that enable the performance of functionalities such as printing, data binding, serializing, and automatic layout algorithms. Virtualized rendering optimizes the rendering of large diagrams. It is fully localizable for any culture." };
            TreeNavigatorModel wpfRich = new TreeNavigatorModel() { Header = "Rich-Text Box", Description = "The RichTextBox control is a Microsoft Word-like word processor control that lets users view and edit rich content like formatted text, images, lists, and tables. It can also import and export .doc, .docx, HTML, XAML, and .txt file formats." };
            TreeNavigatorModel wpfGauge = new TreeNavigatorModel() { Header = "Gauge"  , Description = "Essential Gauge allows the use of XAML and C# code to draw gauges of various designs. It comes with sophisticated support to provide endless possibilities for customization. With Essential Gauge, users can display several data points or data ranges in a concise and compact area. Data in the control can be easily depicted and quickly understood by users of any level." };
            TreeNavigatorModel wpfSchedule = new TreeNavigatorModel() { Header = "Schedule"  , Description = "Essential Schedule for WPF is an Outlook calendar-like scheduler control that lets you add rich scheduling capabilities to your WPF applications. It is designed especially for the WPF platform and makes use of all the nuances that the platform has to offer, such as template creation, powerful data binding, and is also MVVM compatible." };
            TreeNavigatorModel wpfMaps = new TreeNavigatorModel() { Header = "Maps"   , Description = "Essential Maps lets you create visually stunning, interactive maps to show geographical data from an ESRI Shapefile format. It comes with built-in navigation controls along with zooming and panning features." };
            TreeNavigatorModel wpfXlsIO = new TreeNavigatorModel() { Header = "XlsIO" , Description = "Essential XlsIO is a .NET library that can read and write Microsoft Excel files. It features a full-fledged object model similar to the Microsoft Office Automation libraries. It can be used on systems that do not have Microsoft Excel installed, making it an excellent report engine for tabular data. Essential XlsIO enables users to create document-based reports in Windows Forms, ASP.NET, WPF, MVC, and Silverlight applications." };
            TreeNavigatorModel wpfDocIO = new TreeNavigatorModel() { Header = "DocIO" , Description = "Essential DocIO is a .NET library that can read, write, and modify Microsoft Word files. It features a full-fledged object model similar to the Microsoft Office Automation libraries. It can be used on systems that do not have Microsoft Word installed. Essential DocIO enables users to create richly formatted Microsoft Word reports in Windows Forms, ASP.NET, WPF, ASP.NET MVC, and Silverlight applications." };
            TreeNavigatorModel wpfPDF = new TreeNavigatorModel() { Header = "PDF", Description = "Essential PDF is a .NET library that can create and modify Adobe PDF files. It does not have any external dependencies and can be used in Windows Forms, ASP.NET, WPF, ASP.NET MVC, and Silverlight applications." };
            TreeNavigatorModel wpfPDFViewer = new TreeNavigatorModel() { Header = "PDF Viewer" , Description = "Essential PDF Viewer is a 100% managed .NET component with the ability to view and print PDF files from your WPF applications. This feature supports exporting PDF files to various image formats such as BMP, JPEG, and PNG." };
            TreeNavigatorModel wpfGantt = new TreeNavigatorModel() { Header = "Gantt", Description = "Essential Gantt is a Microsoft Project-like viewer and editor control that is used to schedule and manage projects. Its intuitive user interface comprising table and chart views lets you visually manage tasks, task relationships, and resources. It is even possible to import and export data from Microsoft Project." };
            TreeNavigatorModel wpfReportViewer = new TreeNavigatorModel() { Header = "Report Viewer", Description = "Essential Report Viewer is a viewer component for displaying reports defined in Microsoft's RDL format (2008 or 2008 R2) from within your WPF and Silverlight applications. Using Report Viewer, you can display tabular, graphical, or free-form reports that make use of relational, multidimensional, XML, and object data sources. With client-side reports, just refer the viewer to an RDL(C) file and a data source to allow it to process and render the report. With server reports, point the viewer to an RDL file on the SSRS server to render the report." };
            TreeNavigatorModel wpfReportDesigner = new TreeNavigatorModel() { Header = "Report Designer", Description = "Essential Report Designer is a component for creating and previewing RDL-based reports. Using Essential Report Designer, you can quickly build the reports you need and display data in both tabular and chart formats." };
            TreeNavigatorModel wpfAutoComplete = new TreeNavigatorModel() { Header = "Auto-Complete" , Description = "The AutoComplete control provides a common autocomplete text box to easily select values from a predefined list." };
            TreeNavigatorModel wpfCarousel = new TreeNavigatorModel() { Header = "Carousel" , Description = "The Carousel control provides a 3-D interface for displaying objects in a rich visual manner that allows users to quickly navigate through data visually." };
            TreeNavigatorModel wpfCardView = new TreeNavigatorModel() { Header = "Card View"  , Description = "The CardView control provides a unique display of data in the form of cards that can be grouped, sorted, filtered, and edited inline and interactively." };
            TreeNavigatorModel wpfCheckedListBox = new TreeNavigatorModel() { Header = "Checked List Box" , Description = "The CheckedListBox control provides an efficient way to make a multi-selection list." };
            TreeNavigatorModel wpfGallery = new TreeNavigatorModel() { Header = "Gallery" , Description = "The Gallery control is used for displaying categorized collections of objects in thumbnail views." };
            TreeNavigatorModel wpfGroupBar = new TreeNavigatorModel() { Header = "Group Bar", Description = "The GroupBar control provides an Outlook-style navigation UI to your application's sub-sections and menu items." };
            TreeNavigatorModel wpfNotify = new TreeNavigatorModel() { Header = "Notify Icon" , Description = "The NotifyIcon control provides an interactive icon in the notification tray of the desktop with support for different animations and shapes." };

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
        public void PopulateWindowsForms()
        {
            TreeNavigatorModel windowsForms = new TreeNavigatorModel() { Header = "Windows Forms", Description = "Essential Studio for Windows Forms contains all the controls you need for building typical line-of-business web applications including grids, charts, gauges, menus, calendars, editors, and much more. It also includes some unique controls that enable your applications to read and write Excel, Word, and PDF documents." };

            TreeNavigatorModel windowsFormsGridDataControl = new TreeNavigatorModel() { Header = "Grid Data Control", Description = "The high-performance, data-bound GridData control provides a seamless editing experience, and its cell-oriented architecture provides extensive cell-level customization options." };
            TreeNavigatorModel windowsFormsGridControl = new TreeNavigatorModel() { Header = "Grid Control", Description = "The Grid control is a very efficient display engine for tabular data with a powerful formula engine and Excel-like behaviors such as formulas, freeze rows and columns, merged cells, and more. Its powerful cell rendering architecture allows you to load any control inside the grid." };
            TreeNavigatorModel windowsFormsSpreadsheet = new TreeNavigatorModel() { Header = "Spreadsheet", Description = "Essential Spreadsheet is a control for viewing and editing Microsoft Excel files in a familiar Excel-like interface. It combines some of our most popular components like our Grid control, Ribbon control, formula engine, and more to create a first of its kind offering for viewing and editing Excel files" };
            TreeNavigatorModel windowsFormsBIPivotGrid = new TreeNavigatorModel() { Header = "PivotGrid", Description = "Essential BI PivotGrid is a powerful pivot table implementation for visualizing relational data in a multidimensional UI. The pivot grid, as the name implies, pivots the data to organize it in a cross-tabulated form. The pivot grid is just like our OLAPGrid control, but works with relational data. Our powerful in-memory pivoting engine can transform hundreds of thousands of relational table rows into comprehensible pivot information within seconds. Along with pivoting, summarizing and grouping data is also supported." };
            TreeNavigatorModel windowsFormsChart = new TreeNavigatorModel() { Header = "Chart", Description = "Essential Chart for Silverlight is a high-performance charting component that is very easy to use and is also visually stunning. It includes 35 chart types ranging from simple column charts to specialized financial charts. It is designed especially for the Silverlight platform and makes use of all the nuances that the platform has to offer, such as template creation, powerful data binding, animations." };
            TreeNavigatorModel windowsFormsDocking = new TreeNavigatorModel() { Header = "Docking Manager", Description = "The docking manager provides VS.NET-style docked containers support to your application. Dock panels can be docked, floated, auto-hidden, and more. Based on a proven VS.NET-style architecture, your end users can interact with it in a very intuitive fashion. The layout can be set up easily in code or in XAML." };
            TreeNavigatorModel windowsFormsRibbon = new TreeNavigatorModel() { Header = "Ribbon", Description = "Our collection of Office 2007-style UI controls let you create Office-style menus, toolbars, window frames, and more. Bringing your application UI on par with industry standards and leaders has never been easier." };
            TreeNavigatorModel windowsFormsTree = new TreeNavigatorModel() { Header = "Tree View", Description = "The TreeViewAdv control provides all the advanced capabilities that are missing in the framework version. Advanced features such as drag-and-drop, multi-node selection, the ability to add images to nodes, and inline editing support are also available." };
            TreeNavigatorModel windowsFormsDiagram = new TreeNavigatorModel() { Header = "Diagram", Description = "Essential Diagram for Silverlight has the ability to present powerful and feature-rich diagrams. It provides an intuitive user interaction model for creating and editing diagrams with XAML support. It stores graphical objects in a node graph and renders those objects onto the screen. It explicitly lays out diagram objects, or lets the layout manager handle the job by automatically arranging the nodes using the predefined layout algorithms. Essential Diagram is fully localizable for any culture." };
            TreeNavigatorModel windowsFormsRich = new TreeNavigatorModel() { Header = "Rich-Text Editor", Description = "The RichTextBoxAdv control enables users to add formatting to text such as bold, italics, and underline. Font family, font color, and images can also be added in the control." };
            TreeNavigatorModel windowsFormsCircular = new TreeNavigatorModel() { Header = "Circular Gauge", Description = "The circular gauge maps a single numerical value in an interface similar to speedometers or clocks. A range of colors can be applied to the gauge to correspond with particular business logic. The gauge's pointer changes position as the gauge value changes over time." };
            TreeNavigatorModel windowsFormsSchedule = new TreeNavigatorModel() { Header = "Schedule", Description = "Essential Schedule for Silverlight is an Outlook calendar-like scheduler control that lets you add rich scheduling capabilities to your Silverlight applications. It is designed especially for the Silverlight platform and makes use of all the nuances that the platform has to offer, such as template creation, powerful data binding, and is also MVVM compatible." };
            TreeNavigatorModel windowsFormsMaps = new TreeNavigatorModel() { Header = "Maps", Description = "Essential Maps lets you create visually stunning and interactive maps to show geographical data from an ESRI Shapefile. It comes with built-in navigation controls along with zooming and panning features." };
            TreeNavigatorModel windowsFormsXlsIO = new TreeNavigatorModel() { Header = "XlsIO", Description = "Essential XlsIO is a .NET library that can read and write Microsoft Excel files. It features a full-fledged object model similar to the Microsoft Office Automation libraries. It can be used on systems that do not have Microsoft Excel installed, making it an excellent reporting engine for tabular data. Essential XlsIO enables users to create document-based reports in Windows, web, WPF, MVC, and Silverlight applications." };
            TreeNavigatorModel windowsFormsDocIO = new TreeNavigatorModel() { Header = "DocIO", Description = "Essential DocIO is a .NET library that can read, write, and modify Microsoft Word files. It features a full-fledged object model similar to the Microsoft Office Automation libraries. It can be used on systems that do not have Microsoft Word installed. Essential DocIO enables users to create richly formatted Microsoft Word reports in Windows Forms, ASP.NET, WPF, ASP.NET MVC applications." };
            TreeNavigatorModel windowsFormsPDF = new TreeNavigatorModel() { Header = "PDF", Description = "Essential PDF is a .NET library that can create and modify Adobe PDF files. It does not have any external dependencies and can be used in Windows Forms, ASP.NET, WPF, ASP.NET MVC applications." };
            TreeNavigatorModel windowsFormsGantt = new TreeNavigatorModel() { Header = "Gantt", Description = "The Gantt control is a Microsoft Project-like viewer and editor that is used to schedule and manage projects. Its intuitive user interface comprising table and chart views lets you visually manage tasks, task relationships, and resources. It is even possible to import and export data from Microsoft Project." };
            TreeNavigatorModel windowsFormsReportViewer = new TreeNavigatorModel() { Header = "Report Viewer", Description = "Essential Report Viewer is a viewer component for displaying reports defined in Microsoft's RDL format (2008 or 2008 R2) from within your application. Using Essential Report Viewer, you can display tabular, graphical, or free-form reports that make use of relational, multidimensional, XML, and object data sources. With client-side reports, just refer the viewer to an RDL(C) file and a data source allowing it to process and render the report. With server reports, point the viewer to an RDL file on the SSRS server to render the report." };
            TreeNavigatorModel windowsFormsAuto = new TreeNavigatorModel() { Header = "Auto-Complete", Description = "The AutoComplete control provides a common autocomplete text box to easily select values from a predefined list." };
            TreeNavigatorModel windowsFormsCarousel = new TreeNavigatorModel() { Header = "Carousel", Description = "The Carousel control provides a 3-D interface for displaying objects in a rich visual manner that allows users to quickly navigate through data visually." };
            TreeNavigatorModel windowsFormsChecked = new TreeNavigatorModel() { Header = "Checked List Box", Description = "The CheckedListBox control provides an efficient way to make a multi-selection list." };
            TreeNavigatorModel windowsFormsGroup = new TreeNavigatorModel() { Header = "Group Bar", Description = "The GroupBar control provides an Outlook-style navigation UI to your application's sub-sections and menu items." };
            TreeNavigatorModel windowsFormsHierarchy = new TreeNavigatorModel() { Header = "Hierarchy Navigator", Description = "The hierarchy navigator provides a bread crumb navigation interface that supports different skins such as Office 2019, HighContrast, Office 2016, Office 2013, Office 2010, Metro, and Blend." };
            TreeNavigatorModel windowsFormsRangeSlider = new TreeNavigatorModel() { Header = "Range Slider", Description = "The RangeSlider control provides a flexible way to select a value from a specified range with an enhanced feature set." };
            TreeNavigatorModel windowsFormsTabControl = new TreeNavigatorModel() { Header = "Tab Control", Description = "The TabControlAdv control provides a simple and intuitive interface for a tab-based navigation system." };
            TreeNavigatorModel windowsFormsTabNavigation = new TreeNavigatorModel() { Header = "Tab Navigation", Description = "The TabNavigation control provides an elegant look and feel for implementing a rich slide show of content in your webpages." };
            TreeNavigatorModel windowsFormsTaskbar = new TreeNavigatorModel() { Header = "Taskbar", Description = "The TaskBar control provides a Windows-style collapsible, grouped command item list to your UI, similar to the Windows Explorer taskbar." };

            windowsForms.ToolKits.Add(windowsFormsGridDataControl);
            windowsForms.ToolKits.Add(windowsFormsGridControl);
            windowsForms.ToolKits.Add(windowsFormsSpreadsheet);
            windowsForms.ToolKits.Add(windowsFormsBIPivotGrid);
            windowsForms.ToolKits.Add(windowsFormsChart);
            windowsForms.ToolKits.Add(windowsFormsDocking);
            windowsForms.ToolKits.Add(windowsFormsRibbon);
            windowsForms.ToolKits.Add(windowsFormsTree);
            windowsForms.ToolKits.Add(windowsFormsDiagram);
            windowsForms.ToolKits.Add(windowsFormsRich);
            windowsForms.ToolKits.Add(windowsFormsCircular);
            windowsForms.ToolKits.Add(windowsFormsSchedule);
            windowsForms.ToolKits.Add(windowsFormsMaps);
            windowsForms.ToolKits.Add(windowsFormsXlsIO);
            windowsForms.ToolKits.Add(windowsFormsDocIO);
            windowsForms.ToolKits.Add(windowsFormsPDF);
            windowsForms.ToolKits.Add(windowsFormsGantt);
            windowsForms.ToolKits.Add(windowsFormsReportViewer);
            windowsForms.ToolKits.Add(windowsFormsAuto);
            windowsForms.ToolKits.Add(windowsFormsCarousel);
            windowsForms.ToolKits.Add(windowsFormsChecked);
            windowsForms.ToolKits.Add(windowsFormsGroup);
            windowsForms.ToolKits.Add(windowsFormsHierarchy);
            windowsForms.ToolKits.Add(windowsFormsRangeSlider);
            windowsForms.ToolKits.Add(windowsFormsTabControl);
            windowsForms.ToolKits.Add(windowsFormsTabNavigation);
            windowsForms.ToolKits.Add(windowsFormsTaskbar);

            ToolKits.Add(windowsForms);
        }

        /// <summary>
        /// Method used to populate windows phone.
        /// </summary>
        public void PopulateWinUI()
        {
            TreeNavigatorModel winUI = new TreeNavigatorModel() { Header = "WinUI", Description = "Essential Studio for WinUI contains the controls you need to build line-of-business mobile applications including charts, gauges, grids,treeview and much more." };

            TreeNavigatorModel winUIChart = new TreeNavigatorModel() { Header = "Chart", Description = "SfChart provides a perfect way to visualize data with a high level of user interactivity that focus on development,productivity and simplicity of use. SfChart also provides a wide variety of charting features that can be used to visualize large quantities of data, flexibility of binding data and user customization." };
            TreeNavigatorModel winUIGrid = new TreeNavigatorModel() { Header = "Data Grid", Description = "The SfDataGrid (DataGrid) control for WinUI is used to display collection of data in rows and columns. The SfDataGrid control includes editing, exporting and data shaping features (sorting, grouping, filtering and etc) that allows the end users to easily manage the data." };
            TreeNavigatorModel winUIRich = new TreeNavigatorModel() { Header = "Tree Grid", Description = "The SfTreeGrid is a data oriented control that displays the self-relational and hierarchical data in tree structure with columns. The data can be loaded on-demand also." };
            TreeNavigatorModel winUICircular = new TreeNavigatorModel() { Header = "Circular Gauge", Description = "The circular gauge can be used to represent a range of values in a circular interface. It creates sophisticated dashboards with virtual clocks and speedometers that can be employed in financial, industrial, or medical applications." };
            TreeNavigatorModel winUIAuto = new TreeNavigatorModel() { Header = "Color Palatte", Description = "The color palette for WinUI provides a rich visual interface for color selection." };
            TreeNavigatorModel winUIChecked = new TreeNavigatorModel() { Header = "DropDown Color Palatte", Description = "The dropdown color palette for WinUI provides a rich visual interface for color selection." };
            TreeNavigatorModel winUIRange = new TreeNavigatorModel() { Header = "Range Slider", Description = "SfRangeSlider control allows you to select the range of value within the specified minimum and maximum limit. The range can be selected by moving the Thumb control along a track." };
            TreeNavigatorModel winUIButtonAdv = new TreeNavigatorModel() { Header = "DropDown Color Picker", Description = "The dropdown color picker for WinUI provides a rich visual interface for color selection." };
            TreeNavigatorModel winUIColor = new TreeNavigatorModel() { Header = "Color Picker", Description = "The color picker for WinUI provides a rich visual interface for color selection." };
            TreeNavigatorModel winUITime = new TreeNavigatorModel() { Header = "Badge", Description = "Badges are used to notify users of new or unread messages, notifications, or the status of something." };
            TreeNavigatorModel winUIMasked = new TreeNavigatorModel() { Header = "TreeView", Description = "The Syncfusion WinUI TreeView is a data-oriented control that displays data in a hierarchical structure with expanding and collapsing nodes. It is commonly used to illustrate a folder structure, or nested relationships in an application." };
            TreeNavigatorModel winUINumericUpDown = new TreeNavigatorModel() { Header = "BarCode", Description = "The Barcode control helps rendering bar codes in desktop application. The control can be merged with into any desktop application and easy to encode text using the supported symbol types. The basic structure of a bar code consists of a leading and trailing quiet zone, a start pattern, one or more data characters, optionally one or two check characters, and a stop pattern." };
            TreeNavigatorModel winUIDomainUpDown = new TreeNavigatorModel() { Header = "TimePicker", Description = "The SfTimePicker control allows the user to select time values in a touch friendly manner." };
            TreeNavigatorModel winUIJumpList = new TreeNavigatorModel() { Header = "DatePicker", Description = "The SfDatePicker control allows the user to select date values in a touch friendly manner." };

            winUI.ToolKits.Add(winUIChart);
            winUI.ToolKits.Add(winUIGrid);
            winUI.ToolKits.Add(winUIRich);
            winUI.ToolKits.Add(winUICircular);
            winUI.ToolKits.Add(winUIAuto);
            winUI.ToolKits.Add(winUIChecked);
            winUI.ToolKits.Add(winUIRange);
            winUI.ToolKits.Add(winUIButtonAdv);
            winUI.ToolKits.Add(winUIColor);
            winUI.ToolKits.Add(winUITime);
            winUI.ToolKits.Add(winUIMasked);
            winUI.ToolKits.Add(winUINumericUpDown);
            winUI.ToolKits.Add(winUIDomainUpDown);
            winUI.ToolKits.Add(winUIJumpList);

            ToolKits.Add(winUI);
        }

        /// <summary>
        /// Method used to populate metro studio.
        /// </summary>
        public void PopulateMetroStudio()
        {
            TreeNavigatorModel metroStudio = new TreeNavigatorModel() { Header = "Metro Studio", Description = "Syncfusion Metro Studio is a collection of over 1700 Metro-style icon templates that can be easily customized to create thousands of unique Metro icons." };
            ToolKits.Add(metroStudio);
        }

        /// <summary>
        /// Method used to populate ourBase studio.
        /// </summary>
        public void PopulateOurBaseStudio()
        {
            TreeNavigatorModel baseStudio = new TreeNavigatorModel() { Header = "Ourbase Studio", Description = "Orubase is the only mobile application development framework built especially for developing complex line-of-business mobile applications targeting iOS, Android, and Windows Phone platforms in the shortest possible timeframe." };
            ToolKits.Add(baseStudio);
        }
    }
}
