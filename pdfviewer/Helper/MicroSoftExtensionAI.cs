#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;
using Microsoft.Extensions.AI;
using Azure.AI.OpenAI;
using System.Collections.Generic;

namespace syncfusion.pdfviewerdemos.wpf
{
    internal class MicroSoftExtensionAI
    {
        private static IChatClient clientAI;

        /// <summary>
        /// Initializes a new instance of the <see cref="MicroSoftExtensionAI"/> class.
        /// </summary>
        /// <param name="key">Key for the semantic kernal API</param>
        public MicroSoftExtensionAI(string apikey, string endPoint, string modelName)
        {
            clientAI = new AzureOpenAIClient(new System.Uri(endPoint), new System.ClientModel.ApiKeyCredential(apikey)).AsChatClient(modelName);
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
                if (AISettings.ClientAI != null)
                {
                    //// Send the chat completion request to the OpenAI API and await the response.
                    var response = await AISettings.ClientAI.CompleteAsync(systemPrompt);
                    return response.ToString();
                }
            }
            catch
            {
                // Return an empty string if an exception occurs
                return " ";
            }
            return " ";
        }
        /// <summary>
        /// Method to get the answer from GPT using the semantic kernel
        /// </summary>
        /// <param name="extractedText">Extracted text from the document</param>
        /// <returns>Returns the form data as a string</returns>
        public async Task<string> SummarizePdf(string extractedText)
        {
            if (AISettings.ClientAI != null)
            {
                string systemPrompt = "You are a helpful assistant. Your task is to analyze the provided text and generate short summary as a plain text";
                var chatMessages = new List<ChatMessage>
                {
                    new ChatMessage(ChatRole.System, systemPrompt),
                    new ChatMessage(ChatRole.User, extractedText)
                };
                var response = await AISettings.ClientAI.CompleteAsync(chatMessages);
                return response.ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// Method to get the answer from GPT using the semantic kernel
        /// </summary>
        /// <param name="systemPrompt">Prompt for the system message</param>
        /// <param name="userText">User text for the AI</param>
        /// <returns>Returns the form data as a string</returns>
        public async Task<string> GetAnswerFromGPT(string systemPrompt, string userText)
        {
            if (AISettings.ClientAI != null)
            {
                var chatMessages = new List<ChatMessage>
                {
                    new ChatMessage(ChatRole.System, systemPrompt),
                    new ChatMessage(ChatRole.User, userText)
                };

                var result = await AISettings.ClientAI.CompleteAsync(chatMessages);
                return result.ToString();
            }
            return string.Empty;
        }
    }
}
