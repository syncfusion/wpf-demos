#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for HistoryManager.xaml
    /// </summary>
    public partial class HistoryManager : DemoControl
    {
        public HistoryManager()
        {
            InitializeComponent();
        }

        public HistoryManager(string themename) : base(themename)
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });

            Diagram.CommandManager.Commands.RemoveAt(2);
            Diagram.CommandManager.Commands.RemoveAt(1);
            Diagram.CommandManager.Commands.RemoveAt(0);

            ((Diagram.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).RemoveAt(2);
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).Content = "End Group Action";
            System.Windows.Input.Keyboard.Focus(this.Diagram);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).Content = "Start Group Action";
            System.Windows.Input.Keyboard.Focus(this.Diagram);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Diagram.Info as IGraphInfo).ClearHistory();
            UndoText.Text = "";
            RedoText.Text = "";
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            
            if (this.Diagram != null)
            {
                this.Diagram = null;
            }

            Part_FontColor.Dispose();
            Part_FillColor.Dispose();
            Part_StrokeColor.Dispose();

            base.Dispose(disposing);
        }
    }
}
