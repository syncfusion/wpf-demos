#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class ExpandandCollapseViewModel : DiagramViewModel
    {
        private ICommand _ExpandCollapseCommand;
        public ExpandandCollapseViewModel()
        {
            // Initialize Diagram properties
            Constraints = Constraints.Remove(GraphConstraints.PageEditing, GraphConstraints.PanRails);
            Constraints = Constraints.Add(GraphConstraints.Commands);
            Menu = null;
            DefaultConnectorType = ConnectorType.Orthogonal;
            Tool = Tool.ZoomPan;

            //Initialize Commands
            ExpandCollapseCommand = new DelegateCommand(OnExpandCollaseCommand);

            // Initialize DataSourceSettings for SfDiagram

            DataSourceSettings = new DataSourceSettings()
            {
                ParentId = "ParentId",
                Id = "Id",
                DataSource = Getdata(),
            };

            // Initialize LayoutSettings for SfDiagram
            LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = LayoutType.Organization,
                },
            };

            ItemAddedCommand = new DelegateCommand(OnItemAdded);
        }

        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;
            if (args.Item is NodeViewModel)
            {
                (args.Item as NodeViewModel).Annotations = null;
            }
        }

        #region Commands

        public ICommand ExpandCollapseCommand
        {
            get { return _ExpandCollapseCommand; }
            set
            {
                if (_ExpandCollapseCommand != value)
                {
                    _ExpandCollapseCommand = value;
                }
            }
        }

        #endregion

        #region Helper Methods
        /// <summary>
        /// The method to execute the expand and collapse operation.
        /// </summary>
        /// <param name="args">The parent node to be expanded or collapsed</param>
        private void OnExpandCollaseCommand(object args)
        {
            if (args is Node && (args as Node).DataContext is NodeViewModel)
            {
                ExpandCollapseParameter obj = new ExpandCollapseParameter();
                obj.Node = (args as Node).DataContext as NodeViewModel;
                obj.IsUpdateLayout = true;
                IGraphInfo graphinfo = Info as IGraphInfo;
                if (((args as Node).DataContext as NodeViewModel).IsExpanded)
                {
                    graphinfo.Commands.ExpandCollapse.Execute(obj);
                    ((args as Node).DataContext as NodeViewModel).IsExpanded = false;
                    ((args as Node).Content as ExpandandCollapseModel).IsExpand = State.Collapse;
                }
                else
                {
                    graphinfo.Commands.ExpandCollapse.Execute(obj);
                    ((args as Node).DataContext as NodeViewModel).IsExpanded = true;
                    ((args as Node).Content as ExpandandCollapseModel).IsExpand = State.Expand;
                }
            }
        }

        /// <summary>
        /// Method to Get the data for DataSource
        /// </summary>
        /// <param name="employee"></param>
        private ExpandandCollapseModels Getdata()
        {
            ExpandandCollapseModels employee = new ExpandandCollapseModels();

            employee.Add(new ExpandandCollapseModel() { Id = "1", Designation = "Board", RatingColor = "#71AF17", IsRoot = true });

            employee.Add(new ExpandandCollapseModel() { Id = "2", Designation = "General Manager", RatingColor = "#13ab11", ParentId = "1", IsRoot = true });

            employee.Add(new ExpandandCollapseModel() { Id = "3", Designation = "Human Resource\n Manager", RatingColor = "#1859B7", ParentId = "2", IsRoot = true });

            employee.Add(new ExpandandCollapseModel() { Id = "4", Designation = "Design Manager", RatingColor = "#1859B7", ParentId = "2", IsRoot = true });

            employee.Add(new ExpandandCollapseModel() { Id = "5", Designation = "Operations Manager", RatingColor = "#1859B7", ParentId = "2", IsRoot = true });

            employee.Add(new ExpandandCollapseModel() { Id = "6", Designation = "Marketing Manager", RatingColor = "#1859B7", ParentId = "2", IsRoot = true });

            employee.Add(new ExpandandCollapseModel() { Id = "6", Designation = "Trainers", RatingColor = "#2E95D8", ParentId = "3" });

            employee.Add(new ExpandandCollapseModel() { Id = "7", Designation = "Recruiting Team", RatingColor = "#2E95D8", ParentId = "3" });

            employee.Add(new ExpandandCollapseModel() { Id = "8", Designation = "Design Supervisor", RatingColor = "#2E95D8", ParentId = "4" });

            employee.Add(new ExpandandCollapseModel() { Id = "9", Designation = "Development \nSupervisor", RatingColor = "#2E95D8", ParentId = "4" });

            employee.Add(new ExpandandCollapseModel() { Id = "10", Designation = "Statistics Department", RatingColor = "#2E95D8", ParentId = "5" });

            employee.Add(new ExpandandCollapseModel() { Id = "11", Designation = "Logistics Department", RatingColor = "#2E95D8", ParentId = "5" });

            employee.Add(new ExpandandCollapseModel() { Id = "12", Designation = "Overseas Sales \nManager", RatingColor = "#2E95D8", ParentId = "6" });

            employee.Add(new ExpandandCollapseModel() { Id = "13", Designation = "Service Department \nManager", RatingColor = "#2E95D8", ParentId = "6" });

            return employee;
        }

        #endregion
    }

    public class BoolToVisibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? val = value as bool?;
            if (val == true)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (Visibility)value;

            if (val == Visibility.Visible)
            {
                return true; ;

            }
            return false;

        }

    }

    public class EnumtoBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object val = Enum.ToObject(typeof(State), value);
            if (value.ToString() == State.Expand.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
