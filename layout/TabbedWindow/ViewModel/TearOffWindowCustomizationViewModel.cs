using System.Collections.ObjectModel;

namespace syncfusion.layoutdemos.wpf.ViewModel
{
    public class TearOffWindowCustomizationViewModel: NotificationObject
    {
        public ObservableCollection<TabItemModel> sfabItems { get; } = new ObservableCollection<TabItemModel>();
        
        /// <summary>
        /// Reference to the WindowTypeSelectionViewModel
        /// This allows code-behind to access the selected window type
        /// </summary>
        public WindowTypeSelectionViewModel WindowTypeSelector { get; }

        public TearOffWindowCustomizationViewModel()
        {
            // Create single instance of WindowTypeSelectionViewModel
            WindowTypeSelector = new WindowTypeSelectionViewModel();
            WindowTypeSelector.SelectedWindowType = "SfChromelessWindow"; // Default selection

            sfabItems.Add(new TabItemModel(
               header: "Dynamic Windows",
               content: "Select a window type from the dropdown, then drag this tab to create a window based on your choice.",
               description: "Demonstrates dynamic window creation using pre-selected configurations."
           ));

            sfabItems.Add(new TabItemModel(
                header: "Window Behavior",
                content: "Choose a behavior type above and drag this tab to see it applied in the new window.",
                description: "Shows how different window behaviors can be selected and applied during tear-off."


           ));


            sfabItems.Add(new TabItemModel(
                header: "UI variations",
                content: "Pick a UI style from the selector and drag this tab to create a styled window.",
                description: "Illustrates flexible UI styling through pre-selection."

            ));
        }

    }
}
