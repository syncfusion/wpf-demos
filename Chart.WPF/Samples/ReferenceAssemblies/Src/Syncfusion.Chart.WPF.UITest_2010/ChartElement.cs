#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using System.Runtime.InteropServices;

namespace Syncfusion.Chart.WPF.UITest
{
    public class ChartElement : WpfControl
    {
         public ChartElement()
            :this(null)
        {

        }
        public ChartElement(UITestControl container)
            :base(container)
        {
           
            SearchProperties.Add(UITestControl.PropertyNames.ControlType, ControlType.Custom.Name);            

        }
        
        public virtual string Background
        {
            
            get
            {
                return ((string)(this.GetProperty(ChartElement.PropertyNames.Background)));
            }
        }
        
        public virtual string Foreground
        {

            get
            {
                return ((string)(this.GetProperty(ChartElement.PropertyNames.Foreground)));
            }
        }

        public virtual string ChartVisualStyle
        {
            get
            {                
                return ((string)(this.GetProperty(ChartElement.PropertyNames.ChartVisualStyle)));
            }
        }

        public virtual string Orientation
        {

            get
            {

                return ((string)(this.GetProperty(ChartElement.PropertyNames.Orientation)));
            }

        }

        public virtual string OpposedPosition
        {

            get
            {

                return ((string)(this.GetProperty(ChartElement.PropertyNames.OpposedPosition)));
            }

        }
        public virtual string RowsCount
        {

            get
            {

                return ((string)(this.GetProperty(ChartElement.PropertyNames.RowsCount)));
            }

        }
        public virtual string ColumnsCount
        {

            get
            {

                return ((string)(this.GetProperty(ChartElement.PropertyNames.ColumnsCount)));
            }

        }
        public virtual string Dock
        {

            get
            {

                return ((this.GetProperty(ChartElement.PropertyNames.Dock)).ToString());
            }

        }
        public virtual string LegendPanel
        {

            get
            {

                return ((string)(this.GetProperty(ChartElement.PropertyNames.LegendPanel)));
            }

        }
        public virtual string IsContextMenuEnabled
        {

            get
            {

                return ((this.GetProperty(ChartElement.PropertyNames.IsContextMenuEnabled)).ToString());
            }

        }
        public virtual string ValueType
        {

            get
            {

                return ((this.GetProperty(ChartElement.PropertyNames.ValueType)).ToString());
            }

        }
        public virtual string Type
        {

            get
            {
                return ((this.GetProperty(ChartElement.PropertyNames.Type)).ToString());
            }
        }
        public virtual string IsIndexed
        {

            get
            {
                return ((this.GetProperty(ChartElement.PropertyNames.IsIndexed)).ToString());
            }
        }
        public virtual string Interior
        {

            get
            {                
                return ((this.GetProperty(ChartElement.PropertyNames.Interior)).ToString());
            }
        }

        new public abstract class PropertyNames : WpfControl.PropertyNames
        {
            public static readonly string Background = "Background";
            public static readonly string Foreground = "Foreground";
            public static readonly string Orientation = "Orientation";
            public static readonly string ChartVisualStyle = "ChartVisualStyle";
            public static readonly string Dock = "Dock";
            public static readonly string RowsCount = "RowsCount";
            public static readonly string ColumnsCount = "ColumnsCount";
            public static readonly string LegendPanel = "LegendPanel";
            public static readonly string IsContextMenuEnabled = "IsContextMenuEnabled";
            public static readonly string OpposedPosition = "OpposedPosition";
            public static readonly string ValueType = "ValueType";
            public static readonly string Type = "Type";
            public static readonly string IsIndexed = "IsIndexed";
            public static readonly string Interior = "Interior";
        }


        
    }
    }

