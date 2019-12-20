#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System.Reflection;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace SyntaxHighlighting
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        EditControl edit;
        ObservableCollection<Uri> uriList = null;

        #region Constructor
        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public Window1()
        {
            InitializeComponent();           
#if NETCORE
            SetLanguageFormat(Languages.C, @"..//..//..//Resources//CSource.c");
#else
            SetLanguageFormat(Languages.C, @"..//..//Resources//CSource.c");
#endif           
        }

        #endregion      

        #region Click Events
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
                    
        private void Code_Samples_Click_1(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.C, @"..//..//Resources//CSource.c");
        }

        private void Code_Samples_Click_2(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.CSharp, @"..//..//Resources//CSharpSource.cs");
        }

        private void Code_Samples_Click_3(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.Delphi, @"..//..//Resources//DelphiSource.pas");
        }

        private void Code_Samples_Click_4(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.HTML, @"..//..//Resources//HTMLSource.html");
        }

        private void Code_Samples_Click_5(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.Java, @"..//..//Resources//JavaSource.java");
        }

        private void Code_Samples_Click_6(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.JScript, @"..//..//Resources//JScriptSource.js");
        }

        private void Code_Samples_Click_7(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.PowerShell, @"..//..//Resources//PowershellSource.ps1");
        }

        private void Code_Samples_Click_8(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.SQL, @"..//..//Resources//SQLSource.sql");
        }

        private void Code_Samples_Click_9(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.VBScript, @"..//..//Resources//VBScriptSource.vbs");
        }

        private void Code_Samples_Click_10(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.VisualBasic, @"..//..//Resources//VBSource.vb");
        }

        private void Code_Samples_Click_11(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.XAML, @"..//..//Resources//XAMLSource.xaml");
        }

        private void Code_Samples_Click_12(object sender, RoutedEventArgs e)
        {
            UncheckAllMenuItems();
            ((MenuItem)sender).IsChecked = true;
            SetLanguageFormat(Languages.XML, @"..//..//Resources//XMLSource.xml");
        }

        #endregion

        #region Helper Methods
        private void SetLanguageFormat(Languages language, string filePath)
        {
            edit = new EditControl();
            uriList = new ObservableCollection<Uri>();
            edit.DocumentLanguage = language;
            edit.DocumentSource = filePath;

            fontlst.SelectedItem = new FontFamily("Verdana");
            fontsize.SelectedItem=(Double)13;

            Binding fontFamily = new Binding("SelectedItem");
            fontFamily.Source = fontlst;
            edit.SetBinding(EditControl.FontFamilyProperty, fontFamily);

            Binding fontSize = new Binding("SelectedItem");
            fontSize.Source = fontsize;
            edit.SetBinding(EditControl.FontSizeProperty, fontSize);

            Grid.SetRow(edit, 2);
            grid1.Children.Add(edit);
        }

        private void UncheckAllMenuItems()
        {
            item1.IsChecked = false;
            item2.IsChecked = false;
            item3.IsChecked = false;
            item4.IsChecked = false;
            item5.IsChecked = false;
            item6.IsChecked = false;
            item7.IsChecked = false;
            item8.IsChecked = false;
            item9.IsChecked = false;
            item10.IsChecked = false;
            item11.IsChecked = false;
            item12.IsChecked = false;
        }

        #endregion

    }

    public class UriToTextConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is Uri)
            {
                Uri tempUri = value as Uri;
                if (tempUri.Segments.Length > 0)
                {
                    return tempUri.Segments[tempUri.Segments.Length - 1];
                }
                return tempUri.LocalPath;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
