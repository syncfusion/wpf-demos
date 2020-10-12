// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectorView.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the view class for connector.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Windows;
    using System.Windows.Data;

    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Represents the view class for connector.
    /// </summary>
    internal class ConnectorView : Connector
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConnectorView" /> class.
        /// </summary>
        public ConnectorView()
        {
            this.SetBinding(
                VisibilityProperty,
                new Binding { Path = new PropertyPath("Visibility"), Mode = BindingMode.TwoWay });
        }
    }
}