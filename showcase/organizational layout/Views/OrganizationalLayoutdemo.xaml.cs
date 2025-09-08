#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

namespace syncfusion.organizationallayout.wpf
{
    /// <summary>
    /// Interaction logic for FloorPlannerDemo.xaml
    /// </summary>
    public partial class organizationallayoutdemo : ChromelessWindow
    {
        public organizationallayoutdemo()
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
            Diagram.CommandManager.Commands.RemoveAt(5);
            Diagram.CommandManager.Commands.RemoveAt(4);
            Diagram.CommandManager.Commands.RemoveAt(3);
            Diagram.CommandManager.Commands.RemoveAt(2);

            if (this.DataContext != null)
            {
                (this.DataContext as organizationallayoutViewModel).View = this;
            }

            this.SizeChanged += FloorPlannerDemo_SizeChanged;
            this.Closing += FloorPlannerDemo_Closing;

            var ifLeft = SystemParameters.MenuDropAlignment;
            if (ifLeft)
            {
                var t = typeof(SystemParameters);
                var field = t.GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
                field.SetValue(null, false);
                ifLeft = SystemParameters.MenuDropAlignment;
            }
        }

        private void FloorPlannerDemo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.DataContext != null)
            {
                (this.DataContext as organizationallayoutViewModel).SaveCommand.Execute(null);
            }
        }

        private void FloorPlannerDemo_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            var count = Math.Round(e.NewSize.Width / 196);
            double marginLeft = (e.NewSize.Width - (((count > 3 ? count - 2 : count - 1) * 196) + 30)) * 0.5;
            this.BackStageArea.Margin = new Thickness(marginLeft, 48, marginLeft, 48);
        }
    }

    public class SymbolCollection : ObservableCollection<NodeViewModel>
    {

    }
}
