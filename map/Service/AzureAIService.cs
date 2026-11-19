namespace syncfusion.mapdemos.wpf
{
    using Azure.AI.OpenAI;
    using Azure;
    using System;
    using System.Threading.Tasks;
    using syncfusion.demoscommon.wpf;
    using System.Windows.Media.Imaging;
    using System.Windows.Media;
    using Microsoft.Extensions.AI;
    using OpenAI.Images;
    using System.Threading;

    /// <summary>
    /// Provides access to the Azure AI service for performing various AI operations, including chat completions and image-related tasks.
    /// </summary>
    public class AzureAIService
    {
        /// <summary>
        /// The Azure OpenAI Text to Image service client.
        /// </summary>
        ImageClient azureOpenAITextToImageService;

        /// <summary>
        /// The Image Deployment name
        /// </summary>
        private string imageDeploymentName = "DALL-E";

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
                    var response = await AISettings.ClientAI.GetResponseAsync(prompt);
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
        /// Method to get the image from AI.
        /// </summary>
        /// <param name="locationName"> The location name</param>
        /// <returns>The bitmap image</returns>
        public async Task<ImageSource> GetImageFromAI(string locationName)
        {
            azureOpenAITextToImageService = new AzureOpenAIClient(new Uri(AISettings.EndPoint), new AzureKeyCredential(AISettings.Key)).GetImageClient(imageDeploymentName);
            if (string.IsNullOrWhiteSpace(locationName))
            {
                locationName = "a beautiful natural landscape";
            }

            var Prompt = $"Generate a realistic image of {locationName}. If specific details about {locationName} are unavailable, generate a common or representative image of a generic location.";

             OpenAI.Images.ImageGenerationOptions options = new OpenAI.Images.ImageGenerationOptions()
            {
                ResponseFormat = GeneratedImageFormat.Uri,
                Size = GeneratedImageSize.W1024xH1024,
                Quality = GeneratedImageQuality.High,
                Style = GeneratedImageStyle.Natural,
            };

            var imageUrl = await azureOpenAITextToImageService
                .GenerateImageAsync(Prompt, options, cancellationToken: CancellationToken.None);

            if (imageUrl == null || imageUrl.Value?.ImageUri == null)
            {
                throw new Exception("Failed to generate the image. Please check the prompt and service configuration.");
            }

            Uri imageUri = imageUrl.Value.ImageUri;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = imageUri;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            return bitmapImage;
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