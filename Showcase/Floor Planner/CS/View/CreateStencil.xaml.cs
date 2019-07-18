#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FloorPlanner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateStencil : Grid
    {
        public CreateStencil()
        {
            this.InitializeComponent();           
            floorplanstencil.SymbolFilters = new SymbolFilters();
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "All", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Basic Shapes", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Kitchen", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Dining Room", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Living Room", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "BathRoom", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "BedRoom", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Doors", SymbolFilter = Filter });
           
            floorplanstencil.SelectedFilter = floorplanstencil.SymbolFilters[0];          
           
        }
     

        
        public FloorPlannerViewModel DataViewModel
        {
            get { return (FloorPlannerViewModel)GetValue(DataViewModelProperty); }
            set { SetValue(DataViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataViewModelProperty =
            DependencyProperty.Register("DataViewModel", typeof(FloorPlannerViewModel), typeof(CreateStencil), new PropertyMetadata(null,OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CreateStencil c = d as CreateStencil;
            
        }



        private bool Filter(SymbolFilterProvider sender, object symbol)
        {
            if (sender.Content.ToString() == "All")
            {
                return true;
            }
            if ((symbol as FloorPlanSymbolItem).GroupName.Equals(sender.Content.ToString())) 
            {
                return true;
            }
            return false;
        }
       
      
      

      
    }

    public class FloorPlanSymbolGroup : SymbolGroup
    {
    //   public ObservableCollection<FloorPlanSymbolGroup> fsg = new ObservableCollection<FloorPlanSymbolGroup>();
    //    protected override DependencyObject GetContainerForItemOverride()
    //    {
    //       DependencyObject depobj= base.GetContainerForItemOverride();
    //       if (depobj.GetType() ==typeof(Symbol))
    //       {
    //           Symbol s = new Symbol();
               
    //           s.PointerPressed += s_PointerPressed;
    //           s.PointerMoved += s_PointerMoved;
    //           s.PointerReleased += s_PointerReleased;
    //           return s;
    //       }
    //       else
    //       {
    //           FloorPlanSymbolGroup fg = new FloorPlanSymbolGroup();
    //           fg.Loaded += fg_Loaded;
    //           fsg.Add(fg);
    //           return fg;
    //       }

    //    }

    //    void fg_Loaded(object sender, RoutedEventArgs e)
    //    {
    //        GetParent((sender as FloorPlanSymbolGroup));
    //    }

    //    private void GetParent(DependencyObject floorPlanSymbolGroup)
    //    {
    //        DependencyObject obj=floorPlanSymbolGroup;
    //        DependencyObject depobj = VisualTreeHelper.GetParent(obj);
    //        if (depobj.GetType() != typeof(Stencil))
    //        {
    //            obj = depobj;
    //            GetParent(obj);
    //        }
    //        else
    //        {
    //            VModel = (depobj as Stencil).Tag as FloorPlannerViewModel;
    //        }
           
    //    }

    //    protected override void ClearContainerForItemOverride(DependencyObject element, object item)
    //    {
    //        DependencyObject depobj = base.GetContainerForItemOverride();
    //        if (depobj.GetType() == typeof(Symbol))
    //        {
    //            Symbol s = (depobj as Symbol);
    //            s.PointerPressed -= s_PointerPressed;
    //            s.PointerMoved -= s_PointerMoved;
    //            s.PointerReleased -= s_PointerReleased;
    //           // return s;
    //        }
    //    }

    //    Symbol CurrentSymbol = null;
        
    //  bool ispress = false;
    //    void s_PointerReleased(object sender, PointerRoutedEventArgs e)
    //    {
    //        ispress = false;
    //        CurrentSymbol = (sender as Symbol);
    //        CurrentSymbol.Background = ColorConverter("#FF141414");
    //        if (VModel != null) VModel.PreviewLayer.Visibility = Visibility.Collapsed;
    //    }
    //    void s_PointerMoved(object sender, PointerRoutedEventArgs e)
    //    {
    //        if (ispress)
    //        {
    //            if (VModel != null)
    //            {

    //                ((VModel as FloorPlannerViewModel).PreviewLayer as ContentControl).Visibility = Visibility.Visible;
    //                ((VModel as FloorPlannerViewModel).PreviewLayer as ContentControl).IsHitTestVisible = false;
    //                ((VModel as FloorPlannerViewModel).PreviewLayer as ContentControl).ContentTemplate = App.Current.Resources[(sender as Symbol).Content.ToString()] as DataTemplate;
    //                ((VModel as FloorPlannerViewModel).PreviewLayer as ContentControl).Width = 75;
    //                ((VModel as FloorPlannerViewModel).PreviewLayer as ContentControl).Height = 75;
    //                //((VModel as FloorPlannerViewModel).PreviewLayer as Rectangle).
    //                ScaleTransform st = new ScaleTransform();
    //                TranslateTransform tt = new TranslateTransform();
    //                tt.X = e.GetCurrentPoint(null).Position.X-10;
    //                tt.Y = e.GetCurrentPoint(null).Position.Y-75;
    //                TransformGroup rectGroup = new TransformGroup();
    //                rectGroup.Children.Add(st);
    //                rectGroup.Children.Add(tt);
    //                ((VModel as FloorPlannerViewModel).PreviewLayer as ContentControl).RenderTransform = rectGroup;
    //            }
    //        }
    //    }
    //    private Brush ColorConverter(string hexaColor)
    //    {
    //        if (hexaColor != null)
    //        {
    //            if (hexaColor.StartsWith("#"))
    //            {
    //                byte r = Convert.ToByte(hexaColor.Substring(1, 2), 16);
    //                byte g = Convert.ToByte(hexaColor.Substring(3, 2), 16);
    //                byte b = Convert.ToByte(hexaColor.Substring(5, 2), 16);
    //                byte a = Convert.ToByte(hexaColor.Substring(7, 2), 16);
    //                SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(r, g, b, a));
    //                return myBrush;
    //            }
    //            else
    //            {
    //                return this.Resources["sofa"] as LinearGradientBrush;
    //            }
    //        }
    //        return null;
    //    }
    //    void s_PointerPressed(object sender, PointerRoutedEventArgs e)
    //    {
    //        GetParent(sender as Symbol);
           
    //        if (CurrentSymbol != null)
    //        {
    //            if (CurrentSymbol != (sender as Symbol))
    //            {                    //"#FF141414"
    //                CurrentSymbol.Background = ColorConverter("#FF141414");
    //            }
    //            else
    //            {

    //            }
    //            CurrentSymbol = (sender as Symbol);
    //            CurrentSymbol.Background = ColorConverter("#FFBABABA");
    //        }
    //        else
    //        {
    //            CurrentSymbol = (sender as Symbol);
    //        }
           
    //        ispress = true;
    //    }

    //    private PreviewItem _item;
    //    public PreviewItem PreItem
    //    {
    //        get
    //        {
    //            return _item;
    //        }
    //        set
    //        {
    //            if (_item != value)
    //            {
    //                _item = value;
    //                OnPropertyChanged("PreItem");
    //            }
    //        }
    //    }

    //    private FloorPlannerViewModel vm;

    //    public FloorPlannerViewModel VModel
    //    {
    //        get
    //        {
    //            return vm;
    //        }
    //        set
    //        {
    //            //if (vm != value)
    //            {
    //                vm = value;
    //                OnPropertyChanged("VModel");
    //            }
    //        }
    //    }       

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged(string prop)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
    //        }
    //    }
    //}

    //public class PreviewItem:INotifyPropertyChanged
    //{
    //    private string contenttext;

    //    public string ContentText
    //    {
    //        get
    //        {
    //            return contenttext;
    //        }
    //        set
    //        {
    //            if (contenttext != value)
    //            {
    //                contenttext = value;
    //                OnPropertyChanged("ContentText");
    //            }
    //        }
    //    }

    //    private Point _currentpoint;

    //    public Point CurrentPoint
    //    {
    //        get
    //        {
    //            return _currentpoint;
    //        }
    //        set
    //        {
    //            if (_currentpoint != value)
    //            {
    //                _currentpoint = value;
    //                OnPropertyChanged("CurrentPoint");
    //            }
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected  void OnPropertyChanged(string prop)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
    //        }
    //    }
    }
}
