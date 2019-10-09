#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Quick_Command
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        QuickCommandViewModel quick1;
        ICommand EnableOptionsCommand = null;
        SolidColorBrush backgroundcolorchange = new SolidColorBrush(Colors.Goldenrod);
        SolidColorBrush bordercolorchange = new SolidColorBrush(Colors.Black);
        double borderthicknesschange = 1;
        public MainWindow()
        {
            InitializeComponent();
            (diagramcontrol.Info as IGraphInfo).ItemUnSelectedEvent += Diagram_ItemUnSelectedEvent;
            (diagramcontrol.Info as IGraphInfo).ItemSelectedEvent += Diagram_ItemSelectedEvent;
            EnableOptionsCommand = new Command(c => EnableOptionsCommandClick());
            quick1 = AddQuickCommand();
            (diagramcontrol.SelectedItems as SelectorViewModel).Commands = new ObservableCollection<QuickCommandViewModel>()
            {
                    quick1,
            };
        }

        private void Diagram_ItemUnSelectedEvent(object sender, DiagramEventArgs args)
        {
            PropertyBorder.Visibility = Visibility.Collapsed;
        }
        private void Diagram_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            PropertyBorder.Visibility = Visibility.Visible;
        }

        private void EnableOptionsCommandClick()
        {
            PropertyBorder.Visibility = Visibility.Visible;
        }
        private QuickCommandViewModel AddQuickCommand()
        {
            QuickCommandViewModel quick = new QuickCommandViewModel();
            quick.Shape = "F1M23.467,11.733C23.467,18.213 18.214,23.466 11.734,23.466 5.253,23.466 0,18.213 0,11.733 0,5.253 5.253,0 11.734,0 18.214,0 23.467,5.253 23.467,11.733";
            quick.ContentTemplate = this.Resources["Template"] as DataTemplate;
            quick.Command = EnableOptionsCommand;
            quick.ShapeStyle = App.Current.Resources["QuickCommandShapestyle"] as Style;
            quick.OffsetX = 1;
            quick.OffsetY = 1;
            quick.HorizontalAlignment = HorizontalAlignment.Left;
            quick.VerticalAlignment = VerticalAlignment.Top;
            quick.Margin = new Thickness(10);
            quick.CommandParameter = null;
            quick.VisibilityMode = VisibilityMode.Node | VisibilityMode.Connector;
            ((diagramcontrol.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).Add(quick);
            return quick;
        }
        private void positionchanged_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (quick1 != null)
            {
                Syncfusion.Windows.Tools.Controls.ComboBoxAdv cb = sender as Syncfusion.Windows.Tools.Controls.ComboBoxAdv;
                switch (cb.SelectedIndex)
                {
                    case 0:
                        quick1.VerticalAlignment = VerticalAlignment.Top;
                        quick1.HorizontalAlignment = HorizontalAlignment.Left;
                        break;
                    case 1:
                        quick1.VerticalAlignment = VerticalAlignment.Top;
                        quick1.HorizontalAlignment = HorizontalAlignment.Center;
                        break;
                    case 2:
                        quick1.VerticalAlignment = VerticalAlignment.Top;
                        quick1.HorizontalAlignment = HorizontalAlignment.Right;
                        break;
                    case 3:
                        quick1.VerticalAlignment = VerticalAlignment.Center;
                        quick1.HorizontalAlignment = HorizontalAlignment.Left;
                        break;
                    case 4:
                        quick1.VerticalAlignment = VerticalAlignment.Center;
                        quick1.HorizontalAlignment = HorizontalAlignment.Center;
                        break;
                    case 5:
                        quick1.VerticalAlignment = VerticalAlignment.Center;
                        quick1.HorizontalAlignment = HorizontalAlignment.Right;
                        break;
                    case 6:
                        quick1.VerticalAlignment = VerticalAlignment.Bottom;
                        quick1.HorizontalAlignment = HorizontalAlignment.Left;
                        break;
                    case 7:
                        quick1.VerticalAlignment = VerticalAlignment.Bottom;
                        quick1.HorizontalAlignment = HorizontalAlignment.Center;
                        break;
                    case 8:
                        quick1.VerticalAlignment = VerticalAlignment.Bottom;
                        quick1.HorizontalAlignment = HorizontalAlignment.Right;
                        break;
                }
            }
        }
        private void backgroundcolourchanged_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (quick1 != null)
            {
                Syncfusion.Windows.Tools.Controls.ComboBoxItemAdv cb = (Syncfusion.Windows.Tools.Controls.ComboBoxItemAdv)backgroundcolourchanged.SelectedItem;
                string backgroundcolor = (((cb.Content as StackPanel).Children[0] as System.Windows.Shapes.Rectangle).Fill as SolidColorBrush).Color.ToString();
                update(backgroundcolor, "BackGround");
            }
        }
        private void bordercolorchanged_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (quick1 != null)
            {
                Syncfusion.Windows.Tools.Controls.ComboBoxItemAdv cb = (Syncfusion.Windows.Tools.Controls.ComboBoxItemAdv)bordercolorchanged.SelectedItem;
                string bordercolor = (((cb.Content as StackPanel).Children[0] as System.Windows.Shapes.Rectangle).Fill as SolidColorBrush).Color.ToString();
                update(bordercolor, "Border");
            }
        }
        private void update(string str1, string str2)
        {
            quick1.ShapeStyle = GetColor(str1, str2);
        }
        private Style GetColor(string source, string source1)
        {
            if (source1 == "BackGround" || source1 == "Border")
            {
                string hex = source;
                //strip out any # if they exist
                Color color = (Color)ColorConverter.ConvertFromString(hex);
                if (source1 == "BackGround")
                    backgroundcolorchange = new SolidColorBrush(color);
                else if (source1 == "Border")
                    bordercolorchange = new SolidColorBrush(color);
            }
            if (source1 == "BorderThickness")
            {
                borderthicknesschange = Convert.ToDouble(source);
            }
            Style sty = new Style(typeof(System.Windows.Shapes.Path));
            if (source1 == "BackGround")
            {
                sty.Setters.Add(new Setter() { Property = Shape.FillProperty, Value = backgroundcolorchange });
                sty.Setters.Add(new Setter() { Property = Shape.StrokeProperty, Value = bordercolorchange });
                sty.Setters.Add(new Setter() { Property = Shape.StrokeThicknessProperty, Value = borderthicknesschange });
            }
            if (source1 == "Border")
            {
                sty.Setters.Add(new Setter() { Property = Shape.FillProperty, Value = backgroundcolorchange });
                sty.Setters.Add(new Setter() { Property = Shape.StrokeProperty, Value = bordercolorchange });
                sty.Setters.Add(new Setter() { Property = Shape.StrokeThicknessProperty, Value = borderthicknesschange });
            }
            if (source1 == "BorderThickness")
            {
                sty.Setters.Add(new Setter() { Property = Shape.FillProperty, Value = backgroundcolorchange });
                sty.Setters.Add(new Setter() { Property = Shape.StrokeProperty, Value = bordercolorchange });
                sty.Setters.Add(new Setter() { Property = Shape.StrokeThicknessProperty, Value = borderthicknesschange });
            }
            return sty;
        }
        private void shapechanged_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (quick1 != null)
            {
                Syncfusion.Windows.Tools.Controls.ComboBoxAdv cb = sender as Syncfusion.Windows.Tools.Controls.ComboBoxAdv;
                switch (cb.SelectedIndex)
                {
                    case 0:
                        quick1.ContentTemplate = this.Resources["Template"] as DataTemplate;
                        break;
                    case 1:
                        quick1.Content = "M13.671994,14.169995 L1.0569996,14.169995 1.0569996,3.6649869 1.8049993,3.6649869 1.8049993,2.609986 0,2.609986 0,15.224996 14.724994,15.224996 14.724994,13.377994 13.671994,13.377994 z M2.6349954,12.613986 L17.358003,12.613986 17.358003,1.323489E-23 2.6349954,1.323489E-23 z";
                        quick1.ContentTemplate = this.Resources["Path"] as DataTemplate;
                        break;
                }
            }
        }
        private void pathcolourchanged_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void borderthicknesschanged_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (quick1 != null)
            {
                string strokethickness = (d as Syncfusion.Windows.Shared.UpDown).Value.Value.ToString();
                update(strokethickness, "BorderThickness");
            }
        }
        private void sizechanged_TextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
    }
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Func<object, bool> canExecute;
        Action<object> executeAction;
        bool canExecuteCache;

        public Command(Action<object> executeAction,
                               Func<object, bool> canExecute = null)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;

        }

        #region ICommand Members        
        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            bool tempCanExecute = canExecute(parameter);

            if (canExecuteCache != tempCanExecute)
            {
                canExecuteCache = tempCanExecute;
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, new EventArgs());
                }
            }

            return canExecuteCache;
        }

        public void Execute(object parameter)
        {
            if (executeAction != null)
            {
                executeAction(parameter);
            }
        }
        #endregion
    }
    #region CustomClasses
    public class AnnotationCollection : ObservableCollection<IAnnotation>
    {

    }


    //Custom NodeViewModel with new properties   
    #endregion
    public class SegmentPoint : ObservableCollection<IConnectorSegment>
    {

    }
}
