#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.richtextboxdemos.wpf
{
    internal class StickyNotesViewModel : INotifyPropertyChanged
    {
        #region Field
        private Brush titleBrush;
        private Brush contentBrush;
        private ResourceDictionary resources;
        #endregion

        #region Properties
        public Brush ContentBrush
        {
            get
            {
                return contentBrush;
            }
            set
            {
                contentBrush = value;
                OnPropertyChanged("ContentBrush");
            }
        }
        public Brush TitleBrush
        {
            get
            {
                return titleBrush;
            }
            set
            {
                titleBrush = value;
                OnPropertyChanged("TitleBrush");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Represents the Skin Command.
        /// </summary>
        /// <remarks></remarks>
        public static readonly RoutedUICommand SkinCommand = new RoutedUICommand("SkinCommand", "SkinCommand", typeof(StickyNotesDemo));
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Notes_ViewModel"/> class.
        /// </summary>
        public StickyNotesViewModel()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is StickyNotesDemo)
                {
                    resources = window.Resources;
                }
            }
            TitleBrush = resources[SkinColor.Yellow + "TitleBrush"] as Brush;
            ContentBrush = resources[SkinColor.Yellow + "ContentBrush"] as Brush;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void OnSkinExecute(object sender, ExecutedRoutedEventArgs e)
        {
            SkinColor color = SkinColor.Yellow;
            if (e.Parameter is string &&
#if Framework3_5
                EnumTryParse<SkinColor>(e.Parameter.ToString(), out color))
#else
                Enum.TryParse(e.Parameter.ToString(), true, out color))
#endif
            {
                TitleBrush = resources[color + "TitleBrush"] as Brush;
                ContentBrush = resources[color + "ContentBrush"] as Brush;
            }
        }

        /// <summary>
        /// Handles the RequestNavigate event of the richTextBoxAdv control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.RichTextBoxAdv.RequestNavigateEventArgs"/> instance containing the event data.</param>
        internal void RichTextBoxAdv_RequestNavigate(object obj, Syncfusion.Windows.Controls.RichTextBoxAdv.RequestNavigateEventArgs args)
        {
            if (args.Hyperlink.LinkType == Syncfusion.Windows.Controls.RichTextBoxAdv.HyperlinkType.Webpage || args.Hyperlink.LinkType == Syncfusion.Windows.Controls.RichTextBoxAdv.HyperlinkType.Email)
            {
                Uri uri = new Uri(args.Hyperlink.NavigationLink);
#if NETCORE
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = $"/c start " + uri.AbsoluteUri
                };
                Process.Start(processStartInfo);
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
    }
}
