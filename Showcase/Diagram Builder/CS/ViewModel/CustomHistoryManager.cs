// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomHistoryManager.cs" company="">
//   
// </copyright>
// <summary>
//   Reprsents the custom history manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Reprsents the custom history manager.
    /// </summary>
    public class CustomHistoryManager : HistoryManager
    {
        /// <summary>
        /// Restore the last action that was reverted.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object Redo(object data)
        {
            return data;
        }

        /// <summary>
        /// The Undo method reverses the last editing action performed.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object Undo(object data)
        {
            return data;
        }
    }
}