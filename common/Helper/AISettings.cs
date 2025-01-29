#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

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
        static IChatCompletionService chatCompletionService;
        static Kernel kernel;

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
                    var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(DemoBrowserViewModel.ModelName,
                                                         DemoBrowserViewModel.EndPoint, DemoBrowserViewModel.Key);
                    kernel = builder.Build();
                    chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
                    var history = new ChatHistory();
                    history.AddSystemMessage("Hi");
                    OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings();
                    openAIPromptExecutionSettings.ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions;
                    var result = await chatCompletionService.GetChatMessageContentAsync(
                    history,
                    executionSettings: openAIPromptExecutionSettings,
                    kernel: kernel);
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
