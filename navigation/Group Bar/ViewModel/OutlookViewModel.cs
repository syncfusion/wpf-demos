#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.TreeView.Engine;
using Syncfusion.Windows.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the behaviour or business logic for MainWindow.xaml.
    /// </summary>
    public class OutlookViewModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the sub Items.
        /// </summary>
        private ObservableCollection<SubItemModel> subItems;

        /// <summary>
        ///  Maintains the collection of main mail.
        /// </summary>
        private ObservableCollection<MailModel> mainMailCollection;
   
        /// <summary>
        ///  Maintains the selected tree view item.
        /// </summary>
        private object selectedItem;

        /// <summary>
        ///  Maintains thec command for deleted mails.
        /// </summary>
        private ICommand deleteMailCommand;

        /// <summary>
        /// Maintains the command for allMail.
        /// </summary>
        private ICommand allMail;

        /// <summary>
        /// Maintains the command for unReadMail.
        /// </summary>
        private ICommand unReadMail;

        /// <summary>
        /// Maintains the command for groupBar tab change.
        /// </summary>
        private ICommand groupBarTabChangedCommand;

        /// <summary>
        ///  Maintains the collection of addContacts.
        /// </summary>
        private ObservableCollection<ContactModel> addContacts = new ObservableCollection<ContactModel>();

        /// <summary>
        ///  Maintains the collection of notes.
        /// </summary>
        private ObservableCollection<NoteModel> notes = new ObservableCollection<NoteModel>();

        /// <summary>
        /// Maintains the collection for unread mails.
        /// </summary>
        ObservableCollection<MailModel> unReadCollection = new ObservableCollection<MailModel>();

        /// <summary>
        ///  Initializes a new instance of the <see cref="OutlookViewModel" /> class.
        /// </summary>    
        public OutlookViewModel()
        {
            deleteMailCommand = new DelegateCommand<object>(DeleteMail);
            allMail = new DelegateCommand<object>(ExecuteAllMail);
            unReadMail = new DelegateCommand<object>(ExecuteUnreadMail);
            groupBarTabChangedCommand = new DelegateCommand<object>(ExecuteGroupBarTabChange);
            mainMailCollection = GetInboxMails();
            addContacts = GetContacts();
            Notes = GetNotes();           
        }

        /// <summary>
        /// Gets or sets the command for deleted mails <see cref="OutlookViewModel"/> class.
        /// </summary>
        public ICommand DeleteMailCommand
        {
            get
            {
                return deleteMailCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for allMails <see cref="OutlookViewModel"/> class.
        /// </summary>
        public ICommand AllMail
        {
            get
            {
                return allMail;
            }
        }

        /// <summary>
        /// Gets or sets the command for unReadMail <see cref="OutlookViewModel"/> class.
        /// </summary>
        public ICommand UnreadMail
        {
            get
            {
                return unReadMail;
            }
        }

        /// <summary>
        /// Gets or sets the command for groupBarTabChangedCommand <see cref="OutlookViewModel"/> class.
        /// </summary>
        public ICommand GroupBarTabChangedCommand
        {
            get
            {
                return groupBarTabChangedCommand;
            }
        }

        /// <summary>
        /// Gets or sets the collection of selected mails <see cref="OutlookViewModel"/> class.
        /// </summary>
        public ObservableCollection<MailModel> SelectedMails
        {
            get
            {
                return mainMailCollection;
            }
            set
            {
                mainMailCollection = value;
                RaisePropertyChanged("SelectedMails");
            }
        }

        /// <summary>
        /// Gets or sets the collection of UnRead mails <see cref="OutlookViewModel"/> class.
        /// </summary>
        public ObservableCollection<MailModel> UnReadCollection
        {
            get
            {
                return unReadCollection;
            }
            set
            {
                unReadCollection = value;
                RaisePropertyChanged("UnReadCollection");
            }
        }

        /// <summary>
        /// Gets or sets the addContacts <see cref="OutlookViewModel"/> class.
        /// </summary>
        public ObservableCollection<ContactModel> Contacts
        {
            get
            {
                return addContacts;
            }
            set
            {
                addContacts = value;
                RaisePropertyChanged("Contacts");
            }
        }

        /// <summary>
        /// Gets or sets the notes <see cref="OutlookViewModel"/> class.
        /// </summary>
        public ObservableCollection<NoteModel> Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
                RaisePropertyChanged("Notes");
            }
        }

        /// <summary>
        /// Gets or sets the selected tree view item <see cref="OutlookViewModel"/> class.
        /// </summary>
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
                TreeItemChanged(value);
            }
        }

        /// <summary>
        /// Gets or sets the sub items <see cref="OutlookViewModel"/> class.
        /// </summary>
        public ObservableCollection<SubItemModel> SubItems
        {
            get
            {
                return subItems;
            }
            set
            {
                subItems = value;
                RaisePropertyChanged("SubItems");
            }
        }

        /// <summary>
        /// Adding notes to the collection.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<NoteModel> GetNotes()
        {
            ObservableCollection<NoteModel> addNotes = new ObservableCollection<NoteModel>();
            for (int i = 0; i < 5; i++)
            {
                addNotes.Add(new NoteModel() { Message = "Meeting with robb at 7PM" });
                addNotes.Add(new NoteModel() { Message = "Package delivered on monday" });
                addNotes.Add(new NoteModel() { Message = "Due at tuesday" });
                addNotes.Add(new NoteModel() { Message = "License need to be renewed" });
            }         
            return addNotes;
        }
       
        /// <summary>
        /// Adding contacts to the addContacts collection.
        /// </summary>
        /// <returns>Return the collection of contacts</returns>
        private ObservableCollection<ContactModel> GetContacts()
        {
            List<ContactModel> addContacts = new List<ContactModel>();
            addContacts.Add(new ContactModel() { Name = "Alfreds"});
            addContacts.Add(new ContactModel() { Name = "Maria"});
            addContacts.Add(new ContactModel() { Name = "Anders"});
            addContacts.Add(new ContactModel() { Name = "Thomas"});
            addContacts.Add(new ContactModel() { Name = "Hardy"});
            addContacts.Add(new ContactModel() { Name = "Christina"});
            addContacts.Add(new ContactModel() { Name = "Berglunds"});
            addContacts.Add(new ContactModel() { Name = "Berguvsvägen"});
            addContacts.Add(new ContactModel() { Name = "Anil"});
            addContacts.Add(new ContactModel() { Name = "Rex"});
            addContacts.Add(new ContactModel() { Name = "Peter"});
            addContacts.Add(new ContactModel() { Name = "Robert"});
            addContacts.Add(new ContactModel() { Name = "Sam"});
            addContacts.Add(new ContactModel() { Name = "Brandon"});
            addContacts.Add(new ContactModel() { Name = "Charles"});
            addContacts.Add(new ContactModel() { Name = "Arya"});
            addContacts.Add(new ContactModel() { Name = "Tom"});
            addContacts.Add(new ContactModel() { Name = "Lee" });
            addContacts.Add(new ContactModel() { Name = "Martin" });
            addContacts.Add(new ContactModel() { Name = "Herlen" });
            addContacts.Add(new ContactModel() { Name = "James" });
            addContacts.Add(new ContactModel() { Name = "Victoria" });
            addContacts.Add(new ContactModel() { Name = "Damien" });
            addContacts.Add(new ContactModel() { Name = "Victor" });
            addContacts.Add(new ContactModel() { Name = "Chris" });
            addContacts.Add(new ContactModel() { Name = "Southee" });
            addContacts.Add(new ContactModel() { Name = "John" });
            addContacts.Sort();
            return new ObservableCollection<ContactModel>(addContacts);
        }
      
        /// <summary>
        /// Get mails to tree items.
        /// </summary>
        /// <param name="value">Value populated to the tree view items</param>
        private void TreeItemChanged(object value)
        {            
            if ((value as TreeViewNode).Content.ToString() == "Sent Items")
                this.SelectedMails = GetSentMails();
            else
                if ((value as TreeViewNode).Content.ToString() == "Inbox")
                this.SelectedMails = GetInboxMails();
            else
                if ((value as TreeViewNode).Content.ToString() == "Deleted Items")
                this.SelectedMails = GetDeletedMails();
            else
                if ((value as TreeViewNode).Content.ToString() == "Drafts")
                this.SelectedMails = GetDraftMails();
            else
                if ((value as TreeViewNode).Content.ToString() == "Junk Emails")
                this.SelectedMails = GetJunkMails();
            else
                if ((value as TreeViewNode).Content.ToString() == "Outbox")
                this.SelectedMails = GetSentMails();
            else
                this.SelectedMails = null;
        }     
      
        /// <summary>
        /// Method which is used to delete the mail.
        /// </summary>
        /// <param name="arg">Parameter used to delete the mail</param>
        private void DeleteMail(object arg)
        {
            MailModel temp = arg as MailModel;
            MailModel emptyCollection = null;
            bool isdeleted = false;
            foreach (var sortedcoll in this.SelectedMails)
            {
                if (temp.Message == sortedcoll.Message)
                {
                    SelectedMails.Remove(temp);
                    if (SelectedMails.Count == 0)
                        emptyCollection = sortedcoll;
                    isdeleted = true;
                    break;
                }
                if (isdeleted)
                {
                    if (emptyCollection != null)
                    {
                        this.SelectedMails.Remove(emptyCollection);
                    }
                    break;
                }
            }
        }
                     
        /// <summary>
        /// Method which used to get the sentmail items.
        /// </summary>
        /// <returns>Returns the sent mails</returns>
        private ObservableCollection<MailModel> GetSentMails()
        {

            ObservableCollection<MailModel> sentMails = new ObservableCollection<MailModel>();
            MailModel mail1 = new MailModel();
            mail1.Header = "Today";
            mail1.SenderDetails = "Maria Anders";
            mail1.ToAddress = "Jane Jonk";
            mail1.Subject = "Regarding Meeting";
            mail1.IsUnRead = false;
            mail1.Date = "16/04/2020";
            mail1.Message = @" Hi Jane Jonk, Can we schedule Meeting Appointment for today?.";
            sentMails.Add(mail1);

            MailModel mail2 = new MailModel();
            mail2.Header = "Today";
            mail2.SenderDetails = "Thomas Hardy";
            mail2.ToAddress = "Chris Kol";
            mail2.Subject = "Customer has accpeted...";
            mail2.IsUnRead = false;
            mail2.Date = "10/04/2020";
            mail2.Message = @" Hi Chris Kol, Customer has accepted our proposal. Would it be possible for arrange meeting tomorrow?.";
            sentMails.Add(mail2);

            MailModel mail3 = new MailModel();
            mail3.Header = "Today";
            mail3.SenderDetails = "Christina Berglund";
            mail3.ToAddress = "Dev Khar";
            mail3.Subject = "Greeting";
            mail3.IsUnRead = false;
            mail3.Date = "09/04/2020";
            mail3.Message = @" Hi Dev Khar, Merry Christmas.";
            sentMails.Add(mail3);

            MailModel mail4 = new MailModel();
            mail4.Header = "Yesterday";
            mail4.SenderDetails = "Martín Sommer";
            mail4.ToAddress = "Anil Pahr";
            mail4.Subject = "Please come and collect ";
            mail4.IsUnRead = false;
            mail4.Date = "11/03/2020";
            mail4.Message = @"  Hi Anil Pahr, Please come and collect the rent receipt.";

            MailModel mail5 = new MailModel();
            mail5.Header = "Yesterday";
            mail5.SenderDetails = "Victoria Ashworth";
            mail5.ToAddress = "Shanakar";
            mail5.Subject = "Regarding meeting";
            mail5.IsUnRead = false;
            mail5.Date = "01/03/2020";
            mail5.Message = @"  Hi Shanakar, Yes we are available for meeting tomorrow.";
            sentMails.Add(mail5);

            MailModel mail6 = new MailModel();
            mail6.Header = "Yesterday";
            mail6.SenderDetails = "Yang Wang.";
            mail6.ToAddress = "Krish Kael";
            mail6.Subject = "Schedule meeting";
            mail6.IsUnRead = false;
            mail6.Date = "22/02/2020";
            mail6.Message = @"  Hi Krish Kael, Please schedule the meeting on tomorrow.";
            sentMails.Add(mail6);

            MailModel mail7 = new MailModel();
            mail7.Header = "LastWeek";
            mail7.SenderDetails = "Sven Ottlieb";
            mail7.ToAddress = "Marie Krilsh";
            mail7.Subject = "Greeting";
            mail7.IsUnRead = false;
            mail7.Date = "12/02/2020";
            mail7.Message = @" Hi Marie Krilsh, Merry Christmas.";
            sentMails.Add(mail7);

            MailModel mail8 = new MailModel();
            mail8.Header = "LastWeek";
            mail8.SenderDetails = "Aria Cruz";
            mail8.ToAddress = "Maria Krilsh";
            mail8.Subject = "New year Greeting";
            mail8.IsUnRead = false;
            mail8.Date = "07/02/2020";
            mail8.Message = @" Hi Maria Krilsh, I wish you Happy new year.";
            sentMails.Add(mail8);

            MailModel mail9 = new MailModel();
            mail9.Header = "LastWeek";
            mail9.SenderDetails = "Diego Roel";
            mail9.ToAddress = "Michael";
            mail9.Subject = "Weekend Greeting";
            mail9.IsUnRead = false;
            mail9.Date = "28/01/2020";
            mail9.Message = @" Hi Michael, Have a Great Weekend.";
            sentMails.Add(mail9);

            MailModel mail10 = new MailModel();
            mail10.Header = "Last Month";
            mail10.SenderDetails = "Paolo Accorti.";
            mail10.ToAddress = "John Michael";
            mail10.Subject = "Greeting";
            mail10.IsUnRead = false;
            mail10.Date = "25/01/2020";
            mail10.Message = @"   Hi John Michael, Have a Great Day.";
            sentMails.Add(mail10);
            return sentMails;
        }

        /// <summary>
        /// Method which is used to get the inbox mail items.
        /// </summary>
        /// <returns>Returns </returns>
        private ObservableCollection<MailModel> GetInboxMails()
        {
            ObservableCollection<MailModel> inboxMails = new ObservableCollection<MailModel>();
            MailModel mail1 = new MailModel();
            mail1.Header = "Today";
            mail1.SenderDetails = "Maria Anders";
            mail1.ToAddress = "Jane Jonk";
            mail1.Subject = "Regarding Meeting";
            mail1.IsUnRead = true;
            mail1.Date = "16/04/2020";
            mail1.Message = @" Hi Jane Jonk, Can we schedule Meeting Appointment for today?.";
            inboxMails.Add(mail1);

            MailModel mail2 = new MailModel();
            mail2.Header = "Today";
            mail2.SenderDetails = "Thomas Hardy";
            mail2.ToAddress = "Chris Kol";
            mail2.Subject = "Customer has accpeted...";
            mail2.IsUnRead = true;
            mail2.Date= "10/04/2020";
            mail2.Message = @" Hi Chris Kol, Customer has accepted our proposal. Would it be possible for arrange meeting tomorrow?";
            inboxMails.Add(mail2);

            MailModel mail3 = new MailModel();
            mail3.Header = "Today";
            mail3.SenderDetails = "Christina Berglund";
            mail3.ToAddress = "Dev Khar";
            mail3.Subject = "Greeting";
            mail3.IsUnRead = true;
            mail3.Date = "08/04/2020";
            mail3.Message = @" Hi Dev Khar, Merry Christmas.";
            inboxMails.Add(mail3);

            MailModel mail4 = new MailModel();
            mail4.Header = "Yesterday";
            mail4.SenderDetails = "Martín Sommer";
            mail4.ToAddress = "Anil Pahr";
            mail4.Subject = "Please come and collect ";
            mail4.IsUnRead = false;
            mail4.Date = "07/04/2020";
            mail4.Message = @"  Hi Anil Pahr, Please come and collect the rent receipt.";
            inboxMails.Add(mail4);

            MailModel mail5 = new MailModel();
            mail5.Header = "Yesterday";
            mail5.SenderDetails = "Victoria Ashworth";
            mail5.ToAddress = "Shanakar";
            mail5.Subject = "Regarding meeting";
            mail5.IsUnRead = false;
            mail5.Date = "01/04/2020";
            mail5.Message = @"  Hi Shanakar, Yes we are available for meeting tomorrow.";
            inboxMails.Add(mail5);

            MailModel mail6 = new MailModel();
            mail6.Header = "Yesterday";
            mail6.SenderDetails = "Yang Wang.";
            mail6.ToAddress = "Krish Kael";
            mail6.Subject = "Schedule meeting";
            mail6.IsUnRead = false;
            mail6.Date = "11/03/2020";
            mail6.Message = @"  Hi Krish Kael, Please schedule the meeting on tomorrow.";
            inboxMails.Add(mail6);

            MailModel mail7 = new MailModel();
            mail7.Header = "LastWeek";
            mail7.SenderDetails = "Sven Ottlieb";
            mail7.ToAddress = "Marie Krilsh";
            mail7.Subject = "Greeting";
            mail7.IsUnRead = false;
            mail7.Date = "23/03/2020";
            mail7.Message = @" Hi Marie Krilsh, Merry Christmas.";
            inboxMails.Add(mail7);

            MailModel mail8 = new MailModel();
            mail8.Header = "LastWeek";
            mail8.SenderDetails = "Aria Cruz";
            mail8.ToAddress = "Maria Krilsh";
            mail8.Subject = "New year Greeting";
            mail8.IsUnRead = false;
            mail8.Date = "29/02/2020";
            mail8.Message = @" Hi Maria Krilsh, I wish you Happy new year.";
            inboxMails.Add(mail8);

            MailModel mail9 = new MailModel();
            mail9.Header = "LastWeek";
            mail9.SenderDetails = "Diego Roel";
            mail9.ToAddress = "Michael";
            mail9.Subject = "Weekend Greeting";
            mail9.IsUnRead = false;
            mail9.Date = "01/02/2020";
            mail9.Message = @" Hi Michael, Have a Great Weekend.";
            inboxMails.Add(mail9);

            MailModel mail10 = new MailModel();
            mail10.Header = "Last Month";
            mail10.SenderDetails = "Paolo Accorti.";
            mail10.ToAddress = "John Michael";
            mail10.Subject = "Greeting";
            mail10.IsUnRead = false;
            mail10.Date = "26/01/2020";
            mail10.Message = @" Hi John Michael, Have a Great Day.";
            inboxMails.Add(mail10);
            return inboxMails;
        }

        /// <summary>
        /// Method which is used to get the inbox mail items.
        /// </summary>
        /// <returns>Returns </returns>
        private ObservableCollection<MailModel> GetDeletedMails()
        {
            ObservableCollection<MailModel> deletedMails = new ObservableCollection<MailModel>();

            MailModel mail1 = new MailModel();
            mail1.Header = "Today";
            mail1.SenderDetails = "Maria Anders";
            mail1.ToAddress = "Jane Jonk";
            mail1.Subject = "Regarding Meeting";
            mail1.IsUnRead = true;
            mail1.Message = @" Hi Jane Jonk, Can we schedule Meeting Appointment for today?.";
            deletedMails.Add(mail1);

            MailModel mail2 = new MailModel();
            mail2.Header = "Today";
            mail2.SenderDetails = "Thomas Hardy";
            mail2.ToAddress = "Chris Kol";
            mail2.Subject = "Customer has accpeted...";
            mail2.IsUnRead = true;
            mail2.Message = @" Hi Chris Kol, Customer has accepted our proposal. Would it be possible for arrange meeting tomorrow?";
            deletedMails.Add(mail2);

            MailModel mail3 = new MailModel();
            mail3.Header = "Today";
            mail3.SenderDetails = "Christina Berglund";
            mail3.ToAddress = "Dev Khar";
            mail3.Subject = "Greeting";
            mail3.IsUnRead = true;
            mail3.Message = @" Hi Dev Khar, Merry Christmas.";
            deletedMails.Add(mail3);

            MailModel mail4 = new MailModel();
            mail4.Header = "Yesterday";
            mail4.SenderDetails = "Martín Sommer";
            mail4.ToAddress = "Anil Pahr";
            mail4.Subject = "Please come and collect ";
            mail4.IsUnRead = true;
            mail4.Message = @"  Hi Anil Pahr, Please come and collect the rent receipt.";
            deletedMails.Add(mail4);

            MailModel mail5 = new MailModel();
            mail5.Header = "Yesterday";
            mail5.SenderDetails = "Victoria Ashworth";
            mail5.ToAddress = "Shanakar";
            mail5.Subject = "Regarding meeting";
            mail5.IsUnRead = true;
            mail5.Message = @"  Hi Shanakar, Yes we are available for meeting tomorrow.";
            deletedMails.Add(mail5);

            MailModel mail6 = new MailModel();
            mail6.Header = "Yesterday";
            mail6.SenderDetails = "Yang Wang.";
            mail6.ToAddress = "Krish Kael";
            mail6.Subject = "Schedule meeting";
            mail6.IsUnRead = true;
            mail6.Message = @"  Hi Krish Kael, Please schedule the meeting on tomorrow.";
            deletedMails.Add(mail6);

            MailModel mail7 = new MailModel();
            mail7.Header = "LastWeek";
            mail7.SenderDetails = "Sven Ottlieb";
            mail7.ToAddress = "Marie Krilsh";
            mail7.Subject = "Greeting";
            mail7.IsUnRead = true;
            mail7.Message = @" Hi Marie Krilsh, Merry Christmas.";
            deletedMails.Add(mail7);

            MailModel mail8 = new MailModel();
            mail8.Header = "LastWeek";
            mail8.SenderDetails = "Aria Cruz";
            mail8.ToAddress = "Maria Krilsh";
            mail8.Subject = "New year Greeting";
            mail8.IsUnRead = true;
            mail8.Message = @" Hi Maria Krilsh, I wish you Happy new year.";
            deletedMails.Add(mail8);

            MailModel mail9 = new MailModel();
            mail9.Header = "LastWeek";
            mail9.SenderDetails = "Diego Roel";
            mail9.ToAddress = "Michael";
            mail9.Subject = "Weekend Greeting";
            mail9.IsUnRead = true;
            mail9.Message = @" Hi Michael, Have a Great Weekend.";
            deletedMails.Add(mail9);

            MailModel mail10 = new MailModel();
            mail10.Header = "Last Month";
            mail10.SenderDetails = "Paolo Accorti.";
            mail10.ToAddress = "John Michael";
            mail10.Subject = "Greeting";
            mail10.IsUnRead = true;
            mail10.Message = @" Hi John Michael, Have a Great Day.";
            deletedMails.Add(mail10);
            return deletedMails;
        }

        /// <summary>
        /// Method which is used to get the draft mail items.
        /// </summary>
        /// <returns>Returns </returns>
        private ObservableCollection<MailModel> GetDraftMails()
        {
            ObservableCollection<MailModel> draftMails = new ObservableCollection<MailModel>();

            MailModel mail1 = new MailModel();
            mail1.Header = "LastWeek";
            mail1.SenderDetails = "Sven Ottlieb";
            mail1.ToAddress = "Marie Krilsh";
            mail1.Subject = "Greeting";
            mail1.IsUnRead = false;
            mail1.Message = @" Hi Marie Krilsh, Merry Christmas.";
            draftMails.Add(mail1);

            MailModel mail2 = new MailModel();
            mail2.Header = "LastWeek";
            mail2.SenderDetails = "Aria Cruz";
            mail2.ToAddress = "Maria Krilsh";
            mail2.Subject = "New year Greeting";
            mail2.IsUnRead = false;
            mail2.Message = @" Hi Maria Krilsh, I wish you Happy new year.";
            draftMails.Add(mail2);

            MailModel mail3 = new MailModel();
            mail3.Header = "LastWeek";
            mail3.SenderDetails = "Diego Roel";
            mail3.ToAddress = "Michael";
            mail3.Subject = "Weekend Greeting";
            mail3.IsUnRead = false;
            mail3.Message = @" Hi Michael, Have a Great Weekend.";
            draftMails.Add(mail3);

            MailModel mail4 = new MailModel();
            mail4.Header = "Last Month";
            mail4.SenderDetails = "Paolo Accorti.";
            mail4.ToAddress = "John Michael";
            mail4.Subject = "Greeting";
            mail4.IsUnRead = false;
            mail4.Message = @" Hi John Michael, Have a Great Day.";
            draftMails.Add(mail4);
            return draftMails;
        }

        /// <summary>
        /// Method which is used to get the junk mail items.
        /// </summary>
        /// <returns>Returns </returns>
        private ObservableCollection<MailModel> GetJunkMails()
        {
            ObservableCollection<MailModel> junkEMails = new ObservableCollection<MailModel>();

            MailModel mail1 = new MailModel();
            mail1.Header = "LastWeek";
            mail1.SenderDetails = "Sven Ottlieb";
            mail1.ToAddress = "Marie Krilsh";
            mail1.Subject = "Greeting";
            mail1.IsUnRead = false;
            mail1.Message = @" Hi Marie Krilsh, Merry Christmas.";
            junkEMails.Add(mail1);

            MailModel mail2 = new MailModel();
            mail2.Header = "LastWeek";
            mail2.SenderDetails = "Aria Cruz";
            mail2.ToAddress = "Maria Krilsh";
            mail2.Subject = "New year Greeting";
            mail2.IsUnRead = false;
            mail2.Message = @" Hi Maria Krilsh, I wish you Happy new year.";
            junkEMails.Add(mail2);

            MailModel mail3 = new MailModel();
            mail3.Header = "LastWeek";
            mail3.SenderDetails = "Diego Roel";
            mail3.ToAddress = "Michael";
            mail3.Subject = "Weekend Greeting";
            mail3.IsUnRead = false;
            mail3.Message = @" Hi Michael, Have a Great Weekend.";
            junkEMails.Add(mail3);
            return junkEMails;
        }

        /// <summary>
        /// Method used to execute all mails.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        public void ExecuteAllMail(object parameter)
        {
            MailView mailView = parameter as MailView;
            if (mailView.DataContext != null)
            {
                var collection = (mailView.DataContext as OutlookViewModel).SelectedMails;
                if (collection != null)
                {
                    foreach (var collection1 in unReadCollection)
                    {
                        foreach (var collection2 in unReadCollection)
                        {
                            if (collection1.Header == collection2.Header)
                            {
                                if (collection1.Subject == collection2.Subject)
                                {
                                    collection1.IsUnRead = collection2.IsUnRead;
                                }
                            }
                        }
                    }
                }
            }
            if (mailView.unReadMail != null && mailView.unReadMail.IsChecked.Value)
                mailView.unReadMail.IsChecked = false;
            if (mailView.unReadTreeView != null && mailView.showAllTreeView != null)
            {
                mailView.unReadTreeView.Visibility = System.Windows.Visibility.Collapsed;
                mailView.showAllTreeView.Visibility = System.Windows.Visibility.Visible;
            }
        }

        /// <summary>
        /// Method used to execute unread mails.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        public void ExecuteUnreadMail(object parameter)
        {
            MailView mailView = parameter as MailView;
            UnReadCollection.Clear();
            var collection = (mailView.DataContext as OutlookViewModel).SelectedMails;
            if (collection != null)
            {
                foreach (MailModel sorted in collection)
                {                    
                    if (sorted.IsUnRead)
                    {
                        UnReadCollection.Add(sorted);
                    }
                }
            }
            mailView.allMail.IsChecked = false;
            mailView.unReadTreeView.Visibility = System.Windows.Visibility.Visible;
            mailView.showAllTreeView.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// Method used to execute the  groupbar tab change command.
        /// </summary>
        /// <param name="parameter"></param>
        public void ExecuteGroupBarTabChange(object parameter)
        {
            GroupBarOutlook mainWindow = parameter as GroupBarOutlook;
            if (mainWindow != null)
            {
                if (mainWindow.groupBar.SelectedTab.HeaderText.ToString() == "Mailbox")
                {
                    mainWindow.selectedControlContent.Content = new MailView() { DataContext = mainWindow.DataContext as OutlookViewModel };
                }
                else if(mainWindow.groupBar.SelectedTab.HeaderText.ToString() == "Contacts")
                {
                    mainWindow.selectedControlContent.Content = null; mainWindow.selectedControlContent.Content = new ContactsView() { DataContext = mainWindow.DataContext as OutlookViewModel };
                }
                else if (mainWindow.groupBar.SelectedTab.HeaderText.ToString() == "Tasks")
                {
                    mainWindow.selectedControlContent.Content = null; mainWindow.selectedControlContent.Content = new TaskView() { DataContext = mainWindow.DataContext as OutlookViewModel };
                }
                else if (mainWindow.groupBar.SelectedTab.HeaderText.ToString() == "Notes")
                {
                    mainWindow.selectedControlContent.Content = null; mainWindow.selectedControlContent.Content = new NotesView() { DataContext = mainWindow.DataContext as OutlookViewModel };
                }
            }
        }
    }
}
