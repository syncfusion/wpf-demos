#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
                switch (((sender as ComboBoxAdv).SelectedItem as ComboBoxItemAdv).Content.ToString())
                {
                    case "Metro":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Metro);
                        break;
                    case "Blend":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Blend);
                        break;
                    case "Lime":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Lime);
                        break;
                    case "Material Light":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.MaterialLight);
                        break;
                    case "Material Light Blue":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.MaterialLightBlue);
                        break;
                    case "Material Dark":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.MaterialDark);
                        break;
                    case "Material Dark Blue":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.MaterialDarkBlue);
                        break;
                    case "Office2016Colorful":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office2016Colorful);
                        break;
                    case "Office2016DarkGray":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office2016DarkGray);
                        break;
                    case "Office2016White":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office2016White);
                        break;
                    case "VisualStudio2013":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.VisualStudio2013);
                        break;
                    case "Office2013DarkGray":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office2013DarkGray);
                        break;
                    case "Office2013LightGray":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office2013LightGray);
                        break;
                    case "Office2013White":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office2013White);
                        break;
                    case "Office2010Blue":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office2010Blue);
                        break;
                    case "Office2010Black":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office2010Black);
                        break;
                    case "Office2010Silver":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office2010Silver);
                        break;
                    case "Office365":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Office365);
                        break;
                    case "Saffron":
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Saffron);
                        break;
                    
                    default:
                        SfSkinManager.SetVisualStyle(Application.Current.MainWindow, VisualStyles.Default);
                        break;
                }
            }

            catch (NullReferenceException) { }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.SelectionChanged -= OnAssociatedObject_SelectionChanged;
        }
    }
}
