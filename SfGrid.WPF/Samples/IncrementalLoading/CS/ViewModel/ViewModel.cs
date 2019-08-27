#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using IncrementalLoading.NorthwindService;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Services.Client;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace IncrementalLoading
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Members

        NorthwindEntities northwindEntity;

        #endregion

        #region Ctor

        public ViewModel()
        {
            string uri="http://services.odata.org/Northwind/Northwind.svc/";
            if (CheckConnection(uri))
            {
                gridSource = new IncrementalList<Order>(LoadMoreItems) { MaxItemCount = 1000 };
                northwindEntity = new NorthwindEntities(new Uri(uri));
            }
            else
            {
                NoNetwork = true;
                IsBusy = false;
            }
        }

        #endregion

        #region Properties

        private IncrementalList<Order> gridSource;

        public IncrementalList<Order> GridSource
        {
            get { return gridSource; }
            set { gridSource = value; RaisePropertyChanged("GridSource"); }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; RaisePropertyChanged("IsBusy"); }
        }

        private bool noNetwork;

        public bool NoNetwork
        {
            get { return noNetwork; }
            set { noNetwork = value; RaisePropertyChanged("NoNetwork"); }
        }
        

        #endregion

        #region INotifyPropertyChanged Member

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Methods

        void LoadMoreItems(uint count, int baseIndex)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ae) =>
            {
                DataServiceQuery<Order> query = northwindEntity.Orders.Expand("Customer");
                query = query.Skip<Order>(baseIndex).Take<Order>(50) as DataServiceQuery<Order>;
                IAsyncResult ar = query.BeginExecute(null, null);
                var items = query.EndExecute(ar);
                var list = items.ToList();
                Application.Current.Dispatcher.Invoke(new Action(() => { GridSource.LoadItems(list); }));
            };

            worker.RunWorkerCompleted += (o, ae) =>
            {
                IsBusy = false; 
            };
            
            IsBusy = true;
            worker.RunWorkerAsync();
        }

        private bool CheckConnection(String URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
