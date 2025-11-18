using Microsoft.Xaml.Behaviors;
using Newtonsoft.Json;
using syncfusion.demoscommon.wpf;
using Syncfusion.Data;
using Syncfusion.Data.Extensions;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Controls.Notification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.datagriddemos.wpf
{
    public class AIFilterPredicatesBehavior : Behavior<AIFilterPredicatesDemo>
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
        /// Holds the schema of the AIFilterPredicate.
        /// </summary>
        private string schema;

        /// <summary>
        /// Called when attached.
        /// </summary>
        protected override void OnAttached()
        {
            semanticKernelAIService = new SemanticKernelAI();
            schema = GetSerializedFilterPredicate();
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
        private void OnExecutePrompt(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplyFiltersBasedOnAIQuery();
        }

        /// <summary>
        /// Event handler for the reset button click event.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The routed event args.</param>
        private void OnReset(object sender, System.Windows.RoutedEventArgs e)
        {
            queryTextBox.Text = null;
            dataGrid.Columns.ForEach(column =>
            {
                column.FilterPredicates.Clear();
            });
        }

        /// <summary>
        /// Applies filters to the data grid based on a query processed by an AI service.
        /// </summary>
        public async void ApplyFiltersBasedOnAIQuery()
        {
            if (!string.IsNullOrEmpty(queryTextBox.Text))
            {
                var gridReportJson = GetSerializedGridReport(new EmployeeInfo());
                string userInput = ValidateAndGeneratePrompt(schema, queryTextBox.Text, gridReportJson);
                if (userInput != null && semanticKernelAIService.IsCredentialsValid())
                {
                    busyIndicator.Visibility = Visibility.Visible;
                    busyIndicator.IsBusy = true;
                    result = await semanticKernelAIService.GetResponseFromGPT(userInput);
                    if (!string.IsNullOrEmpty(result))
                    {
                        try
                        {
                            result = result.Replace("json", "").Replace("```", "").Replace("\n", "");
                            string[] datas = result.Split(new char[] { ';' });
                            List<AIFilterPredicate> filterPredicates = new List<AIFilterPredicate>();
                            foreach (var data in datas)
                            {
                                if (!string.IsNullOrEmpty(data))
                                    filterPredicates.Add(GetDeserializedFilterPredicate(data));
                            }
                            for (int i = 0; i < filterPredicates.Count; i++)
                            {
                                if(filterPredicates[i].ColumnName != null && this.dataGrid.Columns.Any(x=>x.MappingName == filterPredicates[i].ColumnName) && filterPredicates[i].FilterPredicate != null)
                                    dataGrid.Columns[filterPredicates[i].ColumnName].FilterPredicates.Add(filterPredicates[i].FilterPredicate);
                                else
                                {
                                    busyIndicator.IsBusy = false;
                                    busyIndicator.Visibility = Visibility.Hidden;
                                    MessageBox.Show("Invalid ColumnName / FilterPredicates. Kindly provide a proper query.");
                                    return;
                                }
                            }
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
                    }
                }
            }
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
        /// Serializes the <see cref="AIFilterPredicate"/> object into a JSON string.
        /// </summary>
        private string GetSerializedFilterPredicate()
        {
            return "{\r\n  \"definitions\": {\r\n    \"FilterPredicate\": {\r\n      \"type\": [\r\n        \"object\",\r\n        \"null\"\r\n      ],\r\n      \"properties\": {\r\n        \"FilterType\": {\r\n          \"type\": \"string\",\r\n          \"enum\": [\r\n            \"LessThan\",\r\n            \"LessThanOrEqual\",\r\n            \"Equals\",\r\n            \"NotEquals\",\r\n            \"GreaterThanOrEqual\",\r\n            \"GreaterThan\",\r\n            \"StartsWith\",\r\n            \"NotStartsWith\",\r\n            \"EndsWith\",\r\n            \"NotEndsWith\",\r\n            \"Contains\",\r\n            \"NotContains\"\r\n          ]\r\n        },\r\n        \"FilterValue\": {},\r\n        \"PredicateType\": {\r\n          \"type\": \"string\",\r\n          \"enum\": [\r\n            \"And\",\r\n            \"Or\",\r\n            \"AndAlso\",\r\n            \"OrElse\"\r\n          ]\r\n        },\r\n        \"FilterBehavior\": {\r\n          \"type\": \"string\",\r\n          \"enum\": [\r\n            \"StronglyTyped\",\r\n            \"StringTyped\"\r\n          ]\r\n        },\r\n        \"IsCaseSensitive\": {\r\n          \"type\": \"boolean\"\r\n        },\r\n        \"FilterMode\": {\r\n          \"type\": \"string\",\r\n          \"enum\": [\r\n            \"Value\",\r\n            \"DisplayText\"\r\n          ]\r\n        }\r\n      },\r\n      \"required\": [\r\n        \"FilterType\",\r\n        \"FilterValue\",\r\n        \"PredicateType\",\r\n        \"FilterBehavior\",\r\n        \"IsCaseSensitive\",\r\n        \"FilterMode\"\r\n      ]\r\n    }\r\n  },\r\n  \"type\": \"object\",\r\n  \"properties\": {\r\n    \"ColumnName\": {\r\n      \"type\": [\r\n        \"string\",\r\n        \"null\"\r\n      ]\r\n    },\r\n    \"FilterPredicate\": {\r\n      \"$ref\": \"#/definitions/FilterPredicate\"\r\n    }\r\n  },\r\n  \"required\": [\r\n    \"ColumnName\",\r\n    \"FilterPredicate\"\r\n  ]\r\n}";
        }

        /// <summary>
        /// De-Serializes the provided string into a  <see cref="AIFilterPredicate"/>.
        /// </summary>
        /// <param name="report">String to be Deserialized.</param>
        private AIFilterPredicate GetDeserializedFilterPredicate(string report)
        {
            return JsonConvert.DeserializeObject<AIFilterPredicate>(report);
        }
        /// <summary>
        /// Validates the provided text and generates a formatted prompt string based on the specified model.
        /// </summary>
        /// <param name="text">The text representing the condition or query for filtering.</param>
        /// <param name="model">Generate the conditions based on model.</param>    
        private static string ValidateAndGeneratePrompt(string filterPredicate, string text, string model)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            return $"Generate the JSON of type AIFilterPredicate to filter the model\nModel : {model} for the given query\nQuery : {text} and the AIFilterPredicate schema is AIFilterPredicate : {filterPredicate}. Do not provide any additional information except the AIFilterPredicate as JSON object. If more than one AIFilterPredicate then seperate AIFilterPredicates using semi-colon. Rules for providing the responses : Should not include any unwanted brackets or special characters. Filter predicates should be separated by using a semicolon.";
        }

        /// <summary>
        /// Called when detached.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.executePromptButton.Click -= OnExecutePrompt;
            this.AssociatedObject.resetButton.Click -= OnReset;
            this.AssociatedObject.queryTextBox.KeyDown -= QueryTextBox_KeyDown;
            schema = string.Empty;
        }
    }
}
