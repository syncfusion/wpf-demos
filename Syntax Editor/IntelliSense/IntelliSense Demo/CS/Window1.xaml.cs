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
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System.Reflection;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace IntellisenseDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCollection<Uri> uriList = null;

        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            uriList = new ObservableCollection<Uri>();
            Assembly assembly = Assembly.GetExecutingAssembly();
#if NETCORE
            editCSharp.DocumentSource = "../../../Source.cs";
#else
            editCSharp.DocumentSource = "../../Source.cs";
#endif
            editCSharp.AssemblyReferences = uriList;
            fontlst.SelectedItem = new FontFamily("Verdana");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRemoveRef_Click(object sender, RoutedEventArgs e)
        {
            if (assemblyReferencesList.SelectedItem != null)
            {
                uriList.Remove(assemblyReferencesList.SelectedItem as Uri);
            }
        }

        private void btnAddRef_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Assembly Files (*.dll) | *.dll";
            fileDialog.ShowDialog();
            if (fileDialog.FileName.Trim() != string.Empty)
            {
                uriList.Add(new Uri(fileDialog.FileName));
            }
        }
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
