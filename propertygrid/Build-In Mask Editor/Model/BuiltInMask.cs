#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media;

namespace syncfusion.propertygriddemos.wpf
{
    [Mask(MaskAttribute.Alphanumeric, "AlphanumericMaskProperty")]
    [Mask(MaskAttribute.CardNumber, "CardNumberMaskProperty")]
    [Mask(MaskAttribute.EmailId, "EmailIdMaskProperty")]
    [Mask(MaskAttribute.PositiveNumber, "PositiveNumberMaskProperty")]
    public class BuiltInMask
    {   
        [Display(Description = "It allows only alpha and numeric values")]
        public string AlphanumericMaskProperty { get; set; }

        [Mask(MaskAttribute.Binary)]
        [Display(Description = "It allows only binary values")]
        public string BinaryMaskProperty { get; set; }

        [Display(Description = "It allows only credit or debit card numbers")]
        public string CardNumberMaskProperty { get; set; }

        [Display(Description = "It allows only Email-ID format inputs")]
        public string EmailIdMaskProperty { get; set; }
        
        [Mask(MaskAttribute.Fraction)]
        [Display(Description = "It allows only fraction values")]
        public string FractionMaskProperty { get; set; }

        [Mask(MaskAttribute.HexaDecimal)]
        [Display(Description = "It allows only hexa-decimal values")]
        public string HexaDecimalMaskProperty { get; set; }

        [Mask(MaskAttribute.IPv4)]
        [Display(Description = "It allows only IPV4 format values")]
        public string IPv4MaskProperty { get; set; }

        [Mask(MaskAttribute.IPv6)]
        [Display(Description = "It allows only IPV6 format values")]
        public string IPv6MaskProperty { get; set; }

        [Mask(MaskAttribute.MobileNumber)]
        [Display(Description = "It allows only mobile number values")]
        public string MobileNumberMaskProperty { get; set; }

        [Mask(MaskAttribute.Number)]
        [Display(Description = "It allows only number values")]
        public string NumberMaskProperty { get; set; }

        [Mask(MaskAttribute.Octal)]
        [Display(Description = "It allows only octal number values")]
        public string OctalMaskProperty { get; set; }

        [Display(Description = "It allows only positive values")]
        public string PositiveNumberMaskProperty { get; set; }

        [Mask(MaskAttribute.ProductKey)]
        [Display(Description = "It allows only prodcut key values")]
        public string ProductKeyMaskProperty { get; set; }
    }
}
