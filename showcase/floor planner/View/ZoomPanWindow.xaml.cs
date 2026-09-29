namespace syncfusion.floorplanner.wpf
{
    using Syncfusion.SfSkinManager;
    using Syncfusion.Windows.Shared;
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    ///     Interaction logic for ZoomPanWindow.xaml
    /// </summary>
    public partial class ZoomPanWindow : ChromelessWindow
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ZoomPanWindow" /> class.
        /// </summary>
        public ZoomPanWindow()
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
            this.InitializeComponent();
        }

        /// <summary>
        /// The button_ click method will zoom the diagram based on percentage.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZoomParameter param = (this.DataContext as FloorPlannerViewModel).ZoomParameter;
            var button = sender as Button;
            if (button.Content.ToString() == "Cancel")
            {
                this.textbox.Text = param.PercentageText;
            }
            else
            {
                param.PercentageText = this.textbox.Text;
            }
            if (this.textbox.Text == "200")
            {
                param.IsTwoHundredPercentZoom = true;
            }
            else if (this.textbox.Text == "150")
            {
                param.IsOneFiftyPercentZoom = true;
            }
            else if (this.textbox.Text == "100")
            {
                param.IsHundredPercentZoom = true;
            }
            else if (this.textbox.Text == "75")
            {
                param.IsSeventyFivePercentZoom = true;
            }
            else if (this.textbox.Text == "50")
            {
                param.IsFiftyPercentZoom = true;
            }
            else if (this.textbox.Text == "Page Width")
            {
                param.IsPageWidthZoom = true;
            }
            else if (this.textbox.Text == "Whole Page")
            {
                param.IsWholePageZoom = true;
            }
            else
            {
                param.IsPercentageZoom = true;
            }

            (this.DataContext as FloorPlannerViewModel).OnZoomCommand(this.textbox.Text);
            this.DialogResult = true;
        }

        /// <summary>
        /// This method will zoom the diagram based on the values.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsDigitsOnly(string str)
        {
            foreach (char value in str)
            {
                if ((value < '0' || value > '9') && value != '%')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// The radio button_ checked method will show the parameter values.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton _mRadiobutton = sender as RadioButton;
            this.OkButton.IsEnabled = true;
            this.textbox.IsEnabled = false;
            if (this.IsDigitsOnly(_mRadiobutton.Content.ToString()))
            {
                this.percentage.IsChecked = false;
                string _mContent = _mRadiobutton.Content.ToString();
                string _mContent1 = _mContent.Substring(0, _mContent.Length - 1);
                double _mValue = Convert.ToDouble(_mContent1);
                if (_mRadiobutton.IsChecked == true && _mValue != 0)
                {
                    this.textbox.Text = _mValue.ToString();
                }
            }
            else if (_mRadiobutton.IsChecked == true && !this.IsDigitsOnly(_mRadiobutton.Content.ToString())
                                                     && _mRadiobutton.Name != "zoom3"
                                                     && _mRadiobutton.Name != "percentage")
            {
                this.percentage.IsChecked = false;
                this.textbox.Text = _mRadiobutton.Content.ToString();
            }
            else if (_mRadiobutton.IsChecked == true && _mRadiobutton.Name == "zoom3")
            {
                this.percentage.IsChecked = false;
                this.textbox.Text = _mRadiobutton.CommandParameter.ToString();
            }
            else if (this.percentage.IsChecked == true)
            {
                this.textbox.Text = null;
                this.zoom1.IsChecked = this.zoom2.IsChecked =
                                           this.zoom3.IsChecked =
                                               this.zoom4.IsChecked =
                                                   this.zoom5.IsChecked =
                                                       this.PageWidth.IsChecked = this.Page.IsChecked = false;
                this.textbox.IsEnabled = true;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}