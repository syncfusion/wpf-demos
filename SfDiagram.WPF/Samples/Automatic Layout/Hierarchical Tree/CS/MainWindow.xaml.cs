using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HierarchicalLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
      
        public MainWindow()
        {
            InitializeComponent();

            //To Represent LayoutManager
            diagramControl.LayoutManager = new Syncfusion.UI.Xaml.Diagram.Layout.LayoutManager()
            {
                Layout = new DirectedTreeLayout()
            };

            //Initialize Employee class
            ObservableCollection<Employee> employee = new ObservableCollection<Employee>();

            // Initialize DataSourceSettings
            DataSourceSettings settings = new DataSourceSettings();
            //Get DataSourceSettings Properties.
            settings.ParentId = "ParentId";
            settings.Id = "EmpId";
              
            //Initialize Method
            Data(employee);
            settings.DataSource = employee;
            diagramControl.DataSourceSettings = settings;

           //Initialize PageSettings and Constraints
            InitializeDiagram();
           
            //To Disable ContextMenu
            diagramControl.Menu = null;
            diagramControl.Tool = Tool.ZoomPan;
        }

        // Get Employee Details 
        private void Data(ObservableCollection<Employee> employee)
        {
            employee.Add(new Employee() { EmpId = 1, ParentId = "", Name = "Plant Manager", _Color = "#034d6d" });
            employee.Add(new Employee() { EmpId = 2, ParentId = "1", Name = "Production Manager", _Color = "#1b80c6" });
            employee.Add(new Employee() { EmpId = 3, ParentId = "1", Name = "Administrative Officer", _Color = "#1b80c6" });
            employee.Add(new Employee() { EmpId = 4, ParentId = "1", Name = "Maintenance Manager", _Color = "#1b80c6" });
            employee.Add(new Employee() { EmpId = 5, ParentId = "2", Name = "Control Room", _Color = "#3dbfc9" });
            employee.Add(new Employee() { EmpId = 6, ParentId = "2", Name = "Plant Operator", _Color = "#3dbfc9" });
            employee.Add(new Employee() { EmpId = 7, ParentId = "4", Name = "Electrical Supervisor", _Color = "#3dbfc9" });
            employee.Add(new Employee() { EmpId = 8, ParentId = "4", Name = "Mechanical Supervisor", _Color = "#3dbfc9" });
            employee.Add(new Employee() { EmpId = 9, ParentId = "5", Name = "Foreman", _Color = "#2bb28e" });
            employee.Add(new Employee() { EmpId = 10, ParentId = "6", Name = "Foreman", _Color = "#2bb28e" });
            employee.Add(new Employee() { EmpId = 11, ParentId = "7", Name = "Craft Personnel", _Color = "#2bb28e" });
            employee.Add(new Employee() { EmpId = 12, ParentId = "7", Name = "Craft Personnel", _Color = "#2bb28e" });
            employee.Add(new Employee() { EmpId = 13, ParentId = "8", Name = "Craft Personnel", _Color = "#2bb28e" });
            employee.Add(new Employee() { EmpId = 14, ParentId = "8", Name = "Craft Personnel", _Color = "#2bb28e" });
            employee.Add(new Employee() { EmpId = 15, ParentId = "9", Name = "Craft Personnel", _Color = "#76d13b" });
            employee.Add(new Employee() { EmpId = 16, ParentId = "9", Name = "Craft Personnel", _Color = "#76d13b" });
            employee.Add(new Employee() { EmpId = 17, ParentId = "10", Name = "Craft Personnel", _Color = "#76d13b" });
        }
    

        private void InitializeDiagram()
        {
            //Constraints used to enable/disable Draggable/Selectable.
            diagramControl.Constraints &= ~(GraphConstraints.PageEditing|GraphConstraints.PanRails);
            //PageSettings used to enable the Appearance of Diagram Page.
            diagramControl.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            diagramControl.PageSettings.PageBorderBrush = new SolidColorBrush(Colors.Transparent);
            diagramControl.PageSettings.PageBackground = new SolidColorBrush(Colors.White);
        }

    
        //To Represent Spacing Properties
        public void Hspace_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = (sender as TextBox);
            string Str = box.Text;
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            if (diagramControl.LayoutManager != null)
            {
                if (isNum)
                {
                    if (Double.Parse(box.Text) >= 0)
                    {
                        switch (box.Name)
                        {
                            case "Hspace":
                                (diagramControl.LayoutManager.Layout as DirectedTreeLayout).HorizontalSpacing =
                                    double.Parse(box.Text);
                                diagramControl.LayoutManager.Layout.UpdateLayout();
                                break;
                            case "Vspace":
                                (diagramControl.LayoutManager.Layout as DirectedTreeLayout).VerticalSpacing =
                                    double.Parse(box.Text);
                                diagramControl.LayoutManager.Layout.UpdateLayout();
                                break;
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Please enter valid input");
                }
            }

        }
    }

    // Initialize variables
    public class Employee
    {
        public int EmpId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string _Color { get; set; }
    }
}
