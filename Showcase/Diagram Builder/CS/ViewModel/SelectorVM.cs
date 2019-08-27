#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DiagramBuilder.Utility;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Windows.Controls;
using System.Collections;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Diagram.Controls;

namespace DiagramBuilder.ViewModel
{
    public class SelectorVM : SelectorViewModel, ISelectorVM
    {
        public SelectorVM(DiagramVM diagram)
        {
            Diagram = diagram;
            Diagram.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Info")
                {
                    (Diagram.Info as IGraphInfo).ItemSelectedEvent += ItemSelectedEvent;
                    (Diagram.Info as IGraphInfo).ItemUnSelectedEvent += ItemUnSelectedEvent;
                    (Diagram.Info as IGraphInfo).ViewPortChangedEvent += SelectorVM_ViewPortChangedEvent;
                    (Diagram.Info as IGraphInfo).ItemTappedEvent += SelectorVM_ItemTappedEvent;
                }
            };
            PickerCommand = new Command(param => CurrentBrush = (CurrentBrush)param);
            DecoratorCommand = new DelegateCommand(OnDecoratorChanged, args => { return true; });
            DashDotCommand = new DelegateCommand(OnDashDotCommand, args => { return true; });
            CloseColorPickerPaletteCommand = new DelegateCommand(OnCloseColorPickerPaletteCommand, args => { return true; });
            Diagram = diagram;
            GrowFont = new Command(OnGrowCommand);
            ShrinkFont = new Command(OnShrinkCommand);
            ThicknessCommand = new Command(OnThicknessCommand);
        }

        private void OnCloseColorPickerPaletteCommand(object obj)
        {
            
        }

