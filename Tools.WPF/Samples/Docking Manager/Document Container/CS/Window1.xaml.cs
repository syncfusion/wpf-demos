using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;


namespace DocumentContainerDemo_2008
{
    
    public partial class Window1 : Window
    {
        #region Private Members
        /// <summary>
        /// String for Displaying in the MessageBox.
        /// </summary>
        private const string AttentionHeader = "Attention!";
        int i = 1;
        #endregion

        #region constructor
        /// <summary>
        /// Contructor for window1.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            UpdateGroupbarVisibility();
        }
        #endregion

        #region Helper Methods  

        private void UpdateGroupbarVisibility()
        {
            if (DocContainer != null)
            {
                if (DocContainer.Mode == DocumentContainerMode.TDI)
                {
                    GroupbarBorder_MDI.Visibility = Visibility.Collapsed;
                    GroupbarBorder_TDI.Visibility = Visibility.Visible;
                    Restore.Visibility = Visibility.Collapsed;
                }
                else if (DocContainer.Mode == DocumentContainerMode.MDI)
                {
                    GroupbarBorder_MDI.Visibility = Visibility.Visible;
                    GroupbarBorder_TDI.Visibility = Visibility.Collapsed;
                    Restore.Visibility = Visibility.Visible;
                }
            }
        }
        /// <summary>
        /// Method used for changing the TDI/MDI modes in runtime.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void mode_Click(object sender, RoutedEventArgs e)
        {
            //Changing DocumentContianer Mode
            MenuItem c = (MenuItem)sender;
            string g = c.Header.ToString();           
            if (DocContainer != null)
            {
                if (g.StartsWith("MDI"))
                {
                    DocContainer.Mode = DocumentContainerMode.MDI;
                    TDI.IsChecked = false;
                    MDI.IsChecked = true;
                    UpdateGroupbarVisibility();
                    
                }
                else if (g.StartsWith("TDI"))
                {
                    DocContainer.Mode = DocumentContainerMode.TDI;
                   
                    TDI.IsChecked = true;
                    MDI.IsChecked = false;
                    UpdateGroupbarVisibility();
                                     
                }
            }
        }
        /// <summary>
        /// Method used for changing the Layout for the MDI elements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void Layout_Click(object sender, RoutedEventArgs e)
        {
            //Changing Document Containter Layout
            MenuItem c = (MenuItem)sender;
            string g = c.Header.ToString();
            switch (c.Name)
            {
                case "Cascade":
                    DocContainer.SetLayout(MDILayout.Cascade);
                    break;
                case "THorizontal":
                    DocContainer.SetLayout(MDILayout.Horizontal);
                    break;
                case "TVertical":
                    DocContainer.SetLayout(MDILayout.Vertical);
                    break;
            }            
        }
        /// <summary>
        /// Method used for saving the states to Registry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
     
        private void OnSaveToRegStateClick(object sender, RoutedEventArgs e)
        {           
            //Save State
            BinaryFormatter formatter1 = new BinaryFormatter();
            DocContainer.SaveDockState(formatter1);           
        }

        /// <summary>
        /// Method used for Load the states from Registry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  

