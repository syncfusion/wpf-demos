// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RibbonCheckBox.cs" company="">
//   
// </copyright>
// <summary>
//   Represent the ThemeCheckBox.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Windows;

    using DiagramBuilder.ViewModel;

    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represent the ThemeCheckBox.
    /// </summary>
    public class ThemeCheckBox : RibbonCheckBox
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ThemeCheckBox" /> class.
        /// </summary>
        public ThemeCheckBox()
        {
            this.Checked += this.ThemeCheckBox_Checked;
            this.Unchecked += this.ThemeCheckBox_Unchecked;
        }

        /// <summary>
        /// The theme check box_ checked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ThemeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (win.DataContext is DiagramBuilderVM)
                {
                    (win.DataContext as DiagramBuilderVM).IsApplyTheme = true;
                }
            }
        }

        /// <summary>
        /// The theme check box_ unchecked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ThemeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (win.DataContext is DiagramBuilderVM)
                {
                    (win.DataContext as DiagramBuilderVM).IsApplyTheme = false;
                }
            }
        }
    }
}