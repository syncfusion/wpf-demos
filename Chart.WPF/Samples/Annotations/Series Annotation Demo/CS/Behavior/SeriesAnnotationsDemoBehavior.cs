#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;

namespace AnnotationsSample
{
    class SeriesAnnotationsDemoBehavior:Behavior<Window1>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.xvalue.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(xvalue_ValueChanged);
            this.AssociatedObject.yvalue.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(yvalue_ValueChanged);
            this.AssociatedObject.cmbDescription.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(cmbDescription_SelectionChanged);
            this.AssociatedObject.cmbDescription.SelectedIndex = 2;
        }

        void cmbDescription_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SetDescription();
        }

        void yvalue_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            SetDescription();
        }

        void xvalue_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            SetDescription();
        }

        #region Helper Methods
        /// <summary>
        /// Sets the description.
        /// </summary>
        public void SetDescription()
        {
            double ab = this.AssociatedObject.Chart1.Areas[0].PrimaryAxis.DateTimeRange.Start.ToOADate();
            if (this.AssociatedObject.cmbDescription != null)
            {
                switch (this.AssociatedObject.cmbDescription.SelectedIndex)
                {
                    case 0:
                        this.AssociatedObject.serAnnot1.Description = String.Format("{0:MM/dd/yyyy}", DateTime.FromOADate(this.AssociatedObject.serAnnot1.X)); 
                        break;

                    case 1:
                        this.AssociatedObject.serAnnot1.Description = Math.Truncate(this.AssociatedObject.serAnnot1.Y).ToString();
                        break;

                    case 2:
                        this.AssociatedObject.serAnnot1.Description = String.Format("{0:MM/dd/yyyy}", DateTime.FromOADate(this.AssociatedObject.serAnnot1.X)) + ", " + Math.Round(this.AssociatedObject.serAnnot1.Y).ToString();
                        break;
                }
            }

        }


        #endregion
    }
}
