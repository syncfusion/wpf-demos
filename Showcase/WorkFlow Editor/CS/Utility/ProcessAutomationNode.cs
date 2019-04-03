#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DiagramFrontPageUtility;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using SPath = System.Windows.Shapes.Path;
namespace WorkFlowEditor
{
    public class ProcessAutomationNode : NodeViewModel
    {
        public ProcessAutomationNode()
        {
            ID = Guid.NewGuid().ToString();
        }

        private string type;

        [DataMember]
        public string NodeType
        {
            get
            {
                return type;
            }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged("NodeType");
                }
            }
        }
        private NodeContent _content;

        [DataMember]
        public NodeContent NodeContent
        {
            get
            {
                return _content;
            }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    OnPropertyChanged("NodeContent");
                }
            }
        }       

        public Node AnimationNode
        {
            get;
            set;
        }
    }

    [DataContract]
    public class NodeContent : INotifyPropertyChanged, IDisposable
    {
        public NodeContent()
        {
            Properties = new ObservableCollection<Property>();
            AddProperty = new DelegateCommand<object>(OnAddProperty, args => { return true; });
            DeleteProperty = new DelegateCommand<object>(OnDeleteProperty, args => { return true; });
        }

        private void OnDeleteProperty(object exsist)
        {
            int index = Properties.IndexOf(exsist as Property);
            Properties.RemoveAt(index);
        }



        private bool _isdecison=true;

        

        [DataMember]
        public bool IsNotDecision
        {
            get
            {
                return _isdecison;
            }
            set
            {
                if (_isdecison != value)
                {
                    _isdecison = value;
                    OnPropertyChanged("IsNotDecision");
                }
            }
        }
        private bool _propertyenabled=false;

        public bool IsPropertiesEnabled
        {
            get
            {
                return _propertyenabled;
            }
            set
            {
                if (_propertyenabled != value)
                {
                    _propertyenabled = value;
                    OnPropertyChanged("IsPropertiesEnabled");
                }
            }
        }


        private void OnAddProperty(object newproperty)
        {
                Properties.Add(new Property() { Name = "Property+1", Type = "String" });
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(Name));
            }
        }

        private SolidColorBrush _bbrush = new SolidColorBrush(Colors.Transparent);

        public SolidColorBrush BorderBrush
        {
            get
            {
                return _bbrush;
            }
            set
            {
                if (_bbrush != value)
                {
                    _bbrush = value;
                    OnPropertyChanged("BorderBrush");
                }
            }
        }

        private Thickness _bthich = new Thickness(0);

        public Thickness BorderThick
        {
            get
            {
                return _bthich;
            }
            set
            {
                if (_bthich != value)
                {
                    _bthich = value;
                    OnPropertyChanged("BorderThick");
                }
            }
        }



        private SolidColorBrush _fill=new SolidColorBrush(Colors.Aqua);
       
        public SolidColorBrush FillBrush
        {
            get
            {
                return _fill;
            }
            set
            {
                if (_fill != value)
                {
                    _fill = value;
                    OnPropertyChanged("FillBrush");
                }
            }
        }

        private bool istask = false;

        [DataMember]
        public bool IsTask
        {
            get
            {
                return istask;
            }
            set
            {
                if (istask != value)
                {
                    istask = value;
                    OnPropertyChanged("IsTask");
                }
            }

        }
        private string _text;

        [DataMember]
        public string DispalyText
        {
            get
            {
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged("DispalyText");
                }
            }
        }
        private ObservableCollection<Property> m_Properties;

        //private ObservableCollection<Property> m_Functions;

        [DataMember]
        public ObservableCollection<Property> Properties
        {
            get { return m_Properties; }
            set
            {
                if (m_Properties != value)
                {
                    m_Properties = value;
                    OnPropertyChanged("Properties");
                }
            }
        }

        private ICommand m_addproperty;

        [IgnoreDataMember]
        public ICommand AddProperty
        {
            get
            {
                return m_addproperty;
            }
            set
            {
                if (m_addproperty != value)
                {
                    m_addproperty = value;
                    OnPropertyChanged("AddProperty");
                }
            }
        }

        private ICommand m_deleteproperty;

        [IgnoreDataMember]
        public ICommand DeleteProperty
        {
            get
            {
                return m_deleteproperty;
            }
            set
            {
                if (m_deleteproperty != value)
                {
                    m_deleteproperty = value;
                    OnPropertyChanged("DeleteProperty");
                }
            }
        }

        private ICommand _save;
        public ICommand Save
        {
            get
            {
                return _save;
            }
            set
            {
                if (_save != value)
                {
                    _save = value;
                    OnPropertyChanged("Save");
                }
            }
        }

        private ICommand _openeditor;
        public ICommand OpenEditor
        {
            get
            {
                return _openeditor;
            }
            set
            {
                if (_openeditor != value)
                {
                    _openeditor = value;
                    OnPropertyChanged("OpenEditor");
                }
            }
        }

        private ICommand _done;

        public ICommand Done
        {
            get
            {
                return _done;
            }
            set
            {
                if (_done != value)
                {
                    _done = value;
                    OnPropertyChanged("Done");
                }
            }
        }



        public void Dispose()
        {
            Save = null;
            Done = null;
            OpenEditor = null;
            AddProperty = null;
            Properties = null;
            PropertyChanged = null;
        }
    }

    [DataContract]
    public class Property : INotifyPropertyChanged
    {
        private string m_Name;

        [DataMember]
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

        private string m_propertyvalue;
        [DataMember]
        public string PropertyValue
        {
            get
            {
                return m_propertyvalue;
            }
            set
            {
                if (m_propertyvalue != value)
                {
                    m_propertyvalue = value;
                    OnPropertyChanged("PropertyValue");
                }
            }
        }
        private string m_type;
        [DataMember]
        public string Type
        {
            get
            {
                return m_type;
            }
            set
            {
                if (m_type != value)
                {
                    if (value != null)
                    {
                        m_type = value;
                        OnPropertyChanged("Type");
                    }
                }
            }
        }
        [IgnoreDataMember]
        public ICommand Checked
        {
            get
            {
                return new DelegateCommand<object>(Onchecked, args => { return true; });
            }
        }

        private void Onchecked(object obj)
        {
            this.Type = obj.ToString();
        }

        [DataMember]
        private ObservableCollection<string> types = new ObservableCollection<string>()
       {
          "Double",
          "DatePicker",
          "ColorPicker",
          "Rating",
          "TimePicker"
       };

        [DataMember]
        public ObservableCollection<string> ValueType
        {
            get
            {
                return types;
            }
            set
            {
                if (types != null)
                {
                    types = value;
                    OnPropertyChanged("ValueType");
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
    }

    //public class MidArrowConnector : Connector
    //{
    //    public MidArrowConnector()
    //    {
    //        this.Loaded += MidArrowConnector_Loaded;
    //    }

    //    void MidArrowConnector_Loaded(object sender, RoutedEventArgs e)
    //    {
    //        TransformGroup TargetDecoratorTransform = PART_TargetDecorator.RenderTransform as TransformGroup;
    //        Point midPoint = new Point(SourcePoint.X + (TargetPoint.X - SourcePoint.X) / 2,
    //                                    SourcePoint.Y + (TargetPoint.Y - SourcePoint.Y) / 2);
    //        (TargetDecoratorTransform.Children[2] as TranslateTransform).X = midPoint.X - PART_TargetDecorator.ActualWidth;
    //        (TargetDecoratorTransform.Children[2] as TranslateTransform).Y = midPoint.Y - PART_TargetDecorator.ActualHeight / 2;
    //    }
    //    private SPath PART_TargetDecorator;

    //    public override void OnApplyTemplate()
    //    {
    //        base.OnApplyTemplate();
    //        PART_TargetDecorator = GetTemplateChild("PART_TargetDecorator") as SPath;
    //    }

    //    protected override Size ArrangeOverride(Size finalSize)
    //    {
    //        Size returnSize = base.ArrangeOverride(finalSize);
    //        TransformGroup TargetDecoratorTransform = PART_TargetDecorator.RenderTransform as TransformGroup;
    //        Point midPoint = new Point(SourcePoint.X + (TargetPoint.X - SourcePoint.X) / 2,
    //                                    SourcePoint.Y + (TargetPoint.Y - SourcePoint.Y) / 2);
    //        (TargetDecoratorTransform.Children[2] as TranslateTransform).X = midPoint.X - PART_TargetDecorator.ActualWidth;
    //        (TargetDecoratorTransform.Children[2] as TranslateTransform).Y = midPoint.Y - PART_TargetDecorator.ActualHeight / 2;
    //        return returnSize;
    //    }
    //}
   
    public class ProcessAutomationConnector : ConnectorViewModel
    {

        public ProcessAutomationConnector()
        {
            TargetDecorator = Geometry.Parse("M0,0 L60,25 L0,50");
             TargetDecoratorStyle = GetDecoratorStyle();
            SegmentDecoratorStyle = GetDecoratorStyle();
            SegmentDecorators = new ObservableCollection<ISegmentDecorator>()
            {
                new SegmentDecorator()
                 {                    
                    Shape = "M0,0 L10,5 L0,10",
                    Length = 0.4,
                    RelativeMode = SegmentDecoratorRelativeMode.Connector,
                    
                 }
            };
        }

        private Style GetDecoratorStyle()
        {
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.StrokeProperty, new SolidColorBrush(Colors.Black)));
            s.Setters.Add(new Setter(SPath.WidthProperty, 10d));
            s.Setters.Add(new Setter(SPath.HeightProperty, 10d));
            s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 1d));
            s.Setters.Add(new Setter(SPath.StretchProperty, Stretch.Fill));
            return s;
        }
        private bool isanimation=false;
        [DataMember]
        public bool IsAnimationApplied
        {
            get
            {
                return isanimation;
            }
            set
            {
                if (isanimation != value)
                {
                    isanimation = value;
                    OnPropertyChanged("IsAnimationApplied");
                }
            }
        }

        private bool _mUseforDecisionAnimation = false;

        [DataMember]
        public bool UseforDecisionAnimation
        {
            get
            {
                return _mUseforDecisionAnimation;
            }
            set
            {
                if (_mUseforDecisionAnimation != value)
                {
                    _mUseforDecisionAnimation = value;
                    OnPropertyChanged("UseforDecisionAnimation");
                }
            }
        }

    }

    

    public class ColortoBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                SolidColorBrush s = value as SolidColorBrush;
                return s.Color;
            }
            else
                return null;
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color c = (Color)value;
            return new SolidColorBrush(Color.FromArgb(c.A, c.R, c.G, c.B));
        }

    }
}
