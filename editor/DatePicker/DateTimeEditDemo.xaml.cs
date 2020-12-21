#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class DateTimeEditDemo : DemoControl
    {
        public DateTimeEditDemo()
        {
            InitializeComponent();
        }

        public DateTimeEditDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            foreach (var behavior in Interaction.GetBehaviors(this))
            {
                behavior.Detach();
            }

            if (minDateTime != null)
            {
                minDateTime.Dispose();
                minDateTime = null;
            }

            if (maxDateTime != null)
            {
                maxDateTime.Dispose();
                maxDateTime = null;
            }

            if (canEditDT != null)
            {
                canEditDT.Dispose();
                canEditDT = null;
            }

            if (repeatButtonDT != null)
            {
                repeatButtonDT.Dispose();
                repeatButtonDT = null;
            }

            if (validationDT != null)
            {
                validationDT.Dispose();
                validationDT = null;
            }

            if (scrollingOnCircleDT != null)
            {
                scrollingOnCircleDT.Dispose();
                scrollingOnCircleDT = null;
            }

            if (patternDT != null)
            {
                patternDT.Dispose();
                patternDT = null;
            }

            if (readOnlyDT != null)
            {
                readOnlyDT.Dispose();
                readOnlyDT = null;
            }

            if (disableDateSelectionDT != null)
            {
                disableDateSelectionDT.Dispose();
                disableDateSelectionDT = null;
            }

            if (blackOutDates != null)
            {
                blackOutDates.Dispose();
                blackOutDates = null;
            }

            if (allowNullDT != null)
            {
                allowNullDT.Dispose();
                allowNullDT = null;
            }

            if (cultureDT != null)
            {
                cultureDT.Dispose();
                cultureDT = null;
            }

            base.Dispose(disposing);
        }
    }
}
