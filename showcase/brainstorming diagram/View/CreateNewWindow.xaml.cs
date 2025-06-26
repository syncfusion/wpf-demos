#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace syncfusion.brainstormingdiagram.wpf.View
{
    /// <summary>
    /// Interaction logic for CreateNewWindow.xaml
    /// </summary>
    public partial class CreateNewWindow : ChromelessWindow
    {
        public CreateNewWindow()
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });

            this.txtFileName.Focus();
            this.txtFileName.SelectionStart = 0;
            this.txtFileName.SelectionLength = this.txtFileName.Text.Length;
        }

        public string FileName { get; set; }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.FileName = txtFileName.Text;
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
