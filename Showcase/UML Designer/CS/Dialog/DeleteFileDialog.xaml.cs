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
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UMLDiagramDesigner
{
    public sealed partial class DeleteFileDialog : UserControl, IDialog
    {
        public DeleteFileDialog()
        {
            this.InitializeComponent();
            this.KeyUp += DeleteFileDialog_KeyUp;
            FocusKey.Focus(FocusState.Keyboard);
            this.Unloaded += DeleteFileDialog_Unloaded;
        }

        void DeleteFileDialog_Unloaded(object sender, RoutedEventArgs e)
        {
            this.KeyUp -= DeleteFileDialog_KeyUp;
            this.Unloaded -= DeleteFileDialog_Unloaded;
        }

        void DeleteFileDialog_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }


        public DialogResult DialogResult
        {
            get { return (DialogResult)GetValue(DialogResultProperty); }
            set { SetValue(DialogResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DialogResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.Register("DialogResult", typeof(DialogResult), typeof(DeleteFileDialog), new PropertyMetadata(DialogResult.None, OnDialogResultChanged));

        private static void OnDialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DeleteFileDialog dialog = d as DeleteFileDialog;
            if (dialog.DialogResultChanged != null)
            {
                dialog.DialogResultChanged.Invoke(dialog, null);
            }
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

        private void Yes_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void No_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        public event EventHandler DialogResultChanged;
    }
}
