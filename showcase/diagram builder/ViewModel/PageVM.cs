// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the apperance of the Page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System;
    using System.Runtime.Serialization;
    using System.Windows;
    using System.Windows.Media;

    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Represents the apperance of the Page.
    /// </summary>
    [DataContract]
    public class PageVM : PageSettings, IPageVM
    {
        /// <summary>
        ///     The _m selected unit.
        /// </summary>
        private LengthUnits _mSelectedUnit = LengthUnits.Pixels;

        /// <summary>
        ///     The _m snap to grid.
        /// </summary>
        private bool _mSnapToGrid = true;

        /// <summary>
        ///     The _m snap to object.
        /// </summary>
        private bool _mSnapToObject = true;

        /// <summary>
        ///     Represents the diagram viewmodel.
        /// </summary>
        private DiagramVM diagram;

        /// <summary>
        ///     The _m grid lines.
        /// </summary>
        private bool gridlines = true;

        /// <summary>
        ///     The _m ruler.
        /// </summary>
        private bool ruler = true;

        /// <summary>
        ///     The _m selected format.
        /// </summary>
        private PageSize selectedformat = PageSize.Custom;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PageVM" /> class.
        /// </summary>
        public PageVM()
        {
            // Unit = _unit;
            this.Scale = 1;
            this.SelectedFormat = PageSize.A4;

            //this.OffPageMinMargin = new Thickness(100);
            this.PageOrientation = PageOrientation.Landscape;
            this.InitDiagram();
#if SyncfusionFramework4_5_1
            SyncfusionFramework4_5_1 = Visibility.Visible;
#else
            this.SyncfusionFramework4_5_1 = Visibility.Visible;
#endif
        }

        /// <summary>
        ///     Gets or sets a value indicating whether grid lines can be visible or not.
        /// </summary>
        [DataMember]
        public bool GridLines
        {
            get
            {
                return this.gridlines;
            }

            set
            {
                if (this.gridlines != value)
                {
                    this.gridlines = value;
                    this.OnPropertyChanged(PageConstants.GridLines);
                }
            }
        }

        // private LengthUnit _unit = new LengthUnit() { Unit = LengthUnits.Inches };
        /// <summary>
        ///     Gets or sets the horizontal offset value.
        /// </summary>
        [DataMember]
        public double HOffset { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether ruler can be visible or not.
        /// </summary>
        [DataMember]
        public bool Ruler
        {
            get
            {
                return this.ruler;
            }

            set
            {
                if (this.ruler != value)
                {
                    this.ruler = value;
                    this.OnPropertyChanged(PageConstants.Ruler);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the scale value.
        /// </summary>
        [DataMember]
        public double Scale { get; set; }

        /// <summary>
        ///     Gets or sets the selected pagesize format.
        /// </summary>
        [DataMember]
        public PageSize SelectedFormat
        {
            get
            {
                return this.selectedformat;
            }

            set
            {
                if (this.selectedformat != value)
                {
                    this.selectedformat = value;
                    this.OnPropertyChanged(PageConstants.SelectedFormat);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the selected unit.
        /// </summary>
        [DataMember]
        public LengthUnits SelectedUnit
        {
            get
            {
                return this._mSelectedUnit;
            }

            set
            {
                if (this._mSelectedUnit != value)
                {
                    if (this.Unit == null)
                    {
                        this.Unit = new LengthUnit { Unit = value };
                    }

                    this._mSelectedUnit = value;
                    this.OnPropertyChanged(PageConstants.SelectedUnit);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether snap to grid can be enable or not.
        /// </summary>
        [DataMember]
        public bool SnapToGrid
        {
            get
            {
                return this._mSnapToGrid;
            }

            set
            {
                if (this._mSnapToGrid != value)
                {
                    this._mSnapToGrid = value;
                    this.OnPropertyChanged(PageConstants.SnapToGrid);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether snap to object can be enable or not.
        /// </summary>
        [DataMember]
        public bool SnapToObject
        {
            get
            {
                return this._mSnapToObject;
            }

            set
            {
                if (this._mSnapToObject != value)
                {
                    this._mSnapToObject = value;
                    this.OnPropertyChanged(PageConstants.SnapToObject);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the syncfusion framework 4_5_1.
        /// </summary>
        public Visibility SyncfusionFramework4_5_1 { get; set; }

        /// <summary>
        ///     Gets or sets the vertical offset value.
        /// </summary>
        [DataMember]
        public double VOffset { get; set; }

        /// <summary>
        ///     Represents the pagesettings of the diagram.
        /// </summary>
        public void InitDiagram()
        {
            this.PrintMargin = new Thickness(24);
            this.PageBorderThickness = new Thickness(1);
            this.PageBackground = new SolidColorBrush(Colors.White);
            this.ShowPageBreaks = true;
            if (this.Unit == null)
            {
                this.Unit = new LengthUnit { Unit = this.SelectedUnit };
            }
        }

        /// <summary>
        /// Represents the snapsettings of the diagram.
        /// </summary>
        /// <param name="diagram">
        /// The diagram.
        /// </param>
        public void InitDiagram(DiagramVM diagram)
        {
            this.diagram = diagram;
            this.SnapToGrid = (this.diagram.SnapSettings.SnapConstraints & SnapConstraints.SnapToLines)
                              == SnapConstraints.SnapToLines;

            this.SnapToObject = this.diagram.SnapSettings.SnapToObject == Syncfusion.UI.Xaml.Diagram.SnapToObject.All;
            this.OnPropertyChanged(PageConstants.SelectedFormat);
        }

        /// <summary>
        /// Invoked whenever the effective value of any dependency property on this FrameworkElement has been updated.
        ///     The specific dependency property that changed is reported in the arguments parameter. Overrides
        ///     OnPropertyChanged(name).
        /// </summary>
        /// <param name="name">
        /// Represents the name of the property.
        /// </param>
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            if (this.diagram == null)
            {
                return;
            }

            switch (name)
            {
                case PageConstants.GridLines:
                    this.OnGridLinesChanged();
                    break;
                case PageConstants.Ruler:
                    this.OnRulerChanged();
                    break;
                case PageConstants.SelectedFormat:
                    this.OnSelectedFormatChanged();
                    break;
                case PageConstants.SelectedUnit:
                    this.OnSelectedUnitChanged();
                    break;
                case PageConstants.SnapToGrid:
                    this.OnSnapToGridChanged();
                    break;
                case PageConstants.SnapToObject:
                    this.OnSnapToObjectChanged();
                    break;
                case PageConstants.PageWidth:
                case PageConstants.PageHeight:
                    this.OnPageSizeChanged();
                    break;
            }
        }

        /// <summary>
        /// Represents the value converter.
        /// </summary>
        /// <param name="value">
        /// The value property that changed is reported in the arguments parameter.
        /// </param>
        /// <param name="from">
        /// The from property that changed is reported in the arguments parameter
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double Convert(double value, LengthUnits from)
        {
            LengthUnit unit = this.Unit as LengthUnit;
            return unit.Convert(value, from, this.SelectedUnit);
        }

        /// <summary>
        /// The get page size.
        /// </summary>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see cref="Size?"/>.
        /// </returns>
        private Size? GetPageSize(PageSize pageSize)
        {
            switch (pageSize)
            {
                case PageSize.A0:
                    return this.GetPageSize(1189, 841, LengthUnits.Millimeters);
                case PageSize.A1:
                    return this.GetPageSize(841, 594, LengthUnits.Millimeters);
                case PageSize.A2:
                    return this.GetPageSize(594, 420, LengthUnits.Millimeters);
                case PageSize.A3:
                    return this.GetPageSize(420, 297, LengthUnits.Millimeters);
                case PageSize.A4:
                    return this.GetPageSize(297, 210, LengthUnits.Millimeters);
                case PageSize.A5:
                    return this.GetPageSize(210, 148, LengthUnits.Millimeters);
                case PageSize.Folio:
                    return this.GetPageSize(13, 8.5, LengthUnits.Inches);
                case PageSize.Ledger:
                    return this.GetPageSize(17, 11, LengthUnits.Inches);
                case PageSize.Legal:
                    return this.GetPageSize(14, 8.5, LengthUnits.Inches);
                case PageSize.Letter:
                    return this.GetPageSize(11, 8.5, LengthUnits.Inches);
            }

            return null;
        }

        /// <summary>
        /// The get page size.
        /// </summary>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="lengthUnits">
        /// The length units.
        /// </param>
        /// <returns>
        /// The <see cref="Size"/>.
        /// </returns>
        private Size GetPageSize(double width, double height, LengthUnits lengthUnits)
        {
            if (this.PageOrientation == PageOrientation.Landscape)
            {
                return new Size(this.Convert(width, lengthUnits), this.Convert(height, lengthUnits));
            }

            return new Size(this.Convert(height, lengthUnits), this.Convert(width, lengthUnits));
        }

        /// <summary>
        ///     The on grid lines changed.
        /// </summary>
        private void OnGridLinesChanged()
        {
            if (this.GridLines)
            {
                this.diagram.SnapSettings.SnapConstraints |= SnapConstraints.ShowLines;
            }
            else
            {
                this.diagram.SnapSettings.SnapConstraints &= ~SnapConstraints.ShowLines;
            }
        }

        /// <summary>
        ///     The on page size changed.
        /// </summary>
        private void OnPageSizeChanged()
        {
            foreach (object size in Enum.GetValues(typeof(PageSize)))
            {
                Size? checkSize = this.GetPageSize((PageSize)size);
                if (checkSize.HasValue)
                {
                    if (this.PageWidth == checkSize.Value.Width && this.PageHeight == checkSize.Value.Height
                        || this.PageHeight == checkSize.Value.Width && this.PageWidth == checkSize.Value.Height)
                    {
                        this.SelectedFormat = (PageSize)size;
                        break;
                    }
                }
                else
                {
                    this.SelectedFormat = PageSize.Custom;
                }
            }
        }

        /// <summary>
        ///     The on ruler changed.
        /// </summary>
        private void OnRulerChanged()
        {
            if (this.Ruler)
            {
                this.diagram.HorizontalRuler.Visibility = Visibility.Visible;
                this.diagram.VerticalRuler.Visibility = Visibility.Visible;
            }
            else
            {
                this.diagram.HorizontalRuler.Visibility = Visibility.Collapsed;
                this.diagram.VerticalRuler.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        ///     The on selected format changed.
        /// </summary>
        private void OnSelectedFormatChanged()
        {
            this.UpdatePageSize();
        }

        /// <summary>
        ///     The on selected unit changed.
        /// </summary>
        private void OnSelectedUnitChanged()
        {
            (this.Unit as LengthUnit).Unit = this.SelectedUnit;
            this.UpdatePageSize();
        }

        /// <summary>
        ///     The on snap to grid changed.
        /// </summary>
        private void OnSnapToGridChanged()
        {
            if (this.SnapToGrid)
            {
                this.diagram.SnapSettings.SnapConstraints |= SnapConstraints.SnapToLines;
            }
            else
            {
                this.diagram.SnapSettings.SnapConstraints &= ~SnapConstraints.SnapToLines;
            }
        }

        /// <summary>
        ///     The on snap to object changed.
        /// </summary>
        private void OnSnapToObjectChanged()
        {
            if (this.SnapToObject)
            {
                this.diagram.SnapSettings.SnapToObject = Syncfusion.UI.Xaml.Diagram.SnapToObject.All;
            }
            else
            {
                this.diagram.SnapSettings.SnapToObject = Syncfusion.UI.Xaml.Diagram.SnapToObject.None;
            }
        }

        /// <summary>
        ///     The update page size.
        /// </summary>
        private void UpdatePageSize()
        {
            Size? newSize = this.GetPageSize(this.SelectedFormat);
            if (newSize.HasValue)
            {
                this.PageWidth = newSize.Value.Width;
                this.PageHeight = newSize.Value.Height;
            }
        }
    }
}