// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GalleryStyle.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the gallery style class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Syncfusion.UI.Xaml.Diagram.Theming;

    /// <summary>
    ///     Represents the gallery style class.
    /// </summary>
    public class GalleryStyle : INotifyPropertyChanged
    {
        /// <summary>
        ///     Represents the _m connector variant.
        /// </summary>
        private DiagramItemStyle _mConnectorVariant;

        /// <summary>
        ///     Represents the _m styles.
        /// </summary>
        private List<DiagramItemStyle> _mStyles;

        /// <summary>
        ///     Represents the _m variant 1.
        /// </summary>
        private DiagramItemStyle _mVariant1;

        /// <summary>
        ///     Represents the _m variant 2.
        /// </summary>
        private DiagramItemStyle _mVariant2;

        /// <summary>
        ///     Represents the _m variant 3.
        /// </summary>
        private DiagramItemStyle _mVariant3;

        /// <summary>
        ///     The _m variant 4.
        /// </summary>
        private DiagramItemStyle _mVariant4;

        /// <summary>
        ///     Represents the property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Gets or sets the connector variant.
        /// </summary>
        public DiagramItemStyle ConnectorVariant
        {
            get
            {
                return this._mConnectorVariant;
            }

            set
            {
                if (this._mConnectorVariant != value)
                {
                    this._mConnectorVariant = value;
                    this.OnPropertyChanged("ConnectorVariant");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the styles.
        /// </summary>
        public List<DiagramItemStyle> Styles
        {
            get
            {
                return this._mStyles;
            }

            set
            {
                if (this._mStyles != value)
                {
                    this._mStyles = value;
                    this.OnPropertyChanged("Styles");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the variant 1.
        /// </summary>
        public DiagramItemStyle Variant1
        {
            get
            {
                return this._mVariant1;
            }

            set
            {
                if (this._mVariant1 != value)
                {
                    this._mVariant1 = value;
                    this.OnPropertyChanged("Variant1");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the variant 2.
        /// </summary>
        public DiagramItemStyle Variant2
        {
            get
            {
                return this._mVariant2;
            }

            set
            {
                if (this._mVariant2 != value)
                {
                    this._mVariant2 = value;
                    this.OnPropertyChanged("Variant2");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the variant 3.
        /// </summary>
        public DiagramItemStyle Variant3
        {
            get
            {
                return this._mVariant3;
            }

            set
            {
                if (this._mVariant3 != value)
                {
                    this._mVariant3 = value;
                    this.OnPropertyChanged("Variant3");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the variant 4.
        /// </summary>
        public DiagramItemStyle Variant4
        {
            get
            {
                return this._mVariant4;
            }

            set
            {
                if (this._mVariant4 != value)
                {
                    this._mVariant4 = value;
                    this.OnPropertyChanged("Variant4");
                }
            }
        }

        /// <summary>
        /// Occurs whenever the property changes.
        /// </summary>
        /// <param name="name">
        /// The name specifies the name of the property.
        /// </param>
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}