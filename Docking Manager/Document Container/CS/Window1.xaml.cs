#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
#if !NETCORE
using System.Runtime.Serialization.Formatters.Soap;
#endif
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
            InitializeLog();
            UpdateGroupbarVisibility();
#if NETCORE
            BinFormatterRadio.IsChecked = true;
            BinFormatterRadio.Visibility = Visibility.Collapsed;
#endif

        }
        #endregion

        #region Helper Methods  

        /// <summary>
        /// Initialization while creating object
        /// </summary>   
        public void InitializeLog()
        {
            // Set the width of the window
            window1.Width = System.Windows.SystemParameters.PrimaryScreenWidth * (0.52);
            // Set the height of the window
            window1.Height = System.Windows.SystemParameters.PrimaryScreenHeight * (0.77);
        }

        private void UpdateGroupbarVisibility()
        {
            if (DocContainer != null)
            {
                if (DocContainer.Mode == DocumentContainerMode.TDI)
                {
                    Restore.Visibility = Visibility.Collapsed;
                    chkCanMaximize.IsEnabled = false;
                    chkCanMinimize.IsEnabled = false;
                    chkCanResize.IsEnabled = false;
                    TablistContextMenu.IsEnabled = true;
                    TabItemContextMenu.IsEnabled = true;
                    Cascade.IsEnabled = false;
                    THorizontal.IsEnabled = false;
                    TVertical.IsEnabled = false;
                }
                else if (DocContainer.Mode == DocumentContainerMode.MDI)
                {
                    Restore.Visibility = Visibility.Visible;
                    chkCanMaximize.IsEnabled = true;
                    chkCanMinimize.IsEnabled = true;
                    chkCanResize.IsEnabled = true;
                    TablistContextMenu.IsEnabled = false;
                    TabItemContextMenu.IsEnabled = false;
                    Cascade.IsEnabled = true;
                    THorizontal.IsEnabled = true;
                    TVertical.IsEnabled = true;
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
            RadioButton c = (RadioButton)sender;
            string g = c.Content.ToString();           
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
            Button c = (Button)sender;
            string g = c.Content.ToString();
            switch (c.Name)
            {
                case "Cascade":
                    DocContainer.SetLayout(MDILayout.Cascade);
                    DocumentContainer.SetCanDrag(firstdoc, true);
                    DocumentContainer.SetCanDrag(seconddoc, true);
                    DocumentContainer.SetCanDrag(ThirdDoc, true);
                    break;
                case "THorizontal":
                    DocContainer.SetLayout(MDILayout.Horizontal);
                    DocumentContainer.SetCanDrag(firstdoc, false);
                    DocumentContainer.SetCanDrag(seconddoc, false);
                    DocumentContainer.SetCanDrag(ThirdDoc, false);
                    break;
                case "TVertical":
                    DocContainer.SetLayout(MDILayout.Vertical);
                    DocumentContainer.SetCanDrag(firstdoc, false);
                    DocumentContainer.SetCanDrag(seconddoc, false);
                    DocumentContainer.SetCanDrag(ThirdDoc, false);
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
            Load1.IsEnabled = true;
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
            Isload.IsEnabled = true;
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
                xmlload.IsEnabled = true;
                BinaryFormatter formatter1 = new BinaryFormatter();
                DocContainer.SaveDockState(formatter1, StorageFormat.Xml, 
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_xml.xml");
            }
#if !NETCORE
            else
            {
                xmlload.IsEnabled = true;
                SoapFormatter formatter1 = new SoapFormatter();
                DocContainer.SaveDockState(formatter1, StorageFormat.Xml, 
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_xml.xml");
            }
#endif
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
#if !NETCORE
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
#endif
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
                Binload.IsEnabled = true;
                BinaryFormatter formatter1 = new BinaryFormatter();
                DocContainer.SaveDockState(formatter1, StorageFormat.Binary, 
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_bin.bin");
            }
#if !NETCORE
            else
            {
                Binload.IsEnabled = true;
                SoapFormatter formatter1 = new SoapFormatter();
                DocContainer.SaveDockState(formatter1, StorageFormat.Binary, 
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docum_bin.bin");
            }
#endif
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
#if !NETCORE
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
#endif
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
            RadioButton mi = (RadioButton)e.OriginalSource;
            string g = mi.Content.ToString();
          
            for (int i = 0; i < WindowSwitchers.Children.Count; i++)
            {
                RadioButton mitem = (RadioButton)WindowSwitchers.Children[i];
                if (mitem.Content.ToString().Equals(g))
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
   