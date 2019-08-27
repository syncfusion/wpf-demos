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
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using DiagramFrontPageUtility;
using Syncfusion.Windows.Controls.Media;
using Syncfusion.Windows.Tools.Controls;

namespace FloorPlanner
{
    //[DataContract]
    public class FloorPlannerViewModel : DiagramCommonViewModel
    {        

        private FloorPlanNode _SelectedObject;
        public FloorPlanNode SelectedObject
        {
            get { return _SelectedObject; }
            set
            {
                if (_SelectedObject != null)
                {
                    _SelectedObject = value;
                    OnPropertyChanged("SelectedObject");
                }
            }
        }

        private string _selectbrush;

        [DataMember]
        public string SelectedBrush
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
                    OnPropertyChanged("SelectedBrush");
                }
            }
        }

        private Visibility m_DiagramVisibility = Visibility.Collapsed;
        public new Visibility DiagramVisibility
        {
            get { return m_DiagramVisibility; }
            set
            {
                if (m_DiagramVisibility != value)
                {
                    m_DiagramVisibility = value;
                    OnPropertyChanged("DiagramVisibility");
                }
            }
        }      

        private ICommand m_Back;
        public ICommand Back
        {
            get { return m_Back; }
            set
            {
                if (m_Back != value)
                {
                    m_Back = value;
                    OnPropertyChanged("Back");
                }
            }
        }

        private ICommand m_GoBack;
        public ICommand GoBack
        {
            get { return m_GoBack; }
            set
            {
                if (m_GoBack != value)
                {
                    m_GoBack = value;
                    OnPropertyChanged("GoBack");
                }
            }
        }

        private ICommand m_SelectEditor;
        public ICommand SelectEditor
        {
            get {return m_SelectEditor ;}
            set
            {
                if (m_SelectEditor != value)
                {
                    m_SelectEditor = value;
                    OnPropertyChanged("SelectEditor");
                }
            }
        }

        private string m_CurrentlyLoaded;
        public string CurrentlyLoaded
        {
            get { return m_CurrentlyLoaded; }
            set
            {
                if (m_CurrentlyLoaded != value)
                {
                    m_CurrentlyLoaded = value;
                    OnPropertyChanged("CurrentlyLoaded");
                }
            }
        }

        private ICommand m_Save;
        public ICommand Save
        {
            get { return m_Save; }
            set
            {
                if (m_Save != value)
                {
                    m_Save = value;
                    OnPropertyChanged("Save");
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

        private ICommand m_Create;
        public new ICommand Create
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

        private ICommand _mdelete;
        public ICommand Delete
        {
            get
            {
                return _mdelete;
            }
            set
            {
                if (_mdelete != value)
                {
                    _mdelete = value;
                    OnPropertyChanged("Delete");
                }
            }
        }

        private ICommand _mclear;
        public ICommand Clear
        {
            get
            {
                return _mclear;
            }
            set
            {
                if (_mclear != value)
                {
                    _mclear = value;
                    OnPropertyChanged("Clear");
                }
            }
        }

        private ICommand _maddwall;
        public ICommand AddWall
        {
            get
            {
                return _maddwall;
            }
            set
            {
                if (_maddwall != value)
                {
                    _maddwall = value;
                    OnPropertyChanged("AddWall");
                }
            }
        }

        private ICommand _maddshape;
        public ICommand AddShape
        {
            get
            {
                return _maddshape;
            }
            set
            {
                if (_maddshape != value)
                {
                    _maddshape = value;
                    OnPropertyChanged("AddShape");
                }
            }
        }

        private ICommand _maddprop;
        public ICommand AddProp
        {
            get
            {
                return _maddprop;
            }
            set
            {
                if (_maddprop != value)
                {
                    _maddprop = value;
                    OnPropertyChanged("AddProp");
                }
            }
        }

        private ICommand _maddtext;
        public ICommand AddText
        {
            get
            {
                return _maddtext;
            }
            set
            {
                if (_maddtext != value)
                {
                    _maddtext = value;
                    OnPropertyChanged("AddText");
                }
            }
        }

        private ObservableCollection<FloorPlanSymbolItem> _symbols = null;
        public ObservableCollection<FloorPlanSymbolItem> SymbolCollection
        {
            get
            {
                return _symbols;

            }
            set
            {
                if (_symbols != value)
                {
                    _symbols = value;
                    OnPropertyChanged("SymbolCollection");
                }
            }
        }

        private string _value = string.Empty;
        public string StencilValue
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged("StencilValue");
                }
            }
        }

        private string _text;
         [DataMember]
        public string TitleText
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
                    OnPropertyChanged("TitleText");
                }
            }
        }

         private bool m_enable = false;
         public bool Enabled
         {
             get
             {
                 return m_enable;
             }
             set
             {
                 if (m_enable != value)
                 {
                     m_enable = value;
                     OnPropertyChanged("Enabled");
                 }
             }
         }

         private bool _istextadd=false;
         public bool IsTextAdd
         {
             get
             {
                 return _istextadd;
             }
             set
             {
                 if (_istextadd != value)
                 {
                     _istextadd = value;
                     OnPropertyChanged("IsTextAdd");
                 }
             }
         }

        private ICommand _font;
        public ICommand TitleFont
        {
            get
            {
                return _font;
            }
            set
            {
                if (_font != value)
                {
                    _font = value;
                    OnPropertyChanged("TitleFont");
                }
            }
        }

        private ICommand _fontsize;
        public ICommand TitleFontSize
        {
            get
            {
                return _fontsize;
            }
            set
            {
                if (_fontsize != value)
                {
                    _fontsize = value;
                    OnPropertyChanged("TitleFontSize");
                }
            }
        }

        private ICommand _mdeleteobj;

        public ICommand DeleteSelectedObject
        {
            get
            {
                return _mdeleteobj;
            }
            set
            {
                if (_mdeleteobj != value)
                {
                    _mdeleteobj = value;
                    OnPropertyChanged("DeleteSelectedObject");
                }
            }

        }

        private ObservableCollection<string> _family = new ObservableCollection<string>()
            {
               "Segoe UI",
                "Verdana",
                "Calibri Light",
                "Times New Roman",
                "Consolas",
                "Arial",
                "Century Gothic",
                "Cambria"
            };
        public ObservableCollection<string> FamilyCollection
        {
            get
            {
                return _family;
            }
            set
            {
                if (_family != value)
                {
                    _family = value;
                    OnPropertyChanged("FamilyCollection");
                }
            }
        }
       
        private ObservableCollection<double> _size = new ObservableCollection<double>()
        {
            8,9,10,11,12,14,16,18,20,22,24,26
        };

        public ObservableCollection<double> SizeCollection
        {
            get
            {
                return _size;
            }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged("SizeCollection");
                }
            }
        }

        private string _textfont="Segoe UI";
        public string TextFont
        {
            get
            {
                return _textfont;
            }
            set
            {
                if (_textfont != value)
                {
                    _textfont = value;
                    OnPropertyChanged("TextFont");
                }
            }
        }

        private double _textsize=12;
        public double TextSize
        {
            get
            {
                return _textsize;
            }
            set
            {
                if (_textsize != value)
                {
                    _textsize = value;
                    OnPropertyChanged("TextSize");
                }
            }
        }
        //private Ig _SelectedObject;
        //public FloorPlanNode SelectedObject
        //{
        //    get { return _SelectedObject; }
        //    set
        //    {
        //        _SelectedObject = value;
        //        OnPropertyChanged("SelectedObject");
        //    }
        //}

        private ICommand _bold;
        public ICommand BoldCommand
        {
            get
            {
                return _bold;
            }
            set
            {
                if (_bold != value)
                {
                    _bold = value;
                    OnPropertyChanged("BoldCommand");
                }
            }
        }

        private ICommand _italic;
        public ICommand ItalicCommand
        {
            get
            {
                return _italic;
            }
            set
            {
                if (_italic != value)
                {
                    _italic = value;
                    OnPropertyChanged("ItalicCommand");
                }
            }
        }

        private ICommand _line;
        public ICommand Strokes
        {
            get
            {
                return _line;
            }
            set
            {
                if (_line != value)
                {
                    _line = value;
                    OnPropertyChanged("Strokes");
                }
            }
        }

        private ICommand _fore;
        public ICommand ForgroundColor
        {
            get
            {
                return _fore;
            }
            set
            {
                if (_fore != value)
                {
                    _fore = value;
                    OnPropertyChanged("ForgroundColor");
                }
            }
        }

        private ICommand textchanged;
        public ICommand TextChanged
        {
            get { return textchanged; }
            set
            {
                if (textchanged != value)
                {
                    textchanged = value;
                    OnPropertyChanged("TextChanged");
                }
            }
        }

        private ICommand fcolorchanged;
        public ICommand ForeColorChanged
        {
            get { return fcolorchanged; }
            set
            {
                if (fcolorchanged != value)
                {
                    fcolorchanged = value;
                    OnPropertyChanged("ForeColorChanged");
                }
            }
        }

        private ICommand _cancel;
        public ICommand CancelCommand
        {
            get { return _cancel; }
            set
            {
                if (_cancel != value)
                {
                    _cancel = value;
                    OnPropertyChanged("CancelCommand");
                }
            }
        }

        private ICommand _ok;
        public ICommand OKCommand
        {
            get { return _ok; }
            set
            {
                if (_ok != value)
                {
                    _ok = value;
                    OnPropertyChanged("OKCommand");
                }
            }
        }

        private string _textcolor = "#FFFF7300";
        public string TextColor
        {
            get
            {
                return _textcolor;
            }
            set
            {
                if (_textcolor != value)
                {
                    _textcolor = value;
                    OnPropertyChanged("TextColor");
                }
            }
        }

        private string _type;
        public string ValueType
        {
            get
            {
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged("ValueType");
                }
            }
        }

        //private PreviewItem _mpreview;
        //public PreviewItem Preview
        //{
        //    get
        //    {
        //        return _mpreview;
        //    }
        //    set
        //    {
        //        if (_mpreview != value)
        //        {
        //            _mpreview = value;
        //            OnPropertyChanged("Preview");
        //        }
        //    }
        //}

        private FloorPlanNode _mpreviewnode;
        public FloorPlanNode PreviewNode
        {
            get
            {
                return _mpreviewnode;
            }
            set
            {
                if (_mpreviewnode != value)
                {
                    _mpreviewnode = value;
                    OnPropertyChanged("PreviewNode");
                }
            }
        }

        private TextBox _box;
        public TextBox textbox
        {
            get
            {
                return _box;
            }
            set
            {
                if (_box != value)
                {
                    _box = value;
                    OnPropertyChanged("textbox");
                }
            }
        }

      
    }

    public class SymbolCollectionType : INotifyPropertyChanged
    {
        public SymbolCollectionType()
        {
        }

        private string _type;
        public string ValueType
        {
            get
            {
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged("ValueType");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
    }

    public class TextCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(TextCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            TextBox textBox = depObj as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += textBox_TextChanged;
            }
        }

        static void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            if (textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.Black);

                ICommand command = textBox.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(textBox.Text);
                }
            }
        }

        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    public class ComboboxCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
      typeof(ComboboxCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ComboBox c = depObj as ComboBox;
            if (c != null)
            {
                c.SelectionChanged += c_SelectionChanged;
            }
        }

        static void c_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = (sender as ComboBox);
            if (box != null)
            {
                ICommand command = box.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(box.SelectedItem);
                }
            }
        }

        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    public class ListBoxCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
     typeof(ListBoxCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {

            ColorPickerPalette c = depObj as ColorPickerPalette;
            if (c != null)
            {
                c.ColorChanged += c_SelectedColorChanged;
            }
        }

        static void c_SelectedColorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPickerPalette box = (sender as ColorPickerPalette);
            if (box != null)
            {
                ICommand command = box.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(box.Color);
                }
            }
        }

        static void c_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    public class ButtonCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
   typeof(ButtonCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ToggleButton b = depObj as ToggleButton;
            if (b != null)
            {
                b.Click += b_Click;
            }
        }

        static void b_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton box = (sender as ToggleButton);
            if (box != null)
            {
                ICommand command = box.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(box);
                }
            }
        }


        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    public class DeleteButtonCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
   typeof(DeleteButtonCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            Button b = depObj as Button;
            if (b != null)
            {
                ICommand command = b.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(b);
                }
                b.Click += b_Click;
            }
        }

        static void b_Click(object sender, RoutedEventArgs e)
        {
            Button box = (sender as Button);
            if (box != null)
            {
                ICommand command = box.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(box.Name);
                }
            }
        }


        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    public class ContentPresenters : ContentPresenter
    {

        public ContentPresenters()
        {

        }

        public SolidColorBrush Foreground
        {
            get { return (SolidColorBrush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(SolidColorBrush), typeof(ContentPresenters), new PropertyMetadata(new SolidColorBrush(Colors.DarkGray)));


    }
}
