#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Interaction logic for AutoComplete.xaml
    /// </summary>
    public partial class AutoComplete
    {
        /// <summary>
        /// Initializes the instance of <see cref="AutoComplete"/>class.
        /// </summary>
        public AutoComplete()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the themes.
        /// </summary>
        /// <param name="themename"></param>
        public AutoComplete(string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method used to dipose the controls.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            this.Resources.Clear();


            if(this.multiSelectionComboBox != null)
            {
                this.multiSelectionComboBox.Dispose();
                this.multiSelectionComboBox = null;
            }
            base.Dispose(disposing);
        }
    }
}
