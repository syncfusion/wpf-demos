using System.Collections.Generic;

namespace SearchPanel
{
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrderInfoRepository order = new OrderInfoRepository();
            OrdersDetails = order.GetOrdersDetails(100);
            SearchComboBoxItems = this.GetSearchComboBoxItems();
        }

        private List<string> GetSearchComboBoxItems()
        {
            List<string> comboItem = new List<string>();
            comboItem.Add("Search main Grid");
            comboItem.Add("Search first level Grid's");
            comboItem.Add("Search second level Grid's");
            return comboItem;
        }

        private List<string> _searchComboBoxItems;
        public List<string> SearchComboBoxItems
        {
            get { return _searchComboBoxItems; }
            set { _searchComboBoxItems = value; }
        }

        public List<OrderInfo> _ordersDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public List<OrderInfo> OrdersDetails
        {
            get { return _ordersDetails; }
            set { _ordersDetails = value; }
        }

        public List<Employees> _empyoeeDetails;

        public List<Employees>EmployeeDetails
        {
            get { return _empyoeeDetails; }
            set { _empyoeeDetails = value; }
        }
    }
}
