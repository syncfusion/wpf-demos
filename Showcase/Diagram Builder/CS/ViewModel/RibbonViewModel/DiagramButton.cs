// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramButton.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the custom class of ribbon button.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.Windows;

    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represents the custom class of ribbon button.
    /// </summary>
    public class DiagramButton : RibbonButton
    {
        // Using a DependencyProperty as the backing store for ParentVM.  This enables animation, styling, binding, etc...
        /// <summary>
        ///     The parent vm property.
        /// </summary>
        public static readonly DependencyProperty ParentVMProperty = DependencyProperty.Register(
            "ParentVM",
            typeof(DiagramBuilderVM),
            typeof(DiagramButton),
            new PropertyMetadata(null));

        /// <summary>
        ///     Gets or sets the parent vm.
        /// </summary>
        public DiagramBuilderVM ParentVM
        {
            get
            {
                return (DiagramBuilderVM)this.GetValue(ParentVMProperty);
            }

            set
            {
                this.SetValue(ParentVMProperty, value);
            }
        }
    }
}