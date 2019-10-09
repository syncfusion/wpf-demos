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
using System.Windows.Interactivity;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;
using System.Windows;

namespace WindowsExplorerDemo
{    

    class ListViewClick : TargetedTriggerAction<ListView>
    {
        protected override void Invoke(object parameter)
        {
            IFile file =((ListView)TargetObject).SelectedItem as IFile;
            if (file != null)
            {
                if (file.Info is FileInfo)
                {
                    FileInfo fileInfo = file.Info as FileInfo;
                    Process.Start(new ProcessStartInfo(fileInfo.FullName));
                }

                if (file.Info is DirectoryInfo)
                {
                    DirectoryInfo fileInfo = file.Info as DirectoryInfo;
                    Process.Start(new ProcessStartInfo(fileInfo.FullName));
                }
            }
        }

#if Framework3_5
        public FrameworkElement TargetObject
        {
            get { return (FrameworkElement)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(FrameworkElement), typeof(ListViewClick), new UIPropertyMetadata(null));
#endif
    }  
}
