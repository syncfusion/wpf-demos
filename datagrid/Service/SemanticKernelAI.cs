#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using syncfusion.demoscommon.wpf;
using System.Threading.Tasks;
using System;
using System.Windows;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Provides access to the SemanticKernel service for performing AI operations.
    /// </summary>
    public class SemanticKernelAI
    {
        /// <summary>
        /// Holds the IChatCompletionService instance.
        /// </summary>
        private IChatCompletionService chatCompletionService;

        /// <summary>
        /// Holds the Kernel instance.
        /// </summary>
        private Kernel kernel;

        /// <summary>
        /// Method to get the response from GPT using the semantic kernel
        /// </summary>
        /// <param name="prompt">Prompt for the system message</param>
        /// <returns>The AI results.</returns>
        public async Task<string> GetResponseFromGPT(string prompt)
        {
            try
            {
                var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(AISettings.ModelName, AISettings.EndPoint, AISettings.Key);
                kernel = builder.Build();
                chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

                var history = new ChatHistory();
                history.AddSystemMessage(prompt);
                OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings();
                openAIPromptExecutionSettings.ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions;
                var result = await chatCompletionService.GetChatMessageContentAsync(
                history,
                executionSettings: openAIPromptExecutionSettings,
                kernel: kernel);

                return result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                // Return an empty string if an exception occurs
                return string.Empty;
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