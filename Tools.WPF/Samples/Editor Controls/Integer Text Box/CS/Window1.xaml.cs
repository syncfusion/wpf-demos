#region Copyright Syncfusion Inc. 2001 - 2010
// Copyright Syncfusion Inc. 2001 - 2010. All rights reserved.
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
using Syncfusion.Windows.Shared;
using System.Resources;


namespace IntegerTextBoxDemo
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
            errorTextPopup.PlacementTarget = TxtGroupSeperator;
            this.SizeChanged += Window1_SizeChanged;
           
        }
  #endregion

  #region Methods
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

        private void TxtGroupSeperator_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtGroupSeperator != null)
            {
                if (TxtGroupSeperator.Text.Length == 1)
                {
                    if (char.IsLetterOrDigit(TxtGroupSeperator.Text[0]))
                    {
                        TxtGroupSeperator.Text = string.Empty;
                        if (errorTextPopup != null && !errorTextPopup.IsOpen)
                            errorTextPopup.IsOpen = true;
                    }
                    else
                    {
                        if (errorTextPopup != null && errorTextPopup.IsOpen)
                            errorTextPopup.IsOpen = false;
                    }
                }
            }
        }

        private void TxtGroupSeperator_LostFocus(object sender, RoutedEventArgs e)
        {
            if (errorTextPopup != null && errorTextPopup.IsOpen)
                errorTextPopup.IsOpen = false;
        }

        #endregion

        private void TxtWaterMark_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtWaterMark.IsFocused)
            {
                if (TxtWaterMark.Text == "Type Here")
                {
                    TxtWaterMark.Text = "";
                    TxtWaterMark.Foreground = Brushes.Black;
                }
            }
        }

        private void TxtWaterMark_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtWaterMark.Text == "")
            {
                TxtWaterMark.Text = "Type Here";
                TxtWaterMark.Foreground = Brushes.LightGray;
            }
        }
       
       
    }

}

