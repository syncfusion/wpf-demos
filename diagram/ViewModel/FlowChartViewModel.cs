#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class FlowChartViewModel : DiagramViewModel
    {
        #region fields       

        private List<string> _orientation = new List<string> { "Horizontal", "Vertical" };

        private List<string> _yesdirection = new List<string> { "Same as flow", "Left in flow", "Right in flow" };

        private List<string> _nodirection = new List<string> { "Same as flow", "Left in flow", "Right in flow" };

        private string _layoutDirection = "Vertical";

        private string _yesTreeDirection = "Left in flow";

        private string _noTreeDirection = "Right in flow";

        #endregion

        public DemoControl View;

        public FlowChartViewModel(DemoControl demo)
        {
            View = demo;
            //This command will get invoked when an item is added to the diagram.
            ItemAddedCommand = new DelegateCommand(args => OnItemAdded((ItemAddedEventArgs)args));


            Constraints = Constraints.Remove(GraphConstraints.PageEditing, GraphConstraints.PanRails);

            //Initialize Context menu for diagram.
            Menu = null;

            // Initialize DataSourceSettings for SfDiagram
            DataSourceSettings = new FlowchartDataSourceSettings()
            {
                ParentId = "ParentId",
                Id = "Id",
                DataSource = GetData(),
                ConnectorTextMapping = "Label",
                ContentMapping = "Name",
                ShapeMapping = "_Shape",
                WidthMapping = "_Width",
                HeightMapping = "_Height"
            };

            // Initialize LayoutSettings for SfDiagram
            LayoutManager = new LayoutManager()
            {
                Layout = new FlowchartLayout()
                {
                    Orientation = FlowchartOrientation.TopToBottom,
                    YesBranchValues = new List<string> { "Yes", "True", "Y", "s" },
                    YesBranchDirection = BranchDirection.LeftInFlow,
                    NoBranchValues = new List<string> { "No", "N", "False", "no" },
                    NoBranchDirection = BranchDirection.RightInFlow,
                    HorizontalSpacing = 50,
                    VerticalSpacing = 50,
                },
            };
        }

        private void OnItemAdded(ItemAddedEventArgs args)
        {
            if (args.Item is ConnectorViewModel)
            {
                var connectorannotations = (args.Item as ConnectorViewModel).Annotations as AnnotationCollection;
                foreach (AnnotationEditorViewModel anno in connectorannotations)
                {
                    anno.ViewTemplate = View.Resources["ConnectorAnnotationFlowChartTemplate"] as DataTemplate;
                }
            }
            else if (args.Item is NodeViewModel)
            {
                var nodeannotations = (args.Item as NodeViewModel).Annotations as AnnotationCollection;
                foreach (AnnotationEditorViewModel anno in nodeannotations)
                {
                    anno.TextHorizontalAlignment = TextAlignment.Center;
                }
            }
        }

        #region Methods and Properties


        /// <summary>
        /// Gets or sets the value for Position
        /// </summary>
        public string OrientationDirection
        {
            get
            {
                return _layoutDirection;
            }
            set
            {
                if (_layoutDirection != value)
                {
                    _layoutDirection = value;
                    OnPropertyChanged("OrientationDirection");
                    OnOrientationDirectionChanged(_layoutDirection);
                }
            }
        }

        private void OnOrientationDirectionChanged(string layoutDirection)
        {
            if (layoutDirection == "Vertical")
            {
                (this.LayoutManager.Layout as FlowchartLayout).Orientation = FlowchartOrientation.TopToBottom;
            }
            else if (layoutDirection == "Horizontal")
            {
                (this.LayoutManager.Layout as FlowchartLayout).Orientation = FlowchartOrientation.LeftToRight;
            }
        }

        /// <summary>
        /// Gets or sets the value for MShape
        /// </summary>
        public string YesDirection
        {
            get
            {
                return _yesTreeDirection;
            }
            set
            {
                if (_yesTreeDirection != value)
                {
                    _yesTreeDirection = value;
                    OnPropertyChanged("YesDirection");
                    OnYesDirectionChanged(_yesTreeDirection);
                }
            }
        }

        private void OnYesDirectionChanged(string yesTreeDirection)
        {
            if (yesTreeDirection == "Same as flow")
            {
                (this.LayoutManager.Layout as FlowchartLayout).YesBranchDirection = BranchDirection.SameAsFlow;
            }
            else if (yesTreeDirection == "Left in flow")
            {
                (this.LayoutManager.Layout as FlowchartLayout).YesBranchDirection = BranchDirection.LeftInFlow;
            }
            else if (yesTreeDirection == "Right in flow")
            {
                (this.LayoutManager.Layout as FlowchartLayout).YesBranchDirection = BranchDirection.RightInFlow;
            }
        }

        /// <summary>
        /// Gets or sets the value for MContent
        /// </summary>
        public string NoDirection
        {
            get
            {
                return _noTreeDirection;
            }
            set
            {
                if (_noTreeDirection != value)
                {
                    _noTreeDirection = value;
                    OnPropertyChanged("NoDirection");
                    OnNoDirectionChanged(_noTreeDirection);
                }
            }
        }

        private void OnNoDirectionChanged(string noTreeDirection)
        {
            if (noTreeDirection == "Left in flow")
            {
                (this.LayoutManager.Layout as FlowchartLayout).NoBranchDirection = BranchDirection.LeftInFlow;
            }
            else if (noTreeDirection == "Same as flow")
            {
                (this.LayoutManager.Layout as FlowchartLayout).NoBranchDirection = BranchDirection.SameAsFlow;
            }
            else if (noTreeDirection == "Right in flow")
            {
                (this.LayoutManager.Layout as FlowchartLayout).NoBranchDirection = BranchDirection.RightInFlow;
            }
        }

        public List<string> Orientations
        {
            get
            {
                return _orientation;
            }
        }

        public List<string> YesDirections
        {
            get
            {
                return _yesdirection;
            }
        }

        public List<string> NoDirections
        {
            get
            {
                return _nodirection;
            }
        }

        /// <summary>
        /// Method to Get Data for DataSource
        /// </summary>
        /// <param name="data"></param>
        private FlowChartModels GetData()
        {
            FlowChartModels ItemsInfo = new FlowChartModels();
            var resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
            };
            
            #region flow
            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "1",
                Name = "Start",
                _Shape = resourceDictionary["StartOrEnd"] as string,
                _Width = 120,
                _Height = 40,
                _Color = "#8E44CC"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "2",
                Name = "Open the browser and go to Amazon site",
                ParentId = new List<string> { "1" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 150,
                _Height = 50,
                _Color = "#1759B7"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "3",
                Name = "Already a customer?",
                ParentId = new List<string> { "2" },
                _Shape = resourceDictionary["Decision"] as string,
                _Width = 150,
                _Height = 80,
                _Color = "#2F95D8"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "4",
                Label = new List<string> { "No" },
                Name = "Create an account",
                ParentId = new List<string> { "3" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 150,
                _Height = 50,
                _Color = "#70AF16"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "5",
                Label = new List<string> { "Yes" },
                Name = "Enter login information",
                ParentId = new List<string>() { "3" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 150,
                _Height = 50,
                _Color = "#70AF16"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "6",
                Name = "Search for the book in the search bar",
                ParentId = new List<string> { "5", "4" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 150,
                _Height = 50,
                _Color = "#1759B7"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "7",
                Name = "Select the preferred book",
                ParentId = new List<string> { "6" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 150,
                _Height = 50,
                _Color = "#1759B7"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "8",
                Name = "Is the book new or used?",
                ParentId = new List<string> { "7" },
                _Shape = resourceDictionary["Decision"] as string,
                _Width = 180,
                _Height = 80,
                _Color = "#2F95D8"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "9",
                Label = new List<string> { "Yes" },
                Name = "Select the new book",
                ParentId = new List<string> { "8" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 150,
                _Height = 50,
                _Color = "#70AF16"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "10",
                Label = new List<string> { "No" },
                Name = "Select the used book",
                ParentId = new List<string> { "8" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 150,
                _Height = 50,
                _Color = "#70AF16"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "11",
                Name = "Add to Cart & Proceed to Checkout",
                ParentId = new List<string> { "9", "10" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 155,
                _Height = 50,
                _Color = "#1759B7"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "12",
                Label = new List<string> { "", "False" },
                Name = "Enter shipping and payment details",
                ParentId = new List<string> { "11", "13" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 155,
                _Height = 50,
                _Color = "#1759B7"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "13",
                Name = "Is the information correct?",
                ParentId = new List<string> { "12" },
                _Shape = resourceDictionary["Decision"] as string,
                _Width = 180,
                _Height = 100,
                _Color = "#2F95D8"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "14",
                Label = new List<string> { "True" },
                Name = "Review and place the order",
                ParentId = new List<string> { "13" },
                _Shape = resourceDictionary["Rectangle"] as string,
                _Width = 150,
                _Height = 50,
                _Color = "#1759B7"
            });

            ItemsInfo.Add(new FlowChartModel()
            {
                Id = "15",
                Name = "End",
                ParentId = new List<string> { "14" },
                _Shape = resourceDictionary["StartOrEnd"] as string,
                _Width = 120,
                _Height = 40,
                _Color = "#8E44CC"
            });
            #endregion

            return ItemsInfo;
        }

        #endregion
    }
}
