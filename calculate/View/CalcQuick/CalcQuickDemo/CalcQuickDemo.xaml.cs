#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;
namespace syncfusion.calculatedemos.wpf
{
    /// <summary>
    /// Interaction logic for CalcQuickDemo.xaml
    /// </summary>
    public partial class CalcQuickDemo : DemoControl
    {
        public CalcQuickDemo()
        {
            InitializeComponent();
        }
        public CalcQuickDemo(string themename):base(themename)
        {
            InitializeComponent();
        }

        #region Events

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ManualCalcForm form = new ManualCalcForm();
            SfSkinManagerExtension.SetTheme(this, form);
            form.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AutoCalcForm form = new AutoCalcForm();
            SfSkinManagerExtension.SetTheme(this, form);
            form.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MoreComplexForm form = new MoreComplexForm();
            SfSkinManagerExtension.SetTheme(this, form);
            form.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            AngleForm form = new AngleForm();
            SfSkinManagerExtension.SetTheme(this, form);
            form.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            AutoAngleForm form = new AutoAngleForm();
            SfSkinManagerExtension.SetTheme(this, form);
            form.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            AlgebraicExpressions form = new AlgebraicExpressions();
            SfSkinManagerExtension.SetTheme(this, form);
            form.Show();
        }

        #endregion    
    }
}
