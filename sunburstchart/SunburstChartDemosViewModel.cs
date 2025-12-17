using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.sunburstchartdemos.wpf
{
    public class SunburstChartDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SunburstChartProductDemos());
            return productdemos;
        }
    }

    public class SunburstChartProductDemos : ProductDemo
    {
        public SunburstChartProductDemos()
        {
            this.Product = "Sunburst Chart";
            this.ProductCategory = "CHARTS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M4.08853 1.75411C5.14782 1.16607 6.36033 0.912489 7.5665 1.02674C7.84141 1.05279 8.08538 0.851036 8.11143 0.576125C8.13747 0.301213 7.93572 0.0572425 7.66081 0.0312011C6.2536 -0.102097 4.83902 0.193743 3.60317 0.879797C2.36733 1.56585 1.36813 2.60997 0.737057 3.87478C0.61377 4.12187 0.714135 4.42212 0.961228 4.54541C1.20832 4.6687 1.50857 4.56833 1.63186 4.32124C2.17278 3.23712 3.02923 2.34216 4.08853 1.75411ZM1.0578 7.82597C1.01979 7.55245 0.767244 7.36154 0.493731 7.39956C0.220218 7.43757 0.0293077 7.69011 0.0673215 7.96363C0.226541 9.10923 0.667145 10.1975 1.34975 11.1312C2.03235 12.0649 2.93568 12.8149 3.97897 13.3142C4.22806 13.4334 4.52662 13.3281 4.64582 13.079C4.76503 12.83 4.65973 12.5314 4.41065 12.4122C3.51639 11.9842 2.74211 11.3414 2.15702 10.5411C1.57194 9.74073 1.19427 8.80791 1.0578 7.82597ZM7.70385 4.08358C6.97883 3.90877 6.21469 4.01028 5.56046 4.36832C4.90622 4.72636 4.40881 5.31525 4.16521 6.02014C3.92162 6.72503 3.94932 7.49539 4.2429 8.18097C4.53649 8.86655 5.07491 9.41819 5.75317 9.72832C6.0043 9.84315 6.1148 10.1398 5.99997 10.391C5.88514 10.6421 5.58847 10.7526 5.33733 10.6378C4.43299 10.2243 3.71509 9.48873 3.32364 8.57462C2.9322 7.66051 2.89527 6.63337 3.22006 5.69352C3.54485 4.75366 4.20807 3.96847 5.08038 3.49109C5.9527 3.01371 6.97155 2.87836 7.93824 3.11144C8.20669 3.17616 8.37184 3.44625 8.30712 3.7147C8.24239 3.98315 7.9723 4.1483 7.70385 4.08358ZM10.2644 9.31263C10.424 9.08732 10.3708 8.77524 10.1455 8.61559C9.92018 8.45594 9.60811 8.50916 9.44845 8.73448C9.09777 9.22937 8.60531 9.60635 8.03603 9.81568C7.77686 9.91098 7.64401 10.1983 7.73931 10.4575C7.83461 10.7167 8.12197 10.8495 8.38115 10.7542C9.14019 10.4751 9.79681 9.9725 10.2644 9.31263ZM9.09789 4.15366C9.29148 3.95674 9.60806 3.95405 9.80497 4.14765C10.2164 4.55214 10.5354 5.04084 10.7402 5.58024C10.945 6.11963 11.0307 6.69694 10.9914 7.27255C10.9726 7.54806 10.734 7.75614 10.4585 7.73732C10.183 7.71851 9.97489 7.47992 9.99371 7.20442C10.0232 6.7727 9.95893 6.33972 9.80534 5.93518C9.65175 5.53063 9.41246 5.1641 9.1039 4.86074C8.90698 4.66714 8.90429 4.35057 9.09789 4.15366ZM13.2162 10.2198C13.3432 9.97464 13.2474 9.6729 13.0022 9.54588C12.757 9.41886 12.4553 9.51466 12.3283 9.75986C11.6365 11.0952 10.4686 12.122 9.05574 12.6371C8.7963 12.7317 8.66266 13.0187 8.75724 13.2781C8.85182 13.5375 9.13881 13.6712 9.39825 13.5766C11.0466 12.9757 12.4092 11.7777 13.2162 10.2198ZM9.59189 1.0179C9.72076 0.77367 10.0232 0.680154 10.2674 0.809025C11.3279 1.36857 12.2268 2.19112 12.878 3.19782C13.028 3.42968 12.9617 3.73922 12.7298 3.88922C12.498 4.03921 12.1884 3.97285 12.0384 3.74099C11.4802 2.8781 10.7097 2.17306 9.80076 1.69345C9.55654 1.56458 9.46302 1.26212 9.59189 1.0179ZM7.00068 8.5C7.82911 8.5 8.50068 7.82843 8.50068 7C8.50068 6.17158 7.82911 5.5 7.00068 5.5C6.17225 5.5 5.50068 6.17158 5.50068 7C5.50068 7.82843 6.17225 8.5 7.00068 8.5Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Charts.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The SunburstChart is a customizable data visualization control for displaying hierarchical data in a circular layout, with options for color palettes, labels, and tooltips.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Sunburst Chart.png", UriKind.RelativeOrAbsolute));

            DemoInfo GettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "SUNBURST CHART",

                Description = "This sample demonstrates the basic features in sunburst chart.",

                DemoViewType = typeof(GettingStarted),

            };

            List<Documentation> GettingStartedHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Sunburst Chart - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/sunburst-chart/getting-started")}
            };

            GettingStartedDemo.Documentations = GettingStartedHelpDocuments;
            this.Demos.Add(GettingStartedDemo);  
            this.Demos.Add(new DemoInfo() { SampleName = "Animation", GroupName = "SUNBURST CHART", DemoViewType = typeof(Animation), Description = "This sample demonstrates animation functionality in sunburst chart." });
            this.Demos.Add(new DemoInfo() { SampleName = "Selection", GroupName = "SUNBURST CHART", DemoViewType = typeof(Selection), Description = "This sample demonstrates interactive selection functionality in sunburst chart." });
            this.Demos.Add(new DemoInfo() { SampleName = "Zoom", GroupName = "SUNBURST CHART", DemoViewType = typeof(ZoomableSunburst), Description = "This sample demonstrates interactive zooming functionality in sunburst chart." });
        }
    }
}
