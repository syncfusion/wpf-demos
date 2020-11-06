#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.editordemos.wpf
{
    public class ButtonViewModel : NotificationObject
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
        /// Maintains the collection of shape details.
        /// </summary>        
        private ObservableCollection<ButtonModel> shapeDetails;

        /// <summary>
        /// Maintains the collection of color details.
        /// </summary>
        private ObservableCollection<ButtonModel> colorDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonDemosViewModel" /> class.
        /// </summary>       
        public ButtonViewModel()
        {
            CommonResourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.editordemos.wpf;component/Assets/Buttons/PathIcon.xaml", UriKind.RelativeOrAbsolute) };
            buttonCommand = new DelegateCommand(CommandExecute, CanExecute);
            dropDownCommand = new DelegateCommand<object>(SelectionExecute);
            InitializeShapeDetails();
            InitializeColorDetails();
        }

        /// <summary>
        /// Gets or sets the shape details <see cref="ButtonDemosViewModel"/> class.
        /// </summary>
        public ObservableCollection<ButtonModel> ShapeDetails
        {
            get
            {
                return shapeDetails;
            }
            set
            {
                shapeDetails = value;
                RaisePropertyChanged("ShapeDetails");
            }
        }

        /// <summary>
        /// Gets or sets the color details <see cref="ButtonDemosViewModel"/> class.
        /// </summary>
        public ObservableCollection<ButtonModel> ColorDetails
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
        /// Gets or sets the command for the buttons <see cref="ButtonDemosViewModel"/> class.
        /// </summary>
        public ICommand ButtonCommand
        {
            get
            {
                return buttonCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for the selection change <see cref="ButtonDemosViewModel"/> class.
        /// </summary>
        public ICommand DropDownCommand
        {
            get
            {
                return dropDownCommand;
            }
        }

        /// <summary>
        /// Holds the required resouces for IconTemplate.
        /// </summary>
        private ResourceDictionary CommonResourceDictionary { get; set; }

        /// <summary>
        /// Adding details to the shapeDetails collection.
        /// </summary>  
        private void InitializeShapeDetails()
        {
            shapeDetails = new ObservableCollection<ButtonModel>();
            shapeDetails.Add(new ButtonModel() { Name = "Square", ImageTemplate = CommonResourceDictionary["Square"] as DataTemplate });
            shapeDetails.Add(new ButtonModel() { Name = "Circle", ImageTemplate = CommonResourceDictionary["Circle"] as DataTemplate });
            shapeDetails.Add(new ButtonModel() { Name = "Triangle", ImageTemplate = CommonResourceDictionary["Triangle"] as DataTemplate });
            shapeDetails.Add(new ButtonModel() { Name = "Cylinder", ImageTemplate = CommonResourceDictionary["Cylinder"] as DataTemplate });
            shapeDetails.Add(new ButtonModel() { Name = "Rhombus", ImageTemplate = CommonResourceDictionary["Rhombus"] as DataTemplate });
        }

        /// <summary>
        /// Adding details to the colorDetails collection.
        /// </summary>
        private void InitializeColorDetails()
        {
            colorDetails = new ObservableCollection<ButtonModel>();
            colorDetails.Add(new ButtonModel() { Name = "Orange", ImageTemplate = CommonResourceDictionary["Orange"] as DataTemplate });
            colorDetails.Add(new ButtonModel() { Name = "SkyBlue", ImageTemplate = CommonResourceDictionary["SkyBlue"] as DataTemplate });
            colorDetails.Add(new ButtonModel() { Name = "Yellow", ImageTemplate = CommonResourceDictionary["Yellow"] as DataTemplate });
            colorDetails.Add(new ButtonModel() { Name = "Red", ImageTemplate = CommonResourceDictionary["Red"] as DataTemplate });
            colorDetails.Add(new ButtonModel() { Name = "Green", ImageTemplate = CommonResourceDictionary["Green"] as DataTemplate });
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
            MessageBox.Show("Dropdown item is selected.");
        }
    }
}
