#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using System.Windows.Documents;
using System.Windows.Navigation;

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

        /// <summary>
        /// Used to open the Olap samples in VS
        /// </summary>
        /// <param name="selectedProduct">Slected product demo</param>
        public static void OpenVS(string selectedProduct)
        {
            string root = "";
            if (selectedProduct.ToLower().Contains("chart"))
            {
                root = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\" + "olapchart" + "\\" + "syncfusion.olapchartdemos.wpf_47.sln"));
            }
            else if (selectedProduct.ToLower().Contains("client"))
            {
                root = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\" + "olapclient" + "\\" + "syncfusion.olapclientdemos.wpf_47.sln"));
            }
            else if (selectedProduct.ToLower().Contains("gauge"))
            {
                root = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\" + "olapgauge" + "\\" + "syncfusion.olapgaugedemos.wpf_47.sln"));
            }
            else if (selectedProduct.ToLower().Contains("grid"))
            {
                root = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\" + "olapgrid" + "\\" + "syncfusion.olapgriddemos.wpf_47.sln"));
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
            catch (Exception ex)
            {
                Console.WriteLine($"Request Sampe returns error: {ex}");
            }
        }


        private void OpenSourceCode(Assembly assembly, string buttonName)
        {
            string[] projectpath = assembly.FullName.Split(',');
            var folder = projectpath[0].Split('.')[1].Replace("demos", "");
            string project = "";
            string root = "";
            if (buttonName == "openvisualstudio")
            {
                project = projectpath[0] + ".sln";
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
            catch (Exception exception)
            {
                if (Application.Current.Windows[0].DataContext != null)
                {
                    var viewModel = Application.Current.Windows[0].DataContext as DemoBrowserViewModel;
                    if (viewModel.SelectedProduct != null && viewModel.SelectedSample != null)
                    {
                        ErrorLogging.LogError("Product Sample\\" + viewModel.SelectedProduct.Product + "\\" + viewModel.SelectedSample.SampleName + "@@" + "Requested directory not found." + exception.Message + "\n" + exception.StackTrace + "\n" + exception.Source);
                    }
                    else if (viewModel.SelectedShowcaseSample != null)
                    {
                        ErrorLogging.LogError("Product ShowCase\\" + viewModel.SelectedShowcaseSample.SampleName + "\\" + viewModel.SelectedShowcaseSample.SampleName + "@@" + "Requested directory not found." + exception.Message + "\n" + exception.StackTrace + "\n" + exception.Source);
                    }
                }
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
                if (DemoBrowserViewModel.isMainSB)
                {
                    AssociatedObject.Visibility = Visibility.Visible;
                }
            }
        }
    }

    /// <summary>
    /// This behavior is a trigger action that opens a URL in the default browser when a hyperlink is clicked, using the Process.Start method.
    /// </summary>
    public class UrlNavigation : TriggerAction<Hyperlink>
    {
        protected override void Invoke(object parameter)
        {
            if (this.AssociatedObject == null)
                return;
            if (parameter is RequestNavigateEventArgs requestNavigateEventArgs)
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo(requestNavigateEventArgs.Uri.ToString()) { UseShellExecute = true });
                requestNavigateEventArgs.Handled = true;
            }
        }
    }
}
