using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for SourceCodeViewRwader.xaml
    /// </summary>
    public partial class SourceCodeTabView: UserControl
    {
        public SourceCodeTabView()
        {
            InitializeComponent();
        }

        public string XamlSource
        {
            get { return (string)GetValue(XamlSourceProperty); }
            set { SetValue(XamlSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XamlSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XamlSourceProperty =
            DependencyProperty.Register("XamlSource", typeof(string), typeof(SourceCodeTabView), new PropertyMetadata(null));

        public string CSharapSource
        {
            get { return (string)GetValue(CSharapSourceProperty); }
            set { SetValue(CSharapSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XamlSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CSharapSourceProperty =
            DependencyProperty.Register("CSharapSource", typeof(string), typeof(SourceCodeTabView), new PropertyMetadata(null));



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (XamlSource != null && File.Exists(XamlSource))
            {
                FlowDocumentScrollViewer scrollReader = new FlowDocumentScrollViewer();

                Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(() =>
                {
                    var reader = new StreamReader(XamlSource);
                    string text = reader.ReadToEnd();
                    Paragraph para = para = SyntaxHighlighterXAML.FormatCode(text);
                    var document = new FlowDocument();
                    document.Blocks.Clear();
                    document.Blocks.Add(para);
                    scrollReader.Document = document;

                }));

                (SourceCodeViewTabControl.Items[0] as TabItem).Content = scrollReader;
            }

            if (CSharapSource != null && File.Exists(CSharapSource))
            {
                FlowDocumentScrollViewer scrollReader = new FlowDocumentScrollViewer();

                Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(() =>
                {
                    var reader = new StreamReader(CSharapSource);
                    string text = reader.ReadToEnd();
                    Paragraph para = para = new SyntaxHighlighterCSharp().FormatCode(text); ;
                    var document = new FlowDocument();
                    document.Blocks.Clear();
                    document.Blocks.Add(para);
                    scrollReader.Document = document;

                }));

                (SourceCodeViewTabControl.Items[1] as TabItem).Content = scrollReader;
            }

            if(CSharapSource == null || !File.Exists(CSharapSource))
            {
                (SourceCodeViewTabControl.Items[1] as TabItem).Visibility = Visibility.Collapsed;
            }

            if(XamlSource == null || !File.Exists(XamlSource))
            {
                (SourceCodeViewTabControl.Items[0] as TabItem).Visibility = Visibility.Collapsed;
            }
        }
    }
}
