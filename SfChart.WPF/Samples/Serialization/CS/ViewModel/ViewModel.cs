using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class CategoryDataViewModel
    {
        public CategoryDataViewModel()
        {
            CategoricalDatas = new ObservableCollection<CategoryData>();
            CategoricalDatas.Add(new CategoryData("Gear", 5));
            CategoricalDatas.Add(new CategoryData("Motor", 10));
            CategoricalDatas.Add(new CategoryData("Bearing", 15));
            CategoricalDatas.Add(new CategoryData("Switch", 20));
            CategoricalDatas.Add(new CategoryData("Plug", 20));
            CategoricalDatas.Add(new CategoryData("Cord", 35));
            CategoricalDatas.Add(new CategoryData("Fuse", 40));
            CategoricalDatas.Add(new CategoryData("Pump", 20));
            CategoricalDatas.Add(new CategoryData("Leak", 15));
            CategoricalDatas.Add(new CategoryData("Seals", 40));
        }

        public ObservableCollection<CategoryData> CategoricalDatas
        {
            get;
            set;
        }
    }

}
