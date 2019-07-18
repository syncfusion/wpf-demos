#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Media.Animation;
using DiagramFrontPageUtility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;

namespace MindMap
{
    public class MapViewModel : DiagramCommonViewModel
    {

        public MapViewModel()
        {
            Nodes = new ObservableCollection<CustomNode>();
            Lines = new ObservableCollection<CustomConnector>();
        }

        double length = 100;
        double min = 30;
        public bool AllowUpdate = false;

        private CustomNode _CheckingNode;
        public CustomNode CheckingNode
        {
            get { return _CheckingNode; }
            set
            {
                _CheckingNode = value;
                OnPropertyChanged("CheckingNode");
            }
        }

        private object _data;
        public object Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }

       private CustomNode _SelectedObject;
       public CustomNode SelectedObject
       {
           get { return _SelectedObject; }
           set
           {
               _SelectedObject = value;
               OnPropertyChanged("SelectedObject");
           }
       }

       private Nodepair _pair;
       public Nodepair Pair
       {
           get
           {
               return _pair;
           }
           set
           {
               _pair = value;
               OnPropertyChanged("Pair");
           }
       }
        private ObservableCollection<CustomNode> _Nodes;
        public ObservableCollection<CustomNode> Nodes
        {
            get { return _Nodes; }
            set
            {
                _Nodes = value;
                OnPropertyChanged("Nodes");
            }
        }

        private ObservableCollection<CustomConnector> _Lines;
        public ObservableCollection<CustomConnector> Lines
        {
            get { return _Lines; }
            set
            {
                _Lines = value;
                OnPropertyChanged("Lines");
            }
        }
        private ICommand _mdelete;

        public ICommand Delete
        {
            get
            {
                return _mdelete;
            }
            set
            {
                if (_mdelete != value)
                {
                    _mdelete = value;
                    OnPropertyChanged("Delete");
                }
            }
        }

        private ICommand _mclear;

        public ICommand Clear
        {
            get
            {
                return _mclear;
            }
            set
            {
                if (_mclear != value)
                {
                    _mclear = value;
                    OnPropertyChanged("Clear");
                }
            }
        }
        
        private ICommand m_Back;

        public ICommand Back
        {
            get { return m_Back; }
            set
            {
                if (m_Back != value)
                {
                    m_Back = value;
                    OnPropertyChanged("Back");
                }
            }
        }

        private ICommand m_GoBack;

        public ICommand GoBack
        {
            get { return m_GoBack; }
            set
            {
                if (m_GoBack != value)
                {
                    m_GoBack = value;
                    OnPropertyChanged("GoBack");
                }
            }
        }

        private string m_CurrentlyLoaded;

        public string CurrentlyLoaded
        {
            get { return m_CurrentlyLoaded; }
            set
            {
                if (m_CurrentlyLoaded != value)
                {
                    m_CurrentlyLoaded = value;
                    OnPropertyChanged("CurrentlyLoaded");
                }
            }
        }

        private ICommand m_Save;

        public ICommand Save
        {
            get { return m_Save; }
            set
            {
                if (m_Save != value)
                {
                    m_Save = value;
                    OnPropertyChanged("Save");
                }
            }
        }

        private ICommand m_Load;

        public ICommand Load
        {
            get { return m_Load; }
            set
            {
                if (m_Load != value)
                {
                    m_Load = value;
                    OnPropertyChanged("Load");
                }
            }
        }

        public CustomNode RootNode()
        {
            CustomNode n = new CustomNode();
            n.AllowDelete = false;
            n.InitialPair = new Nodepair(null, n, null);
            n.Childs = new ObservableCollection<CustomNode>();
            n.OffsetX = 700;
            n.OffsetY = 350;
            n.UnitHeight = 40;
            n.UnitWidth = 75;
            //n.Constraints = n.Constraints ^ NodeConstraints.Draggable;
            n.ContentTemplate = App.Current.Resources["RNodeTemplate"] as DataTemplate;
            NodePort port = new NodePort();
            NodePort port1 = new NodePort();
            port.Visibility = Visibility.Collapsed;
            port1.Visibility = Visibility.Collapsed;
            port.NodeOffsetX = 0;
            port.NodeOffsetY = 0.5;
            port1.NodeOffsetX = 1;
            port1.NodeOffsetY = 0.5;
            n.NodePorts = new ObservableCollection<INodePort>()
            {
                port,
                port1
            };
            n.NodeAnnotations = new ObservableCollection<IAnnotation>()
            {
                new CustomLabel(){Content="Root Node"}
            };
            Nodes.Add(n);
            return n;
        }

