using Syncfusion.UI.Xaml.NavigationDrawer;
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

namespace GettingStarted
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public SfNavigationDrawer NavigationDrawer { get; set; }
        public Home()
        {
            InitializeComponent();
        }
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationDrawer != null)
            {
                if (NavigationDrawer.IsOpen)
                    NavigationDrawer.ToggleDrawer();
                else
                {
                    NavigationDrawer.ToggleDrawer();
                }
            }
        }
    }
}
