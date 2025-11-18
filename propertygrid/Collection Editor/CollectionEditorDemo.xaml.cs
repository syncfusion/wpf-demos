#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace syncfusion.propertygriddemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CollectionEditorDemo : DemoControl
    {
        public CollectionEditorDemo()
        {
            InitializeComponent();
        }
        public CollectionEditorDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.propertygrid != null)
            {
                this.propertygrid.Dispose();
                this.propertygrid = null;
            }

            if (this.tabControlExt != null)
            {
                this.tabControlExt.Dispose();
                this.tabControlExt = null;
            }

            base.Dispose(disposing);
        }

        private void propertygrid_CollectionEditorOpening(object sender, Syncfusion.Windows.PropertyGrid.CollectionEditorOpeningEventArgs e)
        {
            string propertyItemName = propertygrid.SelectedPropertyItem.Name;
            if((bool)customIcon.IsChecked)
            {
                if (propertyItemName == "Customers" || propertyItemName == "DeliveryAgents" || propertyItemName == "Employees")
                {
                    e.CollectionEditor.Icon = new BitmapImage(new Uri("pack://application:,,,/syncfusion.propertygriddemos.wpf;component/Assets/Images/WPF_images.png"));
                }
            } 
            if((bool)customTitle.IsChecked)
            {
                e.CollectionEditor.Title = (propertyItemName == "Customers") ? "Customer Details" : (propertyItemName == "DeliveryAgents") ? "Delivery Agents" : "Employees";
            }
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new FakeWindowsPeer(this);
        }
    }

    public class FakeWindowsPeer : UserControlAutomationPeer
    {
        public FakeWindowsPeer(UserControl window)
            : base(window)
        { }
        protected override List<AutomationPeer> GetChildrenCore()
        {
            return null;
        }
    }
}
