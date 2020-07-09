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
using Syncfusion.UI.Xaml.Gauges;

namespace DirectionCompass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CircularScale_LabelCreated(object sender, LabelCreatedEventArgs args)
        {
            switch ((string)args.LabelText)
            {
                case "0":
                    args.LabelText = "N";
                    break;
                case "1":
                    args.LabelText = "NE";
                    break;
                case "2":
                    args.LabelText = "E";
                    break;
                case "3":
                    args.LabelText = "SE";
                    break;
                case "4":
                    args.LabelText = "S";
                    break;
                case "5":
                    args.LabelText = "SW";
                    break;
                case "6":
                    args.LabelText = "W";
                    break;
                case "7":
                    args.LabelText = "NW";
                    break;
            }
        }
    }
}
