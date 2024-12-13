#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.assistviewdemo.wpf.ViewModel;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Chat;
using System;
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
using System.Windows.Shapes;

namespace syncfusion.assistviewdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for ComposeView.xaml
    /// </summary>
    public partial class ComposeView : DemoControl
    {
        public ComposeView()
        {
            InitializeComponent();
            var msgs = this.DataContext as ComposeViewModel;
            msgs.InitAI();
        }

        private void chat_SuggestionSelected(object sender, SuggestionClickedEventArgs e)
        {
            var msgs = chat.DataContext as ComposeViewModel;
            msgs.Chats.Add(new TextMessage { Text = e.Item.ToString(), DateTime = DateTime.Now, Author = chat.CurrentUser });
        }

        private void chat_MenuItemClicked(object sender, MenuItemClickedEventArgs e)
        {
            var msgs = chat.DataContext as ComposeViewModel;
            msgs.MenuItemClicked(e);
        }
    }
}
