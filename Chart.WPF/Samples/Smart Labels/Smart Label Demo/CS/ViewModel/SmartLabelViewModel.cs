#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;

namespace SmartLabels
{
    public class DataCollection 
    {
        public DataCollection()
        {
            Random r1 = new Random();
            this.Data = new ObservableCollection<Data>();
            Data.Add(new Data() { X = 1, Y = 23.5, Y1 = 1, Y2 = 3, Y3 = 5});
            Data.Add(new Data() { X = 2, Y = 28.4 , Y1= 2, Y2 = 10, Y3 =6 });
            Data.Add(new Data() { X = 3, Y = 25.2, Y1 = 3, Y2 = 10, Y3 =3 });
            Data.Add(new Data() { X = 4, Y = 22.4, Y1 = 4, Y2 = 10 });
            Data.Add(new Data() { X = 5, Y = 21, Y1 = 5, Y2 = 10, Y3 =3 });

            Data.Add(new Data() { X = 6, Y = 15.3, Y1 = 6, Y2 = 10, Y3 = 6 });
            Data.Add(new Data() { X = 7, Y = 15.3, Y1 = 7, Y2 = 10, Y3 = 8 });
            Data.Add(new Data() { X = 8, Y = 15.5, Y1 = 8, Y2 = 10, Y3 = 10 });
            Data.Add(new Data() { X = 9, Y = 18.5, Y1 = 9, Y2 = 10, Y3 = 11 });
            Data.Add(new Data() { X = 10, Y = 26.5, Y1 = 10, Y2 = 10, Y3 = 7 });
            Data.Add(new Data() { X = 11, Y = 23.5, Y1 = 11, Y2 = 5, Y3 = 10 });
            Data.Add(new Data() { X = 12, Y = 30.8, Y1 = 12, Y2 = 10, Y3 = 4 });
            Data.Add(new Data() { X = 13, Y = 43.5, Y1 = 13, Y2 = 6, Y3 = 6 });
            Data.Add(new Data() { X = 14, Y = 40.2, Y1 = 14, Y2 = 2, Y3 = 9 });
            Data.Add(new Data() { X = 15, Y = 45.3, Y1 = 16, Y2 = 3, Y3 = 11 });
            Data.Add(new Data() { X = 16, Y = 55.3, Y1 = 17, Y2 = 1, Y3 = 12 });
            Data.Add(new Data() { X = 16.1, Y = 52.1, Y1 = 17, Y2 = 1, Y3 = 12 });
            Data.Add(new Data() { X = 17, Y = 53.1, Y1 = 18, Y2 = 9, Y3 = 23 });

            Data.Add(new Data() { X = 18, Y = 51.1, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 19, Y = 57.5, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 20, Y = 57.3, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 21, Y = 60.3, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 22, Y = 64.9, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 22.1, Y = 64.9, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 24, Y = 67.8, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 24, Y = 67.8, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 24.1, Y = 67.8, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 24.1, Y = 67.8, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 25, Y = 69.3, Y1 = 18, Y2 = 9, Y3 = 23 });
            Data.Add(new Data() { X = 26, Y = 70.4, Y1 = 18, Y2 = 9, Y3 = 23 });


        }
       
        public ObservableCollection<Data> Data
        {
            get;
            set;
        }
        public Array PaletteCollection
        {
            get
            {
                return new ChartColorPalette[] { ChartColorPalette.Nature, 
                                          ChartColorPalette.Metro, 
                                          ChartColorPalette.Default, 
                                          ChartColorPalette.DefaultDark,
                                          ChartColorPalette.MixedFantasy
                                        };
            }
        }

        public Array SeriesType
        {
            get
            {
                return new ChartTypes[] {ChartTypes.Line,
                                         ChartTypes.Spline,
                                         ChartTypes.SplineArea,
                                         ChartTypes.Area,
                                         ChartTypes.Column,
                                         ChartTypes.Scatter,
                                         ChartTypes.Bubble,
                                         ChartTypes.Gantt,
                                         ChartTypes.Bar
                    
                };
            }
        }
    }

}
