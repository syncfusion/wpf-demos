#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;

namespace TreeViewAdvConfigurationDemo
{
    public class ViewModel : NotificationObject
    {
        static BrushConverter brushConverter= new BrushConverter();

        private ICommand selectedItemChangedCommand;
        public ICommand
           SelectedItemChangedCommand
        {
            get
            {
                return selectedItemChangedCommand;
            }
            set
            {
                selectedItemChangedCommand = value;
            }
        }

        private ICommand treeViewAdvDragStartCommand;
        public ICommand
           TreeViewAdvDragStartCommand
        {
            get
            {
                return treeViewAdvDragStartCommand;
            }
            set
            {
                treeViewAdvDragStartCommand = value;
            }
        }

        private ICommand treeViewAdvDragEndCommand;
        public ICommand
           TreeViewAdvDragEndCommand
        {
            get
            {
                return treeViewAdvDragEndCommand;
            }
            set
            {
                treeViewAdvDragEndCommand = value;
            }
        }

        public void SelectedItemChanged(object param)
        {
            Model model = param as Model;
            if(model !=null)
            coll.Add("SelectedItem Changed : " + model.Header);
            EventLogsCollection = coll;
        }

        public void DragStart(object param)
        {            
            coll.Add("DragStart");
            EventLogsCollection = coll;
        }

        public void DragEnd(object param)
        {
            coll.Add("DragEnd");
            EventLogsCollection = coll;
        }

        private ObservableCollection<string> eventLogsCollection;

        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set
            {
                eventLogsCollection = value;
                this.RaisePropertyChanged(() => this.EventLogsCollection);
            }
        }

        ObservableCollection<string> coll = new ObservableCollection<string>();
       
        private ObservableCollection<Model> modelItems;
        public ObservableCollection<Model> ModelItems
        {
            get
            {
                return modelItems;
            }

            set
            {
                modelItems = value;
                this.RaisePropertyChanged(() => this.ModelItems);
            }
        }

        private bool allowMultiSelect=true;
        /// <summary>
        /// Gets or sets a value indicating whether to allow select multiple TreeViewItems.
        /// </summary>        
        public bool AllowMultiSelect
        {
            get
            {
                return allowMultiSelect;
            }

            set
            {
                allowMultiSelect = value;
                this.RaisePropertyChanged(() => this.AllowMultiSelect);
            }
        }

        private bool allowDragDrop;
        /// <summary>
        /// Gets or sets a value indicating whether to allow drag and drop operation for TreeViewAdv.
        /// </summary>        
        public bool AllowDragDrop
        {
            get
            {
                return allowDragDrop;
            }

            set
            {
                allowDragDrop = value;
                this.RaisePropertyChanged(() => this.AllowDragDrop);
            }
        }        
       
        private string animationType = "None";
        /// <summary>
        /// Gets or sets a value indicating type of the animation used for expanding the TreeViewItemAdv.
        /// </summary>        
        public string AnimationType
        {
            get
            {
                return animationType;
            }

            set
            {
                animationType = value;
                this.RaisePropertyChanged(() => this.AnimationType);
            }
        }
    
        private bool showRootLines;
        /// <summary>
        /// Gets or sets a value indicating whether to rootlines in TreeViewAdv.
        /// </summary>        
        public bool ShowRootLines
        {
            get
            {
                return showRootLines;
            }

            set
            {
                showRootLines = value;
                this.RaisePropertyChanged(() => this.ShowRootLines);
            }
        }


        private object selectedItem;

        public object SelectedItem
        {
            get 
            { 
                return selectedItem; 
            }
            set 
            { 
                selectedItem = value;
                this.RaisePropertyChanged(() => this.SelectedItem);
            }
        }
     
        public ViewModel()
        {
            modelItems = new ObservableCollection<Model>();
            if (!DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                PopulateCollection();
                SelectedItem = ModelItems[0];
                selectedItemChangedCommand = new DelegateCommand<object>(SelectedItemChanged);
                treeViewAdvDragEndCommand = new DelegateCommand<object>(DragEnd);
                treeViewAdvDragStartCommand = new DelegateCommand<object>(DragStart);
            }
           
        }

        private void PopulateCollection(Model model, XElement element)
        {
            foreach (XElement ele in element.Descendants(XName.Get("Feature")))
            {
                Model mod = new Model() { Header = ele.FirstAttribute.Value, Description = ele.Attribute(XName.Get("Description")).Value.ToString() };
                model.Models.Add(mod);
            }
        }

        private void PopulateCollection()
        {
#if NETCORE
            XDocument doc = XDocument.Load(@"..\..\..\Products.xml");
#else
            XDocument doc = XDocument.Load("Products.xml");
#endif
            foreach (XElement element in doc.Descendants(XName.Get("Product")))
            {
                Model model = new Model() { Header = element.FirstAttribute.Value, Description = element.Attribute(XName.Get("Description")).Value.ToString() };
                PopulateCollection(model, element);
                ModelItems.Add(model);
            }
        }      
    }
}
