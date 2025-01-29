#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

namespace syncfusion.samplebrowser.wpf
{
    public class SamplesViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            this.ShowcaseDemos = new List<DemoInfo>();

#if !FILEFORMAT
            //GRIDS
            productdemos.Add(new datagriddemos.wpf.DataGridProductDemos());
            productdemos.Add(new treegriddemos.wpf.TreeGridProductDemos());
            productdemos.Add(new gridcontroldemos.wpf.GridControlProductDemos());
#if NET50 || STORE
			productdemos.Add(new pivotgriddemos.wpf.PivotGridProductDemos() { ProductCategory= "GRIDS" });
#endif
			productdemos.Add(new propertygriddemos.wpf.PropertyGridProductDemos());
            //CHARTS
            productdemos.Add(new chartdemos.wpf.ChartProductDemos());
            productdemos.Add(new chartdemos.wpf.Three_DChartProductDemos());
            productdemos.Add(new chartdemos.wpf.SFDateTimeRangeNavigatorDemo());
            productdemos.Add(new sparklinedemos.wpf.SparklineProductDemos());
            productdemos.Add(new smithchartdemos.wpf.SmithChartProductDemos());
            productdemos.Add(new sunburstchartdemos.wpf.SunburstChartProductDemos());
            productdemos.Add(new surfacechartdemos.wpf.SurfaceChartProductDemos());
            productdemos.Add(new bulletgraphdemos.wpf.BulletGraphProductDemos());
            //DATA VISUALIZATION
            productdemos.Add(new diagramdemo.wpf.DiagramProductDemos());
            productdemos.Add(new syncfusion.barcodedemos.wpf.BarcodeProductDemos());
            productdemos.Add(new gaugedemos.wpf.GaugeProductDemos());
            productdemos.Add(new ganttdemos.wpf.GanttProductDemos());
            productdemos.Add(new heatmapdemos.wpf.HeatMapProductDemos());
            productdemos.Add(new kanbandemos.wpf.KanbanProductDemos());
            productdemos.Add(new mapdemos.wpf.MapProductDemos());
            productdemos.Add(new treemapdemos.wpf.TreeMapProductDemos());
             //LAYOUT
            productdemos.Add(new dockingmanagerdemos.wpf.DockingManagerProductDemos());
            productdemos.Add(new layoutdemos.wpf.DocumentContainerProductDemos());
            productdemos.Add(new layoutdemos.wpf.ChromelessWindowProductDemos());
            productdemos.Add(new layoutdemos.wpf.CarouselProductDemos());
            productdemos.Add(new layoutdemos.wpf.CardViewProductDemo());
            productdemos.Add(new layoutdemos.wpf.TileViewProductDemos());
            productdemos.Add(new layoutdemos.wpf.GridSplitterProductDemos());
            productdemos.Add(new layoutdemos.wpf.TextInputLayoutProductDemos());
            //NAVIGATION
            productdemos.Add(new navigationdemos.wpf.TabControlExtProductDemos());
            productdemos.Add(new treeviewdemos.wpf.TreeViewProductDemos());
            productdemos.Add(new navigationdemos.wpf.AccordionProductDemos());
            productdemos.Add(new navigationdemos.wpf.HierarchicalNavigatorProductDemo());
            productdemos.Add(new navigationdemos.wpf.NavigationDrawerProductDemos());
            productdemos.Add(new navigationdemos.wpf.TreeNavigatorProductDemo());
            productdemos.Add(new navigationdemos.wpf.WizardControlProductDemo());
            //MENUS AND BARS
            productdemos.Add(new ribbondemos.wpf.RibbonProductDemos());
            productdemos.Add(new navigationdemos.wpf.GroupBarProductDemos());
            productdemos.Add(new navigationdemos.wpf.MenuProductDemos());
            productdemos.Add(new navigationdemos.wpf.RadialMenuProductDemos());
            productdemos.Add(new navigationdemos.wpf.ToolBarProductDemos());
            productdemos.Add(new navigationdemos.wpf.TaskBarProductDemos());
            // INPUT CONTROLS
            productdemos.Add(new editordemos.wpf.EditorsProductDemos());
			productdemos.Add(new editordemos.wpf.ButtonProductDemos());
            productdemos.Add(new editordemos.wpf.ColorPickerProductDemos());
            productdemos.Add(new imageeditordemos.wpf.ImageEditorProductDemos());
            productdemos.Add(new editordemos.wpf.RangeSliderProductDemos());
            productdemos.Add(new editordemos.wpf.RadialSliderProductDemos());
            productdemos.Add(new editordemos.wpf.RatingProductDemos());
            productdemos.Add(new editordemos.wpf.CalculatorProductDemo());
            //CALENDAR
            productdemos.Add(new schedulerdemos.wpf.SchedulerProductDemos());
            productdemos.Add(new editordemos.wpf.DateTimeEditProductDemo());
            productdemos.Add(new editordemos.wpf.DatePickerProductDemos());
            productdemos.Add(new editordemos.wpf.TimePickerProductDemos());
            productdemos.Add(new editordemos.wpf.CalendarProductDemos());
            productdemos.Add(new editordemos.wpf.TimeSpanEditProductDemo());
            //NOTIFICATION
            productdemos.Add(new syncfusion.notificationdemos.wpf.BusyIndicatorProductDemos());
            productdemos.Add(new syncfusion.notificationdemos.wpf.ProgressbarProductDemos());
            productdemos.Add(new syncfusion.notificationdemos.wpf.BadgeProductDemos());
            productdemos.Add(new syncfusion.notificationdemos.wpf.HubTileProductDemos());
            //FILE FORMAT
            productdemos.Add(new syncfusion.pdfdemos.wpf.PdfProductDemos());
            productdemos.Add(new syncfusion.xlsiodemos.wpf.XlsIOProductDemos());
            productdemos.Add(new syncfusion.dociodemos.wpf.DocIOProductDemos());
            productdemos.Add(new syncfusion.presentationdemos.wpf.PresentationProductDemos());
            //FILE VIEWERS AND EDITORS
            productdemos.Add(new pdfviewerdemos.wpf.PdfViewerProductDemos());
            productdemos.Add(new spreadsheetdemos.wpf.SpreadsheetProductDemos());
            productdemos.Add(new syncfusion.richtextboxdemos.wpf.RichTextBoxProductDemos());
            productdemos.Add(new syntaxeditordemos.wpf.SyntaxEditorProductDemos());
            //LISTS AND DROPDOWN
            productdemos.Add(new dropdowndemos.wpf.AutoCompleteProductDemos());
            productdemos.Add(new dropdowndemos.wpf.ComboBoxProductDemos());
            productdemos.Add(new dropdowndemos.wpf.CheckListBoxProductDemos());
            productdemos.Add(new dropdowndemos.wpf.MultiColumnDropDownProductDemos());
            //MISCELLANEOUS
            productdemos.Add(new spellcheckerdemo.wpf.SpellCheckerProductDemos());
            productdemos.Add(new syncfusion.calculatedemos.wpf.CalculatorProductDemos());
            //CONVERSATIONAL UI
            productdemos.Add(new assistviewdemo.wpf.AIAssistViewProductDemos());
#if !NET50 && !STORE
            //BUSSINESS INTELLIGENCE
            productdemos.Add(new pivotgriddemos.wpf.PivotGridProductDemos());
#if !TEST
            productdemos.Add(new olapgriddemos.wpf.OlapGridProductDemos());
            productdemos.Add(new olapgaugedemos.wpf.OlapGaugeProductDemos());
            productdemos.Add(new olapclientdemos.wpf.OlapClientProductDemos());
            productdemos.Add(new olapchartdemos.wpf.OlapChartProductDemos());
#endif
#endif
            //ShowcaseDemos
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.weatheranalysis.wpf.WeatherAnalysisDemo), SampleName = "Weather Analysis", ImagePath = "/syncfusion.weatheranalysis.wpf;component/Assets/WeatherAnalysis/WeatherAnalysis.png", IsShowcase = true });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.stockanalysisdemo.wpf.StockAnalysisDemo), SampleName = "Stock Analysis", ImagePath = "/syncfusion.stockanalysisdemo.wpf;component/Assets/StockAnalysis.png", IsShowcase = true });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.expenseanalysis.wpf.ExpenseAnalysisDemo), SampleName = "Expense Analysis", ImagePath = "/syncfusion.expenseanalysis.wpf;component/Assets/ExpenseAnalysis/ExpenseAnalysis.png", IsShowcase = true });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.cardashboard.wpf.CarDashBoardDemo), SampleName = "Car DashBoard", ImagePath = "/syncfusion.cardashboard.wpf;component/Assets/Car Dashboard/CarDashboard.png", IsShowcase = true});
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.succinctlyseries.wpf.SuccinctlySeriesDemo), SampleName = "Succinctly Series", ImagePath = "/syncfusion.succinctlyseries.wpf;component/Assets/Succinctly Series/succinctlyseries.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.diagrambuilder.wpf.DiagramBuilderDemo), SampleName = "Diagram Builder", ImagePath = "/syncfusion.diagrambuilder.wpf;component/Asset/DiagramBuilder.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.brainstormingdiagram.wpf.BrainstormingDiagramDemo), SampleName = "Brainstorm Diagram", ImagePath = "/syncfusion.brainstormingdiagram.wpf;component/Resources/Brainstorming.png", IsShowcase = true });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.logicalcircuitdesigner.wpf.LogicalCircuitDesignerDemo), SampleName = "Logic Circuit Diagram", ImagePath = "/syncfusion.logicalcircuitdesigner.wpf;component/Asset/logicCircuitDiagram.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.salesanalysis.wpf.SalesAnalysisDemo), SampleName = "Sales Analysis", ImagePath = "/syncfusion.salesanalysis.wpf;component/Assets/Sales Analysis/SalesAnalysis.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.powerpointviewer.wpf.PowerPointViewerDemo), SampleName = "PowerPoint Viewer", ImagePath = "/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/PowerPointViewer.PNG" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.invoice.wpf.InvoiceDemo), SampleName = "Invoice", ImagePath = "/syncfusion.invoice.wpf;component/Assets/Invoice/Invoice.png" });
#if !TEST
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.visualstudiodemo.wpf.VisualStudioDemo), SampleName = "Visual Studio", ImagePath = "/syncfusion.visualstudiodemo.wpf;component/Assets/visualstudio/VisualStudio.png", IsShowcase = true });
#endif
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.spreadsheetdemo.wpf.SpreadSheetDemo), SampleName = "Spreadsheet", ImagePath = "/syncfusion.spreadsheetdemo.wpf;component/Assets/SfSpreadsheet.png", IsShowcase = true });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.auditshowcase.wpf.AuditShowcaseDemo), SampleName = "Audit Prediction", ImagePath = "/syncfusion.auditshowcase.wpf;component/Assets/AuditShowcase/AuditPrediction.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.organizationallayout.wpf.organizationallayoutdemo), SampleName = "Organizational Layout", ImagePath = "/syncfusion.organizationallayout.wpf;component/Asset/organization.png", IsShowcase = true });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.floorplanner.wpf.FloorPlannerDemo), SampleName = "Floor Planner", ImagePath = "/syncfusion.floorplanner.wpf;component/Asset/floor-planner-tile.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.networkdiagram.wpf.Views.NetworkDiagramDemo), SampleName = "Network Diagram", ImagePath = "/syncfusion.networkdiagram.wpf;component/Asset/networkdiagram.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.workfloweditor.wpf.WorkFlowEditorDemo), SampleName = "Workflow Editor", ImagePath = "/syncfusion.workfloweditor.wpf;component/Resource/work-flow.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.bpmneditor.wpf.BpmnEditorDemo), SampleName = "BPMN Editor", ImagePath = "/syncfusion.bpmneditor.wpf;component/Asset/bpmneditor.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.documenteditor.wpf.DocumentEditorDemo), SampleName = "DocumentEditor", ImagePath = "/syncfusion.documenteditor.wpf;component/Assets/documenteditor/DocumentEditor.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.formulaanalysis.wpf.FormulaAnalysisDemo), SampleName = "Formula Analysis", ImagePath = "/syncfusion.formulaanalysis.wpf;component/Assets/FormulaAnalysis/FormulaAnalysis.png", IsShowcase = true });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.patientmonitor.wpf.PatientMonitorDemo), SampleName = "Patient Monitor", ImagePath = "/syncfusion.patientmonitor.wpf;component/Assets/PatientMonitor/PatientMonitor.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.unitconverter.wpf.UnitConverterDemo), SampleName = "Unit Converter", ImagePath = "/syncfusion.unitconverter.wpf;component/Assets/UnitConverter.png" });
#else
			productdemos.Add(new syncfusion.pdfdemos.wpf.PdfProductDemos());
			productdemos.Add(new syncfusion.xlsiodemos.wpf.XlsIOProductDemos());
			productdemos.Add(new syncfusion.dociodemos.wpf.DocIOProductDemos());
			productdemos.Add(new syncfusion.presentationdemos.wpf.PresentationProductDemos());
			
            productdemos.Add(new syncfusion.pdfviewerdemos.wpf.PdfViewerProductDemos());
            productdemos.Add(new syncfusion.spreadsheetdemos.wpf.SpreadsheetProductDemos());
			productdemos.Add(new syncfusion.richtextboxdemos.wpf.RichTextBoxProductDemos());

            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.invoice.wpf.InvoiceDemo), SampleName = "Invoice", ImagePath = "/syncfusion.invoice.wpf;component/Assets/Invoice/Invoice.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.succinctlyseries.wpf.SuccinctlySeriesDemo), SampleName = "Succinctly Series", ImagePath = "/syncfusion.succinctlyseries.wpf;component/Assets/Succinctly Series/succinctlyseries.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.documenteditor.wpf.DocumentEditorDemo), SampleName = "DocumentEditor", ImagePath = "/syncfusion.documenteditor.wpf;component/Assets/documenteditor/DocumentEditor.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.spreadsheetdemo.wpf.SpreadSheetDemo), SampleName = "Spreadsheet", ImagePath = "/syncfusion.spreadsheetdemo.wpf;component/Assets/SfSpreadsheet.png" });
            this.ShowcaseDemos.Add(new DemoInfo() { DemoViewType = typeof(syncfusion.powerpointviewer.wpf.PowerPointViewerDemo), SampleName = "Presentation Viewer", ImagePath = "/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/PowerPointViewer.PNG" });
#endif
            return productdemos;
        }
    }
}
