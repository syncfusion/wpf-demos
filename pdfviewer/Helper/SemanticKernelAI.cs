#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfviewerdemos.wpf
{
    internal class SemanticKernelAI
    {

        string endpoint = "YOUR-AI-ENDPOINT";
        string deploymentName = "YOUR-DEPLOYMENT-NAME";
        internal string key = string.Empty;

        IChatCompletionService chatCompletionService;
        Kernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SemanticKernelAI"/> class.
        /// </summary>
        /// <param name="key">Key for the semantic kernal API</param>
        public SemanticKernelAI(string apikey, string endPoint, string modelName)
        {
            this.key = apikey;
            this.endpoint = endPoint;
            this.deploymentName = modelName;
            var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(deploymentName, endpoint, key);
            kernel = builder.Build();
            chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
        }

        /// <summary>
        /// Method to get the answer from GPT using the semantic kernel
        /// </summary>
        /// <param name="systemPrompt">Prompt for the system message</param>
        /// <param name="userText">Input text for the user message</param>
        /// <returns>Returns the sensitive informations as a list</returns>
        public async Task<string> GetAnswerFromGPT(string systemPrompt)
        {
            try
            {
                var history = new ChatHistory();
                history.AddSystemMessage(systemPrompt);
                OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings();
                openAIPromptExecutionSettings.ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions;
                var result = await chatCompletionService.GetChatMessageContentAsync(
                history,
                executionSettings: openAIPromptExecutionSettings,
                kernel: kernel);

                return result.ToString();
            }
            catch
            {
                // Return an empty string if an exception occurs
                return " ";
            }
        }
    }
}
