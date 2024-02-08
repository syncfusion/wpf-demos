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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class FourBitDigitOutputViewModel : GateViewModel
    {
        public FourBitDigitOutputViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void GenerateLogic()
        {
            int? state = null;
            
            if (this.Ports != null)
            {
                double OutputSum = 0;
                for (var i = 0; i < (Ports as IEnumerable<object>).Count(); i++)
                {
                    if ((((Ports as PortCollection).ElementAt(i) as NodePortViewModel).Info as INodePortInfo).InConnectors != null &&
                        ((((Ports as PortCollection).ElementAt(i) as NodePortViewModel).Info as INodePortInfo).InConnectors as IEnumerable<object>).Count() > 0)
                    {
                        WireViewModel connector = ((((Ports as PortCollection).ElementAt(i) as NodePortViewModel).Info as INodePortInfo).InConnectors as IEnumerable<object>).ElementAt(0) as WireViewModel;
                        state = (int)connector.State;
                        if (state.HasValue && state == 1)
                        {
                            OutputSum += (Math.Pow(2, i));
                        }
                    }

                }
                this.DisplayOutput(OutputSum);
            }
        }

        protected override void RefreshTemplate()
        {
            this.GenerateLogic();
        }

        private void DisplayOutput(double number)
        {
            switch(number)
            {
                case 0:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNode"] as DataTemplate;
                    break;
                case 1:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeOne"] as DataTemplate;
                    break;
                case 2:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeTwo"] as DataTemplate;
                    break;
                case 3:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeThree"] as DataTemplate;
                    break;
                case 4:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeFour"] as DataTemplate;
                    break;
                case 5:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeFive"] as DataTemplate;
                    break;
                case 6:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeSix"] as DataTemplate;
                    break;
                case 7:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeSeven"] as DataTemplate;
                    break;
                case 8:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeEight"] as DataTemplate;
                    break;
                case 9:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeNine"] as DataTemplate;
                    break;
                case 10:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeA"] as DataTemplate;
                    break;
                case 11:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeB"] as DataTemplate;
                    break;
                case 12:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeC"] as DataTemplate;
                    break;
                case 13:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeD"] as DataTemplate;
                    break;
                case 14:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeE"] as DataTemplate;
                    break;
                case 15:
                    this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["FourBitDigitNodeF"] as DataTemplate;
                    break;
            }
        }
    }
}
