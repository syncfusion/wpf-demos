#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for IntellisenseEditor.xaml
    /// </summary>
    public partial class IntellisenseEditor:DemoControl
    {
        /// <summary>
        /// IntellisenseEditor Constructor 
        /// </summary>
        public IntellisenseEditor()
        {
            InitializeComponent();
        }

        public IntellisenseEditor(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}




