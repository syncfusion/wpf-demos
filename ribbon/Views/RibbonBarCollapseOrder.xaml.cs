using Syncfusion.SfSkinManager;
using System.ComponentModel;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Code behind logic for RibbonBarCollapseOrder.xaml
    /// </summary>
    public partial class RibbonBarCollapseOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RibbonBarCollapseOrder"/> class.
        /// </summary>
        public RibbonBarCollapseOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method used to set the theme while initialization.
        /// </summary>
        /// <param name="themename">Represents the theme name.</param>
        public RibbonBarCollapseOrder(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        /// <summary>
        /// Method used to dispose all the controls used in this sample.
        /// </summary>
        /// <param name="e">Represents the cancel event.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            // Release all managed resources
            if (this.Resources != null)
                this.Resources.Clear();
            if (this.mainRibbon != null)
            {
                this.mainRibbon.Dispose();
                this.mainRibbon = null;
            }
            if (this.editor != null)
            {
                this.editor = null;
            }
            if(mainGrid != null)
            {
                mainGrid.Children.Clear();
                mainGrid = null;
            }
            var viewModel = this.DataContext as GettingStartedViewModel;
            if (viewModel != null)
            {
                viewModel.Dispose();
            }
            base.OnClosing(e);
        }
    }
}
