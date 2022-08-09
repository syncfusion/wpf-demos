#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace syncfusion.ganttdemos.wpf
{
   public class FlatPerformanceCheckViewModel : NotificationObject
    {
        /// <summary>
        /// Random  Variable
        /// </summary>
        private Random random = new Random(14143);

        /// <summary>
        /// Some list of product Names.
        /// </summary>
        private static string[] ProdNames = new string[]{"Airbag sensor","Anti-pinch sensor","Camshaft position sensor",
            "Crankshaft position sensor","Engine sensor","Fuel level sensor","Knock sensor","Light sensor",
            "Manifold absolute pressure sensor","Oxygen sensor","Power-steering pressure sensor","Pressure sensor",
        "Rain sensor","Rotational sensor","Temperature sensor","Transmission input and output sensor","ABS brack sensor",
        "TDC sensor","MAP sensor","IMA sensor","ABS sensor(Anti-lock Brake System)","Battery","Door switch","Ignition switch",
        "Power window switch","Steering column switch","Switch cover","Switch panel","Thermostat","frame switch","Chassis control computer",
        "Cruise control computer","Door contact","Engine computer and management system","Engine control unit","Fuse","Fuse box",
        "Ground strap","Performance chip","Performance monitor","Tire pressure gauge","Vacuum gauge","Voltmeter","Front clip"
        ,"Front fascia and header panel","Grille (also called grill)","Pillar and hard trim","Quarter panel","Radiator core support"
        ,"Performance monitor","Relay connector","Remote lock","Shift improver","Temperature gauge"};

        private ObservableCollection<Product> _productCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public FlatPerformanceCheckViewModel()
        {
            _loadData = new DelegateCommand<object>(OnLoadDataClicked, CanExecute);
        }

        private string _timeTaken;
        /// <summary>
        /// Gets or sets the time taken.
        /// </summary>
        /// <value>The time taken.</value>
        public string TimeTaken
        {
            get
            {
                return _timeTaken;
            }
            set
            {
                _timeTaken = value;
                RaisePropertyChanged("TimeTaken");
            }
        }

        private string _loadedTime;

        /// <summary>
        /// Gets or sets the loaded time.
        /// </summary>
        /// <value>The loaded time.</value>
        public string LoadedTime
        {
            get
            {
                return _loadedTime;
            }

            set
            {
                _loadedTime = value;
                RaisePropertyChanged("LoadedTime");
            }
        }

        private int _noOfItems = 100;

        /// <summary>
        /// Gets or sets the no of items.
        /// </summary>
        /// <value>The no of items.</value>
        public int NoOfItems
        {
            get
            {
                return _noOfItems;
            }

            set
            {
                _noOfItems = value;
                RaisePropertyChanged("NoOfItems");
            }
        }

        #region Delegate Command

        private DelegateCommand<object> _loadData;

        /// <summary>
        /// Gets the load data.
        /// </summary>
        /// <value>The load data.</value>
        public DelegateCommand<object> LoadData
        {
            get
            {
                return _loadData;
            }
        }

        #endregion

        #region DelegateCommand Method

        /// <summary>
        /// Called when [load data clicked].
        /// </summary>
        /// <param name="parms">The parms.</param>
        private void OnLoadDataClicked(object parms)
        {
            ObservableCollection<Product> DataCollection;
            DateTime time = DateTime.Now;
            DataCollection = this.GetData(this.NoOfItems);
            TimeTaken = Math.Round((DateTime.Now - time).TotalSeconds, 4).ToString() + "  Sec";
            this.ProductCollection = DataCollection;
            LoadedTime = Math.Round((DateTime.Now - time).TotalSeconds, 4).ToString() + "  Sec";
        }

        /// <summary>
        /// Determines whether this instance can execute the specified parms.
        /// </summary>
        /// <param name="parms">The parms.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can execute the specified parms; otherwise, <c>false</c>.
        /// </returns>
        private bool CanExecute(object parms)
        {
            return true;
        }

        #endregion
        /// <summary>
        /// Gets the data as itemssource for Gantt
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public ObservableCollection<Product> GetData(int count)
        {
            var data = new ObservableCollection<Product>();
            int randInt = random.Next(10);

            for (int i = 1; i <= count; i++)
            {
                var r = random.Next(0, data.Count);
                data.Add(new Product()
                {
                    ProductId = i,
                    ProductName = ProdNames[random.Next(52)],
                    ManufacturingStart = DateTime.Now.AddDays(-5 + random.Next(10)),
                    ManufacturingEnd = DateTime.Now.AddDays(5 + random.Next(10)),
                    Progress = random.Next(0, 50)
                });
            }
            return data;
        }

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<Product> ProductCollection
        {
            get
            {
                return _productCollection;
            }
            set
            {
                _productCollection = value;
                RaisePropertyChanged("ProductCollection");
            }
        }
    }
}
