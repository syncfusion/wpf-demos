#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;

namespace syncfusion.notificationdemos.wpf
{
    public class IntegrateWithOtherControlsViewModel : NotificationObject
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
    }
}
