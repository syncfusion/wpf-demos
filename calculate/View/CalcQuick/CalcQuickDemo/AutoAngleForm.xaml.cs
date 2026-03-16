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
    /// Interaction logic for AutoAngleForm.xaml
    /// </summary>
    public partial class AutoAngleForm : ChromelessWindow
    {
        #region Constructor

        public AutoAngleForm()
        {
            InitializeComponent();
        }

        #endregion

        #region API Definition
        //Initialize Calcualtor
        //CalcQuickBase calculator = new CalcQuickBase();
        CalcQuick calculator = null;
        #endregion

        #region Event Handler

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TextBox Angle = new TextBox();
            this.Angle.Name = "Angle";
            this.Angle.Text = "30";

            //cosTB = new TextBox();
            this.cosTB.Name = "cosTB";
            this.cosTB.Text = "= cos([Angle] * pi() / 180) ";

            //sinTB = new TextBox();
            this.sinTB.Name = "sinTB";
            this.sinTB.Text = "= sin([Angle] * pi() / 180) ";

            //Instantiate a CalcQuick object:
            calculator = new CalcQuick();

            this.calculator["Angle"] = this.Angle.Text;
            this.calculator["cosTB"] = this.cosTB.Text;
            this.calculator["sinTB"] = this.sinTB.Text;

            //Mark the calculator dirty:
            this.calculator.SetDirty();

            //Now as the values are retrieved from the calculator, they
            //will be the newly calculated values.
            this.cosTB.Text = this.calculator["cosTB"];
            this.sinTB.Text = this.calculator["sinTB"];

            //Register the controls used in calculations.
            //The formula names used are the Control.Name strings.
            this.calculator.RegisterControlArray(new System.Windows.Controls.Control[]
                                                {
                                                    this.Angle,
                                                    this.cosTB,
                                                    this.sinTB
                                                });

            //Allow the CalcQuick sheet to create dependency lists among the formula objects
            //necesary for auto-calculations.
            this.calculator.RefreshAllCalculations();
        }
        #endregion

    }
}
