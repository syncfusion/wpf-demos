#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
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

namespace SpellChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextSpellEditor SpellEditor;

        public MainWindow()
        {
            SpellChecker = new SfSpellChecker();
            InitializeComponent();
            SpellEditor = new TextSpellEditor(txtbx);
            Editor = SpellEditor;
            SpellChecker.PerformSpellCheckUsingContextMenu(Editor);
        }

        public IEditorProperties Editor
        {
            get;
            set;
        }

        public SfSpellChecker SpellChecker
        {
            get;
            set;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SpellChecker.PerformSpellCheckUsingDialog(Editor);
        }

        private void ignoreChecked(object sender, RoutedEventArgs e)
        {
            string _str = (sender as CheckBox).Tag.ToString();
            bool _ischecked = (bool)(sender as CheckBox).IsChecked;
            switch (_str)
            {
                case "1":
                    SpellChecker.IgnoreUrl = _ischecked;
                    break;
                case "2":
                    SpellChecker.IgnoreUpperCaseWords = _ischecked;
                    break;
                case "3":
                    SpellChecker.IgnoreAlphaNumericWords = _ischecked;
                    break;
                case "4":
                    SpellChecker.IgnoreEmailAddress = _ischecked;
                    break;
                case "5":
                    SpellChecker.IgnoreMixedCaseWords = _ischecked;
                    break;
            }
        }

        private void ignoreWebAndFileAddressers_Loaded(object sender, RoutedEventArgs e)
        {
            Border border1 = (sender as CheckBox).Template.FindName("border1", sender as FrameworkElement) as Border;
            if (border1 != null)
                border1.Margin = new Thickness(0, 1, 0, 0);
        }
    }
}
