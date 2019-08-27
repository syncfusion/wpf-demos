#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Windows.Threading;
using Syncfusion.SfSkinManager;

namespace WizardSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
        }

        #endregion

        #region Event

        /// <summary>
        /// Event occurs when selection changed in wizard pages
        /// </summary>
        private void wizardControl_SelectedPageChanged(object sender, RoutedEventArgs e)
        {
            if (wizardControl.SelectedWizardPage == wizPage3)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    txtName.Focus();
                }));
            }
            if (wizardControl.SelectedWizardPage == wizPage4)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    txtPageName.Focus();
                }));
            }
        }
        #endregion
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Content.ToString())
            {
                case "Belnd":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Blend);
                    break;
                case "Lime":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Lime);
                    break;
                case "Metro":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Metro);
                    break;
                case "Office2010Black":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office2010Black);
                    break;
                case "Office2010Blue":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office2010Blue);
                    break;
                case "Office2010Silver":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office2010Silver);
                    break;
                case "Office2013DarkGray":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office2013DarkGray);
                    break;
                case "Office2013LightGray":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office2013LightGray);
                    break;
                case "Office2013White":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office2013White);
                    break;
                case "Office2016Blue":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016Colorful);
                    break;
                case "Office2016DarkGray":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016DarkGray);
                    break;
                case "Office2016White":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016White);
                    break;
                case "Office365":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Office365);
                    break;
                case "Saffron":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Saffron);
                    break;
                case "VisualStudio2013":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.VisualStudio2013);
                    break;
                case "VisualStudio2015":
                    SfSkinManager.SetVisualStyle(this, VisualStyles.VisualStudio2015);
                    break;
                default:
                    SfSkinManager.SetVisualStyle(this, VisualStyles.Default);
                    break;
            }

        }

       
    }
}

