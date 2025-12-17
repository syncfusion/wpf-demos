using syncfusion.logicalcircuitdesigner.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class TemplatedNodeViewModel : GateViewModel
    {
        private object _mcustomcontent;

        public TemplatedNodeViewModel() : base()
        {

        }

        /// <summary>
        /// Gets or sets the model for the node.
        /// </summary>
        [DataMember]
        public object CustomContent
        {
            get
            {
                return this._mcustomcontent;
            }
            set
            {
                if (this._mcustomcontent != value)
                {
                    this._mcustomcontent = value;
                    OnPropertyChanged("CustomContent");
                }
            }
        }

        private string contentTemplateId;
        [DataMember]
        public string ContentTemplateId
        {
            get
            {
                return contentTemplateId;
            }
            set
            {
                if (contentTemplateId != value)
                {
                    contentTemplateId = value;
                    OnPropertyChanged("ContentTemplateId");
                }
            }
        }

        //protected async override void GenerateLogic()
        //{
            //if (_mcustomcontent is ComboBoxInputContent comboBoxContent)
            //{
            //    this.State = (BinaryState)comboBoxContent.InputSelectedItem;
            //}
            //else if (_mcustomcontent is TimerContent timerContent)
            //{
            //    // Update state based on the input connections
            //    if (this.Info is INodeInfo nodeInfo && nodeInfo.InConnectors != null)
            //    {
            //        int? state = null;
            //        foreach (WireViewModel connector in nodeInfo.InConnectors)
            //        {
            //            if (state.HasValue)
            //            {
            //                state = (int)connector.State & state.Value;
            //            }
            //            else
            //            {
            //                state = (int)connector.State;
            //            }
            //        }

            //        if (state.HasValue)
            //        {
            //            if ((BinaryState)state == BinaryState.One)
            //            {
            //                // Sleep for given time before updating the state.
            //                await Task.Delay(timerContent.TimerValue);
            //            }
            //            this.State = (BinaryState)state;
            //        }
            //    }
            //}
        //}

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            if (name == nameof(CustomContent))
            {
                this.Content = this.CustomContent;
                if (_mcustomcontent is INotifyPropertyChanged content)
                {
                    content.PropertyChanged += OnContentPropertyChanged;
                }
            }

            if (name == nameof(ContentTemplateId))
            {
                this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[this.ContentTemplateId] as DataTemplate;
            }
        }

        private void OnContentPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Refreshing the logic on its model's property change
            //if (e.PropertyName == nameof(ComboBoxInputContent.InputSelectedItem) || e.PropertyName == nameof(TimerContent.TimerValue))
            //{
            //    this.GenerateLogic();
            //}
        }
    }
}
