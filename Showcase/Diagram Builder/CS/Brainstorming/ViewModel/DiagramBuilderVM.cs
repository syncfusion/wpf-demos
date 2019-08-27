#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DiagramBuilder.ViewModel;
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using CoreVirtualKeyStates = System.Windows.Input.KeyStates;
using VirtualKey = System.Windows.Input.Key;
using VirtualKeyModifiers = System.Windows.Input.ModifierKeys;
using DiagramBuilder.ViewModel;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System.Windows;
using System.ComponentModel;
using Brainstorming.Utility;
using Brainstorming.View;

namespace Brainstorming.ViewModel
{
    public partial class BrainstormingBuilderVM : DiagramBuilderVM
    {
        #region Private Variables
        // Temporary variable. This is no need in DiagramBuilder
        string _file = string.Empty;
        #endregion
        #region Commands
        DelegateCommand<string> changeTopicCommand;
        DelegateCommand<object> multipleSubTopicCommand;
        DelegateCommand<string> diagramStyleCommand;
        private bool messageBoxWindowOpen;
        DelegateCommand<object> import;
        DelegateCommand<object> export;
        DelegateCommand<object> peerCommand;
        DelegateCommand<object> subTopicCommand;
        public DelegateCommand<object> SubTopicCommand
        {
            get
            {
                return subTopicCommand ??
                    (subTopicCommand = new DelegateCommand<object>(SubTopicCommandExecute));
            }
        }
        public DelegateCommand<object> PeerCommand
        {
            get
            {
                return peerCommand ??
                    (peerCommand = new DelegateCommand<object>(PeerCommandExecute));
            }
        }
        public DelegateCommand<string> ChangeTopicCommand
        {
            get
            {
                return changeTopicCommand ??
                    (changeTopicCommand = new DelegateCommand<string>(ChangeTopicCommandExecute));
            }
        }
        public DelegateCommand<object> MultipleSubTopicCommand
        {
            get
            {
                return multipleSubTopicCommand ??
                    (multipleSubTopicCommand = new DelegateCommand<object>(MultipleSubTopicCommandExecute));
            }
        }
        public DelegateCommand<string> DiagramStyleCommand
        {
            get
            {
                return diagramStyleCommand ??
                    (diagramStyleCommand = new DelegateCommand<string>(DiagramStyleCommandExecute));
            }
        }
        public DelegateCommand<object> Export
        {
            get
            {
                return export ??
                    (export = new DelegateCommand<object>(ExportExecute));
            }
        }
        public DelegateCommand<object> Import
        {
            get
            {
                return import ??
                    (import = new DelegateCommand<object>(ImportExecute));
            }
        }
        #endregion
        #region Public Properties 
        private BrainstormingVM _mSelectedDiagram;
        private bool changeTopicOpen;
        private bool multipleSubTopicOpen;
        private bool diagramStyleOpen;
        private bool exportMessageWindowOpen;
        public OpenCloseWindowBehavior OpenCloseWindowBehavior { get; set; }
        public DiagramStyleViewModel DiagramStyleViewModel { get; set; }
        public MultipleSubTopicViewModel MultipleSubTopicViewModel { get; set; }
        public ChangeTopicViewModel ChangeTopicViewModel { get; set; }
        /// <summary>
        /// Selected DiagramViewMode in application 
        /// </summary>
        //public DiagramVM SelectedDiagram
        //{
        //    get { return _mSelectedDiagram; }
        //    set
        //    {
        //        if (_mSelectedDiagram != value)
        //        {
        //            _mSelectedDiagram = value;
        //            OnPropertyChanged("SelectedDiagram");
        //            AddContextMenutoNode(_mSelectedDiagram.Rootnode);
        //            AddKeyCommands();
        //            _mSelectedDiagram.ItemAddedCommand = new DelegateCommand<object>(ItemAddedCommandExecute);
        //        }
        //    }
        //}
        
