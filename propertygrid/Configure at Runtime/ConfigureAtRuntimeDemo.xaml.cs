#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.PropertyGrid;

namespace syncfusion.propertygriddemos.wpf
{
    /// <summary>
    /// Interaction logic for GettingStarted.xaml
    /// </summary>
    public partial class ConfigureAtRuntimeDemo : DemoControl
    {
        public ConfigureAtRuntimeDemo()
        {
            InitializeComponent();
        }
        public ConfigureAtRuntimeDemo(string themename) : base(themename)
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

            base.Dispose(disposing);
        }

        private void Propertygrid_AutoGeneratingPropertyGridItem(object sender, Syncfusion.Windows.PropertyGrid.AutoGeneratingPropertyGridItemEventArgs e)
        {
            if(e.DisplayName== "FirstName")
            {
                e.DisplayName= "First Name";
                e.Description= "First Name of the actual person.";
                e.Order = 1;
                e.Category = "Identity";
            }
            else if (e.DisplayName == "LastName")
            {
                e.DisplayName = "Last Name";
                e.Description = "Last Name of the actual person.";
                e.Order = 2;
                e.Category = "Identity";

            }
            else if (e.DisplayName == "MaritalStatus")
            {
                e.Order = 6;
                e.Cancel = true;
            }
            else if (e.DisplayName == "Bank")
            {
                e.ExpandMode = PropertyExpandModes.NestedMode;
                e.Description = "Bank in which the person has account.";
                e.Order = 9;
                e.Category = "Additional Info";

            }
            else if (e.DisplayName == "Email")
            {
                e.DisplayName = "Email ID";
                e.Description = "Email address of the actual person.";
                e.Order = 11;
                e.Category = "Additional Info";
            }
            else if (e.DisplayName == "Age")
            {
                e.Description = "Age of the actual person.";
                e.Order = 5;
                e.Category = "Identity";
            }
            else if (e.DisplayName == "DOB")
            {
                e.DisplayName = "Date of Birth";
                e.Description = "Birth date of the actual person.";
                e.Order = 3;
                e.ExpandMode = PropertyExpandModes.FlatMode;
                e.Category = "Identity";
            }
            else if (e.DisplayName == "Gender")
            {
                e.Description = "Gender information of the actual person.";
                e.Order = 4;
                e.Category = "Identity";

            }
            else if (e.DisplayName == "FavoriteColor")
            {
                e.DisplayName = "Favorite Color";
                e.Description = "Favorite color of the actual person.";
                e.Order = 7;
                e.Category = "Additional Info";
            }
            else if (e.DisplayName == "IsPermanent")
            {
                e.DisplayName = "Permanent Employee";
                e.Description = "Determines whether the person is permanent or not.";
                e.Order = 8;
                e.Category = "Additional Info";
            }
            else if (e.DisplayName == "Key")
            {
                e.Cancel = true;

            }
            else if (e.DisplayName == "ID")
            {
                e.Description = "ID of the actual person.";               
                e.Order = 0;
                e.Category = "Identity";
            }
            
            else if (e.DisplayName == "Country")
            {
                e.Description = "Country where the actual person is located.";
                e.Order = 11;
                e.Category = "Additional Info";
            }
            else if (e.DisplayName == "Mobile")
            {
                e.DisplayName = "Mobile Number";
                e.Description = "Contact Number of the actual person.";
                e.Order = 13;
                e.Category = "Additional Info";
            }
        }
    }
}
