#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.gridcontroldemos.wpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
using System.Windows.Controls.Primitives;
    using System.Windows.Input;

    public class ImageTextListBoxListBoxItem : ListBoxItem, INotifyPropertyChanged
    {
        private string text = string.Empty;
        private ImageSource image;

        static ImageTextListBoxListBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageTextListBoxListBoxItem), new FrameworkPropertyMetadata(typeof(ImageTextListBoxListBoxItem)));
        }


        public ImageTextListBoxListBoxItem()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal ImageTextListBox ListBox
        {
            get
            {
                return ((ItemsControl.ItemsControlFromItemContainer(this) as Selector)) as ImageTextListBox;
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.RaisePropertyChangedEvent(new PropertyChangedEventArgs("Text"));
                }
            }
        }

        public ImageSource Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        public override string ToString()
        {
            return this.text;
        }

        private void RaisePropertyChangedEvent(PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, args);
            }
        }



        public static readonly DependencyProperty IsHighlightedProperty = DependencyProperty.Register(
    "IsHighlighted",
    typeof(bool),
    typeof(ImageTextListBoxListBoxItem));

        public bool IsHighlighted
        {
            get
            {
                return (bool)this.GetValue(ImageTextListBoxListBoxItem.IsHighlightedProperty);
            }

            set
            {
                this.SetValue(ImageTextListBoxListBoxItem.IsHighlightedProperty, value);
            }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            var parentListBox = this.ListBox;
            if (parentListBox != null)
            {
                parentListBox.NotifyListBoxItemEnter(this);
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            var parentListBox = this.ListBox;
            if (parentListBox != null)
            {
                parentListBox.NotifyListBoxItemMouseUp(this);
            }

            e.Handled = true;
            base.OnMouseLeftButtonUp(e);
        }

        internal void SetIsHighlighted(bool value)
        {
            this.IsHighlighted = value;
        }


    }
}
