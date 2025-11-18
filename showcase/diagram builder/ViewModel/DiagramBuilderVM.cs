using Microsoft.Win32;
using syncfusion.diagrambuilder.wpf.BPMN;
using syncfusion.diagrambuilder.wpf.FlowChart;
using syncfusion.diagrambuilder.wpf.LogicCircuit;
using syncfusion.diagrambuilder.wpf.Network;
using syncfusion.diagrambuilder.wpf.Utility;
using syncfusion.diagrambuilder.wpf.View;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Theming;
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
                    if (_diagramVM != null)
                    {
                        _diagramVM.PropertyChanged -= DiagramVM_PropertyChanged;
                    }

                    _diagramVM = value;
                    OnPropertyChanged("DiagramVM");

                    if (_diagramVM != null)
                    {
                        _diagramVM.PropertyChanged += DiagramVM_PropertyChanged;
                    }
                }
            }
        }

        private DiagramTheme cacheTheme;
        private void DiagramVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Theme")
            {
                if(cacheTheme != null)
                {
                    cacheTheme.PropertyChanged -= DiagramTheme_PropertyChanged;
                    cacheTheme = null;
                }

                if ((StencilView as Grid).Children.Count > 0)
                {
                    var stencil = (StencilView as Grid).Children[0];
                    cacheTheme = DiagramVM.Theme;
                    if (cacheTheme != null)
                    {
                        if (stencil is IStencilTheme)
                        {
                            (stencil as IStencilTheme).Theme = Activator.CreateInstance(cacheTheme.GetType()) as DiagramTheme;
                        }

                        cacheTheme.PropertyChanged += DiagramTheme_PropertyChanged;
                    }
                }
            }
        }

        private void DiagramTheme_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((StencilView as Grid).Children.Count > 0)
            {
                var stencil = (StencilView as Grid).Children[0];
                if (stencil is IStencilTheme)
                {
                    if (e.PropertyName == "NodeStyles")
                    {
                        (stencil as IStencilTheme).Theme.NodeStyles = (sender as DiagramTheme).NodeStyles;
                    }
                    else if (e.PropertyName == "ConnectorStyles")
                    {
                        (stencil as IStencilTheme).Theme.ConnectorStyles = (sender as DiagramTheme).ConnectorStyles;
                    }
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

            if (DiagramVM != null && DiagramVM.HasChanges)
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
                (DiagramVM as DiagramVM).Theme = new OfficeTheme();
            }
            else if(obj.ToString() == "Flow")
            {
                DiagramVM = new FlowDiagramVM();
                (StencilView as Grid).Children.Clear();
                (StencilView as Grid).Children.Add(new FlowStencil());
                (DiagramVM as FlowDiagramVM).Theme = new OfficeTheme();
            }
            else if(obj.ToString() == "Logic")
            {
                DiagramVM = new LogicCircuitDiagramVM();
                (StencilView as Grid).Children.Clear();
                (StencilView as Grid).Children.Add(new LogicalCircuitStencil());
                (DiagramVM as LogicCircuitDiagramVM).Theme = new OfficeTheme();
            }
            else if (obj.ToString() == "Network")
            {
                DiagramVM = new NetworkDiagramVM();
                (StencilView as Grid).Children.Clear();
                (StencilView as Grid).Children.Add(new NetworkStencil());
                (DiagramVM as NetworkDiagramVM).Theme = new OfficeTheme();
            }
            else if (obj.ToString() == "BPMN")
            {
                DiagramVM = new BPMNDiagramVM();
                (StencilView as Grid).Children.Clear();
                (StencilView as Grid).Children.Add(new BPMNStencil());
                (DiagramVM as BPMNDiagramVM).Theme = new SimpleTheme();
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
