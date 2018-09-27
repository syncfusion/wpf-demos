using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace CustomSummary
{
    class Program
    {
        static void Main(string[] args)
        {
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(FindLicenseKey());
            Class1 c = new Class1();
            c.Run();

            Console.WriteLine("Please press <Enter> to continue.");
            Console.ReadLine();
        }
        /// <summary>
        /// Helper method to find a syncfusion license key from the Common folder
        /// </summary>
        /// <param name="fileName">File name of the syncfusion license key</param>
        /// <returns></returns>
        public static string FindLicenseKey()
        {
            int levelsToCheck = 12;
            string filePath = @"Common\SyncfusionLicense.txt";
            string rootPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().CodeBase.Replace(@"file:///", ""));
            for (int n = 0; n < levelsToCheck; n++)
            {
                string fileDataPath = System.IO.Path.Combine(rootPath, filePath);
                if (System.IO.File.Exists(fileDataPath))
                    return File.ReadAllText(fileDataPath, Encoding.UTF8);
                rootPath = Directory.GetParent(rootPath).FullName;
            }
            return string.Empty;
        }
    }
}
