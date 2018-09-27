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

namespace ForeignKeyReference
{

	/// <summary>
	///		A strongly-typed collection of <see cref="Country"/> objects.
	/// </summary>
	[Serializable]
	public class CountriesCollection : ArrayList
	{
		public new Country this[int index]
		{
			get
			{
				return (Country) base[index];
			}
			set
			{
				base[index] = value;
			}
		}

		public static CountriesCollection CreateDefaultCollection()
		{
			CountriesCollection countries = new CountriesCollection();
			countries.Add(new Country("US", "United States"));
			countries.Add(new Country("CA", "Canada"));
			countries.Add(new Country("AF", "Afghanistan"));
			countries.Add(new Country("AL", "Albania"));
			countries.Add(new Country("DZ", "Algeria"));
			countries.Add(new Country("AS", "American Samoa"));
			countries.Add(new Country("AD", "Andorra"));
			countries.Add(new Country("AO", "Angola"));
			countries.Add(new Country("AI", "Anguilla"));
			countries.Add(new Country("AQ", "Antarctica"));
			countries.Add(new Country("AG", "Antigua and Barbuda"));
			countries.Add(new Country("AR", "Argentina"));
			countries.Add(new Country("AM", "Armenia"));
			countries.Add(new Country("AW", "Aruba"));
			countries.Add(new Country("AU", "Australia"));
			countries.Add(new Country("AT", "Austria"));
			countries.Add(new Country("AZ", "Azerbaijan"));
			countries.Add(new Country("BS", "Bahamas"));
			countries.Add(new Country("BH", "Bahrain"));
			countries.Add(new Country("BD", "Bangladesh"));
			countries.Add(new Country("BB", "Barbados"));
			countries.Add(new Country("BY", "Belarus"));
			countries.Add(new Country("BE", "Belgium"));
			countries.Add(new Country("BZ", "Belize"));
			countries.Add(new Country("BJ", "Benin"));
			countries.Add(new Country("BM", "Bermuda"));
			countries.Add(new Country("BT", "Bhutan"));
			countries.Add(new Country("BO", "Bolivia"));
			countries.Add(new Country("BA", "Bosnia and Herzegovina"));
			countries.Add(new Country("BW", "Botswana"));
			countries.Add(new Country("BV", "Bouvet Island"));
			countries.Add(new Country("BR", "Brazil"));
			countries.Add(new Country("IO", "British Indian Ocean Territory"));
			countries.Add(new Country("BN", "Brunei Darussalam"));
			countries.Add(new Country("BG", "Bulgaria"));
			countries.Add(new Country("BF", "Burkina Faso"));
			countries.Add(new Country("BI", "Burundi"));
			countries.Add(new Country("KH", "Cambodia"));
			countries.Add(new Country("CM", "Cameroon"));
			countries.Add(new Country("CV", "Cape Verde"));
			countries.Add(new Country("KY", "Cayman Islands"));
			countries.Add(new Country("CF", "Central African Republic"));
			countries.Add(new Country("TD", "Chad"));
			countries.Add(new Country("CL", "Chile"));
			countries.Add(new Country("CN", "China"));
			countries.Add(new Country("CX", "Christmas Island"));
			countries.Add(new Country("CC", "Cocos (Keeling) Islands"));
			countries.Add(new Country("CO", "Colombia"));
			countries.Add(new Country("KM", "Comoros"));
			countries.Add(new Country("CG", "Congo"));
			countries.Add(new Country("CK", "Cook Islands"));
			countries.Add(new Country("CR", "Costa Rica"));
			countries.Add(new Country("CI", "Cote D'Ivoire (Ivory Coast)"));
			countries.Add(new Country("HR", "Croatia (Hrvatska)"));
			countries.Add(new Country("CU", "Cuba"));
			countries.Add(new Country("CY", "Cyprus"));
			countries.Add(new Country("CZ", "Czech Republic"));
			countries.Add(new Country("DK", "Denmark"));
			countries.Add(new Country("DJ", "Djibouti"));
			countries.Add(new Country("DM", "Dominica"));
			countries.Add(new Country("DO", "Dominican Republic"));
			countries.Add(new Country("TP", "East Timor"));
			countries.Add(new Country("EC", "Ecuador"));
			countries.Add(new Country("EG", "Egypt"));
			countries.Add(new Country("SV", "El Salvador"));
			countries.Add(new Country("GQ", "Equatorial Guinea"));
			countries.Add(new Country("ER", "Eritrea"));
			countries.Add(new Country("EE", "Estonia"));
			countries.Add(new Country("ET", "Ethiopia"));
			countries.Add(new Country("FK", "Falkland Islands (Malvinas)"));
			countries.Add(new Country("FO", "Faroe Islands"));
			countries.Add(new Country("FJ", "Fiji"));
			countries.Add(new Country("FI", "Finland"));
			countries.Add(new Country("FR", "France"));
			countries.Add(new Country("GF", "French Guiana"));
			countries.Add(new Country("PF", "French Polynesia"));
			countries.Add(new Country("TF", "French Southern Territories"));
			countries.Add(new Country("GA", "Gabon"));
			countries.Add(new Country("GM", "Gambia"));
			countries.Add(new Country("GZ", "Gaza"));
			countries.Add(new Country("GE", "Georgia"));
			countries.Add(new Country("DE", "Germany"));
			countries.Add(new Country("GH", "Ghana"));
			countries.Add(new Country("GI", "Gibraltar"));
			countries.Add(new Country("GR", "Greece"));
			countries.Add(new Country("GL", "Greenland"));
			countries.Add(new Country("GD", "Grenada"));
			countries.Add(new Country("GP", "Guadeloupe"));
			countries.Add(new Country("GU", "Guam"));
			countries.Add(new Country("GT", "Guatemala"));
			countries.Add(new Country("GN", "Guinea"));
			countries.Add(new Country("GW", "Guinea-Bissau"));
			countries.Add(new Country("GY", "Guyana"));
			countries.Add(new Country("HT", "Haiti"));
			countries.Add(new Country("HM", "Heard and McDonald Islands"));
			countries.Add(new Country("HN", "Honduras"));
			countries.Add(new Country("HK", "Hong Kong"));
			countries.Add(new Country("HU", "Hungary"));
			countries.Add(new Country("IS", "Iceland"));
			countries.Add(new Country("IN", "India"));
			countries.Add(new Country("ID", "Indonesia"));
			countries.Add(new Country("IR", "Iran"));
			countries.Add(new Country("IQ", "Iraq"));
			countries.Add(new Country("IE", "Ireland"));
			countries.Add(new Country("IL", "Israel"));
			countries.Add(new Country("IT", "Italy"));
			countries.Add(new Country("JM", "Jamaica"));
			countries.Add(new Country("JP", "Japan"));
			countries.Add(new Country("JO", "Jordan"));
			countries.Add(new Country("KZ", "Kazakhstan"));
			countries.Add(new Country("KE", "Kenya"));
			countries.Add(new Country("KI", "Kiribati"));
			countries.Add(new Country("KP", "Korea (North)"));
			countries.Add(new Country("KR", "Korea (South)"));
			countries.Add(new Country("KW", "Kuwait"));
			countries.Add(new Country("KG", "Kyrgyzstan"));
			countries.Add(new Country("LA", "Laos"));
			countries.Add(new Country("LV", "Latvia"));
			countries.Add(new Country("LB", "Lebanon"));
			countries.Add(new Country("LS", "Lesotho"));
			countries.Add(new Country("LR", "Liberia"));
			countries.Add(new Country("LY", "Libya"));
			countries.Add(new Country("LI", "Liechtenstein"));
			countries.Add(new Country("LT", "Lithuania"));
			countries.Add(new Country("LU", "Luxembourg"));
			countries.Add(new Country("MO", "Macau"));
			countries.Add(new Country("MK", "Macedonia"));
			countries.Add(new Country("MG", "Madagascar"));
			countries.Add(new Country("MW", "Malawi"));
			countries.Add(new Country("MY", "Malaysia"));
			countries.Add(new Country("MV", "Maldives"));
			countries.Add(new Country("ML", "Mali"));
			countries.Add(new Country("MT", "Malta"));
			countries.Add(new Country("MH", "Marshall Islands"));
			countries.Add(new Country("MQ", "Martinique"));
			countries.Add(new Country("MR", "Mauritania"));
			countries.Add(new Country("MU", "Mauritius"));
			countries.Add(new Country("YT", "Mayotte"));
			countries.Add(new Country("MX", "Mexico"));
			countries.Add(new Country("FM", "Micronesia"));
			countries.Add(new Country("MD", "Moldova"));
			countries.Add(new Country("MC", "Monaco"));
			countries.Add(new Country("MN", "Mongolia"));
			countries.Add(new Country("MS", "Montserrat"));
			countries.Add(new Country("MA", "Morocco"));
			countries.Add(new Country("MZ", "Mozambique"));
			countries.Add(new Country("MM", "Myanmar"));
			countries.Add(new Country("NA", "Namibia"));
			countries.Add(new Country("NR", "Nauru"));
			countries.Add(new Country("NP", "Nepal"));
			countries.Add(new Country("NL", "Netherlands"));
			countries.Add(new Country("AN", "Netherlands Antilles"));
			countries.Add(new Country("NC", "New Caledonia"));
			countries.Add(new Country("NZ", "New Zealand"));
			countries.Add(new Country("NI", "Nicaragua"));
			countries.Add(new Country("NE", "Niger"));
			countries.Add(new Country("NG", "Nigeria"));
			countries.Add(new Country("NU", "Niue"));
			countries.Add(new Country("NF", "Norfolk Island"));
			countries.Add(new Country("MP", "Northern Mariana Islands"));
			countries.Add(new Country("NO", "Norway"));
			countries.Add(new Country("OM", "Oman"));
			countries.Add(new Country("PK", "Pakistan"));
			countries.Add(new Country("PW", "Palau"));
			countries.Add(new Country("PA", "Panama"));
			countries.Add(new Country("PG", "Papua New Guinea"));
			countries.Add(new Country("PY", "Paraguay"));
			countries.Add(new Country("PE", "Peru"));
			countries.Add(new Country("PH", "Philippines"));
			countries.Add(new Country("PN", "Pitcairn"));
			countries.Add(new Country("PL", "Poland"));
			countries.Add(new Country("PT", "Portugal"));
			countries.Add(new Country("PR", "Puerto Rico"));
			countries.Add(new Country("QA", "Qatar"));
			countries.Add(new Country("RE", "Reunion"));
			countries.Add(new Country("RO", "Romania"));
			countries.Add(new Country("RU", "Russian Federation"));
			countries.Add(new Country("RW", "Rwanda"));
			countries.Add(new Country("KN", "Saint Kitts and Nevis"));
			countries.Add(new Country("LC", "Saint Lucia"));
			countries.Add(new Country("VC", "Saint Vincent and the Grenadines"));
			countries.Add(new Country("WS", "Samoa"));
			countries.Add(new Country("SM", "San Marino"));
			countries.Add(new Country("ST", "Sao Tome and Principe"));
			countries.Add(new Country("SA", "Saudi Arabia"));
			countries.Add(new Country("SN", "Senegal"));
			countries.Add(new Country("SC", "Seychelles"));
			countries.Add(new Country("SL", "Sierra Leone"));
			countries.Add(new Country("SG", "Singapore"));
			countries.Add(new Country("SK", "Slovak Republic"));
			countries.Add(new Country("SI", "Slovenia"));
			countries.Add(new Country("SB", "Solomon Islands"));
			countries.Add(new Country("SO", "Somalia"));
			countries.Add(new Country("ZA", "South Africa"));
			countries.Add(new Country("ES", "Spain"));
			countries.Add(new Country("LK", "Sri Lanka"));
			countries.Add(new Country("SH", "St. Helena"));
			countries.Add(new Country("PM", "St. Pierre and Miquelon"));
			countries.Add(new Country("SD", "Sudan"));
			countries.Add(new Country("SR", "Suriname"));
			countries.Add(new Country("SJ", "Svalbard and Jan Mayen Islands"));
			countries.Add(new Country("SZ", "Swaziland"));
			countries.Add(new Country("SE", "Sweden"));
			countries.Add(new Country("CH", "Switzerland"));
			countries.Add(new Country("SY", "Syria"));
			countries.Add(new Country("TW", "Taiwan"));
			countries.Add(new Country("TJ", "Tajikistan"));
			countries.Add(new Country("TZ", "Tanzania"));
			countries.Add(new Country("TH", "Thailand"));
			countries.Add(new Country("TG", "Togo"));
			countries.Add(new Country("TK", "Tokelau"));
			countries.Add(new Country("TO", "Tonga"));
			countries.Add(new Country("TT", "Trinidad and Tobago"));
			countries.Add(new Country("TN", "Tunisia"));
			countries.Add(new Country("TR", "Turkey"));
			countries.Add(new Country("TM", "Turkmenistan"));
			countries.Add(new Country("TC", "Turks and Caicos Islands"));
			countries.Add(new Country("TV", "Tuvalu"));
			countries.Add(new Country("UG", "Uganda"));
			countries.Add(new Country("UA", "Ukraine"));
			countries.Add(new Country("AE", "United Arab Emirates"));
			countries.Add(new Country("GB", "United Kingdom"));
			countries.Add(new Country("UY", "Uruguay"));
			countries.Add(new Country("UM", "US Minor Outlying Islands"));
			countries.Add(new Country("UZ", "Uzbekistan"));
			countries.Add(new Country("VU", "Vanuatu"));
			countries.Add(new Country("VA", "Vatican City State (Holy See)"));
			countries.Add(new Country("VE", "Venezuela"));
			countries.Add(new Country("VN", "Viet Nam"));
			countries.Add(new Country("VG", "Virgin Islands (British)"));
			countries.Add(new Country("VI", "Virgin Islands (U.S.)"));
			countries.Add(new Country("WF", "Wallis and Futuna Islands"));
			countries.Add(new Country("WB", "West Bank"));
			countries.Add(new Country("EH", "Western Sahara"));
			countries.Add(new Country("YE", "Yemen"));
			countries.Add(new Country("YU", "Yugoslavia"));
			countries.Add(new Country("ZR", "Zaire"));
			countries.Add(new Country("ZM", "Zambia"));
			countries.Add(new Country("ZW", "Zimbabwe"));

			return countries;
		}

		public override bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public override bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

	}


	[Serializable]
	public class Country
	{
		private string _code;
		private string _name;

		public  Country()
		{
		}

		public  Country(string strCode, string strName)
		{
			this._code = strCode;
			this._name = strName;
		}

		[Browsable(true)]
		public string CountryCode
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
