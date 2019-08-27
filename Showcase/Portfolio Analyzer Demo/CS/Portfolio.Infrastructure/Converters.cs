#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using Syncfusion.Windows.Shared;

using System.Windows.Media;
using System.Windows;
using Syncfusion.UI.Xaml.Charts;

namespace PortfolioAnalyzer.Infrastructure
{

    #region  Converters
    /// <summary>
    /// Volume converter.
    /// </summary>
    public class VolumeConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converts a value from bool to Visibility.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartAxisLabel x = value as ChartAxisLabel;
            if (x != null)
            {
                double v = System.Convert.ToDouble(x.LabelContent);
                return Math.Round(v / 100000, 1);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns> A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// Label converter for Chart.
    /// </summary>
    public class Labelconvertor : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (parameter.ToString() == "SectorValue")
            {
                SectorAndValue info = value as SectorAndValue;

                return String.Format("{0}\n({1}$)", info.SectorName, info.Value);
            }
            else if (parameter.ToString() == "ExchangeValue")
            {
                ExchangeAndValue info = value as ExchangeAndValue;

                return String.Format("{0}\n({1}$)", info.ExchangeName, info.Value);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }


    #region offsetCalculater
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
            //ChartSegment seg = value as ChartSegment;
            //double val = 0;
            //double angle = 0;
            //ChartPieSegment pieseg = seg as ChartPieSegment;
            //// this happens during designer load.
            //if (pieseg == null)
            //    return 0;

            //angle = pieseg.AngleOfSliceRotation;


            //Point pt = ChartSegment.GetCenterOfViewport((ChartSegment)value);

            //if (mode == 0)
            //{
            //    // OffsetX:             
            //    val = Math.Cos(angle) * 200d;
            //}
            //else
            //{
            //    // OffsetY:
            //    val = Math.Sin(angle) * 200d;
            //}
            return value;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
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
    #endregion


    #region ImageConverter
    /// <summary>
    /// Converter to convert resource key into Drawing image.
    /// </summary>
    public class ImageConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                DrawingImage image = Application.Current.Resources[value] as DrawingImage;
                return image;
            }
            return null;
        }



        public Object ConvertBack(Object value, Type targetTypes, Object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    #endregion


   

    #endregion

    #region
    /// <summary>
    /// StepValue provider.
    /// </summary>
    public class StepValueProvider : IDoubleAnimationStepValueProvider
    {
        public static string AnimationType;

        #region IDoubleAnimationStepValueProvider Members

        public double GetAnimationStepValue(double totalseconds, double from, double current, double duration)
        {
            //return GetCubicAnimationStepValue(totalseconds, from, current, duration);
            switch (AnimationType)
            {
                case "Bounce": return GetBounceAnimationStepValue(totalseconds, from, current, duration);
                case "Elastic": return GetElasticAnimationStepValue(totalseconds, from, current, duration);
                case "Back": return GetBackAnimationStepValue(totalseconds, from, current, duration);
                case "Cubic": return GetCubicAnimationStepValue(totalseconds, from, current, duration);
                case "Quintic": return GetQuinticAnimationStepValue(totalseconds, from, current, duration);
                default: return GetCubicAnimationStepValue(totalseconds, from, current, duration);
            }
            throw new Exception("Invalid AnimationType specified");
        }
        // Methods for animations.
        private static double GetBounceAnimationStepValue(double totalseconds, double from, double current, double duration)
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

    #endregion

    #region
    /// <summary>
    /// Property that hold Sector and Value.
    /// </summary>
    public class SectorAndValue
    {
        public string SectorName { get; set; }
        public Decimal? Value { get; set; }
    }

    /// <summary>
    /// Property that hold Exchange and Value.
    /// </summary>
    public class ExchangeAndValue
    {
        public string ExchangeName { get; set; }
        public Decimal? Value { get; set; }
    }


    /// <summary>
    /// Offset calculator that calculate X.
    /// </summary>
    public class OffsetXCalculator : OffsetCalculator
    {
        public OffsetXCalculator() : base(0) { }
    }

    /// <summary>
    /// Offset calculator that calculate Y.
    /// </summary>
    public class OffsetYCalculator : OffsetCalculator
    {
        public OffsetYCalculator() : base(1) { }
    }

    #endregion

    #region SmartLabelConverter
    public class SmartValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null )
            {
                double smartValue = double.Parse(value.ToString()) / 1000000;
                return smartValue.ToString()+"M";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

}
