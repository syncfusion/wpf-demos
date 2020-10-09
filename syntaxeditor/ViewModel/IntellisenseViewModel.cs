#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Represents the view model class for EditControl
    /// </summary>
    public class IntellisenseViewModel:NotificationObject
    {
        /// <summary>
        /// Maintains the font family for the content displayed
        /// </summary>
        private FontFamily selectedItem;

        /// <summary>
        /// Maintains the command for adding assembly references
        /// </summary>
        private ICommand addReferenceCommand;

        /// <summary>
        /// Maintains the command for remvoing the assembly references
        /// </summary>
        private ICommand removeReferenceCommand;
                                           
        /// <summary>
        /// Maintains the command for window loaded
        /// </summary>
        private ICommand windowLoadedCommand;
                
        /// <summary>
        /// Initializes the collection of Uri
        /// </summary>
        ObservableCollection<Uri> uriList = null;
        
        /// <summary>
        /// Maintains a collection of Uri for assemblies
        /// </summary>
        private ObservableCollection<Uri> assemblyReference;

        /// <summary>
        /// Maintains the document source of the edit control
        /// </summary>
        private string source;
        
        /// <summary>
        /// Intializes the instance of<see cref="IntellisenseViewModel"/>class
        /// </summary>
        public IntellisenseViewModel()
        {
            Source = "Data/syntaxeditor/CSharpEditorSource.cs";
            windowLoadedCommand = new DelegateCommand<object>(PopulateData);
            SelectedItem = new FontFamily("Verdana");
            addReferenceCommand = new DelegateCommand<object>(ExecuteAddReference);
            removeReferenceCommand = new DelegateCommand<object>(ExecuteRemoveReference);
        }

        /// <summary>
        /// Gets or sets the collection of Uri for assemblies
        /// </summary>
        public ObservableCollection<Uri> AssemblyReference
        {
            get
            {
                return assemblyReference;
            }
            set
            {
                assemblyReference = value;
                RaisePropertyChanged("AssemblyReference");
            }
        }

        /// <summary>
        ///Gets or sets the document source of the edit control
        /// </summary>
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
                RaisePropertyChanged("Source");
            }
        }

        /// <summary>
        /// Gets or sets the command for removing the assembly references
        /// </summary>
        public ICommand RemoveReferenceCommand
        {
            get
            {
                return removeReferenceCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for adding the assembly references
        /// </summary>
        public ICommand AddReferenceCommand
        {
            get
            {
                return addReferenceCommand;
            }
        }
       
        /// <summary>
        /// Gets or sets the value for font family of the content
        /// </summary>
        public FontFamily SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Gets or sets the command for window loaded
        /// </summary>
        public ICommand WindowLoadedCommand
        {
            get
            {
                return windowLoadedCommand;
            }
        }

        /// <summary>
        /// Method to remove assembly reference
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteRemoveReference(object param)
        {
           if((param as ListBox).SelectedItem != null)
            {
                uriList.Remove((param as ListBox).SelectedItem as Uri);
            }
        }

        /// <summary>
        /// Method to add assembly reference
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteAddReference(object param)
        {
            if (param != null)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Assembly Files (*.dll) | *.dll";
                fileDialog.ShowDialog();
                if (fileDialog.FileName.Trim() != string.Empty)
                {
                    uriList.Add(new Uri(fileDialog.FileName));
                }
            }
        }

        /// <summary>
        /// Method for window loaded
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void PopulateData(object param)
        {
            if (param != null)
            {
                uriList = new ObservableCollection<Uri>();
                Assembly assembly = Assembly.GetExecutingAssembly();
                AssemblyReference = uriList;
            }
        }
    }
}
