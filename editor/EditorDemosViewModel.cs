#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.editordemos.wpf
{
    public class EditorDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            this.ShowcaseDemos = new List<DemoInfo>();
            productdemos.Add(new EditorsProductDemos());
            productdemos.Add(new ButtonProductDemos());
            productdemos.Add(new ColorPickerProductDemos());
            productdemos.Add(new CalculatorProductDemo());
            productdemos.Add(new CalendarProductDemos());
            productdemos.Add(new DateTimeEditProductDemo());
            productdemos.Add(new DatePickerProductDemos());
            productdemos.Add(new TimePickerProductDemos());
            productdemos.Add(new TimeSpanEditProductDemo());
            productdemos.Add(new RatingProductDemos());
            productdemos.Add(new RangeSliderProductDemos());
            productdemos.Add(new RadialSliderProductDemos());
            return productdemos;
        }
    }

    public class EditorsProductDemos : ProductDemo
    {
        public EditorsProductDemos()
        {
            this.Product = "Editors";
            this.ProductCategory = "INPUT CONTROLS";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Registration Form",
                Description = "This sample showcases the basic features of Syncfusion Editor controls such as binding, validation, localization and formatting.",
                GroupName = "GETTING STARTED",
                DemoViewType = typeof(RegistrationFormDemo),
                DemoLauchMode = DemoLauchMode.Window,
                ThemeMode= ThemeMode.Default
            });
            this.Demos.Add(new DemoInfo() { SampleName = "Currency TextBox", Description = "This sample showcases the basic features of CurrencyTextBox control such as number format, scrolling, watermark, range adorner, culture support etc.,", GroupName = "GETTING STARTED", DemoViewType = typeof(CurrencyTextBoxDemo), ThemeMode= ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "Double TextBox", Description = "This sample showcases the basic features of DoubleTextBox control such as number format, scrolling, watermark, range adorner, culture support etc.,", GroupName = "GETTING STARTED", DemoViewType = typeof(DoubleTextBoxDemo), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "Integer TextBox ", Description = "This sample showcases the basic features of IntegerTextBox control such as number format, scrolling, watermark, range adorner, culture support etc.,", GroupName = "GETTING STARTED", DemoViewType = typeof(IntegerTextBoxDemo), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "Percent TextBox", Description = "This sample showcases the basic features of PercentTextBox controls such as negative in a custom color and customization of percentage symbol, number format, scrolling, watermark, range adorner, culture support etc.,", GroupName = "GETTING STARTED", DemoViewType = typeof(PercentTextBoxDemo) , ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "Masked Edit", Description = "A masked text box lets you to restrict the user input to specific formats specified by a mask. You can use it to allow end users to enter proper telephone numbers, e-mails, etc. Regular expression-based masks can also be specified. There are also several built-in skins that can be used.", GroupName = "GETTING STARTED", DemoViewType = typeof(MaskedEditDemo), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "Updown", Description = "This sample showcases the basic features of the Updown control such as number format, scrolling, watermark, range adorner, culture support etc.,", GroupName = "GETTING STARTED", DemoViewType = typeof(UpDownDemo), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "DomainUpdown", Description = "The Up-Down control is a text box with a pair of arrow buttons that increase or decrease the value given in a text box. It supports double values and lets you specify the number of decimal places indicated. When the value changes, it becomes animated; the increment can be customized, and the range of supported values can also be specified.", GroupName = "GETTING STARTED", DemoViewType = typeof(DomainUpDownDemo), ThemeMode = ThemeMode.Inherit });
        }
    }
     
    public class ButtonProductDemos : ProductDemo
    {
        public ButtonProductDemos()
        {
            this.Product = "Buttons";
            this.ProductCategory = "INPUT CONTROLS";
            this.Tag = Tag.Updated;
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Buttons", Tag = Tag.Updated, GroupName = "Buttons", Description = "This sample showcases the basic features of Button, DropDownButton and SplitButton controls.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(ButtonView) });
        }
    }

    public class ColorPickerProductDemos : ProductDemo
    {
        public ColorPickerProductDemos()
        {
            this.Product = "Color Picker";
            this.ProductCategory = "INPUT CONTROLS";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Color Edit", Description= "This sample showcases the basic features of ColorEditor control such as Color selection, Eyedropper support, linear and radial gradient color editor.", GroupName = "Color Picker", DemoViewType = typeof(ColorEditDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Color Picker", Description= "This sample showcases the basic features of ColorPicker control such as Selecting colors from the color palette collection, displaying the color palette as a drop-down control.", GroupName = "Color Picker", DemoViewType = typeof(ColorPickerDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Color Picker Palette", Description= "This sample showcases the basic features of Color Picker Palette control such as Drop-down menu with a selected color highlighted at the top, ToolTip support which provides the name of the color.", GroupName = "Color Picker", DemoViewType = typeof(ColorPickerPaletteDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Color Palette", Description= "This sample showcases the basic features of SfColorPalette such as Swatch selection on swatch pages, Color Selection on Swatches.", GroupName = "Color Picker", DemoViewType = typeof(ColorPaletteDemo) });
        }
    }


    public class CalculatorProductDemo : ProductDemo
    {
        public CalculatorProductDemo()
        {
            this.Product = "Calculator";
            this.ProductCategory = "INPUT CONTROLS";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "The SfCalculator control allows end users to perform simple calculations without switching to external applications.", GroupName = "Calculator", DemoViewType = typeof(CalculatorDemo), ThemeMode = ThemeMode.Inherit });

        }
    }

    public class RatingProductDemos : ProductDemo
    {
        public RatingProductDemos()
        {
            this.Product = "Rating";
            this.ProductCategory = "INPUT CONTROLS";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description = "The Rating control allows users to rate items based on a specified list of options.", GroupName = "Rating", DemoViewType = typeof(RatingDemo), ThemeMode = ThemeMode.Inherit });
        }
    }

    public class RangeSliderProductDemos : ProductDemo
    {
        public RangeSliderProductDemos()
        {
            this.Product = "Range Slider";
            this.ProductCategory = "INPUT CONTROLS";
            this.Tag = Tag.Updated;
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description = "This sample showcases the usage of Range Slider as a normal slider and a range selector.", GroupName = "Range Slider", DemoViewType = typeof(RangeSliderDemo), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", Description = "This sample showcases the different customizations that can be done for the track, thumb, and tooltip of Range Slider.", GroupName = "Range Slider", DemoViewType = typeof(Customization), ThemeMode = ThemeMode.None, Tag = Tag.Updated });
        }
    }


    public class CalendarProductDemos : ProductDemo
    {
        public CalendarProductDemos()
        {
            this.Product = "Calendar";
            this.ProductCategory = "CALENDAR";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description = "This sample showcases the basic features of Calendar Edit control such as Multi selection, Date ranges from year 0 to year 9999 A.D and Customization of its look and feel.", GroupName = "Calendar", DemoViewType = typeof(CalenderEditDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Calender", Description = "This sample showcases the customization options, special dates and tooltip support of Calendar Edit control", GroupName = "Calendar", DemoViewType = typeof(CustomCalenderDemo)});
        }
    }

    public class DateTimeEditProductDemo : ProductDemo
    {
        public DateTimeEditProductDemo()
        {
            this.Product = "DateTimeEdit";
            this.ProductCategory = "CALENDAR";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of DateTimeEdit Control such as DateTime patterns, null value, maximum and minimum dates, date validation, watermark, culture and much more.", GroupName = "DateTimeEdit", DemoViewType = typeof(DateTimeEditDemo) });
            
        }
    }

    public class DatePickerProductDemos : ProductDemo
    {
        public DatePickerProductDemos()
        {
            this.Product = "Date Picker";
            this.ProductCategory = "CALENDAR";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of DatePicker Control such as date format, null value, maximum and minimum dates, date validation, watermark, drop down customization and much more.", GroupName = "Date Picker", DemoViewType = typeof(DatePickerDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Date Selector", Description= "This sample showcases selector format customization and date range support of SfDateSelector.", GroupName = "Date Picker", DemoViewType = typeof(DateSelectorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Date and Time Picker", Description= "This sample showcases how datetime can be edited using date picker and time picker together.", GroupName = "Date Picker", DemoViewType = typeof(DateTimePickerDemo) });
           
        }
    }

    public class TimePickerProductDemos : ProductDemo
    {
        public TimePickerProductDemos()
        {
            this.Product = "Time Picker";
            this.ProductCategory = "CALENDAR";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of SfTimePicker control such as time format, null value, time range, time validation, watermark, drop down customization and much more.", GroupName = "Time Picker", DemoViewType = typeof(TimePickerDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Time Selector", Description= "This sample illustrates the capability of SfTimeSelector can be used as a stand alone control", GroupName = "Time Picker", DemoViewType = typeof(TimeSelectorDemo) });

        }
    }

    public class TimeSpanEditProductDemo : ProductDemo
    {
        public TimeSpanEditProductDemo()
        {
            this.Product = "TimeSpan Edit";
            this.ProductCategory = "CALENDAR";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of TimeSpan Editor Controls such as display format, increment or decrement options and much more.", GroupName = "TimeSpan Edit", DemoViewType = typeof(TimeSpanEditDemo) });


        }
    }

    public class RadialSliderProductDemos : ProductDemo
    {
        public RadialSliderProductDemos()
        {
            this.Product = "Radial Slider";
            this.ProductCategory = "INPUT CONTROLS";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This SfRadialSlider control allows end user to select a numeric value within the minimum and maximum range in the circular track.", GroupName = "Radial Slider", DemoViewType = typeof(SfRadialSliderDemo) });
        }
    }
}