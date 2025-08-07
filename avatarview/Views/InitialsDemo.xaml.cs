#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.avatarviewdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for InitialsDemo.xaml
    /// </summary>
    public partial class InitialsDemo : DemoControl, IDisposable
    {
        bool isLoaded;
        public InitialsDemo()
        {
            InitializeComponent();
            if (avatarView.Background is SolidColorBrush solidBrush)
            {
                avatarBackgroundcolor.Color = solidBrush.Color;
                isLoaded = true;
            }
        }
        private void InitialTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (initialTypeComboBox == null || avatarView == null)
                return;
            switch (initialTypeComboBox.SelectedIndex)
            {
                case 0:
                    avatarView.InitialsType = AvatarInitialsType.SingleCharacter;
                    break;
                case 1:
                    avatarView.InitialsType = AvatarInitialsType.DoubleCharacter;
                    break;
            }
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (firstNameTextBox == null || lastNameTextBox == null || avatarView == null)
                return;

            avatarView.AvatarName = firstNameTextBox.Text.Replace(" ", string.Empty).Trim() + " " + lastNameTextBox.Text.Trim();
        }

        private void AvatarShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (avatarShapeComboBox == null || avatarView == null)
                return;
            switch (avatarShapeComboBox.SelectedIndex)
            {
                case 0:
                    if (avatarSizeComboBox != null && avatarSizeTextBlock != null)
                    {
                        avatarSizeComboBox.Visibility = Visibility.Visible;
                        avatarSizeTextBlock.Visibility = Visibility.Visible;
                        sliderLabel.Visibility = Visibility.Collapsed;
                        customSizeSlider.Visibility = Visibility.Collapsed;
                        sliderLabel1.Visibility = Visibility.Collapsed;
                        customCornerRadiusSlider.Visibility = Visibility.Collapsed;
                        badge.HorizontalPosition = 0.83;
                        badge.VerticalPosition = 0.85;
                        UpdateAvatarViewSize();
                    }
                    avatarView.AvatarShape = AvatarShape.Circle;
                    break;
                case 1:
                    avatarView.AvatarShape = AvatarShape.Square;
                    customSizeSlider.Visibility = Visibility.Collapsed;
                    sliderLabel.Visibility = Visibility.Collapsed;
                    avatarSizeComboBox.Visibility = Visibility.Visible;
                    avatarSizeTextBlock.Visibility = Visibility.Visible;
                    sliderLabel1.Visibility = Visibility.Collapsed;
                    customCornerRadiusSlider.Visibility = Visibility.Collapsed;
                    badge.HorizontalPosition = 0.90;
                    badge.VerticalPosition = 0.90;
                    UpdateAvatarViewSize();
                    break;
                case 2:
                    avatarView.AvatarShape = AvatarShape.Custom;
                    avatarSizeComboBox.Visibility = Visibility.Collapsed;
                    avatarSizeTextBlock.Visibility = Visibility.Collapsed;
                    sliderLabel.Visibility = Visibility.Visible;
                    customSizeSlider.Visibility = Visibility.Visible;
                    sliderLabel1.Visibility = Visibility.Visible;
                    customCornerRadiusSlider.Visibility = Visibility.Visible;
                    avatarView.Height = customSizeSlider.Value;
                    avatarView.Width = customSizeSlider.Value;
                    badge.HorizontalPosition = 0.90;
                    badge.VerticalPosition = 0.90;
                    badgeViewBox.Height = customSizeSlider.Value / 3.2;
                    badgeViewBox.Width = customSizeSlider.Value / 3.2;
                    break;
            }
        }
        private void UpdateAvatarViewSize()
        {
            if (avatarSizeComboBox == null || avatarView == null)
                return;
            switch (avatarSizeComboBox.SelectedIndex)
            {
                case 0:
                    avatarView.AvatarSize = AvatarSize.ExtraLarge;
                    badgeViewBox.Height = 31;
                    badgeViewBox.Width = 31;
                    break;
                case 1:
                    avatarView.AvatarSize = AvatarSize.Large;
                    badgeViewBox.Height = 19;
                    badgeViewBox.Width = 19;
                    break;
                case 2:
                    avatarView.AvatarSize = AvatarSize.Medium;
                    badgeViewBox.Height = 16;
                    badgeViewBox.Width = 16;
                    break;
                case 3:
                    avatarView.AvatarSize = AvatarSize.Small;
                    badgeViewBox.Height = 14;
                    badgeViewBox.Width = 14;
                    break;
                case 4:
                    avatarView.AvatarSize = AvatarSize.ExtraSmall;
                    badgeViewBox.Height = 11;
                    badgeViewBox.Width = 11;
                    break;
            }
        }

        private void AvatarSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAvatarViewSize();
        }

        private void CustomSizeSlider_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (avatarShapeComboBox.SelectedIndex == 2)
            {
                sliderLabel.Visibility = Visibility.Visible;
                avatarView.Width = customSizeSlider.Value;
                avatarView.Height = customSizeSlider.Value;
                badgeViewBox.Height = customSizeSlider.Value / 3.2;
                badgeViewBox.Width = customSizeSlider.Value / 3.2;
            }
        }

        private void CustomSizeSlider_Changed1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (avatarShapeComboBox.SelectedIndex == 2)
            {
                sliderLabel1.Visibility = Visibility.Visible;
                double radius = customCornerRadiusSlider.Value;
                avatarView.CornerRadius = new CornerRadius(radius);
            }
        }

        private void AvatarBackgroundcolor_ColorChanged(object sender, SelectedColorChangedEventArgs e)
        {
            if (isLoaded)
            {
                avatarView.Background = new SolidColorBrush(avatarBackgroundcolor.Color);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.firstNameTextBlock != null)
                {
                    this.firstNameTextBlock = null;
                }
                if (this.firstNameTextBox != null)
                {
                    this.firstNameTextBox = null;
                }
                if (this.lastNameTextBlock != null)
                {
                    this.lastNameTextBlock = null;
                }
                if (this.lastNameTextBox != null)
                {
                    this.lastNameTextBox = null;
                }
                if (this.initialTypeTextBlock != null)
                {
                    this.initialTypeTextBlock = null;
                }
                if (this.initialTypeComboBox != null)
                {
                    this.initialTypeComboBox.SelectionChanged -= this.InitialTypeComboBox_SelectionChanged;
                    this.initialTypeComboBox = null;
                }
                if (this.avatarShapeTextBlock != null)
                {
                    this.avatarShapeTextBlock = null;
                }
                if (this.avatarShapeComboBox != null)
                {
                    this.avatarShapeComboBox.SelectionChanged -= AvatarShapeComboBox_SelectionChanged;
                    this.avatarShapeComboBox = null;
                }
                if (this.avatarSizeTextBlock != null)
                {
                    this.avatarSizeTextBlock = null;
                }
                if (this.avatarSizeComboBox != null)
                {
                    this.avatarSizeComboBox.SelectionChanged -= AvatarSizeComboBox_SelectionChanged;
                    this.avatarSizeComboBox = null;
                }
                if (this.sliderLabel != null)
                {
                    this.sliderLabel = null;
                }
                if (this.customSizeSlider != null)
                {
                    this.customSizeSlider.ValueChanged -= CustomSizeSlider_Changed;
                    this.customSizeSlider = null;
                }
                if (this.sliderLabel1 != null)
                {
                    this.sliderLabel1 = null;
                }
                if (this.customCornerRadiusSlider != null)
                {
                    this.customCornerRadiusSlider.ValueChanged -= CustomSizeSlider_Changed1;
                    this.customCornerRadiusSlider = null;
                }
                if (this.avatarView != null)
                {
                    this.avatarView = null;
                }
                if (this.badge != null)
                {
                    this.badge = null;
                }
                if (this.badgeViewBox != null)
                {
                    this.badgeViewBox = null;
                }
                if (this.badgeTextBlock != null)
                {
                    this.badgeTextBlock = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
