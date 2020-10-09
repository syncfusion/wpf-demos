// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeView.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the node view class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Windows;
    using System.Windows.Data;

    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Represents the node view class.
    /// </summary>
    public class NodeView : Node
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeView" /> class.
        /// </summary>
        public NodeView()
        {
            this.SetBinding(
                VisibilityProperty,
                new Binding { Path = new PropertyPath("Visibility"), Mode = BindingMode.TwoWay });
        }
    }
}