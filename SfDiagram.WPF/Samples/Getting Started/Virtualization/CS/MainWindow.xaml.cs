using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System.Linq;

namespace Virtualization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //Enables the Virtualization.
            diagram.Constraints = (diagram.Constraints & ~(GraphConstraints.PageEditing)) | (GraphConstraints.Virtualize |GraphConstraints.AllowPan | GraphConstraints.Outline | GraphConstraints.Commands) ;
            diagram.Tool = Tool.ZoomPan;
            diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            //Arrange the Node.
            CreateNode();

            //Connects the Nodes.
            CreateConnection();
        }


        //Connects the Hexagon arrangment Nodes.
        private void CreateConnection()
        {
            int increment = 0;
            int altenate = 0;
            NodeCollection nodecollection = diagram.Nodes as NodeCollection;
            ConnectorCollection connectorcollection = diagram.Connectors as ConnectorCollection;
            for (int j = 1; j < 101; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    if ((i + increment + 1) % 100 != 0)
                    {
                        ConnectorViewModel cv1 = new ConnectorViewModel()
                        {
                            SourceNode = nodecollection.ToList()[i + increment],
                            TargetNode = nodecollection.ToList()[i + 1 + increment],
                        };
                        connectorcollection.Add(cv1);
                    }
                    if (j == 1 && i == 0)
                    {
                        ConnectorViewModel cv1 = new ConnectorViewModel()
                        {
                            SourceNode = nodecollection.ToList()[i],
                            TargetNode = nodecollection.ToList()[i + 101],
                        };
                        connectorcollection.Add(cv1);
                    }
                    if (j != 1)
                    {
                        if (i == 0)
                        {
                            if (!((increment + 100) > 9900))
                            {
                                ConnectorViewModel cv1 = new ConnectorViewModel()
                                {
                                    SourceNode = nodecollection.ToList()[i + increment],
                                    TargetNode = nodecollection.ToList()[i + 1 + (increment + 100)],
                                };
                                connectorcollection.Add(cv1);
                            }
                        }
                        else
                        {
                            altenate += 1;
                            if (altenate == 2 || altenate == 5)
                            {
                                if (altenate == 2)
                                {
                                    ConnectorViewModel cv1 = new ConnectorViewModel()
                                    {
                                        SourceNode = nodecollection.ToList()[i + increment],
                                        TargetNode = nodecollection.ToList()[i + 1 + (increment - 100)],
                                    };
                                    connectorcollection.Add(cv1);
                                }
                                else
                                {
                                    ConnectorViewModel cv1 = new ConnectorViewModel()
                                    {
                                        SourceNode = nodecollection.ToList()[i + increment],
                                        TargetNode = nodecollection.ToList()[i - 1 + (increment - 100)],
                                    };
                                    connectorcollection.Add(cv1);
                                }
                            }
                            if (altenate == 5)
                            {
                                altenate = 0;
                                altenate += 1;
                            }
                        }
                    }
                }
                increment += 100;
                altenate = 0;
            }
        }

        //Arrange the Nodes for Hexagon shape.
        private void CreateNode()
        {
            NodeCollection nodecollection = diagram.Nodes as NodeCollection;
            double commonfortop = 0;
            double alternate = 0;
            double levelfortop = 50;
            double levelforremaining = 0;
            for (int j = 1; j < 101; j++)
            {
                for (int i = 0; i < 100; ++i)
                {
                    NodeViewModel node = new NodeViewModel();
                    node.UnitWidth = 50;
                    node.UnitHeight = 30;

                    if (i == 0)
                    {
                        node.OffsetX = 100 + (levelfortop);
                        commonfortop = node.OffsetX;
                    }
                    else
                    {
                        alternate += 1;
                        if (alternate <= 2)
                        {
                            node.OffsetX = 40 + levelforremaining;

                        }
                        else
                        {
                            node.OffsetX = commonfortop;
                        }

                        if (alternate == 4)
                        {
                            alternate = 0;
                        }

                    }

                    node.OffsetY = 20 + (80 * i);
                    nodecollection.Add(node);
                }
                levelfortop += 220;
                levelforremaining += 220;
                alternate = 0;
            }
        }
    }
}
