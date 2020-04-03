#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Maps;
using Syncfusion.Windows.SampleLayout;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ElectionResultDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Events

        private void shapeLayer_ShapesSelected(object sender, SelectionEventArgs args)
        {
            if (Properties_Panel != null && Properties_Panel.Visibility == Visibility.Collapsed)
            {
                Properties_Panel.Visibility = Visibility.Visible;
            }
            if (shapeLayer != null && args.Items is ObservableCollection<MapShape>)
            {
                ObservableCollection<MapShape> mapShapes = (args.Items as ObservableCollection<MapShape>);
                if (mapShapes != null && mapShapes.Count > 0)
                {
                    var selectedShape = (mapShapes[0] as MapShape);
                    if (selectedShape != null && selectedShape.DataContext is ElectionData)
                    {
                        txt_State.Text = (selectedShape.DataContext as ElectionData).State;
                        txt_Winner.Text = (selectedShape.DataContext as ElectionData).Candidate;
                        txt_Electors.Text = (selectedShape.DataContext as ElectionData).Electors.ToString();
                    }
                }
            }
        }

        private void shapeLayer_ShapesUnSelected(object sender, SelectionEventArgs args)
        {
            if (Properties_Panel != null)
            {
                Properties_Panel.Visibility = Visibility.Collapsed;
            }
        }

        #endregion
    }   
}
