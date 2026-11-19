using syncfusion.demoscommon.wpf;
using System.Windows.Media;

namespace syncfusion.editordemos.wpf
{
    public class ColorPickerViewModel : NotificationObject
    {
        private Brush selectedBrush = Brushes.SkyBlue;

        public Brush SelectedBrush
        {
            get 
            { 
                return selectedBrush; 
            }
            set
            {
                if (selectedBrush != value)
                {
                    selectedBrush = value;
                    this.RaisePropertyChanged(nameof(this.SelectedBrush));
                }
            }
        }
    }
}
