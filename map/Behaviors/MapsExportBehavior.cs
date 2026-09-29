namespace syncfusion.mapdemos.wpf
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.SfSkinManager;
    using Syncfusion.UI.Xaml.Maps;

    /// <summary>
    /// Provides export-related behavior for the <see cref="MapExportDemo"/> view, enabling map type switching and exporting maps to various formats.
    /// </summary>
    public class MapsExportBehavior : Behavior<MapExportDemo>
    {
        #region Fields

        /// <summary>
        /// Used to select the map type (Geometry or OSM).
        /// </summary>
        private ComboBox mapTypeComboBox;

        /// <summary>
        /// Used to select the export file format (PNG, JPEG, SVG).
        /// </summary>
        private ComboBox exportTypeComboBox;

        /// <summary>
        /// Used to enter the exported file name.
        /// </summary>
        private TextBox fileNameTextBox;

        /// <summary>
        /// Initiates the map export operation.
        /// </summary>
        private Button exportButton;

        /// <summary>
        /// Map instance displaying geometry-based map data.
        /// </summary>
        private SfMap geometryMap;

        /// <summary>
        /// Map instance displaying OpenStreetMap (OSM) data.
        /// </summary>
        private SfMap osmMap;

        /// <summary>
        /// Helps to restrict the export pop-up calling multiple times.
        /// </summary>
        private bool isInitialized;

        #endregion

        #region Events

        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnAssociatedObjectLoaded;
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            if (this.isInitialized)
            {
                return;
            }

            this.isInitialized = true;
            this.mapTypeComboBox = this.AssociatedObject.FindName("MapTypeComboBox") as ComboBox;
            this.exportTypeComboBox = this.AssociatedObject.FindName("ExportTypeComboBox") as ComboBox;
            this.fileNameTextBox = this.AssociatedObject.FindName("FileNameTextBox") as TextBox;
            this.exportButton = this.AssociatedObject.FindName("ExportButton") as Button;
            this.geometryMap = this.AssociatedObject.FindName("geometryMap") as SfMap;
            this.osmMap = this.AssociatedObject.FindName("osmMap") as SfMap;
            if (this.mapTypeComboBox != null)
            {
                this.mapTypeComboBox.SelectionChanged += this.OnMapTypeComboBoxSelectionChanged;
            }

            if (this.exportButton != null)
            {
                this.exportButton.Click += this.OnExportButtonClick;
            }
        }

        /// <summary>
        /// Handles changes in the selected map type and toggles map visibility between Geometry and OSM maps.
        /// </summary>
        /// <param name="sender">The map type ComboBox.</param>
        /// <param name="e">The event data.</param>
        private void OnMapTypeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.mapTypeComboBox?.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedMapType = selectedItem.Content.ToString();
                if (selectedMapType == "Geometry")
                {
                    this.geometryMap.Visibility = Visibility.Visible;
                    this.osmMap.Visibility = Visibility.Collapsed;
                }
                else if (selectedMapType == "OSM")
                {
                    this.geometryMap.Visibility = Visibility.Collapsed;
                    this.osmMap.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Handles the export button click event. Exports the active map to the selected format and shows a confirmation dialog.
        /// </summary>
        /// <param name="sender">The export button.</param>
        /// <param name="e">The event data.</param>
        private void OnExportButtonClick(object sender, RoutedEventArgs e)
        {
            //ExportFormat exportFormat = this.GetSelectedExportFormat();
            //string fileName = string.IsNullOrWhiteSpace(this.fileNameTextBox.Text) ? "Maps" : this.fileNameTextBox.Text;
            //SfMap activeMap = this.geometryMap.Visibility == Visibility.Visible ? this.geometryMap : this.osmMap;
            //// activeMap.ExportMaps(format: exportFormat, fileName: fileName);
            //var dialog = new Window
            //{
            //    Title = "Export",
            //    Width = 280,
            //    Height = 160,
            //    BorderBrush= new SolidColorBrush(Colors.Black),
            //    ResizeMode = ResizeMode.NoResize,
            //    ShowInTaskbar = false,
            //    WindowStartupLocation = WindowStartupLocation.CenterOwner,
            //    Owner = Window.GetWindow(activeMap)
            //};

            //var root = new Grid();
            //root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //root.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //var contentGrid = new Grid
            //{
            //    Margin = new Thickness(20, 20, 20, 10)
            //};

            //contentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            //contentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            //var iconGrid = new Grid { Width = 32, Height = 32 };
            //iconGrid.Children.Add(new Ellipse
            //{
            //    Fill = Brushes.RoyalBlue,
            //    Stroke = Brushes.DarkBlue,
            //    StrokeThickness = 1
            //});

            //iconGrid.Children.Add(new TextBlock
            //{
            //    Text = "i",
            //    Foreground = Brushes.White,
            //    FontSize = 20,
            //    FontWeight = FontWeights.Bold,
            //    HorizontalAlignment = HorizontalAlignment.Center,
            //    VerticalAlignment = VerticalAlignment.Center
            //});

            //Grid.SetColumn(iconGrid, 0);
            //var messageText = new TextBlock
            //{
            //    Text = "Map exported successfully!",
            //    FontSize = 13,
            //    Margin = new Thickness(15, 4, 0, 0),
            //    VerticalAlignment = VerticalAlignment.Center,
            //    TextWrapping = TextWrapping.Wrap
            //};

            //Grid.SetColumn(messageText, 1);
            //contentGrid.Children.Add(iconGrid);
            //contentGrid.Children.Add(messageText);
            //Grid.SetRow(contentGrid, 0);
            //root.Children.Add(contentGrid);
            //var okButton = new Button
            //{
            //    Content = "OK",
            //    Width = 80,
            //    Height = 26,
            //    Margin = new Thickness(0, 5, 0, 15),
            //    HorizontalAlignment = HorizontalAlignment.Center,
            //};

            //okButton.Click += (_, __) => dialog.DialogResult = true;
            //Grid.SetRow(okButton, 1);
            //root.Children.Add(okButton);
            //dialog.Content = root;
            //SfSkinManager.SetTheme(dialog, SfSkinManager.GetTheme(activeMap));
            //dialog.ShowDialog();
        }

        #endregion

        #region Methods

        ///// <summary>
        ///// Retrieves the export format selected in the export type ComboBox.
        ///// </summary>
        ///// <returns>The selected <see cref="ExportFormat"/>.</returns>
        //private ExportFormat GetSelectedExportFormat()
        //{
        //    if (this.exportTypeComboBox?.SelectedItem is ComboBoxItem selectedItem)
        //    {
        //        return this.GetExportFormat(selectedItem.Content.ToString());
        //    }

        //    return ExportFormat.PNG;
        //}

        ///// <summary>
        ///// Converts a string value to the corresponding <see cref="ExportFormat"/>.
        ///// </summary>
        ///// <param name="format">The format name.</param>
        ///// <returns>The matching <see cref="ExportFormat"/> value.</returns>
        //private ExportFormat GetExportFormat(string format)
        //{
        //    switch (format)
        //    {
        //        case "PNG":
        //            return ExportFormat.PNG;

        //        case "JPEG":
        //            return ExportFormat.JPEG;

        //        case "SVG":
        //            return ExportFormat.SVG;

        //        default:
        //            return ExportFormat.PNG;
        //    }
        //}

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            if (this.mapTypeComboBox != null)
            {
                this.mapTypeComboBox.SelectionChanged -= this.OnMapTypeComboBoxSelectionChanged;
            }

            if (this.exportButton != null)
            {
                this.exportButton.Click -= this.OnExportButtonClick;
            }
              
            AssociatedObject.Loaded -= this.OnAssociatedObjectLoaded;
        }

        #endregion
    }
}