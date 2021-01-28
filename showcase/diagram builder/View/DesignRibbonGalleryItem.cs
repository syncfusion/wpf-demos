// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DesignRibbonGalleryItem.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the custom class for ribbon gallery item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Runtime.Serialization;
    using System.Windows;

    using DiagramBuilder.Model;

    using Syncfusion.UI.Xaml.Diagram.Theming;
    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represents the custom class for ribbon gallery item.
    /// </summary>
    public class DesignRibbonGalleryItem : RibbonGalleryItem
    {
        // Using a DependencyProperty as the backing store for Theme.  This enables animation, styling, binding, etc...
        /// <summary>
        ///     The theme property.
        /// </summary>
        internal static readonly DependencyProperty ThemeProperty = DependencyProperty.Register(
            "Theme",
            typeof(DiagramTheme),
            typeof(DesignRibbonGalleryItem),
            new PropertyMetadata(null, OnThemeChanged));

        /// <summary>
        ///     The _mThemeName.
        /// </summary>
        private string _mThemeName;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DesignRibbonGalleryItem" /> class.
        /// </summary>
        public DesignRibbonGalleryItem()
        {
            this.Loaded += this.DesignRibbonGalleryItem_Loaded;
        }

        /// <summary>
        ///     Gets or sets the theme name.
        /// </summary>
        [DataMember]
        public string ThemeName
        {
            get
            {
                return this._mThemeName;
            }

            set
            {
                if (this._mThemeName != value)
                {
                    this._mThemeName = value;
                }
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
        /// This method triggers whenever a theme is changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DesignRibbonGalleryItem item = d as DesignRibbonGalleryItem;
            if (item.Theme != null)
            {
                item.Content = new GalleryStyle();
                GalleryStyle itemContent = item.Content as GalleryStyle;
                if (item.Theme.NodeStyles != null)
                {
                    itemContent.Variant1 = item.Theme.NodeStyles[StyleId.Variant1];
                    itemContent.Variant2 = item.Theme.NodeStyles[StyleId.Variant2];
                    itemContent.Variant3 = item.Theme.NodeStyles[StyleId.Variant3];
                    itemContent.Variant4 = item.Theme.NodeStyles[StyleId.Variant4];
                }
            }

            if (item.Theme.ConnectorStyles != null)
            {
                (item.Content as GalleryStyle).ConnectorVariant =
                    (d as DesignRibbonGalleryItem).Theme.ConnectorStyles[StyleId.Subtly | StyleId.Accent1];
            }
        }

        /// <summary>
        /// This method is invoked when the design ribbon gallery item is loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DesignRibbonGalleryItem_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Name.Equals("Custom1_ThemeRibbon"))
            {
            }

            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = new System.Uri(@"/syncfusion.diagrambuilder.wpf;component/View/DiagramThemeResources.xaml",System.UriKind.RelativeOrAbsolute)
            };

            this.Theme = resourceDictionary[this.ThemeName] as DiagramTheme;
            this.ContentTemplate = resourceDictionary["ribbonItemTemplate"] as DataTemplate;
        }
    }
}