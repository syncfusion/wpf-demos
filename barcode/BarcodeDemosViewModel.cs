#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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

namespace syncfusion.barcodedemos.wpf
{
    public class BarcodeDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new BarcodeProductDemos());
            return productdemos;
        }
    }

    public class BarcodeProductDemos : ProductDemo
    {
        public BarcodeProductDemos()
        {
            this.Product = "Barcode";
            this.ProductCategory = "DATA VISUALIZATION";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Barcode", GroupName = "Barcode", DemoViewType = typeof(SfBarcode) });
        }
    }
}
