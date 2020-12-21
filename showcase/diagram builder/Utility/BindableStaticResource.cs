// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BindableStaticResource.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the bindable static resource.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System;
    using System.Windows.Data;
    using System.Windows.Markup;

    /// <summary>
    ///     Represents the bindable static resource.
    /// </summary>
    public class BindableStaticResource : MarkupExtension
    {
        /// <summary>
        /// Represents the multibinding value of the service provider.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            MultiBinding multiBinding = new MultiBinding();
            multiBinding.Bindings.Add(
                new Binding { RelativeSource = new RelativeSource { Mode = RelativeSourceMode.Self } });
            multiBinding.Bindings.Add(new Binding());
            multiBinding.Converter = new ResourceKeyToResourceConverter();
            return multiBinding.ProvideValue(serviceProvider);
        }
    }
}