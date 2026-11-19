using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.brainstormingdiagram.wpf.ViewModel
{
    public class Child : RootChild
    {
        #region Private Fields
        private RootChild parent;
        #endregion
        public Child()
        {

        }
        public Child(RootChild parent): base(parent.Direction)
        {
            Parent = parent;
        }

        #region Public properties
        
        public RootChild Parent
        {
            get { return parent; }
            set
            {
                if (parent != value)
                {
                    parent = value;
                    OnPropertyChanged("Parent");
                }
            }
        }
        #endregion
    }
}
