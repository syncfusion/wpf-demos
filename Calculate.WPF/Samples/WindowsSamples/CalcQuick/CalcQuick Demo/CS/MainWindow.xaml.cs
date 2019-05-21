#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows.Forms;
using Syncfusion.Windows.Shared;

namespace FirstSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Events

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ManualCalcForm f = new ManualCalcForm();
            this.Close();
            f.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AutoCalcForm f = new AutoCalcForm();
            this.Close();
            f.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MoreComplexForm f = new MoreComplexForm();
            this.Close();
            f.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            AngleForm f = new AngleForm();
            this.Close();
            f.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            AutoAngleForm f = new AutoAngleForm();
            this.Close();
            f.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            AlgebraicExpressions f = new AlgebraicExpressions();
            this.Close();
            f.Show();
        }

        #endregion    
    }
}
