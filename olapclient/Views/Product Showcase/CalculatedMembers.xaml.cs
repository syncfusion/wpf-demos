#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for CalculatedMembers.xaml
    /// </summary>
    public partial class CalculatedMembers : DemoControl
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatedMembers"/> class.
        /// </summary>
        public CalculatedMembers()
        {
            InitializeComponent();
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as CalculatedMembersViewModel).Dispose();

            if (this.olapClient1 != null)
                this.olapClient1 = null;
        
            base.Dispose(disposing);
        }
    }
}
