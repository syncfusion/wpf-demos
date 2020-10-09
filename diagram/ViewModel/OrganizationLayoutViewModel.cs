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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class OrganizationLayoutViewModel : DiagramViewModel
    {
        
        private ICommand _orgCompactLeft_Command;
        private string compact;
        private ICommand _GetLayoutInfoCommand;
        public Button prevbutton = null;
        public DemoControl View;

        public OrganizationLayoutViewModel()
        {
            // Initialize Diagram properties

            Constraints = Constraints.Remove(GraphConstraints.PageEditing, GraphConstraints.PanRails);
            Menu = null;
            Tool = Tool.ZoomPan;
            DefaultConnectorType = ConnectorType.Orthogonal;


            //Initialize Commands

            orgCompactLeft_Command = new DelegateCommand(OnorgCompactLeft_Command);
            GetLayoutInfoCommand = new DelegateCommand(OnGetLayoutInfoCommand);

            // Initialize DataSourceSettings for SfDiagram

            DataSourceSettings = new DataSourceSettings()
            {
                ParentId = "ReportingPerson",
                Id = "Name",
                DataSource = Getdata(),
            };

            // Initialize LayoutSettings for SfDiagram

            LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = LayoutType.Organization,
                    HorizontalSpacing = 50,
                    VerticalSpacing = 40
                },
            };
        }

        #region Commands

        public ICommand orgCompactLeft_Command
        {
            get { return _orgCompactLeft_Command; }
            set
            {
                if (_orgCompactLeft_Command != value)
                {
                    _orgCompactLeft_Command = value;
                    onPropertyChanged("orgCompactLeft_Command");
                }
            }
        }

        public new ICommand GetLayoutInfoCommand
        {
            get { return _GetLayoutInfoCommand; }
            set
            {
                if (_GetLayoutInfoCommand != value)
                {
                    _GetLayoutInfoCommand = value;
                    onPropertyChanged("orgCompactLeft_Command");
                }
            }
        }

        #endregion

        public new event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        #region Helper Methods

        /// <summary>
        /// Method for GetLayoutInfo Command 
        /// Method to change the Orientation and Type of Layout
        /// </summary>
        /// <param name="obj"></param>
        private void OnGetLayoutInfoCommand(object obj)
        {
            var args = obj as LayoutInfoArgs;
            if (LayoutManager.Layout is DirectedTreeLayout)
            {
                if ((LayoutManager.Layout as DirectedTreeLayout).Type == LayoutType.Organization)
                {
                    if (args.Item is INode)
                    {
                        if (((args.Item as INode).Content as OrganizationLayoutModel).Designation.ToString() == "Managing Director")
                        {
                            args.Assistants.Add(args.Children[0]);
                            args.Children.Remove(args.Children[0]);
                        }
                    }

                    switch (compact)
                    {
                        case "left":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Left;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "right":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Right;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "alternate":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Alternate;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "horizontal_center":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Center;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "horizontal_right":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Right;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "horizontal_left":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Left;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                    }
                }
            }
        }


        /// <summary>
        /// Method to Get the data for DataSource
        /// </summary>
        /// <param name="employee"></param>
        private OrganizationLayoutModels Getdata()
        {
            OrganizationLayoutModels employee = new OrganizationLayoutModels();

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Maria Anders",

                Designation = "Managing Director",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle14.png",
                RatingColor = "#71AF17",

            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Gareth Bale",
                Designation = "Secretary",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle18.png",
                RatingColor = "#13ab11",
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Pedro Afonso",
                Designation = "Project Manager",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle23.png",
                RatingColor = "#1859B7",
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Elizabeth Brown",
                Designation = "Project Lead",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Aria Cruz",
                Designation = "Project Lead",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle0.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Martín Sommer",
                Designation = "Senior S/w Engg",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle27.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Jaime Yorres",
                Designation = "S/w Engg",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle27.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(
                new OrganizationLayoutModel
                {
                    Name = "John Steel",
                    Designation = "Project Trainee",
                    ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png",
                    RatingColor = "#2E95D8",
                    ReportingPerson = "Pedro Afonso"
                });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Lino Rodriguez",
                Designation = "Project Manager",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle8.png",
                RatingColor = "#1859B7",
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Hanna Moos",
                Designation = "Project Lead",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle4.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Lino Rodriguez"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Howard Snyder",
                Designation = "Project Lead",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle26.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Lino Rodriguez"
            });


            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Philip Cramer",
                Designation = "Project Manager",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle27.PNG",
                RatingColor = "#1859B7",
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Daniel Tonini",
                Designation = "Project Lead",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle5.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Philip Cramer"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Annette Roulet",
                Designation = "Senior S/w Engg",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle4.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Philip Cramer"
            });

            employee.Add(new OrganizationLayoutModel()
            {
                Name = "Yoshi Tannamuri",
                Designation = "S/w Engg",
                ImageUrl = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle5.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Philip Cramer"
            });

            return employee;
        }

        /// <summary>
        /// Method to get the Type 
        /// </summary>
        /// <param name="obj"></param>
        private void OnorgCompactLeft_Command(object obj)
        {
            if (obj != null && obj is Button)
            {
                Button button = obj as Button;
                if (prevbutton != null)
                {
                    prevbutton.Style = View.Resources["ButtonStyle"] as Style;
                }
                button.Style = View.Resources["SelectedButtonStyle"] as Style;

                if (button.Name.Equals("orgCompactLeft"))
                {
                    compact = "left";
                }
                else if (button.Name.Equals("orgCompactRight"))
                {
                    compact = "right";
                }
                else if (button.Name.Equals("orgCompactAlternate"))
                {
                    compact = "alternate";
                }
                else if (button.Name.Equals("orgCompactCenter"))
                {
                    compact = "horizontal_center";
                }
                else if (button.Name.Equals("orgCompactHorizontalRight"))
                {
                    compact = "horizontal_right";
                }
                else if (button.Name.Equals("orgCompactHorizontalLeft"))
                {
                    compact = "horizontal_left";
                }
                (LayoutManager.Layout as DirectedTreeLayout).UpdateLayout();

                prevbutton = obj as Button;
            }
        }
        #endregion
    }
}
