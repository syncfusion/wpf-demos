
using Syncfusion.Windows.Controls.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accordion
{
    public class AccordionProperties : INotifyPropertyChanged
    {
        private AccordionSelectionMode mode;

        public AccordionSelectionMode Mode
        {
            get { return mode; }
            set { mode = value; RaisePropertyChanged("Mode"); }
        }

        public void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
