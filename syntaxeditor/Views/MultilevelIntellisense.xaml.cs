#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for MultilevelIntellisense.xaml
    /// </summary>
    public partial class MultilevelIntellisense :DemoControl
    {
        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public MultilevelIntellisense()
        {

            InitializeComponent();       
        }

        public MultilevelIntellisense(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}



