#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
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

namespace DataBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridArea != null)
            {
                if (!(dataGridArea.Content is ListViewPage) && ((ComboBoxItem)e.AddedItems[0]).Content.Equals("Binding List"))
                    dataGridArea.Content = new ListViewPage();

                if (!(dataGridArea.Content is ObservableCollectionPage) && ((ComboBoxItem)e.AddedItems[0]).Content.Equals("Observable Collection"))
                    dataGridArea.Content = new ObservableCollectionPage();

                if (!(dataGridArea.Content is DynamicObjectsPage) && ((ComboBoxItem)e.AddedItems[0]).Content.Equals("Dynamic Objects"))
                    dataGridArea.Content = new DynamicObjectsPage();

                if (!(dataGridArea.Content is DataTablePage) && ((ComboBoxItem)e.AddedItems[0]).Content.Equals("Data Table"))
                    dataGridArea.Content = new DataTablePage();
            }
        }
    }
}
