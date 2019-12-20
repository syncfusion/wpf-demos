#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="MainWindow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace ExportChart
{
    using SampleUtils;

    /// <summary>
    /// The right pane of the sample window contains two buttons named Copy and Save.
    /// 1.When the Copy button is clicked, the chart is copied to the clipboard and can be pasted in any suitable application,
    ///   such as Microsoft Paint as well as word processors, spreadsheets, presentations, and so on.
    /// 2.When the Save button is clicked, the chart can be exported to any of the formats:
    ///  Image format,Bitmap (.bmp),JPG,PNG ,GIF,TIFF,WDP,Document Formats,DOC and PDF
    /// Features:
    /// 1.OLAP Chart for WPF allows charts to be exported in different image formats
    /// 2.ExportIntoNewDoc allows a chart to be exported  into a new Word document with a specified file name.
    ///   It takes the file name as a parameter
    /// 3.ExportIntoTemplateDoc allows a chart to be exported into an existing Word document in the default marker string location. If the default marker string is not found, then the insertion will take place at the end of the document file. 
    ///   It takes the existing document file name as a parameter
    /// 4.ExportIntoTemplateDoc allows a chart to be exported into an existing Word document in the marker string location.
    ///   It takes an existing document file name and marker string as the parameters
    /// 5.ExportIntoTemplateDoc allows a chart to be exported into an existing instance of a document in the default marker string location. If the marker string is not found, then exporting will be done at the end of the document's instance.
    ///   It takes the existing document instance as a parameter.
    /// 6.ExportIntoTemplateDoc allows a chart to be exported into an existing instance of a document in the marker string location.
    ///   It takes the document instance and the marker string as parameters
    /// 7.ExportIntoNewPDF allows a chart to be exported into a new PDF document with the specified file name.
    ///   It takes the file name as a parameter.
    /// 
    /// </summary>
    public partial class MainWindow : SampleWindow
	{
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            ViewModel.ViewModel.ConnectionString = GetConnectionString();
            InitializeComponent();
        }

        #endregion
	}
}