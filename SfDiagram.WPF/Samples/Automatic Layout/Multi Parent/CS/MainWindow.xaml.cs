namespace OrganizationLayout
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.UI.Xaml.Diagram.Layout;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        #region Private Variables

        private string pressedButtonName = string.Empty;

        private ToggleButton previousPressedElement;

        #endregion

        public MainWindow()
        {
            this.InitializeComponent();

            //Initialize Nodes and Connectors
            this.sfdiagram.Nodes = new DiagramCollection<NodeViewModel>();
            this.sfdiagram.Connectors = new DiagramCollection<CustomConnectorViewModel>();

            this.sfdiagram.HorizontalRuler = new Ruler { Orientation = Orientation.Horizontal };
            this.sfdiagram.VerticalRuler = new Ruler { Orientation = Orientation.Vertical };

            var layoutSettings = new DirectedTreeLayout
                                     {
                                         Type = LayoutType.Hierarchical,
                                         Orientation = TreeOrientation.TopToBottom,
                                         HorizontalSpacing = 40,
                                         VerticalSpacing = 40,
                                         Margin = new Thickness()
                                     };

            //To Represent LayoutManager Properties
            this.sfdiagram.LayoutManager = new LayoutManager { Layout = layoutSettings };

            //PageSettings used to enable the Appearance of Digram Page.
            this.sfdiagram.PageSettings.PageBorderBrush = new SolidColorBrush(Colors.Transparent);

            var data = new ObservableCollection<ItemInfo>();

            //Initialize Method
            this.GetDataSource(data);

            //Initialize DataSourceSettings and Represent ParentId,Id.
            var settings = new DataSourceSettings();
            settings.ParentId = "ReportingPerson";
            settings.Id = "Name";
            settings.DataSource = data;

            this.sfdiagram.DataSourceSettings = settings;
            this.Loaded += MainWindow_Loaded;
            this.sfdiagram.Tool = Tool.ZoomPan;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(ToptoBottomOrientation, "Checked", true);
            pressedButtonName = ToptoBottomOrientation.Name;
        }
        //Get Employee Details 
        private void GetDataSource(ObservableCollection<ItemInfo> data)
        {
            data.Add(new ItemInfo("n11", "#ff6329"));

            data.Add(new ItemInfo("n12", "#ff6329"));

            data.Add(new ItemInfo("n13", "#ff6329"));

            data.Add(new ItemInfo("n21", "#941100") { ReportingPerson = new List<string> { "n11", "n12", "n13" } });

            data.Add(new ItemInfo("n31", "#669be5") { ReportingPerson = new List<string> { "n21" } });

            data.Add(new ItemInfo("n32", "#669be5") { ReportingPerson = new List<string> { "n21" } });

            data.Add(new ItemInfo("n41", "#30ab5c") { ReportingPerson = new List<string> { "n31" } });

            data.Add(new ItemInfo("n42", "#30ab5c") { ReportingPerson = new List<string> { "n31" } });

            data.Add(new ItemInfo("n43", "#30ab5c") { ReportingPerson = new List<string> { "n31" } });

            data.Add(new ItemInfo("n44", "#30ab5c") { ReportingPerson = new List<string> { "n31", "n32" } });

            data.Add(new ItemInfo("n45", "#30ab5c") { ReportingPerson = new List<string> { "n32" } });

            data.Add(new ItemInfo("n46", "#30ab5c") { ReportingPerson = new List<string> { "n32" } });

            data.Add(new ItemInfo("n47", "#30ab5c") { ReportingPerson = new List<string> { "n32" } });

            data.Add(new ItemInfo("n51", "#ff9400") { ReportingPerson = new List<string> { "n41", "n42", "n43" } });

            data.Add(new ItemInfo("n52", "#ff9400") { ReportingPerson = new List<string> { "n45", "n46", "n47" } });

            data.Add(new ItemInfo("n61", "#99bb55") { ReportingPerson = new List<string> { "n51" } });

            data.Add(new ItemInfo("n62", "#99bb55") { ReportingPerson = new List<string> { "n51" } });

            data.Add(new ItemInfo("n63", "#99bb55") { ReportingPerson = new List<string> { "n51", "n44" } });

            data.Add(new ItemInfo("n64", "#99bb55") { ReportingPerson = new List<string> { "n44", "n52" } });

            data.Add(new ItemInfo("n65", "#99bb55") { ReportingPerson = new List<string> { "n52" } });

            data.Add(new ItemInfo("n66", "#99bb55") { ReportingPerson = new List<string> { "n52" } });
        }

        private void Orientation_OnClick(object sender, RoutedEventArgs e)
        {
            var layoutInfo = this.sfdiagram.LayoutManager.Layout as DirectedTreeLayout;
            if (layoutInfo != null)
            {
                var newElement = sender as ToggleButton;
                if (this.previousPressedElement != null && this.previousPressedElement != newElement)
                {
                    VisualStateManager.GoToState(this.previousPressedElement, "Normal", true);
                }

                //this.previousPressedElement = newElement;
                this.pressedButtonName = (newElement).Name;
                switch (this.pressedButtonName)
                {
                    case "ToptoBottomOrientation":
                        layoutInfo.Orientation = TreeOrientation.TopToBottom;
                        break;
                    case "BottomtoTopOrientation":
                        layoutInfo.Orientation = TreeOrientation.BottomToTop;
                        break;
                    case "LefttoRightOrientation":
                        layoutInfo.Orientation = TreeOrientation.LeftToRight;
                        break;
                    case "RighttoLeftOrientation":
                        layoutInfo.Orientation = TreeOrientation.RightToLeft;
                        break;

                }
                layoutInfo.UpdateLayout();
            }
        }

        private void Orientation_OnMouseLeave(object sender, MouseEventArgs e)
        {
            var newElement = sender as ToggleButton;
            if (this.pressedButtonName.Equals(newElement.Name))
            {
                if (previousPressedElement == null)
                {
                    previousPressedElement = sender as ToggleButton;
                    VisualStateManager.GoToState(ToptoBottomOrientation, "Normal", true);
                }
                else if (previousPressedElement != sender as ToggleButton)
                {
                    VisualStateManager.GoToState(previousPressedElement as ToggleButton, "Normal", true);
                    previousPressedElement = sender as ToggleButton;
                }
                VisualStateManager.GoToState(newElement, "Checked", true);
            }
            else
            {
                VisualStateManager.GoToState(newElement, "Normal", true);
            }
        }

        private void Orientation_OnMouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(sender as ToggleButton, "MouseEnter", true);
        }
    }

    public class ItemInfo
    {
        public ItemInfo(string name, string color)
        {
            this.Name = name;
            this.RatingColor = color;
            this.Height = 40;
            this.Width = 40;
        }

        public string RatingColor { get; set; }

        public string Name { get; set; }

        public List<string> ReportingPerson { get; set; }
        public  double Width { get; set; }
        public double Height { get; set; }
    }

    public class CustomConnectorViewModel : ConnectorViewModel
    {
        public CustomConnectorViewModel()
            : base()
        {
            this.CornerRadius = 10;
        }
    }
}