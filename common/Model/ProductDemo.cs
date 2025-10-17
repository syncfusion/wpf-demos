using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Specifies the launch mode of  demo.
    /// </summary>    
    public enum DemoLauchMode
    {
        /// <summary>
        /// To load demo inside the sample browser 
        /// </summary>
        Default,

        /// <summary>
        /// To lauch this demo in separate window.
        /// </summary>
        Window
    }

    /// <summary>
    /// Specifies the sample status
    /// </summary>
    public enum Tag
    {
        /// <summary>
        /// No changes done in your demo
        /// </summary>
        None,

        /// <summary>
        /// New Sample
        /// </summary>
        New,

        /// <summary>
        /// Changes are made in your sample.
        /// </summary>
        Updated

    }

    /// <summary>
    /// Determine the whether main window theme should traverse to the your demos in the sample browser
    /// </summary>
    public enum ThemeMode
    {
        /// <summary>
        /// Main window theme will not apply to your demos.
        /// </summary>
        None,
        /// <summary>
        /// Office2019Colorful theme will apply
        /// </summary>
        Default,

        /// <summary>
        /// Main window theme will apply to your demos
        /// </summary>
        Inherit
    }

    /// <summary>
    /// Provides information about the Products.
    /// </summary>
    public abstract class ProductDemo
    {
        private object listViewImagePathData;

        /// <summary>
        /// Gets or set a value indicating whether the control is in preview or not.
        /// </summary>
        public bool IsPreview { get; set; }

        /// <summary>
        /// Gets or set a value of ImageSource to represent the control in GalleryView.
        /// </summary>
        public BitmapImage GalleryViewImageSource { get; set; }

        /// <summary>
        /// Gets or set a value of ImagePathData to represent the control in listview.
        /// </summary>
        public object ListViewImagePathData
        {
            get { return listViewImagePathData; }
            set { listViewImagePathData = value; }
        }

        /// <summary>
        /// Gets or set a value of HeaderImageSource which represents the ProductCategory in ListView.
        /// </summary>
        public BitmapImage HeaderImageSource { get; set; }
       
        /// <summary>
        /// Gets or sets the control description
        /// </summary>
        public string ControlDescription { get; set; }
        /// <summary>
        /// Gets or sets the value of IsHighlighted which denotes whether the Product Demo is highlighted or not
        /// </summary>
        public bool IsHighlighted { get; set; }

        /// <summary>
        /// Gets or sets DemoLaunchMode which denotes whether to load Product demos inside sample browser or in child window.
        /// </summary>
        private DemoLauchMode demoLauchMode = DemoLauchMode.Default;

        /// <summary>
        /// Gets or sets the Product name.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the collection of product demos.
        /// </summary>
        public List<DemoInfo> Demos { get; set; }

        /// <summary>
        /// Gets or sets the Product category.
        /// </summary>
        public string ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets DemoLaunchMode which denotes whether to load Product demos inside sample browser or in child window.
        /// </summary>
        public DemoLauchMode DemoLauchMode
        {
            get
            {
                return demoLauchMode;
            }
            set
            {
                if (demoLauchMode != value)
                {
                    this.demoLauchMode = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Product status.
        /// </summary>
        public Tag Tag { get; set; }

    }

    /// <summary>
    /// Provides information about the product demos.
    /// </summary>
    public class DemoInfo
    {
        /// <summary>
        /// Gets or sets the sample's whatsnew description.
        /// </summary>
        public string WhatsNewDescription { get; set; }

        /// <summary>
        /// Gets or sets the AI sample's description.
        /// </summary>
        public string AISampleDescription { get; set; }

        /// <summary>
        /// Gets or sets the Product details of the SelectedDemo.
        /// </summary>
        public ProductDemo ProductInfo { get; internal set; }

        /// <summary>
        /// Gets or set a value indicating whether the control is in preview or not.
        /// </summary>
        public bool PreviewTag { get; internal set; }

        /// <summary>
        /// Gets or sets the ControlName
        /// </summary>
        public string ControlName { get; internal set; }

        /// <summary>
        /// Gets or sets the GroupName of your demo.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Specify your the sample name which is displayed in sample browser using this property
        /// </summary>
        public string SampleName { get; set; }

        /// <summary>
        /// Specify your sample title which is displayed in sample browser using this property
        /// </summary>
        private string title = null;
        public string Title
        { 
            get
            {
                if (title == null)
                {
                    return SampleName;
                }
                return title;
            }
            set
            {
                if (title != value)
                {
                    this.title = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the description of the sample.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the viewtype of the sample.
        /// </summary>
        public Type DemoViewType { get; set; }

        /// <summary>
        /// Images which needs to be show inside the sample browser
        /// </summary>
        ///<remarks>It applicable only for showcase demo</remarks>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets DemoLaunchMode which denotes whether to load demo insider sample browser or in separate window.
        /// </summary>
        public DemoLauchMode DemoLauchMode { get; set; }

        private ThemeMode themeMode= ThemeMode.Inherit ;

        /// <summary>
        /// Gets or sets the value indicating whether the busy indicator needs to display or not while load the demo.
        /// </summary>
        private bool showBusyIndicator = true;

        /// <summary>
        /// Gets or sets the value determine the whether main window theme should traverse to the your demos in the sample browser
        /// </summary>
        public ThemeMode ThemeMode
        {
            get
            {
                return themeMode;
            }
            set
            {
                if (themeMode != value)
                {
                    this.themeMode = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the sample status.
        /// </summary>
        public Tag Tag { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the busy indicator needs to display or not while load the demo.
        /// </summary>
        public bool ShowBusyIndicator
        {
            get { return showBusyIndicator; }
            set
            {
                showBusyIndicator = value;
            }
        }
        /// <summary>
        /// Gets or sets the value of IsShowcase which denotes whether the ShowcaseDemos needs to be Showcased or not
        /// </summary>
        public bool IsShowcase { get; set; }
        /// <summary>
        /// Gets or sets the AI status.
        /// </summary>
        public bool IsAISample { get; set; }
        /// <summary>
        /// Gets or sets a collection of documentation items.
        /// </summary>
        public List<Documentation> Documentations { get; set; }
        
        /// <summary>
        /// Gets or sets a collection of subdemo items.
        /// </summary>
        public List<DemoInfo> SubCategoryDemos { get; set; }
    }

    /// <summary>
    /// This class represents documentation with content and a page URI.
    /// </summary>
    public class Documentation
    {
        /// <summary>
        /// A property that represents the content or text associated with the link.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// A property that represents a Uniform Resource Identifier (URI) for a specific page or location.
        /// </summary>
        public Uri Uri { get; set; }
    }

    /// <summary>
    /// Provide information about the product and product demos.
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// Gets or sets the sample name
        /// </summary>
        public string SampleName { get; set; }

        /// <summary>
        /// Gets or sets the Product information.
        /// </summary>
        public ProductDemo ProductDemo { get; set; }

        /// <summary>
        /// Gets or set demo information.
        /// </summary>
        public DemoInfo ProductDemoInfo { get; set; }
    }

    
    public class Palette
    {
        private string name;
        /// <summary>
        /// Denotes the palette name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string theme;
        /// <summary>
        /// Denotes the Theme Name
        /// </summary>
        public string Theme
        {
            get { return theme; }
            set { theme = value; }
        }

        private Brush primaryBackground;
        /// <summary>
        /// Denotes the palette primary background brush
        /// </summary>
        public Brush PrimaryBackground
        {
            get { return primaryBackground; }
            set { primaryBackground = value; }
        }

        private Brush primaryForeground;
        /// <summary>
        /// Denotes the palette primary foreground brush
        /// </summary>
        public Brush PrimaryForeground
        {
            get { return primaryForeground; }
            set { primaryForeground = value; }
        }

        private Brush primaryBackgroundAlt;
        /// <summary>
        /// Denotes the palette primay alternate background brush
        /// </summary>
        public Brush PrimaryBackgroundAlt
        {
            get { return primaryBackgroundAlt; }
            set { primaryBackgroundAlt = value; }
        }

        private string displayName;
        /// <summary>
        /// denotes the name to be displayed in the UI
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

    }

    public class Themes
    {
        private string themeName;
        /// <summary>
        /// Denotes the name of the theme
        /// </summary>
        public string ThemeName
        {
            get { return themeName; }
            set { themeName = value; }
        }

        private string themeType;
        /// <summary>
        /// Denotes the Type of the theme
        /// </summary>
        public string ThemeType
        {
            get { return themeType; }
            set { themeType = value; }
        }

        private Brush ellipsefill;
        /// <summary>
        /// Denotes the color to be filled in the ellipse
        /// </summary>
        public Brush EllipseFill
        {
            get { return ellipsefill; }
            set { ellipsefill = value; }
        }

        private Brush ellipsestroke;
        /// <summary>
        /// denotes the color to be filled in the stroke of the ellipse
        /// </summary>
        public Brush EllipseStroke
        {
            get { return ellipsestroke; }
            set { ellipsestroke = value; }
        }
        private Brush pathfill;
        /// <summary>
        /// denotes the color to be applied in the path
        /// </summary>
        public Brush PathFill
        {
            get { return pathfill; }
            set { pathfill = value; }
        }

        private string displayName;
        /// <summary>
        /// denotes the name to be displayed in the UI
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
    }
}
