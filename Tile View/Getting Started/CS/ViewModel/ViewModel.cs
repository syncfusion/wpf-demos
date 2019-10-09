#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using Syncfusion.Windows.Shared;
using System.Windows.Media;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System;

namespace TileViewConfigurationDemo
{
    public class ViewModel :NotificationObject
    {
        private ICommand EventLogCommand;
        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        public ObservableCollection<string> EventLog
        {
            get { return eventlog; }
            set { eventlog = value; }
        }
        public ICommand
         SelectionChanged
        {
            get
            {
                return EventLogCommand;
            }
        }
        public void PropertyChangedHandler(object param)
        {
            if(param !=null)
            EventLog.Add("Selection Changed:"+ param.ToString());
        }
        private ObservableCollection<Model> modelItems;
        public ObservableCollection<Model> ModelItems
        {
            get
            {
                return modelItems;
            }

            set
            {
                modelItems = value;
            }
        }

        private ObservableCollection<BookModel> bookModelItems;
        public ObservableCollection<BookModel> BookModelItems
        {
            get
            {
                return bookModelItems;
            }

            set
            {
                bookModelItems = value;
            }
        }

        #region TileView Properties

        private bool allowItemRepositioning = true;
        /// <summary>
        /// Gets or sets AllowItemRepositioning property of the TileViewControl.
        /// <value>
        ///<c>true</c> if TileViewItems reordering allowed; otherwise, <c>false</c>.
        /// </value>
        ///</summary>
        public bool AllowItemRepositioning
        {
            get
            {
                return allowItemRepositioning;
            }

            set
            {
                allowItemRepositioning = value;
                this.RaisePropertyChanged("AllowItemRepositioning");
            }
        }

        private bool enableTileAnimation = true;
        /// <summary>
        /// Gets or sets EnableTileAnimation property of the TileViewControl.
        /// <value>
        ///<c>true</c> if TileViewItems reordering allowed; otherwise, <c>false</c>.
        /// </value>
        ///</summary>
        public bool EnableTileAnimation
        {
            get
            {
                return enableTileAnimation;
            }

            set
            {
                enableTileAnimation = value;
                this.RaisePropertyChanged("EnableTileAnimation");
            }
        }

       
        
        private TimeSpan animationDuration = TimeSpan.FromMilliseconds(700);
        /// <summary>
        /// Gets or sets EnableTileAnimation property of the TileViewControl.
        /// <value>
        ///<c>true</c> if TileViewItems reordering allowed; otherwise, <c>false</c>.
        /// </value>
        ///</summary>
        public TimeSpan AnimationDuration
        {
            get
            {
                return animationDuration;
            }

            set
            {
                animationDuration = value;
                this.RaisePropertyChanged("AnimationDuration");
            }
        }


        private bool clickHeaderToMaximize;
        /// <summary>
        /// Gets or sets ClickHeaderToMaximize property of the TileViewControl.
        /// <value>
        ///<c>true</c> if click on TileViewItem's header to maximize allowed; otherwise, <c>false</c>.
        /// </value>
        ///</summary>
        public bool ClickHeaderToMaximize
        {
            get
            {
                return clickHeaderToMaximize;
            }

            set
            {
                clickHeaderToMaximize = value;
                this.RaisePropertyChanged("ClickHeaderToMaximize");
            }
        }

        private bool isMinMaxButtonOnMouseOverOnly;
        /// <summary>
        /// Gets or sets IsMinMaxButtonOnMouseOverOnly property of the TileViewControl.
        /// <value>
        ///<c>true</c>Minimize and Maximize buttons in TileViewItem remains visible only when mouse over on that TileViewItem.
        ///<c>false</c>Minimize and Maximize buttons in TileViewItem remains visible always.
        /// </value>
        ///</summary>
        public bool IsMinMaxButtonOnMouseOverOnly
        {
            get
            {
                return isMinMaxButtonOnMouseOverOnly;
            }

            set
            {
                isMinMaxButtonOnMouseOverOnly = value;
                this.RaisePropertyChanged("IsMinMaxButtonOnMouseOverOnly");
            }
        }

        private Visibility splitterVisibility = Visibility.Visible;
        /// <summary>
        /// Gets or sets the Visibility of the Splitter in between the TileViewItems.
        /// </summary>
        public Visibility SplitterVisibility
        {
            get
            {
                return splitterVisibility;
            }

            set
            {
                splitterVisibility = value;
                this.RaisePropertyChanged("SplitterVisibility");
            }
        }

        private int columnCount=3;
        /// <summary>
        /// Gets or sets the ColumCount of the TileViewControl.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return columnCount;
            }

