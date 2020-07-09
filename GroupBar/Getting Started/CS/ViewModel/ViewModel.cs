#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Windows;

namespace GroupBarDemo
{
    /// <summary>
    /// Represents a viewmodel for groupbar control. 
    /// </summary>
    public class ViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the selected modes.
        /// </summary>
        private string selectedModeproperty;

        /// <summary>
        /// Maintains the visibility.
        /// </summary>
        private Visibility allowCollapseTextVisibility;

        /// <summary>
        /// Maintains the visibility for allow collapse checkbox.
        /// </summary>
        private Visibility allowCollapseCheckBoxVisibility;

        /// <summary>
        /// Maintains the command for visual mode.
        /// </summary>
        private ICommand visualMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>   
        public ViewModel()
        {
            selectedModeproperty = "StackMode";
            visualMode = new DelegateCommand<object>(HideAllowCollapse);
        }

        /// <summary>
        /// Gets or sets the command for hiding allow collapse option when default, multi expansion mode is selected <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand VisualModeCommand
        {
            get
            {
                return visualMode;
            }
        }

        /// <summary>
        /// Gets or sets the selected modes <see cref="GettingStartedDemosViewModel"/> class.
        /// </summary>
        public string SelectedModeProperty
        {
            get { return selectedModeproperty; }
            set { selectedModeproperty = value; RaisePropertyChanged("SelectedModeproperty"); }
        }

        /// <summary>
        /// Gets or sets the visibility for allow collapse option <see cref="GettingStartedDemosViewModel"/> class.
        /// </summary>
        public Visibility AllowCollapseTextVisibility
        {
            get { return allowCollapseTextVisibility; }
            set { allowCollapseTextVisibility = value; RaisePropertyChanged("AllowCollapseTextVisibility"); }
        }

        /// <summary>
        /// Gets or sets the visibility for allow collapse option <see cref="GettingStartedDemosViewModel"/> class.
        /// </summary>
        public Visibility AllowCollapseCheckBoxVisibility
        {
            get { return allowCollapseCheckBoxVisibility; }
            set { allowCollapseCheckBoxVisibility = value; RaisePropertyChanged("AllowCollapseCheckBoxVisibility"); }
        }

        /// <summary>
        /// Method use to execute the visualMode command.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void HideAllowCollapse(object parameter)
        {
            if (SelectedModeProperty == "Default" || SelectedModeProperty == "MultipleExpansion")
            {
                AllowCollapseTextVisibility = System.Windows.Visibility.Hidden;
                AllowCollapseCheckBoxVisibility = System.Windows.Visibility.Hidden;
            }
            else if (SelectedModeProperty == "StackMode")
            {
                AllowCollapseTextVisibility = System.Windows.Visibility.Visible;
                AllowCollapseCheckBoxVisibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
