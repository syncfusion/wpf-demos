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
using System.Drawing;
using syncfusion.demoscommon.wpf;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FormFillingandProtection : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public FormFillingandProtection()
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
                //Creates an empty Word document instance.
                using (WordDocument document = new WordDocument())
                {

                    //Get Template document and database path.
                    string dataPath = @"Assets\DocIO\";

                    //Opens template document.
                    document.Open(dataPath + "ContentControlTemplate.docx");


                    WTextRange textRange;

                    #region Fill data and lock the contents of content control
                    
                    #region Drop down list content control
                    //Find the drop down list content control with title "Status".
                    IInlineContentControl inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "Status") as IInlineContentControl;
                    inlineControl.ContentControlProperties.LockContents = true;
                    //Sets default option to display.
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    textRange.Text = "In-Progress";
                    ApplyCharacterFormat(textRange);
                    inlineControl.ParagraphItems.Add(textRange);
                    
                    //Adds items to the dropdown list.
                    ContentControlListItem item;
                    item = new ContentControlListItem();
                    item.DisplayText = "Testing";
                    item.Value = "2";
                    inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
                    
                    item = new ContentControlListItem();
                    item.DisplayText = "Review";
                    item.Value = "3";
                    inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
                    
                    item = new ContentControlListItem();
                    item.DisplayText = "Completed";
                    item.Value = "4";
                    inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
                    #endregion
                    
                    
                    #region Calendar content control
                    //Find the first date picker content control with tag "Date".
                    inlineControl = document.FindItemByProperties(EntityType.InlineContentControl,
                       new string[2] { "ContentControlProperties.Type", "ContentControlProperties.Tag" },
                       new string[2] { "Date", "Date" }) as IInlineContentControl;
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    //Sets today's date to display.
                    textRange.Text = DateTime.Now.ToShortDateString();
                    ApplyCharacterFormat(textRange);
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    
                    //Find the inline content control with title "StartDate".
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                       "ContentControlProperties.Title", "StartDate") as IInlineContentControl;
                    inlineControl.ContentControlProperties.LockContents = true;
                    //Sets default date to display.
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    textRange.Text = DateTime.Now.AddDays(-6).ToShortDateString();
                    ApplyCharacterFormat(textRange);
                    
                    //Find the inline content control with title "EndDate".
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                       "ContentControlProperties.Title", "EndDate") as IInlineContentControl;
                    inlineControl.ContentControlProperties.LockContents = true;
                    //Sets default date to display.
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    textRange.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                    ApplyCharacterFormat(textRange);
                    #endregion
                    
                    #region Plain text content controls
                    //Find the plain text content control with title "ProjectName".
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "ProjectName") as IInlineContentControl;
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    //Sets text in plain text content control.
                    textRange.Text = "Website for Adventure works cycle";
                    ApplyCharacterFormat(textRange);
                    
                    
                    //Find the plain text content control with title "ProjectManager".
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "ProjectManager") as IInlineContentControl;
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    //Sets text in plain text content control.
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    textRange.Text = "Nancy Davolio";
                    ApplyCharacterFormat(textRange);
                    
                    //Find the plain text content control with title "TeamSize".
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "TeamSize") as IInlineContentControl;
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    //Sets text in plain text content control.
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    textRange.Text = "10";
                    ApplyCharacterFormat(textRange);
                    
                    
                    //Find the plain text content control with title "TeamName".
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "TeamName") as IInlineContentControl;
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    //Sets text in plain text content control.
                    textRange.Text = "Adventure Works Cycle";
                    ApplyCharacterFormat(textRange);
                    
                    //Find the plain text content control with title "ProjectVision".
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "ProjectVision") as IInlineContentControl;
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    //Sets text in rich text content control.
                    textRange.Text = "Launch a website on " + DateTime.Now.AddDays(50).ToShortDateString() + " that allows customers to purchase products online " +
                        "and reflects Adventure Works Cycle having the highest quality and the best products in its category.";
                    ApplyCharacterFormat(textRange);
                    
                    //Find the plain text content control with title "Issues".
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "Issues") as IInlineContentControl;
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    //Sets text in rich text content control.
                    textRange.Text = "By the end of next month, if we do not have a finalized product image, we will not be able to meet our deployment deadline.";
                    ApplyCharacterFormat(textRange);
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    
                    //Find the plain text content control with title "MilestoneAccomplished"
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "MilestoneAccomplished") as IInlineContentControl;
                    //Clear the existing content in content control
                    inlineControl.ParagraphItems.Clear();
                    //Add first milestone as WTextRange
                    textRange = new WTextRange(document);
                    inlineControl.ParagraphItems.Add(textRange);
                    inlineControl.ContentControlProperties.Multiline = true;
                    //Sets text in rich text content control.
                    textRange.Text = "Framed the basic structure of website.";
                    ApplyCharacterFormat(textRange);
                    //Add line break
                    Break br = new Break(document, BreakType.LineBreak);
                    inlineControl.ParagraphItems.Add(br);
                    //Add next milestone as WTextRange
                    textRange = new WTextRange(document);
                    inlineControl.ParagraphItems.Add(textRange);
                    textRange.Text = " Applied for design review.";
                    ApplyCharacterFormat(textRange);
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    
                    //Find the plain text content control with title "NextWeekMilestones"
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "NextWeekMilestones") as IInlineContentControl;
                    //Clear the existing content in content control
                    inlineControl.ParagraphItems.Clear();
                    //Add first milestone as WTextRange
                    textRange = new WTextRange(document);
                    inlineControl.ParagraphItems.Add(textRange);
                    inlineControl.ContentControlProperties.Multiline = true;
                    //Sets text in rich text content control.
                    textRange.Text = "Prepare design files for development.";
                    ApplyCharacterFormat(textRange);
                    //Add line break
                    br = new Break(document, BreakType.LineBreak);
                    inlineControl.ParagraphItems.Add(br);
                    //Add next milestone as WTextRange
                    textRange = new WTextRange(document);
                    inlineControl.ParagraphItems.Add(textRange);
                    textRange.Text = " Start development - Sprint 1 (Homepage & Product Detail Page).";
                    ApplyCharacterFormat(textRange);
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    
                    //Find the plain text content control with title "UpcomingMilestones"
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "UpcomingMilestones") as IInlineContentControl;
                    //Clear the existing content in content control
                    inlineControl.ParagraphItems.Clear();
                    //Add first milestone as WTextRange
                    textRange = new WTextRange(document);
                    inlineControl.ParagraphItems.Add(textRange);
                    //Enable multiline in content control
                    inlineControl.ContentControlProperties.Multiline = true;
                    //Sets text in rich text content control.
                    textRange.Text = DateTime.Now.AddDays(15).ToShortDateString() + " : Design Approval";
                    ApplyCharacterFormat(textRange);
                    //Add line break
                    br = new Break(document, BreakType.LineBreak);
                    inlineControl.ParagraphItems.Add(br);
                    //Add next milestone as WTextRange
                    textRange = new WTextRange(document);
                    inlineControl.ParagraphItems.Add(textRange);
                    textRange.Text = " " + DateTime.Now.AddDays(30).ToShortDateString() + " : Development Begins";
                    ApplyCharacterFormat(textRange);
                    //Add line break
                    br = new Break(document, BreakType.LineBreak);
                    inlineControl.ParagraphItems.Add(br);
                    //Add next milestone as WTextRange
                    textRange = new WTextRange(document);
                    inlineControl.ParagraphItems.Add(textRange);
                    textRange.Text = " " + DateTime.Now.AddDays(45).ToShortDateString() + " : Deployment";
                    ApplyCharacterFormat(textRange);
                    //Protects the content control.
                    inlineControl.ContentControlProperties.LockContents = true;
                    #endregion
                    
                    #region CheckBox Content control
                    //Find checkbox content control with tag "C#".
                    inlineControl = document.FindItemByProperties(EntityType.InlineContentControl,
                        new string[2] { "ContentControlProperties.Type", "ContentControlProperties.Tag" },
                        new string[2] { "CheckBox", "C#" }) as InlineContentControl;
                    inlineControl.ContentControlProperties.LockContents = true;
                    //Sets checkbox as checked state.
                    inlineControl.ContentControlProperties.IsChecked = true;
                    #endregion
                    
                    #region Drop down list content control
                    //Find the drop down list content control with title "Platform".
                    inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                        "ContentControlProperties.Title", "Platform") as IInlineContentControl;
                    inlineControl.ContentControlProperties.LockContents = true;
                    //Sets default option to display.
                    textRange = inlineControl.ParagraphItems[0] as WTextRange;
                    textRange.Text = "ASP.NET";
                    ApplyCharacterFormat(textRange);
                    inlineControl.ParagraphItems.Add(textRange);
                    
                    //Adds items to the dropdown list.
                    item = new ContentControlListItem();
                    item.DisplayText = "ASP.NET MVC";
                    item.Value = "2";
                    inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
                    
                    item = new ContentControlListItem();
                    item.DisplayText = "ASP.NET Core";
                    item.Value = "3";
                    inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
                    
                    item = new ContentControlListItem();
                    item.DisplayText = "Blazor";
                    item.Value = "4";
                    inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
                    #endregion
                    
                    #region Block content control
                    //Find all the block content controls which having title "Description".
                    List<Entity> blockContentControls = document.FindAllItemsByProperty(EntityType.BlockContentControl,
                        "ContentControlProperties.Title", "ContactInformation");
                    //Access the first block content control.
                    BlockContentControl blockContentControl = blockContentControls[0] as BlockContentControl;
                    //Protects the block content control
                    blockContentControl.ContentControlProperties.LockContents = true;
                    #endregion
                    #endregion

                    try
                    {
                        //Saving the document as .docx
                        document.Save("Form Filling and Protection.docx", FormatType.Docx);

                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Form Filling and Protection.docx") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Form Filling and Protection.docx" + ") then try generating the document.", "File is already open",
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
        /// <summary>
        /// Apply character format for text range
        /// </summary>
        private void ApplyCharacterFormat(WTextRange textRange)
        {
            textRange.CharacterFormat.FontName = "Century Gothic";
            textRange.CharacterFormat.FontSize = 12;
            textRange.CharacterFormat.TextColor = Color.Black;
        }
        #endregion
    }
}