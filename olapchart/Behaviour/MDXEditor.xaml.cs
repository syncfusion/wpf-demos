#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MDXEditor.xaml
    /// </summary>
    public partial class MDXEditor : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MDXEditor"/> class.
        /// </summary>
        public MDXEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MDXEditor"/> class with the specified view model.
        /// </summary>
        public MDXEditor(MDXQueryViewModel viewModel)
            : base()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
