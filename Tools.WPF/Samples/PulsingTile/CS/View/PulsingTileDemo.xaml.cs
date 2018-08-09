using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Input;

namespace SfPulsingTile
{
    /// <summary>
    /// Interaction logic for PulsingTileDemo.xaml
    /// </summary>
    public partial class PulsingTileDemo : UserControl
    {
        public PulsingTileDemo()
        {
            InitializeComponent();
        }
        private void pulseduration_Changed(object sender, ValueChangedEventArgs e)
        {
            if (hubtile != null)
            {
                hubtile.PulseDuration = TimeSpan.FromSeconds(Double.Parse(pulseduration.Value.ToString()));
            }
        }

        private void radiusx_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (hubtile != null)
            {
                hubtile.RadiusX = Double.Parse(radiusx.Value.ToString());
            }
        }

        private void radiusy_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (hubtile != null)
            {

                hubtile.RadiusY = Double.Parse(radiusy.Value.ToString());
            }
        }

        private void pulsescale_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (hubtile != null)
            {

                hubtile.PulseScale = Double.Parse(pulsescale.Value.ToString());
            }
        }

        private void pulsescale_Loaded_1(object sender, RoutedEventArgs e)
        {
            (sender as SfDomainUpDown).Value = 2;
        }
    }
    
}
