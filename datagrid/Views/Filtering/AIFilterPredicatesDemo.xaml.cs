using syncfusion.demoscommon.wpf;
using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for AIFilterPredicatesDemo.xaml
    /// </summary>
    public partial class AIFilterPredicatesDemo : DemoControl
    {
        public AIFilterPredicatesDemo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Releases the resources used by the <see cref="AIViewFilterDemo"/> class, including both managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.dataGrid != null)
            {
                this.dataGrid.Dispose();
                this.dataGrid = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as EmployeeInfoViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

            if (this.busyIndicator != null)
            {
                this.busyIndicator.Dispose();
                this.busyIndicator = null;
            }

            if (this.executePromptButton != null)
                this.executePromptButton = null;

            if (this.resetButton != null)
                this.resetButton = null;

            if (this.queryTextBox != null)
                this.queryTextBox = null;

            base.Dispose(disposing);
        }
    }
}
