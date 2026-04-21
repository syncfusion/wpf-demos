#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.logicalcircuitdesigner.wpf.Model;
using syncfusion.logicalcircuitdesigner.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace syncfusion.logicalcircuitdesigner.wpf
{
    /// <summary>
    /// Interaction logic for LogicCircuitDiagramDemo.xaml
    /// </summary>
    public partial class LogicalCircuitDesignerDemo : Window
    {
        public LogicalCircuitDesignerDemo()
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "MaterialDark" });
            (this.DataContext as LogicGatesViewModel).View = this;
            Diagram.KnownTypes = () => new List<Type>()
            {
                typeof(BinaryState)
            };

            Diagram.Loaded += Diagram_Loaded;
            (Diagram.Info as IGraphInfo).MouseDown += LogicalCircuitDesignerDemo_MouseDown;
            (Diagram.Info as IGraphInfo).MouseUp += LogicalCircuitDesignerDemo_MouseUp;
            (Diagram.Info as IGraphInfo).ItemDropEvent += LogicalCircuitDesignerDemo_ItemDropEvent;
            (Diagram.Info as IGraphInfo).ItemSelectedEvent += LogicalCircuitDesignerDemo_ItemSelectedEvent;
            (Diagram.Info as IGraphInfo).ItemUnSelectedEvent += LogicalCircuitDesignerDemo_ItemUnSelectedEvent;
            (Diagram.Info as IGraphInfo).ItemAdded += LogicalCircuitDesignerDemo_ItemAdded;
            (Diagram.Info as IGraphInfo).ItemSelectedEvent += LogicalCircuitDesignerDemo_ItemSelectedEvent1;
        }

        private void LogicalCircuitDesignerDemo_ItemSelectedEvent1(object sender, DiagramEventArgs args)
        {
            if (args.Item is ClockViewModel gate)
            {
                signalDuration.Value = gate.TimerValue;
            }
        }

        private void LogicalCircuitDesignerDemo_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if (args.Item is ClockViewModel gate)
            {
                gate.TimerValue = 2000;
                signalDuration.Value = 2000;
            }
        }

        private void LogicalCircuitDesignerDemo_ItemUnSelectedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is ClockViewModel)
            {
                ClockInputBox.Visibility = Visibility.Collapsed;
            }
        }

        private void LogicalCircuitDesignerDemo_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is ClockViewModel)
            {
                ClockInputBox.Visibility = Visibility.Visible;
            }
        }

        private void LogicalCircuitDesignerDemo_ItemDropEvent(object sender, ItemDropEventArgs args)
        {
            if (args.ItemSource == Cause.Stencil && args.Source is ClockViewModel)
            {
                ClockInputBox.Visibility = Visibility.Visible;
            }
        }

        private void LogicalCircuitDesignerDemo_MouseUp(object sender, MouseUpEventArgs args)
        {
            if (args.Item is PushButtonViewModel gate)
            {
                gate.State = BinaryState.Zero;
            }
        }

        private void LogicalCircuitDesignerDemo_MouseDown(object sender, MouseDownEventArgs args)
        {
            if (args.Item is PushButtonViewModel gate)
            {
                gate.State = BinaryState.One;
            }
        }

        private void LoadDiagramFromFile(string file)
        {
            (Diagram.Nodes as ObservableCollection<BaseGateViewModel>).Clear();
            (Diagram.Connectors as ObservableCollection<WireViewModel>).Clear();
            if (Diagram.Info != null)
            {
                using (FileStream fileStream = File.OpenRead(file))
                {
                    (Diagram.Info as IGraphInfo).Load(fileStream);
                }
            }
        }

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadDiagramFromFile(@"Data/Diagram/BasicLogicCircuit.xml");
            Diagram.Loaded -= Diagram_Loaded;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.stencil != null)
            {
				this.stencil.SymbolGroups = null;
				this.stencil.SymbolSource = null;
				this.stencil.DataContext = null;
				this.stencil = null;
            }

            if (this.Diagram != null)
            {
                (Diagram.Nodes as ObservableCollection<BaseGateViewModel>).Clear();
                (Diagram.Connectors as ObservableCollection<WireViewModel>).Clear();
                Diagram.Constraints = GraphConstraints.Default;
                Diagram.DataContext = null;
                Diagram = null;
            }

            (this.DataContext as LogicGatesViewModel).View = null;
            this.DataContext = null;

            base.OnClosing(e);
        }


        private void UpDown_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selectedNode = ((Diagram.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).FirstOrDefault();
            if (selectedNode is ClockViewModel && e.NewValue != null)
            {
                int timer = 0;
                if (int.TryParse(e.NewValue.ToString(), out timer))
                {
                    (selectedNode as ClockViewModel).TimerValue = timer;
                }
            }
        }
    }
}
