using System.Windows;
using System.Windows.Controls;

namespace PropertyGridConfigurationDemo
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



        public object Selectedobject
        {
            get { return (object)GetValue(SelectedobjectProperty); }
            set { SetValue(SelectedobjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selectedobject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedobjectProperty =
            DependencyProperty.Register("Selectedobject", typeof(object), typeof(PropertyView), new PropertyMetadata(null));

        private void selobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selectedobject = e.AddedItems[0];
        }
        
    }
}
