using syncfusion.diagramdemo.wpf.Model;
using syncfusion.diagramdemo.wpf.Views;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using syncfusion.demoscommon.wpf;
using System.Windows.Media;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using Syncfusion.Pdf;
using Syncfusion.XPS;
using System.IO;
using Microsoft.Win32;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class SmartSequenceDiagramViewModel : DiagramViewModel
    {
        #region fields, properties and command

        System.Windows.ResourceDictionary resourceDictionary = new System.Windows.ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

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

        #endregion

        #region constructor

        public SmartSequenceDiagramViewModel()
        {
            this.Tool = Tool.MultipleSelect;
            this.Nodes = new NodeCollection();
            this.Connectors = new ConnectorCollection();
            this.DefaultConnectorType = ConnectorType.Line;
            this.Constraints = GraphConstraints.Default;

            SelectedItems = new SelectorViewModel()
            {
                Commands = null,
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.Rotator & ~SelectorConstraints.Resizer & ~SelectorConstraints.Pivot,
            };

            ItemAddedCommand = new DelegateCommand(OnItemAdded);
            ItemSelectedCommand = new DelegateCommand(OnItemSelected);
            ItemDeletingCommand = new DelegateCommand(OnItemDeleting);
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

            this.Model = GenerateSequenceDiagramData();
        }

        #endregion

        #region Helper Methods

        private UMLSequenceDiagramModel GenerateSequenceDiagramData()
        {
            return new UMLSequenceDiagramModel
            {
                SpaceBetweenParticipants = 300,
                Participants = new List<UMLSequenceParticipant>
                {
                    new UMLSequenceParticipant
                    {
                        ID = "User",
                        Content = "User",
                        IsActor = true,
                    },
                    new UMLSequenceParticipant
                    {
                        ID = "Transaction",
                        Content = "Transaction",
                        ActivationBoxes = new List<UMLSequenceActivationBox>
                        {
                            new UMLSequenceActivationBox {ID = "act1", StartMessageID = 1, EndMessageID=4}
                        }
                    },
                    new UMLSequenceParticipant
                    {
                        ID = "FraudDetectionSystem",
                        Content = "FraudDetectionSystem",
                        ActivationBoxes = new List<UMLSequenceActivationBox>
                        {
                            new UMLSequenceActivationBox {ID = "act2", StartMessageID = 2, EndMessageID=3},
                            new UMLSequenceActivationBox {ID = "act3", StartMessageID = 5, EndMessageID=6}
                        }
                    }
                },
                Messages = new List<UMLSequenceMessage>
                {
                    new UMLSequenceMessage { ID = 1, Content = "Initiate Transaction", FromParticipantID = "User", ToParticipantID = "Transaction", Type = UMLSequenceMessageType.Synchronous },
                    new UMLSequenceMessage { ID = 2, Content = "Send Transaction Data", FromParticipantID = "Transaction", ToParticipantID = "FraudDetectionSystem", Type = UMLSequenceMessageType.Synchronous },
                    new UMLSequenceMessage { ID = 3, Content = "Validate Transaction", FromParticipantID = "FraudDetectionSystem", ToParticipantID = "Transaction", Type = UMLSequenceMessageType.Reply },
                    new UMLSequenceMessage { ID = 4, Content = "Transaction Approved", FromParticipantID = "Transaction", ToParticipantID = "User", Type = UMLSequenceMessageType.Asynchronous },
                    new UMLSequenceMessage { ID = 5, Content = "Flag Transaction", FromParticipantID = "Transaction", ToParticipantID = "FraudDetectionSystem", Type = UMLSequenceMessageType.Synchronous },
                    new UMLSequenceMessage { ID = 6, Content = "Fraud Detected", FromParticipantID = "FraudDetectionSystem", ToParticipantID = "User", Type = UMLSequenceMessageType.Reply },
                    new UMLSequenceMessage { ID = 7, Content = "Cancel Transaction", FromParticipantID = "User", ToParticipantID = "Transaction", Type = UMLSequenceMessageType.Synchronous },
                    new UMLSequenceMessage { ID = 8, Content = "Complete Transaction", FromParticipantID = "User", ToParticipantID = "Transaction", Type = UMLSequenceMessageType.Synchronous }
                },
                Fragments = new List<UMLSequenceFragment>
                {
                    new UMLSequenceFragment
                    {
                        ID = 1,
                        Type = UMLSequenceFragmentType.Alternative,
                        Conditions = new List<UMLSequenceFragmentCondition>
                        {
                            new UMLSequenceFragmentCondition
                            {
                                Content = "Fraud Detected",
                                MessageIds = new List<object> { 5, 6, 7 }
                            },
                            new UMLSequenceFragmentCondition
                            {
                                Content = "No Fraud Detected",
                                MessageIds = new List<object> { 8 }
                            }
                        }
                    },
                }
            };
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

            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();

            HasChanges = false;

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                using (Stream myStream = dialog.OpenFile())
                {
                    (Info as IGraphInfo).Load(myStream);
                }
            }

            Tool = Tool.MultipleSelect;
            PanEnabled = false;
            SelectEnabled = true;
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

        private void OnItemDeleting(object obj)
        {
            var args = obj as ItemDeletingEventArgs;
            var item = args.Item as NodeViewModel;
            if (item != null)
            {

                args.DeleteDependentConnector = true;
                args.DeleteSuccessors = true;
            }
        }

        private void OnItemSelected(object obj)
        {
            var args = obj as ItemSelectedEventArgs;

            if (this.SelectedItems is SelectorViewModel)
            {
                SelectorViewModel sv = this.SelectedItems as SelectorViewModel;
                if (sv.Nodes is ObservableCollection<object> nodes && nodes.Any())
                {
                    (this.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection();
                }
            }
        }

        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;

            if (args.Item != null && args.Item is NodeViewModel)
            {
                NodeViewModel node = args.Item as NodeViewModel;
                if (args.ItemSource == ItemSource.ClipBoard)
                {
                    node.IsSelected = true;
                    (this.Info as IGraphInfo).Commands.Delete.Execute(null);
                }
                if (node.Annotations != null)
                {
                    // if node is a participant then update annotations
                    if (node.Annotations != null && !node.Name.Contains("Fragment"))
                    {
                        var resourceDictionary = new System.Windows.ResourceDictionary
                        {
                            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
                        };

                        var annotation = (node.Annotations as AnnotationCollection).FirstOrDefault();
                        if (annotation != null)
                            annotation.FontSize = 18;

                        bool isActor = node.Shape.ToString() == resourceDictionary["User"].ToString();

                        // if participant is of rectangular shape, update node width according to annotation length
                        if (!isActor && annotation != null && annotation is TextAnnotationViewModel)
                        {
                            annotation.Foreground = new System.Windows.Media.SolidColorBrush(Colors.White);
                            UpdateNodeWidth((NodeViewModel)node, (annotation as TextAnnotationViewModel).Text.ToString());
                        }
                        else if (annotation != null)
                        {
                            annotation.FontSize = 14;
                        }
                    }
                    else
                    {
                        // if node is a fragment, then update shape style and its annotations
                        if (node.Annotations != null && node.Name.Contains("Fragment"))
                        {

                            node.ShapeStyle = new Style(typeof(System.Windows.Shapes.Path))
                            {
                                Setters =
                                {
                                    new Setter(System.Windows.Shapes.Path.FillProperty, Brushes.CornflowerBlue),
                                    new Setter(System.Windows.Shapes.Path.StretchProperty, Stretch.Fill),
                                    new Setter(System.Windows.Shapes.Path.StrokeProperty, Brushes.CornflowerBlue)
                                }
                            };


                            var annotation = (node.Annotations as AnnotationCollection).FirstOrDefault();
                            if (annotation != null)
                            {
                               annotation.Foreground = new System.Windows.Media.SolidColorBrush(Colors.White);
                            }
                        }
                    }
                }
            }
            if (args.Item != null && args.Item is ConnectorViewModel)
            {
                ConnectorViewModel connector = args.Item as ConnectorViewModel;
                if (connector.Annotations != null)
                {
                    var annotation = (connector.Annotations as AnnotationCollection).FirstOrDefault();
                    if (annotation != null)
                    {
                        annotation.FontSize = 18;
                        annotation.Margin = new Thickness(0, -15, 0, 0);
                        annotation.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
                    }
                }
            }
        }

        private void UpdateNodeWidth(NodeViewModel node, string text)
        {
            if (node == null) return;
            if (text == null) text = string.Empty;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize = 18;
            textBlock.TextWrapping = TextWrapping.NoWrap;

            // Measure with infinite width
            textBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Size desiredSize = textBlock.DesiredSize;

            // Compute new width with some padding
            double measuredWidth = desiredSize.Width + 20;  // 20 for padding

            double newWidth = 100;
            if (measuredWidth > 100)
            {
                newWidth = measuredWidth;
            }

            // Update the node's width only
            node.UnitWidth = newWidth;
        }
        #endregion
    }
}
