using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace SfTreeNavigator
{
    public class TreeViewModel : NotificationObject
    {
        private List<TreeModel> models;

        public List<TreeModel> Models
        {
            get { return models; }
            set { models = value; }
        }

        public TreeViewModel()
        {
            Models = new List<TreeModel>();
        }
    }
}
