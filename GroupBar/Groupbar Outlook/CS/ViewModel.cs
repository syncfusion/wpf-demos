#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GroupbarOutlookDemo
{
    /// <summary>
    /// Represents a class of Viewmodel.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        #region Field
        /// <summary>
        ///  Maintains the command for selected item.
        /// </summary>
        private ICommand changeSelectedItemCommand;

        /// <summary>
        ///  Maintains the sub Items.
        /// </summary>
        private ObservableCollection<GroupbarSubItem> subItems;

        /// <summary>
        ///  Maintains the tree view details.
        /// </summary>
        private ObservableCollection<string> treeViewDetails;

        /// <summary>
        ///  Maintains the collection of search details.
        /// </summary>

        private ObservableCollection<string> searchDetails;
        /// <summary>
        ///  Maintains the collection of main mail.
        /// </summary>
        private ObservableCollection<SortedMailCollection> mainMailCollection;
   
        /// <summary>
        ///  Maintains the selected tree view item.
        /// </summary>
        private object selectedTreeViewItem;

        /// <summary>
        ///  Maintains thec command for deleted mails.
        /// </summary>
        private ICommand deleteMailCommand;

        /// <summary>
        ///  Maintains the collection of contacts.
        /// </summary>
        private ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

        /// <summary>
        ///  Maintains the collection of notes.
        /// </summary>
        private ObservableCollection<NoteModel> notes = new ObservableCollection<NoteModel>();
        #endregion

        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>    
        public ViewModel()
        {
            deleteMailCommand = new DelegateCommand(DeleteMail, candelete);
            changeSelectedItemCommand = new DelegateCommand(ChangeSelectedItem, CanChange);
            mainMailCollection = GetInboxMails();
            contacts = GetContacts();
            Notes = GetNotes();
            TreeViewDetails = new ObservableCollection<string>();
            SearchDetails = new ObservableCollection<string>();
            PopulateTreeViewItems();
            PopulateSearchItems();
            }
        #endregion

        #region Events
        /// <summary>
        /// Initialize the event which Notifies when the selected item changes. 
        /// </summary>    
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the command for changed item.
        /// </summary>
        [Category("Summary")]
        public ICommand ChangeSelectedItemCommand
        {
            get { return changeSelectedItemCommand; }
            set { changeSelectedItemCommand = value; }
        }

        /// <summary>
        /// Gets or sets the command for deleted mails.
        /// </summary>
        [Category("Summary")]
        public ICommand DeleteMailCommand
        {
            get { return deleteMailCommand; }
            set { deleteMailCommand = value; }
        }

        /// <summary>
        /// Gets or sets the collection of selected mails.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<SortedMailCollection> SelectedMailCollection
        {
            get { return mainMailCollection; }
            set { mainMailCollection = value; Notify("SelectedMailCollection"); }
        }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<ContactModel> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<NoteModel> Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        /// <summary>
        /// Gets or sets the selected tree view item.
        /// </summary>
        [Category("Summary")]
        public object SelectedTreeViewItem
        {
            get { return selectedTreeViewItem; }
            set { selectedTreeViewItem = value;
                Notify("SelectedTreeViewItem");
                TreeItemChanged(value); ;
            }
        }

        /// <summary>
        /// Gets or sets the sub items.
        /// </summary>
        [Category("Summary")]
       public ObservableCollection<GroupbarSubItem> SubItems
        {
            get { return subItems; }
            set { subItems = value; }
        }

        /// <summary>
        /// Gets or sets the tree view details.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<string> TreeViewDetails
        {
            get { return treeViewDetails; }
            set { treeViewDetails = value; }
        }

        /// <summary>
        /// Gets or sets the search details.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<string> SearchDetails
        {
            get { return searchDetails; }
            set { searchDetails = value; }
        }
        #endregion

        #region Helper methods
       /// <summary>
       /// Adding notes to the collection.
       /// </summary>
       /// <returns></returns>
        private ObservableCollection<NoteModel> GetNotes()
        {
            ObservableCollection<NoteModel> _notes = new ObservableCollection<NoteModel>();
            _notes.Add(new NoteModel() { Message = "Meeting with robb at 7PM" });
            _notes.Add(new NoteModel() { Message = "Package delivered on monday" });
            _notes.Add(new NoteModel() { Message = "Due at tuesday" });
            _notes.Add(new NoteModel() { Message = "License need to be renewed" });
            return _notes;
        }
       
        /// <summary>
        /// Adding contacts to the contacts collection.
        /// </summary>
        /// <returns>Return the collection of contacts</returns>
        private ObservableCollection<ContactModel> GetContacts()
        {
            List<ContactModel> contacts = new List<ContactModel>();
            contacts.Add(new ContactModel() { Name = "Alfreds", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Maria", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Anders", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Thomas", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Hardy", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Christina", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Berglunds", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Berguvsvägen", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Anil", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Victoria", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Peter", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Robert", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Red", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Brandon", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Charles", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Arya", PhoneNumber = "" });
            contacts.Add(new ContactModel() { Name = "Tom", PhoneNumber = "" });
            contacts.Sort();
            return new ObservableCollection<ContactModel>(contacts);
        }
      
        /// <summary>
        /// Get mails to tree items.
        /// </summary>
        /// <param name="value">Value populated to the tree view items</param>
        private void TreeItemChanged(object value)
        {
            if (value.ToString() == "customer@support.com")
                this.SelectedMailCollection = GetInboxMails();
            else
            if (value.ToString() == "Sent Items")
                this.SelectedMailCollection = GetSentMails();
            else
                if (value.ToString() == "Inbox")
                this.SelectedMailCollection = GetInboxMails();
            else
                this.SelectedMailCollection = null;
        }

         /// <summary>
         /// Transfer the mails to the main mail collection.
         /// </summary>
         /// <param name="obj">Getting mails to main mail collection from inbox</param>
        private void ChangeSelectedItem(object obj)
        {
            mainMailCollection = GetInboxMails();
        }

        /// <summary>
        /// Method used to check the changes.
        /// </summary>
        /// <param name="arg">Check the changes</param>
        /// <returns>Returns the changes</returns>
        private bool CanChange(object arg)
        {
            return true;
        }
      
        /// <summary>
        /// Method which is used to delete the mail.
        /// </summary>
        /// <param name="arg">Parameter used to delete the mail</param>
        private void DeleteMail(object arg)
        {
            MailModel temp = arg as MailModel;
            SortedMailCollection emptyCollection = null;
            bool isdeleted = false;
            foreach (var sortedcoll in this.SelectedMailCollection)
            {
                foreach (MailModel mail in sortedcoll.MailCollection)
                {
                    if (temp == mail)
                    {
                        sortedcoll.MailCollection.Remove(temp);
                        if (sortedcoll.MailCollection.Count == 0)
                            emptyCollection = sortedcoll;
                        isdeleted = true;
                        break;
                    }
                }
                if (isdeleted)
                {
                    if (emptyCollection != null)
                    {
                        this.SelectedMailCollection.Remove(emptyCollection);
                    }
                    break;
                }
            }
        }
       
        /// <summary>
        /// Method which is used to check whether the mail can delete or not.
        /// </summary>
        /// <param name="obj">Used to check the mail can be delete</param>
        /// <returns>Returns true</returns>
        private bool candelete(object obj)
        {
            return true;
        }
       
        /// <summary>
        /// Method which is used to add the items to the catogory.
        /// </summary>
        /// <returns>Return the mail headers</returns>
        private ObservableCollection<MailCategory> GetMails()
        {
            ObservableCollection<MailCategory> _mails = new ObservableCollection<MailCategory>();
            _mails.Add(new MailCategory() { Header = "Inbox", MailCollection = null });
            _mails.Add(new MailCategory() { Header = "Sent Items"});
            _mails.Add(new MailCategory() { Header = "Drafts", MailCollection = GetDraftsMails() });
            _mails.Add(new MailCategory() { Header = "Junk", MailCollection = GetJunkMails() });
            _mails.Add(new MailCategory() { Header = "Deleted Items" });
            _mails.Add(new MailCategory() { Header = "Archieve" });
            _mails.Add(new MailCategory() { Header = "Outbox" });

            return _mails;
        }
       
        /// <summary>
        /// Method which is used to get the junkmails.
        /// </summary>
        /// <returns>Returns the jun mails</returns>
        private ObservableCollection<MailModel> GetJunkMails()
        {
            ObservableCollection<MailModel> junk = new ObservableCollection<MailModel>();
            for (int i = 0; i < 5; i++)
            {
                MailModel mail = GetMail();
                mail.Category = "Junk";
                junk.Add(mail);
            }
            return junk;
        }
      
        /// <summary>
        /// Method which is used to get the draftmails.
        /// </summary>
        /// <returns>Return the draft items</returns>
        private ObservableCollection<MailModel> GetDraftsMails()
        {
            ObservableCollection<MailModel> drafts = new ObservableCollection<MailModel>();
            for (int i = 0; i < 5; i++)
            {
                MailModel mail = GetMail();
                mail.Category = "Drafts";
                drafts.Add(mail);
            }
            return drafts;
        }
       
        /// <summary>
        /// Method which used to get the sentmail items.
        /// </summary>
        /// <returns>Returns the sent mails</returns>
        private ObservableCollection<SortedMailCollection> GetSentMails()
        {

            ObservableCollection<SortedMailCollection> inboxMails = new ObservableCollection<SortedMailCollection>();
            SortedMailCollection sorted1 = new SortedMailCollection();
            sorted1.Header = "Today";
            MailModel mail1 = new MailModel();
            mail1.Sender = "Maria Anders";
            mail1.To = "Jane Jonk";
            mail1.Subject = "Regarding Meeting";
            mail1.IsUnRead = false;
            mail1.Message = @" Hi Jane Jonk,

                               Can we schedule Meeting Appointment for today?.
  
                               Thanks,
                               Maria Anders.";
            sorted1.MailCollection.Add(mail1);
            MailModel mail2 = new MailModel();
            mail2.Sender = "Thomas Hardy";
            mail2.To = "Chris Kol";
            mail2.Subject = "Customer has accpeted...";
            mail2.IsUnRead = false;
            mail2.Message = @" 
                            Hi Chris Kol,

                            Customer has accepted our proposal. Would it be possible for arrange meeting tomorrow?.
  
                            Thanks,
                            Thomas Hardy.";
            sorted1.MailCollection.Add(mail2);
            MailModel mail3 = new MailModel();
            mail3.Sender = "Christina Berglund";
            mail3.To = "Dev Khar";
            mail3.Subject = "Greeting";
            mail3.IsUnRead = false;
            mail3.Message = @" Hi Dev Khar,

                                Merry Christmas.
  
                                Thanks,
                                Christina Berglund.";
            inboxMails.Add(sorted1);

            SortedMailCollection sorted2 = new SortedMailCollection();
            sorted2.Header = "Yesterday";
            MailModel mail4 = new MailModel();
            mail4.Sender = "Martín Sommer";
            mail4.To = "Anil Pahr";
            mail4.Subject = "Please come and collect ";
            mail4.IsUnRead = false;
            mail4.Message = @"  Hi Anil Pahr,

                                Please come and collect the rent receipt.
  
                                Thanks,
                                Martín Sommer.";
            sorted2.MailCollection.Add(mail4);

            MailModel mail5 = new MailModel();
            mail5.Sender = "Victoria Ashworth";
            mail5.To = "Shanakar";
            mail5.Subject = "Regarding meeting";
            mail5.IsUnRead = false;
            mail5.Message = @"  Hi Shanakar,

    Yes we are available for meeting tomorrow.
  
    Thanks,
    Victoria Ashworth.";
            sorted2.MailCollection.Add(mail5);
            MailModel mail6 = new MailModel();
            mail6.Sender = "Yang Wang.";
            mail6.To = "Krish Kael";
            mail6.Subject = "Schedule meeting";
            mail6.IsUnRead = false;
            mail6.Message = @"  Hi Krish Kael,

    Please schedule the meeting on tomorrow.
  
    Thanks,
    Yang Wang.";
            sorted2.MailCollection.Add(mail6);
            SortedMailCollection sorted3 = new SortedMailCollection();
            sorted3.Header = "LastWeek";
            MailModel mail7 = new MailModel();
            mail7.Sender = "Sven Ottlieb";
            mail7.To = "Marie Krilsh";
            mail7.Subject = "Greeting";
            mail7.IsUnRead = false;
            mail7.Message = @"  
    Hi Marie Krilsh,

    Merry Christmas.
  
    Thanks,
    Sven Ottlieb.";
            sorted3.MailCollection.Add(mail7);
            MailModel mail8 = new MailModel();
            mail8.Sender = "Aria Cruz";
            mail8.To = "Maria Krilsh";
            mail8.Subject = "New year Greeting";
            mail8.IsUnRead = false;
            mail8.Message = @" Hi Maria Krilsh,

    I wish you Happy new year..
  
    Thanks,
    Aria Cruz.";
            sorted3.MailCollection.Add(mail8);
            MailModel mail9 = new MailModel();
            mail9.Sender = "Diego Roel";
            mail9.To = "Michael";
            mail9.Subject = "Weekend Greeting";
            mail9.IsUnRead = false;
            mail9.Message = @" Hi Michael,

    Have a Great Weekend.
  
    Thanks,
    Diego Roel.";
            sorted3.MailCollection.Add(mail9);

            SortedMailCollection sorted4 = new SortedMailCollection();
            sorted4.Header = "Last Month";
            MailModel mail10 = new MailModel();
            mail10.Sender = "Paolo Accorti.";
            mail10.To = "John Michael";
            mail10.Subject = "Greeting";
            mail10.IsUnRead = false;
            mail10.Message = @"   Hi John Michael,

    Have a Great Day.
  
    Thanks,
    Paolo Accorti.";
            sorted4.MailCollection.Add(mail10);
            inboxMails.Add(sorted2);
            inboxMails.Add(sorted4);
            return inboxMails;
  
        }

        /// <summary>
        /// Method which is used to get the inbox mail items.
        /// </summary>
        /// <returns>Returns </returns>
        private ObservableCollection<SortedMailCollection> GetInboxMails()
        {
            ObservableCollection<SortedMailCollection> inboxMails = new ObservableCollection<SortedMailCollection>();
            SortedMailCollection sorted1 = new SortedMailCollection();
            sorted1.Header = "Today";
            MailModel mail1 = new MailModel();
            mail1.Sender = "Maria Anders";
            mail1.To = "Jane Jonk";
            mail1.Subject = "Regarding Meeting";
            mail1.IsUnRead = true;
            mail1.Message = @" Hi Jane Jonk,

                               Can we schedule Meeting Appointment for today?.
  
                               Thanks,
                               Maria Anders.";
            sorted1.MailCollection.Add(mail1);
            MailModel mail2 = new MailModel();
            mail2.Sender = "Thomas Hardy";
            mail2.To = "Chris Kol";
            mail2.Subject = "Customer has accpeted...";
            mail2.IsUnRead = true;
            mail2.Message = @" 
                            Hi Chris Kol,

                            Customer has accepted our proposal. Would it be possible for arrange meeting tomorrow?.
  
                            Thanks,
                            Thomas Hardy.";
            sorted1.MailCollection.Add(mail2);
            MailModel mail3 = new MailModel();
            mail3.Sender = "Christina Berglund";
            mail3.To = "Dev Khar";
            mail3.Subject = "Greeting";
            mail3.IsUnRead = false;
            mail3.Message = @" Hi Dev Khar,

                                Merry Christmas.
  
                                Thanks,
                                Christina Berglund.";
            sorted1.MailCollection.Add(mail3);
            inboxMails.Add(sorted1);

            SortedMailCollection sorted2 = new SortedMailCollection();
            sorted2.Header = "Yesterday";
            MailModel mail4 = new MailModel();
            mail4.Sender = "Martín Sommer";
            mail4.To = "Anil Pahr";
            mail4.Subject = "Please come and collect ";
            mail4.IsUnRead = false;
            mail4.Message = @"  Hi Anil Pahr,

                                Please come and collect the rent receipt.
  
                                Thanks,
                                Martín Sommer.";
            sorted2.MailCollection.Add(mail4);

            MailModel mail5 = new MailModel();
            mail5.Sender = "Victoria Ashworth";
            mail5.To = "Shanakar";
            mail5.Subject = "Regarding meeting";
            mail5.IsUnRead = false;
            mail5.Message = @"  Hi Shanakar,

    Yes we are available for meeting tomorrow.
  
    Thanks,
    Victoria Ashworth.";
            sorted2.MailCollection.Add(mail5);
            MailModel mail6 = new MailModel();
            mail6.Sender = "Yang Wang.";
            mail6.To = "Krish Kael";
            mail6.Subject = "Schedule meeting";
            mail6.IsUnRead = false;
            mail6.Message = @"  Hi Krish Kael,

    Please schedule the meeting on tomorrow.
  
    Thanks,
    Yang Wang.";
            sorted2.MailCollection.Add(mail6);
            SortedMailCollection sorted3 = new SortedMailCollection();
            sorted3.Header = "LastWeek";
            MailModel mail7 = new MailModel();
            mail7.Sender = "Sven Ottlieb";
            mail7.To = "Marie Krilsh";
            mail7.Subject = "Greeting";
            mail7.IsUnRead = false;
            mail7.Message = @"  
    Hi Marie Krilsh,

    Merry Christmas.
  
    Thanks,
    Sven Ottlieb.";
            sorted3.MailCollection.Add(mail7);
            MailModel mail8 = new MailModel();
            mail8.Sender = "Aria Cruz";
            mail8.To = "Maria Krilsh";
            mail8.Subject = "New year Greeting";
            mail8.IsUnRead = false;
            mail8.Message = @" Hi Maria Krilsh,

    I wish you Happy new year..
  
    Thanks,
    Aria Cruz.";
            sorted3.MailCollection.Add(mail8);
            MailModel mail9 = new MailModel();
            mail9.Sender = "Diego Roel";
            mail9.To = "Michael";
            mail9.Subject = "Weekend Greeting";
            mail9.IsUnRead = false;
            mail9.Message = @" Hi Michael,

    Have a Great Weekend.
  
    Thanks,
    Diego Roel.";
            sorted3.MailCollection.Add(mail9);

            SortedMailCollection sorted4 = new SortedMailCollection();
            sorted4.Header = "Last Month";
            MailModel mail10 = new MailModel();
            mail10.Sender = "Paolo Accorti.";
            mail10.To = "John Michael";
            mail10.Subject = "Greeting";
            mail10.IsUnRead = false;
            mail10.Message = @"   Hi John Michael,
    Have a Great Day.
 
    Thanks,
    Paolo Accorti.";
            sorted4.MailCollection.Add(mail10);
            inboxMails.Add(sorted2);
            inboxMails.Add(sorted3);
            inboxMails.Add(sorted4);
            return inboxMails;
        }

        /// <summary>
        /// Method which is used to get the main mails.
        /// </summary>
        /// <returns></returns>
        public MailModel GetMail()
        {
            return new MailModel()
            {
                From = "sumoneannoying@mail.com",
                To = "thispc@mail.com",
                IsUnRead = false,
                CC = { },
                Sender = "Some One",
                Subject = "House loan",
                Message = @"adsjnfasdflksadfjlasdfasdf
                            asdfasdfasdfasdfasdfasdf
                            asdfa
                            sdf
                            asdf
                            asdfffffffffffffasdfasdfaskdfuhcaoisfjoasxdijfaosjfasdfijasdoifjazdofas
                            sadfaksdfoascfjasodifasodixfjaodfmjaofiasdofiasdkfnkcnkzxjcnaisdufhspuefhq
                            asdfhaspidfhaspdiufuhansdicjapse8fy p aw97efyaspidfhaspdifjaspdiufhar7ofapsdfvimalasdciunasidupisducnipaudshfaprhfasd
                            asduahsdcuinasiuahspfihaperifasidfjaso8fu9r8fhapisdfjapsidfhasry8ghapsdfknapsdofarup8gahsdifhmas
                            asdhfupiasdfhasr8fhaskdnvasndcaosdfijas[o9rugfaspodphvmasduifhpa7rhfasdufhapr8faosdifamosdchas[df8asd
                            ahsdipfuhaspidfhaspe8fuosdjasodiifjasodfias\asdipfuhas[dfhaspaisuhfasncnakxcna;sdfas;difjasd;fjasdfgasdgfasdfjasdfhas;kdfha;sdkfhask;djfhasdjfh
                            asdkkfhasdfhasdifhasodifamso[difjmasdpifhyrsAFHNSIDUHASD;IFA;SDFJAS;DFa;sidf;masdhf;asdifhasmdasj;difja;sdif;asdfija"
            };
        }

        /// <summary>
        ///  /// <summary>
        /// Event handling method for notified changes.
        /// </summary>
        /// <param name="name">Notify the changes</param>
        private void Notify(string name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// Add items to treeviews.
        /// </summary>
        private void PopulateTreeViewItems()
        {
            TreeViewDetails.Add("Inbox");
            TreeViewDetails.Add("Sent Items");
            TreeViewDetails.Add("Deleted Items");         
            TreeViewDetails.Add("Drafts");
            TreeViewDetails.Add("Junk Items");
            TreeViewDetails.Add("Outbox");
        }

        /// <summary>
        /// Add items to search combobox.
        /// </summary>
        private void PopulateSearchItems()
        {
            SearchDetails.Add("Current Folder");
            SearchDetails.Add("All Folder");
            SearchDetails.Add("Current Mailbox");
            SearchDetails.Add("All Mailbox");
            SearchDetails.Add("All Outlook Items");       
        }
    }
    #endregion
}
