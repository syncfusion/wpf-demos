#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using System;
    using Syncfusion.Windows.Shared;

    public class XAMLConfigViewModel : NotificationObject
    {
        #region Field

        public static string ConnectionString;
        private string olapConnectionString = "";
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="XAMLConfigViewModel"/> class.
        /// </summary>
        public XAMLConfigViewModel() 
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                olapConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                olapConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
        }

        #endregion

        #region Properties


        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string OlapConnectionString
        {
            get { return olapConnectionString; }
            set { olapConnectionString = value; RaisePropertyChanged("OlapConnectionString"); }
        }

        #endregion
    }
}
