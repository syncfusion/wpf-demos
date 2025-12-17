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
using System.Xml.Linq;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// A trigger action that opens the source code for the demo. It can open the source code in the Visual studio or on Github.
    /// </summary>
    public class OpenSourceCodeAction : TriggerAction<Button>
    {
        /// <summary>
        /// Invokes the action when associated button is clicked.
        /// </summary>
        /// <param name="parameter">The parameter passed to the action.</param>
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
        /// Opens the source code in either Visual studio or a web browser for Github
        /// </summary>
        /// <param name="assembly">The assembly of the demo.</param>
        /// <param name="buttonName">The name of the button clicked.</param>
        private void OpenSourceCode(Assembly assembly, string buttonName)
        {
            string[] projectpath = assembly.FullName.Split(',');
            var folder = projectpath[0].Split('.')[1].Replace("demos", "");
            string project = "";
            string frameworkVersion = string.Empty;
            string root = "";

            bool isIndividualProject = false;

            string targetFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\targets"));

            if (!Directory.Exists(targetFolder)) {
                targetFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\..\\targets"));
            }

            isIndividualProject = Directory.GetFiles(targetFolder, "*.targets").Any(filePath => Path.GetFileName(filePath).Contains("_Net"));

            if (buttonName == "openvisualstudio")
            {
                frameworkVersion = new System.Runtime.Versioning.FrameworkName(AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName).Version.ToString();
                frameworkVersion = frameworkVersion.ToString().Replace(".",string.Empty);
                // below if condition used to open the individual demo project if the target file has suffix "_NET" on file name
                if (isIndividualProject)
                {
                    var versionMap = new Dictionary<string, string>
                    {
                        { "462", "_Net462" },
                        { "80", "_Net80" },
                        { "90", "_Net90"},
                        { "100", "_Net10"}
                    };

                    if (versionMap.TryGetValue(frameworkVersion, out var mappedFrameworkValue))
                    {
                        project = projectpath[0] + $"{mappedFrameworkValue}" + ".sln";
                        root = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\" + folder + "\\" + project));
                        if (!File.Exists(root))
                        {
                            // THe below code for root and target file is used to get the folder path from the Bin folder if we run the demo from sample browser in visual studio.
                            root = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\..\\" + folder + "\\" + project));
                        }
                    }
                }
                else // below else condition used to open the SDK styled demo project if the target file has no suffix "_NET" on file name on the directory
                {
                    project = projectpath[0] + ".sln";
                    string targetFilePath = Path.Combine(targetFolder, "MultiTargeting.targets");
                    root = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\" + folder + "\\" + project));
                    if (!File.Exists(root))
                    {
                        // THe below code for root and target file is used to get the folder path from the Bin folder if we run the demo from sample browser in visual studio.
                        root = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\..\\" + folder + "\\" + project));
                        targetFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\..\\targets\\MultiTargeting.targets"));
                    }

                    if (File.Exists(targetFilePath))
                    {
                        // below dictionary is used to get the framework current application exe is running.
                        var versionMap = new Dictionary<string, string>
                        {
                        { "462", "net462" },
                        { "80", "net8.0-windows" },
                        { "90", "net9.0-windows"},
                        { "100", "net10.0-windows"}
                        };

                        if (versionMap.TryGetValue(frameworkVersion, out var mappedFrameworkValue))
                        {
                            AddActiveDebugFramework(mappedFrameworkValue, targetFilePath);
                        }
                    }
                }
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

        /// <summary>
        /// Adds or updates an ActiveDebugFramework tag in a .targets file.
        /// </summary>
        /// <param name="framework">The framework version string.</param>
        /// <param name="targetFilePath">The path to the .targets file.</param>
        public static void AddActiveDebugFramework(string framework, string targetFilePath) {
            string TagName = "ActiveDebugFramework";

            try
            {
                if (File.Exists(targetFilePath))
                {
                    XDocument document = XDocument.Load(targetFilePath);
                    var propertyGroups = document.Descendants("PropertyGroup");
                    XElement elementPresent = null;

                    foreach (var propertyGroup in propertyGroups) { 
                        elementPresent = propertyGroup.Element(TagName);
                        if (elementPresent != null)
                            break;
                    }

                    if (elementPresent != null)
                    {
                        if (elementPresent.Value != framework)
                        {
                            elementPresent.Value = framework;
                            document.Save(targetFilePath);
                        }
                        else
                        {
                            Console.WriteLine($"No PropertyGroup found in {targetFilePath}");
                        }
                    }
                    else
                    {
                        XElement propetyGroup = propertyGroups.First();
                        XElement element = new XElement(TagName, framework);
                        propetyGroup.Add(element);
                        document.Save(targetFilePath);
                    }
                }
            }
            catch (Exception exception) {
                Console.WriteLine($"Error processing Target File: {exception.Message} ");
            }
        }
    }

    /// <summary>
    /// A trigger action that sets the visibility of a button when loaded.
    /// </summary>
    public class OpenSourceLoadedAction : TriggerAction<Button>
    {
        /// <summary>
        /// Invokes the action, Typically on the 'Loaded' event of the button
        /// </summary>
        /// <param name="parameter">The paramter of the action.</param>
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
        /// <summary>
        /// Invokes the action when navigation event is triggered. It opens the hyperlink's URI in the default sample browser.
        /// </summary>
        /// <param name="parameter">The paramter of the action.</param>
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
