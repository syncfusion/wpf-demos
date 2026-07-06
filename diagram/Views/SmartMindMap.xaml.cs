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
    /// Interaction logic for SmartMindMap.xaml
    /// </summary>
    public partial class SmartMindMap : DemoControl
    {
        SemanticKernelAI semanticKernelOpenAI;

        public SmartMindMap()
        {
            InitializeComponent();
        }
        public SmartMindMap(string themename) : base(themename)
        {
            InitializeComponent();
            this.Diagram.Loaded += Diagram_Loaded;
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

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NodeViewModel node in this.Diagram.Nodes as NodeCollection)
            {
                if (node.Content != null && node.Content is MindmapEmployee)
                {
                    // Set Node Shape
                    node.Shape = new EllipseGeometry(new Rect(0, 0, 120, 60));

                    // Set Node ShapeStyle
                    Style shapeStyle = new Style(typeof(Path));
                    shapeStyle.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
                    string colorString = (node.Content as MindmapEmployee).Color.ToString();

                    if (!string.IsNullOrEmpty(colorString))
                    {
                        Color color = (Color)ColorConverter.ConvertFromString(colorString);
                        SolidColorBrush brush = new SolidColorBrush(color);
                        shapeStyle.Setters.Add(new Setter(Path.FillProperty, brush));
                        node.ShapeStyle = shapeStyle;
                    }

                    // Set Node Annotations
                    node.Annotations = new ObservableCollection<IAnnotation>()
                    {
                        new AnnotationEditorViewModel()
                        {
                            Content = (node.Content as MindmapEmployee).Name
                        }
                    };
                }
            }

            var layout = this.Diagram.LayoutManager.Layout as SfSmartMindMapTreeLayout;
            if (layout != null)
            {
                layout.InvalidateLayout();
                (Diagram.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter() { ZoomCommand = ZoomCommand.Zoom, ZoomTo = 0.75 });
                ((layout.LayoutRoot as INode).Info as INodeInfo).BringIntoCenter();
            }
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
                string result = await semanticKernelOpenAI.GetResponseFromAI(input, AIDiagramLayout.MindMap);

                Diagram.LayoutManager = new LayoutManager()
                {
                    Layout = new MindMapTreeLayout()
                    {
                        HorizontalSpacing = 50,
                        VerticalSpacing = 50,
                        Orientation = Orientation.Horizontal,
                        SplitMode = MindMapTreeMode.Custom
                    },
                    RefreshFrequency = RefreshFrequency.ArrangeParsing
                };

                if (!string.IsNullOrEmpty(result))
                {
                    Diagram.LoadDiagramFromMermaid(result);
                    
                    var viewModel = this.DataContext as SmartMindMapViewModel;

                    if (viewModel != null)
                    {
                        var layoutManager = Diagram.LayoutManager.Layout as MindMapTreeLayout;

                        if (layoutManager != null)
                        {
                            // Applying colors for node
                            var layoutRootNode = layoutManager.LayoutRoot as NodeViewModel;
                            if (layoutRootNode != null)
                            {
                                viewModel.SetNodeColors(layoutRootNode);
                            }
                            var layoutRootINode = layoutManager.LayoutRoot as INode;
                            if (layoutRootINode != null)
                            {
                                var nodeInfo = layoutRootINode.Info as INodeInfo;
                                if (nodeInfo != null)
                                {
                                    nodeInfo.BringIntoCenter();
                                }
                            }
                        }
                    }
                    
                    (Diagram.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter() { ZoomCommand = ZoomCommand.Zoom, ZoomTo = 0.75 });
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
