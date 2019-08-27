#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using Syncfusion.Windows.Shared;
using System.Diagnostics;

namespace RichTextBoxAdvSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if Framework4_0
            //Enables touch manipulation.
            rte.IsManipulationEnabled = true;
#endif
            rte.FileOpening += (sender, e) =>
                {
                    rte.Document = DocxImporting.ConvertToDocumentAdv(e.DocumentStream, e.FormatType);
                    PageCount = rte.Viewer.Pages.Count;
                };

            rte.FileSaving += (sender, e) =>
                {
                    DocxExporting.ConvertToDocument(rte.Document, e.DoucmentStream, e.FormatType);
                };

            rte.Loaded += (sender, e) =>
                {
                    PageCount = rte.Viewer.Pages.Count;
                };
            rte.LayoutUpdated += (sender, e) =>
                {
                    PageCount = rte.Viewer.Pages.Count;
                };
            rte.OpenFailed += rte_OpenFailed;
            rte.SaveFailed += rte_SaveFailed;
            rte.RequestNavigate += rte_RequestNavigate;
            DataContext = rte;
            pagecount.DataContext = this;
            SkinStorage.SetVisualStyle(this, "Office2013");
        }

        void rte_RequestNavigate(object obj, Syncfusion.Windows.Tools.Controls.RequestNavigateEventArgs args)
        {
            if (args.Hyperlink.NavigationUrl != null && Uri.IsWellFormedUriString(args.Hyperlink.NavigationUrl, UriKind.RelativeOrAbsolute))
            {
                System.Diagnostics.Process.Start(args.Hyperlink.NavigationUrl);
            }
        }
        

        void rte_SaveFailed(object obj, SaveFailedEventArgs args)
        {
            MessageBox.Show(args.Exception.Message, args.Message, MessageBoxButton.OK);
        }

        void rte_OpenFailed(object obj, OpenFailedEventArgs args)
        {
            MessageBox.Show(args.Exception.Message, args.Message, MessageBoxButton.OK);
        }


        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(int), typeof(MainWindow), new PropertyMetadata(0));



    }
    public class ZoomFactorInPercentage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double factor = Math.Round(System.Convert.ToDouble(value), 2);
            if (factor == 0)
            {
                factor = 0.1;
            }
            return (int)(factor * 100 * 4);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RunAdv : Run
    {
        public RunAdv()
        {

        }

        public string RunText
        {
            get { return (string)GetValue(RunTextProperty); }
            set { SetValue(RunTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RunText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RunTextProperty =
            DependencyProperty.Register("RunText", typeof(string), typeof(RunAdv), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnRunTextChanged)));

        private static void OnRunTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RunAdv runadv = d as RunAdv;
            runadv.OnRunTextChanged(e);
        }

        private void OnRunTextChanged(DependencyPropertyChangedEventArgs e)
        {
            base.Text = (string)e.NewValue;
        }
    }
}
