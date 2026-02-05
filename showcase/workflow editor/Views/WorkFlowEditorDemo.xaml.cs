#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Windows.Controls;

namespace syncfusion.workfloweditor.wpf
{
    /// <summary>
    /// Interaction logic for WorkFlowEditorDemo.xaml
    /// </summary>
    public partial class WorkFlowEditorDemo : ChromelessWindow
    {
        public WorkFlowEditorDemo()
        {
            InitializeComponent();            
            this.Template = this.Resources["ChromelessWindowTemplate"] as ControlTemplate;

            //DataContext for syncfusion.workfloweditor.wpf
            ProcessAutomationViewModel VM = new ProcessAutomationViewModel();
            VM.GoBack = new DelegateCommand<object>(OnGoBack);
            this.DataContext = VM;
        }

        private void OnGoBack(object parameter)
        {
            ProcessAutomationViewModel VM = this.DataContext as ProcessAutomationViewModel;
            VM.GoBack = null;
            this.DataContext = null;            
        }
    }
}
