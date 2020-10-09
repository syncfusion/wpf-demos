#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.diagrambackstage.wpf
{
    public sealed partial class RenameFileDialog : Window
    {
        public RenameFileDialog()
        {
            this.InitializeComponent();
            this.KeyUp += RenameFileDialog_KeyUp;
            FocusKey.Focus();
            this.DataContext = this;
            this.Unloaded += RenameFileDialog_Unloaded;
        }

        void RenameFileDialog_Unloaded(object sender, RoutedEventArgs e)
        {
            this.KeyUp -= RenameFileDialog_KeyUp;
            this.Unloaded -= RenameFileDialog_Unloaded;
        }


        void RenameFileDialog_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if (e.Key == Key.Enter)
            {
                this.Focus();
                this.DialogResult =DialogResult.Yes;
            }
        }

        public Visibility FileExist
        {
            get { return (Visibility)GetValue(FileExistProperty); }
            set { SetValue(FileExistProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileExist.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileExistProperty =
            DependencyProperty.Register("FileExist", typeof(Visibility), typeof(RenameFileDialog), new PropertyMetadata(Visibility.Collapsed));



        public new DialogResult DialogResult
        {
            get { return (DialogResult)GetValue(DialogResultProperty); }
            set { SetValue(DialogResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DialogResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.Register("DialogResult", typeof(DialogResult), typeof(RenameFileDialog), new PropertyMetadata(DialogResult.None, OnDialogResultChanged));

        private static void OnDialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RenameFileDialog dialog = d as RenameFileDialog;
            if (dialog.DialogResultChanged != null)
            {
                dialog.DialogResultChanged.Invoke(dialog, null);
            }
        }

        public new Task<DialogResult> ShowDialog()
        {
            TaskCompletionSource<DialogResult> result = new TaskCompletionSource<DialogResult>();
            this.DialogResultChanged += (s, e) =>
            {
                result.SetResult(this.DialogResult);
            };
            return result.Task;
        }

        public event EventHandler DialogResultChanged;

        public string NewFileName
        {
            get { return (string)GetValue(NewFileNameProperty); }
            set { SetValue(NewFileNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewFileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewFileNameProperty =
            DependencyProperty.Register("NewFileName", typeof(string), typeof(RenameFileDialog), new PropertyMetadata(""));

        private void Ok_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
