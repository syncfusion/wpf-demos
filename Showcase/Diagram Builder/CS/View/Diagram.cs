#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using DiagramBuilder.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Runtime.Serialization;
using System.Reflection;
using Syncfusion.SfSkinManager;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
using SScroll = System.Windows.Controls.Primitives.IScrollInfo;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using VisibilityMode = Syncfusion.UI.Xaml.Diagram.Controls.VisibilityMode;

namespace DiagramBuilder.View
{
    internal class Diagram : SfDiagram
    {
        string Extension;
        BitmapEncoder CodeGuid;
        public Diagram()
        {
            Binding bind = new Binding();
            bind.Path = new PropertyPath("Visibility");
            bind.Source = this;
            bind.Mode = BindingMode.OneWay;
            bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            SetBinding(DummyVisibilityProperty, bind);

            ////this.Style = new Style(GetType(), this.FindResource(typeof(SfDiagram)) as Style);
            ////this.DefaultStyleKey = new ThemeResourceKey() { ElementType = typeof(SfDiagram), ThemeType = themeType };
            //this.DefaultStyleKey = typeof (SfDiagram);
            this.KnownTypes = new GetTypes(GetKnownTypes);
            
            this.SetBinding(TitleProperty,
                new Binding()
                {
                    Path = new PropertyPath("Title"),
                    Mode = BindingMode.TwoWay
                });

            this.SetBinding(IsSelectedProperty,
                new Binding()
                {
                    Path = new PropertyPath("IsSelected"),
                    Mode = BindingMode.TwoWay
                });

            this.SetBinding(PageDummyProperty,
                new Binding()
                {
                    Path = new PropertyPath("PageSettings"),
                    Mode = BindingMode.TwoWay
                });

            this.SetBinding(PrintingServiceProperty,
             new Binding()
             {
                 Path = new PropertyPath("PrintingService"),
                 Mode = BindingMode.TwoWay
             });

            this.SetBinding(ExportSettingsProperty,
             new Binding()
             {
                 Path = new PropertyPath("ExportSettings"),
                 Mode = BindingMode.TwoWay
             });

            this.SetBinding(IsExportProperty,
             new Binding()
             {
                 Path = new PropertyPath("IsExport"),
                 Mode = BindingMode.TwoWay
             });

            this.SetBinding(SelectedItemsProperty,
            new Binding()
            {
                Path = new PropertyPath("SelectedItems"),
                Mode = BindingMode.TwoWay
            });
            this.SetBinding(PreviewSettingsProperty,
             new Binding()
             {
                 Path = new PropertyPath("PreviewSettings"),
                 Mode = BindingMode.TwoWay
             });

            this.Loaded += Diagram_Loaded;
            this.Unloaded += Diagram_Unloaded;
            this.MouseUp += Diagram_MouseUp;
            this.Page.Loaded += Page_Loaded;
           
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //(this.Info as IGraphInfo).Commands.FitToPage.Execute(null);
        }

        //protected override void OnInitialized(EventArgs e)
        //{
        //    base.OnInitialized(e);
        //    //this.DefaultStyleKey = typeof (SfDiagram);
        //    //Theme theme = StyleManager.GetTheme(this);
        //    //Type themeType = null;
        //    //if (theme != null)
        //    //{
        //    //    themeType = theme.GetType();
        //    //}
        //    this.DefaultStyleKey = new ComponentResourceKey()
        //    {
        //        TypeInTargetAssembly = typeof (SfDiagram),
        //        ResourceId = SfSkinManager.GetVisualStyle(Application.Current.MainWindow)
        //    };
        //}

        void Diagram_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //e.Handled = true;
        }

        void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            //if (this.DataContext != null && (this.DataContext as DiagramVM)._isValidXml)
            //{
            //    IGraphInfo graph = (sender as SfDiagram).Info as IGraphInfo;
            //    PageVM page = (this.DataContext as DiagramVM).PageSettings as PageVM;
            //    graph.Commands.Zoom.Execute(
            //       new ZoomPositionParamenter()
            //       {
            //           ZoomTo = page.Scale
            //       });
            //    if (graph.ScrollInfo != null)
            //    {
            //        graph.ScrollInfo.PanTo(new Point(page.HOffset, page.VOffset));
            //    }
            //}
            (sender as SfDiagram).Constraints = (sender as SfDiagram).Constraints | GraphConstraints.Undoable;
            this.CommandManager.View = this;
            (DataContext as IDiagramViewModel).FirstLoad.Execute(null);

            this.SetBinding(PageSettingsProperty,
                new Binding()
                {
                    Path = new PropertyPath("PageSettings"),
                    Mode = BindingMode.TwoWay
                });

