#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GettingStarted_Events.Utility;

namespace GettingStarted_Events.ViewModel
{
    class EventDiagramVM : DiagramViewModel
    {
        #region Fields

        private bool _annotationchanged = false;
        private bool _autoscroll = false;
        private bool _connectorediting = false;
        private bool _connectorsourcechanged = false;
        private bool _connectortargetchanged = false;
        private bool _dragenter = true;
        private bool _dragleave = false;
        private bool _dragover = false;
        private bool _drop = true;
        private bool _itemadded = true;
        private bool _itemdeleted = true;
        private bool _itemdoubletapped = false;
        private bool _itemselected = false;
        private bool _itemtapped = true;
        private bool _itemunselected = false;
        private bool _menuitemclicked = false;
        private bool _menuopening = true;
        private bool _nodechanged = false;
        private bool _annotationediting = false;
        private bool _annotationedited = false;
        private bool _annotationrotating = false;
        private bool _annotationrotated = true;
        private bool _annotationdragging = false;
        private bool _annotationdragged = true;
        private bool _annotationresizing = false;
        private bool _annotationresized = true;
        private bool _coneditstarting = false;
        private bool _coneditstarted = true;
        private bool _coneditdragging = false;
        private bool _coneditcompleted = true;
        private bool _consourcestarting = false;
        private bool _consourcestarted = true;
        private bool _consourcedragging = false;
        private bool _consourcecompleted = true;
        private bool _contargetstarting = false;
        private bool _contargetstarted = true;
        private bool _contargetdragging = false;
        private bool _contargetcompleted = true;
        private bool _nodestarted = true;
        private bool _noderotating = false;
        private bool _noderotated = true;
        private bool _nodedragging = false;
        private bool _nodedragged = true;
        private bool _noderesizing = false;
        private bool _noderesized = true;
        private string _events;
        private ICommand _clear;

        #endregion

        #region Constructor
        public EventDiagramVM()
        {
            #region Diagram Properties Initialization

            HorizontalRuler = new Ruler();

            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };

            SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.All,
                SnapToObject = SnapToObject.All,
            };

            PageSettings = new PageSettings()
            {
                PageBackground = new SolidColorBrush(Colors.White),
            };

