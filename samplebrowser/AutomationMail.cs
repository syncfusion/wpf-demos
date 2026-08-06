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

            Task bindingErrorTask = Task.Factory.StartNew(() =>
            {
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
                                    if (splitwords.Length > 2)
                                    {
                                        if (directory.Name.Contains("BindingError"))
                                        {
                                            bindErrorSheet[bindingErrorRow, 1].Text = splitwords[0];
                                            bindErrorSheet[bindingErrorRow, 2].Text = splitwords[1];
                                            bindErrorSheet[bindingErrorRow, 3].Text = splitwords[2];
                                            bindingErrorRow++;
                                        }
                                        else if (directory.Name.Contains("LiveDemos"))
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
                    }

                    if (File.Exists("BindingErrorReport.xlsx"))
                    {
                        File.Delete("BindingErrorReport.xlsx");
                    }

                    workbook.SaveAs("BindingErrorReport.xlsx");
                }
            });

            Task errorLogTask = Task.Factory.StartNew(() =>
            {
                using (ExcelEngine errorLogExcelEngine = new ExcelEngine())
                {
                    IApplication application = errorLogExcelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Excel2016;
                    IWorkbook workbook = application.Workbooks.Create(1);

                    IWorksheet errorLogSheet = workbook.Worksheets[0];
                    errorLogSheet.Name = "ErrorLog";
                    workbook.Version = ExcelVersion.Excel2013;
                    IStyle style = workbook.Styles.Add("NewStyle");
                    style.Font.Bold = true;

                    errorLogSheet[1, 1].CellStyle = errorLogSheet[1, 2].CellStyle = errorLogSheet[1, 3].CellStyle =
                        errorLogSheet[1, 4].CellStyle = style;

                    errorLogSheet[1, 1].Text = "Sample Type";
                    errorLogSheet[1, 2].Text = "Product Name";
                    errorLogSheet[1, 3].Text = "Sample Name";
                    errorLogSheet[1, 4].Text = "Error Message";
                    errorLogSheet.SetColumnWidth(1, 35);
                    errorLogSheet.SetColumnWidth(2, 40);
                    errorLogSheet.SetColumnWidth(3, 40);
                    errorLogSheet.SetColumnWidth(4, 100);
                    int errorLogRow = 2;

                    DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\ErrorLog\");
                    FileInfo[] textFiles = dir.GetFiles("*.txt", SearchOption.AllDirectories);

                    if (textFiles.Length > 0)
                    {
                        foreach (FileInfo subDir in textFiles)
                        {
                            if (Directory.GetParent(subDir.FullName).Parent.Name == "Product ShowCase"
                                || Directory.GetParent(subDir.FullName).Parent.Name == "Product Sample"
                                )
                            {
                                errorLogSheet[errorLogRow, 1].Text = Directory.GetParent(subDir.FullName).Parent.Name;
                                errorLogSheet[errorLogRow, 2].Text = Directory.GetParent(subDir.FullName).Name;
                                errorLogSheet[errorLogRow, 3].Text = Path.GetFileNameWithoutExtension(subDir.Name);
                                errorLogSheet[errorLogRow, 4].Text = File.ReadAllText(subDir.FullName);
                                errorLogRow++;
                            }
                        }
                    }


                    if (Directory.Exists(dir.ToString()))
                    {
                        foreach (FileInfo file in dir.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dire in dir.GetDirectories())
                        {
                            dire.Delete(true);
                        }
                    }

                    if (File.Exists("ErrorLogReport.xlsx"))
                    {
                        File.Delete("ErrorLogReport.xlsx");
                    }

                    workbook.SaveAs("ErrorLogReport.xlsx");
                }
            });

            bindingErrorTask.Wait();errorLogTask.Wait();

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
    }
}
