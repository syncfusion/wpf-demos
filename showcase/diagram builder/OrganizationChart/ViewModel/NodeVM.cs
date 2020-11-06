#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DiagramBuilder.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OrganizationChart.ViewModel
{
    public class OrganizationChartNodeVM : NodeVM
    {
        #region Constructor
        public OrganizationChartNodeVM()
        {
            
        }

        #endregion
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);            
        }
        #region Public Properties

        private CustomContent _customcontent;
        private string _CustomContentTemplate;

        [DataMember]
        public CustomContent CustomContent
        {
            get { return _customcontent; }
            set
            {
                if(_customcontent != value)
                {
                    _customcontent = value;
                    Content = CustomContent;
                    OnPropertyChanged("Content");
                }
            }
        }

        [DataMember]
        public string CustomContentTemplate
        {
            get { return _CustomContentTemplate; }
            set
            {
                if (_CustomContentTemplate != value)
                {
                    ResourceDictionary resourceDictionary = new ResourceDictionary()
                    {
                        Source = new Uri(@"/syncfusion.diagrambuilder.Wpf;component/OrganizationChart/Theme/OrganizationChartUI.xaml", UriKind.RelativeOrAbsolute)
                    };

                    _CustomContentTemplate = value;
                    ContentTemplate = resourceDictionary[CustomContentTemplate] as DataTemplate;
                    OnPropertyChanged("Content");
                }
            }
        }

        private string parentID;
        
        [DataMember]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                if (parentID != value)
                {
                    parentID = value;
                    OnPropertyChanged("ParentID");
                }
            }
        }
        private string _type;

        [DataMember]
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        #endregion

        #region Public Commands
        private DelegateCommand<object> expandCollapseCommand;

        public DelegateCommand<object> ExpandCollapseCommand
        {
            get
            {
                return expandCollapseCommand ??
                    (expandCollapseCommand = new DelegateCommand<object>(ExpandCollapseCommandExecute));
            }
        }
        #endregion
        #region Private Methods
        private void ExpandCollapseCommandExecute(object param)
        {
            ExpandCollapseParameter parameter = new ExpandCollapseParameter()
            {
                Node = this,
                IsUpdateLayout = true
            };
            ((this.Info as INodeInfo).Graph as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
        }
        private void Annotation_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Mode"))
            {
                LabelVM annotaiton = sender as LabelVM;
                if (annotaiton != null && annotaiton.Mode == ContentEditorMode.View)
                {
                    TextBlock textblock = new TextBlock();
                    textblock.RenderTransformOrigin = new Point(0.5, 0.5);
                    textblock.Width = this.UnitWidth;
                    textblock.Text = annotaiton.Content.ToString();
                    textblock.TextWrapping = annotaiton.WrapText;
                    textblock.FontStyle = annotaiton.FontStyle;
                    textblock.FontSize = annotaiton.FontSize;
                    textblock.Foreground = annotaiton.LabelForeground;
                    textblock.FontWeight = annotaiton.FontWeight;
                    textblock.FontFamily = annotaiton.Font;
                    textblock.HorizontalAlignment = annotaiton.HorizontalAlignment;
                    textblock.VerticalAlignment = annotaiton.VerticalAlignment;
                    textblock.TextAlignment = annotaiton.TextHorizontalAlignment;
                    textblock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                }
            }
        }
        #endregion
    }

    [DataContract]
    public class CustomContent : INotifyPropertyChanged
    {

        private double _imagevisibility = 100;

        [DataMember]
        public double ImageVisibility
        {
            get { return _imagevisibility; }
            set
            {
                if (_imagevisibility != value)
                {
                    _imagevisibility = value;
                    OnPropertyChanged("ImageVisibility");
                }
            }
        }


        private string _name = "Name";

        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _role = "Role";

        [DataMember]
        public string Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged("Role");
                }
            }
        }

        private string _image = "/syncfusion.diagrambuilder.wpf;component/Resources/male.png";

        [DataMember]
        public string Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }        

        private object _templatecolor = "#FF4F88BB";

        [DataMember]
        public object Templatecolor
        {
            get { return _templatecolor; }
            set
            {
                if (_templatecolor != value)
                {
                    _templatecolor = value;
                    OnPropertyChanged("Templatecolor");
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
