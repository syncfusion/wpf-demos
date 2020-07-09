#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.SfSkinManager;

namespace MenuMerging
{
    public class ViewModel: NotificationObject
    {
        /// <summary>
        /// Maintains the checkModel.
        /// </summary>
        private Model checkedModel = null;

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
        private Model helpModel;

        /// <summary>
        /// Maintains the collection of items to be displayed as products.
        /// </summary>
        private ObservableCollection<ChartModel> products;

        /// <summary>
        /// Maintains the collection of file menu item <see cref="Model"/> class.
        /// </summary>
        private ObservableCollection<Model> fileCommands;

        /// <summary>
        /// Maintains the collection of window menu item <see cref="Model"/> class.
        /// </summary>
        private ObservableCollection<Model> windowCommands;

        /// <summary>
        /// Maintains the collection of  menu item <see cref="Model"/> class.
        /// </summary>
        private ObservableCollection<Model> otherCommands;

        /// <summary>
        /// Maintains the collection of other tool commands <see cref="Model"/> class.
        /// </summary>
        private ObservableCollection<Model> otherToolCommands;

        /// <summary>
        /// Maintains the value for file menu item.
        /// </summary>
        private Model fileModel;

        /// <summary>
        /// Maintains the value for customize chart menu item.
        /// </summary>        
        private Model chart1Model;

        /// <summary>
        /// Maintains the value for windows menu item.
        /// </summary>
        private Model windowModel;

        /// <summary>
        /// Maintains the value for chart view menu item.
        /// </summary>
        private Model chartModel;


        /// <summary>
        /// Maintains the value for grid model menu items.
        /// </summary>
        private Model gridModel;

        /// <summary>
        /// DocumentContainer Instance in the viewModel  
        /// </summary>
        private static DocumentContainer documentContainer = null;

        /// <summary>
        /// Initializes the instance of <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.Products = new ObservableCollection<ChartModel>();
            Random rndm = new Random();

            SfSkinManager.ApplyStylesOnApplication = true;
            newGridCommand = new DelegateCommand<object>(OpenNewGrid);
            newChartCommand = new DelegateCommand<object>(OpenNewChart);
            newCommand = new DelegateCommand<object>(OpenNew);
            tileHorizontalCommand = new DelegateCommand<object>(TileHorizontal);
            tileVerticallCommand = new DelegateCommand<object>(TileVertical);
            tileCascadeCommand = new DelegateCommand<object>(Cascade);
            helpCommand = new DelegateCommand<object>(ExecuteHelpCommand);
            aboutCommand = new DelegateCommand<object>(ExecuteAboutCommand);

            Products.Add(new ChartModel() { ProductId = 1, ProductName = "Rice", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 2, ProductName = "Wheat", Price2000 = rndm.Next(5, 80), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 1, ProductName = "Oil", Price2000 = rndm.Next(5, 60), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 4, ProductName = "Corn", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 5, ProductName = "Gram", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 6, ProductName = "Milk", Price2000 = rndm.Next(5, 90), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 7, ProductName = "Butter", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 8, ProductName = "Oil", Price2000 = rndm.Next(5, 60), Price2010 = rndm.Next(10, 60) });

            FileCollection = new ObservableCollection<Model>();
            WindowCollection = new ObservableCollection<Model>();

            FileModel = new Model() { Name = "File" };
            FileModel.MenuMergingCollection.Add(new Model() { Name = "New Product Details", Icon = "../../../Images/NewDocumentHS.png", Command = NewGridCommand });
            FileModel.MenuMergingCollection.Add(new Model() { Name = "New product Statistics", Icon = "../../../Images/graphhs.png", Command = NewChartCommand });
            FileModel.MenuMergingCollection.Add(new Model() { Name = "Open", Icon = "../../../Images/openfolderHS.png", Command = NewCommand });
            FileModel.MenuMergingCollection.Add(new Model() { Name = "Exit", Icon = "../../../Images/DeleteHS.png", Command = NewCommand });

            WindowModel = new Model() { Name = "Windows" };
            WindowModel.MenuMergingCollection.Add(new Model() { Name = "Cascade", Icon = "../../../Images/CascadeWindowsHS.png", Command = TileCascadeCommand, IsCheckable = true });
            WindowModel.MenuMergingCollection.Add(new Model() { Name = "Tile Horizontally", Icon = "../../../Images/ArrangeWindowsHS.png", Command = TileHorizontalCommand, IsCheckable = true });
            WindowModel.MenuMergingCollection.Add(new Model() { Name = "Tile Vertically", Icon = "../../../Images/ArrangeSideBySideHS.png", Command = TileVerticalCommand, IsCheckable = true });

