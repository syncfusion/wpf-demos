#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System;
using System.Xml.Linq;
using System.Windows.Input;
using System.Windows;
using System.Windows.Threading;
using Syncfusion.UI.Xaml.TreeView;
using Syncfusion.UI.Xaml.TreeView.Engine;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Notification;

namespace PerformanceDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        private SfTreeView treeView;
        private SfBusyIndicator busyIndicator;

        private ICommand treeViewOnDemandCommand;
        public ICommand TreeViewOnDemandCommand
        {
            get { return treeViewOnDemandCommand; }
            set { treeViewOnDemandCommand = value; RaisePropertyChanged("TreeViewOnDemandCommand"); }
        }

        private ICommand clickCommand;

        public ICommand ClickCommand
        {
            get { return clickCommand; }
            set { clickCommand = value; RaisePropertyChanged("ClickCommand"); }
        }

        private ObservableCollection<Model> items = new ObservableCollection<Model>();
        public ObservableCollection<Model> Items
        {
            get { return items; }
            set { items = value; this.RaisePropertyChanged("Items"); }
        }

        public ViewModel()
        {
            ClickCommand = new Commands(ExecuteClickAction, CanExecuteClickCommand);
            TreeViewOnDemandCommand = new Commands(ExecuteOnDemandLoading, CanExecuteOnDemandLoading);
        }
        internal void PopulateCollection(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Model item = new Model() { Header = "Module " + (i+1) };
                items.Add(item);
            }
        }

        ObservableCollection<Model> GetChildItems(Model item)
        {
            ObservableCollection<Model> childItems = new ObservableCollection<Model>();
            for (int i = 0; i < 500; i++)
            {
                childItems.Add(new Model() { Header = item.Header + "." + (i+1) });
            }
            
            return childItems;
        }

        /// <summary>
        /// CanExecute method is called before expanding and initialization of node. Returns whether the node has child nodes or not.
        /// Based on return value, expander visibility of the node is handled.  
        /// </summary>
        /// <param name="sender">TreeViewNode is passed as default parameter </param>
        /// <returns>Returns true, if the specified node has child items to load on demand and expander icon is displayed for that node, else returns false and icon is not displayed.</returns>
        private bool CanExecuteOnDemandLoading(object sender)
        {
            var node = sender as TreeViewNode;
            if (node.Level < 3)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Execute method is called when any item is requested for load-on-demand items.
        /// </summary>
        /// <param name="obj">TreeViewNode is passed as default parameter </param>
        private void ExecuteOnDemandLoading(object obj)
        {
            var node = obj as TreeViewNode;

            // Skip the repeated population of child items when every time the node expands.
            if (node.ChildNodes.Count > 0)
            {
                node.IsExpanded = true;
                return;
            }
            var treeView = Application.Current.MainWindow.FindName("treeView") as SfTreeView;
            var item = node.Content as Model;

            //Animation starts for expander to show progressing of load on demand
            node.ShowExpanderAnimation = true;

            treeView.Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle,
                new Action(() =>
                {
                    if (items != null)
                    {
                        var childItems = GetChildItems(item);
                        node.PopulateChildNodes(childItems);
                        if (childItems.Count > 0)
                            node.IsExpanded = true;



            //Stop the animation after load on demand is executed, if animation not stopped, it remains still after execution of load on demand.
            node.ShowExpanderAnimation = false;
                    }
                }));
        }

        private bool CanExecuteClickCommand(object sender)
        {
            return true;
        }

        private void ExecuteClickAction(object obj)
        {
            var loadingBtn = obj as Button;
            loadingBtn.Visibility = Visibility.Collapsed;

            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
            treeView = Application.Current.MainWindow.FindName("treeView") as SfTreeView;
            busyIndicator = Application.Current.MainWindow.FindName("loadingIndicator") as SfBusyIndicator;
            busyIndicator.IsBusy = true;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.treeView.ItemsSource = this.Items;
            var node = this.treeView.Nodes[0];
            ExpandNodes(node);
            this.treeView.Visibility = Visibility.Visible;
            this.busyIndicator.IsBusy = false;
            this.busyIndicator.Visibility = Visibility.Collapsed;
        }

        private void ExpandNodes(TreeViewNode node)
        {
            if (node.HasChildNodes)
                this.treeView.ExpandNode(node);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            PopulateCollection(100000);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
