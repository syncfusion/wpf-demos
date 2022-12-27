#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.ComponentModel;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Interaction logic for SilentPrinting.xaml
    /// </summary>
    public partial class SilentPrinting : ChromelessWindow
    {
        public SilentPrinting()
        {
            InitializeComponent();
        }
        public SilentPrinting(string themeName)
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.DataContext = null;
            base.OnClosing(e);
        }
    }
}
