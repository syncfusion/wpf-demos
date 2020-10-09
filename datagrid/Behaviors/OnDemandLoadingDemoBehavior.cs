#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Syncfusion.Data;
using Syncfusion.Data.Extensions;
using Syncfusion.UI.Xaml.Controls.DataPager;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.datagriddemos.wpf
{
    public class OnDemandLoadingDemoBehavior : Behavior<OnDemandPagingDemo>
    {
        private EmployeeInfoViewModel viewmodel;
        private List<EmployeeInfo> source;
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnAssociateObjectLoad;
            viewmodel = new EmployeeInfoViewModel();
            source = viewmodel.GetEmployeesList(1800);
        }
        
        void OnAssociateObjectLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            AssociatedObject.sfDataPager.OnDemandLoading += OnDemandLoading;
            AssociatedObject.dataGrid.SortColumnsChanging += OnSortColimnChanging;
            AssociatedObject.sfDataPager.MoveToFirstPage();
        }

        private void OnSortColimnChanging(object sender, Syncfusion.UI.Xaml.Grid.GridSortColumnsChangingEventArgs e)
        {
            (this.AssociatedObject.sfDataPager.PagedSource as PagedCollectionView).ResetCache();
            (this.AssociatedObject.sfDataPager.PagedSource as PagedCollectionView).ResetCacheForPage(this.AssociatedObject.sfDataPager.PageIndex);
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                var sortDesc = e.AddedItems[0];
                if (sortDesc.SortDirection == ListSortDirection.Ascending)
                {
                    source = source.OfQueryable().AsQueryable().OrderBy(sortDesc.ColumnName).Cast<EmployeeInfo>().ToList();
                }
                else
                {
                    source =
                        source.OfQueryable()
                              .AsQueryable()
                              .OrderByDescending(sortDesc.ColumnName)
                              .Cast<EmployeeInfo>()
                              .ToList();
                }
                this.AssociatedObject.sfDataPager.MoveToPage(this.AssociatedObject.sfDataPager.PageIndex);
            }
        }

        void OnDemandLoading(object sender, OnDemandLoadingEventArgs args)
        {
            AssociatedObject.sfDataPager.LoadDynamicItems(args.StartIndex,source.Skip(args.StartIndex).Take(args.PageSize));
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= OnAssociateObjectLoad;
            AssociatedObject.sfDataPager.OnDemandLoading -= OnDemandLoading;
            AssociatedObject.dataGrid.SortColumnsChanging -= OnSortColimnChanging;
        }
    }
}
