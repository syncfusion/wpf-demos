#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Diagram;
using System.Runtime.Serialization;
using System.ComponentModel;
namespace DiagramBuilder.ViewModel
{
    [DataContract]
    public class PageVM :PageSettings, IPageVM
    {
        //private LengthUnit _unit = new LengthUnit() { Unit = LengthUnits.Inches };
        public event PropertyChangedEventHandler PropertyChanged;

        [DataMember]
        public double HOffset
        {
            get;
            set;
        }
        [DataMember]
        public double VOffset { get; set; }
        [DataMember]
        public double Scale { get; set; }

        public PageVM()
        {
            //Unit = _unit;
            Scale = 1;
            SelectedFormat = PageSize.A4;
           
            OffPageMinMargin = new Thickness(100);
            PageOrientation = PageOrientation.Landscape;
            InitDiagram();
#if SyncfusionFramework4_5_1
            SyncfusionFramework4_5_1 = Visibility.Visible; 
#else
            SyncfusionFramework4_5_1 = Visibility.Visible;
#endif
        }

        public void InitDiagram()
        {
            //switch (Application.Current.RequestedTheme)
            //{
            //    case ApplicationTheme.Dark:
            //        PageBackground = new SolidColorBrush(new Color() { A = 255, R = 26, G = 26, B = 26 });
            //        PageBorderBrush = new SolidColorBrush(new Color() { A = 255, R = 80, G = 81, B = 81 });
            //        break;
            //    case ApplicationTheme.Light:
            //        PageBackground = new SolidColorBrush(new Color() { A = 255, R = 255, G = 255, B = 255 });
            //        PageBorderBrush = new SolidColorBrush(new Color() { A = 255, R = 106, G = 107, B = 107 });
            //        break;
            //}
            PrintMargin = new Thickness(24);
            PageBorderThickness = new Thickness(1);
            PageBackground = new SolidColorBrush(Colors.White);
            ShowPageBreaks = true;
            if (Unit == null)
            {
                Unit = new LengthUnit { Unit = SelectedUnit }; 
            }            
        }

        public void InitDiagram(DiagramVM diagram)
        {
            _mDiagram = diagram;
            SnapToGrid = (_mDiagram.SnapSettings.SnapConstraints &
                         SnapConstraints.SnapToLines) == SnapConstraints.SnapToLines;

            SnapToObject = _mDiagram.SnapSettings.SnapToObject == Syncfusion.UI.Xaml.Diagram.SnapToObject.All;
            OnPropertyChanged(PageConstants.SelectedFormat);
        }

        public Visibility SyncfusionFramework4_5_1 { get; set; }

        private DiagramVM _mDiagram = null;

        private PageSize _mSelectedFormat = PageSize.Custom;
        private LengthUnits _mSelectedUnit =  LengthUnits.Pixels;
        private bool _mGridLines = true;
        private bool _mSnapToGrid = true;
        private bool _mSnapToObject = true;
        private bool _mRuler = true;

        [DataMember]
        public PageSize SelectedFormat
        {
            get
            {
                return _mSelectedFormat;
            }
            set
            {
                if (_mSelectedFormat != value)
                {
                    _mSelectedFormat = value;
                    OnPropertyChanged(PageConstants.SelectedFormat);
                }
            }
        }

        [DataMember]
        public LengthUnits SelectedUnit
        {
            get
            {
                return _mSelectedUnit;
            }
            set
            {
                if (_mSelectedUnit != value)
                {
                    if (Unit == null)
                    {
                        Unit = new LengthUnit() { Unit = value };
                    }
                    _mSelectedUnit = value;
                    OnPropertyChanged(PageConstants.SelectedUnit);
                }
            }
        }

        [DataMember]
        public bool GridLines
        {
            get
            {
                return _mGridLines;
            }
            set
            {
                if (_mGridLines != value)
                {
                    _mGridLines = value;
                    OnPropertyChanged(PageConstants.GridLines);
                }
            }
        }

