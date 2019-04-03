#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.Grid;

namespace VisualStylesDemo
{
    public class VisualThemesTriggerAction : TargetedTriggerAction<ComboBox>
    {
        SfTreeGrid grid = (Application.Current.MainWindow as VisualStylesDemo.MainWindow).treeGrid;

        /// <summary>
        /// Invokes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected override void Invoke(object parameter)
        {
            var cb = this.AssociatedObject as ComboBox;
            // Apply Visual Style based on the selected theme
            switch (cb.SelectedItem.ToString())
            {
                case "Metro":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Metro);
                    break;
                case "Blend":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Blend);
                    break;
                case "Lime":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Lime);
                    break;
                case "Saffron":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Saffron);
                    break;
                case "Office365":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office365);
                    break;
                case "Office2016Colorful":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office2016Colorful);
                    break;
                case "Office2016DarkGray":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office2016DarkGray);
                    break;
                case "Office2016White":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office2016White);
                    break;
                case "VisualStudio2013":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.VisualStudio2013);
                    break;
                case "Office2013DarkGray":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office2013DarkGray);
                    break;
                case "Office2013LightGray":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office2013LightGray);
                    break;
                case "Office2013White":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office2013White);
                    break;
                case "Office2010Blue":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office2010Blue);
                    break;
                case "Office2010Black":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office2010Black);
                    break;
                case "Office2010Silver":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Office2010Silver);
                    break;                
                case "VisualStudio2015":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.VisualStudio2015);
                    break;
                case "SystemTheme":
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.SystemTheme);
                    break;
                default:
                    SfSkinManager.SetVisualStyle(grid, VisualStyles.Default);
                    break;
            }
        }
    }
}
