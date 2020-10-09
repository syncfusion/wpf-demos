// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrainstormingConnectorVM.cs" company="">
//   
// </copyright>
// <summary>
//   The brainstorming connector vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.ViewModel
{
    using System.Collections.Generic;

    using DiagramBuilder.ViewModel;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.UI.Xaml.Diagram.Theming;

    /// <summary>
    ///     The brainstorming connector vm.
    /// </summary>
    public class BrainstormingConnectorVM : ConnectorVM
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BrainstormingConnectorVM" /> class.
        /// </summary>
        public BrainstormingConnectorVM()
        {
            // Need to fix.
            this.ThemeStyleId = StyleId.Accent1 | StyleId.Subtly;

            this.Constraints = ConnectorConstraints.Default ^ ConnectorConstraints.Selectable;
            var annotations = this.Annotations as List<IAnnotation>;
            if (annotations != null)
            {
                foreach (IAnnotation annotation in annotations)
                {
                    annotation.ReadOnly = true;
                }
            }
        }
    }
}