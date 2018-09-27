using System.Windows;

namespace VirtualizedCell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
	public partial class App : Application
	{
		public App()
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Syncfusion.Licensing.DemoCommon.FindLicenseKey());
		} 
	}
}
