#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Chart;
using System.Windows;
using System.Windows.Controls;

namespace ChartCustomPanel
{

    public class CustomPanelModel
    {
        public CustomPanelModel()
        {
            this.Products = new ObservableCollection<product>();
            Random rand = new Random(DateTime.Now.Millisecond);
            List<product> productList = new List<product>();
            Products.Add(new product() { ProductId = 2002, UnitsInStock = 20, UnitPrice = 13, OrdersAvailable = 49, OrdersCompleted = 9 });
            Products.Add(new product() { ProductId = 2003, UnitsInStock = 43, UnitPrice = 70, OrdersAvailable = 2, OrdersCompleted = 1 });
            Products.Add(new product() { ProductId = 2004, UnitsInStock = 12, UnitPrice = 23, OrdersAvailable = 45, OrdersCompleted = 3 });
            Products.Add(new product() { ProductId = 2005, UnitsInStock = 35, UnitPrice = 56, OrdersAvailable = 23, OrdersCompleted = 7 });
            Products.Add(new product() { ProductId = 2006, UnitsInStock = 25, UnitPrice = 45, OrdersAvailable = 12, OrdersCompleted=4 });
            Products.Add(new product() { ProductId = 2007, UnitsInStock = 40, UnitPrice = 67, OrdersAvailable = 46, OrdersCompleted = 8 });
            Products.Add(new product() { ProductId = 2008, UnitsInStock = 18, UnitPrice = 40, OrdersAvailable = 35, OrdersCompleted = 4 });
        }

        public ObservableCollection<product> Products { get; set; }

    }

    public class ChartAreaPanel : CarouselPanel
    {
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            ItemsPresenter presenter = this.TemplatedParent as ItemsPresenter;
            if (presenter != null)
            {
                ItemsControl control = presenter.TemplatedParent as ItemsControl;
                if (control != null)
                {
                    var context = ((FrameworkElement)e.OriginalSource).DataContext;
                    if (context is ChartArea)
                    {
                        SelectElement(context as ChartArea);
                    }
                    else if (context is ChartColumnSegment)
                    {
                        SelectElement(((ChartColumnSegment)context).Series.Area);
                    }
                    else if (context is ChartAxis)
                    {
                        SelectElement(((ChartAxis)context).Area);
                    }
                    else if (context is ChartAreaSegment)
                    {
                        SelectElement(((ChartAreaSegment)context).Series.Area);
                    }
                }
            }
        }
    }
}