        public void Update(CustomNode node)
        {
            AddNode(node.Pair);
            foreach (CustomNode n in node.Childs)
            {
                Update(n);
            }
            //if (!Nodes.Contains(node))
            //    Nodes.Add(node);
        }

        public bool ChildCheck(CustomNode node)
        {
            bool IsFound = false;
            if (node.Childs != null)
            {
                foreach (CustomNode n in node.Childs)
                {
                    if (n == CheckingNode)
                    {
                        IsFound = true;
                    }
                    else
                    {
                        IsFound = ChildCheck(n);
                    }
                    if (IsFound)
                        break;
                }
            }
            return IsFound;
        }

        public  void RemoveNode(CustomNode root)
        {
            if (root.Childs != null)
            {
                foreach (CustomNode node in root.Childs)
                {
                    RemoveNode(node);
                }
            }

            if (!AllowUpdate & root.Pair.Root != null)
            {
                Animate(root, (root.Info as INodeInfo).ActualWidth, 0, "Width");
                Animate(root, (root.Info as INodeInfo).ActualHeight, 0, "Height");
                if (root.Pair.Root.OffsetX < root.OffsetX)
                    Animate(root, root.OffsetX, root.OffsetX - 100, "OffsetX");
                if (root.Pair.Root.OffsetX > root.OffsetX)
                    Animate(root, root.OffsetX, root.OffsetX + 100, "OffsetX");
                if (root.Pair.Root.OffsetY < root.OffsetY)
                    Animate(root, root.OffsetY, root.OffsetY - 100, "OffsetY");
                if (root.Pair.Root.OffsetY > root.OffsetY)
                    Animate(root, root.OffsetY, root.OffsetY + 100, "OffsetY");
            
                 //Task.WaitAny(TimeSpan.FromMilliseconds(200));
                if (root.Pair.Link != null)
                {
                    Lines.Remove(root.Pair.Link);
                }
                Nodes.Remove(root);
            }
            else
            {
                root.OffsetX = 700;
                root.OffsetY = 350;
            }
        }

        private void Animate(CustomNode root, double from, double to, string name)
        {
            //root.From = from;
            //root.Pname = name;
            //root.To = to;
        }

