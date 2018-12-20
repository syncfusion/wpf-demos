#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace StatisticalFunctions
{
    public class DataCollection : ObservableCollection<Data>
    {
        public DataCollection()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            Random r3 = new Random();
            Random r4 = new Random();
            //for(int i=0; i<10; i++)
            {
                this.Add(new Data() { X = 5, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 5, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 2, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 2, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 2, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 5, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 2.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 5, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 3, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });

            }
        }
    }
}
