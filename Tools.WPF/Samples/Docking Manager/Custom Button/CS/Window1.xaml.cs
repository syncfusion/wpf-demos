using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;


namespace DockingSampleCustomButton
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
    {
        

        #region Constructor
        /// <summary>
        /// Construtor for window1
        /// </summary>
        public Window1()
		{
			InitializeComponent();
            InitializeLog();           
		}

        /// <summary>
        /// Initialization while creating object
        /// </summary>    

        public void InitializeLog()
        {
            window1.Width = System.Windows.SystemParameters.PrimaryScreenWidth * (0.67);
            window1.Height = System.Windows.SystemParameters.PrimaryScreenHeight * (0.67);
            this.DockingManager.ContainerMode = DocumentContainerMode.TDI;
        }
        #endregion 

        
    }
}
