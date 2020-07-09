#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using GettingStarted_Export.Utility;
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace GettingStarted_Export.ViewModel
{
    public class DiagramVM : DiagramViewModel
    {
        private double _x = 0;
        private double _y = 0;
        private double _width = 0;
        private double _height = 0;
        private string _exporttype;
        private List<string> _mexporttype = new List<string> { "PNG", "JPG", "TIF", "GIF", "BMP", "WDP", "XPS", "PDF" };



        public List<string> ExportTypes
        {
            get
            {
                return _mexporttype;
            }
        }

        public string ExportType
        {
            get
            {
                return _exporttype;
            }
            set
            {
                if(_exporttype != value)
                {
                    _exporttype = value;
                    OnPropertyChanged("ExportType");
                }
            }
        }

        public DiagramVM()
        {            
            //Custom command to execute export action
            ExportCommand = new Command(OnExported);
            ModeCommand = new Command(OnModeChanged);
        }

        private void OnModeChanged(object obj)
        {
            var content = obj.ToString();
            switch(content)
            {
                case "Content":
                    ExportSettings.ExportMode = ExportMode.Content;
                    break;
                case "PageSettings":
                    ExportSettings.ExportMode = ExportMode.PageSettings;
                    break;

            }
        }

        public ICommand ExportCommand { get; set; }
        public ICommand ModeCommand { get; set; }

        public double Clip_X
        {
            get
            {
                return _x;
            }
            set
            {
                if(_x != value)
                {
                    _x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        public double Clip_Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        public double Clip_Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged("Width");
                }
            }
        }

        public double Clip_Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged("Height");
                }
            }
        }

        String Extension;
        private void OnExported(object ob)
        {
            String obj = this.ExportType;

            //Assigning Extension based on the chosen exporttype.
            switch (obj)
            {
                case "BMP":
                    Extension = ("BMP File(*.bmp)|*.bmp");
                    break;
                case "WDP":
                    Extension = ("WDP File(*.wdp)|*.wdp");
                    break;
                case "JPG":
                    Extension = ("JPG File(*.jpg)|*.jpg");
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
                case "XPS":
                    Extension = ("XPS File(*.xps)|*.xps");
                    break;
                case "PDF":
                    Extension = ("PDF File(*.pdf)|*.pdf");
                    break;
            }       

            if(Clip_Height != 0 && Clip_Width != 0)
            {
                ExportSettings.Clip = new Rect(Clip_X, Clip_Y, Clip_Width, Clip_Height);
            }
            else
            {
                ExportSettings.Clip = Rect.Empty;
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
            bool? istrue = m_SaveFileDialog.ShowDialog();

            string filenamechanged;

            if (istrue == true)
            {
                //assign the filename to a local variable
                string extension = System.IO.Path.GetExtension(m_SaveFileDialog.FileName).TrimStart('.');
                string fileName = m_SaveFileDialog.FileName;
                if (extension != "")
                {
                    if (extension.ToLower() != ExportType.ToLower())
                    {
                        fileName = fileName + "." + ExportType.ToLower();
                    }

                    if (ExportType.ToLower() == "pdf")
                    {
                        filenamechanged = fileName + ".xps";

                        ExportSettings.IsSaveToXps = true;

                        //Assigning exportstream from the saved file
                        this.ExportSettings.FileName = filenamechanged;
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();

                        var converter = new XPSToPdfConverter { };
                        
                        var document = new PdfDocument();

                        document = converter.Convert(filenamechanged);
                        document.Save(fileName);
                        document.Close(true);

                    }

                    else
                    {
                        if (ExportType.ToLower() == "xps")
                        {
                            ExportSettings.IsSaveToXps = true;
                        }
                        //Assigning exportstream from the saved file
                        this.ExportSettings.FileName = fileName;
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();
                    }
                }
            }

        }
    }

    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();

                System.Windows.Media.Brush brush = (System.Windows.Media.Brush)converter.ConvertFromString(value.ToString());

                return (brush as System.Windows.Media.SolidColorBrush).Color;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (System.Windows.Media.Brush)converter.ConvertFromString(value.ToString());
                return brush;
            }
            return value;
        }
    }
}
