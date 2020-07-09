#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace StickyNotes
{
    internal class Notes_ViewModel : INotifyPropertyChanged
    {
        #region Field
        private Brush titleBrush;
        private Brush contentBrush;
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
        public static readonly RoutedUICommand SkinCommand = new RoutedUICommand("SkinCommand", "SkinCommand", typeof(Notes));
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Notes_ViewModel"/> class.
        /// </summary>
        public Notes_ViewModel()
        {
            TitleBrush = Application.Current.Resources[Model.SkinColor.Yellow + "TitleBrush"] as Brush;
            ContentBrush = Application.Current.Resources[Model.SkinColor.Yellow + "ContentBrush"] as Brush;
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
            Model.SkinColor color = Model.SkinColor.Yellow;
            if (e.Parameter is string &&
#if Framework3_5
                EnumTryParse<SkinColor>(e.Parameter.ToString(), out color))
#else
                Enum.TryParse(e.Parameter.ToString(), true, out color))
#endif
                TitleBrush = Application.Current.Resources[color + "TitleBrush"] as Brush;
            ContentBrush = Application.Current.Resources[color + "ContentBrush"] as Brush;
        }
    }
}
