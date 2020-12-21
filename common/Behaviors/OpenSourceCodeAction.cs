#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.demoscommon.wpf
{
    public class OpenSourceCodeAction : TriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            if (this.AssociatedObject == null)
                return;

            var viewmodel = this.AssociatedObject.DataContext as DemoBrowserViewModel;
            if (AssociatedObject.DataContext is DemoBrowserViewModel)
            {
                if (viewmodel != null && viewmodel.SelectedSample != null && viewmodel.SelectedSample.DemoViewType != null)
                {
                    var assembly = viewmodel.SelectedSample.DemoViewType.Assembly;
                    OpenSourceCode(assembly, AssociatedObject.Name);
                }
            }
            else
            {
                if (AssociatedObject.TemplatedParent != null)
                {
                    OpenSourceCode(AssociatedObject.TemplatedParent.GetType().Assembly, AssociatedObject.Name);
                }

            }
        }
        private void OpenSourceCode(Assembly assembly, string buttonName)
        {
            string[] projectpath = assembly.FullName.Split(',');
            var folder = projectpath[0].Split('.')[1].Replace("demos", "");
            string frameworkVersion = "";
            string project = "";
            string root = "";
            if (buttonName == "openvisualstudio")
            {
                frameworkVersion = new System.Runtime.Versioning.FrameworkName(AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName).Version.ToString();
                frameworkVersion = frameworkVersion.ToString().Replace(".", string.Empty);
                project = projectpath[0] + "_" + frameworkVersion + ".sln";
                root = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\" + folder + "\\" + project));
            }
            else if (buttonName == "opengithub")
            {
                root = "https://github.com/syncfusion/wpf-demos/tree/master/" + folder;
            }

            if (!File.Exists(root) && buttonName == "openvisualstudio")
            {
                return;
            }
            try
            {
                var process = new ProcessStartInfo
                {
                    FileName = root,
                    UseShellExecute = true
                };
                Process.Start(process);
            }
            catch (Exception e)
            {
                ErrorLogging.LogError("Requested directory not found." + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }
    }

    public class OpenSourceLoadedAction : TriggerAction<Button>
    {
        

        protected override void Invoke(object parameter)
        {
            if (this.AssociatedObject == null)
                return;
            if (DemoBrowserViewModel.IsStoreApp && AssociatedObject.Name == "opengithub")
            {
                AssociatedObject.Visibility = Visibility.Visible;
            }
            else if (!DemoBrowserViewModel.IsStoreApp && AssociatedObject.Name == "openvisualstudio")
            {
                string frameworkVersion = new System.Runtime.Versioning.FrameworkName(AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName).Version.ToString();
                frameworkVersion = frameworkVersion.ToString().Replace(".", string.Empty);
                if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_" + frameworkVersion))
                {
                    AssociatedObject.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