        public void AddNode(Nodepair root)
        {
            double x = root.Root.OffsetX;
            double y = root.Root.OffsetY;
            double x1 = 0;
            double y1 = 0;
            double x2 = 0;
            string angle;
            if (root.Root.Pair == null)
                root.Root.Pair = root.Root.InitialPair;
            if (root.Root.Pair.Root == null)
            {
                for (int i = 1; i < 100; i++)
                {
                    x1 = (i * length - ((i - 1) * min)) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                    y1 = (i * length) + (root.Root.Info as INodeInfo).ActualHeight / 2 + (root.Child.Info as INodeInfo).ActualHeight / 2;
                    x2 = (i * length) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                    if (Check(root, new Point(x + x1, y - y1)))
                    {
                        AddElement(root, new Point(x + x1, y - y1));
                        break;
                    }

                    else if (Check(root, new Point(x + x1, y + y1)))
                    {
                        AddElement(root, new Point(x + x1, y + y1));
                        break;
                    }

                    else if (Check(root, new Point(x - x1, y + y1)))
                    {
                        AddElement(root, new Point(x - x1, y + y1));
                        break;
                    }

                    else if (Check(root, new Point(x - x1, y - y1)))
                    {
                        AddElement(root, new Point(x - x1, y - y1));
                        break;
                    }

                    else if (Check(root, new Point(x + x2, y)))
                    {
                        AddElement(root, new Point(x + x2, y));
                        break;
                    }

                    else if (Check(root, new Point(x, y + y1)))
                    {
                        AddElement(root, new Point(x, y + y1));
                        break;
                    }

                    else if (Check(root, new Point(x - x2, y)))
                    {
                        AddElement(root, new Point(x - x2, y));
                        break;
                    }

                    else if (Check(root, new Point(x, y - y1)))
                    {
                        AddElement(root, new Point(x, y - y1));
                        break;
                    }

                }
            }
            else
            {
                angle = root.Root.Angle.ToString();
                switch (angle)
                {
                    case "-90":
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                x1 = (i * length - ((i - 1) * min)) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                y1 = (i * length) + (root.Root.Info as INodeInfo).ActualHeight / 2 + (root.Child.Info as INodeInfo).ActualHeight / 2;
                                x2 = (i * length) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;

                                if (Check(root, new Point(x, y-y1)))
                                {
                                    AddElement(root, new Point(x, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x-x1, y-y1)))
                                {
                                    AddElement(root, new Point(x-x1, y-y1));
                                    break;
                                }
                                else if (Check(root, new Point(x+x1, y-y1)))
                                {
                                    AddElement(root, new Point(x+x1, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x-x2, y)))
                                {
                                    AddElement(root, new Point(x-x2, y));
                                    break;
                                }

                                else if (Check(root, new Point(x+x2, y)))
                                {
                                    AddElement(root, new Point(x+x2, y));
                                    break;
                                }
                                else if (Check(root, new Point(x-x1, y+y1)))
                                {
                                    AddElement(root, new Point(x-x1, y+y1));
                                    break;
                                }
                                else if (Check(root, new Point(x+x1, y+y1)))
                                {
                                    AddElement(root, new Point(x+x1, y+y1));
                                    break;
                                }

                            }
                        }
                        break;
                    case "-45":
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                x1 = (i * length - ((i - 1) * min)) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                y1 = (i * length) + (root.Root.Info as INodeInfo).ActualHeight / 2 + (root.Child.Info as INodeInfo).ActualHeight / 2;
                                x2 = (i * length) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;

                                if (Check(root, new Point(x+x1, y-y1)))
                                {
                                    AddElement(root, new Point(x+x1, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x+x2, y)))
                                {
                                    AddElement(root, new Point(x+x2, y));
                                    break;
                                }
                                else if (Check(root, new Point(x, y-y1)))
                                {
                                    AddElement(root, new Point(x, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x+x1, y+y1)))
                                {
                                    AddElement(root, new Point(x+x1, y+y1));
                                    break;
                                }



                                else if (Check(root, new Point(x-x1, y-y1)))
                                {
                                    AddElement(root, new Point(x-x1, y-y1));
                                    break;
                                }



                                else if (Check(root, new Point(x, y+y1)))
                                {
                                    AddElement(root, new Point(x, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x-x2, y)))
                                {
                                    AddElement(root, new Point(x-x2, y));
                                    break;
                                }

                            }
                        }
                        break;
                    case "0":
                        {
                            for (int i = 1; i < 10; i++)
                            {

                                x1 = (i * length - ((i - 1) * min)) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                y1 = (i * length) + (root.Root.Info as INodeInfo).ActualHeight / 2 + (root.Child.Info as INodeInfo).ActualHeight / 2;
                                x2 = (i * length) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;

                                if (Check(root, new Point(x+x2, y)))
                                {
                                    AddElement(root, new Point(x+x2, y));
                                    break;
                                }
                                else if (Check(root, new Point(x+x1, y-y1)))
                                {
                                    AddElement(root, new Point(x+x1, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x+x1, y+y1)))
                                {
                                    AddElement(root, new Point(x+x1, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x, y-y1)))
                                {
                                    AddElement(root, new Point(x, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x, y+y1)))
                                {
                                    AddElement(root, new Point(x, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x-x1, y-y1)))
                                {
                                    AddElement(root, new Point(x-x1, y-y1));
                                    break;
                                }
                                else if (Check(root, new Point(x-x1, y+y1)))
                                {
                                    AddElement(root, new Point(x-x1, y+y1));
                                    break;
                                }

                            }
                        }
                        break;
                    case "45":
                        {
                           
                            for (int i = 1; i < 10; i++)
                            {
                                x1 = (i * length - ((i - 1) * min)) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                y1 = (i * length) + (root.Root.Info as INodeInfo).ActualHeight / 2 + (root.Child.Info as INodeInfo).ActualHeight / 2;
                                x2 = (i * length) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                if (Check(root, new Point(x+x1, y+y1)))
                                {
                                    AddElement(root, new Point(x+x1, y+y1));
                                    break;
                                }
                                else if (Check(root, new Point(x+x2, y)))
                                {
                                    AddElement(root, new Point(x+x2, y));
                                    break;
                                }

                                else if (Check(root, new Point(x, y+y1)))
                                {
                                    AddElement(root, new Point(x, y+y1));
                                    break;
                                }
                                else if (Check(root, new Point(x+x1, y-y1)))
                                {
                                    AddElement(root, new Point(x+x1, y-y1));
                                    break;
                                }
                                else if (Check(root, new Point(x-x1, y+y1)))
                                {
                                    AddElement(root, new Point(x-x1, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x, y-y1)))
                                {
                                    AddElement(root, new Point(x, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x-x2, y)))
                                {
                                    AddElement(root, new Point(x-x2, y));
                                    break;
                                }

                            }
                        }
                        break;
                    case "90":
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                x1 = (i * length - ((i - 1) * min)) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                y1 = (i * length) + (root.Root.Info as INodeInfo).ActualHeight / 2 + (root.Child.Info as INodeInfo).ActualHeight / 2;
                                x2 = (i * length) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                if (Check(root, new Point(x, y+y1)))
                                {
                                    AddElement(root, new Point(x, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x-x1, y+y1)))
                                {
                                    AddElement(root, new Point(x-x1, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x+x1, y+y1)))
                                {
                                    AddElement(root, new Point(x+x1, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x-x2, y)))
                                {
                                    AddElement(root, new Point(x-x2, y));
                                    break;
                                }
                                else if (Check(root, new Point(x+x2, y)))
                                {
                                    AddElement(root, new Point(x+x2, y));
                                    break;
                                }

                                else if (Check(root, new Point(x-x1, y-y1)))
                                {
                                    AddElement(root, new Point(x-x1, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x+x1, y-y1)))
                                {
                                    AddElement(root, new Point(x+x1, y-y1));
                                    break;
                                }
                            }
                        }
                        break;
                    case "135":
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                x1 = (i * length - ((i - 1) * min)) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                y1 = (i * length) + (root.Root.Info as INodeInfo).ActualHeight / 2 + (root.Child.Info as INodeInfo).ActualHeight / 2;
                                x2 = (i * length) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                if (Check(root, new Point(x-x1, y+y1)))
                                {
                                    AddElement(root, new Point(x-x1, y+y1));
                                    break;
                                }
                                else if (Check(root, new Point(x-x2, y)))
                                {
                                    AddElement(root, new Point(x-x2, y));
                                    break;
                                }

                                else if (Check(root, new Point(x, y+y1)))
                                {
                                    AddElement(root, new Point(x, y+y1));
                                    break;
                                }
                                else if (Check(root, new Point(x-x1, y-y1)))
                                {
                                    AddElement(root, new Point(x-x1, y-y1));
                                    break;
                                }
                                else if (Check(root, new Point(x+x1, y+y1)))
                                {
                                    AddElement(root, new Point(x+x1, y+y1));
                                    break;
                                }
                                else if (Check(root, new Point(x, y-y1)))
                                {
                                    AddElement(root, new Point(x, y-y1));
                                    break;
                                }
                                else if (Check(root, new Point(x+x2, y)))
                                {
                                    AddElement(root, new Point(x+x2, y));
                                    break;
                                }
                            }
                        }
                        break;
                    case "180":
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                x1 = (i * length - ((i - 1) * min)) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                y1 = (i * length) + (root.Root.Info as INodeInfo).ActualHeight / 2 + (root.Child.Info as INodeInfo).ActualHeight / 2;
                                x2 = (i * length) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                if (Check(root, new Point(x-x2, y)))
                                {
                                    AddElement(root, new Point(x-x2, y));
                                    break;
                                }

                                else if (Check(root, new Point(x-x1, y-y1)))
                                {
                                    AddElement(root, new Point(x-x1, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x-x1, y+y1)))
                                {
                                    AddElement(root, new Point(x-x1, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x, y-y1)))
                                {
                                    AddElement(root, new Point(x, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x, y+y1)))
                                {
                                    AddElement(root, new Point(x, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x+x1, y-y1)))
                                {
                                    AddElement(root, new Point(x+x1, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x+x1, y+y1)))
                                {
                                    AddElement(root, new Point(x+x1, y+y1));
                                    break;
                                }

                            }
                        }
                        break;
                    case "-135":
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                x1 = (i * length - ((i - 1) * min)) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                y1 = (i * length) + (root.Root.Info as INodeInfo).ActualHeight / 2 + (root.Child.Info as INodeInfo).ActualHeight / 2;
                                x2 = (i * length) + (root.Root.Info as INodeInfo).ActualWidth / 2 + (root.Child.Info as INodeInfo).ActualWidth / 2;
                                if (Check(root, new Point(x-x1, y-y1)))
                                {
                                    AddElement(root, new Point(x-x1, y-y1));
                                    break;
                                }

                                else if (Check(root, new Point(x-x2, y)))
                                {
                                    AddElement(root, new Point(x-x2, y));
                                    break;
                                }

                                else if (Check(root, new Point(x, y-y1)))
                                {
                                    AddElement(root, new Point(x, y-y1));
                                    break;
                                }
                                else if (Check(root, new Point(x-x1, y+y1)))
                                {
                                    AddElement(root, new Point(x-x1, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x+x1, y-y1)))
                                {
                                    AddElement(root, new Point(x+x1, y-y1));
                                    break;
                                }
                                else if (Check(root, new Point(x, y+y1)))
                                {
                                    AddElement(root, new Point(x, y+y1));
                                    break;
                                }

                                else if (Check(root, new Point(x+x2, y)))
                                {
                                    AddElement(root, new Point(x+x2, y));
                                    break;
                                }

                            }
                        }
                        break;
                }
            }
            
        }

        public bool Check(Nodepair root, Point p)
        {
            Rect r1 = new Rect(new Point(p.X - 60, p.Y - 30), new Point(p.X + 60, p.Y + 30));
            foreach (CustomNode n in Nodes)
            {
                Rect r = (n.Info as INodeInfo).Bounds;
                //Rect r = new Rect(n.OffsetX, n.OffsetY, (n.Info as INodeInfo).ActualWidth, (n.Info as INodeInfo).ActualHeight);
                if (n != root.Child)
                {
                    if (r1.Contains(new Point((n.Info as INodeInfo).Bounds.Left, (n.Info as INodeInfo).Bounds.Top)) || r1.Contains(new Point((n.Info as INodeInfo).Bounds.Right, (n.Info as INodeInfo).Bounds.Top)) || r1.Contains(new Point((n.Info as INodeInfo).Bounds.Left, (n.Info as INodeInfo).Bounds.Bottom)) || r1.Contains(new Point((n.Info as INodeInfo).Bounds.Right, (n.Info as INodeInfo).Bounds.Bottom)) || r.Contains(new Point(p.X, p.Y)))
                       
                   // if (r.Contains(new Point(p.X,p.Y)) || r1.Contains(new Point((n.Info as INodeInfo).Bounds.Left, (n.Info as INodeInfo).Bounds.Top)) || r1.Contains(new Point(n.OffsetX + (n.Info as INodeInfo).Bounds.Width, n.OffsetY + (n.Info as INodeInfo).Bounds.Height)) || r1.Contains(new Point(n.OffsetX - (n.Info as INodeInfo).Bounds.Width, n.OffsetY - (n.Info as INodeInfo).Bounds.Height)))
                        return false;
                }
            }
            //Rect r2 = new Rect(root.Root.OffsetX, root.Root.OffsetY, (root.Root.Info as INodeInfo).ActualWidth, (root.Root.Info as INodeInfo).ActualHeight);
            //if(r2.Contains(new Point(p.X - 50, p.Y - 50))|| r2.Contains(new Point(p.X + 50, p.Y + 50)))
            //    return false;
            return true;
        }

      public  double FindAngle(CustomNode node)
        {
            //if (node.Pair == null)
            //    node.Pair = node.InitialPair;
            if (node.Pair.Root != null)
            {
                Point p1 = new Point(node.Pair.Root.OffsetX, node.Pair.Root.OffsetY);
                Point p2 = new Point(node.Pair.Child.OffsetX, node.Pair.Child.OffsetY);
                double dx = p2.X - p1.X;
                double dy = p2.Y - p1.Y;
                double ang = Math.Atan2(dy, dx) * 180 / Math.PI;
                return ang;
            }
            else return 0;
        }

        public void AddElement(Nodepair pair, Point p)
        {
           
            pair.Child.OffsetX = p.X;
            pair.Child.OffsetY = p.Y;
            pair.Child.Angle = FindAngle(pair.Child);
            Pair = pair;
            if (!AllowUpdate)
            {
                //if (pair.Root.OffsetX < p.X)
                //    Animate(pair.Child, p.X - 100, p.X, "OffsetX");
                //if (pair.Root.OffsetX > p.X)
                //    Animate(pair.Child, p.X + 100, p.X, "OffsetX");
                //if (pair.Root.OffsetY < p.Y)
                //    Animate(pair.Child, p.Y - 100, p.Y, "OffsetY");
                //if (pair.Root.OffsetY > p.Y)
                //    Animate(pair.Child, p.Y + 100, p.Y, "OffsetY");
            }
            pair.Link.SourceNode = pair.Root;
            pair.Link.TargetNode=pair.Child;
        }


        public Storyboard RepeatAnimate(CustomNode n, double from, double to, string property, bool complete, bool autoreverse)
        {
            Storyboard storyboard = new Storyboard();
           // if (complete)
           //     storyboard.Completed += storyboard_Completed;
           // DoubleAnimation doubleAnimation = new DoubleAnimation();
           // doubleAnimation.From = from;
           // doubleAnimation.To = to;
           // if (autoreverse)
           //     doubleAnimation.AutoReverse = true;
           // doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(200));
           // doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
           // doubleAnimation.EnableDependentAnimation = true;
           // storyboard.Children.Add(doubleAnimation);
           //// Storyboard.SetTarget(doubleAnimation,n);
           // Storyboard.SetTargetProperty(doubleAnimation, property);
           // storyboard.Begin();
            return storyboard;
        }

        private void storyboard_Completed(object sender, object e)
        {
            Animate(Pair.Child, (Pair.Child.Info as INodeInfo).ActualWidth, (Pair.Child.Info as INodeInfo).ActualWidth + 10, "Width");
            Animate(Pair.Child, (Pair.Child.Info as INodeInfo).ActualHeight, (Pair.Child.Info as INodeInfo).ActualHeight + 10, "Height");
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private Predicate<T> _canExecute;
        private Action<T> _method;
        bool _canExecuteCache = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        public DelegateCommand(Action<T> method)
            : this(method, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="canExecute">The can execute.</param>
        public DelegateCommand(Action<T> method, Predicate<T> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public DelegateCommand(ICommand Clicked, Predicate<object> predicate)
        {
            // TODO: Complete member initialization
            this.Clicked = Clicked;
            this.predicate = predicate;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                bool tempCanExecute = _canExecute((T)parameter);

                if (_canExecuteCache != tempCanExecute)
                {
                    _canExecuteCache = tempCanExecute;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                }
            }

            return _canExecuteCache;

        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (_method != null)
                _method.Invoke((T)parameter);
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged;
        private ICommand Clicked;
        private Predicate<object> predicate;

        #endregion
    }
}
