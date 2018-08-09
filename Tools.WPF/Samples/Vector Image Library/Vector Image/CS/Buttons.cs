using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace VectorImage
{
    /// <summary>
    /// NavigationLeftButton class
    /// </summary>
    public class NavigationLeftButton : Button
    {
        static NavigationLeftButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationLeftButton), new FrameworkPropertyMetadata(typeof(NavigationLeftButton)));
        }
    }
    /// <summary>
    /// NavigationRightButton class
    /// </summary>
    public class NavigationRightButton : Button
    {
        static NavigationRightButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationRightButton), new FrameworkPropertyMetadata(typeof(NavigationRightButton)));
        }
    }
    /// <summary>
    /// ImageNavigationRight class
    /// </summary>
    public class ImageNavigationRight : Button
    {
        static ImageNavigationRight()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageNavigationRight), new FrameworkPropertyMetadata(typeof(ImageNavigationRight)));
        }
    }
    /// <summary>
    /// ImageNavigationLeft class
    /// </summary>
    public class ImageNavigationLeft : Button
    {
        static ImageNavigationLeft()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageNavigationLeft), new FrameworkPropertyMetadata(typeof(ImageNavigationLeft)));
        }
    }
}
