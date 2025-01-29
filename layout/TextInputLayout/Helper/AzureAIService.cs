#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.layoutdemos.wpf
{
    using System.Threading.Tasks;
    using syncfusion.demoscommon.wpf;
    using Microsoft.SemanticKernel.ChatCompletion;
    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.Connectors.OpenAI;

    /// <summary>
    /// Helper class to interact with Azure AI.
    /// </summary>
    internal class AzureOpenAIServiceConnector
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
                // Return an empty string if an exception occurs.
                return " ";
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