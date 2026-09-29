using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.datetimedemos.wpf
{
    public class DateTimeDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            this.ShowcaseDemos = new List<DemoInfo>();
            productdemos.Add(new CalendarProductDemos());
            productdemos.Add(new DateTimeEditProductDemo());
            productdemos.Add(new DatePickerProductDemos());
            productdemos.Add(new TimePickerProductDemos());
            productdemos.Add(new TimeSpanEditProductDemo());
            return productdemos;
        }
    }

    public class CalendarProductDemos : ProductDemo
    {
        public CalendarProductDemos()
        {
            this.Product = "Calendar";
            this.ProductCategory = "CALENDAR";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M0 2.5C0 1.11929 1.11929 0 2.5 0H11.5C12.8807 0 14 1.11929 14 2.5V11.5C14 12.8807 12.8807 14 11.5 14H2.5C1.11929 14 0 12.8807 0 11.5V2.5ZM2.5 1C1.67157 1 1 1.67157 1 2.5V4H13V2.5C13 1.67157 12.3284 1 11.5 1H2.5ZM13 5H1V11.5C1 12.3284 1.67157 13 2.5 13H11.5C12.3284 13 13 12.3284 13 11.5V5ZM6 7.5C6 6.94772 5.55228 6.5 5 6.5C4.44772 6.5 4 6.94772 4 7.5C4 8.05228 4.44772 8.5 5 8.5C5.55228 8.5 6 8.05228 6 7.5ZM10 7.5C10 6.94772 9.55228 6.5 9 6.5C8.44772 6.5 8 6.94772 8 7.5C8 8.05228 8.44772 8.5 9 8.5C9.55228 8.5 10 8.05228 10 7.5ZM9 9.5C9.55228 9.5 10 9.94772 10 10.5C10 11.0523 9.55228 11.5 9 11.5C8.44772 11.5 8 11.0523 8 10.5C8 9.94772 8.44772 9.5 9 9.5ZM6 10.5C6 9.94772 5.55228 9.5 5 9.5C4.44772 9.5 4 9.94772 4 10.5C4 11.0523 4.44772 11.5 5 11.5C5.55228 11.5 6 11.0523 6 10.5Z"),
                Width = 14,
                Height = 14,
            };
            this.IsHighlighted = true;
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Calendar.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Calendar control allows to navigate to any day of any year. It provides multiselect date support, custom tooltips for dates, etc";
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Calendar.png", UriKind.RelativeOrAbsolute));
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 0C1.11929 0 0 1.11929 0 2.5V11.5C0 12.8807 1.11929 14 2.5 14H5.5C5.77614 14 6 13.7761 6 13.5C6 13.2239 5.77614 13 5.5 13H2.5C1.67157 13 1 12.3284 1 11.5V5H13V6C13 6.27614 13.2239 6.5 13.5 6.5C13.7761 6.5 14 6.27614 14 6V2.5C14 1.11929 12.8807 0 11.5 0H2.5ZM13 4V2.5C13 1.67157 12.3284 1 11.5 1H2.5C1.67157 1 1 1.67157 1 2.5V4H13ZM4.5 6.5C5.05228 6.5 5.5 6.94772 5.5 7.5C5.5 8.05228 5.05228 8.5 4.5 8.5C3.94772 8.5 3.5 8.05228 3.5 7.5C3.5 6.94772 3.94772 6.5 4.5 6.5ZM5.5 10.5C5.5 9.94771 5.05228 9.5 4.5 9.5C3.94772 9.5 3.5 9.94771 3.5 10.5C3.5 11.0523 3.94772 11.5 4.5 11.5C5.05228 11.5 5.5 11.0523 5.5 10.5ZM10.5 13.5C12.1569 13.5 13.5 12.1569 13.5 10.5C13.5 8.84315 12.1569 7.5 10.5 7.5C8.84315 7.5 7.5 8.84315 7.5 10.5C7.5 12.1569 8.84315 13.5 10.5 13.5ZM10.5 14.5C12.7091 14.5 14.5 12.7091 14.5 10.5C14.5 8.29086 12.7091 6.5 10.5 6.5C8.29086 6.5 6.5 8.29086 6.5 10.5C6.5 12.7091 8.29086 14.5 10.5 14.5ZM11 9C11 8.72386 10.7761 8.5 10.5 8.5C10.2239 8.5 10 8.72386 10 9V10.5C10 10.7761 10.2239 11 10.5 11H12C12.2761 11 12.5 10.7761 12.5 10.5C12.5 10.2239 12.2761 10 12 10H11V9Z"),
                Width = 15,
                Height = 15,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Calendar.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The DateTimeEdit control provides a simple and intuitive interface for picking DateTime. In other words, users can quickly navigate and select dates ";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/DateTimeEdit.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of DateTimeEdit Control such as DateTime patterns, null value, maximum and minimum dates, date validation, watermark, culture and much more.", GroupName = "DateTimeEdit", DemoViewType = typeof(DateTimeEditDemo) });
            
        }
    }

    public class DatePickerProductDemos : ProductDemo
    {
        public DatePickerProductDemos()
        {
            this.Product = "Date Picker";
            this.ProductCategory = "CALENDAR";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.49999 0C1.11928 0 0 1.11928 0 2.49999V3.49999V11.5C0 12.8807 1.11928 14 2.49999 14H5.99997C6.27611 14 6.49996 13.7761 6.49996 13.5C6.49996 13.2238 6.27611 13 5.99997 13H2.49999C1.67156 13 0.999994 12.3284 0.999994 11.5V3.99999H12.9999V4.49999C12.9999 4.77613 13.2238 4.99998 13.4999 4.99998C13.7761 4.99998 13.9999 4.77613 13.9999 4.49999V3.49999V2.49999C13.9999 1.11928 12.8806 0 11.4999 0H2.49999ZM12.9999 2.99999V2.49999C12.9999 1.67157 12.3284 0.999997 11.4999 0.999997H2.49999C1.67156 0.999997 0.999994 1.67157 0.999994 2.49999V2.99999H12.9999ZM12.3023 6.73196C12.5785 6.25367 13.1901 6.0898 13.6684 6.36594C14.1466 6.64208 14.3105 7.25367 14.0344 7.73196L13.5768 8.52443L13.968 8.75027C14.2072 8.88834 14.2891 9.19414 14.151 9.43328C14.0129 9.67243 13.7072 9.75436 13.468 9.61629L13.0768 9.39045L10.044 14.6435C10.0379 14.6541 10.0277 14.6619 10.0158 14.6651L8.95816 14.9485C8.79812 14.9914 8.63362 14.8964 8.59073 14.7364L8.30734 13.6787C8.30415 13.6668 8.30582 13.6542 8.31198 13.6435L11.3448 8.39046L10.8699 8.1163C10.6308 7.97823 10.5489 7.67243 10.6869 7.43329C10.825 7.19414 11.1308 7.11221 11.3699 7.25028L11.8448 7.52444L12.3023 6.73196ZM4.99997 6.99998C4.99997 6.4477 4.55226 5.99998 3.99998 5.99998C3.4477 5.99998 2.99998 6.4477 2.99998 6.99998C2.99998 7.55226 3.4477 7.99998 3.99998 7.99998C4.55226 7.99998 4.99997 7.55226 4.99997 6.99998ZM7.99995 5.99998C8.55224 5.99998 8.99995 6.4477 8.99995 6.99998C8.99995 7.55226 8.55224 7.99998 7.99995 7.99998C7.44767 7.99998 6.99996 7.55226 6.99996 6.99998C6.99996 6.4477 7.44767 5.99998 7.99995 5.99998ZM4.99997 9.99997C4.99997 9.44769 4.55226 8.99997 3.99998 8.99997C3.4477 8.99997 2.99998 9.44769 2.99998 9.99997C2.99998 10.5523 3.4477 11 3.99998 11C4.55226 11 4.99997 10.5523 4.99997 9.99997Z"),
                Width = 15,
                Height = 15,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Calendar.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The DatePicker is a touch-friendly interface to quickly select a date. It supports different date formats and specify minimum and maximum dates";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Date Picker.png", UriKind.RelativeOrAbsolute));
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M15 8C15 11.866 11.866 15 8 15C4.13401 15 1 11.866 1 8C1 4.13401 4.13401 1 8 1C11.866 1 15 4.13401 15 8ZM16 8C16 12.4183 12.4183 16 8 16C3.58172 16 0 12.4183 0 8C0 3.58172 3.58172 0 8 0C12.4183 0 16 3.58172 16 8ZM8 5.5C8 5.22386 7.77614 5 7.5 5C7.22386 5 7 5.22386 7 5.5V8.5C7 8.77614 7.22386 9 7.5 9H10.5C10.7761 9 11 8.77614 11 8.5C11 8.22386 10.7761 8 10.5 8H8V5.5Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Calendar.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The TimePicker control provides a touch-friendly interface to quickly select time. It supports time formatting, minimum and maximum times, etc.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Time Picker.png", UriKind.RelativeOrAbsolute));
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H14C14.5523 1 15 1.44772 15 2V8C15 8.55229 14.5523 9 14 9H2C1.44772 9 1 8.55228 1 8V2C1 1.44772 1.44772 1 2 1ZM0 2C0 0.89543 0.895431 0 2 0H14C15.1046 0 16 0.895431 16 2V8C16 9.10457 15.1046 10 14 10H2C0.895431 10 0 9.10457 0 8V2ZM12.3904 8.01196L13.3501 6.81235C13.612 6.48497 13.3789 6 12.9597 6H11.0403C10.6211 6 10.388 6.48497 10.6499 6.81235L11.6096 8.01196C11.8097 8.26216 12.1903 8.26216 12.3904 8.01196ZM10.6499 3.18765L11.6096 1.98804C11.8097 1.73784 12.1903 1.73784 12.3904 1.98804L13.3501 3.18765C13.612 3.51503 13.3789 4 12.9597 4H11.0403C10.6211 4 10.388 3.51503 10.6499 3.18765ZM4 3C3.44772 3 3 3.44772 3 4V6C3 6.55228 3.44772 7 4 7H8C8.55228 7 9 6.55228 9 6V4C9 3.44772 8.55228 3 8 3H4Z"),
                Width = 16,
                Height = 10,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Calendar.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The TimeSpan Editor control allows to edit the timespan. It allows to choose different time formats and specify minimum and maximum time spans. ";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/TimeSpan Edit.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of TimeSpan Editor Controls such as display format, increment or decrement options and much more.", GroupName = "TimeSpan Edit", DemoViewType = typeof(TimeSpanEditDemo) });


        }
    }
}