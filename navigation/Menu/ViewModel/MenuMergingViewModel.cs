#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.SfSkinManager;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the view model class.
    /// </summary>
    public class MenuMergingViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the checkModel.
        /// </summary>
        private MenuMergingModel checkedModel = null;

        /// <summary>
        /// Maintains the command for new products details.
        /// </summary>
        private ICommand newGridCommand;

        /// <summary>
        /// Maintains the command for new product statistics.
        /// </summary>
        private ICommand newChartCommand;

        /// <summary>
        /// Maintains the new command.
        /// </summary>
        private ICommand newCommand;

        /// <summary>
        /// Maintains the command for horizontal orientation. 
        /// </summary>
        private ICommand tileHorizontalCommand;

        /// <summary>
        /// Maintains the command for cascade orientation.
        /// </summary>
        private ICommand tileCascadeCommand;

        /// <summary>
        /// Maintains the command for vertical orientation.
        /// </summary>
        private ICommand tileVerticallCommand;

        /// <summary>
        /// Maintains the command for help.
        /// </summary>
        private ICommand helpCommand;

        /// <summary>
        /// Maintains the command for about.
        /// </summary>
        private ICommand aboutCommand;

        /// <summary>
        /// Maintains the active document.
        /// </summary>
        private UIElement activeDocument;

        /// <summary>
        /// Maintains the help menu item.
        /// </summary>
        private MenuMergingModel helpModel;

        /// <summary>
        /// Maintains the collection of items to be displayed as products.
        /// </summary>
        private ObservableCollection<ChartModel> products;

        /// <summary>
        /// Maintains the collection of file menu item <see cref="MenuMergingModel"/> class.
        /// </summary>
        private ObservableCollection<MenuMergingModel> fileCommands;

        /// <summary>
        /// Maintains the collection of window menu item <see cref="MenuMergingModel"/> class.
        /// </summary>
        private ObservableCollection<MenuMergingModel> windowCommands;

        /// <summary>
        /// Maintains the collection of  menu item <see cref="MenuMergingModel"/> class.
        /// </summary>
        private ObservableCollection<MenuMergingModel> otherCommands;

        /// <summary>
        /// Maintains the collection of other tool commands <see cref="MenuMergingModel"/> class.
        /// </summary>
        private ObservableCollection<MenuMergingModel> otherToolCommands;

        /// <summary>
        /// Maintains the value for file menu item.
        /// </summary>
        private MenuMergingModel fileModel;

        /// <summary>
        /// Maintains the value for customize chart menu item.
        /// </summary>        
        private MenuMergingModel chart1Model;

        /// <summary>
        /// Maintains the value for windows menu item.
        /// </summary>
        private MenuMergingModel windowModel;

        /// <summary>
        /// Maintains the value for chart view menu item.
        /// </summary>
        private MenuMergingModel chartModel;


        /// <summary>
        /// Maintains the value for grid model menu items.
        /// </summary>
        private MenuMergingModel gridModel;

        /// <summary>
        /// Holds the required resouces for Icon.
        /// </summary>
        private ResourceDictionary CommonResourceDictionary { get; set; }


        /// <summary>
        /// DocumentContainer Instance in the viewModel  
        /// </summary>
        private static DocumentContainer documentContainer = null;

        /// <summary>
        /// Initializes the instance of <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public MenuMergingViewModel()
        {
            this.Products = new ObservableCollection<ChartModel>();
            Random rndm = new Random();
            CommonResourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.navigationdemos.wpf;component/Assets/Menu/Icon.xaml", UriKind.RelativeOrAbsolute) };
            newGridCommand = new DelegateCommand<object>(OpenNewGrid);
            newChartCommand = new DelegateCommand<object>(OpenNewChart);
            newCommand = new DelegateCommand<object>(OpenNew);
            tileHorizontalCommand = new DelegateCommand<object>(TileHorizontal);
            tileVerticallCommand = new DelegateCommand<object>(TileVertical);
            tileCascadeCommand = new DelegateCommand<object>(Cascade);
            helpCommand = new DelegateCommand<object>(ExecuteHelpCommand);
            aboutCommand = new DelegateCommand<object>(ExecuteAboutCommand);

            Products.Add(new ChartModel() { ProductId = 1, ProductName = "Rice", OldPrice = rndm.Next(5, 40), NewPrice = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 2, ProductName = "Wheat", OldPrice = rndm.Next(5, 80), NewPrice = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 1, ProductName = "Oil", OldPrice = rndm.Next(5, 60), NewPrice = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 4, ProductName = "Corn", OldPrice = rndm.Next(5, 40), NewPrice = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 5, ProductName = "Gram", OldPrice = rndm.Next(5, 40), NewPrice = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 6, ProductName = "Milk", OldPrice = rndm.Next(5, 90), NewPrice = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 7, ProductName = "Butter", OldPrice = rndm.Next(5, 40), NewPrice = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 8, ProductName = "Oil", OldPrice = rndm.Next(5, 60), NewPrice = rndm.Next(10, 60) });

            FileCollection = new ObservableCollection<MenuMergingModel>();
            WindowCollection = new ObservableCollection<MenuMergingModel>();

            FileModel = new MenuMergingModel() { Name = "File" };
            FileModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "New Product Details", Icon = CommonResourceDictionary["New"] as object, ImageTemplate = CommonResourceDictionary["NewPathIcon"] as DataTemplate, Command = NewGridCommand });
            FileModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "New product Statistics", Icon = CommonResourceDictionary["FileChart"] as object, ImageTemplate = CommonResourceDictionary["ChartPathIcon"] as DataTemplate, Command = NewChartCommand });
            FileModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Open", Icon = CommonResourceDictionary["Open"] as object, ImageTemplate = CommonResourceDictionary["OpenPathIcon"] as DataTemplate, Command = NewCommand });
            FileModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Exit", Icon = CommonResourceDictionary["FileDelete"] as object, ImageTemplate = CommonResourceDictionary["DeletePathIcon"] as DataTemplate, Command = NewCommand });

            WindowModel = new MenuMergingModel() { Name = "Windows" };
            WindowModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Cascade", Icon = CommonResourceDictionary["CascadeWindow"] as object, ImageTemplate = CommonResourceDictionary["CascadeWindowPathIcon"] as DataTemplate, Command = TileCascadeCommand, IsCheckable = true });
            WindowModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Tile Horizontally", Icon = CommonResourceDictionary["ArrangeWindow"] as object, ImageTemplate = CommonResourceDictionary["ArrangeWindowPathIcon"] as DataTemplate, Command = TileHorizontalCommand, IsCheckable = true });
            WindowModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Tile Vertically", Icon = CommonResourceDictionary["SideBySide"] as object, ImageTemplate = CommonResourceDictionary["SideBySidePathIcon"] as DataTemplate, Command = TileVerticalCommand, IsCheckable = true });

            WindowModel.MenuMergingCollection[0].PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);
            WindowModel.MenuMergingCollection[1].PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);
            WindowModel.MenuMergingCollection[2].PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);

            ChartModel = new MenuMergingModel() { Name = "Chart View" };
            ChartModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "New Statistics", Icon = CommonResourceDictionary["Chart"] as object, ImageTemplate = CommonResourceDictionary["ChartPathIcon"] as DataTemplate, Command = NewCommand });
            ChartModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Refresh Chart", Icon = CommonResourceDictionary["Repeat"] as object, ImageTemplate = CommonResourceDictionary["RepeatPathIcon"] as DataTemplate, Command = NewCommand });
            ChartModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Publish Data", Icon = CommonResourceDictionary["PublishWeb"] as object, ImageTemplate = CommonResourceDictionary["PublishWebPathIcon"] as DataTemplate, Command = NewCommand });
            ChartModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Close View", Icon = CommonResourceDictionary["Delete"] as object, ImageTemplate = CommonResourceDictionary["DeletePathIcon"] as DataTemplate, Command = NewCommand });

            Chart1Model = new MenuMergingModel() { Name = "Customize Chart" };
            Chart1Model.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Change Chart Type", Icon = CommonResourceDictionary["Pie"] as object, ImageTemplate = CommonResourceDictionary["AlignToBottomPathIcon"] as DataTemplate, Command = NewCommand });
            Chart1Model.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Add Series", Icon = CommonResourceDictionary["AlignToBottom"] as object, ImageTemplate = CommonResourceDictionary["DeletePathIcon"] as DataTemplate, Command = NewCommand });

            this.PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);

            GridModel = new MenuMergingModel() { Name = "Grid View" };
            GridModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Refresh Grid", Icon = CommonResourceDictionary["GridRepeat"] as object, ImageTemplate = CommonResourceDictionary["RepeatPathIcon"] as DataTemplate, Command = NewCommand });
            GridModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Close View", Icon = CommonResourceDictionary["GridDelete"] as object, ImageTemplate = CommonResourceDictionary["DeletePathIcon"] as DataTemplate, Command = NewCommand });

            HelpModel = new MenuMergingModel() { Name = "Help" };
            HelpModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "Online Help", Icon = CommonResourceDictionary["Help"] as object });
            HelpModel.MenuMergingCollection.Add(new MenuMergingModel() { Name = "About" });

            OtherCollection = new ObservableCollection<MenuMergingModel>();
            OtherToolBarCollection = new ObservableCollection<MenuMergingModel>();
            OtherCollection.Add(FileModel);
            FileCollection = FileModel.MenuMergingCollection;
            OtherCollection.Add(WindowModel);
            WindowCollection = WindowModel.MenuMergingCollection;
        }

        /// <summary>
        /// Gets the document container.
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <returns>Returns window property.</returns>
        public static string GetDocumentContainer(DependencyObject obj)
        {
            return (string)obj.GetValue(DocumentContainerProperty);
        }

        /// <summary>
        /// Sets the document container.
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <param name="value">Specifies the window.</param>
        public static void SetDocumentContainer(DependencyObject obj, DocumentContainer value)
        {
            obj.SetValue(DocumentContainerProperty, value);
        }

        // Using a DependencyProperty as the backing store for DocumentContainer. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DocumentContainerProperty =
            DependencyProperty.RegisterAttached("DocumentContainer", typeof(string), typeof(MenuMergingViewModel), new FrameworkPropertyMetadata(OnDocumentContainerChanged));

        /// <summary>
        /// Method executes when dependency property changes
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <param name="args">Specifies the event.</param>        
        public static void OnDocumentContainerChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            documentContainer = obj as DocumentContainer;
        }

        /// <summary>
        /// Gets or sets the command for help  <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand HelpCommand
        {
            get
            {
                return helpCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for about <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand AboutCommand
        {
            get
            {
                return aboutCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for new product details <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand NewGridCommand
        {
            get
            {
                return newGridCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for new product statistics <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand NewChartCommand
        {
            get
            {
                return newChartCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command to be excuted on clicking the menu item <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand NewCommand
        {
            get
            {
                return newCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for horizontal orientation <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand TileHorizontalCommand
        {
            get
            {
                return tileHorizontalCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for vertical orientation <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand TileVerticalCommand
        {
            get
            {
                return tileVerticallCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for cascade orientation <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand TileCascadeCommand
        {
            get
            {
                return tileCascadeCommand;
            }
        }

        /// <summary>
        /// Gets or sets the collection of items to be displayed as products <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ObservableCollection<ChartModel> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                RaisePropertyChanged("Products");
            }
        }

        /// <summary>
        /// Gets or sets the collection of file menu item  <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ObservableCollection<MenuMergingModel> FileCollection
        {
            get
            {
                return fileCommands;
            }
            set
            {
                fileCommands = value;
                RaisePropertyChanged("FileCollection");
            }
        }

        /// <summary>
        /// Gets or sets the collection of  window menu item <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ObservableCollection<MenuMergingModel> WindowCollection
        {
            get
            {
                return windowCommands;
            }
            set
            {
                windowCommands = value;
                RaisePropertyChanged("WindowCollection");
            }
        }

        /// <summary>
        /// Gets or sets the collection of  commands to be used in the menu item <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ObservableCollection<MenuMergingModel> OtherCollection
        {
            get
            {
                return otherCommands;
            }
            set
            {
                otherCommands = value;
                RaisePropertyChanged("OtherCollection");
            }
        }

        /// <summary>
        /// Gets or sets the collection of other tool bar commands <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ObservableCollection<MenuMergingModel> OtherToolBarCollection
        {
            get
            {
                return otherToolCommands;
            }
            set
            {
                otherToolCommands = value;
                RaisePropertyChanged("OtherToolBarCollection");
            }
        }

        /// <summary>
        /// Gets or sets the  value for file menu item <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public MenuMergingModel FileModel
        {
            get
            {
                return fileModel;
            }
            set
            {
                fileModel = value;
                RaisePropertyChanged("FileModel");
            }
        }

        /// <summary>
        /// Gets or sets the value window menu item <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public MenuMergingModel WindowModel
        {
            get
            {
                return windowModel;
            }
            set
            {
                windowModel = value;
                RaisePropertyChanged("WindowModel");
            }
        }

        /// <summary>
        /// Gets or sets the value for chart view menu item <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public MenuMergingModel ChartModel
        {
            get
            {
                return chartModel;
            }
            set
            {
                chartModel = value;
                RaisePropertyChanged("ChartModel");
            }
        }

        /// <summary>
        /// Gets or sets the value for customize chart menu item <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public MenuMergingModel Chart1Model
        {
            get
            {
                return chart1Model;
            }
            set
            {
                chart1Model = value;
                RaisePropertyChanged("Chart1Model");
            }
        }

        /// <summary>
        /// Gets or sets the value for grid view menu items <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public MenuMergingModel GridModel
        {
            get
            {
                return gridModel;
            }
            set
            {
                gridModel = value;
                RaisePropertyChanged("GridModel");
            }
        }

        /// <summary>
        /// Gets or sets the help menu item <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public MenuMergingModel HelpModel
        {
            get
            {
                return helpModel;
            }
            set
            {
                helpModel = value;
                RaisePropertyChanged("HelpModel");
            }
        }

        /// <summary>
        /// Gets or sets the active document <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public UIElement ActiveDocument
        {
            get
            {
                return activeDocument;
            }

            set
            {
                activeDocument = value;
                RaisePropertyChanged("ActiveDocument");
            }
        }

        /// <summary>
        /// Method to execute new command.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter</param>
        private void OpenNew(object parameter)
        {
            MessageBox.Show(parameter.ToString() + " has been selected ");
        }

        /// <summary>
        /// Method to execute command for new product statistics.
        /// </summary>
        private void OpenNewChart(object parameter)
        {
            documentContainer.Items.Add(new ChartView());
        }

        /// <summary>
        /// Method to execute  newGridCommand.
        /// </summary>
        private void OpenNewGrid(object parameter)
        {
            documentContainer.Items.Add(new GridView());

            if (checkedModel != null)
            {
                switch (checkedModel.Name)
                {
                    case "Cascade":
                        tileCascadeCommand = new DelegateCommand<object>(Cascade);
                        break;
                    case "Tile Horizontally":
                        tileHorizontalCommand = new DelegateCommand<object>(TileHorizontal);
                        break;
                    default:
                        tileVerticallCommand = new DelegateCommand<object>(TileVertical);
                        break;
                }
            }
        }

        /// <summary>
        /// Method to property changed in <see cref="MenuMergingViewModel"/>class.
        /// </summary>
        /// <param name="sender">Specifies the object </param>
        /// <param name="e">Speciifes the EventArgs</param>
        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ActiveDocument")
            {
                if (ActiveDocument is GridView)
                {
                    if (!OtherCollection.Contains(GridModel))
                    {
                        OtherCollection.Remove(HelpModel);
                        OtherCollection.Add(GridModel);
                        OtherCollection.Add(HelpModel);
                        OtherToolBarCollection = GridModel.MenuMergingCollection;
                        OtherCollection.Remove(ChartModel);
                        OtherCollection.Remove(Chart1Model);
                    }
                }
                else
                {
                    if (!OtherCollection.Contains(ChartModel))
                    {
                        OtherCollection.Remove(HelpModel);
                        OtherCollection.Add(ChartModel);
                        OtherToolBarCollection = ChartModel.MenuMergingCollection;
                        OtherCollection.Add(Chart1Model);
                        OtherCollection.Remove(GridModel);
                        OtherCollection.Add(HelpModel);
                    }
                }
            }
            else if (e.PropertyName == "IsChecked")
            {
                if (checkedModel != null)
                    checkedModel.IsChecked = false;
                checkedModel = sender as MenuMergingModel;
            }
        }

        /// <summary>
        /// Method to execute cascade orientation.
        /// </summary>
        private void Cascade(object parameter)
        {
            double top = 0.0;
            double left = 0.0;
            foreach (UIElement element in documentContainer.Items)
            {
                DocumentContainer.SetMDIBounds(element, new Rect(left, top, 500, 300));
                left += 60;
                top += 60;
            }
        }

        /// <summary>
        /// Method to execute horizontal orientation.
        /// </summary>
        private void TileHorizontal(object parameter)
        {
            double height = documentContainer.ActualHeight / documentContainer.Items.Count - 3;
            double top = 0.0;
            double left = 0.0;
            foreach (UIElement element in documentContainer.Items)
            {
                DocumentContainer.SetMDIBounds(element, new Rect(left, top, documentContainer.ActualWidth - 4, height));
                top += height;
            }
        }

        /// <summary>
        /// Method to execute vertical orientation.
        /// </summary>
        private void TileVertical(object parameter)
        {
            double width = documentContainer.ActualWidth / documentContainer.Items.Count - 4;
            double top = 0.0;
            double left = 0.0;
            foreach (UIElement element in documentContainer.Items)
            {
                DocumentContainer.SetMDIBounds(element, new Rect(left, top, width, documentContainer.ActualHeight - 3));
                left += width;
            }
        }

        /// <summary>
        /// Method used to execute the helpCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ExecuteHelpCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the page ?", "Help", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/welcome-to-syncfusion-essential-wpf");
            }
        }

        /// <summary>
        /// method used to execute aboutCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ExecuteAboutCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the page ?", "About", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.syncfusion.com/company/about-us");
            }
        }
    }
}
