#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.ComponentModel;

namespace GroupBarDemo
{
    /// <summary>
    /// Represents a control that performs drag and drop.
    /// </summary>
    public class ViewModel : NotificationObject
    {      
        #region Fields
        /// <summary>
        ///  Maintains the collection for event logs .
        /// </summary>
        private ObservableCollection<string> eventLogsCollection;

        /// <summary>
        ///  Maintains the collection for visual modes .
        /// </summary>
        private ObservableCollection<string> visualModes;

        /// <summary>
        ///  Maintains the collection for visibility details .
        /// </summary>
        private ObservableCollection<string> visibilityDetails;

        /// <summary>
        ///  Maintains the collection for orientations.
        /// </summary>
        private ObservableCollection<string> orientations;

        /// <summary>
        ///  Maintains the command for dragstart.
        /// </summary>
        private ICommand dragstart;

        /// <summary>
        ///  Maintains the command for dragend.
        /// </summary>
        private ICommand dragend;

        /// <summary>
        /// Maintains the collection for home bar new items.
        /// </summary>
        ObservableCollection<string> collection = new ObservableCollection<string>();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>   
        public ViewModel()
        {           
            DragStart = new DelegateCommand<object>(GroupViewItemDragStart);
            DragEnd = new DelegateCommand<object>(GroupViewItemDragEnd);
            VisualModes = new ObservableCollection<string>();
            VisibilityDetails = new ObservableCollection<string>();
            Orientations = new ObservableCollection<string>();
            PopulateVisualModes();
            PopulateVisibility();
            PopulateOrientation();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the collection for event logs.
        /// </summary>
        [Category("Summary")]      
        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set
            {
                eventLogsCollection = value;
                this.RaisePropertyChanged(() => this.EventLogsCollection);
            }
        }

        /// <summary>
        /// Gets or sets the colletion details for visual modes.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<string> VisualModes
        {
            get
            {
                return visualModes;
            }
            set
            {
                if (visualModes != value)
                    visualModes = value;
            }

        }

        /// <summary>
        /// Gets or sets the details for visibility details.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<string> VisibilityDetails
        {
            get
            {
                return visibilityDetails;
            }
            set
            {
                if (visibilityDetails != value)
                    visibilityDetails = value;
            }

        }

        /// <summary>
        /// Gets or sets the orientations.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<string> Orientations
        {
            get
            {
                return orientations;
            }
            set
            {
                if (orientations != value)
                    orientations = value;
            }
        }

        /// <summary>
        /// Gets or sets the command details for Drag start.
        /// </summary>
        [Category("Summary")]
        public ICommand DragStart
        {
            get { return dragstart; }
            set
            {
                dragstart = value;
                this.RaisePropertyChanged(() => this.DragStart);
            }
        }

        /// <summary>
        /// Gets or sets the command details for Drag end.
        /// </summary>
        [Category("Summary")]
        public ICommand DragEnd
        {
            get { return dragend; }
            set
            {
                dragend = value;
                this.RaisePropertyChanged(() => this.DragEnd);
            }
        }
        #endregion

        #region Helpermethods
        /// <summary>
        /// Method which indicates to start dragging.
        /// </summary>
        /// <param name="parameter">Invokes the parameter which is to be start the drag</param>
        private void GroupViewItemDragStart(object parameter)
        {
            if (parameter != null)
            {
                collection.Add("DragStarted  (" + parameter.ToString() + " )");
                EventLogsCollection = collection;
            }
        }

        /// <summary>
        /// Method which indicates to end dragging.
        /// </summary>
        /// <param name="parameter">Invokes the parameter which is to be end the drag</param>
        private void GroupViewItemDragEnd(object parameter)
        {
            if (parameter != null)
            {
                collection.Add("DragEnded  (" + parameter.ToString() + " )");
                EventLogsCollection = collection;
            }
        }

        /// <summary>
        /// Adding details to the visual modes collection.
        /// </summary>  
        private void PopulateVisualModes()
        {
            VisualModes.Add("Default");
            VisualModes.Add("MultipleExpansion");
            VisualModes.Add("StackMode");
        }

        /// <summary>
        /// Adding details to the visibility details collection.
        /// </summary>  
        private void PopulateVisibility()
        {
            VisibilityDetails.Add("Visible");
            VisibilityDetails.Add("Hidden");
        }

        /// <summary>
        /// Adding details to the orientations collection.
        /// </summary>  
        private void PopulateOrientation()
        {
            Orientations.Add("Horizontal");
            Orientations.Add("Vertical");
        }
        #endregion
    }
}
