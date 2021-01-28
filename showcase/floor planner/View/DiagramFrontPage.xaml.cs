#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System.Windows.Media.Animation;

namespace syncfusion.floorplanner.wpf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DiagramFrontPage : UserControl
    {
        private DateTime createdDate = new DateTime(2020, 9, 25);
        private string installedLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public DiagramFrontPage()
        {
            this.InitializeComponent();
            this.Cancel = new DelegateCommand<object>(OnCancel);
            this.fileList.SelectionChanged += fileList_SelectionChanged;
            this.Unloaded += DiagramFrontPage_Unloaded;
        }

        void DiagramFrontPage_Unloaded(object sender, RoutedEventArgs e)
        {
            Cancel = null;
            this.Unloaded -= DiagramFrontPage_Unloaded;
            if (fileList != null)
            {
                fileList.SelectionChanged -= fileList_SelectionChanged;

            }
            ObservableCollection<FileItem> items = fileList.DataContext as ObservableCollection<FileItem>;
            foreach (FileItem item in items)
            {
                item.Dispose();
            }
            fileList.DataContext = null;
            creator = null;
        }

        public DiagramCommonViewModel DiagramCommonViewModel
        {
            get { return (DiagramCommonViewModel)GetValue(UMLViewModelProperty); }
            set { SetValue(UMLViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DiagramCommonViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UMLViewModelProperty =
            DependencyProperty.Register("DiagramCommonViewModel", typeof(DiagramCommonViewModel), typeof(DiagramFrontPage), new PropertyMetadata(null, OnUMLViewModelChanged));

        private static void OnUMLViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DiagramFrontPage front = d as DiagramFrontPage;

            if (e.NewValue == null)
            {
                return;
            }

            front.DiagramCommonViewModel.ItemClick = new DelegateCommand<object>(front.ItemClicked);
        }

        private void ItemClicked(object obj)
        {
            FileItem clicked = obj as FileItem;
            clicked.Load.Execute(clicked.Name);
        }

        void fileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DiagramCommonViewModel.SelectedItemsCount = fileList.SelectedItems.Count;
        }

        public ICommand Create
        {
            get { return (ICommand)GetValue(CreateProperty); }
            set { SetValue(CreateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Create.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateProperty =
            DependencyProperty.Register("Create", typeof(ICommand), typeof(DiagramFrontPage), new PropertyMetadata(null, OnCreateChanged));

        private static void OnCreateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DiagramFrontPage).LoadDiagrams();
        }

        public ICommand Load
        {
            get { return (ICommand)GetValue(LoadProperty); }
            set { SetValue(LoadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Load.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadProperty =
            DependencyProperty.Register("Load", typeof(ICommand), typeof(DiagramFrontPage), new PropertyMetadata(null));

        public ICommand Cancel { get; set; }

        private void OnCancel(object param)
        {
            if (prop != null)
            {
                Storyboard animation = prop.Resources["PropertyEditor_Storyboard_Collapse"] as Storyboard;
                animation.Stop();
                animation.Begin();
            }
        }

        private ICommand m_itemClick;
        public ICommand ItemClick
        {
            get { return m_itemClick; }
            set
            {
                if (m_itemClick != value)
                {
                    m_itemClick = value;

                }
            }
        }

        FileItem creator;

        private void LoadDiagrams()
        {
            string pathString = System.IO.Path.Combine(installedLocation, "FloorPlan");
            string[] predefinedDiagrams = new string[] { "FloorPlan.xml" };
            LoadFiles(pathString, predefinedDiagrams, "Data/Diagram");
        }

        private void LoadFiles(string pathString, string[] predefinedDiagrams, string predefinedFolder)
        {
            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }

            var items = new ObservableCollection<FileItem>();
            var predefinedSamples = new List<string>();
            foreach (string file in predefinedDiagrams)
            {
                var filePath = Path.Combine(pathString, file);
                predefinedSamples.Add(filePath);
                if (File.Exists(filePath))
                {
                    if (this.IsOldFile(filePath))
                    {
                        File.Delete(filePath);
                        System.IO.File.Copy(predefinedFolder + @"/" + file, filePath, false);
                    }
                }
                else
                {
                    System.IO.File.Copy(predefinedFolder + @"/" + file, filePath, false);
                }
            }

            var files = Directory.GetFiles(pathString).ToList();
            int i = 0;
            while (i < files.Count)
            {
                if (this.IsOldFile(files[i]) && !predefinedSamples.Contains(files[i]))
                {
                    files.Remove(files[i]);
                    continue;
                }

                i++;
            }

            PopulateGridView(files, items);
        }

        private bool IsOldFile(string filePath)
        {
            var directoryInfo = new DirectoryInfo(filePath);
            if (directoryInfo.Extension.ToString() == ".xml")
            {
                if (directoryInfo.CreationTime < createdDate)
                {
                    return true;
                }
            }

            return false;
        }

        private void PopulateGridView(List<string> files, ObservableCollection<FileItem> items)
        {
            foreach (string file in files)
            {
                DirectoryInfo DI = new DirectoryInfo(file);
                if (DI.Extension.ToString() == ".xml")
                {
                    string extension = System.IO.Path.GetExtension(DI.Name);
                    string filename = DI.Name;
                    string result = filename.Substring(0, DI.Name.Length - extension.Length);
                    FileItem item = new FileItem();
                    item.Name = result;
                    item.Load = this.Load;
                    item.ItemClick = this.ItemClick;
                    item.LastUpdated = DI.CreationTime;
                    items.Add(item);
                }
            }
            creator = new FileItem { Name = "Untitled", Create = Create, Cancel = Cancel };
            NewFile.DataContext = creator;
            fileList.DataContext = items;
            checkName(items);
            Binding bin = new Binding();
            bin.Path = new PropertyPath("Name");
            if (textBox == null)
            {
                textBox = root1.Children[2] as TextBox;
            }
            textBox.SetBinding(TextBox.TextProperty, bin);
        }



        private void checkName(ObservableCollection<FileItem> items)
        {
            if (items != null)
            {
                foreach (FileItem item in items.Where(i => i.Name == creator.Name))
                {
                    creator.Name = "Untitled" + getFileCount(items);
                }
            }
        }

        private int getFileCount(ObservableCollection<FileItem> items)
        {
            int max = 1;
            foreach (string fileName in items.Where(i => i.Name.StartsWith("Untitled")).Select(i => i.Name.Replace("Untitled", "")))
            {
                int parsed = 0;
                if (int.TryParse(fileName, out parsed))
                {
                    if (max <= parsed)
                    {
                        max = parsed + 1;
                    }
                }
            }
            return max;
        }

        Grid prop;

        private void Pop_NewFileCreator(object sender, MouseButtonEventArgs e)
        {
            prop = ((sender as Grid).Children[0] as Grid);

            if (prop.Visibility == Visibility.Collapsed)
            {
                checkName(fileList.DataContext as ObservableCollection<FileItem>);
                prop.Visibility = Visibility.Visible;
                Storyboard animation;
                animation = prop.Resources["PropertyEditor_Storyboard_Visible1"] as Storyboard;
                animation.Stop();
                animation.Begin();
                prop.Height = 60;
                prop.Children[0].Visibility = Visibility.Collapsed;

                if (textBox != null)
                {
                    textBox.Focus();
                }
            }
            else
            {
                HideCreator();
            }
        }

        private void HideCreator()
        {
            if (prop.Visibility != Visibility.Collapsed)
            {

                Storyboard animation = prop.Resources["PropertyEditor_Storyboard_Collapse1"] as Storyboard;
                animation.Stop();
                animation.Begin();
                prop.Visibility = Visibility.Collapsed;

            }
        }

        private void CloseNewFilePopup_Clicked(object sender, RoutedEventArgs e)
        {
            this.HideCreator();
        }

        private void NewFileCreate_Clicked(object sender, RoutedEventArgs e)
        {
            HideCreator();

            ObservableCollection<FileItem> data = fileList.DataContext as ObservableCollection<FileItem>;

            Button src = sender as Button;
            if (data != null)
            {

                if (data.Where(i => i.Name == src.CommandParameter.ToString()).Count() == 0)
                {
                    data.Add(
                        new FileItem
                        {
                            Name = (sender as Button).CommandParameter.ToString(),
                            Load = this.Load,
                            LastUpdated = DateTimeOffset.Now
                        });

                    this.Create.Execute(src.CommandParameter + "");
                    checkName(data);
                }
            }

        }

        TextBox textBox;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HideCreator();
        }
    }

    public class FileItem : INotifyPropertyChanged, IDisposable
    {
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set
            {
                if (m_Name != value)
                {
                    m_Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private ICommand m_Create;

        public ICommand Create
        {
            get { return m_Create; }
            set
            {
                if (m_Create != value)
                {
                    m_Create = value;
                    OnPropertyChanged("Create");
                }
            }
        }

        private ICommand m_Load;

        public ICommand Load
        {
            get { return m_Load; }
            set
            {
                if (m_Load != value)
                {
                    m_Load = value;
                    OnPropertyChanged("Load");
                }
            }
        }

        private ICommand m_Cancel;

        public ICommand Cancel
        {
            get { return m_Cancel; }
            set
            {
                if (m_Cancel != value)
                {
                    m_Cancel = value;
                    OnPropertyChanged("Cancel");
                }
            }
        }

        private DateTimeOffset m_LastUpdated;

        public DateTimeOffset LastUpdated
        {
            get { return m_LastUpdated; }
            set
            {
                if (m_LastUpdated != value)
                {
                    m_LastUpdated = value;
                    OnPropertyChanged("LastUpdated");
                }
            }
        }

        protected virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand m_itemClick;
        public ICommand ItemClick
        {
            get { return m_itemClick; }
            set
            {
                if (m_itemClick != value)
                {
                    m_itemClick = value;
                    OnPropertyChanged("ItemClick");
                }
            }
        }

        public void Dispose()
        {
            PropertyChanged = null;
            Create = null;
            Load = null;
            Cancel = null;
        }
    }

    public class DiagramTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null)
            {
                return value;
            }

            return String.Format((String)parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class FileButton : ContentControl
    {
        public FileButton()
        {
            this.MouseLeftButtonUp += FileButton_MouseLeftButtonUp;
        }

        void FileButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FileButton f = sender as FileButton;

            if (f.Tag != null)
            {
                DiagramFrontPage fp = f.Tag as DiagramFrontPage;
                (fp.DataContext as DiagramCommonViewModel).ItemClick.Execute(this.DataContext as FileItem);
            }
        }

        void FileButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
