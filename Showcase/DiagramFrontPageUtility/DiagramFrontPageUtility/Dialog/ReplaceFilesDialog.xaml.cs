#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DiagramFrontPageUtility
{
    public partial class ReplaceFilesDialog : Window
    {
        public ReplaceFilesDialog()
        {
            this.InitializeComponent();
            this.KeyUp += ReplaceFilesDialog_KeyUp;
            //FocusKey.Focus();
            this.DataContext = this;
            this.Unloaded += ReplaceFilesDialog_Unloaded;
        }

        void ReplaceFilesDialog_Unloaded(object sender, RoutedEventArgs e)
        {
            this.KeyUp -= ReplaceFilesDialog_KeyUp;
            this.Unloaded -= ReplaceFilesDialog_Unloaded;
        }

        void ReplaceFilesDialog_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //if (e.Key == VirtualKey.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        public bool Repeat
        {
            get { return (bool)GetValue(RepeatProperty); }
            set { SetValue(RepeatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Repeat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RepeatProperty =
            DependencyProperty.Register("Repeat", typeof(bool), typeof(ReplaceFilesDialog), new PropertyMetadata(false));

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(ReplaceFilesDialog), new PropertyMetadata(""));


        public DialogResult DialogResult
        {
            get { return (DialogResult)GetValue(DialogResultProperty); }
            set { SetValue(DialogResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DialogResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.Register("DialogResult", typeof(DialogResult), typeof(ReplaceFilesDialog), new PropertyMetadata(DialogResult.None, OnDialogResultChanged));

        private static void OnDialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
             ReplaceFilesDialog dialog = d as ReplaceFilesDialog;
             if (dialog.DialogResultChanged != null)
             {
                 dialog.DialogResultChanged.Invoke(dialog, null);
             }
        }
        
        public event EventHandler DialogResultChanged;

        private void Yes_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void No_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Task<DialogResult> ShowDialog()
        {
            TaskCompletionSource<DialogResult> result = new TaskCompletionSource<DialogResult>();
            this.DialogResultChanged += (s, e) =>
                {
                    result.SetResult(this.DialogResult);
                };
            return result.Task;
        }
    }

    public enum DialogResult
    {
        None,
        Yes,
        No,
        Cancel
    }
}
