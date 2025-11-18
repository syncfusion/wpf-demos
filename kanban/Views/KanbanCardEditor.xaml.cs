#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.kanbandemos.wpf
{
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Specifies the possible actions that can be performed in a card editor.
    /// </summary>
    public enum DialogAction
    {
        Save,
        Delete,
        Cancel
    }

    /// <summary>
    /// Interaction logic for KanbanCardEditor.xaml
    /// </summary>
    public partial class KanbanCardEditor : ChromelessWindow
    {
        #region Properties

        /// <summary>
        /// Tracks the user's selected action in the dialog (Save, Delete, or Cancel).
        /// </summary>
        public DialogAction? Action { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="KanbanCardEditor"/> class.
        /// </summary>
        public KanbanCardEditor()
        {
            this.InitializeComponent();
            this.SaveButton.Click += (s, e) =>
            {
                DialogResult = true;
                this.Action = DialogAction.Save;
            };

            this.DeleteButton.Click += (s, e) =>
            {
                this.Action = DialogAction.Delete;
                DialogResult = false;
                this.Close();
            };

            this.CancelButton.Click += (s, e) =>
            {
                this.Action = DialogAction.Cancel;
                this.Close();
            };
        }

        #endregion
    }
}