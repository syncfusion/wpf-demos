// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramTabViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the diagram tab view model class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    ///     Represents the diagram tab view model class.
    /// </summary>
    public class DiagramTabViewModel: INotifyPropertyChanged
    {
        private Visibility visibility = Visibility.Visible;
        /// <summary>
        ///     Gets or sets the diagram groups collection.
        /// </summary>
        public ObservableCollection<DiagramBarViewModel> DiagramGroups { get; set; }

        /// <summary>
        ///     Gets or sets the header.
        /// </summary>
        public string Header { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
        

        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                if (visibility != value)
                {
                    visibility = value;
                    this.OnPropertyChanged("Visibility");
                }
            }
        }
    }
}