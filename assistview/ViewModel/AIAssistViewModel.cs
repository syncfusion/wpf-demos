using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Newtonsoft.Json;
using Syncfusion.UI.Xaml.Chat;
using Microsoft.Extensions.AI;

namespace syncfusion.assistviewdemo.wpf.ViewModel
{
    internal class AIAssistViewModel : INotifyPropertyChanged
    {
        internal bool isStopResponding;

        private Author currentUser;
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

        public SfAIAssistView assistView
        {
            get;
            set;
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

        private IEnumerable<string> suggestion;
        public IEnumerable<string> Suggestion
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

        AIAssistChatService<Response> service;

        public DataTemplate AIIcon { get; set; }

        public AIAssistViewModel()
        {
            this.Chats = new ObservableCollection<object>();
            this.Chats.CollectionChanged += Chats_CollectionChanged1;
            this.Suggestion = new List<string>();
            this.CurrentUser = new Author { Name = "John" };
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
                    { goalSuggest, goalSolution},
                    { toolSuggest, toolSolution}
                },
            };

            await service.Initialize();
            Suggestion = new List<string>(service.Suggestions);
            Chats.Add(new AIMessage
            {
                Author = new Author { Name = "Bot", ContentTemplate = AIIcon },
                DateTime = DateTime.Now,
                Text = "I am an AI assistant.\n" +
                "Ask anything you want to know",
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

        private async void Chats_CollectionChanged1(object sender, NotifyCollectionChangedEventArgs e)
        {
            var item = e.NewItems?[0] as ITextMessage;
            if (item != null)
            {
                if (item.Author.Name == currentUser.Name && service != null)
                {
                    ShowTypingIndicator = true;
                    await service.NonStreamingChat(item.Text);
                    await Task.Delay(500);
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
                    Suggestion = new List<string>(service.Suggestions);
                }
                isStopResponding = false;
            }
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

    public class AIAssistChatService<T> where T : Response
    {
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

        public string Requirement { get; set; }
        public Dictionary<string, string> OfflineContent { get; set; } = new Dictionary<string, string>();
        public string Response { get; set; }
        public List<string> Suggestions { get; set; } = new List<string>();
        public async Task Initialize()
        {
            if (!AISettings.IsCredentialValid)
            {
                AISettings.ShowAISettingsWindow();
            }

            if (AISettings.IsCredentialValid)
            {
                await AISettings.ClientAI.CompleteAsync(Requirement);
            }

            Suggestions = OfflineContent.Keys.ToList();
        }

        Random r = new Random();
        public async Task<T> NonStreamingChat(string line)
        {
            Response = string.Empty;
            T res = default(T);
            var actLine = line;
            try
            {
                line += $"[variation: {Guid.NewGuid()}]";
                if (AISettings.IsCredentialValid)
                {
                    Requirement = String.Format(line + "Give required information in markdown format along with next 3 possible questions the user might ask, send the response in json schema.{0}", GenerateJsonSchema(typeof(Response)));
                    var response = await AISettings.ClientAI.CompleteAsync(Requirement);
                    var json = response.ToString();
                    json = json.Replace("```json", "");
                    json = json.Replace("```", "");
                    res = JsonConvert.DeserializeObject<T>(json);
                    Response = res.AIResponse;
                    Suggestions = res.Suggestions;
                }
                else
                {
                    await Task.Delay(2000);
                }
            }
            catch (Exception ex)
            {
                Response = ex.Message;
            }
            if (res == null)
            {
                if (OfflineContent.ContainsKey(actLine))
                {
                    string response;
                    OfflineContent.TryGetValue(actLine, out response);
                    Response = response;
                    Suggestions = OfflineContent.Keys.ToList();
                }

                if (string.IsNullOrEmpty(Response))
                {
                    Response = "For real-time prompt processing, connect the AIAssistView component to your preferred AI service, " +
                        "such as OpenAI or Azure Cognitive Services. " +
                        "Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
                }
            }

            return res;
        }

        public async Task ResponseToolbarItemClicked(ResponseToolbarItemClickedEventArgs e, ObservableCollection<object> chats)
        {
            if (e.Item.ItemType == ToolBarItemType.Regenerate)
            {
                var aiMessage = e.ChatItem.DataContext as AIMessage;
                var regenerateIndex = chats.IndexOf(aiMessage);

                if (regenerateIndex > 0)
                {
                    var question = (chats[regenerateIndex - 1] as TextMessage)?.Text;
                    string message = string.Empty;
                    try
                    {
                        await NonStreamingChat(question);
                        message = Response;
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                    }
                    chats[regenerateIndex] = new AIMessage
                    {
                        Author = aiMessage.Author,
                        DateTime = aiMessage.DateTime,
                        Text = message
                    };
                }
            }
        }
    }

    public class Response
    {
        public string AIResponse { get; set; }
        public List<string> Suggestions { get; set; }
    }

    public class AIMessage : NotificationObject, Syncfusion.UI.Xaml.Chat.ITextMessage
    {

        private string solution;

        /// <summary>
        /// Gets or sets the text to be display as the message.
        /// </summary>
        public string Solution
        {
            get
            {
                return this.solution;
            }
            set
            {
                this.solution = value;
                RaisePropertyChanged(nameof(Solution));
            }
        }

        private Author author;

        /// <summary>
        /// Gets or sets the author to be display in the message.
        /// </summary>
        public Author Author
        {
            get { return author; }
            set
            {
                author = value;
                RaisePropertyChanged(nameof(Author));
            }
        }

        private DateTime dateTime;

        /// <summary>
        /// Gets or sets the date and time details when the message was created.
        /// </summary>
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                RaisePropertyChanged(nameof(DateTime));
            }
        }

        private string text;

        /// <summary>
        /// Gets or sets the text to be display as the message.
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; RaisePropertyChanged(nameof(Text)); }
        }
    }

    public class ViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AITemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is AIMessage)
            {
                return AITemplate;
            }
            return null;
        }
    }
}
