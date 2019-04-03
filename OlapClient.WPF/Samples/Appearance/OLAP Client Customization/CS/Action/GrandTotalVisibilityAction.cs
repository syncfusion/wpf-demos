#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace OLAPClientCustomization.Action
{
    using Syncfusion.Windows.Client.Olap;
    using System.Windows.Interactivity;
    using System.Windows;
    using System.Windows.Controls;

    class GrandTotalVisibilityAction : TargetedTriggerAction<OlapClient>
    {
        #region Methods

        protected override void Invoke(object parameter)
        {
            RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
            if (eventArgs != null)
            {
                CheckBox chkBox = eventArgs.OriginalSource as CheckBox;
                if (chkBox != null && chkBox.IsChecked != null)
                {
                    this.Target.OlapGrid.ShowGrandTotals = (bool)chkBox.IsChecked;
                }
            }
        }

        #endregion
    }
}