
using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    ///  Represents the note model.
    /// </summary>
    public class NoteModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the message.
        /// </summary>
        private string message;

        /// <summary>
        /// Gets or sets the message <see cref="NoteModel"/>.
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message != value)
                {
                    message = value;
                    RaisePropertyChanged("Message");
                }
            }
        }
    }
}
