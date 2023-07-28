#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string culture = "en-US";
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);

            //Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                        CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = Activator.CreateInstance(typeof(ExpenseAnalysisDemo)) as Window;
            window.Show();
            base.OnStartup(e);
        }
    } 
}
