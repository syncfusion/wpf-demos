#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace UMLDiagramDesigner
{
    public class Model
    {
        public void Serialize(SfDiagram diagramModel, Stream stream)
        {
            Nodes = ((IEnumerable<object>)diagramModel.Nodes).OfType<Node>()
                                      .Where(node => node.Content is INode)
                                      .Select(node => node.Content)
                                      .ToList<Object>();

            Lines = ((IEnumerable<object>)diagramModel.Connectors).OfType<Connector>()
                                            .Where(line => line.Content is ILine && line.SourceNode != null && line.TargetNode != null)
                                            .Select(line => line.Content).Cast<LineProperties>()
                                            .ToList<LineProperties>();

            XmlSerializer serializer = new XmlSerializer(typeof(Model),
                                                            new Type[]
                                                            {
                                                                typeof(ClassNode),
                                                                typeof(InterfaceNode),
                                                                typeof(NoteNode),
                                                                typeof(TextNode),
                                                                typeof(LineProperties)
                                                            });

            serializer.Serialize(stream, this);
        }

        public void DeSerialize(Stream stream, SfDiagram diagramModel)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Model),
                                                            new Type[]
                                                            {
                                                                typeof(ClassNode),
                                                                typeof(InterfaceNode),
                                                                typeof(NoteNode),
                                                                typeof(TextNode),
                                                                typeof(LineProperties)
                                                            });
            Model localModel;

            localModel = (Model)serializer.Deserialize(stream);

            Dictionary<INode, Node> NodeContentPair = new Dictionary<INode, Node>();

            foreach (INode node in localModel.Nodes)
            {
                Node newNode = new Node() { Content = node };
                (diagramModel.Nodes as IList<Node>).Add(newNode);
                NodeContentPair.Add(node, newNode);
            }

            foreach (LineProperties line in localModel.Lines)
            {
                Connector lineConnector = new Connector()
                    {
                        Segments = new ObservableCollection<object>() { new StraightSegment() },
                        Content = line
                    };
                foreach (INode node in localModel.Nodes)
                {
                    if(node.ID == line.HeadID)
                    {
                        line.Head = node;
                        lineConnector.SourceNode = NodeContentPair[node];
                    }

                    if(node.ID == line.TailID)
                    {
                        line.Tail = node;
                        lineConnector.TargetNode = NodeContentPair[node];
                    }
                }
                (diagramModel.Connectors as ICollection<Connector>).Add(lineConnector);
            }
        }

        private List<Object> m_Nodes;
        public List<Object> Nodes
        {
            get
            {
                return m_Nodes;
            }
            set
            {
                m_Nodes = value;
            }
        }

        private List<LineProperties> m_Lines;
        public List<LineProperties> Lines
        {
            get
            {
                return m_Lines;
            }
            set
            {
                m_Lines = value;
            }
        }
    }
}
