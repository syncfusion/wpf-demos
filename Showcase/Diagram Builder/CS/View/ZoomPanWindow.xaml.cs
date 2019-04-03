#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiagramBuilder.View
{
    /// <summary>
    /// Interaction logic for ZoomPanWindow.xaml
    /// </summary>
    public partial class ZoomPanWindow : Window
    {
        public ZoomPanWindow()
        {
            InitializeComponent();
            this.Closed += Zoom_Closed;
            this.Loaded += ZoomPanWindow_Loaded;
       
        }

        void ZoomPanWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Owner = (this.DataContext as DiagramBuilder.MainWindow);

        }

        void Zoom_Closed(object sender, EventArgs e)
        {
            (this.DataContext as DiagramBuilder.MainWindow).Isopen = true;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            IconRemover.RemoveIcon(this);
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var _mRadiobutton = (sender as RadioButton);
            OkButton.IsEnabled = true;
            textbox.IsEnabled = false;
            if (IsDigitsOnly(_mRadiobutton.Content.ToString()))
            {
                percentage.IsChecked = false;
                string _mContent = _mRadiobutton.Content.ToString();
                string _mContent1 = _mContent.Substring(0, _mContent.Length - 1);
                double _mvalue = Convert.ToDouble(_mContent1);
                if (_mRadiobutton.IsChecked == true && _mvalue != 0)
                {
                    textbox.Text = _mvalue.ToString();
                 }

            }
            else if (_mRadiobutton.IsChecked == true && !IsDigitsOnly(_mRadiobutton.Content.ToString()) && _mRadiobutton.Name != "zoom3" && _mRadiobutton.Name != "percentage")
            {
                percentage.IsChecked = false;
                textbox.Text = _mRadiobutton.Name.ToString();
            }
            else if (_mRadiobutton.IsChecked == true && _mRadiobutton.Name == "zoom3")
            {
                percentage.IsChecked = false;
                textbox.Text = _mRadiobutton.CommandParameter.ToString();
            }
            else if (percentage.IsChecked == true)
            {
                textbox.Text = null;
                zoom1.IsChecked = zoom2.IsChecked = zoom3.IsChecked = zoom4.IsChecked = zoom5.IsChecked = width.IsChecked = Page.IsChecked = false;
                textbox.IsEnabled = true;
            }
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char value in str)
            {
                if ((value < '0' || value > '9') && value != '%')
                    return false;
            }

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((this.DataContext as DiagramBuilder.MainWindow).DataContext as DiagramBuilder.ViewModel.DiagramBuilderVM).OnZoomCommand(textbox.Text);
           (this.DataContext as DiagramBuilder.MainWindow).Isopen=true;
            this.Close();
        }


    }
    public static class IconRemover
    {
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr win, int index);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr win, int index, int newStyle);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr win, IntPtr InsertAfter,
                   int x, int y, int width, int height, uint flags);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr win, uint msg,
                     IntPtr wParam, IntPtr lParam);

        const int Exstyle = -20;
        const int Exmodelframe = 0x0001;
        const int Nosize = 0x0001;
        const int Nomove = 0x0002;
        const int Nozorder = 0x0004;
        const int Framechanged = 0x0020;

        public static void RemoveIcon(Window window)
        {
            IntPtr win = new WindowInteropHelper(window).Handle;
            int extendedStyle = GetWindowLong(win, Exstyle);
            SetWindowLong(win, Exstyle, extendedStyle | Exmodelframe);
            SetWindowPos(win, IntPtr.Zero, 0, 0, 0, 0, Nomove |
                  Nosize | Nozorder | Framechanged);
        }
    }
}
