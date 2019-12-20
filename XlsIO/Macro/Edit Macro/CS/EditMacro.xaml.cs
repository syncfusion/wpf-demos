#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Media;
using Syncfusion.XlsIO;
using System.ComponentModel;
using System.Globalization;
using Syncfusion.Windows.Shared;
using Syncfusion.Office;

namespace EssentialXlsIOSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditMacro : ChromelessWindow
    {
        #region Constants
#if NETCORE
        private const string DEFAULTPATH = @"..\..\..\..\..\..\..\Common\Data\XlsIO\{0}";
        private const string DEFAULTIMAGEPATH = @"..\..\..\..\..\..\..\Common\Images\XlsIO\{0}";
#else
        private const string DEFAULTPATH = @"..\..\..\..\..\..\Common\Data\XlsIO\{0}";
        private const string DEFAULTIMAGEPATH = @"..\..\..\..\..\..\Common\Images\XlsIO\{0}";
#endif
        #endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public EditMacro()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string headerImage = GetFullImagePath("xlsio_header.png");
            this.image1.Source = (ImageSource)img.ConvertFromString(headerImage); 
        }
        #endregion

        #region Events
        /// <summary>
        /// Loads the input template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fileName = GetFullTemplatePath("EditMacroTemplate.xltm");
                #region View the Workbook
                try
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
#else
                    System.Diagnostics.Process.Start(fileName);
#endif                    
                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show("MS Excel is not installed in this system");
                    Console.WriteLine(ex.ToString());
                }
                #endregion
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        /// <summary>
        /// Edits and saves the macro file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            #region Initialize Workbook
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //An existing macro-enabled workbook is opened.[Equivalent to the workbook in MS Excel]
            IWorkbook workbook;
            string inputPath = GetFullTemplatePath("EditMacroTemplate.xltm");
            workbook = application.Workbooks.Open(inputPath, ExcelOpenType.Automatic);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet worksheet = workbook.Worksheets[0];
            #endregion

            #region Edit Macro
            IVbaProject vbaProject = workbook.VbaProject;
            IVbaModule vbaModule = vbaProject.Modules["Module1"];
            vbaModule.Code = vbaModule.Code.Replace("xlAreaStacked", "xlLine");
            #endregion

            try
            {
                #region Workbook Save
                string fileName = "";
                if (rdbXLS.IsChecked.Value)
                {
                    fileName = "EditMacro.xls";
                    workbook.Version = ExcelVersion.Excel97to2003;
                    workbook.SaveAs(fileName);
                }
                else if (rdbXLTM.IsChecked.Value)
                {
                    fileName = "EditMacro.xltm";
                    workbook.SaveAs(fileName);
                }
                else if (rdbXLSM.IsChecked.Value)
                {
                    fileName = "EditMacro.xlsm";
                    workbook.SaveAs(fileName);
                }
                #endregion

                #region Workbook Close and Dispose
                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();
                #endregion

                #region View the Workbook
                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                        {
                            UseShellExecute = true
                        };
                        process.Start();
#else
                        System.Diagnostics.Process.Start(fileName);
#endif

                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("MS Excel is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
                #endregion
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        # endregion

        #region HelperMethods
        /// <summary>
        /// Get the input file and return the path of input file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns></returns>
        private string GetFullTemplatePath(string inputFile)
        {
            return string.Format(DEFAULTPATH, inputFile);
        }

        private string GetFullImagePath(string imageFile)
        {
            return string.Format(DEFAULTIMAGEPATH, imageFile);
        }
        #endregion

    }
}