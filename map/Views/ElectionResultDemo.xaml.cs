#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.mapdemos.wpf
{
    /// <summary>
    /// Interaction logic for ElectionResultDemo.xaml
    /// </summary>
    public partial class ElectionResultDemo : DemoControl
    {
        #region Constructor

        public ElectionResultDemo()
        {
            InitializeComponent();
        }

        public ElectionResultDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (map != null)
            {
                map.Dispose();
                map = null;
            }

            base.Dispose(disposing);
        }
    }   
}
