// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewCommand.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the list view command class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;

    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represents the list view command class.
    /// </summary>
    internal class ListViewCommand
    {
        /// <summary>
        ///     Represents the command property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(ListViewCommand),
            new PropertyMetadata(null, PropertyChangedCallback));

        /// <summary>
        /// The get command method will return the command.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="ICommand"/>.
        /// </returns>
        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        /// <summary>
        /// Represents the property changed callback value.
        /// </summary>
        /// <param name="depObj">
        /// The dep obj.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            RibbonMenuItem listView = depObj as RibbonMenuItem;
            ColorPickerPalette colorPicker = depObj as ColorPickerPalette;
            if (listView != null)
            {
                listView.Click += ListView_Click;
            }

            if (colorPicker != null)
            {
                colorPicker.MoreColorWindowOpening += ColorPicker_MoreColorWindowOpening;
            }
        }

        /// <summary>
        /// This method triggers when a commad is set to the element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="command">
        /// The command.
        /// </param>
        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }

        /// <summary>
        /// This method handles the popup opening and popup closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void ColorPicker_MoreColorWindowOpening(object sender, MoreColorCancelEventArgs args)
        {
            ColorPickerPalette colorPicker = sender as ColorPickerPalette;
            if (colorPicker.Parent is StackPanel && (colorPicker.Parent as StackPanel).Parent is Popup)
                ((colorPicker.Parent as StackPanel).Parent as Popup).IsOpen = false;
        }

        /// <summary>
        /// Executing the list view header command.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void ListView_Click(object sender, RoutedEventArgs e)
        {
            RibbonMenuItem listView = sender as RibbonMenuItem;
            if (listView != null)
            {
                ICommand command = listView.GetValue(CommandProperty) as ICommand;

                if (command != null)
                {
                    command.Execute(listView.Header);
                }
            }
        }
    }
}