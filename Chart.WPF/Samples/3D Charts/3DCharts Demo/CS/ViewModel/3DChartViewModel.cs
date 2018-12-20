#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
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
using Syncfusion.Windows.Chart;

namespace Chart3D
{
    public class _3DChartViewModel
    {
        public _3DChartViewModel()
        {

            this.Products = new ObservableCollection<_3DChartModel>();

            Products.Add(new _3DChartModel() { ProdId = 1, Prodname = "Rice", Price2000 = 20, Price2010 = 53, Price2012 = 22 });
            Products.Add(new _3DChartModel() { ProdId = 2, Prodname = "Wheat", Price2000 = 22, Price2010 = 36, Price2012 = 25 });
            Products.Add(new _3DChartModel() { ProdId = 3, Prodname = "Oil", Price2000 = 30, Price2010 = 80, Price2012 = 28 });
            Products.Add(new _3DChartModel() { ProdId = 4, Prodname = "Corn", Price2000 = 26, Price2010 = 30, Price2012 = 16 });
            Products.Add(new _3DChartModel() { ProdId = 5, Prodname = "Gram", Price2000 = 36, Price2010 = 68, Price2012 = 30 });
            Products.Add(new _3DChartModel() { ProdId = 6, Prodname = "Milk", Price2000 = 26, Price2010 = 50, Price2012 = 35 });
            Products.Add(new _3DChartModel() { ProdId = 7, Prodname = "Butter", Price2000 = 40, Price2010 = 73, Price2012 = 30 });

        }

        public ObservableCollection<_3DChartModel> Products { get; set; }


        public Array TypesCollection
        {
            get
            {
                return new ChartTypes[] {   
                                                        ChartTypes.Column, 
                                                        ChartTypes.Bar,
                                                        ChartTypes.Gantt,
                                                        ChartTypes.Line,
                                                        ChartTypes.Scatter,
                                                        ChartTypes.SplineArea,
                                                        ChartTypes.StepArea,
                                                        ChartTypes.StepLine,
                                                        ChartTypes.SplineArea,
                                                        ChartTypes.StackingArea,
                                                        ChartTypes.RangeColumn, 
                                                    };
            }
        }

        public Array ThemesCollection
        {
            get
            {
                return new ChartColorPalette[] {   
                                                      ChartColorPalette.Metro,
                                                      ChartColorPalette.DefaultDark,
                                                      ChartColorPalette.DefaultAlpha,
                                                      ChartColorPalette.Nature,
                                                    };
            }
        }

    }
}
