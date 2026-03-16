#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.layoutdemos.wpf.ViewModel;
using Syncfusion.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.layoutdemos.wpf
{
    internal class TabConversionHelpers
    {
        public static TabItemModel ToModel(SfTabItem item)
        {
            var header = (item != null && item.Header != null) ? item.Header.ToString() : string.Empty;

            string contentStr = string.Empty;
            if (item != null)
            {
                var content = item.Content;
                var tb = content as TextBlock;
                if (tb != null) contentStr = tb.Text ?? string.Empty;
                else if (content is string) contentStr = (string)content;
                else contentStr = (content != null) ? content.ToString() : string.Empty;
            }

            return new TabItemModel(header, contentStr);
        }


        public static SfTabItem ToInlineTab(TabItemModel model)
        {
            var header = (model != null) ? model.Header : string.Empty;
            var content = (model != null) ? model.Content : string.Empty;
            var description = (model != null) ? model.Description : string.Empty;

            var panel = new StackPanel { Margin = new Thickness(12) };
            panel.Children.Add(new TextBlock { Text = content ?? string.Empty, FontWeight = FontWeights.Bold, FontSize = 14 });
            if (!string.IsNullOrEmpty(description))
            {
                panel.Children.Add(new TextBlock { Text = description, TextWrapping = TextWrapping.Wrap, Margin = new Thickness(0,6,0,0) });
            }
            // Add a clear moved-status note so users understand docking back may not be possible
            panel.Children.Add(new TextBlock { Text = "Status: Moved into this window. Docking back to the original window may not be possible.", FontStyle = FontStyles.Italic, Margin = new Thickness(0,6,0,0) });
            return new SfTabItem
            {
                Header = header ?? string.Empty,
                Content = panel
            };
        }
    }
}

