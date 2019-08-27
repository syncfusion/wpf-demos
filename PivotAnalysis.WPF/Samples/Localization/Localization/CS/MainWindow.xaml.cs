#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Localization
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Windows;
    using System.Threading;

    public partial class MainWindow : Window
    {
        public MainWindow()

        {
            //  Set the current thread culture to load the localization resource file added .    
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");

            InitializeComponent();
            if (CultureInfo.CurrentUICulture.ToString() == "ar-AE")
            {
                this.FlowDirection = FlowDirection.RightToLeft;
            }
            if (CultureInfo.CurrentUICulture.ToString() == "en-US")
                return;
            Assembly controlAssembly = Application.ResourceAssembly;
            if (Application.Current != null || Application.ResourceAssembly != null)
            {
                Assembly assembly = null;
                if (Application.Current != null)
                {
                    assembly = Application.Current.GetType().Assembly;
                    try
                    {
                        assembly = Application.Current.GetType().Assembly.GetSatelliteAssembly(CultureInfo.CurrentUICulture);
                    }
                    catch
                    {
                        assembly = Application.Current != null ? Application.Current.GetType().Assembly : Application.ResourceAssembly;
                    }
                }
                ResourceManager manager = null;
                bool found = false;
                string resourceNameModified = "";
                //Making sure here whether the user modified the en-US culture and embedded the resource. This should be very rare case though. If the resource is not available only in the app level only, it will extract the resource from control assembly.
                if (assembly != null)
                {
                    foreach (var resourceName in assembly.GetManifestResourceNames())
                    {
                        if (resourceName.Contains(controlAssembly.FullName.Split(',')[0]) && !resourceName.Contains((string.Format("{0}.Resources", assembly.FullName.Split(',')[0]))))
                        {
                            resourceNameModified = resourceName;
                            found = true;
                        }
                        else if (resourceName.Equals(string.Format("{0}.Resources.{1}.resources", assembly.FullName.Split(',')[0],
                            controlAssembly.FullName.Split(',')[0])))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found || !CultureInfo.CurrentUICulture.Name.Equals("en-US"))
                    {
                        if (found && resourceNameModified != "")
                        {
                            manager = new ResourceManager(resourceNameModified.Replace(".resources", ""), assembly);
                        }
                        else
                            manager = new ResourceManager(string.Format("{0}.Resources.{1}", assembly.FullName.Split(',')[0],
                                controlAssembly.FullName.Split(',')[0]), assembly);
                    }
                    else
                    {
                        manager = new ResourceManager(string.Format("Syncfusion.Windows.Controls.PivotGrid.Resources.{0}",
                            controlAssembly.FullName.Split(',')[0]), controlAssembly);
                    }
                }
                var currentUICulture = CultureInfo.CurrentUICulture;
                if (manager != null && manager.GetResourceSet(currentUICulture, true, true) != null)
                {
                    List<KeyValuePair<string, string>> resourceKeys = new List<KeyValuePair<string, string>>();
                    ResourceSet set = manager.GetResourceSet(currentUICulture, true, true);
                    foreach (DictionaryEntry o in set)
                    {
                        resourceKeys.Add(new KeyValuePair<string, string>((string)o.Key, (string)o.Value));
                    }
                    for (int key = 0; key < resourceKeys.Count; key++)
                    {
                        for (int row = 0; row < this.pivotGrid1.PivotRows.Count; row++)
                        {
                            if (resourceKeys[key].Key == this.pivotGrid1.PivotRows[row].FieldCaption)
                            {
                                this.pivotGrid1.PivotRows[row].FieldCaption = resourceKeys[key].Value;
                            }
                        }
                        for (int column = 0; column < this.pivotGrid1.PivotColumns.Count; column++)
                        {
                            if (resourceKeys[key].Key == this.pivotGrid1.PivotColumns[column].FieldCaption)
                            {
                                this.pivotGrid1.PivotColumns[column].FieldCaption = resourceKeys[key].Value;
                            }
                        }
                        for (int values = 0; values < this.pivotGrid1.PivotCalculations.Count; values++)
                        {
                            if (resourceKeys[key].Key == this.pivotGrid1.PivotCalculations[values].FieldCaption)
                            {
                                this.pivotGrid1.PivotCalculations[values].FieldCaption = resourceKeys[key].Value;
                            }
                        }
                        for (int values = 0; values < this.pivotGrid1.PivotFields.Count; values++)
                        {
                            if (resourceKeys[key].Key == this.pivotGrid1.PivotFields[values].FieldCaption)
                            {
                                this.pivotGrid1.PivotFields[values].FieldCaption = resourceKeys[key].Value;
                            }
                        }
                    }
                }
            }
        }
    }
}