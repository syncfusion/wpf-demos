// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RibbonCommand.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the ribbon command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using DiagramBuilder.View;
    using DiagramBuilder.ViewModel;

    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represents the ribbon command.
    /// </summary>
    internal class RibbonCommand
    {
        /// <summary>
        ///     Represents the command property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(RibbonCommand),
            new PropertyMetadata(null, PropertyChangedCallback));

        /// <summary>
        /// This method returns the command property of the element.
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
            Ribbon ribbon = depObj as Ribbon;
            TextBlock text = depObj as TextBlock;
            if (ribbon != null)
            {
                ribbon.BackStageOpening += Ribbon_BackStageOpening;
                (ribbon.DataContext as DiagramBuilderVM).Ribbon = ribbon;
            }

            if (text != null)
            {
                text.MouseLeftButtonDown += Text_MouseLeftButtonDown;
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
        /// This method invokes when ribbon back stage is opening.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void Ribbon_BackStageOpening(object sender, CancelEventArgs e)
        {
            Ribbon ribbon = sender as Ribbon;
            if (!((ribbon.DataContext as DiagramBuilderVM).IsBackStageCommandButtonsEnabled == false))
            {
                foreach (object obj in ribbon.BackStage.Items)
                {
                    if (obj is BackStageCommandButton)
                    {
                        BackStageCommandButton backStageCommandButton = obj as BackStageCommandButton;
                        if (backStageCommandButton.Header == "Save" || backStageCommandButton.Header == "SaveAs"
                                                                    || backStageCommandButton.Header == "Print"
                                                                    || backStageCommandButton.Header == "Export")
                        {
                            backStageCommandButton.IsEnabled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The method triggers when the text mouse left button is pressed down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void Text_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            if ((text.DataContext as DiagramBuilderVM).Isopen)
            {
                ZoomPanWindow n = new ZoomPanWindow();
                n.DataContext = Application.Current.MainWindow;
                n.Show();
                (text.DataContext as DiagramBuilderVM).Isopen = false;
            }
        }
    }
}