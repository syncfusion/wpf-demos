#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using GettingStarted_PrintandExport.Utility;
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GettingStarted_PrintandExport.ViewModel
{
    public class DiagramVM : DiagramViewModel
    {        
        public DiagramVM()
        {
            //Initialize Methods
            InitializeSfDiagram();

            //Custom Command to execute Print action     
            PrintClickCommand = new Command(OnPrintCommand);

            //Custom command to execute export action
            ExportCommand = new Command(OnExported);
        }

        public ICommand PrintClickCommand { get; set; }

        public ICommand ExportCommand { get; set; }


        private void InitializeSfDiagram()
        {
            //Initializing PrintingService for DiagramViewModel
            PrintingService = new PrintingService();

            //to display page number at top of the print preview.            
            PrintingService.PrintSettings.PageHeaderHeight = 50;
            PrintingService.PrintSettings.PageHeaderTemplate = App.Current.Resources["PrintHeaderTemplate"] as DataTemplate;
        }

        //Method to execute Print action
        private void OnPrintCommand(object obj)
        {           
            PrintingService.Print();          
        }

        String Extension;
        private void OnExported(object ob)
        {

            String obj = this.ExportSettings.ExportType.ToString();

            //Assigning Extension based on the chosen exporttype.
            switch (obj)
            {
                case "BMP":
                    Extension = ("BMP File(*.bmp)|*.bmp");
                    break;
                case "WDP":
                    Extension = ("WDP File(*.wdp)|*.wdp");
                    break;
                case "JPEG":
                    Extension = ("JPEG File(*.jpg)|*.jpg");
                    break;
                case "PNG":
                    Extension = ("PNG File(*.png)|*.png");
                    break;
                case "TIF":
                    Extension = ("TIF File(*.tif)|*.tif");
                    break;
                case "GIF":
                    Extension = ("GIF File(*.gif)|*.gif");
                    break;
            }
            SaveFile(Extension);
        }


        private void SaveFile(string filter)
        {
            //To Represent SaveFile Dialog Box
            SaveFileDialog m_SaveFileDialog = new SaveFileDialog();                     

            //Assign the selected extension to the SavefileDialog filter
            m_SaveFileDialog.Filter = filter;

            //To display savefiledialog       
            m_SaveFileDialog.ShowDialog();

            //assign the filename to a local variable
            string extension = Path.GetExtension(m_SaveFileDialog.FileName);
            if (extension != "")
            {
                using (Stream str = m_SaveFileDialog.OpenFile())
                {                   
                    //Assigning exportstream from the saved file
                    this.ExportSettings.ExportStream = str;
                    // Method to Export the SfDiagram
                    (this.Info as IGraphInfo).Export();
                }
            }

        }
    }
}
