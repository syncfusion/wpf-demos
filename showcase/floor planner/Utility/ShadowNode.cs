#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Controls.Navigation;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Shapes;

namespace syncfusion.floorplanner.wpf
{
    public class ShadowNode : FloorPlanNode
    {
        private SfRadialSlider radialSlider;

        public ShadowNode() : base()
        {
            this.Constraints = NodeConstraints.None;
            this.Annotations = null;
        }

        public FloorPlanConnector TargetConnector { get; set; }

        public void Show()
        {
            radialSlider = new SfRadialSlider()
            {
                Width = 110,
                Height = 110,
                TickFrequency = 2,
                SmallChange = 1,
                Minimum = 2,
                Maximum = 10,
                InnerRimRadiusFactor = 0.4,
                LabelVisibility = Visibility.Visible
            };

            var resource = new System.Windows.ResourceDictionary() { Source = new Uri(@"/syncfusion.floorplanner.wpf;component/Template/FloorPlanDictionary.xaml", UriKind.RelativeOrAbsolute) };
            radialSlider.LabelTemplate = resource["LabelTemplate"] as DataTemplate;

            var binding = new Binding("Value");
            binding.Source = radialSlider;
            radialSlider.SetBinding(SfRadialSlider.ContentProperty, binding);

            this.Content = radialSlider;
            if (TargetConnector != null)
            {
                foreach (Setter setter in TargetConnector.ConnectorGeometryStyle.Setters)
                {
                    if (setter.Property.Name == "StrokeThickness")
                    {
                        radialSlider.Value = double.Parse(setter.Value.ToString());
                        break;
                    }
                }
            }

            radialSlider.ValueChanged += RadialSlider_ValueChanged;
        }

        private void RadialSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (TargetConnector != null)
            {
                var newStyle = new Style() { TargetType = typeof(Path) };
                foreach (Setter setter in TargetConnector.ConnectorGeometryStyle.Setters)
                {
                    if (setter.Property.Name == "StrokeThickness")
                    {
                        var newSetter = new Setter()
                        {
                            Property = Path.StrokeThicknessProperty,
                            Value = e.NewValue
                        };
                        newStyle.Setters.Add(newSetter);

                        continue;
                    }

                    newStyle.Setters.Add(setter);
                }

                TargetConnector.ConnectorGeometryStyle = newStyle;
            }

            this.Hide();
        }

        public void Hide()
        {
            if (radialSlider != null)
            {
                radialSlider.ValueChanged -= RadialSlider_ValueChanged;
                this.Content = null;
            }
        }
    }
}
