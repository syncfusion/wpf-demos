#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.navigationdemos.wpf
{
    public class GroupBarGettingStartedViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the command for visual mode.
        /// </summary>
        private ICommand visualMode;

        /// <summary>
        /// Maintains the selected modes.
        /// </summary>
        private VisualMode selectedModeproperty;

        /// <summary>
        /// Maintains the visibility for allow collapse checkbox.
        /// </summary>
        private Visibility checkBoxVisibility;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupBarGettingStartedViewModel" /> class.
        /// </summary>   
        public GroupBarGettingStartedViewModel()
        {
            visualMode = new DelegateCommand<object>(HideAllowCollapse);
            selectedModeproperty = VisualMode.StackMode;
        }

        /// <summary>
        /// Gets or sets the command for hiding allow collapse option when default, multi expansion mode is selected <see cref="GroupBarGettingStartedViewModel"/> class.
        /// </summary>
        public ICommand VisualModeCommand
        {
            get
            {
                return visualMode;
            }
        }

        /// <summary>
        /// Gets or sets the selected modes <see cref="GroupBarGettingStartedViewModel"/> class.
        /// </summary>
        public VisualMode SelectedModeProperty
        {
            get
            {
                return selectedModeproperty;
            }
            set
            {
                selectedModeproperty = value;
                RaisePropertyChanged("SelectedModeproperty");
            }
        }

        /// <summary>
        /// Gets or sets the visibility for allow collapse option <see cref="GroupBarGettingStartedViewModel"/> class.
        /// </summary>
        public Visibility CheckBoxVisibility
        {
            get
            {
                return checkBoxVisibility;
            }
            set
            {
                checkBoxVisibility = value;
                RaisePropertyChanged("CheckBoxVisibility");
            }
        }

        /// <summary>
        /// Method use to execute the visualMode command.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void HideAllowCollapse(object parameter)
        {
            if (SelectedModeProperty == VisualMode.Default || SelectedModeProperty == VisualMode.MultipleExpansion)
            {
                CheckBoxVisibility = System.Windows.Visibility.Hidden;
            }
            else if (SelectedModeProperty == VisualMode.StackMode)
            {
                CheckBoxVisibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
