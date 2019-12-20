#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace ComboBoxAdv_Demo
{
   public class Behavior : Behavior<ComboBoxAdv>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.SelectionChanged += OnAssociatedObject_SelectionChanged;
        }

        private void OnAssociatedObject_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                SfSkinManager.SetVisualStyle(Application.Current.MainWindow, (VisualStyles)Enum.Parse(typeof(VisualStyles), ((sender as ComboBoxAdv).SelectedItem as ComboBoxItemAdv).Content.ToString()));
            }

            catch (NullReferenceException) { }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.SelectionChanged -= OnAssociatedObject_SelectionChanged;
        }
    }
}
