#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using System.Windows.Input;

namespace syncfusion.workfloweditor.wpf
{
    public class DiagramCommonViewModel : INotifyPropertyChanged
    {
        private int m_SelectedItemsCount;

        public int SelectedItemsCount
        {
            get { return m_SelectedItemsCount; }
            set
            {
                if (m_SelectedItemsCount != value)
                {
                    m_SelectedItemsCount = value;
                    OnPropertyChanged("SelectedItemsCount");
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

        private ICommand m_itemClick;
        public ICommand ItemClick
        {
            get { return m_itemClick; }
            set
            {
                if (m_itemClick != value)
                {
                    m_itemClick = value;
                    OnPropertyChanged("ItemClick");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
