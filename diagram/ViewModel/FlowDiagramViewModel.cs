#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class FlowDiagramViewModel : DiagramViewModel
    {
        private bool first = true;
        public FlowDiagramViewModel()
        {
            //Graph constraints is used here to enable/disable the undoable process.
            Constraints = Constraints.Add(GraphConstraints.Undoable);

            ItemAddedCommand = new DelegateCommand(OnItemAdded);
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChanged);
        }

        private void OnViewPortChanged(object obj)
        {
            var args = obj as ChangeEventArgs<object, ScrollChanged>;
            if (Info != null && (args.Item as SfDiagram).IsLoaded == true && first && args.NewValue.ContentBounds != args.OldValue.ContentBounds)
            {
                (Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                first = false;
            }
        }

        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;
            if (args.Item is NodeViewModel)
            {
                if (args.ItemSource == ItemSource.Stencil)
                {
                    (args.Item as NodeViewModel).Annotations = new ObservableCollection<IAnnotation>()
                    {
                        new TextAnnotationViewModel()
                        {
                            FontFamily = new FontFamily("FontFamily"),
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                        }
                    };
                }
                foreach (IAnnotation anno in (args.Item as NodeViewModel).Annotations as ObservableCollection<IAnnotation>)
                {
                    (anno as TextAnnotationViewModel).FontFamily = new FontFamily("Calibri");
                }
            }
        }
    }
}
