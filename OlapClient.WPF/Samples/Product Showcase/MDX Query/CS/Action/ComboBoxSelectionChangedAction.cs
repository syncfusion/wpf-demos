#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace MdxQuery.Action
{
    using System;
    using Syncfusion.Windows.Client.Olap;
    using System.Windows.Interactivity;
    using System.Windows.Controls;
    using Mdx_Query.ViewModel;
    class ComboBoxSelectionChangedAction : TargetedTriggerAction<OlapClient>, IDisposable
    {
        ViewModel viewModel = new ViewModel();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void Invoke(object parameter)
        {
            if (parameter is SelectionChangedEventArgs)
            {
                ComboBox targetBox = (parameter as SelectionChangedEventArgs).OriginalSource as ComboBox;
                if (this.Target != null && this.Target.DataContext is ViewModel)
                {
                    viewModel = this.Target.DataContext as ViewModel;
                }
                if (targetBox != null && this.Target != null)
                {
                    switch (targetBox.SelectedIndex)
                    {
                        case 0:
                            viewModel.CurrentMDXQuery = viewModel.SimpleDimensions();
                            break;

                        case 1:
                            viewModel.CurrentMDXQuery = viewModel.HierarchyandLevels();
                            break;

                        case 2:
                            viewModel.CurrentMDXQuery = viewModel.MultipleSeriesDimensions();
                            break;
                        
                        case 3:
                            viewModel.CurrentMDXQuery = viewModel.MultipleMeasuresInSeries();
                            break;
                        
                        case 4:
                            viewModel.CurrentMDXQuery = viewModel.SlicingByMeasures();
                            break;
                       
                        case 5:
                            viewModel.CurrentMDXQuery = viewModel.SlicingByDimensions();
                            break;
                        
                        case 6:
                            viewModel.CurrentMDXQuery = viewModel.FilteredDimensions();
                            break;

                        default:
                            break;
                    }
                    viewModel.ExecuteMDX();
                    this.Target.OlapDataManager = viewModel.ClientDataManager;
                    this.Target.DataBind();
                }
            }
            if (parameter is System.Windows.RoutedEventArgs&&!( parameter is SelectionChangedEventArgs))
            {
                CheckBox targetBox = (parameter as System.Windows.RoutedEventArgs).OriginalSource as CheckBox;
                if (this.Target != null && this.Target.DataContext is ViewModel)
                {
                    viewModel = this.Target.DataContext as ViewModel;
                }
                viewModel.ExecuteMDX();
                this.Target.OlapDataManager = viewModel.ClientDataManager;
                this.Target.DataBind();
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                viewModel.Dispose();
        }
    }
}
