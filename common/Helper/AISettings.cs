using Azure.AI.OpenAI;
using Azure;
using Microsoft.Extensions.AI;
using Syncfusion.SfSkinManager;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Represents a helper class that contain API related to AI Services.
    /// </summary>
    public static class AISettings
    {
        static string modelName = string.Empty;
        static string key = string.Empty;
        static string endPoint = string.Empty;
        static IChatClient clientAI;

        /// <summary>
        /// Gets or sets a value indicating whether the AI Credentials is valid or not.
        /// </summary>
        public static bool IsCredentialValid
        {
            get; internal set;
        }

        /// <summary>
        /// Gets or sets the model name in the AI Setup Window.
        /// </summary>
        public static string ModelName
        {
            get
            {
                return modelName;
            }
            set
            {
                if (ModelName != value) 
                { 
                    modelName = value;
                } 
            }
        }

        /// <summary>
        /// Gets or sets the end point in the AI Setup Window.
        /// </summary>
        public static string EndPoint
        {
            get
            {
                return endPoint;
            }
            set
            {
                if (endPoint != value)
                {
                    endPoint = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the key in the AI Setup Window.
        /// </summary>
        public static string Key
        {
            get
            {
                return key;
            }
            set
            {
                if (key != value)
                {
                    key = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the AI chat client.
        /// </summary>
        public static IChatClient ClientAI
        {
            get
            {
                return clientAI;
            }
            set
            {
                clientAI = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating DataContext of MainWindow. 
        /// </summary>
        internal static DemoBrowserViewModel DemoBrowserViewModel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating the error message details.
        /// </summary>
        internal static string ErrorMessage 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Helps to show AISettingsWindow.
        /// </summary>
        public static void ShowAISettingsWindow()
        {
            DemoBrowserViewModel.ModelName = ModelName;
            DemoBrowserViewModel.Key = Key;
            DemoBrowserViewModel.EndPoint = EndPoint;

            AISettingsWindow settingsWindow = new AISettingsWindow(DemoBrowserViewModel);
            settingsWindow.WindowState = WindowState.Normal;
            Window productDemoWindow = null;
            WindowCollection windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window is ProductDemosWindow)
                {
                    productDemoWindow = window as Window;
                }
            }
            settingsWindow.Owner = (productDemoWindow != null  && productDemoWindow.IsVisible)? productDemoWindow : DemosNavigationService.MainWindow;
            SfSkinManager.SetTheme(settingsWindow, new Theme("Windows11Light"));
            settingsWindow.ShowDialog();

        }

        /// <summary>
        /// Helps to close the AISettingsWindow.
        /// </summary>
        internal static void CloseAISettingsWindow()
        {
            ModelName = DemoBrowserViewModel.ModelName;
            Key = DemoBrowserViewModel.Key;
            EndPoint = DemoBrowserViewModel.EndPoint;

            WindowCollection windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window is AISettingsWindow)
                {
                    window.Close();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SemanticKernelAI"/> class.
        /// </summary>
        /// <param name="key">Key for the semantic kernal API</param>
        internal static async Task<bool> ValidateCredentials()
        {
            ErrorMessage = string.Empty;
            try
            {
                Uri uriResult;
                bool isValidUri = Uri.TryCreate(DemoBrowserViewModel.EndPoint, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (!isValidUri || !DemoBrowserViewModel.EndPoint.Contains("http"))
                {
                    ErrorMessage = "Please enter valid EndPoint.";
                }
                else
                {
                    clientAI = new AzureOpenAIClient(new Uri(DemoBrowserViewModel.EndPoint), new AzureKeyCredential(DemoBrowserViewModel.Key)).AsChatClient(modelId: DemoBrowserViewModel.ModelName);
                    
                    if (ClientAI != null)
                    {
                        await ClientAI.CompleteAsync("Hello, Test Check");
                    }
                }
            }
            catch (Exception ex)
            {
                //Check the error message and display the appropriate message
                if (ex.Message.Contains("API deployment"))
                {
                    ErrorMessage = "Please enter valid ModelName.";
                }
                else if (ex.Message.Contains("Access denied"))
                {
                    ErrorMessage = "Please enter valid Key.";
                }
                else
                {
                    ErrorMessage = "Please enter valid EndPoint.";
                }
            }

            IsCredentialValid = string.IsNullOrEmpty(ErrorMessage) ? true : false;
            return IsCredentialValid;
        }
    }
}
