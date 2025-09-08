#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.layoutdemos.wpf
{
    using Microsoft.Extensions.AI;
    using System.Threading.Tasks;
    using syncfusion.demoscommon.wpf;

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
            try
            {
                if (AISettings.ClientAI != null)
                {
                    //// Send the chat completion request to the OpenAI API and await the response.
                    var response = await AISettings.ClientAI.CompleteAsync(prompt);
                    return response.ToString();
                }
            }
            catch
            {
                // Return an empty string if an exception occurs.
                return " ";
            }

            return " ";
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