using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.brainstormingdiagram.wpf.View
{
    public class Selector : Syncfusion.UI.Xaml.Diagram.Selector
    {
        static Selector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Selector), new FrameworkPropertyMetadata(typeof(Selector)));
        }
        public Selector()
        { }
    }
}
