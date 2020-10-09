#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SyntaxHighlight
{
    /// <summary>
    /// Reperesentsthe viewmodel class for edit control
    /// </summary>
    public  class ViewModel:NotificationObject
    {
        /// <summary>
        /// Maintains the command for exit option
        /// </summary>
        private ICommand exitCommand;

        /// <summary>
        /// Maintains the font family of the content in the edit control
        /// </summary>
        private FontFamily selectedItem;

        /// <summary>
        /// Maintains the intellisense mode of edit control
        /// </summary>
        private IntellisenseMode intellisenseType;

        /// <summary>
        /// Maintains teh value indicating whether the intellisense is enabled
        /// </summary>
        private bool enableIntellisense;

        /// <summary>
        /// Maintains the value for document source
        /// </summary>
        private string source;

        /// <summary>
        /// Maintains the language of the content in the edit control
        /// </summary>
        private Languages  language;

        /// <summary>
        /// Maintains the collection of uri
        /// </summary>
        ObservableCollection<Uri> uriList = null;

        /// <summary>
        /// Maintains the enumerable collection of uri for assemblies
        /// </summary>
        private IEnumerable<Uri> assemblyReference;

        /// <summary>
        /// Initializes the instance of <see cref="ViewModel"/>class
        /// </summary>
        public ViewModel()
        {
         
            SelectedItem = new FontFamily("Verdana");
            IntellisenseType = IntellisenseMode.Auto;
            EnableIntellisense = true;
#if NETCORE
            Source = "../../../Source.cs";
#else
            Source = "../../Source.cs";
#endif
            Language = Languages.CSharp;
            exitCommand = new DelegateCommand<object>(ExecuteExitCommand);
            uriList = new ObservableCollection<Uri>();
#if NETCORE
            uriList.Add(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Assemblies/mscorlib.dll")));
            uriList.Add(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Assemblies/System.dll")));
            uriList.Add(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Assemblies/System.Core.dll")));
#else
            uriList.Add(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Assemblies/mscorlib.dll")));
            uriList.Add(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Assemblies/System.dll")));
            uriList.Add(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Assemblies/System.Core.dll")));
#endif
            AssemblyReference = uriList;
           
        }
 
        /// <summary>
        /// Gets or sets the assembly references
        /// </summary>
        public IEnumerable<Uri> AssemblyReference
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
        /// Gets or sets the langugae of the content in edit control
        /// </summary>
        public Languages Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
                RaisePropertyChanged("Language");
            }
        }

        /// <summary>
        /// Gets or sets the document source for the edit control
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
        /// Gets or sets the command for window exit
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand;
            }
        }

        /// <summary>
        /// Gets or sets the value indicating the intellisense in the edit contrl is enabled
        /// </summary>
        public bool EnableIntellisense
        {
            get
            {
                return enableIntellisense;
            }
            set
            {
                enableIntellisense = value;
                RaisePropertyChanged("EnableIntellisense");
            }
        }

        /// <summary>
        /// Gets or sets the intellisense mode of the edit contorl
        /// </summary>
        public IntellisenseMode IntellisenseType
        {
            get
            {
                return intellisenseType;
            }
            set
            {
                intellisenseType = value;
                RaisePropertyChanged("IntellisenseType");
            }
        }

        /// <summary>
        /// Gets or sets the font family of the content in the edit control
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
        /// Method to  exit window
        /// </summary>
        /// <param name="param">specifies the object parameter</param>
        private void ExecuteExitCommand(object param)
        {
            Application.Current.Shutdown();
        }
        
    }
}
