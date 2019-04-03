#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
namespace OrganizationalChartDemo
{
    //Class to Search based on Values
    public class SearchViewModel
    {
        public SearchViewModel()
        {
            SearchResult = new DiagramCollection<OrgNodeViewModel> ();
            FilterResult = new DiagramCollection<OrgNodeViewModel>();
        }

        #region Properties

        public DiagramCollection<OrgNodeViewModel> SearchResult
        {
            get;
            set;
        }

        public DiagramCollection<OrgNodeViewModel> FilterResult
        {
            get;
            set;
        } 
        #endregion       

        #region Private Functions

        //Initialize Search /Filter
        internal void UpdateSearch(DiagramCollection<OrgNodeViewModel> diagramCollection, DiagramCollection<OrgConnectorViewModel> ConnectorCollection, string filtertext, string filteroption, string filterselection)
        {
            double res;
            bool checkNumeric = double.TryParse(filtertext, out res);
            if(!filtertext.Equals(""))
            {
            if (!filteroption.Equals("Name") && !filteroption.Equals("Designation"))
            {              
                MakeNumericSearch(diagramCollection, ConnectorCollection, filtertext, filteroption, "Greater", filterselection);
            }
            else
            {               
                MakeStringFilter(diagramCollection, ConnectorCollection, filtertext, filteroption, "Contains");
            }
            }
        }

        //String Search Logic
        private void MakeStringFilter(DiagramCollection<OrgNodeViewModel> diagramCollection, DiagramCollection<OrgConnectorViewModel> ConnectorCollection, string filtertext, string option, string condition)
        {
            if (CheckSearch())
            {              
                var exactvalue = filtertext;
                string value = string.Empty;
                foreach (var item in diagramCollection)
                {
                    if ((item as OrgNodeViewModel).Visible == true)
                    {
                        if ((item as OrgNodeViewModel).Content is Employee)
                        {
                            if (option == "Name")
                            {
                                value = ((item as OrgNodeViewModel).Content as Employee).Name;
                            }
                            else if (option == "Designation")
                            {
                                value = ((item as OrgNodeViewModel).Content as Employee).Destination;
                            }

                            if (condition == "Contains")
                            {
                                   if (value.IndexOf(exactvalue, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                                    {
                                        if (value == exactvalue || option == "Name")
                                        {
                                            ((item as OrgNodeViewModel).Content as Employee).IsSearched = true;
                                            (SearchResult as DiagramCollection<OrgNodeViewModel>).Add(item as OrgNodeViewModel);
                                        }
                                    }
                                 }                           
                        }
                    }
                }
            }
        }

        private bool CheckSearch()
        {
            if (SearchResult.Count > 0)
            {
                foreach (var item in SearchResult)
                {
                    ((item as OrgNodeViewModel).Content as Employee).IsSearched = false;
                }
                SearchResult = new DiagramCollection<OrgNodeViewModel>();
            }
            return true;
        }

        //Numeric Search and Filter logic
        private void MakeNumericSearch(DiagramCollection<OrgNodeViewModel> diagramCollection, DiagramCollection<OrgConnectorViewModel> ConnectorCollection, string filtertext, string option, string condition, string selection)
        {
            if (CheckSearchandFilter(ConnectorCollection))
            {
                double comparevalue = 0;
                double res;
                bool checkNumeric = Double.TryParse(filtertext, out res);
                double filteramount = Convert.ToDouble(filtertext);

                foreach (var item in diagramCollection)
                {
                    if ((item as OrgNodeViewModel).Visible == true)
                    {
                        if((item as OrgNodeViewModel).Content is Employee)
                        {
                        if (option == "Salary")
                        {
                            comparevalue = Convert.ToDouble(((item as OrgNodeViewModel).Content as Employee).Salary);

                        }
                        if (checkNumeric)
                        {
                            switch (condition)
                            {
                                case "Greater":
                                    if (comparevalue >= filteramount)
                                    {
                                        if (selection == "Search")
                                        {
                                            if (!(SearchResult as DiagramCollection<OrgNodeViewModel>).Contains(item))
                                                ((item as OrgNodeViewModel).Content as Employee).IsSearched = true;
                                                (SearchResult as DiagramCollection<OrgNodeViewModel>).Add(item);
                                        }
       
                                    }

                                    break;                               
                            }
                        }
                        }
                    }
                }

                if (selection == "Filter")
                {
                    foreach (var item1 in ConnectorCollection)
                    {
                        (item1 as OrgConnectorViewModel).ConnectorOpacity = 0.3;
                    }
                }
            }
        }

        //Checking for results
        internal bool CheckSearchandFilter(DiagramCollection<OrgConnectorViewModel> conectorCollection)
        {
            if (SearchResult.Count > 0)
            {
                foreach (var item in SearchResult)
                {
                    ((item as OrgNodeViewModel).Content as Employee).IsSearched = false;
                }
                SearchResult = new DiagramCollection<OrgNodeViewModel>();
            }
            return true;
        }       
        #endregion
      
    }
}
