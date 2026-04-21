#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using Syncfusion.SfSkinManager;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace syncfusion.sparklinedemos.wpf
{
    /// <summary>
    /// Interaction logic for sparklineMeasures.xaml
    /// </summary>
    public partial class Sparkline : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sparkline"/> class.
        /// </summary>
        public Sparkline()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sparkline"/> class with the theme.
        /// </summary>
        /// <param name="themename">Represents the name of the theme.</param>
        public Sparkline(string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (dataGrid != null)
            {
                dataGrid.Dispose();
                dataGrid = null;
            }

            base.Dispose(disposing);
        }
    }
}