#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for Maps.xaml
    /// </summary>
    public partial class Maps : UserControl
    {
        public Maps()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            map.Dispose();
            if (this.DataContext is MapsViewModel mapsViewModel)
                mapsViewModel.Dispose();
        }
    }
}
