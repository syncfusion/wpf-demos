#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.mapdemos.wpf
{
    using Syncfusion.UI.Xaml.Maps;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows;

    /// <summary>
    /// Selects a DataTemplate based on custom logic for displaying different markers on the map.
    /// </summary>
    public class MapMarkerTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapMarkerTemplateSelector" /> class.
        /// </summary>
        public MapMarkerTemplateSelector()
        {

        }

        /// <summary>
        /// Gets or sets the DataTemplate for USA markers.
        /// </summary>
        public DataTemplate USAMarkerTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate for Brazil markers.
        /// </summary>
        public DataTemplate BrazilMarkerTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate for India markers.
        /// </summary>
        public DataTemplate IndiaMarkerTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate for China markers.
        /// </summary>
        public DataTemplate ChinaMarkerTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate for Indonesia markers.
        /// </summary>
        public DataTemplate IndonesiaMarkerTemplate { get; set; }

        /// <summary>
        /// Method to selects the appropriate DataTemplate for the provided item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="container">The bindable object.</param>
        /// <returns>The data template.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is CustomDataSymbol customDataSymbol && customDataSymbol.Data != null)
            {
                var value = customDataSymbol.Data as Model;
                switch (value.Name)
                {
                    case "USA":
                        return USAMarkerTemplate;
                    case "Brazil":
                        return BrazilMarkerTemplate;
                    case "India":
                        return IndiaMarkerTemplate;
                    case "China":
                        return ChinaMarkerTemplate;
                    case "Indonesia":
                        return IndonesiaMarkerTemplate;
                }
            }

            return base.SelectTemplate(item, container);
        }
    }
}