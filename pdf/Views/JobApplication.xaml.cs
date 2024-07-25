#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;

using System.Drawing;
using Syncfusion.Pdf.Graphics;
using System.Diagnostics;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.IO;
using System.Windows.Resources;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class JobApplication : DemoControl
    {
        public JobApplication()
        {
            InitializeComponent();
        }
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion
        PdfDocument pdfDoc;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a new documenFt class object.
            pdfDoc = new PdfDocument();
            pdfDoc.ViewerPreferences.HideMenubar = true;
            pdfDoc.ViewerPreferences.HideWindowUI = true;
            pdfDoc.ViewerPreferences.HideToolbar = true;
            pdfDoc.ViewerPreferences.FitWindow = true;

            pdfDoc.ViewerPreferences.PageLayout = PdfPageLayout.SinglePage;
            pdfDoc.PageSettings.Orientation = PdfPageOrientation.Portrait;
            pdfDoc.PageSettings.Margins.All = 0;

            //To set coordinates to draw form fields
            RectangleF bounds = new RectangleF(180, 65, 156, 15);
            PdfUnitConvertor con = new PdfUnitConvertor();

            PdfImage img = new PdfBitmap(GetFileStream("Careers.png"));


            //Set the page size
            SizeF pageSize = new SizeF(500, 310);
            pdfDoc.PageSettings.Height = pageSize.Height;
            pdfDoc.PageSettings.Width = pageSize.Width;

            Font f = new Font("Calibri", 12f, System.Drawing.FontStyle.Bold);
            PdfFont pdfFont = new PdfTrueTypeFont(f);

            #region First Page
            pdfDoc.Pages.Add();

            PdfPage firstPage = pdfDoc.Pages[0];
            pdfDoc.Pages[0].Graphics.DrawImage(img, 0, 0, pageSize.Width, pageSize.Height);
            pdfDoc.Pages[0].Graphics.DrawString("General Information", pdfFont, new PdfSolidBrush(new PdfColor(213, 123, 19)), 25, 40);
            pdfDoc.Pages[0].Graphics.DrawString("Education Grade", pdfFont, new PdfSolidBrush(new PdfColor(213, 123, 19)), 25, 190);

            f = new Font("Calibri", 10f);
            pdfFont = new PdfTrueTypeFont(f);
            //Create fields in first page.
            pdfDoc.Pages[0].Graphics.DrawString("First Name:", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 65);

            //Create text box for firstname.
            CreateTextBox(pdfDoc.Pages[0], "FirstName", "First Name", f, bounds);

            pdfFont = new PdfTrueTypeFont(f);
            pdfDoc.Pages[0].Graphics.DrawString("Last Name:", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 83);

            //Set position to draw form fields
            bounds.Y = bounds.Y + 18;
            //Create text box for lastname.
            CreateTextBox(pdfDoc.Pages[0], "LastName", "Last Name", f, bounds);

            pdfFont = new PdfTrueTypeFont(f);
            pdfDoc.Pages[0].Graphics.DrawString("Email:", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 103);

            //Set position to draw form fields
            bounds.Y = bounds.Y + 18;

            //Create text box for Email.
            CreateTextBox(pdfDoc.Pages[0], "Email", "Email id", f, bounds);

            pdfFont = new PdfTrueTypeFont(f);
            pdfDoc.Pages[0].Graphics.DrawString("Business Phone:", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 123);

            //Set position to draw form fields
            bounds.Y = bounds.Y + 18;

            //Create text box for Business phone.
            CreateTextBox(pdfDoc.Pages[0], "Business", "Business phone", f, bounds);

            pdfFont = new PdfTrueTypeFont(f);
            pdfDoc.Pages[0].Graphics.DrawString("Which position are\nyou applying for?", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 143);

            //Create combo box for Position.
            #region Create ComboBox
            //Set position to draw Combo Box
            bounds.Y = bounds.Y + 24;

            PdfComboBoxField comboBox = new PdfComboBoxField(pdfDoc.Pages[0], "JobTitle");
            comboBox.Bounds = bounds;
            comboBox.BorderWidth = 1;
            comboBox.BorderColor = new PdfColor(System.Drawing.Color.Gray);

            pdfFont = new PdfTrueTypeFont(f);
            comboBox.Font = pdfFont;
            comboBox.ToolTip = "Job Title";


            comboBox.Items.Add(new PdfListFieldItem("Development", "accounts"));
            comboBox.Items.Add(new PdfListFieldItem("Support", "advertise"));
            comboBox.Items.Add(new PdfListFieldItem("Documentation", "agri"));

            pdfDoc.Form.Fields.Add(comboBox);
            #endregion

            pdfDoc.Pages[0].Graphics.DrawString("Highest qualification", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 217);

            //Create Checkbox box.
            #region Create CheckBox

            f = new Font("Calibri", 8f);
            pdfFont = new PdfTrueTypeFont(f); ;
            //Set position to draw Checkbox
            bounds.Y = 239;
            bounds.X = 25;
            bounds.Width = 10;

            bounds.Height = 10;

            // Create a Check Box
            PdfCheckBoxField chb = new PdfCheckBoxField(pdfDoc.Pages[0], "Adegree");

            chb.Font = pdfFont;
            chb.ToolTip = "degree";
            chb.Bounds = bounds;
            chb.BorderColor = new PdfColor(System.Drawing.Color.Gray);
            bounds.X += chb.Bounds.Height + 10;

            pdfDoc.Pages[0].Graphics.DrawString("Associate degree", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), bounds.X, bounds.Y);
            bounds.X += 90;
            pdfDoc.Form.Fields.Add(chb);
            //Create a Checkbox
            chb = new PdfCheckBoxField(pdfDoc.Pages[0], "Bdegree");
            chb.Font = pdfFont;
            chb.Bounds = bounds;
            chb.BorderColor = new PdfColor(System.Drawing.Color.Gray);
            bounds.X += chb.Bounds.Height + 10;

            pdfDoc.Pages[0].Graphics.DrawString("Bachelor degree", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), bounds.X, bounds.Y);

            bounds.X += 90;
            pdfDoc.Form.Fields.Add(chb);
            //Create a Checkbox
            chb = new PdfCheckBoxField(pdfDoc.Pages[0], "college");

            chb.Font = pdfFont;
            chb.ToolTip = "college";
            chb.Bounds = bounds;
            chb.BorderColor = new PdfColor(System.Drawing.Color.Gray);

            bounds.X += chb.Bounds.Height + 10;

            pdfDoc.Pages[0].Graphics.DrawString("College", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), bounds.X, bounds.Y);

            bounds.Y += 20;
            bounds.X = 25;
            pdfDoc.Form.Fields.Add(chb);
            //Create a Checkbox
            chb = new PdfCheckBoxField(pdfDoc.Pages[0], "pg");

            chb.Font = pdfFont;
            chb.Bounds = bounds;
            chb.BorderColor = new PdfColor(System.Drawing.Color.Gray);
            bounds.X += chb.Bounds.Height + 10;

            pdfDoc.Pages[0].Graphics.DrawString("Post Graduate", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), bounds.X, bounds.Y);

            bounds.X += 90;
            pdfDoc.Form.Fields.Add(chb);
            //Create a Checkbox
            chb = new PdfCheckBoxField(pdfDoc.Pages[0], "mba");

            chb.Font = pdfFont;
            chb.Bounds = bounds;
            chb.BorderColor = new PdfColor(System.Drawing.Color.Gray);

            bounds.X += chb.Bounds.Height + 10;

            pdfDoc.Pages[0].Graphics.DrawString("MBA", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), bounds.X, bounds.Y);

            pdfDoc.Form.Fields.Add(chb);
            #endregion

            # region Create Button
            PdfButtonField submitButton = new PdfButtonField(pdfDoc.Pages[0], "Next");
            submitButton.Bounds = new RectangleF(pdfDoc.Pages[0].GetClientSize().Width - 20, pdfDoc.Pages[0].GetClientSize().Height - 25, 20, 20);
            submitButton.Font = pdfFont;
            submitButton.ToolTip = "Next";

            PdfPage page = pdfDoc.Pages.Add();
            PdfDestination dest = new PdfDestination(page, new System.Drawing.Point(0, 100));
            PdfGoToAction goToAction = new PdfGoToAction(page);
            goToAction.Destination = dest;
            submitButton.Actions.GotFocus = goToAction;
            # endregion

            # endregion

            # region Second Page
            //Create second page.		
            pdfDoc.Pages.Add();

            img = new PdfBitmap(GetFileStream("Careers.png"));

            pdfDoc.Pages[1].Graphics.DrawImage(img, new System.Drawing.PointF(0, 0), new SizeF(pageSize.Width, pageSize.Height));

            pdfDoc.Pages[1].Graphics.DrawString("Current position", new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Bold), new PdfSolidBrush(new PdfColor(213, 123, 19)), 25, 40);

            bounds.X = 25; bounds.Y = 65;
            chb = new PdfCheckBoxField(pdfDoc.Pages[1], "Cemp");
            chb.Font = pdfFont;
            chb.Bounds = bounds;
            chb.BorderWidth = 1;
            chb.BorderColor = new PdfColor(System.Drawing.Color.Gray);
            bounds.X += chb.Bounds.Height + 10;

            pdfDoc.Pages[1].Graphics.DrawString("I am not currently employed", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), bounds.X, bounds.Y);

            bounds.X += 90;
            pdfDoc.Form.Fields.Add(chb);
            pdfFont = new PdfTrueTypeFont(f);

            //Add fileds in second page
            pdfDoc.Pages[1].Graphics.DrawString("Job Title", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 85);

            bounds.X = 175;
            bounds.Y = 85;
            bounds.Width = 150;
            bounds.Height = 16;

            CreateTextBox(pdfDoc.Pages[1], "Jtitle", "Job title", f, bounds);
            pdfDoc.Pages[1].Graphics.DrawString("Employer:", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 103);

            //Set position to draw form fields
            bounds.Y = bounds.Y + 18;
            CreateTextBox(pdfDoc.Pages[1], "Employer", "Employer", f, bounds);
            pdfDoc.Pages[1].Graphics.DrawString("Reason for leaving:", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 123);

            //Set position to draw form fields
            bounds.Y = bounds.Y + 18;
            CreateTextBox(pdfDoc.Pages[1], "Reason", "Reason for leaving", f, bounds);
            pdfDoc.Pages[1].Graphics.DrawString("Total Annual salary:", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 143);

            //Set position to draw form fields
            bounds.Y = bounds.Y + 18;
            CreateTextBox(pdfDoc.Pages[1], "Asalary", "Annual salary", f, bounds);

            pdfDoc.Pages[1].Graphics.DrawString("Duties:", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 168);
            bounds.Y = bounds.Y + 50;
            bounds.X = 25;
            bounds.Height = bounds.Height * 4;
            CreateTextBox(pdfDoc.Pages[1], "Duties", "Duties", f, bounds);
            pdfDoc.Pages[1].Graphics.DrawString("Employment type:", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 268);

            #region Create ComboBox

            //Set position to draw Combo Box
            bounds.Y = bounds.Y + 74;
            bounds.Height = 20;
            bounds.X = 175;

            //Create a combo Box
            comboBox = new PdfComboBoxField(pdfDoc.Pages[1], "EmpType");
            comboBox.Bounds = bounds;

            comboBox.BorderColor = new PdfColor(System.Drawing.Color.Gray);
            pdfFont = new PdfTrueTypeFont(f);
            comboBox.Font = pdfFont;
            comboBox.ToolTip = "Employment type";

            comboBox.Items.Add(new PdfListFieldItem("Full time", "ft"));
            comboBox.Items.Add(new PdfListFieldItem("Part time", "pt"));

            pdfDoc.Form.Fields.Add(comboBox);
            #endregion

            # endregion

            # region Third Page
            //Create submit button for next page navigation.
            submitButton = new PdfButtonField(pdfDoc.Pages[1], "Apply");
            submitButton.Bounds = new RectangleF(pdfDoc.Pages[1].GetClientSize().Width - 20, pdfDoc.Pages[1].GetClientSize().Height - 25, 20, 20);
            submitButton.Font = pdfFont;
            submitButton.BorderStyle = PdfBorderStyle.Beveled;

            page = pdfDoc.Pages[2];
            dest = new PdfDestination(page, new System.Drawing.Point(0, 100));
            goToAction = new PdfGoToAction(page);
            goToAction.Destination = dest;
            submitButton.Actions.GotFocus = goToAction;


            img = new PdfBitmap(GetFileStream("Careers.png"));

            pdfDoc.Pages[2].Graphics.DrawImage(img, 0, 0, pageSize.Width, pageSize.Height);

            f = new Font("Calibri", 12f, System.Drawing.FontStyle.Bold);
            pdfFont = new PdfTrueTypeFont(f);
            pdfDoc.Pages[2].Graphics.DrawString("Thank You", pdfFont, new PdfSolidBrush(new PdfColor(213, 123, 19)), 25, 80);

            f = new Font("Calibri", 10f, System.Drawing.FontStyle.Regular);
            pdfFont = new PdfTrueTypeFont(f);
            pdfDoc.Pages[2].Graphics.DrawString("Thanks for taking the time to complete this form.\nWe will be in contact with you shortly.", pdfFont, new PdfSolidBrush(new PdfColor(124, 143, 166)), 25, 110);

            //Send email
            PdfButtonField submitButton1 = new PdfButtonField(pdfDoc.Pages[2], "submitButton1");
            submitButton1.Bounds = new RectangleF(25, 160, 100, 20);
            submitButton1.Font = pdfFont;
            submitButton1.Text = "Apply";
            submitButton1.BorderStyle = PdfBorderStyle.Beveled;
            submitButton1.BackColor = new PdfColor(181, 191, 203);

            PdfJavaScriptAction javaAction = new PdfJavaScriptAction("address = app.response(\"Enter an e-mail address.\",\"SEND E-MAIL\",\"\");"
                + "if (address)" +

                "{ " +
                "cmdLine = \"mailto:\" + address;" +

                "this.submitForm(cmdLine,true,false,\"Remarks\");" +

                "}");

            submitButton1.Actions.GotFocus = javaAction;
            pdfDoc.Form.Fields.Add(submitButton1);
            pdfDoc.Form.SetDefaultAppearance(false);
            #endregion Third Page

            pdfDoc.Save("JobApplication.pdf");
			pdfDoc.Close(true);
            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("JobApplication.pdf") { UseShellExecute = true };
                process.Start();

            }

        }
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfdemos.wpf;component/Assets/PDF/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
        # region Helpher Methods
        /// <summary>
        /// Creates textbox and adds it in the form
        /// </summary>
        /// <param name="page"></param>
        /// <param name="text"></param>
        /// <param name="tooltip"></param>
        /// <param name="f"></param>
        /// <param name="bounds"></param>
        protected void CreateTextBox(PdfPage page, string text, string tooltip, Font f, RectangleF bounds)
        {
            PdfTextBoxField textBoxField = new PdfTextBoxField(page, text);
            //Set properties to the textbox
            textBoxField.ToolTip = tooltip;
            PdfTrueTypeFont font = new PdfTrueTypeFont(f);
            textBoxField.Font = font;
            textBoxField.BorderColor = new PdfColor(System.Drawing.Color.Gray);
            textBoxField.BorderStyle = PdfBorderStyle.Beveled;
            textBoxField.Bounds = bounds;
            pdfDoc.Form.Fields.Add(textBoxField);
        }
        #endregion
    }
}
