#region Copyright Syncfusion Inc. 2001 - 2020
//
//  Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using System.Windows.Media;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.IO;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon =(ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
#else
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
#endif
        }
        # endregion

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
                //Creates an empty Word document instance.
                WordDocument document = new WordDocument();

                // Get Template document and database path.
                string dataPath = string.Empty;
#if NETCORE
                dataPath =  @"..\..\..\..\..\..\..\Common\Data\DocIO\";
#else
                dataPath = @"..\..\..\..\..\..\Common\Data\DocIO\";
#endif
                //Opens template document.
                document.Open(dataPath+ "ContentControlTemplate.docx");

                IWTextRange textRange;
				//Gets table from the template document.
				IWTable table = document.LastSection.Tables[0];
				WTableRow row = table.Rows[1];
	
				#region Inserting content controls
	
				#region Calendar content control
				IWParagraph cellPara = row.Cells[0].Paragraphs[0];
				//Accesses the date picker content control.
				IInlineContentControl inlineControl = (cellPara.ChildEntities[2] as IInlineContentControl);
				textRange = inlineControl.ParagraphItems[0] as WTextRange;
				//Sets today's date to display.
				textRange.Text = DateTime.Now.ToShortDateString();
				textRange.CharacterFormat.FontSize = 14;
				//Protects the content control.
				inlineControl.ContentControlProperties.LockContents = true;
				#endregion
	
				#region Plain text content controls
				table = document.LastSection.Tables[1];
				row = table.Rows[0];
				cellPara = row.Cells[0].LastParagraph;
				//Accesses the plain text content control.
				inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
				//Protects the content control.
				inlineControl.ContentControlProperties.LockContents = true;
				textRange = inlineControl.ParagraphItems[0] as WTextRange;
				//Sets text in plain text content control.
				textRange.Text = "Northwind Analytics";
				textRange.CharacterFormat.FontSize = 14;
	
				cellPara = row.Cells[1].LastParagraph;
				//Accesses the plain text content control.
				inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
				//Protects the content control.
				inlineControl.ContentControlProperties.LockContents = true;
				textRange = inlineControl.ParagraphItems[0] as WTextRange;
				//Sets text in plain text content control.
				textRange.Text = "Northwind";
				textRange.CharacterFormat.FontSize = 14;
	
				row = table.Rows[1];
				cellPara = row.Cells[0].LastParagraph;
				//Accesses the plain text content control.
				inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
				//Protects the content control.
				inlineControl.ContentControlProperties.LockContents = true;
				//Sets text in plain text content control.
				textRange = inlineControl.ParagraphItems[0] as WTextRange;
				textRange.Text = "10";
				textRange.CharacterFormat.FontSize = 14;
	
	
				cellPara = row.Cells[1].LastParagraph;
				//Accesses the plain text content control.
				inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
				//Protects the content control.
				inlineControl.ContentControlProperties.LockContents = true;
				//Sets text in plain text content control.
				textRange = inlineControl.ParagraphItems[0] as WTextRange;
				textRange.Text = "Nancy Davolio";
				textRange.CharacterFormat.FontSize = 14;
				#endregion
	
				#region CheckBox Content control
				row = table.Rows[2];
				cellPara = row.Cells[0].LastParagraph;
				//Inserts checkbox content control.
				inlineControl = cellPara.AppendInlineContentControl(ContentControlType.CheckBox);
				inlineControl.ContentControlProperties.LockContents = true;
				//Sets checkbox as checked state.
				inlineControl.ContentControlProperties.IsChecked = true;
				textRange = cellPara.AppendText("C#, ");
				textRange.CharacterFormat.FontSize = 14;
	
				//Inserts checkbox content control.
				inlineControl = cellPara.AppendInlineContentControl(ContentControlType.CheckBox);
				inlineControl.ContentControlProperties.LockContents = true;
				//Sets checkbox as checked state.
				inlineControl.ContentControlProperties.IsChecked = true;
				textRange = cellPara.AppendText("VB");
				textRange.CharacterFormat.FontSize = 14;
				#endregion
	
	
				#region Drop down list content control
				cellPara = row.Cells[1].LastParagraph;
				//Accesses the dropdown list content control.
				inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
				inlineControl.ContentControlProperties.LockContents = true;
				//Sets default option to display.
				textRange = inlineControl.ParagraphItems[0] as WTextRange;
				textRange.Text = "ASP.NET";
				textRange.CharacterFormat.FontSize = 14;
				inlineControl.ParagraphItems.Add(textRange);
	
				//Adds items to the dropdown list.
				ContentControlListItem item;
				item = new ContentControlListItem();
				item.DisplayText = "ASP.NET MVC";
				item.Value = "2";
				inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
	
				item = new ContentControlListItem();
				item.DisplayText = "Windows Forms";
				item.Value = "3";
				inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
	
				item = new ContentControlListItem();
				item.DisplayText = "WPF";
				item.Value = "4";
				inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
	
				item = new ContentControlListItem();
				item.DisplayText = "Xamarin";
				item.Value = "5";
				inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
				#endregion
	
				#region Calendar content control
				row = table.Rows[3];
				cellPara = row.Cells[0].LastParagraph;
				//Accesses the date picker content control.
				inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
				inlineControl.ContentControlProperties.LockContents = true;
				//Sets default date to display.
				textRange = inlineControl.ParagraphItems[0] as WTextRange;
				textRange.Text = DateTime.Now.AddDays(-5).ToShortDateString();
				textRange.CharacterFormat.FontSize = 14;
	
				cellPara = row.Cells[1].LastParagraph;
				//Inserts date picker content control.
				inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
				inlineControl.ContentControlProperties.LockContents = true;
				//Sets default date to display.
				textRange = inlineControl.ParagraphItems[0] as WTextRange;
				textRange.Text = DateTime.Now.AddDays(10).ToShortDateString();
				textRange.CharacterFormat.FontSize = 14;
				#endregion
	
				#endregion
				#region Block content control
				//Accesses the block content control.
				BlockContentControl blockContentControl = ((document.ChildEntities[0] as WSection).Body.ChildEntities[2] as BlockContentControl);
				//Protects the block content control
				blockContentControl.ContentControlProperties.LockContents = true;
				#endregion

                //Saving the document as .docx
                document.Save("Sample.docx", FormatType.Docx);
                document.Close();
                //Message box confirmation to view the created document.
                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]                        
#if NETCORE
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.docx") { UseShellExecute = true };
                        process.Start();
#else
                        System.Diagnostics.Process.Start("Sample.docx");
#endif
                        //Exit
                        this.Close();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            #endregion
        }
    }
}