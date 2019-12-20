#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace MenuMerging
{
    public class ViewModel: NotificationObject
    {
        private CommandModel checkedModel = null;

        public ViewModel()
        {
            this.Products = new ObservableCollection<ChartModel>();
            Random rndm = new Random();
            Products.Add(new ChartModel() { ProductId = 1, ProductName = "Rice", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 2, ProductName = "Wheat", Price2000 = rndm.Next(5, 80), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 1, ProductName = "Oil", Price2000 = rndm.Next(5, 60), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 4, ProductName = "Corn", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 5, ProductName = "Gram", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 6, ProductName = "Milk", Price2000 = rndm.Next(5, 90), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 7, ProductName = "Butter", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) });
            Products.Add(new ChartModel() { ProductId = 8, ProductName = "Oil", Price2000 = rndm.Next(5, 60), Price2010 = rndm.Next(10, 60) });
          

            FileCommands = new ObservableCollection<CommandModel>();
            WindowCommands = new ObservableCollection<CommandModel>();
            
            FileCommands.Add(new CommandModel() { Name = "New Product Details", Icon = "/Images/NewDocumentHS.png", Command = NewGridCommand });
            FileCommands.Add(new CommandModel() { Name = "New product Statistics", Icon = "/Images/graphhs.png", Command = NewChartCommand });
            FileCommands.Add(new CommandModel() { Name = "Open", Icon = "/Images/openfolderHS.png" });
            FileCommands.Add(new CommandModel() { Name = "Exit", Icon = "/Images/DeleteHS.png" });

            WindowCommands.Add(new CommandModel() { Name = "Cascade", Icon = "/Images/CascadeWindowsHS.png", Command = TileCascade, IsCheckable=true });
            WindowCommands.Add(new CommandModel() { Name = "Tile Horizontally", Icon = "/Images/ArrangeWindowsHS.png", Command = TileHorizontal, IsCheckable = true });
            WindowCommands.Add(new CommandModel() { Name = "Tile Vertically", Icon = "/Images/ArrangeSideBySideHS.png", Command = TileVertical, IsCheckable = true });

            WindowCommands[0].PropertyChanged+=new PropertyChangedEventHandler(ViewModel_PropertyChanged);
            WindowCommands[1].PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);
            WindowCommands[2].PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);

            ChartModel = new CommandModel() { Name = "Chart View" };
            ChartModel.Commands.Add(new CommandModel() { Name = "New Statistics", Icon = "/Images/graphhs.png", Command=NewCommand });
            ChartModel.Commands.Add(new CommandModel() { Name = "Refresh Chart", Icon = "/Images/RepeatHS.png", Command = NewCommand });
            ChartModel.Commands.Add(new CommandModel() { Name = "Publish Data", Icon = "/Images/PublishToWebHS.png", Command = NewCommand });         
            ChartModel.Commands.Add(new CommandModel() { Name = "Close View", Icon = "/Images/DeleteHS.png", Command = NewCommand });

            Chart1Model = new CommandModel() { Name = "Customize Chart" };
            Chart1Model.Commands.Add(new CommandModel() { Name = "Change Chart Type", Icon = "/Images/PieChartHS.png", Command = NewCommand });
            Chart1Model.Commands.Add(new CommandModel() { Name = "Add Series", Icon = "/Images/AlignObjectsBottomHS.png", Command = NewCommand });

            this.PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);

            GridModel = new CommandModel() { Name = "Grid View" };
            GridModel.Commands.Add(new CommandModel() { Name = "New Payroll", Icon = "/Images/NewReportHS.png", Command = NewCommand });
            GridModel.Commands.Add(new CommandModel() { Name = "Refresh Grid", Icon = "/Images/RepeatHS.png", Command = NewCommand });        
            GridModel.Commands.Add(new CommandModel() { Name = "Close View", Icon = "/Images/DeleteHS.png", Command = NewCommand });

            OtherCommands = new ObservableCollection<CommandModel>();
            OtherToolbarCommands = new ObservableCollection<CommandModel>();
        }

        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ActiveDocument")
            {
                if (ActiveDocument is GridView)
                {
                    if (!OtherCommands.Contains(GridModel))
                    {
                        OtherCommands.Add(GridModel);
                        OtherToolbarCommands = GridModel.Commands;
                        OtherCommands.Remove(ChartModel);
                        OtherCommands.Remove(Chart1Model);
                    }
                }
                else
                {
                    if (!OtherCommands.Contains(ChartModel))
                    {
                        OtherCommands.Add(ChartModel);
                        OtherToolbarCommands = ChartModel.Commands;
                        OtherCommands.Add(Chart1Model);
                        OtherCommands.Remove(GridModel);
                    }
                }
            }
            else if (e.PropertyName == "IsChecked")
            {
                if (checkedModel != null)
                    checkedModel.IsChecked = false;
                checkedModel = sender as CommandModel;
            }
        }

        private DelegateCommand<object> newGridCommand;

        public DelegateCommand<object> NewGridCommand
        {
            get
            {
                if (newGridCommand == null)
                {
                    newGridCommand = new DelegateCommand<object>(param => OpenNewGrid());
                }
                return newGridCommand;
            }
        }

        private void OpenNewGrid()
        {
            MainWindow window = App.Current.MainWindow as MainWindow;
            window.MDIView.container.Items.Add(new GridView());

            if (checkedModel != null)
            {
                switch (checkedModel.Name)
                {
                    case "Cascade":
                        Cascade();
                        break;
                    case "Tile Horizontally":
                        TileH();
                        break;
                    default:
                        TileV();
                        break;
                }
            }
        }

        private DelegateCommand<object> newChartCommand;

        public DelegateCommand<object> NewChartCommand
        {
            get
            {
                if (newChartCommand == null)
                {
                    newChartCommand = new DelegateCommand<object>(param => OpenNewChart());
                }
                return newChartCommand;
            }
        }


        private DelegateCommand<object> newCommand;

        public DelegateCommand<object> NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new DelegateCommand<object>(OpenNew);
                }
                return newCommand;
            }
        }

        private void OpenNew(object parameter)
        {
            MessageBox.Show(parameter.ToString() + " Executed");

        }

        private void OpenNewChart()
        {
            MainWindow window = App.Current.MainWindow as MainWindow;
            window.MDIView.container.Items.Add(new ChartView());

        }

        private DelegateCommand<object> tileH;

        public DelegateCommand<object> TileHorizontal
        {
            get
            {
                if (tileH == null)
                {
                    tileH = new DelegateCommand<object>(param => TileH());
                }
                return tileH;
            }
        }

        private DelegateCommand<object> tileV;

        public DelegateCommand<object> TileVertical
        {
            get
            {
                if (tileV == null)
                {
                    tileV = new DelegateCommand<object>(param => TileV());
                }
                return tileV;
            }
        }

        private DelegateCommand<object> tileC;

        public DelegateCommand<object> TileCascade
        {
            get
            {
                if (tileC == null)
                {
                    tileC = new DelegateCommand<object>(param => Cascade());
                }
                return tileC;
            }
        }

        private void Cascade()
        {
            MainWindow window = App.Current.MainWindow as MainWindow;
            double top = 0.0;
            double left = 0.0;
            foreach (UIElement element in window.MDIView.container.Items)
            {
                DocumentContainer.SetMDIBounds(element, new Rect(left, top, 500, 300));
                left += 60;
                top += 60;
            }
        }

        private void TileH()
        {
            MainWindow window = App.Current.MainWindow as MainWindow;
            double height = window.MDIView.container.ActualHeight / window.MDIView.container.Items.Count - 3;
            double top = 0.0;
            double left = 0.0;
            foreach (UIElement element in window.MDIView.container.Items)
            {
                DocumentContainer.SetMDIBounds(element, new Rect(left, top, window.MDIView.container.ActualWidth - 4, height));
                top += height;
            }
        }

        private void TileV()
        {
            MainWindow window = App.Current.MainWindow as MainWindow;
            double width = window.MDIView.container.ActualWidth / window.MDIView.container.Items.Count - 4;
            double top = 0.0;
            double left = 0.0;
            foreach (UIElement element in window.MDIView.container.Items)
            {
                DocumentContainer.SetMDIBounds(element, new Rect(left, top, width, window.MDIView.container.ActualHeight - 3));
                left += width;
            }
        }

        public ObservableCollection<ChartModel> Products { get; set; }

        public ObservableCollection<CommandModel> FileCommands { get; set; }

        public ObservableCollection<CommandModel> WindowCommands { get; set; }

        public ObservableCollection<CommandModel> OtherCommands { get; set; }


        private ObservableCollection<CommandModel> othertoolcommnds;

        public ObservableCollection<CommandModel> OtherToolbarCommands 
        { 
            get
            {
                return othertoolcommnds;
            }
            set
            {
                othertoolcommnds = value;
                RaisePropertyChanged("OtherToolbarCommands");
            }
        }

        public CommandModel ChartModel { get; set; }

        public CommandModel Chart1Model { get; set; }

        public CommandModel GridModel { get; set; }

        private UIElement activeDocument;

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
    }
}
