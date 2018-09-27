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
using Syncfusion.Windows.Shared;

namespace TimeSpanEditor
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
          
            
        }

        #endregion

        private void readonly_Click(object sender, RoutedEventArgs e)
        {
            if (myTimeSpanEdit.IsEnabled)
                myTimeSpanEdit.IsEnabled = false;
            else
                myTimeSpanEdit.IsEnabled = true;

        }

        private void txtnullstring_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtnullstring.IsFocused)
            {
                if (txtnullstring.Text == "Type Here")
                {
                    txtnullstring.Text = "";
                    txtnullstring.Foreground = Brushes.Black;
                }
            }
        }

        private void txtnullstring_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtnullstring.Text == "")
            {
                txtnullstring.Text = "Type Here";
                txtnullstring.Foreground = Brushes.LightGray;
            }
        }
    }
}
