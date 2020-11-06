#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace syncfusion.navigationdemos.wpf
{
	public class MenuCollectionModel : NotificationObject
	{
		public ObservableCollection<Message> MessageContent
		{
			get;
			set;
		}

		private string menuItem;
		public MenuCollectionModel()
		{
		}

		public string MenuItem
		{
			get
			{
				return menuItem;
			}

			set
			{
				menuItem = value;
			}
		}

		public string Icon
		{
			get;
			set;
		}

		public System.Windows.Media.Geometry PathData
		{
			get;
			set;
		}

		private Brush textColor = new SolidColorBrush(Colors.Black);
		public Brush TextColor
		{
			get

			{
				return textColor;
			}
			set
			{
				textColor = value;
				RaisePropertyChanged("TextColor");
			}
		}

		private Brush fontColor = new SolidColorBrush(Color.FromRgb(117,117,117));
		public Brush FontColor
		{
			get

			{
				return fontColor;
			}
			set
			{
				fontColor = value;
				RaisePropertyChanged("FontColor");
			}
		}
	}
}
