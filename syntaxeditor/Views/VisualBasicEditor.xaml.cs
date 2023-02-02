#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for VisualBasicEditor.xaml
    /// </summary>
    public partial class VisualBasicEditor: DemoControl
    {
        public VisualBasicEditor()
        {
            InitializeComponent();
        }

        public VisualBasicEditor(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            if (this.editControl != null)
            {
                this.editControl = null;
            }

            if (this.Mainmenu != null)
                this.Mainmenu = null;

            if (this.Toolbar != null)
                this.Toolbar = null;

            base.Dispose(disposing);
        }
    }
}
