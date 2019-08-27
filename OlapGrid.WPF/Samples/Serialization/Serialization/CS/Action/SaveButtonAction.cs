#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Serialization.Action
{
    using System;
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Grid.Olap;
    using Microsoft.Win32;
    using System.Windows;
    using System.Windows.Controls;

    public class SaveButtonAction : TargetedTriggerAction<OlapGrid>
    {
        protected override void Invoke(object parameter)
        {
            if(((parameter as RoutedEventArgs).Source as Button).Name == "saveBtn")
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = "Report Set";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.DefaultExt = "xml";
                    saveFileDialog.Filter = "Report Set (.xml)|*.xml";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        this.Target.OlapDataManager.CurrentReport.GridSettings = this.Target.GridSettings;
                        this.Target.OlapDataManager.SaveReport(saveFileDialog.FileName);

                        MessageBox.Show("Report has been saved successfully.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error while serializing.\nException Message:" + ex.Message, "Error on serialization.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }

    class CheckBoxUncheckedTriggerAction : TargetedTriggerAction<OlapGrid>
    {
        protected override void Invoke(object parameter)
        {
            if(!(bool)((parameter as RoutedEventArgs).OriginalSource as CheckBox).IsChecked)
            {
                this.Target.Background = null;
            }
        }
    }
}