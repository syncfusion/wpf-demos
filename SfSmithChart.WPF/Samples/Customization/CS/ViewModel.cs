#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.SmithChart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customization
{
    public class ViewModel
    {
        public ViewModel()
        {
            Trace1 = new ObservableCollection<Model>();

            Trace1.Add(new Model() { Resistance = 0, Reactance = 0.05 });
            Trace1.Add(new Model() { Resistance = 0.3, Reactance = 0.1 });
            Trace1.Add(new Model() { Resistance = 0.5, Reactance = 0.2 });
            Trace1.Add(new Model() { Resistance = 1.0, Reactance = 0.4 });
            Trace1.Add(new Model() { Resistance = 1.5, Reactance = 0.5 });
            Trace1.Add(new Model() { Resistance = 2.0, Reactance = 0.5 });
            Trace1.Add(new Model() { Resistance = 2.5, Reactance = 0.4 });
            Trace1.Add(new Model() { Resistance = 3.5, Reactance = 0.0 });
            Trace1.Add(new Model() { Resistance = 4.5, Reactance = -0.5 });
            Trace1.Add(new Model() { Resistance = 5, Reactance = -1.0 });
            Trace1.Add(new Model() { Resistance = 6, Reactance = -1.5 });
            Trace1.Add(new Model() { Resistance = 7, Reactance = -2.5 });
            Trace1.Add(new Model() { Resistance = 8, Reactance = -3.5 });
            Trace1.Add(new Model() { Resistance = 9, Reactance = -4.5 });
            Trace1.Add(new Model() { Resistance = 10, Reactance = -10 });
            Trace1.Add(new Model() { Resistance = 20, Reactance = -50 });

            Trace2 = new ObservableCollection<Model>();

            Trace2.Add(new Model() { Resistance = 0, Reactance = 0.15 });
            Trace2.Add(new Model() { Resistance = 0.3, Reactance = 0.2 });
            Trace2.Add(new Model() { Resistance = 0.5, Reactance = 0.4 });
            Trace2.Add(new Model() { Resistance = 1.0, Reactance = 0.8 });
            Trace2.Add(new Model() { Resistance = 1.5, Reactance = 1.0 });
            Trace2.Add(new Model() { Resistance = 2.0, Reactance = 1.2 });
            Trace2.Add(new Model() { Resistance = 2.5, Reactance = 1.3 });
            Trace2.Add(new Model() { Resistance = 3.5, Reactance = 1.6 });
            Trace2.Add(new Model() { Resistance = 4.5, Reactance = 2.0 });
            Trace2.Add(new Model() { Resistance = 6, Reactance = 4.5 });
            Trace2.Add(new Model() { Resistance = 8, Reactance = 6 });
            Trace2.Add(new Model() { Resistance = 10, Reactance = 25 });
        }

        public ObservableCollection<Model> Trace1 { get; set; }
        public ObservableCollection<Model> Trace2 { get; set; }

        public Array Palette
        {
            get { return Enum.GetValues(typeof(ColorPalette)).Cast<ColorPalette>().Except(new ColorPalette[] { ColorPalette.Custom }).ToArray(); }
        }

        public Array RenderingType
        {
            get { return Enum.GetValues(typeof(RenderingType)); }
        }

        public Array LegendPosition
        {
            get { return Enum.GetValues(typeof(ChartDock)).Cast<ChartDock>().Except(new ChartDock[] { ChartDock.Floating }).ToArray(); }
        }
    }

    public class Model
    {
        public double Resistance { get; set; }

        public double Reactance { get; set; }
    }
}
