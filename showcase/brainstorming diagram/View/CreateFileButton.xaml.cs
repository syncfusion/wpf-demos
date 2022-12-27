#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;

namespace syncfusion.brainstormingdiagram.wpf.View
{
    /// <summary>
    /// Interaction logic for CreateFileButton.xaml
    /// </summary>
    public partial class CreateFileButton : UserControl, INotifyPropertyChanged
    {
        #region Fields

        private string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BrainstormingDiagram");

        private string fileName = string.Empty;
        bool isPressed;

        #endregion

        public CreateFileButton()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += CreateFileButton_MouseLeftButtonDown;
            this.MouseLeftButtonUp += CreateFiles_MouseLeftButtonUp;
        }

        #region Properties

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CreateFileButton), new UIPropertyMetadata(null));

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
        private void CreateFileButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isPressed = true;
        }

        private void CreateFiles_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isPressed)
            {
                var window = new CreateNewWindow();
                var windowState = window.ShowDialog();
                if (windowState.HasValue && windowState.Value)
                {
                    this.FileName = window.FileName;
                    this.Command.Execute(this.FileName);
                }
                isPressed = false;
            }
        }
        #endregion
    }

}
