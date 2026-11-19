using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;

namespace syncfusion.notificationdemos.wpf
{
    public class IntegrateWithOtherControlsViewModel : NotificationObject, IDisposable
    {
        public List<IntegrateWithOtherControlsModel> MailItems { get; set; }
        public IntegrateWithOtherControlsViewModel()
        {
            MailItems = new List<IntegrateWithOtherControlsModel>();
            MailItems.Add(new IntegrateWithOtherControlsModel()
            {
                ItemName = "Starred Items",
                UnreadMessageount = null
            });
            MailItems.Add(new IntegrateWithOtherControlsModel()
            {
                ItemName = "Inbox",
                UnreadMessageount = "99+"
            });
            MailItems.Add(new IntegrateWithOtherControlsModel()
            {
                ItemName = "Sent Items",
                UnreadMessageount = null
            });
            MailItems.Add(new IntegrateWithOtherControlsModel()
            {
                ItemName = "Deleted Items",
                UnreadMessageount = "10+"
            });           
            MailItems.Add(new IntegrateWithOtherControlsModel()
            {
                ItemName = "Snoozed Items",
                UnreadMessageount = null
            });
            MailItems.Add(new IntegrateWithOtherControlsModel()
            {
                ItemName = "Junk Email",
                UnreadMessageount = "43+"
            });
        }

        public void Dispose()
        {
            if(MailItems != null)
            {
                MailItems.Clear();
                MailItems = null;
            }
        }
    }
}
