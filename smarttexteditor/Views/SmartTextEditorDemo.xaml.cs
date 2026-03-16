#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.SmartComponents;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.smarttexteditordemos.wpf
{
    /// <summary>
    /// Interaction logic for SmartTextEditorDemo.xaml
    /// </summary>
    public partial class SmartTextEditorDemo : DemoControl
    {
        public SmartTextEditorDemo()
        {            
            InitializeComponent();            
        }

        public SmartTextEditorDemo(string themename) : base(themename)
        {
            InitializeComponent();
            if (!AISettings.IsCredentialValid)
            {
                AISettings.ShowAISettingsWindow();
            }

            if (AISettings.IsCredentialValid)
            {
                AzureOpenAIClient azureClient = new AzureOpenAIClient(new Uri(AISettings.EndPoint), new ApiKeyCredential(AISettings.Key));
                IChatClient azureChatClient = azureClient.GetChatClient(AISettings.ModelName).AsIChatClient();
                SyncfusionAIExtension.Services.AddSingleton<IChatClient>(azureChatClient);
                SyncfusionAIExtension.ConfigureSyncfusionAIServices();
            }      
        }
    }
}
