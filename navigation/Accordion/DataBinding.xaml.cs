#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBinding : DemoControl
    {
        /// <summary>
        /// Initializes the new instance of <see cref="DataBinding"/> class.
        /// </summary>
        public DataBinding()
        {
            InitializeComponent();
        }

        public DataBinding(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.accordion != null)
            {
                this.accordion = null;
            }
            if (this.selectedItemTextBlock != null)
                this.selectedItemTextBlock = null;
            if (this.selectedItemComboBox != null)
                this.selectedItemComboBox = null;
            base.Dispose(disposing);
        }
    }
}
