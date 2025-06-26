#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;

namespace syncfusion.expenseanalysis.wpf
{
    public class ItemViewModel : BaseViewModel
    {
        private DataTemplate icon;
        private string title;
        private object content;

        public DataTemplate Icon
        {
            get { return icon; }
            set { icon = value; RaisePropertyChanged(nameof(Icon)); }
        }

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(nameof(Title)); }
        }

        public object Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(nameof(Content)); }
        }
    }
}
