#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
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
    public partial class AssistViewDemo : DemoControl
    {
        bool isSuggestionSelected = false;    
        public AssistViewDemo()
        {    
            InitializeComponent();
            var msgs = this.DataContext as AIAssistViewModel;
            msgs.InitAI();
        }

        private void Chat_SuggestionSelected(object sender, SuggestionClickedEventArgs e)
        {
            var msgs = Chat.DataContext as AIAssistViewModel;
            msgs.Chats.Add(new TextMessage { Text = e.Item.ToString(), DateTime = DateTime.Now, Author = Chat.CurrentUser });
            isSuggestionSelected = true;
        }

        protected override void Dispose(bool disposing)
        {
            if ((this.DataContext as AIAssistViewModel).assistView != null)
            {
                (this.DataContext as AIAssistViewModel).assistView = null;
            }

            base.Dispose(disposing);
        }

        private void Chat_StopResponding(object sender, EventArgs e)
        {
            var msgs = Chat.DataContext as AIAssistViewModel;
            msgs.isStopResponding = true;
        }

        private void Chat_ResponseToolbarItemClicked(object sender, ResponseToolbarItemClickedEventArgs e)
        {
            var msgs = Chat.DataContext as AIAssistViewModel;
            msgs.ResponseToolbarItemClicked(e);
        }

        private void Chat_InputToolbarItemClicked(object sender, InputToolbarItemClickedEventArgs e)
        {
            var viewModel = this.DataContext as AIAssistViewModel;
            if (viewModel == null) return;

            var dlg = new OpenFileDialog
            {
                Title = "Select a file",
                Filter = "Text Files (*.txt)|*.txt|" +
                        "Markdown Files (*.md)|*.md|" +
                        "JSON Files (*.json)|*.json|" +
                        "XML Files (*.xml)|*.xml|" +
                        "HTML Files (*.html;*.htm)|*.html;*.htm|" +
                        "All Files (*.*)|*.*"
            };
            var uploadedFile = new FileInfo();
            if (dlg.ShowDialog() == true)
            {
               
                uploadedFile.Path = dlg.FileName; // save path
                uploadedFile.Name = System.IO.Path.GetFileName(dlg.FileName);
                var fi = new System.IO.FileInfo(dlg.FileName);
                uploadedFile.Size = fi.Length < 1024 ? $"{fi.Length} B"
                                     : fi.Length < (1024 * 1024) ? $"{fi.Length / 1024} KB"
                                     : $"{fi.Length / (1024 * 1024)} MB";
                uploadedFile.Name = System.IO.Path.GetFileName(dlg.FileName);               
            }
            if(uploadedFile.Path != null)
                 viewModel.Files.Add(uploadedFile);
        }

        private void Chat_PromptRequest(object sender, PromptRequestEventArgs e)
        {
            if(isSuggestionSelected)
            {
                isSuggestionSelected = false;
                return;
            }
            e.Handled = true;
            var assistViewModel = Chat.DataContext as AIAssistViewModel;
            ObservableCollection<FileInfo> files = new ObservableCollection<FileInfo>();
            ITextMessage textMessage = e.InputMessage as ITextMessage;

            foreach (var msg in assistViewModel.Files)
            {
                files.Add(new FileInfo { Name = msg.Name, Size = msg.Size, Path = msg.Path });
            }

            if (files.Count > 0)
            {
                assistViewModel.Chats.Add(new FileItemMessage
                {

                    Text = textMessage.Text.ToString(),
                    DateTime = DateTime.Now,
                    Author = Chat.CurrentUser,
                    Files = files

                });
            }
            else
            {
                assistViewModel.Chats.Add(new TextMessage
                {
                    Text = textMessage.Text.ToString(),
                    DateTime = DateTime.Now,
                    Author = Chat.CurrentUser,

                });
            }
            if (assistViewModel.Files != null)
            {
                assistViewModel.Files.Clear();
            }
        }
    }
}
