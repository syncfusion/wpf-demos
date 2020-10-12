#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class CustomPort : NodePortViewModel
    {
        #region Fields

        private Brush _fillcolor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1916C1"));

        private Brush _strokecolor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

        private string _strokethickness = "1";

        private string _porttype;

        private string _Sizechanged = "10";

        private string _shapename = "Circle";

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Strokethickness of CustomPort
        /// </summary>
        public string Strokethickness
        {
            get
            {
                return _strokethickness;
            }
            set
            {
                if (_strokethickness != value)
                {
                    _strokethickness = value;
                    OnPropertyChanged("Strokethickness");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Size of CustomPort
        /// </summary>
        public string Sizechanged
        {
            get
            {
                return _Sizechanged;
            }
            set
            {
                if (_Sizechanged != value)
                {
                    _Sizechanged = value;
                    OnPropertyChanged("Sizechanged");
                }
            }
        }

        /// <summary>
        /// Gets or sets the shape of CustomPort
        /// </summary>
        public string ShapeName
        {
            get
            {
                return _shapename;
            }
            set
            {
                if (_shapename != value)
                {
                    _shapename = value;
                    OnPropertyChanged("ShapeName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Strokecolor of CustomPort
        /// </summary>
        public Brush Strokecolor
        {
            get
            {
                return _strokecolor;
            }
            set
            {
                if (_strokecolor != value)
                {
                    _strokecolor = value;
                    OnPropertyChanged("Strokecolor");
                }
            }
        }

        /// <summary>
        /// Gets or sets Fillcolor of CustomPort
        /// </summary>
        public Brush Fillcolor
        {
            get
            {
                return _fillcolor;
            }
            set
            {
                if (_fillcolor != value)
                {
                    _fillcolor = value;
                    OnPropertyChanged("Fillcolor");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Porttype of CustomPort
        /// </summary>
        public string Porttype
        {
            get
            {
                return _porttype;
            }
            set
            {
                if (_porttype != value)
                {
                    _porttype = value;
                    OnPropertyChanged("PortType");
                }
            }
        }

        #endregion
    }
}
