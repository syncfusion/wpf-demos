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

namespace syncfusion.treeviewdemos.wpf
{
    public class PerformanceViewModel : INotifyPropertyChanged
    {
        #region Constructor
        public PerformanceViewModel()
        {
            ClickCommand = new OnDemandCommand(ExecuteClickAction, CanExecuteClickCommand);
            TreeViewOnDemandCommand = new OnDemandCommand(ExecuteOnDemandLoading, CanExecuteOnDemandLoading);
        }
        #endregion

        #region Properties

        private Visibility visibility;

        /// <summary>
        /// Gets or sets the visibility of SfBusyIndicator.
        /// </summary>
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                RaisePropertyChanged("Visibility");
            }
        }

        private bool isBusy= false;

        /// <summary>
        /// Gets or sets the value that indicating IsBusy status in SfBusyIndicator.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        private Visibility treeViewVisibility = Visibility.Collapsed;

        /// <summary>
        /// Gets or sets the visibility of SfTreeView.
        /// </summary>
        public Visibility TreeViewVisibility
        {
            get { return treeViewVisibility; }
            set
            {
                treeViewVisibility = value;
                RaisePropertyChanged("TreeViewVisibility");
            }
        }

        private Visibility buttonVisibility;

        /// <summary>
        /// Gets or sets the visibility of Button.
        /// </summary>
        public Visibility ButtonVisibility
        {
            get { return buttonVisibility; }
            set
            {
                buttonVisibility = value;
                RaisePropertyChanged("ButtonVisibility");
            }
        }

        private ObservableCollection<Model> items = new ObservableCollection<Model>();
        public ObservableCollection<Model> Items
        {
            get { return items; }
            set { items = value; this.RaisePropertyChanged("Items"); }
        }

        #endregion

        #region Command

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

        #endregion

        #region Methods 

        private ObservableCollection<Model> GetCollection(int count)
        {
            ObservableCollection<Model> collection = new ObservableCollection<Model>();
            for (int i = 0; i < count; i++)
            {
                collection.Add(new Model() { Header = "Module " + (i + 1) });
            }

            return collection;
        }

        private ObservableCollection<Model> GetChildItems(Model item)
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
            var item = node.Content as Model;

            //Animation starts for expander to show progressing of load on demand
            node.ShowExpanderAnimation = true;

            Application.Current.MainWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                new Action(() =>
                {
                    var childItems = GetChildItems(item);
                    node.PopulateChildNodes(childItems);
                    if (childItems.Count > 0)
                        node.IsExpanded = true;
                    //Stop the animation after load on demand is executed, if animation not stopped, it remains still after execution of load on demand.
                    node.ShowExpanderAnimation = false;
                }));
        }

        private bool CanExecuteClickCommand(object sender)
        {
            return true;
        }

        private void ExecuteClickAction(object obj)
        {
            this.ButtonVisibility = Visibility.Collapsed;
            this.IsBusy = true;

            Application.Current.MainWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background,
               new Action(() =>
               {
                   this.Items = GetCollection(100000); ;
                   this.TreeViewVisibility = Visibility.Visible;
                   this.IsBusy = false;
                   this.Visibility = Visibility.Collapsed;
               }));
        } 

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
