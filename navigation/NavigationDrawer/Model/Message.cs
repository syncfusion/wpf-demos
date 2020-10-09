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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.navigationdemos.wpf
{
	public class Message
	{
		public string Sender
		{
			get;
			set;
		}

		public String Subject
		{
			get;
			set;
		}
		public String Content
		{
			get;
			set;
		}
		public String Date
		{
			get;
			set;
		}
		public Brush SubjectColor
		{
			get;
			set;
		}

		public FontWeight FontAttribute
		{
			get;
			set;
		}
	}
}
