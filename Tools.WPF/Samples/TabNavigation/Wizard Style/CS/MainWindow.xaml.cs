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
using Syncfusion.Windows.Tools.Controls;

namespace WizardDemo_2010
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var Items = GetEnumValues();
            effectCombo.ItemsSource = Items;         
            effectCombo.SelectedIndex = 0;
        }
       
        public static TransitionEffects[] GetEnumValues()
        {
            var type = typeof(TransitionEffects);
            return (from field in type.GetFields()
                    where field.IsLiteral
                    select (TransitionEffects)field.GetValue(type)).ToArray();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void previousCommand_Click(object sender, RoutedEventArgs e)
        {
            license.IsChecked = true;
        }
    }
}
