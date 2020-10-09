#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Windows.Media;

namespace syncfusion.editordemos.wpf
{
    public class ColorPickerViewModel : NotificationObject
    {
        private Brush selectedBrush = Brushes.SkyBlue;

        public Brush SelectedBrush
        {
            get 
            { 
                return selectedBrush; 
            }
            set
            {
                if (selectedBrush != value)
                {
                    selectedBrush = value;
                    this.RaisePropertyChanged(nameof(this.SelectedBrush));
                }
            }
        }
    }
}
