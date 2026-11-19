using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.floorplanner.wpf
{
    /// <summary>
    /// Interaction logic for CreateFileButton.xaml
    /// </summary>
    public partial class CreateFileButton : UserControl, INotifyPropertyChanged
    {
        #region Fields

        private bool isPressed;
        private string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FloorPlanner");

        #endregion

        public CreateFileButton()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += CreateFiles_MouseLeftButtonDown;
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

        private void CreateFiles_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    var fileName = Path.Combine(folderPath, window.FileName + ".xml");
                    this.Command.Execute(fileName);
                }
            }

            isPressed = false;
        }
        #endregion
    }

}