            this.SetBinding(SnapSettingsProperty,
               new Binding()
               {
                   Path = new PropertyPath("SnapSettings"),
                   Mode = BindingMode.TwoWay
               });
           
            //(this.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection();
            //QuickCommandViewModel Quickcommands_Delete = AddQuickCommand(new Thickness(0, 50, 0, 0), new Point(.5, 1), "Delete", (this.Info as IGraphInfo).Commands.Delete);
            //QuickCommandViewModel Quickcommands_Draw = AddQuickCommand(new Thickness(50, 0, 0, 0), new Point(1, 0.5), "Draw", (this.Info as IGraphInfo).Commands.Draw);
            //QuickCommandViewModel Quickcommands_Duplicate = AddQuickCommand(new Thickness(50, 50, 0, 0), new Point(1, 1), "Duplicate", (this.Info as IGraphInfo).Commands.Duplicate);

        }
        private QuickCommandViewModel AddQuickCommand(Thickness margin, Point offset, string content, ICommand command)
        {
            QuickCommandViewModel quickCommand = new QuickCommandViewModel()
            {
                Margin = margin,
                OffsetX = offset.X,
                OffsetY = offset.Y,
                Command = command,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = GetTemplate(content),
                VisibilityMode = VisibilityMode.Node,
                Shape = "F1M23.467,11.733C23.467,18.213 18.214,23.466 11.734,23.466 5.253,23.466 0,18.213 0,11.733 0,5.253 5.253,0 11.734,0 18.214,0 23.467,5.253 23.467,11.733",
                ShapeStyle=App.Current.Resources["QuickCommandstyle"] as Style,
            };
            if (content == "Draw" || content == "Duplicate")
            {
                DrawParameter drawParameter = new DrawParameter(DrawingTool.Connector, null, null, null, null, NullSourceTarget.SelectionAsSource | NullSourceTarget.CloneSourceAsTarget);
                DupilicateParameter duplicateParameter = new DupilicateParameter() { DragClone = true };
                quickCommand.DragCommand = command;
                if (content == "Duplicate")
                {
                    quickCommand.CommandParameter = duplicateParameter;
                }
                else
                {
                    quickCommand.CommandParameter = drawParameter;
                }
            }
            ((this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).Add(quickCommand);
            return quickCommand;
        }
        /// <summary>
        /// Constructs a new instance of the <see cref="GetTemplate(string)"/> method.
        /// </summary>
        /// <param name="item">Gets the item value</param>
        /// <returns>Returns the string</returns>
        private object GetTemplate(string item)
        {
            object s = null;
            if (item == "Delete")
            {
                s = "F1M377.5879,673.9355L376.1439,675.4095L369.8539,668.9945L363.5639,675.4095L362.1189,673.9355L368.4079,667.5205L362.1189,661.1035L363.5639,659.6295L369.8539,666.0465L376.1439,659.6295L377.5879,661.1035L371.2989,667.5205z";
            }
            else if (item == "Draw")
            {
                s = "F1M423.144,677.5312L423.144,671.2692L410.147,671.2692L410.147,666.4982L423.144,666.4982L423.144,661.0822L431.368,669.3062z";
            }
            else if (item == "Duplicate")
            {
                s = "M13.671994,14.169995 L1.0569996,14.169995 1.0569996,3.6649869 1.8049993,3.6649869 1.8049993,2.609986 0,2.609986 0,15.224996 14.724994,15.224996 14.724994,13.377994 13.671994,13.377994 z M2.6349954,12.613986 L17.358003,12.613986 17.358003,1.323489E-23 2.6349954,1.323489E-23 z";
            }

            return s;
        }
        void Diagram_Unloaded(object sender, RoutedEventArgs e)
        {
            
            this.Unloaded -= Diagram_Unloaded;
            KnownTypes = null;
        }

#if !SyncfusionFramework4_5_1

        //We need to set the Keyboaed focus when Diagram is getting visible.
        public Visibility DummyVisibility
        {
            get { return (Visibility)GetValue(DummyVisibilityProperty); }
            private set { SetValue(DummyVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LocalVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DummyVisibilityProperty =
            DependencyProperty.Register("LocalVisibility", typeof(Visibility), typeof(Diagram), new PropertyMetadata(Visibility.Collapsed, OnVisibilityChanged));

        private static void OnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Keyboard.Focus(d as Diagram);
        }
        

        //public object ExportSettings
        //{
        //    get { return (object)GetValue(ExportSettingsProperty); }
        //    set { SetValue(ExportSettingsProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ExportSettings.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ExportSettingsProperty =
        //    DependencyProperty.Register("ExportSettings", typeof(object), typeof(Diagram), new PropertyMetadata(null));



        //public object PrintingService
        //{
        //    get { return (object)GetValue(PrintingServiceProperty); }
        //    set { SetValue(PrintingServiceProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for PrintingService.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PrintingServiceProperty =
        //    DependencyProperty.Register("PrintingService", typeof(object), typeof(Diagram), new PropertyMetadata(null));

        #endif

        [DataMember]
        public string Title
        {
            get { return (string )GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        [DataMember]
        public PageVM PageDummy
        {
            get { return (PageVM)GetValue(PageDummyProperty); }
            set { SetValue(PageDummyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageDummy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageDummyProperty =
            DependencyProperty.Register("PageDummy", typeof(PageVM), typeof(Diagram), new PropertyMetadata(null));

     
        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string ), typeof(Diagram), new PropertyMetadata(string.Empty));

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(Diagram), new PropertyMetadata(false));
        public bool IsExport
        {
            get { return (bool)GetValue(IsExportProperty); }
            set { SetValue(IsExportProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsExport.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsExportProperty =
            DependencyProperty.Register("IsExport", typeof(bool), typeof(Diagram), new PropertyMetadata(false, IsExported));
      
     private static void IsExported(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                (d as Diagram).OnExported();
            }
            if(((d as Diagram).DataContext as DiagramVM).IsExport)
                ((d as Diagram).DataContext as DiagramVM).IsExport = false;
        } 
 


        private void InvokeSave(string p)
        {
            Extension = p;
        }
        private void OnExported()
        {

            string s = SaveFile(Extension);
            if (!string.IsNullOrEmpty(s))
            {
                ExportSettings es = new ExportSettings();

                // Method to Export the SfDiagram
                if ("XPS File(*.xps)|*.xps" == Extension)
                {
                    es.FileName = s;
                    es.IsSaveToXps = true;
                    this.ExportSettings = es;

                }
                else
                {
                    es.FileName = s;
                    this.ExportSettings = es;

                }
                //  (this.ExportSettings as ExportSettings).ExportBitmapEncoder = guid;
                this.Export();

            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
        }
        private string SaveFile(string filter)
        {

            SaveFileDialog m_SaveFileDialog = new SaveFileDialog();
            m_SaveFileDialog = new SaveFileDialog();
            m_SaveFileDialog.Filter = "Bitmap File(*.bmp)|*.bmp|Gif File(*.gif)|*.gif |JPEG File(*.jpeg)|*.jpeg |Png File(*.png)|*.png |Tiff File(*.tiff)|*.tiff |WDP File(*.wdp)|*.wdp|XPS File(*.xps)|*.xps";
            m_SaveFileDialog.FileName = "DiagramExport";
            m_SaveFileDialog.ShowDialog();
            string name = m_SaveFileDialog.FileName;
            string extension = Path.GetExtension(name);
            InvokeSave(extension);
            if (m_SaveFileDialog.FileName == name)
            {
                name = m_SaveFileDialog.FileName;
            }
            return name;
        }

        /// <summary>
        ///  Method to override or customize the default or custom behavior
        /// </summary>      
        protected override void SetTool(SetToolArgs args)
        {
            if (args.Source is NodePortVM && this.Tool != Tool.ContinuesDraw && this.Tool != Tool.DrawOnce)
            {
                args.Action = ActiveTool.Drag;
            }
            else 
            {
                base.SetTool(args);
            }
        }
        public IEnumerable<Type> GetKnownTypes()
        {
            List<Type> known = new List<Type>()
            {
                typeof(FontStyle),
                typeof(TextAlignment),
                typeof(HorizontalAlignment),
                typeof(VerticalAlignment),
                typeof(Visibility),
                typeof(ConnectType),
                typeof(ConnectorType),
                typeof(Thickness),
                typeof(DoubleCollection),
                typeof(FontWeight),
                typeof(PageVM),
            };
            foreach (var item in known)
            {
                yield return item;
            }
        }
        
        protected override Node GetNodeForItemOverride(object item)
        {
            return new NodeView();
        }

        protected override Connector GetConnectorForItemOverride(object item)
        {
            return new ConnectorView();
        }

        //protected override Selector GetSelectorForItemOverride(object item)
        //{
        //    return new SelectorView();
        //}

        protected override object GetNewNode(Type desiredType)
        {
            return new NodeVM();
        }

        protected override object GetNewConnector(Type desiredType)
        {
            return new ConnectorVM();
        }

        protected override object GetNewGroup(Type desiredType)
        {
            return new GroupVM();
        }
    }

    public class ThemeResourceKey : ComponentResourceKey
    {
        public ThemeResourceKey(String resourceId)
        {
            ResourceId = resourceId;
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes().Where(t => typeof(UIElement).IsAssignableFrom(t));
            var uiElementType = types.FirstOrDefault();
            if (uiElementType == default(Type))
                throw new ArgumentException("No custom UIElements defined within this XAML");

            TypeInTargetAssembly = uiElementType;
        }
    }

    public class VariableSizedWrapGrid : Panel, SScroll
    {
        #region HorizontalAlignment HorizontalChildrenAlignment
        public HorizontalAlignment HorizontalChildrenAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalChildrenAlignmentProperty); }
            set { SetValue(HorizontalChildrenAlignmentProperty, value); }
        }

        public static readonly DependencyProperty HorizontalChildrenAlignmentProperty =
            DependencyProperty.Register("HorizontalChildrenAlignment", typeof(HorizontalAlignment), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(HorizontalAlignment.Left, FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region double ItemHeight
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));
        #endregion

        #region double ItemWidth
        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }

        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register("ItemWidth", typeof(double), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));
        #endregion

        #region bool LatchIemSize
        public bool LatchItemSize
        {
            get { return (bool)GetValue(LatchItemSizeProperty); }
            set { SetValue(LatchItemSizeProperty, value); }
        }

        public static readonly DependencyProperty LatchItemSizeProperty =
            DependencyProperty.Register("LatchItemSize", typeof(bool), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));
        #endregion

        #region int MaximumRowsOrColumns
        public int MaximumRowsOrColumns
        {
            get { return (int)GetValue(MaximumRowsOrColumnsProperty); }
            set { SetValue(MaximumRowsOrColumnsProperty, value); }
        }

        public static readonly DependencyProperty MaximumRowsOrColumnsProperty =
            DependencyProperty.Register("MaximumRowsOrColumns", typeof(int), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));
        #endregion

        #region Orientation Orientation
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(Orientation.Vertical, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));
        #endregion

        #region bool StrictItemOrder
        public bool StrictItemOrder
        {
            get { return (bool)GetValue(StrictItemOrderProperty); }
            set { SetValue(StrictItemOrderProperty, value); }
        }

        public static readonly DependencyProperty StrictItemOrderProperty =
            DependencyProperty.Register("StrictItemOrder", typeof(bool), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));
        #endregion

        #region VerticalAlignment VerticalChildrenAlignment
        public VerticalAlignment VerticalChildrenAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalChildrenAlignmentProperty); }
            set { SetValue(VerticalChildrenAlignmentProperty, value); }
        }

        public static readonly DependencyProperty VerticalChildrenAlignmentProperty =
            DependencyProperty.Register("VerticalChildrenAlignment", typeof(VerticalAlignment), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(VerticalAlignment.Top, FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region int ColumnSpan
        public static int GetColumnSpan(DependencyObject obj)
        {
            return (int)obj.GetValue(ColumnSpanProperty);
        }

        public static void SetColumnSpan(DependencyObject obj, int value)
        {
            obj.SetValue(ColumnSpanProperty, value);
        }

        public static readonly DependencyProperty ColumnSpanProperty =
            DependencyProperty.RegisterAttached("ColumnSpan", typeof(int), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.AffectsParentArrange | FrameworkPropertyMetadataOptions.AffectsParentMeasure));
        #endregion

        #region int RowSpan
        public static int GetRowSpan(DependencyObject obj)
        {
            return (int)obj.GetValue(RowSpanProperty);
        }

        public static void SetRowSpan(DependencyObject obj, int value)
        {
            obj.SetValue(RowSpanProperty, value);
        }

        public static readonly DependencyProperty RowSpanProperty =
            DependencyProperty.RegisterAttached("RowSpan", typeof(int), typeof(VariableSizedWrapGrid),
                new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.AffectsParentArrange | FrameworkPropertyMetadataOptions.AffectsParentMeasure));
        #endregion

        private class PlotSorterVertical : IComparer<Rect>
        {
            public int Compare(Rect x, Rect y)
            {
                if (x.Left < y.Left)
                    return -1;
                if (x.Left > y.Left)
                    return 1;
                if (x.Top < y.Top)
                    return -1;
                if (x.Top > y.Top)
                    return 1;
                return 0;
            }
        }

        private class PlotSorterHorizontal : IComparer<Rect>
        {
            public int Compare(Rect x, Rect y)
            {
                if (x.Top < y.Top)
                    return -1;
                if (x.Top > y.Top)
                    return 1;
                if (x.Left < y.Left)
                    return -1;
                if (x.Left > y.Left)
                    return 1;
                return 0;
            }
        }

        private IEnumerable<Rect> ReserveAcreage(Rect acreage, Rect plot)
        {
            if (acreage.IntersectsWith(plot))
            {
                // Above?
                if (plot.Top < acreage.Top)
                {
                    var rest = new Rect(plot.Location, new Size(plot.Width, acreage.Top - plot.Top));
                    yield return rest;
                }

                // Below?
                if (plot.Bottom > acreage.Bottom)
                {
                    var rest = new Rect(new Point(plot.Left, acreage.Bottom), new Size(plot.Width, plot.Bottom - acreage.Bottom));
                    yield return rest;
                }

                // Left?
                if (plot.Left < acreage.Left)
                {
                    var rest = new Rect(plot.Location, new Size(acreage.Left - plot.Left, plot.Height));
                    yield return rest;
                }

                // Right?
                if (plot.Right > acreage.Right)
                {
                    var rest = new Rect(new Point(acreage.Right, plot.Top), new Size(plot.Right - acreage.Right, plot.Height));
                    yield return rest;
                }
            }
            else
            {
                yield return plot;
            }
        }

        private Point PlaceElement(Size requiredSize, ref List<Rect> plots,
            double itemWidth, double itemHeight)
        {
            var location = new Point();

            foreach (var plot in plots)
            {
                if ((plot.Height >= requiredSize.Height) && (plot.Width >= requiredSize.Width))
                {
                    var acreage = new Rect(plot.Location, requiredSize);

                    Rect innerRect;
                    Rect outerRect;
                    IComparer<Rect> plotSorter;

                    if (Orientation == Orientation.Vertical)
                    {
                        innerRect = new Rect(0, 0, acreage.X + itemWidth, acreage.Y);
                        outerRect = new Rect(0, 0, acreage.X, double.MaxValue);
                        plotSorter = new PlotSorterVertical();
                    }
                    else
                    {
                        innerRect = new Rect(0, 0, acreage.X, acreage.Y + itemHeight);
                        outerRect = new Rect(0, 0, double.MaxValue, acreage.Y);
                        plotSorter = new PlotSorterHorizontal();
                    }

                    List<Rect> localPlots;

                    if (StrictItemOrder)
                    {
                        localPlots = plots.SelectMany(p => ReserveAcreage(acreage, p))
                            .SelectMany(p => ReserveAcreage(outerRect, p))
                            .SelectMany(p => ReserveAcreage(innerRect, p)).Distinct().ToList();
                    }
                    else
                    {
                        localPlots = plots.SelectMany(p => ReserveAcreage(acreage, p)).Distinct().ToList();
                    }

                    localPlots.RemoveAll(x => localPlots.Any(y => y.Contains(x) && !y.Equals(x)));
                    localPlots.Sort(plotSorter);
                    plots = localPlots;

                    location = acreage.Location;
                    break;
                }
            }

            return location;
        }

        private Rect ArrangeElement(Rect acreage, Size desiredSize, Vector offset)
        {
            var rect = acreage;

            // Adjust horizontal location and size for alignment
            switch (HorizontalChildrenAlignment)
            {
                case HorizontalAlignment.Center:
                    rect.X = rect.X + Math.Max(0, (acreage.Width - desiredSize.Width) / 2);
                    rect.Width = desiredSize.Width;
                    break;
                case HorizontalAlignment.Left:
                    rect.Width = desiredSize.Width;
                    break;
                case HorizontalAlignment.Right:
                    rect.X = rect.X + Math.Max(0, acreage.Width - desiredSize.Width);
                    rect.Width = desiredSize.Width;
                    break;
                case HorizontalAlignment.Stretch:
                default:
                    break;
            }

            // Adjust vertical location and size for alignment
            switch (VerticalChildrenAlignment)
            {
                case VerticalAlignment.Bottom:
                    rect.Y = rect.Y + Math.Max(0, acreage.Height - desiredSize.Height);
                    rect.Height = desiredSize.Height;
                    break;
                case VerticalAlignment.Center:
                    rect.Y = rect.Y + Math.Max(0, (acreage.Height - desiredSize.Height) / 2);
                    rect.Height = desiredSize.Height;
                    break;
                case VerticalAlignment.Top:
                    rect.Height = desiredSize.Height;
                    break;
                case VerticalAlignment.Stretch:
                default:
                    break;
            }

            // Adjust location for scrolling offset
            rect.Location = rect.Location - offset;

            return rect;
        }

        double _itemHeight;
        double _itemWidth;

        private System.Windows.Controls.ScrollViewer _owner;
        private Size _extent = new Size();
        private Size _viewport = new Size();
        private Vector _offset = new Vector();

        private void SetViewport(Size size)
        {
            if (_viewport != size)
            {
                _viewport = size;
                if (_owner != null)
                {
                    _owner.InvalidateScrollInfo();
                }
            }
        }

        private void SetExtent(Size size)
        {
            if (_extent != size)
            {
                _extent = size;
                if (_owner != null)
                {
                    _owner.InvalidateScrollInfo();
                }
            }
        }

        private IList<Rect> _finalRects;

        protected override Size MeasureOverride(Size availableSize)
        {
            var desiredSizeMin = new Size();
            var elementSizes = new List<Size>(InternalChildren.Count);

            _itemHeight = ItemHeight;
            _itemWidth = ItemWidth;

            foreach (UIElement element in InternalChildren)
            {
                Size elementSize = LatchItemSize ?
                    new Size(double.IsNaN(_itemWidth) ? double.MaxValue : _itemWidth * GetColumnSpan(element), double.IsNaN(_itemHeight) ? double.MaxValue : _itemHeight * GetRowSpan(element)) :
                    new Size(double.IsNaN(ItemWidth) ? double.MaxValue : _itemWidth * GetColumnSpan(element), double.IsNaN(ItemHeight) ? double.MaxValue : _itemHeight * GetRowSpan(element));

                // Measure each element providing allocated plot size.
                element.Measure(elementSize);

                // Use the elements desired size as item size in the undefined dimension(s)
                if (double.IsNaN(_itemHeight) || (!LatchItemSize && double.IsNaN(ItemHeight)))
                {
                    elementSize.Height = element.DesiredSize.Height;
                }

                if (double.IsNaN(_itemWidth) || (!LatchItemSize && double.IsNaN(ItemWidth)))
                {
                    elementSize.Width = element.DesiredSize.Width;
                }

                if (double.IsNaN(_itemHeight))
                {
                    _itemHeight = element.DesiredSize.Height / GetRowSpan(element);
                }

                if (double.IsNaN(_itemWidth))
                {
                    _itemWidth = element.DesiredSize.Width / GetColumnSpan(element);
                }

                // The minimum size of the panel is equal to the largest element in each dimension.
                desiredSizeMin.Height = Math.Max(desiredSizeMin.Height, elementSize.Height);
                desiredSizeMin.Width = Math.Max(desiredSizeMin.Width, elementSize.Width);

                elementSizes.Add(elementSize);
            }

            // Always use at least the available size for the panel unless infinite.
            var desiredSize = new Size();
            desiredSize.Height = double.IsPositiveInfinity(availableSize.Height) ? 0 : availableSize.Height;
            desiredSize.Width = double.IsPositiveInfinity(availableSize.Width) ? 0 : availableSize.Width;

            // Available plots on the panel real estate
            var plots = new List<Rect>();

            // Calculate maximum size
            var maxSize = (MaximumRowsOrColumns > 0) ?
                new Size(_itemWidth * MaximumRowsOrColumns, _itemHeight * MaximumRowsOrColumns) :
                new Size(double.MaxValue, double.MaxValue);

            // Add the first plot covering the entire estate.
            var bigPlot = new Rect(new Point(0, 0), (Orientation == Orientation.Vertical) ?
                new Size(double.MaxValue, Math.Max(Math.Min(availableSize.Height, maxSize.Height), desiredSizeMin.Height)) :
                new Size(Math.Max(Math.Min(availableSize.Width, maxSize.Width), desiredSizeMin.Width), double.MaxValue));

            plots.Add(bigPlot);

            _finalRects = new List<Rect>(InternalChildren.Count);

            using (var sizeEnumerator = elementSizes.GetEnumerator())
            {
                foreach (UIElement element in InternalChildren)
                {
                    sizeEnumerator.MoveNext();
                    var elementSize = sizeEnumerator.Current;

                    // Find a plot able to hold this element.
                    var acreage = new Rect(
                        PlaceElement(elementSize, ref plots, _itemWidth, _itemHeight), elementSize);

                    _finalRects.Add(acreage);

                    // Keep track of panel size...
                    desiredSize.Height = Math.Max(desiredSize.Height, acreage.Bottom);
                    desiredSize.Width = Math.Max(desiredSize.Width, acreage.Right);
                }
            }

            SetViewport(availableSize);
            SetExtent(desiredSize);

            return desiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var actualSize = new Size();
            actualSize.Height = double.IsPositiveInfinity(finalSize.Height) ? 0 : finalSize.Height;
            actualSize.Width = double.IsPositiveInfinity(finalSize.Width) ? 0 : finalSize.Width;

            using (var rectEnumerator = _finalRects.GetEnumerator())
            {
                foreach (UIElement element in InternalChildren)
                {
                    rectEnumerator.MoveNext();
                    var acreage = rectEnumerator.Current;

                    // Keep track of panel size...
                    actualSize.Height = Math.Max(actualSize.Height, acreage.Bottom);
                    actualSize.Width = Math.Max(actualSize.Width, acreage.Right);

                    // Arrange each element using allocated plot location and size.
                    element.Arrange(ArrangeElement(acreage, element.DesiredSize, _offset));
                }
            }

            // Adjust offset when the viewport size changes
            SetHorizontalOffset(Math.Max(0, Math.Min(HorizontalOffset, ExtentWidth - ViewportWidth)));
            SetVerticalOffset(Math.Max(0, Math.Min(VerticalOffset, ExtentHeight - ViewportHeight)));

            return actualSize;
        }

        #region IScrollInfo
        // This property is not intended for use in your code. It is exposed publicly to fulfill an interface contract (IScrollInfo). Setting this property has no effect.
        public bool CanVerticallyScroll
        {
            get { return false; }
            set { }
        }

        // This property is not intended for use in your code. It is exposed publicly to fulfill an interface contract (IScrollInfo). Setting this property has no effect.
        public bool CanHorizontallyScroll
        {
            get { return false; }
            set { }
        }

        public double ExtentWidth
        {
            get { return _extent.Width; }
        }

        public double ExtentHeight
        {
            get { return _extent.Height; }
        }

        public double ViewportWidth
        {
            get { return _viewport.Width; }
        }

        public double ViewportHeight
        {
            get { return _viewport.Height; }
        }

        public double HorizontalOffset
        {
            get { return _offset.X; }
        }

        public double VerticalOffset
        {
            get { return _offset.Y; }
        }

        public System.Windows.Controls.ScrollViewer ScrollOwner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public void LineUp()
        {
            SetVerticalOffset(VerticalOffset - _itemHeight);
        }

        public void LineDown()
        {
            SetVerticalOffset(VerticalOffset + _itemHeight);
        }

        public void LineLeft()
        {
            SetHorizontalOffset(HorizontalOffset - _itemWidth);
        }

        public void LineRight()
        {
            SetHorizontalOffset(HorizontalOffset + _itemWidth);
        }

        public void PageUp()
        {
            SetVerticalOffset(VerticalOffset - Math.Max(_itemHeight, Math.Max(0, _viewport.Height - _itemHeight)));
        }

        public void PageDown()
        {
            SetVerticalOffset(VerticalOffset + Math.Max(_itemHeight, Math.Max(0, _viewport.Height - _itemHeight)));
        }

        public void PageLeft()
        {
            SetHorizontalOffset(HorizontalOffset - Math.Max(_itemWidth, Math.Max(0, _viewport.Width - _itemWidth)));
        }

        public void PageRight()
        {
            SetHorizontalOffset(HorizontalOffset + Math.Max(_itemWidth, Math.Max(0, _viewport.Width - _itemWidth)));
        }

        public void MouseWheelUp()
        {
            LineUp();
        }

        public void MouseWheelDown()
        {
            LineDown();
        }

        public void MouseWheelLeft()
        {
            LineLeft();
        }

        public void MouseWheelRight()
        {
            LineRight();
        }

        public void SetHorizontalOffset(double offset)
        {
            offset = Math.Max(0, Math.Min(offset, ExtentWidth - ViewportWidth));
            if (offset != _offset.X)
            {
                _offset.X = offset;
                if (_owner != null)
                {
                    _owner.InvalidateScrollInfo();
                }
                InvalidateArrange();
            }
        }

        public void SetVerticalOffset(double offset)
        {
            offset = Math.Max(0, Math.Min(offset, ExtentHeight - ViewportHeight));
            if (offset != _offset.Y)
            {
                _offset.Y = offset;
                if (_owner != null)
                {
                    _owner.InvalidateScrollInfo();
                }
                InvalidateArrange();
            }
        }

        public Rect MakeVisible(Visual visual, Rect rectangle)
        {
            if (rectangle.IsEmpty || visual == null || visual == this || !IsAncestorOf(visual))
            {
                return Rect.Empty;
            }

            rectangle = visual.TransformToAncestor(this).TransformBounds(rectangle);

            Rect viewRect = new Rect(HorizontalOffset, VerticalOffset, ViewportWidth, ViewportHeight);

            // Horizontal
            if (rectangle.Right + HorizontalOffset > viewRect.Right)
            {
                viewRect.X = viewRect.X + rectangle.Right + HorizontalOffset - viewRect.Right;
            }
            if (rectangle.Left + HorizontalOffset < viewRect.Left)
            {
                viewRect.X = viewRect.X - (viewRect.Left - (rectangle.Left + HorizontalOffset));
            }

            // Vertical
            if (rectangle.Bottom + VerticalOffset > viewRect.Bottom)
            {
                viewRect.Y = viewRect.Y + rectangle.Bottom + VerticalOffset - viewRect.Bottom;
            }
            if (rectangle.Top + VerticalOffset < viewRect.Top)
            {
                viewRect.Y = viewRect.Y - (viewRect.Top - (rectangle.Top + VerticalOffset));
            }

            SetHorizontalOffset(viewRect.X);
            SetVerticalOffset(viewRect.Y);

            rectangle.Intersect(viewRect);

            return rectangle;
        }
        #endregion
    }

    public class CustomGrid : Grid,INotifyPropertyChanged
    {
        public CustomGrid()
        {
            RowDefinition rd = new RowDefinition() { Height = GridLength.Auto };
            RowDefinition rd1 = new RowDefinition() { Height = GridLength.Auto };
            RowDefinition rd2 = new RowDefinition() { Height = GridLength.Auto };

            this.RowDefinitions.Add(rd1);
            this.RowDefinitions.Add(rd);
            this.RowDefinitions.Add(rd2);

            ColumnDefinition cd = new ColumnDefinition() {Width = GridLength.Auto};
            ColumnDefinition cd1 = new ColumnDefinition() { Width = GridLength.Auto };
            ColumnDefinition cd2 = new ColumnDefinition() { Width = GridLength.Auto };
            ColumnDefinition cd3 = new ColumnDefinition() { Width = GridLength.Auto };

            this.ColumnDefinitions.Add(cd);
            this.ColumnDefinitions.Add(cd1);
            this.ColumnDefinitions.Add(cd2);
            this.ColumnDefinitions.Add(cd3);
            this.Loaded += CustomGrid_Loaded;
        }

        private string _mheader;

        public string Header
        {
            get { return _mheader; }
            set
            {
                if (_mheader != value)
                {
                    _mheader = value;
                    OnChanges("Header");
                }
            }
        }

 

        void CustomGrid_Loaded(object sender, RoutedEventArgs e)
        {
            

            foreach (UIElement child in Children)
            {
                if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Fill")
                {
                    Grid.SetRow(child,0);
                    Grid.SetColumn(child,1);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Stroke")
                {
                    Grid.SetRow(child, 1);
                    Grid.SetColumn(child, 1);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Quick Style")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 0);
                    Grid.SetRowSpan(child,2);
                }

                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Cut")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 1);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Copy")
                {
                    Grid.SetRow(child, 1);
                    Grid.SetColumn(child, 1);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Paste")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 0);
                    Grid.SetRowSpan(child, 2);
                }

                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "BringToFront")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 2);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "SendToBack")
                {
                    Grid.SetRow(child, 1);
                    Grid.SetColumn(child, 2);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Group")
                {
                    Grid.SetRow(child, 2);
                    Grid.SetColumn(child, 2);
                    
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Align")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 0);
                    Grid.SetRowSpan(child, 2);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Position")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 1);
                    Grid.SetRowSpan(child, 2);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Pointer Tool")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 0);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Connector")
                {
                    Grid.SetRow(child, 1);
                    Grid.SetColumn(child, 0);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "Text")
                {
                    Grid.SetRow(child, 2);
                    Grid.SetColumn(child, 0);
                }

                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Identifier == "Ruler")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 0);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Identifier == "Grid")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 1);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Identifier == "PageBreaks")
                {
                    Grid.SetRow(child,0);
                    Grid.SetColumn(child, 2);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Identifier == "MultiplePage")
                {
                    Grid.SetRow(child, 1);
                    Grid.SetColumn(child, 0);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Identifier == "SnapToObject")
                {
                    Grid.SetRow(child, 1);
                    Grid.SetColumn(child, 1);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Identifier == "SnapToGrid")
                {
                    Grid.SetRow(child, 1);
                    Grid.SetColumn(child, 2);
                }
                else if (((child as ContentPresenter).Content as DiagramButtonViewModel).Label == "TaskPanes")
                {
                    Grid.SetRow(child, 0);
                    Grid.SetColumn(child, 3);
                    Grid.SetRowSpan(child, 2);
                }
            }
        }

     

        protected override void OnInitialized(EventArgs e)
        {
            
            base.OnInitialized(e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnChanges(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this,new PropertyChangedEventArgs(name));
            }
        }
    }

    
}