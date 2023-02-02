#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

namespace syncfusion.demoscommon.wpf
{
    public abstract class DemoBrowserViewModel : NotificationObject
    {
        public static string DefaultThemeName = "Windows11Light";

        public static System.Globalization.CultureInfo AppCulture;
        #region Member

        /// <summary>
        /// Maintains the selected product <see cref="ProductDemo"/>
        /// </summary>
        private ProductDemo _selectedproduct;

        /// <summary>
        /// Maintains the selected sample <see cref="DemoInfo"/>
        /// </summary>
        private DemoInfo _selectedsample = null;

        /// Maintains the selected showcase sample <see cref="DemoInfo"/>
        /// </summary>
        private DemoInfo selectedShowcaseSample = null;

        /// <summary>
        /// Maintains the selected <see cref="VisualStyles"/>
        /// </summary>
        private string selectedthemename = DemoBrowserViewModel.DefaultThemeName;

        /// <summary>
        /// Maintains busy status of sample browser while switching between themes.
        /// </summary>
        private bool isProductDemoBusy = false;

        /// <summary>
        /// Property to store busy status of sample browser while launch the show case demo.
        /// </summary>
        private bool isShowCaseDemoBusy = false;

        /// <summary>
        /// Gets or sets the property value indicating whether the products demos launch in separate window
        /// </summary>
        private bool isWindowMode = true;

        /// <summary>
        /// Gets or sets the property value indicating whether the selected sample thememode is inherit or not
        /// </summary>
        private bool isThemeInheritMode = true;

        /// <summary>
        /// Gets or sets the collection of product demos.
        /// </summary>
        public List<ProductDemo> ProductDemos { get; set; }

        /// <summary>
        /// Gets or sets the collection of show case demos demos.
        /// </summary>
        public List<DemoInfo> ShowcaseDemos { get; set; }

        /// <summary>
        ///  Gets or sets the collection of product and demos information.
        /// </summary>
        public List<ProductInfo> ProductInfo { get; set; }

        /// <summary>
        /// Maintains the product demo collection
        /// </summary>
        /// <returns>Product demos</returns>
        public abstract List<ProductDemo> GetDemosDetails();

        /// <summary>
        /// Gets  or sets the item searched in the Search text box
        /// </summary>
        private ProductInfo searchItem;

        /// <summary>
        /// Gets  or sets the item searched in the Search text box
        /// </summary>
        private string searchtext;

        /// <summary>
        /// Maintains the command for Navigate all product button.
        /// </summary>
        private ICommand navigateAllProducts;

        /// <summary>
        ///  Maintains the command for <see cref="SfTextBoxExt"/> loaded event.
        /// </summary>
        private ICommand searchTextBoxLoadedCommand;

        /// <summary>
        ///  Maintains the command for <see cref="Window"/> loaded event.
        /// </summary>
        private ICommand windowLoadedCommand;

        /// <summary>
        /// Maintain the command to change the visibility of the theme panel
        /// </summary>
        private ICommand themepanelvisibilitycommand;

        /// <summary>
        ///  Maintains the command for <see cref="ProductDemosWindow"/> loaded event.
        /// </summary>
        private ICommand productwindowLoadedCommand;
        /// <summary>
        /// Gets or set the title bar background
        /// </summary>
        private Brush titleBarBackground = new SolidColorBrush(Color.FromRgb(43, 87, 154));

