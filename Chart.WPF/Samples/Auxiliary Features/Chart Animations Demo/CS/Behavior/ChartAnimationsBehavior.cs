#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Data;
using Syncfusion.Windows.Chart;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Controls;
using System.Collections;

namespace ChartAnimations
{
    class ChartAnimationsBehavior : Behavior<Window1>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.AnimTypes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(AnimTypes_SelectionChanged);
            base.OnAttached();
        }

        void AnimTypes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.AssociatedObject.AnimTypes.SelectedItem != null)
            {
                ListBoxItem item = this.AssociatedObject.AnimTypes.SelectedItem as ListBoxItem;

                switch (item.Content.ToString())
                {
                    case "Bounce":
                        StepValueProvider.AnimationType = "Bounce";
                        break;
                    case "Elastic":
                        StepValueProvider.AnimationType = "Elastic";
                        break;
                    case "Back":
                        StepValueProvider.AnimationType = "Back";
                        break;
                    case "Cubic":
                        StepValueProvider.AnimationType = "Cubic";
                        break;
                    case "Quintic":
                        StepValueProvider.AnimationType = "Quintic";
                        break;
                }
                ApplyTemplateToSeries("ColumnTemplate", this.AssociatedObject.ColumnChart);
            }
            else
                this.AssociatedObject.AnimTypes.SelectedIndex = 0;
        }

        private void ApplyTemplateToSeries(string Key, Chart chart)
        {
            foreach (ChartSeries series in chart.Areas[0].Series)
            {
                series.Template = this.AssociatedObject.Resources[Key] as DataTemplate;

                // Resetting DataSource to null helps force a redraw on the chart while changing the template.
                // This workaround, of course, won't be necessary if you don't plan to change the series' template
                // during runtime.
                IEnumerable source = series.DataSource as IEnumerable;
                series.DataSource = null;
                series.DataSource = source;
            }
        }
    }

   

    public class StepValueProvider : IDoubleAnimationStepValueProvider
    {
        public static string AnimationType = "Bounce";

        #region IDoubleAnimationStepValueProvider Members

        public double GetAnimationStepValue(double totalseconds, double from, double current, double duration)
        {
            switch (AnimationType)
            {
                case "Bounce": return GetBounceAnimationStepValue(totalseconds, from, current, duration);
                case "Elastic": return GetElasticAnimationStepValue(totalseconds, from, current, duration);
                case "Back": return GetBackAnimationStepValue(totalseconds, from, current, duration);
                case "Cubic": return GetCubicAnimationStepValue(totalseconds, from, current, duration);
                case "Quintic": return GetQuinticAnimationStepValue(totalseconds, from, current, duration);
            }
            throw new Exception("Invalid AnimationType specified");
        }
        public double GetBounceAnimationStepValue(double totalseconds, double from, double current, double duration)
        {
            if ((totalseconds /= duration) < (1 / 2.75))
                return current * (7.5625 * totalseconds * totalseconds) + from;
            else if (totalseconds < (2 / 2.75))
                return current * (7.5625 * (totalseconds -= (1.5 / 2.75)) * totalseconds + .75) + from;
            else if (totalseconds < (2.5 / 2.75))
                return current * (7.5625 * (totalseconds -= (2.25 / 2.75)) * totalseconds + .9375) + from;
            else
                return current * (7.5625 * (totalseconds -= (2.625 / 2.75)) * totalseconds + .984375) + from;
        }
        public double GetElasticAnimationStepValue(double totalseconds, double from, double current, double duration)
        {
            if ((totalseconds /= duration) == 1)
                return from + current;

            double p = duration * .3;
            double s = p / 4;

            return (current * Math.Pow(2, -10 * totalseconds) * Math.Sin((totalseconds * duration - s) * (2 * Math.PI) / p) + current + from);
        }
        public double GetBackAnimationStepValue(double t, double b, double c, double d)
        {
            return c * ((t = t / d - 1) * t * ((1.70158 + 1) * t + 1.70158) + 1) + b;
        }
        public double GetCubicAnimationStepValue(double t, double b, double c, double d)
        {
            if ((t /= d / 2) < 1)
                return c / 2 * t * t * t + b;

            return c / 2 * ((t -= 2) * t * t + 2) + b;
        }
        public double GetQuinticAnimationStepValue(double t, double b, double c, double d)
        {
            if (t < d / 2)
            {
                return ((c / 2) * ((t = t / d - 1) * t * t * t * t + 1) + b);
            }
            double s = (t * 2 - d);
            double f = (b + c / 2);
            double e = c / 2;
            return e * (s /= d) * s * s * s * s + f;
        }
        #endregion
    }

    public class AnimationValueProvider : IDoubleAnimationStepValueProvider
    {
        #region IAnimationStepValueProvider Members

        public double GetAnimationStepValue(double t, double b, double c, double d)
        {
            if ((t /= d) == 1)
                return b + c;

            double p = d * .3;
            double s = p / 4;

            return (c * Math.Pow(2, -10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p) + c + b);
        }
        #endregion
    }

    public class PieAnimationValueProvider : IDoubleAnimationStepValueProvider
    {
        #region IAnimationStepValueProvider Members

        // Penner animation - bounce ease out:
        public double GetAnimationStepValue(double t, double b, double c, double d)
        {
            if ((t /= d) < (1 / 2.75))
                return c * (7.5625 * t * t) + b;
            else if (t < (2 / 2.75))
                return c * (7.5625 * (t -= (1.5 / 2.75)) * t + .75) + b;
            else if (t < (2.5 / 2.75))
                return c * (7.5625 * (t -= (2.25 / 2.75)) * t + .9375) + b;
            else
                return c * (7.5625 * (t -= (2.625 / 2.75)) * t + .984375) + b;
        }

        #endregion
    }

    public class OffsetXCalculator : OffsetCalculator
    {
        public OffsetXCalculator() : base(0) { }
    }
    public class OffsetYCalculator : OffsetCalculator
    {
        public OffsetYCalculator() : base(1) { }
    }
    public class OffsetCalculator : IValueConverter
    {
        private int mode;
        public OffsetCalculator(int mode)
        {
            if (mode < 0 || mode > 2)
                throw new Exception("Valid values for OffsetCalculator are 0 or 1. 0 for X Offset, 1 for Y Offset");

            this.mode = mode;
        }

        #region IValueConverter Members

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartSegment seg = value as ChartSegment;
            double val = 0;
            double angle = 0;
            ChartPieSegment pieseg = seg as ChartPieSegment;
            // this happens during designer load.
            if (pieseg == null)
                return 0;

            angle = pieseg.AngleOfSliceRotation;

            Point pt = ChartSegment.GetCenterOfViewport((ChartSegment)value);

            if (mode == 0)
            {
                // OffsetX:             
                val = Math.Cos(angle) * 200d;
            }
            else
            {
                // OffsetY:
                val = Math.Sin(angle) * 200d;
            }
            return val;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
