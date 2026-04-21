#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.floorplanner.wpf
{
    /// <summary>
    /// Interaction logic for RecentFileButton.xaml
    /// </summary>
    public partial class TemplateFileButton : UserControl, INotifyPropertyChanged
    {
        #region Fields
        
        private bool isPressed;
        private string currentFileName = String.Empty;
        private string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FloorPlanner");
        private string fileName = string.Empty;
        private string _imagepath = "/syncfusion.floorplanner.wpf;component/Asset/floor-planner-tile.png";

        #endregion

        public TemplateFileButton()
        {
            InitializeComponent();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            this.MouseLeftButtonDown += TemplateFiles_MouseLeftButtonDown;
            this.MouseLeftButtonUp += TemplateFiles_MouseLeftButtonUp;
        }

        #region Properties

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(TemplateFileButton), new UIPropertyMetadata(null));

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    this.OnPropertyChanged("FileName");
                }
            }
        }

        public string ImagePath
        {
            get
            {
                return _imagepath;
            }
            set
            {
                if (_imagepath != value)
                {
                    _imagepath = value;
                    this.OnPropertyChanged("ImagePath");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Events
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        private void TemplateFiles_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isPressed = true;
        }

        private void TemplateFiles_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isPressed)
            {
                int i = 1;
                var predefinedFolder = @"Data/Diagram";
                while (File.Exists(Path.Combine(folderPath, this.FileName + "(" + i + ")" + ".xml")))
                {
                    i++;
                }

                File.Copy(Path.Combine(predefinedFolder, this.FileName + ".xml"), Path.Combine(folderPath, this.FileName + "(" + i + ")" + ".xml"));

                this.Command.Execute(Path.Combine(folderPath, this.FileName + "(" + i + ")" + ".xml"));
            }

            isPressed = false;
        }

        #endregion
    }
}
