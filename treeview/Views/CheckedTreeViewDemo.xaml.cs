using System.Windows;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;

namespace syncfusion.treeviewdemos.wpf
{
    /// <summary>
    /// Interaction logic for CheckedTreeViewDemo.xaml
    /// </summary>
    public partial class CheckedTreeViewDemo : DemoControl
    {
        #region Constructor

        public CheckedTreeViewDemo()
        {
            InitializeComponent();
        }
		
		public CheckedTreeViewDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
		
        #endregion

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.treeView != null)
            {
                this.treeView.Dispose();
                this.treeView = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.listView != null)
                this.listView = null;

            if (this.label != null)
                this.label = null;

            base.Dispose(disposing);
        }
    }
}
