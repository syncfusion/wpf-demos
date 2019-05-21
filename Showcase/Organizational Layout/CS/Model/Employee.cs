#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OrganizationalChartDemo
{
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private double salary;
        private string destination;
        private string imageurl;
        private string doj;
        private State isexpand;
        private bool issearch = false;
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

        public ObservableCollection<string> Designation
        {
            get
            {
                return _disp;
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

        private NodeFocusState isfocus;
        public NodeFocusState IsFocus
        {
            get
            {
                return isfocus;
            }
            set
            {
                if (isfocus != value)
                {
                    isfocus = value;
                    if (value == NodeFocusState.Normal)
                    {
                        BackgroundBrush = new SolidColorBrush(Colors.Transparent);
                    }
                    else if (value == NodeFocusState.MouseHover)
                    {
                        Color c = Color.FromArgb(255, 239, 239, 239);
                        BackgroundBrush = new SolidColorBrush(c);
                    }
                    else if (value == NodeFocusState.Focused)
                    {
                        BackgroundBrush = ColorConverter(RatingColor);
                    }
                    OnPropertyChanged(("IsFocus"));
                }
            }
        }

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
                        OnPropertyChanged(("RatingColor"));
                    }
                }
            }
        }
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public enum State
    {
        Expand,
        Collapse,
        None
    };

    public enum NodeFocusState
    {
        Normal,
        MouseHover,
        Focused
    };
}
