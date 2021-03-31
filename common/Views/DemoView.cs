#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace syncfusion.demoscommon.wpf
{
    [ContentProperty("Content")]
    [DefaultProperty("Content")]
    public class DemoControl : UserControl, IDisposable
    {

        public DemoControl()
        {
            this.DefaultStyleKey = typeof(DemoControl);
        }

        public DemoControl(string themename) : this()
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
        }

        Grid ROOT;
        ContentPresenter SAMPLEVIEW;
        Grid OPTIONSVIEW;
        Border OPTIONSBORDER;
        public override void OnApplyTemplate()
        {
            ROOT = GetTemplateChild("ROOT") as Grid;
            SAMPLEVIEW = GetTemplateChild("SAMPLEVIEW") as ContentPresenter;
            OPTIONSVIEW = GetTemplateChild("OPTIONSVIEW") as Grid;
            OPTIONSBORDER = GetTemplateChild("OPTIONSBORDER") as Border;

            base.OnApplyTemplate();

            if (Options == null)
            {
                OPTIONSVIEW.Visibility = Visibility.Collapsed;
                ROOT.ColumnDefinitions[1].Width = new GridLength(0);
            }
            else
            {
                if (OptionsPosition == Dock.Right)
                {
                    ROOT.ColumnDefinitions[1].Width = OptionsSize;
                    OPTIONSVIEW.Margin = new Thickness(5, 0, 0, 0);
                    OPTIONSBORDER.BorderThickness = new Thickness(1, 0, 0, 0);
                }
                else if(OptionsPosition == Dock.Left)
                {
                    ROOT.ColumnDefinitions.RemoveAt(1);
                    ROOT.ColumnDefinitions.Insert(0, new ColumnDefinition() { Width = OptionsSize });
                    OPTIONSVIEW.Margin = new Thickness(0, 0, 5, 0);
                    OPTIONSBORDER.BorderThickness = new Thickness(0, 0, 1, 0);
                    Grid.SetColumn(SAMPLEVIEW, 1);
                    Grid.SetColumn(OPTIONSVIEW, 0);
                }
                else if (OptionsPosition == Dock.Top)
                {
                    ROOT.ColumnDefinitions.Clear();
                    ROOT.RowDefinitions.Add(new RowDefinition() { Height = OptionsSize });
                    ROOT.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                    OPTIONSVIEW.Margin = new Thickness(0, 0, 0, 5);
                    OPTIONSBORDER.BorderThickness = new Thickness(0, 0, 0, 1);
                    Grid.SetRow(SAMPLEVIEW, 1);
                    Grid.SetRow(OPTIONSVIEW, 0);
                }
                else if (OptionsPosition == Dock.Bottom)
                {
                    ROOT.ColumnDefinitions.Clear();
                    ROOT.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                    ROOT.RowDefinitions.Add(new RowDefinition() { Height = OptionsSize });
                    OPTIONSVIEW.Margin = new Thickness(0, 5, 0, 0);
                    OPTIONSBORDER.BorderThickness = new Thickness(0, 1, 0, 0);
                    Grid.SetRow(SAMPLEVIEW, 0);
                    Grid.SetRow(OPTIONSVIEW, 1);
                }
            }
        }


        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        /// <summary>
        ///  Gets or sets the options view.
        /// </summary>
        public object Options
        {
            get { return (object)GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }

        public static readonly DependencyProperty OptionsProperty =
            DependencyProperty.Register("Options", typeof(object), typeof(DemoControl), new PropertyMetadata(null));


        /// <summary>
        ///  Gets or sets position of <see cref="DemoControl.Options"/> view. You can position left, right, top or button and contorl the width or height using <see cref="DemoControl.OptionsSize"/>
        /// </summary>
        public Dock OptionsPosition
        {
            get { return (Dock)GetValue(OptionsPositionProperty); }
            set { SetValue(OptionsPositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OptionsPosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OptionsPositionProperty =
            DependencyProperty.Register("OptionsPosition", typeof(Dock), typeof(DemoControl), new PropertyMetadata(Dock.Right));

        /// <summary>
        /// Gets or sets the width of <see cref="DemoControl.Options"/> view when <see cref="DemoControl.OptionsPosition"/> is <see cref="Dock.Left"/> and <see cref="Dock.Right"/>.
        /// Gets or sets the height of <see cref="DemoControl.Options"/> view when <see cref="DemoControl.OptionsPosition"/> is <see cref="Dock.Top"/> and <see cref="Dock.Bottom"/>.
        /// </summary>
        public GridLength OptionsSize
        {
            get { return (GridLength)GetValue(OptionsSizeProperty); }
            set { SetValue(OptionsSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OptionsSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OptionsSizeProperty =
            DependencyProperty.Register("OptionsSize", typeof(GridLength), typeof(DemoControl), new PropertyMetadata(new GridLength(200)));

        /// <summary>
        /// Gets or sets the text displayed as options heading. you can hide the same by setting empty string.
        /// </summary>
        public string OptionsTitle
        {
            get { return (string)GetValue(OptionsTitleProperty); }
            set { SetValue(OptionsTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OptionsTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OptionsTitleProperty =
            DependencyProperty.Register("OptionsTitle", typeof(string), typeof(DemoControl), new PropertyMetadata("OPTIONS"));

        [Browsable(false)]
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DemoControl), new PropertyMetadata(string.Empty));

        [Browsable(false)]
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(DemoControl), new PropertyMetadata(string.Empty));
    }
}
