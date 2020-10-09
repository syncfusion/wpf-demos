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
    public class OpenSourceCodeAction : TargetedTriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
                Button button = eventArgs.OriginalSource as Button;
                if (button.DataContext != null && button.DataContext is DemoBrowserViewModel)
                {
                    DemoBrowserViewModel viewmodel = button.DataContext as DemoBrowserViewModel;
                    if (viewmodel != null && viewmodel.SelectedSample != null && viewmodel.SelectedSample.DemoViewType != null)
                    {
                        var assembly = viewmodel.SelectedSample.DemoViewType.Assembly;
                        OpenSourceCode(assembly);
                    }
                }
                else
                {
                    if (button.TemplatedParent != null)
                    {
                        OpenSourceCode(button.TemplatedParent.GetType().Assembly);
                    }

                }
            }
        }
        private void OpenSourceCode(Assembly assembly)
        {
            string[] projectpath = assembly.FullName.Split(',');
            var folder = projectpath[0].Split('.')[1].Replace("demos","");
            if(folder == "chart")
            {
                folder = folder +"s";
            }
            string frameworkVersion = new System.Runtime.Versioning.FrameworkName(AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName).Version.ToString();
            frameworkVersion = frameworkVersion.ToString().Replace(".", string.Empty);
            string project = projectpath[0] + "_"+ frameworkVersion + ".sln";
            string root = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\" + folder + "\\" + project));
            if (!File.Exists(root))
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

    public class OpenSourceLoadedAction : TargetedTriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                string frameworkVersion = new System.Runtime.Versioning.FrameworkName(AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName).Version.ToString();
                frameworkVersion = frameworkVersion.ToString().Replace(".", string.Empty);
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
                Button button = eventArgs.OriginalSource as Button;
                if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"+frameworkVersion))
                {
                    button.Visibility = Visibility.Visible;
                }
            }
        }
       
    }
}
