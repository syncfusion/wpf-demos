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
using System.IO;
using Syncfusion.DocIO;
using System.ComponentModel;
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using System.Windows.Controls;

namespace TrackingChanges
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        string path;
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
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");          
            path = @"..\..\..\..\..\..\..\Common\Data\DocIO\";
#else
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
            path = @"..\..\..\..\..\..\Common\Data\DocIO\";
#endif                     
            radioButtonAccept.IsEnabled = false;
            radioButtonReject.IsEnabled = false;
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
				//Get Template document and database path.                
#if NETCORE
                string dataPath = @"..\..\..\..\..\..\..\Common\Data\DocIO\";
#else
                string dataPath = @"..\..\..\..\..\..\Common\Data\DocIO\";
#endif

                //Loads the template document.
                WordDocument document = new WordDocument();
                document.OpenReadOnly(dataPath + "TrackChangesTemplate.docx", FormatType.Automatic);
			    //Get Template document and database path.                
                string author = GetAuthorName(comboBoxAuthorName.SelectedIndex);
                //Accepts the all changes made by the author
                if (radioButtonAccept.IsChecked == true)
                    AcceptRevisionsOfAuthor(document, author);
                //Rejects the all the changes made by the author
                else if (radioButtonReject.IsChecked==true)
                    RejectRevisionsOfAuthor(document, author);
                //Rejects all the tracked changes revisions in the Word document
                else if (radioButtonRejectAll.IsChecked==true)
                    document.Revisions.RejectAll();
                //Accepts all the tracked changes revisions in the Word document
                else
                    document.Revisions.AcceptAll();
                //Save as doc format
				document.Save("Track Changes.docx", FormatType.Docx);
                document.Close();
                //Message box confirmation to view the created document.
                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]                        
#if NETCORE
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Track Changes.docx") { UseShellExecute = true };
                        process.Start();
#else
                        System.Diagnostics.Process.Start("Track Changes.docx");
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
               
                    // Exit
                    this.Close();                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
		/// <summary>
        /// Gets the author name
        /// </summary>
        private string GetAuthorName(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 1:
                    return "Nancy Davolio";
                case 2:
                    return "Steven Buchanan";
                case 3:
                    return "Stanley Hudson";
                case 4:
                    return "Andrew Fuller";
            }
            return string.Empty;
        }

        private void ComboBoxSelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            //If none author selected disable the radio button, otherwise enabled
            if (comboBoxAuthorName.SelectedIndex != 0)
            {
                radioButtonAccept.IsChecked = true;
                radioButtonAccept.IsEnabled = true;
                radioButtonReject.IsEnabled = true;
            }
            else if(radioButtonAcceptAll!=null && radioButtonAccept !=null && radioButtonReject!=null)
            {
                radioButtonAcceptAll.IsChecked = true;
                radioButtonAccept.IsEnabled = false;
                radioButtonReject.IsEnabled = false;
            }
        }
        #endregion
        #region Helper Methods
        /// <summary>
        ///  Rejects the all changes made by the author
        /// </summary>
        private void RejectRevisionsOfAuthor(WordDocument document, string author)
        {
            //Iterate into all the revisions in Word document
            for (int i = document.Revisions.Count - 1; i >= 0; i--)
            {
                //Checks the author of current revision and rejects it.
                if (document.Revisions[i].Author == author)
                    document.Revisions[i].Reject();

                //Reset to last item when reject the moving related revisions.
                if (i > document.Revisions.Count - 1)
                    i = document.Revisions.Count;
            }
        }
        /// <summary>
        ///  Accepts the all changes made by the author
        /// </summary>
        private void AcceptRevisionsOfAuthor(WordDocument document, string author)
        {
            //Iterate into all the revisions in Word document
            for (int i = document.Revisions.Count - 1; i >= 0; i--)
            {
                //Checks the author of current revision and rejects it.
                if (document.Revisions[i].Author == author)
                    document.Revisions[i].Accept();

                //Reset to last item when accept the moving related revisions.
                if (i > document.Revisions.Count - 1)
                    i = document.Revisions.Count;
            }
        }      
        #endregion
       
		   /// <summary>
        /// Opens the template document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            //Get Template document and database path.            
#if NETCORE
            string dataPath = @"..\..\..\..\..\..\..\Common\Data\DocIO\";
#else
            string dataPath = @"..\..\..\..\..\..\Common\Data\DocIO\";
#endif
            string path = System.IO.Path.Combine(dataPath, @"TrackChangesTemplate.docx");
            //Opens the template document.
            //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]            
#if NETCORE
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
            process.Start();
#else
            System.Diagnostics.Process.Start(path);
#endif
        }

    }
}