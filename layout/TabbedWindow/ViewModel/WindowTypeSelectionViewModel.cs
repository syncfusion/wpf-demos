using System.Collections.ObjectModel;

namespace syncfusion.layoutdemos.wpf.ViewModel
{
    /// <summary>
    /// ViewModel for window type selection.
    /// Manages the available window types and current selection.
    /// </summary>
    public class WindowTypeSelectionViewModel : NotificationObject
    {
        private string _selectedWindowType;

        public ObservableCollection<string> WindowTypes { get; } = 
            new ObservableCollection<string> { "SfChromelessWindow","Custom Window", "MS-Window" };

        public string SelectedWindowType
        {
            get => _selectedWindowType;
            set
            {
                _selectedWindowType = value;
                RaisePropertyChanged(nameof(SelectedWindowType));
            }
        }
    }
}
