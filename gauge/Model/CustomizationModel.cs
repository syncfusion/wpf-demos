#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace syncfusion.gaugedemos.wpf
{
   public class CustomizationModel : NotificationObject
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (string.Equals(title, value))
                {
                    return;
                }
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        private Brush brush;
        public Brush Brush
        {
            get
            {
                return brush;
            }
            set
            {
                if (Brush.Equals(brush, value))
                {
                    return;
                }
                brush = value;
                RaisePropertyChanged("Brush");
            }
        }
    }
}

