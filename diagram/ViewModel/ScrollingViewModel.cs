#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class ScrollingViewModel : DiagramViewModel
    {
        #region Fields

        private List<string> _Settings = new List<string>() { "Auto", "Scroll", "Drag" };
        private string _SelectedSetting = "Scroll";
        private List<string> _Limits = new List<string>() { "Infinity", "Diagram", "Limited" };
        private string _SelectedLimit = "Infinity";
        private double _Areax = 0;
        private double _Areay = 0;
        private double _Areawidth = 1500;
        private double _Areaheight = 1500;
        private double _BorderLeft = 40;
        private double _BorderRight = 40;
        private double _BorderTop = 40;
        private double _BorderBottom = 40;
        private bool _AreaEnabled = false;
        private bool _BorderEnabled = false;

        #endregion

        #region Constructor

        public ScrollingViewModel()
        {
            ScrollSettings = new ScrollSettings();

            SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.ShowLines,
            };

            PageSettings = new PageSettings()
            {
                PageHeight = 723,
                PageWidth = 1124,
                ShowPageBreaks = true,
                MultiplePage = true,
            };

            SelectedItems = new SelectorViewModel();

            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };

            SelectorChangedCommand = new DelegateCommand(OnSelectorChanged);
        }

        #endregion

        #region Properties

        public string SelectedSetting
        {
            get
            {
                return _SelectedSetting;
            }
            set
            {
                if (value != _SelectedSetting)
                {
                    _SelectedSetting = value;
                    OnPropertyChanged("SelectedSetting");
                    OnSelectedSettingsChanged(value);
                }
            }
        }

        public List<string> Settings
        {
            get
            {
                return _Settings;
            }
            set
            {
                if (value != _Settings)
                {
                    _Settings = value;
                    OnPropertyChanged("Settings");
                }
            }
        }

        public string SelectedLimit
        {
            get
            {
                return _SelectedLimit;
            }
            set
            {
                if (value != _SelectedLimit)
                {
                    _SelectedLimit = value;
                    OnPropertyChanged("SelectedLimit");
                    OnSelectedLimitChanged(value);
                }
            }
        }

        public List<string> Limits
        {
            get
            {
                return _Limits;
            }
            set
            {
                if (value != _Limits)
                {
                    _Limits = value;
                    OnPropertyChanged("Limits");
                }
            }
        }

        public double AreaX
        {
            get
            {
                return _Areax;
            }
            set
            {
                if (_Areax != value)
                {
                    _Areax = value;
                    OnPropertyChanged("AreaX");
                }
            }
        }

        public double AreaY
        {
            get
            {
                return _Areay;
            }
            set
            {
                if (_Areay != value)
                {
                    _Areay = value;
                    OnPropertyChanged("AreaY");
                }
            }
        }

        public double AreaWidth
        {
            get
            {
                return _Areawidth;
            }
            set
            {
                if (_Areawidth != value)
                {
                    _Areawidth = value;
                    OnPropertyChanged("AreaWidth");
                }
            }
        }

        public double AreaHeight
        {
            get
            {
                return _Areaheight;
            }
            set
            {
                if (_Areaheight != value)
                {
                    _Areaheight = value;
                    OnPropertyChanged("AreaHeight");
                }
            }
        }

        public double BorderLeft
        {
            get
            {
                return _BorderLeft;
            }
            set
            {
                if (_BorderLeft != value)
                {
                    _BorderLeft = value;
                    OnPropertyChanged("BorderLeft");
                }
            }
        }

        public double BorderRight
        {
            get
            {
                return _BorderRight;
            }
            set
            {
                if (_BorderRight != value)
                {
                    _BorderRight = value;
                    OnPropertyChanged("BorderRight");
                }
            }
        }

        public double BorderTop
        {
            get
            {
                return _BorderTop;
            }
            set
            {
                if (_BorderTop != value)
                {
                    _BorderTop = value;
                    OnPropertyChanged("BorderTop");
                }
            }
        }

        public double BorderBottom
        {
            get
            {
                return _BorderBottom;
            }
            set
            {
                if (_BorderBottom != value)
                {
                    _BorderBottom = value;
                    OnPropertyChanged("BorderBottom");
                }
            }
        }

        public bool AreaEnabled
        {
            get
            {
                return _AreaEnabled;
            }
            set
            {
                if (_AreaEnabled != value)
                {
                    _AreaEnabled = value;
                    OnPropertyChanged("AreaEnabled");
                }
            }
        }

        public bool BorderEnabled
        {
            get
            {
                return _BorderEnabled;
            }
            set
            {
                if (_BorderEnabled != value)
                {
                    _BorderEnabled = value;
                    OnPropertyChanged("BorderEnabled");
                }
            }
        }

        #endregion
        
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            
            if (name == "Areax" || name == "AreaY" || name == "AreaWidth" || name == "AreaHeight")
            {
                if (SelectedSetting == "Drag")
                {
                    ScrollSettings.EditableArea = new Rect(AreaX, AreaY, AreaWidth, AreaHeight);
                }
                else
                {
                    ScrollSettings.ScrollableArea = new Rect(AreaX, AreaY, AreaWidth, AreaHeight);
                }
            }
            else if (name == "BorderLeft" || name == "BorderTop" || name == "BorderRight" || name == "BorderBottom")
            {
                ScrollSettings.AutoScrollBorder = new Thickness(BorderLeft, BorderTop, BorderRight, BorderBottom);
            }
        }

        #region Helper Methods

        /// <summary>
        /// This method is used for execute scrollsettings changes.
        /// </summary>
        /// <param name="value"></param>
        private void OnSelectedSettingsChanged(string value)
        {
            if (value == "Auto")
            {
                BorderEnabled = true;
                ScrollSettings.AutoScrollLimit = ScrollLimit.Infinity;
                ScrollSettings.AutoScrollBorder = new Thickness(BorderLeft, BorderTop, BorderRight, BorderBottom);
            }
            else if (value == "Scroll")
            {
                BorderEnabled = false;
                AreaEnabled = false;
                ScrollSettings.ScrollLimit = ScrollLimit.Infinity;
            }
            else if (value == "Drag")
            {
                BorderEnabled = false;
                AreaEnabled = false;
                ScrollSettings.DragLimit = ScrollLimit.Infinity;
            }
            SelectedLimit = "Infinity";
        }

        /// <summary>
        /// This method is used to execute scroll settings changed.
        /// </summary>
        /// <param name="value"></param>
        private void OnSelectedLimitChanged(string value)
        {
            if (value == "Infinity")
            {
                AreaEnabled = false;
                if (SelectedSetting == "Auto")
                {
                    ScrollSettings.AutoScrollLimit = ScrollLimit.Infinity;
                }
                else if (SelectedSetting == "Scroll")
                {
                    ScrollSettings.ScrollLimit = ScrollLimit.Infinity;
                }
                if (SelectedSetting == "Drag")
                {
                    ScrollSettings.DragLimit = ScrollLimit.Infinity;
                }
            }
            else if (value == "Diagram")
            {
                AreaEnabled = false;
                if (SelectedSetting == "Auto")
                {
                    ScrollSettings.AutoScrollLimit = ScrollLimit.Diagram;
                }
                else if (SelectedSetting == "Scroll")
                {
                    ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
                }
                if (SelectedSetting == "Drag")
                {
                    ScrollSettings.DragLimit = ScrollLimit.Diagram;
                }
            }
            else if (value == "Limited")
            {
                AreaEnabled = true;
                if (SelectedSetting == "Auto")
                {
                    ScrollSettings.AutoScrollLimit = ScrollLimit.Limited;
                    ScrollSettings.ScrollableArea = new Rect(AreaX, AreaY, AreaWidth, AreaHeight);
                    ScrollSettings.AutoScrollBorder = new Thickness(BorderLeft, BorderTop, BorderRight, BorderBottom);
                }
                else if (SelectedSetting == "Scroll")
                {
                    ScrollSettings.ScrollLimit = ScrollLimit.Limited;
                    ScrollSettings.ScrollableArea = new Rect(AreaX, AreaY, AreaWidth, AreaHeight);
                }
                if (SelectedSetting == "Drag")
                {
                    ScrollSettings.DragLimit = ScrollLimit.Limited;
                    ScrollSettings.EditableArea = new Rect(AreaX, AreaY, AreaWidth, AreaHeight);
                }
            }
        }

        private void OnSelectorChanged(object parameter)
        {
            (parameter as SelectorChangedEventArgs).BlockCursor = Cursors.No;
            (parameter as SelectorChangedEventArgs).Block = true;
        }

        #endregion

    }
}
