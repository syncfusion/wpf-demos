#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.MindMapDiagram.Utility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.UI.Xaml.MindMapDiagram.ViewModel
{
    public class DiagramStyleViewModel : DiagramElementViewModel
    {
        Dictionary<int, StyleId> SelectedDiagramLevelStyles { get; set; }
        Dictionary<int, string> SelectedDiagramLevelShapes { get; set; }

        private MindMapViewModel styleDiagram;
        private object _mSelectedStyle;
        private object _mSelectedShape;
        private MindMapViewModel diagramBuilderVM;
        private ObservableCollection<string> levels;
        private ObservableCollection<ThemeStyleButtonVM> _mThemeStylesCollection;
        private ObservableCollection<string> topics;
        private ObservableCollection<string> connectorStyles;
        private int mselectedLevel = 0;
        private bool _mIsStraightConnectorType = false;
        public int SelectedLevel
        {
            get { return mselectedLevel; }
            set
            {
                if (mselectedLevel != value)
                {
                    mselectedLevel = value;
                    OnPropertyChanged("SelectedLevel");
                }
            }
        }
        public MindMapViewModel StyleDiagram
        {
            get { return styleDiagram; }
            set
            {
                if (styleDiagram != value)
                {
                    styleDiagram = value;
                    OnPropertyChanged("StyleDiagram");
                }
            }
        }

        public object SelectedStyle
        {
            get { return _mSelectedStyle; }
            set
            {
                if (_mSelectedStyle != value)
                {
                    _mSelectedStyle = value;
                    OnPropertyChanged("SelectedStyle");
                }
            }
        }
        public object SelectedShape
        {
            get { return _mSelectedShape; }
            set
            {
                if (_mSelectedShape != value)
                {
                    _mSelectedShape = value;
                    OnPropertyChanged("SelectedShape");

                }
            }
        }
        public bool IsStraightConnectorType
        {
            get { return _mIsStraightConnectorType; }
            set
            {
                if (_mIsStraightConnectorType != value)
                {
                    _mIsStraightConnectorType = value;
                    OnPropertyChanged("IsStraightConnectorType");
                }
            }
        }

        /// <summary>
        /// Gets applications diagram builder vm.
        /// </summary>
        public MindMapViewModel MindMapViewModel
        {
            get { return diagramBuilderVM; }
            set
            {
                if (diagramBuilderVM != value)
                {
                    diagramBuilderVM = value;
                    OnPropertyChanged("MindMapViewModel");
                }
            }
        }
        public ObservableCollection<string> Levels
        {
            get { return levels; }
            set
            {
                if (levels != value)
                {
                    levels = value;
                    OnPropertyChanged("Levels");
                }
            }
        }
        public ObservableCollection<ThemeStyleButtonVM> ThemeStylesCollection
        {
            get { return _mThemeStylesCollection; }
            set
            {
                if (_mThemeStylesCollection != value)
                {
                    _mThemeStylesCollection = value;
                    OnPropertyChanged("ThemeStylesCollection");
                }
            }
        }
        public ObservableCollection<string> Topics
        {
            get { return topics; }
            set
            {
                if (topics != value)
                {
                    topics = value;
                    OnPropertyChanged("Topics");
                }
            }
        }
        /// <summary>
        /// Gets or sets collection of connector styes.
        /// </summary>
        public ObservableCollection<string> ConnectorStyles
        {
            get { return connectorStyles; }
            set
            {
                if (connectorStyles != value)
                {
                    connectorStyles = value;
                    OnPropertyChanged("ConnectorStyles");
                }
            }
        }
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch (name)
            {
                case "SelectedStyle":
                    LevelBasedStyleChanged();
                    break;
                case "SelectedShape":
                    if (SelectedShape != null)
                    {
                        LevelBasedShapeChanged();
                        SelectedDiagramLevelShapes[SelectedLevel] = SelectedShape.ToString();
                    }
                    break;
                case "IsStraightConnectorType":
                    ConnectorTypeChanged();
                    break;
                case "SelectedLevel":
                    UpdateTopics();
                    SelectedLevelChanged();
                    break;
            }
        }

        #region Constructor
        public DiagramStyleViewModel(MindMapViewModel mindMapViewModel)
        {
            MindMapViewModel = mindMapViewModel;

            ConnectorStyles = new ObservableCollection<string>() { "Curved", "Straight" };
            Levels = new ObservableCollection<string>()
            {
                "Root",
                "Level 1",
                "Level 2",
                "Level 3",
                "Level 4",
            };
            Topics = new ObservableCollection<string>() { "Oval", "Cloud", "Rectangle", "Line", "Freehand", "Wave" };
        }

        #endregion
        #region Public Commands
        DelegateCommand<object> applyCommand;
        DelegateCommand<object> okCommand;
        DelegateCommand<object> cancelCommand;
        DelegateCommand<object> keyDownCommand;
        public DelegateCommand<object> ApplyCommand
        {
            get
            {
                return applyCommand ??
                    (applyCommand = new DelegateCommand<object>(ApplyCommandExecute));
            }
        }
        public DelegateCommand<object> OkCommand
        {
            get
            {
                return okCommand ??
                    (okCommand = new DelegateCommand<object>(OkCommandExecute));
            }
        }
        public DelegateCommand<object> CancelCommand
        {
            get
            {
                return cancelCommand ??
                    (cancelCommand = new DelegateCommand<object>(CancelCommandExecute));
            }
        }
        public DelegateCommand<object> KeyDownCommand
        {
            get
            {
                return keyDownCommand ??
                    (keyDownCommand = new DelegateCommand<object>(KeyDownCommandExecute));
            }
        }

        #endregion
        #region Internal Methods
        internal void UpdateTopics()
        {
            if (SelectedLevel == 0)
            {
                Topics = new ObservableCollection<string>() { "Oval", "Cloud", "Rectangle", "Starburst" };
            }
            else
            {
                Topics = new ObservableCollection<string>() { "Oval", "Cloud", "Rectangle", "Line", "Freehand", "Wave" };
            }
        }
        #endregion
        #region Private Properties
        /// <summary>
        /// Method will execute when ApplyCommand executed
        /// </summary>
        private void ApplyCommandExecute(object obj)
        {

            MindMapViewModel.ChangeDiagramStyleForConnector(MindMapViewModel, IsStraightConnectorType ? "Straight" : "Curved");
            foreach (var style in SelectedDiagramLevelStyles)
            {
                if (MindMapViewModel.LevelStyles.Count > style.Key)
                {
                    MindMapViewModel.LevelStyles[style.Key] = new System.Tuple<string, StyleId>(MindMapViewModel.LevelStyles[style.Key].Item1, style.Value);
                }
                MindMapViewModel.ChangeStyleIdForSelectedLevel();
            }
            foreach (var style in SelectedDiagramLevelShapes)
            {
                if (MindMapViewModel.LevelStyles.Count > style.Key)
                {
                    MindMapViewModel.LevelStyles[style.Key] = new System.Tuple<string, StyleId>(style.Value, MindMapViewModel.LevelStyles[style.Key].Item2);
                }
                MindMapViewModel.ChangeItemShapeForSelectedLevel();
            }
            //IsStraightConnectorType = true;
        }
        /// <summary>
        /// Method will execute when KeyDownCommand executed
        /// </summary>
        private void KeyDownCommandExecute(object obj)
        {
            OkCommand.Execute(null);
        }

        /// <summary>
        /// Method will execute when CancelCommand executed
        /// </summary>
        private void CancelCommandExecute(object obj)
        {
            MindMapViewModel.OpenCloseWindowBehavior.OpenDiagramStyleWindow = false;
        }
        /// <summary>
        /// Method will execute when OkCommand executed
        /// </summary>
        private void OkCommandExecute(object obj)
        {
            ApplyCommand.Execute(null);
            MindMapViewModel.OpenCloseWindowBehavior.OpenDiagramStyleWindow = false;
        }
        public void GenerateThemeStyleCollection()
        {
            if (ThemeStylesCollection == null)
            {
                ThemeStylesCollection = new ObservableCollection<ThemeStyleButtonVM>()
            {
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Variant1, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Variant1], ColumnNumber = 0 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Variant2, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Variant2], ColumnNumber = 1 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Variant3, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Variant3], ColumnNumber = 2 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Variant4, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Variant4], ColumnNumber = 3 },

                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Subtly | StyleId.Accent1, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Subtly | StyleId.Accent1], ColumnNumber = 0, RowNumber = 1 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Subtly | StyleId.Accent2, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Subtly | StyleId.Accent2], ColumnNumber = 1, RowNumber = 1 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Subtly | StyleId.Accent3, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Subtly | StyleId.Accent3], ColumnNumber = 2, RowNumber = 1 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Subtly | StyleId.Accent4, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Subtly | StyleId.Accent4], ColumnNumber = 3, RowNumber = 1 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Subtly | StyleId.Accent5, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Subtly | StyleId.Accent5], ColumnNumber = 4, RowNumber = 1 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Subtly | StyleId.Accent6, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Subtly | StyleId.Accent6], ColumnNumber = 5, RowNumber = 1 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Subtly | StyleId.Accent7, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Subtly | StyleId.Accent7], ColumnNumber = 6, RowNumber = 1 },

                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Refined | StyleId.Accent1, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Refined | StyleId.Accent1], ColumnNumber = 0, RowNumber = 2 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Refined | StyleId.Accent2, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Refined | StyleId.Accent2], ColumnNumber = 1, RowNumber = 2 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Refined | StyleId.Accent3, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Refined | StyleId.Accent3], ColumnNumber = 2, RowNumber = 2 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Refined | StyleId.Accent4, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Refined | StyleId.Accent3], ColumnNumber = 3, RowNumber = 2 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Refined | StyleId.Accent5, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Refined | StyleId.Accent5], ColumnNumber = 4, RowNumber = 2 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Refined | StyleId.Accent6, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Refined | StyleId.Accent7], ColumnNumber = 5, RowNumber = 2 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Refined | StyleId.Accent7, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Refined | StyleId.Accent7], ColumnNumber = 6, RowNumber = 2 },

                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Balanced | StyleId.Accent1, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Balanced | StyleId.Accent1], ColumnNumber = 0, RowNumber = 3 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Balanced | StyleId.Accent2, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Balanced | StyleId.Accent2], ColumnNumber = 1, RowNumber = 3 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Balanced | StyleId.Accent3, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Balanced | StyleId.Accent3], ColumnNumber = 2, RowNumber = 3 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Balanced | StyleId.Accent4, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Balanced | StyleId.Accent4], ColumnNumber = 3, RowNumber = 3 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Balanced | StyleId.Accent5, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Balanced | StyleId.Accent5], ColumnNumber = 4, RowNumber = 3 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Balanced | StyleId.Accent6, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Balanced | StyleId.Accent6], ColumnNumber = 5, RowNumber = 3 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Balanced | StyleId.Accent7, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Balanced | StyleId.Accent7], ColumnNumber = 6, RowNumber = 3 },

                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Moderate | StyleId.Accent1, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Moderate | StyleId.Accent1], ColumnNumber = 0, RowNumber = 4 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Moderate | StyleId.Accent2, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Moderate | StyleId.Accent2], ColumnNumber = 1, RowNumber = 4 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Moderate | StyleId.Accent3, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Moderate | StyleId.Accent2], ColumnNumber = 2, RowNumber = 4 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Moderate | StyleId.Accent4, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Moderate | StyleId.Accent4], ColumnNumber = 3, RowNumber = 4 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Moderate | StyleId.Accent5, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Moderate | StyleId.Accent5], ColumnNumber = 4, RowNumber = 4 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Moderate | StyleId.Accent6, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Moderate | StyleId.Accent6], ColumnNumber = 5, RowNumber = 4 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Moderate | StyleId.Accent7, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Moderate | StyleId.Accent7], ColumnNumber = 6, RowNumber = 4 },

                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Focused | StyleId.Accent1, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Focused | StyleId.Accent1], ColumnNumber = 0, RowNumber = 5 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Focused | StyleId.Accent2, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Focused | StyleId.Accent2], ColumnNumber = 1, RowNumber = 5 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Focused | StyleId.Accent3, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Focused | StyleId.Accent3], ColumnNumber = 2, RowNumber = 5 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Focused | StyleId.Accent4, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Focused | StyleId.Accent4], ColumnNumber = 3, RowNumber = 5 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Focused | StyleId.Accent5, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Focused | StyleId.Accent5], ColumnNumber = 4, RowNumber = 5 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Focused | StyleId.Accent6, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Focused | StyleId.Accent6], ColumnNumber = 5, RowNumber = 5 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Focused | StyleId.Accent7, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Focused | StyleId.Accent7], ColumnNumber = 6, RowNumber = 5 },

                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Intense | StyleId.Accent1, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Intense | StyleId.Accent1], ColumnNumber = 0, RowNumber = 6 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Intense | StyleId.Accent2, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Intense | StyleId.Accent2], ColumnNumber = 1, RowNumber = 6 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Intense | StyleId.Accent3, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Intense | StyleId.Accent3], ColumnNumber = 2, RowNumber = 6 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Intense | StyleId.Accent4, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Intense | StyleId.Accent3], ColumnNumber = 3, RowNumber = 6 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Intense | StyleId.Accent5, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Intense | StyleId.Accent5], ColumnNumber = 4, RowNumber = 6 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Intense | StyleId.Accent6, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Intense | StyleId.Accent6], ColumnNumber = 5, RowNumber = 6 },
                new ThemeStyleButtonVM(){ ThemeStyleId = StyleId.Intense | StyleId.Accent7, ShapeStyle = StyleDiagram.Theme.NodeStyles[StyleId.Intense | StyleId.Accent7], ColumnNumber = 6, RowNumber = 6 },
            };
            }
        }
        /// <summary>
        /// Applying level based style from diagram to style diagram.
        /// </summary>
        internal void ApplyLevelStyle()
        {
            SelectedLevel = 0;
            StyleDiagram.Theme = MindMapViewModel.Theme;
            var nodes = (MindMapViewModel.Nodes as NodeCollection).GroupBy(x => (x is Root) ? (x as Root).Level : (x as RootChild).Level).Select(x => x.FirstOrDefault());
            SelectedDiagramLevelStyles = new Dictionary<int, StyleId>();
            SelectedDiagramLevelShapes = new Dictionary<int, string>();
            foreach (NodeViewModel node in nodes)
            {
                SelectedDiagramLevelStyles.Add((node is Root) ? (node as Root).Level : (node as RootChild).Level, node.ThemeStyleId);
                SelectedDiagramLevelShapes.Add((node is Root) ? (node as Root).Level : (node as RootChild).Level, (node is Root) ? (node as Root).ShapeName : (node as RootChild).ShapeName);
            }
            foreach (NodeViewModel node in StyleDiagram.Nodes as NodeCollection)
            {
                if (SelectedDiagramLevelStyles.ContainsKey(((node is Root) ? (node as Root).Level : (node as RootChild).Level)))
                {
                    node.ThemeStyleId = SelectedDiagramLevelStyles[(node is Root) ? (node as Root).Level : (node as RootChild).Level];
                }
                if (SelectedDiagramLevelShapes.ContainsKey(((node is Root) ? (node as Root).Level : (node as RootChild).Level)))
                {
                    if (node is Root)
                    {
                        (node as Root).ShapeName = SelectedDiagramLevelShapes[(node is Root) ? (node as Root).Level : (node as RootChild).Level];
                    }
                    else
                    {
                        (node as RootChild).ShapeName = SelectedDiagramLevelShapes[(node is Root) ? (node as Root).Level : (node as RootChild).Level];
                    }
                }
            }
            SelectedShape = SelectedDiagramLevelShapes[SelectedLevel];

            StyleId selectedLevelStyleID = (nodes.ToList()[SelectedLevel] as NodeViewModel).ThemeStyleId;
            foreach (ThemeStyleButtonVM themeStyleButtonVM in ThemeStylesCollection)
            {
                if (themeStyleButtonVM.ThemeStyleId == selectedLevelStyleID)
                {
                    SelectedStyle = themeStyleButtonVM;
                    break;
                }
            }
            if ((MindMapViewModel.Connectors as ConnectorCollection).Count() > 0)
            {
                IConnector connector = (MindMapViewModel.Connectors as ConnectorCollection)[0];
                if (connector.Segments is ObservableCollection<IConnectorSegment>)
                {
                    if ((connector.Segments as ObservableCollection<IConnectorSegment>)[0] is CubicCurveSegment)
                    {
                        StyleDiagram.DefaultConnectorType = ConnectorType.CubicBezier;
                        IsStraightConnectorType = false;
                    }
                    else
                    {
                        StyleDiagram.DefaultConnectorType = ConnectorType.Orthogonal;
                        IsStraightConnectorType = true;
                    }
                }
            }
            else
            {
                if (MindMapViewModel.DefaultConnectorType == ConnectorType.CubicBezier)
                {
                    StyleDiagram.DefaultConnectorType = ConnectorType.CubicBezier;
                    //SelectedConnectorStyle = "Curved";
                    IsStraightConnectorType = false;
                }
                else
                {
                    StyleDiagram.DefaultConnectorType = ConnectorType.Orthogonal;
                    //SelectedConnectorStyle = "Straight";
                    IsStraightConnectorType = true;
                }
            }
        }

        private void LevelBasedShapeChanged()
        {
            if (SelectedShape != null)
            {
                string obj = SelectedShape.ToString();
                if (SelectedDiagramLevelShapes.ContainsKey(SelectedLevel))
                {
                    SelectedDiagramLevelShapes[SelectedLevel] = obj;
                }
                else
                {
                    SelectedDiagramLevelShapes.Add(SelectedLevel, obj);
                }
                foreach (NodeViewModel nodeVM in StyleDiagram.Nodes as NodeCollection)
                {
                    if (((nodeVM is Root) ? (nodeVM as Root).Level : (nodeVM as RootChild).Level) == SelectedLevel)
                    {
                        //nodeVM.Shape = Application.Current.Resources[obj];
                        if(nodeVM is Root)
                        {
                            (nodeVM as Root).ShapeName = obj.ToString();
                        }
                        else
                        {
                            (nodeVM as RootChild).ShapeName = obj.ToString();
                        }
                    }
                }
            }
        }

        private void LevelBasedStyleChanged()
        {
            StyleId styleId = (SelectedStyle as ThemeStyleButtonVM).ThemeStyleId;
            if (SelectedDiagramLevelStyles.ContainsKey(SelectedLevel))
            {
                SelectedDiagramLevelStyles[SelectedLevel] = styleId;
            }
            else
            {
                SelectedDiagramLevelStyles.Add(SelectedLevel, styleId);
            }
            foreach (NodeViewModel node in StyleDiagram.Nodes as NodeCollection)
            {
                if (((node is Root) ? (node as Root).Level : (node as RootChild).Level) == SelectedLevel)
                {
                    node.ThemeStyleId = styleId;
                }
            }
        }
        private void ConnectorTypeChanged()
        {
            if (StyleDiagram != null)
            {
                foreach (ConnectorViewModel connector in StyleDiagram.Connectors as ConnectorCollection)
                {
                    if (!IsStraightConnectorType)
                    {
                        connector.Segments = new ObservableCollection<IConnectorSegment>
                            {
                                new CubicCurveSegment()
                                {
                                }
                            };
                    }
                    else
                    {
                        connector.Segments = new ObservableCollection<IConnectorSegment>
                                {
                                    new OrthogonalSegment()
                                    {
                                    }
                                };
                    }
                }
            }
        }

        private void SelectedLevelChanged()
        {
            var nodes = (MindMapViewModel.Nodes as NodeCollection).GroupBy(x => (x is Root) ? (x as Root).Level :  (x as RootChild).Level).Select(x => x.FirstOrDefault());
            if (SelectedDiagramLevelShapes.ContainsKey(SelectedLevel))
            {
                SelectedShape = SelectedDiagramLevelShapes[SelectedLevel];
            }

            if (SelectedDiagramLevelStyles.ContainsKey(SelectedLevel))
            {
                StyleId selectedStyleID = (nodes.ToList()[SelectedLevel] as NodeViewModel).ThemeStyleId;
                foreach (ThemeStyleButtonVM themeStyleButtonVM in ThemeStylesCollection)
                {
                    if (themeStyleButtonVM.ThemeStyleId == selectedStyleID)
                    {
                        SelectedStyle = themeStyleButtonVM;
                        break;
                    }
                }
            }
        }
        #endregion
    }

    public class ThemeStyleButtonVM : DiagramElementViewModel
    {
        public ThemeStyleButtonVM()
        {

        }

        private int _mColumnNumber;
        private DiagramItemStyle _mShapeStyle;
        private int _mRowNumber = 0;
        private StyleId _mThemeStyleID;

        public int ColumnNumber
        {
            get { return _mColumnNumber; }
            set
            {
                if (_mColumnNumber != value)
                {
                    _mColumnNumber = value;
                    OnPropertyChanged("ColumnNumber");
                }
            }
        }
        public int RowNumber
        {
            get { return _mRowNumber; }
            set
            {
                if (_mRowNumber != value)
                {
                    _mRowNumber = value;
                    OnPropertyChanged("RowNumber");
                }
            }
        }
        public StyleId ThemeStyleId
        {
            get { return _mThemeStyleID; }
            set
            {
                if (_mThemeStyleID != value)
                {
                    _mThemeStyleID = value;
                }
            }
        }
        public DiagramItemStyle ShapeStyle
        {
            get { return _mShapeStyle; }
            set
            {
                if (_mShapeStyle != value)
                {
                    _mShapeStyle = value;
                    OnPropertyChanged("ShapeStyle");
                }
            }
        }
    }
}
