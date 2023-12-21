#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace syncfusion.organizationallayout.wpf.Views
{
    /// <summary>
    /// Interaction logic for Search_Window.xaml
    /// </summary>
    public partial class Search_Window : ChromelessWindow
    {
        public Search_Window()
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
            SearchContent.TextChanged += SearchContent_TextChanged;
        }

        private void SearchContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!(Keyboard.IsKeyDown(Key.Space)))
            {
                if (selectednode != null)
                {
                    selectednode.IsSelected = false;
                    selectednode = null;
                }
                searchednodes = new ObservableCollection<organizationallayoutNode>();
            }
        }

        ObservableCollection<organizationallayoutNode> searchednodes = new ObservableCollection<organizationallayoutNode>();

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            if(SearchContent.Text != null && (!(SearchContent.Text == "")))
            {
                if((FieldCombobox.SelectedItem as ComboBoxItem).Content.ToString() == "Name")
                {
                    foreach(organizationallayoutNode node in (DataContext as SfDiagram).Nodes as ObservableCollection<organizationallayoutNode>)
                    {                        
                        if(node.CustomContent.Name.ToLower().Contains(SearchContent.Text.ToLower()))
                        {
                            searchednodes.Add(node);
                        }
                    }

                    SelectPreviousItem();
                }

                if ((FieldCombobox.SelectedItem as ComboBoxItem).Content.ToString() == "Role")
                {
                    foreach (organizationallayoutNode node in (DataContext as SfDiagram).Nodes as ObservableCollection<organizationallayoutNode>)
                    {
                        if (node.CustomContent.Role.ToLower().Contains(SearchContent.Text.ToLower()))
                        {
                            searchednodes.Add(node);
                        }
                    }

                    SelectPreviousItem();
                }

                if ((FieldCombobox.SelectedItem as ComboBoxItem).Content.ToString() == "EmpID")
                {
                    foreach (organizationallayoutNode node in (DataContext as SfDiagram).Nodes as ObservableCollection<organizationallayoutNode>)
                    {
                        if (node.CustomContent.EmployeeID.ToLower().Contains(SearchContent.Text.ToLower()))
                        {
                            searchednodes.Add(node);
                        }
                    }

                    SelectPreviousItem();
                }

                if ((FieldCombobox.SelectedItem as ComboBoxItem).Content.ToString() == "Team")
                {
                    foreach (organizationallayoutNode node in (DataContext as SfDiagram).Nodes as ObservableCollection<organizationallayoutNode>)
                    {
                        if (node.CustomContent.Team.ToLower().Contains(SearchContent.Text.ToLower()))
                        {
                            searchednodes.Add(node);
                        }
                    }

                    SelectPreviousItem();
                }
            }
        }

        organizationallayoutNode selectednode = null;

        private void SelectPreviousItem()
        {
            foreach(organizationallayoutNode node in searchednodes)
            {
                if(node.IsSelected)
                {
                    selectednode = node;
                }
            }

            if (searchednodes.Count > 0)
            {
                if (selectednode == null)
                {
                    searchednodes.ElementAt(0).IsSelected = true;
                    selectednode = searchednodes.ElementAt(0);
                    (selectednode.Info as INodeInfo).BringIntoViewport();
                }
                else
                {
                    int index = searchednodes.IndexOf(selectednode);
                    if (index == 0)
                    {
                        selectednode.IsSelected = false;
                        searchednodes.Last().IsSelected = true;
                        selectednode = searchednodes.Last();
                        (selectednode.Info as INodeInfo).BringIntoViewport();
                    }
                    else
                    {
                        selectednode.IsSelected = false;
                        searchednodes.ElementAt(index - 1).IsSelected = true;
                        selectednode = searchednodes.ElementAt(index - 1);
                        (selectednode.Info as INodeInfo).BringIntoViewport();
                    }
                }
            }
        }

        private void RibbonButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (SearchContent.Text != null && (!(SearchContent.Text == "")))
            {
                if ((FieldCombobox.SelectedItem as ComboBoxItem).Content.ToString() == "Name")
                {
                    foreach (organizationallayoutNode node in (DataContext as SfDiagram).Nodes as ObservableCollection<organizationallayoutNode>)
                    {
                        if (node.CustomContent.Name.ToLower().Contains(SearchContent.Text.ToLower()))
                        {
                            searchednodes.Add(node);
                        }
                    }

                    SelectNextItem();
                }

                if ((FieldCombobox.SelectedItem as ComboBoxItem).Content.ToString() == "Role")
                {
                    foreach (organizationallayoutNode node in (DataContext as SfDiagram).Nodes as ObservableCollection<organizationallayoutNode>)
                    {
                        if (node.CustomContent.Role.ToLower().Contains(SearchContent.Text.ToLower()))
                        {
                            searchednodes.Add(node);
                        }
                    }

                    SelectNextItem();
                }

                if ((FieldCombobox.SelectedItem as ComboBoxItem).Content.ToString() == "EmpID")
                {
                    foreach (organizationallayoutNode node in (DataContext as SfDiagram).Nodes as ObservableCollection<organizationallayoutNode>)
                    {
                        if (node.CustomContent.EmployeeID.ToLower().Contains(SearchContent.Text.ToLower()))
                        {
                            searchednodes.Add(node);
                        }
                    }

                    SelectNextItem();
                }

                if ((FieldCombobox.SelectedItem as ComboBoxItem).Content.ToString() == "Team")
                {
                    foreach (organizationallayoutNode node in (DataContext as SfDiagram).Nodes as ObservableCollection<organizationallayoutNode>)
                    {
                        if (node.CustomContent.Team.ToLower().Contains(SearchContent.Text.ToLower()))
                        {
                            searchednodes.Add(node);
                        }
                    }

                    SelectNextItem();
                }
            }
        }

        private void SelectNextItem()
        {
            foreach (organizationallayoutNode node in searchednodes)
            {
                if (node.IsSelected)
                {
                    selectednode = node;
                }
            }

            if (searchednodes.Count > 0)
            {
                if (selectednode == null)
                {
                    searchednodes.ElementAt(0).IsSelected = true;
                    selectednode = searchednodes.ElementAt(0);
                    (selectednode.Info as INodeInfo).BringIntoViewport();
                }
                else
                {
                    int index = searchednodes.IndexOf(selectednode);
                    if (index == searchednodes.Count - 1)
                    {
                        selectednode.IsSelected = false;
                        searchednodes.First().IsSelected = true;
                        selectednode = searchednodes.First();
                        (selectednode.Info as INodeInfo).BringIntoViewport();
                    }
                    else
                    {
                        selectednode.IsSelected = false;
                        searchednodes.ElementAt(index + 1).IsSelected = true;
                        selectednode = searchednodes.ElementAt(index + 1);
                        (selectednode.Info as INodeInfo).BringIntoViewport();
                    }
                }
            }
        }
    }
}
