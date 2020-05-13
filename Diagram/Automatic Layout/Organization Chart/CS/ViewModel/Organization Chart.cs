#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace AutomaticLayout_OrganizationLayout
{
    public class OrganizationChart : DiagramViewModel
    {
        private ICommand _orgCompactLeft_Command;
        private string compact;
        private ICommand _GetLayoutInfoCommand;
        public Button prevbutton = null;

        public OrganizationChart()
        {
            // Initialize Diagram properties

            Constraints = Constraints.Remove(GraphConstraints.PageEditing , GraphConstraints.PanRails);
            Menu = null;
            Tool = Tool.ZoomPan;
            DefaultConnectorType = ConnectorType.Orthogonal;
            

            //Initialize Commands

            orgCompactLeft_Command = new Command(OnorgCompactLeft_Command);
            GetLayoutInfoCommand = new Command(OnGetLayoutInfoCommand);

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

        public event PropertyChangedEventHandler PropertyChanged;

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
                        if (((args.Item as INode).Content as Employee).Designation.ToString() == "Managing Director")
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
        private Employees Getdata()
        {
            Employees employee = new Employees();

            employee.Add(new Employee()
            {
                Name = "Maria Anders",
                
                Designation = "Managing Director",
                ImageUrl = "./Assets/eric.png",
                RatingColor = "#71AF17",
                
            });

            employee.Add(new Employee()
            {
                Name = "Gareth Bale",
                Designation = "Secretary",
                ImageUrl = "./Assets/image54.png",
                RatingColor = "#13ab11",
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new Employee()
            {
                Name = "Pedro Afonso",
                Designation = "Project Manager",
                ImageUrl = "./Assets/Paul.png",
                RatingColor = "#1859B7",
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new Employee()
            {
                Name = "Elizabeth Brown",
                Designation = "Project Lead",
                ImageUrl = "./Assets/Maria.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(new Employee()
            {
                Name = "Aria Cruz",
                Designation = "Project Lead",
                ImageUrl = "./Assets/Jenny.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(new Employee()
            {
                Name = "Martín Sommer",
                Designation = "Senior S/w Engg",
                ImageUrl = "./Assets/image2.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(new Employee()
            {
                Name = "Jaime Yorres",
                Designation = "S/w Engg",
                ImageUrl = "./Assets/image2.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Pedro Afonso"
            });

            employee.Add(
                new Employee
                {
                    Name = "John Steel",
                    Designation = "Project Trainee",
                    ImageUrl = "/Assets/Maria.png",
                    RatingColor = "#2E95D8",
                    ReportingPerson = "Pedro Afonso"
                });

            employee.Add(new Employee()
            {
                Name = "Lino Rodriguez",
                Designation = "Project Manager",
                ImageUrl = "./Assets/Robin.PNG",
                RatingColor = "#1859B7",
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new Employee()
            {
                Name = "Hanna Moos",
                Designation = "Project Lead",
                ImageUrl = "./Assets/image55.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Lino Rodriguez"
            });

            employee.Add(new Employee()
            {
                Name = "Howard Snyder",
                Designation = "Project Lead",
                ImageUrl = "./Assets/image12.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Lino Rodriguez"
            });


            employee.Add(new Employee()
            {
                Name = "Philip Cramer",
                Designation = "Project Manager",
                ImageUrl = "./Assets/image2.PNG",
                RatingColor = "#1859B7",
                ReportingPerson = "Maria Anders"
            });

            employee.Add(new Employee()
            {
                Name = "Daniel Tonini",
                Designation = "Project Lead",
                ImageUrl = "./Assets/image57.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Philip Cramer"
            });

            employee.Add(new Employee()
            {
                Name = "Annette Roulet",
                Designation = "Senior S/w Engg",
                ImageUrl = "./Assets/image55.png",
                RatingColor = "#2E95D8",
                ReportingPerson = "Philip Cramer"
            });

            employee.Add(new Employee()
            {
                Name = "Yoshi Tannamuri",
                Designation = "S/w Engg",
                ImageUrl = "./Assets/image57.png",
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
                    prevbutton.Style = App.Current.MainWindow.Resources["ButtonStyle"] as Style;
                }
                button.Style = App.Current.MainWindow.Resources["SelectedButtonStyle"] as Style;

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
