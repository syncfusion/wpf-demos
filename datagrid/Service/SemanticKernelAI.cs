#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Threading.Tasks;
using System;
using System.Windows;
using Microsoft.Extensions.AI;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Provides access to the SemanticKernel service for performing AI operations.
    /// </summary>
    public class SemanticKernelAI
    {
        /// <summary>
        /// Method to get the response from GPT using the semantic kernel
        /// </summary>
        /// <param name="prompt">Prompt for the system message</param>
        /// <returns>The AI results.</returns>
        public async Task<string> GetResponseFromGPT(string prompt)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                // Return an empty string if an exception occurs
                return string.Empty;
            }
            return string.Empty;
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