            WindowModel.MenuMergingCollection[0].PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);
            WindowModel.MenuMergingCollection[1].PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);
            WindowModel.MenuMergingCollection[2].PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);

            ChartModel = new Model() { Name = "Chart View" };
            ChartModel.MenuMergingCollection.Add(new Model() { Name = "New Statistics", Icon = "../../../Images/graphhs.png", Command = NewCommand });
            ChartModel.MenuMergingCollection.Add(new Model() { Name = "Refresh Chart", Icon = "../../../Images/RepeatHS.png", Command = NewCommand });
            ChartModel.MenuMergingCollection.Add(new Model() { Name = "Publish Data", Icon = "../../../Images/PublishToWebHS.png", Command = NewCommand });
            ChartModel.MenuMergingCollection.Add(new Model() { Name = "Close View", Icon = "../../../Images/DeleteHS.png", Command = NewCommand });

            Chart1Model = new Model() { Name = "Customize Chart" };
            Chart1Model.MenuMergingCollection.Add(new Model() { Name = "Change Chart Type", Icon = "../../../Images/PieChartHS.png", Command = NewCommand });
            Chart1Model.MenuMergingCollection.Add(new Model() { Name = "Add Series", Icon = "../../../Images/AlignObjectsBottomHS.png", Command = NewCommand });

            this.PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);

            GridModel = new Model() { Name = "Grid View" };
            GridModel.MenuMergingCollection.Add(new Model() { Name = "New Payroll", Icon = "../../../Images/NewReportHS.png", Command = NewCommand });
            GridModel.MenuMergingCollection.Add(new Model() { Name = "Refresh Grid", Icon = "../../../Images/RepeatHS.png", Command = NewCommand });
            GridModel.MenuMergingCollection.Add(new Model() { Name = "Close View", Icon = "../../../Images/DeleteHS.png", Command = NewCommand });

            HelpModel = new Model() { Name = "Help" };
            HelpModel.MenuMergingCollection.Add(new Model() { Name = "Online Help", Icon = "../../../Images/Help.png" });
            HelpModel.MenuMergingCollection.Add(new Model() { Name = "About" });

            OtherCollection = new ObservableCollection<Model>();
            OtherToolBarCollection = new ObservableCollection<Model>();
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
            DependencyProperty.RegisterAttached("DocumentContainer", typeof(string), typeof(ViewModel), new FrameworkPropertyMetadata(OnDocumentContainerChanged));

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
        /// Gets or sets the command for help  <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand HelpCommand
        {
            get
            {
                return helpCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for about <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand AboutCommand
        {
            get
            {
                return aboutCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for new product details <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand NewGridCommand
        {
            get
            {
                return newGridCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for new product statistics <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand NewChartCommand
        {
            get
            {
                return newChartCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command to be excuted on clicking the menu item <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand NewCommand
        {
            get
            {
                return newCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for horizontal orientation <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand TileHorizontalCommand
        {
            get
            {
                return tileHorizontalCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for vertical orientation <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand TileVerticalCommand
        {
            get
            {
                return tileVerticallCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for cascade orientation <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand TileCascadeCommand
        {
            get
            {
                return tileCascadeCommand;
            }
        }

        /// <summary>
        /// Gets or sets the collection of items to be displayed as products <see cref="ViewModel"/> class.
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
        /// Gets or sets the collection of file menu item  <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FileCollection
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
        /// Gets or sets the collection of  window menu item <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> WindowCollection
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
        /// Gets or sets the collection of  commands to be used in the menu item <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> OtherCollection
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
        /// Gets or sets the collection of other tool bar commands <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> OtherToolBarCollection
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
        /// Gets or sets the  value for file menu item <see cref="ViewModel"/> class.
        /// </summary>
        public Model FileModel
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
        /// Gets or sets the value window menu item <see cref="ViewModel"/> class.
        /// </summary>
        public Model WindowModel
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
        /// Gets or sets the value for chart view menu item <see cref="ViewModel"/> class.
        /// </summary>
        public Model ChartModel
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
        /// Gets or sets the value for customize chart menu item <see cref="ViewModel"/> class.
        /// </summary>
        public Model Chart1Model
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
        /// Gets or sets the value for grid view menu items <see cref="ViewModel"/> class.
        /// </summary>
        public Model GridModel
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
        /// Gets or sets the help menu item <see cref="ViewModel"/> class.
        /// </summary>
        public Model HelpModel
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
        /// Gets or sets the active document <see cref="ViewModel"/> class.
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
        /// Method to property changed in <see cref="ViewModel"/>class.
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
                checkedModel = sender as Model;
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
