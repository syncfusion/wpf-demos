#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Gantt;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace Predecessors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ValidationModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var validationMode = (sender as ComboBox).SelectedItem.ToString();
            Gantt.ValidationMode = (Mode)Enum.Parse(typeof(Mode), validationMode);
        }
    }
}
