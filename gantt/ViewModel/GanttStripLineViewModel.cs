#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.Gantt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.ganttdemos.wpf
{
    public class GanttStripLineViewModel : NotificationObject
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public GanttStripLineViewModel()
        {
            InitialSetup();
        }

        #endregion

        #region Private Members

        private string _repeatStripContent = "Weekly Team Meeting";
        private string _nonRepeatStripContent = "Product Development Started";
        private Brush _repeatStripColor = (Brush)new BrushConverter().ConvertFrom("#FFF9E362");
        private Brush _nonRepeatStripColor = (Brush)new BrushConverter().ConvertFrom("#81F1DE");
        private ObservableCollection<TaskDetails> _taskCollection;
        private ObservableCollection<Resource> _resourceCollection;
        private List<StripLineInfo> _stripCollection;
        List<StripLineInfo> Slots;
        private DelegateCommand<object> _noneChecked;
        private DelegateCommand<object> _nonWorkingHoursChecked;
        private DelegateCommand<object> _workingHoursChecked;
        private DelegateCommand<object> _splStripChecked;
        private DelegateCommand<object> _buttonClick;
        LinearGradientBrush linearBrush = GanttDictionaries.GanttStyleDictionary["BackgroundBrush"] as LinearGradientBrush;

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<TaskDetails> TaskCollection
        {
            get
            {
                return _taskCollection;
            }
            set
            {
                _taskCollection = value;
            }
        }

        /// <summary>
        /// Gets or sets the gantt resources.
        /// </summary>
        /// <value>The gantt resources.</value>
        public ObservableCollection<Resource> ResourceCollection
        {
            get
            {
                return _resourceCollection;
            }
            set
            {
                _resourceCollection = value;
            }
        }

        /// <summary>
        /// Gets or sets the strip collection.
        /// </summary>
        /// <value>The strip collection.</value>
        public List<StripLineInfo> StripCollection
        {
            get
            {
                return _stripCollection;
            }
            set
            {
                _stripCollection = value;
                RaisePropertyChanged("StripCollection");
            }
        }

        /// <summary>
        /// Gets or sets the content of the repeat strip.
        /// </summary>
        /// <value>The content of the repeat strip.</value>
        public string RepeatStripContent
        {
            get
            {
                return _repeatStripContent;
            }
            set
            {
                _repeatStripContent = value;
                RaisePropertyChanged("RepeatStripContent");
            }
        }

        /// <summary>
        /// Gets or sets the content of the non repeat strip.
        /// </summary>
        /// <value>The content of the non repeat strip.</value>
        public string NonRepeatStripContent
        {
            get
            {
                return _nonRepeatStripContent;
            }
            set
            {
                _nonRepeatStripContent = value;
                RaisePropertyChanged("NonRepeatStripContent");
            }
        }

        /// <summary>
        /// Gets or sets the color of the repeat strip.
        /// </summary>
        /// <value>The color of the repeat strip.</value>
        public Brush RepeatStripColor
        {
            get
            {
                return _repeatStripColor;
            }
            set
            {
                _repeatStripColor = value;
                RaisePropertyChanged("RepeatStripColor");
            }
        }

        /// <summary>
        /// Gets or sets the color of the non repeat strip.
        /// </summary>
        /// <value>The color of the non repeat strip.</value>
        public Brush NonRepeatStripColor
        {
            get
            {
                return _nonRepeatStripColor;
            }
            set
            {
                _nonRepeatStripColor = value;
                RaisePropertyChanged("NonRepeatStripColor");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initials the setup.
        /// </summary>
        private void InitialSetup()
        {
            GanttStripLineModel task = new GanttStripLineModel();
            this._taskCollection = task.TaskCollection;
            this.ResourceCollection = task.ResourceCollection;
            _stripCollection = GetStripCollection();
            _noneChecked = new DelegateCommand<object>(OnNoneChecked, CanExecute);
            _nonWorkingHoursChecked = new DelegateCommand<object>(OnNonWorkingHoursChecked, CanExecute);
            _workingHoursChecked = new DelegateCommand<object>(OnWorkingHoursChecked, CanExecute);
            _splStripChecked = new DelegateCommand<object>(OnSplStripChecked, CanExecute);
            _buttonClick = new DelegateCommand<object>(OnButtonclick, CanExecute);
        }

        /// <summary>
        /// Gets the strip collection.
        /// </summary>
        /// <returns></returns>
        private List<StripLineInfo> GetStripCollection()
        {
            StyleSelector styleSelector = GanttDictionaries.GanttStyleDictionary["styleselector"] as StyleSelector;
            DataTemplateSelector templateSelector = GanttDictionaries.GanttStyleDictionary["tempselector"] as DataTemplateSelector;
            DataTemplate template = GanttDictionaries.GanttStyleDictionary["temp"] as DataTemplate;

            List<StripLineInfo> data = new List<StripLineInfo>();
            data.Add(new StripLineInfo() { Content = RepeatStripContent, StartDate = new DateTime(2012, 6, 4), EndDate = new DateTime(2012, 6, 4), HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, Background = RepeatStripColor, RepeatBehavior = Repeat.Week, RepeatFor = 1, RepeatUpto = new DateTime(2012, 12, 10), ContentTemplate = template });
            data.Add(new StripLineInfo() { Content = NonRepeatStripContent, StartDate = new DateTime(2012, 6, 1), EndDate = new DateTime(2012, 6, 1), HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, Background = NonRepeatStripColor });
            data.Add(new StripLineInfo() { Content = "Demo of the product to Customer", StartDate = new DateTime(2012, 12, 13), EndDate = new DateTime(2012, 12, 13), HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, Background = (Brush)new BrushConverter().ConvertFrom("#FFF79608") });
            return data;
        }

        #endregion

        #region Delegate Commands

        /// <summary>
        /// Gets the none checked.
        /// </summary>
        /// <value>The none checked.</value>
        public DelegateCommand<object> NoneChecked
        {
            get
            {
                return _noneChecked;
            }
        }

        /// <summary>
        /// Gets the non working hours checked.
        /// </summary>
        /// <value>The non working hours checked.</value>
        public DelegateCommand<object> NonWorkingHoursChecked
        {
            get
            {
                return _nonWorkingHoursChecked;
            }
        }

        /// <summary>
        /// Gets the working hours checked.
        /// </summary>
        /// <value>The working hours checked.</value>
        public DelegateCommand<object> WorkingHoursChecked
        {
            get
            {
                return _workingHoursChecked;
            }
        }

        /// <summary>
        /// Gets the SPL strip checked.
        /// </summary>
        /// <value>The SPL strip checked.</value>
        public DelegateCommand<object> SplStripChecked
        {
            get
            {
                return _splStripChecked;
            }
        }

        /// <summary>
        /// Gets the button click.
        /// </summary>
        /// <value>The button click.</value>
        public DelegateCommand<object> ButtonClick
        {
            get
            {
                return _buttonClick;
            }
        }

        #endregion

        #region DelegateCommand Methods

        /// <summary>
        /// Called when [none checked].
        /// </summary>
        /// <param name="parms">The parms.</param>
        private void OnNoneChecked(object parms)
        {
            this.StripCollection = GetStripCollection();
        }

        /// <summary>
        /// Called when [non working hours checked].
        /// </summary>
        /// <param name="parms">The parms.</param>
        private void OnNonWorkingHoursChecked(object parms)
        {
            Slots = new List<StripLineInfo>();
            Slots.Add(new StripLineInfo() { Background = linearBrush, StartDate = new DateTime(2012, 5, 19), EndDate = new DateTime(2012, 5, 21), RepeatUpto = new DateTime(2012, 12, 24), RepeatBehavior = Repeat.Week, RepeatFor = 1 });
            this.StripCollection = Slots;
        }

        /// <summary>
        /// Called when [working hours checked].
        /// </summary>
        /// <param name="parms">The parms.</param>
        private void OnWorkingHoursChecked(object parms)
        {
            Slots = new List<StripLineInfo>();
            Slots.Add(new StripLineInfo() { Background = linearBrush, StartDate = new DateTime(2012, 5, 21), EndDate = new DateTime(2012, 5, 26), RepeatUpto = new DateTime(2012, 12, 24), RepeatBehavior = Repeat.Week, RepeatFor = 1 });
            this.StripCollection = Slots;
        }

        /// <summary>
        /// Called when [SPL strip checked].
        /// </summary>
        /// <param name="parms">The parms.</param>
        private void OnSplStripChecked(object parms)
        {
            DataTemplate temp = GanttDictionaries.GanttStyleDictionary["SplDays"] as DataTemplate;
            Slots = new List<StripLineInfo>();
            Slots.Add(new StripLineInfo() { Background = Brushes.HotPink, StartDate = new DateTime(2012, 5, 21), EndDate = new DateTime(2012, 5, 21), Content = "Weekly Team Meeting", VerticalContentAlignment = VerticalAlignment.Center, RepeatUpto = new DateTime(2012, 12, 24), RepeatBehavior = Repeat.Week, RepeatFor = 1, ContentTemplate = temp });
            this.StripCollection = Slots;
        }

        /// <summary>
        /// Called when [buttonclick].
        /// </summary>
        /// <param name="parms">The parms.</param>
        private void OnButtonclick(object parms)
        {
            if (this.StripCollection.Count > 1)
            {
                this.StripCollection[0].Content = this.RepeatStripContent;
                this.StripCollection[1].Content = this.NonRepeatStripContent;
                this.StripCollection[0].Background = this.RepeatStripColor;
                this.StripCollection[1].Background = this.NonRepeatStripColor;
            }
        }

        /// <summary>
        /// Determines whether this instance can execute the specified parms.
        /// </summary>
        /// <param name="parms">The parms.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can execute the specified parms; otherwise, <c>false</c>.
        /// </returns>
        bool CanExecute(object parms)
        {
            return true;
        }

        #endregion
    }
}