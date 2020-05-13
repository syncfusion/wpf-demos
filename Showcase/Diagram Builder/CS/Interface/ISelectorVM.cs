// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISelectorVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the SelectorVM interface class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Represents the SelectorVM interface class.
    /// </summary>
    public interface ISelectorVM : ISelector
    {
        /// <summary>
        ///     Gets or sets the allow drag.
        /// </summary>
        bool? AllowDrag { get; set; }

        /// <summary>
        ///     Gets or sets the allow resize.
        /// </summary>
        bool? AllowResize { get; set; }

        /// <summary>
        ///     Gets or sets the allow rotate.
        /// </summary>
        bool? AllowRotate { get; set; }

        /// <summary>
        ///     Gets or sets the angle.
        /// </summary>
        double? Angle { get; set; }

        /// <summary>
        ///     Gets or sets the aspect ratio.
        /// </summary>
        bool? AspectRatio { get; set; }

        /// <summary>
        ///     Gets or sets the bold.
        /// </summary>
        bool? Bold { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether bottom.
        /// </summary>
        bool Bottom { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether bottom left.
        /// </summary>
        bool BottomLeft { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether bottom right.
        /// </summary>
        bool BottomRight { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether center.
        /// </summary>
        bool Center { get; set; }

        /// <summary>
        ///     Gets or sets the connector gallary name.
        /// </summary>
        string ConnectorGalleryName { get; set; }

        /// <summary>
        ///     Gets or sets the current brush.
        /// </summary>
        CurrentBrush CurrentBrush { get; set; }

        /// <summary>
        ///     Gets or sets the dash dot command.
        /// </summary>
        ICommand DashDotCommand { get; set; }

        /// <summary>
        ///     Gets or sets the decorator.
        /// </summary>
        string Decorator { get; set; }

        /// <summary>
        ///     Gets or sets the decorator command.
        /// </summary>
        ICommand DecoratorCommand { get; set; }

        /// <summary>
        ///     Gets or sets the fill.
        /// </summary>
        Brush Fill { get; set; }

        /// <summary>
        ///     Gets or sets the font.
        /// </summary>
        FontFamily Font { get; set; }

        /// <summary>
        ///     Gets or sets the font size.
        /// </summary>
        int? FontSize { get; set; }

        /// <summary>
        ///     Gets or sets the font style.
        /// </summary>
        FontStyle? FontStyle { get; set; }

        /// <summary>
        ///     Gets or sets the font value.
        /// </summary>
        int? FontValue { get; set; }

        /// <summary>
        ///     Gets or sets the font weight.
        /// </summary>
        FontWeight? FontWeight { get; set; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        double? Height { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is anything selected.
        /// </summary>
        bool IsAnythingSelected { get; set; }

        /// <summary>
        ///     Gets or sets the is brush editing.
        /// </summary>
        Visibility IsBrushEditing { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is connector label set.
        /// </summary>
        bool IsConnectorLabelSet { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is connector selected.
        /// </summary>
        bool IsConnectorSelected { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is label set.
        /// </summary>
        bool IsLabelSet { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is node label set.
        /// </summary>
        bool IsNodeLabelSet { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is node selected.
        /// </summary>
        bool IsNodeSelected { get; set; }

        /// <summary>
        ///     Gets or sets the italic.
        /// </summary>
        bool? Italic { get; set; }

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
        ///     Gets or sets the label h align.
        /// </summary>
        HorizontalAlignment? LabelHAlign { get; set; }

        /// <summary>
        ///     Gets or sets the label margin.
        /// </summary>
        double? LabelMargin { get; set; }

        /// <summary>
        ///     Gets or sets the label v align.
        /// </summary>
        VerticalAlignment? LabelVAlign { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether left.
        /// </summary>
        bool Left { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether middle.
        /// </summary>
        bool Middle { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Gets or sets the node gallary name.
        /// </summary>
        string NodeGalleryName { get; set; }

        /// <summary>
        ///     Gets or sets the opacity.
        /// </summary>
        double? Opacity { get; set; }

        /// <summary>
        ///     Gets or sets the picked brush.
        /// </summary>
        Brush PickedBrush { get; set; }

        /// <summary>
        ///     Gets or sets the picker command.
        /// </summary>
        ICommand PickerCommand { get; set; }

        /// <summary>
        ///     Gets or sets the px.
        /// </summary>
        double? Px { get; set; }

        /// <summary>
        ///     Gets or sets the py.
        /// </summary>
        double? Py { get; set; }

        /// <summary>
        ///     Gets or sets the quick fill.
        /// </summary>
        Brush QuickFill { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether right.
        /// </summary>
        bool Right { get; set; }

        /// <summary>
        ///     Gets or sets the rotate text.
        /// </summary>
        bool? RotateText { get; set; }

        /// <summary>
        ///     Gets or sets the scale.
        /// </summary>
        double Scale { get; set; }

        /// <summary>
        ///     Gets or sets the source cap.
        /// </summary>
        string SourceCap { get; set; }

        /// <summary>
        ///     Gets or sets the stroke.
        /// </summary>
        Brush Stroke { get; set; }

        /// <summary>
        ///     Gets or sets the style.
        /// </summary>
        Style Style { get; set; }

        /// <summary>
        ///     Gets or sets the target cap.
        /// </summary>
        string TargetCap { get; set; }

        /// <summary>
        ///     Gets or sets the text alignment.
        /// </summary>
        TextAlignment? TextAlignment { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether text center.
        /// </summary>
        bool TextCenter { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether text left.
        /// </summary>
        bool TextLeft { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether text right.
        /// </summary>
        bool TextRight { get; set; }

        /// <summary>
        ///     Gets or sets the thickness.
        /// </summary>
        double? Thickness { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether top.
        /// </summary>
        bool Top { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether top left.
        /// </summary>
        bool TopLeft { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether top right.
        /// </summary>
        bool TopRight { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        ConnectType? Type { get; set; }

        /// <summary>
        ///     Gets or sets the under line.
        /// </summary>
        bool? UnderLine { get; set; }

        /// <summary>
        ///     Gets or sets the visibile.
        /// </summary>
        bool? Visible { get; set; }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        double? Width { get; set; }

        /// <summary>
        ///     Gets or sets the x.
        /// </summary>
        double? X { get; set; }

        /// <summary>
        ///     Gets or sets the y.
        /// </summary>
        double? Y { get; set; }
    }
}