        #endregion
        #region Constructor
        public BrainstormingBuilderVM()
        {
            DiagramStyleViewModel = new DiagramStyleViewModel(this);
            MultipleSubTopicViewModel = new MultipleSubTopicViewModel(this);
            ChangeTopicViewModel = new ChangeTopicViewModel(this);
            //this.Diagrams.CollectionChanged += Diagrams_CollectionChanged;
            OpenCloseWindowBehavior = new OpenCloseWindowBehavior() { BrainstormingBuilderVM = this };
        }        
        #endregion
        #region Command Execution Methods
        /// <summary>
        /// Method will execute when ChangeTopicCommand executed
        /// </summary>
        private void ChangeTopicCommandExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                OpenCloseWindowBehavior.OpenTopicChangeWindow = true;
            }
        }
        /// <summary>
        /// Method will execute when MultipleSubTopicCommand executed
        /// </summary>
        private void MultipleSubTopicCommandExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                OpenCloseWindowBehavior.OpenMultipleSubTopicWindow = true;
            }
        }
        /// <summary>
        /// Method will execute when DiagramStyleCommand executed
        /// </summary>
        private void DiagramStyleCommandExecute(object param)
        {
            //DiagramStyleOpen = true;
            OpenCloseWindowBehavior.OpenDiagramStyleWindow = true;
        }
        /// <summary>
        /// Method will execute when SubTopicCommand executed
        /// </summary>
        private void SubTopicCommandExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).CreateSubTopicCommandChild(param);
            }
        }
        /// <summary>
        /// Method will execute when PeerCommand executed
        /// </summary>
        private void PeerCommandExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).CreatePeerCommandChild();
            }
        }
        /// <summary>
        /// Method will execute when Export executed
        /// </summary>
        private void ExportExecute(object param)
        {            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "File Save";
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.Filter = ("XML File(*.xml)|*.xml");
            saveFileDialog1.ShowDialog();
            _file = saveFileDialog1.FileName;
            if (!string.IsNullOrEmpty(_file))
            {
                String prefix = "bs";
                String testNamespace = "http://schemas.microsoft.com/visio/2003/brainstorming";
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement(prefix, "Brainstorm", testNamespace);
                doc.AppendChild(root);
                if ((SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Rootnode != null)
                {
                    XmlElement id = doc.CreateElement(prefix, "topic", testNamespace);
                    var attribute = doc.CreateAttribute(prefix, "TopicID", testNamespace);
                    attribute.InnerText = "T1";
                    id.SetAttributeNode(attribute);
                    XmlElement name = doc.CreateElement(prefix, "text", testNamespace);
                    //name.InnerText = ((SelectedDiagram.Rootnode.Annotations as AnnotationCollection)[0] as TextAnnotationViewModel).Text;
                    name.InnerText = (((SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Rootnode.Annotations as List<IAnnotation>)[0] as LabelVM).Content.ToString();
                    id.AppendChild(name);

                    if ((SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Rootnode.ChildCount > 0)
                    {
                        SerializeChild((SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Rootnode, doc, id);
                    }
                    root.AppendChild(id);
                }

                doc.Save(_file);
                //ExportMessageWindowOpen = true;
                OpenCloseWindowBehavior.OpenExportMessageWindow = true;
            }
        }
        /// <summary>
        /// Method will execute when Import executed
        /// </summary>
        private void ImportExecute(object param)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to save Diagram?", "Diagram Builder", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Save.Execute(null);
            }

            OpenFileDialog openDialogBox = new OpenFileDialog();
            openDialogBox.Title = "File Open";
            if (openDialogBox.ShowDialog() == true)
            {
                (SelectedDiagram as BrainstormingVM).addChildAtLeft = false;
                IGraphInfo graph = this.Info as IGraphInfo;

                using (Stream stream = openDialogBox.OpenFile())
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(stream);
                    foreach (XmlNode brainstrom in xml.ChildNodes)
                    {
                        if (brainstrom.LocalName.Equals("Brainstorm"))
                        {
                            (SelectedDiagram.Nodes as ObservableCollection<BrainstormingNodeVM>).Clear();
                            (SelectedDiagram.Connectors as ObservableCollection<BrainstormingConnectorVM>).Clear();
                            foreach (XmlNode rootTopic in brainstrom.ChildNodes)
                            {
                                (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Rootnode = (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).AddRootNode();
                                (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Updatebowtielayout("root");
                                foreach (XmlNode att in rootTopic.ChildNodes)
                                {
                                    if (att.LocalName.Equals("text"))
                                    {
                                        //((SelectedDiagram.Rootnode.Annotations as AnnotationCollection)[0] as TextAnnotationViewModel).Text = att.InnerText;
                                        (((SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Rootnode.Annotations as List<IAnnotation>)[0] as LabelVM).Content = att.InnerText;
                                    }
                                    if (att.LocalName.Equals("topic"))
                                    {
                                        ((SelectedDiagram.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
                                        (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Rootnode.IsSelected = true;
                                        //(SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).addChildAtLeft = false;// (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).addChildAtLeft ? false : true;
                                        DeSeriaizeChild((SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Rootnode, att);
                                    }
                                }
                            }
                        }
                    }
                }
                (SelectedDiagram as BrainstormingVM).Updatebowtielayout("root");
            }
        }
        /// <summary>
        /// Method will execute when ItemAddedCommand executed
        /// </summary>
        private void ItemAddedCommandExecute(object param)
        {
            ItemAddedEventArgs args = param as ItemAddedEventArgs;
            if (args.Item is BrainstormingNodeVM)
            {
                if ((SelectedDiagram as BrainstormingVM).Rootnode == null)
                {
                    if ((args.Item as BrainstormingNodeVM).Type.Equals("root"))
                    {
                        (SelectedDiagram as BrainstormingVM).Rootnode = args.Item as BrainstormingNodeVM;
                        (SelectedDiagram as BrainstormingVM).Rootnode.IsSelected = true;
                    }
                }
                AddContextMenutoNode(args.Item as BrainstormingNodeVM);
            }
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Adding Content Menu to Node
        /// </summary>
        private void AddContextMenutoNode(BrainstormingNodeVM node)
        {
            if (node != null)
            {
                if (node.Menu == null)
                {
                    node.Menu = new DiagramMenu();
                    node.Menu.MenuItems = new ObservableCollection<DiagramMenuItem>();
                }

                DiagramMenuItem mi = new DiagramMenuItem()
                {
                    Content = "Add Subtopic",
                    Command = SubTopicCommand
                };
                DiagramMenuItem mi1 = new DiagramMenuItem()
                {
                    Content = "Add Peer Topic",
                    Command = PeerCommand
                };
                DiagramMenuItem mi2 = new DiagramMenuItem()
                {
                    Content = "Add Multiple Subtopics",
                    Command = MultipleSubTopicCommand
                };
                DiagramMenuItem mi3 = new DiagramMenuItem()
                {
                    Content = "Change Topic Shapes",
                    Command = ChangeTopicCommand
                };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
                if (node != (SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).Rootnode)
                {
                    (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi1);
                }
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi2);
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi3);

                DiagramMenuItem mi4 = new DiagramMenuItem()
                {
                    Content = "Edit Text",
                    Command = (SelectedDiagram as BrainstormingVM).EditText
                };
                DiagramMenuItem mi5 = new DiagramMenuItem()
                {
                    Content = "Delete",
                    Command = (SelectedDiagram as BrainstormingVM).ItemDeletingCommand
                };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi4);
                if (node != (SelectedDiagram as BrainstormingVM).Rootnode)
                {
                    (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi5);
                }
                node.Constraints = node.Constraints | NodeConstraints.Menu;
                node.Constraints = node.Constraints & ~NodeConstraints.InheritMenu;
            }
        }
        /// <summary>
        /// Adding additional Gesture command 
        /// </summary>
        private void AddKeyCommands()
        {
            SelectedDiagram.CommandManager.Commands.Add
                (
                    new GestureCommand()
                    {
                        Command = SubTopicCommand,
                        Gesture = new Gesture
                        {
                            Key = VirtualKey.B,
                            KeyModifiers = VirtualKeyModifiers.Alt,
                            KeyState = CoreVirtualKeyStates.Down

                        },
                        Name = "SubTopic",
                    }
                );
            SelectedDiagram.CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = PeerCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.P,
                        KeyModifiers = VirtualKeyModifiers.Alt,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "Peer",
                }
            );
            SelectedDiagram.CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = MultipleSubTopicCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.U,
                        KeyModifiers = VirtualKeyModifiers.Alt,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "MultipleSubTopic",
                }
            );
        }
        /// <summary>
        /// Adding xmlelement to xml document based on the child element
        /// </summary>
        private void SerializeChild(BrainstormingNodeVM nodeVM, XmlDocument doc, XmlElement id)
        {
            String prefix = "bs";
            String testNamespace = "http://schemas.microsoft.com/visio/2003/brainstorming";
            int i = 1;
            foreach (IConnector connector in (nodeVM.Info as INodeInfo).OutConnectors)
            {
                BrainstormingNodeVM node = connector.TargetNode as BrainstormingNodeVM;

                XmlElement id1 = doc.CreateElement(prefix, "topic", testNamespace);
                var attribute1 = doc.CreateAttribute(prefix, "TopicID", testNamespace);
                attribute1.InnerText = id.Attributes[0].InnerText + "." + i;
                id1.SetAttributeNode(attribute1);
                XmlElement name1 = doc.CreateElement(prefix, "text", testNamespace);
                //name1.InnerText = ((node.Annotations as AnnotationCollection)[0] as TextAnnotationViewModel).Text; ;
                name1.InnerText = ((node.Annotations as List<IAnnotation>)[0] as LabelVM).Content.ToString();
                id1.AppendChild(name1);
                id.AppendChild(id1);
                if (node.ChildCount > 0)
                {
                    SerializeChild(node, doc, id1);
                }
                i++;
            }
        }
        /// <summary>
        /// Adding new element when execute Import command
        /// </summary>
        private void DeSeriaizeChild(BrainstormingNodeVM SelectedNode, XmlNode xmlNode)
        {
            BrainstormingNodeVM newParentNode = null;
            //SubTopicCommand.Execute(subtopic);
            foreach (XmlNode att in xmlNode.ChildNodes)
            {
                if (att.LocalName.Equals("text"))
                {
                    SubTopicCommand.Execute(att.InnerText);
                    ((SelectedDiagram.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
                    newParentNode = (SelectedDiagram.Nodes as ObservableCollection<BrainstormingNodeVM>).Last();
                    BrainstormingNodeVM parentNode = (newParentNode.Info as INodeInfo).InNeighbors.First() as BrainstormingNodeVM;
                    parentNode.IsSelected = true;
                }
                if (att.LocalName.Equals("topic"))
                {
                    ((SelectedDiagram.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
                    newParentNode.IsSelected = true;
                    DeSeriaizeChild(newParentNode, att);
                }
            }
        }
        //private void Diagrams_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    if(e.NewItems != null)
        //    {
        //        if(e.NewItems[0] is BrainstormingVM)
        //        {
        //            BrainstormingVM diagramVM = e.NewItems[0] as BrainstormingVM;
        //            AddContextMenutoNode(diagramVM.Rootnode);
        //            //diagramVM.AddContextMenutoNode(diagramVM.Rootnode);
        //            AddKeyCommands();
        //            diagramVM.ItemAddedCommand = new DelegateCommand<object>(ItemAddedCommandExecute);
        //        }
        //    }
        //}
        #endregion
        #region Protected Methods
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch(name)
            {
                case "SelectedDiagram":
                    if(SelectedDiagram is Brainstorming.ViewModel.BrainstormingVM)
                    {
                        AddKeyCommands();
                        this.IsBlankDiagramSelected = false;                        
                        SelectedDiagram.ItemAddedCommand = new DelegateCommand<object>(ItemAddedCommandExecute);
                        if ((SelectedDiagram as BrainstormingVM).Rootnode != null)
                        {
                            AddContextMenutoNode((SelectedDiagram as BrainstormingVM).Rootnode);
                        }
                    }
                    else
                    {
                        this.IsBlankDiagramSelected = true;
                    }
                    if(SelectedDiagram is FlowChart.ViewModel.FlowDiagramVm)
                    {
                        SymbolFilterProvider flowShapes = new SymbolFilterProvider { SymbolFilter = this.Stencil.Filter, Content = "Flow Shapes" };
                        (this.Stencil as StencilVM).SelectedFilter = flowShapes;
                    }
                    else
                    {
                        SymbolFilterProvider all = new SymbolFilterProvider { SymbolFilter = this.Stencil.Filter, Content = "All" };
                        (this.Stencil as StencilVM).SelectedFilter = all;
                    }
                    break;
            }
        }
        #endregion  
    }
}
