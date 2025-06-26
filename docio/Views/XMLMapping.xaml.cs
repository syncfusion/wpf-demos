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
using syncfusion.demoscommon.wpf;
using System.ComponentModel;
using System.IO;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class XMLMapping : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public XMLMapping()
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
            try
            {
                // Get XML file path.
                string dataPath = @"Assets\DocIO\";

                // Create a new document.
                using (WordDocument document = new WordDocument())
                {

                    //Add a section & a paragraph in the empty document.
                    document.EnsureMinimal();

                    //Loads XML file into the customXML part of the Word document.
                    CustomXMLPart docIOxmlPart = new CustomXMLPart(document);
                    docIOxmlPart.Load(System.IO.Path.Combine(dataPath, "Employees.xml"));

                    //Insert content controls and maps Employees details to it.
                    InsertAndMapEmployees(document, "EmployeesList", docIOxmlPart);

                    try
                    {
                        //Saving the document as .docx
                        document.Save("XML Mapping.docx", FormatType.Docx);

                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("XML Mapping.docx") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\XML Mapping.docx" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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
        /// Insert and Maps CustomXMLPart to content control based on XPath.
        /// </summary>
        /// <param name="paragraph">Paragraph instance to append content control.</param>
        /// <param name="XPath">XPath of the CustomXMLNode to be mapped</param>
        /// <param name="custXMLPart">CustomXMLPart of the CustomXMLNode</param>
        private void MapCustomXMLPart(IWParagraph paragraph, string XPath, CustomXMLPart custXMLPart)
        {
            IInlineContentControl contentControl = paragraph.AppendInlineContentControl(ContentControlType.Text);
            contentControl.ContentControlProperties.XmlMapping.SetMapping(XPath, string.Empty, custXMLPart);
        }
        /// <summary>
        /// Inserts content control and maps the employees details to it. 
        /// </summary>
        /// <param name="document">Word document instance.</param>
        /// <param name="xmlRootPath">Custom XML root Xpath.</param>
        /// <param name="docIOxmlPart">CustomXMLPart instance.</param>
        private void InsertAndMapEmployees(WordDocument document, string xmlRootPath, CustomXMLPart docIOxmlPart)
        {
            //Retrieving CustomXMLNode from xmlRootPath.
            CustomXMLNode parentNode = docIOxmlPart.SelectSingleNode(xmlRootPath);

            int empIndex = 1;
            foreach (CustomXMLNode employeeNode in parentNode.ChildNodes)
            {
                if (employeeNode.HasChildNodes())
                {
                    //Adds new paragraph to the section
                    IWParagraph paragraph = document.LastSection.AddParagraph();
                    paragraph.ParagraphFormat.BackColor = System.Drawing.Color.Gray;

                    IWTextRange textrange = paragraph.AppendText("Employee");
                    textrange.CharacterFormat.TextColor = System.Drawing.Color.White;
                    textrange.CharacterFormat.Bold = true;
                    textrange.CharacterFormat.FontSize = 14;

                    //Insert content controls and maps Employee details to it.
                    InsertAndMapEmployee(document, employeeNode, xmlRootPath, docIOxmlPart, empIndex);
                }
                empIndex++;
            }
        }
        /// <summary>
        /// Inserts content control and maps the employee details to it.
        /// </summary>
        /// <param name="document">Word document instance.</param>
        /// <param name="employeesNode">CustomXMLNode of employee.</param>
        /// <param name="rootXmlPath">Custom XML root Xpath.</param>
        /// <param name="docIOxmlPart">CustomXMLPart instance.</param>
        /// <param name="empIndex">Current employee index.</param>
        private void InsertAndMapEmployee(WordDocument document, CustomXMLNode employeesNode, string rootXmlPath, CustomXMLPart docIOxmlPart, int empIndex)
        {
            //Column names of Employee element.
            string[] employeesDetails = { "FirstName", "LastName", "Employee ID", "Extension", "Address", "City", "Country" };
            int empChildIndex = 0;
            int customerIndex = 1;

            // Append current empolyee XPath with root XPath.
            string empPath = "/" + rootXmlPath + "/Employees[" + empIndex + "]/";
            // Iterating child elements of Employee
            foreach (CustomXMLNode employeeChild in employeesNode.ChildNodes)
            {
                IWParagraph paragraph = document.LastParagraph;
                if (employeeChild.HasChildNodes())
                {
                    //Insert a content controls and maps Customer details to it.
                    InsertAndMapCustomer(document, employeeChild, docIOxmlPart, empPath, customerIndex);
                    customerIndex++;
                }
                else
                {
                    if (empChildIndex != 1)
                    {
                        //Insert a content controls and maps Employee details other than Customer details to it.
                        paragraph = document.LastSection.AddParagraph();
                        if (empChildIndex == 0)
                            paragraph.AppendText("Name:");
                        else
                            paragraph.AppendText(employeesDetails[empChildIndex] + ": ");
                    }
                    else
                        paragraph.AppendText(" ");
                    MapCustomXMLPart(paragraph, empPath + employeesDetails[empChildIndex].Replace(" ", ""), docIOxmlPart);
                }
                empChildIndex++;
            }
        }
        /// <summary>
        /// Insert a content controls and maps Customer details to it.
        /// </summary>
        /// <param name="document">Word document instance.</param>
        /// <param name="customerNode">CustomXMLNode of customer.</param>
        /// <param name="docIOxmlPart">CustomXMLPart instance.</param>
        /// <param name="empPath">Current employee index.</param>
        /// <param name="custIndex">Current customer index.</param>
        private void InsertAndMapCustomer(WordDocument document, CustomXMLNode customerNode, CustomXMLPart docIOxmlPart, string empPath, int custIndex)
        {
            //Column names of Customer element.
            string[] customersDetails = { "Customer ID", "Employee ID", "Company Name", "Contact Name", "City", "Country" };

            document.LastSection.AddParagraph();

            //Adds new paragraph to the section
            IWParagraph paragraph = document.LastSection.AddParagraph();
            paragraph.ParagraphFormat.BackColor = System.Drawing.Color.Green;
            paragraph.ParagraphFormat.LeftIndent = 72;

            IWTextRange textrange = paragraph.AppendText("Customers");
            textrange.CharacterFormat.TextColor = System.Drawing.Color.White;
            textrange.CharacterFormat.Bold = true;
            textrange.CharacterFormat.FontSize = 14;

            int orderIndex = 1;
            int custChild = 0;
            bool isFirstOrder = true;
            string customerXpath = empPath + "Customers[" + custIndex + "]/";
            foreach (CustomXMLNode customerChild in customerNode.ChildNodes)
            {
                if (customerChild.HasChildNodes())
                {
                    //Insert a content controls and maps Orders details to it.
                    InsertAndMapOrders(document, customerChild, docIOxmlPart, customerXpath, orderIndex, isFirstOrder);
                    document.LastSection.AddParagraph();
                    isFirstOrder = false;
                    orderIndex++;
                }
                else
                {
                    //Insert a content controls and maps Customer details other than Order details to it.
                    paragraph = document.LastSection.AddParagraph();
                    paragraph.ParagraphFormat.LeftIndent = 72;

                    paragraph.AppendText(customersDetails[custChild] + ": ");
                    MapCustomXMLPart(paragraph, customerXpath + customersDetails[custChild].Replace(" ", ""), docIOxmlPart);
                }
                custChild++;
            }
        }
        /// <summary>
        /// Insert a content controls and maps Orders details to it.
        /// </summary>
        /// <param name="document">Word document instance.</param>
        /// <param name="orderNode">CustomXMLNode of order.</param>
        /// <param name="docIOxmlPart">CustomXMLPart instance.</param>
        /// <param name="custPath">Current customer index</param>
        /// <param name="orderIndex">Current order index</param>
        /// <param name="isFirst">Indicates whether it is the first order of the customer.</param>
        private void InsertAndMapOrders(WordDocument document, CustomXMLNode orderNode, CustomXMLPart docIOxmlPart, string custPath, int orderIndex, bool isFirst)
        {
            //Column names of order element.
            string[] ordersDetails = { "Order ID", "Customer ID", "Order Date", "Shipped Date", "Required Date" };

            IWParagraph paragraph = null;
            IWTextRange textrange = null;
            if (isFirst)
            {
                document.LastSection.AddParagraph();
                //Adds new paragraph to the section
                paragraph = document.LastSection.AddParagraph();
                paragraph.ParagraphFormat.BackColor = System.Drawing.Color.Red;
                paragraph.ParagraphFormat.LeftIndent = 128;

                textrange = paragraph.AppendText("Orders");
                textrange.CharacterFormat.TextColor = System.Drawing.Color.White;
                textrange.CharacterFormat.Bold = true;
                textrange.CharacterFormat.FontSize = 14;
            }
            int orderChildIndex = 0;
            string customerXpath = custPath + "Orders[" + orderIndex + "]/";
            foreach (CustomXMLNode orderChild in orderNode.ChildNodes)
            {
                //Adds new paragraph to the section
                paragraph = document.LastSection.AddParagraph();
                paragraph.ParagraphFormat.LeftIndent = 128;

                paragraph.AppendText(ordersDetails[orderChildIndex] + ": ");
                MapCustomXMLPart(paragraph, customerXpath + "/" + ordersDetails[orderChildIndex].Replace(" ", ""), docIOxmlPart);
                orderChildIndex++;
            }
        }
        #endregion
    }
}