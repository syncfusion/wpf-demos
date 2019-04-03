#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


namespace BIDashboard.Helper
{
    using System;
    using System.Configuration;
    using Syncfusion.Olap.Manager;
    public sealed class OlapDataSourceHelper
    {
        /// <summary>
        /// Returns the OlapDataManager for the given input OlapReport file.
        /// </summary>
        /// <param name="reportFileName"></param>
        /// <returns></returns>
        public static OlapDataManager GetManager(string reportFileName, string connectionString1)
        {
            try
            {
                var connectionString = string.Empty;
                if (connectionString1 == null)
                    connectionString = GetConnectionString();
                else
                    connectionString = connectionString1;

                var olapDataManager = new OlapDataManager(connectionString);
                olapDataManager.LoadReportDefinitionFile(reportFileName);

                var currentReport = olapDataManager.Reports[0];
                olapDataManager.SetCurrentReport(currentReport);

                return olapDataManager;
            }
            catch
            {
                throw new ArgumentException("Unable to load the specified report.");
            }
        }

        private static string GetConnectionString()
        {
            var connectionString = "";

            if (ConnectionHelper.Instance.UseConnectionName)
            {
                connectionString = ConfigurationManager.ConnectionStrings[ConnectionHelper.Instance.ConnectionName].ConnectionString;
            }
            else
            {
                connectionString = ConnectionHelper.Instance.ConnectionString;
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                // Fallback default connection string.
                connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            }

            return connectionString;
        }
    }

    public sealed class ConnectionHelper
    {
        #region [ Singleton Instance ]
        
        private static readonly ConnectionHelper instance = new ConnectionHelper(); 

        #endregion

        #region [ Private Constructor ]
        
        private ConnectionHelper()
        {
        } 

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets a value indicating whether to use ConnectionName while establishing connection.
        /// </summary>
        /// <value><c>true</c> if [use connection name]; otherwise, <c>false</c>.</value>
        public bool UseConnectionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the connection.
        /// </summary>
        /// <value>The name of the connection.</value>
        public string ConnectionName { get; set; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        #endregion

        #region [ Instace Property ]

        public static ConnectionHelper Instance
        {
            get { return instance; }
        }

        #endregion
    }
}
