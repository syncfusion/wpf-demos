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

namespace SfTreeNavigator
{
    /// <summary>
    /// Interaction logic for TreeNavigatorDemo.xaml
    /// </summary>
    public partial class TreeNavigatorDemo : UserControl
    {
        public TreeNavigatorDemo()
        {
            InitializeComponent();
        }

        void _Loaded(object sender, RoutedEventArgs e)
        {
            navigation.Items.Add(Syncfusion.Windows.Controls.Navigation.NavigationMode.Default);
            navigation.Items.Add(Syncfusion.Windows.Controls.Navigation.NavigationMode.Extended);
            navigation.SelectedIndex = 1;
            navigation.SelectionChanged -= navigation_SelectionChanged;
            navigation.SelectionChanged += navigation_SelectionChanged;
        }

        void navigation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tree.NavigationMode = (Syncfusion.Windows.Controls.Navigation.NavigationMode)navigation.SelectedItem;
        }
    }
}
