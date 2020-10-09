#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
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
    /// Interaction logic for Annotations.xaml
    /// </summary>
    public partial class Annotations : DemoControl
    {
        public Annotations()
        {
            InitializeComponent();
        }

        public Annotations(string themename) : base(themename)
        {
            InitializeComponent();
            (this.DataContext as AnnotationsViewModel).View = this;
            (Diagram.Info as IGraphInfo).ItemSelectedEvent += Diagram_ItemSelectedEvent;
            (Diagram.Info as IGraphInfo).ItemUnSelectedEvent += Diagram_ItemUnSelectedEvent;

            var selectedItems = this.Diagram.SelectedItems as ISelector;
            if (selectedItems != null && selectedItems.Nodes is IEnumerable<object> )
            {
                var selectedNode = (selectedItems.Nodes as IEnumerable<object>).FirstOrDefault();
                if(selectedNode != null)
                {
                    this.OnItemSelected(selectedNode);
                }
            }
        }

        /// <summary>
        /// Item selected event to change the property panel elements value and enable or disbale the panel.
        /// </summary>
        /// <param name="sender">Diagram</param>
        /// <param name="args">DiagramEventArgs</param>
        private void Diagram_ItemUnSelectedEvent(object sender, DiagramEventArgs args)
        {
            var viewModel = Diagram.DataContext as AnnotationsViewModel;
            viewModel.Decoration = null;
            viewMode.IsChecked = false;
            labelInteraction.IsChecked = false;
            bold.Background = new SolidColorBrush(Colors.Transparent);
            italic.Background = new SolidColorBrush(Colors.Transparent);
            Strike.Background = new SolidColorBrush(Colors.Transparent);
            underline.Background = new SolidColorBrush(Colors.Transparent);
            if (((Diagram.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() == 0 &&
               ((Diagram.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>).Count() == 0)
            {
                propertyPanel.IsEnabled = false;
                if (viewModel.prevbutton != null)
                {
                    viewModel.prevbutton.Style = this.Resources["AnnotationsButtonStyle"] as Style;
                }
            }
            else
            {
                propertyPanel.IsEnabled = true;
            }
        }

        /// <summary>
        /// Item selected event to change the property panel elements value and enable or disbale the panel.
        /// </summary>
        /// <param name="sender">Diagram</param>
        /// <param name="args">DiagramEventArgs</param>
        private void Diagram_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            this.OnItemSelected((args as ItemSelectedEventArgs).Item);
        }

        private void OnItemSelected(object item)
        {
            propertyPanel.IsEnabled = true;
            if ((Diagram.DataContext as AnnotationsViewModel).prevbutton != null)
            {
                (Diagram.DataContext as AnnotationsViewModel).prevbutton.Style = this.Resources["AnnotationsButtonStyle"] as Style;
            }

            if (item is INode)
            {
                NodeViewModel node = item as NodeViewModel;
                foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                {
                    this.UpdatePropertyPanelElements(annotation);

                    #region Button selection for Node
                    if (annotation.Offset == new Point(0.5, 0.5))
                    {
                        this.Center.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = Center as Button;
                        break;
                    }
                    else if (annotation.Offset == new Point(0, 0))
                    {
                        this.TopLeft.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = TopLeft as Button;
                        break;
                    }
                    else if (annotation.Offset == new Point(1, 0))
                    {
                        this.TopRight.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = TopRight as Button;
                        break;
                    }
                    else if (annotation.Offset == new Point(0, 1))
                    {
                        this.BottomLeft.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = BottomLeft as Button;
                        break;
                    }
                    else if (annotation.Offset == new Point(1, 1))
                    {
                        this.BottomRight.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = BottomRight as Button;
                        break;
                    }
                    else if (annotation.Offset == new Point(0.5, 1))
                    {
                        this.MarginText.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = MarginText as Button;
                        break;
                    }
                    #endregion
                }
            }
            else
            {
                ConnectorViewModel connector = item as ConnectorViewModel;
                foreach (IAnnotation annotation in connector.Annotations as ObservableCollection<IAnnotation>)
                {
                    this.UpdatePropertyPanelElements(annotation);

                    #region Button Selection for connectors
                    if (annotation.Length == 0)
                    {
                        this.SourceText.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = SourceText as Button;
                        break;
                    }
                    else if (annotation.Length == 1)
                    {
                        this.TargetText.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = TargetText as Button;
                        break;
                    }
                    else if (annotation.Length == 0.5 && annotation.Margin == new Thickness(0, -10, 0, 0))
                    {
                        this.AboveCenter.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = AboveCenter as Button;
                        break;
                    }
                    else if (annotation.Length == 0.5 && annotation.Margin == new Thickness(0, 10, 0, 0))
                    {
                        this.BelowCenter.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = BelowCenter as Button;
                        break;
                    }
                    else if (annotation.Length == 0.5 && annotation.Margin == new Thickness(0, 0, 0, 0))
                    {
                        this.CenterText.Style = this.Resources["AnnotationsSelectedButtonStyle"] as Style;
                        (Diagram.DataContext as AnnotationsViewModel).prevbutton = CenterText as Button;
                        break;
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// To update the node and annotation property values to the property panel.
        /// </summary>
        /// <param name="annotation">Annotation of the node or connector.</param>
        private void UpdatePropertyPanelElements(IAnnotation annotation)
        {
            #region FontStyle
            if ((annotation as TextAnnotationViewModel).FontWeight == FontWeights.Bold)
            {
                bold.Background = new SolidColorBrush(Colors.LightBlue);
            }

            if ((annotation as TextAnnotationViewModel).FontStyle == FontStyles.Italic)
            {
                italic.Background = new SolidColorBrush(Colors.LightBlue);
            }
            #endregion

            #region UnderLine and Strike for Node
            if ((annotation as TextAnnotationViewModel).TextDecorations != null && (annotation as TextAnnotationViewModel).TextDecorations.Contains(TextDecorations.Underline[0]))
            {
                underline.Background = new SolidColorBrush(Colors.LightBlue);
                (Diagram.DataContext as AnnotationsViewModel).underLineFlag = true;
                if ((Diagram.DataContext as AnnotationsViewModel).Decoration == null)
                    (Diagram.DataContext as AnnotationsViewModel).Decoration = new TextDecorationCollection();
                (Diagram.DataContext as AnnotationsViewModel).Decoration.Add(TextDecorations.Underline);
            }
            else
            {
                (Diagram.DataContext as AnnotationsViewModel).underLineFlag = false;
            }

            if ((annotation as TextAnnotationViewModel).TextDecorations != null &&
                (annotation as TextAnnotationViewModel).TextDecorations.Contains(TextDecorations.Strikethrough[0]))
            {
                Strike.Background = new SolidColorBrush(Colors.LightBlue);
                (Diagram.DataContext as AnnotationsViewModel).strikeFlag = true;
                if ((Diagram.DataContext as AnnotationsViewModel).Decoration == null)
                    (Diagram.DataContext as AnnotationsViewModel).Decoration = new TextDecorationCollection();
                (Diagram.DataContext as AnnotationsViewModel).Decoration.Add(TextDecorations.Strikethrough);
            }
            else
            {
                (Diagram.DataContext as AnnotationsViewModel).strikeFlag = false;
            }
            #endregion

            #region Edit Mode

            if (annotation.ReadOnly)
            {
                viewMode.IsChecked = true;
            }
            else
            {
                viewMode.IsChecked = false;
            }
            #endregion

            #region Label interaction

            if (annotation.Constraints.Contains(AnnotationConstraints.Selectable))
            {
                labelInteraction.IsChecked = true;
            }
            else
            {
                labelInteraction.IsChecked = false;
            }
            #endregion
        }

    }
}
