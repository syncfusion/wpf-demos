#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace syncfusion.chartdemos.wpf
{
    public abstract class AzureBaseService
    {
        #region Fields
        
        /// <summary>
        /// The API key
        /// </summary>
        private const string key = "key";

        /// <summary>
        /// The EndPoint
        /// </summary>
        private const string endpoint = "https://YOUR_ACCOUNT.openai.azure.com/";

        /// <summary>
        /// The Deployment name
        /// </summary>
        internal const string deploymentName = "deployment name";

        /// <summary>
        /// The Image Deployment name
        /// </summary>
        internal const string imageDeploymentName = "IMAGE_MODEL_NAME";

        /// <summary>
        /// The chatCompletions
        /// </summary>
        private IChatCompletionService chatCompletions;

        /// <summary>
        /// The kernel
        /// </summary>
        private Kernel kernel;

        /// <summary>
        /// The chatHistory
        /// </summary>
        private ChatHistory chatHistory;

        private static bool isCredentialValid = false;

        private static bool isAlreadyValidated = false;

        private Uri uriResult;

        #endregion

        public AzureBaseService()
        {
            ValidateCredential();
        }

        #region Properties

        /// <summary>
        /// Gets or Set a value indicating whether an credentials are valid or not.
        /// Returns <c>true</c> if the credentials are valid; otherwise, <c>false</c>.
        /// </summary>
        public static bool IsCredentialValid
        {
            get
            {
                return isCredentialValid;
            }
            set
            {
                isCredentialValid = value;
            }
        }

        public ChatHistory ChatHistory
        {
            get
            {
                return chatHistory;
            }
            set
            {
                chatHistory = value;
            }
        }

        public IChatCompletionService ChatCompletions
        {
            get
            {
                return chatCompletions;
            }
            set
            {
                chatCompletions = value;
            }
        }

        public Kernel Kernel
        {
            get
            {
                return kernel;
            }
            set
            {
                kernel = value;
            }
        }

        #endregion

        #region Private Methods

        private void GetAzureOpenAIKernal()
        {
            // Create the chat history
            chatHistory = new ChatHistory();
            var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(deploymentName, endpoint, key);

            // Get the kernal from build
            kernel = builder.Build();

            //Get the chat completions from kernal
            chatCompletions = kernel.GetRequiredService<IChatCompletionService>();
        }

        /// <summary>
        /// Validate Azure Credentials
        /// </summary>
        private async void ValidateCredential()
        {
            this.GetAzureOpenAIKernal();

            if (isAlreadyValidated)
            {
                return;
            }
            
            try
            {
                ChatHistory.AddSystemMessage("Hello, Test Check");
                await chatCompletions.GetChatMessageContentAsync(chatHistory: ChatHistory, kernel: kernel);
            }
            catch (Exception)
            {
                ShowAlertAsync();
                return;
            }

            IsCredentialValid = true;
            isAlreadyValidated = true;
        }

        /// <summary>
        /// Show Alert Popup
        /// </summary>
        private async void ShowAlertAsync()
        {
            if (!IsCredentialValid && !isAlreadyValidated)
            {
                isAlreadyValidated = true;
                MessageBox.Show("The Azure API key or endpoint is missing or incorrect. Please verify your credentials. You can also continue with the offline data.",
                                "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);

                await Task.CompletedTask; 
            }
        }

        #endregion
    }
}