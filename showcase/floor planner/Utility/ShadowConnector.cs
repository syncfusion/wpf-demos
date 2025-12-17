using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.floorplanner.wpf
{
    public class ShadowConnector : FloorPlanConnector
    {
        private Size arrowSize = new Size(13, 25);

        public ShadowConnector() : base()
        {
            this.SourceDecorator = GetArrow();
            this.TargetDecorator = GetArrow();
            this.SourceDecoratorStyle = null;
            this.TargetDecoratorStyle = null;
            this.ConnectorGeometryStyle = null;
            this.Annotations = new AnnotationCollection() { new AnnotationEditorViewModel() { ViewTemplate = new DataTemplate() } };
            this.Constraints = ConnectorConstraints.None;
            this.Segments = new ObservableCollection<IConnectorSegment>() { new StraightSegment() };
        }

        public void Show()
        {
            this.SourceDecoratorStyle = this.GetArrowStyle();
            this.TargetDecoratorStyle = this.GetArrowStyle();
            this.ConnectorGeometryStyle = GetLineStyle();
            (this.Annotations as AnnotationCollection)[0].ViewTemplate = GetAnnotationTemplate();
        }

        public void Hide()
        {
            this.SourceDecoratorStyle = null;
            this.TargetDecoratorStyle = null;
            this.ConnectorGeometryStyle = null;
            (this.Annotations as AnnotationCollection)[0].ViewTemplate = new DataTemplate();
        }

        private DataTemplate GetAnnotationTemplate()
        {
            var resource = new ResourceDictionary() { Source = new Uri(@"/syncfusion.floorplanner.wpf;component/Template/FloorPlanDictionary.xaml", UriKind.RelativeOrAbsolute) };
            return resource != null ? resource["AnnotationViewTemplate"] as DataTemplate : null;
        }

        private Geometry GetArrow()
        {
            PathGeometry arrow = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new Point(0, arrowSize.Height / 2);
            figure.Segments = new PathSegmentCollection();
            figure.Segments.Add(new LineSegment() { Point = new Point(arrowSize.Width - 2, arrowSize.Height) });
            figure.Segments.Add(new LineSegment() { Point = new Point(0, arrowSize.Height * 1.5) });
            figure.IsFilled = true;
            figure.IsClosed = true;
            arrow.Figures.Add(figure);
            figure = new PathFigure();
            figure.StartPoint = new Point(arrowSize.Width - 2, 0);
            figure.Segments.Add(new LineSegment() { Point = new Point(arrowSize.Width - 2, arrowSize.Height * 2) });
            arrow.Figures.Add(figure);
            return arrow;
        }

        private Style GetArrowStyle()
        {
            Style style = new Style(typeof(Path));
            style.Setters.Add(new Setter(Path.WidthProperty, arrowSize.Width));
            style.Setters.Add(new Setter(Path.HeightProperty, arrowSize.Height));
            style.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            style.Setters.Add(new Setter(Path.StrokeThicknessProperty, 1d));
            style.Setters.Add(new Setter(Path.FillProperty, (SolidColorBrush)new BrushConverter().ConvertFromString("#FFBF2121")));
            style.Setters.Add(new Setter(Path.StrokeProperty, (SolidColorBrush)new BrushConverter().ConvertFromString("#FFBF2121")));
            return style;
        }

        private Style GetLineStyle()
        {
            Style style = new Style(typeof(Path));
            style.Setters.Add(new Setter(Path.StrokeThicknessProperty, 1d));
            style.Setters.Add(new Setter(Path.StrokeProperty, new SolidColorBrush(Colors.Red)));
            return style;
        }

    }
}