            Constraints.Add(GraphConstraints.Drop);

            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.QuickCommands,
            };

            #endregion

            #region Commands

            Clear = new Command(OnClearCommand);

            AnnotationChangedCommand = new Command(OnAnnotationChanged);
            AutoScrolledCommand = new Command(OnAutoScrollChanged);
            ConnectorEditingCommand = new Command(OnConnectorEditing);
            ConnectorSourceChangedCommand = new Command(OnConnectorSourceChanged);
            ConnectorTargetChangedCommand = new Command(OnConnectorTargetChanged);
            DragEnterCommand = new Command(OnDragEnter);
            DragLeaveCommand = new Command(OnDragLeave);
            DragOverCommand = new Command(OnDragOver);
            DropCommand = new Command(OnDrop);
            ItemAddedCommand = new Command(OnItemAdded);
            ItemDeletedCommand = new Command(OnItemDeleted);
            ItemDoubleTappedCommand = new Command(OnItemDoupleTapped);
            ItemSelectedCommand = new Command(OnItemSelected);
            ItemTappedCommand = new Command(OnItemTapped);
            ItemUnSelectedCommand = new Command(OnItemUnSelected);
            MenuItemClickedCommand = new Command(OnMenuItemClicked);
            MenuOpeningCommand = new Command(OnMenuOpening);
            NodeChangedCommand = new Command(OnNodeChanged);

            #endregion
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Method to change the value for Clear
        /// </summary>
        /// <param name="obj"></param>
        private void OnClearCommand(object obj)
        {
            (obj as TextBox).Text = null;
            _events = null;
        }

        /// <summary>
        /// Method to change the value for NodeChanged
        /// </summary>
        /// <param name="obj"></param>
        private void OnNodeChanged(object obj)
        {
            var args = (obj as ChangeEventArgs<object, NodeChangedEventArgs>).NewValue;            
            if (args.InteractionState == NodeChangedInteractionState.Started)
            {
                if (NodeStarted)
                {
                    Events = "NodeChanged Event" + "\n" + "\t" + "Action = " + args.InteractionState.ToString();
                }
            }
            else if (args.InteractionState == NodeChangedInteractionState.Rotating)
            {
                if (NodeRotating)
                {
                    Events = "NodeChanged Event" + "\n" + "\t" + "Action = " + args.InteractionState.ToString();
                }
            }
            else if (args.InteractionState == NodeChangedInteractionState.Rotated)
            {
                if (NodeRotated)
                {
                    Events = "NodeChanged Event" + "\n" + "\t" + "Action = " + args.InteractionState.ToString();
                }
            }
            else if (args.InteractionState == NodeChangedInteractionState.Dragging)
            {
                if (NodeDragging)
                {
                    Events = "NodeChanged Event" + "\n" + "\t" + "Action = " + args.InteractionState.ToString();
                }
            }
            else if (args.InteractionState == NodeChangedInteractionState.Dragged)
            {
                if (NodeDragged)
                {
                    Events = "NodeChanged Event" + "\n" + "\t" + "Action = " + args.InteractionState.ToString();
                }
            }
            else if (args.InteractionState == NodeChangedInteractionState.Resizing)
            {
                if (NodeResizing)
                {
                    Events = "NodeChanged Event" + "\n" + "\t" + "Action = " + args.InteractionState.ToString();
                }
            }
            else if (args.InteractionState == NodeChangedInteractionState.Resized)
            {
                if (NodeResized)
                {
                    Events = "NodeChanged Event" + "\n" + "\t" + "Action = " + args.InteractionState.ToString();
                }
            }
        }

        /// <summary>
        /// Method to change the value for MenuOpening
        /// </summary>
        /// <param name="obj"></param>
        private void OnMenuOpening(object obj)
        {
            if (MenuOpening)
            {
                Events = "MenuOpening Event";
            }
        }

        /// <summary>
        /// Method to change the value for MenuItemClicked
        /// </summary>
        /// <param name="obj"></param>
        private void OnMenuItemClicked(object obj)
        {
            var args = obj as MenuItemClickedEventArgs;
            if (MenuItemClicked)
            {
                Events = "MenuItemClicked Event" + "\n" + "\t" + "\t" + "Clicked Item = " + args.Item.Content.ToString();
            }
        }

        /// <summary>
        /// Method to change the value for ItemUnselected
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemUnSelected(object obj)
        {
            var args = obj as DiagramEventArgs;
            if (ItemUnSelected)
            {
                Events = "ItemUnSelected Event";
            }
        }

        /// <summary>
        /// Method to change the value for ItemTapped
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemTapped(object obj)
        {
            var args = obj as ItemTappedEventArgs;
            if (ItemTapped)
            {
                if (args.Item is SfDiagram)
                {
                    Events = "ItemTapped Event" + "\n" + "\t" + "Tapped Item = Diagram";
                }
                else if (args.Item is INode)
                {
                    Events = "ItemTapped Event" + "\n" + "\t" + "Tapped Item = Node";
                }
                else if (args.Item is IConnector)
                {
                    Events = "ItemTapped Event" + "\n" + "\t" + "Tapped Item = Connector";
                }
            }
        }

        /// <summary>
        /// Method to change the value for ItemSelected
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemSelected(object obj)
        {
            var args = obj as ItemSelectedEventArgs;
            if (ItemSelected)
            {
                Events = "ItemSelected Event";
            }
        }

        /// <summary>
        /// Method to change the value for ItemDoubleTapped
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemDoupleTapped(object obj)
        {
            var args = obj as ItemDoubleTappedEventArgs;
            if (ItemDoubleTapped)
            {
                if (args.Item is SfDiagram)
                {
                    Events = "ItemDoubleTapped Event" + "\n" + "\t" + "Double Tapped Item = Diagram";
                }
                else if (args.Item is INode)
                {
                    Events = "ItemDoubleTapped Event" + "\n" + "\t" + "Double Tapped Item = Node";
                }
                else if (args.Item is IConnector)
                {
                    Events = "ItemDoubleTapped Event" + "\n" + "\t" + "Double Tapped Item = Connector";
                }
            }
        }

        /// <summary>
        /// Method to change the value for ItemDeleted
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemDeleted(object obj)
        {
            var args = obj as ItemDeletedEventArgs;
            if (ItemDeleted)
            {
                if (args.Item is INode)
                {
                    Events = "ItemDeleted Event" + "\n" + "\t" + "Deleted Item = Node";
                }
                else if (args.Item is IConnector)
                {
                    Events = "ItemDeleted Event" + "\n" + "\t" + "Deleted Item = Connector";
                }
            }
        }

        /// <summary>
        /// Method to change the value for ItemAdded
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;
            if (ItemAdded)
            {
                if (args.Item is INode)
                {
                    Events = "ItemAdded Event" + "\n" + "\t" + "Added Item = Node";
                }
                else if (args.Item is IConnector)
                {
                    Events = "ItemAdded Event" + "\n" + "\t" + "Added Item = Connector";
                }
            }
        }

        /// <summary>
        /// Method to change the value for Drop
        /// </summary>
        /// <param name="obj"></param>
        private void OnDrop(object obj)
        {
            var args = obj as ItemDropEventArgs;
            if (Drop)
            {
                Events = "Drop Event";
            }
        }

        /// <summary>
        /// Method to change the value for DragLeave
        /// </summary>
        /// <param name="obj"></param>
        private void OnDragLeave(object obj)
        {
            if (DragLeave)
            {
                Events = "DragLeave Event";
            }
        }

        /// <summary>
        /// Method to change the value for DragOver
        /// </summary>
        /// <param name="obj"></param>
        private void OnDragOver(object obj)
        {
            var args = obj as ItemDropEventArgs;
            if (DragOver)
            { 
                Events = "DragOver Event";
            }  
        }

        /// <summary>
        /// Method to change the value for DragEnter
        /// </summary>
        /// <param name="obj"></param>
        private void OnDragEnter(object obj)
        {
            var args = obj as ItemDropEventArgs;
            if (Dragenter)
            {
                Events = "DragEnter Event";
            }
        }

        /// <summary>
        /// Method to change the value for ConnectorTargetChanged
        /// </summary>
        /// <param name="obj"></param>
        private void OnConnectorTargetChanged(object obj)
        {
            var args = (obj as ChangeEventArgs<object, ConnectorChangedEventArgs>).NewValue;
            if (args.DragState == DragState.Starting)
            {
                if (ConnectorTargetStarting)
                {
                    Events = "ConnectorTargetChanged Event" + "\n" + "\t" + "Action =" + args.DragState.ToString();
                }
            }
            else if (args.DragState == DragState.Started)
            {
                if (ConnectorTargetStarted)
                {
                    Events = "ConnectorTargetChanged Event" + "\n" + "\t" + "Action =" + args.DragState.ToString();
                }
            }
            else if (args.DragState == DragState.Dragging)
            {
                if (ConnectorTargetDragging)
                {
                    Events = "ConnectorTargetChanged Event" + "\n" + "\t" + "Action =" + args.DragState.ToString();
                }
            }
            else if (args.DragState == DragState.Completed)
            {
                if (ConnectorTargetCompleted)
                {
                    Events = "ConnectorTargetChanged Event" + "\n" + "\t" + "Action =" + args.DragState.ToString();
                }
            }
        }

        /// <summary>
        /// Method to change the value for ConnectorSourceChanged
        /// </summary>
        /// <param name="obj"></param>
        private void OnConnectorSourceChanged(object obj)
        {
            var args = (obj as ChangeEventArgs<object, ConnectorChangedEventArgs>).NewValue;
            if (args.DragState == DragState.Starting)
            {
                if (ConnectorSourceStarting)
                {
                    Events = "ConnectorSourceChanged Event" + "\n" + "\t" + "Action =" + args.DragState.ToString();
                }
            }
            else if (args.DragState == DragState.Started)
            {
                if (ConnectorSourceStarted)
                {
                    Events = "ConnectorSourceChanged Event" + "\n" + "\t" + "Action =" + args.DragState.ToString();
                }
            }
            else if (args.DragState == DragState.Dragging)
            {
                if (ConnectorSourceDragging)
                {
                    Events = "ConnectorSourceChanged Event" + "\n" + "\t" + "Action =" + args.DragState.ToString();
                }
            }
            else if (args.DragState == DragState.Completed)
            {
                if (ConnectorSourceCompleted)
                {
                    Events = "ConnectorSourceChanged Event" + "\n" + "\t" + "Action =" + args.DragState.ToString();
                }
            }
        }

        /// <summary>
        /// Method to change the value for ConnectorEditing
        /// </summary>
        /// <param name="obj"></param>
        private void OnConnectorEditing(object obj)
        {
            var args = obj as ConnectorEditingEventArgs;
            if (args.DragState == DragState.Completed)
            {
                if (ConnectorEditCompleted)
                {
                    Events = "ConnectorEditing Event" + "\n" + "\t" + "ControlPointType = " + args.ControlPointType.ToString() + "\n" + "\t"
                        + "Action =" + args.DragState.ToString();
                }
            }
            else if (args.DragState == DragState.Dragging)
            {
                if (ConnectorEditDragging)
                {
                    Events = "ConnectorEditing Event" + "\n" + "\t" + "ControlPointType = " + args.ControlPointType.ToString() + "\n" + "\t"
                        + "Action =" + args.DragState.ToString();
                }
            }
            else if (args.DragState == DragState.Started)
            {
                if (ConnectorEditStarted)
                {
                    Events = "ConnectorEditing Event" + "\n" + "\t" + "ControlPointType = " + args.ControlPointType.ToString() + "\n" + "\t"
                        + "Action =" + args.DragState.ToString();
                }
            }
            else if (args.DragState == DragState.Starting)
            {
                if (ConnectorEditStarting)
                {
                    Events = "ConnectorEditing Event" + "\n" + "\t" + "ControlPointType = " + args.ControlPointType.ToString() + "\n" + "\t"
                        + "Action =" + args.DragState.ToString();
                }
            }            
        }

        /// <summary>
        /// Method to change the value for AutoScroll
        /// </summary>
        /// <param name="obj"></param>
        private void OnAutoScrollChanged(object obj)
        {
            if (AutoScroll)
            {
                Events = "AutoScrollChanged Event";
            }
        }

        /// <summary>
        /// Method to change the value for Annotation Changed
        /// </summary>
        /// <param name="obj"></param>
        private void OnAnnotationChanged(object obj)
        {
            var args = (obj as ChangeEventArgs<object, AnnotationChangedEventArgs>).NewValue;
            if (args.AnnotationInteractionState == AnnotationInteractionState.Editing)
            {
                if (AnnotationEditing)
                {
                    Events = "AnnotationChanged Event" + "\n" + "\t" + "Action = " + args.AnnotationInteractionState.ToString();
                }
            }
            else if (args.AnnotationInteractionState == AnnotationInteractionState.Edited)
            {
                if (AnnotationEdited)
                {
                    Events = "AnnotationChanged Event" + "\n" + "\t" + "Action = " + args.AnnotationInteractionState.ToString();
                }
            }
            else if(args.AnnotationInteractionState == AnnotationInteractionState.Rotating)
            {
                if (AnnotationRotating)
                {
                    Events = "AnnotationChanged Event" + "\n" + "\t" + "Action = " + args.AnnotationInteractionState.ToString();
                }
            }
            else if(args.AnnotationInteractionState == AnnotationInteractionState.Rotated)
            {
                if (AnnotationRotated)
                {
                    Events = "AnnotationChanged Event" + "\n" + "\t" + "Action = " + args.AnnotationInteractionState.ToString();
                }
            }
            else if (args.AnnotationInteractionState == AnnotationInteractionState.Dragging)
            {
                if (AnnotationDragging)
                {
                    Events = "AnnotationChanged Event" + "\n" + "\t" + "Action = " + args.AnnotationInteractionState.ToString();
                }
            }
            else if (args.AnnotationInteractionState == AnnotationInteractionState.Dragged)
            {
                if (AnnotationDragged)
                {
                    Events = "AnnotationChanged Event" + "\n" + "\t" + "Action = " + args.AnnotationInteractionState.ToString();
                }
            }
            else if (args.AnnotationInteractionState == AnnotationInteractionState.Resizing)
            {
                if (AnnotationResizing)
                {
                    Events = "AnnotationChanged Event" + "\n" + "\t" + "Action = " + args.AnnotationInteractionState.ToString();
                }
            }
            else if (args.AnnotationInteractionState == AnnotationInteractionState.Resized)
            {
                if (AnnotationResized)
                {
                    Events = "AnnotationChanged Event" + "\n" + "\t" + "Action = " + args.AnnotationInteractionState.ToString();
                }
            }
        }

        #endregion

        #region Properties and Command

        #region AnnotationChanged Properties

        /// <summary>
        /// Gets or sets the Value for AnnotationChanged
        /// </summary>
        public bool AnnotationChanged
        {
            get
            {
                return _annotationchanged;
            }
            set
            {
                if(value != _annotationchanged)
                {
                    _annotationchanged = value;
                    if(_annotationchanged)
                    {
                        AnnotationDragged = true;
                        AnnotationDragging = true;
                        AnnotationEdited = true;
                        AnnotationEditing = true;
                        AnnotationResized = true;
                        AnnotationResizing = true;
                        AnnotationRotated = true;
                        AnnotationRotating = true;
                    }
                    else
                    {
                        AnnotationDragged = false;
                        AnnotationDragging = false;
                        AnnotationEdited = false;
                        AnnotationEditing = false;
                        AnnotationResized = false;
                        AnnotationResizing = false;
                        AnnotationRotated = false;
                        AnnotationRotating = false;
                    }
                    OnPropertyChanged("AnnotationChanged");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for AnnotationEditing
        /// </summary>
        public bool AnnotationEditing
        {
            get
            {
                return _annotationediting;
            }
            set
            {
                if (value != _annotationediting)
                {
                    _annotationediting = value;
                    OnPropertyChanged("AnnotationEditing");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for AnnotationEdited
        /// </summary>
        public bool AnnotationEdited
        {
            get
            {
                return _annotationedited;
            }
            set
            {
                if (value != _annotationedited)
                {
                    _annotationedited = value;
                    OnPropertyChanged("AnnotationEdited");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for AnnotationResizing
        /// </summary>
        public bool AnnotationResizing
        {
            get
            {
                return _annotationresizing;
            }
            set
            {
                if (value != _annotationresizing)
                {
                    _annotationresizing = value;
                    OnPropertyChanged("AnnotationResizing");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for AnnotationResized
        /// </summary>
        public bool AnnotationResized
        {
            get
            {
                return _annotationresized;
            }
            set
            {
                if (value != _annotationresized)
                {
                    _annotationresized = value;
                    OnPropertyChanged("AnnotationResized");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for AnnotationRotating
        /// </summary>
        public bool AnnotationRotating
        {
            get
            {
                return _annotationrotating;
            }
            set
            {
                if (value != _annotationrotating)
                {
                    _annotationrotating = value;
                    OnPropertyChanged("AnnotationRotating");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for AnnotationRotated
        /// </summary>
        public bool AnnotationRotated
        {
            get
            {
                return _annotationrotated;
            }
            set
            {
                if (value != _annotationrotated)
                {
                    _annotationrotated = value;
                    OnPropertyChanged("AnnotationRotated");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for AnnotationDragging
        /// </summary>
        public bool AnnotationDragging
        {
            get
            {
                return _annotationdragging;
            }
            set
            {
                if (value != _annotationdragging)
                {
                    _annotationdragging = value;
                    OnPropertyChanged("AnnotationDragging");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for AnnotationDragged
        /// </summary>
        public bool AnnotationDragged
        {
            get
            {
                return _annotationdragged;
            }
            set
            {
                if (value != _annotationdragged)
                {
                    _annotationdragged = value;
                    OnPropertyChanged("AnnotationDragged");
                }
            }
        }

        #endregion

        #region ConnectorEditProperties

        /// <summary>
        /// Gets or sets the Value for ConnectorEditing
        /// </summary>
        public bool ConnectorEditing
        {
            get
            {
                return _connectorediting;
            }
            set
            {
                if (value != _connectorediting)
                {
                    _connectorediting = value;
                    if(_connectorediting)
                    {
                        ConnectorEditCompleted = true;
                        ConnectorEditDragging = true;
                        ConnectorEditStarted = true;
                        ConnectorEditStarting = true;
                    }
                    else
                    {
                        ConnectorEditCompleted = false;
                        ConnectorEditDragging = false;
                        ConnectorEditStarted = false;
                        ConnectorEditStarting = false;
                    }
                    OnPropertyChanged("ConnectorEditing");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ConnectorEditStarting
        /// </summary>
        public bool ConnectorEditStarting
        {
            get
            {
                return _coneditstarting;
            }
            set
            {
                if(value != _coneditstarting)
                {
                    _coneditstarting = value;
                    OnPropertyChanged("ConnectorEditStarting");
                }
            }
        }
        /// <summary>
        /// Gets or sets the Value for ConnectorEditStarted
        /// </summary>
        public bool ConnectorEditStarted
        {
            get
            {
                return _coneditstarted;
            }
            set
            {
                if (value != _coneditstarted)
                {
                    _coneditstarted = value;
                    OnPropertyChanged("ConnectorEditStarted");
                }
            }
        }
        /// <summary>
        /// Gets or sets the Value for ConnectorEditDragging
        /// </summary>
        public bool ConnectorEditDragging
        {
            get
            {
                return _coneditdragging;
            }
            set
            {
                if (value != _coneditdragging)
                {
                    _coneditdragging = value;
                    OnPropertyChanged("ConnectorEditDragging");
                }
            }
        }
        /// <summary>
        /// Gets or sets the Value for ConnectorEditCompleted
        /// </summary>
        public bool ConnectorEditCompleted
        {
            get
            {
                return _coneditcompleted;
            }
            set
            {
                if (value != _coneditcompleted)
                {
                    _coneditcompleted = value;
                    OnPropertyChanged("ConnectorEditCompleted");
                }
            }
        }

        #endregion

        #region ConnectorSourceChanged Properties

        /// <summary>
        /// Gets or sets the Value for ConnectorSourceChanged
        /// </summary>
        public bool ConnectorSourceChanged
        {
            get
            {
                return _connectorsourcechanged;
            }
            set
            {
                if (value != _connectorsourcechanged)
                {
                    _connectorsourcechanged = value;
                    if (_connectorsourcechanged)
                    {
                        ConnectorSourceCompleted = true;
                        ConnectorSourceDragging = true;
                        ConnectorSourceStarted = true;
                        ConnectorSourceStarting = true;
                    }
                    else
                    {
                        ConnectorSourceCompleted = false;
                        ConnectorSourceDragging = false;
                        ConnectorSourceStarted = false;
                        ConnectorSourceStarting = false;
                    }
                    OnPropertyChanged("ConnectorSourceChanged");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ConnectorSourceStarting
        /// </summary>
        public bool ConnectorSourceStarting
        {
            get
            {
                return _consourcestarting;
            }
            set
            {
                if (value != _consourcestarting)
                {
                    _consourcestarting = value;
                    OnPropertyChanged("ConnectorSourceStarting");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ConnectorSourceStarted
        /// </summary>
        public bool ConnectorSourceStarted
        {
            get
            {
                return _consourcestarted;
            }
            set
            {
                if (value != _consourcestarted)
                {
                    _consourcestarted = value;
                    OnPropertyChanged("ConnectorSourceStarted");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ConnectorSourceDragging
        /// </summary>
        public bool ConnectorSourceDragging
        {
            get
            {
                return _consourcedragging;
            }
            set
            {
                if (value != _consourcedragging)
                {
                    _consourcedragging = value;
                    OnPropertyChanged("ConnectorSourceDragging");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ConnectorSourceCompleted
        /// </summary>
        public bool ConnectorSourceCompleted
        {
            get
            {
                return _consourcecompleted;
            }
            set
            {
                if (value != _consourcecompleted)
                {
                    _consourcecompleted = value;
                    OnPropertyChanged("ConnectorSourceCompleted");
                }
            }
        }

        #endregion

        #region ConnectorTargetChanged Properties

        /// <summary>
        /// Gets or sets the Value for ConnectorTargetChanged
        /// </summary>
        public bool ConnectorTargetChanged
        {
            get
            {
                return _connectortargetchanged;
            }
            set
            {
                if (value != _connectortargetchanged)
                {
                    _connectortargetchanged = value;
                    if (_connectortargetchanged)
                    {
                        ConnectorTargetCompleted = true;
                        ConnectorTargetDragging = true;
                        ConnectorTargetStarted = true;
                        ConnectorTargetStarting = true;
                    }
                    else
                    {
                        ConnectorTargetCompleted = false;
                        ConnectorTargetDragging = false;
                        ConnectorTargetStarted = false;
                        ConnectorTargetStarting = false;
                    }
                    OnPropertyChanged("ConnectorTargetChanged");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ConnectorTargetStarting
        /// </summary>
        public bool ConnectorTargetStarting
        {
            get
            {
                return _contargetstarting;
            }
            set
            {
                if (value != _contargetstarting)
                {
                    _contargetstarting = value;
                    OnPropertyChanged("ConnectorTargetStarting");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ConnectorTargetStarted
        /// </summary>
        public bool ConnectorTargetStarted
        {
            get
            {
                return _contargetstarted;
            }
            set
            {
                if (value != _contargetstarted)
                {
                    _contargetstarted = value;
                    OnPropertyChanged("ConnectorTargetStarted");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ConnectorTargetDragging
        /// </summary>
        public bool ConnectorTargetDragging
        {
            get
            {
                return _contargetdragging;
            }
            set
            {
                if (value != _contargetdragging)
                {
                    _contargetdragging = value;
                    OnPropertyChanged("ConnectorTargetDragging");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ConnectorTargetCompleted
        /// </summary>
        public bool ConnectorTargetCompleted
        {
            get
            {
                return _contargetcompleted;
            }
            set
            {
                if (value != _contargetcompleted)
                {
                    _contargetcompleted = value;
                    OnPropertyChanged("ConnectorTargetCompleted");
                }
            }
        }

        #endregion

        #region NodeChanged Properties

        /// <summary>
        /// Gets or sets the Value for NodeChanged
        /// </summary>
        public bool NodeChanged
        {
            get
            {
                return _nodechanged;
            }
            set
            {
                if (value != _nodechanged)
                {
                    _nodechanged = value;
                    if (_nodechanged)
                    {
                        NodeDragged = true;
                        NodeDragging = true;
                        NodeStarted = true;
                        NodeResized = true;
                        NodeResizing = true;
                        NodeRotated = true;
                        NodeRotating = true;
                    }
                    else
                    {
                        NodeDragged = false;
                        NodeDragging = false;
                        NodeStarted = false;
                        NodeResized = false;
                        NodeResizing = false;
                        NodeRotated = false;
                        NodeRotating = false;
                    }
                    OnPropertyChanged("NodeChanged");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for NodeStarted
        /// </summary>
        public bool NodeStarted
        {
            get
            {
                return _nodestarted;
            }
            set
            {
                if (value != _nodestarted)
                {
                    _nodestarted = value;
                    OnPropertyChanged("NodeEdited");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for NodeResizing
        /// </summary>
        public bool NodeResizing
        {
            get
            {
                return _noderesizing;
            }
            set
            {
                if (value != _noderesizing)
                {
                    _noderesizing = value;
                    OnPropertyChanged("NodeResizing");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for NodeResized
        /// </summary>
        public bool NodeResized
        {
            get
            {
                return _noderesized;
            }
            set
            {
                if (value != _noderesized)
                {
                    _noderesized = value;
                    OnPropertyChanged("NodeResized");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for NodeRotating
        /// </summary>
        public bool NodeRotating
        {
            get
            {
                return _noderotating;
            }
            set
            {
                if (value != _noderotating)
                {
                    _noderotating = value;
                    OnPropertyChanged("NodeRotating");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for NodeRotated
        /// </summary>
        public bool NodeRotated
        {
            get
            {
                return _noderotated;
            }
            set
            {
                if (value != _noderotated)
                {
                    _noderotated = value;
                    OnPropertyChanged("NodeRotated");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for NodeDragging
        /// </summary>
        public bool NodeDragging
        {
            get
            {
                return _nodedragging;
            }
            set
            {
                if (value != _nodedragging)
                {
                    _nodedragging = value;
                    OnPropertyChanged("NodeDragging");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for NodeDragged
        /// </summary>
        public bool NodeDragged
        {
            get
            {
                return _nodedragged;
            }
            set
            {
                if (value != _nodedragged)
                {
                    _nodedragged = value;
                    OnPropertyChanged("NodeDragged");
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the Value for AutoScroll
        /// </summary>
        public bool AutoScroll
        {
            get
            {
                return _autoscroll;
            }
            set
            {
                if (value != _autoscroll)
                {
                    _autoscroll = value;
                    OnPropertyChanged("AutoScroll");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for DragEnter
        /// </summary>
        public bool Dragenter
        {
            get
            {
                return _dragenter;
            }
            set
            {
                if (value != _dragenter)
                {
                    _dragenter = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for DragLeave
        /// </summary>
        public bool DragLeave
        {
            get
            {
                return _dragleave;
            }
            set
            {
                if (value != _dragleave)
                {
                    _dragleave = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for DragOver
        /// </summary>
        public bool DragOver
        {
            get
            {
                return _dragover;
            }
            set
            {
                if (value != _dragover)
                {
                    _dragover = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for Drop
        /// </summary>
        public bool Drop
        {
            get
            {
                return _drop;
            }
            set
            {
                if (value != _drop)
                {
                    _drop = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ItemAdded
        /// </summary>
        public bool ItemAdded
        {
            get
            {
                return _itemadded;
            }
            set
            {
                if (value != _itemadded)
                {
                    _itemadded = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ItemDeleted
        /// </summary>
        public bool ItemDeleted
        {
            get
            {
                return _itemdeleted;
            }
            set
            {
                if (value != _itemdeleted)
                {
                    _itemdeleted = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ItemDoubleTapped
        /// </summary>
        public bool ItemDoubleTapped
        {
            get
            {
                return _itemdoubletapped;
            }
            set
            {
                if (value != _itemdoubletapped)
                {
                    _itemdoubletapped = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ItemSelected
        /// </summary>
        public bool ItemSelected
        {
            get
            {
                return _itemselected;
            }
            set
            {
                if (value != _itemselected)
                {
                    _itemselected = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ItemTapped
        /// </summary>
        public bool ItemTapped
        {
            get
            {
                return _itemtapped;
            }
            set
            {
                if (value != _itemtapped)
                {
                    _itemtapped = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for ItemUnselected
        /// </summary>
        public bool ItemUnSelected
        {
            get
            {
                return _itemunselected;
            }
            set
            {
                if (value != _itemunselected)
                {
                    _itemunselected = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for MenuItemClicked
        /// </summary>
        public bool MenuItemClicked
        {
            get
            {
                return _menuitemclicked;
            }
            set
            {
                if (value != _menuitemclicked)
                {
                    _menuitemclicked = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for MenuOpening
        /// </summary>
        public bool MenuOpening
        {
            get
            {
                return _menuopening;
            }
            set
            {
                if (value != _menuopening)
                {
                    _menuopening = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for Events
        /// </summary>
        public string Events
        {
            get
            {
                return _events;
            }
            set
            {
                if (_events != value)
                {
                    var tempevents = _events;
                    _events = value + "\n" + tempevents;
                    OnPropertyChanged("Events");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Value for Clear
        /// </summary>
        public ICommand Clear
        {
            get { return _clear; }
            set { _clear = value; }
        }

        #endregion
    }


    //Collection of Symbols
    public class SymbolCollection : ObservableCollection<object>
    {

    }
}
