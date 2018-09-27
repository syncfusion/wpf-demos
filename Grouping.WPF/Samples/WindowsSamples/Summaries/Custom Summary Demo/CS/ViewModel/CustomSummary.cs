#region Copyright Syncfusion Inc. 2001 - 2006
//
//  Copyright Syncfusion Inc. 2001 - 2006. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.Text;

using Syncfusion.Collections;
using Syncfusion.Collections.BinaryTree;
using Syncfusion.Diagnostics;
using Syncfusion.Grouping;

using ISummary = Syncfusion.Collections.BinaryTree.ITreeTableSummary;

namespace CustomSummary
{
	/// <summary>
	/// Simple summary example: Counts total sum of entries. 
	/// </summary>
	public sealed class TotalSummary : SummaryBase
	{
		double _total;

		public static readonly TotalSummary Empty = new TotalSummary(0);
		
		/// <summary>
		/// Assign this CreateSummaryDelegate handler method to SummaryDescriptor.CreateSummaryMethod 
		/// </summary>
		/// <param name="sd"></param>
		/// <param name="record"></param>
		/// <returns></returns>
		public static ISummary CreateSummaryMethod(SummaryDescriptor sd, Record record)
		{
			object obj = sd.GetValue(record);
			bool isNull = (obj == null || obj is DBNull);
			if (isNull)
				return Empty;
			else
			{
				double val = Convert.ToDouble(obj);
				return new TotalSummary(val);
			}
		}

		/// <summary>
		/// Initializes a new summary object.
		/// </summary>
		/// <param name="total"></param>
		public TotalSummary(double total)
		{
			_total = total;
		}

		/// <summary>
		/// The running total of this summary
		/// </summary>
		public double Total
		{
			get
			{
				return _total;
			}
		}

		/// <summary>
		/// Combines this summary information with another objects summary and returns a new object.  
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		/// <remarks>
		/// This method must honor the immutable characteristics of summary objects and return 
		/// a new summary object instead of modifying an existing summary object.
		/// </remarks>
		public override SummaryBase Combine(SummaryBase other)
		{
			return Combine((TotalSummary) other);
		}

		/// <summary>
		/// Combines this summary information with another objects summary and returns a new object.  
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		/// <remarks>
		/// This method must honor the immutable characteristics of summary objects and return 
		/// a new summary object instead of modifying an existing summary object.
		/// </remarks>
		public TotalSummary Combine(TotalSummary other)
		{
			// Summary objects are immutable. That means properties cannot be modified for an 
			// existing object. Instead every time a change is made a new object must be created (just like 
			// System.String). 
			//
			// This allows following optimization: return existing summary object if either one of the values is 0. -->
			if (other.Total == 0)
				return this;
			else if (Total == 0)
				return other;
				// <-- end of optimization
			else
				return new TotalSummary(this.Total + other.Total);
		}

		/// <override/>
		public override string ToString()
		{
			return String.Format("Total = {0:0.00}", Total);
		}
	}



	/// <summary>
	/// Advanced summary example: Collects all entries of a column in a sorted vector. Provides statistical functions
	/// that work on this set such as Median, Percentile25, Percentile75 and PercentileQ.
	/// </summary>
	public class StatisticsSummary : SummaryBase
	{
		double[] _values;
		int _length;

		public static readonly StatisticsSummary Empty = new StatisticsSummary(new double[0], 0);
		
		public static ISummary CreateSummaryMethod(SummaryDescriptor sd, Record record)
		{
			object obj = sd.GetValue(record);
			bool isNull = (obj == null || obj is DBNull)
				|| (obj is double) && double.IsNaN((double) obj);
			// could also be double.NaN... which is also treated as null

			if (isNull)
				return new StatisticsSummary(new double[0], 0);// { double.NaN }, 1);
			else
			{
				double val = Convert.ToDouble(obj);
				return new StatisticsSummary(new double[] { val }, 1);
			}
		}

		public StatisticsSummary(double[] values, int length)
		{
			_values = values;
			_length = length;
		}

		public int Count
		{
			get
			{
				if (_values == null)
					return 0;
				return _length;
			}
		}

		public double[] Values
		{
			get
			{
				return _values;
			}
		}

		/// <override/>
		public override SummaryBase Combine(SummaryBase other)
		{
			return Combine((StatisticsSummary) other);
		}

		int _Compare(double x, double y)
		{
			int cmp;
			bool xIsNull = double.IsNaN(x);
			bool yIsNull = double.IsNaN(y);;

			if (yIsNull && xIsNull)
				cmp = 0;
			else if (xIsNull)
				cmp = -1;
			else if (yIsNull)
				cmp = 1;
			else if (y == x)
				cmp = 0;
			else if (y > x)
				cmp = 1;
			else
				cmp = -1;

			return cmp;
		}

		public StatisticsSummary Combine(StatisticsSummary other)
		{
			int length;
			double[] d = CombineHelper(other, false, out length);
			if (length == this.Count)
				return this;
			else if (length == other.Count)
				return other;
			else
				return new StatisticsSummary(d, length);
		}
		
