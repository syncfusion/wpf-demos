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