        [DataMember]
        public bool SnapToGrid
        {
            get
            {
                return _mSnapToGrid;
            }
            set
            {
                if (_mSnapToGrid != value)
                {
                    _mSnapToGrid = value;
                    OnPropertyChanged(PageConstants.SnapToGrid);
                }
            }
        }

        [DataMember]
        public bool SnapToObject
        {
            get
            {
                return _mSnapToObject;
            }
            set
            {
                if (_mSnapToObject != value)
                {
                    _mSnapToObject = value;
                    OnPropertyChanged(PageConstants.SnapToObject);
                }
            }
        }

        [DataMember]
        public bool Ruler
        {
            get
            {
                return _mRuler;
            }
            set
            {
                if (_mRuler != value)
                {
                    _mRuler = value;
                    OnPropertyChanged(PageConstants.Ruler);
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }

            if(_mDiagram == null)
            {
                return;
            }

            switch (name)
            {
                case PageConstants.GridLines:
                    OnGridLinesChanged();
                    break;
                case PageConstants.Ruler:
                    OnRulerChanged();
                    break;
                case PageConstants.SelectedFormat:
                    OnSelectedFormatChanged();
                    break;
                case PageConstants.SelectedUnit:
                    OnSelectedUnitChanged();
                    break;
                case PageConstants.SnapToGrid:
                    OnSnapToGridChanged();
                    break;
                case PageConstants.SnapToObject:
                    OnSnapToObjectChanged();
                    break;
                case PageConstants.PageWidth:
                case PageConstants.PageHeight:
                    OnPageSizeChanged();
                    break;
            }
        }

        private void OnSnapToObjectChanged()
        {
            if (SnapToObject)
            {
                _mDiagram.SnapSettings.SnapToObject = Syncfusion.UI.Xaml.Diagram.SnapToObject.All;
            }
            else
            {
                _mDiagram.SnapSettings.SnapToObject = Syncfusion.UI.Xaml.Diagram.SnapToObject.None;
            }
        }

        private void OnSnapToGridChanged()
        {
            if (SnapToGrid)
            {
                _mDiagram.SnapSettings.SnapConstraints |= SnapConstraints.SnapToLines;
            }
            else
            {
                _mDiagram.SnapSettings.SnapConstraints &= ~SnapConstraints.SnapToLines;
            }
        }

        private void OnSelectedUnitChanged()
        {
            (this.Unit as LengthUnit).Unit = SelectedUnit;
            UpdatePageSize();
        }

        private void OnSelectedFormatChanged()
        {
            UpdatePageSize();
        }

        private void OnRulerChanged()
        {
            if (Ruler)
            {
                _mDiagram.HorizontalRuler.Visibility = Visibility.Visible;
                _mDiagram.VerticalRuler.Visibility = Visibility.Visible;
            }
            else
            {
                _mDiagram.HorizontalRuler.Visibility = Visibility.Collapsed;
                _mDiagram.VerticalRuler.Visibility = Visibility.Collapsed;
            }
        }
        
        private void OnGridLinesChanged()
        {
            if (GridLines)
            {
                _mDiagram.SnapSettings.SnapConstraints |= SnapConstraints.ShowLines;
            }
            else
            {
                _mDiagram.SnapSettings.SnapConstraints &= ~SnapConstraints.ShowLines;                
            }
        }

        private void OnPageSizeChanged()
        {
            foreach (var size in Enum.GetValues(typeof(ViewModel.PageSize)))
            {
                Size? checkSize = GetPageSize((ViewModel.PageSize) size);
                if (checkSize.HasValue)
                {
                    if ((PageWidth == checkSize.Value.Width && PageHeight == checkSize.Value.Height) ||
                        (PageHeight == checkSize.Value.Width && PageWidth == checkSize.Value.Height))
                    {
                        SelectedFormat = (ViewModel.PageSize) size;
                        break;
                    }
                    else
                    {
                    }
                }
                else
                {
                    SelectedFormat = ViewModel.PageSize.Custom;
                }
            }
        }

        private void UpdatePageSize()
        {
            Size? newSize = GetPageSize(SelectedFormat);
            if (newSize.HasValue)
            {
                PageWidth = newSize.Value.Width;
                PageHeight = newSize.Value.Height;
            }
            else
            {
                
            }
        }

        private Size? GetPageSize(ViewModel.PageSize pageSize)
        {
            switch (pageSize)
            {
                case ViewModel.PageSize.A0:
                    return GetPageSize(1189, 841, LengthUnits.Millimeters);
                case ViewModel.PageSize.A1:
                    return GetPageSize(841, 594, LengthUnits.Millimeters);
                case ViewModel.PageSize.A2:
                    return GetPageSize(594, 420, LengthUnits.Millimeters);
                case ViewModel.PageSize.A3:
                    return GetPageSize(420, 297, LengthUnits.Millimeters);
                case ViewModel.PageSize.A4:
                    return GetPageSize(297, 210, LengthUnits.Millimeters);
                case ViewModel.PageSize.A5:
                    return GetPageSize(210, 148, LengthUnits.Millimeters);
                case ViewModel.PageSize.Folio:
                    return GetPageSize(13, 8.5, LengthUnits.Inches);
                case ViewModel.PageSize.Ledger:
                    return GetPageSize(17, 11, LengthUnits.Inches);
                case ViewModel.PageSize.Legal:
                    return GetPageSize(14, 8.5, LengthUnits.Inches);
                case ViewModel.PageSize.Letter:
                    return GetPageSize(11, 8.5, LengthUnits.Inches);
            }
            return null;
        }

        private Size GetPageSize(
            double width, double height, 
            LengthUnits lengthUnits)
        {
            if (PageOrientation == PageOrientation.Landscape)
            {
                return new Size(Convert(width, lengthUnits), Convert(height, lengthUnits));
            }
            else
            {
                return new Size(Convert(height, lengthUnits), Convert(width, lengthUnits));
            }
        }

        private double Convert(double value, LengthUnits from)
        {
            LengthUnit unit = Unit as LengthUnit;
            return unit.Convert(value, from, SelectedUnit);
        }
    }

