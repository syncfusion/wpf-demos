// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomEffect.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the effects of diagram theme.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;

    using Syncfusion.UI.Xaml.Diagram.Theming;

    /// <summary>
    ///     Represents the effects of diagram theme.
    /// </summary>
    public class CustomEffect : Effect
    {
        /// <summary>
        /// The generate style method will generate style based on the stroke and foreground color.
        /// </summary>
        /// <param name="theme">
        /// The theme.
        /// </param>
        /// <param name="accent">
        /// The accent.
        /// </param>
        /// <returns>
        /// The <see cref="DiagramItemStyle"/>.
        /// </returns>
        public override DiagramItemStyle GenerateStyle(Theme theme, string accent)
        {
            if (this.Name.Equals("Subtly"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Stroke = this.ConvertHexToBrush("#e9eff7");
                        style.Foreground = this.ConvertHexToBrush("#5b9bd5");
                        break;
                    case "Accent2":
                        style.Stroke = this.ConvertHexToBrush("#ebeff5");
                        style.Foreground = this.ConvertHexToBrush("#759fcc");
                        break;
                    case "Accent3":
                        style.Stroke = this.ConvertHexToBrush("#e8ebef");
                        style.Foreground = this.ConvertHexToBrush("#41719c");
                        break;
                    case "Accent4":
                        style.Stroke = this.ConvertHexToBrush("#f3f6fa");
                        style.Foreground = this.ConvertHexToBrush("#bdd0e9");
                        break;
                    case "Accent5":
                        style.Stroke = this.ConvertHexToBrush("#fbece7");
                        style.Foreground = this.ConvertHexToBrush("#ed7d31");
                        break;
                    case "Accent6":
                        style.Stroke = this.ConvertHexToBrush("#ebf1e8");
                        style.Foreground = this.ConvertHexToBrush("#70ad47");
                        break;
                    case "Accent7":
                        style.Stroke = this.ConvertHexToBrush("#fef4e7");
                        style.Foreground = this.ConvertHexToBrush("#fec000");
                        break;
                }

                return style;
            }

            if (this.Name.Equals("Refined"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Foreground = this.ConvertHexToBrush("#5b9bd5");
                        break;
                    case "Accent2":
                        style.Foreground = this.ConvertHexToBrush("#759fcc");
                        break;
                    case "Accent3":
                        style.Foreground = this.ConvertHexToBrush("#41719c");
                        break;
                    case "Accent4":
                        style.Foreground = this.ConvertHexToBrush("#bdd0e9");
                        break;
                    case "Accent5":
                        style.Foreground = this.ConvertHexToBrush("#ed7d31");
                        break;
                    case "Accent6":
                        style.Foreground = this.ConvertHexToBrush("#70ad47");
                        break;
                    case "Accent7":
                        style.Foreground = this.ConvertHexToBrush("#fec000");
                        break;
                }

                return style;
            }

            if (this.Name.Equals("Balanced"))
            {
                HsvLinearColorPattern hsvPattern = null;
                Brush foreground = null;
                Brush stroke = null;
                switch (accent)
                {
                    case "Accent1":
                        hsvPattern = this.generateHSVPattern(
                            new Point(0, 0),
                            new Point(1, 0),
                            60,
                            0.5,
                            0.5,
                            new List<string> { "#e9eff7", "#f4f7fb", "#feffff" },
                            new List<double> { 0, 0.24, 0.54 });
                        foreground = stroke = this.ConvertHexToBrush("#4f87bb");
                        break;
                    case "Accent2":
                        hsvPattern = this.generateHSVPattern(
                            new Point(0, 0),
                            new Point(1, 0),
                            60,
                            0.5,
                            0.5,
                            new List<string> { "#ebeff5", "#f5f7fa", "#feffff" },
                            new List<double> { 0, 0.24, 0.54 });
                        foreground = stroke = this.ConvertHexToBrush("#668bb3");
                        break;
                    case "Accent3":
                        hsvPattern = this.generateHSVPattern(
                            new Point(0, 0),
                            new Point(1, 0),
                            60,
                            0.5,
                            0.5,
                            new List<string> { "#e8ebef", "#f4f5f7", "#feffff" },
                            new List<double> { 0, 0.24, 0.54 });
                        foreground = stroke = this.ConvertHexToBrush("#386288");
                        break;
                    case "Accent4":
                        hsvPattern = this.generateHSVPattern(
                            new Point(0, 0),
                            new Point(1, 0),
                            60,
                            0.5,
                            0.5,
                            new List<string> { "#f3f6fa", "#f9fafc", "#feffff" },
                            new List<double> { 0, 0.24, 0.54 });
                        foreground = stroke = this.ConvertHexToBrush("#a6b6cd");
                        break;
                    case "Accent5":
                        hsvPattern = this.generateHSVPattern(
                            new Point(0, 0),
                            new Point(1, 0),
                            60,
                            0.5,
                            0.5,
                            new List<string> { "#fbece7", "#fdf5f3", "#feffff" },
                            new List<double> { 0, 0.24, 0.54 });
                        foreground = stroke = this.ConvertHexToBrush("#d06d29");
                        break;
                    case "Accent6":
                        hsvPattern = this.generateHSVPattern(
                            new Point(0, 0),
                            new Point(1, 0),
                            60,
                            0.5,
                            0.5,
                            new List<string> { "#ebf1e8", "#f5f8f4", "#feffff" },
                            new List<double> { 0, 0.24, 0.54 });
                        foreground = stroke = this.ConvertHexToBrush("#61973d");
                        break;
                    case "Accent7":
                        hsvPattern = this.generateHSVPattern(
                            new Point(0, 0),
                            new Point(1, 0),
                            60,
                            0.5,
                            0.5,
                            new List<string> { "#fef4e7", "#fef9f3", "#feffff" },
                            new List<double> { 0, 0.24, 0.54 });
                        foreground = stroke = this.ConvertHexToBrush("#dfa800");
                        break;
                }

                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                if (hsvPattern != null)
                {
                    style.Fill = hsvPattern.GetBrush(theme, accent);
                }

                style.Stroke = stroke;
                style.Foreground = foreground;
                return style;
            }

            if (this.Name.Equals("Moderate"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                style.Foreground = this.ConvertHexToBrush("#feffff");
                return style;
            }

            if (this.Name.Equals("Focused"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Stroke = this.ConvertHexToBrush("#40709c");
                        break;
                    case "Accent2":
                        style.Stroke = this.ConvertHexToBrush("#547395");
                        break;
                    case "Accent3":
                        style.Stroke = this.ConvertHexToBrush("#2d5171");
                        break;
                    case "Accent4":
                        style.Stroke = this.ConvertHexToBrush("#8a98ab");
                        break;
                    case "Accent5":
                        style.Stroke = this.ConvertHexToBrush("#ae5a21");
                        break;
                    case "Accent6":
                        style.Stroke = this.ConvertHexToBrush("#507e31");
                        break;
                    case "Accent7":
                        style.Stroke = this.ConvertHexToBrush("#ba8c00");
                        break;
                }

                style.Foreground = this.ConvertHexToBrush("#feffff");
                return style;
            }

            if (this.Name.Equals("Intense"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Stroke = this.ConvertHexToBrush("#40709c");
                        break;
                    case "Accent2":
                        style.Stroke = this.ConvertHexToBrush("#547395");
                        break;
                    case "Accent3":
                        style.Stroke = this.ConvertHexToBrush("#2d5171");
                        break;
                    case "Accent4":
                        style.Stroke = this.ConvertHexToBrush("#8a98ab");
                        break;
                    case "Accent5":
                        style.Stroke = this.ConvertHexToBrush("#ae5a21");
                        break;
                    case "Accent6":
                        style.Stroke = this.ConvertHexToBrush("#507e31");
                        break;
                    case "Accent7":
                        style.Stroke = this.ConvertHexToBrush("#ba8c00");
                        break;
                }

                style.Foreground = this.ConvertHexToBrush("#feffff");
                return style;
            }

            return base.GenerateStyle(theme, accent);
        }

        /// <summary>
        /// This method will convert the hexadecimal value to brush color.
        /// </summary>
        /// <param name="hex">
        /// The hex.
        /// </param>
        /// <returns>
        /// The <see cref="Brush"/>.
        /// </returns>
        private Brush ConvertHexToBrush(string hex)
        {
            Brush brush = (SolidColorBrush)new BrushConverter().ConvertFrom(hex);
            return brush;
        }

        /// <summary>
        /// This method will generate hsv linear color pattern.
        /// </summary>
        /// <param name="startPoint">
        /// The start point.
        /// </param>
        /// <param name="endPoint">
        /// The end point.
        /// </param>
        /// <param name="angle">
        /// The angle.
        /// </param>
        /// <param name="centerX">
        /// The center x.
        /// </param>
        /// <param name="centerY">
        /// The centerY.
        /// </param>
        /// <param name="colors">
        /// The colors.
        /// </param>
        /// <param name="offsets">
        /// The offsets.
        /// </param>
        /// <returns>
        /// The <see cref="HsvLinearColorPattern"/>.
        /// </returns>
        private HsvLinearColorPattern generateHSVPattern(
            Point startPoint,
            Point endPoint,
            double angle,
            double centerX,
            double centerY,
            List<string> colors,
            List<double> offsets)
        {
            HsvLinearColorPattern fillPattern = new HsvLinearColorPattern
                                                    {
                                                        StartPoint = startPoint,
                                                        EndPoint = endPoint,
                                                        Stops = new HsvSolidColorPatternCollection
                                                                    {
                                                                        new HsvSolidColorPattern
                                                                            {
                                                                                BaseColor = BaseColor.Color,
                                                                                Color = this.ConvertHexToBrush(
                                                                                    colors[0]),
                                                                                Offset = offsets[0]
                                                                            },
                                                                        new HsvSolidColorPattern
                                                                            {
                                                                                BaseColor = BaseColor.Color,
                                                                                Color = this.ConvertHexToBrush(
                                                                                    colors[1]),
                                                                                Offset = offsets[1]
                                                                            },
                                                                        new HsvSolidColorPattern
                                                                            {
                                                                                BaseColor = BaseColor.Color,
                                                                                Color = this.ConvertHexToBrush(
                                                                                    colors[2]),
                                                                                Offset = offsets[2]
                                                                            }
                                                                    }
                                                    };

            fillPattern.Transform = new RotateTransform { Angle = angle, CenterX = centerX, CenterY = centerY };

            return fillPattern;
        }
    }
}