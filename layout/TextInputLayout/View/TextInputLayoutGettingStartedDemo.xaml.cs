#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
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

namespace syncfusion.layoutdemos.wpf.Views.TextInputLayout
{
    /// <summary>
    /// Interaction logic for TextInputLayoutGettingStartedDemo.xaml
    /// </summary>
    public partial class TextInputLayoutGettingStartedDemo : DemoControl
    {
        public TextInputLayoutGettingStartedDemo()
        {
            InitializeComponent();
        }

        public TextInputLayoutGettingStartedDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (nameInputLayout != null)
            {
                nameInputLayout.Dispose();
                nameInputLayout = null;
            }

            if (genderInputLayout != null)
            {
                genderInputLayout.Dispose();
                genderInputLayout = null;
            }

            if (phoneNumberInputLayout != null)
            {
                phoneNumberInputLayout.Dispose();
                phoneNumberInputLayout = null;
            }

            if (altPhoneNumberInputLayout != null)
            {
                altPhoneNumberInputLayout.Dispose();
                altPhoneNumberInputLayout = null;
            }

            if (addressInputLayout != null)
            {
                addressInputLayout.Dispose();
                addressInputLayout = null;
            }

            if (countryInputLayout != null)
            {
                countryInputLayout.Dispose();
                countryInputLayout = null;
            }

            if (emailInputLayout != null)
            {
                emailInputLayout.Dispose();
                emailInputLayout = null;
            }

            if (altEmailInputLayout != null)
            {
                altEmailInputLayout.Dispose();
                altEmailInputLayout = null;
            }

            if (notesInputLayout != null)
            {
                notesInputLayout.Dispose();
                notesInputLayout = null;
            }

            base.Dispose(disposing);
        }
    }
}