    public enum PageSize
    {
        Letter,
        Folio,
        Legal,
        Ledger,

        A5,
        A4,
        A3,
        A2,
        A1,
        A0,

        Custom
    }

    public interface IPageVM 
    {
        //List<PageSize> Format { get; set; }
        PageSize SelectedFormat { get; set; }
        //List<PageOrientation> Orientations { get; set; }
        //List<LengthUnits> Units { get; set; }
        LengthUnits SelectedUnit { get; set; }

        bool GridLines { get; set; }
        bool SnapToGrid { get; set; }
        bool SnapToObject { get; set; }
        bool Ruler { get; set; }
    }

    public static class PageConstants
    {
        public const string PageWidth = "PageWidth";
        public const string PageHeight = "PageHeight";
        public const string MultiplePage = "MultiplePage";
        public const string OffPageMinMargin = "OffPageMinMargin";
        public const string OffPageMaxMargin = "OffPageMaxMargin";
        public const string PageOrientation = "PageOrientation";
        public const string PageBackground = "PageBackground";
        public const string PageBorderBrush = "PageBorderBrush";
        public const string PageBorderThickness = "PageBorderThickness";
        public const string Unit = "Unit";
        public const string ShowPageBreaks = "ShowPageBreaks";
        public const string PrintMargin = "PrintMargin";
        public const string ScrollLimit = "ScrollLimit";
        public const string AutoScrollBorder = "AutoScrollBorder";
        public const string ScrollableArea = "ScrollableArea";
        public const string MinimumScrollableArea = "MinimumScrollableArea";
        public const string MaximumScrollableArea = "MaximumScrollableArea";

        public const string Format = "Format";
        public const string SelectedFormat = "SelectedFormat";
        public const string Orientations = "Orientations";
        public const string Units = "Units";
        public const string SelectedUnit = "SelectedUnit";

        public const string GridLines = "GridLines";
        public const string SnapToGrid = "SnapToGrid";
        public const string SnapToObject = "SnapToObject";
        public const string Ruler = "Ruler";
    }
}
