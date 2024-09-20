#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.mapdemos.wpf
{
    using Azure.AI.OpenAI;
    using Azure;
    using System;
    using System.Threading.Tasks;
    using syncfusion.demoscommon.wpf;
    using System.Windows.Media.Imaging;
    using System.Windows.Media;
    using Microsoft.SemanticKernel.ChatCompletion;
    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.Connectors.OpenAI;

    /// <summary>
    /// Provides access to the Azure AI service for performing various AI operations, including chat completions and image-related tasks.
    /// </summary>
    public class AzureAIService
    {
        /// <summary>
        /// Method to get response from AI.
        /// </summary>
        /// <param name="prompt">The user prompt.</param>
        /// <returns>The AI results.</returns>
        public async Task<string> GetResponseFromOpenAI(string prompt)
        {
            IChatCompletionService chatCompletionService;
            Kernel kernel;
            string endpoint = AISettings.EndPoint;
            string key = AISettings.Key;
            string deploymentName = AISettings.ModelName;
            var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(deploymentName, endpoint, key);
            kernel = builder.Build();
            chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

            try
            {
                var chatHistory = new ChatHistory();
                chatHistory.AddSystemMessage(prompt);
                OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings();
                openAIPromptExecutionSettings.ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions;
                var result = await chatCompletionService.GetChatMessageContentAsync(chatHistory, executionSettings: openAIPromptExecutionSettings,
                    kernel: kernel);

                return result.ToString();
            }
            catch
            {
                // Return an empty string if an exception occurs
                return " ";
            }
        }

        /// <summary>
        /// Method to get the image from AI.
        /// </summary>
        /// <param name="locationName"> The location name</param>
        /// <returns>The bitmap image</returns>
        public async Task<ImageSource> GetImageFromAI(string locationName)
        {
            string endpoint = AISettings.EndPoint;
            string key = AISettings.Key;
            AzureKeyCredential credential = new AzureKeyCredential(key);
            OpenAIClient azureClient = new OpenAIClient(new Uri(endpoint), credential);
            try
            {
               var imageGenerations = await azureClient.GetImageGenerationsAsync(
               new ImageGenerationOptions()
               {
                   Prompt = $"Share the {locationName} image.",
                   Size = ImageSize.Size1024x1024,
                   Quality = ImageGenerationQuality.Standard,
                   DeploymentName = "DALL-E",

               });

                Uri imageUri = imageGenerations.Value.Data[0].Url;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = imageUri;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
            catch
            {
                // Return an empty image if an exception occurs.
                return new BitmapImage();
            }
        }

        /// <summary>
        /// Method to verify the credentials.
        /// </summary>
        /// <returns><b>true</b> if the credentials are valid;otherwise <b>false</b></returns>
        internal bool IsCredentialsValid()
        {
            if (!AISettings.IsCredentialValid)
            {
                AISettings.ShowAISettingsWindow();
            }

            return AISettings.IsCredentialValid;
        }
    }
}