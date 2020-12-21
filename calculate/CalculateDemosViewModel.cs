#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.calculatedemos.wpf
{
    public class CalculateDemosViewModel: DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new CalculatorProductDemos());
            return productdemos;
        }
    }

    public class CalculatorProductDemos : ProductDemo
    {
        public CalculatorProductDemos()
        {
            this.Product = "Calculate";
            this.ProductCategory = "MISCELLANEOUS";
            this.Demos = new List<DemoInfo>();

            this.Demos.Add(new DemoInfo() { SampleName = "Array Calculation", GroupName = "PRODUCT SHOWCASE", Description = "This sample illustrates how to add calculation support to a double array by wrapping the array in a class that implements the ICalcData interface.", DemoViewType = typeof(ArrayCalculationDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Function Library", GroupName = "GETTING STARTED", Description = "This sample explains about different formulas supported by CalcQuick objects. The following displays the sample output image.", DemoViewType = typeof(GettingStarted) });
            this.Demos.Add(new DemoInfo() { SampleName = "CalcQuick", GroupName = "CALCQUICK", Description = "This sample illustrates how to quickly add calculations support for usercontrol or controls on an application.", DemoViewType = typeof(CalcQuickDemo) });

        }
    }
}
