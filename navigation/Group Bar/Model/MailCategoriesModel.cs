using syncfusion.demoscommon.wpf;
using System.Collections.ObjectModel;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the mail category.
    /// </summary>
    public class MailCategoriesModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the collection of mails.
        /// </summary>
        private ObservableCollection<MailModel> mailCollection;

        /// <summary>
        ///  Maintains the header.
        /// </summary>
        private string header;

        /// <summary>
        /// Gets or sets the mail details <see cref="MailCategoriesModel"/> class.
        /// </summary>
        public ObservableCollection<MailModel> MailCollection
        {
            get { return mailCollection; }
            set { mailCollection = value; RaisePropertyChanged("MailCollection"); }
        }

        /// <summary>
        /// Gets or sets the header <see cref="MailCategoriesModel"/> class.
        /// </summary>
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                if (header != value)
                {
                    header = value;
                    RaisePropertyChanged("Header");
                }
            }
        }
    }
}
