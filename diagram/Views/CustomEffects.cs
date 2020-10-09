#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Represents the Effect to apply for Theme.
    /// </summary>
    public class CustomEffect : Effect
    {
        /// <summary>
        /// Convert the hexa decimal code to brush color.
        /// </summary>
        /// <param name="hex"> hexa decimal value</param>
        /// <returns>SolidColorBrush</returns>
        private Brush ConvertHexToBrush(string hex)
        {
            Brush brush = (SolidColorBrush)(new BrushConverter().ConvertFrom(hex));
            return brush;
        }
        /// <summary>
        /// Define the color pattern
        /// </summary>
        /// <param name="startPoint">Start point</param>
        /// <param name="endPoint">End point</param>
        /// <param name="angle">Angle of the color</param>
        /// <param name="centerX">center position of X</param>
        /// <param name="centery">center position of Y</param>
        /// <param name="colors">list of color codes</param>
        /// <param name="offsets">position of the color</param>
        /// <returns></returns>
        HsvLinearColorPattern generateHSVPattern(Point startPoint, Point endPoint, double angle, double centerX, double centery, List<string> colors, List<double> offsets)
        {
            HsvLinearColorPattern fillpattern = new HsvLinearColorPattern()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                Stops = new HsvSolidColorPatternCollection()
                            {
                                new HsvSolidColorPattern()
                                {
                                    BaseColor = BaseColor.Color,
                                    Color = ConvertHexToBrush(colors[0]),
                                    Offset = offsets[0]
                                },
                                new HsvSolidColorPattern()
                                {
                                    BaseColor = BaseColor.Color,
                                    Color = ConvertHexToBrush(colors[1]),
                                    Offset = offsets[1]
                                },
                                new HsvSolidColorPattern()
                                {
                                    BaseColor = BaseColor.Color,
                                    Color = ConvertHexToBrush(colors[2]),
                                    Offset = offsets[2]
                                },
                            }
            };

            fillpattern.Transform = new RotateTransform()
            {
                Angle = angle,
                CenterX = centerX,
                CenterY = centery
            };

            return fillpattern;
        }
        /// <summary>
        /// Generate the theme style based on the accent. 
        /// </summary>
        /// <param name="theme">diagram theme</param>
        /// <param name="accent"></param>
        /// <returns></returns>
        public override DiagramItemStyle GenerateStyle(Theme theme, string accent)
        {
            if (this.Name.Equals("Subtly"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Stroke = ConvertHexToBrush("#e9eff7");
                        style.Foreground = ConvertHexToBrush("#5b9bd5");
                        break;
                    case "Accent2":
                        style.Stroke = ConvertHexToBrush("#ebeff5");
                        style.Foreground = ConvertHexToBrush("#759fcc");
                        break;
                    case "Accent3":
                        style.Stroke = ConvertHexToBrush("#e8ebef");
                        style.Foreground = ConvertHexToBrush("#41719c");
                        break;
                    case "Accent4":
                        style.Stroke = ConvertHexToBrush("#f3f6fa");
                        style.Foreground = ConvertHexToBrush("#bdd0e9");
                        break;
                    case "Accent5":
                        style.Stroke = ConvertHexToBrush("#fbece7");
                        style.Foreground = ConvertHexToBrush("#ed7d31");
                        break;
                    case "Accent6":
                        style.Stroke = ConvertHexToBrush("#ebf1e8");
                        style.Foreground = ConvertHexToBrush("#70ad47");
                        break;
                    case "Accent7":
                        style.Stroke = ConvertHexToBrush("#fef4e7");
                        style.Foreground = ConvertHexToBrush("#fec000");
                        break;
                }
                return style;
            }
            else if (this.Name.Equals("Refined"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Foreground = ConvertHexToBrush("#5b9bd5");
                        break;
                    case "Accent2":
                        style.Foreground = ConvertHexToBrush("#759fcc");
                        break;
                    case "Accent3":
                        style.Foreground = ConvertHexToBrush("#41719c");
                        break;
                    case "Accent4":
                        style.Foreground = ConvertHexToBrush("#bdd0e9");
                        break;
                    case "Accent5":
                        style.Foreground = ConvertHexToBrush("#ed7d31");
                        break;
                    case "Accent6":
                        style.Foreground = ConvertHexToBrush("#70ad47");
                        break;
                    case "Accent7":
                        style.Foreground = ConvertHexToBrush("#fec000");
                        break;
                }
                return style;
            }
            else if (this.Name.Equals("Balanced"))
            {
                HsvLinearColorPattern hsvPattern = null;
                Brush foreground = null;
                Brush stroke = null;
                switch (accent)
                {
                    case "Accent1":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#e9eff7", "#f4f7fb", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#4f87bb");
                        break;
                    case "Accent2":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#ebeff5", "#f5f7fa", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#668bb3");
                        break;
                    case "Accent3":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#e8ebef", "#f4f5f7", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#386288");
                        break;
                    case "Accent4":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#f3f6fa", "#f9fafc", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#a6b6cd");
                        break;
                    case "Accent5":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#fbece7", "#fdf5f3", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#d06d29");
                        break;
                    case "Accent6":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#ebf1e8", "#f5f8f4", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#61973d");
                        break;
                    case "Accent7":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#fef4e7", "#fef9f3", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#dfa800");
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
            else if (this.Name.Equals("Moderate"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                style.Foreground = ConvertHexToBrush("#feffff");
                return style;
            }
            else if (this.Name.Equals("Focused"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Stroke = ConvertHexToBrush("#40709c");
                        break;
                    case "Accent2":
                        style.Stroke = ConvertHexToBrush("#547395");
                        break;
                    case "Accent3":
                        style.Stroke = ConvertHexToBrush("#2d5171");
                        break;
                    case "Accent4":
                        style.Stroke = ConvertHexToBrush("#8a98ab");
                        break;
                    case "Accent5":
                        style.Stroke = ConvertHexToBrush("#ae5a21");
                        break;
                    case "Accent6":
                        style.Stroke = ConvertHexToBrush("#507e31");
                        break;
                    case "Accent7":
                        style.Stroke = ConvertHexToBrush("#ba8c00");
                        break;
                }
                style.Foreground = ConvertHexToBrush("#feffff");
                return style;
            }
            else if (this.Name.Equals("Intense"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Stroke = ConvertHexToBrush("#40709c");
                        break;
                    case "Accent2":
                        style.Stroke = ConvertHexToBrush("#547395");
                        break;
                    case "Accent3":
                        style.Stroke = ConvertHexToBrush("#2d5171");
                        break;
                    case "Accent4":
                        style.Stroke = ConvertHexToBrush("#8a98ab");
                        break;
                    case "Accent5":
                        style.Stroke = ConvertHexToBrush("#ae5a21");
                        break;
                    case "Accent6":
                        style.Stroke = ConvertHexToBrush("#507e31");
                        break;
                    case "Accent7":
                        style.Stroke = ConvertHexToBrush("#ba8c00");
                        break;
                }
                style.Foreground = ConvertHexToBrush("#feffff");
                return style;
            }
            else
                return base.GenerateStyle(theme, accent);
        }
    }
}
