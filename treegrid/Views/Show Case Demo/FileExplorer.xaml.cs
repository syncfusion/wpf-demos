#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for FileExplorer.xaml
    /// </summary>
    public partial class FileExplorer : ChromelessWindow
    {
        public FileExplorer()
        {
            InitializeComponent();
        }

        public FileExplorer(string themename)
        {
            SfSkinManager.SetVisualStyle(this, (VisualStyles)Enum.Parse(typeof(VisualStyles), themename));
            InitializeComponent();
            this.Closed += FileExplorer_Closed;
        }

        private void FileExplorer_Closed(object sender, EventArgs e)
        {
            if (this.treeGrid != null)
            {
                this.treeGrid.Dispose();
                this.treeGrid = null;
            }
            this.Closed -= FileExplorer_Closed;
        }
    }
}
