#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using Syncfusion.Olap.Manager;
    using System;
    using System.Collections.Generic;
    using Syncfusion.Windows.Shared;
    using System.Linq;

    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class ConfigurationViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationViewModel"/> class.
        /// </summary>
        public ConfigurationViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = ConfigurationModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = ConfigurationModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            this.olapDataManager = new OlapDataManager(ConnectionString);
        }

        #endregion

        #region Properties

        public OlapDataManager ClientDataManager
        {
            get { return this.olapDataManager; }
            set { this.olapDataManager = value; }
        }

        public IEnumerable<string> ClientDispModes
        {
            get
            {
                return Enum<Syncfusion.Windows.Client.Olap.DisplayModes>.GetNames();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Generic enumeration class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Enum<T>
    {
        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetNames()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("Type '" + type.Name + "' is not an enum");

            return
              (from field in
                   type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
               where field.IsLiteral
               select field.Name).ToList();
        }
    }
}
