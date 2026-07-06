using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.Input;

namespace syncfusion.editordemos.wpf
{
    public class MaskedEditViewModel : NotificationObject
    {
        private char promptChar = '_';
        private InputValidationMode validationMode = InputValidationMode.KeyPress;

        public char PromptChar
        {
            get 
            { 
                return promptChar; 
            }
            set
            {
                if (promptChar != value)
                {
                    promptChar = value;
                    this.RaisePropertyChanged(nameof(this.PromptChar));
                }
            }
        }

        public InputValidationMode ValidationMode
        {
            get
            {
                return validationMode;
            }
            set
            {
                if (validationMode != value)
                {
                    validationMode = value;
                    this.RaisePropertyChanged(nameof(this.ValidationMode));
                }
            }
        }
    }
}
