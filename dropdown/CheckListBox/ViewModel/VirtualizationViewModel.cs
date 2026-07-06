using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.dropdowndemos.wpf
{
    class VirtualizationViewModel : IDisposable
    {
        private ObservableCollection<Model> collection = new ObservableCollection<Model>();

        public ObservableCollection<Model> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
            }
        }
        public VirtualizationViewModel()
        {
            Collection = new ObservableCollection<Model>();
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Model myitem = new Model() { Name = "Module " + i.ToString(), GroupName = "Group" + j.ToString() };
                    Collection.Add(myitem);
                }
            }
        }

        public void Dispose()
        {
            if (this.Collection != null)
            {
                this.Collection.Clear();
            }
        }
    }
}
