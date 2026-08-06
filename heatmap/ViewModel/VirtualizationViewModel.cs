using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.heatmapdemos.wpf
{
    public class VirtualizationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DataModel> _productlist;
        public VirtualizationViewModel()
        {
            ProductList = new ObservableCollection<DataModel>();
            AddData();
        }

        public ObservableCollection<DataModel> ProductList
        {
            get
            {
                return _productlist;
            }
            set
            {
                if (value != _productlist)
                {
                    _productlist = value;
                    onpropertychanged("ProductList");
                }
            }
        }

        private void onpropertychanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        Random r = new Random();
        private void AddData()
        {
            for (int i = 0; i < 1000; i++)
            {
                ProductList.Add(new DataModel(i.ToString(), r.Next(0, 100), r.Next(0, 100), r.Next(0, 100), r.Next(0, 100), r.Next(0, 100)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
