using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.Windows.Shared;
using System;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace OrganizationLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        #region Private Variables

        private string compact;
        private string pressedButtonName = string.Empty;
        private UIElement previousPressedElement = null;
        
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            //Initialize Nodes and Connectors
            sfdiagram.Nodes = new DiagramCollection<NodeViewModel>();
            sfdiagram.Connectors = new DiagramCollection<ConnectorViewModel>();

            //To Represent LayoutManager Properties
            sfdiagram.LayoutManager = new Syncfusion.UI.Xaml.Diagram.Layout.LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = Syncfusion.UI.Xaml.Diagram.Layout.LayoutType.Organization,
                    HorizontalSpacing = 50,
                    VerticalSpacing = 40
                }
            };


            //Item Added Event
            (sfdiagram.Info as IGraphInfo).GetLayoutInfo += MainWindow_GetLayoutInfo;
            //PageSettings used to enable the Appearance of Digram Page.
            sfdiagram.PageSettings.PageBorderBrush = new SolidColorBrush(Colors.Transparent);

            ObservableCollection<Employee>  employee = new ObservableCollection<Employee>();

            //Initialize Method
            Data(employee);

            //Initialize DataSourceSettings and Represent ParentId,Id.
            DataSourceSettings settings = new DataSourceSettings();
            settings.ParentId = "ReportingPerson";
            settings.Id = "Name";
            settings.DataSource = employee;
            sfdiagram.DataSourceSettings = settings;

           
            this.Loaded += MainPage_Loaded;
            sfdiagram.Tool = Tool.ZoomPan;
            sfdiagram.Constraints &= ~(GraphConstraints.PageEditing | GraphConstraints.PanRails);
        }       

        //Get Employee Details 
        private void Data(ObservableCollection<Employee> employee)
        {
            employee.Add(new Employee()
            {
                Name = "Maria Anders",
                ContactNo = 7899896099,
                Designation = "Managing Director",
                Doj = "1-March-2010",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/eric.png",
                RatingColor = "#71AF17",
                Salary = 90000
            });
          
            employee.Add(new Employee()
            {
                Name = "Pedro Afonso",
                ContactNo = 7899896099,
                Designation = "Project Manager",
                Doj = "1/May/2010",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/Paul.png",
                RatingColor = "#1859B7",
                Salary = 80000,
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new Employee()
            {
                Name = "Elizabeth Brown",
                ContactNo = 7899896099,
                Designation = "Project Lead",
                Doj = "27- Nov-2010",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/Maria.png",
                RatingColor = "#2E95D8",
                Salary = 70000,
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(new Employee()
            {
                Name = "Aria Cruz",
                ContactNo = 7899896099,
                Designation = "Project Lead",
                Doj = "12-feb-2010",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/Jenny.png",
                RatingColor = "#2E95D8",
                Salary = 70000,
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(new Employee()
            {
                Name = "Martín Sommer",
                ContactNo = 7899896099,
                Designation = "Senior S/w Engg",
                Doj = "23/may/2012",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/image2.png",
                RatingColor = "#2E95D8",
                Salary = 60000,
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(new Employee()
            {
                Name = "Jaime Yorres",
                ContactNo = 7899896099,
                Designation = "S/w Engg",
                Doj = "23/may/2012",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/image2.png",
                RatingColor = "#2E95D8",
                Salary = 50000,
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(
                new Employee
                    {
                        Name = "John Steel",
                        ContactNo = 7899896099,
                        Designation = "Project Trainee",
                        Doj = "21-Sep-2011",
                        EmailId = "joplin@xyz.com",
                        ImageUrl = "/Assets/Maria.png",
                        RatingColor = "#2E95D8",
                        Salary = 40000,
                        ReportingPerson = "Pedro Afonso"
                    });

            employee.Add(new Employee()
            {
                Name = "Lino Rodriguez",
                ContactNo = 7899896099,
                Designation = "Project Manager",
                Doj = "15-Nov-2010",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/Robin.PNG",
                RatingColor = "#1859B7",
                Salary = 80000,
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new Employee()
            {
                Name = "Hanna Moos",
                ContactNo = 7899896099,
                Designation = "Project Lead",
                Doj = "12-May-2011",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/image55.png",
                RatingColor = "#2E95D8",
                Salary = 70000,
                ReportingPerson = "Lino Rodriguez"
            });

            employee.Add(new Employee()
            {
                Name = "Howard Snyder",
                ContactNo = 7899896099,
                Designation = "Project Lead",
                Doj = "18-dec-2010",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/image12.png",
                RatingColor = "#2E95D8",
                Salary = 70000,
                ReportingPerson = "Lino Rodriguez"
            });


            employee.Add(new Employee()
            {
                Name = "Philip Cramer",
                ContactNo = 7899896099,
                Designation = "Project Manager",
                Doj = "07-August-2011",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/image2.PNG",
                RatingColor = "#1859B7",
                Salary = 80000,
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new Employee()
            {
                Name = "Daniel Tonini",
                ContactNo = 7899896099,
                Designation = "Project Lead",
                Doj = "21-Sep-2011",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/image57.png",
                RatingColor = "#2E95D8",
                Salary = 70000,
                ReportingPerson = "Philip Cramer"
            });

            employee.Add(new Employee()
            {
                Name = "Annette Roulet",
                ContactNo = 7899896099,
                Designation = "Senior S/w Engg",
                Doj = "21-Sep-2011",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/image55.png",
                RatingColor = "#2E95D8",
                Salary = 60000,
                ReportingPerson = "Philip Cramer"
            });

            employee.Add(new Employee()
            {
                Name = "Yoshi Tannamuri",
                ContactNo = 7899896099,
                Designation = "S/w Engg",
                Doj = "21-Sep-2011",
                EmailId = "joplin@xyz.com",
                ImageUrl = "./Assets/image57.png",
                RatingColor = "#2E95D8",
                Salary = 50000,
                ReportingPerson = "Philip Cramer"
            });
        }
       
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            compact = "alternate";
            VisualStateManager.GoToState(orgCompactAlternate, "Checked", true);
            pressedButtonName = orgCompactAlternate.Name;

        }

        void MainWindow_GetLayoutInfo(object sender, LayoutInfoArgs args)
        {
            if (sfdiagram.LayoutManager.Layout is DirectedTreeLayout)
            {
                if ((sfdiagram.LayoutManager.Layout as DirectedTreeLayout).Type == LayoutType.Organization)
                {

                    switch (compact)
                    {
                        case "left":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Left;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "right":
                            if (!args.HasSubTree)
                            {
                                    args.Type = ChartType.Right;
                                    args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "alternate":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Alternate;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "horizontal_center":
                            if (!args.HasSubTree)
                            { 
                                args.Type = ChartType.Center;
                                    args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "horizontal_right":
                            if (!args.HasSubTree)
                            {
                                    args.Type = ChartType.Right;
                                    args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "horizontal_left":
                            if (!args.HasSubTree)
                            {
                                    args.Type = ChartType.Left;
                                    args.Orientation = Orientation.Horizontal;
                            }
                            break;
                    }
                }
            }
        }

        private void orgCompactLeft_Click(object sender, RoutedEventArgs e)
        {
            pressedButtonName = (sender as ToggleButton).Name;
            if ((sender as ToggleButton).Name.Equals("orgCompactLeft"))
            {
                compact = "left";
            }
            else if ((sender as ToggleButton).Name.Equals("orgCompactRight"))
            {
                compact = "right";
            }
            else if ((sender as ToggleButton).Name.Equals("orgCompactAlternate"))
            {
                compact = "alternate";
            }
            else if ((sender as ToggleButton).Name.Equals("orgCompactCenter"))
            {
                compact = "horizontal_center";
            }
            else if ((sender as ToggleButton).Name.Equals("orgCompactHorizontalRight"))
            {
                compact = "horizontal_right";
            }
            else if ((sender as ToggleButton).Name.Equals("orgCompactHorizontalLeft"))
            {
                compact = "horizontal_left";
            }
            (sfdiagram.LayoutManager.Layout as DirectedTreeLayout).UpdateLayout();
        }

        private void hierarchicalLeftToRight_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(sender as ToggleButton, "MouseEnter", true);
        }

       //To Represent State Selection 
        private void hierarchicalLeftToRight_MouseLeave(object sender, MouseEventArgs e)
        {
            if (pressedButtonName.Equals((sender as ToggleButton).Name))
            {
                if (previousPressedElement == null)
                {
                    previousPressedElement = sender as ToggleButton;
                    VisualStateManager.GoToState(orgCompactAlternate, "Normal", true);
                }
                else if (previousPressedElement != sender as ToggleButton)
                {
                    VisualStateManager.GoToState(previousPressedElement as ToggleButton, "Normal", true);
                    previousPressedElement = sender as ToggleButton;
                }
                VisualStateManager.GoToState(sender as ToggleButton, "Checked", true);
            }
            else
            {
                VisualStateManager.GoToState(sender as ToggleButton, "Normal", true);
            }
        }
    }

    //Initialize Employee Class Variables and Properties
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private double salary;
        private string destination;
        private string imageurl;
        private string doj;
        private string emailid;
        private double contactno;
        private State isexpand;
        private bool issearch = false;
        private bool isfilter = true;
        private double _borderthick = 1;
        private string heatmap = "#FFC34444";
        private string reportingPerson;

        public Employee()
        {
            Models = new ObservableCollection<Employee>();

        }
        public State IsExpand
        {
            get
            {
                return isexpand;
            }
            set
            {
                if (isexpand != value)
                {
                    isexpand = value;
                    OnPropertyChanged(("IsExpand"));
                }
            }
        }

        public bool IsSearched
        {
            get
            {
                return issearch;
            }
            set
            {
                if (issearch != value)
                {
                    issearch = value;
                    OnPropertyChanged(("IsSearched"));
                }
            }
        }

        private ObservableCollection<string> _disp = new ObservableCollection<string>()
        {
            "Managing Director",
            "Project Manager",
            "Project Lead",
            "Senior S/w Engg",
            "S/w Engg",
            "Project Trainee"
        };

        //public ObservableCollection<string> Designation
        //{
        //    get
        //    {
        //        return _disp;
        //    }
        //}

        private string _mDesignation;
        public string Designation
        {
            get { return _mDesignation; }
            set
            {
                if (_mDesignation != value)
                {
                    _mDesignation = value;
                    OnPropertyChanged("Designation");
                }
            }
        }

        private ObservableCollection<string> _gen = new ObservableCollection<string>()
        {
            "Female",
            "Male"
        };

        public ObservableCollection<string> Gender
        {
            get
            {
                return _gen;
            }
        }

        private ObservableCollection<int> _rat = new ObservableCollection<int>()
        {
            1,2,3,4,5
        };

        public ObservableCollection<int> Rating
        {
            get
            {
                return _rat;
            }
        }

        //private NodeFocusState isfocus;
        //public NodeFocusState IsFocus
        //{
        //    get
        //    {
        //        return isfocus;
        //    }
        //    set
        //    {
        //        if (isfocus != value)
        //        {
        //            isfocus = value;
        //            if (value == NodeFocusState.Normal)
        //            {
        //                BackgroundBrush = new SolidColorBrush(Colors.White);
        //            }
        //            else if (value == NodeFocusState.MouseHover)
        //            {
        //                Color c = Color.FromArgb(255, 239, 239, 239);
        //                BackgroundBrush = new SolidColorBrush(c);
        //            }
        //            else if (value == NodeFocusState.Focused)
        //            {
        //                BackgroundBrush = ColorConverter(RatingColor);
        //            }
        //            OnPropertyChanged(("IsFocus"));
        //        }
        //    }
        //}

        private SolidColorBrush ColorConverter(string hexaColor)
        {
            if (hexaColor != null)
            {
                byte r = Convert.ToByte(hexaColor.Substring(1, 2), 16);
                byte g = Convert.ToByte(hexaColor.Substring(3, 2), 16);
                byte b = Convert.ToByte(hexaColor.Substring(5, 2), 16);
                byte a = Convert.ToByte(hexaColor.Substring(7, 2), 16);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(r, g, b, a));
                return myBrush;
            }
            return null;
        }
        public bool IsFiltered
        {
            get
            {
                return isfilter;
            }
            set
            {
                if (isfilter != value)
                {
                    isfilter = value;
                    OnPropertyChanged(("IsFiltered"));
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(("Name"));
                }
            }
        }

        public string ReportingPerson
        {
            get
            {
                return reportingPerson;
            }
            set
            {
                if (reportingPerson != value)
                {
                    reportingPerson = value;
                    OnPropertyChanged(("ReportingPerson"));
                }
            }
        }

        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (salary != value)
                {
                    salary = value;
                    OnPropertyChanged(("Salary"));
                }
            }
        }

        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                if (destination != value)
                {
                    if (value != null)
                    {
                        destination = value;
                        OnPropertyChanged(("Destination"));
                    }
                }
            }
        }

        public string ImageUrl
        {
            get
            {
                return imageurl;
            }
            set
            {
                if (imageurl != value)
                {
                    if (value != null)
                    {
                        imageurl = value;
                        OnPropertyChanged(("ImageUrl"));
                    }
                }
            }
        }


        private bool isedit = false;

        public bool IsEdit
        {
            get
            {
                return isedit;
            }
            set
            {
                if (isedit != value)
                {
                    isedit = value;
                    OnPropertyChanged(("IsEdit"));
                }
            }
        }

        public string Doj
        {
            get
            {
                return doj;
            }
            set
            {
                if (doj != value)
                {
                    doj = value;
                    OnPropertyChanged(("Doj"));
                }
            }
        }

        public string EmailId
        {
            get
            {
                return emailid;
            }
            set
            {
                if (emailid != value)
                {
                    emailid = value;
                    OnPropertyChanged(("EmailId"));
                }
            }
        }

        public double ContactNo
        {
            get
            {
                return contactno;
            }
            set
            {
                if (contactno != value)
                {
                    contactno = value;
                    OnPropertyChanged(("ContactNo"));
                }
            }
        }

        public double BorderThickness
        {
            get
            {
                return _borderthick;
            }
            set
            {
                if (_borderthick != value)
                {
                    _borderthick = value;
                    OnPropertyChanged(("BorderThickness"));
                }
            }

        }

        public string RatingColor
        {
            get
            {
                return heatmap;
            }
            set
            {
                if (heatmap != value)
                {
                    if (value != null)
                    {
                        heatmap = value;
                        //if (RatingUpdated != null)
                        //{
                        //    RatingUpdated.Execute(RatingColor);
                        //}
                        OnPropertyChanged(("RatingColor"));
                    }
                }
            }
        }

        //private ICommand _rating;

        //public ICommand RatingUpdated
        //{
        //    get
        //    {
        //        return _rating;
        //    }
        //    set
        //    {
        //        if (_rating != null)
        //        {
        //            _rating = value;
        //            OnPropertyChanged(("RatingUpdated"));
        //        }
        //    }
        //}

        private ObservableCollection<Employee> models;


        public ObservableCollection<Employee> Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged(("Models"));
            }
        }


        //public ICommand BrowseCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand<object>(OnClick, args => { return true; });
        //    }
        //}

        private BitmapImage _bit;

        public BitmapImage BitImag
        {
            get
            {
                return _bit;
            }
            set
            {
                if (_bit != value)
                {
                    _bit = value;
                    OnPropertyChanged(("BitImag"));
                }
            }
        }
        private ICommand _path;
        public ICommand PathClickCommand
        {
            get
            {
                return _path;
            }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    OnPropertyChanged(("PathClickCommand"));
                }
            }
        }

        private ICommand _Rating;
        public ICommand RatingCommand
        {
            get
            {
                return _Rating;
            }
            set
            {
                if (_Rating != value)
                {
                    _Rating = value;
                    OnPropertyChanged(("RatingCommand"));
                }
            }
        }

        private ICommand _selection;

        public ICommand Selection
        {
            get
            {
                return _selection;
            }
            set
            {
                if (_selection != value)
                {
                    _selection = value;
                    OnPropertyChanged(("Selection"));
                }
            }
        }

        private void OnPress(object obj)
        {

        }

        private SolidColorBrush _backbrush;
        public SolidColorBrush BackgroundBrush
        {
            get
            {
                return _backbrush;
            }
            set
            {
                if (_backbrush != value)
                {
                    _backbrush = value;
                    OnPropertyChanged(("BackgroundBrush"));
                }
            }
        }


        private void OnClick(object obj)
        {
            //Image im = new Image();
            //FileOpenPicker open = new FileOpenPicker();
            //open.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            //open.ViewMode = PickerViewMode.Thumbnail;

            //// Filter to include a sample subset of file types
            //open.FileTypeFilter.Clear();
            //open.FileTypeFilter.Add(".bmp");
            //open.FileTypeFilter.Add(".png");
            //open.FileTypeFilter.Add(".jpeg");
            //open.FileTypeFilter.Add(".jpg");

            //// Open a stream for the selected file
            //StorageFile file = await open.PickSingleFileAsync();

            //// Ensure a file was selected
            //if (file != null)
            //{
            //    // Ensure the stream is disposed once the image is loaded
            //    using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            //    {
            //       await BitImag.SetSourceAsync(fileStream);                  
            //    }
            //    ImageUrl = file.Path;
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    //Specifies the state
    public enum State
    {
        Expand,
        Collapse,
        None
    };

}
