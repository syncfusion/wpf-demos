using System.Windows.Controls;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for AllComponentsPage.xaml
    /// </summary>
    public partial class AllComponentsPage : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllComponentsPage"/> class.
        /// </summary>
        public AllComponentsPage()
        {
            InitializeComponent();
            listView.GroupStyle.Add(this.Resources["ListViewGroupStyle"] as GroupStyle);
        }
    }
}
