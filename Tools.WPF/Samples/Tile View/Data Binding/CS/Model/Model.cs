using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataBindingDemo
{
    public class ApplicationTile
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public string Header { get; set; }

        public string SlideImage { get; set; }

        public bool CanSlide { get; set; }

        public FrameworkElement View { get; set; }
    }
}
