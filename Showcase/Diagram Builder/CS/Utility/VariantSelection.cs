// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariantSelection.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the variant selection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System.Windows;
    using System.Windows.Input;

    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represents the variant selection.
    /// </summary>
    public class VariantSelection
    {
        /// <summary>
        ///     Represents the selection command property.
        /// </summary>
        public static readonly DependencyProperty SelectionCommandProperty = DependencyProperty.RegisterAttached(
            "SelectionCommand",
            typeof(ICommand),
            typeof(VariantSelection),
            new PropertyMetadata(null, OnPropertyChanged));

        /// <summary>
        /// This method returns the selection command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="ICommand"/>.
        /// </returns>
        public static ICommand SelectionCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(SelectionCommandProperty);
        }

        /// <summary>
        /// This method invokes when a selected command value is assigned to the object.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void SetSelectionCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(SelectionCommandProperty, value);
        }

        /// <summary>
        /// Occurs when ever the property changes.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonGallery rg = d as RibbonGallery;
            rg.SelectedItemChanged += rg_SelectedItemChanged;
        }

        /// <summary>
        /// This method triggers when ribbon gallery selected item is changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void rg_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand command = SelectionCommand(d);
            if (e.NewValue != null)
            {
                command.Execute(e.NewValue);
            }
        }
    }
}