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
    /// Interaction logic for Overview.xaml
    /// </summary>
    public partial class Overview : DemoControl
    {
        public Overview()
        {
            InitializeComponent();
            var msgs = this.DataContext as OverviewViewModel;
            msgs.InitAI();
        }

        private void chat_SuggestionSelected(object sender, SuggestionClickedEventArgs e)
        {
            var msgs = chat.DataContext as OverviewViewModel;
            msgs.Chats.Add(new TextMessage { Text = e.Item.ToString(), DateTime = DateTime.Now, Author = chat.CurrentUser });
        }

        private void popup_Click(object sender, RoutedEventArgs e)
        {
            AssistFlyOut.IsOpen = true;
        }

        private void chat_StopResponding(object sender, EventArgs e)
        {
            var msgs = chat.DataContext as OverviewViewModel;
            msgs.isStopResponding = true;
        }

        private void chat_ResponseToolbarItemClicked(object sender, ResponseToolbarItemClickedEventArgs e)
        {
            var msgs = chat.DataContext as OverviewViewModel;
            msgs.ResponseToolbarItemClicked(e);
            if (e.Item.ItemType == ToolBarItemType.Copy)
            {
                oneNote.Text = oneNote.Text + "\n\n" + (e.ChatItem.DataContext as AIMessage).Text;

            }
        }
    }
}
