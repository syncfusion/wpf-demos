#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.XlsIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace FormControls_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        private string fileName;
        private System.Drawing.Color color1;
        private string[] onlinePayments;

        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            onlinePayments = new string[] { "Credit Card", "Net Banking" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            // The instantiation process consists of two steps.

            // Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            // Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

             // Check if user opts for Excel 2007
            if (this.rdButtonxlsx.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2007;
                color1 = System.Drawing.Color.FromArgb(255, 255, 230);
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2010;
                color1 = System.Drawing.Color.FromArgb(255, 255, 230);
            }
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2013;
                color1 = System.Drawing.Color.FromArgb(255, 255, 230);
            }
            else
                color1 = System.Drawing.Color.FromArgb(255, 255, 204);

            // A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            // Workbook created with two worksheets
            IWorkbook workbook = application.Workbooks.Create(2);
            // The first worksheet object in the worksheets collection is accessed.
            // (0 based index)
            IWorksheet sheet2 = workbook.Worksheets[1];
            //Assigning the array content to cells
            // by passing row and column position 
            for (int i = 0; i < onlinePayments.Length; i++)
                sheet2.SetValue(i + 1, 1, onlinePayments[i]);

            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

              
            sheet.Pictures.AddPicture(2, 3, @"..\..\..\..\..\..\..\Common\Images\XlsIO\contact_sales.gif");
            sheet[4, 3].Text = "Phone";
            sheet[4, 3].CellStyle.Font.Bold = true;
            sheet[5, 3].Text = "Toll Free";
            sheet[5, 5].Text = "1-888-9DOTNET";
            sheet[6, 5].Text = "1-888-936-8638";
            sheet[7, 5].Text = "1-919-481-1974";
            sheet[8, 3].Text = "Fax";
            sheet[8, 5].Text = "1-919-573-0306";
            sheet[9, 3].Text = "Email";
            sheet[10, 3].Text = "Sales";
            //Creating the hyperlink in the 10th column and 
            //5th row of the sheet 
            IHyperLink link = sheet.HyperLinks.Add(sheet[10, 5]);
            link.Type = ExcelHyperLinkType.Url;
            link.Address = "mailto:sales@syncfusion.com";

            sheet[12, 3].Text = "Please fill out all required fields.";
            sheet[14, 5].Text = "First Name*";
            sheet[14, 5].CellStyle.Font.Bold = true;
            sheet[14, 8].Text = "Last Name*";
            sheet[14, 8].CellStyle.Font.Bold = true;

            //Create textbox for respective field
            //textbox to get First Name
            ITextBoxShape textBoxShape = sheet.TextBoxes.AddTextBox(15, 5, 23, 190);
            textBoxShape.Fill.FillType = ExcelFillType.SolidColor;
            textBoxShape.Fill.ForeColor = color1;

            //textbox to get Last Name
            textBoxShape = sheet.TextBoxes.AddTextBox(15, 8, 23, 195);
            textBoxShape.Fill.FillType = ExcelFillType.SolidColor;
            textBoxShape.Fill.ForeColor = color1;

            sheet[17, 3].Text = "Company*";
            textBoxShape = sheet.TextBoxes.AddTextBox(17, 5, 23, 385);
            textBoxShape.Fill.FillType = ExcelFillType.SolidColor;
            textBoxShape.Fill.ForeColor = color1;
            sheet[19, 3].Text = "Phone*";
            textBoxShape = sheet.TextBoxes.AddTextBox(19, 5, 23, 385);
            textBoxShape.Fill.FillType = ExcelFillType.SolidColor;
            textBoxShape.Fill.ForeColor = color1;
            sheet[21, 3].Text = "Email*";
            textBoxShape = sheet.TextBoxes.AddTextBox(21, 5, 23, 385);
            textBoxShape.Fill.FillType = ExcelFillType.SolidColor;
            textBoxShape.Fill.ForeColor = color1;
            sheet[23, 3].Text = "Website";
            textBoxShape = sheet.TextBoxes.AddTextBox(23, 5, 23, 385);

            ICheckBoxShape chkBoxProducts = sheet.CheckBoxes.AddCheckBox(25, 5, 20, 75);
            chkBoxProducts.Text = "";           
            sheet[25, 3].Text = "Multiple products?";

            sheet[27, 3, 28, 3].Merge();
            sheet[27, 3].Text = "Product(s)*";
            sheet[27, 3].MergeArea.CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
            // Create a checkbox for each product
            ICheckBoxShape chkBoxProduct;
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(27, 5, 20, 75);
            chkBoxProduct.Text = "Studio";
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(27, 6, 20, 75);
            chkBoxProduct.Text = "Calculate";
            chkBoxProduct.IsSizeWithCell = true;
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(27, 7, 20, 75);
            chkBoxProduct.Text = "Chart";
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(27, 8, 20, 75);
            chkBoxProduct.Text = "Diagram";
            chkBoxProduct.IsSizeWithCell = true;
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(27, 9, 20, 75);
            chkBoxProduct.Text = "Edit";
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(27, 10, 20, 75);
            chkBoxProduct.Text = "XlsIO";
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(28, 5, 20, 75);
            chkBoxProduct.Text = "Grid";
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(28, 6, 20, 75);
            chkBoxProduct.Text = "Grouping";
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(28, 7, 20, 75);
            chkBoxProduct.Text = "HTMLUI";
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(28, 8, 20, 75);
            chkBoxProduct.Text = "PDF";
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(28, 9, 20, 75);
            chkBoxProduct.Text = "Tools";
            chkBoxProduct = sheet.CheckBoxes.AddCheckBox(28, 10, 20, 75);
            chkBoxProduct.Text = "DocIO";
            chkBoxProducts.CheckState = ExcelCheckState.Mixed;

            //generate the link to linked cell property and formula
            GenerateFormula(excelEngine);


            sheet[30, 3].Text = "Selected Products Count";
            //counts the selected product
            sheet[30, 5].Formula = "Sum(AA2:AA13)";
            //align the cell content
            sheet[30, 5].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
            //create the textbox for additional information
            sheet[35, 3].Text = "Additional Information";
            textBoxShape = sheet.TextBoxes.AddTextBox(32, 5, 150, 385);


            if (!this.rdButtonxls.IsChecked.Value)
            {
                sheet[43, 3].Text = "Online Payment";

                // Create combobox
                IComboBoxShape comboBox1 = sheet.ComboBoxes.AddComboBox(43, 5, 20, 100);

                // Assign range to display in dropdown list
                comboBox1.ListFillRange = sheet2["A1:A2"];

                // select 1st item from the list
                comboBox1.SelectedIndex = 1;

                sheet[46, 3].Text = "Card Type";
                IOptionButtonShape optionButton1 = sheet.OptionButtons.AddOptionButton(46, 5);
                optionButton1.Text = "American Express";
                optionButton1.CheckState = ExcelCheckState.Checked;

                optionButton1 = sheet.OptionButtons.AddOptionButton(46, 7);
                optionButton1.Text = "Master Card";

                optionButton1 = sheet.OptionButtons.AddOptionButton(46, 9);
                optionButton1.Text = "Visa";
            }
            //column alignment
            sheet.Columns[0].AutofitColumns();
            sheet.Columns[3].ColumnWidth = 12;
            sheet.Columns[4].ColumnWidth = 10;
            sheet.Columns[5].ColumnWidth = 10;
            sheet.IsGridLinesVisible = false;
            // Assign the filename depends upon the version
            if ((this.rdButtonxlsx.IsChecked.Value) || (this.rdButtonexcel2010.IsChecked.Value) || (this.rdButtonexcel2013.IsChecked.Value))
                fileName = "FormControls.xlsx";
            else
                fileName = "FormControls.xls";

            try
            {
                // Save the file
                workbook.SaveAs(fileName);
                //closes the workbook
                workbook.Close();
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process.Start(fileName);

                        //Exit
                        this.Close();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                    // Exit
                    this.Close();
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        #region Helper Methods
        /// <summary>
        /// Generates the formula and linkedcell 
        /// </summary>
        /// <param name="excelEngine">excel application engine</param>
        private void GenerateFormula(ExcelEngine excelEngine)
        {
            //gets the address of the 1st sheet
            IWorksheet worksheet = excelEngine.Excel.Workbooks[0].Worksheets[0];
            ICheckBoxes checkBoxes = worksheet.CheckBoxes;
            string formula;
            // loop through each checkbox and assing the link
            for (int i = 1; i < checkBoxes.Count; i++)
            {
                // range for linkedcell
                IRange range = worksheet["Z" + (i + 1)];
                checkBoxes[i].LinkedCell = range;
                //formula to check whether the checkbox checked
                formula = "IF(" + range.AddressLocal + ",1,0)";
                worksheet["AA" + (i + 1)].Formula = formula;
            }
        }
        #endregion
    }
}
