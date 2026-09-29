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
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;

namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AutoCompleteDemo : DemoControl
    {
        public AutoCompleteDemo()
        {
            InitializeComponent();
        }

        public AutoCompleteDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.autoComplete != null)
            {
                this.autoComplete.Dispose();
                this.autoComplete = null;
            }

            if (this.filterType != null)
            {
                this.filterType.Dispose();
                this.filterType = null;
            }

            if (this.itemTemplate != null)
            {
                this.itemTemplate.Dispose();
                this.itemTemplate = null;
            }

            if (this.diacriticTypes != null)
            {
                this.diacriticTypes.Dispose();
                this.diacriticTypes = null;
            }

            if (this.popup != null)
            {
                this.popup.Dispose();
                this.popup = null;
            }

            if (this.customFilter != null)
            {
                this.customFilter.Dispose();
                this.customFilter = null;
            }

            base.Dispose(disposing);
        }
    }      
}

