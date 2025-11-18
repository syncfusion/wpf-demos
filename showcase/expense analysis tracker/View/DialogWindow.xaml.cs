#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
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
using System.Windows.Shapes;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogWindow"/> class.
        /// </summary>
        public DialogWindow()
        {
            SfSkinManager.SetTheme(this, new Theme("Windows11Light"));
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the text displayed on the primary confirmation button.
        /// </summary>
        public string AcceptText
        {
            get { return (string)GetValue(AcceptTextProperty); }
            set { SetValue(AcceptTextProperty, value); }
        }

        /// <summary>
        /// Identies the <see cref="AcceptText"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AcceptTextProperty =
            DependencyProperty.Register("AcceptText", typeof(string), typeof(DialogWindow), new PropertyMetadata("OK"));


        /// <summary>
        /// Gets or sets the result of the dialog, indicating how it is closed.
        /// </summary>
        public MessageBoxResult Result
        {
            get { return (MessageBoxResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        /// <summary>
        /// Identies the <see cref="Result"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(MessageBoxResult), typeof(DialogWindow), new PropertyMetadata(MessageBoxResult.None));

        /// <summary>
        /// Handles the click event for the confirmation button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguement.</param>
        private void OK_Clicked(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles the click event for the cancellation button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguement.</param>
        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Handles the Mouseleftbuttondown event on the title bar to enable window dragging.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguement.</param>
        private void Title_OnLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// Overrides the default key down behavior to handle the Escape key.
        /// </summary>
        /// <param name="e">The event arguement.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if(e.Key == Key.Escape)
            {
                Result = MessageBoxResult.Cancel;
                this.Close();
            }
        }
    }

    
}
