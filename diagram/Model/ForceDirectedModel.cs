#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagramdemos.wpf.Model
{
    public class ForceDirectedDetail
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Manager { get; set; }
        public string Color { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }


    public class ForceDirectedDetails : ObservableCollection<ForceDirectedDetail>
    {

    }
}
