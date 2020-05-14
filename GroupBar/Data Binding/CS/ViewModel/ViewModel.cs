#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace ItemsSourceDemo
{
    /// <summary>
    /// Represents a viewmodel.
    /// </summary>
    public class ViewModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the collection for sample list.
        /// </summary>
        private ObservableCollection<Model> sampleList;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            SampleList = new ObservableCollection<Model>();
            PopulateData();
        }

		/// <summary>
        /// Gets or sets the sample list <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> SampleList
        {
            get
            {
                return sampleList;
            }
            set
            {
                if (sampleList != value)
                    sampleList = value;
                RaisePropertyChanged("SampleList");
            }
        }

		/// <summary>
        /// Adding details to the sample list collection.
        /// </summary>  
        private void PopulateData()
        {
            SampleList.Add(new Model() { Name = "Buchanan", Age = "25", Location = "Washington D.C.", DateOfBirth = "02/25/1984", Image = "/Resources/Buchanan.png" });
            SampleList.Add(new Model() { Name = "Callahan", Age = "19", Location = "Costa Rica", DateOfBirth = "10/16/1990", Image = "/Resources/Callahan.png" });
            SampleList.Add(new Model() { Name = "Fuller", Age = "35", Location = "Carolina", DateOfBirth = "09/24/1970", Image = "/Resources/Fuller.png" });
            SampleList.Add(new Model() { Name = "Lever Ling", Age = "28", Location = "New York", DateOfBirth = "08/26/1985", Image = "/Resources/Leverling.png" });
            SampleList.Add(new Model() { Name = "King", Age = "20", Location = "Canada", DateOfBirth = "12/19/1984", Image = "/Resources/King.png" });
        }
    }
}
