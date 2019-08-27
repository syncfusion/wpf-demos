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
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace WindowsExplorerDemo
{
    public interface IFile 
    {
        string Name { get; set; }

        DateTime DateModified { get; set; }

        string FileType { get; set; }

        double Size { get; set; }

        object Info { get; set; }

        ImageSource Icon { get; set; }

        bool IsSelected { get; set; }
    }
}
