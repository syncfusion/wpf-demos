#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Collections.Generic;
using System.Windows.Media;

namespace PMMLWPFSampleBrowser
{
    /// <summary>
    /// Hold the Model information
    /// </summary>
    public class Model : NotificationObject
    {
        public string Name { get; set; }

        public bool IsExpanded { get; set; }

        public string Tag { get; set; }

        public List<Sample> SampleCollection { get; set; }
    }
}