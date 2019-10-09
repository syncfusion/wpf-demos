#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using GettingStarted_Export.Utility;
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Diagram;
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

    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();

                Brush brush = (Brush)converter.ConvertFromString(value.ToString());

                return (brush as SolidColorBrush).Color;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(value.ToString());
                return brush;
            }
            return value;
        }
    }
}
