// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramStyleViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The diagram style view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Theming;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     The diagram style view model.
    /// </summary>
    public class DiagramStyleViewModel : DiagramElementViewModel
    {
        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/syncfusion.diagrambuilder.Wpf;component/Brainstorming/Theme/BrainstormingUI.xaml", UriKind.RelativeOrAbsolute)
        };

        /// <summary>
        ///     The _m is straight connector type.
        /// </summary>
        private bool _mIsStraightConnectorType = true;

        /// <summary>
        ///     The _m selected shape.
        /// </summary>
        private object _mSelectedShape;

        /// <summary>
        ///     The _m selected style.
        /// </summary>
        private object _mSelectedStyle;

        /// <summary>
        ///     The _m theme styles collection.
        /// </summary>
        private ObservableCollection<ThemeStyleButtonVM> _mThemeStylesCollection;

        /// <summary>
        ///     The apply command.
        /// </summary>
        private DelegateCommand<object> applyCommand;

        /// <summary>
        ///     The cancel command.
        /// </summary>
        private DelegateCommand<object> cancelCommand;

        /// <summary>
        ///     The connector styles.
        /// </summary>
        private ObservableCollection<string> connectorStyles;

        /// <summary>
        ///     The diagram builder vm.
        /// </summary>
        private BrainstormingBuilderVM diagramBuilderVM;

        /// <summary>
        ///     The key down command.
        /// </summary>
        private DelegateCommand<object> keyDownCommand;

        /// <summary>
        ///     The levels.
        /// </summary>
        private ObservableCollection<string> levels;

        /// <summary>
        ///     The mselected level.
        /// </summary>
        private int mselectedLevel;

        /// <summary>
        ///     The ok command.
        /// </summary>
        private DelegateCommand<object> okCommand;

        /// <summary>
        ///     The style diagram.
        /// </summary>
        private BrainstormingVM styleDiagram;

        /// <summary>
        ///     The topics.
        /// </summary>
        private ObservableCollection<string> topics;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramStyleViewModel"/> class.
        /// </summary>
        /// <param name="diagramBuilderVM">
        /// The diagram builder vm.
        /// </param>
        public DiagramStyleViewModel(BrainstormingBuilderVM diagramBuilderVM)
        {
            this.DiagramBuilderVM = diagramBuilderVM;

            this.ConnectorStyles = new ObservableCollection<string> { "Curved", "Straight" };
            this.Levels = new ObservableCollection<string> { "Level 1", "Level 2", "Level 3", "Level 4" };
            this.Topics = new ObservableCollection<string>
                              {
                                  "Oval",
                                  "Cloud",
                                  "Rectangle",
                                  "Line",
                                  "Freehand",
                                  "Wave"
                              };
        }

        /// <summary>
        ///     Gets the apply command.
        /// </summary>
        public DelegateCommand<object> ApplyCommand
        {
            get
            {
                return this.applyCommand ?? (this.applyCommand = new DelegateCommand<object>(this.ApplyCommandExecute));
            }
        }

        /// <summary>
        ///     Gets the cancel command.
        /// </summary>
        public DelegateCommand<object> CancelCommand
        {
            get
            {
                return this.cancelCommand
                       ?? (this.cancelCommand = new DelegateCommand<object>(this.CancelCommandExecute));
            }
        }

        /// <summary>
        ///     Gets or sets collection of connector styes.
        /// </summary>
        public ObservableCollection<string> ConnectorStyles
        {
            get
            {
                return this.connectorStyles;
            }

            set
            {
                if (this.connectorStyles != value)
                {
                    this.connectorStyles = value;
                    this.OnPropertyChanged("ConnectorStyles");
                }
            }
        }

        /// <summary>
        ///     Gets applications diagram builder vm.
        /// </summary>
        public BrainstormingBuilderVM DiagramBuilderVM
        {
            get
            {
                return this.diagramBuilderVM;
            }

            set
            {
                if (this.diagramBuilderVM != value)
                {
                    this.diagramBuilderVM = value;
                    this.OnPropertyChanged("DiagramBuilderVM");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is straight connector type.
        /// </summary>
        public bool IsStraightConnectorType
        {
            get
            {
                return this._mIsStraightConnectorType;
            }

            set
            {
                if (this._mIsStraightConnectorType != value)
                {
                    this._mIsStraightConnectorType = value;
                    this.OnPropertyChanged("IsStraightConnectorType");
                }
            }
        }

        /// <summary>
        ///     Gets the key down command.
        /// </summary>
        public DelegateCommand<object> KeyDownCommand
        {
            get
            {
                return this.keyDownCommand
                       ?? (this.keyDownCommand = new DelegateCommand<object>(this.KeyDownCommandExecute));
            }
        }

        /// <summary>
        ///     Gets or sets the levels.
        /// </summary>
        public ObservableCollection<string> Levels
        {
            get
            {
                return this.levels;
            }

            set
            {
                if (this.levels != value)
                {
                    this.levels = value;
                    this.OnPropertyChanged("Levels");
                }
            }
        }

        /// <summary>
        ///     Gets the ok command.
        /// </summary>
        public DelegateCommand<object> OkCommand
        {
            get
            {
                return this.okCommand ?? (this.okCommand = new DelegateCommand<object>(this.OkCommandExecute));
            }
        }

        /// <summary>
        ///     Gets or sets the selected level.
        /// </summary>
        public int SelectedLevel
        {
            get
            {
                return this.mselectedLevel;
            }

            set
            {
                if (this.mselectedLevel != value)
                {
                    this.mselectedLevel = value;
                    this.OnPropertyChanged("SelectedLevel");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the selected shape.
        /// </summary>
        public object SelectedShape
        {
            get
            {
                return this._mSelectedShape;
            }

            set
            {
                if (this._mSelectedShape != value)
                {
                    this._mSelectedShape = value;
                    this.OnPropertyChanged("SelectedShape");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the selected style.
        /// </summary>
        public object SelectedStyle
        {
            get
            {
                return this._mSelectedStyle;
            }

            set
            {
                if (this._mSelectedStyle != value)
                {
                    this._mSelectedStyle = value;
                    this.OnPropertyChanged("SelectedStyle");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the style diagram.
        /// </summary>
        public BrainstormingVM StyleDiagram
        {
            get
            {
                return this.styleDiagram;
            }

            set
            {
                if (this.styleDiagram != value)
                {
                    this.styleDiagram = value;
                    this.OnPropertyChanged("StyleDiagram");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the theme styles collection.
        /// </summary>
        public ObservableCollection<ThemeStyleButtonVM> ThemeStylesCollection
        {
            get
            {
                return this._mThemeStylesCollection;
            }

            set
            {
                if (this._mThemeStylesCollection != value)
                {
                    this._mThemeStylesCollection = value;
                    this.OnPropertyChanged("ThemeStylesCollection");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the topics.
        /// </summary>
        public ObservableCollection<string> Topics
        {
            get
            {
                return this.topics;
            }

            set
            {
                if (this.topics != value)
                {
                    this.topics = value;
                    this.OnPropertyChanged("Topics");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the selected diagram level shapes.
        /// </summary>
        private Dictionary<int, string> SelectedDiagramLevelShapes { get; set; }

        /// <summary>
        ///     Gets or sets the selected diagram level styles.
        /// </summary>
        private Dictionary<int, StyleId> SelectedDiagramLevelStyles { get; set; }

        /// <summary>
        ///     The generate theme style collection.
        /// </summary>
        public void GenerateThemeStyleCollection()
        {
            if (this.ThemeStylesCollection == null)
            {
                this.ThemeStylesCollection = new ObservableCollection<ThemeStyleButtonVM>
                                                 {
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Variant1,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[StyleId.Variant1],
                                                             ColumnNumber = 0
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Variant2,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[StyleId.Variant2],
                                                             ColumnNumber = 1
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Variant3,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[StyleId.Variant3],
                                                             ColumnNumber = 2
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Variant4,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[StyleId.Variant4],
                                                             ColumnNumber = 3
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Subtly | StyleId.Accent1,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Subtly | StyleId.Accent1],
                                                             ColumnNumber = 0,
                                                             RowNumber = 1
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Subtly | StyleId.Accent2,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Subtly | StyleId.Accent2],
                                                             ColumnNumber = 1,
                                                             RowNumber = 1
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Subtly | StyleId.Accent3,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Subtly | StyleId.Accent3],
                                                             ColumnNumber = 2,
                                                             RowNumber = 1
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Subtly | StyleId.Accent4,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Subtly | StyleId.Accent4],
                                                             ColumnNumber = 3,
                                                             RowNumber = 1
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Subtly | StyleId.Accent5,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Subtly | StyleId.Accent5],
                                                             ColumnNumber = 4,
                                                             RowNumber = 1
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Subtly | StyleId.Accent6,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Subtly | StyleId.Accent6],
                                                             ColumnNumber = 5,
                                                             RowNumber = 1
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Subtly | StyleId.Accent7,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Subtly | StyleId.Accent7],
                                                             ColumnNumber = 6,
                                                             RowNumber = 1
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Refined | StyleId.Accent1,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Refined | StyleId.Accent1],
                                                             ColumnNumber = 0,
                                                             RowNumber = 2
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Refined | StyleId.Accent2,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Refined | StyleId.Accent2],
                                                             ColumnNumber = 1,
                                                             RowNumber = 2
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Refined | StyleId.Accent3,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Refined | StyleId.Accent3],
                                                             ColumnNumber = 2,
                                                             RowNumber = 2
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Refined | StyleId.Accent4,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Refined | StyleId.Accent3],
                                                             ColumnNumber = 3,
                                                             RowNumber = 2
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Refined | StyleId.Accent5,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Refined | StyleId.Accent5],
                                                             ColumnNumber = 4,
                                                             RowNumber = 2
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Refined | StyleId.Accent6,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Refined | StyleId.Accent7],
                                                             ColumnNumber = 5,
                                                             RowNumber = 2
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Refined | StyleId.Accent7,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Refined | StyleId.Accent7],
                                                             ColumnNumber = 6,
                                                             RowNumber = 2
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Balanced | StyleId.Accent1,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Balanced | StyleId.Accent1],
                                                             ColumnNumber = 0,
                                                             RowNumber = 3
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Balanced | StyleId.Accent2,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Balanced | StyleId.Accent2],
                                                             ColumnNumber = 1,
                                                             RowNumber = 3
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Balanced | StyleId.Accent3,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Balanced | StyleId.Accent3],
                                                             ColumnNumber = 2,
                                                             RowNumber = 3
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Balanced | StyleId.Accent4,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Balanced | StyleId.Accent4],
                                                             ColumnNumber = 3,
                                                             RowNumber = 3
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Balanced | StyleId.Accent5,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Balanced | StyleId.Accent5],
                                                             ColumnNumber = 4,
                                                             RowNumber = 3
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Balanced | StyleId.Accent6,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Balanced | StyleId.Accent6],
                                                             ColumnNumber = 5,
                                                             RowNumber = 3
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Balanced | StyleId.Accent7,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Balanced | StyleId.Accent7],
                                                             ColumnNumber = 6,
                                                             RowNumber = 3
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Moderate | StyleId.Accent1,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Moderate | StyleId.Accent1],
                                                             ColumnNumber = 0,
                                                             RowNumber = 4
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Moderate | StyleId.Accent2,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Moderate | StyleId.Accent2],
                                                             ColumnNumber = 1,
                                                             RowNumber = 4
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Moderate | StyleId.Accent3,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Moderate | StyleId.Accent2],
                                                             ColumnNumber = 2,
                                                             RowNumber = 4
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Moderate | StyleId.Accent4,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Moderate | StyleId.Accent4],
                                                             ColumnNumber = 3,
                                                             RowNumber = 4
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Moderate | StyleId.Accent5,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Moderate | StyleId.Accent5],
                                                             ColumnNumber = 4,
                                                             RowNumber = 4
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Moderate | StyleId.Accent6,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Moderate | StyleId.Accent6],
                                                             ColumnNumber = 5,
                                                             RowNumber = 4
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Moderate | StyleId.Accent7,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Moderate | StyleId.Accent7],
                                                             ColumnNumber = 6,
                                                             RowNumber = 4
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Focused | StyleId.Accent1,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Focused | StyleId.Accent1],
                                                             ColumnNumber = 0,
                                                             RowNumber = 5
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Focused | StyleId.Accent2,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Focused | StyleId.Accent2],
                                                             ColumnNumber = 1,
                                                             RowNumber = 5
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Focused | StyleId.Accent3,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Focused | StyleId.Accent3],
                                                             ColumnNumber = 2,
                                                             RowNumber = 5
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Focused | StyleId.Accent4,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Focused | StyleId.Accent4],
                                                             ColumnNumber = 3,
                                                             RowNumber = 5
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Focused | StyleId.Accent5,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Focused | StyleId.Accent5],
                                                             ColumnNumber = 4,
                                                             RowNumber = 5
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Focused | StyleId.Accent6,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Focused | StyleId.Accent6],
                                                             ColumnNumber = 5,
                                                             RowNumber = 5
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Focused | StyleId.Accent7,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Focused | StyleId.Accent7],
                                                             ColumnNumber = 6,
                                                             RowNumber = 5
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Intense | StyleId.Accent1,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Intense | StyleId.Accent1],
                                                             ColumnNumber = 0,
                                                             RowNumber = 6
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Intense | StyleId.Accent2,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Intense | StyleId.Accent2],
                                                             ColumnNumber = 1,
                                                             RowNumber = 6
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Intense | StyleId.Accent3,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Intense | StyleId.Accent3],
                                                             ColumnNumber = 2,
                                                             RowNumber = 6
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Intense | StyleId.Accent4,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Intense | StyleId.Accent3],
                                                             ColumnNumber = 3,
                                                             RowNumber = 6
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Intense | StyleId.Accent5,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Intense | StyleId.Accent5],
                                                             ColumnNumber = 4,
                                                             RowNumber = 6
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Intense | StyleId.Accent6,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Intense | StyleId.Accent6],
                                                             ColumnNumber = 5,
                                                             RowNumber = 6
                                                         },
                                                     new ThemeStyleButtonVM
                                                         {
                                                             ThemeStyleId = StyleId.Intense | StyleId.Accent7,
                                                             ShapeStyle =
                                                                 this.StyleDiagram.Theme.NodeStyles[
                                                                     StyleId.Intense | StyleId.Accent7],
                                                             ColumnNumber = 6,
                                                             RowNumber = 6
                                                         }
                                                 };
            }
        }

        /// <summary>
        ///     Applying level based style from diagram to style diagram.
        /// </summary>
        internal void ApplyLevelStyle()
        {
            this.SelectedLevel = 0;
            this.StyleDiagram.Theme = this.DiagramBuilderVM.SelectedDiagram.Theme;
            IEnumerable<BrainstormingNodeVM> nodes = (this.DiagramBuilderVM.SelectedDiagram.Nodes as NodeVMCollection)
                .GroupBy(x => x.Level).Select(x => x.FirstOrDefault());
            this.SelectedDiagramLevelStyles = new Dictionary<int, StyleId>();
            this.SelectedDiagramLevelShapes = new Dictionary<int, string>();
            foreach (BrainstormingNodeVM node in nodes)
            {
                this.SelectedDiagramLevelStyles.Add(node.Level, node.ThemeStyleId);
                this.SelectedDiagramLevelShapes.Add(node.Level, node.ShapeName);
            }

            foreach (BrainstormingNodeVM node in this.StyleDiagram.Nodes as NodeVMCollection)
            {
                if (this.SelectedDiagramLevelStyles.Count - 1 >= node.Level)
                {
                    node.ThemeStyleId = this.SelectedDiagramLevelStyles[node.Level];
                }

                if (this.SelectedDiagramLevelShapes.Count - 1 >= node.Level)
                {
                    node.ShapeName = this.SelectedDiagramLevelShapes[node.Level];
                }
            }

            this.SelectedShape = this.SelectedDiagramLevelShapes[this.SelectedLevel];

            StyleId selectedLevelStyleID = nodes.ToList()[this.SelectedLevel].ThemeStyleId;
            foreach (ThemeStyleButtonVM themeStyleButtonVM in this.ThemeStylesCollection)
            {
                if (themeStyleButtonVM.ThemeStyleId == selectedLevelStyleID)
                {
                    this.SelectedStyle = themeStyleButtonVM;
                    break;
                }
            }

            if (this.DiagramBuilderVM.SelectedDiagram.DefaultConnectorType == ConnectorType.CubicBezier)
            {
                this.StyleDiagram.DefaultConnectorType = ConnectorType.CubicBezier;

                // SelectedConnectorStyle = "Curved";
                this.IsStraightConnectorType = false;
            }
            else
            {
                this.StyleDiagram.DefaultConnectorType = ConnectorType.Orthogonal;

                // SelectedConnectorStyle = "Straight";
                this.IsStraightConnectorType = true;
            }
        }

        /// <summary>
        ///     The update topics.
        /// </summary>
        internal void UpdateTopics()
        {
            if (this.SelectedLevel == 0)
            {
                this.Topics = new ObservableCollection<string> { "Oval", "Cloud", "Rectangle", "Starburst" };
            }
            else
            {
                this.Topics = new ObservableCollection<string>
                                  {
                                      "Oval",
                                      "Cloud",
                                      "Rectangle",
                                      "Line",
                                      "Freehand",
                                      "Wave"
                                  };
            }
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
                case "SelectedStyle":
                    this.LevelBasedStyleChanged();
                    break;
                case "SelectedShape":
                    if (this.SelectedShape != null)
                    {
                        this.LevelBasedShapeChanged();
                        this.SelectedDiagramLevelShapes[this.SelectedLevel] = this.SelectedShape.ToString();
                    }

                    break;
                case "IsStraightConnectorType":
                    this.ConnectorTypeChanged();
                    break;
                case "SelectedLevel":
                    this.UpdateTopics();
                    this.SelectedLevelChanged();
                    break;
            }
        }

        /// <summary>
        /// Method will execute when ApplyCommand executed
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void ApplyCommandExecute(object obj)
        {
            BrainstormingVM diagramVM = this.DiagramBuilderVM.SelectedDiagram as BrainstormingVM;
            diagramVM.ChangeDiagramStyleForConnector(diagramVM, this.IsStraightConnectorType ? "Straight" : "Curved");
            foreach (KeyValuePair<int, StyleId> style in this.SelectedDiagramLevelStyles)
            {
                if (diagramVM.LevelStyles.Count > style.Key)
                {
                    diagramVM.LevelStyles[style.Key] = new System.Tuple<string, StyleId>(
                        diagramVM.LevelStyles[style.Key].Item1,
                        style.Value);
                }

                diagramVM.ChangeStyleIdForSelectedLevel();
            }

            foreach (KeyValuePair<int, string> style in this.SelectedDiagramLevelShapes)
            {
                if (diagramVM.LevelStyles.Count > style.Key)
                {
                    diagramVM.LevelStyles[style.Key] = new System.Tuple<string, StyleId>(
                        style.Value,
                        diagramVM.LevelStyles[style.Key].Item2);
                }

                diagramVM.ChangeItemShapeForSelectedLevel();
            }

            // IsStraightConnectorType = true;
        }

        /// <summary>
        /// Method will execute when CancelCommand executed
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void CancelCommandExecute(object obj)
        {
            this.DiagramBuilderVM.OpenCloseWindowBehavior.OpenDiagramStyleWindow = false;
        }

        /// <summary>
        ///     The connector type changed.
        /// </summary>
        private void ConnectorTypeChanged()
        {
            if (this.StyleDiagram != null)
            {
                foreach (BrainstormingConnectorVM connector in this.StyleDiagram.Connectors as ConnectorVMCollection)
                {
                    if (!this.IsStraightConnectorType)
                    {
                        connector.Segments = new ObservableCollection<IConnectorSegment> { new CubicCurveSegment() };
                    }
                    else
                    {
                        connector.Segments = new ObservableCollection<IConnectorSegment> { new OrthogonalSegment() };
                    }
                }
            }
        }

        /// <summary>
        /// Method will execute when KeyDownCommand executed
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void KeyDownCommandExecute(object obj)
        {
            this.OkCommand.Execute(null);
        }

        /// <summary>
        ///     The level based shape changed.
        /// </summary>
        private void LevelBasedShapeChanged()
        {
            if (this.SelectedShape != null)
            {
                string obj = this.SelectedShape.ToString();
                if (this.SelectedDiagramLevelShapes.ContainsKey(this.SelectedLevel))
                {
                    this.SelectedDiagramLevelShapes[this.SelectedLevel] = obj;
                }
                else
                {
                    this.SelectedDiagramLevelShapes.Add(this.SelectedLevel, obj);
                }

                foreach (BrainstormingNodeVM nodeVM in this.StyleDiagram.Nodes as NodeVMCollection)
                {
                    if (nodeVM.Level == this.SelectedLevel)
                    {
                        nodeVM.Shape = resourceDictionary[obj];
                    }
                }
            }
        }

        /// <summary>
        ///     The level based style changed.
        /// </summary>
        private void LevelBasedStyleChanged()
        {
            StyleId styleId = (this.SelectedStyle as ThemeStyleButtonVM).ThemeStyleId;
            if (this.SelectedDiagramLevelStyles.ContainsKey(this.SelectedLevel))
            {
                this.SelectedDiagramLevelStyles[this.SelectedLevel] = styleId;
            }
            else
            {
                this.SelectedDiagramLevelStyles.Add(this.SelectedLevel, styleId);
            }

            foreach (BrainstormingNodeVM node in this.StyleDiagram.Nodes as NodeVMCollection)
            {
                if (node.Level == this.SelectedLevel)
                {
                    node.ThemeStyleId = styleId;
                }
            }
        }

        /// <summary>
        /// Method will execute when OkCommand executed
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OkCommandExecute(object obj)
        {
            this.ApplyCommand.Execute(null);
            this.DiagramBuilderVM.OpenCloseWindowBehavior.OpenDiagramStyleWindow = false;
        }

        /// <summary>
        ///     The selected level changed.
        /// </summary>
        private void SelectedLevelChanged()
        {
            IEnumerable<BrainstormingNodeVM> nodes = (this.DiagramBuilderVM.SelectedDiagram.Nodes as NodeVMCollection)
                .GroupBy(x => x.Level).Select(x => x.FirstOrDefault());
            if (this.SelectedDiagramLevelShapes.Count - 1 >= this.SelectedLevel)
            {
                this.SelectedShape = this.SelectedDiagramLevelShapes[this.SelectedLevel];
            }

            if (this.SelectedDiagramLevelStyles.Count - 1 >= this.SelectedLevel)
            {
                StyleId selectedStyleID = nodes.ToList()[this.SelectedLevel].ThemeStyleId;
                foreach (ThemeStyleButtonVM themeStyleButtonVM in this.ThemeStylesCollection)
                {
                    if (themeStyleButtonVM.ThemeStyleId == selectedStyleID)
                    {
                        this.SelectedStyle = themeStyleButtonVM;
                        break;
                    }
                }
            }
        }
    }
}