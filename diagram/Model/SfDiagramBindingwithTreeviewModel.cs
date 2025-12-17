using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagramdemo.wpf.Model
{
    public class Items : NotificationObject
    {
        #region fields

        private int _id;

        private int _parentid;

        private string _name;


        private ObservableCollection<Items> _subitems;

        #endregion

        #region Properties

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        public int ParentID
        {
            get
            {
                return _parentid;
            }
            set
            {
                if (_parentid != value)
                {
                    _parentid = value;
                    OnPropertyChanged("ParentID");
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public ObservableCollection<Items> SubItems
        {
            get
            {
                return _subitems;
            }
            set
            {
                if (_subitems != value)
                {
                    _subitems = value;
                    OnPropertyChanged("SubItems");
                }
            }
        }
        #endregion

        public new event PropertyChangedEventHandler PropertyChanged;

        public Items()
        {

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
