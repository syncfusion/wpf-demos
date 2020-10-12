// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZoomParameter.cs" company="">
//   
// </copyright>
// <summary>
//   customize the default zoom using the zoom parameter class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Model
{
    using System.ComponentModel;

    /// <summary>
    ///     customize the default zoom using the zoom parameter class.
    /// </summary>
    public class ZoomParameter : INotifyPropertyChanged
    {
        /// <summary>
        ///     Represents the _isfiftypercentzoom.
        /// </summary>
        private bool _Isfiftypercentzoom;

        /// <summary>
        ///     Represents the _ishundredpercentzoom.
        /// </summary>
        private bool _Ishundredpercentzoom;

        /// <summary>
        ///     Represents the _isonefiftypercentzoom.
        /// </summary>
        private bool _Isonefiftypercentzoom;

        /// <summary>
        ///     Represents the _ispagewidth.
        /// </summary>
        private bool _ispagewidth;

        /// <summary>
        ///     Represents the _ispercentagezoom.
        /// </summary>
        private bool _ispercentagezoom;

        /// <summary>
        ///     Represents the _isseventyfivepercentzoom.
        /// </summary>
        private bool _Isseventyfivepercentzoom;

        /// <summary>
        ///     Represents the _istwohundredpercentzoom.
        /// </summary>
        private bool _Istwohundredpercentzoom;

        /// <summary>
        ///     Represents the _iswholepage.
        /// </summary>
        private bool _iswholepage;

        /// <summary>
        ///     Represents the _percentagetext.
        /// </summary>
        private string _percentagetext;

        /// <summary>
        ///     Represents the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Gets or sets a value indicating whether diagram can zoom upto fifty percent or not.
        /// </summary>
        public bool IsFiftyPercentZoom
        {
            get
            {
                return this._Isfiftypercentzoom;
            }

            set
            {
                if (this._Isfiftypercentzoom != value)
                {
                    this._Isfiftypercentzoom = value;
                    this.OnPropertyChanged("IsFiftyPercentZoom");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether diagram can zoom upto hundred percent or not.
        /// </summary>
        public bool IsHundredPercentZoom
        {
            get
            {
                return this._Ishundredpercentzoom;
            }

            set
            {
                if (this._Ishundredpercentzoom != value)
                {
                    this._Ishundredpercentzoom = value;
                    this.OnPropertyChanged("IsHundredPercentZoom");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether diagram can zoom upto one fifty percent or not.
        /// </summary>
        public bool IsOneFiftyPercentZoom
        {
            get
            {
                return this._Isonefiftypercentzoom;
            }

            set
            {
                if (this._Isonefiftypercentzoom != value)
                {
                    this._Isonefiftypercentzoom = value;
                    this.OnPropertyChanged("IsOneFiftyPercentZoom");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether zooming can happen based on page width or not.
        /// </summary>
        public bool IsPageWidthZoom
        {
            get
            {
                return this._ispagewidth;
            }

            set
            {
                if (this._ispagewidth != value)
                {
                    this._ispagewidth = value;
                    this.OnPropertyChanged("IsPageWidthZoom");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether zooming can happen on percentage basis or not.
        /// </summary>
        public bool IsPercentageZoom
        {
            get
            {
                return this._ispercentagezoom;
            }

            set
            {
                if (this._ispercentagezoom != value)
                {
                    this._ispercentagezoom = value;
                    this.OnPropertyChanged("IsPercentageZoom");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether diagram can zoom upto seventy five percent or not.
        /// </summary>
        public bool IsSeventyFivePercentZoom
        {
            get
            {
                return this._Isseventyfivepercentzoom;
            }

            set
            {
                if (this._Isseventyfivepercentzoom != value)
                {
                    this._Isseventyfivepercentzoom = value;
                    this.OnPropertyChanged("IsSeventyFivePercentZoom");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether diagram can zoom upto two hundred percent or not.
        /// </summary>
        public bool IsTwoHundredPercentZoom
        {
            get
            {
                return this._Istwohundredpercentzoom;
            }

            set
            {
                if (this._Istwohundredpercentzoom != value)
                {
                    this._Istwohundredpercentzoom = value;
                    this.OnPropertyChanged("IsTwoHundredPercentZoom");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether whole page can zoom or not.
        /// </summary>
        public bool IsWholePageZoom
        {
            get
            {
                return this._iswholepage;
            }

            set
            {
                if (this._iswholepage != value)
                {
                    this._iswholepage = value;
                    this.OnPropertyChanged("IsWholePageZoom");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the percentage text.
        /// </summary>
        public string PercentageText
        {
            get
            {
                return this._percentagetext;
            }

            set
            {
                if (this._percentagetext != value)
                {
                    this._percentagetext = value;
                    this.OnPropertyChanged("PercentageText");
                }
            }
        }

        /// <summary>
        /// Occurs whenever the property changes.
        /// </summary>
        /// <param name="name">
        /// The name specifies the name of the property.
        /// </param>
        private void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}