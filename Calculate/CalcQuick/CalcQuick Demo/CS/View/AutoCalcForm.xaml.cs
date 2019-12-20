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
    /// Interaction logic for AutoCalcForm.xaml
    /// </summary>
    public partial class AutoCalcForm : ChromelessWindow
    {
        #region API Definition
        CalcQuick calculator = null;
        #endregion

        #region Constructor

        public AutoCalcForm()
        {
            InitializeComponent();
        }

        #endregion             

        #region Event Handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //1) Instantiate a CalcQuick object:
            calculator = new CalcQuick();

            //2) Populate your controls:
            this.txtA.Text = "12";
            this.txtB.Text = "3";
            this.txtC.Text = "= [A] + 2 * [B]";

            //C is the only formula:
            this.lblc.Content= this.txtC.Text;


            //Must enter formula names before turning on calculations.
            //3) Assign formula object names:
            calculator["A"] = this.txtA.Text;
            calculator["B"] = this.txtB.Text;
            calculator["C"] = this.txtC.Text;
            calculator["D"] = this.txtD.Text;

            //4) Turn on auto calculations:
            this.calculator.AutoCalc = true;

            //5) Subscribe to the event to set newly calculated values:
            this.calculator.ValueSet += new QuickValueSetEventHandler(calculator_ValueSet);

            //6) Subscribe to some events (in this case, Leave events) to trigger setting values into CalcQuick:
            this.txtA.LostFocus += new RoutedEventHandler(txtA_MouseLeave);
            this.txtB.LostFocus += new RoutedEventHandler(txtB_MouseLeave);
            this.txtC.LostFocus += new RoutedEventHandler(txtC_MouseLeave);
            this.txtD.LostFocus += new RoutedEventHandler(txtD_MouseLeave);

            //7) Allow the CalcQuick sheet to create dependency lists among the formula objects
            //   necesary for auto-calculations.
            this.calculator.RefreshAllCalculations();
        }

        void txtD_MouseLeave(object sender, RoutedEventArgs e)
        {
            calculator["D"] = this.txtD.Text;
            this.lbld.Content = this.calculator.GetFormula("D");
            this.txtD.AcceptsTab = false;
        }

        void txtC_MouseLeave(object sender, RoutedEventArgs e)
        {
            calculator["C"] = this.txtC.Text;
            this.lblc.Content = this.calculator.GetFormula("C");
            this.txtC.AcceptsTab = false;
        }

        void txtB_MouseLeave(object sender, RoutedEventArgs e)
        {
            calculator["B"] = this.txtB.Text;
            this.lblb.Content = this.calculator.GetFormula("B");
            this.txtB.AcceptsTab = false;
        }

        void txtA_MouseLeave(object sender, RoutedEventArgs e)
        {
            calculator["A"] = this.txtA.Text;
            this.lbla.Content = this.calculator.GetFormula("A");
            this.txtA.AcceptsTab = false;
        }

        // Raised when a value is calculated:
        private void calculator_ValueSet(object sender, QuickValueSetEventArgs e)
        {
            //	if(e.Action == FormulaInfoSetAction.CalculatedValueSet)
            {
                switch (e.Key)
                {
                    case "A":
                        this.txtA.Text = this.calculator[e.Key].ToString();
                        break;
                    case "B":
                        this.txtB.Text = this.calculator[e.Key].ToString();
                        break;
                    case "C":
                        this.txtC.Text = this.calculator[e.Key].ToString();
                        break;
                    case "D":
                        this.txtD.Text = this.calculator[e.Key].ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ChromelessWindow_Closed(object sender, EventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
        }
        #endregion
    }
}