		protected double[] CombineHelper(StatisticsSummary other, bool distinct, out int length)
		{
			double[] d = new double[(Count + other.Count)];
			double[] others = other.Values;

			int n1 = 0;
			int n2 = 0;
			int len1 = Count;
			int len2 = other.Count;
			int n3 = 0;
			while (n1 < len1 && n2 < len2)
			{
				int cmp = _Compare(_values[n1], others[n2]);
				if (cmp > 0)
					d[n3] = (_values[n1++]);
				else if (cmp < 0)
					d[n3] = (others[n2++]);
				else
				{
					d[n3] = (_values[n1++]);
					if (distinct)
						n2++;
				}
				n3++;
			}
			while (n1 < len1)
				d[n3++] = (_values[n1++]);

			while (n2 < len2)
				d[n3++] = (others[n2++]);
		
			length = n3;
			return d;
		}

		double GetPercentile(double p)
		{
			if (p < 0 || p > 1)
				throw new ArgumentOutOfRangeException("Percentile out-of-range.");
			double[] s = _values;
			double t = p*(_length-1);
			int i = (int) t;
			return (i+1-t)*s[i] + (t-i)*s[i+1];
		}

		public double Median
		{
			get
			{
				if (_length < 2)
					return double.NaN;
				return GetPercentile(0.5);
			}
		}

		public double Percentile25
		{
			get
			{
				if (_length < 2)
					return double.NaN;
				return GetPercentile(0.25);
			}
		}

		public double Percentile75
		{
			get
			{
				if (_length < 2)
					return double.NaN;
				return GetPercentile(0.75);
			}
		}

		public double PercentileQ
		{
			get
			{
				if (_length < 2)
					return double.NaN;
				return Percentile75 - Percentile25;
			}
		}

		/// <override/>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(String.Concat(
				"Count = " + this.Count.ToString(),
				", Values = { "));
			for (int n = 0; n < Math.Min(5, Count); n++)
			{
				if (n > 0)
					sb.Append(", ");
				sb.Append(double.IsNaN(_values[n]) ? "null" : _values[n].ToString("G"));
			}
			if (Count >= 5)
				sb.Append(", ...");
			sb.Append(" }");
			if (Count > 1)
			{
				sb.AppendFormat(", Med={0}", this.Median);
				sb.AppendFormat(", P25={0}", this.Percentile25);
				sb.AppendFormat(", P75={0}", this.Percentile75);
				sb.AppendFormat(", PQ={0}", this.PercentileQ);
			}
			return sb.ToString();
		}
	}



	/// <summary>
	/// Advanced summary example: Collects all unique integer entries of a column in a sorted vector. 
	/// </summary>
	public sealed class DistinctInt32CountSummary : SummaryBase
	{
		Int32[] _values;
	
		public static readonly DistinctInt32CountSummary Empty = new DistinctInt32CountSummary(new Int32[0]);
			
		public static ISummary CreateSummaryMethod(SummaryDescriptor sd, Record record)
		{
			object obj = sd.GetValue(record);
			bool isNull = (obj == null || obj is DBNull);

			if (isNull)
				return new DistinctInt32CountSummary(new Int32[0]);
			else
			{
				Int32 val = Convert.ToInt32(obj);
				return new DistinctInt32CountSummary(new Int32[] { val });
			}
		}
		
		public DistinctInt32CountSummary(Int32[] values)
		{
			_values = values;
		}
	
		public int Count
		{
			get
			{
				if (_values == null)
					return 0;
				return _values.Length;
			}
		}
		public Int32[] Values
		{
			get
			{
				return _values;
			}
		}
	
		public override SummaryBase Combine(SummaryBase other)
		{
			return Combine((DistinctInt32CountSummary) other);
		}
	
		int _Compare(object x, object y)
		{
			int cmp;
			bool xIsNull = (x == null || x is DBNull);
			bool yIsNull = (y == null || y is DBNull);
	
			if (yIsNull && xIsNull)
				cmp = 0;
			else if (xIsNull)
				cmp = -1;
			else if (yIsNull)
				cmp = 1;
			else 
				cmp = ((IComparable) x).CompareTo(y);
	
			return cmp;
		}
	
		public DistinctInt32CountSummary Combine(DistinctInt32CountSummary other)
		{
			ArrayList d = new ArrayList(Count + other.Count);
			Int32[] others = other.Values;
	
			int n1 = 0;
			int n2 = 0;
			int len1 = _values.Length;
			int len2 = others.Length;
			while (n1 < len1 && n2 < len2)
			{
				int cmp = _Compare(_values[n1], others[n2]);
				if (cmp < 0)
					d.Add(_values[n1++]);
				else if (cmp > 0)
					d.Add(others[n2++]);
				else
				{
					d.Add(_values[n1++]);
					n2++;
				}
			}
			while (n1 < len1)
				d.Add(_values[n1++]);
	
			while (n2 < len2)
				d.Add(others[n2++]);
				
			return new DistinctInt32CountSummary((Int32[]) d.ToArray(typeof(Int32)));
		}
	
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(String.Concat(
				"Count = " + this.Count.ToString(),
				", Values = {"));
			for (int n = 0; n < Math.Min(10, Count); n++)
			{
				if (n > 0)
					sb.Append(", ");
				sb.Append(Values[n].ToString());
			}
			if (Count >= 10)
				sb.Append(", ...");
			sb.Append("}" );
			return sb.ToString();
		}
	}

}
