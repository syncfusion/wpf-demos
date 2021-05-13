#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
[Mask(MaskAttribute.Alphanumeric, "AlphanumericMaskProperty")]
[Mask(MaskAttribute.CardNumber, "CardNumberMaskProperty")]
[Mask(MaskAttribute.EmailId, "EmailIdMaskProperty")]
[Mask(MaskAttribute.PositiveNumber, "PositiveNumberMaskProperty")]
public class BuiltInMask
{
    public string AlphanumericMaskProperty { get; set; }

    [Mask(MaskAttribute.Binary)]
    public string BinaryMaskProperty { get; set; }

    public string CardNumberMaskProperty { get; set; }

    public string EmailIdMaskProperty { get; set; }

    [Mask(MaskAttribute.Fraction)]
    public string FractionMaskProperty { get; set; }

    [Mask(MaskAttribute.HexaDecimal)]
    public string HexaDecimalMaskProperty { get; set; }

    [Mask(MaskAttribute.IPv4)]
    public string IPv4MaskProperty { get; set; }

    [Mask(MaskAttribute.IPv6)]
    public string IPv6MaskProperty { get; set; }

    [Mask(MaskAttribute.MobileNumber)]
    public string MobileNumberMaskProperty { get; set; }

    [Mask(MaskAttribute.Number)]
    public string NumberMaskProperty { get; set; }

    [Mask(MaskAttribute.Octal)]
    public string OctalMaskProperty { get; set; }

    public string PositiveNumberMaskProperty { get; set; }

    [Mask(MaskAttribute.ProductKey)]
    public string ProductKeyMaskProperty { get; set; }
}
