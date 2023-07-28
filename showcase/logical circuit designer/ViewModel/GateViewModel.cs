#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public interface IGate
    {
        BinaryState State { get; set; }
    }

    public abstract class BaseGateViewModel : NodeViewModel, IGate, IDisposable
    {
        private BinaryState state = BinaryState.Zero;
        private LogicGatesViewModel diagramModel;

        public BaseGateViewModel() : base()
        {
            this.Constraints = NodeConstraints.Default & ~NodeConstraints.Connectable;
        }

        [DataMember]
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

        public SimpleEventHandler StateChanged;

        public void ResetState()
        {
            this.GenerateLogic();
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            if (name == "State")
            {
                if (StateChanged != null)
                {
                    StateChanged.Invoke(this);
                }

                this.RefreshTemplate();
            }
        }

        protected virtual void GenerateLogic()
        {
            if (this.Info is INodeInfo nodeInfo && nodeInfo.InConnectors != null)
            {
                int? state = null;
                foreach (WireViewModel connector in nodeInfo.InConnectors)
                {
                    if (state.HasValue)
                    {
                        state = (int)connector.State & state.Value;
                    }
                    else
                    {
                        state = (int)connector.State;
                    }
                }

                if (state.HasValue)
                    this.State = (BinaryState)state;
            }
        }

        protected virtual void RefreshTemplate()
        {

        }

        public virtual void Dispose()
        {
            
        }
    }

    public abstract class GateViewModel : BaseGateViewModel
    {
        public GateViewModel() : base()
        {

        }

        internal void InitEvents(WireViewModel connector)
        {
            connector.StateChanged += OnInputStateChanged;
        }

        internal void DisposeEvents(WireViewModel connector)
        {
            connector.StateChanged -= OnInputStateChanged;
        }

        private void OnInputStateChanged(IGroupable inputWire)
        {
            this.GenerateLogic();
        }
    }

    public delegate void SimpleEventHandler(IGroupable sender);
}
