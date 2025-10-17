namespace syncfusion.demoscommon.wpf
{
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

        public NavigationViewModel()
        {

        }
    }
}
