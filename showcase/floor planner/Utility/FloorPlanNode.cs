#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.floorplanner.wpf
{
    public class FloorPlanNode : Node
    {
        public FloorPlanNode()
        {
           NodeAnnotations=new ObservableCollection<object>();
           this.Constraints = this.Constraints & ~NodeConstraints.Connectable;
        }
        private string _mcontentname;

        [DataMember]
        public string ContentName
        {
            get
            {
                return _mcontentname;
            }
            set
            {
                if (_mcontentname != value)
                {
                    _mcontentname = value;
                    OnPropertyChanged("ContentName");
                }
            }
        }

        private bool _misTextNode=false;
        [DataMember]
        public bool IsTextNode
        {
            get
            {
                return _misTextNode;
            }
            set
            {
                if (_misTextNode != value)
                {
                    _misTextNode = value;
                    OnPropertyChanged("IsTextNode");
                }
            }
        }

        private bool _misshapeNode = false;
        [DataMember]
        public bool IsShapeNode
        {
            get
            {
                return _misshapeNode;
            }
            set
            {
                if (_misshapeNode != value)
                {
                    _misshapeNode = value;
                    OnPropertyChanged("IsShapeNode");
                }
            }
        }

        private string _font1="Segoe UI";
        [DataMember]
        public string Font
        {
            get
            {
                return _font1;
            }
            set
            {
                if (_font1 != value)
                {
                    _font1 = value;
                    OnPropertyChanged("Font");
                }
            }
        }

        private double _fontsize1=12;
        [DataMember]
        public double TextFontSize
        {
            get
            {
                return _fontsize1;
            }
            set
            {
                if (_fontsize1 != value)
                {
                    _fontsize1 = value;
                    OnPropertyChanged("TextFontSize");
                }
            }
        }

        private string _text;
        [DataMember]
        public string NodeText
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
                    OnPropertyChanged("NodeText");
                }
            }
        }

        private string _forecolor = "#FFFF7300";
        [DataMember]
        public string ForeColor
        {
            get
            {
                return _forecolor;
            }
            set
            {
                if (_forecolor != value)
                {
                    _forecolor = value;
                    OnPropertyChanged("ForeColor");
                }
            }
        }

        [DataMember]
        private string _textweight="Normal";
        public string TextWeight
        {
            get
            {
                return _textweight;
            }
            set
            {
                if (_textweight != value)
                {
                    _textweight = value;
                    OnPropertyChanged("TextWeight");
                }
            }
        }

         [DataMember]
        private FontStyle _textstyle=FontStyles.Normal;
        public FontStyle TextStyle
        {
            get
            {
                return _textstyle;
            }
            set
            {
                if (_textstyle != value)
                {
                    _textstyle = value;
                    OnPropertyChanged("TextStyle");
                }
            }
        }

        private string _selectbrush = "#FFFFFFFF";
        [DataMember]
        public string SelectedColor
        {
            get
            {
               // Foreground = new SolidColorBrush(PerceivedBrightness(_selectbrush.Color) > 130 ? Colors.Black : Colors.White);
                return _selectbrush;
            }
            set
            {
                if (_selectbrush != value)
                {
                    //if (type != null && type.StartsWith("sub") && value != null)
                    //{
                    //    Foreground = value;
                    //}
                    _selectbrush = value;
                    OnPropertyChanged("SelectedColor");
                }
            }
        }

        private bool isoption=false;
        [DataMember]
        public bool IsOption
        {
            get
            {
                return isoption;
            }
            set
            {
                if (isoption != value)
                {
                    isoption = value;
                    OnPropertyChanged("IsOption");
                }
            }
        }

        public ObservableCollection<object> NodeAnnotations
        {
            get
            {
                return (ObservableCollection<object>)this.Annotations;
            }
            set
            {
                if ((ObservableCollection<object>)this.Annotations != value)
                {
                    this.Annotations = value;
                    OnPropertyChanged("NodeAnnotations");
                }
            }
        }

    
        //private SolidColorBrush _foreground;
        //public SolidColorBrush Foreground
        //{
        //    get
        //    {
        //        if (type != null && type.StartsWith("sub"))
        //        {
        //            return SelectedBrush;
        //        }
        //        return _foreground;
        //    }
        //    set
        //    {
        //        if (_foreground != value)
        //        {
        //            _foreground = value;
        //            OnPropertyChanged("Foreground");
        //        }

        //    }
        //}


    }

    public class FloorPlanConnector : Connector
    {
        public ObservableCollection<object> ConnectorAnnotations
        {
            get
            {
                return (ObservableCollection<object>)this.Annotations;
            }
            set
            {
                if (this.Annotations != value)
                {
                    this.Annotations = value;
                    OnPropertyChanged("ConnectorAnnotations");
                }
            }
        }

        public FloorPlanConnector()
        {
            ConnectorAnnotations=new ObservableCollection<object>();
            Segments = new ConnectorSegments();
        }
        private double thick=6;
        [DataMember]
        public double ConThickness
        {
            get
            {
                return thick;
            }
            set
            {
                if (thick != value)
                {
                    thick = value;
                    OnPropertyChanged("ConThickness");
                }
            }
        }

        private bool isbesizer;
        [DataMember]
        public bool IsBesizer
        {
            get
            {
                return isbesizer;
            }
            set
            {
                if (isbesizer != value)
                {
                    isbesizer = value;
                    OnPropertyChanged("IsBesizer");
                }
            }
        }

        private string segment;
        [DataMember]
        public string SegmentType
        {
            get
            {
                return segment;
            }
            set
            {
                if (segment != value)
                {
                    segment = value;
                    OnPropertyChanged("SegmentType");
                }
            }
        }

        private string _bezier=string.Empty;
        [DataMember]
        public string BezierString
        {
            get
            {
                return _bezier;
            }
            set
            {
                if (_bezier != value)
                {
                    _bezier = value;
                    OnPropertyChanged("BezierString");
                }
            }
        }

        private string intermediate = string.Empty;
        [DataMember]
        public string IntermediateString
        {
            get
            {
                return intermediate;
            }
            set
            {
                if (intermediate != value)
                {
                    intermediate = value;
                    OnPropertyChanged("IntermediateString");
                }
            }
        }

        private bool issplit;
        [DataMember]
        public bool IsSplit
        {
            get
            {
                return issplit;
            }
            set
            {
                if (issplit != value)
                {
                    issplit = value;
                    OnPropertyChanged("IsSplit");
                }
            }

        }

        private bool iswallinfo=false;
        [DataMember]
        public bool IsWallInfo
        {
            get
            {
                return iswallinfo;
            }
            set
            {
                if (iswallinfo != value)
                {
                    iswallinfo = value;
                    OnPropertyChanged("IsWallInfo");
                }
            }
        }

       

    }

    public class FloorPlanDiagram : SfDiagram
    {
        public ContentControl Preview;
         
        public FloorPlanDiagram()
        {
           
           
        }

        public override void OnApplyTemplate()
        {
            // WPF-53352 Issue on "Tooltip for node show empty content" has been resolved.
            base.OnApplyTemplate();
            Preview = GetTemplateChild("previewrect") as ContentControl;
        }
        protected override Node GetNodeForItemOverride(object item)
        {
           return new FloorPlanNode();
        }

        protected override Connector GetConnectorForItemOverride(object item)
        {
            return new FloorPlanConnector();
        }

        protected override void SetTool(SetToolArgs args)
        {
            if (args.Source is IConnector)
            {
                args.Action = ActiveTool.Drag;
            }
            else
            base.SetTool(args); 
        }
    }
    public class StringtoVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomColorList : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<String> colors = new List<String>()
            {
                "#FF45B5B2",
                "#FF25a0da",
                "#FFED0006",
                "#FF00B25A",
                "#FFFFC425",
                "#FFE02B5F",
                "#FF6B9531",
                "#FF1D6080",
                "#FFDD789B",
                "#FF5D3AB8",
                "#FFF2875A",
                "#FF6E8FD4"
            };
            foreach (var item in colors)
            {
                yield return item;
            }
        }
    }

}
