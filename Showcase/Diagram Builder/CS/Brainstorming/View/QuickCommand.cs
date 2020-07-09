// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuickCommand.cs" company="">
//   
// </copyright>
// <summary>
//   The quick command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.View
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    ///     The quick command.
    /// </summary>
    public class QuickCommand : Syncfusion.UI.Xaml.Diagram.QuickCommand
    {
        /// <summary>
        ///     Initializes static members of the <see cref="QuickCommand" /> class.
        /// </summary>
        static QuickCommand()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(QuickCommand),
                new FrameworkPropertyMetadata(typeof(QuickCommand)));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="QuickCommand" /> class.
        /// </summary>
        public QuickCommand()
        {
            this.MouseEnter += this.QuickCommand_MouseEnter;
            this.MouseLeave += this.QuickCommand_MouseLeave;
            this.MouseLeftButtonDown += this.QuickCommand_MouseLeftButtonDown;
        }

        /// <summary>
        /// The quick command_ mouse enter.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void QuickCommand_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "PointerOver", true);
        }

        /// <summary>
        /// The quick command_ mouse leave.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void QuickCommand_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "Normal", true);
        }

        /// <summary>
        /// The quick command_ mouse left button down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void QuickCommand_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VisualStateManager.GoToState(this, "Pressed", true);
        }
    }
}