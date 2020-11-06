// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DesignVariantRibbonGalleryItem.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the design variant ribbon gallery item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Collections.Generic;
    using System.Windows;

    using Syncfusion.UI.Xaml.Diagram.Theming;
    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represents the design variant ribbon gallery item.
    /// </summary>
    public class DesignVariantRibbonGalleryItem : RibbonGalleryItem
    {
        // Using a DependencyProperty as the backing store for ConnectorVariant.  This enables animation, styling, binding, etc...
        /// <summary>
        ///     The connector variant property.
        /// </summary>
        internal static readonly DependencyProperty ConnectorVariantProperty = DependencyProperty.Register(
            "ConnectorVariant",
            typeof(Dictionary<StyleId, DiagramItemStyle>),
            typeof(DesignVariantRibbonGalleryItem),
            new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for Theme.  This enables animation, styling, binding, etc...
        /// <summary>
        ///     The theme property.
        /// </summary>
        internal static readonly DependencyProperty ThemeProperty = DependencyProperty.Register(
            "Theme",
            typeof(DiagramTheme),
            typeof(DesignVariantRibbonGalleryItem),
            new PropertyMetadata(null));

        /// <summary>
        ///     Initializes a new instance of the <see cref="DesignVariantRibbonGalleryItem" /> class.
        /// </summary>
        public DesignVariantRibbonGalleryItem()
        {
            this.IsEnabledChanged += this.DesignVariantRibbonGalleryItem_IsEnabledChanged;
        }

        /// <summary>
        ///     Gets or sets the connector variant.
        /// </summary>
        internal Dictionary<StyleId, DiagramItemStyle> ConnectorVariant
        {
            get
            {
                return (Dictionary<StyleId, DiagramItemStyle>)this.GetValue(ConnectorVariantProperty);
            }

            set
            {
                this.SetValue(ConnectorVariantProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the theme.
        /// </summary>
        internal DiagramTheme Theme
        {
            get
            {
                return (DiagramTheme)this.GetValue(ThemeProperty);
            }

            set
            {
                this.SetValue(ThemeProperty, value);
            }
        }

        /// <summary>
        /// The design variant ribbon gallery item_ is enabled changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DesignVariantRibbonGalleryItem_IsEnabledChanged(
            object sender,
            DependencyPropertyChangedEventArgs e)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = new System.Uri(@"/syncfusion.diagrambuilder.wpf;component/View/DiagramThemeResources.xaml", System.UriKind.RelativeOrAbsolute)
            };

            if ((bool)e.NewValue)
            {
                this.ContentTemplate = resourceDictionary["ribbonVariantItemTemplate"] as DataTemplate;
            }
            else
            {
                switch (this.Name)
                {
                    case "VariantGallery0":
                        this.ContentTemplate =
                            resourceDictionary["disabledRibbonVariantItemTemplate0"] as DataTemplate;
                        break;
                    case "VariantGallery1":
                    case "VariantGallery2":
                    case "VariantGallery3":
                        this.ContentTemplate =
                            resourceDictionary["disabledRibbonVariantItemTemplate1"] as DataTemplate;
                        break;
                }
            }
        }
    }
}