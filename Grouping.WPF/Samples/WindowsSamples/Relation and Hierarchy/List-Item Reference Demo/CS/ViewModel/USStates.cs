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

namespace ListItemReference
{

	/// <summary>
	///		A strongly-typed collection of <see cref="USState"/> objects.
	/// </summary>
	[Serializable]
	public class USStatesCollection : ArrayList
	{
		public new USState this[int index]
		{
			get
			{
				return (USState) base[index];
			}
			set
			{
				base[index] = value;
			}
		}

		public static USStatesCollection CreateDefaultCollection()
		{
			USStatesCollection states = new USStatesCollection();
			states.Add(new USState("AL", "Alabama"));
			states.Add(new USState("AK", "Alaska"));
			states.Add(new USState("AZ", "Arizona"));
			states.Add(new USState("AR", "Arkansas"));
			states.Add(new USState("CA", "California"));
			states.Add(new USState("CO", "Colorado"));
			states.Add(new USState("CT", "Connecticut"));
			states.Add(new USState("DC", "D.C."));
			states.Add(new USState("DE", "Delaware"));
			states.Add(new USState("FL", "Florida"));
			states.Add(new USState("GA", "Georgia"));
			states.Add(new USState("HI", "Hawaii"));
			states.Add(new USState("ID", "Idaho"));
			states.Add(new USState("IL", "Illinois"));
			states.Add(new USState("IN", "Indiana"));
			states.Add(new USState("IA", "Iowa"));
			states.Add(new USState("KS", "Kansas"));
			states.Add(new USState("KY", "Kentucky"));
			states.Add(new USState("LA", "Louisiana"));
			states.Add(new USState("ME", "Maine"));
			states.Add(new USState("MD", "Maryland"));
			states.Add(new USState("MA", "Massachusetts"));
			states.Add(new USState("MI", "Michigan"));
			states.Add(new USState("MN", "Minnesota"));
			states.Add(new USState("MS", "Mississippi"));
			states.Add(new USState("MO", "Missouri"));
			states.Add(new USState("MT", "Montana"));
			states.Add(new USState("NE", "Nebraska"));
			states.Add(new USState("NV", "Nevada"));
			states.Add(new USState("NH", "New Hampshire"));
			states.Add(new USState("NJ", "New Jersey"));
			states.Add(new USState("NM", "New Mexico"));
			states.Add(new USState("NY", "New York"));
			states.Add(new USState("NC", "North Carolina"));
			states.Add(new USState("ND", "North Dakota"));
			states.Add(new USState("OH", "Ohio"));
			states.Add(new USState("OK", "Oklahoma"));
			states.Add(new USState("OR", "Oregon"));
			states.Add(new USState("PA", "Pennsylvania"));
			states.Add(new USState("RI", "Rhode Island"));
			states.Add(new USState("SC", "South Carolina"));
			states.Add(new USState("SD", "South Dakota"));
			states.Add(new USState("TN", "Tennessee"));
			states.Add(new USState("TX", "Texas"));
			states.Add(new USState("UT", "Utah"));
			states.Add(new USState("VT", "Vermont"));
			states.Add(new USState("VA", "Virginia"));
			states.Add(new USState("WA", "Washington"));
			states.Add(new USState("WV", "West Virginia"));
			states.Add(new USState("WI", "Wisconsin"));
			states.Add(new USState("WY", "Wyoming"));
			states.Add(new USState("BC", "British Columbia"));
			states.Add(new USState("MB", "Manitoba"));
			states.Add(new USState("NB", "New Brunswick"));
			states.Add(new USState("NL", "Newfoundland and Labrador"));
			states.Add(new USState("NT", "Northwest Territories"));
			states.Add(new USState("NS", "Nova Scotia"));
			states.Add(new USState("NU", "Nunavut"));
			states.Add(new USState("ON", "Ontario"));
			states.Add(new USState("PE", "Prince Edward Island"));
			states.Add(new USState("QC", "Quebec"));
			states.Add(new USState("SK", "Saskatchewan"));
			states.Add(new USState("YT", "Yukon Territories"));

			return states;
		}

		public override bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		public override bool IsFixedSize
		{
			get
			{
				return true;
			}
		}

	}


	[Serializable]
	public class USState
	{
		private string _code;
		private string _name;

		public  USState()
		{
		}

		public  USState(string key, string name)
		{
			this._code = key;
			this._name = name;
		}

		[Browsable(true)]
		public string Key
		{
			get
			{
				return _code;
			}
			set
			{
				_code = value;
			}
		}

		[Browsable(true)]
		public string Name
		{
      
			get
			{
				return _name ;
			}
			set
			{
				_name = value;
			}
		}

		public override string ToString()
		{
			return this._name + "(" + this._code + ")";
		}
	}
}
