#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;

namespace SpellCheckerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        TextBoxSpellEditor TextEditor;

        public MainWindow()
        {
            Checker = new SpellChecker();
            InitializeComponent();
            TextEditor = new TextBoxSpellEditor(txtbx);
            SpellEditor = TextEditor;
            Checker.SpellCheckCompleted += new EventHandler(Checker_SpellCheckCompleted);
        }

        void Checker_SpellCheckCompleted(object sender, EventArgs e)
        {
            Window1 message = new Window1();
            message.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            message.Height = 130;
            message.Show();
        }

        public ISpellEditor SpellEditor
        {
            get;
            set;
        }

        public SpellChecker Checker
        {
            get;
            set;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Checker.SpellCheckForEditor(SpellEditor);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtbx.Visibility = Visibility.Visible;
            //rtb.Visibility = Visibility.Collapsed;
            SpellEditor = TextEditor;
        }

        private void ignoreChecked(object sender, RoutedEventArgs e)
        {
            string str = (sender as CheckBox).Tag.ToString();

            bool isChecked = (bool)(sender as CheckBox).IsChecked;

            switch (str)
            {
                case "1":
                    Checker.ExcludeInternetAddresses = Checker.ExcludeFileNames = isChecked;
                    break;
                case "2":
                    Checker.ExcludeWordsInUpperCase = isChecked;
                    break;
                case "3":
                    Checker.ExcludeWordsWithNumbers = isChecked;
                    break;
                case "4":
                    Checker.ExcludeEmailAddress = isChecked;
                    break;
                case "5":
                    Checker.ExcludeWordsInMixedCase = isChecked;
                    break;
            }
        }

        private void ChromelessWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Checker.ExcludeInternetAddresses = (bool)ignoreWebAndFileAddressers.IsChecked;
            Checker.ExcludeWordsInUpperCase = (bool)ignoreUpperCase.IsChecked;
            Checker.ExcludeWordsWithNumbers = (bool)ignoreNumber.IsChecked;
            Checker.ExcludeEmailAddress = (bool)ignoreEmail.IsChecked;
            Checker.ExcludeWordsInMixedCase = (bool)ignoreMixedCase.IsChecked;
        }

    }
}
