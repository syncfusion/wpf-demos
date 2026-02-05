#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using Syncfusion.Windows.Shared;

namespace syncfusion.calculatedemos.wpf
{
    /// <summary>
    /// Interaction logic for ManualCalcForm.xaml
    /// </summary>
    public partial class ManualCalcForm : ChromelessWindow
    {
        #region Constructor

        public ManualCalcForm()
        {
            InitializeComponent();
        }

        //public ManualCalcForm(string themeName)
        //{
        //    SfSkinManager.SetTheme(this, new Theme() { ThemeName = themeName });
        //    InitializeComponent();
        //}

        #endregion

        //Initialize Calculator 
        CalcQuick calculator = null;

        #region Event Handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            calculator = new CalcQuick();

            this.txtA.Text = "12";
            this.txtB.Text = "=[A] + [C]";
            this.txtC.Text = "13";
        }

        private void butCalc_Click(object sender, RoutedEventArgs e)
        {
            calculator["A"] = this.txtA.Text;
            calculator["B"] = this.txtB.Text;
            calculator["C"] = this.txtC.Text;
            calculator["D"] = this.txtD.Text;

            calculator.SetDirty();

            this.txtA.Text = calculator["A"].ToString();
            this.txtB.Text = calculator["B"].ToString();
            this.txtC.Text = calculator["C"].ToString();
            this.txtD.Text = calculator["D"].ToString();
        }

        private void butForm_Click(object sender, RoutedEventArgs e)
        {
            this.txtA.Text = calculator.GetFormula("A");
            this.txtB.Text = calculator.GetFormula("B");
            this.txtC.Text = calculator.GetFormula("C");
            this.txtD.Text = calculator.GetFormula("D");
        }

        private void butReset_Click(object sender, RoutedEventArgs e)
        {
            calculator.ResetKeys();
        }
        #endregion
    }
}
