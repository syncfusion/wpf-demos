#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using syncfusion.demoscommon.wpf;

namespace syncfusion.richtextboxdemos.wpf
{
    /// <summary>
    /// Interaction logic for StickyNotesDemo.xaml
    /// </summary>
    public partial class StickyNotesDemo : Window
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="StickyNotesDemo"/> class.
        /// </summary>
        public StickyNotesDemo()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
            //Enables touch manipulation.
            richTextBoxAdv.IsManipulationEnabled = true;
            richTextBoxAdv.RequestNavigate += (DataContext as StickyNotesViewModel).RichTextBoxAdv_RequestNavigate;
            CommandBindings.Add(new CommandBinding(StickyNotesViewModel.SkinCommand, (DataContext as StickyNotesViewModel).OnSkinExecute));
        }
        #endregion

        #region Events
        /// <summary>
        /// Called when [loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (richTextBoxAdv != null)
                richTextBoxAdv.Focus();
        }
        /// <summary>
        /// Called on new note button clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.RoutedEventArgs">RoutedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void NewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            StickyNotesDemo window = new StickyNotesDemo();
            window.ShowInTaskbar = false;
            window.Owner = this.Owner;
            window.Show();
        }
        /// <summary>
        /// Called on delete note button clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.RoutedEventArgs">RoutedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void DeleteNoteButton_Click(object sender, RoutedEventArgs e)
        {
            ////When Closing the first opened StickyNotes Window, first opened and other opened StickyNotes windows are closed.
            ////and When Closing other than first opened StickyNotes window, particular StickyNotes alone is closed.
            bool isFirstStickyNotestWindow = false;
            int stickyNoteWindowsCount = 0;
            if (this.Owner != null && this.Owner is MainWindow)
            {
                stickyNoteWindowsCount = (this.Owner as MainWindow).OwnedWindows.Count;
                if (stickyNoteWindowsCount > 2)
                {
                    Window firstStickyNotesWindow = (this.Owner as syncfusion.demoscommon.wpf.MainWindow).OwnedWindows[1];
                    if (this == firstStickyNotesWindow)
                    {
                        isFirstStickyNotestWindow = true;
                    }
                }
            }
          
                if (isFirstStickyNotestWindow)
                {
                    if (MessageBox.Show("Are you sure you want to delete all note?", "Sticky Notes", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        for (int i = stickyNoteWindowsCount - 1; i >= 1; i--)
                        {
                            (this.Owner as syncfusion.demoscommon.wpf.MainWindow).OwnedWindows[i].Close();
                        }
                    }
                }
                else
                {
                    if(MessageBox.Show("Are you sure you want to delete this note?", "Sticky Notes", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                    this.Close();
                    }
                  
                }    
        }
        /// <summary>
        /// Called on boder mouse left button down.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.Input.MouseButtonEventArgs">MouseButtonEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        /// <summary>
        /// Called on thumb dragged.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.Controls.Primitives.DragDeltaEventArgs">DragDeltaEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            try
            {
                Root.Width += e.HorizontalChange;
                Root.Height += e.VerticalChange;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Implementation

        /// <summary>
        /// Raises the Closing event.
        /// </summary>
        /// <param name="e">CancelEventArgs that contains the event dat</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Dispose();
            base.OnClosing(e);
        }
        /// <summary>
        /// Releases all resources used by the <see cref="StickyNotesDemo"/>.
        /// </summary>
        /// <remarks></remarks>
        private void Dispose()
        {
            this.Loaded -= OnLoaded;
            CommandBindings.Clear();
            if (richTextBoxAdv != null)
            {
                richTextBoxAdv.RequestNavigate -= (DataContext as StickyNotesViewModel).RichTextBoxAdv_RequestNavigate;
                richTextBoxAdv.Dispose();
                richTextBoxAdv = null;
            }
        }
        #endregion
    }
}
