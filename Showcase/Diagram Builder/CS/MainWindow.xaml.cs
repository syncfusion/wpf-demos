#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DiagramBuilder.ViewModel;
using System.Windows.Input;
using DiagramBuilder.Utility;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;

namespace DiagramBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding exitBinding = new Binding();
            exitBinding.Path = new PropertyPath("Exit");
            exitBinding.Mode = BindingMode.TwoWay;
            SetBinding(ExitProperty, exitBinding);
            Binding ZoomInBinding = new Binding();
            ZoomInBinding.Path = new PropertyPath("ZoomIn");
            SetBinding(ZoomInProperty, ZoomInBinding);
            Binding ZoomOutBinding = new Binding();
            ZoomOutBinding.Path = new PropertyPath("ZoomOut");
            SetBinding(ZoomOutProperty, ZoomOutBinding);
            Exit = new Command(OnExitCommand);
            ZoomIn = new Command(OnZoomInCommand);
            ZoomOut = new Command(OnZoomOutCommand);

            SkinStorage.SetVisualStyle(this,"Office2013");

            //SfSkinManager.SetVisualStyle(this, VisualStyles.Office2013White);
            //SfSkinManager.ApplyStylesOnApplication = true;
            //ChangeTheme("Metro");
        }


        private void ChangeTheme(string p)
        {
            ResourceDictionary dict = new ResourceDictionary();
            ResourceDictionary dict1 = new ResourceDictionary();
            Application.Current.Resources.MergedDictionaries.Clear();
            if (p.Equals("Default"))
            {
                dict.Source = new Uri("/Syncfusion.SfDiagram.WPF;Component/Themes/Generic.xaml", UriKind.Relative);
                dict1.Source = new Uri("/Syncfusion.SfDiagram.WPF;Component/Themes/WpfSlResource.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Add(dict);
                Application.Current.Resources.MergedDictionaries.Add(dict1);
            }
            else
            {
                string x = "/Syncfusion.Themes." + p + ".WPF;component/SfDiagram/SfDiagram.xaml";
                dict.Source = new Uri(x, UriKind.Relative);
                //Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
        }
        public ICommand Exit
        {
            get { return (ICommand)GetValue(ExitProperty); }
            set { SetValue(ExitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Exit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExitProperty =
            DependencyProperty.Register("Exit", typeof(ICommand), typeof(MainWindow), new PropertyMetadata(null));

        public ICommand ZoomOut
        {
            get { return (ICommand)GetValue(ZoomOutProperty); }
            set { SetValue(ZoomOutProperty, value); }
        }

        public static readonly DependencyProperty ZoomOutProperty =
           DependencyProperty.Register("ZoomOut", typeof(ICommand), typeof(MainWindow), new PropertyMetadata(null));

        public ICommand ZoomIn
        {
            get { return (ICommand)GetValue(ZoomInProperty); }
            set { SetValue(ZoomInProperty, value); }
        }

        public static readonly DependencyProperty ZoomInProperty =
           DependencyProperty.Register("ZoomIn", typeof(ICommand), typeof(MainWindow), new PropertyMetadata(null));

        public async void OnExitCommand(object param)
        {
            IDiagramBuilderVM viewModel = this.DataContext as IDiagramBuilderVM;
            await viewModel.PrepareExit();
            Exit = null;
            //Frame.GoBack();
        }
        public void OnZoomInCommand(object param)
        {
            IDiagramBuilderVM vm = this.DataContext as IDiagramBuilderVM;
            vm.ZoomIn.Execute(null);

        }
        public void OnZoomOutCommand(object param)
        {
            IDiagramBuilderVM vm = this.DataContext as IDiagramBuilderVM;
            vm.ZoomOut.Execute(null);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool _isopen=true;
        public bool Isopen
        {
            get { return _isopen; }
            set 
            {
                if (_isopen !=value)
                {
                    _isopen = value;
                }
           
            }

        }
      
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Isopen)
            {
                View.ZoomPanWindow n = new View.ZoomPanWindow();
                n.DataContext = this;
                n.Show();
                Isopen = false;
            }
        }

        
      
        private void HideBackstage_Click(object sender, RoutedEventArgs e)
        {
            ribbon.HideBackStage();
        }
    }

    public class AppBar : ContentControl
    {
        public AppBar()
        {
            
        }
    }

    public class CustomPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in Children)
                child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            return new Size(0, 0);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double remainingSpace = Math.Max(0.0, finalSize.Height - Children.Cast<UIElement>().Sum(c => c.DesiredSize.Height));
            var extraSpace = remainingSpace / Children.Count;
            double offset = 0.0;

            foreach (UIElement child in Children)
            {
                double height = child.DesiredSize.Height + extraSpace;
                child.Arrange(new Rect(0, offset, finalSize.Width, height));
                offset += height;
            }

            return finalSize;
        }

    }
}
