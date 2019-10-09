#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using UserInteraction_UserHandles.Utility;

namespace UserInteraction_UserHandles.ViewModel
{
    public class UserHandlesDiagramViewModel : DiagramViewModel
    {
        #region fields

        private ICommand _duplicatecommand;

        private ICommand _deletecommand;

        private List<string> _mposition = new List<string> { "Top", "Left", "Bottom", "Right", "TopLeft", "TopRight", "BottomLeft", "BottomRight" };

        private List<string> _mshape = new List<string> { "Ellipse", "Rectangle", "Diamond" };

        private List<string> _mcontent = new List<string> { "Duplicate", "Delete" };

        private object _quickcommandposition = "BottomRight";

        private object _quickcommandshape = "Ellipse";

        private object _quickcommandcontent = "Duplicate";

        private bool first = false;

        #endregion

        #region Commands and Properties

        /// <summary>
        /// Get the value for DuplicateCommand
        /// </summary>
        public ICommand DuplicateCommand
        {
            get { return _duplicatecommand; }
            set { _duplicatecommand = value; }
        }

        /// <summary>
        /// Get the value for DeleteCommand
        /// </summary>
        public ICommand DeleteCommand
        {
            get { return _deletecommand; }
            set { _deletecommand = value; }
        }

        /// <summary>
        /// Gets or sets the value for Position
        /// </summary>
        public object QuickCommandPosition
        {
            get
            {
                return _quickcommandposition;
            }
            set
            {
                if (_quickcommandposition != value)
                {
                    _quickcommandposition = value;
                    OnPropertyChanged("QuickCommandPosition");
                    OnQuickCommandPositionChanged(_quickcommandposition);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value for MShape
        /// </summary>
        public object QuickCommandShape
        {
            get
            {
                return _quickcommandshape;
            }
            set
            {
                if (_quickcommandshape != value)
                {
                    _quickcommandshape = value;
                    OnPropertyChanged("QuickCommandShape");
                    OnQuickCommandShapeChanged(_quickcommandshape);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value for MContent
        /// </summary>
        public object QuickCommandContent
        {
            get
            {
                return _quickcommandcontent;
            }
            set
            {
                if (_quickcommandcontent != value)
                {
                    _quickcommandcontent = value;
                    OnPropertyChanged("QuickCommandContent");
                    OnQuickCommandContentChanged(_quickcommandcontent);
                }
            }
        }
        
        public List<string> Positions
        {
            get
            {
                return _mposition;
            }
        }

        public List<string> Shapes
        {
            get
            {
                return _mshape;
            }
        }

        public List<string> Contents
        {
            get
            {
                return _mcontent;
            }
        }

        #endregion

        #region Constructor
        public UserHandlesDiagramViewModel()
        {

            #region Properties

            first = true;

            // Initialize value for Commands , properies of DiagramViewModel

            DuplicateCommand = new Command(OnDuplicateCommand);

            DeleteCommand = new Command(OnDeleteCommand);

            ItemSelectedCommand = new Command(OnItemSelectedCommand);

            ItemAddedCommand = new Command(OnItemAdded);

            PageSettings = new PageSettings()
            {
                PageBackground = new SolidColorBrush(Colors.Transparent),
                PageBorderBrush = new SolidColorBrush(Colors.Transparent),
            };

            SnapSettings = new SnapSettings()
            {
                SnapToObject = SnapToObject.All,
                SnapConstraints = SnapConstraints.All,
            };

            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.Rotator | SelectorConstraints.HideDisabledResizer,
            };
            
            Theme = new OfficeTheme();

            #endregion
        }

        private void OnItemAdded(object obj)
        {
            ItemAddedEventArgs args = obj as ItemAddedEventArgs;

            if(args.Item is NodeViewModel)
            {
                foreach(TextAnnotationViewModel anno in (args.Item as NodeViewModel).Annotations as ObservableCollection<IAnnotation>)
                {
                    anno.FontFamily = new FontFamily("Calibri");
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Method to change the Content value of QuickCommand
        /// </summary>
        /// <param name="content"></param>
        private void OnQuickCommandContentChanged(object content)
        {
            QuickCommandViewModel quickCommand = ((this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection)[0];
            if (content.ToString().Equals("Duplicate"))
            {
                quickCommand.Command = DuplicateCommand;
                quickCommand.Content = "M0,2.4879999 L0.986,2.4879999 0.986,9.0139999 6.9950027,9.0139999 6.9950027,10 0.986,10 C0.70400238,10 0.47000122,9.9060001 0.28100207,9.7180004 0.09400177,9.5300007 0,9.2959995 0,9.0139999 z M3.0050011,0 L9.0140038,0 C9.2960014,0 9.5300026,0.093999863 9.7190018,0.28199956 9.906002,0.47000027 10,0.70399952 10,0.986 L10,6.9949989 C10,7.2770004 9.906002,7.5160007 9.7190018,7.7110004 9.5300026,7.9069996 9.2960014,8.0049992 9.0140038,8.0049992 L3.0050011,8.0049992 C2.7070007,8.0049992 2.4650002,7.9069996 2.2770004,7.7110004 2.0890007,7.5160007 1.9950027,7.2770004 1.9950027,6.9949989 L1.9950027,0.986 C1.9950027,0.70399952 2.0890007,0.47000027 2.2770004,0.28199956 2.4650002,0.093999863 2.7070007,0 3.0050011,0 z";
            }
            else if (content.ToString().Equals("Delete"))
            {
                quickCommand.Command = DeleteCommand;
                quickCommand.Content = "M0.54700077,2.2130003 L7.2129992,2.2130003 7.2129992,8.8800011 C7.2129992,9.1920013 7.1049975,9.4570007 6.8879985,9.6739998 6.6709994,9.8910007 6.406,10 6.0939997,10 L1.6659999,10 C1.3539997,10 1.0890004,9.8910007 0.87200136,9.6739998 0.65500242,9.4570007 0.54700071,9.1920013 0.54700077,8.8800011 z M2.4999992,0 L5.2600006,0 5.8329986,0.54600048 7.7599996,0.54600048 7.7599996,1.6660004 0,1.6660004 0,0.54600048 1.9270014,0.54600048 z";
            }
        }

        /// <summary>
        /// Method to change the Shape of the QuickCommand
        /// </summary>
        /// <param name="shape"></param>
        private void OnQuickCommandShapeChanged(object shape)
        {
            QuickCommandViewModel quickCommand = ((this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection)[0];
            quickCommand.Shape = App.Current.Resources[shape.ToString()];
        }

        /// <summary>
        /// Method to chnage the Position of QuickCommand
        /// </summary>
        /// <param name="position"></param>
        private void OnQuickCommandPositionChanged(object position)
        {
            QuickCommandViewModel quickCommand = ((this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection)[0];
            if (position.ToString() == "Top")
            {
                quickCommand.OffsetY = 0;
                quickCommand.OffsetX = 0.5;
                quickCommand.Margin = new Thickness(0, 0, 0, 25);
            }

            else if (position.ToString() == "Left")
            {
                quickCommand.OffsetY = 0.5;
                quickCommand.OffsetX = 0;
                quickCommand.Margin = new Thickness(0, 0, 25, 0);
            }

            else if (position.ToString() == "Right")
            {
                quickCommand.OffsetY = 0.5;
                quickCommand.OffsetX = 1;
                quickCommand.Margin = new Thickness(25, 0, 0, 0);
            }

            else if (position.ToString() == "Bottom")
            {
                quickCommand.OffsetY = 1;
                quickCommand.OffsetX = 0.5;
                quickCommand.Margin = new Thickness(0, 25, 0, 0);
            }

            else if (position.ToString() == "BottomRight")
            {
                quickCommand.OffsetY = 1;
                quickCommand.OffsetX = 1;
                quickCommand.Margin = new Thickness(20, 20, 0, 0);
            }

            else if (position.ToString() == "BottomLeft")
            {
                quickCommand.OffsetY = 1;
                quickCommand.OffsetX = 0;
                quickCommand.Margin = new Thickness(0, 20, 20, 0);
            }

            else if (position.ToString() == "TopRight")
            {
                quickCommand.OffsetY = 0;
                quickCommand.OffsetX = 1;
                quickCommand.Margin = new Thickness(20, 0, 0, 20);
            }

            else if (position.ToString() == "TopLeft")
            {
                quickCommand.OffsetY = 0;
                quickCommand.OffsetX = 0;
                quickCommand.Margin = new Thickness(0, 0, 20, 20);
            }
        }

        private void OnDeleteCommand(object obj)
        {
            (this.Info as IGraphInfo).Commands.Delete.Execute(null);
        }

        private void OnDuplicateCommand(object obj)
        {
            (this.Info as IGraphInfo).Commands.Duplicate.Execute(null);
        }

        private void OnItemSelectedCommand(object obj)
        {
            if (first)
            {
                (this.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection()
                {
                    new QuickCommandViewModel()
                    {
                        Shape = App.Current.Resources["Ellipse"],
                        ShapeStyle = App.Current.MainWindow.Resources["QuickCommandShapestyle"] as Style,
                        OffsetX = 1,
                        OffsetY = 1,
                        Command = DuplicateCommand,
                        Content = "M0,2.4879999 L0.986,2.4879999 0.986,9.0139999 6.9950027,9.0139999 6.9950027,10 0.986,10 C0.70400238,10 0.47000122,9.9060001 0.28100207,9.7180004 0.09400177,9.5300007 0,9.2959995 0,9.0139999 z M3.0050011,0 L9.0140038,0 C9.2960014,0 9.5300026,0.093999863 9.7190018,0.28199956 9.906002,0.47000027 10,0.70399952 10,0.986 L10,6.9949989 C10,7.2770004 9.906002,7.5160007 9.7190018,7.7110004 9.5300026,7.9069996 9.2960014,8.0049992 9.0140038,8.0049992 L3.0050011,8.0049992 C2.7070007,8.0049992 2.4650002,7.9069996 2.2770004,7.7110004 2.0890007,7.5160007 1.9950027,7.2770004 1.9950027,6.9949989 L1.9950027,0.986 C1.9950027,0.70399952 2.0890007,0.47000027 2.2770004,0.28199956 2.4650002,0.093999863 2.7070007,0 3.0050011,0 z",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(20,20,0,0),
                        VisibilityMode = VisibilityMode.Node | VisibilityMode.Connector,
                    },
                };
                first = false;
            }
        }

        #endregion
    }
}
