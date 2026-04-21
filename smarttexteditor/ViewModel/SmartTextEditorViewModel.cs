#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
using System.Threading.Tasks;

namespace syncfusion.smarttexteditordemos.wpf.ViewModel
{
    public class SmartTextEditorViewModel
    {
        private string userRole;
        public string UserRole
        {
            get { return userRole; }
            set
            {
                if (userRole != value)
                {
                    userRole = value;
                    OnPropertyChanged(nameof(UserRole));
                }
            }
        }

        public ObservableCollection<Role> Roles { get; }

        private Role selectedRole;
        public Role SelectedRole
        {
            get => selectedRole;
            set
            {
                if (selectedRole != value)
                {
                    selectedRole = value;
                    UserRole = selectedRole?.Text;
                    OnPropertyChanged(nameof(SelectedRole));
                }
            }
        }

        public SmartTextEditorViewModel()
        {
            Roles = new ObservableCollection<Role>
            {
                new Role
                {
                    ID = "Role1",
                    Text = "Open-source project maintainer replying to issues",
                    SuggestionPhrases =
                    {
                        "Thanks for reporting this!",
                        "Could you share the steps to reproduce?",
                        "Looks like this might be a duplicate of #{issue}.",
                        "Please try the latest version.",
                        "Can you provide your OS and framework details?"
                    }
                },
                new Role
                {
                    ID = "Role2",
                    Text = "Employee collaborating with team",
                    SuggestionPhrases =
                    {
                        "Here’s the latest update.",
                        "Let’s discuss this in the next meeting.",
                        "I’ll handle this task.",
                        "Moving this to the next sprint.",
                        "Please review and share your thoughts."
                    }
                },
                new Role
                {
                    ID = "Role3",
                    Text = "Support agent helping customers",
                    SuggestionPhrases =
                    {
                        "Thanks for reaching out!",
                        "I understand this can be frustrating.",
                        "Could you share a screenshot?",
                        "We’re checking this and will update soon.",
                        "Try clearing cache and restarting the app."
                    }
                },
                new Role
                {
                    ID = "Role4",
                    Text = "Sales rep responding to client queries",
                    SuggestionPhrases =
                    {
                        "Thank you for your interest!",
                        "I can arrange a quick demo for you.",
                        "I’ll send pricing details shortly.",
                        "Could you share your timeline?",
                        "Let me know a good time for a call."
                    }
                }
            };

            SelectedRole = Roles[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class Role
    {
        public string ID { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public List<string> SuggestionPhrases { get; } = new List<string>();
    }
}
