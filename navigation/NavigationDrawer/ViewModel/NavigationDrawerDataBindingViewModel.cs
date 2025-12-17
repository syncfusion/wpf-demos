#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.navigationdemos.wpf
{
	public class NavigationDrawerDataBindingViewModel : NotificationObject
	{
		private object categorySelectedItem;
		public object CategorySelectedItem
		{
			get { return categorySelectedItem; }
			set { categorySelectedItem = value; }
		}

		Binding pathFillBinding = new Binding();
		public ObservableCollection<Category> Categories { get; set; }
		public NavigationDrawerDataBindingViewModel()
		{
			pathFillBinding.Path = new PropertyPath(TextBlock.ForegroundProperty);
			pathFillBinding.RelativeSource = new RelativeSource { Mode = RelativeSourceMode.Self };
			pathFillBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			
			Path category1 = new Path();
			category1.Data = Geometry.Parse("M7.9999998,1.3820004 L2.0000002,7.1004685 2.0000002,13.000003 6.0000002,13.000003 6.0000002,8.0000033 10,8.0000033 10,13.000003 14,13.000003 14,7.0996867 z M7.9999998,0 L16,7.625001 15.311,8.3490009 15,8.0526344 15,14.000003 9.0000002,14.000003 9.0000002,9.0000033 7.0000002,9.0000033 7.0000002,14.000003 1.0000003,14.000003 1.0000003,8.0535465 0.69000006,8.3490009 0,7.625001 z");
			category1.Height = 14;
			category1.Width=16;
			category1.HorizontalAlignment = HorizontalAlignment.Center;
			category1.VerticalAlignment = VerticalAlignment.Center;
			category1.Stretch = Stretch.Fill;
			category1.SetBinding(Path.FillProperty, pathFillBinding);

			Path category2 = new Path();
			category2.Data = Geometry.Parse("M11,5.0000011 L11,15.000014 12.5,15.000014 C12.776,15.000014 13,14.775014 13,14.500013 L13,5.0000011 z M1.0000001,5.0000011 L1.0000001,14.500013 C1,14.775014 1.224,15.000014 1.5,15.000014 L10,15.000014 10,5.0000011 9,5.0000011 3,5.0000011 z M6,1.0000011 C4.8969994,1.0000011 4,1.8970043 3.9999999,3.0000011 L3.9999999,3.9999999 8,3.9999999 8,3.0000011 C8,1.8970043 7.1030006,1.0000011 6,1.0000011 z M9,0.99999997 C8.79,1 8.5875001,1.033 8.3972502,1.09375 L8.3321118,1.1159092 8.4031668,1.2062768 C8.7778573,1.7069547 9,2.3280608 9,3.0000011 L9,3.9999999 11,3.9999999 11,2.9999999 C11,1.897 10.103,1 9,0.99999997 z M9,0 C10.654,0 12,1.346 12,2.9999999 L12,3.9999999 14,3.9999999 14,14.500013 C14,15.327014 13.327,16.000014 12.5,16.000014 L11,16.000014 3,16.000014 1.5,16.000014 C0.67299986,16.000014 0,15.327014 0,14.500013 L0,3.9999999 3,3.9999999 3,3.0000011 C3,1.3459941 4.3460007,1.0986328E-06 6,1.192094E-06 6.5168748,1.0986328E-06 7.0036716,0.13144573 7.4287133,0.36265859 L7.50984,0.40936392 7.5846896,0.36610183 C8.0055308,0.13470703 8.4857497,0 9,0 z");
			category2.Height = 16;
			category2.Width = 14;
			category2.HorizontalAlignment = HorizontalAlignment.Center;
			category2.VerticalAlignment = VerticalAlignment.Center;
			category2.Stretch = Stretch.Fill;
			category2.SetBinding(Path.FillProperty, pathFillBinding);

			Path category3 = new Path();
			category3.Data = Geometry.Parse("M11.371002,1.2839998 L9.959003,1.7889997 13.325999,11.724998 14.737998,11.219998 z M4.9999998,1.0039969 L4.9999998,12.003997 6,12.003997 6,1.0039969 z M1,1.0039969 L1,12.003997 2.0000001,12.003997 2.0000001,1.0039969 z M4,0.0039970982 L7,0.0039970982 7,13.003997 4,13.003997 z M0,0.0039970982 L2.9999999,0.0039970982 2.9999999,13.003997 0,13.003997 z M11.992001,0 L16.000997,11.829997 12.705,13.008997 8.6960044,1.1789997 z");
			category3.Height = 13.009;
			category3.Width = 16;
			category3.HorizontalAlignment = HorizontalAlignment.Center;
			category3.VerticalAlignment = VerticalAlignment.Center;
			category3.Stretch = Stretch.Fill;
			category3.SetBinding(Path.FillProperty, pathFillBinding);

			Path category4 = new Path();
			category4.Data = Geometry.Parse("M8,1 C6.0700002,1 4.5,2.5700002 4.5,4.5 4.5,6.4299999 6.0700002,8 8,8 9.9300003,8 11.5,6.4299999 11.5,4.5 11.5,2.5700002 9.9300003,1 8,1 z M8,0 C10.481,0 12.5,2.0190001 12.5,4.5 12.5,6.050625 11.711329,7.4207813 10.514112,8.2303417 L10.332124,8.3471314 10.376252,8.3602881 C13.630699,9.3747748 16,12.416066 16,16 L15,16 C15,12.139999 11.860001,9 8,9 4.1399994,9 1,12.139999 1,16 L0,16 C0,12.416066 2.3693013,9.3747748 5.6237478,8.3602881 L5.6678762,8.3471314 5.4858885,8.2303417 C4.288672,7.4207813 3.5,6.050625 3.5,4.5 3.5,2.0190001 5.5190001,0 8,0 z");
			category4.Height = 16;
			category4.Width = 16;
			category4.HorizontalAlignment = HorizontalAlignment.Center;
			category4.VerticalAlignment = VerticalAlignment.Center;
			category4.Stretch = Stretch.Fill;
			category4.SetBinding(Path.FillProperty, pathFillBinding);

			Categories = new ObservableCollection<Category>();
			Categories.Add(new Category()
			{
				Name = "Category 1",
				Icon = category1
			});
			Categories.Add(new Category()
			{
				Name = "Category 2",
				Icon = category2
			});
			Categories.Add(new Category()
			{
				Name = "Category 3",
				Icon = category3
			});
			Categories.Add(new Category()
			{
				Name = "Category 4",
				Icon = category4
			});
			CategorySelectedItem = Categories[0];
		}
	}
}
