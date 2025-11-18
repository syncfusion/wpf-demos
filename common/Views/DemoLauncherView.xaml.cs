#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for DemoLauncherView.xaml
    /// </summary>
    public partial class DemoLauncherView : UserControl
    {
        /// <summary>
        /// stores the type of the window that will be launched when the user interacts with the view.
        /// </summary>
        Type DemoType;

        /// <summary>
        /// Initializes a new instance of the <see cref="DemosListView"/> class.
        /// </summary>
        /// <param name="DemoViewType">The <see cref="Type"/> of the demo window to be launched.</param>
        public DemoLauncherView(Type DemoViewType)
        {
            InitializeComponent();
            DemoType = DemoViewType;
        }

        /// <summary>
        /// Gets or sets the HyperLinkStyle for the collection of helplinks in the documentation
        /// </summary>
        public Style HyperLinkStyle
        {
            get { return (Style)GetValue(HyperLinkStyleProperty); }
            set { SetValue(HyperLinkStyleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for <see cref="HyperLinkStyle"/>. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HyperLinkStyleProperty =
            DependencyProperty.Register("HyperLinkStyle", typeof(Style), typeof(DemoLauncherView), new PropertyMetadata(null));

    }
}
