#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace DataBindingDemo
{
    public class TriggerAction : TargetedTriggerAction<ComboBox>
    {

        Frame dataGridArea = (App.Current.MainWindow as MainWindow).dataGridArea; 

        /// <summary>
        /// Invokes the trigger action
        /// </summary>
        protected override void Invoke(object parameter)
        {
            var selectedItem = (this.AssociatedObject as ComboBox).SelectedItem as ComboBoxItem;
            if (dataGridArea != null)
            {
                if (!(dataGridArea.Content is ListViewPage) && selectedItem.Content.ToString().Equals("Binding List"))
                    dataGridArea.Content = new ListViewPage();

                if (!(dataGridArea.Content is ObservableCollectionPage) && selectedItem.Content.ToString().Equals("Observable Collection"))
                    dataGridArea.Content = new ObservableCollectionPage();

                if (!(dataGridArea.Content is DynamicObjectsPage) && selectedItem.Content.ToString().Equals("Dynamic Objects"))
                    dataGridArea.Content = new DynamicObjectsPage();

                if (!(dataGridArea.Content is DataTablePage) && selectedItem.Content.ToString().Equals("Data Table"))
                    dataGridArea.Content = new DataTablePage();

            }
        }
    }
}
