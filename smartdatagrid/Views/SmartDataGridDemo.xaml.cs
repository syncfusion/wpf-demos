#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.SmartComponents;
using Syncfusion.Windows.Shared;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.smartdatagriddemos.wpf
{

    /// <summary>
    /// Interaction logic for GettingStarted.xaml
    /// </summary>
    public partial class SmartDataGridDemo : DemoControl
    {
        public SmartDataGridDemo(string themename) : base(themename)
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

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            if (this.DataContext != null)
                this.DataContext = null;

            //Release all managed resources
            if (this.Smartdatagrid != null)
            {
                this.Smartdatagrid.Dispose();
                this.Smartdatagrid = null;
            }
            base.Dispose(disposing);
        }
    }
}
