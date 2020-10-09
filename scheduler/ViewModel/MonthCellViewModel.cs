#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace syncfusion.schedulerdemos.wpf
{
    /// <summary>
    /// Month cell view model to provide data of month cell to DataTemplate.
    /// </summary>
    public class MonthCellViewModel : NotificationObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets month foreground.
        /// </summary>
        public Brush Foreground { get; set; }

        /// <summary>
        /// Gets or sets month date.
        /// </summary>
        public string DateText { get; set; }

        /// <summary>
        /// Gets or sets month cell appointments.
        /// </summary>
        public List<ScheduleAppointment> MonthCellAppointments { get; set; }

        #endregion
    }
}
