#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class ZoomingAndPanningViewModel : DiagramViewModel
    {
        #region Fields

        private ICommand _ZoomInCommand;
        private ICommand _ZoomOutCommand;
        private ICommand _PanCommand;
        private ICommand _ResetCommand;
        private ICommand _BringintoViewCommand;
        private ICommand _BringintoCenterCommand;
        private ICommand _FitToPageCommand;
        private ICommand _SelectCommand;
        private bool _ZoomInEnabled = true;
        private bool _ZoomOutEnabled = true;
        private bool _SelectEnabled = false;
        private bool _ResetEnabled = false;
        private bool _BringIntoViewEnabled = true;
        private bool _PanEnabled = true;
        private bool _FitToPageEnabled = true;

        #endregion

        #region Constructor

        public ZoomingAndPanningViewModel()
        {
            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.QuickCommands,
            };
            ZoomInCommand = new DelegateCommand(ZoomInExecution);
            ZoomOutCommand = new DelegateCommand(ZoomOutExecution);
            PanCommand = new DelegateCommand(PanExecution);
            ResetCommand = new DelegateCommand(ResetExecution);
            BringintoViewCommand = new DelegateCommand(BrintintoViewExecution);
            BringintoCenterCommand = new DelegateCommand(BringintoCenterExecution);
            FitToPageCommand = new DelegateCommand(FitToPageExecution);
            SelectCommand = new DelegateCommand(SelectExecution);
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChanged);
        }

        #endregion

        #region Commands and Properties

        public bool ZoomInEnabled
        {
            get
            {
                return _ZoomInEnabled;
            }
            set
            {
                if (value != _ZoomInEnabled)
                {
                    _ZoomInEnabled = value;
                    OnPropertyChanged("ZoomInEnabled");
                }
            }
        }

        public bool ZoomOutEnabled
        {
            get
            {
                return _ZoomOutEnabled;
            }
            set
            {
                if (value != _ZoomOutEnabled)
                {
                    _ZoomOutEnabled = value;
                    OnPropertyChanged("ZoomOutEnabled");
                }
            }
        }

        public bool ResetEnabled
        {
            get
            {
                return _ResetEnabled;
            }
            set
            {
                if (value != _ResetEnabled)
                {
                    _ResetEnabled = value;
                    OnPropertyChanged("ResetEnabled");
                }
            }
        }

        public bool FitToPageEnabled
        {
            get
            {
                return _FitToPageEnabled;
            }
            set
            {
                if (value != _FitToPageEnabled)
                {
                    _FitToPageEnabled = value;
                    OnPropertyChanged("FitToPageEnabled");
                }
            }
        }

        public bool PanEnabled
        {
            get
            {
                return _PanEnabled;
            }
            set
            {
                if (value != _PanEnabled)
                {
                    _PanEnabled = value;
                    OnPropertyChanged("PanEnabled");
                }
            }
        }

        public bool SelectEnabled
        {
            get
            {
                return _SelectEnabled;
            }
            set
            {
                if (value != _SelectEnabled)
                {
                    _SelectEnabled = value;
                    OnPropertyChanged("SelectEnabled");
                }
            }
        }

        public bool BringIntoViewEnabled
        {
            get
            {
                return _BringIntoViewEnabled;
            }
            set
            {
                if (value != _BringIntoViewEnabled)
                {
                    _BringIntoViewEnabled = value;
                    OnPropertyChanged("BringIntoViewEnabled");
                }
            }
        }

        public ICommand ZoomInCommand
        {
            get { return _ZoomInCommand; }
            set { _ZoomInCommand = value; }
        }

        public ICommand ZoomOutCommand
        {
            get { return _ZoomOutCommand; }
            set { _ZoomOutCommand = value; }
        }

        public ICommand PanCommand
        {
            get { return _PanCommand; }
            set { _PanCommand = value; }
        }

        public ICommand ResetCommand
        {
            get { return _ResetCommand; }
            set { _ResetCommand = value; }
        }

        public ICommand BringintoViewCommand
        {
            get { return _BringintoViewCommand; }
            set { _BringintoViewCommand = value; }
        }

        public ICommand BringintoCenterCommand
        {
            get { return _BringintoCenterCommand; }
            set { _BringintoCenterCommand = value; }
        }

        public ICommand FitToPageCommand
        {
            get { return _FitToPageCommand; }
            set { _FitToPageCommand = value; }
        }

        public ICommand SelectCommand
        {
            get { return _SelectCommand; }
            set { _SelectCommand = value; }
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// This method is used to execute Select command
        /// </summary>
        /// <param name="obj"></param>
        private void SelectExecution(object obj)
        {
            Tool = Tool.MultipleSelect;
            SelectEnabled = false;
            PanEnabled = true;
        }

        private bool fittopageexecuted;

        /// <summary>
        /// This method is used to fit the diagram into viewport
        /// </summary>
        /// <param name="obj"></param>
        private void FitToPageExecution(object obj)
        {
            (Info as IGraphInfo).Commands.FitToPage.Execute(null);
            fittopageexecuted = true;
            FitToPageEnabled = false;
            BringIntoViewEnabled = false;
        }

        /// <summary>
        /// This method is used to execute BringintoCenter command
        /// </summary>
        /// <param name="obj"></param>
        private void BringintoCenterExecution(object obj)
        {
            if ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object> != null && ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                NodeViewModel node = ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as NodeViewModel;
                (node.Info as INodeInfo).BringIntoCenter();
            }
            else
            {
                MessageBox.Show("Please select any Node to bring into Centre");
            }
            BringIntoViewEnabled = true;
        }

        /// <summary>
        /// This method is used to execute BringintoView command
        /// </summary>
        /// <param name="obj"></param>
        private void BrintintoViewExecution(object obj)
        {
            if ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object> != null && ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                NodeViewModel node = ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as NodeViewModel;
                (node.Info as INodeInfo).BringIntoViewport();
            }
            else
            {
                MessageBox.Show("Please select any Node to bring into Viewport");
            }
        }

        /// <summary>
        /// This method is used to execute Reset command
        /// </summary>
        /// <param name="obj"></param>
        private void ResetExecution(object obj)
        {
            Tool = Tool.MultipleSelect;
            (Info as IGraphInfo).Commands.Reset.Execute(null);
            SelectEnabled = false;
            PanEnabled = true;
            ResetEnabled = false;
        }

        /// <summary>
        /// This method is used to execute Pan command
        /// </summary>
        /// <param name="obj"></param>
        private void PanExecution(object obj)
        {
            Tool = Tool.ZoomPan;
            PanEnabled = false;
            SelectEnabled = true;
        }

        /// <summary>
        /// This method is used to execute ZoomOut command
        /// </summary>
        /// <param name="obj"></param>
        private void ZoomOutExecution(object obj)
        {
            (Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter() { ZoomCommand = ZoomCommand.ZoomOut, ZoomFactor = 0.2 });
        }

        /// <summary>
        /// This method is used to execute ZoomIn command
        /// </summary>
        /// <param name="obj"></param>
        private void ZoomInExecution(object obj)
        {
            (Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter() { ZoomCommand = ZoomCommand.ZoomIn, ZoomFactor = 0.2 });
        }

        /// <summary>
        /// This method is used to execute viewport changed command
        /// </summary>
        /// <param name="obj"></param>
        private void OnViewPortChanged(object obj)
        {
            var args = obj as ChangeEventArgs<object, ScrollChanged>;
            if (args.NewValue.CurrentZoom == 30)
            {
                ZoomInEnabled = false;
            }
            else
            {
                ZoomInEnabled = true;
            }
            if (args.NewValue.CurrentZoom == 0.3)
            {
                ZoomOutEnabled = false;
            }
            else
            {
                ZoomOutEnabled = true;
            }
            if (args.NewValue.CurrentZoom != 1 || (args.OldValue.ViewPort != args.NewValue.ViewPort && PanEnabled == false))
            {
                ResetEnabled = true;
            }
            if (fittopageexecuted != true)
            {
                if (FitToPageEnabled == false && ((args.OldValue.ViewPort != args.NewValue.ViewPort && PanEnabled == false) || args.OldValue.CurrentZoom != args.NewValue.CurrentZoom))
                {
                    FitToPageEnabled = true;
                }

                if (FitToPageEnabled == true && args.OldValue.CurrentZoom != args.NewValue.CurrentZoom)
                {
                    if (args.NewValue.CurrentZoom > args.OldValue.CurrentZoom)
                    {
                        BringIntoViewEnabled = true;
                    }
                }
            }
            else
            {
                fittopageexecuted = false;
            }


        }

        #endregion
    }
}
