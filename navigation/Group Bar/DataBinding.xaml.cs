#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System.Windows.Data;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class GroupBarDataBinding : DemoControl
    {
        public GroupBarDataBinding()
        {
            InitializeComponent();
        }

        public GroupBarDataBinding(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
	    // Release all managed resources
	    if (this.Resources != null)
		this.Resources.Clear();
            if (this.group_Bar != null)
            {
                if (Interaction.GetBehaviors(this.group_Bar) != null)
                    Interaction.GetBehaviors(this.group_Bar).Clear();
                if (Interaction.GetTriggers(this.group_Bar) != null)
                    Interaction.GetTriggers(this.group_Bar).Clear();
                this.group_Bar.ItemsSource = null;
                this.group_Bar.ItemContainerStyle = null;
                this.group_Bar.Dispose();
                this.group_Bar = null;
            }

            if (this.selectOrientation != null)
            {
                BindingOperations.ClearAllBindings(this.selectOrientation);
                if (Interaction.GetBehaviors(this.selectOrientation) != null)
                    Interaction.GetBehaviors(this.selectOrientation).Clear();
                if (Interaction.GetTriggers(this.selectOrientation) != null)
                    Interaction.GetTriggers(this.selectOrientation).Clear();
                this.selectOrientation = null;
            }

            if (this.selectVisualMode != null)
            {
                BindingOperations.ClearAllBindings(this.selectVisualMode);
                if (Interaction.GetBehaviors(this.selectVisualMode) != null)
                    Interaction.GetBehaviors(this.selectVisualMode).Clear();
                if (Interaction.GetTriggers(this.selectVisualMode) != null)
                    Interaction.GetTriggers(this.selectVisualMode).Clear();
                this.selectVisualMode = null;
            }

            if (this.userName != null)
            {
                BindingOperations.ClearAllBindings(this.userName);
                this.userName = null;
            }

            if (this.enableContextMenu != null)
        	this.enableContextMenu = null;
    	    if (this.allowCollapse != null)
        	this.allowCollapse = null;
	    if (this.orientationTextBlock != null)
            	this.orientationTextBlock = null;
	    if (this.visualModeTextBlock != null)
            	this.visualModeTextBlock = null;
	    if (this.selectedItemTextBlock != null)
            	this.selectedItemTextBlock = null;
            BindingOperations.ClearAllBindings(this);
            if (Interaction.GetBehaviors(this) != null)
                Interaction.GetBehaviors(this).Clear();
            if (Interaction.GetTriggers(this) != null)
                Interaction.GetTriggers(this).Clear();
            this.DataContext = null;
            base.Dispose(disposing);
        }

    }
}
