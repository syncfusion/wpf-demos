using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramDesigner
{
    public class EditingOption : INotifyPropertyChanged
    {
        private EditingType m_EditType;

        public EditingType EditType
        {
            get { return m_EditType; }
            set
            {
                if (m_EditType != value)
                {
                    m_EditType = value;
                    OnPropertyChanged("EditType");
                }
            }
        }

        protected virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public enum EditingType
    {
        Delete,
        EditProperty,
        Connect,
        Split
    }

    public enum ObjectType
    {
        Node,
        Connector
    }
}