        private void SelectorVM_ItemTappedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is NodeVM)
            {
                if ((args.Item as NodeVM).Style == null)
                {
                    this.NodeGallaryName = null;
                }
            }
            else if (args.Item is INodePortVM)
            {
                INodePortVM port = args.Item as INodePortVM;
                INodePortVM selectedPort = SelectedPort != null ? SelectedPort as INodePortVM : null;
                this.Clear();
                if(selectedPort!=port)
                SelectedPort = port;
            }
            else
            {
                SelectedPort = null;
            }
        }


        private void OnDashDotCommand(object obj)
        {
            var a = (obj as Grid);
            if (IsConnectorSelected || IsNodeSelected)
            {
                foreach (var node in SelectedItems.OfType<IGroupableVM>())
                {
                    node.DashDot = a.DataContext.ToString();
                }
            }
        }

        private void OnDecoratorChanged(object obj)
        {
            var a = (obj as Grid);
            //GroupTransactions group = new GroupTransactions();
            //group.ContinuousUndoRedo = ContinuousUndoRedo.Start;
            //Diagram.HistoryManager.BeginComposite(Diagram.HistoryManager, group);
            if (IsConnectorSelected)
            {
                foreach (var con in SelectedItems.OfType<IConnectorVM>())
                {

                    con.TargetCap = null;
                    con.SourceCap = null;
                    if ((a.DataContext as Arrows).Issourcecap)
                    {
                        con.SourceCap = ((a.DataContext as Arrows)).LineData;
                    }
                    else if (((a.DataContext as Arrows)).Istargetcap)
                    {
                        con.TargetCap = ((a.DataContext as Arrows)).LineData;
                    }
                    else if (((a.DataContext as Arrows)).Isbothcap)
                    {
                        con.SourceCap = ((a.DataContext as Arrows)).LineData;
                        con.TargetCap = ((a.DataContext as Arrows)).LineData;
                    }

                }
            }
            //GroupTransactions group1 = new GroupTransactions();
            //group1.ContinuousUndoRedo = ContinuousUndoRedo.End;
            //Diagram.HistoryManager.EndComposite(Diagram.HistoryManager, group1);

        }

        private void OnShrinkCommand(object obj)
        {
            this.FontValue = -2;
        }

        private void OnGrowCommand(object obj)
        {           
            this.FontValue = 2;
        }


        private void OnThicknessCommand(object obj)
        {
            int thickness = 0;
            if (int.TryParse(obj.ToString(), out thickness))
            {
                foreach (var node in SelectedItems.OfType<IGroupableVM>())
                {
                    node.Thickness = (double)thickness;
                }
                foreach (var connector in SelectedItems.OfType<IGroupableVM>())
                {
                    connector.Thickness = (double)thickness;
                }
            }
        }

        public void Clear()
        {
            List<IGroupableVM> local = new List<IGroupableVM>();
            foreach (IGroupableVM item in SelectedItems)
            {
                local.Add(item);
            }
            foreach (IGroupableVM item in local)
            {
                (item as IGroupable).IsSelected = false;
            }
            Annotation = null;
            SelectedPort = null;
        }

        void SelectorVM_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            Scale = args.NewValue.CurrentZoom;
        }

        public DiagramVM Diagram { get; set; }

        List<IGroupableVM> SelectedItems = new List<IGroupableVM>();
        private IPort _mSelectedPort;

        public IPort SelectedPort
        {
            get { return _mSelectedPort; }
            set
            {
                if (_mSelectedPort != value)
                {
                    if (value == null)
                    {
                        (_mSelectedPort as INodePortVM).IsSelected = false;
                    }
                    else
                    {
                        (value as INodePortVM).IsSelected = true;
                    }
                    _mSelectedPort = value;
                    OnPropertyChanged("SelectedPort");
                }
            }
        }
        private void UpdateProperties(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case GroupableConstants.Label:
                    if (SelectedItems.Count == 1)
                    {
                        Label = SelectedItems.FirstOrDefault().Label;
                    }
                    UpdateSelectedKind();
                    break;
                case GroupableConstants.OffsetX:
                    if (SelectedItems.OfType<INode>().Count() == 1)
                    {
                        X = SelectedItems.OfType<INode>().FirstOrDefault().OffsetX;
                    }
                    else
                    {
                        X = null;
                    }
                    break;
                case GroupableConstants.OffsetY:
                    if (SelectedItems.OfType<INode>().Count() == 1)
                    {
                        Y = SelectedItems.OfType<INode>().FirstOrDefault().OffsetY;
                    }
                    else
                    {
                        Y = null;
                    }
                    break;
                case GroupableConstants.UnitWidth:
                    if (SelectedItems.OfType<INode>().Count() == 1)
                    {
                        Width = SelectedItems.OfType<INode>().FirstOrDefault().UnitWidth;
                    }
                    if (SelectedItems.OfType<INode>().Count() == 0)
                    {
                        Width = null;
                    }
                    break;
                case GroupableConstants.UnitHeight:
                    if (SelectedItems.OfType<INode>().Count() == 1)
                    {
                        Height = SelectedItems.OfType<INode>().FirstOrDefault().UnitHeight;
                    }
                    if (SelectedItems.OfType<INode>().Count() == 0)
                    {
                        Height = null;
                    }
                    break;
                case GroupableConstants.RotateAngle:
                    if (SelectedItems.OfType<INode>().Count() == 1)
                    {
                        Angle = SelectedItems.OfType<INode>().FirstOrDefault().RotateAngle;
                    }
                    if (SelectedItems.OfType<INode>().Count() == 0)
                    {
                        Angle = null;
                    }
                    break;
                case GroupableConstants.HyperLink:
                    if (SelectedItems.Count == 1)
                    {
                        HyperLink = SelectedItems.FirstOrDefault().HyperLink;
                    }
                    UpdateSelectedKind();
                    break;
            }
        }
        bool italic = false;
        bool bold = false;
        bool underline = false;
        bool strike = false;     
        void ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            var item = args.Item as IGroupableVM;
            var node = args.Item as INodeVM;
            var con = args.Item as IConnectorVM;
            SelectedPort = null;
            item.PropertyChanged += UpdateProperties;
            SelectedItems.Add(item);
            UpdateSelectedKind();
            if (SelectedItems.Count == 1)
            {
                if (item != null)
                {
                    if (!bold)
                    {
                        bold = this.Bold.Value;
                        this.Bold = item.Bold;
                    }
                    if (!underline)
                    {
                        underline = this.UnderLine.Value;
                        this.UnderLine = item.UnderLine;
                    }
                    if (!strike)
                    {
                        strike = this.Strike.Value;
                        this.Strike = item.Strike;
                    }
                    this.DashDot = item.DashDot;
                    this.Font = item.Font;
                    this.FontSize = item.FontSize;                   
                    this.FontStyle = item.FontStyle;
                    this.FontWeight = item.FontWeight;
                    if (!italic)
                    {                     
                        italic = this.Italic.Value;
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
                    this.Visibile = item.Visibility == Visibility.Visible;
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
                    this.NodeGallaryName = node.NodeGallaryName;
                    if (node.QuickFill==null&&node.Fill is SolidColorBrush)
                        this.Fill = node.Fill;
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
                    this.ConnectorGallaryName = con.ConnectorGallaryName;
                    this.Stroke = con.Stroke;
                }
                else
                {
                    SourceCap = null;
                    TargetCap = null;
                    Type = null;
                }
            }
            if (SelectedItems.OfType<INodeVM>().Count() == 1)
            {
                node = SelectedItems.OfType<INodeVM>().FirstOrDefault();
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
                if (node.QuickFill==null&&node.Fill is SolidColorBrush)
                    this.Fill = node.Fill;
            }

            if (SelectedItems.OfType<IConnectorVM>().Count() == 1)
            {
                con = SelectedItems.OfType<IConnectorVM>().FirstOrDefault();
                this.SourceCap = con.SourceCap;
                this.TargetCap = con.TargetCap;
                this.Type = con.Type;
            }
            
        }

        void ItemUnSelectedEvent(object sender, DiagramEventArgs args)
        {
            var item = args.Item as IGroupableVM;
            item.PropertyChanged += UpdateProperties;
            SelectedItems.Remove(args.Item as IGroupableVM);
            if (item is IGroupable)
            {
                foreach (IAnnotation annotaiton in (item as IGroupable).Annotations as List<IAnnotation>)
                {
                    if (annotaiton.Content != null)
                    {
                        if (string.IsNullOrEmpty(annotaiton.Content.ToString()))
                        {
                            if (item is NodeVM)
                            {
                                Diagram.NodeCollection.Remove(item as NodeVM);
                                break;
                            }
                            else if (item is ConnectorVM)
                            {
                                Diagram.ConnectorCollection.Remove(item as ConnectorVM);
                                break;
                            }
                        }
                    }
                }
            }
            UpdateSelectedKind();
            if (SelectedItems.Count == 1)
            {
                var firstItem = SelectedItems[0];
                var firstNode = SelectedItems[0] as INodeVM;
                var firstCon = SelectedItems[0] as IConnectorVM;
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
                    this.Visibile = firstItem.Visibility == Visibility.Visible;
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
                    SourceCap = null;
                    TargetCap = null;
                    Type = null;
                }
            }
            if (SelectedItems.OfType<INodeVM>().Count() == 1)
            {
                var node = SelectedItems.OfType<INodeVM>().FirstOrDefault();
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

            if (SelectedItems.OfType<INodeVM>().Count() == 0)
            {
                var node = SelectedItems.OfType<INodeVM>().FirstOrDefault();
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
                if (bold)
                {
                    this.Bold = bold;
                    bold = false;
                }
                if (underline)
                {
                    this.UnderLine = underline;
                    underline = false;
                }
                if (italic)
                {
                    this.Italic = italic;
                    italic = false;
                }
                if (strike)
                {
                    this.Strike = strike;
                    strike = false;
                }
                this.FontSize = 12;
                this.Font = new FontFamily("Segoe UI");
            }


            if (SelectedItems.OfType<IConnectorVM>().Count() == 1)
            {
                var con = SelectedItems.OfType<IConnectorVM>().FirstOrDefault();
                this.SourceCap = con.SourceCap;
                this.TargetCap = con.TargetCap;
                this.Type = con.Type;
            }
            if (SelectedItems.Count > 1)
            {
                var firstItem = SelectedItems[0];
                if (firstItem != null)
                {
                    if (SelectedItems.Any(i => i.Bold != firstItem.Bold))
                    {
                        Bold = null;
                    }
                    else
                    {
                        Bold = firstItem.Bold;
                    }

                    if (SelectedItems.Any(i => i.UnderLine != firstItem.UnderLine))
                    {
                        UnderLine = null;
                    }
                    else
                    {
                        UnderLine = firstItem.UnderLine;
                    }


                    if (SelectedItems.Any(i => i.DashDot != firstItem.DashDot))
                    {
                        DashDot = null;
                    }
                    else
                    {
                        DashDot = firstItem.DashDot;
                    }

                    if (SelectedItems.Any(i => i.Font != firstItem.Font))
                    {
                        Font = null;
                    }
                    else
                    {
                        Font = firstItem.Font;
                    }

                    if (SelectedItems.Any(i => i.FontSize != firstItem.FontSize))
                    {
                        FontSize = null;
                    }
                    else
                    {
                        FontSize = firstItem.FontSize;
                    }

                    
                    if (SelectedItems.Any(i => i.FontStyle != firstItem.FontStyle))
                    {
                        FontStyle = null;
                    }
                    else
                    {
                        FontStyle = firstItem.FontStyle;
                    }

                    if (SelectedItems.Any(i => i.FontWeight.Equals(firstItem.FontWeight)))
                    {
                        FontWeight = null;
                    }
                    else
                    {
                        FontWeight = firstItem.FontWeight;
                    }


                    if (SelectedItems.Any(i => i.LabelBackground != firstItem.LabelBackground))
                    {
                        LabelBackground = null;
                    }
                    else
                    {
                        LabelBackground = firstItem.LabelBackground;
                    }


                    if (SelectedItems.Any(i => i.LabelForeground != firstItem.LabelForeground))
                    {
                        LabelForeground = null;
                    }
                    else
                    {
                        LabelForeground = firstItem.LabelForeground;
                    }

                    if (SelectedItems.Any(i => i.Italic != firstItem.Italic))
                    {
                        Italic = null;
                    }
                    else
                    {
                        Italic = firstItem.Italic;
                    }

                    if (SelectedItems.Any(i => i.Label != firstItem.Label))
                    {
                        Label = null;
                    }
                    else
                    {
                        Label = firstItem.Label;
                    }


                    if (SelectedItems.Any(i => i.LabelHAlign != firstItem.LabelHAlign))
                    {
                        LabelHAlign = null;
                    }
                    else
                    {
                        LabelHAlign = firstItem.LabelHAlign;
                    }

                    if (SelectedItems.Any(i => i.LabelMargin != firstItem.LabelMargin))
                    {
                        LabelMargin = null;
                    }
                    else
                    {
                        LabelMargin = firstItem.LabelMargin.Left;
                    }

                    if (SelectedItems.Any(i => i.LabelVAlign != firstItem.LabelVAlign))
                    {
                        LabelVAlign = null;
                    }
                    else
                    {
                        LabelVAlign = firstItem.LabelVAlign;
                    }

                    if (SelectedItems.Any(i => i.Name != firstItem.Name))
                    {
                        Name = string.Empty;
                    }
                    else
                    {
                        Name = firstItem.Name;
                    }

                    if (SelectedItems.Any(i => i.Stroke != firstItem.Stroke))
                    {
                        Stroke = null;
                    }
                    else
                    {
                        Stroke = firstItem.Stroke;
                    }

                    if (SelectedItems.Any(i => i.Style != firstItem.Style))
                    {
                        Style = null;
                    }
                    else
                    {
                        Style = firstItem.Style;
                    }

                    if (SelectedItems.Any(i => i.Thickness != firstItem.Thickness))
                    {
                        Thickness = null;
                    }
                    else
                    {
                        Thickness = firstItem.Thickness;
                    }

                    if (SelectedItems.Any(i => i.Visibility != firstItem.Visibility))
                    {
                        Visibile = null;
                    }
                    else
                    {
                        Visibile = firstItem.Visibility == Visibility.Visible;
                    }
                    if (SelectedItems.Any(i => i.Opacity != firstItem.Opacity))
                    {
                        Opacity = null;
                    }
                    else
                    {
                        Opacity = firstItem.Opacity;
                    }
                }
                var firstNode = SelectedItems.OfType<INodeVM>().FirstOrDefault();
                if (firstNode != null)
                {
                    if (SelectedItems.OfType<INodeVM>().Any(i => i.OffsetX != firstNode.OffsetX))
                    {
                        X = null;
                    }
                    else
                    {
                        X = firstNode.OffsetX;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.OffsetY != firstNode.OffsetY))
                    {
                        Y = null;
                    }
                    else
                    {
                        Y = firstNode.OffsetY;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.Pivot.X != firstNode.Pivot.X))
                    {
                        Px = null;
                    }
                    else
                    {
                        Px = firstNode.Pivot.X;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.Pivot.Y != firstNode.Pivot.Y))
                    {
                        Py = null;
                    }
                    else
                    {
                        Py = firstNode.Pivot.Y;
                    }
                    if (SelectedItems.OfType<INodeVM>().Any(i => i.UnitWidth != firstNode.UnitWidth))
                    {
                        Width = null;
                    }
                    else
                    {
                        Width = firstNode.UnitWidth;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.UnitHeight != firstNode.UnitHeight))
                    {
                        Height = null;
                    }
                    else
                    {
                        Height = firstNode.UnitHeight;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.RotateAngle != firstNode.RotateAngle))
                    {
                        Angle = null;
                    }
                    else
                    {
                        Angle = firstNode.RotateAngle;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.AllowDrag != firstNode.AllowDrag))
                    {
                        AllowDrag = null;
                    }
                    else
                    {
                        AllowDrag = firstNode.AllowDrag;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.AllowResize != firstNode.AllowResize))
                    {
                        AllowResize = null;
                    }
                    else
                    {
                        AllowResize = firstNode.AllowResize;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.AllowRotate != firstNode.AllowRotate))
                    {
                        AllowRotate = null;
                    }
                    else
                    {
                        AllowRotate = firstNode.AllowRotate;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.AspectRatio != firstNode.AspectRatio))
                    {
                        AspectRatio = null;
                    }
                    else
                    {
                        AspectRatio = firstNode.AspectRatio;
                    }

                    if (SelectedItems.OfType<INodeVM>().Any(i => i.Fill != firstNode.Fill))
                    {
                        Fill = null;
                    }
                    else
                    {
                        Fill = firstNode.Fill;
                    }
                }
                var firstCon = SelectedItems.OfType<IConnectorVM>().FirstOrDefault();
                if (firstCon != null)
                {
                    if (SelectedItems.OfType<IConnectorVM>().Any(i => i.SourceCap != firstCon.SourceCap))
                    {
                        SourceCap = null;
                    }
                    else
                    {
                        SourceCap = firstCon.SourceCap;
                    }

                    if (SelectedItems.OfType<IConnectorVM>().Any(i => i.TargetCap != firstCon.TargetCap))
                    {
                        TargetCap = null;
                    }
                    else
                    {
                        TargetCap = firstCon.TargetCap;
                    }

                    if (SelectedItems.OfType<IConnectorVM>().Any(i => i.Type != firstCon.Type))
                    {
                        Type = null;
                    }
                    else
                    {
                        Type = firstCon.Type;
                    }
                }
            }
        }

        private void UpdateSelectedKind()
        {
            if (SelectedItems.OfType<INodeVM>().Any())
            {
                IsNodeSelected = true;
            }
            else
            {
                IsNodeSelected = false;
            }
            if (SelectedItems.OfType<IConnectorVM>().Any())
            {
                IsConnectorSelected = true;
            }
            else
            {
                IsConnectorSelected = false;
            }
            if (IsNodeSelected || IsConnectorSelected)
            {
                IsAnythingSelected = true;
            }
            else
            {
                IsAnythingSelected = false;
            }

            if (IsAnythingSelected && SelectedItems.Any(item => !string.IsNullOrEmpty(item.Label)))
            {
                IsLabelSet = true;
            }
            else
            {
                IsLabelSet = false;
            }
            if (IsNodeSelected && SelectedItems.OfType<INodeVM>().Any(item => !string.IsNullOrEmpty((string)item.Label)))
            {
                IsNodeLabelSet = true;
            }
            else
            {
                IsNodeLabelSet = false;
            }
            if (IsConnectorSelected && SelectedItems.OfType<IConnectorVM>().Any(item => !string.IsNullOrEmpty((string)item.Label)))
            {
                IsConnectorLabelSet = true;
            }
            else
            {
                IsConnectorLabelSet = false;
            }
        }

        #region Dimension
        double? _mPx = 0d;
        public double? Px
        {
            get
            {
                return _mPx;
            }
            set
            {
                if (_mPx != value)
                {
                    _mPx = value;
                    OnPropertyChanged(SelectorConstants.Px);
                }
            }
        }

        double? _mPy = 0d;
        public double? Py
        {
            get
            {
                return _mPy;
            }
            set
            {
                if (_mPy != value)
                {
                    _mPy = value;
                    OnPropertyChanged(SelectorConstants.Py);
                }
            }
        }

        double? _mX = 0d;
        public double? X
        {
            get
            {
                return _mX;
            }
            set
            {
                if (_mX != value)
                {
                    _mX = value;
                    OnPropertyChanged(SelectorConstants.X);
                }
            }
        }

        double? _mY = 0d;
        public double? Y
        {
            get
            {
                return _mY;
            }
            set
            {
                if (_mY != value)
                {
                    _mY = value;
                    OnPropertyChanged(SelectorConstants.Y);
                }
            }
        }

        double? _mAngle = 0d;
        public double? Angle
        {
            get
            {
                return _mAngle;
            }
            set
            {
                if (_mAngle != value)
                {
                    _mAngle = value;
                    OnPropertyChanged(SelectorConstants.Angle);
                }
            }
        }

        double? _mWidth = double.NaN;
        public double? Width
        {
            get
            {
                return _mWidth;
            }
            set
            {
                if (_mWidth != value &&
                    !(_mWidth.HasValue && Double.IsNaN(_mWidth.Value) &&
                      value.HasValue && double.IsNaN(value.Value)))
                {
                    _mWidth = value;
                    OnPropertyChanged(SelectorConstants.Width);
                }
            }
        }

        double? _mHeight = double.NaN;
        public double? Height
        {
            get
            {
                return _mHeight;
            }
            set
            {
                if (_mHeight != value &&
                    !(_mHeight.HasValue && Double.IsNaN(_mHeight.Value) &&
                      value.HasValue && double.IsNaN(value.Value)))
                {
                    _mHeight = value;
                    OnPropertyChanged(SelectorConstants.Height);
                }
            }
        }

        private void OnXChanged()
        {
            if (X.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.OffsetX = X.Value;
                }
            }
        }

        private void OnYChanged()
        {
            if (Y.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.OffsetY = Y.Value;
                }
            }
        }

        private void OnPYChanged()
        {
            if (Py.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.Pivot = new Point(node.Pivot.X, Py.Value);
                }
            }
        }

        private void OnPXChanged()
        {
            if (Px.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.Pivot = new Point(Px.Value, node.Pivot.Y);
                }
            }
        }

        private void OnAngleChanged()
        {
            if (Angle.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.RotateAngle = Angle.Value;
                }
            }
        }

        private void OnWidthChanged()
        {
            if (Width.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.UnitWidth = Width.Value;
                }
            }
        }

        private void OnHeightChanged()
        {
            if (Height.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.UnitHeight = Height.Value;
                }
            }
        }

        #endregion
        
        #region Shape

        #region Prop
        private Brush _mQuickFill = null;
        public Brush QuickFill
        {
            get
            {
                return _mQuickFill;
            }
            set
            {
                if (_mQuickFill != value)
                {
                    _mQuickFill = value;
                    OnPropertyChanged(SelectorConstants.QuickFill);
                }
            }
        }
        private string _mnodeGallaryName;

        public string NodeGallaryName
        {
            get { return _mnodeGallaryName; }
            set
            {
                if (_mnodeGallaryName != value)
                {
                    if (value != null && value.Contains("Syncfusion.Windows.Tools.Controls.RibbonGalleryItem:"))
                    {
                        _mnodeGallaryName = value.Remove(0, 53);
                    }
                    else
                    {
                        _mnodeGallaryName = value;
                    }
                    OnPropertyChanged(SelectorConstants.NodeGallaryName);
                }
            }
        }
        private string _mconnectorGallaryName;

        public string ConnectorGallaryName
        {
            get { return _mconnectorGallaryName; }
            set
            {
                if (_mconnectorGallaryName != value)
                {
                    if (value != null && value.Contains("Syncfusion.Windows.Tools.Controls.RibbonGalleryItem:"))
                    {
                        _mconnectorGallaryName = value.Remove(0, 53);
                    }
                    else
                    {
                        _mconnectorGallaryName = value;
                    }

                    OnPropertyChanged(SelectorConstants.ConnectorGallaryName);
                }
            }
        }
        private string _mToolTipConstraint = "Default";

        public string ToolTipConstraint
        {
            get
            {
                return _mToolTipConstraint;
            }
            set
            {
                if (_mToolTipConstraint != value)
                {
                    _mToolTipConstraint = value;
                    OnPropertyChanged(SelectorConstants.ToolTipConstraint);
                }
            }
        }

        Brush _mFill = null;
        public Brush Fill
        {
            get
            {
                return _mFill;
            }
            set
            {
                if (_mFill != value)
                {
                    _mFill = value;
                    OnPropertyChanged(NodeConstants.Fill);
                }
            }
        }

        Brush _mStroke = null;
        public Brush Stroke
        {
            get
            {
                return _mStroke;
            }
            set
            {
                if (_mStroke != value)
                {
                    _mStroke = value;
                    OnPropertyChanged(GroupableConstants.Stroke);
                }
            }
        }

        double? _mThickness = 1d;
        public double? Thickness
        {
            get
            {
                return _mThickness;
            }
            set
            {
                if (_mThickness != value)
                {
                    _mThickness = value;
                    OnPropertyChanged(GroupableConstants.Thickness);
                }
            }
        }

        string _mDashDot = null;
        public string DashDot
        {
            get
            {
                return _mDashDot;
            }
            set
            {
                if (_mDashDot != value)
                {
                    _mDashDot = value;
                    OnPropertyChanged(GroupableConstants.DashDot);
                }
            }
        }

        Style _mStyle = null;
        public Style Style
        {
            get
            {
                return _mStyle;
            }
            set
            {
                if (_mStyle != value)
                {
                    _mStyle = value;
                    OnPropertyChanged(GroupableConstants.Style);
                }
            }
        }

        double? _mOpacity = null;
        public double? Opacity
        {
            get
            {
                return _mOpacity;
            }
            set
            {
                if (_mOpacity != value)
                {
                    _mOpacity = value;
                    OnPropertyChanged(GroupableConstants.Opacity);
                }
            }
        }
        #endregion

        private void OnFillChanged()
        {
            if (Fill != null)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {  
                    node.Fill = Fill;
                    NodeGallaryName = null;
                    node.NodeGallaryName = null;
                }
            }
        }

        private void OnStrokeChanged()
        {
            if (Stroke != null)
            {
                foreach (var node in SelectedItems.OfType<IGroupableVM>())
                {
                    node.Stroke = Stroke;
                    if (node is ConnectorVM)
                    {
                        ConnectorGallaryName = null;
                        (node as ConnectorVM).ConnectorGallaryName = null;
                    }
                }
            }
        }

        private void OnThicknessChanged()
        {
            if (Thickness != null)
            {
                foreach (var node in SelectedItems.OfType<IGroupableVM>())
                {
                    node.Thickness = Thickness.Value;
                }
            }
        }

        private void OnDashDotChanged()
        {
            if (DashDot != null)
            {
                foreach (var node in SelectedItems.OfType<IGroupableVM>())
                {
                    node.DashDot = DashDot;
                }
            }
        }
        
        private void OnStyleChanged()
        {
            if (Style != null)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.Style = Style;
                }
                foreach (var node in SelectedItems.OfType<IConnectorVM>())
                {
                    node.Style = Style;
                }
            }
        }

        private void OnOpacityChanged()
        {
            if (Opacity != null)
            {
                foreach (var node in SelectedItems.OfType<IGroupableVM>())
                {
                    node.Opacity = Opacity.Value;
                }
            }
        }

        //private Style GetCustomStyle()
        //{
        //    Style customStyle = new Style(typeof(Path));
        //    if (Stroke != null)
        //    {
        //        customStyle.Setters.Add(new Setter(Path.StrokeProperty, Stroke));
        //    }
        //    if (Thickness.HasValue)
        //    {
        //        customStyle.Setters.Add(new Setter(Path.StrokeThicknessProperty, Thickness.Value));
        //    }
        //    if (Fill != null)
        //    {
        //        customStyle.Setters.Add(new Setter(Path.FillProperty, Fill));
        //    }
        //    if (DashDot != null)
        //    {
        //        customStyle.Setters.Add(new Setter(Path.StrokeDashArrayProperty, DashDot));
        //    }
        //    customStyle.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
        //    return customStyle;
        //}

        #endregion

        #region Connector
        #region Prop
        string _mDecorator = null;
        public string Decorator
        {
            get
            {
                return _mDecorator;
            }
            set
            {
                if (_mDecorator != value)
                {
                    _mDecorator = value;
                    OnPropertyChanged(ConnectorConstants.Decorator);
                }
            }
        }
        string _mSourceCap = null;
        public string SourceCap
        {
            get
            {
                return _mSourceCap;
            }
            set
            {
                if (_mSourceCap != value)
                {
                    _mSourceCap = value;
                    OnPropertyChanged(ConnectorConstants.SourceCap);
                }
            }
        }

        string _mTargetCap = null;
        public string TargetCap
        {
            get
            {
                return _mTargetCap;
            }
            set
            {
                if (_mTargetCap != value)
                {
                    _mTargetCap = value;
                    OnPropertyChanged(ConnectorConstants.TargetCap);
                }
            }
        }

        ConnectType? _mType = ConnectType.Straight;
        public ConnectType? Type
        {
            get
            {
                return _mType;
            }
            set
            {
                if (_mType != value)
                {
                    _mType = value;
                    OnPropertyChanged(ConnectorConstants.Type);
                }
            }
        } 
        #endregion

        private void OnSourceCapChanged()
        {
            if (SourceCap != null)
            {
                foreach (var con in SelectedItems.OfType<IConnectorVM>())
                {
                    con.SourceCap = SourceCap; 
                }
            }
        }
        private void OnDecoratorChanged()
        {
            if (Decorator != null)
            {
                
            }
        }
        
        private void OnTagetCapChanged()
        {
            if (TargetCap != null)
            {
                foreach (var con in SelectedItems.OfType<IConnectorVM>())
                {
                    con.TargetCap = TargetCap;
                }
            }
        }
        
        private void OnTypeChanged()
        {
            if (Type.HasValue)
            {
                foreach (var con in SelectedItems.OfType<IConnectorVM>())
                {
                    con.Type = Type.Value;
                }
            }
        }
        #endregion

        #region Label
        #region Prop
        string _mLabel = string.Empty;
        public string Label
        {
            get
            {
                return _mLabel;
            }
            set
            {
                if (_mLabel != value)
                {
                    _mLabel = value;
                    OnPropertyChanged(GroupableConstants.Label);
                }
            }
        }

        FontFamily _mFont = new FontFamily("Segoe UI");
        public FontFamily Font
        {
            get
            {
                return _mFont;
            }
            set
            {
                if (_mFont != value)
                {
                    _mFont = value;
                    OnPropertyChanged(GroupableConstants.Font);
                }
            }
        }

        int? _mFontSize = 8;
        public int? FontSize
        {
            get
            {
                return _mFontSize;
            }
            set
            {
                if (_mFontSize != value)
                {
                    _mFontSize = value;
                    OnPropertyChanged(GroupableConstants.FontSize);
                }
            }
        }
        int? fontvalue = 0;
        public int? FontValue
        {
            get
            {
                return fontvalue;
            }
            set
            {

                fontvalue = value;
                OnPropertyChanged(SelectorConstants.FontValue);
            }
        }

        FontWeight? _mFontWeight;
        public FontWeight? FontWeight
        {
            get
            {
                return _mFontWeight;
            }
            set
            {
                //if (_mFontWeight != value)
                {
                    _mFontWeight = value;
                    OnPropertyChanged(GroupableConstants.FontWeight);
                }
            }
        }

        private FontStyle? _mFontStyle = null;
        public FontStyle? FontStyle
        {
            get
            {
                return _mFontStyle;
            }
            set
            {
                if (_mFontStyle != value)
                {
                    _mFontStyle = value;
                    OnPropertyChanged(GroupableConstants.FontStyle);
                }
            }
        }

        bool? _mBold = false;
        public bool? Bold
        {
            get
            {
                return _mBold;
            }
            set
            {
                if (_mBold != value)
                {
                    _mBold = value;
                    OnPropertyChanged(GroupableConstants.Bold);
                }
            }
        }
        bool? _mRotateText = false;
        public bool? RotateText
        {
            get
            {
                return _mRotateText;
            }
            set
            {
                if (_mRotateText != value)
                {
                    _mRotateText = value;
                    OnPropertyChanged(GroupableConstants.RotateText);
                }
            }
        }
        bool? _munderline = false;
          public bool? UnderLine
        {
            get
            {
                return _munderline;
            }
            set
            {
                if (_munderline != value)
                {
                    _munderline = value;
                    OnPropertyChanged(GroupableConstants.UnderLine);
                }
            }
        }

          bool? _mStrike = false;
          public bool? Strike
          {
              get
              {
                  return _mStrike;
              }
              set
              {
                  if (_mStrike != value)
                  {
                      _mStrike = value;
                      OnPropertyChanged(GroupableConstants.Strike);
                  }
              }
          }

        bool? _mItalic = false;
        public bool? Italic
        {
            get
            {
                return _mItalic;
            }
            set
            {
                if (_mItalic != value)
                {
                    _mItalic = value;
                    OnPropertyChanged(GroupableConstants.Italic);
                }
            }
        }

        private TextAlignment? _mTextAlignment = null;
        public TextAlignment? TextAlignment
        {
            get
            {
                return _mTextAlignment;
            }
            set
            {
                if (_mTextAlignment != value)
                {
                    _mTextAlignment = value;
                    OnPropertyChanged(GroupableConstants.TextAlignment);
                }
            }
        }

        public bool TextLeft
        {
            get { return _textLeft; }
            set
            {
                if(_textLeft != value)
                {
                    _textLeft = value;
                    OnPropertyChanged(GroupableConstants.TextLeft);
                }
            }
        }

        public bool TextCenter
        {
            get { return _textCenter; }
            set
            {
                if (_textCenter != value)
                {
                    _textCenter = value;
                    OnPropertyChanged(GroupableConstants.TextCenter);
                }
            }
        }

        public bool TextRight
        {
            get { return _textRight; }
            set
            {
                if (_textRight != value)
                {
                    _textRight = value;
                    OnPropertyChanged(GroupableConstants.TextRight);
                }
            }
        }

        bool _mTopLeft = false;
        public bool TopLeft
        {
            get
            {
                return _mTopLeft;
            }
            set
            {
                if (_mTopLeft != value)
                {
                    _mTopLeft = value;
                    OnPropertyChanged(GroupableConstants.TopLeft);
                }
            }
        }

        bool _mMiddle = false;
        public bool Middle
        {
            get
            {
                return _mMiddle;
            }
            set
            {
                if (_mMiddle != value)
                {
                    _mMiddle = value;
                    OnPropertyChanged(GroupableConstants.Middle);
                }
            }
        }

        bool _mtop = false;
        public bool Top
        {
            get
            {
                return _mtop;
            }
            set
            {
                if (_mtop != value)
                {
                    _mtop = value;
                    OnPropertyChanged(GroupableConstants.Top);
                }
            }
        }

        bool _mTopRight = false;
        public bool TopRight
        {
            get
            {
                return _mTopRight;
            }
            set
            {
                if (_mTopRight != value)
                {
                    _mTopRight = value;
                    OnPropertyChanged(GroupableConstants.TopRight);
                }
            }
        }

        bool _mLeft = false;
        public bool Left
        {
            get
            {
                return _mLeft;
            }
            set
            {
                if (_mLeft != value)
                {
                    _mLeft = value;
                    OnPropertyChanged(GroupableConstants.Left);
                }
            }
        }

        bool _mCenter = false;
        public bool Center
        {
            get
            {
                return _mCenter;
            }
            set
            {
                if (_mCenter != value)
                {
                    _mCenter = value;
                    OnPropertyChanged(GroupableConstants.Center);
                }
            }
        }

        bool _mRight = false;
        public bool Right
        {
            get
            {
                return _mRight;
            }
            set
            {
                if (_mRight != value)
                {
                    _mRight = value;
                    OnPropertyChanged(GroupableConstants.Right);
                }
            }
        }

        bool _mBottomLeft = false;
        public bool BottomLeft
        {
            get
            {
                return _mBottomLeft;
            }
            set
            {
                if (_mBottomLeft != value)
                {
                    _mBottomLeft = value;
                    OnPropertyChanged(GroupableConstants.BottomLeft);
                }
            }
        }

        bool _mBottom = false;
        public bool Bottom
        {
            get
            {
                return _mBottom;
            }
            set
            {
                if (_mBottom != value)
                {
                    _mBottom = value;
                    OnPropertyChanged(GroupableConstants.Bottom);
                }
            }
        }

        bool _mBottomRight = false;
        public bool BottomRight
        {
            get
            {
                return _mBottomRight;
            }
            set
            {
                if (_mBottomRight != value)
                {
                    _mBottomRight = value;
                    OnPropertyChanged(GroupableConstants.BottomRight);
                }
            }
        }

        private HorizontalAlignment? _mLabelHAlign = null;
        public HorizontalAlignment? LabelHAlign
        {
            get
            {
                return _mLabelHAlign;
            }
            set
            {
                if (_mLabelHAlign != value)
                {
                    _mLabelHAlign = value;
                    OnPropertyChanged(GroupableConstants.LabelHAlign);
                }
            }
        }

        private VerticalAlignment? _mLabelVAlign = null;
        public VerticalAlignment? LabelVAlign
        {
            get
            {
                return _mLabelVAlign;
            }
            set
            {
                if (_mLabelVAlign != value)
                {
                    _mLabelVAlign = value;
                    OnPropertyChanged(GroupableConstants.LabelVAlign);
                }
            }
        }

        double? _mLabelMargin = null;
        public double? LabelMargin
        {
            get
            {
                return _mLabelMargin;
            }
            set
            {
                if (_mLabelMargin != value)
                {
                    _mLabelMargin = value;
                    OnPropertyChanged(GroupableConstants.LabelMargin);
                }
            }
        }

        #endregion
        private void OnLabelChanged()
        {
            if (Label != null)
            {
                foreach (var item in SelectedItems)
                {
                    item.Label = Label;
                }
            }
        }

        private void OnFontChanged()
        {
            if (Font != null)
            {
                foreach (var item in SelectedItems)
                {
                    item.Font = Font;
                }
            }
        }

        private void OnFontSizeChanged()
        {
            if (FontSize.HasValue)
            {
                for (int i = 0; i < SelectedItems.Count; i++)
                {
                    if (FontValue.Value != 0 && i > 0)
                    {
                        break;
                    }
                    SelectedItems[i].FontSize = (int)FontSize.Value;
                }
            }
        }
        private void OnFontValueChanged()
        {
            if (FontValue.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    item.FontSize += (int)FontValue.Value;
                }
                if (SelectedItems.Count > 0)
                    FontSize = SelectedItems[0].FontSize;
            }
        }
        private void OnFontWeightChanged()
        {
            if (FontWeight.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    item.FontWeight = FontWeight.Value;
                }
            }
        }

        private void OnFontStyleChanged()
        {
            if (FontStyle.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    item.FontStyle = FontStyle.Value;
                }
            }
        }

        private void OnBoldChanged()
        {
            if (Bold.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    item.Bold = Bold.Value;
                }
            }
        }

        private void OnUnderLineChanged()
        {
            if (UnderLine.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    item.UnderLine = UnderLine.Value;
                }
            }
        }

        private void OnStrikeChanged()
        {
            if (Strike.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    item.Strike = Strike.Value;
                }
            }
        }

        private void OnItalicChanged()
        {
            if (Italic.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    item.Italic = Italic.Value;
                }
            }
        }

        private bool _mHoldLabelAlignment = false;

        private void OnTextAlignToggled(string name)
        {
            if (_mHoldLabelAlignment)
            {
                return;
            }
            _mHoldLabelAlignment = true;
            switch (name)
            {
                case GroupableConstants.TextLeft:
                    TextAlignment = System.Windows.TextAlignment.Left;
                    break;
                case GroupableConstants.TextCenter:
                    TextAlignment = System.Windows.TextAlignment.Center;
                    break;
                case GroupableConstants.TextRight:
                    TextAlignment = System.Windows.TextAlignment.Right;
                    break;
            }
            _mHoldLabelAlignment = false;
        }

        private void OnTextAlignmentChanged()
        {
            if (_mHoldLabelAlignment)
            {
                return;
            }
            _mHoldLabelAlignment = true;
            if (TextAlignment.HasValue)
            {
                switch (TextAlignment)
                {
                    case System.Windows.TextAlignment.Left:
                        TextLeft = true;
                        TextCenter = false;
                        TextRight = false;
                        break;
                    case System.Windows.TextAlignment.Center:
                        TextLeft = false;
                        TextCenter = true;
                        TextRight = false;
                        break;
                    case System.Windows.TextAlignment.Right:
                        TextLeft = false;
                        TextCenter = false;
                        TextRight = true;
                        break;
                }
            }
            _mHoldLabelAlignment = false;
        }

        private void AlignToggled(string corner)
        {
            if (_mHoldLabelAlignment)
            {
                return;
            }
            _mHoldLabelAlignment = true;
            switch (corner)
            {
                case GroupableConstants.TopLeft:
                    LabelHAlign = HorizontalAlignment.Left;
                    LabelVAlign = VerticalAlignment.Top;
                    break;
                case GroupableConstants.Middle:
                    LabelVAlign = VerticalAlignment.Center;
                    break;
                case GroupableConstants.Top:
                    LabelVAlign = VerticalAlignment.Top;
                    break;
                case GroupableConstants.TopRight:
                    LabelHAlign = HorizontalAlignment.Right;
                    LabelVAlign = VerticalAlignment.Top;
                    break;
                case GroupableConstants.Left:
                    LabelHAlign = HorizontalAlignment.Left;
                    break;
                case GroupableConstants.Center:
                    LabelHAlign = HorizontalAlignment.Center;
                    break;
                case GroupableConstants.Right:
                    LabelHAlign = HorizontalAlignment.Right;
                    break;
                case GroupableConstants.BottomLeft:
                    LabelHAlign = HorizontalAlignment.Left;
                    LabelVAlign = VerticalAlignment.Bottom;
                    break;
                case GroupableConstants.Bottom:
                    LabelVAlign = VerticalAlignment.Bottom;
                    break;
                case GroupableConstants.BottomRight:
                    LabelHAlign = HorizontalAlignment.Right;
                    LabelVAlign = VerticalAlignment.Bottom;
                    break;
            }
            _mHoldLabelAlignment = false;
            OnLabelHAlignChanged();
        }

        private void OnLabelHAlignChanged()
        {
            if (_mHoldLabelAlignment)
            {
                return;
            }
            _mHoldLabelAlignment = true;

            if (LabelHAlign.HasValue)
            {
                switch (LabelHAlign.Value)
                {
                    case HorizontalAlignment.Left:
                        //TopLeft = true;
                        //Top = false;
                        //TopRight = false;
                        Left = true;
                        Center = false;
                        Right = false;
                        //BottomLeft = true;
                        //Bottom = false;
                        //BottomRight = false;
                        break;
                    case HorizontalAlignment.Center:
                        //TopLeft = false;
                        //Top = true;
                        //TopRight = false;
                        Left = false;
                        Center = true;
                        Right = false;
                        //BottomLeft = false;
                        //Bottom = true;
                        //BottomRight = false;
                        break;
                    case HorizontalAlignment.Right:
                        //TopLeft = false;
                        //Top = false;
                        //TopRight = true;
                        Left = false;
                        Center = false;
                        Right = true;
                        //BottomLeft = false;
                        //Bottom = false;
                        //BottomRight = true;
                        break;
                }
                OnLabelVAlignChanged();
            }
            else
            {
                TopLeft = false;
                Top = false;
                TopRight = false;
                Middle = false;
                Left = false;
                Center = false;
                Right = false;
                BottomLeft = false;
                Bottom = false;
                BottomRight = false;
            }

            if (LabelHAlign.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    item.LabelHAlign = LabelHAlign.Value;
                }
            }
           
        }

        private void OnLabelVAlignChanged()
        {
            _mHoldLabelAlignment = false;
            if (_mHoldLabelAlignment)
            {
                return;
            }
            _mHoldLabelAlignment = true;
            if (LabelVAlign.HasValue)
            {
                switch (LabelVAlign)
                {
                    case VerticalAlignment.Top:
                        TopLeft = TopLeft;
                        Top = Top;
                        TopRight = TopRight;
                        Middle = false;
                        Top = true;
                        //Left = false;
                        //Center = false;
                        //Right = false;
                        BottomLeft = false;
                        Bottom = false;
                        BottomRight = false;
                        break;
                    case VerticalAlignment.Center:
                        TopLeft = false;
                        Top = false;
                        TopRight = false;
                        Middle = true;
                        //Left = Left;
                        //Center = Center;
                        //Right = Right;
                        BottomLeft = false;
                        Bottom = false;
                        BottomRight = false;
                        break;
                    case VerticalAlignment.Bottom:
                        TopLeft = false;
                        Top = false;
                        TopRight = false;
                        Middle = false;
                        Bottom = true;
                        //Left = false;
                        //Center = false;
                        //Right = false;
                        BottomLeft = BottomLeft;
                        Bottom = Bottom;
                        BottomRight = BottomRight;
                        break;
                }
            }
                if (LabelVAlign.HasValue)
                {
                    foreach (var item in SelectedItems)
                    {
                        item.LabelVAlign = LabelVAlign.Value;
                    }
                }
                _mHoldLabelAlignment = false;                        
        }

        private void OnLabelForegroundChanged()
        {
            if (LabelForeground != null)
            {
                foreach (var item in SelectedItems)
                {
                    item.LabelForeground = LabelForeground;
                }
            }
        }

        private void OnLabelBackgroundChanged()
        {
            if (LabelBackground != null)
            {
                foreach (var item in SelectedItems)
                {
                    item.LabelBackground = LabelBackground;
                }
            }
        }

        private void OnLabelMarginChanged()
        {
            if (LabelMargin.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    item.LabelMargin = new Thickness(LabelMargin.Value);
                }
            }
        }

        private void OnHyperLinkChanged()
        {
            if (HyperLink != null)
            {
                foreach (var item in SelectedItems)
                {
                    item.HyperLink = HyperLink;
                }
            }
        }
        #endregion

        string _mName = string.Empty;
        public string Name
        {
            get
            {
                return _mName;
            }
            set
            {
                if (_mName != value)
                {
                    _mName = value;
                    OnPropertyChanged(GroupableConstants.Name);
                }
            }
        }

        private void OnNameChanged()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.Name = Name;
                }
            }
        }

        #region State

        #region Prop

        private bool? _mVisibile = null;
        public bool? Visibile
        {
            get
            {
                return _mVisibile;
            }
            set
            {
                if (_mVisibile != value)
                {
                    _mVisibile = value;
                    OnPropertyChanged(GroupableConstants.Visibility);
                }
            }
        }

        bool? _mAllowDrag = true;
        public bool? AllowDrag
        {
            get
            {
                return _mAllowDrag;
            }
            set
            {
                if (_mAllowDrag != value)
                {
                    _mAllowDrag = value;
                    OnPropertyChanged(NodeConstants.AllowDrag);
                }
            }
        }

        bool? _mAllowResize = true;
        public bool? AllowResize
        {
            get
            {
                return _mAllowResize;
            }
            set
            {
                if (_mAllowResize != value)
                {
                    _mAllowResize = value;
                    OnPropertyChanged(NodeConstants.AllowResize);
                }
            }
        }

        bool? _mAspectRatio = true;
        public bool? AspectRatio
        {
            get
            {
                return _mAspectRatio;
            }
            set
            {
                if (_mAspectRatio != value)
                {
                    _mAspectRatio = value;
                    OnPropertyChanged(NodeConstants.AspectRatio);
                }
            }
        }

        bool? _mAllowRotate = true;
        private bool _textLeft;
        private bool _textCenter;
        private bool _textRight;
        private ICommand _pickerCommand;
        private Brush _pickedBrush;
        private CurrentBrush _currentBrush;
        private Visibility _isBrushEditing = Visibility.Collapsed;

        public bool? AllowRotate
        {
            get
            {
                return _mAllowRotate;
            }
            set
            {
                if (_mAllowRotate != value)
                {
                    _mAllowRotate = value;
                    OnPropertyChanged(NodeConstants.AllowRotate);
                }
            }
        }
        #endregion

        private void OnVisibilityChanged()
        {
            if (Visibile.HasValue)
            {
                foreach (var item in SelectedItems)
                {
                    if (Visibile.Value)
                    {
                        item.Visibility= Visibility.Visible;
                    }
                    else
                    {
                        item.Visibility = Visibility.Collapsed;                        
                    }
                }
            }
        }

        private void OnToolTipConstraintsChanged()
        {
            if (ToolTip!=null)
            {
                ToolTip.Constraints = (ToolTipConstraints) Enum.Parse(typeof (ToolTipConstraints), ToolTipConstraint);
            }
        }

        private void OnAllowDragChanged()
        {
            if (AllowDrag.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.AllowDrag = AllowDrag.Value;
                }
            }
        }

        private void OnAllowResizeChanged()
        {
            if (AllowResize.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.AllowResize = AllowResize.Value;
                }
            }
        }

        private void OnAllowRotateChanged()
        {
            if (AllowRotate.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.AllowRotate = AllowRotate.Value;
                }
            }
        }

        private void OnAspectRatioChanged()
        {
            if (AspectRatio.HasValue)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.AspectRatio = AspectRatio.Value;
                }
            }
        }

        #endregion
        
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch (name)
            {
                case SelectorConstants.ToolTipConstraint:
                    OnToolTipConstraintsChanged();
                    break;
                case NodeConstants.AllowDrag:
                    OnAllowDragChanged();
                    break;
                case NodeConstants.AllowResize:
                    OnAllowResizeChanged();
                    break;
                case NodeConstants.AllowRotate:
                    OnAllowRotateChanged();
                    break;
                case NodeConstants.AspectRatio:
                    OnAspectRatioChanged();
                    break;
                case SelectorConstants.Angle:
                    OnAngleChanged();
                    break;
                case GroupableConstants.Bold:
                    OnBoldChanged();
                    break;
                case GroupableConstants.UnderLine:
                    OnUnderLineChanged();
                    break;
                case GroupableConstants.Strike:
                    OnStrikeChanged();
                    break;
                case ConnectorConstants.Caps:
                    OnDecoratorChanged();
                    break;
                case GroupableConstants.DashDot:
                    OnDashDotChanged();
                    break;
                case NodeConstants.Fill:
                    OnFillChanged();
                    break;
                case GroupableConstants.Font:
                    OnFontChanged();
                    break;
                case GroupableConstants.FontSize:
                    OnFontSizeChanged();
                    break;
                case SelectorConstants.FontValue:
                    OnFontValueChanged();
                    break;
                case GroupableConstants.FontStyle:
                    OnFontStyleChanged();
                    break;
                case GroupableConstants.FontWeight:
                    OnFontWeightChanged();
                    break;
                case SelectorConstants.Height:
                    OnHeightChanged();
                    break;
                case GroupableConstants.Italic:
                    OnItalicChanged();
                    break;
                case GroupableConstants.Label:
                    OnLabelChanged();
                    break;
                case GroupableConstants.TextAlignment:
                    OnTextAlignmentChanged();
                    break;
                case GroupableConstants.LabelHAlign:
                    OnLabelHAlignChanged();
                    break;
                case GroupableConstants.LabelMargin:
                    OnLabelMarginChanged();
                    break;
                case GroupableConstants.LabelVAlign:
                    OnLabelVAlignChanged();
                    break;
                case GroupableConstants.Name:
                    OnNameChanged();
                    break;
                case ConnectorConstants.SourceCap:
                    OnSourceCapChanged();
                    break;
                case ConnectorConstants.Decorator:
                    OnDecoratorChanged();
                    break;
                case GroupableConstants.Stroke:
                    OnStrokeChanged();
                    break;
                case GroupableConstants.Style:
                    OnStyleChanged();
                    break;
                case GroupableConstants.Opacity:
                    OnOpacityChanged();
                    break;
                case ConnectorConstants.TargetCap:
                    OnTagetCapChanged();
                    break;
                case GroupableConstants.Thickness:
                    OnThicknessChanged();
                    break;
                case ConnectorConstants.Type:
                    OnTypeChanged();
                    break;
                case GroupableConstants.Visibility:
                    OnVisibilityChanged();
                    break;
                case SelectorConstants.Width:
                    OnWidthChanged();
                    break;
                case SelectorConstants.X:
                    OnXChanged();
                    break;
                case SelectorConstants.Y:
                    OnYChanged();
                    break;
                case SelectorConstants.Px:
                    OnPXChanged();
                    break;
                case SelectorConstants.Py:
                    OnPYChanged();
                    break;
                case GroupableConstants.TextLeft:
                case GroupableConstants.TextCenter:
                case GroupableConstants.TextRight:
                    OnTextAlignToggled(name);
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
                    AlignToggled(name);
                    break;
                case SelectorConstants.CurrentBrush:
                    switch (CurrentBrush)
                    {
                        case CurrentBrush.Fill:
                            IsBrushEditing = Visibility.Visible;
                            PickedBrush = Fill;
                            break;
                        case CurrentBrush.Stroke:
                            IsBrushEditing = Visibility.Visible;
                            PickedBrush = Stroke;
                            break;
                        case CurrentBrush.LabelBackground:
                            IsBrushEditing = Visibility.Visible;
                            PickedBrush = LabelBackground;
                            break;
                        case CurrentBrush.LabelForeground:
                            IsBrushEditing = Visibility.Visible;
                            PickedBrush = LabelForeground;
                            break;
                        case CurrentBrush.None:
                            IsBrushEditing = Visibility.Collapsed;
                            break;
                    }
                    break;
                case SelectorConstants.PickedBrush:
                    switch (CurrentBrush)
                    {
                        case CurrentBrush.Fill:
                            Fill = PickedBrush;
                            break;
                        case CurrentBrush.Stroke:
                            Stroke = PickedBrush;
                            break;
                        case CurrentBrush.LabelBackground:
                            LabelBackground = PickedBrush;
                            break;
                        case CurrentBrush.LabelForeground:
                            LabelForeground = PickedBrush;
                            break;
                        case CurrentBrush.None:
                            break;
                    }
                    break;
                case GroupableConstants.LabelBackground:
                    OnLabelBackgroundChanged();
                    break;
                case GroupableConstants.LabelForeground:
                    OnLabelForegroundChanged();
                    break;
                case SelectorConstants.Scale:
                    OnScaleChanged();
                    break;
                case GroupableConstants.HyperLink:
                    OnHyperLinkChanged();
                    break;
                case NodeConstants.NodeGallaryName:
                    OnNodeGallaryNameChanged();
                    break;
                case ConnectorConstants.ConnectorGallaryName:
                    OnConnectorGallaryNameChanged();
                    break;
                case GroupableConstants.QuickFill:
                    OnQuickFillChanged();
                    break;
                case GroupableConstants.RotateText:
                    OnRotateTextChanged();
                    break;
            }
        }

        private void OnRotateTextChanged()
        {
            if (RotateText ==  true)
            {               
                foreach (NodeVM nv in SelectedItems.OfType<NodeVM>())
                {
                    if (nv.IsSelected)
                    {
                        foreach (LabelVM av in nv.Annotations as List<IAnnotation>)
                        {
                            av.RotateAngle += 90;
                        }
                    }
                }
                foreach (ConnectorVM cv in SelectedItems.OfType<ConnectorVM>())
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
            RotateText = false;                     
        }

        private void OnConnectorGallaryNameChanged()
        {
            if (ConnectorGallaryName != null)
            {
                foreach (var node in SelectedItems.OfType<IConnectorVM>())
                {
                    node.ConnectorGallaryName = ConnectorGallaryName;

                }
            }
        }

        private void OnQuickFillChanged()
        {
            if (QuickFill != null)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.QuickFill = QuickFill;
                }
            }
        }
        private void OnNodeGallaryNameChanged()
        {
            if (NodeGallaryName != null)
            {
                foreach (var node in SelectedItems.OfType<INodeVM>())
                {
                    node.NodeGallaryName = NodeGallaryName;

                }
            }

        }
        private void OnScaleChanged()
        {
            IGraphInfo info = Diagram.Info as IGraphInfo;
            if(info != null)
            {
                info.Commands.Zoom.Execute(new ZoomPositionParamenter()
                    {
                        ZoomCommand = ZoomCommand.Zoom,
                         ZoomTo = Scale,
                    });
               
            }
        }
        
        public ICommand PickerCommand
        {
            get { return _pickerCommand; }
            set
            {
                if (_pickerCommand != value)
                {
                    _pickerCommand = value;
                    OnPropertyChanged(SelectorConstants.PickerCommand);
                }
            }
        }

        private ICommand _decorator;
        public ICommand DecoratorCommand
        {
            get { return _decorator; }
            set
            {
                if (_decorator != value)
                {
                    _decorator = value;
                    OnPropertyChanged(SelectorConstants.DecoratorCommand);
                }
            }
        }
        private ICommand _dashdotcommand;
        public ICommand DashDotCommand
        {
            get { return _dashdotcommand; }
            set
            {
                if (_dashdotcommand != value)
                {
                    _dashdotcommand = value;
                    OnPropertyChanged(SelectorConstants.DashDotCommand);
                }
            }
        }
        private ICommand _closeColorPickerPaletteCommand;
        public ICommand CloseColorPickerPaletteCommand
        {
            get { return _closeColorPickerPaletteCommand; }
            set
            {
                if (_closeColorPickerPaletteCommand != value)
                {
                    _closeColorPickerPaletteCommand = value;
                    OnPropertyChanged("CloseColorPickerPaletteCommand");
                }
            }
        }

        public ICommand GrowFont { get; set; } 
        public ICommand ShrinkFont { get; set; }
        public ICommand ThicknessCommand { get; set; }

        public Brush PickedBrush
        {
            get { return _pickedBrush; }
            set
            {
                if (_pickedBrush != value)
                {
                    _pickedBrush = value;
                    OnPropertyChanged(SelectorConstants.PickedBrush);
                }
            }
        }

        public CurrentBrush CurrentBrush
        {
            get { return _currentBrush; }
            set
            {
                if (_currentBrush != value)
                {
                    _currentBrush = value;
                    OnPropertyChanged(SelectorConstants.CurrentBrush);
                }
            }
        }

        public Visibility IsBrushEditing
        {
            get { return _isBrushEditing; }
            set
            {
                if (_isBrushEditing != value)
                {
                    _isBrushEditing = value;
                    OnPropertyChanged(SelectorConstants.IsBrushEditing);
                }
            }
        }
        
        private Brush _mLabelBackground;
        public Brush LabelBackground
        {
            get { return _mLabelBackground; }
            set
            {
                if (_mLabelBackground != value)
                {
                    _mLabelBackground = value;
                    OnPropertyChanged(GroupableConstants.LabelBackground);
                }
            }
        }

        private Brush _mLabelForeground = new SolidColorBrush(Colors.Aqua);
        public Brush LabelForeground
        {
            get { 
                return _mLabelForeground; }
            set
            {
                if (_mLabelForeground != value)
                {
                    _mLabelForeground = value;
                    OnPropertyChanged(GroupableConstants.LabelForeground);
                }
            }
        }

        private bool _mAnythingSelected = false;
        public bool IsAnythingSelected
        {
            get { return _mAnythingSelected; }
            set
            {
                if (_mAnythingSelected != value)
                {
                    _mAnythingSelected = value;
                    OnPropertyChanged(SelectorConstants.IsAnythingSelected);
                }
            }
        }

        private bool _mIsNodeSelected = false;
        public bool IsNodeSelected
        {
            get { return _mIsNodeSelected; }
            set
            {
                if (_mIsNodeSelected != value)
                {
                    _mIsNodeSelected = value;
                    OnPropertyChanged(SelectorConstants.IsNodeSelected);
                }
            }
        }

        private bool _mIsConnectorSelected = false;
        public bool IsConnectorSelected
        {
            get { return _mIsConnectorSelected; }
            set
            {
                if (_mIsConnectorSelected != value)
                {
                    _mIsConnectorSelected = value;
                    OnPropertyChanged(SelectorConstants.IsConnectorSelected);
                }
            }
        }

        private bool _mIsLabelSet = false;
        public bool IsLabelSet
        {
            get { return _mIsLabelSet; }
            set
            {
                if (_mIsLabelSet != value)
                {
                    _mIsLabelSet = value;
                    OnPropertyChanged(SelectorConstants.IsLabelSet);
                }
            }
        }

        private bool _mIsNodeLabelSet = false;
        public bool IsNodeLabelSet
        {
            get { return _mIsNodeLabelSet; }
            set
            {
                if (_mIsNodeLabelSet != value)
                {
                    _mIsNodeLabelSet = value;
                    OnPropertyChanged(SelectorConstants.IsNodeLabelSet);
                }
            }
        }

        private bool _mIsConnectorLabelSet = false;
        public bool IsConnectorLabelSet
        {
            get { return _mIsConnectorLabelSet; }
            set
            {
                if (_mIsConnectorLabelSet != value)
                {
                    _mIsConnectorSelected = value;
                    OnPropertyChanged(SelectorConstants.IsConnectorLabelSet);
                }
            }
        }

        private double _mScale = 1d;
        public double Scale
        {
            get { return _mScale; }
            set
            {
                if (_mScale != value)
                {
                    _mScale = value;
                    OnPropertyChanged(SelectorConstants.Scale);
                }
            }
        }

        string _mHyperLink = "http://";
        public string HyperLink
        {
            get
            {
                return _mHyperLink;
            }
            set
            {
                if (_mHyperLink != value)
                {
                    _mHyperLink = value;
                    OnPropertyChanged(GroupableConstants.HyperLink);
                }
            }
        }
    }

    public static class SelectorConstants
    {
        public const string X = "X";
        public const string Y = "Y";
        public const string Px = "Px";
        public const string Py = "Py";
        public const string Width = "Width";
        public const string Height = "Height";
        public const string Angle = "Angle";
        public const string PickerCommand = "PickerCommand";
        public const string DecoratorCommand = "DecoratorCommand";
        public const string DashDotCommand = "DashDotCommand";
        public const string PickedBrush = "PickedBrush";
        public const string CurrentBrush = "CurrentBrush";
        public const string IsBrushEditing = "IsBrushEditing";
        public const string IsAnythingSelected = "IsAnythingSelected";
        public const string IsNodeSelected = "IsNodeSelected";
        public const string IsConnectorSelected = "IsConnectorSelected";
        public const string Scale = "Scale";
        public const string IsLabelSet = "IsLabelSet";
        public const string IsNodeLabelSet = "IsNodeLabelSet";
        public const string IsConnectorLabelSet = "IsConnectorLabelSet";
        public const string ToolTipConstraint = "ToolTipConstraint";
        public const string QuickFill = "QuickFill";
        public const string NodeGallaryName = "NodeGallaryName";
        public const string ConnectorGallaryName = "ConnectorGallaryName";
        public const string FontValue = "FontValue";

    }

    public interface ISelectorVM : ISelector
    {
        double? X { get; set; }
        double? Y { get; set; }
        double? Px { get; set; }
        double? Py { get; set; }
        double? Angle { get; set; }
        double? Width { get; set; }
        double? Height { get; set; }

        Brush Fill { get; set; }
        Brush Stroke { get; set; }
        double? Thickness { get; set; }
        ICommand DashDotCommand { get; set; }
        Style Style { get; set; }
        double? Opacity { get; set; }
        double Scale { get; set; }

        string SourceCap { get; set; }
        string TargetCap { get; set; }
        string Decorator { get; set; }
        ICommand DecoratorCommand { get; set; }
        ConnectType? Type { get; set; }

        string Label { get; set; }
        FontFamily Font { get; set; }
        int? FontSize { get; set; }
        int? FontValue { get; set; }
        FontWeight? FontWeight { get; set; }
        FontStyle? FontStyle { get; set; }
        bool? Bold { get; set; }
        bool? Italic { get; set; }
        bool? UnderLine { get; set; }

        bool? RotateText { get; set; }
        Brush LabelForeground { get; set; }
        Brush LabelBackground { get; set; }

        TextAlignment? TextAlignment { get; set; }
        HorizontalAlignment? LabelHAlign { get; set; }
        VerticalAlignment? LabelVAlign { get; set; }

        bool TextLeft { get; set; }
        bool TextCenter { get; set; }
        bool TextRight { get; set; }

        bool TopLeft { get; set; }
        bool Middle { get; set; }
        bool Top { get; set; }
        bool TopRight { get; set; }

        bool Left { get; set; }
        bool Center { get; set; }
        bool Right { get; set; }

        bool BottomLeft { get; set; }
        bool Bottom { get; set; }
        bool BottomRight { get; set; }

        double? LabelMargin { get; set; }

        string Name { get; set; }
        bool? Visibile { get; set; }
        bool? AllowDrag { get; set; }
        bool? AllowResize { get; set; }
        bool? AllowRotate { get; set; }
        bool? AspectRatio { get; set; }

        ICommand PickerCommand { get; set; }
        Brush PickedBrush { get; set; }
        CurrentBrush CurrentBrush { get; set; }
        Visibility IsBrushEditing { get; set; }

        bool IsAnythingSelected { get; set; }
        bool IsNodeSelected { get; set; }
        bool IsConnectorSelected { get; set; }

        bool IsLabelSet { get; set; }
        bool IsNodeLabelSet { get; set; }
        bool IsConnectorLabelSet { get; set; }

        string NodeGallaryName { get; set; }
        string ConnectorGallaryName { get; set; }
        Brush QuickFill { get; set; }
        //List<DoubleCollection> DashDots { get; set; }
        //List<Geometry> Caps { get; set; }
        //List<ConnectorType> Types { get; set; }
        //List<FontFamily> Fonts { get; set; }
    }

    public enum ConnectType
    {
        Straight,
        Orthogonal,
        Bezier
    }

    public enum CurrentBrush
    {
        None,
        Stroke,
        Fill,
        LabelForeground,
        LabelBackground
    }

}
