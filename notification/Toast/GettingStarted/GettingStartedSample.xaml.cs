#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.SfToastNotification;
using Syncfusion.Windows.Tools.Controls;
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

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for GettingStartedDemo.xaml
    /// </summary>
    public partial class GettingStartedSample : DemoControl
    {
        public GettingStartedSample()
        {
            InitializeComponent();
        }

        private void OnShowToastClick(object sender, RoutedEventArgs e)
        {
            var options = new ToastOptions
            {
                
                Mode = ParseMode(),
                Variant = ParseVariant(),
                Placement = ParsePlacement(),
             
                Title = TitleBox.Text,
                Header = HeaderBox.Text,
                Message = MessageBox.Text,

                Duration = TimeSpan.FromMilliseconds(int.Parse(DurationBox.Text)),
                PreventAutoClose = PreventAutoCloseCheck.IsChecked == true,

                ShowCloseButton = ShowCloseCheck.IsChecked == true,
                ShowActionButtons = ShowActionsCheck.IsChecked == true,

                ShowAnimationType= ParseShowAnimation(),
                CloseAnimationType = ParseCloseAnimation()
            };

            if (!string.IsNullOrEmpty(ParseSeverity()))
            {
                options.Severity = (ToastSeverity)Enum.Parse(typeof(ToastSeverity), ParseSeverity());
            }

            if (ForegroundBox.Color.A != 0)
                options.AccentBrush = new SolidColorBrush(ForegroundBox.Color);

            SfToastNotification.Show(this, options);
        }

        private void OnCloseAllClick(object sender, RoutedEventArgs e)
        {
            SfToastNotification.CloseAll();
        }

        // ▼ Helpers — Convert ComboBox string to enums ▼

        private ToastMode ParseMode()
        {
            var item = (ModeCombo.SelectedItem as ComboBoxItem)?.Content.ToString();
            return item == "Screen" ? ToastMode.Screen : ToastMode.Window;
        }

        private string ParseSeverity()
        {   
            return (SeverityCombo.SelectedItem as ComboBoxItemAdv)?.Content.ToString();
        }

        private ToastVariant ParseVariant()
        {
            if (VariantCombo.SelectedItem != null)
            {
                return (ToastVariant)Enum.Parse(typeof(ToastVariant),
                    (VariantCombo.SelectedItem as ComboBoxItemAdv).Content.ToString());
            }
            else
            {
               return ToastVariant.Filled;
            }
        }

        private ToastPlacement ParsePlacement()
        {
            if (PlacementCombo.SelectedItem != null)
            {
                return (ToastPlacement)Enum.Parse(typeof(ToastPlacement),
                    (PlacementCombo.SelectedItem as ComboBoxItem).Content.ToString());
            }
            else
            {
               return ToastPlacement.BottomRight;
            }
        }

        private ToastAnimation ParseShowAnimation()
        {
            if (ShowAnimCombo.SelectedItem != null)
            {
                return (ToastAnimation)Enum.Parse(typeof(ToastAnimation),
                    (ShowAnimCombo.SelectedItem as ComboBoxItem).Content.ToString());
            }
            else
            {
                return ToastAnimation.FadeIn;
            }
        }
        private ToastAnimation ParseCloseAnimation()
        {
            if (CloseAnimCombo.SelectedItem != null)
            {
                return (ToastAnimation)Enum.Parse(typeof(ToastAnimation),
                    (CloseAnimCombo.SelectedItem as ComboBoxItem).Content.ToString());
            }
            else
            {
                return ToastAnimation.FadeOut;
            }
        }

        private void SeverityCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          var item = (ToastSeverity)Enum.Parse(typeof(ToastSeverity), ParseSeverity());
            if (ForegroundBox == null) return;
            if (item != ToastSeverity.None)
                ForegroundBox.IsEnabled = true;
            else
                ForegroundBox.IsEnabled = false;
        }
    }
}
