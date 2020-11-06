#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    /// <summary>
    /// Represent the Gallery style.
    /// </summary>
    public class GalleryStyle : NotificationObject
    {
        private List<DiagramItemStyle> _mStyles;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public new event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Gets or sets the list of diagram item style.
        /// </summary>
        public List<DiagramItemStyle> Styles
        {
            get { return _mStyles; }
            set
            {
                if (_mStyles != value)
                {
                    _mStyles = value;
                    OnPropertyChanged("Styles");
                }
            }
        }

        private DiagramItemStyle _mVariant1;
        /// <summary>
        /// Gets or sets the Variant1 style.
        /// </summary>
        public DiagramItemStyle Variant1
        {
            get { return _mVariant1; }
            set
            {
                if (_mVariant1 != value)
                {
                    _mVariant1 = value;
                    OnPropertyChanged("Variant1");
                }
            }
        }

        private DiagramItemStyle _mVariant2;
        /// <summary>
        /// Gets or sets the Variant2 style.
        /// </summary>
        public DiagramItemStyle Variant2
        {
            get { return _mVariant2; }
            set
            {
                if (_mVariant2 != value)
                {
                    _mVariant2 = value;
                    OnPropertyChanged("Variant2");
                }
            }
        }

        private DiagramItemStyle _mVariant3;
        /// <summary>
        /// Gets or sets the Variant3 style.
        /// </summary>
        public DiagramItemStyle Variant3
        {
            get { return _mVariant3; }
            set
            {
                if (_mVariant3 != value)
                {
                    _mVariant3 = value;
                    OnPropertyChanged("Variant3");
                }
            }
        }

        private DiagramItemStyle _mVariant4;
        /// <summary>
        /// Gets or sets the Variant4 style.
        /// </summary>
        public DiagramItemStyle Variant4
        {
            get { return _mVariant4; }
            set
            {
                if (_mVariant4 != value)
                {
                    _mVariant4 = value;
                    OnPropertyChanged("Variant4");
                }
            }
        }

        private DiagramItemStyle _mConnectorVariant;
        /// <summary>
        /// Gets or sets the ConnectorVariant style.
        /// </summary>
        public DiagramItemStyle ConnectorVariant
        {
            get { return _mConnectorVariant; }
            set
            {
                if (_mConnectorVariant != value)
                {
                    _mConnectorVariant = value;
                    OnPropertyChanged("ConnectorVariant");
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the GalleryStyle class.
        /// </summary>
        public GalleryStyle()
        {

        }
        /// <summary>
        /// This method is called by the Set accessor of each property.
        /// The CallerMemberName attribute that is applied to the optional propertyName
        /// </summary>
        /// <param name="name">parameter causes the property name of the caller to be substituted as an argument.</param>
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
