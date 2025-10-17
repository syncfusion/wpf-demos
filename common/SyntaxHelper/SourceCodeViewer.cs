using syncfusion.demoscommon.wpf;
using System.IO;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace syncfusion.demoscommon.wpf
{
    //Codesnippet viewer
    public class SourceCodeViewer : FlowDocumentScrollViewer
    {
     
        /// <summary>
        /// Gets or sets the file path to show the code snippets. 
        /// </summary>
        public string FilePath 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// initializes the instances of a <see cref="SyntaxViewer"/>
        /// </summary>
        public SourceCodeViewer()
        {
            this.Loaded += SyntaxViewer_Loaded;
        }

        private void SyntaxViewer_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (FilePath != null && File.Exists(FilePath))
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(() =>
                {
                    FileInfo fi = new FileInfo(FilePath);
                    var reader = new StreamReader(FilePath);
                    string text = reader.ReadToEnd();
                    Paragraph para= null;
                    if (fi != null)
                    {                        
                        if (fi.Extension== ".cs")
                        {
                            para = new SyntaxHighlighterCSharp().FormatCode(text);
                        }
                        else
                        {
                            para = SyntaxHighlighterXAML.FormatCode(text);
                        }
                    }
                    
                    var document = new FlowDocument();
                    document.Blocks.Clear();
                    document.Blocks.Add(para);
                    this.Document = document;
                }));              
            }
        }
    }
}
