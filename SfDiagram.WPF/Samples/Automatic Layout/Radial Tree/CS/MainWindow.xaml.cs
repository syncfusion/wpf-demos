using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RadialLayoutDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Employee> employee = new ObservableCollection<Employee>();
            diagramControl.Nodes = new ObservableCollection<Node>();
            diagramControl.Connectors = new ObservableCollection<Connector>();
            //To Represent DataSourceSettings Properties
            DataSourceSettings settings = new DataSourceSettings();
            settings.ParentId = "ParentId";
            settings.Id = "EmpId";
            settings.Root = "1";
            settings.DataSource = employee;
            diagramControl.DataSourceSettings = settings;

            //Initialize method
            Data(employee);

            //Initialize PageSettings and Constraints
            InitializeDiagram();

            //To Represent LayoutManager Properties
            diagramControl.LayoutManager = new LayoutManager()
            {
                Layout = new RadialTreeLayout()
                {
                    HorizontalSpacing = 10,
                    VerticalSpacing =30
                }
            };
          
            //To Disable ContextMenu
            diagramControl.Menu = null;

            //To make Diagram as ReadOnly
            diagramControl.Tool = Tool.ZoomPan;
            diagramControl.Constraints |=GraphConstraints.Pannable|GraphConstraints.Zoomable;
        }       

        private void InitializeDiagram()
        {
            //Constraints used to enable/disable Dragging/Selectable.
            diagramControl.Constraints &= ~GraphConstraints.PageEditing;
            //PageSettings used to enable the Appearance of Diagram Page.
            diagramControl.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            diagramControl.PageSettings.PageBorderBrush = new SolidColorBrush(Colors.Transparent);
            diagramControl.PageSettings.PageBackground = new SolidColorBrush(Colors.White);
            diagramControl.DefaultConnectorType = ConnectorType.Line;
        }

        //Get Employee Details
        private void Data(ObservableCollection<Employee> employee)
        {
            employee.Add(new Employee() { EmpId = 1, ParentId = "", Imageurl = "./Assets/Thomas.png" });
            employee.Add(new Employee() { EmpId = 2, ParentId = "1", Imageurl = "./Assets/Clayton.png" });
            employee.Add(new Employee() { EmpId = 3, ParentId = "1", Imageurl = "./Assets/eric.png" });
            employee.Add(new Employee() { EmpId = 4, ParentId = "1", Imageurl = "./Assets/John.png" });
            employee.Add(new Employee() { EmpId = 5, ParentId = "1", Imageurl = "./Assets/image12.png" });
            employee.Add(new Employee() { EmpId = 6, ParentId = "1", Imageurl = "./Assets/image2.png" });
            employee.Add(new Employee() { EmpId = 7, ParentId = "1", Imageurl = "./Assets/image3.png" });
            employee.Add(new Employee() { EmpId = 8, ParentId = "1", Imageurl = "./Assets/image50.png" });
            employee.Add(new Employee() { EmpId = 9, ParentId = "2", Imageurl = "./Assets/image51.png" });
            employee.Add(new Employee() { EmpId = 10, ParentId = "2", Imageurl = "./Assets/image53.png" });
            employee.Add(new Employee() { EmpId = 11, ParentId = "3", Imageurl = "./Assets/image54.png" });
            employee.Add(new Employee() { EmpId = 12, ParentId = "3", Imageurl = "./Assets/image55.png" });
            employee.Add(new Employee() { EmpId = 13, ParentId = "4", Imageurl = "./Assets/image56.png" });
            employee.Add(new Employee() { EmpId = 14, ParentId = "4", Imageurl = "./Assets/image57.png" });
            employee.Add(new Employee() { EmpId = 15, ParentId = "5", Imageurl = "./Assets/images7.png" });
            employee.Add(new Employee() { EmpId = 16, ParentId = "5", Imageurl = "./Assets/images9.png" });
            employee.Add(new Employee() { EmpId = 17, ParentId = "6", Imageurl = "./Assets/Jenny.png" });
            employee.Add(new Employee() { EmpId = 18, ParentId = "6", Imageurl = "./Assets/John.png" });
            employee.Add(new Employee() { EmpId = 19, ParentId = "7", Imageurl = "./Assets/eric.png" });
            employee.Add(new Employee() { EmpId = 20, ParentId = "7", Imageurl = "./Assets/Maria.png" });
            employee.Add(new Employee() { EmpId = 21, ParentId = "8", Imageurl = "./Assets/image12.png" });
            employee.Add(new Employee() { EmpId = 22, ParentId = "8", Imageurl = "./Assets/Paul.png" });
            employee.Add(new Employee() { EmpId = 23, ParentId = "9", Imageurl = "./Assets/Robin.png" });
            employee.Add(new Employee() { EmpId = 24, ParentId = "9", Imageurl = "./Assets/smith.png" });
            employee.Add(new Employee() { EmpId = 25, ParentId = "10", Imageurl = "./Assets/Thomas.png" });
            employee.Add(new Employee() { EmpId = 26, ParentId = "10", Imageurl = "./Assets/Clayton.png" });
            employee.Add(new Employee() { EmpId = 27, ParentId = "11", Imageurl = "./Assets/eric.png" });
            employee.Add(new Employee() { EmpId = 28, ParentId = "11", Imageurl = "./Assets/images7.png" });
            employee.Add(new Employee() { EmpId = 29, ParentId = "12", Imageurl = "./Assets/image12.png" });
            employee.Add(new Employee() { EmpId = 30, ParentId = "12", Imageurl = "./Assets/image2.png" });
            employee.Add(new Employee() { EmpId = 31, ParentId = "13", Imageurl = "./Assets/image3.png" });
            employee.Add(new Employee() { EmpId = 32, ParentId = "13", Imageurl = "./Assets/image50.png" });
            employee.Add(new Employee() { EmpId = 33, ParentId = "14", Imageurl = "./Assets/image51.png" });
            employee.Add(new Employee() { EmpId = 34, ParentId = "14", Imageurl = "./Assets/image53.png" });
            employee.Add(new Employee() { EmpId = 35, ParentId = "15", Imageurl = "./Assets/image54.png" });
            employee.Add(new Employee() { EmpId = 36, ParentId = "15", Imageurl = "./Assets/image55.png" });
            employee.Add(new Employee() { EmpId = 37, ParentId = "16", Imageurl = "./Assets/image56.png" });
            employee.Add(new Employee() { EmpId = 38, ParentId = "16", Imageurl = "./Assets/image57.png" });
            employee.Add(new Employee() { EmpId = 39, ParentId = "17", Imageurl = "./Assets/images7.png" });
            employee.Add(new Employee() { EmpId = 40, ParentId = "17", Imageurl = "./Assets/images9.png" });
            employee.Add(new Employee() { EmpId = 41, ParentId = "18", Imageurl = "./Assets/Jenny.png" });
            employee.Add(new Employee() { EmpId = 42, ParentId = "18", Imageurl = "./Assets/John.png" });
            employee.Add(new Employee() { EmpId = 43, ParentId = "19", Imageurl = "./Assets/Clayton.png" });
            employee.Add(new Employee() { EmpId = 44, ParentId = "19", Imageurl = "./Assets/Maria.png" });
            employee.Add(new Employee() { EmpId = 45, ParentId = "20", Imageurl = "./Assets/image55.png" });
            employee.Add(new Employee() { EmpId = 46, ParentId = "20", Imageurl = "./Assets/Paul.png" });
            employee.Add(new Employee() { EmpId = 47, ParentId = "21", Imageurl = "./Assets/Robin.png" });
            employee.Add(new Employee() { EmpId = 48, ParentId = "21", Imageurl = "./Assets/smith.png" });
            employee.Add(new Employee() { EmpId = 49, ParentId = "22", Imageurl = "./Assets/Thomas.png" });
            employee.Add(new Employee() { EmpId = 50, ParentId = "22", Imageurl = "./Assets/John.png" });
        }
        double hspace = 0;
        double vspace = 0;
        //To Change the Spacing Property
        private void Hspace_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = (sender as TextBox);
            string Str = box.Text;
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            if (diagramControl.LayoutManager != null)
            {
                if (isNum && Double.Parse(box.Text) > 0 )
                {                    
                        switch (box.Name)
                        {
                            case "Hspace":

                                (diagramControl.LayoutManager.Layout as RadialTreeLayout).HorizontalSpacing = double.Parse(box.Text);
                                hspace = double.Parse(box.Text);
                                 diagramControl.LayoutManager.Layout.UpdateLayout();
                                break;
                            case "Vspace":
                                (diagramControl.LayoutManager.Layout as RadialTreeLayout).VerticalSpacing = double.Parse(box.Text);
                                vspace = double.Parse(box.Text);
                                diagramControl.LayoutManager.Layout.UpdateLayout();
                                break;
                        }                    
                }
                else
                {
                    MessageBox.Show("Please enter valid input");
                    switch (box.Name)
                    {
                        case "Hspace":
                            Hspace.Text = hspace.ToString();
                            break;
                        case "Vspace":
                            Vspace.Text = vspace.ToString();
                            break;
                    }
                }                
            }
        }        
    }

    //Initialize Variables
    public class Employee
    {
        public int EmpId { get; set; }
        public string Imageurl { get; set; }
        public string ParentId { get; set; }
    }
}
