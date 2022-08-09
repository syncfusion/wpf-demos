#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.floorplanner.wpf
{
    public class FloorPlanConnector : ConnectorViewModel
    {
        private SolidColorBrush strokeColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#444444");
        private Size arrowSize = new Size(13, 23);

        public FloorPlanConnector() : base()
        {
            if (!(this is ShadowConnector))
            {
                this.SourceDecorator = null;
                this.TargetDecorator = null;
                this.Segments = new ConnectorSegments() { new StraightSegment() };
                this.Annotations = null;
                this.UpdateStyle();
            }
        }

        [DataMember]
        public SolidColorBrush StrokeColor
        {
            get
            {
                return strokeColor;
            }
            set
            {
                if (strokeColor != value)
                {
                    this.strokeColor = value;
                    this.OnPropertyChanged("StrokeColor");
                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            switch (name)
            {
                case "StrokeColor":
                    this.UpdateStyle("Stroke");
                    break;
            }
        }

        private void UpdateStyle(string propertyName = default(string))
        {
            if (!(this is ShadowConnector))
            {
                var newStyle = new Style() { TargetType = typeof(Path) };
                if (propertyName == default(string))
                {
                    newStyle.Setters.Add(new Setter() { Property = Path.StrokeProperty, Value = this.strokeColor });
                    newStyle.Setters.Add(new Setter() { Property = Path.StrokeThicknessProperty, Value = 4d });
                }
                else
                {
                    foreach (Setter setter in this.ConnectorGeometryStyle.Setters)
                    {
                        if (setter.Property.Name == propertyName)
                        {
                            if (propertyName == "Stroke")
                            {
                                var newSetter = new Setter()
                                {
                                    Property = Path.StrokeProperty,
                                    Value = this.strokeColor
                                };
                                newStyle.Setters.Add(newSetter);
                            }

                            continue;
                        }

                        newStyle.Setters.Add(setter);
                    }
                }

                this.ConnectorGeometryStyle = newStyle;
            }
        }
    }
}
