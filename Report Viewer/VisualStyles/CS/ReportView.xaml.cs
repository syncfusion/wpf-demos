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
using Syncfusion.Windows.Reports.Viewer;
using Microsoft.Win32;
using System.Windows.Threading;
using System.IO;
using System.Collections;
using Syncfusion.Samples.ViewModel;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
#if !SyncfusionFramework3_5
using Syncfusion.SfSkinManager;
#endif
namespace Syncfusion.Samples
{
    public partial class ReportView : ChromelessWindow 
    {        
        #region Constructor

        public ReportView()
        {
            InitializeComponent();
            SkinStorage.SetVisualStyle(this, "Metro");
            
        }

        #endregion

        #region Selection Changed event

        private void ComboBoxAdv_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBoxItemAdv item;
            WindowCollection windows = Application.Current.Windows;
            if (windows.Count > 0)
            {
                Window samplewindow = windows[0];
                ComboBoxAdv combo = sender as ComboBoxAdv;
                if (combo != null)
                {
                    if (combo.SelectedItem != null)
                    {
                        item = combo.SelectedItem as ComboBoxItemAdv;
                        if (this.viewer != null)
                        {
#if !SyncfusionFramework3_5
                            Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this.viewer, (VisualStyles)Enum.Parse(typeof(VisualStyles), item.Content.ToString()));
#endif
                            Syncfusion.Samples.ViewModel.ReportViewModel viewModel = new ReportViewModel();
                            viewModel.Loaded(samplewindow as object, e);
                        }
                    }

                }
            }
        }

        #endregion
    }
}
