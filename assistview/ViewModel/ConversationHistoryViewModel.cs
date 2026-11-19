using Microsoft.Extensions.AI;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace syncfusion.assistviewdemo.wpf.ViewModel
{
    internal class ConversationHistoryViewModel : INotifyPropertyChanged
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
        private DataTemplate aiIcon;
        AIAssistChatService<Response> service;

        private Author botAuthor;

        public DataTemplate AIIcon
        {
            get { return aiIcon; }
            set
            {
                aiIcon = value;
                // Refresh the shared bot author's avatar template now that the
                // XAML resource has been applied. Without this every AIMessage
                // created in the constructor keeps a null ContentTemplate and
                // renders with the user avatar instead of the AI symbol.
                if (botAuthor != null)
                    botAuthor.ContentTemplate = value;
            }
        }

        private ObservableCollection<AssistConversationItem> conversations;
        public ObservableCollection<AssistConversationItem> Conversations
        {
            get { return this.conversations; }
            set
            {
                this.conversations = value;
                RaisePropertyChanged("Conversations");
            }
        }

        public ConversationHistoryViewModel()
        {
            this.Chats = new ObservableCollection<object>();
            this.CurrentUser = new Author { Name = "John" };

            var user = new Author { Name = "John" };
            this.botAuthor = new Author { Name = "Bot", ContentTemplate = AIIcon };
            var bot = this.botAuthor;


            this.Conversations = new ObservableCollection<AssistConversationItem>()
            {
                new AssistConversationItem
                {
                    Title = "How to Improve Code Quality",
                    DateTime = DateTime.Now.AddMinutes(-30),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddMinutes(-30),
                            Text = "How to Improve Code Quality"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddMinutes(-29),
                            Text = "**How to Improve Code Quality:**\n\n" +
                                   "1. Follow SOLID principles (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion) to create maintainable and scalable code.\n" +
                                   "2. Write comprehensive unit tests with high coverage to catch bugs early and facilitate refactoring with confidence.\n" +
                                   "3. Conduct regular code reviews to share knowledge, identify issues, and maintain consistent coding standards across the team.\n" +
                                   "4. Use static analysis tools like SonarQube or StyleCop to automatically detect code smells, security vulnerabilities, and potential bugs."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Best Practices for API Design",
                    DateTime = DateTime.Now.AddDays(-1),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-1),
                            Text = "Best Practices for API Design"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-1).AddMinutes(1),
                            Text = "**Best Practices for API Design:**\n\n" +
                                   "1. Use RESTful principles with clear resource models and proper HTTP methods (GET for retrieval, POST for creation, PUT for updates, DELETE for removal).\n" +
                                   "2. Implement API versioning (URL-based or header-based) to maintain backward compatibility while introducing new features.\n" +
                                   "3. Provide comprehensive API documentation using tools like Swagger/OpenAPI with examples, error codes, and authentication details.\n" +
                                   "4. Design consistent error responses, implement rate limiting, and use proper status codes to communicate API behavior clearly."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Cloud Migration Strategy",
                    DateTime = DateTime.Now.AddDays(-2),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-2),
                            Text = "Cloud Migration Strategy"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-2).AddMinutes(1),
                            Text = "**Cloud Migration Strategy:**\n\n" +
                                   "1. Assess current infrastructure by documenting applications, dependencies, performance metrics, and security requirements in detail.\n" +
                                   "2. Choose appropriate cloud services (IaaS, PaaS, SaaS) based on workload requirements, cost analysis, and organizational expertise.\n" +
                                   "3. Create a phased migration plan starting with non-critical systems, conducting thorough testing at each stage, and maintaining rollback procedures.\n" +
                                   "4. Monitor post-migration performance, optimize resource allocation, and continuously review costs to ensure ROI."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Database Optimization Tips",
                    DateTime = DateTime.Now.AddDays(-3),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-3),
                            Text = "Database Optimization Tips"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-3).AddMinutes(1),
                            Text = "**Database Optimization Tips:**\n\n" +
                                   "1. Implement proper indexing on frequently queried columns, but avoid over-indexing which can slow down write operations.\n" +
                                   "2. Optimize queries by using EXPLAIN plans, eliminating N+1 queries, and using appropriate JOIN strategies for your database system.\n" +
                                   "3. Implement connection pooling to reuse database connections efficiently and reduce overhead from establishing new connections.\n" +
                                   "4. Use caching strategies (Redis, Memcached) for frequently accessed data, and consider database partitioning for very large datasets to improve query performance."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Security Considerations",
                    DateTime = DateTime.Now.AddDays(-4),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-4),
                            Text = "Security Considerations"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-4).AddMinutes(1),
                            Text = "**Security Considerations:**\n\n" +
                                   "1. Implement robust authentication mechanisms (OAuth 2.0, JWT) and authorization frameworks (RBAC, ABAC) to control access to sensitive resources.\n" +
                                   "2. Encrypt sensitive data both in transit (TLS/SSL) and at rest using industry-standard encryption algorithms like AES-256.\n" +
                                   "3. Validate all user inputs on the server-side to prevent injection attacks, XSS, and other common vulnerabilities.\n" +
                                   "4. Conduct regular security audits, penetration testing, and stay updated with security patches to protect against emerging threats."
                        }
                    }
                },
                new AssistConversationItem
                {
                    Title = "Performance Tuning",
                    DateTime = DateTime.Now.AddDays(-5),
                    AssistItems = new ObservableCollection<object>
                    {
                        new TextMessage
                        {
                            Author = user,
                            DateTime = DateTime.Now.AddDays(-5),
                            Text = "Performance Tuning"
                        },
                        new AIMessage
                        {
                            Author = bot,
                            DateTime = DateTime.Now.AddDays(-5).AddMinutes(1),
                            Text = "**Performance Tuning:**\n\n" +
                                   "1. Profile your code using tools like dotTrace or profilers to identify bottlenecks and resource-intensive operations accurately.\n" +
                                   "2. Optimize algorithms by choosing appropriate data structures, reducing time complexity, and avoiding unnecessary computations.\n" +
                                   "3. Implement caching layers (distributed caches) and asynchronous processing to handle high loads and improve response times.\n" +
                                   "4. Use load balancing techniques and horizontal scaling to distribute traffic across multiple servers and ensure system reliability."
                        }
                    }
                }
            };
        }

        public async void InitAI()
        {
            var offlineContent = new Dictionary<string, string>();
            if (Conversations != null)
            {
                foreach (var item in Conversations)
                {
                    if (item == null || string.IsNullOrEmpty(item.Title) || item.AssistItems == null)
                        continue;

                    var aiText = item.AssistItems.OfType<AIMessage>().LastOrDefault();
                    if (aiText != null && !string.IsNullOrEmpty(aiText.Text) &&
                        !offlineContent.ContainsKey(item.Title))
                    {
                        offlineContent[item.Title] = aiText.Text;
                    }
                }
            }

            service = new AIAssistChatService<Response>
            {
                Requirement = string.Format("I am an AI assistant that helps people find information, " +
                "Give required information in markdown format and send the response in json schema.{0}",
                GenerateJsonSchema(typeof(Response))),
                OfflineContent = offlineContent
            };

            await service.Initialize();
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

        public async Task SendUserMessageAsync(string text)
        {
            if (service == null || string.IsNullOrWhiteSpace(text))
                return;

            ShowTypingIndicator = true;
            try
            {
                await service.NonStreamingChat(text);
                if (!isStopResponding)
                {
                    Chats.Add(new AIMessage
                    {
                        Author = new Author { Name = "Bot", ContentTemplate = AIIcon },
                        DateTime = DateTime.Now,
                        Text = service.Response
                    });
                }
            }
            finally
            {
                ShowTypingIndicator = false;
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
            if (e.Item.ItemType != ToolBarItemType.Regenerate)
            {
                ShowTypingIndicator = true;
                await service.ResponseToolbarItemClicked(e, chats);
                ShowTypingIndicator = false;
                return;
            }

            AIMessage aiMessage = e.ChatItem?.DataContext as AIMessage;
            if (aiMessage == null)
            {
                aiMessage = Chats.OfType<AIMessage>().LastOrDefault();
            }
            if (aiMessage == null)
                return;

            int aiIndex = Chats.IndexOf(aiMessage);
            if (aiIndex <= 0)
                return;

            string question = null;
            for (int i = aiIndex - 1; i >= 0; i--)
            {
                if (Chats[i] is TextMessage tm)
                {
                    question = tm.Text;
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(question))
                return;

            ShowTypingIndicator = true;
            try
            {
                await service.NonStreamingChat(question);
                if (!isStopResponding)
                {
                    Chats[aiIndex] = new AIMessage
                    {
                        Author = aiMessage.Author,
                        DateTime = aiMessage.DateTime,
                        Text = string.IsNullOrEmpty(service.Response)
                            ? "For real-time prompt processing, connect the AIAssistView component to your preferred AI service, " +
                              "such as OpenAI or Azure Cognitive Services. " +
                              "Ensure you obtain the necessary API credentials to authenticate and enable seamless integration."
                            : service.Response
                    };
                }
            }
            finally
            {
                ShowTypingIndicator = false;
                isStopResponding = false;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
