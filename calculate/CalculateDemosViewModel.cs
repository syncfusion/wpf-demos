using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.calculatedemos.wpf
{
    public class CalculateDemosViewModel: DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new CalculatorProductDemos());
            return productdemos;
        }
    }

    public class CalculatorProductDemos : ProductDemo
    {
        public CalculatorProductDemos()
        {
            this.Product = "Calculate";
            this.ProductCategory = "MISCELLANEOUS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V4H1V2C1 1.44772 1.44772 1 2 1ZM0 5V4V2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V12C14 13.1046 13.1046 14 12 14H2C0.89543 14 0 13.1046 0 12V5ZM1 5H13V12C13 12.5523 12.5523 13 12 13H2C1.44772 13 1 12.5523 1 12V5ZM2.5 7.5C2.5 7.22386 2.72386 7 3 7H6C6.27614 7 6.5 7.22386 6.5 7.5C6.5 7.77614 6.27614 8 6 8H3C2.72386 8 2.5 7.77614 2.5 7.5ZM3 10C2.72386 10 2.5 10.2239 2.5 10.5C2.5 10.7761 2.72386 11 3 11H6C6.27614 11 6.5 10.7761 6.5 10.5C6.5 10.2239 6.27614 10 6 10H3ZM8 7.5C8 6.94772 8.44772 6.5 9 6.5H10C10.5523 6.5 11 6.94772 11 7.5C11 8.05228 10.5523 8.5 10 8.5H9C8.44771 8.5 8 8.05228 8 7.5ZM9 9.5C8.44772 9.5 8 9.94771 8 10.5C8 11.0523 8.44771 11.5 9 11.5H10C10.5523 11.5 11 11.0523 11 10.5C11 9.94771 10.5523 9.5 10 9.5H9Z"),
                Width = 14,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Miscellaneous.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.ControlDescription = "Calculate is a .NET class library that adds extensive calculation support, including a function library of over 400 Excel-compatible functions.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Calculate.png", UriKind.RelativeOrAbsolute));

            List<Documentation> arrayCalculationDocumentation = new List<Documentation>();
            arrayCalculationDocumentation.Add(new Documentation { Content = "Calculate - ICalcData API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Calculate.ICalcData.html") });
            this.Demos.Add(new DemoInfo() { SampleName = "Array Calculation", GroupName = "PRODUCT SHOWCASE", Description = "This sample illustrates how to add calculation support to a double array by wrapping the array in a class that implements the ICalcData interface.", DemoViewType = typeof(ArrayCalculationDemo), Documentations = arrayCalculationDocumentation });

            List<Documentation> gettingStartedDocumentation = new List<Documentation>();
            gettingStartedDocumentation.Add(new Documentation { Content = "Calculate - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/windowsforms/calculation-engine/getting-started") });
            this.Demos.Add(new DemoInfo() { SampleName = "Function Library", GroupName = "GETTING STARTED", Description = "This sample explains about different formulas supported by CalcQuick objects. The following displays the sample output image.", DemoViewType = typeof(GettingStarted), Documentations = gettingStartedDocumentation });

            List<Documentation> calcQuickDocumentation = new List<Documentation>();
            calcQuickDocumentation.Add(new Documentation { Content = "Caculate - CalcQuickBase API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Calculate.CalcQuickBase.html") });
            calcQuickDocumentation.Add(new Documentation { Content = "Calculate - CalcQuick Documentation", Uri = new Uri("https://help.syncfusion.com/windowsforms/calculation-engine/working-with-calcquick") });
            this.Demos.Add(new DemoInfo() { SampleName = "CalcQuick", GroupName = "CALCQUICK", Description = "This sample illustrates how to quickly add calculations support for usercontrol or controls on an application.", DemoViewType = typeof(CalcQuickDemo), Documentations = calcQuickDocumentation });

        }
    }
}
