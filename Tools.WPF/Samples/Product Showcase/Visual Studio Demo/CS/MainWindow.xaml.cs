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
using System.IO;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Tools.Controls;

namespace VS2010DockingManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnActivateWindow(object sender, RoutedEventArgs e)
        {
            string name = (sender as MenuItemAdv).Tag as string;
            dockingManager.ActivateWindow(name);
        }
    }

    
}
