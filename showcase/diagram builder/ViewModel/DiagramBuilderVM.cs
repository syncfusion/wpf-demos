// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramBuilderVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the viewmodel class for diagram.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Xml;

    using Brainstorming.ViewModel;

    using DiagramBuilder.Model;
    using DiagramBuilder.Utility;
    using DiagramBuilder.View;

    using FlowChart.ViewModel;

    using Microsoft.Win32;
    using OrganizationChart.ViewModel;
    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.UI.Xaml.Diagram.Theming;
    using Syncfusion.Windows.Tools.Controls;

    using Path = System.Windows.Shapes.Path;

    /// <summary>
    ///     Represents the viewmodel class for diagram.
    /// </summary>
    public class DiagramBuilderVM : DiagramElementViewModel, IDiagramBuilderVM
    {
        /// <summary>
        ///     The _m fonts.
        /// </summary>
        private static List<FontFamily> _mFonts = new List<FontFamily>
                                                      {
                                                          new FontFamily("Segoe UI"),
                                                          new FontFamily("Calibri"),
                                                          new FontFamily("Arial"),
                                                          new FontFamily("Comic Sans MS"),
                                                          new FontFamily("Georgia"),
                                                          new FontFamily("Times New Roman")
                                                      };

        /// <summary>
        ///     The _m caps.
        /// </summary>
        private List<Arrows> _mCaps = new List<Arrows>
                                          {
                                              new Arrows
                                                  {
                                                      LineData = "M0,0 z",
                                                      HorizontalAlignment = "Left",
                                                      Angle = 180,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData =
                                                          "M0.511,0L5.099,4.734L0.511,9.468L0,8.941L4.077,4.734L0,0.527z",
                                                      HorizontalAlignment = "Left",
                                                      Issourcecap = true,
                                                      Angle = 180,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData =
                                                          "M0.511,0L5.099,4.734L0.511,9.468L0,8.941L4.077,4.734L0,0.527z",
                                                      HorizontalAlignment = "Right",
                                                      Istargetcap = true,
                                                      Angle = 0,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData =
                                                          "M0.511,0L5.099,4.734L0.511,9.468L0,8.941L4.077,4.734L0,0.527z",
                                                      HorizontalAlignment = "Left",
                                                      Isbothcap = true,
                                                      Angle = 180,
                                                      IsCap = true
                                                  },
                                              new Arrows
                                                  {
                                                      LineData = "M0,0L7.583,3.792L0,7.583z",
                                                      HorizontalAlignment = "Left",
                                                      Angle = 180,
                                                      Issourcecap = true,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData = "M0,0L7.583,3.792L0,7.583z",
                                                      HorizontalAlignment = "Right",
                                                      Angle = 0,
                                                      Istargetcap = true,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData = "M0,0L7.583,3.792L0,7.583z",
                                                      HorizontalAlignment = "Left",
                                                      Angle = 180,
                                                      Isbothcap = true,
                                                      IsCap = true
                                                  },
                                              new Arrows
                                                  {
                                                      LineData = "M4.333,0L8.667,4.333L4.333,8.666L0,4.333z",
                                                      HorizontalAlignment = "Left",
                                                      Issourcecap = true,
                                                      Angle = 180,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData = "M4.333,0L8.667,4.333L4.333,8.666L0,4.333z",
                                                      HorizontalAlignment = "Right",
                                                      Istargetcap = true,
                                                      Angle = 0,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData = "M4.333,0L8.667,4.333L4.333,8.666L0,4.333z",
                                                      HorizontalAlignment = "Left",
                                                      Isbothcap = true,
                                                      Angle = 180,
                                                      IsCap = true
                                                  },
                                              new Arrows
                                                  {
                                                      LineData =
                                                          "M3.25847,5.37642e-006C3.80781,0.00100555 4.36433,0.141591 4.87424,0.436245C6.42923,1.33324 6.96123,3.32022 6.06423,4.87521C5.75589,5.4094 5.31863,5.82282 4.8144,6.09894C3.85177,6.62609 2.64505,6.65285 1.62524,6.0642C0.0712487,5.16721 -0.461751,3.17923 0.436248,1.62524C0.534357,1.45527 0.645505,1.29752 0.7677,1.15252L0.779131,1.13929L0.82074,1.09115L0.847908,1.06127L0.875099,1.03136L0.917886,0.986597L0.930739,0.973151C1.54972,0.341551 2.39522,-0.00156644 3.25847,5.37642e-006z",
                                                      HorizontalAlignment = "Left",
                                                      Issourcecap = true,
                                                      Angle = 180,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData =
                                                          "M3.25847,5.37642e-006C3.80781,0.00100555 4.36433,0.141591 4.87424,0.436245C6.42923,1.33324 6.96123,3.32022 6.06423,4.87521C5.75589,5.4094 5.31863,5.82282 4.8144,6.09894C3.85177,6.62609 2.64505,6.65285 1.62524,6.0642C0.0712487,5.16721 -0.461751,3.17923 0.436248,1.62524C0.534357,1.45527 0.645505,1.29752 0.7677,1.15252L0.779131,1.13929L0.82074,1.09115L0.847908,1.06127L0.875099,1.03136L0.917886,0.986597L0.930739,0.973151C1.54972,0.341551 2.39522,-0.00156644 3.25847,5.37642e-006z",
                                                      HorizontalAlignment = "Right",
                                                      Istargetcap = true,
                                                      Angle = 0,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData =
                                                          "M3.25847,5.37642e-006C3.80781,0.00100555 4.36433,0.141591 4.87424,0.436245C6.42923,1.33324 6.96123,3.32022 6.06423,4.87521C5.75589,5.4094 5.31863,5.82282 4.8144,6.09894C3.85177,6.62609 2.64505,6.65285 1.62524,6.0642C0.0712487,5.16721 -0.461751,3.17923 0.436248,1.62524C0.534357,1.45527 0.645505,1.29752 0.7677,1.15252L0.779131,1.13929L0.82074,1.09115L0.847908,1.06127L0.875099,1.03136L0.917886,0.986597L0.930739,0.973151C1.54972,0.341551 2.39522,-0.00156644 3.25847,5.37642e-006z",
                                                      HorizontalAlignment = "Left",
                                                      Isbothcap = true,
                                                      Angle = 180,
                                                      IsCap = true
                                                  },
                                              new Arrows
                                                  {
                                                      LineData = "M0,0L9.75,3.983L1.74344e-006,8.125L3.837,4.063z",
                                                      HorizontalAlignment = "Left",
                                                      Issourcecap = true,
                                                      Angle = 180,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData = "M0,0L9.75,3.983L1.74344e-006,8.125L3.837,4.063z",
                                                      HorizontalAlignment = "Right",
                                                      Istargetcap = true,
                                                      Angle = 0,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData = "M0,0L9.75,3.983L1.74344e-006,8.125L3.837,4.063z",
                                                      HorizontalAlignment = "Left",
                                                      Isbothcap = true,
                                                      Angle = 180,
                                                      IsCap = true
                                                  },
                                              new Arrows
                                                  {
                                                      LineData =
                                                          "M0.365001,0L4.0625,3.69703L7.76,1.21072e-006L8.125,0.365999L4.42826,4.06274L8.125,7.759L7.759,8.125L4.0625,4.4285L0.365999,8.125L0,7.759L3.69674,4.06274L0,0.365999z",
                                                      HorizontalAlignment = "Left",
                                                      Issourcecap = true,
                                                      Angle = 180,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData =
                                                          "M0.365001,0L4.0625,3.69703L7.76,1.21072e-006L8.125,0.365999L4.42826,4.06274L8.125,7.759L7.759,8.125L4.0625,4.4285L0.365999,8.125L0,7.759L3.69674,4.06274L0,0.365999z",
                                                      HorizontalAlignment = "Right",
                                                      Istargetcap = true,
                                                      Angle = 0,
                                                      IsCap = false
                                                  },
                                              new Arrows
                                                  {
                                                      LineData =
                                                          "M0.365001,0L4.0625,3.69703L7.76,1.21072e-006L8.125,0.365999L4.42826,4.06274L8.125,7.759L7.759,8.125L4.0625,4.4285L0.365999,8.125L0,7.759L3.69674,4.06274L0,0.365999z",
                                                      HorizontalAlignment = "Left",
                                                      Isbothcap = true,
                                                      Angle = 180,
                                                      IsCap = true
                                                  }
                                          };

        /// <summary>
        ///     The _m dash dots.
        /// </summary>
        private List<string> _mDashDots = new List<string>
                                              {
                                                  "1,0",
                                                  "18,6",
                                                  "3,1",
                                                  "2,2",
                                                  "7,1,4,1",
                                                  "3,1,3,2,1,2",
                                                  "1,2"
                                              };

        /// <summary>
        ///     The _m draw connector.
        /// </summary>
        private bool _mDrawConnector;

        /// <summary>
        ///     The _m draw text node.
        /// </summary>
        private bool _mDrawTextNode;

        /// <summary>
        ///     The _m format.
        /// </summary>
        private List<PageSize> _mFormat = new List<PageSize>
                                              {
                                                  PageSize.Letter,
                                                  PageSize.Folio,
                                                  PageSize.Legal,
                                                  PageSize.Ledger,
                                                  PageSize.A5,
                                                  PageSize.A4,
                                                  PageSize.A3,
                                                  PageSize.A2,
                                                  PageSize.A1,
                                                  PageSize.A0,
                                                  PageSize.Custom
                                              };

        /// <summary>
        ///     The _misapplytheme.
        /// </summary>
        private bool _misapplytheme = true;

        /// <summary>
        ///     The _m is blank diagram selected.
        /// </summary>
        private bool _mIsBlankDiagramSelected;

        /// <summary>
        ///     The _m is OrgChart diagram selected.
        /// </summary>
        private bool _mIsOrgChartSelected = true;

        /// <summary>
        ///     The _m is bring front enable.
        /// </summary>
        private bool _mIsBringFrontEnable;

        /// <summary>
        ///     The _m is drawing tool enable.
        /// </summary>
        private bool _mIsDrawingToolEnable;

        /// <summary>
        ///     The _mIsOpen.
        /// </summary>
        private bool _mIsOpen = true;

        /// <summary>
        ///     The _m is send back enable.
        /// </summary>
        private bool _mIsSendBackEnable;

        /// <summary>
        ///     The _m orientations.
        /// </summary>
        private List<PageOrientation> _mOrientations = new List<PageOrientation>
                                                           {
                                                               PageOrientation.Landscape, PageOrientation.Portrait
                                                           };

        /// <summary>
        ///     The _m pointer tool.
        /// </summary>
        private bool _mPointerTool = true;

        /// <summary>
        ///     The _m port visible.
        /// </summary>
        private bool _mPortVisible;

        /// <summary>
        ///     The _mSelectText.
        /// </summary>
        private bool _mSelectText;

        /*This property is used to change Drawing Tool icons at run time*/

        /// <summary>
        ///     The _m small icon.
        /// </summary>
        private string _mSmallIcon = ICons.DrawingTool_Rectangle.ToImageSource();

        /// <summary>
        ///     The _m tool tip constraints.
        /// </summary>
        private List<string> _mToolTipConstraints = new List<string>
                                                        {
                                                            "None",
                                                            "Position",
                                                            "Size",
                                                            "Angle",
                                                            "Default"
                                                        };

        /// <summary>
        ///     The _m types.
        /// </summary>
        private List<ConnectType> _mTypes = new List<ConnectType>
                                                {
                                                    ConnectType.Straight, ConnectType.Orthogonal, ConnectType.Bezier
                                                };

        /// <summary>
        ///     The _m units.
        /// </summary>
        private List<LengthUnits> _mUnits = new List<LengthUnits>
                                                {
                                                    LengthUnits.Inches,
                                                    LengthUnits.Feets,
                                                    LengthUnits.Yards,
                                                    LengthUnits.Millimeters,
                                                    LengthUnits.Centimeters,
                                                    LengthUnits.Meters,
                                                    LengthUnits.Pixels
                                                };

        /// <summary>
        ///     The _ saved path.
        /// </summary>
        private string _SavedPath;

        /// <summary>
        ///     The _selected diagram.
        /// </summary>
        private DiagramVM _selectedDiagram;

        /// <summary>
        ///     The _viewmodel.
        /// </summary>
        private DiagramCommandsViewModel _viewmodel;

        /// <summary>
        ///     The _ zoom parameter.
        /// </summary>
        private ZoomParameter _ZoomParameter;

        /// <summary>
        ///     The installed location.
        /// </summary>
        private string installedLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiagramBuilderVM" /> class.
        /// </summary>
        public DiagramBuilderVM()
        {
            this.New = new Command(this.OnNewCommand);
            this.Import = new Command(this.OnImportCommand);
            this.Save = new Command(this.OnSaveCommand);
            this.SaveAll = new Command(this.OnSaveAllCommand);
            this.Print = new Command(this.OnPrintCommand);
            this.ZoomIn = new Command(this.OnZoomInCommand);
            this.ZoomOut = new Command(this.OnZoomOutCommand);
            this.Open = new Command(this.OnOpenCommand);
            this.QuickStyle = new Command(this.OnQuickCommand);
            this.VariantStyle = new Command(this.OnVariantStyleCommand);
            this.SaveAs = new Command(this.OnSaveAsCommand);
            this.Draw = new Command(this.OnDrawCommand);
            this.Stencil = new StencilVm();
            this.Diagrams = new ObservableCollection<DiagramVM>();
            this.ZoomParameter = new ZoomParameter();
            this.RibbonCommand = new Command(this.OnRibbonCommand);

            this.DiagramCommandsVm = new DiagramCommandsViewModel();
#if !SyncfusionFramework4_5_1
            this.Framework = Visibility.Collapsed;
#else
            Framework = Visibility.Visible;
#endif
        }

        /// <summary>
        ///     Gets or sets the fonts.
        /// </summary>
        public static List<FontFamily> Fonts
        {
            get
            {
                return _mFonts;
            }

            set
            {
                if (_mFonts != value)
                {
                    _mFonts = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the caps.
        /// </summary>
        public List<Arrows> Caps
        {
            get
            {
                return this._mCaps;
            }

            set
            {
                if (this._mCaps != value)
                {
                    this._mCaps = value;
                    this.OnPropertyChanged(ConnectorConstants.Caps);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the dashdots.
        /// </summary>
        public List<string> DashDots
        {
            get
            {
                return this._mDashDots;
            }
        }

        /// <summary>
        ///     Gets or sets the diagram commands vm.
        /// </summary>
        public DiagramCommandsViewModel DiagramCommandsVm
        {
            get
            {
                return this._viewmodel;
            }

            set
            {
                if (this._viewmodel != value)
                {
                    this._viewmodel = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the collection of diagramvm.
        /// </summary>
        public ObservableCollection<DiagramVM> Diagrams { get; set; }

        /// <summary>
        ///     Gets or sets the draw command.
        /// </summary>
        public ICommand Draw { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether connector can draw or not.
        /// </summary>
        public bool DrawConnector
        {
            get
            {
                return this._mDrawConnector;
            }

            set
            {
                if (this._mDrawConnector != value)
                {
                    this._mDrawConnector = value;
                    this.OnPropertyChanged("DrawConnector");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether text node can be draw or not.
        /// </summary>
        public bool DrawTextNode
        {
            get
            {
                return this._mDrawTextNode;
            }

            set
            {
                if (this._mDrawTextNode != value)
                {
                    this._mDrawTextNode = value;
                    this.OnPropertyChanged("DrawTextNode");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the framework.
        /// </summary>
        public Visibility Framework { get; set; }

        /// <summary>
        ///     Gets or sets the import command.
        /// </summary>
        public ICommand Import { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether themes can apply for diagramming elements or not.
        /// </summary>
        public bool IsApplyTheme
        {
            get
            {
                return this._misapplytheme;
            }

            set
            {
                if (this._misapplytheme != value)
                {
                    this._misapplytheme = value;
                    this.OnPropertyChanged("IsApplyTheme");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether  backstagecommandbuttons can be enabled or not.
        /// </summary>
        public bool IsBackStageCommandButtonsEnabled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether blank diagram can be selected or not.
        /// </summary>
        public bool IsBlankDiagramSelected
        {
            get
            {
                return this._mIsBlankDiagramSelected;
            }

            set
            {
                if (this._mIsBlankDiagramSelected != value)
                {
                    this._mIsBlankDiagramSelected = value;
                    this.OnPropertyChanged("IsBlankDiagramSelected");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether Orgchart diagram is selected or not.
        /// </summary>
        public bool IsOrgChartSelected
        {
            get
            {
                return this._mIsOrgChartSelected;
            }

            set
            {
                if (this._mIsOrgChartSelected != value)
                {
                    this._mIsOrgChartSelected = value;
                    this.OnPropertyChanged("IsOrgChartSelected");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether bringfront can be enabled or not.
        /// </summary>
        public bool IsBringFrontEnable
        {
            get
            {
                return this._mIsBringFrontEnable;
            }

            set
            {
                if (this._mIsBringFrontEnable != value)
                {
                    this._mIsBringFrontEnable = value;
                    this.OnPropertyChanged("IsBringFrontEnable");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether drawing tool can be enabled or not.
        /// </summary>
        public bool IsDrawingToolEnable
        {
            get
            {
                return this._mIsDrawingToolEnable;
            }

            set
            {
                if (this._mIsDrawingToolEnable != value)
                {
                    this._mIsDrawingToolEnable = value;
                    this.OnPropertyChanged("IsDrawingToolEnable");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether loading can happen or not.
        /// </summary>
        public bool IsLoaded { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether open can happen or not.
        /// </summary>
        public bool Isopen
        {
            get
            {
                return this._mIsOpen;
            }

            set
            {
                if (this._mIsOpen != value)
                {
                    this._mIsOpen = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether sendback can be enabled or not.
        /// </summary>
        public bool IsSendBackEnable
        {
            get
            {
                return this._mIsSendBackEnable;
            }

            set
            {
                if (this._mIsSendBackEnable != value)
                {
                    this._mIsSendBackEnable = value;
                    this.OnPropertyChanged("IsSendBackEnable");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the new command.
        /// </summary>
        public ICommand New { get; set; }

        /// <summary>
        ///     Gets or sets the open command.
        /// </summary>
        public ICommand Open { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether pointertoolcan be enabled or not.
        /// </summary>
        public bool PointerTool
        {
            get
            {
                return this._mPointerTool;
            }

            set
            {
                if (this._mPointerTool != value)
                {
                    this._mPointerTool = value;
                    this.OnPropertyChanged("PointerTool");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether port can be visible or not.
        /// </summary>
        public bool PortVisible
        {
            get
            {
                return this._mPortVisible;
            }

            set
            {
                if (this._mPortVisible != value)
                {
                    this._mPortVisible = value;
                    this.OnPropertyChanged("PortVisible");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the print command.
        /// </summary>
        public ICommand Print { get; set; }

        /// <summary>
        ///     Gets or sets the quick style command.
        /// </summary>
        public ICommand QuickStyle { get; set; }

        /// <summary>
        ///     Gets or sets the ribbon.
        /// </summary>
        public Ribbon Ribbon { get; set; }

        /// <summary>
        ///     Gets or sets the ribbon command.
        /// </summary>
        public ICommand RibbonCommand { get; set; }

        /// <summary>
        ///     Gets or sets the save command.
        /// </summary>
        public ICommand Save { get; set; }

        /// <summary>
        ///     Gets or sets the save all command.
        /// </summary>
        public ICommand SaveAll { get; set; }

        /// <summary>
        ///     Gets or sets the save as command.
        /// </summary>
        public ICommand SaveAs { get; set; }

        /// <summary>
        ///     Gets or sets the selected diagram.
        /// </summary>
        public DiagramVM SelectedDiagram
        {
            get
            {
                return this._selectedDiagram;
            }

            set
            {
                if (this._selectedDiagram != value)
                {
                    if (this._selectedDiagram != null)
                    {
                        this._selectedDiagram.IsSelected = false;
                    }

                    this._selectedDiagram = value;
                    if (this._selectedDiagram != null)
                    {
                        this._selectedDiagram.IsSelected = true;
                    }

                    this.OnPropertyChanged("SelectedDiagram");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether text is selected or not.
        /// </summary>
        public bool SelectedText
        {
            get
            {
                return this._mSelectText;
            }

            set
            {
                if (this._mSelectText != value)
                {
                    this._mSelectText = value;
                    this.OnPropertyChanged("SelectedText");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the small icon.
        /// </summary>
        public string SmallIcon
        {
            get
            {
                return this._mSmallIcon;
            }

            set
            {
                if (this._mSmallIcon != value)
                {
                    this._mSmallIcon = value;
                    this.OnPropertyChanged("SmallIcon");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the stencil.
        /// </summary>
        public StencilVm Stencil { get; set; }

        /// <summary>
        ///     Gets or sets the variant style.
        /// </summary>
        public ICommand VariantStyle { get; set; }

        /// <summary>
        ///     Gets or sets the zoom in command.
        /// </summary>
        public ICommand ZoomIn { get; set; }

        /// <summary>
        ///     Gets or sets the zoom out command.
        /// </summary>
        public ICommand ZoomOut { get; set; }

        /// <summary>
        ///     Gets or sets the zoom parameter.
        /// </summary>
        public ZoomParameter ZoomParameter
        {
            get
            {
                return this._ZoomParameter;
            }

            set
            {
                if (this._ZoomParameter != value)
                {
                    this._ZoomParameter = value;
                    this.OnPropertyChanged("ZoomParameter");
                }
            }
        }

        public ICommand Delete { get; private set; }

        /// <summary>
        ///     Represents the hide backstage_ click.
        /// </summary>
        public void HideBackstageClick()
        {
            this.Ribbon.HideBackStage();
            this.IsBackStageCommandButtonsEnabled = true;
        }

        /// <summary>
        /// Represents the import command execution.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void OnImportCommand(object data)
        {
        }

        /// <summary>
        /// Represents the new command execution.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void OnNewCommand(object data)
        {
            this.HideBackstageClick();
            if (this._SavedPath == null)
            {
                if (this.SelectedDiagram != null)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show(
                        "Do you want to save Diagram?",
                        "Diagram Builder",
                        MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        this.Save.Execute(null);
                    }
                }

                if (data == null)
                {
                    DiagramVM firstDiagram = this.Diagrams.Count > 0 ? this.Diagrams[0] : null;
                    if (firstDiagram == null || firstDiagram.DiagramType.ToString() == "Blank")
                    {
                        this.DiagramCommandsVm.RemoveBrainstorming();
                        this.DiagramCommandsVm.RemoveOrganizationChart();
                        this.CreateBlankDiagram(this._SavedPath);
                    }
                    else if (firstDiagram.DiagramType.ToString() == "Brainstorming")
                    {
                        this.DiagramCommandsVm.RemoveOrganizationChart();
                        this.DiagramCommandsVm.PopulateBrainstorming();
                        this.CreateBrainstormingDiagram(this._SavedPath);
                    }
                    else if (firstDiagram.DiagramType.ToString() == "FlowChart")
                    {
                        this.DiagramCommandsVm.RemoveOrganizationChart();
                        this.DiagramCommandsVm.RemoveBrainstorming();
                        this.CreateFlowChartDiagram(this._SavedPath);
                    }
                    else if (firstDiagram.DiagramType.ToString() == "OrganizationChart")
                    {
                        this.DiagramCommandsVm.RemoveBrainstorming();
                        this.DiagramCommandsVm.PopulateOrganizationChart();
                        CreateOrganizationChartDiagram(_SavedPath);
                    }
                }
                else if (data.ToString().Equals("Blank"))
                {
                    this.DiagramCommandsVm.RemoveBrainstorming();
                    this.DiagramCommandsVm.RemoveOrganizationChart();
                    this.CreateBlankDiagram(this._SavedPath);
                }
                else if (data.ToString().Equals("Brainstorming"))
                {
                    this.DiagramCommandsVm.PopulateBrainstorming();
                    this.DiagramCommandsVm.RemoveOrganizationChart();
                    this.CreateBrainstormingDiagram(this._SavedPath);
                }
                else if (data.ToString().Equals("FlowChart"))
                {
                    this.DiagramCommandsVm.RemoveOrganizationChart();
                    this.DiagramCommandsVm.RemoveBrainstorming();
                    this.CreateFlowChartDiagram(this._SavedPath);
                }
                else if (data.ToString().Equals("OrganizationChart"))
                {
                    this.DiagramCommandsVm.PopulateOrganizationChart();
                    this.DiagramCommandsVm.RemoveBrainstorming();
                    CreateOrganizationChartDiagram(_SavedPath);
                }
            }
            else if (this._SavedPath != null && File.Exists(this._SavedPath))
            {
                if (data.ToString().Equals("Blank"))
                {
                    this.DiagramCommandsVm.RemoveBrainstorming();
                    this.DiagramCommandsVm.RemoveOrganizationChart();
                    this.CreateBlankDiagramOnLoad(this._SavedPath, true);
                }
                else if (data.ToString().Equals("Brainstorming"))
                {
                    this.DiagramCommandsVm.PopulateBrainstorming();
                    this.DiagramCommandsVm.RemoveOrganizationChart();
                    this.CreateBrainstormingDiagramOnLoad(this._SavedPath, true);
                }
                else if (data.ToString().Equals("FlowChart"))
                {
                    this.DiagramCommandsVm.RemoveBrainstorming();
                    this.DiagramCommandsVm.RemoveOrganizationChart();
                    this.CreateFlowchartDiagramOnLoad(this._SavedPath, true);
                }
                else if (data.ToString().Equals("OrganizationChart"))
                {
                    this.DiagramCommandsVm.RemoveBrainstorming();
                    this.DiagramCommandsVm.PopulateOrganizationChart();
                    CreateOrganizationChartDiagramOnLoad(_SavedPath, true);
                }
            }

            this._SavedPath = null;
        }

        /// <summary>
        /// Represents the open command execution.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void OnOpenCommand(object data)
        {
            this.HideBackstageClick();
            if (this.SelectedDiagram != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                    "Do you want to save Diagram?",
                    "Diagram Builder",
                    MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    this.Save.Execute(null);
                }
            }

            OpenFileDialog openDialogBox = new OpenFileDialog();
            openDialogBox.Title = "Load";
            openDialogBox.RestoreDirectory = true;
            openDialogBox.DefaultExt = "xml";
            openDialogBox.Filter = "xml files (*.xml)|*.xml";
            bool? isFileChosen = openDialogBox.ShowDialog();
            if (isFileChosen == true)
            {
                this._SavedPath = openDialogBox.FileName;
                using (FileStream fileStream = File.OpenRead(this._SavedPath))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    using (XmlReader reader = XmlReader.Create(this._SavedPath, settings))
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsEmptyElement && reader.NodeType == XmlNodeType.Text)
                            {
                                string value = reader.Value;
                                if (value == "DiagramType")
                                {
                                    reader.ReadToFollowing("a:Value");
                                    value = reader.ReadElementContentAsString();
                                    if (value == "Blank")
                                    {
                                        this.OnNewCommand("Blank");
                                    }
                                    else if (value == "Brainstorming")
                                    {
                                        this.OnNewCommand("Brainstorming");
                                    }
                                    else if (value == "FlowChart")
                                    {
                                        this.OnNewCommand("FlowChart");
                                    }
                                    else if( value == "OrganizationChart")
                                    {
                                        this.OnNewCommand("OrganizationChart");
                                    }

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (isFileChosen == false && this.SelectedDiagram == null)
            {
                this.Ribbon.ShowBackStage();
            }
        }

        /// <summary>
        /// Represents the print command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void OnPrintCommand(object value)
        {
#if SyncfusionFramework4_5_1
            PageVM page = SelectedDiagram.PageSettings as PageVM;

            PrintingService print = SelectedDiagram.PrintingService;
            print.PrintMargin = page.PrintMargin;
            switch (page.SelectedFormat)
            {
                case PageSize.A0:
                    print.PrintMediaSize = PrintMediaSize.IsoA0;
                    break;
                case PageSize.A1:
                    print.PrintMediaSize = PrintMediaSize.IsoA1;
                    break;
                case PageSize.A2:
                    print.PrintMediaSize = PrintMediaSize.IsoA2;
                    break;
                case PageSize.A3:
                    print.PrintMediaSize = PrintMediaSize.IsoA3;
                    break;
                case PageSize.A4:
                    print.PrintMediaSize = PrintMediaSize.IsoA4;
                    break;
                case PageSize.A5:
                    print.PrintMediaSize = PrintMediaSize.IsoA5;
                    break;
                case PageSize.Folio:
                    print.PrintMediaSize = PrintMediaSize.OtherMetricFolio;
                    break;
                case PageSize.Ledger:
                    print.PrintMediaSize = PrintMediaSize.NorthAmericaTabloid;
                    break;
                case PageSize.Legal:
                    print.PrintMediaSize = PrintMediaSize.NorthAmericaLegal;
                    break;
                case PageSize.Letter:
                    print.PrintMediaSize = PrintMediaSize.NorthAmericaLetter;
                    break;
            }
            if (page.PageOrientation == PageOrientation.Landscape)
            {
                print.PrintOrientation = PrintOrientation.Landscape;
            }
            else
            {
                print.PrintOrientation = PrintOrientation.Portrait;
            }

            print.UnregisterForPrinting();
             print.RegisterForPrinting();
            

// await Windows.Graphics.Printing.PrintManager.ShowPrintUIAsync(); 
#endif
        }

        /// <summary>
        /// Represents the save all command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public async void OnSaveAllCommand(object value)
        {
            await this.SaveAllDiagrams();
        }

        /// <summary>
        /// Represents the save as command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void OnSaveAsCommand(object value)
        {
            this.HideBackstageClick();
            SaveFileDialog saveAsFileDialog = new SaveFileDialog { Title = "Save As", DefaultExt = ".xml" };
            saveAsFileDialog.Filter = "Text file (*.xml)|*.xml";

            if (saveAsFileDialog.ShowDialog() == true)
            {
                this._SavedPath = saveAsFileDialog.FileName;
                IGraphInfo graph = this.SelectedDiagram.Info as IGraphInfo;
                PageVM page = this.SelectedDiagram.PageSettings as PageVM;
                page.Scale = this.SelectedDiagram.ScrollSettings.ScrollInfo.CurrentZoom;
                using (Stream fileStream = saveAsFileDialog.OpenFile())
                {
                    graph.Save(fileStream);
                }
            }
        }

        /// <summary>
        /// Represents the save command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public async void OnSaveCommand(object value)
        {
            this.HideBackstageClick();
            if (this._SavedPath == null)
            {
                SaveFileDialog saveAsFileDialog = new SaveFileDialog { Title = "Save ", DefaultExt = ".xml" };
                saveAsFileDialog.Filter = "Text file (*.xml)|*.xml";

                if (saveAsFileDialog.ShowDialog() == true)
                {
                    this._SavedPath = saveAsFileDialog.FileName;
                    IGraphInfo graph = this.SelectedDiagram.Info as IGraphInfo;
                    PageVM page = this.SelectedDiagram.PageSettings as PageVM;
                    page.Scale = this.SelectedDiagram.ScrollSettings.ScrollInfo.CurrentZoom;
                    using (Stream fileStream = saveAsFileDialog.OpenFile())
                    {
                        graph.Save(fileStream);
                    }
                }
            }
            else if (this._SavedPath != null && File.Exists(this._SavedPath))
            {
                await this.SelectedDiagram.Save(this._SavedPath);
            }
        }

        /// <summary>
        ///     Represents the select text changed command execution.
        /// </summary>
        public void OnSelectTextChanged()
        {
            if (this.SelectedText)
            {
                foreach (DiagramVM diagram in this.Diagrams)
                {
                    diagram.DrawingTool = DrawingTool.None;
                    diagram.Tool = Tool.MultipleSelect;
                    diagram.PortVisibility = PortVisibility.MouseOverOnConnect;
                    List<NodeVM> nodes = (diagram.Nodes as ObservableCollection<NodeVM>).ToList();
                    foreach (NodeVM nv in nodes)
                    {
                        if (nv.Shape == null && nv.Content == null)
                        {
                            continue;
                        }

                        foreach (LabelVM av in nv.Annotations as List<IAnnotation>)
                        {
                            av.Constraints = AnnotationConstraints.Draggable | AnnotationConstraints.Resizable
                                                                             | AnnotationConstraints.Selectable
                                                                             | AnnotationConstraints.Rotatable
                                                                             | (AnnotationConstraints.Default
                                                                                & ~AnnotationConstraints.Inherit);
                        }
                    }

                    List<ConnectorVM> connectors = (diagram.Connectors as ObservableCollection<ConnectorVM>).ToList();
                    foreach (ConnectorVM cv in connectors)
                    {
                        foreach (LabelVM av in cv.Annotations as List<IAnnotation>)
                        {
                            av.Constraints = AnnotationConstraints.Draggable | AnnotationConstraints.Resizable
                                                                             | AnnotationConstraints.Selectable
                                                                             | AnnotationConstraints.Rotatable
                                                                             | (AnnotationConstraints.Default
                                                                                & ~AnnotationConstraints.Inherit);
                        }
                    }
                }

                this.DrawConnector = false;
                this.PointerTool = false;
                this.DrawTextNode = false;
                this.IsDrawingToolEnable = false;
                this.PortVisible = false;
            }
            else if (!this.PortVisible && !this.DrawConnector && !this.DrawTextNode && !this.IsDrawingToolEnable)
            {
                this.PointerTool = true;
                foreach (DiagramVM diagram in this.Diagrams)
                {
                    if (diagram.Nodes is ObservableCollection<NodeVM>)
                    {
                        List<NodeVM> nodes = (diagram.Nodes as ObservableCollection<NodeVM>).ToList();
                        foreach (NodeVM nv in nodes)
                        {
                            foreach (LabelVM av in nv.Annotations as List<IAnnotation>)
                            {
                                av.Constraints = AnnotationConstraints.Default;
                            }
                        }
                    }

                    if (diagram.Connectors is ObservableCollection<ConnectorVM>)
                    {
                        List<ConnectorVM> connectors =
                            (diagram.Connectors as ObservableCollection<ConnectorVM>).ToList();
                        foreach (ConnectorVM cv in connectors)
                        {
                            foreach (LabelVM av in cv.Annotations as List<IAnnotation>)
                            {
                                av.Constraints = AnnotationConstraints.Default;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Represents the zoom command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void OnZoomCommand(object value)
        {
            if (value != null)
            {
                if (this.IsDigitsOnly(value.ToString()) && value.ToString() != string.Empty)
                {
                    double _mZoomValue = Convert.ToDouble(value) / 100;
                    (this.SelectedDiagram.Info as IGraphInfo).Commands.Zoom.Execute(
                        new ZoomPositionParameter { ZoomTo = _mZoomValue, ZoomCommand = ZoomCommand.Zoom });
                }
                else if (value.ToString() == "Page")
                {
                    (this.SelectedDiagram.Info as IGraphInfo).Commands.FitToPage.Execute(
                        new FitToPageParameter { FitToPage = FitToPage.FitToPage, Region = Region.PageSettings });
                }
                else if (value.ToString() == "Width")
                {
                    (this.SelectedDiagram.Info as IGraphInfo).Commands.FitToPage.Execute(
                        new FitToPageParameter { FitToPage = FitToPage.FitToWidth, Region = Region.PageSettings });
                }
            }
        }

        /// <summary>
        /// Represents the zoom in command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void OnZoomInCommand(object value)
        {
            (this.SelectedDiagram.Info as IGraphInfo).Commands.Zoom.Execute(
                new ZoomPositionParameter { ZoomFactor = 0.2, ZoomCommand = ZoomCommand.ZoomIn });
        }

        /// <summary>
        /// Represents the zoom out command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void OnZoomOutCommand(object value)
        {
            (this.SelectedDiagram.Info as IGraphInfo).Commands.Zoom.Execute(
                new ZoomPositionParameter { ZoomFactor = 0.2, ZoomCommand = ZoomCommand.ZoomOut });
        }

        /// <summary>
        ///     Represents the prepare exit action.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public async Task PrepareExit()
        {
            await this.SaveAllDiagrams();
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch (name)
            {
                case "DrawConnector":
                    this.OnDrawConnectorChanged();
                    break;
                case "PortVisible":
                    this.OnPortVisibleChanged();
                    break;
                case "PointerTool":
                    this.OnPointerToolChanged();
                    break;
                case "DrawTextNode":
                    this.OnDrawTextNodeChanged();
                    break;
                case "IsDrawingToolEnable":
                    this.IsDrawingToolEnableChanged();
                    break;
                case "SelectedText":
                    this.OnSelectTextChanged();
                    break;
                case "IsBringFrontEnable":
                    this.OnBringFrontEnabled();
                    break;
                case "IsSendBackEnable":
                    this.OnSendBackEnabled();
                    break;
            }
        }

        /// <summary>
        /// The create blank diagram.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        private void CreateBlankDiagram(string file)
        {
            DiagramVM newDiagram = this.GetNewDiagramVm(file, false);
            this.Diagrams.Add(newDiagram);
            this.SelectedDiagram = newDiagram;
        }

        /// <summary>
        /// The create blank diagram on load.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private void CreateBlankDiagramOnLoad(string file, bool value)
        {
            DiagramVM newDiagram = this.GetNewDiagramVm(file, true);
            this.RetainPageSettingsOnLoad(newDiagram);
            this.Diagrams.Add(newDiagram);
            this.SelectedDiagram = newDiagram;
        }

        /// <summary>
        /// The create brainstorming diagram.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        private void CreateBrainstormingDiagram(string file)
        {
            BrainstormingVM newDiagram = this.GetNewBrainstormingDiagram(file, false);
            this.SelectedDiagram = newDiagram;
            Ribbon.SelectedIndex = 0;
            this.Diagrams.Add(newDiagram);
        }

        /// <summary>
        /// The create brainstorming diagram on load.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private void CreateBrainstormingDiagramOnLoad(string file, bool value)
        {
            BrainstormingVM newDiagram = this.GetNewBrainstormingDiagram(file, true);
            this.RetainPageSettingsOnLoad(newDiagram);
            this.SelectedDiagram = newDiagram;
            Ribbon.SelectedIndex = 0;
            this.Diagrams.Add(newDiagram);
        }

        /// <summary>
        /// The create flow chart diagram.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        private void CreateFlowChartDiagram(string file)
        {
            FlowDiagramVm newFlowChart = this.GetNewFlowChartDiagram(file, false);
            this.Diagrams.Add(newFlowChart);
            Ribbon.SelectedIndex = 0;
            this.SelectedDiagram = newFlowChart;
        }

        /// <summary>
        /// The create flowchart diagram on load.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private void CreateFlowchartDiagramOnLoad(string file, bool value)
        {
            FlowDiagramVm newDiagram = this.GetNewFlowChartDiagram(file, true);
            this.RetainPageSettingsOnLoad(newDiagram);
            this.SelectedDiagram = newDiagram;
            Ribbon.SelectedIndex = 0;
            this.Diagrams.Add(newDiagram);
        }

        /// <summary>
        /// The get new brainstorming diagram.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="isValidXml">
        /// The is valid xml.
        /// </param>
        /// <returns>
        /// The <see cref="BrainstormingVM"/>.
        /// </returns>
        private BrainstormingVM GetNewBrainstormingDiagram(string file, bool isValidXml)
        {
            BrainstormingVM diagram = new BrainstormingVM(file, isValidXml) { Title = "Page" };
            if (this._mDrawConnector)
            {
                diagram.DrawingTool = DrawingTool.Connector;
                diagram.Tool = Tool.ContinuesDraw;
                diagram.DefaultConnectorType = ConnectorType.Orthogonal;
            }
            else if (this._mDrawTextNode)
            {
                diagram.Tool = Tool.ContinuesDraw;
                diagram.DrawingTool = DrawingTool.Node;
                diagram.IsDrawTextNode = true;
            }
            else if (this._mIsDrawingToolEnable)
            {
                if (diagram.Shape.Equals("Line"))
                {
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Connector;
                    diagram.IsDrawTextNode = false;
                    diagram.DefaultConnectorType = ConnectorType.Line;
                }
                else if (diagram.Shape.Equals("Rectangle"))
                {
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Node;
                    diagram.IsDrawTextNode = false;
                }
            }
            else if (this._mPortVisible)
            {
                diagram.PortVisibility = PortVisibility.Visible;
            }

            diagram.PropertyChanged += (s, e) =>
                {
                    DiagramVM sender = s as DiagramVM;
                    if (e.PropertyName == "IsSelected")
                    {
                        if (sender.IsSelected)
                        {
                            this.SelectedDiagram = sender;
                        }
                    }
                };
            return diagram;
        }

        /// <summary>
        /// The get new diagram vm.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="isValidXml">
        /// The is valid xml.
        /// </param>
        /// <returns>
        /// The <see cref="DiagramVM"/>.
        /// </returns>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private DiagramVM GetNewDiagramVm(string file, bool isValidXml)
        {
            DiagramVM diagram = new DiagramVM(file, isValidXml) { Title = "Page" };
            if (this._mDrawConnector)
            {
                diagram.DrawingTool = DrawingTool.Connector;
                diagram.Tool = Tool.ContinuesDraw;
                diagram.DefaultConnectorType = ConnectorType.Orthogonal;
            }
            else if (this._mDrawTextNode)
            {
                diagram.Tool = Tool.ContinuesDraw;
                diagram.DrawingTool = DrawingTool.Node;
                diagram.IsDrawTextNode = true;
            }
            else if (this._mIsDrawingToolEnable)
            {
                if (diagram.Shape.Equals("Line"))
                {
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Connector;
                    diagram.IsDrawTextNode = false;
                    diagram.DefaultConnectorType = ConnectorType.Line;
                }
                else if (diagram.Shape.Equals("Rectangle"))
                {
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Node;
                    diagram.IsDrawTextNode = false;
                }
            }
            else if (this._mPortVisible)
            {
                diagram.PortVisibility = PortVisibility.Visible;
            }

            diagram.PropertyChanged += (s, e) =>
                {
                    base.OnPropertyChanged(e.PropertyName);
                    DiagramVM sender = s as DiagramVM;
                    if (e.PropertyName == "IsSelected")
                    {
                        if (sender.IsSelected)
                        {
                            this.SelectedDiagram = sender;
                        }
                    }
                };
            return diagram;
        }

        /// <summary>
        /// The get new flow chart diagram.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="isValidXml">
        /// The is valid xml.
        /// </param>
        /// <returns>
        /// The <see cref="FlowDiagramVm"/>.
        /// </returns>
        private FlowDiagramVm GetNewFlowChartDiagram(string file, bool isValidXml)
        {
            FlowDiagramVm diagram = new FlowDiagramVm(file, isValidXml);
            if (this._mDrawConnector)
            {
                diagram.DrawingTool = DrawingTool.Connector;
                diagram.Tool = Tool.ContinuesDraw;
                diagram.DefaultConnectorType = ConnectorType.Orthogonal;
            }
            else if (this._mDrawTextNode)
            {
                diagram.Tool = Tool.ContinuesDraw;
                diagram.DrawingTool = DrawingTool.Node;
                diagram.IsDrawTextNode = true;
            }
            else if (this._mIsDrawingToolEnable)
            {
                if (diagram.Shape.Equals("Line"))
                {
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Connector;
                    diagram.IsDrawTextNode = false;
                    diagram.DefaultConnectorType = ConnectorType.Line;
                }
                else if (diagram.Shape.Equals("Rectangle"))
                {
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Node;
                    diagram.IsDrawTextNode = false;
                }
            }
            else if (this._mPortVisible)
            {
                diagram.PortVisibility = PortVisibility.Visible;
            }

            diagram.PropertyChanged += (s, e) =>
                {
                    DiagramVM sender = s as DiagramVM;
                    if (e.PropertyName == "IsSelected")
                    {
                        if (sender != null && sender.IsSelected)
                        {
                            this.SelectedDiagram = sender;
                        }
                    }
                };
            return diagram;
        }

        /// <summary>
        /// The is digits only.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsDigitsOnly(string value)
        {
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     The is drawing tool enable changed.
        /// </summary>
        private void IsDrawingToolEnableChanged()
        {
            if (this.IsDrawingToolEnable)
            {
                foreach (DiagramVM diagram in this.Diagrams)
                {
                    if (diagram.Shape.Equals("Line"))
                    {
                        diagram.DrawingTool = DrawingTool.Connector;
                        diagram.DefaultConnectorType = ConnectorType.Line;
                    }
                    else if (diagram.Shape.Equals("PolyLine"))
                    {
                        diagram.DrawingTool = DrawingTool.Connector;
                        diagram.DefaultConnectorType = ConnectorType.PolyLine;
                    }
                    else if (diagram.Shape.Equals("Rectangle") || diagram.Shape.Equals("Ellipse"))
                    {
                        diagram.DrawingTool = DrawingTool.Node;
                        diagram.DefaultConnectorType = ConnectorType.Orthogonal;
                    }
                    else if (diagram.Shape.Equals("FreeHand"))
                    {
                        diagram.DrawingTool = DrawingTool.FreeHand;
                    }

                    diagram.PortVisibility = PortVisibility.MouseOverOnConnect;
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.IsDrawTextNode = false;
                }

                this.PointerTool = false;
                this.DrawTextNode = false;
                this.DrawConnector = false;
                this.SelectedText = false;
                this.PortVisible = false;
            }
            else if (!this.DrawTextNode && !this.DrawConnector && !this.PortVisible && !this.SelectedText)
            {
                this.PointerTool = true;
            }
        }

        /// <summary>
        ///     Method to execute the bringtofront command
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private void OnBringFrontEnabled()
        {
            if (this.IsBringFrontEnable)
            {
                (this.SelectedDiagram.Info as IGraphInfo).Commands.BringToFront.Execute(null);
                this.IsBringFrontEnable = false;
            }
        }

        /// <summary>
        /// The on draw command.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        private void OnDrawCommand(object value)
        {
            this.IsDrawingToolEnable = true;
            foreach (DiagramVM diagram in this.Diagrams)
            {
                if (value.ToString().Equals("Line"))
                {
                    this.SmallIcon = ICons.DrawingTool_StraightLine.ToImageSource();
                    diagram.DrawingTool = DrawingTool.Connector;
                    diagram.DefaultConnectorType = ConnectorType.Line;
                }
                else if (value.ToString().Equals("Rectangle"))
                {
                    this.SmallIcon = ICons.DrawingTool_Rectangle.ToImageSource();
                    diagram.DrawingTool = DrawingTool.Node;
                    diagram.DefaultConnectorType = ConnectorType.Orthogonal;
                }
                else if (value.ToString().Equals("Ellipse"))
                {
                    this.SmallIcon = ICons.DrawingTool_Ellipse.ToImageSource();
                    diagram.DefaultConnectorType = ConnectorType.Orthogonal;
                    diagram.DrawingTool = DrawingTool.Node;
                }
                else if (value.ToString().Equals("PolyLine"))
                {
                    this.SmallIcon = ICons.Polyline.ToImageSource();
                    diagram.DrawingTool = DrawingTool.Connector;
                    diagram.DefaultConnectorType = ConnectorType.PolyLine;
                }
                else if (value.ToString().Equals("FreeHand"))
                {
                    this.SmallIcon = ICons.ConnectorType_CubicBeier.ToImageSource();
                    diagram.DrawingTool = DrawingTool.FreeHand;
                }

                diagram.PortVisibility = PortVisibility.MouseOverOnConnect;
                diagram.Tool = Tool.ContinuesDraw;
                diagram.IsDrawTextNode = false;
                diagram.Shape = value.ToString();
            }
        }

        /// <summary>
        ///     The on draw connector changed.
        /// </summary>
        private void OnDrawConnectorChanged()
        {
            if (this.DrawConnector)
            {
                foreach (DiagramVM diagram in this.Diagrams)
                {
                    diagram.PortVisibility = PortVisibility.MouseOverOnConnect;
                    diagram.DrawingTool = DrawingTool.Connector;
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DefaultConnectorType = ConnectorType.Orthogonal;
                }

                this.PointerTool = false;
                this.DrawTextNode = false;
                this.IsDrawingToolEnable = false;
                this.PortVisible = false;
                this.SelectedText = false;
            }
            else if (!this.PortVisible && !this.DrawTextNode && !this.SelectedText && !this.IsDrawingToolEnable)
            {
                this.PointerTool = true;
            }
        }

        /// <summary>
        ///     The on draw text node changed.
        /// </summary>
        private void OnDrawTextNodeChanged()
        {
            if (this.DrawTextNode)
            {
                foreach (DiagramVM diagram in this.Diagrams)
                {
                    diagram.PortVisibility = PortVisibility.MouseOverOnConnect;
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Node;
                    diagram.IsDrawTextNode = true;
                    if (diagram.SelectedItems is SelectorVM && (diagram.SelectedItems as SelectorVM).Annotation != null)
                    {
                        (diagram.SelectedItems as SelectorVM).Annotation.Mode = ContentEditorMode.Edit;
                    }
                }

                this.PointerTool = false;
                this.DrawConnector = false;
                this.IsDrawingToolEnable = false;
                this.PortVisible = false;
                this.SelectedText = false;
            }
            else if (!this.DrawConnector && !this.IsDrawingToolEnable && !this.PortVisible && !this.SelectedText)
            {
                this.PointerTool = true;
            }
        }

        /// <summary>
        ///     The on pointer tool changed.
        /// </summary>
        private void OnPointerToolChanged()
        {
            if (this.PointerTool)
            {
                foreach (DiagramVM diagram in this.Diagrams)
                {
                    diagram.DrawingTool = DrawingTool.None;
                    diagram.Tool = Tool.MultipleSelect;
                    diagram.PortVisibility = PortVisibility.MouseOverOnConnect;
                    diagram.DefaultConnectorType = ConnectorType.Orthogonal;
                }

                this.DrawConnector = false;
                this.DrawTextNode = false;
                this.IsDrawingToolEnable = false;
                this.PortVisible = false;
                this.SelectedText = false;
            }
        }

        /// <summary>
        ///     The on port visible changed.
        /// </summary>
        private void OnPortVisibleChanged()
        {
            if (this.PortVisible)
            {
                foreach (DiagramVM diagram in this.Diagrams)
                {
                    diagram.PortVisibility = PortVisibility.Visible;
                    diagram.DrawingTool = DrawingTool.None;
                    diagram.Tool = Tool.MultipleSelect;
                }

                this.PointerTool = false;
                this.DrawTextNode = false;
                this.DrawConnector = false;
                this.IsDrawingToolEnable = false;
                this.SelectedText = false;
            }
            else if (!this.DrawConnector && !this.DrawTextNode && !this.SelectedText && !this.IsDrawingToolEnable)
            {
                this.PointerTool = true;
                foreach (DiagramVM diagram in this.Diagrams)
                {
                    diagram.PortVisibility = PortVisibility.MouseOverOnConnect;
                }
            }
        }

        /// <summary>
        /// The on quick command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnQuickCommand(object obj)
        {
            // GroupTransactions group = new GroupTransactions();
            // group.ContinuousUndoRedo = ContinuousUndoRedo.Start;
            // (SelectedDiagram as DiagramVM).HistoryManager.BeginComposite((SelectedDiagram as DiagramVM).HistoryManager, group);
            string name = obj + "Style";
            Style s = null;
            foreach (Window win in Application.Current.Windows)
            {
                if (win.DataContext is DiagramBuilderVM)
                {
                    s = win.Resources[name] as Style;
                }
            }
            ISelectorVM selectedItem = this.SelectedDiagram.SelectedItems as ISelectorVM;
            DesignRibbonGalleryItem galleryItem = obj as DesignRibbonGalleryItem;
            if (galleryItem != null && galleryItem.Content is GalleryStyle && this.SelectedDiagram is BrainstormingVM
                && ((this.SelectedDiagram as BrainstormingVM).NodeCollection != null
                || (this.SelectedDiagram as BrainstormingVM).ConnectorCollection != null))
            {
                foreach (var nodeVm in (this.SelectedDiagram as BrainstormingVM).NodeCollection)
                {
                    if (!nodeVm.Constraints.Contains(NodeConstraints.ThemeStyle))
                    {
                        nodeVm.Constraints |= NodeConstraints.ThemeStyle;
                    }
                }

                foreach (var connectorVm in (this.SelectedDiagram as BrainstormingVM).ConnectorCollection)
                {
                    if (!connectorVm.Constraints.Contains(ConnectorConstraints.ThemeStyle))
                    {
                        connectorVm.Constraints |= ConnectorConstraints.ThemeStyle;
                    }
                }

                this.SelectedDiagram.Theme = galleryItem.Theme;
            }
            else if (galleryItem != null && galleryItem.Content is GalleryStyle && this.SelectedDiagram is FlowDiagramVm
                && ((this.SelectedDiagram as FlowDiagramVm).NodeCollection != null
                || (this.SelectedDiagram as FlowDiagramVm).ConnectorCollection != null))
            {
                foreach (var nodeVm in (this.SelectedDiagram as FlowDiagramVm).NodeCollection)
                {
                    if (!nodeVm.Constraints.Contains(NodeConstraints.ThemeStyle))
                    {
                        nodeVm.Constraints |= NodeConstraints.ThemeStyle;
                    }
                }

                foreach (var connectorVm in (this.SelectedDiagram as FlowDiagramVm).ConnectorCollection)
                {
                    if (!connectorVm.Constraints.Contains(ConnectorConstraints.ThemeStyle))
                    {
                        connectorVm.Constraints |= ConnectorConstraints.ThemeStyle;
                    }
                }

                this.SelectedDiagram.Theme = galleryItem.Theme;
            }

            else if (galleryItem != null && galleryItem.Content is GalleryStyle && this.SelectedDiagram.NodeCollection != null)
            {
                foreach (var nodeVm in this.SelectedDiagram.NodeCollection)
                {
                    if (!nodeVm.Constraints.Contains(NodeConstraints.ThemeStyle))
                    {
                        nodeVm.Constraints |= NodeConstraints.ThemeStyle;
                    }
                }

                foreach (var connectorVm in this.SelectedDiagram.ConnectorCollection)
                {
                    if (!connectorVm.Constraints.Contains(ConnectorConstraints.ThemeStyle))
                    {
                        connectorVm.Constraints |= ConnectorConstraints.ThemeStyle;
                    }
                }

                this.SelectedDiagram.Theme = galleryItem.Theme;
            }

            else
            {
                if (selectedItem.IsNodeSelected)
                {
                    Style stye = new Style();
                    stye.TargetType = typeof(Path);
                    if (s != null)
                    {
                        foreach (Setter set in s.Setters)
                        {
                            if (set.Property == Shape.FillProperty)
                            {
                                stye.Setters.Add(new Setter(Shape.FillProperty, (Brush)set.Value));
                                selectedItem.QuickFill = (Brush)set.Value;
                            }
                            else if (set.Property == Shape.StrokeProperty)
                            {
                                stye.Setters.Add(new Setter(Shape.StrokeProperty, (Brush)set.Value));
                            }
                            else if (set.Property == Shape.StrokeThicknessProperty)
                            {
                                stye.Setters.Add(new Setter(Shape.StrokeThicknessProperty, (double)set.Value));
                            }
                            else if (set.Property == FrameworkElement.TagProperty)
                            {
                                BrushConverter converter = new BrushConverter();
                                Brush brush = (Brush)converter.ConvertFromString(set.Value.ToString());
                                selectedItem.LabelForeground = brush;
                            }
                        }
                    }

                    selectedItem.Style = stye;
                    selectedItem.NodeGalleryName = obj.ToString();
                }
                else if (selectedItem.IsConnectorSelected)
                {
                    Style stye = new Style();
                    stye.TargetType = typeof(Path);
                    foreach (Setter set in s.Setters)
                    {
                        if (set.Property == Shape.StrokeProperty)
                        {
                            stye.Setters.Add(new Setter(Shape.StrokeProperty, (Brush)set.Value));
                            selectedItem.Stroke = (Brush)set.Value;
                        }
                        else if (set.Property == Shape.StrokeThicknessProperty)
                        {
                            stye.Setters.Add(new Setter(Shape.StrokeThicknessProperty, (double)set.Value));
                        }
                        else if (set.Property == Shape.StrokeDashArrayProperty)
                        {
                            stye.Setters.Add(new Setter(Shape.StrokeDashArrayProperty, set.Value));
                        }
                    }

                    selectedItem.Style = stye;
                    selectedItem.ConnectorGalleryName = obj.ToString();
                }
            }

            // GroupTransactions group1 = new GroupTransactions();
            // group1.ContinuousUndoRedo = ContinuousUndoRedo.End;
            // (SelectedDiagram as DiagramVM).HistoryManager.EndComposite((SelectedDiagram as DiagramVM).HistoryManager, group1);
        }

        /// <summary>
        /// The on ribbon command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnRibbonCommand(object obj)
        {
        }

        /// <summary>
        ///     Method to execute the sendtoback command
        /// </summary>
        private void OnSendBackEnabled()
        {
            if (this.IsSendBackEnable)
            {
                (this.SelectedDiagram.Info as IGraphInfo).Commands.SendToBack.Execute(null);
                this.IsSendBackEnable = false;
            }
        }

        /// <summary>
        /// The on variant style command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnVariantStyleCommand(object obj)
        {
            if (obj != null && obj is DesignVariantRibbonGalleryItem && this.SelectedDiagram.NodeCollection != null)
            {
                foreach (var nodeVm in this.SelectedDiagram.NodeCollection)
                {
                    if (!nodeVm.Constraints.Contains(NodeConstraints.ThemeStyle))
                    {
                        nodeVm.Constraints |= NodeConstraints.ThemeStyle;
                    }
                }

                foreach (var connectorVm in this.SelectedDiagram.ConnectorCollection)
                {
                    if (!connectorVm.Constraints.Contains(ConnectorConstraints.ThemeStyle))
                    {
                        connectorVm.Constraints |= ConnectorConstraints.ThemeStyle;
                    }
                }

                var galleryItem = obj as DesignVariantRibbonGalleryItem;
                if (galleryItem.Content != null)
                {
                    this.SelectedDiagram.Theme.NodeStyles =
                        galleryItem.Content as Dictionary<StyleId, DiagramItemStyle>;
                }

                if (galleryItem.ConnectorVariant != null)
                {
                    this.SelectedDiagram.Theme.ConnectorStyles = galleryItem.ConnectorVariant;
                }
            }
        }

        /// <summary>
        ///     The save all diagrams.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        private async Task SaveAllDiagrams()
        {
            foreach (DiagramVM diagram in this.Diagrams)
            {
                await diagram.Save(null);
            }
        }

        void CreateOrganizationChartDiagram(string file)
        {
            OrganizationChartDiagramVM neworganizationchart = GetNewOrganizationChart(file, false);
            Diagrams.Add(neworganizationchart);     
            Ribbon.SelectedIndex = 0;
            SelectedDiagram = neworganizationchart;
        }

        private OrganizationChartDiagramVM GetNewOrganizationChart(string file, bool isValidXml)
        {
            OrganizationChartDiagramVM diagram = new OrganizationChartDiagramVM(file, isValidXml);
            if (_mDrawConnector)
            {
                diagram.DrawingTool = DrawingTool.Connector;
                diagram.Tool = Tool.ContinuesDraw;
                diagram.DefaultConnectorType = ConnectorType.Orthogonal;
            }
            else if (_mDrawTextNode)
            {
                diagram.Tool = Tool.ContinuesDraw;
                diagram.DrawingTool = DrawingTool.Node;
                diagram.IsDrawTextNode = true;
            }
            else if (_mIsDrawingToolEnable)
            {

                if (diagram.Shape.Equals("Line"))
                {
                    diagram.Tool = Tool.ContinuesDraw;
                   diagram.DrawingTool = DrawingTool.Connector;
                    diagram.IsDrawTextNode = false;
                    diagram.DefaultConnectorType = ConnectorType.Line;
                }
                else if (diagram.Shape.Equals("Rectangle"))
                {
                    diagram.Tool = Tool.ContinuesDraw;
                    diagram.DrawingTool = DrawingTool.Node;
                    diagram.IsDrawTextNode = false;
                }
            }
            else if (_mPortVisible)
            {
                diagram.PortVisibility = PortVisibility.Visible;
            }
            diagram.Delete = Delete;
            diagram.PropertyChanged += (s, e) =>
            {
                DiagramVM sender = s as DiagramVM;
                if (e.PropertyName == "IsSelected")
                {
                    if (sender.IsSelected)
                    { 
                        this.SelectedDiagram = sender;
                    }
                }
            };
            return diagram;
        }

        void CreateOrganizationChartDiagramOnLoad(string file, bool value)
        {
            OrganizationChart.ViewModel.OrganizationChartDiagramVM newDiagram = GetNewOrganizationChart(file, true);
            Ribbon.SelectedIndex = 0;
            RetainPageSettingsOnLoad(newDiagram);
            SelectedDiagram = newDiagram;
            Diagrams.Add(newDiagram);
        }

        void RetainPageSettingsOnLoad(DiagramVM loadedDiagram)
        {
            if (SelectedDiagram != null)
            {
                var oldPageVM = SelectedDiagram.PageSettings as PageVM;
                var newPageVM = loadedDiagram.PageSettings as PageVM;
                newPageVM.Ruler = oldPageVM.Ruler;
                newPageVM.GridLines = oldPageVM.GridLines;
                newPageVM.ShowPageBreaks = oldPageVM.ShowPageBreaks;
                newPageVM.SnapToGrid = oldPageVM.SnapToGrid;
                newPageVM.SnapToObject = oldPageVM.SnapToObject;
                newPageVM.MultiplePage = oldPageVM.MultiplePage;
            }
        }
    }
}