using System.Windows;

namespace syncfusion.expenseanalysis.wpf
{
    public class ItemViewModel : BaseViewModel
    {
        private DataTemplate icon;
        private string title;
        private object content;

        public DataTemplate Icon
        {
            get { return icon; }
            set { icon = value; RaisePropertyChanged(nameof(Icon)); }
        }

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(nameof(Title)); }
        }

        public object Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(nameof(Content)); }
        }
    }
}
