#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using RibbonSample;
using Syncfusion.SfSkinManager;
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
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RibbonSample
{
    /// <summary>
    ///  Represents the behaviour code for Window1.xaml.
    /// </summary>
    class ViewModel
    {
        #region Fields
        /// <summary>
        ///  Maintains the collection of themes.
        /// </summary>
        private ObservableCollection<Model> skinList = new ObservableCollection<Model>();

        /// <summary>
        ///  Maintains the collection of font.family.
        /// </summary>
        private ObservableCollection<Model> fontfamilyList = new ObservableCollection<Model>();

        /// <summary>
        ///  Maintains the collection of font.size.
        /// </summary>
        private ObservableCollection<Model> fontsizeList = new ObservableCollection<Model>();

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            Model model = new Model();
            InitializationOfCommands();
            InitializeFont_FamilySize();
            InitializeSkin();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the skins for the ItemSource of the RibbonComboBox Control <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> SkinList
        {
            get { return skinList; }
            set { skinList = value; }
        }

        /// <summary>
        /// Gets or sets the font.family for the ItemSource of RibbonComboBox Control <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FontFamilyList
        {
            get { return fontfamilyList; }
            set { fontfamilyList = value; }
        }

        /// <summary>
        /// Gets or sets the font.size for the ItemSource of the RibbonComboBox Control <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FontSizeList
        {
            get { return fontsizeList; }
            set { fontsizeList = value; }
        }

        /// <summary>
        /// Gets or sets the command for the control.
        /// </summary>
        public ICommand MyCommand { get; set; }

        /// <summary>
        /// Gets or sets the command for the control.
        /// </summary>
        public ICommand MyCommandTwo { get; set; }

        #endregion

        #region Command Execute and CanExecute
        /// <summary>
        /// Indicates whether the command can execute on the current command target.
        /// </summary>
        /// <param name="arg">Specifies the object from the command.</param>
        /// <returns>This method returns boolean.</returns>
        private bool canExecuteRTL(object arg)
        {
            if (arg != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Changes the Window direction when command executes.
        /// </summary>
        /// <param name="obj">Specifies the object from the command.</param>
        private void executeActionRTL(object obj)
        {
            Window1 window = obj as Window1;
            window.FlowDirection = (FlowDirection)(1 - (int)window.FlowDirection);
        }

        /// <summary>
        /// Indicates whether the command can execute on the current command target.
        /// </summary>
        /// <param name="parameter">Specifies the object from the command.</param>
        /// <returns>This method returns boolean.</returns>
        private bool canexecutemethod(object parameter)
        {
            if (parameter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Execute method to disable the RibbonBar.
        /// </summary>
        /// <param name="parameter">Specifies the object from the command.</param>
        private void executemethod(object parameter)
        {
            DisableRibbonBar(parameter);
        }

        /// <summary>
        /// Disables the RibbonBar when command executes.
        /// </summary>
        /// <param name="parameter">Specifies the object from the command.</param>
        private void DisableRibbonBar(object parameter)
        {
            Window1 window = parameter as Window1;
            if (window != null)
            {
                if (window.ribbonBar_disable.Label== "Disable Ribbon Bar")
                {
                    window.simplebtns.IsEnabled = !window.simplebtns.IsEnabled;
                    window.dropbtns.IsEnabled = !window.dropbtns.IsEnabled;
                }              
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialization of commands.
        /// </summary>
        public void InitializationOfCommands()
        {
            MyCommand = new DisableRibbonBarCommand(executemethod, canexecutemethod);
            MyCommandTwo = new RightToLeftCommand(executeActionRTL, canExecuteRTL);
        }

        /// <summary>
        /// Initialization of font size and font family for RibbonComboBox.
        /// </summary>
        public void InitializeFont_FamilySize()
        {
            int[] sizes = new int[15] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                FontFamilyList.Add(new Model() { FontFamily = fontFamily.ToString() });
            }
            for (int i = 0; i < sizes.Length; i++)
            {
                FontSizeList.Add(new Model() { FontSize = sizes[i] });
            }          
        }

        /// <summary>
        /// Initialization of skins for Window.
        /// </summary>
        public void InitializeSkin()
        {
            foreach (var sfSkinManager in Enum.GetNames(typeof(VisualStyles)))
            {
                SkinList.Add(new Model() { Skins = sfSkinManager.ToString() });
            }
        }
        #endregion
    }
}
