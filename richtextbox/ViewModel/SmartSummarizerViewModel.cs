#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.richtextboxdemos.wpf.Helper;
using Syncfusion.UI.Xaml.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.richtextboxdemos.wpf
{
    public class SmartSummarizerViewModel : INotifyPropertyChanged
    {
        #region Fields
        internal SemanticKernelAI semanticKernelOpenAI;
        private readonly DocumentManager documentManager;
        private readonly Author aiAssist;

        private bool isInitializeAssistant;
        private bool isUserQuestionRaised = true;

        private ObservableCollection<object> chats;
        private ObservableCollection<string> suggestions;
        private Author currentUser;
        private bool showTypingIndicator;
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets the collection of chat objects.
        /// </summary>
        public ObservableCollection<object> Chats
        {
            get
            {
                return chats;
            }
            set
            {
                chats = value;
                RaisePropertyChanged(nameof(chats));
            }
        }
        /// <summary>
        /// Gets or sets the collection of suggestions.
        /// </summary>
        public ObservableCollection<string> Suggestions
        {
            get
            {
                return suggestions;
            }
            set
            {
                suggestions = value;
                RaisePropertyChanged(nameof(suggestions));
            }
        }
        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                RaisePropertyChanged(nameof(CurrentUser));
            }
        }
        /// <summary>
        /// Gets or sets the show typing indicator.
        /// </summary>
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

        public event PropertyChangedEventHandler PropertyChanged;
        public DataTemplate AIIcon { get; set; }
        #endregion

        #region Constructor
        public SmartSummarizerViewModel()
        {

        }


        public SmartSummarizerViewModel(DocumentManager documentManager, DataTemplate aiIcon)
        {
            this.documentManager = documentManager;
            Chats = new ObservableCollection<object>();
            Chats.CollectionChanged += Chats_CollectionChanged;
            Suggestions = new ObservableCollection<string>();
            CurrentUser = new Author { Name = "" };
            AIIcon = aiIcon;
            aiAssist = new Author { Name = "AI Assistant", ContentTemplate = AIIcon };
        }
        #endregion

        #region Implementation
        /// <summary>
        /// Initializes the AI assistant by summarizing the provided document and generating 
        /// suggestions based on the content. It updates the chat and suggestions accordingly.
        /// </summary>
        /// <param name="inputText">The input text to be summarized and analyzed.</param>
        public async Task InitializeAiAssist()
        {
            isInitializeAssistant = true;
            ClearChatAndSuggestion();
            AddMessageToChat(CurrentUser, "Summarize the document");
            ShowTypingIndicator = true;
            var summary = await GenerateSummary();
            AddMessageToChat(aiAssist, summary);
            var questions = await GenerateSuggestions();
            Suggestions = new ObservableCollection<string>(questions);
            ShowTypingIndicator = false;
            isInitializeAssistant = false;
        }

        /// <summary>
        /// Handles the selection of a suggestion by the user. It sends the selected question 
        /// to the AI assistant and retrieves a response based on the input text.
        /// </summary>
        /// <param name="question">The question selected by the user.</param>
        /// <param name="inputText">The original input text to be used in generating the response.</param>
        public async Task HandleSuggestionSelected(string question)
        {
            if (string.IsNullOrWhiteSpace(question)) return;
            isUserQuestionRaised = false;
            AddMessageToChat(CurrentUser, question);
            ShowTypingIndicator = true;
            var response = await GenerateResponse(question);
            AddMessageToChat(aiAssist, response);
            ShowTypingIndicator = false;
            isUserQuestionRaised = true;
        }

        /// <summary>
        /// Generates a short summary of the provided input text using an AI model.
        /// </summary>
        /// <param name="inputText">The text to be summarized.</param>
        /// <returns>A generated summary.</returns>
        private async Task<string> GenerateSummary()
        {
            string prompt = $"You are a helpful assistant. Your task is to analyze the \"{documentManager.DocumentText}\" and generate a short summary.";
            return await semanticKernelOpenAI.GetAnswerFromGPT(prompt);
        }

        /// <summary>
        /// Generates a list of 3 short diverse questions based on the provided input text.
        /// </summary>
        /// <param name="inputText">The text to analyze for generating questions.</param>
        /// <returns>A collection of generated questions.</returns>
        private async Task<IEnumerable<string>> GenerateSuggestions()
        {
            string prompt = $"You are a helpful assistant. Your task is to analyze the \"{documentManager.DocumentText}\" and generate 3 short diverse questions, each not exceeding 10 words.";
            string response = await semanticKernelOpenAI.GetAnswerFromGPT(prompt);
            return response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Generates a response to a user question based on the provided input text.
        /// </summary>
        /// <param name="inputText">The context or document to refer to when answering the question.</param>
        /// <param name="question">The user question that needs to be answered.</param>
        /// <returns>The generated response.</returns>
        private async Task<string> GenerateResponse(string question)
        {
            string prompt = $"You are a helpful assistant. Use the provided context \"{documentManager.DocumentText}\" to answer the user question {question}.";
            return await semanticKernelOpenAI.GetAnswerFromGPT(prompt);
        }

        private async void Chats_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && !isInitializeAssistant)
            {
                ShowTypingIndicator = true;
                if (e.NewItems[0] is ITextMessage item && item.Author.Name == CurrentUser.Name && isUserQuestionRaised)
                {
                    string question = item.Text;

                    if (!string.IsNullOrWhiteSpace(question))
                    {
                        string prompt = $"You are a helpful assistant. Use the provided context {documentManager.DocumentText} to answer the user question {question}.";

                        var response = await semanticKernelOpenAI.GetAnswerFromGPT(prompt);
                        AddMessageToChat(aiAssist, response);
                        ShowTypingIndicator = false;
                    }
                }
            }
        }

        /// <summary>
        /// Handles changes in the Chats collection, specifically when a new item is added.
        /// </summary>
        /// <param name="sender">The source of the event (Chats collection).</param>
        /// <param name="e">Event arguments containing details about the change in the collection.</param>
        private void AddMessageToChat(Author author, string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                Chats.Add(new TextMessage
                {
                    Author = author,
                    Text = text,
                    DateTime = DateTime.Now,
                });
            }
        }

        /// <summary>
        /// Handles the menu item clicked event asynchronously.
        /// </summary>
        /// <param name="e">Contains the event data for the menu item clicked event.</param>
        internal async void chat_MenuItemClicked(MenuItemClickedEventArgs e)
        {
            ShowTypingIndicator = true;
            await MenuItemClicked(e, chats);
            ShowTypingIndicator = false;
        }

        /// <summary>
        /// Processes a menu item click event within a chat context, performing actions such as regenerating a response.
        /// </summary>
        /// <param name="e">The event data containing information about the selected menu item and chat item context.</param>
        /// <param name="chats">A collection of chat items that can be manipulated based on the menu action performed.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task MenuItemClicked(MenuItemClickedEventArgs e, ObservableCollection<object> chats)
        {
            var aiMessage = e.ChatItem.DataContext as TextMessage;
            if (aiMessage == null)
                return;

            switch (e.MenuType)
            {
                case MenuItemType.Regenerate:
                    int regenerateIndex = chats.IndexOf(aiMessage);

                    if (regenerateIndex <= 0)
                        return;

                    string question = (chats[regenerateIndex - 1] as TextMessage)?.Text;
                    string refreshedMessage = regenerateIndex - 1 == 0
                        ? await GenerateSummary()
                        : await GenerateResponse(question);

                    chats[regenerateIndex] = new TextMessage
                    {
                        Author = aiMessage.Author,
                        DateTime = aiMessage.DateTime,
                        Text = refreshedMessage
                    };
                    break;

                case MenuItemType.Copy:
                    Clipboard.SetText(aiMessage.Text);
                    break;
            }
        }

        /// <summary>
        /// Clears both the chat and suggestions collections to reset the assistant state.
        /// </summary>
        public void ClearChatAndSuggestion()
        {
            Chats.Clear();
            Suggestions.Clear();
        }

        /// <summary>
        /// Raises the PropertyChanged event to notify listeners that a property has changed.
        /// </summary>
        /// <param name="propName">The name of the property that has changed.</param>
        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            if (Chats != null)
            {
                Chats.CollectionChanged -= Chats_CollectionChanged;
                Chats = null;
            }
            if (semanticKernelOpenAI != null)
            {
                semanticKernelOpenAI = null;
            }
            if (Chats != null)
            {
                Chats.Clear();
            }
            if (Suggestions != null)
            {
                Suggestions.Clear();
            }
            if(documentManager != null)
            {
                documentManager.Dispose();
            }
            Chats = null;
            Suggestions = null;
        }
        #endregion
    }
}
