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


namespace BackStageSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ribbon1.BackStageOpening += new System.ComponentModel.CancelEventHandler(ribbon1_BackStageOpening);
            ribbon1.BackStageClosing += new System.ComponentModel.CancelEventHandler(ribbon1_BackStageClosing);
            ribbon1.ShowBackStage();
           
        }

        void ribbon1_BackStageClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (BackStageClosingCheckBox.IsChecked == true || BackStageClosingCheckBox1.IsChecked == true || BackStageClosingCheckBox2.IsChecked == true)
                e.Cancel = true;
        }


        void ribbon1_BackStageOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (BackStageOpeningCheckBox.IsChecked == true || BackStageOpeningCheckBox1.IsChecked == true)
                e.Cancel = true;
        }

        private void BackStageButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ribbon1.HideBackStage();
        }

        private void OpenBackStage_Click(object sender, RoutedEventArgs e)
        {
            ribbon1.ShowBackStage();
        }

        private void HideBackStage_Click(object sender, RoutedEventArgs e)
        {
            ribbon1.HideBackStage();
        }

        private void ChangeColor(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ribbon1.BackStageColor = new BrushConverter().ConvertFromString(e.NewValue.ToString()) as SolidColorBrush;
        }
    }
}
