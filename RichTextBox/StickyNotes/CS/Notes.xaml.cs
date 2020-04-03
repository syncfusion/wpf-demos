#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/// <summary>
/// 
/// </summary>
namespace StickyNotes
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes
    {
        #region Field
        private SkinColor skinColor;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Skin Color.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public SkinColor SkinColor
        {
            get
            {
                return skinColor;
            }
            set
            {
                skinColor = value;
                OnSkinColorChanged();
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Represents the Skin Command.
        /// </summary>
        /// <remarks></remarks>
        public static readonly RoutedUICommand SkinCommand = new RoutedUICommand("SkinCommand", "SkinCommand", typeof(Notes));
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Notes"/> class.
        /// </summary>
        public Notes()
        {
            InitializeComponent();
#if !Framework3_5
            //Enables touch manipulation.
            richTextBoxAdv.IsManipulationEnabled = true;
#endif
            richTextBoxAdv.RequestNavigate += RichTextBoxAdv_RequestNavigate;
            this.Loaded += OnLoaded;
            this.Closed += OnClosed;
            CommandBindings.Add(new CommandBinding(SkinCommand, OnSkinExecute));
            SkinColor = SkinColor.Yellow;
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
        /// Handles the RequestNavigate event of the richTextBoxAdv control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.RichTextBoxAdv.RequestNavigateEventArgs"/> instance containing the event data.</param>
        void RichTextBoxAdv_RequestNavigate(object obj, Syncfusion.Windows.Controls.RichTextBoxAdv.RequestNavigateEventArgs args)
        {
            if (args.Hyperlink.LinkType == Syncfusion.Windows.Controls.RichTextBoxAdv.HyperlinkType.Webpage || args.Hyperlink.LinkType == Syncfusion.Windows.Controls.RichTextBoxAdv.HyperlinkType.Email)
            {
                Uri uri = new Uri(args.Hyperlink.NavigationLink);
#if NETCORE
                System.Diagnostics.Process.Start(@"cmd.exe", @"/c start " + uri.AbsoluteUri);
#else
                Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
#endif
            }
            else if (args.Hyperlink.LinkType == HyperlinkType.File && File.Exists(args.Hyperlink.NavigationLink))
#if NETCORE
                System.Diagnostics.Process.Start(@"cmd.exe", @"/c start " + args.Hyperlink.NavigationLink);
#else
                Process.Start(args.Hyperlink.NavigationLink);
#endif
        }
        /// <summary>
        /// Called when closed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.EventArgs">EventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void OnClosed(object sender, EventArgs e)
        {
            Dispose();
        }
        /// <summary>
        /// Called on Skin executed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.Input.ExecutedRoutedEventArgs">ExecutedRoutedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void OnSkinExecute(object sender, ExecutedRoutedEventArgs e)
        {
            SkinColor color;
            if (e.Parameter is string &&
#if Framework3_5
                EnumTryParse<SkinColor>(e.Parameter.ToString(), out color))
#else
                Enum.TryParse(e.Parameter.ToString(), true, out color))
#endif
                SkinColor = color;
            else if (e.Parameter != null && Enum.IsDefined(typeof(SkinColor), e.Parameter))
                SkinColor = (SkinColor)e.Parameter;
        }
        #endregion

        #region Click Events
        /// <summary>
        /// Called on new note button clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.RoutedEventArgs">RoutedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void NewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            Notes window = new Notes();
            window.SkinColor = SkinColor;
            window.ShowInTaskbar = false;
            window.Owner = this;
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
            if (MessageBox.Show("Are you sure you want to delete this note?", "Sticky Notes", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
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
        /// Called on skin color changed.
        /// </summary>
        /// <remarks></remarks>
        private void OnSkinColorChanged()
        {
            Brush TitleBrush = Application.Current.Resources[SkinColor + "TitleBrush"] as Brush;
            Brush ContentBrush = Application.Current.Resources[SkinColor + "ContentBrush"] as Brush;
            title.Background = TitleBrush;
            content.Background = ContentBrush;
        }
        /// <summary>
        /// Releases all resources used by the.
        /// <see cref="T:StickyNotes.Notes">Notes</see>.
        /// </summary>
        /// <remarks></remarks>
        private void Dispose()
        {
            this.Closed -= OnClosed;
            this.Loaded -= OnLoaded;
            CommandBindings.Clear();
            if (richTextBoxAdv != null)
            {
                richTextBoxAdv.RequestNavigate -= RichTextBoxAdv_RequestNavigate;
                richTextBoxAdv.Dispose();
                richTextBoxAdv = null;
            }
        }
        #endregion

#if Framework3_5
        #region Static Implementation
        /// <summary>
        /// Determines whether the string is defined in the Enum or not.
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <typeparam name="T"></typeparam>
        /// <remarks></remarks>
        public static bool EnumTryParse<T>(string strType, out T result)
        {
            string strTypeFixed = strType.Replace(' ', '_');
            if (Enum.IsDefined(typeof(T), strTypeFixed))
            {
                result = (T)Enum.Parse(typeof(T), strTypeFixed, true);
                return true;
            }
            else
            {
                foreach (string value in Enum.GetNames(typeof(T)))
                {
                    if (value.Equals(strTypeFixed, StringComparison.OrdinalIgnoreCase))
                    {
                        result = (T)Enum.Parse(typeof(T), value);
                        return true;
                    }
                }
                result = default(T);
                return false;
            }
        }
        #endregion
#endif
    }

    /// <summary>
    /// Represents the skin color.
    /// </summary>
    /// <remarks></remarks>
    public enum SkinColor
    {
        Blue,
        Green,
        Pink,
        Purple,
        White,
        Yellow,
    }
}
