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
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Customization
    {
        #region Constructor

        public Customization()
        {
            InitializeComponent();
        }

        public Customization(string themename) : base(themename)
        {
            InitializeComponent();
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (this.gradientRangeSlider != null)
            {
                this.gradientRangeSlider.Dispose();
                this.gradientRangeSlider = null;
            }

            if (this.customRangeSlider != null)
            {
                this.customRangeSlider.Dispose();
                this.customRangeSlider = null;
            }

            if (this.trackRangeSlider != null)
            {
                this.trackRangeSlider.Dispose();
                this.trackRangeSlider = null;
            }

            if (this.tickRangeSlider != null)
            {
                this.tickRangeSlider.Dispose();
                this.tickRangeSlider = null;
            }

            base.Dispose(disposing);
        }

    }
}
