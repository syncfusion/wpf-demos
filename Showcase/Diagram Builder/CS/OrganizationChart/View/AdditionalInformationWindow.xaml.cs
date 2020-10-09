#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Windows.Shapes;

namespace OrganizationChart.View
{
    /// <summary>
    /// Interaction logic for AdditionalInformationWindow.xaml
    /// </summary>
    public partial class AdditionalInformationWindow : Window
    {
        public List<string> Annotations = new List<string>();
        public string Annotation;

        public AdditionalInformationWindow()
        {
            InitializeComponent();
            this.Loaded += AdditionalInformationWindow_Loaded;
        }

        private void AdditionalInformationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            foreach (string checkboxname in Annotations as List<string>)
            {
                for (int j = 0; j <= listbox.Items.Count - 1; j++)
                {
                    CheckBox checkbox = listbox.Items[j] as CheckBox;
                    if (checkbox.Name == checkboxname)
                    {
                        listbox.Items.Remove(checkbox);
                        listbox.Items.Insert(i, checkbox);
                        checkbox.IsChecked = true;
                        i++;
                    }
                }
            }

            if(Annotation != "Name")
            {
                foreach(ComboBoxItem item in combobox.Items as ItemCollection)
                {
                    if(item.Content.ToString() == Annotation)
                    {
                        combobox.SelectedItem = item;
                    }
                }
            }

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Annotations.Clear();
            foreach (CheckBox checkbox in listbox.Items as ItemCollection)
            {
                if (checkbox.IsChecked == true)
                {
                    Annotations.Add(checkbox.Name.ToString());
                }
            }

            Annotation = (combobox.SelectedItem as ComboBoxItem).Content.ToString();

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedItem != null)
            {
                CheckBox check = listbox.SelectedItem as CheckBox;
                int selectedindex = listbox.SelectedIndex;
                if (selectedindex != 0)
                {
                    listbox.Items.Remove(check);
                    listbox.Items.Insert(selectedindex - 1, check);
                    listbox.SelectedItem = check;
                }
            }
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedItem != null)
            {
                CheckBox check = listbox.SelectedItem as CheckBox;
                int itemscount = listbox.Items.Count;
                int selectedindex = listbox.SelectedIndex;
                if (selectedindex != itemscount - 1)
                {
                    listbox.Items.Remove(check);
                    listbox.Items.Insert(selectedindex + 1, check);
                    listbox.SelectedItem = check;
                }
            }
        }
    }
}
