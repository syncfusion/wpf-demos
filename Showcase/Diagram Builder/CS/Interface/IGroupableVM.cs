// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGroupableVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the GroupableVM interface class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    ///     Represents the GroupableVM interface class.
    /// </summary>
    public interface IGroupableVM : INotifyPropertyChanged
    {
        /// <summary>
        ///     Gets or sets a value indicating whether text appears as bold or not.
        /// </summary>
        bool Bold { get; set; }

        /// <summary>
        ///     Gets or sets the dash dot.
        /// </summary>
        string DashDot { get; set; }

        /// <summary>
        ///     Gets or sets the font.
        /// </summary>
        FontFamily Font { get; set; }

        /// <summary>
        ///     Gets or sets the font size.
        /// </summary>
        int FontSize { get; set; }

        /// <summary>
        ///     Gets or sets the font style.
        /// </summary>
        FontStyle FontStyle { get; set; }

        /// <summary>
        ///     Gets or sets the font weight.
        /// </summary>
        FontWeight FontWeight { get; set; }

        /// <summary>
        ///     Gets or sets the hyper link.
        /// </summary>
        string HyperLink { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether text appears as italic or not.
        /// </summary>
        bool Italic { get; set; }

        /// <summary>
        ///     Gets or sets the label.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        ///     Gets or sets the label background.
        /// </summary>
        Brush LabelBackground { get; set; }

        /// <summary>
        ///     Gets or sets the label foreground.
        /// </summary>
        Brush LabelForeground { get; set; }

        /// <summary>
        ///     Gets or sets the label horizontal alignment.
        /// </summary>
        HorizontalAlignment LabelHAlign { get; set; }

        /// <summary>
        ///     Gets or sets the label margin.
        /// </summary>
        Thickness LabelMargin { get; set; }

        /// <summary>
        ///     Gets or sets the label vertical alignment.
        /// </summary>
        VerticalAlignment LabelVAlign { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Gets or sets the opacity.
        /// </summary>
        double Opacity { get; set; }

        /// <summary>
        ///     Gets or sets the quick fill.
        /// </summary>
        Brush QuickFill { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether text appears with strike or not.
        /// </summary>
        bool Strike { get; set; }

        /// <summary>
        ///     Gets or sets the stroke.
        /// </summary>
        Brush Stroke { get; set; }

        /// <summary>
        ///     Gets or sets the style.
        /// </summary>
        Style Style { get; set; }

        /// <summary>
        ///     Gets or sets the text alignment.
        /// </summary>
        TextAlignment TextAlignment { get; set; }

        /// <summary>
        ///     Gets or sets the thickness.
        /// </summary>
        double Thickness { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether text appears with under line or not.
        /// </summary>
        bool UnderLine { get; set; }

        /// <summary>
        ///     Gets or sets the visibility.
        /// </summary>
        Visibility Visibility { get; set; }
    }
}