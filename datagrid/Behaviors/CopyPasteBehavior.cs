#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.datagriddemos.wpf
{
    public class CopyPasteBehaviour : Behavior<CutCopyPasteDemo>
    {
        SfDataGrid SfDataGrid;
        ComboBoxAdv CopyCombobox, PasteCombobox;
        TextBox Clipboardtextbox;

        protected override void OnAttached()
        {
            var window = this.AssociatedObject;
            this.SfDataGrid = window.FindName("datagrid") as SfDataGrid;
            this.CopyCombobox = window.FindName("CopyOptionComboBox") as ComboBoxAdv;
            this.PasteCombobox = window.FindName("PasteOptionComboBox") as ComboBoxAdv;
            this.Clipboardtextbox = window.FindName("Clipboardcontent") as TextBox;

            this.SfDataGrid.GridCopyContent += SfDataGrid_GridCopyContent;
            this.CopyCombobox.SelectionChanged += CopyCombobox_SelectionChanged;
            this.PasteCombobox.SelectionChanged += PasteCombobox_SelectionChanged;
        }

        //By using the GridCopyContent event we can able to get the clipboardtext
        void SfDataGrid_GridCopyContent(object sender, GridCopyPasteEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                this.Clipboardtextbox.Text = Clipboard.GetText();
            }));
        }

        //By using combobox selectionchanged event we can able to set the Enum option for Paste based on the combobox selected item
        void PasteCombobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var data = (sender as ComboBoxAdv);
            if (data.SelectedItems != null)
            {
                var selecteditems = data.SelectedItems.Cast<GridPasteOption>().ToList();
                List<string> selecteddata = new List<string>();
                for (int i = 0; i < selecteditems.Count; i++)
                {
                    if (i == 0)
                        this.SfDataGrid.GridPasteOption = selecteditems[i];
                    else
                        this.SfDataGrid.GridPasteOption = this.SfDataGrid.GridPasteOption | selecteditems[i];
                }
            }
        }

        //By using combobox selectionchanged event we can able to set the Enum option for Copy based on the combobox selected item
        void CopyCombobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var data = (sender as ComboBoxAdv);
            if (data.SelectedItems != null)
            {
                var selecteditems = data.SelectedItems.Cast<GridCopyOption>().ToList();
                for (int i = 0; i < selecteditems.Count; i++)
                {
                    if (i == 0)
                        this.SfDataGrid.GridCopyOption = selecteditems[i];
                    else
                        this.SfDataGrid.GridCopyOption = this.SfDataGrid.GridCopyOption | selecteditems[i];
                }
            }
        }
        protected override void OnDetaching()
        {
            this.SfDataGrid.GridCopyContent -= SfDataGrid_GridCopyContent;
            this.CopyCombobox.SelectionChanged -= CopyCombobox_SelectionChanged;
            this.PasteCombobox.SelectionChanged -= PasteCombobox_SelectionChanged;
        }
    }
}
