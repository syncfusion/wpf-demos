// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrainstormingBuilderVM.cs" company="">
//   
// </copyright>
// <summary>
//   The brainstorming builder vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CoreVirtualKeyStates = System.Windows.Input.KeyStates;
using VirtualKey = System.Windows.Input.Key;
using VirtualKeyModifiers = System.Windows.Input.ModifierKeys;

namespace Brainstorming.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Xml;

    using Brainstorming.Utility;

    using DiagramBuilder.ViewModel;

    using FlowChart.ViewModel;

    using Microsoft.Win32;
    using OrganizationChart.ViewModel;
    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.UI.Xaml.Diagram.Stencil;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     The brainstorming builder vm.
    /// </summary>
    public class BrainstormingBuilderVM : DiagramBuilderVM
    {
        // Temporary variable. This is no need in DiagramBuilder
        /// <summary>
        ///     The _file.
        /// </summary>
        private string _file = string.Empty;

        /// <summary>
        ///     The change topic command.
        /// </summary>
        private DelegateCommand<string> changeTopicCommand;

        /// <summary>
        ///     The diagram style command.
        /// </summary>
        private DelegateCommand<string> diagramStyleCommand;

        /// <summary>
        ///     The export.
        /// </summary>
        private DelegateCommand<object> export;

        /// <summary>
        ///     The import.
        /// </summary>
        private DelegateCommand<object> import;

        /// <summary>
        ///     The multiple sub topic command.
        /// </summary>
        private DelegateCommand<object> multipleSubTopicCommand;

        /// <summary>
        ///     The peer command.
        /// </summary>
        private DelegateCommand<object> peerCommand;

        /// <summary>
        ///     The sub topic command.
        /// </summary>
        private DelegateCommand<object> subTopicCommand;

        /// <summary>
        ///     Gets the change topic command.
        /// </summary>
        public DelegateCommand<string> ChangeTopicCommand
        {
            get
            {
                return this.changeTopicCommand
                       ?? (this.changeTopicCommand = new DelegateCommand<string>(this.ChangeTopicCommandExecute));
            }
        }

        /// <summary>
        ///     Gets the diagram style command.
        /// </summary>
        public DelegateCommand<string> DiagramStyleCommand
        {
            get
            {
                return this.diagramStyleCommand
                       ?? (this.diagramStyleCommand = new DelegateCommand<string>(this.DiagramStyleCommandExecute));
            }
        }

        /// <summary>
        ///     Gets the export.
        /// </summary>
        public DelegateCommand<object> Export
        {
            get
            {
                return this.export ?? (this.export = new DelegateCommand<object>(this.ExportExecute));
            }
        }

        /// <summary>
        ///     Gets the import.
        /// </summary>
        public new DelegateCommand<object> Import
        {
            get
            {
                return this.import ?? (this.import = new DelegateCommand<object>(this.ImportExecute));
            }
        }

        /// <summary>
        ///     Gets the multiple sub topic command.
        /// </summary>
        public DelegateCommand<object> MultipleSubTopicCommand
        {
            get
            {
                return this.multipleSubTopicCommand ?? (this.multipleSubTopicCommand =
                                                            new DelegateCommand<object>(
                                                                this.MultipleSubTopicCommandExecute));
            }
        }

        /// <summary>
        ///     Gets the peer command.
        /// </summary>
        public DelegateCommand<object> PeerCommand
        {
            get
            {
                return this.peerCommand ?? (this.peerCommand = new DelegateCommand<object>(this.PeerCommandExecute));
            }
        }

        /// <summary>
        ///     Gets the sub topic command.
        /// </summary>
        public DelegateCommand<object> SubTopicCommand
        {
            get
            {
                return this.subTopicCommand
                       ?? (this.subTopicCommand = new DelegateCommand<object>(this.SubTopicCommandExecute));
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
                case "SelectedDiagram":
                    if (this.SelectedDiagram is BrainstormingVM)
                    {
                        this.AddKeyCommands();
                        this.IsBlankDiagramSelected = false;
                        this.IsOrgChartSelected = true;
                        this.SelectedDiagram.ItemAddedCommand =
                            new DelegateCommand<object>(this.ItemAddedCommandExecute);
                        if ((this.SelectedDiagram as BrainstormingVM).Rootnode != null)
                        {
                            this.AddContextMenutoNode((this.SelectedDiagram as BrainstormingVM).Rootnode);
                        }
                    }
                    else if (SelectedDiagram is OrganizationChartDiagramVM)
                    {
                        this.IsBlankDiagramSelected = false;
                        this.IsOrgChartSelected = false;
                    }
                    else
                    {
                        this.IsBlankDiagramSelected = true;
                        this.IsOrgChartSelected = true;
                    }

                    if (this.SelectedDiagram is FlowDiagramVm)
                    {
                        SymbolFilterProvider flowShapes = new SymbolFilterProvider
                                                              {
                                                                  SymbolFilter = this.Stencil.Filter,
                                                                  Content = "Flow Shapes"
                                                              };
                        this.Stencil.SelectedFilter = flowShapes;
                    }
                    else
                    {
                        SymbolFilterProvider all = new SymbolFilterProvider
                                                       {
                                                           SymbolFilter = this.Stencil.Filter, Content = "All"
                                                       };
                        this.Stencil.SelectedFilter = all;
                    }

                    break;
            }
        }

        /// <summary>
        /// Adding Content Menu to Node
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        private void AddContextMenutoNode(BrainstormingNodeVM node)
        {
            if (node != null)
            {
                if (node.Menu == null)
                {
                    node.Menu = new DiagramMenu() { MenuItems = new ObservableCollection<DiagramMenuItem>() };
                }

                DiagramMenuItem mi = new DiagramMenuItem { Content = "Add Subtopic", Command = this.SubTopicCommand };
                DiagramMenuItem mi1 = new DiagramMenuItem { Content = "Add Peer Topic", Command = this.PeerCommand };
                DiagramMenuItem mi2 = new DiagramMenuItem
                                          {
                                              Content = "Add Multiple Subtopics", Command = this.MultipleSubTopicCommand
                                          };
                DiagramMenuItem mi3 = new DiagramMenuItem
                                          {
                                              Content = "Change Topic Shapes", Command = this.ChangeTopicCommand
                                          };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
                if (node != (this.SelectedDiagram as BrainstormingVM).Rootnode)
                {
                    (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi1);
                }

                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi2);
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi3);

                DiagramMenuItem mi4 = new DiagramMenuItem
                                          {
                                              Content = "Edit Text",
                                              Command = (this.SelectedDiagram as BrainstormingVM).EditText
                                          };
                DiagramMenuItem mi5 = new DiagramMenuItem
                                          {
                                              Content = "Delete",
                                              Command = (this.SelectedDiagram as BrainstormingVM).ItemDeletingCommand
                                          };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi4);
                if (node != (this.SelectedDiagram as BrainstormingVM).Rootnode)
                {
                    (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi5);
                }

                node.Constraints |= NodeConstraints.Menu;
                node.Constraints &= ~NodeConstraints.InheritMenu;
            }
        }

        /// <summary>
        ///     Adding additional Gesture command
        /// </summary>
        private void AddKeyCommands()
        {
            this.SelectedDiagram.CommandManager.Commands.Add(
                new GestureCommand
                    {
                        Command = this.SubTopicCommand,
                        Gesture = new Gesture
                                      {
                                          Key = VirtualKey.B,
                                          KeyModifiers = VirtualKeyModifiers.Alt,
                                          KeyState = CoreVirtualKeyStates.Down
                                      },
                        Name = "SubTopic"
                    });
            this.SelectedDiagram.CommandManager.Commands.Add(
                new GestureCommand
                    {
                        Command = this.PeerCommand,
                        Gesture = new Gesture
                                      {
                                          Key = VirtualKey.P,
                                          KeyModifiers = VirtualKeyModifiers.Alt,
                                          KeyState = CoreVirtualKeyStates.Down
                                      },
                        Name = "Peer"
                    });
            this.SelectedDiagram.CommandManager.Commands.Add(
                new GestureCommand
                    {
                        Command = this.MultipleSubTopicCommand,
                        Gesture = new Gesture
                                      {
                                          Key = VirtualKey.U,
                                          KeyModifiers = VirtualKeyModifiers.Alt,
                                          KeyState = CoreVirtualKeyStates.Down
                                      },
                        Name = "MultipleSubTopic"
                    });
        }

        /// <summary>
        /// Method will execute when ChangeTopicCommand executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void ChangeTopicCommandExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = (this.SelectedDiagram as BrainstormingVM).GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                this.OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                this.OpenCloseWindowBehavior.OpenTopicChangeWindow = true;
            }
        }

        /// <summary>
        /// Adding new element when execute Import command
        /// </summary>
        /// <param name="SelectedNode">
        /// The Selected Node.
        /// </param>
        /// <param name="xmlNode">
        /// The xml Node.
        /// </param>
        private void DeSerializeChild(BrainstormingNodeVM SelectedNode, XmlNode xmlNode)
        {
            BrainstormingNodeVM newParentNode = null;

            // SubTopicCommand.Execute(subtopic);
            foreach (XmlNode att in xmlNode.ChildNodes)
            {
                if (att.LocalName.Equals("text"))
                {
                    this.SubTopicCommand.Execute(att.InnerText);
                    ((this.SelectedDiagram.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)
                        .Clear();
                    newParentNode = (this.SelectedDiagram.Nodes as ObservableCollection<BrainstormingNodeVM>).Last();
                    BrainstormingNodeVM parentNode =
                        (newParentNode.Info as INodeInfo).InNeighbors.First() as BrainstormingNodeVM;
                    parentNode.IsSelected = true;
                }

                if (att.LocalName.Equals("topic"))
                {
                    ((this.SelectedDiagram.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)
                        .Clear();
                    newParentNode.IsSelected = true;
                    this.DeSerializeChild(newParentNode, att);
                }
            }
        }

        /// <summary>
        /// Method will execute when DiagramStyleCommand executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void DiagramStyleCommandExecute(object param)
        {
            // DiagramStyleOpen = true;
            this.OpenCloseWindowBehavior.OpenDiagramStyleWindow = true;
        }

        /// <summary>
        /// Method will execute when Export executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void ExportExecute(object param)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
                                                 {
                                                     Title = "File Save",
                                                     DefaultExt = "xml",
                                                     Filter = "XML File(*.xml)|*.xml"
                                                 };
            saveFileDialog1.ShowDialog();
            this._file = saveFileDialog1.FileName;
            if (!string.IsNullOrEmpty(this._file))
            {
                string prefix = "bs";
                string testNamespace = "http://schemas.microsoft.com/visio/2003/brainstorming";
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement(prefix, "Brainstorm", testNamespace);
                doc.AppendChild(root);
                if ((this.SelectedDiagram as BrainstormingVM).Rootnode != null)
                {
                    XmlElement id = doc.CreateElement(prefix, "topic", testNamespace);
                    XmlAttribute attribute = doc.CreateAttribute(prefix, "TopicID", testNamespace);
                    attribute.InnerText = "T1";
                    id.SetAttributeNode(attribute);
                    XmlElement name = doc.CreateElement(prefix, "text", testNamespace);

                    // name.InnerText = ((SelectedDiagram.Rootnode.Annotations as AnnotationCollection)[0] as TextAnnotationViewModel).Text;
                    name.InnerText =
                        (((this.SelectedDiagram as BrainstormingVM).Rootnode.Annotations as List<IAnnotation>)[0] as
                         LabelVM).Content.ToString();
                    id.AppendChild(name);

                    if ((this.SelectedDiagram as BrainstormingVM).Rootnode.ChildCount > 0)
                    {
                        this.SerializeChild((this.SelectedDiagram as BrainstormingVM).Rootnode, doc, id);
                    }

                    root.AppendChild(id);
                }

                doc.Save(this._file);

                // ExportMessageWindowOpen = true;
                this.OpenCloseWindowBehavior.OpenExportMessageWindow = true;
            }
        }

        /// <summary>
        /// Method will execute when Import executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void ImportExecute(object param)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Do you want to save Diagram?",
                "Diagram Builder",
                MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Save.Execute(null);
            }

            OpenFileDialog openDialogBox = new OpenFileDialog() { Title = "File Open" };
            if (openDialogBox.ShowDialog() == true)
            {
                (this.SelectedDiagram as BrainstormingVM).addChildAtLeft = false;

                using (Stream stream = openDialogBox.OpenFile())
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(stream);
                    foreach (XmlNode brainstrom in xml.ChildNodes)
                    {
                        if (brainstrom.LocalName.Equals("Brainstorm"))
                        {
                            (this.SelectedDiagram.Nodes as ObservableCollection<BrainstormingNodeVM>).Clear();
                            (this.SelectedDiagram.Connectors as ObservableCollection<BrainstormingConnectorVM>).Clear();
                            foreach (XmlNode rootTopic in brainstrom.ChildNodes)
                            {
                                (this.SelectedDiagram as BrainstormingVM).Rootnode =
                                    (this.SelectedDiagram as BrainstormingVM).AddRootNode();
                                (this.SelectedDiagram as BrainstormingVM).Updatebowtielayout("root");
                                foreach (XmlNode att in rootTopic.ChildNodes)
                                {
                                    if (att.LocalName.Equals("text"))
                                    {
                                        // ((SelectedDiagram.Rootnode.Annotations as AnnotationCollection)[0] as TextAnnotationViewModel).Text = att.InnerText;
                                        (((this.SelectedDiagram as BrainstormingVM).Rootnode.Annotations as
                                          List<IAnnotation>)[0] as LabelVM).Content = att.InnerText;
                                    }

                                    if (att.LocalName.Equals("topic"))
                                    {
                                        ((this.SelectedDiagram.SelectedItems as SelectorViewModel).Nodes as
                                         ObservableCollection<object>).Clear();
                                        (this.SelectedDiagram as BrainstormingVM).Rootnode.IsSelected = true;

                                        // (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).addChildAtLeft = false;// (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).addChildAtLeft ? false : true;
                                        this.DeSerializeChild((this.SelectedDiagram as BrainstormingVM).Rootnode, att);
                                    }
                                }
                            }
                        }
                    }
                }

                (this.SelectedDiagram as BrainstormingVM).Updatebowtielayout("root");
            }
        }

        /// <summary>
        /// Method will execute when ItemAddedCommand executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void ItemAddedCommandExecute(object param)
        {
            ItemAddedEventArgs args = param as ItemAddedEventArgs;
            if (args.Item is BrainstormingNodeVM)
            {
                if ((this.SelectedDiagram as BrainstormingVM).Rootnode == null)
                {
                    if ((args.Item as BrainstormingNodeVM).Type.Equals("root"))
                    {
                        (this.SelectedDiagram as BrainstormingVM).Rootnode = args.Item as BrainstormingNodeVM;
                        (this.SelectedDiagram as BrainstormingVM).Rootnode.IsSelected = true;
                    }
                }

                this.AddContextMenutoNode(args.Item as BrainstormingNodeVM);
            }
        }

        /// <summary>
        /// Method will execute when MultipleSubTopicCommand executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void MultipleSubTopicCommandExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = (this.SelectedDiagram as BrainstormingVM).GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                this.OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                this.OpenCloseWindowBehavior.OpenMultipleSubTopicWindow = true;
            }
        }

        /// <summary>
        /// Method will execute when PeerCommand executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void PeerCommandExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = (this.SelectedDiagram as BrainstormingVM).GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                this.OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                (this.SelectedDiagram as BrainstormingVM).CreatePeerCommandChild();
            }
        }

        /// <summary>
        /// Adding xmlelement to xml document based on the child element
        /// </summary>
        /// <param name="nodeVM">
        /// The node VM.
        /// </param>
        /// <param name="doc">
        /// The doc.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        private void SerializeChild(BrainstormingNodeVM nodeVM, XmlDocument doc, XmlElement id)
        {
            string prefix = "bs";
            string testNamespace = "http://schemas.microsoft.com/visio/2003/brainstorming";
            int i = 1;
            foreach (IConnector connector in (nodeVM.Info as INodeInfo).OutConnectors)
            {
                BrainstormingNodeVM node = connector.TargetNode as BrainstormingNodeVM;

                XmlElement id1 = doc.CreateElement(prefix, "topic", testNamespace);
                XmlAttribute attribute1 = doc.CreateAttribute(prefix, "TopicID", testNamespace);
                attribute1.InnerText = id.Attributes[0].InnerText + "." + i;
                id1.SetAttributeNode(attribute1);
                XmlElement name1 = doc.CreateElement(prefix, "text", testNamespace);

                // name1.InnerText = ((node.Annotations as AnnotationCollection)[0] as TextAnnotationViewModel).Text; ;
                name1.InnerText = ((node.Annotations as List<IAnnotation>)[0] as LabelVM).Content.ToString();
                id1.AppendChild(name1);
                id.AppendChild(id1);
                if (node.ChildCount > 0)
                {
                    this.SerializeChild(node, doc, id1);
                }

                i++;
            }
        }

        /// <summary>
        /// Method will execute when SubTopicCommand executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void SubTopicCommandExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = (this.SelectedDiagram as BrainstormingVM).GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                this.OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                (this.SelectedDiagram as BrainstormingVM).CreateSubTopicCommandChild(param);
            }
        }

        #region Public Properties 

        /// <summary>
        ///     Gets or sets the open close window behavior.
        /// </summary>
        public OpenCloseWindowBehavior OpenCloseWindowBehavior { get; set; }

        /// <summary>
        ///     Gets or sets the diagram style view model.
        /// </summary>
        public DiagramStyleViewModel DiagramStyleViewModel { get; set; }

        /// <summary>
        ///     Gets or sets the multiple sub topic view model.
        /// </summary>
        public MultipleSubTopicViewModel MultipleSubTopicViewModel { get; set; }

        /// <summary>
        ///     Gets or sets the change topic view model.
        /// </summary>
        public ChangeTopicViewModel ChangeTopicViewModel { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BrainstormingBuilderVM" /> class.
        ///     Selected DiagramViewMode in application
        /// </summary>

        // public DiagramVM SelectedDiagram
        // {
        // get { return _mSelectedDiagram; }
        // set
        // {
        // if (_mSelectedDiagram != value)
        // {
        // _mSelectedDiagram = value;
        // OnPropertyChanged("SelectedDiagram");
        // AddContextMenutoNode(_mSelectedDiagram.Rootnode);
        // AddKeyCommands();
        // _mSelectedDiagram.ItemAddedCommand = new DelegateCommand<object>(ItemAddedCommandExecute);
        // }
        // }
        // }
        #endregion

        #region Constructor

        public BrainstormingBuilderVM()
        {
            this.DiagramStyleViewModel = new DiagramStyleViewModel(this);
            this.MultipleSubTopicViewModel = new MultipleSubTopicViewModel(this);
            this.ChangeTopicViewModel = new ChangeTopicViewModel(this);

            // this.Diagrams.CollectionChanged += Diagrams_CollectionChanged;
            this.OpenCloseWindowBehavior = new OpenCloseWindowBehavior { BrainstormingBuilderVM = this };
        }

        #endregion

        // private void Diagrams_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        // {
        // if(e.NewItems != null)
        // {
        // if(e.NewItems[0] is BrainstormingVM)
        // {
        // BrainstormingVM diagramVM = e.NewItems[0] as BrainstormingVM;
        // AddContextMenutoNode(diagramVM.Rootnode);
        // //diagramVM.AddContextMenutoNode(diagramVM.Rootnode);
        // AddKeyCommands();
        // diagramVM.ItemAddedCommand = new DelegateCommand<object>(ItemAddedCommandExecute);
        // }
        // }
        // }
    }
}