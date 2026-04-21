#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for XMLAndXAMLEditor.xaml
    /// </summary>
    public partial class XMLAndXAMLEditor: DemoControl
    {
        /// <summary>
        /// XMLAndXAMLEditor Constructor
        /// </summary>
        public XMLAndXAMLEditor()
        {
            InitializeComponent();
        }

        public XMLAndXAMLEditor(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            if (this.editXML != null)
            {
                this.editXML = null;
            }

            if (this.editXAML != null)
            {
                this.editXAML = null;
            }

            if (this.Mainmenu != null)
                this.Mainmenu = null;

            if (this.Toolbar != null)
                this.Toolbar = null;

            if (this.tabControl1 != null)
                this.tabControl1 = null;

            if (this.DataContext != null)
                this.DataContext = null;

            base.Dispose(disposing);
        }
    }
}
