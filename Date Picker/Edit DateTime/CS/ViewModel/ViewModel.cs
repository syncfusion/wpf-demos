#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Controls.Input;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EditDateTime
{
    public class ViewModel : NotificationObject
    {            
        public ViewModel()
        {
            
        }

        private DateTime datetime=DateTime.Now;

        public DateTime Value
        {
            get { return datetime; }
            set { datetime = value;
                RaisePropertyChanged("Value");
            }
        }    

    }
}
