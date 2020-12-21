# Syncfusion WPF samples 

This repository contains the demos of [Syncfusion WPF UI controls](https://www.syncfusion.com/products/wpf?utm_source=github&utm_medium=listing). This is the best place to check our controls to get more insight about the usage of APIs. You can also check our controls by installing out [Demos](https://www.syncfusion.com/demos#desktop?utm_source=github&utm_medium=listing), in which you can browse the demo for all the controls.

This section guides you to use the Syncfusion WPF samples in your applications.

* [Requirements to run the demo](#requirements-to-run-the-demo)
* [How to run the demos](#how-to-run-the-demos)
* [Controls Catalog](#controls-catalog)
* [Documentation](#documentation)
* [License](#license)
* [Support and Feedback](#support-and-feedback)

## <a name="requirements-to-run-the-demo"></a>Requirements to run the demo ##

The demos are provided for .NET Framework 4.5, .NET Framework 4.7 and .NET 5.0. 
* .NET Framework - Requires Visual Studio 2010 or higher to run demos based on the .NET Framework you want to use.
* Refer [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) requirements for running .NET5.0 demos.

## <a name="how-to-run-the-demos"></a>How to run the demos ##

### Running All Controls Demo

To run the demos, 
 * Clone or download this repository.
 * Open `syncfusion.samplebrowser.wpf_47` file (`_47` denotes framework version, You can choose the solution files ends with `_45` or `_50` also) present under **samplebrowser** folder in Visual Studio.
 * Restore nugets for all the demo projects.
 * Set `syncfusion.samplebrowser.wpf` as start up project and run.

   **Notes:** While downloading the zip file, follow below steps
   * Before you unzip the archive, right-click it, select **Properties**, and then select **Unblock**.
   * Be sure to unzip the entire archive, and not just individual demos. The demos all depend on the common folder in the archive.
   * If you unzip individual demos, they will not build due to references to other portions of the ZIP file that were not unzipped. You must unzip the entire archive if you intend to build the samples.
   
### Running Individual Control Demos

To run the Individual Control Demos, 
 * Open respective control folder. For example, To run `DataGrid demos` open `syncfusion.datagriddemos.wpf_47` file (`_47` denotes framework version, You can choose the solution files ends with `_45` or `_50` also) present under **datagrid** folder in Visual Studio.
 * Build project to restore nugets for the demo project.
 * Set `syncfusion.datagriddemos.wpf` as start up project and run.

## <a name="controls-catalog"></a>Controls Catalog ## 

<table>
    <tr>
        <td colspan="3">
            <b>GRIDS</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="datagrid">Data Grid</a>
        </td>
        <td>
            <a href="treegrid">Tree Grid</a>
        </td>
        <td>
            <a href="gridcontrol">Grid Control</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="propertygrid">Property Grid</a>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <b>CHARTS</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="charts">Charts</a>
        </td>
        <td>
            <a href="charts">3D-Charts</a>
        </td>
        <td>
            <a href="charts">Range Navigator</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="sparkline">Sparkline</a>
        </td>
        <td>
            <a href="smithchart">Smith Chart</a>
        </td>
        <td>
            <a href="sunburstchart">Sunburst Chart</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="surfacechart">Surface Chart</a>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <b>DATA VISUALIZATION</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="diagram">Diagram</a>
        </td>
        <td>
            <a href="barcode">Barcode</a>
        </td>
        <td>
            <a href="bulletgraph">Bullet Graph</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="gauge">Gauge</a>
        </td>
        <td>
            <a href="gantt">Gantt</a>
        </td>
        <td>
            <a href="heatmap">Heat Map</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="kanban">Kanban</a>
        </td>
         <td>
            <a href="map">Map</a>
        </td>
         <td>
            <a href="treemap">Treemap</a>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <b>LAYOUT</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="dockingmanager">Docking Manager</a>
        </td>
        <td>
            <a href="layout">Document Container</a>
        </td>
        <td>
            <a href="layout">Chromeless Window</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="layout">Carousel</a>
        </td>
        <td>
            <a href="layout">Card View</a>
        </td>
        <td>
            <a href="layout">Tile View</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="layout">Grid Splitter</a>
        </td>
         <td>
            <a href="layout">TextInputLayout</a>
        </td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <b>NAVIGATION</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="navigation">TabControl</a>
        </td>
        <td>
            <a href="treeview">TreeView</a>
        </td>
        <td>
            <a href="navigation">Accordion</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="navigation">Hierarchical Navigator</a>
        </td>
        <td>
            <a href="navigation">Navigation Drawer</a>
        </td>
        <td>
            <a href="navigation">Tree Navigator</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="navigation">Wizard Control</a>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <b>MENUS AND BARS</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="ribbon">Ribbon</a>
        </td>
        <td>
            <a href="navigation">Group Bar</a>
        </td>
        <td>
            <a href="navigation">Menu</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="navigation">Radial Menu</a>
        </td>
        <td>
            <a href="navigation">Tool Bar</a>
        </td>
        <td>
            <a href="navigation">Task Bar</a>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <b>INPUT CONTROLS</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="editor">Editors</a>
        </td>
        <td>
            <a href="editor">Buttons</a>
        </td>
        <td>
            <a href="editor">Color Picker</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="imageeditor">Image Editor</a>
        </td>
        <td>
            <a href="editor">Range Slider</a>
        </td>
        <td>
            <a href="editor">Radial Slider</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="editor">Rating</a>
        </td>
        <td>
            <a href="editor">Calculator</a>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <b>CALENDAR</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="scheduler">Scheduler</a>
        </td>
        <td>
            <a href="editor">DateTimeEdit</a>
        </td>
        <td>
            <a href="editor">Date Picker</a>
        </td>
    </tr>
    <tr>
        <td>
            <a href="editor">Time Picker</a>
        </td>
        <td>
            <a href="editor">Calendar</a>
        </td>
        <td>
            <a href="navigation">TimeSpan Edit</a>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <b>NOTIFICATION</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="notification">Hub Tile</a>
        </td>
        <td>
            <a href="notification">Notify Icon</a>
        </td>
        <td>
            <a href="notification">Busy Indicator</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="notification">Progressbar</a>
        </td>
        <td></td>
        <td></td>
    </tr>
     <tr>
        <td colspan="3">
            <b>FILE FORMAT</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="pdf">PDF</a>
        </td>
        <td>
            <a href="xlsio">Excel Library (XlsIO)</a>
        </td>
        <td>
            <a href="docio">Word Library (DocIO)</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="presentation">Presentation</a>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <b>FILE VIEWERS AND EDITORS</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="pdfviewer">PDF Viewer</a>
        </td>
        <td>
            <a href="spreadsheet">Spreadsheet</a>
        </td>
        <td>
            <a href="richtextbox">RichTextBox</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="syntaxeditor">Syntax Editor</a>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <b>LISTS AND DROPDOWN</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="dropdown">AutoComplete</a>
        </td>
        <td>
            <a href="dropdown">ComboBox</a>
        </td>
        <td>
            <a href="dropdown">CheckListBox</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="dropdown">MultiColumn Dropdown</a>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <b>MISCELLANEOUS</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="spellchecker">Spell Checker</a>
        </td>
        <td>
            <a href="calculate">Calculate</a>
        </td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">
            <b>BUSINESS INTELLIGENCE</b>
        </td>
    </tr>
    <tr>
        <td>
            <a href="pivotgrid">Pivot Grid</a>
        </td>
        <td>
            <a href="olapgrid">Olap Grid</a>
        </td>
        <td>
            <a href="olapgauge">Olap Gauge</a>
        </td>
    </tr>
     <tr>
        <td>
            <a href="olapclient">Olap Client</a>
        </td>
        <td>
            <a href="olapchart">Olap Chart</a>
        </td>
        <td></td>
    </tr>
</table>

## <a name="documentation"></a>Documentation ##

* [Syncfusion User Guide](https://help.syncfusion.com/wpf/welcome-to-syncfusion-essential-wpf?utm_source=github&utm_medium=listing)
* [API Reference](https://help.syncfusion.com/cr/wpf?utm_source=github&utm_medium=listing)

## <a name="license"></a>License ##

Syncfusion has no liability for any damage or consequence that may arise by the use or viewing of the samples. The samples are for demonstrative purposes and if you choose to use or access the samples you agree to not hold Syncfusion liable, in any form, for any damage that is related to use, accessing or otherwise viewing the samples. By accessing, viewing, or otherwise seeing the samples you acknowledge and agree Syncfusion’s samples will not allow you to seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize or otherwise do anything with Syncfusion’s samples.

## <a name="support-and-feedback"></a>Support and Feedback ##

* For any other queries, reach our [Syncfusion support team](https://www.syncfusion.com/support/directtrac/incidents/newincident?utm_source=github&utm_medium=listing) or post the queries through the [community forums](https://www.syncfusion.com/forums?utm_source=github&utm_medium=listing).

* To renew the subscription, click [here](https://www.syncfusion.com/sales/products?utm_source=github&utm_medium=listing) or contact our sales team at <salessupport@syncfusion.com>.

<p>Copyright © 2001-2020 Syncfusion, Inc. Updated on 2020-12-21 at precisely 22:38:05 EST.</p>
  
