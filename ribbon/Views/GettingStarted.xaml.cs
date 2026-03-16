#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Code behind logic for Window1.xaml
    /// </summary>
    public partial class GettingStarted : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStarted"/> class.
        /// </summary>
        public GettingStarted()
        {
            InitializeComponent();
        }

        public GettingStarted(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.Resources != null)
                this.Resources.Clear();
            var viewModel = this.DataContext as GettingStartedViewModel;
            if (viewModel != null)
            {
                if (viewModel.FontFamilyList != null)
                {
                    viewModel.FontFamilyList.Clear();
                    viewModel.FontFamilyList = null;
                }
                if (viewModel.FontSizeList != null)
                {
                    viewModel.FontSizeList.Clear();
                    viewModel.FontSizeList = null;
                }
                viewModel.Dispose();
                viewModel = null;
            }
            if (this.mainRibbon != null)
            {
                this.mainRibbon.Dispose();
                this.mainRibbon = null;
            }
            if (this.editor != null)
            {
                this.editor = null;
            }            
              
            if (mainGrid != null)
            {
                mainGrid.Children.Clear();
                mainGrid = null;
            }
            if (ribbonGrid != null)
            {
                ribbonGrid.Children.Clear();
                ribbonGrid = null;
            }                   
            BindingOperations.ClearAllBindings(this);
            base.Dispose(disposing);
        }
    }
}