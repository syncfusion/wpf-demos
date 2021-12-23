#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.brainstormingdiagram.wpf.Utility;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.brainstormingdiagram.wpf.ViewModel
{
    public class MessageBoxWindowViewModel
    {
        public MessageBoxWindowViewModel(MindMapViewModel mindMapViewModel)
        {
            MindMapViewModel = mindMapViewModel;
        }
        /// <summary>
        /// Gets applications diagram builder vm.
        /// </summary>
        public MindMapViewModel MindMapViewModel { get; private set; }
        DelegateCommand<object> okCommand;
        public DelegateCommand<object> OkCommand
        {
            get
            {
                return okCommand ??
                    (okCommand = new DelegateCommand<object>(OkCommandExecute));
            }
        }

        /// <summary>
        /// Method will execute when OkCommand executed
        /// </summary>
        private void OkCommandExecute(object obj)
        {
            MindMapViewModel.OpenCloseWindowBehavior.OpenMessageBoxWindow = false;
        }
    }
}
