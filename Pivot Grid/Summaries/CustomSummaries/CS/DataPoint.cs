#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace CustomSummaries
{
	public class DataPoint
	{
		public int ID { get; private set; }
		public string Category { get; private set; }
		public string Item { get; private set; }
		public decimal Currency { get; private set; }
		public double Value1 { get; private set; }
		public double Value2 { get; private set; }
		public double Value3 { get; private set; }

		public DataPoint(int id, string category, string item, decimal currency,
			double value1, double value2, double value3)
		{
			ID = id;
			Category = category;
			Item = item;
			Currency = currency;
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
		}
	}
}
