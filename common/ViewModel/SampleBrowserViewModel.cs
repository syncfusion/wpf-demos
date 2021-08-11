#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.demoscommon.wpf
{
    public abstract class DemoBrowserViewModel : NotificationObject
    {
        public static string DefaultThemeName = "FluentLight";

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

        /// <summary>
        /// Method helps to perform product selection change.
        /// </summary>
        private void OnSelectedProductChanged()
        {
            if (this.SelectedProduct == null)
                return;

            selectedthemename = DemoBrowserViewModel.DefaultThemeName;
            ProductDemosWindow productDemo= null;
            if (this.isWindowMode)
            {
                UpdateTitleBarBackgroundandForeground(SelectedThemeName);
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
            }
            else
            {
                IsThemeInheritMode = true;
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
        }

        private void UpdateTitleBarBackgroundandForeground(string selectedTheme)
        {
            if (selectedTheme == "MaterialLight")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(1, 121, 255));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (selectedTheme == "MaterialDark")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(5, 218, 197));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else if (selectedTheme == "MaterialLightBlue")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(15, 115, 175));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (selectedTheme == "MaterialDarkBlue")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(137, 209, 63));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else if (selectedTheme == "Office2019Colorful")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(43, 87, 154));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (selectedTheme == "Office2019Black")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(38, 90, 170));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (selectedTheme == "Office2019DarkGray")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(43, 87, 154));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (selectedTheme == "Office2019White")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(43, 87, 154));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (selectedTheme == "Office2019HighContrast")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(250, 217, 91));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else if (selectedTheme == "Office2019HighContrastWhite")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(76, 0, 148));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (selectedTheme == "SystemTheme")
            {
                TitleBarBackground = SystemColors.HighlightBrush;
                TitleBarForeground = SystemColors.HighlightTextBrush;
            }
            else if (selectedTheme == "FluentLight")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(0, 120, 212));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (selectedTheme == "FluentDark")
            {
                TitleBarBackground = new SolidColorBrush(Color.FromRgb(0, 120, 212));
                TitleBarForeground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
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
                catch (Exception e)
                {
                    ErrorLogging.LogError(this.SelectedProduct.Product+ "\\"+ this.SelectedSample.SampleName+ "-"+ e.Message + "\n" + e.StackTrace);
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
                catch (Exception e)
                {
                    ErrorLogging.LogError(this.SelectedProduct.Product + "\\" + this.SelectedSample.SampleName + "-" + e.Message + "\n" + e.StackTrace);
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

    }
}
