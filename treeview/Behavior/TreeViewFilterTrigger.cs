#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.TreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.treeviewdemos.wpf
{
    public class TreeViewFilterTrigger : TargetedTriggerAction<SfTreeView>
    {
        protected override void Invoke(object parameter)
        {
            var viewModel = this.Target.DataContext as FileManagerViewModel;
            viewModel.filterChanged += OnFilterChanged;
        }
        private void OnFilterChanged()
        {
            var viewModel = this.Target.DataContext as FileManagerViewModel;
            viewModel.CollectionView.Filter = (e) =>
            {
                FileManager file = e as FileManager;
                if ((file.FileName.ToLower()).Contains(viewModel.FilterText.ToLower()))
                    return true;
                if (file.SubFiles != null)
                {
                    foreach (var subFile in file.SubFiles)
                        if (subFile.FileName.ToLower().Contains(viewModel.FilterText.ToLower()))
                            return true;
                }
                return false;
            };
            this.Target.ExpandAll();
            
        }
    }
}
