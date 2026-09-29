using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Model;
using syncfusion.diagramdemos.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class FunnelDiagramViewModel : DiagramViewModel
    {
        #region Colors
        private const string C1 = "#C2272D";
        private const string C2 = "#F16C0D";
        private const string C3 = "#FFC107";
        private const string C4 = "#4CB443";
        private const string C5 = "#008AE0";
        private const string C6 = "#8715BC";
        #endregion

        #region SVG Paths
        private const string P1 = "M560 0H0L56.7194 80H503.281L560 0Z";
        private const string P2 = "M446 0H0L56.648 80H389.352L446 0Z";
        private const string P3 = "M334 0H0L56.869 80H277.131L334 0Z";
        private const string P4 = "M220 0H0L56.801 80H163.199L220 0Z";
        private const string P5 = "M0 0H106V80H0Z";
        private const string P6 = "M0 0H106V80H0Z";
        #endregion

        #region Icon Path Data
        private const string Icon1 = "M4.3699951,12.678039L5.6099854,17.949037C5.71698,18.400026,6.1199951,18.718995,6.5839844,18.718995L7,18.718995C7.552002,18.718995,8,18.270997,8,17.718995L8,12.718993 5,12.718993C4.7869873,12.718993,4.5769958,12.70404,4.3699951,12.678039z M18,5.7189916L18,9.7189925C19.10498,9.7189925 20,8.824034 20,7.718992 20,6.6150492 19.10498,5.7189916 18,5.7189916z M5,4.7189916C3.3429871,4.7189916 2,6.0620091 2,7.718992 2,9.376036 3.3429871,10.718993 5,10.718993L8,10.718993 8,4.7189916z M16,2.6000333C14.615997,3.3730438 13.121002,3.8699923 11.904999,4.1830414 11.153992,4.3770116 10.490997,4.5029881 10,4.5850194L10,10.905028C10.009979,10.907042 10.019989,10.908995 10.029999,10.912047 10.548981,11.027037 11.268982,11.200011 12.074005,11.43103 13.274994,11.776 14.72998,12.265991 16,12.915038z M16.761786,0.00033078478C17.394739,0.01459883,18,0.48952875,18,1.2529873L18,3.7189911C20.208984,3.7189911 22,5.5100072 22,7.718992 22,9.9280379 20.208984,11.718993 18,11.718993L18,14.199035C18,15.27002 16.807983,15.773011 16.020996,15.240051 14.835999,14.436034 13.069,13.796996 11.52298,13.354003 10.955994,13.191039 10.431976,13.059997 10,12.958007L10,17.718995C10,19.376039,8.6569824,20.718995,7,20.718995L6.5839844,20.718995C5.1919861,20.718995,3.9830017,19.762025,3.6640015,18.407045L2.1080019,11.79602C0.83297729,10.890013 0,9.4030135 0,7.718992 0,4.9580052 2.2389832,2.7189908 5,2.7189911L8.9459839,2.7189911C8.9759827,2.7160001 9.0189819,2.7109952 9.0740051,2.7029996 9.1949768,2.688046 9.3739929,2.6630216 9.598999,2.6260345 10.048981,2.5530362 10.682983,2.4330411 11.405975,2.2460297 12.871979,1.8690151 14.625,1.2400477 15.987976,0.24004764L16.140991,0.1459922C16.336739,0.042003615,16.5508,-0.0044250747,16.761786,0.00033078478z";

        private const string Icon2 = "M11.000009,6.1250267C9.8950096,6.1250267 9.0000091,7.0210271 9.0000091,8.1250267 9.0000091,9.2300272 9.8950096,10.125027 11.000009,10.125027 12.10501,10.125027 13.000009,9.2300272 13.000009,8.1250267 13.000009,7.0210271 12.10501,6.1250267 11.000009,6.1250267z M11.000009,4.1250267C13.20901,4.1250267 15.000009,5.9160271 15.000009,8.1250267 15.000009,10.334027 13.20901,12.125027 11.000009,12.125027 8.7910095,12.125027 7.0000096,10.334027 7.0000096,8.1250267 7.0000096,5.9160271 8.7910095,4.1250267 11.000009,4.1250267z M11.187395,2.0000002C8.0853401,2 4.7573004,3.9250488 2.1652916,8.125 4.7573004,12.325012 8.0853401,14.25 11.187395,14.25 14.285421,14.25 17.498469,12.328003 19.860495,8.125 17.498469,3.9230347 14.285421,2 11.187395,2.0000002z M11.187395,0C15.351443,-1.3168167E-08 19.267472,2.6860351 21.884505,7.6589966 22.038498,7.9510498 22.038498,8.2990112 21.884505,8.5910034 19.267472,13.564026 15.351443,16.25 11.187395,16.25 7.0353409,16.25 3.0012997,13.578003 0.13426358,8.6260376 -0.044754527,8.31604 -0.044754527,7.934021 0.13426358,7.6240234 3.0012997,2.6719971 7.0353409,-1.3168167E-08 11.187395,0z";

        private const string Icon3 = "M4.9999999,13.999973L13,13.999973C15.760986,13.999973,18,16.238987,18,18.999973L18,19.999973C18,20.551975 17.552002,20.999973 17,20.999973 16.447998,20.999973 16,20.551975 16,19.999973L16,18.999973C16,17.342991,14.656982,15.999973,13,15.999973L4.9999999,15.999973C3.3429869,15.999973,1.9999999,17.342991,1.9999999,18.999973L1.9999999,19.999973C1.9999999,20.551975 1.5520018,20.999973 0.99999987,20.999973 0.44799791,20.999973 -1.3413208E-07,20.551975 2.8421709E-14,19.999973L2.8421709E-14,18.999973C-1.3413208E-07,16.238987,2.238983,13.999973,4.9999999,13.999973z M8.9999894,2C7.0669898,2 5.4999899,3.5670004 5.4999899,5.5 5.4999899,7.4330001 7.0669898,9 8.9999894,9 10.93299,9 12.499989,7.4330001 12.499989,5.5 12.499989,3.5670004 10.93299,2 8.9999894,2z M8.9999894,0C12.037989,0 14.499989,2.4630003 14.499989,5.5 14.499989,8.5380001 12.037989,11 8.9999894,11 5.9619897,11 3.4999899,8.5380001 3.4999901,5.5 3.4999899,2.4630003 5.9619897,0 8.9999894,0z";

        private const string Icon4 = "M8.9999886,6.7228865L8.9999886,11.277123 12.982986,9.0010051z M8.471489,4.36031C8.7287388,4.3550133,8.993989,4.4170164,9.243989,4.5597738L14.735986,7.6979369C15.743985,8.2739667,15.743985,9.7280425,14.735986,10.303073L9.243989,13.441235C8.243989,14.012265,6.99999,13.291227,6.99999,12.139168L6.99999,5.8618416C6.99999,4.9977964,7.6997395,4.3762015,8.471489,4.36031z M4,2.0000001C2.894989,1.9999999,2,2.896057,2,3.9999999L2,14C2,15.105041,2.894989,16,4,16L18,16C19.10498,16,20,15.105041,20,14L20,3.9999999C20,2.896057,19.10498,1.9999999,18,2.0000001z M4,0L18,0C20.208984,-8.9406967E-08,22,1.7910155,22,3.9999999L22,14C22,16.209045,20.208984,18,18,18L4,18C1.7909851,18,0,16.209045,0,14L0,3.9999999C0,1.7910155,1.7909851,-8.9406967E-08,4,0z";

        private const string Icon5 = "M5.0000002,15.000285L7.072,15.000285C7.0260001,15.326282 7.0000001,15.660279 7.0000001,16.000277 7.0000001,16.339273 7.0260001,16.673271 7.072,17.000268L5.0000002,17.000268C4.448,17.000268 4,16.552272 4,16.000277 4,15.447281 4.448,15.000285 5.0000002,15.000285z M16.249982,13.749745C15.993981,13.749745,15.737985,13.847508,15.542993,14.043035L13.249993,16.336003 12.456994,15.543035C12.066979,15.151982 11.432977,15.151982 11.042992,15.543035 10.651971,15.934026 10.651971,16.565984 11.042992,16.957036L12.542993,18.457036C12.932977,18.848027,13.566979,18.848027,13.956994,18.457036L16.956994,15.457036C17.347985,15.065984 17.347985,14.434026 16.956994,14.043035 16.761987,13.847508 16.505982,13.749745 16.249982,13.749745z M5.0000002,11.000318L9.103,11.000318C8.5160002,11.574313,8.0310001,12.250308,7.6750001,13.000301L5.0000002,13.000301C4.448,13.000301 4,12.552305 4,12.00031 4,11.447314 4.448,11.000318 5.0000002,11.000318z M13.999993,11.000005C16.76098,11.000005 18.999993,13.239018 18.999993,16.000005 18.999993,18.760991 16.76098,21.000005 13.999993,21.000005 11.238976,21.000005 8.9999933,18.760991 8.9999934,16.000005 8.9999933,13.239018 11.238976,11.000005 13.999993,11.000005z M6.0000002,6.0003595L6.0000002,7.0003512 12,7.0003512 12,6.0003595z M6.0000002,4.0003762L12,4.0003762C13.105,4.0003762,14,4.8953686,14,6.0003595L14,7.0003512C14,8.104342,13.105,9.0003346,12,9.0003347L6.0000002,9.0003347C4.895,9.0003346,4,8.104342,4,7.0003512L4,6.0003595C4,4.8953686,4.895,4.0003762,6.0000002,4.0003762z M16.982126,0.00015163422C17.170836,-0.0031328201 17.359625,0.047034264 17.525001,0.14940834 17.82,0.33140659 18,0.65340424 18,1.0004015L18,10.256324C17.396,9.8343277,16.723,9.5063305,16,9.2913324L16,2.6183882 15.447,2.8943853C15.166,3.0353842,14.834,3.0353842,14.553,2.8943853L13,2.118392 11.447,2.8943853C11.166,3.0353842,10.834,3.0353842,10.553,2.8943853L9.0000003,2.118392 7.4470003,2.8943853C7.1660001,3.0353842,6.8340001,3.0353842,6.5530002,2.8943853L5.0000002,2.118392 3.447,2.8943853C3.1660004,3.0353842,2.8340001,3.0353842,2.553,2.8943853L2,2.6183882 2,19.381248 2.553,19.10525C2.8340001,18.964252,3.1660004,18.964252,3.447,19.10525L5.0000002,19.881244 6.5530002,19.10525C6.8340001,18.964252,7.1660001,18.964252,7.4470003,19.10525L7.8210003,19.292249C8.3240002,20.234241,9.0370002,21.046234,9.896,21.66923L9.4470001,21.894227C9.1660002,22.035226,8.8340002,22.035226,8.5530002,21.894227L7.0000001,21.118234 5.4470005,21.894227C5.1660001,22.035226,4.8340001,22.035226,4.553,21.894227L3,21.118234 1.447,21.894227C1.1370001,22.049226 0.76900005,22.032227 0.47500038,21.850227 0.18000031,21.668229 0,21.346231 0,21.000235L0,1.0004015C0,0.65340424 0.18000031,0.33140659 0.47500038,0.14940834 0.64037514,0.047034264 0.82916451,-0.0031328201 1.0178742,0.00015163422 1.1646485,0.0027065277 1.3113751,0.037596703 1.447,0.10540867L3,0.88140202 4.553,0.10540867 4.6600003,0.059409142C4.9160004,-0.032589912,5.2010002,-0.017590523,5.4470005,0.10540867L7.0000001,0.88140202 8.5530002,0.10540867 8.66,0.059409142C8.9160002,-0.032589912,9.2010002,-0.017590523,9.4470001,0.10540867L11,0.88140202 12.553,0.10540867 12.66,0.059409142C12.916,-0.032589912,13.201,-0.017590523,13.447,0.10540867L15,0.88140202 16.553,0.10540867C16.688625,0.037596703,16.835352,0.0027065277,16.982126,0.00015163422z";

        private const string Icon6 = "M2.8220494,3.0701222L2.0380752,11.693925 8.206872,17.862785C8.6448576,18.300773 9.3548341,18.300773 9.79282,17.862785 10.230805,17.424795 10.230805,16.714811 9.79282,16.276821L9.2928362,15.776832C8.9018493,15.38684 8.9018493,14.753855 9.2928362,14.362864 9.6349497,14.020747 10.162339,13.977982 10.550101,14.23457 10.605834,14.271374 10.658493,14.314137 10.707371,14.363009L12.707497,16.362888C13.145525,16.800861 13.855569,16.800861 14.293597,16.362888 14.704247,15.952288 14.729914,15.302639 14.370594,14.862158L14.30185,14.786113 12.293222,12.777436C11.902203,12.386436 11.902203,11.753428 12.293222,11.362429 12.683205,10.972407 13.316196,10.972407 13.707216,11.362429L16.207204,13.86248C16.64519,14.300476 17.355178,14.300476 17.793195,13.86248 18.23118,13.425458 18.23118,12.715483 17.793195,12.277425L13.914216,8.3983797C13.133214,7.6173581,11.867229,7.6173581,11.086227,8.3983797L10.121236,9.362389C8.9502215,10.534409,7.0502374,10.534409,5.8792534,9.362389L5.7072572,9.1913647C4.5362425,8.0193438,4.5362425,6.1203188,5.7072572,4.9482984L7.5853863,3.0701222z M13.34229,2.000107C12.502034,1.9928713,11.647167,2.2637691,10.611224,2.8712906L7.1212518,6.362328C6.7312387,6.7533273,6.7312387,7.3863358,7.1212518,7.7773346L7.2932477,7.9483585C7.6832297,8.3393578,8.3172293,8.3393578,8.707242,7.9483585L9.6722331,6.9843501C11.234207,5.4223069,13.766207,5.4223069,15.328211,6.9843501L19.207189,10.862419C19.245282,10.900513,19.282185,10.939348,19.317898,10.978876L19.396168,11.070035 19.903873,11.070035 19.193707,3.2507464 17.696179,3.5502598C17.436202,3.6022627 17.166183,3.5492832 16.945176,3.4022464 15.521203,2.4522762 14.446196,2.054258 13.510196,2.0052458 13.454259,2.0023083 13.398307,2.0005898 13.34229,2.000107z M13.344055,0.00012429846C13.43396,0.00071186111 13.524331,0.0033857794 13.615207,0.0081963473 14.945187,0.078204942 16.262197,0.60220234 17.698194,1.5102406L19.01178,1.2476271 19.003928,1.1611753C18.953931,0.61118297 19.358907,0.12418984 19.908873,0.074190584 20.458839,0.02419125 20.945809,0.42918555 20.995807,0.97917793L21.995746,11.979022C22.021745,12.259019 21.927751,12.537015 21.737761,12.745012 21.548774,12.95201 21.280789,13.070008 20.999806,13.070008L20.121428,13.070008 20.117859,13.21972C20.082146,13.968101 19.778589,14.70607 19.207189,15.277485 18.521491,15.962634 17.596288,16.262388 16.701029,16.176744L16.565773,16.160535 16.564849,16.166006C16.450561,16.756162 16.16484,17.319705 15.707685,17.776803 14.67909,18.805273 13.111541,18.96597 11.914522,18.258897L11.892147,18.244914 11.831728,18.383979C11.681739,18.707229 11.473421,19.010101 11.206773,19.276752 9.9878135,20.495723 8.0118783,20.495723 6.7929183,19.276752L0.29313231,12.7769C0.08313942,12.566904,-0.022857189,12.274911,0.0041418076,11.978918L1.0041091,0.97917007C1.0541074,0.42918239 1.5410914,0.024191652 2.0910733,0.074190584 2.6100562,0.12118943 3.0010433,0.55817942 3.0000435,1.0701679L9.7280059,1.0701679 9.959363,0.94150881C11.064352,0.3440869,12.164052,-0.0075889729,13.344055,0.00012429846z";
        #endregion

        #region Templates
        private DataTemplate _titleMainTemplate;
        private  DataTemplate _titleSubTemplate;
        private  DataTemplate _segmentValueTemplate;
        private  DataTemplate _iconGlyphTemplate;
        private  DataTemplate _stageLabelTemplate;
        #endregion


        public DemoControl View;

        public FunnelDiagramViewModel()
        {
         
        }

        #region Helpermethods
        public void TemplatedInitilization()
        {
            var nodeCollection = new NodeCollection();
            var connectorCollection = new ConnectorCollection();
            _titleMainTemplate = View.Resources["TitleMainTemplate"] as DataTemplate;
            _titleSubTemplate = View.Resources["TitleSubTemplate"] as DataTemplate;
            _segmentValueTemplate = View.Resources["SegmentValueTemplate"] as DataTemplate;
            _iconGlyphTemplate = View.Resources["IconGlyphTemplate"] as DataTemplate;
            _stageLabelTemplate = View.Resources["StageLabelTemplate"] as DataTemplate;

            var stages = new[]
           {
                new FunnelStageModel { Id="awareness",     Label="Ad Exposure",      DisplayValue="10,000", Color=C1, PathData=P1, NodeWidth=560, NodeHeight=80, OffsetX=280, OffsetY=120, P1=new Point(568.15,144), P2=new Point(595.66,120), ConversionRate=null,  CumulativeRate=100, IconText=Icon1 },
                new FunnelStageModel { Id="interest",      Label="Page Visits",      DisplayValue="6,500",  Color=C2, PathData=P2, NodeWidth=446, NodeHeight=80, OffsetX=280, OffsetY=200, P1=new Point(568.15,224), P2=new Point(595.66,200), ConversionRate=65.00, CumulativeRate=65,  IconText=Icon2 },
                new FunnelStageModel { Id="consideration", Label="Sign Ups",         DisplayValue="3,800",  Color=C3, PathData=P3, NodeWidth=334, NodeHeight=80, OffsetX=280, OffsetY=280, P1=new Point(568.15,304), P2=new Point(595.66,280), ConversionRate=58.46, CumulativeRate=38,  IconText=Icon3 },
                new FunnelStageModel { Id="intent",        Label="Demo Requests",    DisplayValue="2,000",  Color=C4, PathData=P4, NodeWidth=220, NodeHeight=80, OffsetX=280, OffsetY=360, P1=new Point(568.15,384), P2=new Point(595.66,360), ConversionRate=52.63, CumulativeRate=20,  IconText=Icon4 },
                new FunnelStageModel { Id="purchase",      Label="Orders",           DisplayValue="1,200",  Color=C5, PathData=P5, NodeWidth=106, NodeHeight=80, OffsetX=280, OffsetY=440, P1=new Point(568.15,464), P2=new Point(595.66,440), ConversionRate=60.00, CumulativeRate=12,  IconText=Icon5 },
                new FunnelStageModel { Id="retention",     Label="Subscribed Users", DisplayValue="800",    Color=C6, PathData=P6, NodeWidth=106, NodeHeight=80, OffsetX=280, OffsetY=520, P1=new Point(568.15,544), P2=new Point(595.66,520), ConversionRate=66.67, CumulativeRate=8,   IconText=Icon6 },
            };

            nodeCollection.Add(CreateTitleNode());

            foreach (var s in stages)
            {
                nodeCollection.Add(CreateStageNode(s));
                nodeCollection.Add(CreateLabelCircleNode(s));
                nodeCollection.Add(CreateLabelTextNode(s));
                connectorCollection.Add(CreateConnector(s));
            }

            Nodes = nodeCollection;
            Connectors = connectorCollection;
            SnapSettings = new SnapSettings { SnapConstraints = SnapConstraints.None };
        }

        private NodeViewModel CreateTitleNode()
        {
            return new NodeViewModel
            {
                ID = "title",
                OffsetX = 280,
                OffsetY = -20,
                UnitWidth = 400,
                UnitHeight = 60,
                Shape = new RectangleGeometry(new Rect(0, 0, 400, 60)),
                ShapeStyle = MakeShapeStyle("Transparent", "Transparent"),
                Constraints = NodeConstraints.Default
                           & ~NodeConstraints.Draggable
                           & ~NodeConstraints.Selectable
                           & ~NodeConstraints.Delete,
                Annotations = new ObservableCollection<IAnnotation>
                {
                    new AnnotationEditorViewModel
                    {
                        Content      = "Marketing Funnel",
                        Offset       = new Point(0.5, 0.3),
                        ViewTemplate = _titleMainTemplate,
                        FontSize = 24,
                        ReadOnly = true,

                    },
                    new AnnotationEditorViewModel
                    {
                        Content      = "Measuring Campaign Effectiveness",
                        Offset       = new Point(0.5, 0.75),
                        ViewTemplate = _titleSubTemplate,
                        FontSize = 16, ReadOnly = true,
                    }
                }
            };
        }

        private FunnelNodeViewModel CreateStageNode(FunnelStageModel s)
        {
            return new FunnelNodeViewModel
            {
                ID = s.Id,
                OffsetX = s.OffsetX,
                OffsetY = s.OffsetY,
                UnitWidth = s.NodeWidth,
                UnitHeight = s.NodeHeight,
                Shape = Geometry.Parse(s.PathData),
                ShapeStyle = MakeShapeStyle(s.Color, "Transparent"),
                Constraints = NodeConstraints.Default
                           & ~NodeConstraints.Draggable
                           & ~NodeConstraints.Selectable
                           & ~NodeConstraints.Delete,
                TooltipData = new FunnelTooltipModel
                {
                    Label = s.Label,
                    IconText = s.IconText,
                    Color = s.Color,
                    CumulativeText = $"{s.CumulativeRate}%",
                    ConversionText = s.ConversionRate.HasValue
                                        ? $"{s.ConversionRate:0.##}%"
                                        : null
                },
                Ports = new ObservableCollection<IPort>
                {
                    new NodePortViewModel
                    {
                        ID          = s.Id + "_rightPort",
                        // ✅ Top-right corner of bounding box = start of connector
                        NodeOffsetX = 0.7,
                        NodeOffsetY = 0.8,
                        PortVisibility = PortVisibility.Collapse,
                        Constraints = PortConstraints.None
                    }
                },
                Annotations = new ObservableCollection<IAnnotation>
                {
                    new AnnotationEditorViewModel
                    {
                        Content      = s.DisplayValue,
                        Offset       = new Point(0.5, 0.5),
                        ViewTemplate = _segmentValueTemplate,
                         ReadOnly = true,
                    }
                }
            };
        }

        private NodeViewModel CreateLabelCircleNode(FunnelStageModel s)
        {
            return new NodeViewModel
            {
                ID = s.Id + "_label",
                OffsetX = 770,
                OffsetY = s.OffsetY,
                UnitWidth = 56,
                UnitHeight = 56,
                Shape = new EllipseGeometry(new Point(28, 28), 28, 28),
                ShapeStyle = MakeShapeStyle(s.Color, s.Color),
                Constraints = NodeConstraints.Default
                           & ~NodeConstraints.Draggable
                           & ~NodeConstraints.Selectable
                           & ~NodeConstraints.Delete,
                Ports = new ObservableCollection<IPort>
                {
                    new NodePortViewModel
                    {
                        ID          = s.Id + "_leftPort",
                        NodeOffsetX = 0.0,
                        NodeOffsetY = 0.5,
                        PortVisibility = PortVisibility.Collapse,
                        Constraints = PortConstraints.None
                    }
                },
                Annotations = new ObservableCollection<IAnnotation>
                {
                    new AnnotationEditorViewModel
                    {
                        Content      = s.IconText,
                        Offset       = new Point(0.5, 0.5),
                        ViewTemplate = _iconGlyphTemplate,  ReadOnly = true,

                    }
                }
            };
        }

        private NodeViewModel CreateLabelTextNode(FunnelStageModel s)
        {
            return new NodeViewModel
            {
                ID = s.Id + "_text",
                OffsetX = 640,
                OffsetY = s.OffsetY - 20,
                UnitWidth = 130,
                UnitHeight = 20,
                Shape = new RectangleGeometry(new Rect(0, 0, 130, 20)),
                ShapeStyle = MakeShapeStyle("Transparent", "Transparent"),
                Constraints = NodeConstraints.Default
                           & ~NodeConstraints.Draggable
                           & ~NodeConstraints.Selectable
                           & ~NodeConstraints.Delete,
                Annotations = new ObservableCollection<IAnnotation>
                {
                    new AnnotationEditorViewModel
                    {
                        Content      = s.Label,
                        Offset       = new Point(0.8, 0.7),
                        ViewTemplate = _stageLabelTemplate,
                        FontWeight = FontWeights.Normal,  ReadOnly = true,
                    }
                }
            };
        }

        private ConnectorViewModel CreateConnector(FunnelStageModel s)
        {
            var strokeBrush = new SolidColorBrush(
                (Color)ColorConverter.ConvertFromString(s.Color));

            var lineStyle = new Style(typeof(Path));
            lineStyle.Setters.Add(new Setter(Path.StrokeProperty, strokeBrush));
            lineStyle.Setters.Add(new Setter(Path.StrokeThicknessProperty, 1.5));

            var decoratorStyle = new Style(typeof(Path));
            decoratorStyle.Setters.Add(
                new Setter(Path.VisibilityProperty, Visibility.Collapsed));

            return new ConnectorViewModel
            {
                SourceNodeID = s.Id,
                SourcePortID = s.Id + "_rightPort",
                TargetNodeID = s.Id + "_label",
                TargetPortID = s.Id + "_leftPort",
               
                // ✅ Two StraightSegments = JS demo equivalent:
                //    segments: [
                //        { type: 'Straight', point: { x: p1x, y: p1y } },   ← diagonal
                //        { type: 'Straight', point: { x: p2x, y: p2y } },   ← horizontal to circle
                //    ]
                Segments = new ObservableCollection<IConnectorSegment>
                {
                    new StraightSegment { Point = s.P1 },  // diagonal waypoint
                    new StraightSegment { Point = s.P2 },  // horizontal approach to circle
                },

                ConnectorGeometryStyle = lineStyle,
                TargetDecoratorStyle = decoratorStyle,
                SourceDecoratorStyle = decoratorStyle,
                Constraints = ConnectorConstraints.None
            };
        }

        private static Style MakeShapeStyle(string fill, string stroke)
        {
            var style = new Style(typeof(Path));
            style.Setters.Add(new Setter(Path.FillProperty,
                fill == "Transparent" ? Brushes.Transparent
                    : new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString(fill))));
            style.Setters.Add(new Setter(Path.StrokeProperty,
                stroke == "Transparent" ? Brushes.Transparent
                    : new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString(stroke))));
            return style;
        }
        #endregion
    }

    public class FunnelStageModel
    {
        #region Properties
        public string Id { get; set; }
        public string Label { get; set; }
        public string DisplayValue { get; set; }
        public string Color { get; set; }
        public string PathData { get; set; }
        public double NodeWidth { get; set; }
        public double NodeHeight { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        // ✅ Two waypoints matching JS demo p1/p2 pattern
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public double? ConversionRate { get; set; }
        public double CumulativeRate { get; set; }
        public string IconText { get; set; }
        #endregion
    }

    public class FunnelTooltipModel
    {
        #region Properties
        public string Label { get; set; }
        public string IconText { get; set; }
        public string Color { get; set; }
        public string ConversionText { get; set; }
        public string CumulativeText { get; set; }
        #endregion
    }

    public class FunnelNodeViewModel : NodeViewModel
    {
        public FunnelTooltipModel TooltipData { get; set; }
    }
}
