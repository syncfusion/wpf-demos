#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Controls;

namespace syncfusion.spellcheckerdemo.wpf
{
    public class SpellCheckerBehavior: Behavior<SpellCheckerDemo>
    {
        private SpellCheckerViewModel viewModel;
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnAssociatedObjectLoaded;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= OnAssociatedObjectLoaded;
            base.OnDetaching();
        }

        private void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.button.Click -= Button_Click;
            AssociatedObject.button.Click += Button_Click;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel = AssociatedObject.DataContext as SpellCheckerViewModel;
            viewModel.Editor = new TextSpellEditor(AssociatedObject.txtbx);
            viewModel.SpellChecker.PerformSpellCheckUsingContextMenu(viewModel.Editor);
            viewModel.SpellChecker.PerformSpellCheckUsingDialog(viewModel.Editor);
        }
    }
}
