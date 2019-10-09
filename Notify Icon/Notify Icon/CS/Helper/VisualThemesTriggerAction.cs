#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace NotifyIcon_2008
{
    public class VisualThemesTriggerAction : TargetedTriggerAction<ComboBox>
    {
        /// <summary>
        /// Invokes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected override void Invoke(object parameter)
        {
            var cb = this.AssociatedObject as ComboBox;
            Window win = VisualUtils.FindAncestor(cb, typeof(Window)) as Window;
            // Apply Visual Style based on the selected theme
            if (win != null && cb != null)
            {
                switch (cb.SelectedItem.ToString())
                {
                    case "Metro":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Metro);
                        break;
                    case "Blend":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Blend);
                        break;
                    case "Lime":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Lime);
                        break;
                    case "Saffron":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Saffron);
                        break;
                    case "Office365":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office365);
                        break;
                    case "Office2016Colorful":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office2016Colorful);
                        break;
                    case "Office2016DarkGray":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office2016DarkGray);
                        break;
                    case "Office2016White":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office2016White);
                        break;
                    case "VisualStudio2013":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.VisualStudio2013);
                        break;
                    case "Office2013DarkGray":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office2013DarkGray);
                        break;
                    case "Office2013LightGray":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office2013LightGray);
                        break;
                    case "Office2013White":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office2013White);
                        break;
                    case "Office2010Blue":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office2010Blue);
                        break;
                    case "Office2010Black":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office2010Black);
                        break;
                    case "Office2010Silver":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Office2010Silver);
                        break;
                    case "VisualStudio2015":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.VisualStudio2015);
                        break;
                    case "SystemTheme":
                        SfSkinManager.SetVisualStyle(win, VisualStyles.SystemTheme);
                        break;
                    default:
                        SfSkinManager.SetVisualStyle(win, VisualStyles.Default);
                        break;
                }
            }
        }
    }
}
