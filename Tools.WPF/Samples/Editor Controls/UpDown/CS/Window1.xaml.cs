#region Copyright Syncfusion Inc. 2001 - 2010
// Copyright Syncfusion Inc. 2001 - 2010. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
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
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Threading;

namespace UpDownDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : ChromelessWindow
    {
        #region Constructor

        /// <summary>
        /// Constructor for window1.
        /// </summary>

        public Window1()
        {
            InitializeComponent();
            errorTextPopup.PlacementTarget = step;
            this.SizeChanged += Window1_SizeChanged;
           
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            MovePopup();
            base.OnLocationChanged(e);
        }

        void Window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MovePopup();
        }

        private void MovePopup()
        {
            var offset = errorTextPopup.HorizontalOffset;
            errorTextPopup.HorizontalOffset = offset + 1;
            errorTextPopup.HorizontalOffset = offset;
        }

        #endregion

        #region Methods

        private void step_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (step != null)
            {
               
                    if ((int)e.Key >= 34 && (int)e.Key<=43 &&Keyboard.Modifiers!=ModifierKeys.Shift || e.Key==Key.Back || e.Key== Key.Delete||e.Key==Key.Left ||e.Key ==Key.Right)
                    {
                        if (errorTextPopup != null && errorTextPopup.IsOpen)
                            errorTextPopup.IsOpen = false;
                    }
                    else
                    {
                        if (errorTextPopup != null && !errorTextPopup.IsOpen)
                            errorTextPopup.IsOpen = true;
                        e.Handled = true;
                    }
               
            }
        }

        private void TxtGroupSeperator_LostFocus(object sender, RoutedEventArgs e)
        {
            if (errorTextPopup != null && errorTextPopup.IsOpen)
                errorTextPopup.IsOpen = false;
        }

        private void readonly_Click(object sender, RoutedEventArgs e)
        {
            if (updown.IsEnabled == true)
                updown.IsEnabled = false;
            else
                updown.IsEnabled = true;
        }
        #endregion

      

       


    }

}
