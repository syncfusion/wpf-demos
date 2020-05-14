#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Button_Controls
{
    /// <summary>
    /// Represents the behaviour or business logic for MainWindow.xaml.
    /// </summary>
    public class ViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the command for buttons.
        /// </summary>
        private ICommand buttonCommand;

        /// <summary>
        /// Maintains the command for selection change.
        /// </summary>
        private ICommand dropDownCommand;

        /// <summary>
        /// Maintains the collection of country details.
        /// </summary>        
        private ObservableCollection<Model> countryDetails;

        /// <summary>
        /// Maintains the collection of color details.
        /// </summary>
        private ObservableCollection<Model> colorDetails;      

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>       
        public ViewModel()
        {
            buttonCommand = new DelegateCommand(CommandExecute, CanExecute);
            dropDownCommand = new DelegateCommand<object>(SelectionExecute);
            InitializeCountryDetails();
            InitializeColorDetails();
        }
     
        /// <summary>
        /// Gets or sets the country details <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> CountryDetails
        {
            get
            {
                return countryDetails;
            }
            set
            {
                countryDetails = value;
                RaisePropertyChanged("CountryDetails");
            }
        }

        /// <summary>
        /// Gets or sets the color details <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> ColorDetails
        {
            get
            {
                return colorDetails;
            }
            set
            {
                colorDetails = value;
                RaisePropertyChanged("ColorDetails");
            }
        }      

        /// <summary>
        /// Gets or sets the command for the buttons <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand ButtonCommand
        {
            get
            {
                return buttonCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for the selection change <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand DropDownCommand
        {
            get
            {
                return dropDownCommand;
            }
        }

        /// <summary>
        /// Adding details to the countryDetails collection.
        /// </summary>  
        private void InitializeCountryDetails()
        {
            countryDetails = new ObservableCollection<Model>();
            countryDetails.Add(new Model() { Name = "India", ImagePath = "Images/india.png" });
            countryDetails.Add(new Model() { Name = "France", ImagePath = "Images/france.png" });
            countryDetails.Add(new Model() { Name = "Germany", ImagePath = "Images/germany.png" });
            countryDetails.Add(new Model() { Name = "Canada", ImagePath = "Images/canada.png" });
            countryDetails.Add(new Model() { Name = "China", ImagePath = "Images/china.png" });
        }

        /// <summary>
        /// Adding details to the colorDetails collection.
        /// </summary>
        private void InitializeColorDetails()
        {
            colorDetails = new ObservableCollection<Model>();
            colorDetails.Add(new Model() { Name = "Orange", ImagePath = "Images/orange.png" });
            colorDetails.Add(new Model() { Name = "SkyBlue", ImagePath = "Images/skyblue.png" });
            colorDetails.Add(new Model() { Name = "Yellow", ImagePath = "Images/yellow.png" });
            colorDetails.Add(new Model() { Name = "Red", ImagePath = "Images/red.png" });
            colorDetails.Add(new Model() { Name = "Black", ImagePath = "Images/black.png" });
        }  
        
        /// <summary>
        /// Method which is used to implement button action.
        /// </summary>
        /// <param name="parameter">Button to show the action.</param>
        public void CommandExecute(object parameter)
        {
            MessageBox.Show("Button clicked.");
        }

        /// <summary>
        /// Indicates whether the command can execute.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of canexecute.</param>
        /// <returns>Specifies the boolean.</returns>
        private bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Method which is used to implement selection change action.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void SelectionExecute(object parameter)
        {
            MessageBox.Show("DropDown item is selected.");
        }
    }
}
