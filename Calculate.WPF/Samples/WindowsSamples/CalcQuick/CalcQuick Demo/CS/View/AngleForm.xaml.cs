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
using System.Windows.Shapes;
using Syncfusion.Calculate;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Calculate;

namespace FirstSample
{
    /// <summary>
    /// Interaction logic for AngleForm.xaml
    /// </summary>
    public partial class AngleForm : ChromelessWindow
    {
        #region Constructor

        public AngleForm()
        {
            InitializeComponent();
        }

        #endregion

        #region API Definition

        //Initialize Calculator
        CalcQuick calculator = new CalcQuick();

        #endregion

        #region Event Handler

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Let the calculator know the values / formulas 
            //by using an indexer on the calculator object.
            //Here we are using the text box names as the indexer keys
            //provided to the calculator object. This is not required.
            //The only restrictions for the indexer key values are that they 
            //unique nonempty strings.
            this.calculator["Angle"] = this.Angle.Text;
            this.calculator["cosTB"] = this.cosTB.Text;
            this.calculator["sinTB"] = this.sinTB.Text;

            //Mark the calculator dirty:
            this.calculator.SetDirty();

            //Now as the values are retrieved from the calculator, they
            //will be the newly calculated values.
            this.cosTB.Text = this.calculator["cosTB"];
            this.sinTB.Text = this.calculator["sinTB"];
        }

        private void ChromelessWindow_Closed(object sender, EventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
        }
        #endregion      
    }
}
