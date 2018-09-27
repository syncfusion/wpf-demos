using Syncfusion.Windows.Shared;
using System;
using System.Windows.Controls;

namespace TileViewConfigurationDemo
{
    /// <summary>
    /// Interaction logic for PropertyView.xaml
    /// </summary>
    public partial class PropertyView : UserControl
    {
        public PropertyView()
        {
            InitializeComponent();
            row.MinValue = 3;
            col.MinValue = 3;
            AnimationSpan.MinValue = new TimeSpan(0, 0, 0, 0, 1);
            AnimationSpan.MaxValue = new TimeSpan(0, 0, 0, 30, 1);
        }

      
    }
}
