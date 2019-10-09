#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Tools.Controls;

namespace TaskBarDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016Colorful);
            InitializeComponent();           
        }
        #endregion

        #region Events
        private void Chkexpanditems_Unchecked(object sender, RoutedEventArgs e)
        {
            chkShowheader.IsEnabled = false;
        }

        private void Chkexpanditems_Checked(object sender, RoutedEventArgs e)
        {
            chkShowheader.IsEnabled = true;
        }

        private void ChkShowheader_Unchecked(object sender, RoutedEventArgs e)
        {
            chkexpanditems.IsEnabled = false;
            TaskBar.SetIsOpened(TaskBar, true);
        }

        private void ChkShowheader_Checked(object sender, RoutedEventArgs e)
        {
            if(chkexpanditems != null)
                chkexpanditems.IsEnabled = true;
        }
        #endregion
    }
}
            
           