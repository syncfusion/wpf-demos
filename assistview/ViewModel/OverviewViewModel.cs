#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.assistviewdemo.wpf.ViewModel
{
    internal class OverviewViewModel : INotifyPropertyChanged
    {
        private Author currentUser;
        AIAssistChatService<Response> service;
        internal bool isStopResponding;

        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        private ObservableCollection<object> chats;
        public ObservableCollection<object> Chats
        {
            get
            {
                return this.chats;
            }
            set
            {
                this.chats = value;
                RaisePropertyChanged("Messages");
            }
        }

        private bool showTypingIndicator;
        public bool ShowTypingIndicator
        {
            get
            {
                return this.showTypingIndicator;
            }
            set
            {
                this.showTypingIndicator = value;
                RaisePropertyChanged("ShowTypingIndicator");
            }
        }

        private ObservableCollection<string> suggestion;
        public ObservableCollection<string> Suggestion
        {
            get
            {
                return this.suggestion;
            }
            set
            {
                this.suggestion = value;
                RaisePropertyChanged("Suggestion");
            }
        }
        public DataTemplate AIIcon { get; set; }

        public OverviewViewModel()
        {
            this.Chats = new ObservableCollection<object>();
            this.Chats.CollectionChanged += Chats_CollectionChanged1;
            this.Suggestion = new ObservableCollection<string>();
            this.CurrentUser = new Author { Name = "John" };
        }

        private async void Chats_CollectionChanged1(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var item = e.NewItems?[0] as ITextMessage;
            if (item != null)
            {
                if (item.Author.Name == currentUser.Name)
                {
                    Suggestion.Clear();
                    ShowTypingIndicator = true;
                    await service.NonStreamingChat(item.Text);
                    Suggestion = new ObservableCollection<string>(service.Suggestions);
                    if (!isStopResponding)
                    {
                        Chats.Add(new AIMessage
                        {
                            Author = new Author { Name = "Bot", ContentTemplate = AIIcon },
                            DateTime = DateTime.Now,
                            Text = service.Response
                        });
                    }
                    ShowTypingIndicator = false;
                }
                isStopResponding = false;
            }
        }

        public async void InitAI()
        {
            string goalSuggest = "How do I set daily goals in my work day?";
            string goalSolution = "To stay focused and productive, try these steps for setting daily goals:\n\n" +
                            "- **Identify Priorities**: List the most important tasks based on deadlines or significance.\n" +
                            "- **Break Down Tasks**: Split larger tasks into smaller, manageable steps.\n" +
                            "- **Set SMART Goals**: Make sure goals are Specific, Measurable, Achievable, Relevant, and Time-bound.\n" +
                            "- **Time Blocking**: Allocate specific times for each task to stay organized and on track.\n" +
                            "Would you like more tips on any of these steps?";

            string toolSuggest = "What tools or apps can help me prioritize tasks?";
            string toolSolution = "Here are some tools to help you prioritize tasks effectively:\n\n"
                + "- **Google Keep**: For simple note-taking and task organization with labels and reminders.\n"
                + "- **Scoro**: A project management tool for streamlining activities and team collaboration.\n"
                + "- **Evernote**: Great for note-taking, to-do lists, and reminders.\n"
                + "- **Todoist**: A powerful task manager for setting priorities and tracking progress.\n"
                + "Are you looking for tools to manage a specific type of task or project?";

            service = new AIAssistChatService<Response>
            {
                Requirement = string.Format("I am an AI assistant that helps people find information, " +
               "Give required information in markdown format along with next 3 possible questions the user might ask, " +
               "send the response in json schema.{0}", GenerateJsonSchema(typeof(Response))),
                OfflineContent = new Dictionary<string, string>
                {
                     {goalSuggest, goalSolution },
                    {toolSuggest, toolSolution }
                },
                //Conversation = new ChatHistory()
            };

            await service.Initialize();
            Suggestion = new ObservableCollection<string>(service.Suggestions);

            Chats.Add(new AIMessage
            {
                Author = new Author { Name = "Bot", ContentTemplate = AIIcon },
                DateTime = DateTime.Now,
                Text = "Hello! I'm your AI assistant. Ask me anything, and I'll be here to assist. How can I help you today?",
            });

        }
        public static string GenerateJsonSchema(Type type)
        {
            var store =
@"{
  ""type"": ""object"",
  ""properties"": {
    ""AIResponse"": {
      ""type"": [
        ""string"",
        ""null""
      ]
    },
    ""Suggestions"": {
      ""type"": [
        ""array"",
        ""null""
      ],
      ""items"": {
        ""type"": [
          ""string"",
          ""null""
        ]
      }
    }
  },
  ""required"": [
    ""AIResponse"",
    ""Suggestions""
  ]
}";
            return store;
        }

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        internal async void ResponseToolbarItemClicked(ResponseToolbarItemClickedEventArgs e)
        {
            ShowTypingIndicator = true;
            await service.ResponseToolbarItemClicked(e, chats);
            ShowTypingIndicator = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
