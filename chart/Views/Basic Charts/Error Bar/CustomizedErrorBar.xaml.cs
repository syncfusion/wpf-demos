#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Linq;
using System.Reflection.Emit;
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
 

namespace syncfusion.chartdemos.wpf
{
    public partial class CustomizedErrorBar : DemoControl
    {
        public CustomizedErrorBar()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            sfchart.Dispose();
            base.Dispose(disposing);
        }

        private void Mode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = mode.SelectedIndex;
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        {
                            Errorseries.Mode = ErrorBarMode.Horizontal;
                            break;
                        }
                    case 1:
                        {
                            Errorseries.Mode = ErrorBarMode.Vertical;
                            break;
                        }
                    case 2:
                        {
                            Errorseries.Mode = ErrorBarMode.Both;
                            break;
                        }
                }
            }
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = type.SelectedIndex;
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        {
                            Errorseries.Type = ErrorBarType.Fixed;
                            break;
                        }
                    case 1:
                        {
                            Errorseries.Type = ErrorBarType.Percentage;
                            break;
                        }
                    case 2:
                        {
                            Errorseries.Type = ErrorBarType.StandardDeviation;
                            break;
                        }
                    case 3:
                        {
                            Errorseries.Type = ErrorBarType.StandardErrors;
                            break;
                        }

                    case 4:
                        {
                            Errorseries.Type = ErrorBarType.Custom;
                            break;
                        }
                }
            }
        }
    }
}

