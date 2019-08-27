#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Markup;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using DiagramBuilder.ViewModel;

namespace DiagramBuilder.Utility
{
    public class BooleanToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility val = (Visibility)value;
            if (val == Visibility.Visible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class BooleanToOppositeVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility val = (Visibility)value;
            if (val == Visibility.Collapsed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class Inverter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Visibility)value == Visibility.Visible)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class Ext
    {
        public static Color ToColor(this string value) {
            Color c;
            var match = Regex.Match(value, "#([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})");
            int a = Convert.ToInt32(match.Groups[1].Value, 16);
            int r = Convert.ToInt32(match.Groups[2].Value, 16);
            int g = Convert.ToInt32(match.Groups[3].Value, 16);
            int b = Convert.ToInt32(match.Groups[4].Value, 16);
            c = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            return c;
        }

        public static DoubleCollection Clone(this DoubleCollection item)
        {
            DoubleCollection col = new DoubleCollection();
            foreach (var dou in item)
            {
                col.Add(dou);
            }
            return col;
        }
    }

    public class StringtoCommandConverter : DependencyObject, IValueConverter
    {


        public DiagramBuilderVM Context
        {
            get { return (DiagramBuilderVM)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Context.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(DiagramBuilderVM), typeof(StringtoCommandConverter), new PropertyMetadata(null, onPropertychanged));

        private static void onPropertychanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string command = value.ToString();
            ////DiagramBuilderVM vm = values[1] as DiagramBuilderVM;
            //if (vm != null)
            //{
            //    switch (command)
            //    {
            //        case "Cut":
            //            return vm.Cut;
            //            break;
            //        case "Copy":
            //            return vm.Copy;
            //            break;
            //        case "Paste":
            //            return vm.Paste;
            //            break;

            //    }
            //}
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumtoVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string con = value.ToString();
            string check = parameter.ToString();
            if (con.Equals(check))
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TexttoPercentageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double scale = Math.Floor((Double)value * 100);
            return scale.ToString() + "%";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class PickerVisibilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Visibility)value == Visibility.Visible)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
               
                  Brush   brush = (Brush) converter.ConvertFromString(value.ToString());
             
