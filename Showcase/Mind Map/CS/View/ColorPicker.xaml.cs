using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using Syncfusion.Windows.Controls.Media;

namespace MindMap
{
    public sealed partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            this.InitializeComponent();
        }

        private void Picker_SelectedColorChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            SfColorPalette sf = (sender as SfColorPalette);
            if (this.DataContext != null)
            {
                //if (this.DataContext is FloorPlannerDemo.FloorPlanNode)
                //{
                //    (this.DataContext as FloorPlannerDemo.FloorPlanNode).SelectedColor = sf.SelectedColor.ToString();
                //}
            }
        }

        private void Picker_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
