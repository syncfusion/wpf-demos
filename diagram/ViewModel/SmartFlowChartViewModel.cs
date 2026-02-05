#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Model;
using syncfusion.diagramdemo.wpf.Views;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using Microsoft.Extensions.AI;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.IO;
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.XPS;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class SmartFlowChartViewModel : DiagramViewModel
    {
        public DemoControl View;
        private Rect currentViewPort = Rect.Empty; 
        
        private ICommand _NewCommand;
        private ICommand _SaveCommand;
        private ICommand _LoadCommand;
        private ICommand _PanCommand;
        private bool _PanEnabled = true;
        private ICommand _SelectCommand;
        private bool _SelectEnabled = false;
        private ICommand _ZoomInCommand;
        private ICommand _ZoomOutCommand;
        private ICommand _ExportCommand;


        public SmartFlowChartViewModel(DemoControl demo)
        {
            View = demo;
            ItemAddedCommand = new DelegateCommand(args => OnItemAdded((ItemAddedEventArgs)args));
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChangedCommandExecute);
            Menu = null;
            Tool = Tool.MultipleSelect;

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

            NewCommand = new DelegateCommand(OnNew);
            LoadCommand = new DelegateCommand(OnLoad);
            SaveCommand = new DelegateCommand(OnSave);
            ZoomInCommand = new DelegateCommand(ZoomInExecution);
            ZoomOutCommand = new DelegateCommand(ZoomOutExecution);
            PanCommand = new DelegateCommand(PanExecution);
            SelectCommand = new DelegateCommand(SelectExecution);
            ExportCommand = new DelegateCommand(ExportExecution);
            this.PanEnabled = false;
            this.SelectEnabled = true;
        }

        public bool PanEnabled
        {
            get
            {
                return _PanEnabled;
            }
            set
            {
                if (value != _PanEnabled)
                {
                    _PanEnabled = value;
                    OnPropertyChanged("PanEnabled");
                }
            }
        }

        public bool SelectEnabled
        {
            get
            {
                return _SelectEnabled;
            }
            set
            {
                if (value != _SelectEnabled)
                {
                    _SelectEnabled = value;
                    OnPropertyChanged("SelectEnabled");
                }
            }
        }

        public ICommand ZoomInCommand
        {
            get { return _ZoomInCommand; }
            set { _ZoomInCommand = value; }
        }

        public ICommand ZoomOutCommand
        {
            get { return _ZoomOutCommand; }
            set { _ZoomOutCommand = value; }
        }

        public ICommand PanCommand
        {
            get { return _PanCommand; }
            set { _PanCommand = value; }
        }
        public ICommand SelectCommand
        {
            get { return _SelectCommand; }
            set { _SelectCommand = value; }
        }

        public ICommand NewCommand
        {
            get { return _NewCommand; }
            set { _NewCommand = value; }
        }

        public ICommand LoadCommand
        {
            get { return _LoadCommand; }
            set { _LoadCommand = value; }
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand; }
            set { _SaveCommand = value; }
        }

        public ICommand ExportCommand
        {
            get { return _ExportCommand; }
            set { _ExportCommand = value; }
        }

        /// <summary>
        /// This method is used to execute Select command
        /// </summary>
        /// <param name="obj"></param>
        private void SelectExecution(object obj)
        {
            this.Tool = Tool.MultipleSelect;
            this.SelectEnabled = true;
            this.PanEnabled = false;
        }

        /// <summary>
        /// This method is used to execute Pan command
        /// </summary>
        /// <param name="obj"></param>
        private void PanExecution(object obj)
        {
            this.Tool = Tool.ZoomPan;
            this.PanEnabled = true;
            this.SelectEnabled = false;
        }

        /// <summary>
        /// This method is used to execute Save command
        /// </summary>
        /// <param name="obj"></param>
        private void OnSave(object obj)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save XML";
            dialog.Filter = "XML File (*.xml)|*.xml";
            if (dialog.ShowDialog() == true)
            {
                using (Stream s = File.Open(dialog.FileName, FileMode.OpenOrCreate))
                {
                    s.SetLength(0);
                    (Info as IGraphInfo).Save(s);
                }
            }
        }

        /// <summary>
        /// This method is used to execute load command
        /// </summary>
        /// <param name="obj"></param>
        private void OnLoad(object obj)
        {
            if (this.HasChanges)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                            "Do you want to save the Diagram?",
                            "SfDiagram",
                            MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    this.OnSave(null);
                }
            }

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                using (Stream myStream = dialog.OpenFile())
                {
                    (Info as IGraphInfo).Load(myStream);
                }
            }
        }

        /// <summary>
        /// This method is used to execute new command
        /// </summary>
        /// <param name="obj"></param>
        private void OnNew(object obj)
        {
            if (this.HasChanges)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                            "Do you want to save the Diagram?",
                            "SfDiagram",
                            MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    this.OnSave(null);
                }
            }

            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();
            HasChanges = false;
        }

        /// <summary>
        /// This method is used to execute ZoomOut command
        /// </summary>
        /// <param name="obj"></param>
        private void ZoomOutExecution(object obj)
        {
            (Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter() { ZoomCommand = ZoomCommand.ZoomOut, ZoomFactor = 0.2 });
        }

        /// <summary>
        /// This method is used to execute ZoomIn command
        /// </summary>
        /// <param name="obj"></param>
        private void ZoomInExecution(object obj)
        {
            (Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter() { ZoomCommand = ZoomCommand.ZoomIn, ZoomFactor = 0.2 });
        }

        /// <summary>
        /// This method is used to execute Export command
        /// </summary>
        /// <param name="obj"></param>
        private void ExportExecution(object obj)
        {
            String Extension = "JPG File(*.jpg)|*.jpg|PNG File(*.png)|*.png|BMP File (*.bmp)|*.bmp|WDP File (*.wdp)|*.wdp|TIF File(*.tif)|*.tif|GIF File(*.gif)|*.gif|XPS File(*.xps)|*.xps|PDF File(*.pdf)|*.pdf";
            //("WDP File(*.wdp)|*.wdp") + ("BMP File(*.bmp)|*.bmp");

            //To Represent SaveFile Dialog Box
            SaveFileDialog m_SaveFileDialog = new SaveFileDialog();

            //Assign the selected extension to the SavefileDialog filter
            m_SaveFileDialog.Filter = Extension;

            //To display savefiledialog       
            bool? istrue = m_SaveFileDialog.ShowDialog();
            string filenamechanged;

            if (istrue == true)
            {
                //assign the filename to a local variable
                string extension = System.IO.Path.GetExtension(m_SaveFileDialog.FileName).TrimStart('.');
                string fileName = System.IO.Path.ChangeExtension(m_SaveFileDialog.FileName, null);
                this.ExportSettings = new ExportSettings() { ExportMode = ExportMode.Content };
                if (extension != "")
                {
                    if (extension.ToLower() != this.ExportSettings.ExportType.ToString().ToLower())
                    {
                        switch (extension.ToLower())
                        {
                            case "png":
                                this.ExportSettings.ExportType = ExportType.PNG;
                                break;
                            case "jpg":
                                this.ExportSettings.ExportType = ExportType.JPEG;
                                break;
                            case "bmp":
                                this.ExportSettings.ExportType = ExportType.BMP;
                                break;
                            case "wdp":
                                this.ExportSettings.ExportType = ExportType.WDP;
                                break;
                            case "gif":
                                this.ExportSettings.ExportType = ExportType.GIF;
                                break;
                            case "tif":
                                this.ExportSettings.ExportType = ExportType.TIF;
                                break;
                        }
                    }

                    if (extension.ToLower() == "pdf")
                    {
                        filenamechanged = fileName + ".xps";

                        ExportSettings.IsSaveToXps = true;

                        //Assigning exportstream from the saved file
                        this.ExportSettings.FileName = filenamechanged;
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();

                        var converter = new XPSToPdfConverter { };

                        var document = new PdfDocument();

                        document = converter.Convert(filenamechanged);
                        fileName = fileName + ".pdf";
                        document.Save(fileName);
                        document.Close(true);
                    }
                    else
                    {
                        if (extension.ToLower() == "xps")
                        {
                            ExportSettings.IsSaveToXps = true;
                        }

                        //Assigning exportstream from the saved file
                        this.ExportSettings.FileName = fileName;
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();
                    }
                }
            }
        }

        private void OnViewPortChangedCommandExecute(object parameter)
        {
            var args = parameter as ChangeEventArgs<object, ScrollChanged>;
            if (Info != null && (args.Item as SfDiagram).IsLoaded && args.NewValue.ContentBounds != currentViewPort)
            {
                var graphInfo = Info as IGraphInfo;

                Rect topLeftRect = new Rect(new Point(0,0), new Point(0, 0));

                graphInfo.BringIntoViewport(topLeftRect);
            }
            currentViewPort = args.NewValue.ContentBounds;
        }

        private void OnItemAdded(ItemAddedEventArgs args)
        {
            if (args.Item is ConnectorViewModel)
            {
                var connectorannotations = (args.Item as ConnectorViewModel).Annotations as ObservableCollection<IAnnotation>;
                foreach (AnnotationEditorViewModel anno in connectorannotations)
                {
                    anno.ViewTemplate = View.Resources["ConnectorAnnotationFlowChartTemplate"] as DataTemplate;
                }
            }
            else if (args.Item is NodeViewModel)
            {
                NodeViewModel node = (NodeViewModel)args.Item;
                var nodeannotations = node.Annotations as ObservableCollection<IAnnotation>;
                foreach (AnnotationEditorViewModel anno in nodeannotations)
                {
                    anno.TextHorizontalAlignment = TextAlignment.Center;
                    if (node.Content != null) 
                        anno.Foreground = new System.Windows.Media.SolidColorBrush(Colors.White);
                }
                if (node.Content != null)
                {
                    FlowChartModel content = node.Content as FlowChartModel;
                    if (content != null)
                    {
                        node.ShapeStyle = new Style(typeof(System.Windows.Shapes.Path))
                        {
                            Setters = { new Setter(System.Windows.Shapes.Path.StretchProperty, Stretch.Fill),}
                        };
                        switch (content.Id)
                        {
                            case "1":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#8E44CC"))));
                                break;
                            case "2":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#1759B7"))));
                                break;
                            case "3":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#2F95D8"))));
                                break;
                            case "4":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#70AF16"))));
                                break;      
                            case "5":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#70AF16"))));
                                break;
                            case "6":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#1759B7"))));
                                break;
                            case "7":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#1759B7"))));
                                break;
                            case "8":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#2F95D8"))));
                                break;
                            case "9":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#70AF16"))));
                                break;
                            case "10":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#70AF16"))));
                                break;
                            case "11":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#1759B7"))));
                                break;
                            case "12":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#1759B7"))));
                                break;
                            case "13":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#2F95D8"))));
                                break;
                            case "14":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#1759B7"))));
                                break;
                            case "15":
                                node.ShapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#8E44CC"))));
                                break;
                        }

                    }
                }
            }
        }

        #region Methods

        /// <summary>
        /// Method to Get Data for DataSource
        /// </summary>
        /// <param name="data"></param>
        private FlowChartModels GetData()
        {
            FlowChartModels ItemsInfo = new FlowChartModels();
            var resourceDictionary = new System.Windows.ResourceDictionary()
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
