// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectType.cs" company="">
//   
// </copyright>
// <summary>
//   Specifies the types of the Connector.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    /// <summary>
    ///     Specifies the types of the Connector.
    /// </summary>
    public enum ConnectType
    {
        /// <summary>
        ///     Specifies the connectortype as straight line is essentially just a line with no curve.
        /// </summary>
        Straight,

        /// <summary>
        ///     Specifies the connectortype as orthogonal which consist of a sequence of horizontal and vertical line segments.
        /// </summary>
        Orthogonal,

        /// <summary>
        ///     Specifies the connectortype as bezier which consist of controlpoints to edit the curve.
        /// </summary>
        Bezier
    }
}