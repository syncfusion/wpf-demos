#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class SequenceDiagramViewModel : DiagramViewModel
    {
        public DemoControl View;
        private bool first = true;

        public SequenceDiagramViewModel()
        {
            this.Tool = Tool.ZoomPan;
            this.Nodes = new NodeCollection();
            this.Connectors = new ConnectorCollection();
            this.DefaultConnectorType = ConnectorType.Line;
            this.Constraints = GraphConstraints.Default | GraphConstraints.Undoable;
            this.Model = GenerateSequenceDiagramData();
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

        private UMLSequenceDiagramModel GenerateSequenceDiagramData()
        {
            return  new UMLSequenceDiagramModel
            {
                SpaceBetweenParticipants = 300,
                Participants = new List<UMLSequenceParticipant>
                {
                    new UMLSequenceParticipant
                    {
                        ID = "User",
                        Content = "User",
                        IsActor = true,
                    },
                    new UMLSequenceParticipant
                    {
                        ID = "Transaction",
                        Content = "Transaction",
                        ActivationBoxes = new List<UMLSequenceActivationBox>
                        {
                            new UMLSequenceActivationBox {ID = "act1", StartMessageID = 1, EndMessageID=4}
                        }
                    },
                    new UMLSequenceParticipant
                    {
                        ID = "FraudDetectionSystem",
                        Content = "FraudDetectionSystem",
                        ActivationBoxes = new List<UMLSequenceActivationBox>
                        {
                            new UMLSequenceActivationBox {ID = "act2", StartMessageID = 2, EndMessageID=3},
                            new UMLSequenceActivationBox {ID = "act3", StartMessageID = 5, EndMessageID=6}
                        }
                    }
                },
                Messages = new List<UMLSequenceMessage>
                {
                    new UMLSequenceMessage { ID = 1, Content = "Initiate Transaction", FromParticipantID = "User", ToParticipantID = "Transaction", Type = UMLSequenceMessageType.Synchronous },
                    new UMLSequenceMessage { ID = 2, Content = "Send Transaction Data", FromParticipantID = "Transaction", ToParticipantID = "FraudDetectionSystem", Type = UMLSequenceMessageType.Synchronous },
                    new UMLSequenceMessage { ID = 3, Content = "Validate Transaction", FromParticipantID = "FraudDetectionSystem", ToParticipantID = "Transaction", Type = UMLSequenceMessageType.Reply },
                    new UMLSequenceMessage { ID = 4, Content = "Transaction Approved", FromParticipantID = "Transaction", ToParticipantID = "User", Type = UMLSequenceMessageType.Asynchronous },
                    new UMLSequenceMessage { ID = 5, Content = "Flag Transaction", FromParticipantID = "Transaction", ToParticipantID = "FraudDetectionSystem", Type = UMLSequenceMessageType.Synchronous },
                    new UMLSequenceMessage { ID = 6, Content = "Fraud Detected", FromParticipantID = "FraudDetectionSystem", ToParticipantID = "User", Type = UMLSequenceMessageType.Reply },
                    new UMLSequenceMessage { ID = 7, Content = "Cancel Transaction", FromParticipantID = "User", ToParticipantID = "Transaction", Type = UMLSequenceMessageType.Synchronous },
                    new UMLSequenceMessage { ID = 8, Content = "Complete Transaction", FromParticipantID = "User", ToParticipantID = "Transaction", Type = UMLSequenceMessageType.Synchronous }
                },
                Fragments = new List<UMLSequenceFragment>
                {
                    new UMLSequenceFragment
                    {
                        ID = 1,
                        Type = UMLSequenceFragmentType.Alternative,
                        Conditions = new List<UMLSequenceFragmentCondition>
                        {
                            new UMLSequenceFragmentCondition
                            {
                                Content = "Fraud Detected",
                                MessageIds = new List<object> { 5, 6, 7 }
                            },
                            new UMLSequenceFragmentCondition
                            {
                                Content = "No Fraud Detected",
                                MessageIds = new List<object> { 8 }
                            }
                        }
                    },
                }
            };
        }



    }
}