        private void OnLoadFromRegStateClick(object sender, RoutedEventArgs e)
        {          
            //Load State
            BinaryFormatter formatter1 = new BinaryFormatter();
            try
            {
                DocContainer.LoadDockState(formatter1);
            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        /// <summary>
        /// Method used for saving the states to IS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void OnSaveStateToIsoStorageClick(object sender, RoutedEventArgs e)
        {
            //Save State to Isolated Storage
            DocContainer.SaveDockState();
        }
        /// <summary>
        /// Method used for Load the states from IS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void OnLoadStateFromIsoStorageClick(object sender, RoutedEventArgs e)
        {
            //Load State from Isolated Storage
            DocContainer.LoadDockState();
        }
        /// <summary>
        /// Method used for reset the states from IS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void OnResetStateInIsoStorageClick(object sender, RoutedEventArgs e)
        {
           //Delete Internal Isolated Storage
            DocContainer.DeleteInternalIsolatedStorage();
        }
        /// <summary>
        /// Method used for saving the states to XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void OnSaveToXMLStateClick(object sender, RoutedEventArgs e)
        {
           //Save to XML sate
            if (BinFormatterRadio.IsChecked == true)
            {
                BinaryFormatter formatter1 = new BinaryFormatter();
                DocContainer.SaveDockState(formatter1, StorageFormat.Xml, 
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_xml.xml");
            }
            else
            {
                SoapFormatter formatter1 = new SoapFormatter();
                DocContainer.SaveDockState(formatter1, StorageFormat.Xml, 
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_xml.xml");
            }
        }
        /// <summary>
        /// Method used for Load the states from XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void OnLoadFromXMLStateClick(object sender, RoutedEventArgs e)
        {
           //Load from XML State
            if (BinFormatterRadio.IsChecked == true)
            {
                BinaryFormatter formatter1 = new BinaryFormatter();
                try
                {
                    DocContainer.LoadDockState(formatter1, StorageFormat.Xml,
                        AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_xml.xml");
                }
                catch (XmlException ex)
                {
                    MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, 
                                                                 MessageBoxImage.Warning);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, 
                                                                 MessageBoxImage.Warning);
                }
            }
            else
            {
                SoapFormatter formatter1 = new SoapFormatter();
                try
                {
                    DocContainer.LoadDockState(formatter1, StorageFormat.Xml, 
                        AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_xml.xml");
                }
                catch (XmlException ex)
                {
                    MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, 
                                                                 MessageBoxImage.Warning);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK,
                                                                 MessageBoxImage.Warning);
                }
            }
        }
        /// <summary>
        /// Method used for saving the states to Binary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void OnSaveToBinStateClick(object sender, RoutedEventArgs e)
        {
            //Save to Binary State   
            if (BinFormatterRadio.IsChecked == true)
            {
                BinaryFormatter formatter1 = new BinaryFormatter();
                DocContainer.SaveDockState(formatter1, StorageFormat.Binary, 
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_bin.bin");
            }
            else
            {
                SoapFormatter formatter1 = new SoapFormatter();
                DocContainer.SaveDockState(formatter1, StorageFormat.Binary, 
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_bin.bin");
            }
        }
        /// <summary>
        /// Method used for Load the states from Binary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void OnLoadFromBinStateClick(object sender, RoutedEventArgs e)
        { 
            //Load from Binary State
            if (BinFormatterRadio.IsChecked == true)
            {
                BinaryFormatter formatter1 = new BinaryFormatter();
                try
                {
                    DocContainer.LoadDockState(formatter1, StorageFormat.Binary, 
                        AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_bin.bin");
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK,
                                                                 MessageBoxImage.Warning);
                }
                catch (XmlException ex)
                {
                    MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, 
                                                                 MessageBoxImage.Warning);
                }
            }
            else
            {
                SoapFormatter formatter1 = new SoapFormatter();
                try
                {
                   DocContainer.LoadDockState(formatter1, StorageFormat.Binary, 
                       AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_bin.bin");
                }
                catch (XmlException ex)
                {
                    MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, 
                                                                 MessageBoxImage.Warning);
                }
            }
        }
        /// <summary>
        /// Method used for Reset the States.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void OnResetStateClick(object sender, RoutedEventArgs e)
        {           
            //Reset State
            DocContainer.ResetState();            
        }
        /// <summary>
        /// Method used for Deleting the states.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void deletestate_Click(object sender, RoutedEventArgs e)
        {
            //Delete Dock State
            DocContainer.DeleteDockState(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_xml.xml");
            DocContainer.DeleteDockState(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_bin.bin");
            DocContainer.DeleteDockState();
        }
        /// <summary>
        /// Method used to add elements to the Document Container.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void AddElement_Click(object sender, RoutedEventArgs e)
        {           
           RichTextBox rtb = new RichTextBox();
           rtb.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
           DocumentContainer.SetHeader(rtb, "New Window" + i.ToString());
           Rect re = new Rect(30, 30, 300, 300);
           DocumentContainer.SetMDIBounds(rtb, re);
           DocContainer.Items.Add(rtb);
           DocContainer.ActiveDocument = rtb;
           i++;            
        }
         /// <summary>
        /// Method used to close the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Method used to change the different window switchers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>   
        private void windowswitchers_Click(object sender, RoutedEventArgs e)
        {
            //Changing SwitchMode
            MenuItem mi = (MenuItem)e.OriginalSource;
            string g = mi.Header.ToString();
            gbVistaFlip.Visibility = Visibility.Collapsed;
            for (int i = 0; i < WindowSwitchers.Items.Count; i++)
            {
                MenuItem mitem = (MenuItem)WindowSwitchers.Items[i];
                if (mitem.Header.ToString().Equals(g))
                    mitem.IsChecked = true;
                else
                    mitem.IsChecked = false;
            }
            if (g.StartsWith("Immediate"))
                DocContainer.SwitchMode = SwitchMode.Immediate;
            else if (g.StartsWith("List"))
                DocContainer.SwitchMode = SwitchMode.List;
            else if (g.StartsWith("QuickTabs"))
                DocContainer.SwitchMode = SwitchMode.QuickTabs;
            else if (g.StartsWith("VS2005"))
                DocContainer.SwitchMode = SwitchMode.VS2005;
            else if (g.StartsWith("VistaFlip"))
            {
                DocContainer.SwitchMode = SwitchMode.VistaFlip;
                gbVistaFlip.Visibility = Visibility.Visible;              
            }
        }
        /// <summary>
        /// Method used to close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion
    }
}
   