        /// <summary>
        /// Gets or set the title bar foreground
        /// </summary>
        private Brush titleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public DemoBrowserViewModel()
        {
            AppCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            ProductDemos = GetDemosDetails();
            PopulateProducts();
            PopulatePaletteList();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the selected <see cref="ProductDemo"/> product.
        /// </summary>
        public ProductDemo SelectedProduct
        {
            get { return _selectedproduct; }
            set
            {
                _selectedproduct = value;
                OnSelectedProductChanged();
                this.RaisePropertyChanged("SelectedProduct");
            }
        }
       
        /// <summary>
        /// Gets or sets the property value indicating whether it is store package application or not.
        /// </summary>
        public static bool IsStoreApp = false;

        /// <summary>
        /// Gets or sets the property value indicating whether automate the samples to log bidding error.
        /// </summary>
        public static bool CanAutomate = false;

        /// Property to store busy status of sample browser while switching between themes.
        /// </summary>
        public bool IsProductDemoBusy
        {
            get { return isProductDemoBusy; }
            set
            {
                isProductDemoBusy = value;
                RaisePropertyChanged("IsProductDemoBusy");
            }
        }

        /// <summary>
        /// Property to store busy status of sample browser while launch the show case demo.
        /// </summary>
        public bool IsShowCaseDemoBusy
        {
            get { return isShowCaseDemoBusy; }
            set
            {
                isShowCaseDemoBusy = value;
                RaisePropertyChanged("IsShowCaseDemoBusy");
            }
        }

        /// <summary>
        /// Gets or sets the property value indicating whether the products demos launch in separate window
        /// </summary>
        public bool IsWindowMode
        {
            get { return isWindowMode; }
            set
            {
                isWindowMode = value;
                RaisePropertyChanged("IsWindowMode");
            }
        }

        /// <summary>
        /// Gets or sets the selected <see cref="DemoInfo"/> sample.
        /// </summary>
        public DemoInfo SelectedSample
        {
            get { return _selectedsample; }
            set
            {
                _selectedsample = value;
                OnSelectedSampleChanged(_selectedsample);
                this.RaisePropertyChanged("SelectedSample");
            }
        }

        /// <summary>
        /// Gets or sets the selected showcase <see cref="DemoInfo"/> sample.
        /// </summary>
        public DemoInfo SelectedShowcaseSample
        {
            get { return selectedShowcaseSample; }
            set
            {
                selectedShowcaseSample = value;
                this.RaisePropertyChanged("SelectedShowcaseSample");
            }
        }

        /// <summary>
        /// Gets or sets the property value indicating whether the selected sample thememode  is inherit or not.
        /// </summary>
        public bool IsThemeInheritMode
        {
            get { return isThemeInheritMode; }
            set
            {
                isThemeInheritMode = value;
                RaisePropertyChanged("IsThemeInheritMode");
            }
        }


        /// <summary>
        /// Gets or sets the selected <see cref="VisualStyles"/> of application.
        /// </summary>
        public string SelectedThemeName
        {
            get { return selectedthemename; }
            set
            {
                selectedthemename = value;
                if (selectedthemename == "SystemTheme")
                {
                    ColorPaletteVisibility = false;
                }
                else
                {
                    ColorPaletteVisibility = true;
                    Palettes = new ObservableCollection<Palette>(PaletteList.Where(x => (x.Theme.Equals(selectedthemename))).ToList<Palette>());
                    SelectedPalette = Palettes.Where(x => x.Name.Equals("Default")).ToList<Palette>()[0];
                }
                OnThemeChanged(selectedthemename);
                this.RaisePropertyChanged("SelectedTheme");
            }
        }

        /// <summary>
        /// Gets or set the item serached in the search text box
        /// </summary>
        public ProductInfo SearchItem
        {
            get { return searchItem; }
            set
            {
                searchItem = value;
                OnSearchItemChanged(searchItem);
                this.RaisePropertyChanged("SearchItem");
            }
        }

        /// <summary>
        /// Gets or set the item serached in the search text box
        /// </summary>
        public string SearchText
        {
            get { return searchtext; }
            set
            {
                searchtext = value;
                this.RaisePropertyChanged("SearchText");
            }
        }      

        /// <summary>
        /// Gets or set the title bar background
        /// </summary>
        public Brush TitleBarBackground
        {
            get { return titleBarBackground; }
            set
            {
                titleBarBackground = value;
                this.RaisePropertyChanged("TitleBarBackground");
            }
        }

        /// <summary>
        /// Gets or set the title bar foreground
        /// </summary>
        public Brush TitleBarForeground
        {
            get { return titleBarForeground; }
            set
            {
                titleBarForeground = value;
                this.RaisePropertyChanged("TitleBarForeground");
            }
        }

        /// <summary>
        /// Gets the command  <see cref="Button"/> click event.
        /// </summary>
        public ICommand NavigateAllProductsCommand
        {
            get
            {
                if (navigateAllProducts == null)
                {
                    navigateAllProducts = new DelegateCommand<object>(NavigateAllProducts);
                }
                return navigateAllProducts;
            }
        }

        public ICommand ThemePanelVisibilityCommand
        {
            get
            {
                themepanelvisibilitycommand = new DelegateCommand<object>(ChangeVisibilityofThemepanel);
                return themepanelvisibilitycommand;
            }
        }

        private bool themepanelvisibility = false;

        /// <summary>
        /// Gets or sets the property used to Indicates the visibility of the ThemePanel
        /// </summary>
        public bool ThemePanelVisibility
        {
            get { return themepanelvisibility; }
            set { themepanelvisibility = value;
                RaisePropertyChanged(nameof(ThemePanelVisibility));
            }
        }

        private bool themebuttonvisibility = true;

        public  bool ThemeButtonVisibility
        {
            get { return themebuttonvisibility; }
            set { themebuttonvisibility = value;
                RaisePropertyChanged(nameof(ThemeButtonVisibility));
            }
        }


        private void ChangeVisibilityofThemepanel(object obj)
        {
           
                ThemePanelVisibility = false;
           
        }

        /// <summary>
        /// Gets the command  <see cref="SfTextBoxExt"/> loaded event.
        /// </summary>
        public ICommand SearchTextBoxLoadedCommand
        {
            get
            {
                if (searchTextBoxLoadedCommand == null)
                {
                    searchTextBoxLoadedCommand = new DelegateCommand<object>(SearchTextBoxLoaded);
                }
                return searchTextBoxLoadedCommand;
            }
        }

        /// <summary>
        /// Gets the command  <see cref="MainWindow"/> loaded event.
        /// </summary>
        public ICommand WindowLoadedCommand
        {
            get
            {
                if (windowLoadedCommand == null)
                {
                    windowLoadedCommand = new DelegateCommand<object>(WindowLoaded);
                }
                return windowLoadedCommand;
            }
        }

        /// <summary>
        /// Gets the command  <see cref="ProductDemosWindow"/> loaded event.
        /// </summary>
        public ICommand ProductWindowLoadedCommand
        {
            get
            {
                if (productwindowLoadedCommand == null)
                {
                    productwindowLoadedCommand = new DelegateCommand<object>(ProductWindowLoaded);
                }
                return productwindowLoadedCommand;
            }
        }

        #endregion

        /// <summary>
        /// Method helps to create colllection for Showcase demos and products collections.
        /// </summary>
        private void PopulateProducts()
        {
            ProductInfo = new List<ProductInfo>();
            foreach (ProductDemo product in ProductDemos)
            {
                if (product.Demos != null && product.Demos.Count > 0)
                {
                    foreach (DemoInfo demo in product.Demos)
                    {
                        ProductInfo.Add(new ProductInfo() { SampleName = demo.SampleName, ProductDemo = product, ProductDemoInfo = demo });
                    }
                }
            }
        }

        public Action ThemeChanged;

        private List<Palette> PaletteList = new List<Palette>();

        /// <summary>
        /// Method helps to perform product selection change.
        /// </summary>
        private void OnSelectedProductChanged()
        {
            if (this.SelectedProduct == null)
                return;

            selectedthemename = DemoBrowserViewModel.DefaultThemeName;

            // Fluent theme is the default theme.
            selectedtheme = themelist.FirstOrDefault(theme => theme.ThemeName == "Windows11Light");
            Palettes = new ObservableCollection<Palette>(PaletteList.Where(x => (x.Theme.Equals(selectedthemename))).ToList<Palette>());
            SelectedPalette = Palettes.Where(x => x.Name.Equals("Default")).ToList<Palette>()[0];
            UpdateTitleBarBackgroundandForeground(selectedthemename);
            ProductDemosWindow productDemo = null;
            if (this.isWindowMode)
            {
                productDemo = new ProductDemosWindow(this);
                productDemo.Owner = DemosNavigationService.MainWindow;
                SfSkinManager.SetTheme(productDemo, new Theme() { ThemeName = SelectedThemeName });
            }
            else
            {               
                if (DemosNavigationService.RootNavigationService.CanGoForward)
                {
                    DemosNavigationService.RootNavigationService.GoForward();
                }
                else
                {
                    DemosNavigationService.RootNavigationService.Navigate(new DemosListView() { DataContext = this });
                }
            }
            if (this.SearchItem == null)
            {
                SelectedSample = this.SelectedProduct.Demos[0];
            }
            else
            {
                if (searchItem.ProductDemoInfo != null && this.SelectedSample != searchItem.ProductDemoInfo)
                {
                    this.SelectedSample = searchItem.ProductDemoInfo;
                    this.SearchText = null;
                }
            }
            if (ThemeChanged != null)
            {
                ThemeChanged();
            }
            if (productDemo != null)
            {
                productDemo.ShowDialog();
            }
        }

        /// <summary>
        /// Method helps to perform sample selection change operation.
        /// </summary>
        /// <param name="demoInfo">Selected Sample</param>
        private void OnSelectedSampleChanged(DemoInfo demoInfo)
        {
            if (demoInfo == null)
                return;

            if (demoInfo.ThemeMode != ThemeMode.Inherit)
            {
                IsThemeInheritMode = false;
                ThemeButtonVisibility = false;
                if (ThemePanelVisibility)
                    ThemePanelVisibility = false;
            }
            else
            {
                IsThemeInheritMode = true;
                ThemeButtonVisibility = true;
            }

            if (demoInfo.ShowBusyIndicator)
            {
                IsProductDemoBusy = true;
            }

            var olddemo = DemosNavigationService.DemoNavigationService.Content as IDisposable;
            if (demoInfo.DemoLauchMode == DemoLauchMode.Window ||
                   (SelectedProduct != null && SelectedProduct.DemoLauchMode == DemoLauchMode.Window))
            {
                var demoLauncherView = new DemoLauncherView(demoInfo.DemoViewType) { DataContext = this };
                SfSkinManager.SetTheme(demoLauncherView, new Theme() { ThemeName = SelectedThemeName });
                DemosNavigationService.DemoNavigationService.Navigate(demoLauncherView);
            }
            else
            {
                var demoControl = DemoLaucherExtension.LauchDemo<DemoControl>(this, demoInfo);
                if (demoControl != null && DemosNavigationService.DemoNavigationService != null)
                {
                    demoControl.Title = demoInfo.SampleName;
                    demoControl.Description = demoInfo.Description;
                    DemosNavigationService.DemoNavigationService.Navigate(demoControl);
                }
            }

            if (olddemo != null)
                olddemo.Dispose();

            DemosNavigationService.MainWindow.Dispatcher.BeginInvoke(new Action(() =>
            {
                IsProductDemoBusy = false;
            }),
            System.Windows.Threading.DispatcherPriority.ApplicationIdle);


            if (demoInfo.ThemeMode != ThemeMode.Inherit || SelectedThemeName=="SystemTheme")
            {
                ColorPaletteVisibility = false;
            }
            else
            {
                ColorPaletteVisibility = true;
            }
        }

        private bool colorpalettevisibility = true;

        /// <summary>
        /// Gets or sets the property value indicating whether the colorpalette combobox should be visible or not
        /// </summary>
        public bool ColorPaletteVisibility
        {
            get { return colorpalettevisibility; }
            set
            {
                colorpalettevisibility = value;
                RaisePropertyChanged("ColorPaletteVisibility");
            }
        }

        /// <summary>
        /// Method helps to update the selected <see cref="VisualStyles"/>
        /// </summary>
        /// <param name="selectedTheme">Selected Theme</param>
        private void OnThemeChanged(string selectedTheme)
        {
            var productDemosWindow = Application.Current.Windows.OfType<ProductDemosWindow>();
            foreach (var window in productDemosWindow)
            {
                SfSkinManager.SetTheme(window, new Theme() { ThemeName = SelectedThemeName });
            }

            UpdateTitleBarBackgroundandForeground(selectedTheme);

             var navigationService = DemosNavigationService.DemoNavigationService;
            if (navigationService != null && navigationService.Content != null)
            {
                if (navigationService.Content is DemoLauncherView || navigationService.Content is DemosListView ||
                        (SelectedSample != null &&
                        navigationService.Content is DemoControl &&
                        SelectedSample.ThemeMode == ThemeMode.Inherit))
                {
                    SfSkinManager.SetTheme(navigationService.Content as DependencyObject, new Theme() { ThemeName= SelectedThemeName });
                }
            }

            if(ThemeChanged!=null)
            {
                ThemeChanged();
            }
        }

        private void UpdateTitleBarBackgroundandForeground(string selectedTheme)
        {
           
            if (selectedTheme == "SystemTheme")
            {
                TitleBarBackground = SystemColors.HighlightBrush;
                TitleBarForeground = SystemColors.HighlightTextBrush;
            }
            else
            {

                TitleBarBackground = SelectedPalette.PrimaryBackground;
                TitleBarForeground = SelectedPalette.PrimaryForeground;
            }
        }

        private ObservableCollection<Themes> themelist = new ObservableCollection<Themes>()
        {
            new Themes{ThemeName="Windows11Light", DisplayName="Light" , ThemeType="Windows 11 Themes", EllipseFill=(Brush)new BrushConverter().ConvertFromString("#FFFFFF") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#E5E5E5"), PathFill=(Brush)new BrushConverter().ConvertFromString("#005FB8")},
            new Themes{ThemeName="Windows11Dark" ,DisplayName="Dark" , ThemeType="Windows 11 Themes",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#202020") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#333333"), PathFill=(Brush)new BrushConverter().ConvertFromString("#60CDFF")},
            new Themes{ThemeName="MaterialLight",DisplayName="Light", ThemeType="Material Themes",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#FFFFFF") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#E9E9E9"), PathFill=(Brush)new BrushConverter().ConvertFromString("#0077FF")},
            new Themes{ThemeName="MaterialDark", DisplayName="Dark" ,ThemeType="Material Themes",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#848484") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#5F5F5F"), PathFill=(Brush)new BrushConverter().ConvertFromString("#0077FF") },
            new Themes{ThemeName ="MaterialLightBlue", DisplayName="Light Blue", ThemeType="Material Themes",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#BEFFF3") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#E9E9E9"), PathFill=(Brush)new BrushConverter().ConvertFromString("#008FA3")},
            new Themes{ThemeName="MaterialDarkBlue", DisplayName="Dark Blue",ThemeType="Material Themes",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#808EA3") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#64638E"), PathFill=(Brush)new BrushConverter().ConvertFromString("#08C2CE")},
            new Themes{ThemeName="Office2019White", DisplayName="White",ThemeType="Office 2019 Themes",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#FFFFFF") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#E9E9E9"), PathFill=(Brush)new BrushConverter().ConvertFromString("#0077FF")},
            new Themes{ThemeName="Office2019Black", DisplayName="Black",ThemeType="Office 2019 Themes",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#020202") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#262626"), PathFill=(Brush)new BrushConverter().ConvertFromString("#008FA3")},
            new Themes{ThemeName="Office2019Colorful", DisplayName="Colorful",ThemeType="Office 2019 Themes" ,EllipseFill=(Brush)new BrushConverter().ConvertFromString("#FFFFFF") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#E9E9E9"), PathFill=(Brush)new BrushConverter().ConvertFromString("#0077FF")},
            new Themes{ThemeName="Office2019DarkGray", DisplayName="Dark Gray",ThemeType="Office 2019 Themes",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#949494") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#949494"), PathFill=(Brush)new BrushConverter().ConvertFromString("#0077FF")},
            new Themes{ThemeName="Office2019HighContrast",DisplayName="High Contrast Black",ThemeType="Office 2019 Themes" ,EllipseFill=(Brush)new BrushConverter().ConvertFromString("#000000") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#000000"), PathFill=(Brush)new BrushConverter().ConvertFromString("#FFD600")},
            new Themes{ThemeName="Office2019HighContrastWhite", DisplayName="High Contrast White",ThemeType="Office 2019 Themes" ,EllipseFill=(Brush)new BrushConverter().ConvertFromString("#FFFFFF") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#E9E9E9"), PathFill=(Brush)new BrushConverter().ConvertFromString("#5419B4")},
            new Themes{ThemeName="FluentLight", DisplayName="Light" , ThemeType="Fluent Themes", EllipseFill=(Brush)new BrushConverter().ConvertFromString("#FFFFFF") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#E9E9E9"), PathFill=(Brush)new BrushConverter().ConvertFromString("#0077FF")},
            new Themes{ThemeName="FluentDark" ,DisplayName="Dark" , ThemeType="Fluent Themes",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#313131") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#000000"), PathFill=(Brush)new BrushConverter().ConvertFromString("#0077FF")},
            new Themes{ThemeName="SystemTheme", DisplayName="System Theme", ThemeType="System Theme",EllipseFill=(Brush)new BrushConverter().ConvertFromString("#FFFFFF") , EllipseStroke=(Brush)new BrushConverter().ConvertFromString("#888888"), PathFill=(Brush)new BrushConverter().ConvertFromString("#000000")}

        };

        public ObservableCollection<Themes> ThemeList
        {
            get { return themelist; }
            set
            {
                themelist = value;
                RaisePropertyChanged("ThemeList");

            }
        }

        private Themes selectedtheme;

        public Themes SelectedTheme
        {
            get { return selectedtheme; }
            set { selectedtheme = value;
                if (selectedtheme != null)
                {
                    SelectedThemeName = selectedtheme.ThemeName;
                }
                RaisePropertyChanged(nameof(SelectedTheme));
            }
        }


        /// <summary>
        /// Method helps to navigate the product which searched using text box.
        /// </summary>
        private void OnSearchItemChanged(ProductInfo searchItem)
        {
            if (searchItem == null)
                return;

            ProductDemo selectedProduct = searchItem.ProductDemo;
            if (selectedProduct != null && this.SelectedProduct != selectedProduct)
            {
                if (!IsWindowMode && DemosNavigationService.RootNavigationService.CanGoBack)
                {
                    DemosNavigationService.RootNavigationService.GoBack();
                }
                this.SelectedProduct = selectedProduct;
            }
        }

        /// <summary>
        /// Method used to excute navigate all products <see cref="Button"/> click event
        /// </summary>
        /// <param name="param"></param>
        private void NavigateAllProducts(object param)
        {
            if (IsWindowMode)
            {
                WindowCollection windows = Application.Current.Windows;
                foreach (Window window in windows)
                {
                    if (window is ProductDemosWindow)
                    {
                        window.Close();
                    }
                }
            }
            else
            {
                if (DemosNavigationService.RootNavigationService.CanGoBack)
                {
                    DemosNavigationService.RootNavigationService.GoBack();
                }
            }
            this.SelectedProduct = null;
            this.SelectedSample = null;
        }


        /// <summary>
        /// Method used to excute   <see cref="SfTextBoxExt"/> loaded event
        /// </summary>
        /// <param name="param"></param>
        private void SearchTextBoxLoaded(object param)
        {
            var textboxext = param as SfTextBoxExt;
            if (textboxext != null)
            {
                textboxext.Filter = GetProducts;
            }
        }

        /// <summary>
        /// Method used to excute   <see cref="MainWindow"/> loaded event
        /// </summary>
        /// <param name="param"></param>
        private void WindowLoaded(object param)
        {
#if DEBUG
            if (CanAutomate)
            {
                try
                {
                    BindingErrorAutomation.RunBindingErrorAutomation(this);
                }
                catch (Exception exception)
                {
                        if (this.SelectedProduct != null && this.SelectedSample != null)
                        {
                            ErrorLogging.LogError("Product Sample\\" + this.SelectedProduct.Product + "\\" + this.SelectedSample.SampleName + "@@" + exception.Message + " StackTrace: " + exception.StackTrace + " Exception Source: " + exception.Source);
                        }
                        else if (this.SelectedShowcaseSample != null)
                        {
                            ErrorLogging.LogError("Product ShowCase\\" + this.SelectedShowcaseSample.SampleName + "\\" + this.SelectedShowcaseSample.SampleName + "@@" + exception.Message + " StackTrace: " + exception.StackTrace + " Exception Source: " + exception.Source);
                        }
                }
            }
#endif
        }

        /// <summary>
        /// Method used to excute   <see cref="ProductDemosWindow"/> loaded event
        /// </summary>
        /// <param name="param"></param>
        private void ProductWindowLoaded(object param)
        {
#if DEBUG
            if (CanAutomate)
            {
                try
                {
                    BindingErrorAutomation.UpdateSelectedSample();
                }
                catch (Exception exception)
                {
                    if (this.SelectedProduct != null && this.SelectedSample != null)
                    {
                        ErrorLogging.LogError("Product Sample\\" + this.SelectedProduct.Product + "\\" + this.SelectedSample.SampleName + "@@" + exception.Message + " StackTrace: " + exception.StackTrace + " Exception Source: " + exception.Source);
                    }
                    else if (this.SelectedShowcaseSample != null)
                    {
                        ErrorLogging.LogError("Product ShowCase\\" + this.SelectedShowcaseSample.SampleName + "\\" + this.SelectedShowcaseSample.SampleName + "@@" + exception.Message + " StackTrace: " + exception.StackTrace + " Exception Source: " + exception.Source);
                    }
                }
            }
#endif
        }

        /// <summary>
        /// Helps to get the product demos based on serach result
        /// </summary>
        /// <param name="search">serach text</param>
        /// <param name="item">search item</param>
        /// <returns></returns>
        private bool GetProducts(string search, object item)
        {
            var model = item as ProductInfo;
            if (model != null)
            {
                if (model.SampleName.ToLower().Contains(search.ToLower()))
                {
                    return true;
                }
                else if (model.ProductDemo.Product.ToLower().Contains(search.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
        private ObservableCollection<Palette> palettes;

        /// <summary>
        /// Gets or sets the property value indicating the list of colorpalette for the selected Theme.
        /// </summary>
        public ObservableCollection<Palette> Palettes
        {
            get { return palettes; }
            set
            {
                palettes = value;
                RaisePropertyChanged("Palettes");
            }
        }
        private Palette selectedpalette;

        public Palette SelectedPalette
        {
            get { return selectedpalette; }
            set
            {
                selectedpalette = value;
                if (SelectedPalette != null && SelectedPalette.Name != null)
                {
                    OnPaletteChanged(selectedthemename);
                }
                RaisePropertyChanged("SelectedPalette");

            }
        }

        /// <summary>
        /// Method helps to update the selected ColorPalettes
        /// </summary>
        /// <param name="ThemeName">Selected Theme</param>
        void OnPaletteChanged(string ThemeName)
        {
            switch (ThemeName)
            {
                case "Windows11Light":
                    {
                        changePalette("Syncfusion.Themes.Windows11Light.WPF.Windows11LightThemeSettings, Syncfusion.Themes.Windows11Light.WPF", "Syncfusion.Themes.Windows11Light.WPF.Windows11Palette, Syncfusion.Themes.Windows11Light.WPF", ThemeName);
                        break;
                    }
                case "Windows11Dark":
                    {
                        changePalette("Syncfusion.Themes.Windows11Dark.WPF.Windows11DarkThemeSettings, Syncfusion.Themes.Windows11Dark.WPF", "Syncfusion.Themes.Windows11Dark.WPF.Windows11Palette, Syncfusion.Themes.Windows11Dark.WPF", ThemeName);
                        break;
                    }
                case "FluentLight":
                    {
                        changePalette("Syncfusion.Themes.FluentLight.WPF.FluentLightThemeSettings, Syncfusion.Themes.FluentLight.WPF", "Syncfusion.Themes.FluentLight.WPF.FluentPalette, Syncfusion.Themes.FluentLight.WPF", ThemeName);
                        break;
                    }
                case "FluentDark":
                    {
                        changePalette("Syncfusion.Themes.FluentDark.WPF.FluentDarkThemeSettings, Syncfusion.Themes.FluentDark.WPF",  "Syncfusion.Themes.FluentDark.WPF.FluentPalette, Syncfusion.Themes.FluentDark.WPF", ThemeName);
                        break;
                    }
                case "MaterialLight":
                    {
                        changePalette("Syncfusion.Themes.MaterialLight.WPF.MaterialLightThemeSettings, Syncfusion.Themes.MaterialLight.WPF", "Syncfusion.Themes.MaterialLight.WPF.MaterialPalette, Syncfusion.Themes.MaterialLight.WPF", ThemeName);
                        break;
                    }
                case "MaterialLightBlue":
                    {
                        changePalette("Syncfusion.Themes.MaterialLightBlue.WPF.MaterialLightBlueThemeSettings, Syncfusion.Themes.MaterialLightBlue.WPF", "Syncfusion.Themes.MaterialLightBlue.WPF.MaterialPalette, Syncfusion.Themes.MaterialLightBlue.WPF", ThemeName);
                        break;
                    }
                case "MaterialDark":
                    {
                        changePalette("Syncfusion.Themes.MaterialDark.WPF.MaterialDarkThemeSettings, Syncfusion.Themes.MaterialDark.WPF", "Syncfusion.Themes.MaterialDark.WPF.MaterialPalette, Syncfusion.Themes.MaterialDark.WPF", ThemeName);
                        break;
                    }
                case "MaterialDarkBlue":
                    {
                        changePalette("Syncfusion.Themes.MaterialDarkBlue.WPF.MaterialDarkBlueThemeSettings, Syncfusion.Themes.MaterialDarkBlue.WPF", "Syncfusion.Themes.MaterialDarkBlue.WPF.MaterialPalette, Syncfusion.Themes.MaterialDarkBlue.WPF", ThemeName);
                        break;
                    }
                case "Office2019Colorful":
                    {
                        changePalette("Syncfusion.Themes.Office2019Colorful.WPF.Office2019ColorfulThemeSettings, Syncfusion.Themes.Office2019Colorful.WPF", "Syncfusion.Themes.Office2019Colorful.WPF.Office2019Palette, Syncfusion.Themes.Office2019Colorful.WPF", ThemeName);
                        break;
                    }
                case "Office2019Black":
                    {
                        changePalette("Syncfusion.Themes.Office2019Black.WPF.Office2019BlackThemeSettings, Syncfusion.Themes.Office2019Black.WPF", "Syncfusion.Themes.Office2019Black.WPF.Office2019Palette, Syncfusion.Themes.Office2019Black.WPF", ThemeName);
                        break;
                    }
                case "Office2019White":
                    {
                        changePalette("Syncfusion.Themes.Office2019White.WPF.Office2019WhiteThemeSettings, Syncfusion.Themes.Office2019White.WPF", "Syncfusion.Themes.Office2019White.WPF.Office2019Palette, Syncfusion.Themes.Office2019White.WPF", ThemeName);
                        break;
                    }
                case "Office2019DarkGray":
                    {
                        changePalette("Syncfusion.Themes.Office2019DarkGray.WPF.Office2019DarkGrayThemeSettings, Syncfusion.Themes.Office2019DarkGray.WPF", "Syncfusion.Themes.Office2019DarkGray.WPF.Office2019Palette, Syncfusion.Themes.Office2019DarkGray.WPF", ThemeName);
                        break;

                    }
                case "Office2019HighContrast":
                    {
                        changePalette("Syncfusion.Themes.Office2019HighContrast.WPF.Office2019HighContrastThemeSettings, Syncfusion.Themes.Office2019HighContrast.WPF", "Syncfusion.Themes.Office2019HighContrast.WPF.HighContrastPalette, Syncfusion.Themes.Office2019HighContrast.WPF", ThemeName);
                        break;
                    }
                case "Office2019HighContrastWhite":
                    {
                        changePalette("Syncfusion.Themes.Office2019HighContrastWhite.WPF.Office2019HighContrastWhiteThemeSettings, Syncfusion.Themes.Office2019HighContrastWhite.WPF", "Syncfusion.Themes.Office2019HighContrastWhite.WPF.HighContrastPalette, Syncfusion.Themes.Office2019HighContrastWhite.WPF", ThemeName);
                        break;
                    }

            }
            if (SelectedSample != null)
            {
                OnThemeChanged(ThemeName);
            }
        }

        /// <summary>
        /// Method helps to Change the Color palette for the SelectedTheme
        /// </summary>
        /// <param name="themeType">Type of the theme</param>
        /// <param name="theme">Name of the selected theme</param>
        private void changePalette(string themeType, string paletteType, string theme)
        {
            object themeSettings = Activator.CreateInstance(Type.GetType(themeType));
            themeSettings.GetType().GetRuntimeProperty("Palette").SetValue(themeSettings, Enum.Parse(Type.GetType(paletteType), SelectedPalette.Name));
            SfSkinManager.RegisterThemeSettings(theme, (IThemeSetting)themeSettings);
        }

        /// <summary>
        /// Method helps to populate palette items into Palettelist
        /// </summary>
            void PopulatePaletteList()
            {
                var paletteDetails = new List<Palette>();
                var xml = File.ReadAllText(@"Model/PaletteList.xml");
                XmlDocument Doc = new XmlDocument();
                Doc.LoadXml(xml);
                XmlNodeList xmlnode = Doc.GetElementsByTagName("Palettes");
               
            for (int i = 0; i <= xmlnode.Count - 1; i++)
            {
                foreach (var node in xmlnode[i].ChildNodes)
                {
                    var element = node as XmlElement;
                    string name = null, theme = null, primaryBackground = null, primaryForeground = null, primaryBackgroundAlt = null, displayname = null;

                    if (element == null || element.Attributes.Count <= 0)
                        continue;

                    name = element.HasAttribute("Name") ? element.Attributes["Name"].Value : string.Empty;
                    theme = element.HasAttribute("Theme") ? element.Attributes["Theme"].Value : string.Empty;

                    primaryBackground = element.HasAttribute("PrimaryBackground") ? element.Attributes["PrimaryBackground"].Value : string.Empty;
                    primaryForeground = element.HasAttribute("PrimaryForeground") ? element.Attributes["PrimaryForeground"].Value : string.Empty;
                    primaryBackgroundAlt = element.HasAttribute("PrimaryBackgroundAlt") ? element.Attributes["PrimaryBackgroundAlt"].Value : string.Empty;
                    displayname = element.HasAttribute("DisplayName") ? element.Attributes["DisplayName"].Value : string.Empty;
                    var palette = new Palette()
                    {
                        Name = name,
                        Theme = theme,
                        DisplayName = displayname,
                        PrimaryBackground = (Brush)new BrushConverter().ConvertFromString(primaryBackground),
                        PrimaryForeground = (Brush)new BrushConverter().ConvertFromString(primaryForeground),
                        PrimaryBackgroundAlt = (Brush)new BrushConverter().ConvertFromString(primaryBackgroundAlt)
                    };
                    paletteDetails.Add(palette);
                }
            }
            PaletteList = paletteDetails;

        }

       

    }
 }

