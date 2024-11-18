#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.layoutdemos.wpf
{
    using System;
    using Microsoft.Xaml.Behaviors;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.UI.Xaml.TextInputLayout;
    using syncfusion.demoscommon.wpf;
    using System.Threading.Tasks;
    using System.Windows.Shapes;
    using System.Windows.Media;

    /// <summary>
    /// Represents the behavior for the feedback form.
    /// </summary>
    internal class FeedbackFormBehavior : Behavior<FeedbackFormSmartFill>
    {
        private readonly string mailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])\." + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
        /// <summary>
        /// The smart paste button.
        /// </summary>
        private Button smartPasteButton;

        /// <summary>
        /// The submit button.
        /// </summary>
        private Button submitButton;

        /// <summary>
        /// It holds the feedback form view model.
        /// </summary>
        private FeedbackFormViewModel feedbackFormViewModel;

        /// <summary>
        /// Holds the clipboard text.
        /// </summary>
        private string clipboardText;

        /// <summary>
        /// It holds the copied button1.
        /// </summary>
        private Button copiedButton1;

        /// <summary>
        /// It holds the copied button2.
        /// </summary>
        private Button copiedButton2;

        /// <summary>
        /// It holds the copied button3.
        /// </summary>
        private Button copiedButton3;

        /// <summary>
        /// Holds the input data 1.
        /// </summary>
        private TextBlock inputData1;

        /// <summary>
        /// Holds the input data 2.
        /// </summary>
        private TextBlock inputData2;

        /// <summary>
        /// Holds the input data 3.
        /// </summary>
        private TextBlock inputData3;

        /// <summary>
        /// Flag suspends validation till submit button clicked.
        /// </summary>
        private bool canValidateForErrors;

        /// <summary>
        /// Holds the name text input layout.
        /// </summary>
        private SfTextInputLayout nameTextInputLayout;

        /// <summary>
        /// Holds the email text input layout instance.
        /// </summary>
        private SfTextInputLayout emailTextInputLayout;

        /// <summary>
        /// Holds the product name text input layout.
        /// </summary>
        private SfTextInputLayout productNameTextInputLayout;

        /// <summary>
        /// Holds the product name text input layout.
        /// </summary>
        private SfTextInputLayout productVersionTextInputLayout;

        /// <summary>
        /// Holds the rating text input layout.
        /// </summary>
        private SfTextInputLayout ratingTextInputLayout;

        /// <summary>
        /// Holds the comments text input layout.
        /// </summary>

        private SfTextInputLayout commentsTextInputLayout;

        /// <summary>
        /// It holds the azure AI service instance.
        /// </summary>
        private AzureOpenAIServiceConnector azureAIService = new AzureOpenAIServiceConnector();

        /// <summary>
        /// It holds the index. There are 3 product feedback details in the feedback form model. The index is used to get the feedback details.
        /// </summary>
        int index = -1;

        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += this.OnAssociatedObjectLoaded;
        }

        /// <summary>
        /// Handles the loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The routed event args.</param>
        private void OnAssociatedObjectLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.copiedButton1 = this.AssociatedObject.CopiedButton1;
            this.copiedButton2 = this.AssociatedObject.CopiedButton2;
            this.copiedButton3 = this.AssociatedObject.CopiedButton3;

            this.inputData1 = this.AssociatedObject.InputData1;
            this.inputData2 = this.AssociatedObject.InputData2;
            this.inputData3 = this.AssociatedObject.InputData3;

            this.nameTextInputLayout = this.AssociatedObject.nameTextInputLayout;
            this.emailTextInputLayout = this.AssociatedObject.emailTextInputLayout;
            this.productNameTextInputLayout = this.AssociatedObject.productNameTextInputLayout;
            this.productVersionTextInputLayout = this.AssociatedObject.prodectVersionTextInputLayout;
            this.ratingTextInputLayout = this.AssociatedObject.ratingTextInputLayout;
            this.commentsTextInputLayout = this.AssociatedObject.commentsTextInputLayout;

            this.smartPasteButton = this.AssociatedObject.smartPasteButton;
            this.submitButton = this.AssociatedObject.submitButton;

            this.feedbackFormViewModel = this.AssociatedObject.textInputLayoutViewModel;
            if (this.azureAIService != null)
            {
                this.azureAIService.IsCredentialsValid();
            }

            // Unwire events, while switching theme events called multiple times issue.
            this.UnWireEvents();

            this.submitButton.Click += this.OnSubmitButtonClicked;
            this.smartPasteButton.Click += this.OnSmartPasteButtonClicked;

            this.copiedButton1.Click += this.OnCopyTextToClipboardButtonClicked;
            this.copiedButton2.Click += this.OnCopyTextToClipboardButtonClicked;
            this.copiedButton3.Click += this.OnCopyTextToClipboardButtonClicked;
        }

        /// <summary>
        /// Event handler for the copy text to clipboard on button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private async void OnCopyTextToClipboardButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Path path = button.Content as Path;
                if (path == null)
                {
                    return;
                }

                path.Data = Geometry.Parse("M1 4.75L4 7.75L10.75 1");
                path.Width = 12;
                path.Height = 9;
                switch (button.Name)
                {
                    case "CopiedButton1":
                        this.index = 0;
                        Clipboard.SetText(this.inputData1.Text);
                        break;
                    case "CopiedButton2":
                        this.index = 1;
                        Clipboard.SetText(this.inputData2.Text);
                        break;
                    case "CopiedButton3":
                        this.index = 2;
                        Clipboard.SetText(this.inputData3.Text);
                        break;
                }

                await Task.Delay(4000);
                path.Data = Geometry.Parse("M9.5 15.5H3.5C1.84315 15.5 0.5 14.1569 0.5 12.5V2.50002M4 13.5H10C10.8284 13.5 11.5 12.8284 11.5 12V2C11.5 1.17157 10.8284 0.5 10 0.5H4C3.17157 0.5 2.5 1.17157 2.5 2V12C2.5 12.8284 3.17157 13.5 4 13.5Z");
                path.Width = 12;
                path.Height = 16;
            }
        }

        // <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= this.OnAssociatedObjectLoaded;
            this.UnWireEvents();
        }

        /// <summary>
        /// Method to unwire events.
        /// </summary>
        private void UnWireEvents()
        {
            this.smartPasteButton.Click -= this.OnSmartPasteButtonClicked;
            this.submitButton.Click -= this.OnSubmitButtonClicked;
            this.copiedButton1.Click -= this.OnCopyTextToClipboardButtonClicked;
            this.copiedButton2.Click -= this.OnCopyTextToClipboardButtonClicked;
            this.copiedButton3.Click -= this.OnCopyTextToClipboardButtonClicked;
        }

        /// <summary>
        /// Method to fill the data form with the selected product details. This button is enabled only the open ai key is set.
        /// </summary>
        private void UpdateSmartPasteDataForm(string response)
        {
            //// Deserialize the JSON string to a Dictionary
            var openAIJsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            //// Create lists to hold field names and values
            var filedNames = new List<string>();
            var fieldValues = new List<string>();
            foreach (var data in openAIJsonData)
            {
                filedNames.Add(data.Key);
                fieldValues.Add(data.Value?.ToString() ?? string.Empty);
            }

            this.feedbackFormViewModel.FeedbackForm.Name = fieldValues[0];
            this.feedbackFormViewModel.FeedbackForm.Email = fieldValues[1];
            this.feedbackFormViewModel.FeedbackForm.ProductName = fieldValues[2];
            this.feedbackFormViewModel.FeedbackForm.ProductVersion = fieldValues[3];
            this.feedbackFormViewModel.FeedbackForm.Rating = fieldValues[4];
            this.feedbackFormViewModel.FeedbackForm.Comments = fieldValues[5];
        }

        /// <summary>
        /// Method to update the data form smart paste data.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private async void OnSmartPasteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                this.clipboardText = Clipboard.GetText();
            }
            else
            {
                this.clipboardText = string.Empty;
            }

            if (string.IsNullOrEmpty(this.clipboardText))
            {
                MessageBox.Show("Please copy the data to paste", "Information", MessageBoxButton.OK);
                return;
            }

            string finalResponse = string.Empty;
            if (!AISettings.IsCredentialValid)
            {
                if (this.index == -1)
                {
                    MessageBox.Show("Please copy the data to paste", "Information", MessageBoxButton.OK);
                    return;
                }

                this.UpdateTextInputLayouts();
                finalResponse = this.feedbackFormViewModel.FeedbackForms[this.index];
                this.UpdateSmartPasteDataForm(finalResponse);
                return;
            }

            string dataFormJsonData = JsonConvert.SerializeObject(this.feedbackFormViewModel.FeedbackForm);
            string prompt = $"Merge the copied data into the DataForm field content, ensuring that the copied text matches suitable field names. Here are the details:" +
                  $"\n\nCopied data: {this.clipboardText}," +
                  $"\nDataForm Field Name: {dataFormJsonData}," +
                  $"\nProvide the resultant DataForm directly." +
                  $"\n\nConditions to follow:" +
                  $"\n1. Do not use the copied text directly as the field name; merge appropriately." +
                  $"\n2. Ignore case sensitivity when comparing copied text and field names." +
                  $"\n3. Final output must be Json format" +
                  $"\n4. No need any explanation or comments in the output" +
                  $"\n5. Please provide the valid JSON object without any additional formatting characters like backticks or newlines";

            finalResponse = await azureAIService.GetResponseFromOpenAI(prompt);
            this.UpdateSmartPasteDataForm(finalResponse);
        }

        /// <summary>
        /// Method to update the details on submit button clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void OnSubmitButtonClicked(object sender, RoutedEventArgs e)
        {
            this.UpdateTextInputLayouts();
            if (this.IsValidAllFields())
            {
                MessageBox.Show("Feedback submitted successfully", "Success", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Please enter valid details", "Error", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Method to update the all the text input layout.
        /// </summary>
        private void UpdateTextInputLayouts()
        {
            this.nameTextInputLayout.HasError = false;
            this.emailTextInputLayout.HasError = false;
            this.productNameTextInputLayout.HasError = false;
            this.productVersionTextInputLayout.HasError = false;
            this.ratingTextInputLayout.HasError = false;
            this.commentsTextInputLayout.HasError = false;
        }

        /// <summary>
        /// Validates all the fields in the feedback form.
        /// </summary>
        /// <returns>Returns true if all the fields valid</returns>
        private bool IsValidAllFields()
        {
            bool isValidForm = true;
            FeedbackForm feedbackForm = this.feedbackFormViewModel.FeedbackForm;
            //// Name Validation.
            if (string.IsNullOrEmpty(feedbackForm.Name))
            {
                isValidForm = false;
                this.nameTextInputLayout.HasError = true;
                this.nameTextInputLayout.ErrorText = "Enter your name";
            }
            else if (feedbackForm.Name.Length > 20)
            {
                isValidForm = false;
                this.nameTextInputLayout.HasError = true;
                this.nameTextInputLayout.ErrorText = "Name cannot exceed 20 characters";
            }

            //// Email Validation.
            if (string.IsNullOrEmpty(feedbackForm.Email))
            {
                isValidForm = false;
                this.emailTextInputLayout.HasError = true;
                this.emailTextInputLayout.ErrorText = "Enter your email";
            }
            else if (!Regex.IsMatch(this.feedbackFormViewModel.FeedbackForm.Email, this.mailPattern))
            {
                isValidForm = false;
                this.emailTextInputLayout.HasError = true;
                this.emailTextInputLayout.ErrorText = "Please enter a valid email address.";
            }

            //// Product Name Validation.
            if (string.IsNullOrEmpty(feedbackForm.ProductName))
            {
                isValidForm = false;
                this.productNameTextInputLayout.HasError = true;
                this.productNameTextInputLayout.ErrorText = "Enter product name";
            }
            else if (feedbackForm.ProductName.Length > 20)
            {
                isValidForm = false;
                this.productNameTextInputLayout.HasError = true;
                this.productNameTextInputLayout.ErrorText = "Product name cannot exceed 20 characters";
            }

            //// Product Version Validation.
            if (string.IsNullOrEmpty(feedbackForm.ProductVersion))
            {
                isValidForm = false;
                this.productVersionTextInputLayout.HasError = true;
                this.productVersionTextInputLayout.ErrorText = "Enter product version";
            }

            //// Rating Validation.
            if (string.IsNullOrEmpty(feedbackForm.Rating))
            {
                isValidForm = false;
                this.ratingTextInputLayout.HasError = true;
                this.ratingTextInputLayout.ErrorText = "Enter rating";
            }
            else if (!double.TryParse(feedbackForm.Rating, out double rating))
            {
                isValidForm = false;
                this.ratingTextInputLayout.HasError = true;
                this.ratingTextInputLayout.ErrorText = "Please enter a valid rating";
            }
            else if (rating < 1 || rating > 5)
            {
                isValidForm = false;
                this.ratingTextInputLayout.HasError = true;
                this.ratingTextInputLayout.ErrorText = "Rating should be between 1 and 5";
            }

            //// Comments Validation.
            if (string.IsNullOrEmpty(feedbackForm.Comments))
            {
                isValidForm = false;
                this.commentsTextInputLayout.HasError = true;
                this.commentsTextInputLayout.ErrorText = "Enter your comments";
            }

            return isValidForm;
        }
    }
}