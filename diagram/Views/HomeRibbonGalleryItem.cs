using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    ///  Represents a RibbonGalleryItem control.
    /// </summary>
    /// <remarks>RibbonGalleryItem class represents a control that is used to wrap any content inside the Ribbon gallery control.</remarks>
    public class HomeRibbonGalleryItem : RibbonGalleryItem
    {
        private StyleId _mThemeStyleID;
        /// <summary>
        /// Initializes a new instance of the HomeRibbonGalleryItem class.
        /// </summary>
        public HomeRibbonGalleryItem()
        {
            this.IsEnabledChanged += HomeRibbonGalleryItem_IsEnabledChanged;
        }
        /// <summary>
        /// Occurs when the element is enabled or disables in the user interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeRibbonGalleryItem_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                if (this.DataContext != null)
                {
                    if (this.Parent != null && (this.Parent as RibbonGallery).Name == "connectorEffectStylesGallery")
                    {
                        this.ContentTemplate = (this.DataContext as ThemeStyleViewModel).View.Resources["coneffectStyleItemTemplate"] as DataTemplate;
                    }
                    else
                    {
                        this.ContentTemplate = (this.DataContext as ThemeStyleViewModel).View.Resources["effectStyleItemTemplate"] as DataTemplate;
                    }
                }
            }
            else
            {
                if (this.DataContext != null)
                {
                    this.ContentTemplate = (this.DataContext as ThemeStyleViewModel).View.Resources["disabledeffectStyleItemTemplate"] as DataTemplate;
                }
            }
        }
       
        /// <summary>
        /// Gets or sets the ThemeStyleId.
        /// </summary>
        public StyleId ThemeStyleId
        {
            get { return _mThemeStyleID; }
            set
            {
                if (_mThemeStyleID != value)
                {
                    _mThemeStyleID = value;
                }
            }
        }

    }
}
