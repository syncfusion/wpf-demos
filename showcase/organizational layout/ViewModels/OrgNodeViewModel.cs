#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
//using SampleBrowser;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.organizationallayout.wpf
{
    //Custom NodeViewModel
    public class OrgNodeViewModel :NodeViewModel
    {
        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.organizationallayout.wpf;component/Resources/OrgNodeContentTemplate.xaml", UriKind.RelativeOrAbsolute)
        };

        public OrgNodeViewModel()
        {
            UnitWidth = 185;
            UnitHeight = 65;
            ContentTemplate = resourceDictionary["employeeContentTemplate"] as DataTemplate;
           Constraints = Constraints ;
       
        }

        #region Variables
        private bool isadded = false;
        private bool visible = true;
        private int index;
        private double _x;
        private double _y;
        private Popup _custom = new Popup();
        private State _previousstate;

        public bool IsNew
        {
            get
            {
                return isadded;
            }
            set
            {
                if (isadded != value)
                {
                    isadded = value;
                    OnPropertyChanged("IsNew");
                }
            }
        }

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                if (index != value)
                {
                    index = value;
                    OnPropertyChanged("Index");
                }
            }
        }
      
        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (visible != value)
                {
                    visible = value;
                    OnPropertyChanged("Visible");
                }
            }
        }

        public double X
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

        public double Y
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

        public Popup CustomToolTip
        {
            get
            {
                return _custom;
            }
            set
            {
                if (_custom != value)
                {
                    _custom = value;
                    OnPropertyChanged("CustomToolTip");
                }
            }
        }

        public State PreviousState
        {
            get
            {
                return _previousstate;
            }
            set
            {
                if (_previousstate != value)
                {
                    _previousstate = value;
                    OnPropertyChanged("PreviousState");
                }
            }
        } 
        #endregion
    }

    //Custom ConnectorViewModel
    public class OrgConnectorViewModel : ConnectorViewModel
    {
        public OrgConnectorViewModel()
        {
            SolidColorBrush solid = new SolidColorBrush();
            solid.Color = Color.FromArgb(255, 186, 186, 186);
            this.ConnectorGeometryStyle = GetStyle(solid);
            this.Constraints = this.Constraints & ~ConnectorConstraints.Selectable;
        }

        private Style GetStyle(SolidColorBrush solid)
        {
            Style s = new Style();
            s.TargetType = typeof(Path);
            s.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, solid));
            s.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 1.20));
            return s;
        }

        private bool visible = true;

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (visible != value)
                {
                    visible = value;
                    OnPropertyChanged("Visible");
                }
            }
        }

        private double _opacity=1;

        public double ConnectorOpacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                if (_opacity != value)
                {
                    _opacity = value;
                    OnPropertyChanged("ConnectorOpacity");
                }
            }
        }
    }
}
