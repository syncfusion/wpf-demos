#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Newtonsoft.Json;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Controls.Notification;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Represents a behavior that enhances the functionality of a <see cref="AIViewFilterDemo"/>.
    /// This behavior provides additional logic or interaction for the AIViewFilterDemo.
    /// </summary>
    public class AIViewFilterBehavior : Behavior<AIViewFilterDemo>
    {
        /// <summary>
        /// Holds the SemanticKernel AI service instance.
        /// </summary>
        private SemanticKernelAI semanticKernelAIService;

        /// <summary>
        /// Holds the data grid instance.
        /// </summary>
        private SfDataGrid dataGrid;

        /// <summary>
        /// Holds the busy indicator instance.
        /// </summary>
        private SfBusyIndicator busyIndicator;

        /// <summary>
        /// Holds the text box instance.
        /// </summary>
        private TextBox queryTextBox;

        /// <summary>
        /// Holds the result of the AI response.
        /// </summary>
        private string result;

        /// <summary>
        /// Called when attached.
        /// </summary>
        protected override void OnAttached()
        {
            semanticKernelAIService = new SemanticKernelAI();
            this.AssociatedObject.Loaded += OnLoaded;
            this.semanticKernelAIService.IsCredentialsValid();
        }

        /// <summary>
        /// Called when the associated object is loaded.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The routed event args.</param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            dataGrid = this.AssociatedObject.dataGrid;
            busyIndicator = this.AssociatedObject.busyIndicator;
            queryTextBox = this.AssociatedObject.queryTextBox;
            this.AssociatedObject.executePromptButton.Click += OnExecutePrompt;
            this.AssociatedObject.resetButton.Click += OnReset;
            this.AssociatedObject.queryTextBox.KeyDown += QueryTextBox_KeyDown;
        }

        /// <summary>
        /// Handles the KeyDown event for the query text box. 
        /// Triggers the application of filters based on an AI query when the Enter key is pressed.
        /// </summary>
        /// <param name="sender">The source of the event, typically the query text box.</param>
        /// <param name="e">The key routed event arguments.</param>
        private void QueryTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
                return;
            ApplyFiltersBasedOnAIQuery();
        }

        /// <summary>
        /// Event handler for the execute prompt button click event.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The routed event args.</param>
        private void OnExecutePrompt(object sender, RoutedEventArgs e)
        {
            ApplyFiltersBasedOnAIQuery();
        }

        /// <summary>
        /// Applies view filters to the data grid based on a user query processed by an AI service.
        /// </summary>
        private async void ApplyFiltersBasedOnAIQuery()
        {
            if (!string.IsNullOrEmpty(queryTextBox.Text))
            {
                var gridReportJson = GetSerializedGridReport(new EmployeeInfo());
                string userInput = ValidateAndGeneratePrompt(queryTextBox.Text, gridReportJson);
                if (userInput != null && semanticKernelAIService.IsCredentialsValid())
                {
                    busyIndicator.Visibility = Visibility.Visible;
                    busyIndicator.IsBusy = true;
                    result = await semanticKernelAIService.GetResponseFromGPT(userInput);
                    if (result != null && dataGrid.Columns.Any(x => result.Contains(x.MappingName)))
                    {
                        try
                        {
                            dataGrid.View.Filter = FilterRecord;
                            dataGrid.View.RefreshFilter();
                            busyIndicator.IsBusy = false;
                            busyIndicator.Visibility = Visibility.Hidden;
                        }
                        catch (Exception ex)
                        {
                            busyIndicator.IsBusy = false;
                            busyIndicator.Visibility = Visibility.Hidden;
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        busyIndicator.IsBusy = false;
                        busyIndicator.Visibility = Visibility.Hidden;
                        if (result != string.Empty)
                            MessageBox.Show("Invalid ColumnName. Kindly provide proper query.");//
                    }
                }
            }
        }

        /// <summary>
        /// Filters the records based on the provided condition.
        /// </summary>
        /// <param name="o">The object to be filtered.</param>
        /// <returns>
        /// <c>true</c> If the object meets the criteria defined by the specified condition; otherwise, <c>false</c>.
        /// </returns>
        private bool FilterRecord(object o)
        {
            var data = o as EmployeeInfo;
            var parameter = System.Linq.Expressions.Expression.Parameter(typeof(EmployeeInfo));
            if ((bool)DynamicExpressionParser.ParseLambda(new[] { parameter }, typeof(bool), result).Compile().DynamicInvoke(data))
                return true;
            return false;
        }

        /// <summary>
        /// Serializes the provided <see cref="EmployeeInfo"/> object into a JSON string.
        /// </summary>
        /// <param name="report">The <see cref="EmployeeInfo"/> object to be serialized.</param>
        /// <returns>A JSON string representation of the <paramref name="report"/>.</returns>
        private string GetSerializedGridReport(EmployeeInfo report)
        {
            return JsonConvert.SerializeObject(report);
        }

        /// <summary>
        /// Validates the provided text and generates a formatted prompt string based on the specified model.
        /// </summary>
        /// <param name="text">The text representing the condition or query for filtering.</param>
        /// <param name="model">Generate the conditions based on model.</param>        
        private static string ValidateAndGeneratePrompt(string text, string model)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            return $"Please specify the condition for filtering using symbols. Provide the property name followed by the condition. For example, to filter employees with a rating greater than 5, you would specify 'Rating > 5' Example for string, to filter employees equal to male, you would specify \"Gender == \"Male\"\". No other additional information needed except the condition. This the model I am using, you can refer this model to get the property name.\nModel : {model} \nQuery : {text}";
        }

        /// <summary>
        /// Event handler for the reset button click event.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The routed event args.</param>
        private void OnReset(object sender, RoutedEventArgs e)
        {
            queryTextBox.Text = string.Empty;
            dataGrid.View.Filter = null; 
            dataGrid.View.RefreshFilter();
        }

        /// <summary>
        /// Called when detached.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.executePromptButton.Click -= OnExecutePrompt;
            this.AssociatedObject.resetButton.Click -= OnReset;
            this.AssociatedObject.queryTextBox.KeyDown -= QueryTextBox_KeyDown;
        }
    }
}