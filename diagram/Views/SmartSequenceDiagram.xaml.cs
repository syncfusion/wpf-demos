using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Model;
using syncfusion.diagramdemo.wpf.ViewModel;
using syncfusion.diagramdemos.wpf.Views;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.Windows.Controls.Notification;
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

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for SmartSequenceDiagram.xaml
    /// </summary>
    public partial class SmartSequenceDiagram : DemoControl
    {
        SemanticKernelAI semanticKernelOpenAI;

        public SmartSequenceDiagram()
        {
            InitializeComponent();
        }
        public SmartSequenceDiagram(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new SmartSequenceDiagramViewModel();
            Diagram.Loaded += DiagramControl_Loaded;
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });

            // Validate the AI credentials
            if (!AISettings.IsCredentialValid)
            {
                AISettings.ShowAISettingsWindow();
            }

            // Initialize the Semantic Kernel AI
            if (AISettings.IsCredentialValid)
            {
                semanticKernelOpenAI = new SemanticKernelAI(AISettings.Key, AISettings.EndPoint, AISettings.ModelName);
                AIAssistBtn.IsEnabled = true;
            }
            else
            {
                AIAssistBtn.IsEnabled = false;
                semanticKernelOpenAI = null;
            }
        }

        private void DiagramControl_Loaded(object sender, RoutedEventArgs e)
        {
            (Diagram.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToPage, Margin = new Thickness(10) });
        }

        private void TextBox_PreviewMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void AIAssistBtn_Click(object sender, RoutedEventArgs e)
        {
            AIAssistPopup.IsOpen = true;
            popupTextBox.Focus();
        }
        private void popupTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                GenerateDiagram_Clicked(sender, e);
                e.Handled = true;
            }
        }
        private void popupTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (popupTextBox.Text.Length > 0)
            {
                generateDiagramButton.IsEnabled = true;
            }
            else
            {
                generateDiagramButton.IsEnabled = false;
            }
        }

        private async void GenerateDiagram_Clicked(object sender, RoutedEventArgs e)
        {
            AIAssistPopup.IsOpen = false;

            Button button = e.Source as Button;
            TextBox textBox = e.Source as TextBox;

            sfBusyIndicator.Visibility = Visibility.Visible;

            try
            {
                if (button != null && (button.Content is Viewbox) && !string.IsNullOrEmpty(popupTextBox.Text))
                {
                    await LoadDiagram(popupTextBox.Text);
                }
                if (button != null && !(button.Content is Viewbox) && !string.IsNullOrEmpty(button.Content.ToString()))
                {
                    await LoadDiagram(button.Content.ToString());
                }
                else if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
                {
                    await LoadDiagram(textBox.Text);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                sfBusyIndicator.Visibility = Visibility.Hidden;
                popupTextBox.Text = string.Empty;
            }
        }


        private async Task LoadDiagram(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                string result = await semanticKernelOpenAI.GetResponseFromAI(input, AIDiagramLayout.SequenceDiagram);

                if (!string.IsNullOrEmpty(result))
                {
                    Diagram.LoadDiagramFromMermaid(result);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.Diagram != null)
            {
                this.Diagram = null;
            }
            base.Dispose(disposing);
        }
    }
}
