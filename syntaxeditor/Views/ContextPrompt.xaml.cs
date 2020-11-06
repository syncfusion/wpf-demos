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
    /// Interaction logic for ContextPrompt.xaml
    /// </summary>
    public partial class ContextPrompt :DemoControl
    {
        public ContextPrompt()
        {
            InitializeComponent();
        }

        public ContextPrompt(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.editControl != null)
            {
                this.editControl.Dispose();
                this.editControl = null;
            }

            base.Dispose(disposing);

        }
    }
}