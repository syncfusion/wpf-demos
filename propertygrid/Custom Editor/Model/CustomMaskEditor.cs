using Syncfusion.Windows.PropertyGrid;

namespace syncfusion.propertygriddemos.wpf
{
    public class CustomMaskEditor : MaskEditor
    {
        public CustomMaskEditor()
        {
            Mask = "[A-Za-z0-9._%-]+@[A-Za-z0-9]+.[A-Za-z]{2,3}";
        }
    }
}
