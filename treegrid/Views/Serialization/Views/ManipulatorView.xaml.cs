using System.Windows;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for ManipulatorView.xaml
    /// </summary>
    public partial class ManipulatorView : Window
    {
        public static ManipulatorView manipulatorView;
        public ManipulatorView()
        {
            InitializeComponent();
            manipulatorView = this;
        }
    }
}
