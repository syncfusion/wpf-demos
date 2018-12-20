#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Chart;
using System.Collections.ObjectModel;
using System.Xml;
using System.Windows.Markup;
using System.IO;

namespace ChartExport
{
    
    public class Products : ObservableCollection<Product>
    {
        public Products()
        {
            this.Add(new Product { X = "Jan", Y1 = 2, Y2 = 5 });
            this.Add(new Product { X = "Mar", Y1 = 5, Y2 = 2 });
            this.Add(new Product { X = "May", Y1 = 4, Y2 = 4 });
            this.Add(new Product { X = "Jul", Y1 = 7, Y2 = 6 });
            this.Add(new Product { X = "Sep", Y1 = 2, Y2 = 3 });
            this.Add(new Product { X = "Nov", Y1 = 8, Y2 = 5 });
            
        }
    }
}
