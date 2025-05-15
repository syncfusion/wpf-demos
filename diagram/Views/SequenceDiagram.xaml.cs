#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
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
    /// Interaction logic for SequenceDiagram.xaml
    /// </summary>
    public partial class SequenceDiagram : DemoControl
    {
        public SequenceDiagram()
        {
            InitializeComponent();
        }

        public SequenceDiagram(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new SequenceDiagramViewModel();
            DiagramControl.Loaded += DiagramControl_Loaded;
        }

        private void DiagramControl_Loaded(object sender, RoutedEventArgs e)
        {
            var nodes = DiagramControl.Nodes as NodeCollection;
            var connectors = DiagramControl.Connectors as ConnectorCollection;

            if (nodes == null) return;

            foreach(var node in nodes)
            {
                if (node.Annotations != null)
                {
                    // if node is a fragment, then update all of its annotations
                    if (node.Annotations != null && node.Name.Contains("Fragment"))
                    {
                        var annotations = (node.Annotations as AnnotationCollection)
                                            .Where(anno => anno != null)
                                            .ToList();
                        for (int i = 0; i < annotations.Count; i++)
                        {
                            annotations[i].FontSize = 14;
                            if (i == 0)
                            {
                                annotations[i].Margin = new Thickness(5, -1, 5, 5);
                                annotations[i].Foreground = new SolidColorBrush(Colors.White);
                            }
                            else
                            {
                                annotations[i].Background = new SolidColorBrush(Colors.White);
                            }
                        }
                    }
                    else if (node.Annotations != null)
                    {
                        // if node is a participant then update annotations
                        if (node.Annotations != null && !node.Name.Contains("Fragment"))
                        {
                            var resourceDictionary = new ResourceDictionary
                            {
                                Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
                            };

                            var annotation = (node.Annotations as AnnotationCollection).FirstOrDefault();

                            if (annotation != null) 
                                annotation.FontSize = 18;

                            bool isActor = node.Shape.ToString() == resourceDictionary["User"].ToString();

                            // if participant is of rectangular shape, update node width according to annotation length
                            if (!isActor && annotation != null && annotation is TextAnnotationViewModel)
                            {
                                annotation.Foreground = new SolidColorBrush(Colors.White);
                                UpdateNodeWidth((NodeViewModel)node, (annotation as TextAnnotationViewModel).Text.ToString());
                            }
                            else
                            {
                                if (annotation != null)
                                    annotation.FontSize = 14;
                            }
                        }
                    }

                }
            }

            foreach(var connector in connectors)
            {
                if (connector.Annotations != null)
                {
                    var annotation = (connector.Annotations as AnnotationCollection).FirstOrDefault();
                    if (annotation != null)
                    {
                        annotation.FontSize = 18;
                        annotation.Margin = new Thickness(0, -15, 0, 0);
                        annotation.Background = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }

        private void UpdateNodeWidth(NodeViewModel node, string text)
        {
            if (node == null) return;
            if (text == null) text = string.Empty;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize = 18;
            textBlock.TextWrapping = TextWrapping.NoWrap;

            // Measure with infinite width
            textBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Size desiredSize = textBlock.DesiredSize;

            // Compute new width with some padding
            double measuredWidth = desiredSize.Width + 20;  // 20 for padding

            double newWidth = 100;
            if (measuredWidth > 100)
            {
                newWidth = measuredWidth;
            }

            // Update the node's width only
            node.UnitWidth = newWidth;
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

    }
}
