#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;


namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for SerializationDemo.xaml
    /// </summary>
    public partial class SerializationDemo : DemoControl
    {
        public static SerializationDemo demoControl;
        public SerializationDemo()
        {
            InitializeComponent();
            demoControl = this;
        }

        public SerializationDemo(string themename) : base(themename)
        {
            InitializeComponent();            
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.dataGrid != null)
            {
                this.dataGrid.Dispose();
                this.dataGrid = null;
            } 

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.textBlock1 != null)
                this.textBlock1 = null;

            if (this.textBlock2 != null)
                this.textBlock2 = null;

            if (this.SerializeColumns != null)
                this.SerializeColumns = null;

            if (this.SerializeGrouping != null)
                this.SerializeGrouping = null;

            if (this.SerializeSorting != null)
                this.SerializeSorting = null;

            if (this.SerializeFiltering != null)
                this.SerializeFiltering = null;

            if (this.SerializeGroupSummaries != null)
                this.SerializeGroupSummaries = null;

            if (this.SerializeTableSummaries != null)
                this.SerializeTableSummaries = null;

            if (this.SerializeStackedHeaders != null)
                this.SerializeStackedHeaders = null;

            if (this.button1 != null)
                this.SerializeSorting = null;

            if (this.DeserializeColumns != null)
                this.DeserializeColumns = null;

            if (this.DeserializeGrouping != null)
                this.DeserializeGrouping = null;

            if (this.DeserializeSorting != null)
                this.DeserializeSorting = null;

            if (this.DeserializeFiltering != null)
                this.DeserializeFiltering = null;

            if (this.DeserializeGroupSummaries != null)
                this.DeserializeGroupSummaries = null;


            if (this.DeserializeTableSummaries != null)
                this.DeserializeTableSummaries = null;

            if (this.button3 != null)
                this.button3 = null;

            if (this.button2 != null)
                this.button2 = null;

            if (this.textBlock3 != null)
                this.textBlock3 = null;

            if (this.button4 != null)
                this.button4 = null;

            if (this.button5 != null)
                this.button5 = null;

            demoControl = null;
            base.Dispose(disposing);
        }
    }
}
