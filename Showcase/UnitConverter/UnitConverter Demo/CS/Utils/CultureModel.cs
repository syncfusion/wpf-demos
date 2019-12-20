#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Globalization;

namespace UnitConverterDemo
{
    public class CultureModel
    {
        public CultureInfo US
        {
            get
            {
                return new CultureInfo("en-US");
            }
        }

        public CultureInfo India
        {
            get
            {
                return new CultureInfo("hi-IN");
            }
        }

        public CultureInfo French
        {
            get
            {
                return new CultureInfo("fr-FR");
            }
        }

        public CultureInfo German
        {
            get
            {
                return new CultureInfo("de-DE");
            }
        }

        public CultureInfo UK
        {
            get
            {
                return new CultureInfo("en-GB");
            }
        }

        public CultureInfo Chineese
        {
            get
            {
                return new CultureInfo("zh-CN");
            }
        }

        public CultureInfo Arabic
        {
            get
            {
                return new CultureInfo("ar-BH");
            }
        }

        public CultureInfo Zulu
        {
            get
            {
                return new CultureInfo("zu-ZA");
            }
        }

        public CultureInfo Japan
        {
            get
            {
                return new CultureInfo("ja-JP");
            }
        }

        public string USSymbol
        {
            get
            {
                return new CultureInfo("en-US").NumberFormat.CurrencySymbol;
            }
        }

        public string IndiaSymbol
        {
            get
            {
                return new CultureInfo("hi-IN").NumberFormat.CurrencySymbol;
            }
        }

        public string FrenchSymbol
        {
            get
            {
                return new CultureInfo("fr-FR").NumberFormat.CurrencySymbol;
            }
        }

        public string GermanSymbol
        {
            get
            {
                return new CultureInfo("de-DE").NumberFormat.CurrencySymbol;
            }
        }

        public string UKSymbol
        {
            get
            {
                return new CultureInfo("en-GB").NumberFormat.CurrencySymbol;
            }
        }

        public string ChineeseSymbol
        {
            get
            {
                return new CultureInfo("zh-CN").NumberFormat.CurrencySymbol;
            }
        }

        public string ArabicSymbol
        {
            get
            {
                return new CultureInfo("ar-BH").NumberFormat.CurrencySymbol;
            }
        }

        public string ZuluSymbol
        {
            get
            {
                return new CultureInfo("zu-ZA").NumberFormat.CurrencySymbol;
            }
        }

        public string JapanSymbol
        {
            get
            {
                return new CultureInfo("ja-JP").NumberFormat.CurrencySymbol;
            }
        }
    }
}
