#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace syncfusion.calculatedemos.wpf
{
    internal class SelectionBehavior : Behavior<Selector>
    {
        private GettingStartedViewModel viewModel;

        #region Overrides

        protected override void OnAttached()
        {
            base.OnAttached();
            this.viewModel = (AssociatedObject.DataContext as GettingStartedViewModel);
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }

        #endregion

        #region Properties

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(SelectionBehavior),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty IgnoreNullSelectionProperty =
            DependencyProperty.Register("IgnoreNullSelection", typeof(bool), typeof(SelectionBehavior), new PropertyMetadata(true));

        /// <summary>
        /// Determines whether null selection (which usually occurs since the combobox is rebuilt or its list is refreshed) should be ignored.
        /// True by default.
        /// </summary>
        public bool IgnoreNullSelection
        {
            get { return (bool)GetValue(IgnoreNullSelectionProperty); }
            set { SetValue(IgnoreNullSelectionProperty, value); }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Called when the SelectedItem dependency property is changed.
        /// Updates the associated selector's SelectedItem with the new value.
        /// </summary>
        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (SelectionBehavior)d;
            var selector = behavior.AssociatedObject;
            selector.SelectedValue = e.NewValue;
        }

        /// <summary>
        /// Called when the associated selector's selection is changed.
        /// Tries to assign it to the <see cref="SelectedItem"/> property.
        /// If it fails, updates the selector's with  <see cref="SelectedItem"/> property's current value.
        /// </summary>
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IgnoreNullSelection && (e.AddedItems == null || e.AddedItems.Count == 0)) return;
            SelectedItem = AssociatedObject.SelectedItem;

            if (SelectedItem != AssociatedObject.SelectedItem)
            {
                AssociatedObject.SelectedItem = SelectedItem;
            }
            if (!string.IsNullOrEmpty(viewModel.TxtA) && !string.IsNullOrEmpty(viewModel.TxtB))
            {
                switch (((BindList)SelectedItem).Formula.Trim())
                {
                    case "Sum":
                    case "Avg":
                    case "Max":
                    case "Min":
                    case "And":
                    case "Or":
                    case "Product":
                    case "Average":
                    case "Sumsq":
                    case "Avedev":
                    case "Averagea":
                    case "Gammadist":
                    case "Geomean":
                    case "Harmean":
                    case "Hypgeomdist":
                    case "Binomdist":
                    case "Normdist":
                    case "Count":
                    case "Counta":
                    case "Devsq":
                    case "Kurt":
                    case "Maxa":
                    case "Median":
                    case "Mina":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],[B],[C],[D])";
                        break;
                    case "Pi":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "()*([A]+[B]*[C]+[D])";
                        break;
                    case "VLookUp":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(2,[A],5,true)";
                        break;
                    case "HLookUp":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(2,[A],1,true)";
                        break;
                    case "Sign":
                    case "Gammaln":
                    case "Countblank":
                    case "Fisher":
                    case "Fisherinv":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A])";
                        break;
                    case "NormsInv":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A]/100)";
                        break;
                    case "Norminv":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(0.98,0,1)";
                        break;
                    case "Finv":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(0.01,[A],[B])";
                        break;
                    case "Pow":
                    case "Power":
                    case "Sumx2my2":
                    case "Sumx2py2":
                    case "Sumxmy2":
                    case "Intercept":
                    case "Chidist":
                    case "Chiinv":
                    case "Chitest":
                    case "Large":
                    case "Rsq":
                    case "Slope":
                    case "Small":
                    case "Steyx":
                    case "Trimmean":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],[D])";
                        break;
                    case "Roman":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],4)";
                        break;
                    case "If":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A]+[B]>[C]+[D],True)";
                        break;
                    case "Sumif":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],[B]>[C],[D])";
                        break;
                    case "Not":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(IF([A]+[B]>[C]+[D],True))";
                        break;
                    case "False":
                    case "True":
                        this.viewModel.TxtGen = "=(IF([A]+[B]>[C]+[D],True))" + ((BindList)SelectedItem).Formula.ToString() + "()";
                        break;
                    case "Left":
                    case "Right":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(TextLength,[A]+[B])";
                        break;
                    case "Len":
                    case "Int":
                    case "Column":
                    case "IsError":
                    case "IsNumber":
                    case "IsLogical":
                    case "IsNA":
                    case "IsErr":
                    case "IsBlank":
                    case "IsText":
                    case "IsNonText":
                    case "Exp":
                    case "Sinh":
                    case "Sqrt":
                    case "Log10":
                    case "LN":
                    case "Atanh":
                    case "Acosh":
                    case "Asin":
                    case "Asinh":
                    case "ABS":
                    case "Atan":
                    case "Cos":
                    case "Sin":
                    case "Cosh":
                    case "Tanh":
                    case "Log":
                    case "Fact":
                    case "Ln":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(Sum([A],[B],[C],[D]))";
                        break;
                    case "Db":
                    case "Ddb":
                    case "Fv":
                    case "Ipmt":
                    case "Ispmt":
                    case "Pmt":
                    case "Ppmt":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],[B],[C],[D])";
                        break;
                    case "Mirr":
                    case "Nper":
                    case "Npv":
                    case "Rate":
                    case "Sln":
                    case "Syd":
                    case "Vdb":
                    case "Date":
                    case "Time":
                    case "Gammainv":
                    case "Confidence":
                    case "CritBinom":
                    case "Expondist":
                    case "Fdist":
                    case "Forecast":
                    case "Lognormdist":
                    case "Loginv":
                    case "Negbinomdist":
                    case "Poisson":
                    case "Standardize":
                    case "Weibull":

                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],[B],[C])";
                        break;
                    case "Rand":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "()*Sum([A],[B],[C],[D])";
                        break;
                    case "Ceiling":
                    case "Floor":
                    case "Rounddown":
                    case "Round":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(Sum([A],[B],[C],[D]),0.5)";
                        break;
                    case "Day":
                    case "Datevalue":
                    case "Days360":
                    case "Hour":
                    case "Minute":
                    case "Second":
                    case "Month":
                    case "Now":
                    case "Today":
                    case "Weekday":
                    case "Year":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(" + DateTime.Now.Date.ToShortDateString() + ")";
                        break;
                    case "Index":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A])";
                        break;
                    case "OffSet":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],-1,-1)";
                        break;
                    case "Mid":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(MidPoint,1,[A])";
                        break;
                    case "Exact":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],[A])";
                        break;
                    case "Fixed":
                    case "Prob":
                    case "Rank":
                    case "Skew":
                    case "Stdev":
                    case "Stdeva":
                    case "Stdevp":
                    case "Stdevpa":
                    case "Var":
                    case "Vara":
                    case "Varp":
                    case "Varpa":
                    case "Ztest":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],3,1)";
                        break;
                    case "Lower":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(LOWERTEXT)";
                        break;
                    case "Upper":
                    case "Trim":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(uppertext)";
                        break;
                    case "Text":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(Sum([A],[B],[C],[D]),$0.00)";
                        break;
                    case "Concatenate":
                    case "Combin":
                    case "Correl":
                    case "Covar":
                    case "Pearson":
                    case "Percentile":
                    case "Percentrank":
                    case "Permut":
                    case "Atan2":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],[B])";
                        break;
                    case "Substitute":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],[A],[B])";
                        break;
                    case "Irr":
                    case "Xirr":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(Sum([A],[B],[C],[D])," + DateTime.Now + ",0.1)";
                        break;
                    case "Value":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(Avg([A],[B],[C],[D]))";
                        break;
                    case "Mod":
                    case "Mode":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(Sum([A],[B],[C],[D]))/2";
                        break;
                    case "Trunc":
                    case "Degrees":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "(Pi([A],[B],[C],[D]))";
                        break;
                    case "Countif":
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A],True)";
                        break;
                    default:
                        this.viewModel.TxtGen = "=" + ((BindList)SelectedItem).Formula.ToString() + "([A]+[B])";
                        break;
                }
            }
        }

        #endregion
    }
}
