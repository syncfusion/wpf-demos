#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.navigationdemos.wpf
{
    public class EmployeeDetailViewModel :NotificationObject
    {
        /// <summary>
        ///  Maintains the collection for sample list.
        /// </summary>
        private ObservableCollection<EmployeeDetailModel> sampleList;

        /// <summary>
        /// Maintains the command for visual mode.
        /// </summary>
        private ICommand visualMode;

        /// <summary>
        /// Maintains the selected modes.
        /// </summary>
        private string selectedModeproperty;

        /// <summary>
        /// Maintains the visibility for allow collapse checkbox.
        /// </summary>
        private Visibility checkBoxVisibility;

        /// <summary>
        ///  Initializes a new instance of the <see cref="EmployeeDetailViewModel" /> class.
        /// </summary>
        public EmployeeDetailViewModel()
        {
            selectedModeproperty = "StackMode";
            SampleList = new ObservableCollection<EmployeeDetailModel>();
            visualMode = new DelegateCommand<object>(HideAllowCollapse);
            PopulateData();
        }

        /// <summary>
        /// Gets or sets the sample list <see cref="EmployeeDetailViewModel"/> class.
        /// </summary>
        public ObservableCollection<EmployeeDetailModel> SampleList
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
            SampleList.Add(new EmployeeDetailModel() { Name = "Buchanan", Age = "25", Location = "Washington D.C.", DateOfBirth = "02/25/1984", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle14.png" });
            SampleList.Add(new EmployeeDetailModel() { Name = "Callahan", Age = "19", Location = "Costa Rica", DateOfBirth = "10/16/1990", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle23.png" });
            SampleList.Add(new EmployeeDetailModel() { Name = "Fuller", Age = "35", Location = "Carolina", DateOfBirth = "09/24/1970", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png" });
            SampleList.Add(new EmployeeDetailModel() { Name = "Lever Ling", Age = "28", Location = "New York", DateOfBirth = "08/26/1985", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle33.png" });
            SampleList.Add(new EmployeeDetailModel() { Name = "King", Age = "20", Location = "Canada", DateOfBirth = "12/19/1984", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle35.png" });
        }

        /// <summary>
        /// Gets or sets the command for hiding allow collapse option when default, multi expansion mode is selected <see cref="EmployeeDetailViewModel"/> class.
        /// </summary>
        public ICommand VisualMode
        {
            get
            {
                return visualMode;
            }
        }

        /// <summary>
        /// Gets or sets the selected modes <see cref="EmployeeDetailViewModel"/> class.
        /// </summary>
        public string SelectedModeProperty
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
        /// Gets or sets the visibility for allow collapse option <see cref="EmployeeDetailViewModel"/> class.
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
            if (SelectedModeProperty == "Default" || SelectedModeProperty == "MultipleExpansion")
            {
                CheckBoxVisibility = System.Windows.Visibility.Hidden;
            }
            else if (SelectedModeProperty == "StackMode")
            {
                CheckBoxVisibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
