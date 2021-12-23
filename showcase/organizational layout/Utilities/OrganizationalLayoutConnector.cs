#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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

namespace syncfusion.organizationallayout.wpf
{
    public class organizationallayoutConnector : ConnectorViewModel
    {
        private SolidColorBrush strokeColor = new SolidColorBrush(Colors.Gray);

        public organizationallayoutConnector() : base()
        {
            this.Annotations = null;
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
            var newStyle = new Style() { TargetType = typeof(Path) };
            if (propertyName == default(string))
            {
                newStyle.Setters.Add(new Setter() { Property = Path.StrokeProperty, Value = this.strokeColor });
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
