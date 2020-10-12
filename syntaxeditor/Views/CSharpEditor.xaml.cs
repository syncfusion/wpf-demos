#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for CSharpEditor.xaml
    /// </summary>
    public partial class CSharpEditor
    {
        /// <summary>
        /// CSharpEditor Constructor 
        /// </summary>
        public CSharpEditor()
        {
            InitializeComponent();
        }

        public CSharpEditor(string themename) : base(themename)
        {
            InitializeComponent();
        }
    }
}