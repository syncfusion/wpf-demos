#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Edit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Reperesentsthe viewmodel class for edit control
    /// </summary>
    public  class ContextPromptViewModel:NotificationObject
    {

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
        /// Initializes the instance of <see cref="ContextPromptViewModel"/>class
        /// </summary>
        public ContextPromptViewModel()
        {      
            SelectedItem = new FontFamily("Verdana");
            IntellisenseType = IntellisenseMode.Auto;
            EnableIntellisense = true;
            Source = "Data/syntaxeditor/ContextPromptSource.cs";
            Language = Languages.CSharp;
            uriList = new ObservableCollection<Uri>();
            uriList.Add(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../DLL/mscorlib.dll")));
            uriList.Add(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../DLL/System.dll")));
            uriList.Add(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../DLL/System.dll")));
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
    }
}
