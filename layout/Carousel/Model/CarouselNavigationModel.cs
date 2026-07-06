using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace syncfusion.layoutdemos.wpf
{
    public class CarouselNavigationModel
    {
        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
            }
        }

    }
}
