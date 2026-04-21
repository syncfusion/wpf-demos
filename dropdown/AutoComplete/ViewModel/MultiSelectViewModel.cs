#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace syncfusion.dropdowndemos.wpf
{
    public class MultiSelectViewModel : NotificationObject
    {
        private ObservableCollection<ContactsInfo> contactData;
        public ObservableCollection<ContactsInfo> ContactData
        {
            get { return contactData; }
            set { contactData = value; }
        }

        private string toText;
        public string ToText
        {
            get { return toText; }
            set
            {
                toText = value;
                RaisePropertyChanged("ToText");
            }
        }

        private Visibility labelVisibility = Visibility.Visible;
        public Visibility LabelVisibility
        {
            get { return labelVisibility; }
            set
            {
                labelVisibility = value;
                RaisePropertyChanged("LabelVisibility");
            }
        }

        private string ccText;
        public string CcText
        {
            get { return ccText; }
            set
            {
                ccText = value;
                RaisePropertyChanged("CcText");
            }
        }
        private string bccText;
        public string BccText
        {
            get { return bccText; }
            set
            {
                bccText = value;
                RaisePropertyChanged("BccText");
            }
        }
        private ObservableCollection<object> toSelectedItem;
        public ObservableCollection<object> ToSelectedItem
        {
            get { return toSelectedItem; }
            set
            {
                toSelectedItem = value;
                RaisePropertyChanged("ToSelectedItem");
            }
        }

        private ObservableCollection<object> ccSelectedItem;
        public ObservableCollection<object> CcSelectedItem
        {
            get { return ccSelectedItem; }
            set
            {
                ccSelectedItem = value;
                RaisePropertyChanged("CcSelectedItem");
            }
        }
        private ObservableCollection<object> bccSelectedItem;
        public ObservableCollection<object> BccSelectedItem
        {
            get { return bccSelectedItem; }
            set
            {
                bccSelectedItem = value;
                RaisePropertyChanged("BccSelectedItem");
            }
        }
        public ICommand ClickCommand
        {
            get
            {
                return new DelegateCommand<object>(ClearSelectedItem);
            }
        }

        public ICommand EntryTextChanged
        {
            get;
            private set;
        }

        private void ClearSelectedItem(object context)
        {
            if (ToSelectedItem != null && ToSelectedItem.Count > 0)
            {
                ToSelectedItem = new ObservableCollection<object>();
                if (CcSelectedItem != null)
                {
                    CcSelectedItem = new ObservableCollection<object>();
                }

                if (BccSelectedItem != null)
                {
                    BccSelectedItem = new ObservableCollection<object>();
                }

                ToText = string.Empty;
                CcText = string.Empty;
                BccText = string.Empty;
                MessageBox.Show("Mail has been sent                                                        ", "Success", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.None);
            }
            else
            {
                MessageBox.Show("Must have atleast one recipient                                                        ", "", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.None);
            }
        }

        public MultiSelectViewModel()
        {
            EntryTextChanged = new DelegateCommand(EntryTextChangedMethod);
            contactData = new ObservableCollection<ContactsInfo>();
            ToSelectedItem = new ObservableCollection<object>();
            CcSelectedItem = new ObservableCollection<object>();
            BccSelectedItem = new ObservableCollection<object>();
            string[] CustomerNames = new string[]
            {
            "Kyle",
            "Victoriya",
            "Clara",
            "Ellie",
            "Gabriella",
            "Alexander",
            "Nora",
            "Lucy",
            "Sebastian",
            "Arianna",
            "Sarah",
            "Kaylee",
            "Jacob",
            "Adriana",
            "Ethan",
            "Finley",
            "Daleyza",
            "Leila",
            "Jayden",
            "Mckenna",
            "Jacqueline",
            "Brynn",
            "Sawyer",
            "Liam",
            "Rosalie",
            "Maci",
            "Mason",
            "Jackson",
            "Miranda",
            "Talia",
            "Shelby",
            "Haven",
            "Yaretzi",
            "Zariah",
            "Karla",
            "Zeke",
            "Cassandra",
            "Pearl",
            "Aiden",
            "Irene",
            "Zelda",
            "Wren",
            "Vince",
            "Yamileth",
            "Steve",
            "Belen",
            "Briley",
            "Jada",
            "Holly",
            "Jaden"
            };

            for (int i = 0; i < CustomerNames.Count(); i++)
            {
                var details = new ContactsInfo()
                {
                    Name = CustomerNames[i],
                    Email = CustomerNames[i].Replace(" ", "") + "@outlook.com",
                    Image = "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle" + (i % 30) + ".png"
                };
                contactData.Add(details);
            }

            ToSelectedItem.Add(contactData[1]);
            ToSelectedItem.Add(contactData[2]);
            ToSelectedItem.Add(contactData[3]);
        }

        private void EntryTextChangedMethod(object obj)
        {
            var textBox = (obj as TextBox);
            if (textBox != null)
            {
                if (textBox.Text.Length > 0)
                {
                    LabelVisibility = Visibility.Collapsed;
                }
                else
                {
                    LabelVisibility = Visibility.Visible;
                }
            }
        }
    }
}
