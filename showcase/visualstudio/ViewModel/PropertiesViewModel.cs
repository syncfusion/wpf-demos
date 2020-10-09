#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;

namespace syncfusion.visualstudiodemo.wpf
{
    public class PropertiesViewModel : NotificationObject
    {
        private Person person = null;

        public Person SelectedObject
        {
            get { return person; }
            set { person = value; }
        }

        public PropertiesViewModel()
        {
            SelectedObject = new Person();
            EnableGrouping = true;
        }

        private bool enableGroup;

        public bool EnableGrouping
        {
            get { return enableGroup; }
            set { enableGroup = value; this.RaisePropertyChanged(nameof(EnableGrouping)); }
        }

    }
}
