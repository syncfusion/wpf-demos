#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Syncfusion.UI.Xaml.Controls.Barcode;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
namespace syncfusion.barcodedemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SfBarcode : DemoControl
    {
        private List<string> allowedTexts;
        private List<string> validTexts;

        public SfBarcode()
        {
            InitializeComponent();

            allowedTexts = new List<string>();
            allowedTexts.Add("1 2 3 4 5 6 7 8 9 0\nText length should be 11 or 12!!!");
            allowedTexts.Add("0-9, A-Z,a dash(-),a dot(.),$,/,+,%, SPACE");
            allowedTexts.Add("0-9 A-Z a-z");
            allowedTexts.Add("0-9, a dash(-)");
            allowedTexts.Add("0-9,-,$,:,/,a dot(.),+");
            allowedTexts.Add("1 2 3 4 5 6 7 8 9 0\nText length should be 8!!!");
            allowedTexts.Add("1 2 3 4 5 6 7 8 9 0 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z - . $ / + % SPACE");
            allowedTexts.Add("All 128 ASCII characters");
            allowedTexts.Add("NUL (0x00) SOH (0x01) STX (0x02) ETX (0x03) EOT"
+ "(0x04) ENQ (0x05) ACK (0x06) BEL (0x07) BS (0x08) HT (0x09) LF (0x0A) VT"
+ "(0x0B) FF (0x0C) CR (0x0D) SO (0x0E) SI (0x0F) DLE (0x10) DC1 (0x11) DC2"
+ "(0x12) DC3 (0x13) DC4 (0x14) NAK (0x15) SYN (0x16) ETB (0x17) CAN"
+ "(0x18) EM (0x19) SUB (0x1A) ESC (0x1B) FS (0x1C) GS (0x1D) RS (0x1E) US"
+ "(0x1F) SPACE (0x20) \" ! # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A"
+ "B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ / ]^ _");
            allowedTexts.Add("SPACE (0x20) ! \" # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 :"
+ "; < = > ? @ A B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ / ]^ _ ` a"
+ "b c d e f g h i j k l m n o p q r s t u v w x y z { | } ~ DEL (•)");
            allowedTexts.Add("0 1 2 3 4 5 6 7 8 9");
            allowedTexts.Add("All 128 ASCII characters");
            allowedTexts.Add("All 128 ASCII characters");

            validTexts = new List<string>();
            validTexts.Add(@"^[\x00-\x7F]");
            validTexts.Add(@"^[\x41-\x5A\x30-\x39\x20\-\.\$\/\+\%\ ]+$");
            validTexts.Add(@"^[\x00-\x7F]+$");
            validTexts.Add(@"^[0-9\-]*$");
            validTexts.Add(@"^[\d\-\$\:\/\.\+]+$");
            validTexts.Add(@"^[\x41-\x5A\x30-\x39\x20\-\*\.\$\/\+\%]+$");
            validTexts.Add(@"^[\x41-\x5A\x30-\x39\x20\-\.\$\/\+\%\ ]+$");
            validTexts.Add(@"^[\000-\177]*$");
            validTexts.Add(@"^[\000-\137]*$");
            validTexts.Add(@"^[\040-\177]*$");
            validTexts.Add(@"^(([0-9]{2})+?)*$");
            validTexts.Add("");
            validTexts.Add("");

            barcodeTypeList.Items.Add("UpcBarcode");
            barcodeTypeList.Items.Add("Code39");
            barcodeTypeList.Items.Add("Code39Extended");
            barcodeTypeList.Items.Add("Code11");
            barcodeTypeList.Items.Add("Codabar");
            barcodeTypeList.Items.Add("Code32");
            barcodeTypeList.Items.Add("Code93");
            barcodeTypeList.Items.Add("Code93Extended");
            barcodeTypeList.Items.Add("Code128A");
            barcodeTypeList.Items.Add("Code128B");
            barcodeTypeList.Items.Add("Code128C");
            barcodeTypeList.Items.Add("DataMatrix");
            barcodeTypeList.Items.Add("QRBarcode");
        }

        private void barcodeTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            barCodeTip.Text = allowedTexts[barcodeTypeList.SelectedIndex];
            barcodeControl.Symbology = (BarcodeSymbolType)Enum.Parse(typeof(BarcodeSymbolType), barcodeTypeList.SelectedItem.ToString(), true);

            switch (barcodeControl.Symbology)
            {
                case BarcodeSymbolType.Codabar:
                    CodabarSetting codabar = new CodabarSetting();
                    codabar.BarHeight = 120;
                    barcodeControl.SymbologySettings = codabar;
                    textToEncode.Text = "01234567";
                    barcodeControl.DisplayText = true;
                    break;
                case BarcodeSymbolType.Code11:
                    Code11Setting code11 = new Code11Setting();
                    code11.BarHeight = 120;
                    barcodeControl.SymbologySettings = code11;
                    textToEncode.Text = "01234567";
                    barcodeControl.DisplayText = true;
                    break;
                case BarcodeSymbolType.Code32:
                    Code32Setting code32 = new Code32Setting();
                    code32.BarHeight = 120;
                    barcodeControl.SymbologySettings = code32;
                    textToEncode.Text = "01234567";
                    barcodeControl.DisplayText = true;
                    break;
                case BarcodeSymbolType.Code128C:
                    Code128CSetting code128C = new Code128CSetting();
                    code128C.BarHeight = 120;
                    barcodeControl.SymbologySettings = code128C;
                    textToEncode.Text = "01234567";
                    barcodeControl.DisplayText = true;
                    break;

                case BarcodeSymbolType.QRBarcode:
                    {
                        QRBarcodeSetting setting = new QRBarcodeSetting();
                        setting.XDimension = 5;
                        barcodeControl.SymbologySettings = setting;
                        textToEncode.Text = @"HTTP://WWW.SYNCFUSION.COM";
                        barcodeControl.DisplayText = false;
                    }
                    break;
                case BarcodeSymbolType.DataMatrix:
                    {
                        DataMatrixSetting setting = new DataMatrixSetting();
                        setting.XDimension = 8;
                        barcodeControl.SymbologySettings = setting;
                        textToEncode.Text = "SYNCFUSION";
                        barcodeControl.DisplayText = false;
                    }
                    break;
                case BarcodeSymbolType.Code128B:
                    Code128BSetting code128B = new Code128BSetting();
                    code128B.BarHeight = 120;
                    barcodeControl.SymbologySettings = code128B;
                    textToEncode.Text = "SYNCFUSION";
                    barcodeControl.DisplayText = true;
                    break;
                case BarcodeSymbolType.Code128A:
                    Code128ASetting code128A = new Code128ASetting();
                    code128A.BarHeight = 120;
                    barcodeControl.SymbologySettings = code128A;
                    textToEncode.Text = "SYNCFUSION";
                    barcodeControl.DisplayText = true;
                    break;
                case BarcodeSymbolType.Code39:
                    Code39Setting code39 = new Code39Setting();
                    code39.BarHeight = 120;
                    barcodeControl.SymbologySettings = code39;
                    textToEncode.Text = "SYNCFUSION";
                    barcodeControl.DisplayText = true;
                    break;
                case BarcodeSymbolType.Code39Extended:
                    Code39ExtendedSetting code39Ex = new Code39ExtendedSetting();
                    code39Ex.BarHeight = 120;
                    barcodeControl.SymbologySettings = code39Ex;
                    textToEncode.Text = "SYNCFUSION";
                    barcodeControl.DisplayText = true;
                    break;
                case BarcodeSymbolType.Code93:
                    Code93Setting code93 = new Code93Setting();
                    code93.BarHeight = 120;
                    barcodeControl.SymbologySettings = code93;
                    textToEncode.Text = "SYNCFUSION";
                    barcodeControl.DisplayText = true;
                    break;
                case BarcodeSymbolType.Code93Extended:
                    Code93ExtendedSetting code93Ex = new Code93ExtendedSetting();
                    code93Ex.BarHeight = 120;
                    barcodeControl.SymbologySettings = code93Ex;
                    textToEncode.Text = "SYNCFUSION";
                    barcodeControl.DisplayText = true;
                    break;
                case BarcodeSymbolType.UpcBarcode:
                    UpcBarcodeSetting codeUpc = new UpcBarcodeSetting();
                    codeUpc.BarHeight = 120;                  
                    textToEncode.Text = "01234567890";
                    barcodeControl.DisplayText = true;
                    break;
                default:
                    textToEncode.Text = "SYNCFUSION";
                    break;
            }
            ValidateText();
            barcodeControl.Text = textToEncode.Text;
        }

        private void ValidateText()
        {
            string expression = validTexts[barcodeTypeList.SelectedIndex];

            Regex validator = new Regex(expression, RegexOptions.Singleline);
            errorNotify.Visibility = Visibility.Visible;
            if ((barcodeTypeList.SelectedItem.ToString() != "QRBarcode") && barcodeTypeList.SelectedItem.ToString() != "DataMatrix" && barcodeTypeList.SelectedItem.ToString() != "Code32" && textToEncode.Text.Length > 14)
                errorNotify.Text = "*Only 14 characters are allowed";
            else if (barcodeTypeList.SelectedItem.ToString() == "DataMatrix" && textToEncode.Text.Length > 60)
                errorNotify.Text = "*Only 60 characters are allowed";
            else if (barcodeTypeList.SelectedItem.ToString() == "QRBarcode" && textToEncode.Text.Length > 270)
                errorNotify.Text = "*Only 270 characters are allowed";
            else if (!validator.Match(textToEncode.Text).Success || ((barcodeTypeList.SelectedItem.ToString() == "Code32") && textToEncode.Text.Length != 8))
            {
                barcodeControl.Text = "";
                errorNotify.Visibility = Visibility.Visible;
                errorNotify.Text = "*Invalid characters found in entered text";
            }
            else
                errorNotify.Visibility = Visibility.Collapsed;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if ((barcodeTypeList.SelectedItem.ToString() != "QRBarcode") && barcodeTypeList.SelectedItem.ToString() != "DataMatrix" && barcodeTypeList.SelectedItem.ToString() != "Code32" && textToEncode.Text.Length > 14)
                barcodeControl.Visibility = Visibility.Hidden;
            else if (barcodeTypeList.SelectedItem.ToString() == "DataMatrix" && textToEncode.Text.Length > 60)
                barcodeControl.Visibility = Visibility.Hidden;
            else if (barcodeTypeList.SelectedItem.ToString() == "QRBarcode" && textToEncode.Text.Length > 270)
                barcodeControl.Visibility = Visibility.Hidden;
            else
            {
                barcodeControl.Text = textToEncode.Text;
                barcodeControl.Visibility = Visibility.Visible;
            }
            ValidateText();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            barcodeTypeList.SelectedIndex = 12;
            barcodeTypeList_SelectionChanged(null, null);
        }

        private void textToEncode_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.SelectAll();
        }
    }
}
