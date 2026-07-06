using Microsoft.Win32;
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
            if(MaxToastVisibleCountBox.Text != string.Empty)
                SfToastNotification.MaxToastVisibleCount = int.Parse(MaxToastVisibleCountBox.Text);
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
            if(!string.IsNullOrEmpty(ToastSoundPathBox.Text))
            {
                options.ToastSoundPath = new Uri(ToastSoundPathBox.Text, UriKind.Absolute);
            }
            else
            {
                options.ToastSound = ParseToastSound();
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

        private ToastSound ParseToastSound()
        {
            if (ToastSoundCombo.SelectedItem is ComboBoxItem item &&
                     Enum.TryParse(item.Content.ToString(), out ToastSound sound))
            {
                return sound;
            }
            return ToastSound.Beep;
        }


        private void OnBrowseSoundPathClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Toast Sound File",
                Filter = "Audio Files (*.wav;*.mp3)|*.wav;*.mp3|All Files (*.*)|*.*",
                CheckFileExists = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ToastSoundPathBox.Text = openFileDialog.FileName;
            }
        }

    }
}
