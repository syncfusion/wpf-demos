// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectorVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents a visual representation of selected elements. It behaves like a container for single or multiple
//   selected elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    using DiagramBuilder.Utility;
    using OrganizationChart.ViewModel;
    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     Represents a visual representation of selected elements. It behaves like a container for single or multiple
    ///     selected elements.
    /// </summary>
    public class SelectorVM : SelectorViewModel, ISelectorVM
    {
        /// <summary>
        ///     The _m allow drag.
        /// </summary>
        private bool? allowdrag = true;

        /// <summary>
        ///     The _m allow resize.
        /// </summary>
        private bool? allowresize = true;

        /// <summary>
        ///     The _m allow rotate.
        /// </summary>
        private bool? allowrotate = true;

        /// <summary>
        ///     The _m angle.
        /// </summary>
        private double? angle = 0d;

        /// <summary>
        ///     The _m anything selected.
        /// </summary>
        private bool anythingselected;

        /// <summary>
        ///     The _m aspect ratio.
        /// </summary>
        private bool? aspectratio = true;

        /// <summary>
        ///     Represents the text in bold.
        /// </summary>
        private bool bold;

        /// <summary>
        ///     The _m bottom.
        /// </summary>
        private bool bottom;

        /// <summary>
        ///     The _m bottom left.
        /// </summary>
        private bool bottomleft;

        /// <summary>
        ///     The _m bottom right.
        /// </summary>
        private bool bottomright;

        /// <summary>
        ///     The _m center.
        /// </summary>
        private bool center;

        /// <summary>
        ///     The _close color picker palette command.
        /// </summary>
        private ICommand closeColorPickerPaletteCommand;

        /// <summary>
        ///     The _mConnector gallary name.
        /// </summary>
        private string connectorgalleryname;

        /// <summary>
        ///     The _current brush.
        /// </summary>
        private CurrentBrush currentbrush;

        /// <summary>
        ///     The _m dash dot.
        /// </summary>
        private string dashdot;

        /// <summary>
        ///     The mdashDotCommand.
        /// </summary>
        private ICommand dashdotcommand;

        /// <summary>
        ///     The _decorator.
        /// </summary>
        private ICommand decorator;

        /// <summary>
        ///     The _m font size.
        /// </summary>
        private int? fontsize = 8;

        /// <summary>
        ///     The _m font style.
        /// </summary>
        private FontStyle? fontstyle;

        /// <summary>
        ///     The _m font weight.
        /// </summary>
        private FontWeight? fontweight;

        /// <summary>
        ///     The _m height.
        /// </summary>
        private double? height = double.NaN;

        /// <summary>
        ///     The _m hold label alignment.
        /// </summary>
        private bool holdlabelalignment;

        /// <summary>
        ///     The _m hyper link.
        /// </summary>
        private string hyperlink = "http://";

        /// <summary>
        ///     The _is brush editing.
        /// </summary>
        private Visibility isbrushediting = Visibility.Collapsed;

        /// <summary>
        ///     The _m is connector label set.
        /// </summary>
        private bool isCcnnectorlabelset = false;

        /// <summary>
        ///     The _m is connector selected.
        /// </summary>
        private bool isconnectorselected;

        /// <summary>
        ///     The _m is label set.
        /// </summary>
        private bool islabelset;

        /// <summary>
        ///     The _m is node label set.
        /// </summary>
        private bool isnodelabelset;

        /// <summary>
        ///     The _m is node selected.
        /// </summary>
        private bool isnodeselected;

        /// <summary>
        ///     Represents the text in italic.
        /// </summary>
        private bool italic;

        /// <summary>
        ///     The _m label background.
        /// </summary>
        private Brush labelbackground;

        /// <summary>
        ///     The _m label foreground.
        /// </summary>
        private Brush labelforeground = new SolidColorBrush(Colors.Aqua);

        /// <summary>
        ///     The _m label h align.
        /// </summary>
        private HorizontalAlignment? labelhalign;

        /// <summary>
        ///     The _m label margin.
        /// </summary>
        private double? labelmargin;

        /// <summary>
        ///     The _m label v align.
        /// </summary>
        private VerticalAlignment? labelvalign;

        /// <summary>
        ///     The _m left.
        /// </summary>
        private bool left;

        /// <summary>
        ///     The _m bold.
        /// </summary>
        private bool? mbold = false;

        /// <summary>
        ///     The _m decorator.
        /// </summary>
        private string mdecorator;

        /// <summary>
        ///     The _m fill.
        /// </summary>
        private Brush mfill;

        /// <summary>
        ///     The _m font.
        /// </summary>
        private FontFamily mfont = new FontFamily("Segoe UI");

        /// <summary>
        ///     Represents the font value of the text.
        /// </summary>
        private int? mFontValue = 0;

        /// <summary>
        ///     The _m middle.
        /// </summary>
        private bool middle;

        /// <summary>
        ///     The _m italic.
        /// </summary>
        private bool? mitalic = false;

        /// <summary>
        ///     The _m label.
        /// </summary>
        private string mlabel = string.Empty;

        /// <summary>
        ///     The _m strike.
        /// </summary>
        private bool? mstrike = false;

        /// <summary>
        ///     The _m stroke.
        /// </summary>
        private Brush mstroke;

        /// <summary>
        ///     The _m style.
        /// </summary>
        private Style mstyle;

        /// <summary>
        ///     The _m target cap.
        /// </summary>
        private string mtargetcap;

        /// <summary>
        ///     The _m text alignment.
        /// </summary>
        private TextAlignment? mtextalignment;

        /// <summary>
        ///     The _m thickness.
        /// </summary>
        private double? mthickness = 1d;

        /// <summary>
        ///     The _m tool tip constraint.
        /// </summary>
        private string mtooltipconstraint = "Default";

        /// <summary>
        ///     The mTop.
        /// </summary>
        private bool mtop;

        /// <summary>
        ///     The _m top left.
        /// </summary>
        private bool mtopleft;

        /// <summary>
        ///     The _m top right.
        /// </summary>
        private bool mtopright;

        /// <summary>
        ///     Represents the ConnectType.
        /// </summary>
        private ConnectType? mtype = ConnectType.Straight;

        /// <summary>
        ///     Represents the Underline.
        /// </summary>
        private bool mUnderline;

        /// <summary>
        ///     Represents the visibility.
        /// </summary>
        private bool? mvisible;

        /// <summary>
        ///     Represents the _m width value.
        /// </summary>
        private double? mwidth = double.NaN;

        /// <summary>
        ///     Represents the _m x value.
        /// </summary>
        private double? mX = 0d;

        /// <summary>
        ///     Represents the _m y value.
        /// </summary>
        private double? mY = 0d;

        /// <summary>
        ///     The _m name.
        /// </summary>
        private string name = string.Empty;

        /// <summary>
        ///     The _mNode gallary name.
        /// </summary>
        private string nodegalleryname;

        /// <summary>
        ///     The _m opacity.
        /// </summary>
        private double? opacity;

        /// <summary>
        ///     Represents the _picked brush.
        /// </summary>
        private Brush pickedBrush;

        /// <summary>
        ///     Represents the _picker command.
        /// </summary>
        private ICommand pickerCommand;

        /// <summary>
        ///     The _m px.
        /// </summary>
        private double? px = 0d;

        /// <summary>
        ///     The _m py.
        /// </summary>
        private double? py = 0d;

        /// <summary>
        ///     The _m quick fill.
        /// </summary>
        private Brush quickfill;

        /// <summary>
        ///     The _m right.
        /// </summary>
        private bool right;

        /// <summary>
        ///     The _m rotate text.
        /// </summary>
        private bool? rotatetext = false;

        /// <summary>
        ///     The _m scale.
        /// </summary>
        private double scale = 1d;

        /// <summary>
        ///     Represents the selected items.
        /// </summary>
        private List<IGroupableVM> SelectedItems = new List<IGroupableVM>();

        /// <summary>
        ///     The _m selected port.
        /// </summary>
        private IPort selectedport;

        /// <summary>
        ///     The _m source cap.
        /// </summary>
        private string sourcecap;

        /// <summary>
        ///     Represents the text with strike.
        /// </summary>
        private bool strike;

        /// <summary>
        ///     Represents the _text aligned at center.
        /// </summary>
        private bool textCenter;

        /// <summary>
        ///     Represents the _text aligned at left.
        /// </summary>
        private bool textLeft;

        /// <summary>
        ///     Represents the _text aligned at right.
        /// </summary>
        private bool textRight;

        /// <summary>
        ///     Represents the underline of the text.
        /// </summary>
        private bool underline;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorVM"/> class.
        /// </summary>
        /// <param name="diagram">
        /// The diagram.
        /// </param>
        public SelectorVM(DiagramVM diagram)
        {
            this.Diagram = diagram;
            this.Diagram.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == "Info")
                    {
                        IGraphInfo graphInfo = this.Diagram.Info as IGraphInfo;
                        if (graphInfo != null)
                        {
                            graphInfo.ItemSelectedEvent += this.ItemSelectedEvent;
                            graphInfo.ItemUnSelectedEvent += this.ItemUnSelectedEvent;
                            graphInfo.ViewPortChangedEvent += this.SelectorVM_ViewPortChangedEvent;
                            graphInfo.ItemTappedEvent += this.SelectorVM_ItemTappedEvent;
                        }
                    }
                };
            this.PickerCommand = new Command(param => this.CurrentBrush = (CurrentBrush)param);
            this.DecoratorCommand = new DelegateCommand(this.OnDecoratorChanged, args => { return true; });
            this.DashDotCommand = new DelegateCommand(this.OnDashDotCommand, args => { return true; });
            this.CloseColorPickerPaletteCommand = new DelegateCommand(
                this.OnCloseColorPickerPaletteCommand,
                args => { return true; });
            this.Diagram = diagram;
            this.GrowFont = new Command(this.OnGrowCommand);
            this.ShrinkFont = new Command(this.OnShrinkCommand);
            this.ThicknessCommand = new Command(this.OnThicknessCommand);
        }

        /// <summary>
        ///     Gets or sets the allow drag option for node.
        /// </summary>
        public bool? AllowDrag
        {
            get
            {
                return this.allowdrag;
            }

            set
            {
                if (this.allowdrag != value)
                {
                    this.allowdrag = value;
                    this.OnPropertyChanged(NodeConstants.AllowDrag);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the allow resize option for node.
        /// </summary>
        public bool? AllowResize
        {
            get
            {
                return this.allowresize;
            }

            set
            {
                if (this.allowresize != value)
                {
                    this.allowresize = value;
                    this.OnPropertyChanged(NodeConstants.AllowResize);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the allow rotate option for node.
        /// </summary>
        public bool? AllowRotate
        {
            get
            {
                return this.allowrotate;
            }

            set
            {
                if (this.allowrotate != value)
                {
                    this.allowrotate = value;
                    this.OnPropertyChanged(NodeConstants.AllowRotate);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the angle of the node.
        /// </summary>
        public double? Angle
        {
            get
            {
                return this.angle;
            }

            set
            {
                if (this.angle != value)
                {
                    this.angle = value;
                    this.OnPropertyChanged(SelectorConstants.Angle);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the aspect ratio of the node.
        /// </summary>
        public bool? AspectRatio
        {
            get
            {
                return this.aspectratio;
            }

            set
            {
                if (this.aspectratio != value)
                {
                    this.aspectratio = value;
                    this.OnPropertyChanged(NodeConstants.AspectRatio);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font weight bold.
        /// </summary>
        public bool? Bold
        {
            get
            {
                return this.mbold;
            }

            set
            {
                if (this.mbold != value)
                {
                    this.mbold = value;
                    this.OnPropertyChanged(GroupableConstants.Bold);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether bottom.
        /// </summary>
        public bool Bottom
        {
            get
            {
                return this.bottom;
            }

            set
            {
                if (this.bottom != value)
                {
                    this.bottom = value;
                    this.OnPropertyChanged(GroupableConstants.Bottom);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether bottom left.
        /// </summary>
        public bool BottomLeft
        {
            get
            {
                return this.bottomleft;
            }

            set
            {
                if (this.bottomleft != value)
                {
                    this.bottomleft = value;
                    this.OnPropertyChanged(GroupableConstants.BottomLeft);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether bottom right.
        /// </summary>
        public bool BottomRight
        {
            get
            {
                return this.bottomright;
            }

            set
            {
                if (this.bottomright != value)
                {
                    this.bottomright = value;
                    this.OnPropertyChanged(GroupableConstants.BottomRight);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether center.
        /// </summary>
        public bool Center
        {
            get
            {
                return this.center;
            }

            set
            {
                if (this.center != value)
                {
                    this.center = value;
                    this.OnPropertyChanged(GroupableConstants.Center);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the close color picker palette command.
        /// </summary>
        public ICommand CloseColorPickerPaletteCommand
        {
            get
            {
                return this.closeColorPickerPaletteCommand;
            }

            set
            {
                if (this.closeColorPickerPaletteCommand != value)
                {
                    this.closeColorPickerPaletteCommand = value;
                    this.OnPropertyChanged("CloseColorPickerPaletteCommand");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the connector gallary name.
        /// </summary>
        public string ConnectorGalleryName
        {
            get
            {
                return this.connectorgalleryname;
            }

            set
            {
                if (this.connectorgalleryname != value)
                {
                    if (value != null && value.Contains("Syncfusion.Windows.Tools.Controls.RibbonGalleryItem:"))
                    {
                        this.connectorgalleryname = value.Remove(0, 53);
                    }
                    else
                    {
                        this.connectorgalleryname = value;
                    }

                    this.OnPropertyChanged(SelectorConstants.ConnectorGalleryName);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the current brush.
        /// </summary>
        public CurrentBrush CurrentBrush
        {
            get
            {
                return this.currentbrush;
            }

            set
            {
                if (this.currentbrush != value)
                {
                    this.currentbrush = value;
                    this.OnPropertyChanged(SelectorConstants.CurrentBrush);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the dash dot.
        /// </summary>
        public string DashDot
        {
            get
            {
                return this.dashdot;
            }

            set
            {
                if (this.dashdot != value)
                {
                    this.dashdot = value;
                    this.OnPropertyChanged(GroupableConstants.DashDot);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the dash dot command.
        /// </summary>
        public ICommand DashDotCommand
        {
            get
            {
                return this.dashdotcommand;
            }

            set
            {
                if (this.dashdotcommand != value)
                {
                    this.dashdotcommand = value;
                    this.OnPropertyChanged(SelectorConstants.DashDotCommand);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the decorator.
        /// </summary>
        public string Decorator
        {
            get
            {
                return this.mdecorator;
            }

            set
            {
                if (this.mdecorator != value)
                {
                    this.mdecorator = value;
                    this.OnPropertyChanged(ConnectorConstants.Decorator);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the decorator command.
        /// </summary>
        public ICommand DecoratorCommand
        {
            get
            {
                return this.decorator;
            }

            set
            {
                if (this.decorator != value)
                {
                    this.decorator = value;
                    this.OnPropertyChanged(SelectorConstants.DecoratorCommand);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the diagram viewmodel.
        /// </summary>
        public DiagramVM Diagram { get; set; }

        /// <summary>
        ///     Gets or sets the fill value.
        /// </summary>
        public Brush Fill
        {
            get
            {
                return this.mfill;
            }

            set
            {
                if (this.mfill != value)
                {
                    this.mfill = value;
                    this.OnPropertyChanged(NodeConstants.Fill);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font value.
        /// </summary>
        public FontFamily Font
        {
            get
            {
                return this.mfont;
            }

            set
            {
                if (this.mfont != value)
                {
                    this.mfont = value;
                    this.OnPropertyChanged(GroupableConstants.Font);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font size.
        /// </summary>
        public int? FontSize
        {
            get
            {
                return this.fontsize;
            }

            set
            {
                if (this.fontsize != value)
                {
                    this.fontsize = value;
                    this.OnPropertyChanged(GroupableConstants.FontSize);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font style.
        /// </summary>
        public FontStyle? FontStyle
        {
            get
            {
                return this.fontstyle;
            }

            set
            {
                if (this.fontstyle != value)
                {
                    this.fontstyle = value;
                    this.OnPropertyChanged(GroupableConstants.FontStyle);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font value.
        /// </summary>
        public int? FontValue
        {
            get
            {
                return this.mFontValue;
            }

            set
            {
                this.mFontValue = value;
                this.OnPropertyChanged(SelectorConstants.FontValue);
            }
        }

        /// <summary>
        ///     Gets or sets the font weight.
        /// </summary>
        public FontWeight? FontWeight
        {
            get
            {
                return this.fontweight;
            }

            set
            {
                {
                    // if (_mFontWeight != value)
                    this.fontweight = value;
                    this.OnPropertyChanged(GroupableConstants.FontWeight);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the grow font.
        /// </summary>
        public ICommand GrowFont { get; set; }

        /// <summary>
        ///     Gets or sets the height of the selector.
        /// </summary>
        public double? Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (this.height != value && !(this.height.HasValue && double.IsNaN(this.height.Value) && value.HasValue
                                              && double.IsNaN(value.Value)))
                {
                    this.height = value;
                    this.OnPropertyChanged(SelectorConstants.Height);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the hyper link.
        /// </summary>
        public string HyperLink
        {
            get
            {
                return this.hyperlink;
            }

            set
            {
                if (this.hyperlink != value)
                {
                    this.hyperlink = value;
                    this.OnPropertyChanged(GroupableConstants.HyperLink);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is anything selected.
        /// </summary>
        public bool IsAnythingSelected
        {
            get
            {
                return this.anythingselected;
            }

            set
            {
                if (this.anythingselected != value)
                {
                    this.anythingselected = value;
                    this.OnPropertyChanged(SelectorConstants.IsAnythingSelected);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the is brush editing.
        /// </summary>
        public Visibility IsBrushEditing
        {
            get
            {
                return this.isbrushediting;
            }

            set
            {
                if (this.isbrushediting != value)
                {
                    this.isbrushediting = value;
                    this.OnPropertyChanged(SelectorConstants.IsBrushEditing);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is connector label set.
        /// </summary>
        public bool IsConnectorLabelSet
        {
            get
            {
                return this.isCcnnectorlabelset;
            }

            set
            {
                if (this.isCcnnectorlabelset != value)
                {
                    this.isconnectorselected = value;
                    this.OnPropertyChanged(SelectorConstants.IsConnectorLabelSet);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether connector is selected.
        /// </summary>
        public bool IsConnectorSelected
        {
            get
            {
                return this.isconnectorselected;
            }

            set
            {
                if (this.isconnectorselected != value)
                {
                    this.isconnectorselected = value;
                    this.OnPropertyChanged(SelectorConstants.IsConnectorSelected);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether label is set.
        /// </summary>
        public bool IsLabelSet
        {
            get
            {
                return this.islabelset;
            }

            set
            {
                if (this.islabelset != value)
                {
                    this.islabelset = value;
                    this.OnPropertyChanged(SelectorConstants.IsLabelSet);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether node label is set.
        /// </summary>
        public bool IsNodeLabelSet
        {
            get
            {
                return this.isnodelabelset;
            }

            set
            {
                if (this.isnodelabelset != value)
                {
                    this.isnodelabelset = value;
                    this.OnPropertyChanged(SelectorConstants.IsNodeLabelSet);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether node is selected.
        /// </summary>
        public bool IsNodeSelected
        {
            get
            {
                return this.isnodeselected;
            }

            set
            {
                if (this.isnodeselected != value)
                {
                    this.isnodeselected = value;
                    this.OnPropertyChanged(SelectorConstants.IsNodeSelected);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the italic style.
        /// </summary>
        public bool? Italic
        {
            get
            {
                return this.mitalic;
            }

            set
            {
                if (this.mitalic != value)
                {
                    this.mitalic = value;
                    this.OnPropertyChanged(GroupableConstants.Italic);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label.
        /// </summary>
        public string Label
        {
            get
            {
                return this.mlabel;
            }

            set
            {
                if (this.mlabel != value)
                {
                    this.mlabel = value;
                    this.OnPropertyChanged(GroupableConstants.Label);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label background.
        /// </summary>
        public Brush LabelBackground
        {
            get
            {
                return this.labelbackground;
            }

            set
            {
                if (this.labelbackground != value)
                {
                    this.labelbackground = value;
                    this.OnPropertyChanged(GroupableConstants.LabelBackground);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label foreground.
        /// </summary>
        public Brush LabelForeground
        {
            get
            {
                return this.labelforeground;
            }

            set
            {
                if (this.labelforeground != value)
                {
                    this.labelforeground = value;
                    this.OnPropertyChanged(GroupableConstants.LabelForeground);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the horizontal alignment of the label.
        /// </summary>
        public HorizontalAlignment? LabelHAlign
        {
            get
            {
                return this.labelhalign;
            }

            set
            {
                if (this.labelhalign != value)
                {
                    this.labelhalign = value;
                    this.OnPropertyChanged(GroupableConstants.LabelHAlign);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label margin.
        /// </summary>
        public double? LabelMargin
        {
            get
            {
                return this.labelmargin;
            }

            set
            {
                if (this.labelmargin != value)
                {
                    this.labelmargin = value;
                    this.OnPropertyChanged(GroupableConstants.LabelMargin);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the vertical alignment of the label.
        /// </summary>
        public VerticalAlignment? LabelVAlign
        {
            get
            {
                return this.labelvalign;
            }

            set
            {
                if (this.labelvalign != value)
                {
                    this.labelvalign = value;
                    this.OnPropertyChanged(GroupableConstants.LabelVAlign);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label alignment as left.
        /// </summary>
        public bool Left
        {
            get
            {
                return this.left;
            }

            set
            {
                if (this.left != value)
                {
                    this.left = value;
                    this.OnPropertyChanged(GroupableConstants.Left);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label alignment as middle.
        /// </summary>
        public bool Middle
        {
            get
            {
                return this.middle;
            }

            set
            {
                if (this.middle != value)
                {
                    this.middle = value;
                    this.OnPropertyChanged(GroupableConstants.Middle);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the name of the label.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged(GroupableConstants.Name);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the node gallary name.
        /// </summary>
        public string NodeGalleryName
        {
            get
            {
                return this.nodegalleryname;
            }

            set
            {
                if (this.nodegalleryname != value)
                {
                    if (value != null && value.Contains("Syncfusion.Windows.Tools.Controls.RibbonGalleryItem:"))
                    {
                        this.nodegalleryname = value.Remove(0, 53);
                    }
                    else
                    {
                        this.nodegalleryname = value;
                    }

                    this.OnPropertyChanged(SelectorConstants.NodeGalleryName);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the opacity.
        /// </summary>
        public double? Opacity
        {
            get
            {
                return this.opacity;
            }

            set
            {
                if (this.opacity != value)
                {
                    this.opacity = value;
                    this.OnPropertyChanged(GroupableConstants.Opacity);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the picked brush.
        /// </summary>
        public Brush PickedBrush
        {
            get
            {
                return this.pickedBrush;
            }

            set
            {
                if (this.pickedBrush != value)
                {
                    this.pickedBrush = value;
                    this.OnPropertyChanged(SelectorConstants.PickedBrush);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the picker command.
        /// </summary>
        public ICommand PickerCommand
        {
            get
            {
                return this.pickerCommand;
            }

            set
            {
                if (this.pickerCommand != value)
                {
                    this.pickerCommand = value;
                    this.OnPropertyChanged(SelectorConstants.PickerCommand);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the px value.
        /// </summary>
        public double? Px
        {
            get
            {
                return this.px;
            }

            set
            {
                if (this.px != value)
                {
                    this.px = value;
                    this.OnPropertyChanged(SelectorConstants.Px);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the py value.
        /// </summary>
        public double? Py
        {
            get
            {
                return this.py;
            }

            set
            {
                if (this.py != value)
                {
                    this.py = value;
                    this.OnPropertyChanged(SelectorConstants.Py);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the quick fill.
        /// </summary>
        public Brush QuickFill
        {
            get
            {
                return this.quickfill;
            }

            set
            {
                if (this.quickfill != value)
                {
                    this.quickfill = value;
                    this.OnPropertyChanged(SelectorConstants.QuickFill);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether right.
        /// </summary>
        public bool Right
        {
            get
            {
                return this.right;
            }

            set
            {
                if (this.right != value)
                {
                    this.right = value;
                    this.OnPropertyChanged(GroupableConstants.Right);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the value indicating whether text can rotate.
        /// </summary>
        public bool? RotateText
        {
            get
            {
                return this.rotatetext;
            }

            set
            {
                if (this.rotatetext != value)
                {
                    this.rotatetext = value;
                    this.OnPropertyChanged(GroupableConstants.RotateText);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the scale value.
        /// </summary>
        public double Scale
        {
            get
            {
                return this.scale;
            }

            set
            {
                if (this.scale != value)
                {
                    this.scale = value;
                    this.OnPropertyChanged(SelectorConstants.Scale);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the selected port.
        /// </summary>
        public IPort SelectedPort
        {
            get
            {
                return this.selectedport;
            }

            set
            {
                if (this.selectedport != value)
                {
                    if (value == null)
                    {
                        (this.selectedport as NodePortVM).IsSelected = false;
                    }
                    else
                    {
                        (value as NodePortVM).IsSelected = true;
                    }

                    this.selectedport = value;
                    this.OnPropertyChanged("SelectedPort");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the shrink font.
        /// </summary>
        public ICommand ShrinkFont { get; set; }

        /// <summary>
        ///     Gets or sets the source cap to the text.
        /// </summary>
        public string SourceCap
        {
            get
            {
                return this.sourcecap;
            }

            set
            {
                if (this.sourcecap != value)
                {
                    this.sourcecap = value;
                    this.OnPropertyChanged(ConnectorConstants.SourceCap);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the strike the text.
        /// </summary>
        public bool? Strike
        {
            get
            {
                return this.mstrike;
            }

            set
            {
                if (this.mstrike != value)
                {
                    this.mstrike = value;
                    this.OnPropertyChanged(GroupableConstants.Strike);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the stroke color of the text.
        /// </summary>
        public Brush Stroke
        {
            get
            {
                return this.mstroke;
            }

            set
            {
                if (this.mstroke != value)
                {
                    this.mstroke = value;
                    this.OnPropertyChanged(GroupableConstants.Stroke);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the style.
        /// </summary>
        public Style Style
        {
            get
            {
                return this.mstyle;
            }

            set
            {
                if (this.mstyle != value)
                {
                    this.mstyle = value;
                    this.OnPropertyChanged(GroupableConstants.Style);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the target cap of the connector.
        /// </summary>
        public string TargetCap
        {
            get
            {
                return this.mtargetcap;
            }

            set
            {
                if (this.mtargetcap != value)
                {
                    this.mtargetcap = value;
                    this.OnPropertyChanged(ConnectorConstants.TargetCap);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the text alignment.
        /// </summary>
        public TextAlignment? TextAlignment
        {
            get
            {
                return this.mtextalignment;
            }

            set
            {
                if (this.mtextalignment != value)
                {
                    this.mtextalignment = value;
                    this.OnPropertyChanged(GroupableConstants.TextAlignment);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether text can align at center.
        /// </summary>
        public bool TextCenter
        {
            get
            {
                return this.textCenter;
            }

            set
            {
                if (this.textCenter != value)
                {
                    this.textCenter = value;
                    this.OnPropertyChanged(GroupableConstants.TextCenter);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether text can align at left.
        /// </summary>
        public bool TextLeft
        {
            get
            {
                return this.textLeft;
            }

            set
            {
                if (this.textLeft != value)
                {
                    this.textLeft = value;
                    this.OnPropertyChanged(GroupableConstants.TextLeft);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether text can align at right.
        /// </summary>
        public bool TextRight
        {
            get
            {
                return this.textRight;
            }

            set
            {
                if (this.textRight != value)
                {
                    this.textRight = value;
                    this.OnPropertyChanged(GroupableConstants.TextRight);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the thickness.
        /// </summary>
        public double? Thickness
        {
            get
            {
                return this.mthickness;
            }

            set
            {
                if (this.mthickness != value)
                {
                    this.mthickness = value;
                    this.OnPropertyChanged(GroupableConstants.Thickness);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the thickness command.
        /// </summary>
        public ICommand ThicknessCommand { get; set; }

        /// <summary>
        ///     Gets or sets the tool tip constraint.
        /// </summary>
        public string ToolTipConstraint
        {
            get
            {
                return this.mtooltipconstraint;
            }

            set
            {
                if (this.mtooltipconstraint != value)
                {
                    this.mtooltipconstraint = value;
                    this.OnPropertyChanged(SelectorConstants.ToolTipConstraint);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether text can align at top.
        /// </summary>
        public bool Top
        {
            get
            {
                return this.mtop;
            }

            set
            {
                if (this.mtop != value)
                {
                    this.mtop = value;
                    this.OnPropertyChanged(GroupableConstants.Top);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether text can align at top left.
        /// </summary>
        public bool TopLeft
        {
            get
            {
                return this.mtopleft;
            }

            set
            {
                if (this.mtopleft != value)
                {
                    this.mtopleft = value;
                    this.OnPropertyChanged(GroupableConstants.TopLeft);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether text can align at top right.
        /// </summary>
        public bool TopRight
        {
            get
            {
                return this.mtopright;
            }

            set
            {
                if (this.mtopright != value)
                {
                    this.mtopright = value;
                    this.OnPropertyChanged(GroupableConstants.TopRight);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the type of the connector.
        /// </summary>
        public ConnectType? Type
        {
            get
            {
                return this.mtype;
            }

            set
            {
                if (this.mtype != value)
                {
                    this.mtype = value;
                    this.OnPropertyChanged(ConnectorConstants.Type);
                }
            }
        }

        /// <summary>
        ///     Gets or sets under line the text.
        /// </summary>
        public bool? UnderLine
        {
            get
            {
                return this.mUnderline;
            }

            set
            {
                if (this.mUnderline != value)
                {
                    this.mUnderline = (bool)value;
                    this.OnPropertyChanged(GroupableConstants.UnderLine);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the Visibility.
        /// </summary>
        public bool? Visible
        {
            get
            {
                return this.mvisible;
            }

            set
            {
                if (this.mvisible != value)
                {
                    this.mvisible = value;
                    this.OnPropertyChanged(GroupableConstants.Visibility);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        public double? Width
        {
            get
            {
                return this.mwidth;
            }

            set
            {
                if (this.mwidth != value && !(this.mwidth.HasValue && double.IsNaN(this.mwidth.Value) && value.HasValue
                                              && double.IsNaN(value.Value)))
                {
                    this.mwidth = value;
                    this.OnPropertyChanged(SelectorConstants.Width);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the x value.
        /// </summary>
        public double? X
        {
            get
            {
                return this.mX;
            }

            set
            {
                if (this.mX != value)
                {
                    this.mX = value;
                    this.OnPropertyChanged(SelectorConstants.X);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the y value.
        /// </summary>
        public double? Y
        {
            get
            {
                return this.mY;
            }

            set
            {
                if (this.mY != value)
                {
                    this.mY = value;
                    this.OnPropertyChanged(SelectorConstants.Y);
                }
            }
        }

        /// <summary>
        ///     Clear the selected items from the selection.
        /// </summary>
        public void Clear()
        {
            List<IGroupableVM> local = new List<IGroupableVM>();
            foreach (IGroupableVM item in this.SelectedItems)
            {
                local.Add(item);
            }

            foreach (IGroupableVM item in local)
            {
                (item as IGroupable).IsSelected = false;
            }

            this.Annotation = null;
            this.SelectedPort = null;
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
            switch (name)
            {
                case SelectorConstants.ToolTipConstraint:
                    this.OnToolTipConstraintsChanged();
                    break;
                case NodeConstants.AllowDrag:
                    this.OnAllowDragChanged();
                    break;
                case NodeConstants.AllowResize:
                    this.OnAllowResizeChanged();
                    break;
                case NodeConstants.AllowRotate:
                    this.OnAllowRotateChanged();
                    break;
                case NodeConstants.AspectRatio:
                    this.OnAspectRatioChanged();
                    break;
                case SelectorConstants.Angle:
                    this.OnAngleChanged();
                    break;
                case GroupableConstants.Bold:
                    this.OnBoldChanged();
                    break;
                case GroupableConstants.UnderLine:
                    this.OnUnderLineChanged();
                    break;
                case GroupableConstants.Strike:
                    this.OnStrikeChanged();
                    break;
                case ConnectorConstants.Caps:
                    this.OnDecoratorChanged();
                    break;
                case GroupableConstants.DashDot:
                    this.OnDashDotChanged();
                    break;
                case NodeConstants.Fill:
                    this.OnFillChanged();
                    break;
                case GroupableConstants.Font:
                    this.OnFontChanged();
                    break;
                case GroupableConstants.FontSize:
                    this.OnFontSizeChanged();
                    break;
                case SelectorConstants.FontValue:
                    this.OnFontValueChanged();
                    break;
                case GroupableConstants.FontStyle:
                    this.OnFontStyleChanged();
                    break;
                case GroupableConstants.FontWeight:
                    this.OnFontWeightChanged();
                    break;
                case SelectorConstants.Height:
                    this.OnHeightChanged();
                    break;
                case GroupableConstants.Italic:
                    this.OnItalicChanged();
                    break;
                case GroupableConstants.Label:
                    this.OnLabelChanged();
                    break;
                case GroupableConstants.TextAlignment:
                    this.OnTextAlignmentChanged();
                    break;
                case GroupableConstants.LabelHAlign:
                    this.OnLabelHAlignChanged();
                    break;
                case GroupableConstants.LabelMargin:
                    this.OnLabelMarginChanged();
                    break;
                case GroupableConstants.LabelVAlign:
                    this.OnLabelVAlignChanged();
                    break;
                case GroupableConstants.Name:
                    this.OnNameChanged();
                    break;
                case ConnectorConstants.SourceCap:
                    this.OnSourceCapChanged();
                    break;
                case ConnectorConstants.Decorator:
                    this.OnDecoratorChanged();
                    break;
                case GroupableConstants.Stroke:
                    this.OnStrokeChanged();
                    break;
                case GroupableConstants.Style:
                    this.OnStyleChanged();
                    break;
                case GroupableConstants.Opacity:
                    this.OnOpacityChanged();
                    break;
                case ConnectorConstants.TargetCap:
                    this.OnTargetCapChanged();
                    break;
                case GroupableConstants.Thickness:
                    this.OnThicknessChanged();
                    break;
                case ConnectorConstants.Type:
                    this.OnTypeChanged();
                    break;
                case GroupableConstants.Visibility:
                    this.OnVisibilityChanged();
                    break;
                case SelectorConstants.Width:
                    this.OnWidthChanged();
                    break;
                case SelectorConstants.X:
                    this.OnXChanged();
                    break;
                case SelectorConstants.Y:
                    this.OnYChanged();
                    break;
                case SelectorConstants.Px:
                    this.OnPXChanged();
                    break;
                case SelectorConstants.Py:
                    this.OnPYChanged();
                    break;
                case GroupableConstants.TextLeft:
                case GroupableConstants.TextCenter:
                case GroupableConstants.TextRight:
                    this.OnTextAlignToggled(name);
                    break;
                case GroupableConstants.TopLeft:
                case GroupableConstants.Middle:
                case GroupableConstants.Top:
                case GroupableConstants.TopRight:
                case GroupableConstants.Left:
                case GroupableConstants.Center:
                case GroupableConstants.Right:
                case GroupableConstants.BottomLeft:
                case GroupableConstants.Bottom:
                case GroupableConstants.BottomRight:
                    this.AlignToggled(name);
                    break;
                case SelectorConstants.CurrentBrush:
                    switch (this.CurrentBrush)
                    {
                        case CurrentBrush.Fill:
                            this.IsBrushEditing = Visibility.Visible;
                            this.PickedBrush = this.Fill;
                            break;
                        case CurrentBrush.Stroke:
                            this.IsBrushEditing = Visibility.Visible;
                            this.PickedBrush = this.Stroke;
                            break;
                        case CurrentBrush.LabelBackground:
                            this.IsBrushEditing = Visibility.Visible;
                            this.PickedBrush = this.LabelBackground;
                            break;
                        case CurrentBrush.LabelForeground:
                            this.IsBrushEditing = Visibility.Visible;
                            this.PickedBrush = this.LabelForeground;
                            break;
                        case CurrentBrush.None:
                            this.IsBrushEditing = Visibility.Collapsed;
                            break;
                    }

                    break;
                case SelectorConstants.PickedBrush:
                    switch (this.CurrentBrush)
                    {
                        case CurrentBrush.Fill:
                            this.Fill = this.PickedBrush;
                            break;
                        case CurrentBrush.Stroke:
                            this.Stroke = this.PickedBrush;
                            break;
                        case CurrentBrush.LabelBackground:
                            this.LabelBackground = this.PickedBrush;
                            break;
                        case CurrentBrush.LabelForeground:
                            this.LabelForeground = this.PickedBrush;
                            break;
                        case CurrentBrush.None:
                            break;
                    }

                    break;
                case GroupableConstants.LabelBackground:
                    this.OnLabelBackgroundChanged();
                    break;
                case GroupableConstants.LabelForeground:
                    this.OnLabelForegroundChanged();
                    break;
                case SelectorConstants.Scale:
                    this.OnScaleChanged();
                    break;
                case GroupableConstants.HyperLink:
                    this.OnHyperLinkChanged();
                    break;
                case NodeConstants.NodeGalleryName:
                    this.OnNodeGalleryNameChanged();
                    break;
                case ConnectorConstants.ConnectorGalleryName:
                    this.OnConnectorGalleryNameChanged();
                    break;
                case GroupableConstants.QuickFill:
                    this.OnQuickFillChanged();
                    break;
                case GroupableConstants.RotateText:
                    this.OnRotateTextChanged();
                    break;
            }
        }

        /// <summary>
        /// Represents the alignment options.
        /// </summary>
        /// <param name="corner">
        /// Represents the name of the option.
        /// </param>
        private void AlignToggled(string corner)
        {
            if (this.holdlabelalignment)
            {
                return;
            }

            this.holdlabelalignment = true;
            switch (corner)
            {
                case GroupableConstants.TopLeft:
                    this.LabelHAlign = HorizontalAlignment.Left;
                    this.LabelVAlign = VerticalAlignment.Top;
                    break;
                case GroupableConstants.Middle:
                    this.LabelVAlign = VerticalAlignment.Center;
                    break;
                case GroupableConstants.Top:
                    this.LabelVAlign = VerticalAlignment.Top;
                    break;
                case GroupableConstants.TopRight:
                    this.LabelHAlign = HorizontalAlignment.Right;
                    this.LabelVAlign = VerticalAlignment.Top;
                    break;
                case GroupableConstants.Left:
                    this.LabelHAlign = HorizontalAlignment.Left;
                    break;
                case GroupableConstants.Center:
                    this.LabelHAlign = HorizontalAlignment.Center;
                    break;
                case GroupableConstants.Right:
                    this.LabelHAlign = HorizontalAlignment.Right;
                    break;
                case GroupableConstants.BottomLeft:
                    this.LabelHAlign = HorizontalAlignment.Left;
                    this.LabelVAlign = VerticalAlignment.Bottom;
                    break;
                case GroupableConstants.Bottom:
                    this.LabelVAlign = VerticalAlignment.Bottom;
                    break;
                case GroupableConstants.BottomRight:
                    this.LabelHAlign = HorizontalAlignment.Right;
                    this.LabelVAlign = VerticalAlignment.Bottom;
                    break;
            }

            this.holdlabelalignment = false;
            this.OnLabelHAlignChanged();
        }

        /// <summary>
        /// Triggers when select the diagram elements.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            IGroupableVM item = args.Item as IGroupableVM;
            NodeVM node = args.Item as NodeVM;
            IConnectorVM con = args.Item as IConnectorVM;
            this.SelectedPort = null;
            item.PropertyChanged += this.UpdateProperties;
            this.SelectedItems.Add(item);
            this.UpdateSelectedKind();
            if (this.SelectedItems.Count == 1)
            {
                if (item != null)
                {
                    if (!this.bold)
                    {
                        this.bold = this.Bold.Value;
                        this.Bold = item.Bold;
                    }

                    if (!this.underline)
                    {
                        this.underline = this.UnderLine.Value;
                        this.UnderLine = item.UnderLine;
                    }

                    if (!this.strike)
                    {
                        this.strike = this.Strike.Value;
                        this.Strike = item.Strike;
                    }

                    this.DashDot = item.DashDot;
                    this.Font = item.Font;
                    this.FontSize = item.FontSize;
                    this.FontStyle = item.FontStyle;
                    this.FontWeight = item.FontWeight;
                    if (!this.italic)
                    {
                        this.italic = this.Italic.Value;
                        this.Italic = item.Italic;
                    }

                    this.Label = item.Label;
                    this.LabelVAlign = item.LabelVAlign;
                    this.LabelHAlign = item.LabelHAlign;
                    this.LabelMargin = item.LabelMargin.Left;
                    this.LabelForeground = item.LabelForeground;
                    this.LabelBackground = item.LabelBackground;
                    this.Name = item.Name;
                    this.Style = item.Style;
                    this.QuickFill = item.QuickFill;
                    this.Thickness = item.Thickness;
                    this.Visible = item.Visibility == Visibility.Visible;
                    this.Opacity = item.Opacity;
                    this.HyperLink = item.HyperLink;
                    this.Stroke = item.Stroke;
                }

                if (node != null)
                {
                    this.X = node.OffsetX;
                    this.Y = node.OffsetY;
                    this.Px = node.Pivot.X;
                    this.Py = node.Pivot.Y;
                    this.Width = node.UnitWidth;
                    this.Height = node.UnitHeight;
                    this.Angle = node.RotateAngle;
                    this.AllowDrag = node.AllowDrag;
                    this.AllowResize = node.AllowResize;
                    this.AllowRotate = node.AllowRotate;
                    this.AspectRatio = node.AspectRatio;
                    this.NodeGalleryName = node.NodeGalleryName;
                    if (node.QuickFill == null && node.Fill is SolidColorBrush) this.Fill = node.Fill;
                }
                else
                {
                    this.X = null;
                    this.Y = null;
                    this.Px = null;
                    this.Py = null;
                    this.Width = null;
                    this.Height = null;
                    this.Angle = null;
                    this.AllowDrag = null;
                    this.AllowResize = null;
                    this.AllowRotate = null;
                    this.AspectRatio = null;
                    this.Fill = null;
                }

                if (con != null)
                {
                    this.SourceCap = con.SourceCap;
                    this.TargetCap = con.TargetCap;
                    this.Type = con.Type;
                    this.ConnectorGalleryName = con.ConnectorGalleryName;
                    this.Stroke = con.Stroke;
                }
                else
                {
                    this.SourceCap = null;
                    this.TargetCap = null;
                    this.Type = null;
                }
            }

            if (this.SelectedItems.OfType<NodeVM>().Count() == 1)
            {
                node = this.SelectedItems.OfType<NodeVM>().FirstOrDefault();
                this.X = node.OffsetX;
                this.Y = node.OffsetY;
                this.Px = node.Pivot.X;
                this.Py = node.Pivot.Y;
                this.Width = node.UnitWidth;
                this.Height = node.UnitHeight;
                this.Angle = node.RotateAngle;
                this.AllowDrag = node.AllowDrag;
                this.AllowResize = node.AllowResize;
                this.AllowRotate = node.AllowRotate;
                this.AspectRatio = node.AspectRatio;
                if (node.QuickFill == null && node.Fill is SolidColorBrush) this.Fill = node.Fill;
            }

            if (this.SelectedItems.OfType<IConnectorVM>().Count() == 1)
            {
                con = this.SelectedItems.OfType<IConnectorVM>().FirstOrDefault();
                this.SourceCap = con.SourceCap;
                this.TargetCap = con.TargetCap;
                this.Type = con.Type;
            }
        }

        /// <summary>
        /// Triggers when unselect the diagram elements..
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void ItemUnSelectedEvent(object sender, DiagramEventArgs args)
        {
            IGroupableVM item = args.Item as IGroupableVM;
            item.PropertyChanged += this.UpdateProperties;
            this.SelectedItems.Remove(args.Item as IGroupableVM);
            if (item is INode && (item as INode).Annotations != null)
            {
                foreach (IAnnotation annotation in (item as INode).Annotations as List<IAnnotation>)
                {
                    if (annotation.Content != null)
                    {
                        if (string.IsNullOrEmpty(annotation.Content.ToString()))
                        {
                            if (item is NodeVM)
                            {
                                this.Diagram.NodeCollection.Remove(item as NodeVM);
                                break;
                            }
                        }
                    }
                }
            }

            if (item is IConnector && (item as IConnector).Annotations != null)
            {
                foreach (IAnnotation annotation in (item as IConnector).Annotations as List<IAnnotation>)
                {
                    if (annotation.Content != null)
                    {
                        if (string.IsNullOrEmpty(annotation.Content.ToString()))
                        {
                            if (item is ConnectorVM)
                            {
                                this.Diagram.ConnectorCollection.Remove(item as ConnectorVM);
                                break;
                            }
                        }
                    }
                }
            }

            this.UpdateSelectedKind();
            if (this.SelectedItems.Count == 1)
            {
                IGroupableVM firstItem = this.SelectedItems[0];
                NodeVM firstNode = this.SelectedItems[0] as NodeVM;
                IConnectorVM firstCon = this.SelectedItems[0] as IConnectorVM;
                if (firstItem != null)
                {
                    this.Bold = firstItem.Bold;
                    this.UnderLine = firstItem.UnderLine;
                    this.DashDot = firstItem.DashDot;
                    this.Font = firstItem.Font;
                    this.FontSize = firstItem.FontSize;
                    this.FontStyle = firstItem.FontStyle;
                    this.FontWeight = firstItem.FontWeight;
                    this.Italic = firstItem.Italic;
                    this.Label = firstItem.Label;
                    this.LabelHAlign = firstItem.LabelHAlign;
                    this.LabelMargin = firstItem.LabelMargin.Left;
                    this.LabelVAlign = firstItem.LabelVAlign;
                    this.LabelForeground = firstItem.LabelForeground;
                    this.LabelBackground = firstItem.LabelBackground;
                    this.Name = firstItem.Name;
                    this.Stroke = firstItem.Stroke;
                    this.Style = firstItem.Style;
                    this.Thickness = firstItem.Thickness;
                    this.Visible = firstItem.Visibility == Visibility.Visible;
                    this.Opacity = firstItem.Opacity;
                }

                if (firstNode != null)
                {
                    this.X = firstNode.OffsetX;
                    this.Y = firstNode.OffsetY;
                    this.Px = firstNode.Pivot.X;
                    this.Py = firstNode.Pivot.Y;
                    this.Width = firstNode.UnitWidth;
                    this.Height = firstNode.UnitHeight;
                    this.Angle = firstNode.RotateAngle;
                    this.AllowDrag = firstNode.AllowDrag;
                    this.AllowResize = firstNode.AllowResize;
                    this.AllowRotate = firstNode.AllowRotate;
                    this.AspectRatio = firstNode.AspectRatio;
                    this.Fill = firstNode.Fill;
                }
                else
                {
                    this.X = null;
                    this.Y = null;
                    this.Px = null;
                    this.Py = null;
                    this.Width = null;
                    this.Height = null;
                    this.AllowDrag = null;
                    this.AllowResize = null;
                    this.AllowRotate = null;
                    this.AspectRatio = null;
                    this.Fill = null;
                }

                if (firstCon != null)
                {
                    this.SourceCap = firstCon.SourceCap;
                    this.TargetCap = firstCon.TargetCap;
                    this.Type = firstCon.Type;
                }
                else
                {
                    this.SourceCap = null;
                    this.TargetCap = null;
                    this.Type = null;
                }
            }

            if (this.SelectedItems.OfType<NodeVM>().Count() == 1)
            {
                NodeVM node = this.SelectedItems.OfType<NodeVM>().FirstOrDefault();
                this.X = node.OffsetX;
                this.Y = node.OffsetY;
                this.Px = node.Pivot.X;
                this.Py = node.Pivot.Y;
                this.Width = node.UnitWidth;
                this.Height = node.UnitHeight;
                this.Angle = node.RotateAngle;
                this.AllowDrag = node.AllowDrag;
                this.AllowResize = node.AllowResize;
                this.AllowRotate = node.AllowRotate;
                this.AspectRatio = node.AspectRatio;
                this.Fill = node.Fill;
            }

            if (this.SelectedItems.OfType<INodeVM>().Count() == 0)
            {
                this.X = null;
                this.Y = null;
                this.Px = null;
                this.Py = null;
                this.Width = null;
                this.Height = null;
                this.Angle = null;
                this.AllowDrag = null;
                this.AllowResize = null;
                this.AllowRotate = null;
                this.AspectRatio = null;
                this.Fill = null;
                if (this.bold)
                {
                    this.Bold = this.bold;
                    this.bold = false;
                }

                if (this.underline)
                {
                    this.UnderLine = this.underline;
                    this.underline = false;
                }

                if (this.italic)
                {
                    this.Italic = this.italic;
                    this.italic = false;
                }

                if (this.strike)
                {
                    this.Strike = this.strike;
                    this.strike = false;
                }

                this.FontSize = 12;
                this.Font = new FontFamily("Segoe UI");
            }

            if (this.SelectedItems.OfType<IConnectorVM>().Count() == 1)
            {
                IConnectorVM con = this.SelectedItems.OfType<IConnectorVM>().FirstOrDefault();
                this.SourceCap = con.SourceCap;
                this.TargetCap = con.TargetCap;
                this.Type = con.Type;
            }

            if (this.SelectedItems.Count > 1)
            {
                IGroupableVM firstItem = this.SelectedItems[0];
                if (firstItem != null)
                {
                    if (this.SelectedItems.Any(i => i.Bold != firstItem.Bold))
                    {
                        this.Bold = null;
                    }
                    else
                    {
                        this.Bold = firstItem.Bold;
                    }

                    if (this.SelectedItems.Any(i => i.UnderLine != firstItem.UnderLine))
                    {
                        this.UnderLine = null;
                    }
                    else
                    {
                        this.UnderLine = firstItem.UnderLine;
                    }

                    if (this.SelectedItems.Any(i => i.DashDot != firstItem.DashDot))
                    {
                        this.DashDot = null;
                    }
                    else
                    {
                        this.DashDot = firstItem.DashDot;
                    }

                    if (this.SelectedItems.Any(i => i.Font != firstItem.Font))
                    {
                        this.Font = null;
                    }
                    else
                    {
                        this.Font = firstItem.Font;
                    }

                    if (this.SelectedItems.Any(i => i.FontSize != firstItem.FontSize))
                    {
                        this.FontSize = null;
                    }
                    else
                    {
                        this.FontSize = firstItem.FontSize;
                    }

                    if (this.SelectedItems.Any(i => i.FontStyle != firstItem.FontStyle))
                    {
                        this.FontStyle = null;
                    }
                    else
                    {
                        this.FontStyle = firstItem.FontStyle;
                    }

                    if (this.SelectedItems.Any(i => i.FontWeight.Equals(firstItem.FontWeight)))
                    {
                        this.FontWeight = null;
                    }
                    else
                    {
                        this.FontWeight = firstItem.FontWeight;
                    }

                    if (this.SelectedItems.Any(i => i.LabelBackground != firstItem.LabelBackground))
                    {
                        this.LabelBackground = null;
                    }
                    else
                    {
                        this.LabelBackground = firstItem.LabelBackground;
                    }

                    if (this.SelectedItems.Any(i => i.LabelForeground != firstItem.LabelForeground))
                    {
                        this.LabelForeground = null;
                    }
                    else
                    {
                        this.LabelForeground = firstItem.LabelForeground;
                    }

                    if (this.SelectedItems.Any(i => i.Italic != firstItem.Italic))
                    {
                        this.Italic = null;
                    }
                    else
                    {
                        this.Italic = firstItem.Italic;
                    }

                    if (this.SelectedItems.Any(i => i.Label != firstItem.Label))
                    {
                        this.Label = null;
                    }
                    else
                    {
                        this.Label = firstItem.Label;
                    }

                    if (this.SelectedItems.Any(i => i.LabelHAlign != firstItem.LabelHAlign))
                    {
                        this.LabelHAlign = null;
                    }
                    else
                    {
                        this.LabelHAlign = firstItem.LabelHAlign;
                    }

                    if (this.SelectedItems.Any(i => i.LabelMargin != firstItem.LabelMargin))
                    {
                        this.LabelMargin = null;
                    }
                    else
                    {
                        this.LabelMargin = firstItem.LabelMargin.Left;
                    }

                    if (this.SelectedItems.Any(i => i.LabelVAlign != firstItem.LabelVAlign))
                    {
                        this.LabelVAlign = null;
                    }
                    else
                    {
                        this.LabelVAlign = firstItem.LabelVAlign;
                    }

                    if (this.SelectedItems.Any(i => i.Name != firstItem.Name))
                    {
                        this.Name = string.Empty;
                    }
                    else
                    {
                        this.Name = firstItem.Name;
                    }

                    if (this.SelectedItems.Any(i => i.Stroke != firstItem.Stroke))
                    {
                        this.Stroke = null;
                    }
                    else
                    {
                        this.Stroke = firstItem.Stroke;
                    }

                    if (this.SelectedItems.Any(i => i.Style != firstItem.Style))
                    {
                        this.Style = null;
                    }
                    else
                    {
                        this.Style = firstItem.Style;
                    }

                    if (this.SelectedItems.Any(i => i.Thickness != firstItem.Thickness))
                    {
                        this.Thickness = null;
                    }
                    else
                    {
                        this.Thickness = firstItem.Thickness;
                    }

                    if (this.SelectedItems.Any(i => i.Visibility != firstItem.Visibility))
                    {
                        this.Visible = null;
                    }
                    else
                    {
                        this.Visible = firstItem.Visibility == Visibility.Visible;
                    }

                    if (this.SelectedItems.Any(i => i.Opacity != firstItem.Opacity))
                    {
                        this.Opacity = null;
                    }
                    else
                    {
                        this.Opacity = firstItem.Opacity;
                    }
                }

                NodeVM firstNode = this.SelectedItems.OfType<NodeVM>().FirstOrDefault();
                if (firstNode != null)
                {
                    if (this.SelectedItems.OfType<NodeVM>().Any(i => i.OffsetX != firstNode.OffsetX))
                    {
                        this.X = null;
                    }
                    else
                    {
                        this.X = firstNode.OffsetX;
                    }

                    if (this.SelectedItems.OfType<NodeVM>().Any(i => i.OffsetY != firstNode.OffsetY))
                    {
                        this.Y = null;
                    }
                    else
                    {
                        this.Y = firstNode.OffsetY;
                    }

                    if (this.SelectedItems.OfType<NodeVM>().Any(i => i.Pivot.X != firstNode.Pivot.X))
                    {
                        this.Px = null;
                    }
                    else
                    {
                        this.Px = firstNode.Pivot.X;
                    }

                    if (this.SelectedItems.OfType<NodeVM>().Any(i => i.Pivot.Y != firstNode.Pivot.Y))
                    {
                        this.Py = null;
                    }
                    else
                    {
                        this.Py = firstNode.Pivot.Y;
                    }

                    if (this.SelectedItems.OfType<NodeVM>().Any(i => i.UnitWidth != firstNode.UnitWidth))
                    {
                        this.Width = null;
                    }
                    else
                    {
                        this.Width = firstNode.UnitWidth;
                    }

                    if (this.SelectedItems.OfType<NodeVM>().Any(i => i.UnitHeight != firstNode.UnitHeight))
                    {
                        this.Height = null;
                    }
                    else
                    {
                        this.Height = firstNode.UnitHeight;
                    }

                    if (this.SelectedItems.OfType<NodeVM>().Any(i => i.RotateAngle != firstNode.RotateAngle))
                    {
                        this.Angle = null;
                    }
                    else
                    {
                        this.Angle = firstNode.RotateAngle;
                    }

                    if (this.SelectedItems.OfType<INodeVM>().Any(i => i.AllowDrag != firstNode.AllowDrag))
                    {
                        this.AllowDrag = null;
                    }
                    else
                    {
                        this.AllowDrag = firstNode.AllowDrag;
                    }

                    if (this.SelectedItems.OfType<INodeVM>().Any(i => i.AllowResize != firstNode.AllowResize))
                    {
                        this.AllowResize = null;
                    }
                    else
                    {
                        this.AllowResize = firstNode.AllowResize;
                    }

                    if (this.SelectedItems.OfType<INodeVM>().Any(i => i.AllowRotate != firstNode.AllowRotate))
                    {
                        this.AllowRotate = null;
                    }
                    else
                    {
                        this.AllowRotate = firstNode.AllowRotate;
                    }

                    if (this.SelectedItems.OfType<INodeVM>().Any(i => i.AspectRatio != firstNode.AspectRatio))
                    {
                        this.AspectRatio = null;
                    }
                    else
                    {
                        this.AspectRatio = firstNode.AspectRatio;
                    }

                    if (this.SelectedItems.OfType<INodeVM>().Any(i => i.Fill != firstNode.Fill))
                    {
                        this.Fill = null;
                    }
                    else
                    {
                        this.Fill = firstNode.Fill;
                    }
                }

                IConnectorVM firstCon = this.SelectedItems.OfType<IConnectorVM>().FirstOrDefault();
                if (firstCon != null)
                {
                    if (this.SelectedItems.OfType<IConnectorVM>().Any(i => i.SourceCap != firstCon.SourceCap))
                    {
                        this.SourceCap = null;
                    }
                    else
                    {
                        this.SourceCap = firstCon.SourceCap;
                    }

                    if (this.SelectedItems.OfType<IConnectorVM>().Any(i => i.TargetCap != firstCon.TargetCap))
                    {
                        this.TargetCap = null;
                    }
                    else
                    {
                        this.TargetCap = firstCon.TargetCap;
                    }

                    if (this.SelectedItems.OfType<IConnectorVM>().Any(i => i.Type != firstCon.Type))
                    {
                        this.Type = null;
                    }
                    else
                    {
                        this.Type = firstCon.Type;
                    }
                }
            }
        }

        /// <summary>
        ///     The on allow drag changed.
        /// </summary>
        private void OnAllowDragChanged()
        {
            if (this.AllowDrag.HasValue)
            {
                foreach (INodeVM node in this.SelectedItems.OfType<INodeVM>())
                {
                    node.AllowDrag = this.AllowDrag.Value;
                }
            }
        }

        /// <summary>
        ///     The on allow resize changed.
        /// </summary>
        private void OnAllowResizeChanged()
        {
            if (this.AllowResize.HasValue)
            {
                foreach (INodeVM node in this.SelectedItems.OfType<INodeVM>())
                {
                    node.AllowResize = this.AllowResize.Value;
                }
            }
        }

        /// <summary>
        ///     The on allow rotate changed.
        /// </summary>
        private void OnAllowRotateChanged()
        {
            if (this.AllowRotate.HasValue)
            {
                foreach (INodeVM node in this.SelectedItems.OfType<INodeVM>())
                {
                    node.AllowRotate = this.AllowRotate.Value;
                }
            }
        }

        /// <summary>
        ///     The on angle changed.
        /// </summary>
        private void OnAngleChanged()
        {
            if (this.Angle.HasValue)
            {
                foreach (NodeVM node in this.SelectedItems.OfType<NodeVM>())
                {
                    node.RotateAngle = this.Angle.Value;
                }
            }
        }

        /// <summary>
        ///     The on aspect ratio changed.
        /// </summary>
        private void OnAspectRatioChanged()
        {
            if (this.AspectRatio.HasValue)
            {
                foreach (INodeVM node in this.SelectedItems.OfType<INodeVM>())
                {
                    node.AspectRatio = this.AspectRatio.Value;
                }
            }
        }

        /// <summary>
        ///     The on bold changed.
        /// </summary>
        private void OnBoldChanged()
        {
            if (this.Bold.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.Bold = this.Bold.Value;
                }
            }
        }

        /// <summary>
        /// The on close color picker palette command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnCloseColorPickerPaletteCommand(object obj)
        {
        }

        /// <summary>
        ///     The on connector gallary name changed.
        /// </summary>
        private void OnConnectorGalleryNameChanged()
        {
            if (this.ConnectorGalleryName != null)
            {
                foreach (IConnectorVM node in this.SelectedItems.OfType<IConnectorVM>())
                {
                    node.ConnectorGalleryName = this.ConnectorGalleryName;
                }
            }
        }

        /// <summary>
        ///     The on dash dot changed.
        /// </summary>
        private void OnDashDotChanged()
        {
            if (this.DashDot != null)
            {
                foreach (IGroupableVM node in this.SelectedItems.OfType<IGroupableVM>())
                {
                    node.DashDot = this.DashDot;
                }
            }
        }

        /// <summary>
        /// The on dash dot command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnDashDotCommand(object obj)
        {
            Grid a = obj as Grid;
            if (this.IsConnectorSelected || this.IsNodeSelected)
            {
                foreach (IGroupableVM node in this.SelectedItems.OfType<IGroupableVM>())
                {
                    node.DashDot = a.DataContext.ToString();
                }
            }
        }

        /// <summary>
        /// The on decorator changed.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnDecoratorChanged(object obj)
        {
            Grid a = obj as Grid;

            // GroupTransactions group = new GroupTransactions();
            // group.ContinuousUndoRedo = ContinuousUndoRedo.Start;
            // Diagram.HistoryManager.BeginComposite(Diagram.HistoryManager, group);
            if (this.IsConnectorSelected)
            {
                foreach (IConnectorVM con in this.SelectedItems.OfType<IConnectorVM>())
                {
                    con.TargetCap = null;
                    con.SourceCap = null;
                    Arrows arrows = a.DataContext as Arrows;
                    if (arrows.Issourcecap)
                    {
                        con.SourceCap = arrows.LineData;
                    }
                    else if (arrows.Istargetcap)
                    {
                        con.TargetCap = arrows.LineData;
                    }
                    else if (arrows.Isbothcap)
                    {
                        con.SourceCap = arrows.LineData;
                        con.TargetCap = arrows.LineData;
                    }
                }
            }

            // GroupTransactions group1 = new GroupTransactions();
            // group1.ContinuousUndoRedo = ContinuousUndoRedo.End;
            // Diagram.HistoryManager.EndComposite(Diagram.HistoryManager, group1);
        }

        /// <summary>
        ///     The on decorator changed.
        /// </summary>
        private void OnDecoratorChanged()
        {
            if (this.Decorator != null)
            {
            }
        }

        /// <summary>
        ///     The on fill changed.
        /// </summary>
        private void OnFillChanged()
        {
            if (this.Fill != null)
            {
                foreach (INodeVM node in this.SelectedItems.OfType<INodeVM>())
                {
                    node.Fill = this.Fill;
                    this.NodeGalleryName = null;
                    node.NodeGalleryName = null;
                }
            }
        }

        /// <summary>
        ///     The on font changed.
        /// </summary>
        private void OnFontChanged()
        {
            if (this.Font != null)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.Font = this.Font;
                }
            }
        }

        /// <summary>
        ///     The on font size changed.
        /// </summary>
        private void OnFontSizeChanged()
        {
            if (this.FontSize.HasValue)
            {
                for (int i = 0; i < this.SelectedItems.Count; i++)
                {
                    if (this.FontValue.Value != 0 && i > 0)
                    {
                        break;
                    }

                    this.SelectedItems[i].FontSize = this.FontSize.Value;
                }
            }
        }

        /// <summary>
        ///     The on font style changed.
        /// </summary>
        private void OnFontStyleChanged()
        {
            if (this.FontStyle.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.FontStyle = this.FontStyle.Value;
                }
            }
        }

        /// <summary>
        ///     The on font value changed.
        /// </summary>
        private void OnFontValueChanged()
        {
            if (this.FontValue.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.FontSize += this.FontValue.Value;
                }

                if (this.SelectedItems.Count > 0) this.FontSize = this.SelectedItems[0].FontSize;
            }
        }

        /// <summary>
        ///     The on font weight changed.
        /// </summary>
        private void OnFontWeightChanged()
        {
            if (this.FontWeight.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.FontWeight = this.FontWeight.Value;
                }
            }
        }

        /// <summary>
        /// The on grow command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnGrowCommand(object obj)
        {
            this.FontValue = 2;
        }

        /// <summary>
        ///     The on height changed.
        /// </summary>
        private void OnHeightChanged()
        {
            if (this.Height.HasValue)
            {
                foreach (NodeVM node in this.SelectedItems.OfType<NodeVM>())
                {
                    node.UnitHeight = this.Height.Value;
                }
            }
        }

        /// <summary>
        ///     The on hyper link changed.
        /// </summary>
        private void OnHyperLinkChanged()
        {
            if (this.HyperLink != null)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.HyperLink = this.HyperLink;
                }
            }
        }

        /// <summary>
        ///     The on italic changed.
        /// </summary>
        private void OnItalicChanged()
        {
            if (this.Italic.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.Italic = this.Italic.Value;
                }
            }
        }

        /// <summary>
        ///     The on label background changed.
        /// </summary>
        private void OnLabelBackgroundChanged()
        {
            if (this.LabelBackground != null)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.LabelBackground = this.LabelBackground;
                }
            }
        }

        /// <summary>
        ///     The on label changed.
        /// </summary>
        private void OnLabelChanged()
        {
            if (this.Label != null)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.Label = this.Label;
                }
            }
        }

        /// <summary>
        ///     The on label foreground changed.
        /// </summary>
        private void OnLabelForegroundChanged()
        {
            if (this.LabelForeground != null)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.LabelForeground = this.LabelForeground;
                }
            }
        }

        /// <summary>
        ///     The on label h align changed.
        /// </summary>
        private void OnLabelHAlignChanged()
        {
            if (this.holdlabelalignment)
            {
                return;
            }

            this.holdlabelalignment = true;

            if (this.LabelHAlign.HasValue)
            {
                switch (this.LabelHAlign.Value)
                {
                    case HorizontalAlignment.Left:
                        // TopLeft = true;
                        // Top = false;
                        // TopRight = false;
                        this.Left = true;
                        this.Center = false;
                        this.Right = false;

                        // BottomLeft = true;
                        // Bottom = false;
                        // BottomRight = false;
                        break;
                    case HorizontalAlignment.Center:
                        // TopLeft = false;
                        // Top = true;
                        // TopRight = false;
                        this.Left = false;
                        this.Center = true;
                        this.Right = false;

                        // BottomLeft = false;
                        // Bottom = true;
                        // BottomRight = false;
                        break;
                    case HorizontalAlignment.Right:
                        // TopLeft = false;
                        // Top = false;
                        // TopRight = true;
                        this.Left = false;
                        this.Center = false;
                        this.Right = true;

                        // BottomLeft = false;
                        // Bottom = false;
                        // BottomRight = true;
                        break;
                }

                this.OnLabelVAlignChanged();
            }
            else
            {
                this.TopLeft = false;
                this.Top = false;
                this.TopRight = false;
                this.Middle = false;
                this.Left = false;
                this.Center = false;
                this.Right = false;
                this.BottomLeft = false;
                this.Bottom = false;
                this.BottomRight = false;
            }

            if (this.LabelHAlign.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.LabelHAlign = this.LabelHAlign.Value;
                }
            }
        }

        /// <summary>
        ///     The on label margin changed.
        /// </summary>
        private void OnLabelMarginChanged()
        {
            if (this.LabelMargin.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.LabelMargin = new Thickness(this.LabelMargin.Value);
                }
            }
        }

        /// <summary>
        ///     The on label v align changed.
        /// </summary>
        private void OnLabelVAlignChanged()
        {
            this.holdlabelalignment = false;
            if (this.holdlabelalignment)
            {
                return;
            }

            this.holdlabelalignment = true;
            if (this.LabelVAlign.HasValue)
            {
                switch (this.LabelVAlign)
                {
                    case VerticalAlignment.Top:
                        this.TopLeft = this.TopLeft;
                        this.Top = this.Top;
                        this.TopRight = this.TopRight;
                        this.Middle = false;
                        this.Top = true;

                        // Left = false;
                        // Center = false;
                        // Right = false;
                        this.BottomLeft = false;
                        this.Bottom = false;
                        this.BottomRight = false;
                        break;
                    case VerticalAlignment.Center:
                        this.TopLeft = false;
                        this.Top = false;
                        this.TopRight = false;
                        this.Middle = true;

                        // Left = Left;
                        // Center = Center;
                        // Right = Right;
                        this.BottomLeft = false;
                        this.Bottom = false;
                        this.BottomRight = false;
                        break;
                    case VerticalAlignment.Bottom:
                        this.TopLeft = false;
                        this.Top = false;
                        this.TopRight = false;
                        this.Middle = false;
                        this.Bottom = true;

                        // Left = false;
                        // Center = false;
                        // Right = false;
                        this.BottomLeft = this.BottomLeft;
                        this.Bottom = this.Bottom;
                        this.BottomRight = this.BottomRight;
                        break;
                }
            }

            if (this.LabelVAlign.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.LabelVAlign = this.LabelVAlign.Value;
                }
            }

            this.holdlabelalignment = false;
        }

        /// <summary>
        ///     The on name changed.
        /// </summary>
        private void OnNameChanged()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                foreach (INodeVM node in this.SelectedItems.OfType<INodeVM>())
                {
                    node.Name = this.Name;
                }
            }
        }

        /// <summary>
        ///     The on node gallary name changed.
        /// </summary>
        private void OnNodeGalleryNameChanged()
        {
            if (this.NodeGalleryName != null)
            {
                foreach (NodeVM node in this.SelectedItems.OfType<NodeVM>())
                {
                    node.NodeGalleryName = this.NodeGalleryName;
                }
            }
        }

        /// <summary>
        ///     The on opacity changed.
        /// </summary>
        private void OnOpacityChanged()
        {
            if (this.Opacity != null)
            {
                foreach (IGroupableVM node in this.SelectedItems.OfType<IGroupableVM>())
                {
                    node.Opacity = this.Opacity.Value;
                }
            }
        }

        /// <summary>
        ///     The on px changed.
        /// </summary>
        private void OnPXChanged()
        {
            if (this.Px.HasValue)
            {
                foreach (NodeVM node in this.SelectedItems.OfType<NodeVM>())
                {
                    node.Pivot = new Point(this.Px.Value, node.Pivot.Y);
                }
            }
        }

        /// <summary>
        ///     The on py changed.
        /// </summary>
        private void OnPYChanged()
        {
            if (this.Py.HasValue)
            {
                foreach (NodeVM node in this.SelectedItems.OfType<NodeVM>())
                {
                    node.Pivot = new Point(node.Pivot.X, this.Py.Value);
                }
            }
        }

        /// <summary>
        ///     The on quick fill changed.
        /// </summary>
        private void OnQuickFillChanged()
        {
            if (this.QuickFill != null)
            {
                foreach (NodeVM node in this.SelectedItems.OfType<NodeVM>())
                {
                    node.QuickFill = this.QuickFill;
                }
            }
        }

        /// <summary>
        ///     The on rotate text changed.
        /// </summary>
        private void OnRotateTextChanged()
        {
            if (this.RotateText == true)
            {
                foreach (NodeVM nv in this.SelectedItems.OfType<NodeVM>())
                {
                    if (nv.IsSelected)
                    {
                        foreach (LabelVM av in nv.Annotations as List<IAnnotation>)
                        {
                            av.RotateAngle += 90;
                        }
                    }
                }

                foreach (ConnectorVM cv in this.SelectedItems.OfType<ConnectorVM>())
                {
                    if (cv.IsSelected)
                    {
                        foreach (LabelVM av in cv.Annotations as List<IAnnotation>)
                        {
                            av.RotateAngle += 90;
                        }
                    }
                }
            }

            this.RotateText = false;
        }

        /// <summary>
        ///     The on scale changed.
        /// </summary>
        private void OnScaleChanged()
        {
            IGraphInfo info = this.Diagram.Info as IGraphInfo;
            if (info != null)
            {
                info.Commands.Zoom.Execute(
                    new ZoomPositionParameter { ZoomCommand = ZoomCommand.Zoom, ZoomTo = this.Scale });
            }
        }

        /// <summary>
        /// The on shrink command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnShrinkCommand(object obj)
        {
            this.FontValue = -2;
        }

        /// <summary>
        ///     The on source cap changed.
        /// </summary>
        private void OnSourceCapChanged()
        {
            if (this.SourceCap != null)
            {
                foreach (IConnectorVM con in this.SelectedItems.OfType<IConnectorVM>())
                {
                    con.SourceCap = this.SourceCap;
                }
            }
        }

        /// <summary>
        ///     The on strike changed.
        /// </summary>
        private void OnStrikeChanged()
        {
            if (this.Strike.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.Strike = this.Strike.Value;
                }
            }
        }

        /// <summary>
        ///     The on stroke changed.
        /// </summary>
        private void OnStrokeChanged()
        {
            if (this.Stroke != null)
            {
                foreach (IGroupableVM node in this.SelectedItems.OfType<IGroupableVM>())
                {
                    node.Stroke = this.Stroke;
                    if (node is ConnectorVM)
                    {
                        this.ConnectorGalleryName = null;
                        (node as ConnectorVM).ConnectorGalleryName = null;
                    }
                }
            }
        }

        /// <summary>
        ///     The on style changed.
        /// </summary>
        private void OnStyleChanged()
        {
            if (this.Style != null)
            {
                foreach (INodeVM node in this.SelectedItems.OfType<INodeVM>())
                {
                    node.Style = this.Style;
                }

                foreach (IConnectorVM node in this.SelectedItems.OfType<IConnectorVM>())
                {
                    node.Style = this.Style;
                }
            }
        }

        /// <summary>
        ///     The on taget cap changed.
        /// </summary>
        private void OnTargetCapChanged()
        {
            if (this.TargetCap != null)
            {
                foreach (IConnectorVM con in this.SelectedItems.OfType<IConnectorVM>())
                {
                    con.TargetCap = this.TargetCap;
                }
            }
        }

        /// <summary>
        ///     The on text alignment changed.
        /// </summary>
        private void OnTextAlignmentChanged()
        {
            if (this.holdlabelalignment)
            {
                return;
            }

            this.holdlabelalignment = true;
            if (this.TextAlignment.HasValue)
            {
                switch (this.TextAlignment)
                {
                    case System.Windows.TextAlignment.Left:
                        this.TextLeft = true;
                        this.TextCenter = false;
                        this.TextRight = false;
                        break;
                    case System.Windows.TextAlignment.Center:
                        this.TextLeft = false;
                        this.TextCenter = true;
                        this.TextRight = false;
                        break;
                    case System.Windows.TextAlignment.Right:
                        this.TextLeft = false;
                        this.TextCenter = false;
                        this.TextRight = true;
                        break;
                }
            }

            this.holdlabelalignment = false;
        }

        /// <summary>
        /// The on text align toggled.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        private void OnTextAlignToggled(string name)
        {
            if (this.holdlabelalignment)
            {
                return;
            }

            this.holdlabelalignment = true;
            switch (name)
            {
                case GroupableConstants.TextLeft:
                    this.TextAlignment = System.Windows.TextAlignment.Left;
                    break;
                case GroupableConstants.TextCenter:
                    this.TextAlignment = System.Windows.TextAlignment.Center;
                    break;
                case GroupableConstants.TextRight:
                    this.TextAlignment = System.Windows.TextAlignment.Right;
                    break;
            }

            this.holdlabelalignment = false;
        }

        /// <summary>
        ///     The on thickness changed.
        /// </summary>
        private void OnThicknessChanged()
        {
            if (this.Thickness != null)
            {
                foreach (IGroupableVM node in this.SelectedItems.OfType<IGroupableVM>())
                {
                    node.Thickness = this.Thickness.Value;
                }
            }
        }

        /// <summary>
        /// The on thickness command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnThicknessCommand(object obj)
        {
            int thickness = 0;
            if (int.TryParse(obj.ToString(), out thickness))
            {
                foreach (IGroupableVM node in this.SelectedItems.OfType<IGroupableVM>())
                {
                    node.Thickness = thickness;
                }

                foreach (IGroupableVM connector in this.SelectedItems.OfType<IGroupableVM>())
                {
                    connector.Thickness = thickness;
                }
            }
        }

        /// <summary>
        ///     The on tool tip constraints changed.
        /// </summary>
        private void OnToolTipConstraintsChanged()
        {
            if (this.ToolTip != null)
            {
                this.ToolTip.Constraints = (ToolTipConstraints)Enum.Parse(
                    typeof(ToolTipConstraints),
                    this.ToolTipConstraint);
            }
        }

        /// <summary>
        ///     The on type changed.
        /// </summary>
        private void OnTypeChanged()
        {
            if (this.Type.HasValue)
            {
                foreach (IConnectorVM con in this.SelectedItems.OfType<IConnectorVM>())
                {
                    con.Type = this.Type.Value;
                }
            }
        }

        /// <summary>
        ///     The on under line changed.
        /// </summary>
        private void OnUnderLineChanged()
        {
            if (this.UnderLine.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    item.UnderLine = this.UnderLine.Value;
                }
            }
        }

        /// <summary>
        ///     The on visibility changed.
        /// </summary>
        private void OnVisibilityChanged()
        {
            if (this.Visible.HasValue)
            {
                foreach (IGroupableVM item in this.SelectedItems)
                {
                    if (this.Visible.Value)
                    {
                        item.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        item.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        /// <summary>
        ///     The on width changed.
        /// </summary>
        private void OnWidthChanged()
        {
            if (this.Width.HasValue)
            {
                foreach (NodeVM node in this.SelectedItems.OfType<NodeVM>())
                {
                    node.UnitWidth = this.Width.Value;
                }
            }
        }

        /// <summary>
        ///     The on x changed.
        /// </summary>
        private void OnXChanged()
        {
            if (this.X.HasValue)
            {
                foreach (NodeVM node in this.SelectedItems.OfType<NodeVM>())
                {
                    node.OffsetX = this.X.Value;
                }
            }
        }

        /// <summary>
        ///     The on y changed.
        /// </summary>
        private void OnYChanged()
        {
            if (this.Y.HasValue)
            {
                foreach (NodeVM node in this.SelectedItems.OfType<NodeVM>())
                {
                    node.OffsetY = this.Y.Value;
                }
            }
        }

        /// <summary>
        /// The selector v m_ item tapped event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void SelectorVM_ItemTappedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is NodeVM)
            {
                if ((args.Item as NodeVM).Style == null)
                {
                    this.NodeGalleryName = null;
                }
            }
            else if (args.Item is NodePortVM)
            {
                NodePortVM port = args.Item as NodePortVM;
                NodePortVM selectedPort = this.SelectedPort != null ? this.SelectedPort as NodePortVM : null;
                this.Clear();
                if (selectedPort != port) this.SelectedPort = port;
            }
            else
            {
                this.SelectedPort = null;
            }
        }

        /// <summary>
        /// The selector v m_ view port changed event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void SelectorVM_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            this.Scale = args.NewValue.CurrentZoom;
            DiagramBuilderVM diagram = null;
            foreach (Window win in Application.Current.Windows)
            {
                if (win.DataContext is DiagramBuilderVM)
                {
                    diagram = win.DataContext as DiagramBuilderVM;
                }
            }
            
            if (diagram != null && diagram.ZoomParameter != null)
            {
                var text = diagram.ZoomParameter.PercentageText;
                if (text != "Width" && text != "Page")
                {
                    diagram.ZoomParameter.PercentageText = Math.Floor(this.Scale * 100).ToString();
                }
            }
        }

        /// <summary>
        /// The update properties.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UpdateProperties(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case GroupableConstants.Label:
                    if (this.SelectedItems.Count == 1)
                    {
                        this.Label = this.SelectedItems.FirstOrDefault().Label;
                    }

                    this.UpdateSelectedKind();
                    break;
                case GroupableConstants.OffsetX:
                    if (this.SelectedItems.OfType<INode>().Count() == 1)
                    {
                        this.X = this.SelectedItems.OfType<INode>().FirstOrDefault().OffsetX;
                    }
                    else
                    {
                        this.X = null;
                    }

                    break;
                case GroupableConstants.OffsetY:
                    if (this.SelectedItems.OfType<INode>().Count() == 1)
                    {
                        this.Y = this.SelectedItems.OfType<INode>().FirstOrDefault().OffsetY;
                    }
                    else
                    {
                        this.Y = null;
                    }

                    break;
                case GroupableConstants.UnitWidth:
                    if (this.SelectedItems.OfType<INode>().Count() == 1)
                    {
                        this.Width = this.SelectedItems.OfType<INode>().FirstOrDefault().UnitWidth;
                    }

                    if (this.SelectedItems.OfType<INode>().Count() == 0)
                    {
                        this.Width = null;
                    }

                    break;
                case GroupableConstants.UnitHeight:
                    if (this.SelectedItems.OfType<INode>().Count() == 1)
                    {
                        this.Height = this.SelectedItems.OfType<INode>().FirstOrDefault().UnitHeight;
                    }

                    if (this.SelectedItems.OfType<INode>().Count() == 0)
                    {
                        this.Height = null;
                    }

                    break;
                case GroupableConstants.RotateAngle:
                    if (this.SelectedItems.OfType<INode>().Count() == 1)
                    {
                        this.Angle = this.SelectedItems.OfType<INode>().FirstOrDefault().RotateAngle;
                    }

                    if (this.SelectedItems.OfType<INode>().Count() == 0)
                    {
                        this.Angle = null;
                    }

                    break;
                case GroupableConstants.HyperLink:
                    if (this.SelectedItems.Count == 1)
                    {
                        this.HyperLink = this.SelectedItems.FirstOrDefault().HyperLink;
                    }

                    this.UpdateSelectedKind();
                    break;
            }
        }

        /// <summary>
        ///     The update selected kind.
        /// </summary>
        private void UpdateSelectedKind()
        {
            if (this.SelectedItems.OfType<INodeVM>().Any())
            {
                this.IsNodeSelected = true;
            }
            else
            {
                this.IsNodeSelected = false;
            }

            if (this.SelectedItems.OfType<IConnectorVM>().Any())
            {
                this.IsConnectorSelected = true;
            }
            else
            {
                this.IsConnectorSelected = false;
            }

            if (this.IsNodeSelected || this.IsConnectorSelected)
            {
                this.IsAnythingSelected = true;
            }
            else
            {
                this.IsAnythingSelected = false;
            }

            if (this.IsAnythingSelected && this.SelectedItems.Any(item => !string.IsNullOrEmpty(item.Label)))
            {
                this.IsLabelSet = true;
            }
            else
            {
                this.IsLabelSet = false;
            }

            if (this.IsNodeSelected
                && this.SelectedItems.OfType<INodeVM>().Any(item => !string.IsNullOrEmpty(item.Label)))
            {
                this.IsNodeLabelSet = true;
            }
            else
            {
                this.IsNodeLabelSet = false;
            }

            if (this.IsConnectorSelected
                && this.SelectedItems.OfType<IConnectorVM>().Any(item => !string.IsNullOrEmpty(item.Label)))
            {
                this.IsConnectorLabelSet = true;
            }
            else
            {
                this.IsConnectorLabelSet = false;
            }
        }
    }
}