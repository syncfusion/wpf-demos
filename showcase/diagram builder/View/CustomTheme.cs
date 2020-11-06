// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomTheme.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the custom theme.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Collections.Generic;

    using Syncfusion.UI.Xaml.Diagram.Theming;

    /// <summary>
    ///     Represents the custom theme.
    /// </summary>
    public class CustomTheme : DiagramTheme
    {
        /// <summary>
        ///     Represents the node variant styles.
        /// </summary>
        private List<Dictionary<StyleId, DiagramItemStyle>> _mVariantStyles;

        /// <summary>
        ///     Represents the connector variant styles.
        /// </summary>
        private List<Dictionary<StyleId, DiagramItemStyle>> MConnectorVariantStyles;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomTheme" /> class.
        /// </summary>
        public CustomTheme()
        {
            this.VariantStyles = new List<Dictionary<StyleId, DiagramItemStyle>>();
            this.ConnectorVariantStyles = new List<Dictionary<StyleId, DiagramItemStyle>>();
        }

        /// <summary>
        ///     Gets or sets the node connector styles.
        /// </summary>
        public List<Dictionary<StyleId, DiagramItemStyle>> ConnectorVariantStyles
        {
            get
            {
                return this.MConnectorVariantStyles;
            }

            set
            {
                if (this.MConnectorVariantStyles != value)
                {
                    this.MConnectorVariantStyles = value;
                    this.OnPropertyChanged("ConnectorVariantStyles");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the node variant styles.
        /// </summary>
        public List<Dictionary<StyleId, DiagramItemStyle>> VariantStyles
        {
            get
            {
                return this._mVariantStyles;
            }

            set
            {
                if (this._mVariantStyles != value)
                {
                    this._mVariantStyles = value;
                    this.OnPropertyChanged("VariantStyles");
                }
            }
        }

        /// <summary>
        ///     The initialize styles.
        /// </summary>
        public override void InitializeStyles()
        {
            base.InitializeStyles();
            this.GenerateStyles();
        }

        /// <summary>
        ///     The generate styles.
        /// </summary>
        private void GenerateStyles()
        {
            this.VariantStyles = new List<Dictionary<StyleId, DiagramItemStyle>>();
            this.ConnectorVariantStyles = new List<Dictionary<StyleId, DiagramItemStyle>>();
            Dictionary<StyleId, DiagramItemStyle> DiagramItemStyles;
            DiagramItemStyle variant1;
            DiagramItemStyle variant2;
            DiagramItemStyle variant3;
            DiagramItemStyle variant4;
            this.NodeStyles.TryGetValue(StyleId.Variant1, out variant1);
            this.NodeStyles.TryGetValue(StyleId.Variant2, out variant2);
            this.NodeStyles.TryGetValue(StyleId.Variant3, out variant3);
            this.NodeStyles.TryGetValue(StyleId.Variant4, out variant4);

            DiagramItemStyles = new Dictionary<StyleId, DiagramItemStyle>();
            DiagramItemStyles.Add(StyleId.Variant1, variant1);
            DiagramItemStyles.Add(StyleId.Variant2, variant2);
            DiagramItemStyles.Add(StyleId.Variant3, variant3);
            DiagramItemStyles.Add(StyleId.Variant4, variant4);

            this.VariantStyles.Add(DiagramItemStyles);

            #region Palette 1

            DiagramItemStyles = new Dictionary<StyleId, DiagramItemStyle>();
            DiagramItemStyles.Add(StyleId.Variant1, variant2);
            DiagramItemStyles.Add(StyleId.Variant2, variant1);
            DiagramItemStyles.Add(StyleId.Variant3, variant3);
            DiagramItemStyles.Add(StyleId.Variant4, variant4);

            #endregion

            this.VariantStyles.Add(DiagramItemStyles);

            #region Palette 2

            DiagramItemStyles = new Dictionary<StyleId, DiagramItemStyle>();
            DiagramItemStyles.Add(StyleId.Variant1, variant3);
            DiagramItemStyles.Add(StyleId.Variant2, variant1);
            DiagramItemStyles.Add(StyleId.Variant3, variant2);
            DiagramItemStyles.Add(StyleId.Variant4, variant4);

            #endregion

            this.VariantStyles.Add(DiagramItemStyles);

            #region Palette 3

            DiagramItemStyles = new Dictionary<StyleId, DiagramItemStyle>();
            DiagramItemStyles.Add(StyleId.Variant1, variant4);
            DiagramItemStyles.Add(StyleId.Variant2, variant1);
            DiagramItemStyles.Add(StyleId.Variant3, variant2);
            DiagramItemStyles.Add(StyleId.Variant4, variant3);

            #endregion

            this.VariantStyles.Add(DiagramItemStyles);
            this.ConnectorVariantStyles.Add(DiagramItemStyles);
        }
    }
}