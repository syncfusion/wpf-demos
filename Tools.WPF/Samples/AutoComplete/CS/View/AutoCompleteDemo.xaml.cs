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
using System.Reflection;
using Syncfusion.Windows.Controls.Input;
using System.Windows.Threading;

namespace SfAutoCompleteDemo
{
    /// <summary>
    /// Interaction logic for AutoCompleteDemo.xaml
    /// </summary>
    public partial class AutoCompleteDemo : UserControl
    {
        public AutoCompleteDemo()
        {
            InitializeComponent();
        }

         private Assembly assembly;
      
        private  void autoCompleteMode_Loaded_1(object sender, RoutedEventArgs e)
        {
            ((ComboBox)sender).ItemsSource = Enum.GetValues(typeof(AutoCompleteMode));
            ((ComboBox)sender).SelectedIndex = 2;


            //string assemblyName = "Syncfusion.SfInput.Wpf.dll";
            assembly = Assembly.GetAssembly(typeof(SfTextBoxExt));

            var list = new List<Field>();
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (type.Name.StartsWith("Sf") && type.Namespace == "Syncfusion.Windows.Controls.Input")
                {
                    var item = new Field();
                    item.Name = type.Name;
                    item.Icon = "/Assets/Images/type.png";
                    list.Add(item);
                }
            }
            types.AutoCompleteSource = list;

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                var items = new List<string>();
                for (int i = 0; i < 100000; i++)
                {
                    items.Add("Item No " + i.ToString());
                }
                performance.AutoCompleteSource = items;
            }));
        }          
      
        private void Types_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var list = new List<Field>();
            Type seltype = null;
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (type.Name == types.Text)
                {
                    seltype = type;
                    break;
                }
            }

            if (seltype != null)
            {
                foreach (var field in seltype.GetProperties())
                {
                    var item = new Field();
                    item.Name = field.Name;
                    item.Icon = "/Assets/Images/property.png";
                    list.Add(item);
                }

                foreach (var field in seltype.GetMethods())
                {
                    if (field.Name.Contains("_"))
                        continue;
                    var item = new Field();
                    item.Name = field.Name;
                    item.Icon = "/Assets/Images/method.png";
                    list.Add(item);
                }

                foreach (var field in seltype.GetEvents())
                {
                    var item = new Field();
                    item.Name = field.Name;
                    item.Icon = "/Assets/Images/event.png";
                    list.Add(item);
                }

                fields.AutoCompleteSource = list;
            }
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            var control = sender as TextBlock;
            string text = fields.Text;
            int index = control.Text.IndexOf(text, StringComparison.OrdinalIgnoreCase);

            if (index >= 0)
            {
                var run1 = new Run() { Text = control.Text.Substring(0, index) };
                var run2 = new Run()
                {
                    Text = control.Text.Substring(index, text.Length),
                    Foreground = (SolidColorBrush)this.Resources["brush"]
                };
                var run3 = new Run() { Text = control.Text.Substring(index + text.Length) };

                control.Inlines.Clear();
                control.Inlines.Add(run1);
                control.Inlines.Add(run2);
                control.Inlines.Add(run3);
            }
        }

        private void FrameworkElement_OnLoaded1(object sender, RoutedEventArgs e)
        {
            var control = sender as TextBlock;
            string text = types.Text;
            int index = control.Text.IndexOf(text, StringComparison.OrdinalIgnoreCase);

            if (index >= 0)
            {
                var run1 = new Run() { Text = control.Text.Substring(0, index) };
                var run2 = new Run()
                {
                    Text = control.Text.Substring(index, text.Length),
                    Foreground = (SolidColorBrush)this.Resources["brush"],
                };
                var run3 = new Run() { Text = control.Text.Substring(index + text.Length) };

                control.Inlines.Clear();
                control.Inlines.Add(run1);
                control.Inlines.Add(run2);
                control.Inlines.Add(run3);
            }
        }
    }

    public class Field
    {
        public string Name { get; set; }

        public string Icon { get; set; }
    }
    
}
