#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainstorming.ViewModel
{
    public class MultipleSubTopicViewModel : DiagramElementViewModel
    {
        #region Constructor
        public MultipleSubTopicViewModel(BrainstormingBuilderVM diagramBuilderVM)
        {
            DiagramBuilderVM = diagramBuilderVM;
        }
        #endregion
        #region Public Properties
        private object selectedItem = "Topic 1";
        /// <summary>
        /// Gets or sets text to add multiple sub topics
        /// </summary>
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        /// <summary>
        /// Gets applications diagram builder vm.
        /// </summary>
        public BrainstormingBuilderVM DiagramBuilderVM { get; private set; }
        #endregion
        #region Public Command
        DelegateCommand<object> okCommand;
        DelegateCommand<object> cancelCommand;
        public DelegateCommand<object> OkCommand
        {
            get
            {
                return okCommand ??
                    (okCommand = new DelegateCommand<object>(OkCommandExecute));
            }
        }
        public DelegateCommand<object> CancelCommand
        {
            get
            {
                return cancelCommand ??
                    (cancelCommand = new DelegateCommand<object>(CancelCommandExecute));
            }
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Method will execute when CancelCommand executed
        /// </summary>
        private void CancelCommandExecute(object obj)
        {
            DiagramBuilderVM.OpenCloseWindowBehavior.OpenMultipleSubTopicWindow = false;
        }
        /// <summary>
        /// Method will execute when OkCommand executed
        /// </summary>
        private void OkCommandExecute(object obj)
        {
            (DiagramBuilderVM.SelectedDiagram as Brainstorming.ViewModel.BrainstormingVM).AddMultipleSubTopics(SelectedItem.ToString(), DiagramBuilderVM.SubTopicCommand);
            DiagramBuilderVM.OpenCloseWindowBehavior.OpenMultipleSubTopicWindow = false;
        }
        #endregion
    }
}
