using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagrambuilder.wpf.ViewModel
{
    public class DiagramVM : DiagramViewModel
    {
        public DiagramVM()
        {
            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();
            Groups = new GroupCollection();
            SelectedItems = new SelectorViewModel();
            SnapSettings = new SnapSettings() { SnapToObject = SnapToObject.All, SnapConstraints = SnapConstraints.All };
            HorizontalRuler = new Syncfusion.UI.Xaml.Diagram.Controls.Ruler() { Orientation = System.Windows.Controls.Orientation.Horizontal };
            VerticalRuler = new Syncfusion.UI.Xaml.Diagram.Controls.Ruler() { Orientation = System.Windows.Controls.Orientation.Vertical };
            PageSettings = new PageSettings();
            PortVisibility = PortVisibility.MouseOverOnConnect;
            DefaultConnectorType = ConnectorType.Orthogonal;
            Constraints = GraphConstraints.Default | GraphConstraints.Undoable;
            ItemAddedCommand = new DelegateCommand(OnItemAdded);
            EnableConnectorSplitting = true;
        }

        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;
            if (args.ItemSource == ItemSource.Stencil)
            {
                if (args.Item is INode && (args.Item as INode).Key.ToString() == "Electrical Shapes")
                {
                    (args.Item as INode).ThemeStyleId = StyleId.Accent3 | StyleId.Balanced;
                }
            }
        }
    }
}
