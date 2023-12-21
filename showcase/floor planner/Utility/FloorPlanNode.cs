#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.floorplanner.wpf
{
    public class FloorPlanNode : NodeViewModel
    {
        private SolidColorBrush fillColor = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        private SolidColorBrush strokeColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#444444");

        public FloorPlanNode() : base()
        {
            if (!(this is ShadowNode))
            {
                this.Constraints = NodeConstraints.Default & ~NodeConstraints.Connectable;
                this.Annotations = null;
            }
        }


        [DataMember]
        public SolidColorBrush FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                if (fillColor != value)
                {
                    this.fillColor = value;
                    this.OnPropertyChanged("FillColor");
                }
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

            if (!(this is ShadowNode))
            {
                switch (name)
                {
                    case "Name":
                        this.UpdateStyle();
                        break;
                    case "FillColor":
                        this.UpdateStyle("Fill");
                        break;
                    case "StrokeColor":
                        this.UpdateStyle("Stroke");
                        break;
                }
            }
        }

        private void UpdateStyle(string propertyName = default(string))
        {
            var newStyle = new Style() { TargetType = typeof(System.Windows.Shapes.Path) };
            if (this.ShapeStyle == null)
            {
                newStyle.Setters.Add(new Setter() { Property = Path.StretchProperty, Value = Stretch.Fill });
                newStyle.Setters.Add(new Setter() { Property = Path.FillProperty, Value = this.fillColor });
                newStyle.Setters.Add(new Setter() { Property = Path.StrokeProperty, Value = this.strokeColor });
                if (this.Name.Contains("Door"))
                {
                    newStyle.Setters.Add(new Setter() { Property = Path.StrokeThicknessProperty, Value = 1.3d });
                    newStyle.Setters.Add(new Setter() { Property = Path.StrokeMiterLimitProperty, Value = 10d });
                }
            }
            else
            {
                foreach (Setter setter in this.ShapeStyle.Setters)
                {
                    if (setter.Property.Name == propertyName)
                    {
                        if (propertyName == "Fill")
                        {
                            var newSetter = new Setter()
                            {
                                Property = Path.FillProperty,
                                Value = this.fillColor
                            };
                            newStyle.Setters.Add(newSetter);
                        }
                        else if (propertyName == "Stroke")
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

            this.ShapeStyle = newStyle;
        }
    }
}
