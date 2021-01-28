#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace syncfusion.demoscommon.wpf
{
    public class AutomationMail
    {
        /// <summary>
        /// Helps to send binding error report
        /// </summary>
        internal static void SendBindingErrorReport()
        {
            DirectoryInfo info = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = info.GetFiles("*.txt", SearchOption.AllDirectories);

            if (files == null)
            {
                return;
            }

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                IWorkbook workbook = application.Workbooks.Create(2);
                IWorksheet bindErrorSheet = workbook.Worksheets[0];
                bindErrorSheet.Name = "BindingError";
                IWorksheet liveDemosSheet = workbook.Worksheets[1];
                liveDemosSheet.Name = "LiveDemos";
                workbook.Version = ExcelVersion.Excel2013;
                IStyle style = workbook.Styles.Add("NewStyle");
                style.Font.Bold = true;

                bindErrorSheet[1, 1].Text = "Product Name";
                bindErrorSheet[1, 2].Text = "Sample Name";
                bindErrorSheet[1, 3].Text = "Error Message";
                liveDemosSheet[1, 1].Text = "Product Name";
                liveDemosSheet[1, 2].Text = "Sample Name";
                liveDemosSheet[1, 3].Text = "Live Demos with/without BusyIndicator";
                bindErrorSheet[1, 1].CellStyle = bindErrorSheet[1, 2].CellStyle = bindErrorSheet[1, 3].CellStyle =
                liveDemosSheet[1, 1].CellStyle = liveDemosSheet[1, 2].CellStyle = liveDemosSheet[1, 3].CellStyle = style;
                bindErrorSheet.SetColumnWidth(1, 35);
                bindErrorSheet.SetColumnWidth(2, 65);
                bindErrorSheet.SetColumnWidth(3, 100);
                liveDemosSheet.SetColumnWidth(1, 35);
                liveDemosSheet.SetColumnWidth(2, 65);
                liveDemosSheet.SetColumnWidth(3, 100);
                int bindingErrorRow = 2;
                int liveDemosRow = 2;

                foreach (var directory in files)
                {
                    if (directory.Name.Contains("LiveDemos") || directory.Name.Contains("BindingError"))
                    {
                        var readlines = File.ReadAllLines(directory.FullName).ToList();
                        if (readlines.Count > 0)
                        {
                            bindErrorSheet.Range["C" + bindingErrorRow].WrapText = true;
                            bindErrorSheet.SetRowHeight(bindingErrorRow, 50);
                            bindErrorSheet.Range["C" + liveDemosRow].WrapText = true;
                            bindErrorSheet.SetRowHeight(liveDemosRow, 50);
                            foreach (string message in readlines)
                            {
                                var splitwords = message.Split('\\');
                                if (message.Contains("BindingExpression"))
                                {
                                    bindErrorSheet[bindingErrorRow, 1].Text = splitwords[0];
                                    bindErrorSheet[bindingErrorRow, 2].Text = splitwords[1];
                                    bindErrorSheet[bindingErrorRow, 3].Text = splitwords[2];
                                    bindingErrorRow++;
                                }
                                else
                                {
                                    liveDemosSheet[liveDemosRow, 1].Text = splitwords[0];
                                    liveDemosSheet[liveDemosRow, 2].Text = splitwords[1];
                                    liveDemosSheet[liveDemosRow, 3].Text = splitwords[2];
                                    liveDemosRow++;
                                }
                            }
                        }
                    }
                }

                if (File.Exists("BindingErrorReport.xlsx"))
                {
                    File.Delete("BindingErrorReport.xlsx");
                }

                workbook.SaveAs("BindingErrorReport.xlsx");
                SendAutomationStartedMail();
            }

            foreach (var deleteFile in files)
            {
                if (deleteFile.Name.Contains("LiveDemos") || deleteFile.Name.Contains("BindingError"))
                {
                    if (File.Exists(deleteFile.FullName))
                    {
                        File.Delete(deleteFile.FullName);
                    }
                }
            }
        }
        private static void SendAutomationStartedMail()
        {
            IPHostEntry host;
            string name = System.Net.Dns.GetHostName();
            host = System.Net.Dns.GetHostEntry(name);
            System.Net.IPAddress ip = host.AddressList.Where(n => n.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
            List<string> message = new List<string>();
            string htmlBody = GetBody(ip);
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            MailMessage myMessage = new MailMessage();
            myMessage.AlternateViews.Add(avHtml);
            myMessage.IsBodyHtml = true;
            myMessage.Body = htmlBody;
            myMessage.From = new MailAddress("marimuthu.sivalingam@syncfusion.com");
            var Receivers = ("DockingChildren@syncfusion.com;sivakumarr@syncfusion.com;jeganr@syncfusion.com").Split(';') ;
            for (int i = 0; i < Receivers.Count(); i++)
            {
                myMessage.To.Add(new MailAddress(Receivers[i]));
            } 
            myMessage.Priority = MailPriority.High;
            myMessage.Subject = String.Format("Binding error report details");
            string errorPath = Directory.GetCurrentDirectory() + @"\Errorlog.txt";
            var readlines = File.ReadAllLines(errorPath).ToList();
            string bindingErrorPath = Directory.GetCurrentDirectory() + @"\BindingErrorReport.xlsx";
            if (File.Exists(bindingErrorPath))
            {
                System.Net.Mail.Attachment bindingError = new System.Net.Mail.Attachment(bindingErrorPath);
                myMessage.Attachments.Add(bindingError);
            }
            if (File.Exists(errorPath) && readlines.Count> 2)
            {
                System.Net.Mail.Attachment errorList = new System.Net.Mail.Attachment(errorPath);
                myMessage.Attachments.Add(errorList);
            }
            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            var secure = new SecureString();
            string password = "dxxtzgcrtjbmsrlp";
            foreach (char c in password)
            {
                secure.AppendChar(c);
            }
            client.Credentials = new NetworkCredential("marimuthu.sivalingam@syncfusion.com", secure);
            int count = 0;
            while (count < 3)
            {
                try
                {
                    client.Send(myMessage);
                    message.Add("Automation status has been sent...");
                    count = 3;
                }
                catch (Exception ex)
                {
                    message.Add(ex.Message);
                    message.Add(String.Format("Sending Mail Attemp - {0}", count.ToString()));
                    Thread.Sleep(60000);
                    count++;
                }
            }
        }

        /// <summary>
        /// Generates the email content for build failed
        /// </summary>
        /// <returns></returns>
        private static string GetBody(IPAddress ip)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html bgcolor='#F6F6F6'><p>Hi Team,<br><br>Please find binding error, live demos and error report details from the attachment. </p>");
            sb.Append("<br>Thanks,<br><br>");
            sb.Append("Tools Docking Team<br>Syncfusion Software.</html>");
            return sb.ToString();
        }
    }
}
