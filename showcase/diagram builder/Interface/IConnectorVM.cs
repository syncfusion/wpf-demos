// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConnectorVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the ConnectorVM interface class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    /// <summary>
    ///     Represents the ConnectorVM interface class.
    /// </summary>
    public interface IConnectorVM : IGroupableVM
    {
        /// <summary>
        ///     Gets or sets the connector gallery name.
        /// </summary>
        string ConnectorGalleryName { get; set; }

        /// <summary>
        ///     Gets or sets the source cap.
        /// </summary>
        string SourceCap { get; set; }

        /// <summary>
        ///     Gets or sets the target cap.
        /// </summary>
        string TargetCap { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        ConnectType Type { get; set; }
    }
}