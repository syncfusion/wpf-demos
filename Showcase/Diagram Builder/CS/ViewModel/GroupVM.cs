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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiagramBuilder.ViewModel
{
    public class GroupVM : NodeVM, IGroup
    {

        object _mNodes = null;
        public object Nodes
        {
            get
            {
                return _mNodes;
            }
            set
            {
                if (_mNodes != value)
                {
                    _mNodes = value;
                    OnPropertyChanged(GroupConstants.Nodes);
                }
            }
        }


        object _mConnectors = null;
        public object Connectors
        {
            get
            {
                return _mConnectors;
            }
            set
            {
                if (_mConnectors != value)
                {
                    _mConnectors = value;
                    OnPropertyChanged(GroupConstants.Connectors);
                }
            }
        }


        object _mGroups = null;
        public object Groups
        {
            get
            {
                return _mGroups;
            }
            set
            {
                if (_mGroups != value)
                {
                    _mGroups = value;
                    OnPropertyChanged(GroupConstants.Groups);
                }
            }
        }


        PortVisibility _mPortVisibility = PortVisibility.MouseOver;


        public Thickness Padding
        {
            get;
            set;
        }
        public PortVisibility PortVisibility
        {
            get
            {
                return _mPortVisibility;
            }
            set
            {
                if (_mPortVisibility != value)
                {
                    _mPortVisibility = value;
                    OnPropertyChanged(GroupConstants.PortVisibility);
                }
            }
        }
    }

    public static class GroupConstants
    {
        public const string OffsetX = "OffsetX";
        public const string OffsetY = "OffsetY";
        public const string RotateAngle = "RotateAngle";
        public const string MinWidth = "MinWidth";
        public const string MaxWidth = "MaxWidth";
        public const string MinHeight = "MinHeight";
        public const string MaxHeight = "MaxHeight";
        public const string Content = "Content";
        public const string ContentTemplate = "ContentTemplate";
        public const string Shape = "Shape";
        public const string ShapeStyle = "ShapeStyle";
        public const string Pivot = "Pivot";
        public const string ParentGroup = "ParentGroup";
        public const string Nodes = "Nodes";
        public const string Connectors = "Connectors";
        public const string Groups = "Groups";
        public const string Ports = "Ports";
        public const string ID = "ID";
        public const string Key = "Key";
        public const string IsSelected = "IsSelected";
        public const string ZIndex = "ZIndex";
        public const string Annotations = "Annotations";
        public const string Constraints = "Constraints";
        public const string AutoBind = "AutoBind";
        public const string InternalNodes = "InternalNodes";
        public const string InternalConnectors = "InternalConnectors";
        public const string InternalGroups = "InternalGroups";
        public const string PortVisibility = "PortVisibility";
    }
}
