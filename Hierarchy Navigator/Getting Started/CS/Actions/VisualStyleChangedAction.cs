#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace HierarchyNavigator_2008
{
    /// <summary>
    /// Represents the action for visual style changes.
    /// </summary>
    class VisualStyleChangedAction : TargetedTriggerAction<ComboBox>
    {
        /// <summary>
        /// Invokes the specified parameter.
        /// </summary>
        /// <param name="parameter">Combobox as the parameter</param>
        protected override void Invoke(object parameter)
        {
            var comboBox = this.AssociatedObject as ComboBox;
            Window window = VisualUtils.FindAncestor(comboBox, typeof(Window)) as Window;
            // Apply Visual Style based on the selected theme
            if (window != null && comboBox != null)
            {
                switch (comboBox.SelectedItem.ToString())
                {
                    case "Metro":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Metro);
                        break;
                    case "Blend":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Blend);
                        break;
                    case "Lime":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Lime);
                        break;
                    case "Saffron":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Saffron);
                        break;
                    case "Office365":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office365);
                        break;
                    case "Office2016Colorful":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office2016Colorful);
                        break;
                    case "Office2016DarkGray":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office2016DarkGray);
                        break;
                    case "Office2016White":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office2016White);
                        break;
                    case "VisualStudio2013":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.VisualStudio2013);
                        break;
                    case "Office2013DarkGray":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office2013DarkGray);
                        break;
                    case "Office2013LightGray":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office2013LightGray);
                        break;
                    case "Office2013White":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office2013White);
                        break;
                    case "Office2010Blue":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office2010Blue);
                        break;
                    case "Office2010Black":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office2010Black);
                        break;
                    case "Office2010Silver":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Office2010Silver);
                        break;
                    case "VisualStudio2015":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.VisualStudio2015);
                        break;
                    case "SystemTheme":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.SystemTheme);
                        break;
                    case "Material Light":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.MaterialLight);
                        break;
                    case "Material Light Blue":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.MaterialLightBlue);
                        break;
                    case "Material Dark":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.MaterialDark);
                        break;
                    case "Material Dark Blue":
                        SfSkinManager.SetVisualStyle(window, VisualStyles.MaterialDarkBlue);
                        break;
                    default:
                        SfSkinManager.SetVisualStyle(window, VisualStyles.Default);
                        break;
                }
            }
        }
    }
}
