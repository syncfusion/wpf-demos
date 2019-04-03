#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
