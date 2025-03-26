#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using syncfusion.demoscommon.wpf;
using System.Xml;
using System.Drawing;
using System.Collections.Generic;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TableStyles : DemoControl
    {
        #region Private Members
        string fileName;
        #endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public TableStyles()
        {
            InitializeComponent();
            fileName = @"Assets\DocIO\";           
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {           
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates word document with built - in styles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Open the template document
                using (WordDocument document = new WordDocument(fileName + "TemplateTableStyle.doc"))
                {

                    //Create MailMergeDataTable
                    MailMergeDataTable mailMergeDataTable = GetMailMergeDataTable();
                    //Execute Mail Merge with groups.
                    document.MailMerge.ExecuteGroup(mailMergeDataTable);

                    #region Built-in table styles
                    //Get table to apply style.
                    WTable table = (WTable)document.LastSection.Tables[0];
                    //Apply built-in table style to the table.
                    table.ApplyStyle(BuiltinTableStyle.MediumShading1Accent5);
                    #endregion

                    #region Save Document
                    //Save as docx format
                    if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            document.Save("Table Styles.docx", FormatType.Docx);
                            //Message box confirmation to view the created document
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Table Styles.docx") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Win32Exception ex)
                                {
                                    MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Table Styles.docx" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as pdf format
                    else if (pdf.IsChecked.Value)
                    {
                        try
                        {
                            DocToPDFConverter converter = new DocToPDFConverter();
                            //Convert word document into PDF document
                            PdfDocument pdfDoc = converter.ConvertToPDF(document);
                            //Save the pdf file
                            pdfDoc.Save("Table Styles.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Table Styles.pdf") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("PDF Viewer is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Table Styles.pdf" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creates word document with Custom styles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //Open the template document
                using (WordDocument document = new WordDocument(fileName + "TemplateTableStyle.doc"))
                {

                    //Create MailMergeDataTable
                    MailMergeDataTable mailMergeDataTable = GetMailMergeDataTable();
                    //Execute Mail Merge with groups.
                    document.MailMerge.ExecuteGroup(mailMergeDataTable);

                    #region Custom table styles
                    #region Custom table styles
                    //Get table to apply style
                    WTable table = (WTable)document.LastSection.Tables[0];
                    #region Apply Table style
                    WTableStyle tableStyle = document.AddTableStyle("Tablestyle") as WTableStyle;
                    Color borderColor = Color.WhiteSmoke;
                    Color firstRowBackColor = Color.Blue;
                    Color backColor = Color.WhiteSmoke;
                    ConditionalFormattingStyle firstRowStyle, lastRowStyle, firstColumnStyle, lastColumnStyle, oddColumnBandingStyle, oddRowBandingStyle, evenRowBandingStyle;

                    #region Table Properties
                    tableStyle.TableProperties.RowStripe = 1;
                    tableStyle.TableProperties.ColumnStripe = 1;
                    tableStyle.TableProperties.LeftIndent = 0;

                    tableStyle.TableProperties.Paddings.Top = 0;
                    tableStyle.TableProperties.Paddings.Bottom = 0;
                    tableStyle.TableProperties.Paddings.Left = 5.4f;
                    tableStyle.TableProperties.Paddings.Right = 5.4f;

                    tableStyle.TableProperties.Borders.Top.BorderType = BorderStyle.Single;
                    tableStyle.TableProperties.Borders.Top.LineWidth = 1f;
                    tableStyle.TableProperties.Borders.Top.Color = Color.AliceBlue;
                    tableStyle.TableProperties.Borders.Top.Space = 0;

                    tableStyle.TableProperties.Borders.Bottom.BorderType = BorderStyle.Single;
                    tableStyle.TableProperties.Borders.Bottom.LineWidth = 1f;
                    tableStyle.TableProperties.Borders.Bottom.Color = borderColor;
                    tableStyle.TableProperties.Borders.Bottom.Space = 0;

                    tableStyle.TableProperties.Borders.Left.BorderType = BorderStyle.Single;
                    tableStyle.TableProperties.Borders.Left.LineWidth = 1f;
                    tableStyle.TableProperties.Borders.Left.Color = borderColor;
                    tableStyle.TableProperties.Borders.Left.Space = 0;

                    tableStyle.TableProperties.Borders.Right.BorderType = BorderStyle.Single;
                    tableStyle.TableProperties.Borders.Right.LineWidth = 1f;
                    tableStyle.TableProperties.Borders.Right.Color = borderColor;
                    tableStyle.TableProperties.Borders.Right.Space = 0;

                    tableStyle.TableProperties.Borders.Horizontal.BorderType = BorderStyle.Single;
                    tableStyle.TableProperties.Borders.Horizontal.LineWidth = 1f;
                    tableStyle.TableProperties.Borders.Horizontal.Color = borderColor;
                    tableStyle.TableProperties.Borders.Horizontal.Space = 0;
                    #endregion

                    #region Conditional Formatting Properties
                    #region First Row Conditional Formatting Style
                    firstRowStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.FirstRow);

                    #region Character format
                    firstRowStyle.CharacterFormat.Bold = true;
                    firstRowStyle.CharacterFormat.BoldBidi = true;
                    firstRowStyle.CharacterFormat.TextColor = Color.FromArgb(255, 255, 255, 255);
                    #endregion

                    #region Table Cell Properties
                    firstRowStyle.CellProperties.Borders.Top.BorderType = BorderStyle.Single;
                    firstRowStyle.CellProperties.Borders.Top.LineWidth = 1f;
                    firstRowStyle.CellProperties.Borders.Top.Color = borderColor;
                    firstRowStyle.CellProperties.Borders.Top.Space = 0;

                    firstRowStyle.CellProperties.Borders.Bottom.BorderType = BorderStyle.Single;
                    firstRowStyle.CellProperties.Borders.Bottom.LineWidth = 1f;
                    firstRowStyle.CellProperties.Borders.Bottom.Color = borderColor;
                    firstRowStyle.CellProperties.Borders.Bottom.Space = 0;

                    firstRowStyle.CellProperties.Borders.Left.BorderType = BorderStyle.Single;
                    firstRowStyle.CellProperties.Borders.Left.LineWidth = 1f;
                    firstRowStyle.CellProperties.Borders.Left.Color = borderColor;
                    firstRowStyle.CellProperties.Borders.Left.Space = 0;

                    firstRowStyle.CellProperties.Borders.Right.BorderType = BorderStyle.Single;
                    firstRowStyle.CellProperties.Borders.Right.LineWidth = 1f;
                    firstRowStyle.CellProperties.Borders.Right.Color = borderColor;
                    firstRowStyle.CellProperties.Borders.Right.Space = 0;

                    firstRowStyle.CellProperties.Borders.Horizontal.BorderType = BorderStyle.Cleared;

                    firstRowStyle.CellProperties.Borders.Vertical.BorderType = BorderStyle.Cleared;

                    firstRowStyle.CellProperties.BackColor = firstRowBackColor;
                    firstRowStyle.CellProperties.ForeColor = Color.FromArgb(0, 255, 255, 255);
                    firstRowStyle.CellProperties.TextureStyle = TextureStyle.TextureNone;
                    #endregion
                    #endregion

                    #region Last Row Conditional Formatting Style
                    lastRowStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.LastRow);

                    #region Character format
                    lastRowStyle.CharacterFormat.Bold = true;
                    lastRowStyle.CharacterFormat.BoldBidi = true;
                    #endregion

                    #region Table Cell Properties
                    lastRowStyle.CellProperties.Borders.Top.BorderType = BorderStyle.Double;
                    lastRowStyle.CellProperties.Borders.Top.LineWidth = .75f;
                    lastRowStyle.CellProperties.Borders.Top.Color = borderColor;
                    lastRowStyle.CellProperties.Borders.Top.Space = 0;

                    lastRowStyle.CellProperties.Borders.Bottom.BorderType = BorderStyle.Single;
                    lastRowStyle.CellProperties.Borders.Bottom.LineWidth = 1f;
                    lastRowStyle.CellProperties.Borders.Bottom.Color = borderColor;
                    lastRowStyle.CellProperties.Borders.Bottom.Space = 0;

                    lastRowStyle.CellProperties.Borders.Left.BorderType = BorderStyle.Single;
                    lastRowStyle.CellProperties.Borders.Left.LineWidth = 1f;
                    lastRowStyle.CellProperties.Borders.Left.Color = borderColor;
                    lastRowStyle.CellProperties.Borders.Left.Space = 0;

                    lastRowStyle.CellProperties.Borders.Right.BorderType = BorderStyle.Single;
                    lastRowStyle.CellProperties.Borders.Right.LineWidth = 1f;
                    lastRowStyle.CellProperties.Borders.Right.Color = borderColor;
                    lastRowStyle.CellProperties.Borders.Right.Space = 0;

                    lastRowStyle.CellProperties.Borders.Horizontal.BorderType = BorderStyle.Cleared;

                    lastRowStyle.CellProperties.Borders.Vertical.BorderType = BorderStyle.Cleared;
                    #endregion
                    #endregion

                    #region First Column Conditional Formatting Style
                    firstColumnStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.FirstColumn);
                    #region Character format
                    firstColumnStyle.CharacterFormat.Bold = true;
                    firstColumnStyle.CharacterFormat.BoldBidi = true;
                    #endregion
                    #endregion

                    #region Last Column Conditional Formatting Style
                    lastColumnStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.LastColumn);
                    #region Character format
                    lastColumnStyle.CharacterFormat.Bold = true;
                    lastColumnStyle.CharacterFormat.BoldBidi = true;
                    #endregion
                    #endregion

                    #region Odd Column Banding Conditional Formatting Style
                    oddColumnBandingStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.OddColumnBanding);
                    #region Table Cell Properties
                    oddColumnBandingStyle.CellProperties.BackColor = backColor;
                    oddColumnBandingStyle.CellProperties.ForeColor = Color.FromArgb(0, 255, 255, 255);
                    oddColumnBandingStyle.CellProperties.TextureStyle = TextureStyle.TextureNone;
                    #endregion
                    #endregion

                    #region Odd Row Banding Conditional Formatting Style
                    oddRowBandingStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.OddRowBanding);
                    #region Table Cell Properties
                    oddRowBandingStyle.CellProperties.Borders.Horizontal.BorderType = BorderStyle.Cleared;

                    oddRowBandingStyle.CellProperties.Borders.Vertical.BorderType = BorderStyle.Cleared;

                    oddRowBandingStyle.CellProperties.BackColor = backColor;
                    oddRowBandingStyle.CellProperties.ForeColor = Color.FromArgb(0, 255, 255, 255);
                    oddRowBandingStyle.CellProperties.TextureStyle = TextureStyle.TextureNone;
                    #endregion
                    #endregion

                    #region Even Row Banding Conditional Formatting Style
                    evenRowBandingStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.EvenRowBanding);
                    #region Table Cell Properties
                    evenRowBandingStyle.CellProperties.Borders.Horizontal.BorderType = BorderStyle.Cleared;
                    evenRowBandingStyle.CellProperties.Borders.Vertical.BorderType = BorderStyle.Cleared;
                    #endregion
                    #endregion
                    #endregion
                    #endregion
                    table.ApplyStyle("Tablestyle");
                    #endregion
                    #endregion

                    #region Save Document
                    //Save as docx format
                    if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            document.Save("Table Styles.docx", FormatType.Docx);
                            //Message box confirmation to view the created document
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Table Styles.docx") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Win32Exception ex)
                                {
                                    MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Table Styles.docx" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as pdf format
                    else if (pdf.IsChecked.Value)
                    {
                        try
                        {
                            DocToPDFConverter converter = new DocToPDFConverter();
                            //Convert word document into PDF document
                            PdfDocument pdfDoc = converter.ConvertToPDF(document);
                            //Save the pdf file
                            pdfDoc.Save("Table Styles.pdf");
                            //Message box confirmation to view the created document
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Table Styles.pdf") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("PDF Viewer is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Table Styles.pdf" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
        #region Helper Methods
        /// <summary>
        /// Gets the mail merge data table.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">reader</exception>
        /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
        private MailMergeDataTable GetMailMergeDataTable()
        {
            List<Suppliers> suppliers = new List<Suppliers>();
            FileStream fs = new FileStream(@"Assets\DocIO\Suppliers.xml", FileMode.Open, FileAccess.Read);
            XmlReader reader = XmlReader.Create(fs);
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "SuppliersList")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            while (reader.LocalName != "SuppliersList")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "Suppliers":
                            suppliers.Add(GetSupplier(reader));
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "SuppliersList") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            MailMergeDataTable dataTable = new MailMergeDataTable("Suppliers", suppliers);
            reader.Dispose();
            fs.Dispose();
            return dataTable;
        }
        /// <summary>
        /// Gets the suppliers.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">reader</exception>
        /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
        private Suppliers GetSupplier(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "Suppliers")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            Suppliers supplier = new Suppliers();
            while (reader.LocalName != "Suppliers")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "SupplierID":
                            supplier.SupplierID = reader.ReadElementContentAsString();
                            break;
                        case "CompanyName":
                            supplier.CompanyName = reader.ReadElementContentAsString();
                            break;
                        case "ContactName":
                            supplier.ContactName = reader.ReadElementContentAsString();
                            break;
                        case "ContactTitle":
                            supplier.ContactTitle = reader.ReadElementContentAsString();
                            break;
                        case "Region":
                            supplier.Region = reader.ReadElementContentAsString();
                            break;
                        case "PostalCode":
                            supplier.PostalCode = reader.ReadElementContentAsString();
                            break;
                        case "Phone":
                            supplier.Phone = reader.ReadElementContentAsString();
                            break;
                        case "Fax":
                            supplier.Fax = reader.ReadElementContentAsString();
                            break;
                        case "HomePage":
                            supplier.HomePage = reader.ReadElementContentAsString();
                            break;
                        case "Address":
                            supplier.Address = reader.ReadElementContentAsString();
                            break;
                        case "City":
                            supplier.City = reader.ReadElementContentAsString();
                            break;
                        case "Country":
                            supplier.Country = reader.ReadElementContentAsString();
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Suppliers") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            return supplier;
        }
        #endregion
    }
    #region Helper Class
    public class Suppliers
    {
        #region Fields
        private string m_id;
        private string m_companyName;
        private string m_contactName;
        private string m_address;
        private string m_city;
        private string m_country;
        private string m_contactTitle;
        private string m_region;
        private string m_postalCode;
        private string m_phone;
        private string m_fax;
        private string m_homePage;
        #endregion
        #region Properties
        public string SupplierID
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public string CompanyName
        {
            get { return m_companyName; }
            set { m_companyName = value; }
        }
        public string ContactName
        {
            get { return m_contactName; }
            set { m_contactName = value; }
        }
        public string ContactTitle
        {
            get { return m_contactTitle; }
            set { m_contactTitle = value; }
        }
        public string Region
        {
            get { return m_region; }
            set { m_region = value; }
        }
        public string PostalCode
        {
            get { return m_postalCode; }
            set { m_postalCode = value; }
        }
        public string Phone
        {
            get { return m_phone; }
            set { m_phone = value; }
        }
        public string Fax
        {
            get { return m_fax; }
            set { m_fax = value; }
        }
        public string HomePage
        {
            get { return m_homePage; }
            set { m_homePage = value; }
        }
        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }
        public string City
        {
            get { return m_city; }
            set { m_city = value; }
        }
        public string Country
        {
            get { return m_country; }
            set { m_country = value; }
        }
        #endregion
        #region Constructor
        public Suppliers(string id, string companyName, string contantName, string address, string city, string country)
        {
            m_id = id;
            m_companyName = companyName;
            m_contactName = contantName;
            m_address = address;
            m_city = city;
            m_country = country;
        }
        public Suppliers()
        { }
        #endregion
    }
    #endregion
}