                return (brush as SolidColorBrush).Color;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(value.ToString());
                return brush;
            }
            return null;
        }
    }

    //BindableStaticResource
    public class BindableStaticResource : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var multiBinding = new MultiBinding();
            multiBinding.Bindings.Add(new Binding() { RelativeSource = new RelativeSource() { Mode = RelativeSourceMode.Self } });
            multiBinding.Bindings.Add(new Binding());
            multiBinding.Converter = new ResourceKeyToResourceConverter();
            return multiBinding.ProvideValue(serviceProvider);
        }
    }

    //ResourceKeyToResourceConverter
    class ResourceKeyToResourceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length < 2)
            {
                return null;
            }
            var element = values[0] as FrameworkElement;
            DependencyObject dobject = (element as FrameworkElement).Parent;
            var resourceKey = values[1];
            resourceKey = string.Format("{0}Style", resourceKey);
            var resource = element.TryFindResource(resourceKey);
            if (dobject != null && resource != null)
            {
                if (dobject is Grid)
                {
                    if ((dobject as Grid).Children.Count > 1)
                    {
                        var converter = new System.Windows.Media.BrushConverter();
                        if ((dobject as Grid).Children[0] is TextBlock)
                        {
                            TextBlock tt = (dobject as Grid).Children[0] as TextBlock;
                            foreach (Setter set in (resource as Style).Setters)
                            {
                                if (set.Property == FrameworkElement.TagProperty)
                                {
                                    var brush = (Brush) converter.ConvertFromString(set.Value.ToString());
                                    tt.Foreground = brush;
                                }
                            }
                        }
                        else if ((dobject as Grid).Children[0] is Path)
                        {
                            
                            Path tt = (dobject as Grid).Children[0] as Path;
                            foreach (Setter set in (resource as Style).Setters)
                            {
                                if (set.Property == FrameworkElement.TagProperty)
                                {
                                    var brush = (Brush)converter.ConvertFromString(set.Value.ToString());
                                    tt.Fill = brush;
                                }
                            }
                            
                        }
                    }
                }
              
            }
          

           
            return resource;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class GalarySelection 
    {

        public static ICommand SelectCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(SelectCommandProperty);
        }
        public static void SetSelectCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(SelectCommandProperty, value);
        }

        public static readonly DependencyProperty SelectCommandProperty =
            DependencyProperty.RegisterAttached("SelectCommand", typeof(ICommand), typeof(GalarySelection),
                new PropertyMetadata(null, OnPropertyChanged));
        

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonGallery rg = d as RibbonGallery;
            rg.SelectedItemChanged += rg_SelectedItemChanged;

        }

        static void rg_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand command = SelectCommand(d as DependencyObject);
            if (e.NewValue != null)
            {
                string name = String.Empty;
                if (e.NewValue.ToString().Contains("Syncfusion.Windows.Tools.Controls.RibbonGalleryItem:"))
                {
                    name = e.NewValue.ToString().Remove(0, 53);
                }
                else
                {
                    name = e.NewValue.ToString();
                }

                if (command != null)
                {
                    command.Execute(name);
                }
            }
        }
        
    }

    internal static class ShapeHelper
    {
        public static Dictionary<ICons, string> GeometryDictionary = new Dictionary<ICons, string>();

        static ShapeHelper()
        {
            GeometryDictionary.Add(ICons.Cut, "pack://application:,,,/DiagramBuilder;component/Resources/Cut.png");
            GeometryDictionary.Add(ICons.Copy, "pack://application:,,,/DiagramBuilder;component/Resources/Copy.png");
            GeometryDictionary.Add(ICons.Paste, "pack://application:,,,/DiagramBuilder;component/Resources/Paste.png");
            GeometryDictionary.Add(ICons.Bold, "pack://application:,,,/DiagramBuilder;component/Resources/bold.png");
            GeometryDictionary.Add(ICons.Italic, "pack://application:,,,/DiagramBuilder;component/Resources/italic.png");
            GeometryDictionary.Add(ICons.Center, "pack://application:,,,/DiagramBuilder;component/Resources/Align-center.png");
            GeometryDictionary.Add(ICons.Left, "pack://application:,,,/DiagramBuilder;component/Resources/Align-left.png");
            GeometryDictionary.Add(ICons.Right, "pack://application:,,,/DiagramBuilder;component/Resources/Align-right.png");
            GeometryDictionary.Add(ICons.BottomRight, "pack://application:,,,/DiagramBuilder;component/Resources/Bottomright.png");
            GeometryDictionary.Add(ICons.TopLeft, "pack://application:,,,/DiagramBuilder;component/Resources/Align-middle.png");
            GeometryDictionary.Add(ICons.TopRight, "pack://application:,,,/DiagramBuilder;component/Resources/Bottom.png");
            GeometryDictionary.Add(ICons.BottomLeft, "pack://application:,,,/DiagramBuilder;component/Resources/Bottomleft.png");
            GeometryDictionary.Add(ICons.Top, "pack://application:,,,/DiagramBuilder;component/Resources/Align-top.png");
            GeometryDictionary.Add(ICons.Bottom, "pack://application:,,,/DiagramBuilder;component/Resources/Align-bottom.png");
            GeometryDictionary.Add(ICons.PointerTool, "pack://application:,,,/DiagramBuilder;component/Resources/pointer.png");
            GeometryDictionary.Add(ICons.Select, "pack://application:,,,/DiagramBuilder;component/Resources/select1.png");
            GeometryDictionary.Add(ICons.Position, "pack://application:,,,/DiagramBuilder;component/Resources/position-icon.png");
            GeometryDictionary.Add(ICons.Connector, "pack://application:,,,/DiagramBuilder;component/Resources/connector.png");
            GeometryDictionary.Add(ICons.Port, "pack://application:,,,/DiagramBuilder;component/Resources/Port.png");
            GeometryDictionary.Add(ICons.SelectText, "pack://application:,,,/DiagramBuilder;component/Resources/SelectText.png");
            GeometryDictionary.Add(ICons.RotateText, "pack://application:,,,/DiagramBuilder;component/Resources/RotateText.png");
            GeometryDictionary.Add(ICons.Text, "pack://application:,,,/DiagramBuilder;component/Resources/Text.png");
            GeometryDictionary.Add(ICons.Zoom, "pack://application:,,,/DiagramBuilder;component/Resources/Zoom-1.png");
            GeometryDictionary.Add(ICons.FitToPage, "pack://application:,,,/DiagramBuilder;component/Resources/fullscreen-16x16-2.png");
            GeometryDictionary.Add(ICons.Pagewidth, "pack://application:,,,/DiagramBuilder;component/Resources/Pagewidth.png");
            GeometryDictionary.Add(ICons.Label, "pack://application:,,,/DiagramBuilder;component/Resources/FontColor.png");
            GeometryDictionary.Add(ICons.Fill, "pack://application:,,,/DiagramBuilder;component/Resources/shape-fill.png");
            GeometryDictionary.Add(ICons.Stroke, "pack://application:,,,/DiagramBuilder;component/Resources/shape-fill.png");
            GeometryDictionary.Add(ICons.Align, "pack://application:,,,/DiagramBuilder;component/Resources/Align_Split.png");
            GeometryDictionary.Add(ICons.AlignLeft, "pack://application:,,,/DiagramBuilder;component/Resources/AlignLeft.png");
            GeometryDictionary.Add(ICons.AlignCenter, "pack://application:,,,/DiagramBuilder;component/Resources/AlignCenter.png");
            GeometryDictionary.Add(ICons.AlignRight, "pack://application:,,,/DiagramBuilder;component/Resources/AlignRight.png");
            GeometryDictionary.Add(ICons.AlignTop, "pack://application:,,,/DiagramBuilder;component/Resources/AlignTop.png");
            GeometryDictionary.Add(ICons.AlignMiddle, "pack://application:,,,/DiagramBuilder;component/Resources/AlignMiddle.png");
            GeometryDictionary.Add(ICons.AlignBottom, "pack://application:,,,/DiagramBuilder;component/Resources/AlignBottom.png");
            GeometryDictionary.Add(ICons.Group, "pack://application:,,,/DiagramBuilder;component/Resources/Group.png");
            GeometryDictionary.Add(ICons.UnGroup, "pack://application:,,,/DiagramBuilder;component/Resources/UnGroup.png");
            GeometryDictionary.Add(ICons.BringToFront, "pack://application:,,,/DiagramBuilder;component/Resources/BringToFront.png");
            GeometryDictionary.Add(ICons.SendToBack, "pack://application:,,,/DiagramBuilder;component/Resources/SendToBack.png");
            GeometryDictionary.Add(ICons.BringForward, "pack://application:,,,/DiagramBuilder;component/Resources/BringForward.png");
            GeometryDictionary.Add(ICons.SendBackward, "pack://application:,,,/DiagramBuilder;component/Resources/SendBackward.png");
            GeometryDictionary.Add(ICons.Size, "pack://application:,,,/DiagramBuilder;component/Resources/Size.png");
            GeometryDictionary.Add(ICons.NewPage, "pack://application:,,,/DiagramBuilder;component/Resources/New-page.png");
            GeometryDictionary.Add(ICons.DuplicatePage, "pack://application:,,,/DiagramBuilder;component/Resources/duplicate.png");
            GeometryDictionary.Add(ICons.Pictures, "pack://application:,,,/DiagramBuilder;component/Resources/Pictures.png");
            GeometryDictionary.Add(ICons.Orientation, "pack://application:,,,/DiagramBuilder;component/Resources/Orientation.png");
            GeometryDictionary.Add(ICons.Potrait, "pack://application:,,,/DiagramBuilder;component/Resources/Landscape.png");
            GeometryDictionary.Add(ICons.Landscape, "pack://application:,,,/DiagramBuilder;component/Resources/Portrait.png");
            GeometryDictionary.Add(ICons.A4, "pack://application:,,,/DiagramBuilder;component/Resources/A4.png");
            GeometryDictionary.Add(ICons.A5, "pack://application:,,,/DiagramBuilder;component/Resources/A5.png");
            GeometryDictionary.Add(ICons.Letter, "pack://application:,,,/DiagramBuilder;component/Resources/letter.png");
            GeometryDictionary.Add(ICons.Ledger, "pack://application:,,,/DiagramBuilder;component/Resources/Ledger.png");
            GeometryDictionary.Add(ICons.Legal, "pack://application:,,,/DiagramBuilder;component/Resources/Legal.png");

            GeometryDictionary.Add(ICons.Underline, "pack://application:,,,/DiagramBuilder;component/Resources/Underline16.png");
            GeometryDictionary.Add(ICons.GrowFont, "pack://application:,,,/DiagramBuilder;component/Resources/GrowFont16.png");
            GeometryDictionary.Add(ICons.DecreaseFont, "pack://application:,,,/DiagramBuilder;component/Resources/ShrinkFont16.png");
            GeometryDictionary.Add(ICons.Strike, "pack://application:,,,/DiagramBuilder;component/Resources/Strike.png");

            GeometryDictionary.Add(ICons.SelectAll, "pack://application:,,,/DiagramBuilder;component/Resources/Select-all.png");
            GeometryDictionary.Add(ICons.SelectNode, "pack://application:,,,/DiagramBuilder;component/Resources/select-nodes.png");
            GeometryDictionary.Add(ICons.SelectConnector, "pack://application:,,,/DiagramBuilder;component/Resources/select-connectors.png");

            GeometryDictionary.Add(ICons.SpaceAcross, "pack://application:,,,/DiagramBuilder;component/Resources/SpaceAcross.png");
            GeometryDictionary.Add(ICons.SpaceDown, "pack://application:,,,/DiagramBuilder;component/Resources/SpaceDown.png");
            GeometryDictionary.Add(ICons.DrawingTool_Ellipse, "pack://application:,,,/DiagramBuilder;component/Resources/DrawTool_Ellipse.png");
            GeometryDictionary.Add(ICons.DrawingTool_Rectangle, "pack://application:,,,/DiagramBuilder;component/Resources/DrawTool_Rectangle.png");
            GeometryDictionary.Add(ICons.DrawingTool_StraightLine, "pack://application:,,,/DiagramBuilder;component/Resources/DrawTool_StraightLine.png");
            GeometryDictionary.Add(ICons.Polyline, "pack://application:,,,/DiagramBuilder;component/Resources/Polyline.png");

            GeometryDictionary.Add(ICons.ConnectorType, "pack://application:,,,/DiagramBuilder;component/Resources/Connectors.png");
            GeometryDictionary.Add(ICons.ConnectorType_Orthogonal, "pack://application:,,,/DiagramBuilder;component/Resources/Orthogonal.png");
            GeometryDictionary.Add(ICons.ConnectorType_StraightLine, "pack://application:,,,/DiagramBuilder;component/Resources/StraightLine.png");
            GeometryDictionary.Add(ICons.ConnectorType_CubicBeier, "pack://application:,,,/DiagramBuilder;component/Resources/CubicBezier.png");

            GeometryDictionary.Add(ICons.TaskPanes, "pack://application:,,,/DiagramBuilder;component/Resources/Taskpane.png");
            GeometryDictionary.Add(ICons.PanZoom, "pack://application:,,,/DiagramBuilder;component/Resources/PanZoom.png");
            GeometryDictionary.Add(ICons.SizeandPosition, "pack://application:,,,/DiagramBuilder;component/Resources/SizeandPosition.png");
            GeometryDictionary.Add(ICons.Subtopic, "pack://application:,,,/DiagramBuilder;component/Resources/Subtopic.png");
            GeometryDictionary.Add(ICons.MultipleSubtopics, "pack://application:,,,/DiagramBuilder;component/Resources/MultipleSubtopics.png");
            GeometryDictionary.Add(ICons.Peer, "pack://application:,,,/DiagramBuilder;component/Resources/Peer.png");
            GeometryDictionary.Add(ICons.ChangeTopic, "pack://application:,,,/DiagramBuilder;component/Resources/ChangeTopic.png");
            GeometryDictionary.Add(ICons.DiagramStyle, "pack://application:,,,/DiagramBuilder;component/Resources/DiagramStyle.png");
            GeometryDictionary.Add(ICons.ExportData, "pack://application:,,,/DiagramBuilder;component/Resources/ExportData.png");
            GeometryDictionary.Add(ICons.ImportData, "pack://application:,,,/DiagramBuilder;component/Resources/ImportData.png");
        }

        public static string ToImageSource(this ICons source)
        {

            if (source == ICons.None)
            {
                return null;
            }
            return GeometryDictionary[source];
        }
    }

    public enum Controls
    {
        Button,
        ToggleButton,
        FontFamily,
        FontSize,
        Combobox,
        ColorPicker,
        SplitButton,
        CheckBox,
        Galary
    }

    public enum Tabs
    {
        HOME,
        INSERT,
        VIEW,
        DESIGN,
        BRAINSTORMING,
        NewBRAINSTORMING
    }

    public enum Groups
    {
        Clipboard,
        Font,
        Paragraph,
        Alignment,
        Tools,
        ShapeStyle,
        Arrange,
        Editing,
        Show,
        Zoom,
        PageSetup,
        Pages,
        Illustrations,
        AddTopics,
        Manage
    }

    public enum ICons
    {
        Cut,
        SpaceDown,
        SpaceAcross,
        SelectAll,
        SelectNode,
        SelectConnector,
        Position,
        Copy,
        Paste,
        Polyline,
        FontFamily,
        GrowFont,
        Bold,
        Strike,
        DecreaseFont,
        Italic,
        Underline,
        FontSize,
        Label,
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight,
        PointerTool,
        Connector,
        Text,
        Port,
        SelectText,
        RotateText,
        Fill,
        Stroke,
        Orientation,
        Potrait,
        Landscape,
        Size,
        A4,
        A5,
        Legal,
        Letter,
        Ledger,
        Ruler,
        Grid,
        PageBreaks,
        MultiplePage,
        SnapToObject,
        SnapToGrid,
        Zoom,
        FitToPage,
        Pagewidth,
        Align,
        AlignLeft,
        AlignCenter,
        AlignRight,
        AlignTop,
        AlignBottom,
        AlignMiddle,
        Group,
        UnGroup,
        BringToFront,
        BringForward,
        SendToBack,
        SendBackward,
        NewPage,
        DuplicatePage,
        Pictures,
        None,
        Select,
        DrawingTool_Rectangle,
        DrawingTool_Ellipse,
        DrawingTool_StraightLine,
        ConnectorType,
        ConnectorType_Orthogonal,
        ConnectorType_StraightLine,
        ConnectorType_CubicBeier,
        TaskPanes,
        PanZoom,
        SizeandPosition,
        Subtopic,
        MultipleSubtopics,
        Peer,
        ChangeTopic,
        DiagramStyle,
        ExportData,
        ImportData
    }

}
