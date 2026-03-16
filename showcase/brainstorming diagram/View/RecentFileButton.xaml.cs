#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
    /// Interaction logic for RecentFileButton.xaml
    /// </summary>
    public partial class RecentFileButton : UserControl, INotifyPropertyChanged
    {
        #region Fields

        private string currentFileName = String.Empty;
        private string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BrainstormingDiagram");
        private string fileName = "Planner 1";
        bool isPressed;
        #endregion

        public RecentFileButton()
        {
            InitializeComponent();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            this.MouseLeftButtonUp += RecentFiles_MouseLeftButtonUp;
            this.MouseLeftButtonDown += RecentFileButton_MouseLeftButtonDown;
            this.PART_Menu.MouseLeftButtonDown += PART_Menu_MouseLeftButtonDown;
        }


        #region Properties

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(RecentFileButton), new UIPropertyMetadata(null));

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
        private void RecentFileButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isPressed = true;
        }
        private void RecentFiles_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isPressed)
            {
                this.Open();
                isPressed = false;
            }
        }

        private void PART_Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void PART_Menu_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            switch (menuItem.Header)
            {
                case "_Open":
                    this.Open();
                    break;
                case "_Duplicate":
                    this.Duplicate();
                    break;
                case "_Rename":
                    this.StartEditing();
                    break;
                case "_Delete":
                    this.Delete();
                    break;
            }
        }
        #endregion

        #region Open
        private void Open()
        {
            Command.Execute(this.FileName);
        }
        #endregion

        #region Duplicate
        private void Duplicate()
        {
            int i = 1;
            while (File.Exists(Path.Combine(folderPath, this.FileName + "(" + i + ")" + ".xml")))
            {
                i++;
            }

            File.Copy(Path.Combine(folderPath, this.FileName + ".xml"), Path.Combine(folderPath, this.FileName + "(" + i + ")" + ".xml"));

            var parentElement = this.Parent as Panel;
            var duplicateFile = new RecentFileButton() { FileName = this.FileName + "(" + i + ")",   Command = this.Command };
            if (parentElement != null)
            {
                parentElement.Children.Insert(parentElement.Children.IndexOf(this) + 1, duplicateFile);
            }
        }
        #endregion

        #region Rename

        private void StartEditing()
        {
            this.currentFileName = this.FileName;
            this.lblFileName.Visibility = Visibility.Collapsed;
            this.txtFileName.Visibility = Visibility.Visible;
            this.txtFileName.Focus();
            this.txtFileName.SelectionStart = 0;
            this.txtFileName.SelectionLength = this.FileName.Length;
            this.txtFileName.KeyDown += TxtFileName_KeyDown;
            this.txtFileName.LostFocus += TxtFileName_LostFocus;
        }

        private void TxtFileName_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                this.EndEditing();
            }
        }

        private void TxtFileName_LostFocus(object sender, RoutedEventArgs e)
        {
            this.EndEditing();
        }

        private void EndEditing()
        {
            this.lblFileName.Visibility = Visibility.Visible;
            this.txtFileName.Visibility = Visibility.Collapsed;
            this.txtFileName.KeyDown -= TxtFileName_KeyDown;
            this.txtFileName.LostFocus -= TxtFileName_LostFocus;

            if (!File.Exists(Path.Combine(folderPath, this.FileName + ".xml")))
            {
                File.Copy(Path.Combine(folderPath, this.currentFileName + ".xml"), Path.Combine(folderPath, this.FileName + ".xml"));
                File.Delete(Path.Combine(folderPath, this.currentFileName + ".xml"));
            }
            else
            {
                this.FileName = this.currentFileName;
            }
        }

        #endregion

        #region Delete
        private void Delete()
        {
            File.Delete(Path.Combine(folderPath, this.FileName + ".xml"));

            var parentElement = this.Parent as Panel;
            if (parentElement != null && parentElement.Children.Contains(this))
            {
                parentElement.Children.Remove(this);
            }
        }
        #endregion
    }

}
