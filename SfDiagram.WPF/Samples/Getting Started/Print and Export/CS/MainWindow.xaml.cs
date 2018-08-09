using Microsoft.Win32;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SPath = System.Windows.Shapes.Path;

namespace Printing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        #region Private Variables

        string Extension;
        ExportSettings settings;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            //Initialize Methods
            InitializeSfDiagram();
        }

        private void InitializeSfDiagram()
        {            
            printdiagram.PrintingService.PrintManager.SelectedScaleIndex = 1;            
            printdiagram.PrintingService.PrintSettings.PageHeaderHeight = 50;
            printdiagram.PrintingService.PrintSettings.PageHeaderTemplate = this.Resources["PrintHeaderTemplate"] as DataTemplate;
        }

        #region Event Handlers
        private void InvokeSave(string p, BitmapEncoder guid)
        {
            SaveFile(Extension);
        }


        void Reg_Click(object sender, RoutedEventArgs e)
        {
            //printdiagram.PrintingService.UnregisterForPrinting();
            //printdiagram.PrintingService.RegisterForPrinting();
            printdiagram.PrintingService.ShowDialog = true;
            printdiagram.PrintingService.Print();
        }

        void b_Click(object sender, RoutedEventArgs e)
        {
            SaveFile(Extension);
        }

        //To Represent Selection Process
         void selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = (sender as ComboBox);
            if(settings==null)
            {
                settings = new ExportSettings();
            }
            if (printdiagram != null)
            {
                switch (c.Name)
                {
                    case "fileformat":

                        switch (c.SelectedIndex)
                        {
                            case 0:
                                Extension = ("PNG File(*.png)|*.png");
                                settings.ExportType = ExportType.PNG;
                                break;
                            case 1:
                                Extension = ("JPEG File(*.jpg)|*.jpg");
                                settings.ExportType = ExportType.JPEG;
                                break;
                            case 2:
                                Extension = ("TIF File(*.tif)|*.tif");
                                settings.ExportType = ExportType.TIF;
                                break;
                            case 3:
                                Extension = ("GIF File(*.gif)|*.gif");
                                settings.ExportType = ExportType.GIF;
                                break;
                            case 4:
                                Extension = ("BMP File(*.bmp)|*.bmp");
                                settings.ExportType = ExportType.BMP;
                                break;
                            case 5:
                                Extension = ("WDP File(*.wdp)|*.wdp");
                                settings.ExportType = ExportType.WDP;
                                break;
                            case 6:
                                Extension = ("XPS File(*.xps)|*.xps");
                                break;
                        }
                        break;
                }
            }
        }

        //To Represent SaveFile Dialog Box
        private void SaveFile(string filter)
        {
            SaveFileDialog m_SaveFileDialog = new SaveFileDialog();
            if ("XPS File(*.xps)|*.xps" == Extension)
            {
                settings.IsSaveToXps = true;
                settings.ExportMode = ExportMode.PageSettings;
            }
            else
            {
                settings.ExportMode = ExportMode.PageSettings;
            }
            m_SaveFileDialog.Filter = filter;
            string ext = "." + Extension.ToString();
            m_SaveFileDialog.FileName = "DiagramExport";
            string name = m_SaveFileDialog.FileName;
            m_SaveFileDialog.ShowDialog();
            var path = Path.GetExtension(m_SaveFileDialog.FileName);

            if (path != "")
            {
                using (Stream str = m_SaveFileDialog.OpenFile())
                {
                    printdiagram.ExportSettings = settings;
                    printdiagram.ExportSettings.ExportStream = str;
                    printdiagram.Export();
                }
            }
        }

        private bool IsMultiplePage()
        {
            //if (MultiplePage.IsChecked == true)
            //{
            //    return true;
            //}
            //else
            return false;

        }
        
        #endregion

        //To Represent MultiPage Loaded 
        private void MultiplePage_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox t = (sender as CheckBox);
            switch ((t.Name))
            {
                case "ShowPageBreak":
                    if (t.IsChecked == true)
                    {
                        printdiagram.PageSettings.ShowPageBreaks = true;
                    }
                    else
                    {
                        printdiagram.PageSettings.ShowPageBreaks = false;
                    }
                    break;
                case "MultiplePage":
                    if (t.IsChecked == true)
                    {
                        printdiagram.PageSettings.MultiplePage = true;
                        (printdiagram.ExportSettings as ExportSettings).ImageStretch = Stretch.None;
                    }
                    else
                    {
                        printdiagram.PageSettings.MultiplePage = false;
                        (printdiagram.ExportSettings as ExportSettings).ImageStretch = Stretch.Fill;
                    }
                    break;
            }
        }
    }

    public class AnnotationCollection : ObservableCollection<IAnnotation>
    {

    }

    public class PortCollection : ObservableCollection<INodePort>
    {

    }

    public class SegmentCollection : ObservableCollection<object>
    {

    }
}