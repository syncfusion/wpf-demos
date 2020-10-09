// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramBuilder1.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the user control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Windows.Controls;

    /// <summary>
    ///     Represents the user control.
    /// </summary>
    public sealed partial class DiagramBuilder1 : UserControl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DiagramBuilder1" /> class.
        /// </summary>
        public DiagramBuilder1()
        {
            this.InitializeComponent();

#if SyncfusionFramework4_5_1
            MenuFlyout menu = new MenuFlyout();
            Binding bind = new Binding { Path = new PropertyPath("SelectedDiagram.Export") };
            List<string> formats = new List<string> { "Png", "Jpeg", "Gif", "Tiff", "Jpegxr" };
            foreach (var item in formats)
            {
                MenuFlyoutItem menuItem = new MenuFlyoutItem
                {
                    Text = item,
                    CommandParameter = item
                };
                menuItem.SetBinding(MenuFlyoutItem.CommandProperty, bind);
                menu.Items.Add(menuItem);
            }
            export.Flyout = menu;
#endif
        }
    }
}