#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Windows.Shared;

namespace GettingStarted_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private string fileName;
        private string filePath;
        # endregion

        # region Constructor
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter converter = new ImageSourceConverter();
            this.Icon = (ImageSource)converter.ConvertFromString(GetFullTemplatePath("pdf viewer.png", true));

            // Position and size the window.
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 2 / 3;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight * (3 / 2) - 50;
            this.Left = System.Windows.SystemParameters.PrimaryScreenWidth / 6;
            this.Top = 5;
            this.WindowState = WindowState.Maximized;
            this.UseNativeChrome = true;
            this.Closed += Window1_Closed;
        }
        # endregion

        # region Events
        /// <summary>
        /// Occurs when the window is about to close
        /// </summary>
        private void Window1_Closed(object sender, EventArgs e)
        {
            pdfviewer1.Unload();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            filePath = GetFullTemplatePath(string.Empty, false);

          
            comboBox1.Items.Add("Windows Store Apps Succinctly.pdf");
            comboBox1.Items.Add("JavaScript Succinctly.pdf");
            comboBox1.Items.Add("HTTP Succinctly.pdf");
            comboBox1.Items.Add("F# Succinctly.pdf");
            comboBox1.Items.Add("ASP.NET MVC 4 Succinctly.pdf");
            comboBox1.Items.Add("GIS Succinctly.pdf");
            comboBox1.SelectionChanged += ComboBox_SelectionChanged;
            comboBox1.SelectedItem = comboBox1.Items[0];
         

            // Load a document in PdfViewer.
            pdfviewer1.Load(string.Format("{0}Windows Store Apps Succinctly.pdf", filePath));

           
        }

        // Load the selected document.
       
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fileName = (string)comboBox1.SelectedItem;
			pdfviewer1.Load(string.Format("{0}{1}", filePath, fileName));
        }
      
        # endregion

        # region Helper Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
		    string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }

        # endregion
    }
}
