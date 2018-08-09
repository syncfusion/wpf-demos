using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortfolioAnalyzer.Model;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using PortfolioAnalyzer.Infrastructure;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using Syncfusion.Windows.Data;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Input;

namespace PortfolioAnalyzer.PortfolioGridModule
{

    public class GridQueryCellStyleInfoBehavior : CommandBehaviorBase<GridDataControl>
    {
        public GridQueryCellStyleInfoBehavior(GridDataControl control)
            : base(control)
        {
            control.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }

        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            CommandParameter = e;
            ExecuteCommand();
        }
    }

    public static class GridQueryCellStyleInfo
    {
        private static readonly DependencyProperty GridQueryCellStyleInfoBehaviorProperty
            = DependencyProperty.RegisterAttached(
            "GridQueryCellStyleInfoBehavior",
            typeof(GridQueryCellStyleInfoBehavior),
            typeof(GridQueryCellStyleInfo),
            null);

        public static readonly DependencyProperty CommandProperty
            = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(GridQueryCellStyleInfo),
            new PropertyMetadata(OnSetCommandCallback));

        public static readonly DependencyProperty CommandParameterProperty
            = DependencyProperty.RegisterAttached(
           "CommandParameter",
           typeof(object),
           typeof(GridQueryCellStyleInfo),
           new PropertyMetadata(OnSetCommandParameterCallback));

        public static ICommand GetCommand(GridDataControl control)
        {
            return control.GetValue(CommandProperty) as ICommand;
        }

        public static void SetCommand(GridDataControl control, ICommand command)
        {
            control.SetValue(CommandProperty, command);
        }

        public static void SetCommandParameter(GridDataControl control, object parameter)
        {
            control.SetValue(CommandParameterProperty, parameter);
        }

        public static object GetCommandParameter(GridDataControl control)
        {
            return control.GetValue(CommandParameterProperty);
        }

        private static void OnSetCommandCallback
            (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            GridDataControl control = dependencyObject as GridDataControl;
            if (control != null)
            {
                GridQueryCellStyleInfoBehavior behavior = GetOrCreateBehavior(control);
                behavior.Command = e.NewValue as ICommand;
            }
        }

        private static void OnSetCommandParameterCallback
            (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            GridDataControl control = dependencyObject as GridDataControl;
            if (control != null)
            {
                GridQueryCellStyleInfoBehavior behavior = GetOrCreateBehavior(control);
                behavior.CommandParameter = e.NewValue;
            }
        }

        private static GridQueryCellStyleInfoBehavior GetOrCreateBehavior(GridDataControl control)
        {
            GridQueryCellStyleInfoBehavior behavior =
                control.GetValue(GridQueryCellStyleInfoBehaviorProperty) as GridQueryCellStyleInfoBehavior;
            if (behavior == null)
            {
                behavior = new GridQueryCellStyleInfoBehavior(control);
                control.SetValue(GridQueryCellStyleInfoBehaviorProperty, behavior);
            }
            return behavior;
        }
    }





    public class GridItemsSourceChangedBehavior : CommandBehaviorBase<GridDataControl>
    {
        public GridItemsSourceChangedBehavior(GridDataControl control)
            : base(control)
        {
            control.ItemsSourceChanged += new Syncfusion.Windows.ComponentModel.GridRoutedEventHandler(control_ItemsSourceChanged);
        }

        void control_ItemsSourceChanged(object sender, Syncfusion.Windows.ComponentModel.SyncfusionRoutedEventArgs args)
        {
            CommandParameter = args;
            ExecuteCommand();
        }        
    }

    public static class GridItemsSourceChanged
    {
        private static readonly DependencyProperty GridItemsSourceChangedBehaviorProperty
            = DependencyProperty.RegisterAttached(
            "GridQueryCellStyleInfoBehavior",
            typeof(GridItemsSourceChangedBehavior),
            typeof(GridItemsSourceChanged),
            null);

        public static readonly DependencyProperty CommandProperty
            = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(GridItemsSourceChanged),
            new PropertyMetadata(OnSetCommandCallback));

        public static readonly DependencyProperty CommandParameterProperty
            = DependencyProperty.RegisterAttached(
           "CommandParameter",
           typeof(object),
           typeof(GridItemsSourceChanged),
           new PropertyMetadata(OnSetCommandParameterCallback));

        public static ICommand GetCommand(GridDataControl control)
        {
            return control.GetValue(CommandProperty) as ICommand;
        }

        public static void SetCommand(GridDataControl control, ICommand command)
        {
            control.SetValue(CommandProperty, command);
        }

        public static void SetCommandParameter(GridDataControl control, object parameter)
        {
            control.SetValue(CommandParameterProperty, parameter);
        }

        public static object GetCommandParameter(GridDataControl control)
        {
            return control.GetValue(CommandParameterProperty);
        }

        private static void OnSetCommandCallback
            (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            GridDataControl control = dependencyObject as GridDataControl;
            if (control != null)
            {
                GridItemsSourceChangedBehavior behavior = GetOrCreateBehavior(control);
                behavior.Command = e.NewValue as ICommand;
            }
        }

        private static void OnSetCommandParameterCallback
            (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            GridDataControl control = dependencyObject as GridDataControl;
            if (control != null)
            {
                GridItemsSourceChangedBehavior behavior = GetOrCreateBehavior(control);
                behavior.CommandParameter = e.NewValue;
            }
        }

        private static GridItemsSourceChangedBehavior GetOrCreateBehavior(GridDataControl control)
        {
            GridItemsSourceChangedBehavior behavior =
                control.GetValue(GridItemsSourceChangedBehaviorProperty) as GridItemsSourceChangedBehavior;
            if (behavior == null)
            {
                behavior = new GridItemsSourceChangedBehavior(control);
                control.SetValue(GridItemsSourceChangedBehaviorProperty, behavior);
            }
            return behavior;
        }
    }
}
