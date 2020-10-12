// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZoomPanWindow.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for ZoomPanWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using syncfusion.diagrambuilder.wpf;
    using DiagramBuilder.Model;
    using DiagramBuilder.ViewModel;

    /// <summary>
    ///     Interaction logic for ZoomPanWindow.xaml
    /// </summary>
    public partial class ZoomPanWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ZoomPanWindow" /> class.
        /// </summary>
        public ZoomPanWindow()
        {
            this.InitializeComponent();
            this.Closed += this.Zoom_Closed;
            this.Loaded += this.ZoomPanWindow_Loaded;
        }

        /// <summary>
        /// This method is used to remove the icon.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnSourceInitialized(EventArgs e)
        {
            IconRemover.RemoveIcon(this);
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
            ZoomParameter param = ((this.DataContext as DiagramBuilderDemo).DataContext as DiagramBuilderVM).ZoomParameter;
            param.PercentageText = this.textbox.Text;
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
            else if (this.textbox.Text == "Width")
            {
                param.IsPageWidthZoom = true;
            }
            else if (this.textbox.Text == "Page")
            {
                param.IsWholePageZoom = true;
            }
            else
            {
                param.IsPercentageZoom = true;
            }

            ((this.DataContext as DiagramBuilderDemo).DataContext as DiagramBuilderVM).OnZoomCommand(this.textbox.Text);
            ((this.DataContext as DiagramBuilderDemo).DataContext as DiagramBuilderVM).Isopen = true;
            this.Close();
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
                this.textbox.Text = _mRadiobutton.Name;
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
                                                       this.Width.IsChecked = this.Page.IsChecked = false;
                this.textbox.IsEnabled = true;
            }
        }

        /// <summary>
        /// This event will triggers when zoom pan window is closed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Zoom_Closed(object sender, EventArgs e)
        {
            ((this.DataContext as DiagramBuilderDemo).DataContext as DiagramBuilderVM).Isopen = true;
        }

        /// <summary>
        /// This event will triggers when zoom pan window is loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ZoomPanWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Owner = this.DataContext as DiagramBuilderDemo;
        }
    }
}