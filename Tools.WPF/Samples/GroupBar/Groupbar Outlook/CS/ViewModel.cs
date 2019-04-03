#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
    public class ViewModel : INotifyPropertyChanged
    {
        private ICommand changeSelectedItemCommand;

        public ICommand ChangeSelectedItemCommand
        {
            get { return changeSelectedItemCommand; }
            set { changeSelectedItemCommand = value; }
        }

        private ICommand deleteMailCommand;

        public ICommand DeleteMailCommand
        {
            get { return deleteMailCommand; }
            set { deleteMailCommand = value; }
        }

        private ObservableCollection<SortedMailCollection> mainMailCollection;

        public ObservableCollection<SortedMailCollection> SelectedMailCollection
        {
            get { return mainMailCollection; }
            set { mainMailCollection = value; Notify("SelectedMailCollection"); }
        }

        private ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

        public ObservableCollection<ContactModel> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

        private ObservableCollection<NoteModel> notes = new ObservableCollection<NoteModel>();

        public ObservableCollection<NoteModel> Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        private object selectedTreeViewItem;

        public object SelectedTreeViewItem
        {
            get { return selectedTreeViewItem; }
            set { selectedTreeViewItem = value;
                Notify("SelectedTreeViewItem");
                TreeItemChanged(value); ;
            }
        }

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

        
        //private ObservableCollection<MailCategory> mailCategories;

        //public ObservableCollection<MailCategory> MailCategories
        //{
        //    get { return mailCategories; }
        //    set { mailCategories = value; }
        //}

        //private object selectedCategory;

        //public object SelectedCategory
        //{
        //    get { return selectedCategory; }
        //    set 
        //    {
        //        if(value is MailCategory)
        //        selectedCategory = value;
        //        else
        //            if (value is MailModel)
        //            {
        //                selectedCategory = new ObservableCollection<MailCategory>(this.MailCategories.Where(p => p.Header == (value as MailModel).Category))[0];
        //            }
        //        Notify("SelectedCategory");
        //    }
        //}


        private ObservableCollection<GroupbarSubItem> subItems;

        public ObservableCollection<GroupbarSubItem> SubItems
        {
            get { return subItems; }
            set { subItems = value; }
        }
 

        public ViewModel()
        {
            
            deleteMailCommand = new DelegateCommand( DeleteMail,candelete);
            changeSelectedItemCommand = new DelegateCommand(ChangeSelectedItem, CanChange);
            mainMailCollection = GetInboxMails();
            contacts = GetContacts();
            Notes = GetNotes();
            //mailCategories = GetMails();
            //SubItems = new ObservableCollection<GroupbarSubItem>();
            //SubItems.Add(new GroupbarSubItem() { Content = mailCategories, Header = "Mail", Source = new BitmapImage(new Uri(@"/Images/Mail.png",UriKind.Relative)) });
            //SubItems.Add(new GroupbarSubItem() {  Header = "Calender"  });
            //SubItems.Add(new GroupbarSubItem() { Header = "People" });
            //SubItems.Add(new GroupbarSubItem() { Header = "To Do" });

        }

        private ObservableCollection<NoteModel> GetNotes()
        {
            ObservableCollection<NoteModel> _notes = new ObservableCollection<NoteModel>();
            _notes.Add(new NoteModel() { Message = "Meeting with robb at 7PM" });
            _notes.Add(new NoteModel() { Message = "Package delivered on monday" });
            _notes.Add(new NoteModel() { Message = "Due at tuesday" });
            _notes.Add(new NoteModel() { Message = "License need to be renewed" });
            return _notes;
        }

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

        private void ChangeSelectedItem(object obj)
        {
            mainMailCollection = GetInboxMails();
           // throw new NotImplementedException();
        }

        private bool CanChange(object arg)
        {
            return true;
        }

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

        private bool candelete(object obj)
        {
            return true;
        }

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
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
