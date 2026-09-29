using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.ClientModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace syncfusion.dropdowndemos.wpf
{
    public partial class SmartComboBox : DemoControl
    {
        public SmartComboBox()
        {
            InitializeComponent();
        }

        public SmartComboBox(string themename) : base(themename)
        {
            InitializeComponent();
            if (!AISettings.IsCredentialValid)
            {
                AISettings.ShowAISettingsWindow();
            }
            else 
            {
                AzureOpenAIClient azureClient = new AzureOpenAIClient(new Uri(AISettings.EndPoint), new ApiKeyCredential(AISettings.Key));
                IChatClient azureChatClient = azureClient.GetChatClient(AISettings.ModelName).AsIChatClient();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    public class ComboBoxFilterInfo : TargetedTriggerAction<ComboBoxAdv>
        {
            public ObservableCollection<FoodModel> Items { get; set; }

            public ObservableCollection<FoodModel> FilteredItems { get; set; } = new ObservableCollection<FoodModel>();
            // Summary:
            //     Gets the text entered in ComboBox. Using this text, suggestion list gets prepared
            //     which gets displayed in the drop down list.
            //
            // Value:
            //     The text entered in ComboBox.
            public string Text { get; internal set; }

            protected override async void Invoke(object parameter)
            {
                KeyEventArgs keyEventArgs = parameter as KeyEventArgs;
                var comboBox = keyEventArgs.Source as ComboBoxAdv;
                Text = comboBox.Text;
                await GetMatchingIndexes(keyEventArgs.Source as ComboBoxAdv, this);
                CollectionView items = (CollectionView)CollectionViewSource.GetDefaultView(Target.ItemsSource);
                if (string.IsNullOrWhiteSpace(Text))
                {
                    items.Filter = null;  
                    items.Refresh();
                    comboBox.IsDropDownOpen = true;
                    return;
                }
                items.Filter = ((currentFoodItem) =>
                {
                    if (FilteredItems.Count == 0)
                        return false;
                    foreach (var filteredFoodItem in FilteredItems)
                    {
                        if ((currentFoodItem as FoodModel).Name == (filteredFoodItem.Name))
                            return true;
                    }
                    return false;
                });
                items.Refresh();
                comboBox.IsDropDownOpen = true;
            }

            public async Task<object> GetMatchingIndexes(ComboBoxAdv source, ComboBoxFilterInfo filterInfo)
            {
                Items = (ObservableCollection<FoodModel>)source.ItemsSource;
            ////If credential is not valid, the filtering data shows as empty
            if (!AISettings.IsCredentialValid)
            {
                FilteredItems.Clear();
                var matches = Items
                    .Where(item => item.Name
                    .IndexOf(filterInfo.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
                foreach (var match in matches)
                    FilteredItems.Add(match);

                return await Task.FromResult(FilteredItems);
            }
            string listItems = string.Join("\n", Items.Select(foodItem => foodItem.Name));
                // Join the first five items with newline characters for demo output template for AI
                string outputTemplate = string.Join("\n", Items.Take(5).Select(foodItem => foodItem.Name));
                // Passing the User Input, ItemsSource, Reference output, and CancellationToken
                var filteredItems = await FilterItemsUsingAzureAI(filterInfo.Text, listItems, outputTemplate);
                //source.ItemsSource = filteredItems;
                return await Task.FromResult(filteredItems);
            }

            public async Task<ObservableCollection<FoodModel>> FilterItemsUsingAzureAI(string userInput, string itemsList, string outputTemplate)
            {
                if (!string.IsNullOrEmpty(userInput))
                {
                    var prompt =
                    $"Filter and return matching items from the provided List Items based on the User Input. " +
                    $"Rules: " +
                    $"1. STRICT RULE: Each returned item MUST contain ALL characters from the User Input. " +
                    $"   If any character is missing, EXCLUDE the item completely. This rule is mandatory and cannot be overridden. " +
                    $"2. Matching must be case-insensitive. " +
                    $"3. Apply fuzzy matching (Soundex or Damerau-Levenshtein) ONLY after the strict rule is satisfied. " +
                    $"   Fuzzy matching must NOT include items that fail the character requirement. " +
                    $"4. DO NOT return items that are only phonetically similar but missing characters. " +
                    $"5. Only return items that exist in the provided List Items. Do NOT generate new items. " +
                    $"6. Preserve each item exactly as it is without modification. " +
                    $"7. Ordering: " +
                    $"   - First: items starting with the same first character as the User Input " +
                    $"   - Then: remaining valid matches " +
                    $"8. Return ONLY the matched items, one per line. " +
                    $"   No explanations, no numbering, no symbols, no prefixes, no extra text. " +
                    $"User Input: {userInput} " +
                    $"List Items: {itemsList}";

                    var completion = await AISettings.ClientAI.GetResponseAsync(prompt);

                    var filteredItems = completion.ToString().Split('\n').Select(itemName => itemName.Trim()).Where(itemName => !string.IsNullOrEmpty(itemName)).ToList();

                    if (FilteredItems.Count > 0)
                        FilteredItems.Clear();
                    var matches = Items.Where(foodItem => filteredItems.Contains(foodItem.Name)).ToList();
                    foreach (var matchedItem in matches)
                        FilteredItems.Add(matchedItem);
                }
                return FilteredItems;
            }
        }
    }