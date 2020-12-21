#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using SolidColorBrush = System.Windows.Media.SolidColorBrush;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class ExportViewModel : DiagramViewModel
    {
        private double _x = 0;
        private double _y = 0;
        private double _width = 0;
        private double _height = 0;
        private string _exporttype = "PNG";
        private Brush _exportBackground = new System.Windows.Media.SolidColorBrush(Colors.White);
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
                if (_exporttype != value)
                {
                    _exporttype = value;
                    OnPropertyChanged("ExportType");
                }
            }
        }
        /// <summary>
        /// Gets or sets the text color of the annotation.
        /// </summary>
        public Brush ExportBackground
        {
            get
            {
                return _exportBackground;
            }

            set
            {
                if (_exportBackground != value)
                {
                    _exportBackground = value;
                    OnPropertyChanged("ExportBackground");
                    OnExportBackgroundChanged(_exportBackground);
                }
            }
        }
        public ExportViewModel()
        {
            ExportSettings = new ExportSettings()
            {
                ExportMode = ExportMode.PageSettings,
                ExportBackground = new System.Windows.Media.SolidColorBrush(Colors.White),
            };
            //Custom command to execute export action
            ExportCommand = new DelegateCommand(OnExported);
            ModeCommand = new DelegateCommand(OnModeChanged);
        }

        private void OnModeChanged(object obj)
        {
            var content = obj.ToString();
            switch (content)
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
                if (_x != value)
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

            if (Clip_Height != 0 && Clip_Width != 0)
            {
                ExportSettings.Clip = new Rect(Clip_X, Clip_Y, Clip_Width, Clip_Height);
            }
            else
            {
                ExportSettings.Clip = Rect.Empty;
            }

            SaveFile(Extension);
        }

        private void OnExportBackgroundChanged(Brush Background)
        {
            this.ExportSettings.ExportBackground = (SolidColorBrush)Background;
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

                        Syncfusion.UI.Xaml.Diagram.Controls.ExportType exportType;
                        Enum.TryParse(this.ExportType, out exportType);
                        this.ExportSettings.ExportType = exportType;

                        //Assigning exportstream from the saved file
                        this.ExportSettings.FileName = fileName;
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();
                    }
                }
            }

        }
    }
}

