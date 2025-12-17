using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H14C14.5523 1 15 1.44772 15 2V5C15 5.55228 14.5523 6 14 6H2C1.44772 6 1 5.55228 1 5V2C1 1.44772 1.44772 1 2 1ZM0 2C0 0.89543 0.895431 0 2 0H14C15.1046 0 16 0.895431 16 2V5C16 6.10457 15.1046 7 14 7H2C0.895431 7 0 6.10457 0 5V2ZM2 9H14C14.5523 9 15 9.44772 15 10V12C15 12.5523 14.5523 13 14 13H2C1.44772 13 1 12.5523 1 12V10C1 9.44772 1.44772 9 2 9ZM0 10C0 8.89543 0.895431 8 2 8H14C15.1046 8 16 8.89543 16 10V12C16 13.1046 15.1046 14 14 14H2C0.895431 14 0 13.1046 0 12V10ZM3 3.5C3 3.22386 3.22386 3 3.5 3H12.5C12.7761 3 13 3.22386 13 3.5C13 3.77614 12.7761 4 12.5 4H3.5C3.22386 4 3 3.77614 3 3.5ZM3.5 10.5C3.22386 10.5 3 10.7239 3 11C3 11.2761 3.22386 11.5 3.5 11.5H12.5C12.7761 11.5 13 11.2761 13 11C13 10.7239 12.7761 10.5 12.5 10.5H3.5Z"),
                Width = 16,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/InputControls.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "Editors is a set of UI controls that allows to create rich and interactive data input forms to the applications.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Editors.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Registration Form",
                Description = "This sample showcases the basic features of Syncfusion Editor controls such as binding, validation, localization and formatting.",
                GroupName = "GETTING STARTED",
                DemoViewType = typeof(RegistrationFormDemo),
                DemoLauchMode = DemoLauchMode.Window,
                ThemeMode= ThemeMode.Default
            });
            this.Demos.Add(new DemoInfo() { SampleName = "Currency TextBox", Description = "This sample showcases the basic features of CurrencyTextBox control such as number format, scrolling, watermark, range adorner, culture support etc.,", GroupName = "GETTING STARTED", DemoViewType = typeof(CurrencyTextBoxDemo), ThemeMode= ThemeMode.Inherit});
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H14C14.5523 1 15 1.44772 15 2V7C15 7.55228 14.5523 8 14 8H2C1.44772 8 1 7.55228 1 7V2C1 1.44772 1.44772 1 2 1ZM0 2C0 0.89543 0.895431 0 2 0H14C15.1046 0 16 0.895431 16 2V7C16 8.10457 15.1046 9 14 9H2C0.895431 9 0 8.10457 0 7V2ZM4 3C3.17157 3 2.5 3.67157 2.5 4.5C2.5 5.32843 3.17157 6 4 6L12 6C12.8284 6 13.5 5.32843 13.5 4.5C13.5 3.67157 12.8284 3 12 3L4 3Z"),
                Width = 16,
                Height = 9,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/InputControls.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Button is an advanced control that offers features such as checkable support, multiline support, image size options, different button size modes, and icon templates.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Buttons.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Buttons", GroupName = "Buttons", Description = "This sample showcases the basic features of Button, DropDownButton and SplitButton controls.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(ButtonView) });
        }
    }

    public class ColorPickerProductDemos : ProductDemo
    {
        public ColorPickerProductDemos()
        {
            this.Product = "Color Picker";
            this.ProductCategory = "INPUT CONTROLS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M8.83765 15.9906C7.52 15.9624 6.41883 15.5106 5.55294 14.6353C4.68706 13.7694 4.22588 12.6588 4.19765 11.3318V9.87294C4.17882 9.65647 4.09412 9.45883 3.94353 9.30824C3.64236 9.00706 3.15294 9.02588 2.88941 9.28C2.25882 9.87294 1.13882 9.88235 0.489412 9.23294C0.16 8.90353 0 8.48941 0 8C0.0564706 5.73176 0.837647 3.83059 2.33412 2.33412C3.83059 0.837649 5.73177 0.0564706 7.99059 0C10.2682 0.0564706 12.1788 0.837649 13.6659 2.33412C15.1529 3.83059 15.9435 5.73177 16 7.99059C15.9435 10.2588 15.2471 12.16 13.92 13.6471C12.5835 15.1529 10.8706 15.9435 8.83765 16V15.9906ZM3.41647 8.15059C3.88706 8.15059 4.28235 8.32 4.61177 8.64C4.93177 8.96 5.11059 9.36471 5.13882 9.84471V11.3318C5.16706 12.4047 5.51529 13.28 6.22118 13.9765C6.92706 14.6824 7.78353 15.0306 8.83765 15.0588C10.6071 15.0118 12.0471 14.3435 13.2235 13.0165C14.4 11.6988 15.0118 10.0047 15.0682 7.98118C15.0212 5.96706 14.3435 4.32941 13.0071 2.99294C11.6894 1.67529 10.0047 0.988235 7.99059 0.931765C5.97647 0.978823 4.33883 1.65647 3.00236 2.99294C1.66588 4.32941 0.997647 5.96706 0.941176 8.00941C0.941176 8.2353 1.00706 8.42353 1.15765 8.56471C1.44941 8.85647 1.98588 8.83765 2.24941 8.59294C2.56 8.30118 2.9553 8.15059 3.41647 8.15059ZM8.83929 4.94031C9.04929 5.15031 9.3093 5.25031 9.6293 5.25031C9.9493 5.25031 10.2193 5.15031 10.4193 4.94031C10.6193 4.73031 10.7293 4.47031 10.7293 4.16031C10.7293 3.85031 10.6293 3.59031 10.4193 3.38031C10.2093 3.17031 9.9493 3.07031 9.6293 3.07031C9.3093 3.07031 9.03929 3.17031 8.83929 3.38031C8.63929 3.59031 8.5293 3.85031 8.5293 4.17031C8.5293 4.47031 8.62929 4.72031 8.83929 4.93031V4.94031ZM12.579 7.46125C12.269 7.46125 12.009 7.36125 11.799 7.15125V7.14125C11.599 6.93125 11.479 6.68125 11.459 6.38125C11.479 6.06125 11.589 5.80125 11.799 5.59125C12.009 5.38125 12.269 5.28125 12.579 5.28125C12.889 5.28125 13.149 5.38125 13.359 5.59125C13.569 5.80125 13.669 6.06125 13.669 6.37125C13.669 6.68125 13.569 6.94125 13.359 7.15125C13.149 7.36125 12.889 7.46125 12.579 7.46125ZM11.799 10.8309C12.009 11.0409 12.269 11.1409 12.579 11.1409C12.889 11.1409 13.149 11.0409 13.359 10.8309C13.569 10.6209 13.669 10.3609 13.669 10.0509C13.669 9.74094 13.569 9.48094 13.359 9.27094C13.149 9.06094 12.889 8.96094 12.579 8.96094C12.269 8.96094 12.009 9.06094 11.799 9.27094C11.589 9.48094 11.479 9.73094 11.459 10.0309C11.479 10.3509 11.599 10.6209 11.799 10.8209V10.8309ZM9.6293 13.3499C9.3093 13.3499 9.04929 13.2499 8.83929 13.0399V13.0299C8.62929 12.8299 8.5293 12.5599 8.5293 12.2399C8.5293 11.9399 8.63929 11.6899 8.83929 11.4799C9.03929 11.2699 9.3093 11.1699 9.6293 11.1699C9.9493 11.1699 10.2093 11.2699 10.4193 11.4799C10.6293 11.6899 10.7293 11.9499 10.7293 12.2599C10.7293 12.5699 10.6193 12.8299 10.4193 13.0399C10.2193 13.2499 9.9493 13.3499 9.6293 13.3499Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/InputControls.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The ColorPicker allows users to select a color visually in a WYSIWYG interface. The control provides RGB, HSV, and hex color modes for color selection.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Color Picker.png", UriKind.RelativeOrAbsolute));
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M12 1H2C1.44772 1 1 1.44772 1 2V14C1 14.5523 1.44772 15 2 15H12C12.5523 15 13 14.5523 13 14V2C13 1.44772 12.5523 1 12 1ZM2 0C0.895431 0 0 0.895431 0 2V14C0 15.1046 0.89543 16 2 16H12C13.1046 16 14 15.1046 14 14V2C14 0.895431 13.1046 0 12 0H2ZM10.5 3H3.5C3.22386 3 3 3.22386 3 3.5C3 3.77614 3.22386 4 3.5 4H10.5C10.7761 4 11 3.77614 11 3.5C11 3.22386 10.7761 3 10.5 3ZM3.5 2C2.67157 2 2 2.67157 2 3.5C2 4.32843 2.67157 5 3.5 5H10.5C11.3284 5 12 4.32843 12 3.5C12 2.67157 11.3284 2 10.5 2H3.5ZM4 7.29289L3.35355 6.64645C3.15829 6.45118 2.84171 6.45118 2.64645 6.64645C2.45118 6.84171 2.45118 7.15829 2.64645 7.35355L3.29289 8L2.64645 8.64645C2.45118 8.84171 2.45118 9.15829 2.64645 9.35355C2.84171 9.54882 3.15829 9.54882 3.35355 9.35355L4 8.70711L4.64645 9.35355C4.84171 9.54882 5.15829 9.54882 5.35355 9.35355C5.54882 9.15829 5.54882 8.84171 5.35355 8.64645L4.70711 8L5.35355 7.35355C5.54882 7.15829 5.54882 6.84171 5.35355 6.64645C5.15829 6.45118 4.84171 6.45118 4.64645 6.64645L4 7.29289ZM10 6.5C10.2761 6.5 10.5 6.72386 10.5 7V7.5H11C11.2761 7.5 11.5 7.72386 11.5 8C11.5 8.27614 11.2761 8.5 11 8.5H10.5V9C10.5 9.27614 10.2761 9.5 10 9.5C9.72386 9.5 9.5 9.27614 9.5 9V8.5H9C8.72386 8.5 8.5 8.27614 8.5 8C8.5 7.72386 8.72386 7.5 9 7.5H9.5V7C9.5 6.72386 9.72386 6.5 10 6.5ZM9 11C8.72386 11 8.5 11.2239 8.5 11.5C8.5 11.7761 8.72386 12 9 12H11C11.2761 12 11.5 11.7761 11.5 11.5C11.5 11.2239 11.2761 11 11 11H9ZM2.5 12.5C2.5 12.2239 2.72386 12 3 12H5C5.27614 12 5.5 12.2239 5.5 12.5C5.5 12.7761 5.27614 13 5 13H3C2.72386 13 2.5 12.7761 2.5 12.5ZM9 13C8.72386 13 8.5 13.2239 8.5 13.5C8.5 13.7761 8.72386 14 9 14H11C11.2761 14 11.5 13.7761 11.5 13.5C11.5 13.2239 11.2761 13 11 13H9Z"),
                Width = 14,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/InputControls.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Calculator provides interface that is useful when end users need to perform simple calculations without switching to external applications.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Calculator.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "The SfCalculator control allows end users to perform simple calculations without switching to external applications.", GroupName = "Calculator", DemoViewType = typeof(CalculatorDemo), ThemeMode = ThemeMode.Inherit });

        }
    }

    public class RatingProductDemos : ProductDemo
    {
        public RatingProductDemos()
        {
            this.Product = "Rating";
            this.ProductCategory = "INPUT CONTROLS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M7.96829 1.5L9.54427 4.58813C9.83487 5.15757 10.3802 5.55377 11.0116 5.65418L14.4356 6.19874L11.9856 8.65186C11.5338 9.10421 11.3255 9.74527 11.4251 10.3768L11.9653 13.8015L8.87513 12.2294C8.59023 12.0845 8.27926 12.012 7.96829 12.012V1.5ZM7.07758 1.04544C7.44872 0.318187 8.48787 0.318187 8.85901 1.04544L10.435 4.13357C10.5803 4.41829 10.8529 4.61639 11.1686 4.66659L14.5926 5.21115C15.399 5.33939 15.7201 6.32768 15.1431 6.90539L12.6931 9.35852C12.4672 9.58469 12.3631 9.90522 12.4129 10.221L12.9531 13.6457C13.0803 14.4522 12.2396 15.063 11.5119 14.6928L8.42171 13.1207C8.13681 12.9758 7.79978 12.9758 7.51487 13.1207L4.42473 14.6928C3.697 15.063 2.85631 14.4522 2.98352 13.6457L3.52368 10.221C3.57349 9.90522 3.46934 9.58469 3.24346 9.35852L0.793473 6.90539C0.216505 6.32768 0.53762 5.33939 1.34397 5.21115L4.76795 4.66659C5.08364 4.61639 5.3563 4.41829 5.5016 4.13357L7.07758 1.04544Z"),
                Width = 16,
                Height = 15,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/InputControls.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF Rating control allows users to select rating values from a group of visual symbols like stars.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Rating.png", UriKind.RelativeOrAbsolute));
            DemoInfo GettingStartedRatingDemo = new DemoInfo()
            {
                SampleName = "Getting Started", GroupName = "Rating", Description = "The Rating control allows users to rate items based on a specified list of options.", DemoViewType = typeof(RatingDemo), ThemeMode = ThemeMode.Inherit
            };
            List<Documentation> GettingStartedRatingDocuments = new List<Documentation>()
            {
                new Documentation(){ Content="Rating - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/rating/getting-started")},
            };
            GettingStartedRatingDemo.Documentations = GettingStartedRatingDocuments;
            this.Demos.Add(GettingStartedRatingDemo);
        }
    }

    public class RangeSliderProductDemos : ProductDemo
    {
        public RangeSliderProductDemos()
        {
            this.Product = "Range Slider";
            this.ProductCategory = "INPUT CONTROLS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M4.8268 3C5.65467 3 6.32578 2.32843 6.32578 1.5C6.32578 0.671573 5.65467 0 4.8268 0C3.99894 0 3.32782 0.671573 3.32782 1.5C3.32782 2.32843 3.99894 3 4.8268 3ZM2.29844 1C2.25847 1.18 2.22849 1.37 2.22849 1.56H2.23848C2.23848 1.71 2.25847 1.86 2.27845 2H0.499661C0.219851 2 0 1.78 0 1.5C0 1.22 0.219851 1 0.499661 1H2.29844ZM2.29844 8C2.25847 8.18 2.22849 8.37 2.22849 8.56H2.23848C2.23848 8.71 2.25847 8.86 2.27845 9H0.499661C0.219851 9 0 8.78 0 8.5C0 8.22 0.219851 8 0.499661 8H2.29844ZM6.32578 8.5C6.32578 9.32843 5.65467 10 4.8268 10C3.99894 10 3.32782 9.32843 3.32782 8.5C3.32782 7.67157 3.99894 7 4.8268 7C5.65467 7 6.32578 7.67157 6.32578 8.5ZM9.033 2C9.01302 1.86 8.99303 1.71 8.99303 1.56C8.99303 1.37 9.02301 1.18 9.06298 1H7.36414C7.40411 1.18 7.43409 1.37 7.43409 1.56C7.43409 1.70114 7.4164 1.83343 7.39766 1.97352L7.39765 1.97354L7.39412 2H9.033ZM8.99303 8.56C8.99303 8.71 9.01302 8.86 9.033 9H7.39412L7.39765 8.97354L7.39766 8.97353C7.4164 8.83343 7.43409 8.70114 7.43409 8.56C7.43409 8.37 7.40411 8.18 7.36414 8H9.06298C9.02301 8.18 8.99303 8.37 8.99303 8.56ZM15.4903 1H14.1213C14.1612 1.18 14.1912 1.37 14.1912 1.56C14.1912 1.70118 14.1735 1.83351 14.1548 1.97366L14.1513 2H15.5003C15.7801 2 16 1.78 16 1.5C16 1.22 15.7801 1 15.5003 1H15.4903ZM14.1213 8H15.4903H15.5003C15.7801 8 16 8.22 16 8.5C16 8.78 15.7801 9 15.5003 9H14.1513L14.1548 8.97366C14.1735 8.83352 14.1912 8.70119 14.1912 8.56C14.1912 8.37 14.1612 8.18 14.1213 8ZM11.5917 3C12.4196 3 13.0907 2.32843 13.0907 1.5C13.0907 0.671573 12.4196 0 11.5917 0C10.7639 0 10.0928 0.671573 10.0928 1.5C10.0928 2.32843 10.7639 3 11.5917 3ZM13.0907 8.5C13.0907 9.32843 12.4196 10 11.5917 10C10.7639 10 10.0928 9.32843 10.0928 8.5C10.0928 7.67157 10.7639 7 11.5917 7C12.4196 7 13.0907 7.67157 13.0907 8.5Z"),
                Width = 16,
                Height = 10,
            };
            this.Tag = Tag.None;
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/InputControls.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Range Slider control allows you to select a range of values within a specified minimum and maximum limit. The range can be selected by moving the thumb control along a track. The control is intended to provide a UI to filter collection items within a range.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Range Slider.png", UriKind.RelativeOrAbsolute));
            DemoInfo GettingStartedRangeSliderDemo = new DemoInfo()
            {
                SampleName = "Getting Started", GroupName = "Range Slider", Description = "This sample showcases the usage of Range Slider as a normal slider and a range selector.", DemoViewType = typeof(RangeSliderDemo), ThemeMode = ThemeMode.Inherit
            };
            List<Documentation> GettingStartedRangeSliderDocuments = new List<Documentation>()
            {
                new Documentation(){ Content="Range Slider - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/range-slider/getting-started")},
            };
            GettingStartedRangeSliderDemo.Documentations = GettingStartedRangeSliderDocuments;
            this.Demos.Add(GettingStartedRangeSliderDemo);

            DemoInfo CustomizationRangeSliderDemo = new DemoInfo()
            {
                SampleName = "Customization", GroupName = "Range Slider", Description = "This sample showcases the different customizations that can be done for the track, thumb, and tooltip of Range Slider.", DemoViewType = typeof(Customization), ThemeMode = ThemeMode.Default, Tag = Tag.None
            };
            List<Documentation> CustomizationRangeSliderDocuments = new List<Documentation>()
            {
                new Documentation(){ Content="Range Slider - Customization", Uri = new Uri("https://help.syncfusion.com/wpf/range-slider/customization")},
            };
            CustomizationRangeSliderDemo.Documentations = CustomizationRangeSliderDocuments;
            this.Demos.Add(CustomizationRangeSliderDemo);
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

    public class RadialSliderProductDemos : ProductDemo
    {
        public RadialSliderProductDemos()
        {
            this.Product = "Radial Slider";
            this.ProductCategory = "INPUT CONTROLS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M8 15C11.866 15 15 11.866 15 8C15 6.12741 14.2647 4.42656 13.0671 3.17042C13.2312 3.34261 13.387 3.52366 13.5337 3.71308C14.4842 4.93999 15 6.44799 15 8H11C11 9.65685 9.65685 11 8 11C6.34315 11 5 9.65685 5 8C5 6.34315 6.34315 5 8 5C8.25892 5 8.51018 5.0328 8.74985 5.09447L9.74922 1.22208C10.9107 1.52182 11.9696 2.11329 12.8296 2.93292C11.5734 1.7353 9.87259 1 8 1C4.13401 1 1 4.13401 1 8C1 11.866 4.13401 15 8 15ZM8 16C12.4183 16 16 12.4183 16 8C16 3.58172 12.4183 0 8 0C3.58172 0 0 3.58172 0 8C0 12.4183 3.58172 16 8 16ZM8 10C9.10457 10 10 9.10457 10 8C10 6.89543 9.10457 6 8 6C6.89543 6 6 6.89543 6 8C6 9.10457 6.89543 10 8 10Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/InputControls.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Radial Slider control (circular slider) provides an intuitive interface for selecting a numeric value on a circular display. ";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Radial Slider.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This SfRadialSlider control allows end user to select a numeric value within the minimum and maximum range in the circular track.", GroupName = "Radial Slider", DemoViewType = typeof(SfRadialSliderDemo) });
        }
    }
}