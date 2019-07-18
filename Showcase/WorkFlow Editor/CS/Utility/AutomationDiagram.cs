#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Input;
using SPath = System.Windows.Shapes.Path;
using System.Windows.Media;
namespace WorkFlowEditor
{
    public class AutomationDiagram : SfDiagram
    {

        public AutomationDiagram()
        {
            CustomSelector selector = new CustomSelector();
            selector.Graph = this;
            SelectedItems = selector;
            selector.ZIndex = 10000;
            selector.Nodes = new ObservableCollection<object>();
            selector.Connectors = new ObservableCollection<object>();
            selector.Groups = new ObservableCollection<object>();
        }

        public Syncfusion.UI.Xaml.Diagram.Selector SFSelector = new Syncfusion.UI.Xaml.Diagram.Selector();

        protected override Syncfusion.UI.Xaml.Diagram.Selector GetSelectorForItemOverride(object item)
        {
            return SFSelector;
        }
        protected override object GetNewConnector(Type desiredType)
        {
            return new ProcessAutomationConnector()
            {
                ConnectorGeometryStyle = GetStyle()
               
            };
        }
      
        private Style GetStyle()
        {
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.StrokeProperty, new SolidColorBrush(Colors.Black)));
            s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 1d));
            return s;
        }

        
    }

    public class CustomSelector : SelectorViewModel
    {
        public IGraph Graph { get; set; }

        private object _mobj;
        public object SelectedObject
        {
            get
            {
                return _mobj;
            }
            set
            {
                if (_mobj != value)
                {
                    _mobj = value;
                    OnPropertyChanged("SelectedObject");
                }
            }
        }

        private SolidColorBrush _brush=new SolidColorBrush(Colors.White);

        public SolidColorBrush fillbrush
        {
            get
            {
                return _brush;
            }
            set
            {
                if (_brush != value)
                {
                    _brush = value;
                    OnPropertyChanged("fillbrush");
                }
            }
        }
    }

    public class DrawParam : IDrawParameter
    {
        public DrawingTool Tool { get; set; }
        public Point? Point { get; set; }
        public object Node { get; set; }
        public object Port { get; set; }
        public MouseEventArgs PressedEventArgs { get; set; }
        public NullSourceTarget NullSourceTarget { get; private set; }

        public DrawParam(MouseEventArgs args, object node)
        {
            Tool = DrawingTool.Connector;
            PressedEventArgs = args;
            Node = node;
            NullSourceTarget = NullSourceTarget.None;
        }
    }
}
