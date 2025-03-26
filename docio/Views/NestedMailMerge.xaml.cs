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
using System.Collections.Generic;
using System.Windows;
using Syncfusion.DocIO.DLS;
using System.Collections;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Data;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NestedMailMerge : DemoControl
    {
        # region Private Members
        string filePath;
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public NestedMailMerge()
        {
            InitializeComponent();
            filePath = @"Assets\DocIO\";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            filePath = null;
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Creates document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WordDocument doc = new WordDocument())
                {
                    //Executes mailmerge and creates document in report format
                    #region Load template
                    if (this.radioButtonReport.IsChecked.Value)
                        //Open existing template
                        doc.Open(filePath + "Template_Report.doc", FormatType.Doc);
                    else
                        doc.Open(filePath + "Template_Letter.doc", FormatType.Doc);
                    #endregion

                    #region Execute Mail merge
                    if (radioButtonExplicit.IsChecked.Value)
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(filePath + "Employees.xml");
                        ArrayList commands = new ArrayList();

                        //DictionaryEntry contain "Source table" (KEY) and "Command" (VALUE)
                        DictionaryEntry entry = new DictionaryEntry("Employees", string.Empty);
                        commands.Add(entry);

                        // To retrive customer details
                        DataTable table = ds.Tables["Customers"];
                        string relation = table.ParentRelations[0].ChildColumns[0].ColumnName + " = %Employees." + table.ParentRelations[0].ParentColumns[0].ColumnName + "%";
                        entry = new DictionaryEntry("Customers", relation);
                        commands.Add(entry);

                        // To retrieve order details
                        table = ds.Tables["Orders"];
                        relation = table.ParentRelations[0].ChildColumns[0].ColumnName + " = %Customers." + table.ParentRelations[0].ParentColumns[0].ColumnName + "%";
                        entry = new DictionaryEntry("Orders", relation);
                        commands.Add(entry);

                        //Execute Nested Mail Merge using explicit relational data
                        doc.MailMerge.ExecuteNestedGroup(ds, commands);
                    }
                    else
                    {
                        MailMergeDataTable dataTable = GetMailMergeDataTable();
                        //Execute Nested Mail Merge using implicit relational data
                        doc.MailMerge.ExecuteNestedGroup(dataTable);
                    }
                    #endregion

                    #region Save the document
                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            doc.Save("Nested Mail Merge.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Nested Mail Merge.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Nested Mail Merge.doc" + ") then try generating the document.", "File is already open",
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
                            doc.Save("Nested Mail Merge.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Nested Mail Merge.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Nested Mail Merge.doc" + ") then try generating the document.", "File is already open",
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
                            PdfDocument pdfDoc = converter.ConvertToPDF(doc);
                            //Save the pdf file
                            pdfDoc.Save("Nested Mail Merge.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Nested Mail Merge.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Nested Mail Merge.doc" + ") then try generating the document.", "File is already open",
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
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to view the template document?", "Template document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                if (radioButtonLetter.IsChecked.Value)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(filePath + "Template_Letter.doc") { UseShellExecute = true };
                    process.Start();
                }
                else if (radioButtonReport.IsChecked.Value)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(filePath + "Template_Report.doc") { UseShellExecute = true };
                    process.Start();
                }
            }
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Gets Explicit Employee collection(entitites are nested)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private MailMergeDataTable GetMailMergeDataTable()
        {
            List<EmployeeDetailsImplicit> employees = new List<EmployeeDetailsImplicit>();
            FileStream fs = new FileStream(filePath + "Employees.xml", FileMode.Open, FileAccess.Read);

            XmlReader reader = XmlReader.Create(fs);

            if (reader == null)
                throw new Exception("reader");

            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();

            if (reader.LocalName != "EmployeesList")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);

            reader.Read();

            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();

            while (reader.LocalName != "EmployeesList")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "Employees":
                            employees.Add(GetEmployee(reader));
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "EmployeesList") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            MailMergeDataTable dataTable = new MailMergeDataTable("Employees", employees);
            reader.Close();
            fs.Dispose();
            return dataTable;
        }
        /// <summary>
        /// Gets the order details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">reader</exception>
        /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
        private EmployeeDetailsImplicit GetEmployee(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");

            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();

            if (reader.LocalName != "Employees")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);

            reader.Read();

            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();

            EmployeeDetailsImplicit employee = new EmployeeDetailsImplicit();
            while (reader.LocalName != "Employees")
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
                        case "Address":
                            employee.Address = reader.ReadElementContentAsString();
                            break;
                        case "City":
                            employee.City = reader.ReadElementContentAsString();
                            break;
                        case "Country":
                            employee.Country = reader.ReadElementContentAsString();
                            break;
                        case "Extension":
                            employee.Extension = reader.ReadElementContentAsString();
                            break;
                        case "Customers":
                            employee.Customers.Add(GetCustomer(reader));
                            break;
                        default:
                            reader.Skip();
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
            return employee;
        }
        /// <summary>
        /// Gets the customer details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">reader</exception>
        /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
        private CustomerDetailsImplicit GetCustomer(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");

            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();

            if (reader.LocalName != "Customers")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);

            reader.Read();

            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            CustomerDetailsImplicit customer = new CustomerDetailsImplicit();

            while (reader.LocalName != "Customers")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "CustomerID":
                            customer.CustomerID = reader.ReadElementContentAsString();
                            break;
                        case "EmployeeID":
                            customer.EmployeeID = reader.ReadElementContentAsString();
                            break;
                        case "CompanyName":
                            customer.CompanyName = reader.ReadElementContentAsString();
                            break;
                        case "ContactName":
                            customer.ContactName = reader.ReadElementContentAsString();
                            break;
                        case "City":
                            customer.City = reader.ReadElementContentAsString();
                            break;
                        case "Country":
                            customer.Country = reader.ReadElementContentAsString();
                            break;
                        case "Orders":
                            customer.Orders.Add(GetOrders(reader));
                            break;
                    }
                    reader.Read();
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Customers") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            return customer;
        }
        /// <summary>
        /// Gets the order details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">reader</exception>
        /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
        private OrderDetails GetOrders(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");

            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();

            if (reader.LocalName != "Orders")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);

            reader.Read();

            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            OrderDetails order = new OrderDetails();

            while (reader.LocalName != "Orders")
            {
                if (reader.NodeType != XmlNodeType.EndElement)
                {
                    switch (reader.LocalName)
                    {
                        case "OrderID":
                            order.OrderID = reader.ReadElementContentAsString();
                            break;
                        case "CustomerID":
                            order.CustomerID = reader.ReadElementContentAsString();
                            break;
                        case "OrderDate":
                            order.OrderDate = reader.ReadElementContentAsString();
                            break;
                        case "RequiredDate":
                            order.RequiredDate = reader.ReadElementContentAsString();
                            break;
                        case "ShippedDate":
                            order.ShippedDate = reader.ReadElementContentAsString();
                            break;
                    }
                    reader.Read();
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Orders") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            return order;
        }
        #endregion
    }

    #region Mailmerge data objects
    class EmployeeDetailsImplicit
    {
        #region Feilds
        private string m_employeeID;
        private string m_lastName;
        private string m_firstName;
        private string m_address;
        private string m_city;
        private string m_country;
        private string m_extension;
        private List<CustomerDetailsImplicit> m_customers;
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
        public string Extension
        {
            get { return m_extension; }
            set { m_extension = value; }
        }
        public List<CustomerDetailsImplicit> Customers
        {
            get
            {
                if (m_customers == null)
                    m_customers = new List<CustomerDetailsImplicit>();
                return m_customers;
            }
            set
            {
                m_customers = value;
            }
        }
        #endregion

        #region constructor
        public EmployeeDetailsImplicit()
        {
            m_customers = new List<CustomerDetailsImplicit>();
        }
        #endregion
    }
    class CustomerDetailsImplicit
    {
        #region Feilds
        private string m_customerID;
        private string m_employeeID;
        private string m_companyName;
        private string m_contactName;
        private string m_city;
        private string m_country;
        private List<OrderDetails> m_orders;
        #endregion

        #region Properties
        public List<OrderDetails> Orders
        {
            get
            {
                if (m_orders == null)
                    m_orders = new List<OrderDetails>();
                return m_orders;
            }
            set
            {
                m_orders = value;
            }
        }
        public string CustomerID
        {
            get { return m_customerID; }
            set { m_customerID = value; }
        }
        public string EmployeeID
        {
            get { return m_employeeID; }
            set { m_employeeID = value; }
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
        public CustomerDetailsImplicit()
        {
            m_orders = new List<OrderDetails>();
        }
        #endregion
    }
    internal class OrderDetails
    {
        #region Feilds
        private string m_orderID;
        private string m_customerID;
        private string m_orderDate;
        private string m_requiredDate;
        private string m_shippedDate;
        #endregion

        #region Properties
        public string OrderID
        {
            get { return m_orderID; }
            set { m_orderID = value; }
        }
        public string CustomerID
        {
            get { return m_customerID; }
            set { m_customerID = value; }
        }
        public string OrderDate
        {
            get { return m_orderDate; }
            set { m_orderDate = value; }
        }
        public string RequiredDate
        {
            get { return m_requiredDate; }
            set { m_requiredDate = value; }
        }
        public string ShippedDate
        {
            get { return m_shippedDate; }
            set { m_shippedDate = value; }
        }
        #endregion
    }
    #endregion
}
