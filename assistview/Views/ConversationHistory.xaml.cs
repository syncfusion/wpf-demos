#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.assistviewdemo.wpf.ViewModel;
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Chat;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.assistviewdemo.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ConversationHistory : DemoControl
    {
        public ConversationHistory()
        {
            InitializeComponent();
            this.Loaded += ConversationHistory_Loaded;
        }

        private void ConversationHistory_Loaded(object sender, RoutedEventArgs e)
        {
            // Defer initialization until after the SfAIAssistView template has been
            // applied. Otherwise the initial messages can be dropped before the
            // ChatItemsView template child is available.
            var msgs = this.DataContext as ConversationHistoryViewModel;
            if (msgs != null)
            {
                msgs.InitAI();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if ((this.DataContext as ConversationHistoryViewModel).assistView != null)
            {
                (this.DataContext as ConversationHistoryViewModel).assistView = null;
            }

            base.Dispose(disposing);
        }

        private void Chat_StopResponding(object sender, EventArgs e)
        {
            var msgs = Chat.DataContext as ConversationHistoryViewModel;
            msgs.isStopResponding = true;
        }

        private void Chat_ResponseToolbarItemClicked(object sender, ResponseToolbarItemClickedEventArgs e)
        {
            var msgs = Chat.DataContext as ConversationHistoryViewModel;
            msgs.ResponseToolbarItemClicked(e);
        }

        private async void Chat_PromptRequest(object sender, PromptRequestEventArgs e)
        {
            e.Handled = true;
            var assistViewModel = Chat.DataContext as ConversationHistoryViewModel;
            ITextMessage textMessage = e.InputMessage as ITextMessage;
            string userText = textMessage.Text.ToString();

            assistViewModel.Chats.Add(new TextMessage
            {
                Text = userText,
                DateTime = DateTime.Now,
                Author = Chat.CurrentUser,
            });

            // Manually trigger the AI response for the newly-typed prompt. This is
            // the only path that shows the typing indicator and adds a bot reply.
            await assistViewModel.SendUserMessageAsync(userText);
        }
    }
}
