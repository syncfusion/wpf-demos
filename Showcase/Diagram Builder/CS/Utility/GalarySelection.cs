// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GalarySelection.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the galary selection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System.Windows;
    using System.Windows.Input;

    using DiagramBuilder.Model;

    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represents the galary selection.
    /// </summary>
    public class GallerySelection
    {
        /// <summary>
        ///     Represents the select command property.
        /// </summary>
        public static readonly DependencyProperty SelectCommandProperty = DependencyProperty.RegisterAttached(
            "SelectCommand",
            typeof(ICommand),
            typeof(GallerySelection),
            new PropertyMetadata(null, OnPropertyChanged));

        /// <summary>
        /// This method returns the selected command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="ICommand"/>.
        /// </returns>
        public static ICommand SelectCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(SelectCommandProperty);
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
        public static void SetSelectCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(SelectCommandProperty, value);
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
        /// This method triggers when ribbon gallery selection is changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void rg_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand command = SelectCommand(d);
            if (e.NewValue != null)
            {
                string name = string.Empty;

                if (e.NewValue is RibbonGalleryItem && (e.NewValue as RibbonGalleryItem).Content is GalleryStyle)
                {
                    command.Execute(e.NewValue);
                }
                else
                {
                    if (e.NewValue.ToString().Contains("Syncfusion.Windows.Tools.Controls.RibbonGalleryItem:"))
                    {
                        name = e.NewValue.ToString().Remove(0, 53);
                    }
                    else
                    {
                        name = e.NewValue.ToString();
                    }

                    if (command != null)
                    {
                        command.Execute(name);
                    }
                }
            }
        }
    }
}