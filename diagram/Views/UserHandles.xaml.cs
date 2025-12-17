using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
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

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for UserHandles.xaml
    /// </summary>
    public partial class UserHandles : DemoControl
    {
        public UserHandles()
        {          
            InitializeComponent();
        }

        public UserHandles(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.DiagramControl != null)
            {
                this.DiagramControl = null;
            }
            base.Dispose(disposing);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem position = comboBox.SelectedItem as ComboBoxItem;
            QuickCommandViewModel quickCommand = ((DiagramControl.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection)[0];
            if (position.Content.ToString() == "Top")
            {
                quickCommand.OffsetY = 0;
                quickCommand.OffsetX = 0.5;
                quickCommand.Margin = new Thickness(0, 0, 0, 25);
            }

            else if (position.Content.ToString() == "Left")
            {
                quickCommand.OffsetY = 0.5;
                quickCommand.OffsetX = 0;
                quickCommand.Margin = new Thickness(0, 0, 25, 0);
            }

            else if (position.Content.ToString() == "Right")
            {
                quickCommand.OffsetY = 0.5;
                quickCommand.OffsetX = 1;
                quickCommand.Margin = new Thickness(25, 0, 0, 0);
            }

            else if (position.Content.ToString() == "Bottom")
            {
                quickCommand.OffsetY = 1;
                quickCommand.OffsetX = 0.5;
                quickCommand.Margin = new Thickness(0, 25, 0, 0);
            }

            else if (position.Content.ToString() == "Bottom Right")
            {
                quickCommand.OffsetY = 1;
                quickCommand.OffsetX = 1;
                quickCommand.Margin = new Thickness(20, 20, 0, 0);
            }

            else if (position.Content.ToString() == "Bottom Left")
            {
                quickCommand.OffsetY = 1;
                quickCommand.OffsetX = 0;
                quickCommand.Margin = new Thickness(0, 20, 20, 0);
            }

            else if (position.Content.ToString() == "Top Right")
            {
                quickCommand.OffsetY = 0;
                quickCommand.OffsetX = 1;
                quickCommand.Margin = new Thickness(20, 0, 0, 20);
            }

            else if (position.Content.ToString() == "Top Left")
            {
                quickCommand.OffsetY = 0;
                quickCommand.OffsetX = 0;
                quickCommand.Margin = new Thickness(0, 0, 20, 20);
            }
        }
    }
}
