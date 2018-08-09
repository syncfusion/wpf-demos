
using System.Runtime.Serialization;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Syncfusion.Windows.Shared;

namespace FlowDiagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //Initialize PageSettings ,Snapping and Constraints
            InitializeDiagram();
            diagramcontrol.CommandManager.View = Application.Current.MainWindow;

            //Info - for Diagram Events and Commands
            IGraphInfo info = diagramcontrol.Info as IGraphInfo;
            //Event to notify the when Items added
            info.ItemAdded += info_ItemAdded;

        }

        //Event to notify the Changes
        void info_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            //Items added due to clipboard operation
            if (args.ItemSource == ItemSource.ClipBoard)
            {
                if (args.Item is INode)
                {
                    NodeVm node = args.Item as NodeVm;
                    if (!node.IsCustomStyle)
                    {
                        node.ShapeStyle = App.Current.Resources["nodeshapestyle"] as Style;
                    }
                    else
                    {
                        node.ShapeStyle = App.Current.Resources["nodeshapestyle1"] as Style;
                    }
                    AnnotationEditorViewModel vm=(node.Annotations as ICollection<IAnnotation>).ToList()[0] as AnnotationEditorViewModel;
                    if (node.IsMultiline)
                    {
                        vm.ViewTemplate = App.Current.Resources["viewtemplate"] as DataTemplate;
                    }
                    else
                    {
                        vm.ViewTemplate = App.Current.Resources["viewtemplate1"] as DataTemplate;
                    }
                }
            }
            if (args.Item is ConnectorViewModel)
            {
                ConnectorViewModel cvm = args.Item as ConnectorViewModel;
                if (cvm.Annotations == null)
                {
                    cvm.Annotations = new ObservableCollection<IAnnotation>()
                    {
                        new AnnotationEditorViewModel()
                        {
                            Content = "",
                        }
                    };
                }
            }
        }

        private void InitializeDiagram()
        {
            //Undoable Constraints used to enable/disable Undo/Redo the Action.
          
            diagramcontrol.Constraints = diagramcontrol.Constraints | GraphConstraints.Undoable;
            diagramcontrol.KnownTypes = GetKnownTypes;
        }

        //Helps to serialize the Shape 
        private IEnumerable<Type> GetKnownTypes()
        {
            List<Type> known = new List<Type>()
            {
                typeof(Shapes)
            };
            foreach (var item in known)
            {
                yield return item;
            }
        }
    }

    #region CustomClasses
    public class AnnotationCollection : ObservableCollection<IAnnotation>
    {

    }

    public class NodeVmCollection : ObservableCollection<NodeVm>
    {

    }

    //Custom NodeViewModel with new properties
    public class NodeVm : NodeViewModel
    {
        private bool _multiline = false;
        private bool _customstyle = false;
        [DataMember]
        public bool IsMultiline
        {
            get { return _multiline; }
            set
            {
                if (_multiline != value)
                {
                    _multiline = value;
                    OnPropertyChanged("IsMultiline");
                }
            }
        }
        [DataMember]
        public bool IsCustomStyle
        {
            get { return _customstyle; }
            set
            {
                if (_customstyle != value)
                {
                    _customstyle = value;
                    OnPropertyChanged("IsCustomStyle");
                }
            }
        }
    } 
    #endregion
}





