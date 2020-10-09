// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for App.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Windows;

    using Syncfusion.Licensing;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense(FindLicenseKey());
        }

        /// <summary>
        ///     Helper method to find a syncfusion license key from the Common folder
        /// </summary>
        /// <param name="fileName">
        ///     File name of the syncfusion license key
        /// </param>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public static string FindLicenseKey()
        {
            int levelsToCheck = 12;
            string filePath = @"Common\SyncfusionLicense.txt";

            string rootPath =
                Path.GetDirectoryName(Assembly.GetEntryAssembly().CodeBase.Replace(@"file:///", string.Empty));

            for (int n = 0; n < levelsToCheck; n++)
            {
                string fileDataPath = Path.Combine(rootPath, filePath);
                if (File.Exists(fileDataPath))
                    return File.ReadAllText(fileDataPath, Encoding.UTF8);
                DirectoryInfo rootDirectory = Directory.GetParent(rootPath);
                if (rootDirectory == null)
                    break;
                rootPath = rootDirectory.FullName;
            }

            return string.Empty;
        }
    }
}