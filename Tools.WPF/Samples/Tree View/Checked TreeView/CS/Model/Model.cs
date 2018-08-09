#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace CheckedTreeView
{
    public class Model : NotificationObject
    {
        public Model()
        {
            CheckedItems = new List<Model>();
            UnCheckedItems = new List<Model>();
            Models = new ObservableCollection<Model>();            
            Models.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Models_CollectionChanged);
        }

        void Models_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Model model in e.NewItems)
                {
                    model.Parent = this;
                }
            }
        }

        private string caption=string.Empty;

        public string Caption
        {
            get 
            { 
                return caption; 
            }
            set
            {
                caption = value;
                this.RaisePropertyChanged(() => this.Caption);                
            }
        }

        private bool? isChekced=null;

        public bool? IsChecked
        {
            get 
            { 
                return isChekced; 
            }
            set
            {
                isChekced= value;
                this.RaisePropertyChanged(() => this.IsChecked);
                OnCheckedChanged(this);
            }
        }

        private ObservableCollection<Model> models=null;

        public ObservableCollection<Model> Models
        {
            get 
            {
                return models; 
            }
            set 
            { 
                models = value;
                this.RaisePropertyChanged(() => this.Models);
            }
        }
        

      
        internal List<Model> CheckedItems;

        internal List<Model> UnCheckedItems;

        internal Model Parent;      

        private void OnCheckedChanged(object sender)
        {
            Model instance = sender as Model;

            if (instance.IsChecked.HasValue && instance.IsChecked.Value)
            {
                if (instance.Parent != null && instance.Parent.UnCheckedItems.Contains(instance))
                {
                    instance.Parent.UnCheckedItems.Remove(instance);
                }
                if (instance.Parent != null && !instance.Parent.CheckedItems.Contains(instance))
                {
                    instance.Parent.CheckedItems.Add(instance);
                    if (instance.Parent.CheckedItems.Count == instance.Parent.Models.Count)
                    {
                        instance.Parent.IsChecked = true;
                    }
                }
                
                foreach (Model model in instance.Models)
                {
                    model.IsChecked = true;
                }
            }

            if (instance.IsChecked.HasValue && !instance.IsChecked.Value)
            {
                if (instance.Parent != null && instance.Parent.CheckedItems.Contains(instance))
                {
                    instance.Parent.CheckedItems.Remove(instance);
                }
                if (instance.Parent != null && !instance.Parent.UnCheckedItems.Contains(instance))
                {
                    instance.Parent.UnCheckedItems.Add(instance);
                    if (instance.Models != null && instance.Models.Count > 0)
                    {
                        foreach (Model model in instance.Models)
                        {
                            model.IsChecked = false;
                        }
                    }
                    if (instance.Parent != null && instance.Parent.UnCheckedItems.Count == instance.Parent.Models.Count)
                    {
                        instance.Parent.IsChecked = false;
                    }
                }

                foreach (Model model in instance.Models)
                {
                    if(sender == Parent || model.IsChecked != true)
                    model.IsChecked = false;
                }
            }

            if (instance.Parent != null && instance.Parent.CheckedItems.Count != 0 && instance.Parent.UnCheckedItems.Count != 0)
            {
                instance.Parent.IsChecked = null;
            }
            
        }
    }
}
