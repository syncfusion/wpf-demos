#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// StepValue provider.
    /// </summary>
    public class StepValueProvider : IDoubleAnimationStepValueProvider
    {
        public static string AnimationType;

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
}
