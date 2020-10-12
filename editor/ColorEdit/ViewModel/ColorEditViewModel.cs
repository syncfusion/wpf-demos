#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.editordemos.wpf
{
    public class ColorEditViewModel : NotificationObject
    {
        private Brush brush1 = Brushes.Pink;
        private Color invertColor1 = (Color)ColorConverter.ConvertFromString("#003f34");
        private Brush brush2 = Brushes.Blue;
        private Color invertColor2 = (Color)ColorConverter.ConvertFromString("#ffff00");
        private Brush brush3;
        private Color invertColor3 = (Color)ColorConverter.ConvertFromString("#13520a");
        private Brush brush4;
        private Color invertColor4 = (Color)ColorConverter.ConvertFromString("#db3815");

        public ColorEditViewModel()
        {
            GradientStopCollection gradientStops1 = new GradientStopCollection();
            gradientStops1.Add(new GradientStop() 
            { 
                Color = (Color)ColorConverter.ConvertFromString("#FFADF5F5"), 
                Offset = 1 
            });
            gradientStops1.Add(new GradientStop() 
            { 
                Color = (Color)ColorConverter.ConvertFromString("#FFECADF5"), 
                Offset = 0 
            });
            brush3 = new LinearGradientBrush(gradientStops1, new Point(0.5, 0), new Point(0.5, 1));

            GradientStopCollection gradientStops2 = new GradientStopCollection();
            gradientStops2.Add(new GradientStop() 
            { 
                Color = (Color)ColorConverter.ConvertFromString("#FF324243"), 
                Offset = 0.999444444444443 
            });
            gradientStops2.Add(new GradientStop() 
            { 
                Color = (Color)ColorConverter.ConvertFromString("#FF24C7EA"), 
                Offset = 0.0127777777777768 
            });
            brush4 = new RadialGradientBrush()
            {
                GradientStops = gradientStops2,
                GradientOrigin = new Point(0.5, 0.5),
                Center = new Point(0.5, 0.5)
            };
        }

        public Brush Brush1
        {
            get
            {
                return brush1;
            }
            set
            {
                if (brush1 != value)
                {
                    brush1 = value;
                    this.RaisePropertyChanged(nameof(this.Brush1));
                }
            }
        }

        public Color InvertColor1
        {
            get
            {
                return invertColor1;
            }
            set
            {
                if (invertColor1 != value)
                {
                    invertColor1 = value;
                    this.RaisePropertyChanged(nameof(this.InvertColor1));
                }
            }
        }

        public Brush Brush2
        {
            get
            {
                return brush2;
            }
            set
            {
                if (brush2 != value)
                {
                    brush2 = value;
                    this.RaisePropertyChanged(nameof(this.Brush2));
                }
            }
        }

        public Color InvertColor2
        {
            get
            {
                return invertColor2;
            }
            set
            {
                if (invertColor2 != value)
                {
                    invertColor2 = value;
                    this.RaisePropertyChanged(nameof(this.InvertColor2));
                }
            }
        }

        public Brush Brush3
        {
            get
            {
                return brush3;
            }
            set
            {
                if (brush3 != value)
                {
                    brush3 = value;
                    this.RaisePropertyChanged(nameof(this.Brush3));
                }
            }
        }

        public Color InvertColor3
        {
            get
            {
                return invertColor3;
            }
            set
            {
                if (invertColor3 != value)
                {
                    invertColor3 = value;
                    this.RaisePropertyChanged(nameof(this.InvertColor3));
                }
            }
        }

        public Brush Brush4
        {
            get
            {
                return brush4;
            }
            set
            {
                if (brush4 != value)
                {
                    brush4 = value;
                    this.RaisePropertyChanged(nameof(this.Brush4));
                }
            }
        }

        public Color InvertColor4
        {
            get
            {
                return invertColor4;
            }
            set
            {
                if (invertColor4 != value)
                {
                    invertColor4 = value;
                    this.RaisePropertyChanged(nameof(this.InvertColor4));
                }
            }
        }
    }
}
