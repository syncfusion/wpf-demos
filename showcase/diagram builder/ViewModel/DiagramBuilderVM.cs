#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.diagrambuilder.wpf.BPMN;
using syncfusion.diagrambuilder.wpf.FlowChart;
using syncfusion.diagrambuilder.wpf.LogicCircuit;
using syncfusion.diagrambuilder.wpf.Network;
using syncfusion.diagrambuilder.wpf.Utility;
using syncfusion.diagrambuilder.wpf.View;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.diagrambuilder.wpf.ViewModel
{
    public class DiagramBuilderVM : INotifyPropertyChanged
    {
        /// <summary>
        ///     Gets or sets the new command.
        /// </summary>
        public ICommand New { get; set; }

        /// <summary>
        /// Gets or sets the Ribbon used in the sample.
        /// </summary>
        public Ribbon DiagramRibbon { get; set; }

        private DiagramViewModel _diagramVM;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the DiagramViewModel for the SfDiagramView.
        /// </summary>
        public DiagramViewModel DiagramVM
        {
            get
            {
                return _diagramVM;
            }
            set
            {
                if(value != _diagramVM && value != null)
                {
                    _diagramVM = value;
                    OnPropertyChanged("DiagramVM");
                }
            }
        }

        private object _stencilview;

        /// <summary>
        /// Gets or sets the DiagramViewModel for the SfDiagramView.
        /// </summary>
        public object StencilView
        {
            get
            {
                return _stencilview;
            }
            set
            {
                if (value != _stencilview && value != null)
                {
                    _stencilview = value;
                    OnPropertyChanged("StencilView");
                }
            }
        }

        private object _diagramview;

        /// <summary>
        /// Gets or sets the DiagramViewModel for the SfDiagramView.
        /// </summary>
        public object DiagramView
        {
            get
            {
                return _diagramview;
            }
            set
            {
                if (value != _diagramview && value != null)
                {
                    _diagramview = value;
                    OnPropertyChanged("DiagramView");
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }


        public DiagramBuilderVM()
        { 
            New = new Command(OnNewCommand);            
        }

        private void OnNewCommand(object obj)
        {
            if (this.DiagramRibbon != null)
            {
                this.DiagramRibbon.HideBackStage();
            }

            if (DiagramVM != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                            "Do you want to save Diagram?",
                            "SfDiagramRibbon",
                            MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    SaveDiagram();
                }
            }

            if (obj.ToString() == "Blank")
            {
                DiagramVM = new DiagramVM();
                (StencilView as Grid).Children.Clear();
                (StencilView as Grid).Children.Add(new BlankStencil());
            }
            else if(obj.ToString() == "Flow")
            {
                DiagramVM = new FlowDiagramVM();
                (StencilView as Grid).Children.Clear();
                (StencilView as Grid).Children.Add(new FlowStencil());
            }
            else if(obj.ToString() == "Logic")
            {
                DiagramVM = new LogicCircuitDiagramVM();
                (StencilView as Grid).Children.Clear();
                (StencilView as Grid).Children.Add(new LogicalCircuitStencil());
            }
            else if (obj.ToString() == "Network")
            {
                DiagramVM = new NetworkDiagramVM(); 
                (StencilView as Grid).Children.Clear();
                (StencilView as Grid).Children.Add(new NetworkStencil());
            }
            else if (obj.ToString() == "BPMN")
            {
                DiagramVM = new BPMNDiagramVM();
                (StencilView as Grid).Children.Clear();
                (StencilView as Grid).Children.Add(new BPMNStencil());
            }
        }

        private void SaveDiagram()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save XAML";
            dialog.Filter = "XAML File (*.xaml)|*.xaml";
            if (dialog.ShowDialog() == true)
            {
                File.Delete(dialog.FileName);
                using (Stream s = File.Open(dialog.FileName, FileMode.OpenOrCreate))
                {
                    (DiagramView as SfDiagram).Save(s);
                }
            }
        }
    }
}
