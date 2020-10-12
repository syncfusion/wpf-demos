#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class MultiParentViewModel : DiagramViewModel
    {
        #region Private Variables

        private ICommand _Orientation_Command;
        public Button prevbutton;

        #endregion

        #region Commands
        public ICommand Orientation_Command
        {
            get { return _Orientation_Command; }
            set
            {
                if (_Orientation_Command != value)
                {
                    _Orientation_Command = value;
                    onPropertyChanged("Orientation_Command");
                }
            }
        }
        #endregion

        public MultiParentViewModel()
        {
            //Initialize Diagram Properties
            Connectors = new ObservableCollection<ConnectorVM>();
            Constraints = Constraints.Remove(GraphConstraints.PageEditing, GraphConstraints.PanRails);
            Menu = null;
            Tool = Tool.ZoomPan;
            DefaultConnectorType = ConnectorType.Orthogonal;

            // Initialize Command for sample changes

            Orientation_Command = new DelegateCommand(OnOrientation_Command);

            // Initialize DataSourceSettings for SfDiagram
            DataSourceSettings = new DataSourceSettings()
            {
                ParentId = "ReportingPerson",
                Id = "Name",
                DataSource = GetData(),
            };

            // Initialize LayoutSettings for SfDiagram
            LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = LayoutType.Hierarchical,
                    Orientation = TreeOrientation.TopToBottom,
                    AvoidSegmentOverlapping = true,
                    HorizontalSpacing = 40,
                    VerticalSpacing = 40,
                },
            };
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// Method to change Orientation of the Layout
        /// </summary>
        /// <param name="obj"></param>
        private void OnOrientation_Command(object obj)
        {
            Button button = obj as Button;
            if (prevbutton != null)
            {
                prevbutton.Style = Application.Current.Resources["ButtonStyle"] as Style;
            }
            button.Style = Application.Current.Resources["SelectedButtonStyle"] as Style;

            switch (button.Name.ToString())
            {
                case "ToptoBottomOrientation":
                    (LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.TopToBottom;
                    break;
                case "BottomtoTopOrientation":
                    (LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.BottomToTop;
                    break;
                case "LefttoRightOrientation":
                    (LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.LeftToRight;
                    break;
                case "RighttoLeftOrientation":
                    (LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.RightToLeft;
                    break;
            }
            prevbutton = obj as Button;
        }

        /// <summary>
        /// Method to Get Data for DataSource
        /// </summary>
        /// <param name="data"></param>
        private MultiParentModels GetData()
        {
            MultiParentModels data = new MultiParentModels();

            data.Add(new MultiParentModel("n11", "#ff6329"));

            data.Add(new MultiParentModel("n12", "#ff6329"));

            data.Add(new MultiParentModel("n13", "#ff6329"));

            data.Add(new MultiParentModel("n21", "#941100") { ReportingPerson = new List<string> { "n11", "n12", "n13" } });

            data.Add(new MultiParentModel("n31", "#669be5") { ReportingPerson = new List<string> { "n21" } });

            data.Add(new MultiParentModel("n32", "#669be5") { ReportingPerson = new List<string> { "n21" } });

            data.Add(new MultiParentModel("n41", "#30ab5c") { ReportingPerson = new List<string> { "n31" } });

            data.Add(new MultiParentModel("n42", "#30ab5c") { ReportingPerson = new List<string> { "n31" } });

            data.Add(new MultiParentModel("n43", "#30ab5c") { ReportingPerson = new List<string> { "n31" } });

            data.Add(new MultiParentModel("n44", "#30ab5c") { ReportingPerson = new List<string> { "n31", "n32" } });

            data.Add(new MultiParentModel("n45", "#30ab5c") { ReportingPerson = new List<string> { "n32" } });

            data.Add(new MultiParentModel("n46", "#30ab5c") { ReportingPerson = new List<string> { "n32" } });

            data.Add(new MultiParentModel("n47", "#30ab5c") { ReportingPerson = new List<string> { "n32" } });

            data.Add(new MultiParentModel("n51", "#ff9400") { ReportingPerson = new List<string> { "n41", "n42", "n43" } });

            data.Add(new MultiParentModel("n52", "#ff9400") { ReportingPerson = new List<string> { "n45", "n46", "n47" } });

            data.Add(new MultiParentModel("n61", "#99bb55") { ReportingPerson = new List<string> { "n51" } });

            data.Add(new MultiParentModel("n62", "#99bb55") { ReportingPerson = new List<string> { "n51" } });

            data.Add(new MultiParentModel("n63", "#99bb55") { ReportingPerson = new List<string> { "n51", "n44" } });

            data.Add(new MultiParentModel("n64", "#99bb55") { ReportingPerson = new List<string> { "n44", "n52" } });

            data.Add(new MultiParentModel("n65", "#99bb55") { ReportingPerson = new List<string> { "n52" } });

            data.Add(new MultiParentModel("n66", "#99bb55") { ReportingPerson = new List<string> { "n52" } });

            return data;
        }
    }
    public class ConnectorVM : ConnectorViewModel
    {
        public ConnectorVM()
            : base()
        {
            this.CornerRadius = 10;
        }
    }
}
