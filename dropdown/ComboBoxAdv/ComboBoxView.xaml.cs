#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Interaction logic for ComboBoxAdvDemosView.xaml
    /// </summary>
    public partial class ComboBoxView
    {
        public ComboBoxView()
        {
            InitializeComponent();
        }

        public ComboBoxView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.singleSelectionComboBox != null)
            {
                this.singleSelectionComboBox.Dispose();                            
                this.singleSelectionComboBox = null;
            }

            if(this.multiSelectionComboBox != null)
            {
                this.multiSelectionComboBox.Dispose();
                this.multiSelectionComboBox = null;
            }

            if (this.delimiterComboBox != null)
            {
                this.delimiterComboBox.Dispose();
                this.delimiterComboBox = null;
            }

            if(this.waterMarkComboBox != null)
            {
                this.waterMarkComboBox.Dispose();
                this.waterMarkComboBox = null;
            }
            base.Dispose(disposing);
        }
    }
}
