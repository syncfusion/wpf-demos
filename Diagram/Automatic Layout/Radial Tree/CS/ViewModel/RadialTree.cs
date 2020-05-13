#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AutomaticLayout_RadialTreeLayout
{
    public class RadialTree : DiagramViewModel
    {
        public RadialTree()
        {
            //Initialize Diagram Properties

            Constraints = Constraints.Remove(GraphConstraints.PageEditing);
            Constraints = Constraints.Add(GraphConstraints.Pannable, GraphConstraints.Zoomable);

            ScrollSettings = new ScrollSettings()
            {
                ScrollLimit = ScrollLimit.Diagram,
            };

            PageSettings = new PageSettings()
            {
                PageBackground = new SolidColorBrush(Colors.White),
                PageBorderBrush = new SolidColorBrush(Colors.Transparent),
            };


            // Initialize Layout Data

            Employees employee = new Employees();

            GetData(employee);

            DataSourceSettings = new DataSourceSettings()
            {
                ParentId = "ParentId",
                Id = "EmpId",
                DataSource = employee,
                Root = "1",
            };

            LayoutManager = new LayoutManager()
            {
                Layout = new RadialTreeLayout()
                {
                    HorizontalSpacing = 10,
                    VerticalSpacing = 30
                }
            };
        }

        /// <summary>
        /// Method for getting LayoutData
        /// </summary>
        /// <param name="employee"></param>
        private void GetData(Employees employee)
        {
            employee.Add(new Employee() { EmpId = "1", ParentId = "", Imageurl = "./Assets/Thomas.png" });
            employee.Add(new Employee() { EmpId = "2", ParentId = "1", Imageurl = "./Assets/Clayton.png" });
            employee.Add(new Employee() { EmpId = "3", ParentId = "1", Imageurl = "./Assets/eric.png" });
            employee.Add(new Employee() { EmpId = "4", ParentId = "1", Imageurl = "./Assets/John.png" });
            employee.Add(new Employee() { EmpId = "5", ParentId = "1", Imageurl = "./Assets/image12.png" });
            employee.Add(new Employee() { EmpId = "6", ParentId = "1", Imageurl = "./Assets/image2.png" });
            employee.Add(new Employee() { EmpId = "7", ParentId = "1", Imageurl = "./Assets/image3.png" });
            employee.Add(new Employee() { EmpId = "8", ParentId = "1", Imageurl = "./Assets/image50.png" });
            employee.Add(new Employee() { EmpId = "9", ParentId = "2", Imageurl = "./Assets/image51.png" });
            employee.Add(new Employee() { EmpId = "10", ParentId = "2", Imageurl = "./Assets/image53.png" });
            employee.Add(new Employee() { EmpId = "11", ParentId = "3", Imageurl = "./Assets/image54.png" });
            employee.Add(new Employee() { EmpId = "12", ParentId = "3", Imageurl = "./Assets/image55.png" });
            employee.Add(new Employee() { EmpId = "13", ParentId = "4", Imageurl = "./Assets/image56.png" });
            employee.Add(new Employee() { EmpId = "14", ParentId = "4", Imageurl = "./Assets/image57.png" });
            employee.Add(new Employee() { EmpId = "15", ParentId = "5", Imageurl = "./Assets/images7.png" });
            employee.Add(new Employee() { EmpId = "16", ParentId = "5", Imageurl = "./Assets/images9.png" });
            employee.Add(new Employee() { EmpId = "17", ParentId = "6", Imageurl = "./Assets/Jenny.png" });
            employee.Add(new Employee() { EmpId = "18", ParentId = "6", Imageurl = "./Assets/John.png" });
            employee.Add(new Employee() { EmpId = "19", ParentId = "7", Imageurl = "./Assets/eric.png" });
            employee.Add(new Employee() { EmpId = "20", ParentId = "7", Imageurl = "./Assets/Maria.png" });
            employee.Add(new Employee() { EmpId = "21", ParentId = "8", Imageurl = "./Assets/image12.png" });
            employee.Add(new Employee() { EmpId = "22", ParentId = "8", Imageurl = "./Assets/Paul.png" });
            employee.Add(new Employee() { EmpId = "23", ParentId = "9", Imageurl = "./Assets/Robin.png" });
            employee.Add(new Employee() { EmpId = "24", ParentId = "9", Imageurl = "./Assets/smith.png" });
            employee.Add(new Employee() { EmpId = "25", ParentId = "10", Imageurl = "./Assets/Thomas.png" });
            employee.Add(new Employee() { EmpId = "26", ParentId = "10", Imageurl = "./Assets/Clayton.png" });
            employee.Add(new Employee() { EmpId = "27", ParentId = "11", Imageurl = "./Assets/eric.png" });
            employee.Add(new Employee() { EmpId = "28", ParentId = "11", Imageurl = "./Assets/images7.png" });
            employee.Add(new Employee() { EmpId = "29", ParentId = "12", Imageurl = "./Assets/image12.png" });
            employee.Add(new Employee() { EmpId = "30", ParentId = "12", Imageurl = "./Assets/image2.png" });
            employee.Add(new Employee() { EmpId = "31", ParentId = "13", Imageurl = "./Assets/image3.png" });
            employee.Add(new Employee() { EmpId = "32", ParentId = "13", Imageurl = "./Assets/image50.png" });
            employee.Add(new Employee() { EmpId = "33", ParentId = "14", Imageurl = "./Assets/image51.png" });
            employee.Add(new Employee() { EmpId = "34", ParentId = "14", Imageurl = "./Assets/image53.png" });
            employee.Add(new Employee() { EmpId = "35", ParentId = "15", Imageurl = "./Assets/image54.png" });
            employee.Add(new Employee() { EmpId = "36", ParentId = "15", Imageurl = "./Assets/image55.png" });
            employee.Add(new Employee() { EmpId = "37", ParentId = "16", Imageurl = "./Assets/image56.png" });
            employee.Add(new Employee() { EmpId = "38", ParentId = "16", Imageurl = "./Assets/image57.png" });
            employee.Add(new Employee() { EmpId = "39", ParentId = "17", Imageurl = "./Assets/images7.png" });
            employee.Add(new Employee() { EmpId = "40", ParentId = "17", Imageurl = "./Assets/images9.png" });
            employee.Add(new Employee() { EmpId = "41", ParentId = "18", Imageurl = "./Assets/Jenny.png" });
            employee.Add(new Employee() { EmpId = "42", ParentId = "18", Imageurl = "./Assets/John.png" });
            employee.Add(new Employee() { EmpId = "43", ParentId = "19", Imageurl = "./Assets/Clayton.png" });
            employee.Add(new Employee() { EmpId = "44", ParentId = "19", Imageurl = "./Assets/Maria.png" });
            employee.Add(new Employee() { EmpId = "45", ParentId = "20", Imageurl = "./Assets/image55.png" });
            employee.Add(new Employee() { EmpId = "46", ParentId = "20", Imageurl = "./Assets/Paul.png" });
            employee.Add(new Employee() { EmpId = "47", ParentId = "21", Imageurl = "./Assets/Robin.png" });
            employee.Add(new Employee() { EmpId = "48", ParentId = "21", Imageurl = "./Assets/smith.png" });
            employee.Add(new Employee() { EmpId = "49", ParentId = "22", Imageurl = "./Assets/Thomas.png" });
            employee.Add(new Employee() { EmpId = "50", ParentId = "22", Imageurl = "./Assets/John.png" });
        }
    }
}
