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
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System.Reflection;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace CustomIntellisenseDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCollection<CustomIntellisenseItem> customItems = null;

        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            fontlst.SelectedItem = new FontFamily("Verdana");
            InitializeCustomIntellisenseItems();
            //Changed IntellisenseCommitCharacters property to remove "." from the commit characters to
			//enable usage of "." in intellisense items as in ASP.NET
            editText.CurrentLanguage.IntellisenseCommitCharacters = @"{}[](),:;+-*/%&|^!~=<>?@#'\\""";
			
			//Changed IntellisenseDrillDownChar from '.' to '>' to enable usage of '.' in Intellisense Item
            editText.CurrentLanguage.IntellisenseDrillDownChar = '>';
        }

        private void InitializeCustomIntellisenseItems()
        {
            customItems = new ObservableCollection<CustomIntellisenseItem>();
            customItems.Add(new CustomIntellisenseItem() { Text = "Syncfusion", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/syncfusion.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "ASP.NET", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/aspnet.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "MVC", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/aspnet-mvc.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "BI", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/reporting.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "Silverlight", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/silverlight.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "WinForms", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/winforms.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "WPF", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/wpf.png", UriKind.Relative)) });
            editText.IntellisenseCustomItemsSource = customItems;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            CustomIntellisenseItem item = new CustomIntellisenseItem();
            IntellisenseItemProperties properties = new IntellisenseItemProperties();
            properties.DataContext = item;
            properties.ShowDialog();
            if (item.Text != null && item.Text.Trim() != string.Empty)
            {
                customItems.Add(item);
            }
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (intellisenseItems.SelectedItem != null)
            {
                customItems.Remove(intellisenseItems.SelectedItem as CustomIntellisenseItem);
            }
        }
   
    }

    public class CustomIntellisenseItem : IIntellisenseItem
    {
        #region IIntellisenseItem Members

        public ImageSource Icon
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public IEnumerable<IIntellisenseItem> NestedItems
        {
            get;
            set;
        }

        #endregion
    }
}
