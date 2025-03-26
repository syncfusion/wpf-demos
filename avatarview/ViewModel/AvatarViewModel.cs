#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace syncfusion.avatarviewdemo.wpf.ViewModel
{
    public class AvatarViewModel
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string participants;

        public string Participants
        {
            get { return participants; }
            set { participants = value; }
        }

        public ObservableCollection<Model.Model> PeopleCollection { get; set; }

        public ObservableCollection<Model.Model> GroupViewCollection { get; set; }

        public AvatarViewModel(int count)
        {
            PopulateModel();
            PopulatePeopleCollection(count);
        }

        static int count = 0;

        private void PopulatePeopleCollection(int peopleCount)
        {
            PeopleCollection = new ObservableCollection<Model.Model>();
            for (int i = 0; i < peopleCount; i++)
            {
                while (true)
                {
                    if (GroupViewCollection.Count <= count)
                        count = 0;

                    var person = GroupViewCollection[count++];
                    if (!PeopleCollection.Contains(person))
                    {
                        PeopleCollection.Add(person);
                        break;
                    }
                }
            }
        }

        private void PopulateModel()
        {
            string imagePath = "pack://application:,,,/syncfusion.avatarviewdemos.wpf;component/Assets/AvatarView/";

#if Main_SB
            path = "AvatarView /";
#endif
            GroupViewCollection = new ObservableCollection<Model.Model>
            {
                new Model.Model() { Name = "Adriana", BackgroundColor = Color.FromArgb(0xFF, 0xF2, 0xE9, 0xC8), InitialColor = Color.FromArgb(0xFF, 0x69, 0x53, 0x1C) },
                new Model.Model() { Name = "Haven", BackgroundColor = Color.FromArgb(0xFF, 0xD6, 0xE8, 0xD7), InitialColor = Color.FromArgb(0xFF, 0x24, 0x4F, 0x23) },
                new Model.Model() { Name = "Karla", BackgroundColor = Color.FromArgb(0xFF, 0xD6, 0xE3, 0xE8), InitialColor = Color.FromArgb(0xFF, 0x1A, 0x5F, 0x6F) },
                new Model.Model() { Name = "Davis", BackgroundColor = Color.FromArgb(0xFF, 0xF2, 0xE9, 0xC8), InitialColor = Color.FromArgb(0xFF, 0x69, 0x53, 0x1C) },
                new Model.Model() { Name = "Clara", BackgroundColor = Color.FromArgb(0xFF, 0xD8, 0xFF, 0xF6), InitialColor = Color.FromArgb(0xFF, 0x06, 0x79, 0x6B), ImagePath = imagePath+ "Sarah.png" },
                new Model.Model() { Name = "Daleyza", BackgroundColor = Color.FromArgb(0xFF, 0xD2, 0xF1, 0xEF), InitialColor = Color.FromArgb(0xFF, 0x1D, 0x7B, 0x6A) },
                new Model.Model() { Name = "Ellie", BackgroundColor = Color.FromArgb(0xFF, 0xF2, 0xE9, 0xC8), InitialColor = Color.FromArgb(0xFF, 0x69, 0x53, 0x1C) },
                new Model.Model() { Name = "Finley", BackgroundColor = Color.FromArgb(0xFF, 0xF0, 0xD7, 0xE9), InitialColor = Color.FromArgb(0xFF, 0x7B, 0x1D, 0x67) },
                new Model.Model() { Name = "Jackson", BackgroundColor = Color.FromArgb(0xFF, 0xD6, 0xE8, 0xD7), InitialColor = Color.FromArgb(0xFF, 0x24, 0x4F, 0x23) },
                new Model.Model() { Name = "Jayden", BackgroundColor = Color.FromArgb(0xFF, 0xD6, 0xE3, 0xE8), InitialColor = Color.FromArgb(0xFF, 0x1A, 0x5F, 0x6F) },
                new Model.Model() { Name = "Kaylee", BackgroundColor = Color.FromArgb(0xFF, 0xD8, 0xD7, 0xF0), InitialColor = Color.FromArgb(0xFF, 0x25, 0x1D, 0x7B), ImagePath=imagePath + "Gabriella.png"},
                new Model.Model() { Name = "Lucy", BackgroundColor = Color.FromArgb(0xFF, 0xF0, 0xD7, 0xE9), InitialColor = Color.FromArgb(0xFF, 0x7B, 0x1D, 0x67), ImagePath = imagePath + "Victoriya.png"},
                new Model.Model() { Name = "Jaden", BackgroundColor = Color.FromArgb(0xFF, 0xD2, 0xF1, 0xEF), InitialColor = Color.FromArgb(0xFF, 0x1D, 0x7B, 0x6A) },
                new Model.Model() { Name = "George", BackgroundColor = Color.FromArgb(0xFF, 0xFB, 0xE3, 0xDB), InitialColor = Color.FromArgb(0xFF, 0x7B, 0x2E, 0x1D),ImagePath = imagePath + "Michael.png"},
                new Model.Model() { Name = "Jayden", BackgroundColor = Color.FromArgb(0xFF, 0xF2, 0xE9, 0xC8), InitialColor = Color.FromArgb(0xFF, 0x69, 0x53, 0x1C) },
                new Model.Model() { Name = "Ellanaa", BackgroundColor = Color.FromArgb(0xFF, 0xD6, 0xE8, 0xD7), InitialColor = Color.FromArgb(0xFF, 0x24, 0x4F, 0x23) },
                new Model.Model() { Name = "James", BackgroundColor = Color.FromArgb(0xFF, 0xD6, 0xE3, 0xE8), InitialColor = Color.FromArgb(0xFF, 0x1A, 0x5F, 0x6F), ImagePath = imagePath + "Oscar.png"},
                new Model.Model() { Name = "Zelda", BackgroundColor = Color.FromArgb(0xFF, 0xD8, 0xD7, 0xF0), InitialColor = Color.FromArgb(0xFF, 0x25, 0x1D, 0x7B), ImagePath = imagePath + "Jayden.png"},
                new Model.Model() { Name = "Wren", BackgroundColor = Color.FromArgb(0xFF, 0xF0, 0xD7, 0xE9), InitialColor = Color.FromArgb(0xFF, 0x7B, 0x1D, 0x67) },
                new Model.Model() { Name = "Yamileth", BackgroundColor = Color.FromArgb(0xFF, 0xF4, 0xFF, 0xD6), InitialColor = Color.FromArgb(0xFF, 0x42, 0x58, 0x03) },
                new Model.Model() { Name = "Briley", BackgroundColor = Color.FromArgb(0xFF, 0xFB, 0xE3, 0xDB), InitialColor = Color.FromArgb(0xFF, 0x7B, 0x2E, 0x1D), ImagePath = imagePath + "Finley.png"}
            };
        }
    }
}
