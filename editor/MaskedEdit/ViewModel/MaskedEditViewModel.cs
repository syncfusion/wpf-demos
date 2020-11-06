#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
