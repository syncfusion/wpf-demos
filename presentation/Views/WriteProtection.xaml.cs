#region Copyright Syncfusion Inc. 2001 - 2012
//
//  Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
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
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.Presentation;
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for WriteProtection.xaml
    /// </summary>
    public partial class WriteProtection : DemoControl
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public WriteProtection()
        {
            InitializeComponent();
            string path = @"Assets\Presentation\";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            this.textBox1.Text = "Syncfusion Presentation.pptx";
            this.textBox1.Tag = @"Assets\Presentation\Syncfusion Presentation.pptx";
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        /// <summary>
        /// Encrypt the word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void protect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(passwordBox1.Password))
                {
                    MessageBox.Show("Please enter password to protect", "Password Missing", MessageBoxButton.OK);
                }
                else
                {
                    //Creates instance for presentation 
                    IPresentation presentation = Presentation.Open(textBox1.Tag.ToString());
                    //Set the write protection for presentation instance
                    presentation.SetWriteProtection(passwordBox1.Password);
                    //Saving the presentation
                    presentation.Save("WriteProtection.pptx");
                    //Closing the presentation
                    presentation.Close();

                    if (MessageBox.Show("Do you want to view the protected Presentation?", "Write Protected Presentation",
                              MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("WriteProtection.pptx") { UseShellExecute = true };
                        process.Start();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This file could not be write protected , please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                       MessageBoxButton.OK);
            }
        }
        
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "PowerPoint Presentations|*.pptx";
            Nullable<bool> result = openFileDialog1.ShowDialog();
            if (result == true)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                this.textBox1.Tag = openFileDialog1.FileName;
            }
        }			
    }
}
