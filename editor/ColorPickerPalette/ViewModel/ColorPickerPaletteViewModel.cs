#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Media;

namespace syncfusion.editordemos.wpf
{
    public class ColorPickerPaletteViewModel : NotificationObject
    {
        private Color selectedColor = Colors.Black;
        private PaletteTheme paletteTheme = PaletteTheme.Office;
        private bool isStandardTabVisible = true;
        private bool isCustomTabVisible = true;
        private bool themePanelVisibility = true;
        private bool standardPanelVisibility = true;
        private bool recentlyUsedPanelVisibility = true;
        private bool moreColorOptionVisibility = true;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set
            {
                if (selectedColor != value)
                {
                    selectedColor = value;
                    this.RaisePropertyChanged(nameof(this.SelectedColor));
                }
            }
        }

        public PaletteTheme PaletteTheme
        {
            get
            {
                return paletteTheme;
            }
            set
            {
                if (paletteTheme != value)
                {
                    paletteTheme = value;
                    this.RaisePropertyChanged(nameof(this.PaletteTheme));
                }
            }
        }

        public bool IsStandardTabVisible
        {
            get
            {
                return isStandardTabVisible;
            }
            set
            {
                if (isStandardTabVisible != value)
                {
                    isStandardTabVisible = value;
                    this.RaisePropertyChanged(nameof(this.IsStandardTabVisible));
                }
            }
        }

        public bool IsCustomTabVisible
        {
            get
            {
                return isCustomTabVisible;
            }
            set
            {
                if (isCustomTabVisible != value)
                {
                    isCustomTabVisible = value;
                    this.RaisePropertyChanged(nameof(this.IsCustomTabVisible));
                }
            }
        }

        public bool ThemePanelVisibility
        {
            get
            {
                return themePanelVisibility;
            }
            set
            {
                if (themePanelVisibility != value)
                {
                    themePanelVisibility = value;
                    this.RaisePropertyChanged(nameof(this.ThemePanelVisibility));
                }
            }
        }

        public bool StandardPanelVisibility
        {
            get
            {
                return standardPanelVisibility;
            }
            set
            {
                if (standardPanelVisibility != value)
                {
                    standardPanelVisibility = value;
                    this.RaisePropertyChanged(nameof(this.StandardPanelVisibility));
                }
            }
        }

        public bool RecentlyUsedPanelVisibility
        {
            get
            {
                return recentlyUsedPanelVisibility;
            }
            set
            {
                if (recentlyUsedPanelVisibility != value)
                {
                    recentlyUsedPanelVisibility = value;
                    this.RaisePropertyChanged(nameof(this.RecentlyUsedPanelVisibility));
                }
            }
        }

        public bool MoreColorOptionVisibility
        {
            get
            {
                return moreColorOptionVisibility;
            }
            set
            {
                if (moreColorOptionVisibility != value)
                {
                    moreColorOptionVisibility = value;
                    this.RaisePropertyChanged(nameof(this.MoreColorOptionVisibility));
                }
            }
        }
    }
}
