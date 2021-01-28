// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TabbedDiagrams.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the tabbed diagrams.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Collections;
    using System.Windows.Controls;

    using DiagramBuilder.ViewModel;

    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represents the tabbed diagrams.
    /// </summary>
    public sealed partial class TabbedDiagrams : ItemsControl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TabbedDiagrams" /> class.
        /// </summary>
        public TabbedDiagrams()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This method invokes whenever change in the itemsource.
        /// </summary>
        /// <param name="oldValue">
        /// The old value.
        /// </param>
        /// <param name="newValue">
        /// The new value.
        /// </param>
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
        }

        /// <summary>
        /// This method invokes when docking manager window is closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DockingManager_WindowClosing(object sender, WindowClosingEventArgs e)
        {
            e.Cancel = true;
            (this.DataContext as DiagramBuilderVM).SelectedDiagram.EnablePanZoom = false;
        }

        /// <summary>
        /// This method invokes when docking manager window is closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DockingManager_WindowClosing_1(object sender, WindowClosingEventArgs e)
        {
            e.Cancel = true;
            (this.DataContext as DiagramBuilderVM).SelectedDiagram.EnableSizePosition = false;
        }
    }
}