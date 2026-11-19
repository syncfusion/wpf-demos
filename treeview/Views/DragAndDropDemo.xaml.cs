using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Tools;
using syncfusion.demoscommon.wpf;

namespace syncfusion.treeviewdemos.wpf
{
    /// <summary>
    /// Interaction logic for DragAndDropDemo.xaml
    /// </summary>
    public partial class DragAndDropDemo : DemoControl
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DragAndDropDemo"/> class.
        /// </summary>
        public DragAndDropDemo()
        {
            InitializeComponent();
        }
		
		public DragAndDropDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
		
        #endregion

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();
            // Release all managed resources
            if (sfTreeView1 != null)
            {
                this.sfTreeView1.Dispose();
                this.sfTreeView1 = null;
            }
            if (sfTreeView2 != null)
            {
                this.sfTreeView2.Dispose();
                this.sfTreeView2 = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;
            
            base.Dispose(disposing);
        }
    }
}
