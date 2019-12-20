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
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Primitives;

namespace SfRatingDemo
{
    public class RatingProperties : NotificationObject
    {
        private Precision precision;

        private bool showToolTip = true;
        private bool isReadOnly = false;

        public Precision Precision
        {
            get
            {
                return precision;
            }
            set
            {
                precision = value;
                RaisePropertyChanged("Precision");
            }
        }


        public bool ShowToolTip
        {
            get
            {
                return showToolTip;
            }
            set
            {
                showToolTip = value;
                RaisePropertyChanged("ShowToolTip");
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                isReadOnly = value;
                RaisePropertyChanged("IsReadOnly");
            }
        }
    }
}