            set
            {
                columnCount = value;
                this.RaisePropertyChanged("ColumnCount");
            }
        }

        private int rowCount = 3;
        /// <summary>
        /// Gets or sets the RowCount of the TileViewControl.
        /// </summary>
        public int RowCount
        {
            get
            {
                return rowCount;
            }

            set
            {
                rowCount = value;
                this.RaisePropertyChanged("RowCount");
            }
        }

        private double minimizedItemsPercentage = 20.0d;
        /// <summary>
        /// Gets or sets the percentage of area occupied by the minimized TileViewItems. 
        /// </summary>
        public double MinimizedItemsPercentage
        {
            get
            {
                return minimizedItemsPercentage;
            }

            set
            {
                minimizedItemsPercentage = value;
                this.RaisePropertyChanged("MinimizedItemsPercentage");
            }
        }

        private MinimizedItemsOrientation minimizedItemsOrientation = MinimizedItemsOrientation.Right;
        /// <summary>
        /// Gets or sets the orientation of the minimized TileViewItems..
        /// <value>
        /// <c>Left</c> Minimized TileViewItems aligned in the Left.
        /// <c>Right</c> Minimized TileViewItems aligned in the Right.
        /// <c>Bottom</c> Minimized TileViewItems aligned in the Bottom.
        /// <c>Top</c> Minimized TileViewItems aligned in the Top.
        /// </value>
        /// </summary>
        public MinimizedItemsOrientation MinimizedItemsOrientation
        {
            get
            {
                return minimizedItemsOrientation;
            }

            set
            {
                minimizedItemsOrientation = value;
                this.RaisePropertyChanged("MinimizedItemsOrientation");
            }
        }

        private double splitterThickness = 0.0d;
        /// <summary>
        /// Gets or sets the thickness of the Splitter displayed inbetween the TileViewItems.
        /// </summary>
        public double SplitterThickness
        {
            get
            {
                return splitterThickness;
            }

            set
            {
                splitterThickness = value;
                this.RaisePropertyChanged("SplitterThickness");
            }
        }

        private Brush splitterColor = Brushes.Gray;
        /// <summary>
        /// Gets or sets the color the Splitter displayed inbetween the TileViewItems
        /// </summary>
        public Brush SplitterColor
        {
            get
            {
                return splitterColor;
            }

            set
            {
                splitterColor = value;
                this.RaisePropertyChanged("SplitterColor");
            }
        }
        
        #endregion

        #region Implementation

        public ViewModel()
        {
            EventLogCommand = new DelegateCommand<object>(PropertyChangedHandler);
            modelItems = new ObservableCollection<Model>();
            bookModelItems = new ObservableCollection<BookModel>();
            PopulateCollection();
        }

        string[] headerBackgroundBrushes = { "#977EB9", "#769320", "#298181", "#E87227", "#4D93CE", "#C27F51", "#A64D4D", "#577338", "#7F4E7F" };
        string[] contentBackgroundBrushes0 = { "#957CB8","#708E19","#207A7A","#E86D24","#4C93CE","#A8612F","#A64C4C","#557136","#7B4A7B"};
        string[] contentBackgroundBrushes1 = { "#D4C7E2", "#BCD76F", "#6FBDBD", "#FFC75D", "#68CAE3", "#FBBD96", "#E39595", "#97AF7B", "#BB93BB" };

        BrushConverter bc = new BrushConverter();
        ColorConverter cc = new ColorConverter();

        private void PopulateCollection()
        {
#if NETCORE                       
            XDocument xDocument = XDocument.Load("../../../Books.xml");
#else
            XDocument xDocument = XDocument.Load("Books.xml");
#endif
            IEnumerable<XElement> query = from xElement in xDocument.Descendants("book")                                        
                                          select xElement;
            foreach (XElement xElement in query)
            {
                BookModel bookModel = new BookModel
                {
                    BookID = xElement.FirstAttribute.Value,
                    BookName = xElement.Element("title").Value,
                    AuthorName = xElement.Element("author").Value,
                    Genre = xElement.Element("genre").Value,
                    Price = xElement.Element("price").Value,
                    PublishDate = xElement.Element("publish_date").Value,
                    Description = xElement.Element("description").Value
                };
                bookModelItems.Add(bookModel);
            }
        }

        private LinearGradientBrush GetHeaderBackgroundBrush(int index)
        {
            LinearGradientBrush lbrush = new LinearGradientBrush();
            lbrush.StartPoint = new Point(0.5, 1.01);
            lbrush.EndPoint = new Point(0.5,-0.086);
            GradientStop gs1 = new GradientStop();
            gs1.Color = Colors.White;
            gs1.Offset = 1.0d;
            GradientStop gs2 = new GradientStop();
            gs2.Color = (Color)cc.ConvertFrom(headerBackgroundBrushes[index]);
            gs2.Offset=0.435d;
            lbrush.GradientStops.Add(gs1);
            lbrush.GradientStops.Add(gs2);
            return lbrush;
        }
       
        private LinearGradientBrush GetContentBackgroundBrush(int index)
        {
            LinearGradientBrush lbrush = new LinearGradientBrush();
            lbrush.StartPoint = new Point(0.5, 1);
            lbrush.EndPoint = new Point(0.5, 0.014);
            GradientStop gs1 = new GradientStop();
            gs1.Color = (Color)cc.ConvertFrom(contentBackgroundBrushes0[index]);
            gs1.Offset = 0.0d;
            GradientStop gs2 = new GradientStop();
            gs2.Color = (Color)cc.ConvertFrom(contentBackgroundBrushes1[index]);
            gs2.Offset = 1.0d;
            lbrush.GradientStops.Add(gs1);
            lbrush.GradientStops.Add(gs2);
            return lbrush;
        }

        #endregion
    }
}
