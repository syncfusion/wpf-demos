// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrushPicker.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the brush picker class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    using DiagramBuilder.ViewModel;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     Represents the brush picker class.
    /// </summary>
    public sealed partial class BrushPicker : UserControl
    {
        /// <summary>
        ///     Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            "Color",
            typeof(Color),
            typeof(BrushPicker),
            new PropertyMetadata(Colors.Transparent, OnColorChanged));

        /// <summary>
        ///     Using a DependencyProperty as the backing store for Brush.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty BrushProperty = DependencyProperty.Register(
            "Brush",
            typeof(Brush),
            typeof(BrushPicker),
            new PropertyMetadata(new SolidColorBrush(Colors.Black), OnBrushChanged));

        /// <summary>
        ///     Initializes a new instance of the <see cref="BrushPicker" /> class.
        /// </summary>
        public BrushPicker()
        {
            SkinStorage.SetVisualStyle(this, "Office2013");
            this.InitializeComponent();
        }

        /// <summary>
        ///     Gets or sets the brush.
        /// </summary>
        public Brush Brush
        {
            get
            {
                return (Brush)this.GetValue(BrushProperty);
            }

            set
            {
                this.SetValue(BrushProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the color.
        /// </summary>
        public Color Color
        {
            get
            {
                return (Color)this.GetValue(ColorProperty);
            }

            set
            {
                this.SetValue(ColorProperty, value);
            }
        }

        /// <summary>
        /// This method is used to change the brush color.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BrushPicker brush = d as BrushPicker;
            if (brush.Brush != null)
            {
                if ((brush.Brush as SolidColorBrush).Color != brush.Color)
                {
                    brush.Color = (brush.Brush as SolidColorBrush).Color;
                }
            }
        }

        /// <summary>
        /// This method is used to change the color.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BrushPicker brush = d as BrushPicker;

            if ((brush.Brush as SolidColorBrush).Color != brush.Color)
            {
                brush.Brush = new SolidColorBrush(brush.Color);

                SelectorVM selector = (brush.Tag as DiagramBuilderVM).SelectedDiagram.SelectedItems as SelectorVM;

                BrushConverter converter = new BrushConverter();

                Brush brushS = (Brush)converter.ConvertFromString(e.NewValue.ToString());
                if ((brush.DataContext as DiagramButtonViewModel).Label == "Label")
                {
                    selector.LabelForeground = brushS as SolidColorBrush;
                }
                else if ((brush.DataContext as DiagramButtonViewModel).Label == "Fill")
                {
                    selector.Fill = brushS as SolidColorBrush;
                }
                else if ((brush.DataContext as DiagramButtonViewModel).Label == "Stroke")
                {
                    selector.Stroke = brushS as SolidColorBrush;
                }

                brush.PickerTemp.IsDropDownOpen = false;
            }
        }

        /// <summary>
        /// The button_ click method will expand or collapse the dropdown.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.PickerTemp.IsDropDownOpen) this.PickerTemp.IsDropDownOpen = false;
            else this.PickerTemp.IsDropDownOpen = true;
        }

        /// <summary>
        /// The button_ click_1 method will change the style of the selector.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button element = sender as Button;
            SelectorVM selector = (this.Tag as DiagramBuilderVM).SelectedDiagram.SelectedItems as SelectorVM;
            if (element.Name == "label")
            {
                selector.LabelForeground = this.Brush as SolidColorBrush;
            }
            else if (element.Name == "fill")
            {
                selector.Fill = this.Brush as SolidColorBrush;
            }
            else if (element.Name == "line")
            {
                selector.Stroke = this.Brush as SolidColorBrush;
            }
        }
    }
}