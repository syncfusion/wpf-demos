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
using System.Data;
using Syncfusion.DocIO;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;
using System.Xml;
using System.Collections.Generic;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EmployeeReport : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public EmployeeReport()
        {
            InitializeComponent();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Creates word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get Template document and database path.
            string dataPath = @"Assets\DocIO\";

            try
            {
                // Creating a new document.
                using (WordDocument document = new WordDocument())
                {
                    string inputFile = dataPath + @"\EmployeesReportDemo.doc";
                    // Load template
                    document.Open(inputFile, FormatType.Doc);
                    document.MailMerge.MergeImageField += new MergeImageFieldEventHandler(MergeField_EmployeeImage);
                    //Create MailMergeDataTable
                    MailMergeDataTable mailMergeDataTable = GetMailMergeDataTableEmployee();
                    // Execute Mail Merge with groups. 
                    document.MailMerge.ExecuteGroup(mailMergeDataTable);
                    #region Save Document
                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("Employee Report.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Employee Report.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Employee Report.doc" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as docx format
                    else if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            document.Save("Employee Report.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Employee Report.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Employee Report.doc" + ") then try generating the document.", "File is already open",
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
                            pdfDoc.Save("Employee Report.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Employee Report.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Employee Report.doc" + ") then try generating the document.", "File is already open",
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
                // Shows the Message box with Exception message, if an exception throws.
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            //Message box confirmation to view the created document.
            if (MessageBox.Show("Do you want to view the template document?", "Template Document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\DocIO\EmployeesReportDemo.doc") { UseShellExecute = true };
                process.Start();
            }
        }
        private void MergeField_EmployeeImage(object sender, MergeImageFieldEventArgs args)
        {
            // Get the image from disk during Merge.
            if (args.FieldName == "Photo")
            {
                string ProductFileName = args.FieldValue.ToString();
                byte[] bytes = Convert.FromBase64String(ProductFileName);
                MemoryStream ms = new MemoryStream(bytes);
                args.ImageStream = ms;
            }
        }
#endregion
#region Helper Methods
        /// <summary>
        /// Gets the mail merge data table.
        /// </summary>        
        private MailMergeDataTable GetMailMergeDataTableEmployee()
        {
            List<Employees> employees = new List<Employees>();
            FileStream fs = new FileStream(@"Assets\DocIO\EmployeesList.xml", FileMode.Open, FileAccess.Read);
            XmlReader reader = XmlReader.Create(fs);
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "Employees")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            while (reader.LocalName != "Employees")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "Employee":
                            employees.Add(GetEmployees(reader));
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Employees") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            MailMergeDataTable dataTable = new MailMergeDataTable("Employees", employees);
            reader.Dispose();
            fs.Dispose();
            return dataTable;
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <param name="reader">The reader.</param>        
        private Employees GetEmployees(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "Employee")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            Employees employee = new Employees();
            while (reader.LocalName != "Employee")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "EmployeeID":
                            employee.EmployeeID = reader.ReadElementContentAsString();
                            break;
                        case "LastName":
                            employee.LastName = reader.ReadElementContentAsString();
                            break;
                        case "FirstName":
                            employee.FirstName = reader.ReadElementContentAsString();
                            break;
                        case "Title":
                            employee.Title = reader.ReadElementContentAsString();
                            break;
                        case "TitleOfCourtesy":
                            employee.TitleOfCourtesy = reader.ReadElementContentAsString();
                            break;
                        case "BirthDate":
                            employee.BirthDate = reader.ReadElementContentAsString();
                            break;
                        case "HireDate":
                            employee.HireDate = reader.ReadElementContentAsString();
                            break;
                        case "Address":
                            employee.Address = reader.ReadElementContentAsString();
                            break;
                        case "City":
                            employee.City = reader.ReadElementContentAsString();
                            break;
                        case "Region":
                            employee.Region = reader.ReadElementContentAsString();
                            break;
                        case "PostalCode":
                            employee.PostalCode = reader.ReadElementContentAsString();
                            break;
                        case "Country":
                            employee.Country = reader.ReadElementContentAsString();
                            break;
                        case "HomePhone":
                            employee.HomePhone = reader.ReadElementContentAsString();
                            break;
                        case "Extension":
                            employee.Extension = reader.ReadElementContentAsString();
                            break;
                        case "Photo":
                            employee.Photo = reader.ReadElementContentAsString();
                            break;
                        case "Notes":
                            employee.Notes = reader.ReadElementContentAsString();
                            break;
                        case "ReportsTo":
                            employee.ReportsTo = reader.ReadElementContentAsString();
                            break;

                        default:
                            reader.Skip();
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Employee") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            return employee;
        }
#endregion
    }
#region Helper Classes
    public class Employees
    {
#region Fields
        private string m_employeeID;
        private string m_lastName;
        private string m_firstName;
        private string m_title;
        private string m_titleOfCourtesy;
        private string m_birthDate;
        private string m_hireDate;
        private string m_address;
        private string m_city;
        private string m_region;
        private string m_postalCode;
        private string m_country;
        private string m_homePhone;
        private string m_extension;
        private string m_photo;
        private string m_notes;
        private string m_reportsTo;
#endregion
#region Properties
        public string EmployeeID
        {
            get { return m_employeeID; }
            set { m_employeeID = value; }
        }
        public string LastName
        {
            get { return m_lastName; }
            set { m_lastName = value; }
        }
        public string FirstName
        {
            get { return m_firstName; }
            set { m_firstName = value; }
        }
        public string Title
        {
            get { return m_title; }
            set { m_title = value; }
        }
        public string TitleOfCourtesy
        {
            get { return m_titleOfCourtesy; }
            set { m_titleOfCourtesy = value; }
        }
        public string BirthDate
        {
            get { return m_birthDate; }
            set { m_birthDate = value; }
        }
        public string HireDate
        {
            get { return m_hireDate; }
            set { m_hireDate = value; }
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
        public string Country
        {
            get { return m_country; }
            set { m_country = value; }
        }
        public string HomePhone
        {
            get { return m_homePhone; }
            set { m_homePhone = value; }
        }
        public string Extension
        {
            get { return m_extension; }
            set { m_extension = value; }
        }
        public string Photo
        {
            get { return m_photo; }
            set { m_photo = value; }
        }
        public string Notes
        {
            get { return m_notes; }
            set { m_notes = value; }
        }
        public string ReportsTo
        {
            get { return m_reportsTo; }
            set { m_reportsTo = value; }
        }


#endregion
#region Constructor
        public Employees(string employeeID, string lastName, string firstName, string title, string titleOfCourtesy, string birthDate, string hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string photo, string notes, string reportsTo)
        {
            m_employeeID = employeeID;
            m_lastName = lastName;
            m_firstName = firstName;
            m_title = title;
            m_titleOfCourtesy = titleOfCourtesy;
            m_birthDate = birthDate;
            m_hireDate = hireDate;
            m_address = address;
            m_city = city;
            m_region = region;
            m_postalCode = postalCode;
            m_country = country;
            m_homePhone = homePhone;
            m_extension = extension;
            m_photo = photo;
            m_notes = notes;
            m_reportsTo = reportsTo;

        }
        public Employees()
        { }
#endregion
    }
#endregion
}