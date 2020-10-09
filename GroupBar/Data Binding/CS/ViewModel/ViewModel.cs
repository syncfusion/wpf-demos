#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Syncfusion.Windows.Shared;

namespace ItemsSourceDemo
{
    /// <summary>
    /// Represents a viewmodel.
    /// </summary>
    public class ViewModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the collection for sample list.
        /// </summary>
        private ObservableCollection<Model> sampleList;

        /// <summary>
        /// Maintains the command for visual mode.
        /// </summary>
        private ICommand visualMode;

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
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            selectedModeproperty = "StackMode";
            SampleList = new ObservableCollection<Model>();
            visualMode = new DelegateCommand<object>(HideAllowCollapse);
            PopulateData();
        }

		/// <summary>
        /// Gets or sets the sample list <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> SampleList
        {
            get
            {
                return sampleList;
            }
            set
            {
                if (sampleList != value)
                    sampleList = value;
                RaisePropertyChanged("SampleList");
            }
        }

		/// <summary>
        /// Adding details to the sample list collection.
        /// </summary>  
        private void PopulateData()
        {
            SampleList.Add(new Model() { Name = "Buchanan", Age = "25", Location = "Washington D.C.", DateOfBirth = "02/25/1984", Image = "/Resources/Buchanan.png" });
            SampleList.Add(new Model() { Name = "Callahan", Age = "19", Location = "Costa Rica", DateOfBirth = "10/16/1990", Image = "/Resources/Callahan.png" });
            SampleList.Add(new Model() { Name = "Fuller", Age = "35", Location = "Carolina", DateOfBirth = "09/24/1970", Image = "/Resources/Fuller.png" });
            SampleList.Add(new Model() { Name = "Lever Ling", Age = "28", Location = "New York", DateOfBirth = "08/26/1985", Image = "/Resources/Leverling.png" });
            SampleList.Add(new Model() { Name = "King", Age = "20", Location = "Canada", DateOfBirth = "12/19/1984", Image = "/Resources/King.png" });
        }

        /// <summary>
        /// Gets or sets the command for hiding allow collapse option when default, multi expansion mode is selected <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand VisualMode
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
