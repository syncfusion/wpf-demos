using System.Windows.Controls;
using System.Windows;

namespace TabControlExtConfigurationDemo
{
    /// <summary>
    /// Interaction logic for PropertyView.xaml
    /// </summary>
    public partial class PropertyView : UserControl
    {
        public PropertyView()
        {
            InitializeComponent();            
        }
        private void SelectionChange(object sender,SelectionChangedEventArgs e)
        {
            if (Combo.SelectedItem != null)
            {
                if (Combo.SelectedItem.ToString() == "Top" || Combo.SelectedItem.ToString() == "Bottom")
                {
                    Check.Visibility = Visibility.Collapsed;
                    Text.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Check.Visibility = Visibility.Visible;
                    Text.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
