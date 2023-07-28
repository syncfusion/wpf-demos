#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
        public DialogWindow()
        {
            SfSkinManager.SetTheme(this, new Theme("Windows11Light"));
            InitializeComponent();
        }

        public string AcceptText
        {
            get { return (string)GetValue(AcceptTextProperty); }
            set { SetValue(AcceptTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AcceptText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AcceptTextProperty =
            DependencyProperty.Register("AcceptText", typeof(string), typeof(DialogWindow), new PropertyMetadata("OK"));



        public MessageBoxResult Result
        {
            get { return (MessageBoxResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Result.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(MessageBoxResult), typeof(DialogWindow), new PropertyMetadata(MessageBoxResult.None));

        private void OK_Clicked(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            this.Close();
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            this.Close();
        }

        private void Title_OnLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

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
