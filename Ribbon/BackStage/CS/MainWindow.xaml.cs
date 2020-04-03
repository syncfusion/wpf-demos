#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Windows.Markup;
using System.IO;
using Microsoft.Win32;
using System.Reflection;

namespace BackStageSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ribbon1.BackStageOpening += new System.ComponentModel.CancelEventHandler(ribbon1_BackStageOpening);
            ribbon1.BackStageClosing += new System.ComponentModel.CancelEventHandler(ribbon1_BackStageClosing);
            ribbon1.ShowBackStage();
            LoadRTB();
        }

        /// <summary>
        /// Loaded RTB method.
        /// </summary>
        private void LoadRTB()
        {
#if NETCORE
            string _fileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\Resources\temp.rtf");
#else
            string _fileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\temp.rtf");
#endif
            TextRange range;
            FileStream fStream;
            if (File.Exists(_fileName))
            {
                range = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd);
                fStream = new FileStream(_fileName, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.Rtf);
                fStream.Close();
            }
        }

        /// <summary>
        /// Indicates the backstage closing method.
        /// </summary>
        /// <param name="sender">Backstage.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        void ribbon1_BackStageClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (BackStageClosingCheckBox.IsChecked == true || BackStageClosingCheckBox1.IsChecked == true || BackStageClosingCheckBox2.IsChecked == true)
                e.Cancel = true;
        }

        /// <summary>
        /// Indicates the backstageopening method.
        /// </summary>
        /// <param name="sender">Backstage.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        void ribbon1_BackStageOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (BackStageOpeningCheckBox.IsChecked == true || BackStageOpeningCheckBox1.IsChecked == true)
                e.Cancel = true;
        }

        /// <summary>
        /// Indicates the backstage button clicking method.
        /// </summary>
        /// <param name="sender">Application</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BackStageButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Method which is used to hide backstage.
        /// </summary>
        /// <param name="sender">Backstage.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ribbon1.HideBackStage();
        }

        /// <summary>
        /// Method which is used to show backstage.
        /// </summary>
        /// <param name="sender">Backstage.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OpenBackStage_Click(object sender, RoutedEventArgs e)
        {
            ribbon1.ShowBackStage();
        }

        /// <summary>
        /// Method which is used to hide backstage.
        /// </summary>
        /// <param name="sender">Backstage.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void HideBackStage_Click(object sender, RoutedEventArgs e)
        {
            ribbon1.HideBackStage();
        }

        /// <summary>
        /// Method which is used to change the backgroud color.
        /// </summary>
        /// <param name="d">Backstage color.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ChangeColor(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ribbon1.BackStageColor = new BrushConverter().ConvertFromString(e.NewValue.ToString()) as SolidColorBrush;
        }
    }
}
