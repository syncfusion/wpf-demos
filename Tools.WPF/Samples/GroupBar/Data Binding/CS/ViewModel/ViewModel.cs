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
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ItemsSourceDemo
{
    public class ViewModel
    {
        public ViewModel()
        {
            SampleList = new ObservableCollection<Employee>();
            PopulateData();
           
        }
        public ObservableCollection<Employee> SampleList { get; set; }
        private void PopulateData()
        {
            SampleList.Add(new Employee() { Name = "Buchanan", Age = "25", Location = "Washington D.C.", DOB = "02/25/1984", Image = "/Resources/Buchanan.png" });
            SampleList.Add(new Employee() { Name = "Callahan", Age = "19", Location = "Costa Rica", DOB = "10/16/1990", Image = "/Resources/Callahan.png" });
            SampleList.Add(new Employee() { Name = "Fuller", Age = "35", Location = "Carolina", DOB = "09/24/1970", Image = "/Resources/Fuller.png" });
            SampleList.Add(new Employee() { Name = "Lever Ling", Age = "28", Location = "New York", DOB = "08/26/1985", Image = "/Resources/Leverling.png" });
            SampleList.Add(new Employee() { Name = "King", Age = "20", Location = "Canada", DOB = "12/19/1984", Image = "/Resources/King.png" });
        }

       
    }
}
