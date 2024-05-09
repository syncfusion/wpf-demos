#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.logicalcircuitdesigner.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class WireViewModel : ConnectorViewModel
    {
        private BinaryState state = BinaryState.Zero;
        private BaseGateViewModel cacheSourceNode = null;
        private GateViewModel cacheTargetNode = null;
        private LogicGatesViewModel diagramModel;

        /// <summary>
        /// 
        /// </summary>
        public WireViewModel() : base()
        {
            this.RefreshTemplate();
        }

        /// <summary>
        /// 
        /// </summary>
        public BinaryState State
        {
            get
            {
                return state;
            }

            set
            {
                if (state != value)
                {
                    state = value;
                    this.OnPropertyChanged("State");
                }
            }
        }

        public LogicGatesViewModel DiagramModel
        {
            get
            {
                return diagramModel;
            }
            set
            {
                if (diagramModel != value)
                {
                    diagramModel = value;
                    if (diagramModel != null)
                    {
                        this.RefreshTemplate();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SimpleEventHandler StateChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            if (name == "State")
            {
                this.RefreshTemplate();

                if (StateChanged != null)
                {
                    StateChanged.Invoke(this);
                }
            }
            else if (name == "SourceNode")
            {
                // Subscribing StateChanged for the input connection
                if (cacheSourceNode != null)
                {
                    cacheSourceNode.StateChanged -= OnInputStateChanged;
                    cacheSourceNode = null;
                }
                if (this.SourceNode is BaseGateViewModel inputNode)
                {
                    cacheSourceNode = inputNode;
                    this.State = cacheSourceNode.State;
                    cacheSourceNode.StateChanged += OnInputStateChanged;
                }
            }
            else if (name == "TargetNode")
            {
                // Subscribing StateChanged for the output connection
                if (cacheTargetNode != null)
                {
                    cacheTargetNode.DisposeEvents(this);
                    cacheTargetNode = null;
                }
                if (this.TargetNode is GateViewModel outputNode)
                {
                    cacheTargetNode = outputNode;
                    cacheTargetNode.InitEvents(this);
                }
            }
        }

        /// <summary>
        /// Raises when the input value to the wire is changed
        /// </summary>
        /// <param name="inputNode"></param>
        private void OnInputStateChanged(IGroupable inputNode)
        {
            this.State = (inputNode as BaseGateViewModel).State;
        }

        private void RefreshTemplate()
        {
            var resourceName = state == BinaryState.Zero ? Constants.DefaultConnectorStyle : Constants.ActiveConnectorStyle;
            this.ConnectorGeometryStyle = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[resourceName] as Style;
        }
    }
}
