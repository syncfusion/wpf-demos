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
using System.Windows.Shapes;
using Syncfusion.Calculate;
using System.Windows.Forms;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;

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
