#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.mapdemos.wpf
{
    using Microsoft.Xaml.Behaviors;
    using Newtonsoft.Json.Linq;
    using syncfusion.demoscommon.wpf;
    using Syncfusion.UI.Xaml.Maps;
    using Syncfusion.Windows.Controls.Input;
    using Syncfusion.Windows.Controls.Notification;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Represents a behavior that enhances the functionality of a <see cref="LocationIndicator"/> control.
    /// This behavior provides additional logic or interaction for location indicators.
    public class LocationIndicatorBehavior : Behavior<LocationIndicator>
    {
        /// <summary>
        /// Holds the maps.
        /// </summary>
        private SfMap map;

        /// <summary>
        /// Holds the imagery layer instance.
        /// </summary>
        private ImageryLayer imageLayer;

        /// <summary>
        /// Holds the auto complete instance.
        /// </summary>
        private SfTextBoxExt autoCompleteTextBox;

        /// <summary>
        /// Holds the button instance.
        /// </summary>
        private Button searchButton;

        /// <summary>
        /// Holds the busy indicator instance.
        /// </summary>
        private SfBusyIndicator busyIndicator;

        /// <summary>
        /// Holds the azure AI service instance.
        /// </summary>
        private AzureAIService azureAIService = new AzureAIService();

        /// <summary>
        /// Holds the maps data helper instance.
        /// </summary>
        private MapsDataHelper dataHelper = new MapsDataHelper();

        /// <summary>
        /// Holds the model collection instance.
        /// </summary>
        private ObservableCollection<LocationInfo> viewModel = new ObservableCollection<LocationInfo>();

        /// <summary>
        /// Holds the location indicator view model.
        /// </summary>
        private LocationIndicatorViewModel locationIndicatorViewModel = new LocationIndicatorViewModel();

        /// <summary>
        /// Indicates whether the credentials provided are valid.
        /// </summary>
        private bool isValidCredentials = false;

        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new RoutedEventHandler(this.OnAssociatedObjectLoaded);

            // Previously, credential validation was handled in OnLoaded, which caused issues during theme switching.
            // Now, we ensure the credential status is checked during behavior attachment to avoid such problems.
            this.isValidCredentials = this.azureAIService.IsCredentialsValid();
        }

        /// <summary>
        /// Handles the loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            this.map = this.AssociatedObject.map;
            this.imageLayer = this.AssociatedObject.imageLayer;
            this.autoCompleteTextBox = this.AssociatedObject.autoCompleteTextBox;
            this.searchButton = this.AssociatedObject.searchButton;
            this.busyIndicator = this.AssociatedObject.busyIndicator;
            if (!this.isValidCredentials)
            {
                this.autoCompleteTextBox.NoResultsFoundTemplate = this.CreateDataTemplate();
                this.autoCompleteTextBox.AutoCompleteSource = locationIndicatorViewModel.DataOptions;
            }

            if (this.searchButton != null)
            {
                this.searchButton.Click += this.OnSearchButtonClick;
            }
        }

        /// <summary>
        /// Return the auto complete no result found template.
        /// </summary>
        /// <returns>Data template.</returns>
        private DataTemplate CreateDataTemplate()
        {
            var textBlock = new FrameworkElementFactory(typeof(TextBlock));
            textBlock.SetValue(TextBlock.TextProperty, "Offline search only provides results for “hospitals in New York” and “hotels in Denver.” To get more results, connect to the internet and OpenAI.");
            textBlock.SetValue(TextBlock.FontSizeProperty, 12.0);
            textBlock.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);
            textBlock.SetValue(TextBlock.WidthProperty, 300.0);

            return new DataTemplate { VisualTree = textBlock };
        }

        /// <summary>
        /// Method to button click changed.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The routed event args.</param>
        private async void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            await GetRecommendationAsync(this.autoCompleteTextBox.Text);
            this.busyIndicator.Visibility = Visibility.Hidden;
            this.busyIndicator.IsBusy = false;
        }

        /// <summary>
        /// Method to contain AI respose and updates.
        /// </summary>
        /// <param name="userQuery">The user query.</param>
        /// <returns>The task details.</returns>
        private async Task GetRecommendationAsync(string userQuery)
        {
            if (this.autoCompleteTextBox == null || this.imageLayer == null || this.map == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(this.autoCompleteTextBox.Text))
            {
                return;
            }

            if (this.busyIndicator != null)
            {
                this.busyIndicator.Visibility = Visibility.Visible;
                this.busyIndicator.IsBusy = true;
            }

            var returnMessage = string.Empty;

            if (AISettings.IsCredentialValid)
            {
                string prompt = $"Given location name: {userQuery}" +
             $"\nSome conditions need to follow:" +
             $"\nCheck the location name is just a state, city, capital or region, then retrieve the following fields: location name, detail, latitude, longitude, and set address value as null" +
             $"\nOtherwise, retrieve minimum 5 to 6 entries with following fields: location's name, details, latitude, longitude, address." +
             $"\nThe return format should be the following JSON format: markercollections[Name, Details, Latitude, Longitude, Address]" +
             $"\nRemove ```json and remove ``` if it is there in the code." +
             $"\nProvide JSON format details only, No need any explanation.";

                returnMessage = await azureAIService.GetResponseFromOpenAI(prompt);
            }

            try
            {
                var jsonObj = new JObject();
                if (returnMessage == string.Empty)
                {
                    if (this.autoCompleteTextBox.Text == "Hospitals in New York")
                    {
                        jsonObj = JObject.Parse(this.dataHelper.hospitalsData);
                    }
                    else if (this.autoCompleteTextBox.Text == "Hotels in Denver")
                    {
                        jsonObj = JObject.Parse(dataHelper.hotelsData);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    jsonObj = JObject.Parse(returnMessage);
                }

                this.viewModel.Clear();
                foreach (var marker in jsonObj["markercollections"])
                {
                    LocationInfo model = new LocationInfo();
                    model.Name = (string)marker["Name"];
                    model.Details = (string)marker["Details"];
                    model.Latitude = (string)marker["Latitude"];
                    model.Longitude = (string)marker["Longitude"];
                    model.Address = (string)marker["Address"];
                    if (AISettings.IsCredentialValid)
                    {
                        model.ImageSource = await azureAIService.GetImageFromAI(model.Name);
                    }
                    this.viewModel.Add(model);
                }

                this.imageLayer.Markers = this.viewModel;
                if (this.viewModel.Count > 0)
                {
                    var firstMarker = this.viewModel[0];
                    double latitude, longitude;
                    if (double.TryParse(firstMarker.Latitude, out latitude) && double.TryParse(firstMarker.Longitude, out longitude))
                    {
                        this.imageLayer.Center = new Point(latitude, longitude);
                    }
                }

                this.map.ZoomLevel = 10;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new RoutedEventHandler(this.OnAssociatedObjectLoaded);
            this.AssociatedObject.searchButton.Click -= this.OnSearchButtonClick;
        }
    }
}