
using syncfusion.demoscommon.wpf;

namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Represents the model class for combo box 
    /// </summary>
    public class Country : NotificationObject
    {
        /// <summary>
        /// Represents the name of the country
        /// </summary>
        private string name;

        /// <summary>
        /// Represents the code of the country
        /// </summary>
        private string code;

        /// <summary>
        /// Gets or sets the value for name of the country <see cref="Country"/> class.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the value for country code <see cref="Country"/> class.
        /// </summary>
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
                RaisePropertyChanged("Code");
            }
        }
    }
}
