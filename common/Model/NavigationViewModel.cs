namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Represents the view model for a single item in a navigation menu. It typically holds display information like a label and an icon.
    /// </summary>
    public class NavigationViewModel
    {
        private string navigationItem;
        private object navigationIcon;

        /// <summary>
        /// Gets or set the NavigationItem Text
        /// </summary>
        public string NavigationItem
        {
            get { return navigationItem; }
            set { navigationItem = value; }
        }

        /// <summary>
        /// Gets or set the NavigationItem Icon
        /// </summary>
        public object NavigationIcon
        {
            get { return navigationIcon; }
            set { navigationIcon = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationViewModel"/> class.
        /// </summary>
        public NavigationViewModel()
        {

        }
    }
}
