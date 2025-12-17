using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.editordemos.wpf
{
    public class ButtonModel : NotificationObject
    {
        /// <summary>
        /// Specifies the dropdown item name.
        /// </summary>
        private string name;

        /// <summary>
        /// Specifies the ImageTemplate to add inside the dropdown item. 
        /// </summary>
        private DataTemplate imageTemplate;

        /// <summary>
        /// Gets or sets the name for the dropdown item to be displayed when press the button control <see cref="ButtonModel"/> class.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Gets or sets the ImageTemplate for the dropdown item to be displayed when press the button control <see cref="ButtonModel"/> class.
        /// </summary>
        public DataTemplate ImageTemplate
        {
            get
            {
                return imageTemplate;
            }
            set
            {
                if (imageTemplate != value)
                {
                    imageTemplate = value;
                    RaisePropertyChanged("ImageTemplate");
                }
            }
        }
    }
}
