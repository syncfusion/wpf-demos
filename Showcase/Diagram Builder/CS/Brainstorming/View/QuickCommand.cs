#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Brainstorming.View
{
    public class QuickCommand : Syncfusion.UI.Xaml.Diagram.QuickCommand
    {
        static QuickCommand()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuickCommand), new FrameworkPropertyMetadata(typeof(QuickCommand)));
        }

        public QuickCommand()
        {
            this.MouseEnter += QuickCommand_MouseEnter;
            this.MouseLeave += QuickCommand_MouseLeave;
            this.MouseLeftButtonDown += QuickCommand_MouseLeftButtonDown;
        }

        private void QuickCommand_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VisualStateManager.GoToState(this, "Pressed", true);
        }

        private void QuickCommand_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "Normal", true);
        }

        private void QuickCommand_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "PointerOver", true);
        }
    }
}
