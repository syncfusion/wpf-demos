#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

        private bool? isChekced = false;

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
            var instance = sender as Model;

            if (instance.IsChecked.HasValue && instance.IsChecked.Value)
            {
                if (instance.Parent != null && instance.Parent.UnCheckedItems.Contains(instance))
                    instance.Parent.UnCheckedItems.Remove(instance);
                if (instance.Parent != null && !instance.Parent.CheckedItems.Contains(instance))
                {
                    instance.Parent.CheckedItems.Add(instance);

                    var parentNode1 = instance.Parent;
                    while (parentNode1.CheckedItems.Count == parentNode1.Models.Count)
                    {
                        parentNode1.IsChecked = true;
                        if (parentNode1.Parent == null)
                            break;
                        parentNode1 = parentNode1.Parent;
                    }


                    var parentNode = instance.Parent;
                    while (parentNode.CheckedItems.Count != parentNode.Models.Count)
                    {
                        parentNode.IsChecked = null;
                        if (parentNode.Parent == null)
                            break;
                        parentNode = parentNode.Parent;
                    }
                }

                foreach (var model in instance.Models)
                    model.IsChecked = true;
            }

            if (instance.IsChecked.HasValue && !instance.IsChecked.Value)
            {
                if (instance.Parent != null && instance.Parent.CheckedItems.Contains(instance))
                    instance.Parent.CheckedItems.Remove(instance);
                if (instance.Parent != null && !instance.Parent.UnCheckedItems.Contains(instance))
                {
                    instance.Parent.UnCheckedItems.Add(instance);
                    if (instance.Models != null && instance.Models.Count > 0)
                        foreach (var model in instance.Models)
                            model.IsChecked = false;
                    var parentNode = instance.Parent;
                    while (parentNode.UnCheckedItems.Count == parentNode.Models.Count)
                    {
                        parentNode.IsChecked = false;
                        if (parentNode.Parent == null)
                            break;
                        parentNode.Parent.CheckedItems.Remove(parentNode);
                        parentNode = parentNode.Parent;
                    }

                    var parentNode1 = instance.Parent;
                    while (parentNode1.UnCheckedItems.Count != parentNode1.Models.Count)
                    {
                        parentNode1.IsChecked = null;
                        if (parentNode1.Parent == null)
                            break;
                        parentNode1.Parent.CheckedItems.Remove(parentNode1);
                        parentNode1 = parentNode1.Parent;
                    }
                }
                else if (instance.Parent == null && instance.Models != null && instance.Models.Count > 0)
                {
                    foreach (var model in instance.Models)
                    {
                        model.IsChecked = false;
                        model.Parent.CheckedItems.Remove(model);
                    }
                }

                foreach (var model in instance.Models)
                    if (sender == Parent || model.IsChecked != true)
                    {
                        model.IsChecked = false;
                        model.Parent.CheckedItems.Remove(model);
                    }
            }
        }
    }
}
