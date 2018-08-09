using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Tools.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows.Markup;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools;

namespace LocalizationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {  
     

        //Initialization

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {           
          InitializeComponent();             
        }


        #endregion

        private void ribbonwindow_Loaded(object sender, RoutedEventArgs e)
        {
            SkinStorage.SetVisualStyle(this, "Office2010Silver");         
        } 

    }
}
