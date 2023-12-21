#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Controls.Input;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

        /// <summary>
        /// Gets or set the selecteditem of the NavigationDrawer
        /// </summary>
        private object selectedItem;

        /// <summary>
        /// Gets or set the pageview of the items of NavigationDrawer
        /// </summary>
        private object navigationContent;

        /// <summary>
        /// Gets or set the HeaderItems Collection
        /// </summary>
        private ObservableCollection<NavigationViewModel> headerItems;

        /// <summary>
        /// Maintains the command for the ShowAll ,Explore All Controls ,ListView and GalleryView Buttons
        /// </summary>
        private ICommand clickCommand;

        /// <summary>
        /// Gets or sets the selected Demo in the Whatsnew Demoslist
        /// </summary>
        private DemoInfo _selectedDemo;

        /// <summary>
        /// Property to store visibility state of blur layer in sample browser.
        /// </summary>
        private Visibility blurVisibility = Visibility.Collapsed;

        /// <summary>
        /// Gets or sets the selected subDemo in the demo window
        /// </summary>
        private DemoInfo subCategorySelectedItem;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public DemoBrowserViewModel()
        {
            clickCommand = new DelegateCommand<object>(OnClicked);
            AppCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            ProductDemos = GetDemosDetails();
            HighlightedProductDemos = PopulateHighlightedProductDemos();
            WhatsNewDemos = PopulateWhatsNewDemos();
            PopulateProducts();
            PopulatePaletteList();
            NavigationItems();
            if (this.HeaderItems.Any())
            {
                this.SelectedItem = this.GetType().Name != "SamplesViewModel" ? this.HeaderItems.Last() : this.HeaderItems.First();
            }
            HighlightedShowCaseDemos = PopulateShowCaseDemos();
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
                if (_selectedsample == null || _selectedsample.SubCategoryDemos == null)
                {
                    this.SubCategorySelectedItem = null;
                }
                else if (_selectedsample.SubCategoryDemos != null
                && _selectedsample.SubCategoryDemos.Count > 0 && (this.subCategorySelectedItem == null || 
                !_selectedsample.SubCategoryDemos.Contains(this.SubCategorySelectedItem)))
                {
                    this.SubCategorySelectedItem = _selectedsample.SubCategoryDemos.FirstOrDefault();
                }
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

        /// <summary>
        /// Gets the command for the ShowAll ,Explore All Controls ,ListView and GalleryView Buttons
        /// </summary>
        public ICommand ClickCommand
        {
            get
            {
                return clickCommand;
            }
            set
            {
                clickCommand = value;
                this.RaisePropertyChanged(nameof(ClickCommand));
            }
        }

        /// <summary>
        /// Gets or sets the SelectedItem of the NavigationDrawer
        /// </summary>
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnSelectionChanged();
                this.RaisePropertyChanged(nameof(SelectedItem));
            }
        }
        /// <summary>
        /// Gets or sets the UserControl for the selected NavigationItem
        /// </summary>
        public object NavigationContent
        {
            get { return navigationContent; }
            set
            {
                navigationContent = value;
                this.RaisePropertyChanged(nameof(NavigationContent));
            }
        }
        /// <summary>
        /// Gets or sets the property value indicating the collection of HeaderItems.
        /// </summary>
        public ObservableCollection<NavigationViewModel> HeaderItems
        {
            get
            {
                return headerItems;
            }
            set
            {
                headerItems = value;
                this.RaisePropertyChanged(nameof(HeaderItems));
            }
        }
        /// <summary>
        /// Gets or sets the collection of Highlighted product demos.
        /// </summary>
        public List<ProductDemo> HighlightedProductDemos { get; set; }

        /// <summary>
        /// Gets or sets the collection of Highlighted ShowCase demos.
        /// </summary>
        public List<DemoInfo> HighlightedShowCaseDemos { get; set; }
       
        /// <summary>
        /// Gets or sets the collection of WhatsNewDemos
        /// </summary>
        public List<DemoInfo> WhatsNewDemos { get; set; }

        /// <summary>
        /// Gets or sets the selected demo in the WhatsNew List
        /// </summary>
        public DemoInfo SelectedDemo
        {
            get { return _selectedDemo; }
            set
            {
                _selectedDemo = value;
                OnSelectedDemoChanged();
                this.RaisePropertyChanged("SelectedDemo");
            }
        }

        /// <summary>
        /// Gets or sets the visibility state of the blur layer in sample browser.
        /// </summary>
        public Visibility BlurVisibility
        {
            get { return blurVisibility; }
            set
            {
                blurVisibility = value;
                RaisePropertyChanged(nameof(BlurVisibility));
            }
        }

        /// <summary>
        /// Gets or sets the selected sub demo in the demo window
        /// </summary>
        public DemoInfo SubCategorySelectedItem
        {
            get { return subCategorySelectedItem; }
            set
            {
                subCategorySelectedItem = value;
                this.RaisePropertyChanged(nameof(SubCategorySelectedItem));
                OnSubCategorySelectedItemChanged();
            }
        }

        #endregion

        /// <summary>
        /// Method helps to create collection of Product Demos that are Highlighted
        /// </summary>
        private List<ProductDemo> PopulateHighlightedProductDemos()
        {
            List<ProductDemo> products = new List<ProductDemo>();
            if(ProductDemos!=null)
            {
                foreach (ProductDemo product in ProductDemos)
                {
                    if (product != null && product.IsHighlighted == true)
                    {
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        /// <summary>
        /// Method helps to create collection of Showcase Demos that are Highlighted
        /// </summary>
        private List<DemoInfo> PopulateShowCaseDemos()
        {
            List<DemoInfo> products = new List<DemoInfo>();
            if (ShowcaseDemos != null)
            {
                foreach (DemoInfo product in ShowcaseDemos)
                {
                    if (product != null && product.IsShowcase == true)
                    {
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        /// <summary>
        /// Method helps to create collection for Demos with New,Updated and Preview Tags.
        /// </summary>
        private List<DemoInfo> PopulateWhatsNewDemos()
        {
            List<DemoInfo> products = new List<DemoInfo>();
            if(ProductDemos!= null)
            {
                foreach (ProductDemo product in ProductDemos)
                {
                    foreach (DemoInfo demo in product.Demos)
                    {
                        if (demo.Tag != Tag.None)
                        {
                            if(string.IsNullOrEmpty(demo.WhatsNewDescription))
                            {
                                demo.WhatsNewDescription = demo.Description;
                            }
                            demo.ProductInfo = product;
                            demo.PreviewTag = product.IsPreview;
                            demo.ControlName = product.Product;
                            products.Add(demo);
                        }
                    }
                }
            }
            return products;
        }

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
        /// Method helps to perform demo selection change in WhatsNew List.
        /// </summary>
        private void OnSelectedDemoChanged()
        {
            if(this.SelectedDemo == null)
                return;

            this.SelectedProduct = this.SelectedDemo.ProductInfo;
        }
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
            if (this.SearchItem == null && this.SelectedDemo == null)
            {
                SelectedSample = this.SelectedProduct.Demos[0];
            }
            else if (this.SelectedDemo != null)
            {
                this.SelectedSample = this.SelectedDemo;
            }
            else
            {
                if (searchItem != null && searchItem.ProductDemoInfo != null && this.SelectedSample != searchItem.ProductDemoInfo)
                {
                    this.SelectedSample = searchItem.ProductDemoInfo;
                    this.SearchText = null;
                }
            }
            if (ThemeChanged != null)
            {
                ThemeChanged();
            }

            DemosNavigationService.MainWindow.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (productDemo != null)
                {
                    productDemo.ShowDialog();
                }
            }),
          System.Windows.Threading.DispatcherPriority.Background);
        }

        /// <summary>
        /// Method helps to perform subdemo selection change operation.
        /// </summary>
        private void OnSubCategorySelectedItemChanged()
        {
            if (this.SubCategorySelectedItem == null)
                return;
            this.SubCategorySelectedItem.SubCategoryDemos = this.SelectedSample.SubCategoryDemos;
            this.SelectedSample = this.SubCategorySelectedItem;
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
                if (demoLauncherView.Resources["WPFHyperlinkStyle"] != null)
                {
                    demoLauncherView.HyperLinkStyle = demoLauncherView.Resources["WPFHyperlinkStyle"] as Style;
                }
                DemosNavigationService.DemoNavigationService.Navigate(demoLauncherView);
            }
            else
            {
                var demoControl = DemoLaucherExtension.LauchDemo<DemoControl>(this, demoInfo);
                if (demoControl != null && DemosNavigationService.DemoNavigationService != null)
                {
                    demoControl.SubCategoryDemos = demoInfo.SubCategoryDemos;
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("SubCategorySelectedItem");
                    binding.Source = this;
                    binding.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(demoControl, DemoControl.SubCategorySelectedItemProperty, binding);

                    demoControl.ControlName = this.SelectedProduct != null ? this.SelectedProduct.Product : string.Empty;
                    demoControl.Title = demoInfo.SampleName;
                    demoControl.Description = demoInfo.Description;
                    demoControl.DocumentsItemSource = demoInfo.Documentations;
                    if(demoControl.Resources["WPFHyperlinkStyle"] != null)
                    {
                        demoControl.HyperLinkStyle = demoControl.Resources["WPFHyperlinkStyle"] as Style;
                    }
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
                if (navigationService.Content is DemoControl demoControl && SelectedSample?.ThemeMode == ThemeMode.Inherit &&
                        demoControl.Resources["WPFHyperlinkStyle"] is Style hyperlinkStyle && hyperlinkStyle != null)
                {
                    demoControl.HyperLinkStyle = hyperlinkStyle;
                }
                else if (navigationService.Content is DemoLauncherView demoLauncherView &&
                    demoLauncherView.Resources["WPFHyperlinkStyle"] is Style launcherHyperlinkStyle && launcherHyperlinkStyle != null)
                {
                    demoLauncherView.HyperLinkStyle = launcherHyperlinkStyle;
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
                        this.SelectedItem = this.HeaderItems.Last();
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
        /// Helps to get the product demos based on search result
        /// </summary>
        /// <param name="search">search text</param>
        /// <param name="item">search item</param>
        /// <returns></returns>
        private bool GetProducts(string search, object item)
        {
            if (item is ProductInfo model)
            {
                bool sampleNameContainsSearch = ContainsIgnoreCaseAndSpaceRemoved(model.SampleName, search);
                bool productContainsSearch = ContainsIgnoreCaseAndSpaceRemoved(model.ProductDemo.Product, search);

                return sampleNameContainsSearch || productContainsSearch;
            }
            return false;
        }

        /// <summary>
        /// Checks if the source string contains a search string (ignoring case and spaces) and returns a boolean result.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        private bool ContainsIgnoreCaseAndSpaceRemoved(string source, string search)
        {
            if (source == null || search == null)
            {
                return false;
            }

            return source.Replace(" ", "").ToLower().Contains(search.Replace(" ", "").ToLower());
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
        /// <summary>
        /// Method helps to populate items into NavigationDrawer HeaderItems
        /// </summary>
        private void NavigationItems()
        {
            this.HeaderItems = new ObservableCollection<NavigationViewModel>();
            NavigationViewModel home = new NavigationViewModel()
            {
                NavigationItem = "Home",
                NavigationIcon = new System.Windows.Shapes.Path()
                {
                    Data = Geometry.Parse("M0.5 6.93825C0.5 6.65915 0.616638 6.39275 0.82172 6.20345L6.32172 1.12652C6.70478 0.772929 7.29522 0.77293 7.67828 1.12652L13.1783 6.20345C13.3834 6.39276 13.5 6.65915 13.5 6.93825V13.5004C13.5 14.0527 13.0523 14.5004 12.5 14.5004H9C8.72386 14.5004 8.5 14.2766 8.5 14.0004V10.0004C8.5 9.72428 8.27614 9.50042 8 9.50042H6C5.72386 9.50042 5.5 9.72428 5.5 10.0004V14.0004C5.5 14.2766 5.27614 14.5004 5 14.5004H1.5C0.947715 14.5004 0.5 14.0527 0.5 13.5004V6.93825Z"),
                    Stroke = new SolidColorBrush(Colors.Black),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
            NavigationViewModel whatsNew = new NavigationViewModel()
            {
                NavigationItem = "What's New",
                NavigationIcon = new System.Windows.Shapes.Path()
                {
                    Data = Geometry.Parse("M5.28176 12.5C5.47648 13.1683 5.74709 13.8512 5.98382 14.3963C6.28203 15.083 6.97041 15.5 7.71907 15.5H8.80168C9.53942 15.5 10.2212 15.0951 10.5083 14.4155C10.7406 13.8657 10.9959 13.1732 11.1417 12.5H5.28176ZM5.28176 12.5C4.97352 11.4421 5 11 4.26903 10.0411C3.09433 8.5 2.5 7 2.5 6C2.5 2.96243 4.96243 0.5 8 0.5C11.0376 0.5 13.5 2.96243 13.5 6C13.5 7 13.1747 8.5 12 10.0411C11.269 11 11.4582 11.4421 11.15 12.5"),
                    Stroke = new SolidColorBrush(Colors.Black),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
            NavigationViewModel showcaseApplication = new NavigationViewModel()
            {
                NavigationItem = "Showcase",
                NavigationIcon = new System.Windows.Shapes.Path()
                {
                    Data = Geometry.Parse("M6.50386 0.207929C6.8113 0.0322524 7.18871 0.0322534 7.49614 0.207929L13.4884 3.63205C14.1602 4.01595 14.1602 4.98465 13.4884 5.36854L7.49614 8.79266C7.1887 8.96834 6.81129 8.96834 6.50386 8.79266L0.511643 5.36854C-0.160172 4.98464 -0.160171 4.01595 0.511643 3.63205L6.50386 0.207929ZM7 1.07617L1.00778 4.5003L7 7.92442L12.9922 4.5003L7 1.07617ZM0.417638 6.80694C0.274499 6.83095 0.142952 6.91679 0.065554 7.05276C-0.0710532 7.29275 0.0127516 7.59803 0.252737 7.73464L6.50539 11.2938C6.81208 11.4684 7.18809 11.4684 7.49478 11.2938L13.7474 7.73464C13.9874 7.59803 14.0712 7.29275 13.9346 7.05276C13.8572 6.91679 13.7257 6.83095 13.5825 6.80694C13.5528 6.82847 13.5214 6.84872 13.4884 6.86757L7.49622 10.2917C7.34321 10.3791 7.17285 10.4231 7.00242 10.4234L7.00009 10.4248L6.99775 10.4234C6.82732 10.4231 6.65697 10.3791 6.50395 10.2917L0.511729 6.86757C0.478746 6.84872 0.447382 6.82847 0.417638 6.80694ZM0.065554 9.44729C0.142952 9.31132 0.274499 9.22549 0.417638 9.20147C0.447382 9.223 0.478746 9.24325 0.511729 9.2621L6.50395 12.6862C6.65697 12.7737 6.82732 12.8176 6.99775 12.818L7.00009 12.8193L7.00242 12.818C7.17285 12.8176 7.34321 12.7737 7.49622 12.6862L13.4884 9.2621C13.5214 9.24325 13.5528 9.223 13.5825 9.20147C13.7257 9.22549 13.8572 9.31132 13.9346 9.44729C14.0712 9.68728 13.9874 9.99257 13.7474 10.1292L7.49478 13.6884C7.18809 13.863 6.81208 13.863 6.50539 13.6884L0.252737 10.1292C0.0127516 9.99257 -0.0710532 9.68728 0.065554 9.44729Z"),
                    Fill = new SolidColorBrush(Colors.Black),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
            NavigationViewModel allComponents = new NavigationViewModel()
            {
                NavigationItem = "All Controls",
                NavigationIcon = new System.Windows.Shapes.Path()
                {
                    Data = Geometry.Parse("M5.5 1.5H13.5M5.5 6.5H13.5M5.5 11.5H13.5M1 3.5H3C3.27614 3.5 3.5 3.27614 3.5 3V1C3.5 0.723858 3.27614 0.5 3 0.5H1C0.723858 0.5 0.5 0.723858 0.5 1V3C0.5 3.27614 0.723858 3.5 1 3.5ZM1 8.5H3C3.27614 8.5 3.5 8.27614 3.5 8V6C3.5 5.72386 3.27614 5.5 3 5.5H1C0.723858 5.5 0.5 5.72386 0.5 6V8C0.5 8.27614 0.723858 8.5 1 8.5ZM1 13.5H3C3.27614 13.5 3.5 13.2761 3.5 13V11C3.5 10.7239 3.27614 10.5 3 10.5H1C0.723858 10.5 0.5 10.7239 0.5 11V13C0.5 13.2761 0.723858 13.5 1 13.5Z"),
                    Stroke = new SolidColorBrush(Colors.Black),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
            if(this.GetType().Name != "SamplesViewModel") 
            {
                if(this.WhatsNewDemos.Any())
                {
                    this.HeaderItems.Add(whatsNew);
                }
                this.HeaderItems.Add(allComponents);
            }
            else
            {
                this.HeaderItems.Add(home);
                this.HeaderItems.Add(whatsNew);
                this.HeaderItems.Add(showcaseApplication);
                this.HeaderItems.Add(allComponents);
            }
        }

        /// <summary>
        /// Method helps to display page based on NavigationItem selection
        /// </summary>
        private void OnSelectionChanged()
        {
            string pagename = string.Empty;
            if (this.SelectedItem == null)
                return;
            if (this.SelectedItem is NavigationViewModel navigationViewModel)
            {
                pagename = navigationViewModel.NavigationItem.ToString();
            }
            else if (this.SelectedItem is NavigationItem navigationItem)
            {
                pagename = navigationItem.Header.ToString();
            }
            if (pagename == "Home")
            {
                NavigationContent = new HomePage();
            }
            else if (pagename == "What's New")
            {
                NavigationContent = new WhatsNew();
            }
            else if (pagename == "Showcase")
            {
                NavigationContent = new ShowcaseApplication();
            }
            else if (pagename == "All Controls")
            {
                NavigationContent = new AllComponentsPage();
            }
        }

        private void OnClicked(object paramater)
        {
            if (paramater is RadioButton)
            {
                RadioButton button = (RadioButton)paramater;
                UserControl userControl = VisualUtils.FindAncestor(button, typeof(UserControl)) as UserControl;
                if (userControl != null)
                {
                    ListView listView = VisualUtils.FindDescendant(userControl, typeof(ListView)) as ListView;
                    if (listView != null)
                    {
                        listView.GroupStyle.Clear();
                        DataTemplate FirstTemplate = userControl.Resources["ListViewTemplate"] as DataTemplate;
                        DataTemplate SecondTemplate = userControl.Resources["GalleryViewTemplate"] as DataTemplate;
                        GroupStyle groupstyle1 = userControl.Resources["ListViewGroupStyle"] as GroupStyle;
                        GroupStyle groupstyle2 = userControl.Resources["GalleryViewGroupStyle"] as GroupStyle;
                        listView.ItemTemplate = button.Name.ToString() == "galleryViewButton" ? SecondTemplate : FirstTemplate;
                        if (button.Name.ToString() == "galleryViewButton")
                        {
                            listView.GroupStyle.Add(groupstyle2);
                        }
                        else
                        {
                            listView.GroupStyle.Add(groupstyle1);
                        }
                    }
                }
            }
            if (paramater.ToString() == "ShowAllShowcase")
            {
                if (this.HeaderItems.Count > 0)
                {
                    this.SelectedItem = this.HeaderItems.ElementAt(2);
                }
            }
            else if (paramater.ToString() == "ExploreAllControls")
            {
                if (this.HeaderItems.Count > 0)
                {
                    this.SelectedItem = this.HeaderItems.Last();
                }
            }
            else if (paramater.ToString() == "Buy Now")
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.syncfusion.com/sales/products/wpf") { UseShellExecute = true });
            }
            else if (paramater.ToString() == "Document")
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo("https://help.syncfusion.com/wpf/welcome-to-syncfusion-essential-wpf") { UseShellExecute = true });
            }
            else if (paramater.ToString() == "Support")
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo("https://support.syncfusion.com/create") { UseShellExecute = true });
            }
            else if (paramater.ToString() == "Source Code in GitHub")
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo("https://github.com/syncfusion/wpf-demos") { UseShellExecute = true });
            }
        }
    }
 }

