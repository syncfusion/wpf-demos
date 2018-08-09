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
using System.Diagnostics;
using System.Xml;
using System.ComponentModel;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace StatePersistence
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        #region Private Members

        /// <summary>
        /// Private Members
        /// </summary>       

        private const string AttentionHeader = "Attention";       

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for window1.
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
            // Set the width of the window
            window1.Width = System.Windows.SystemParameters.PrimaryScreenWidth * (0.67);
            // Set the height of the window
            window1.Height = System.Windows.SystemParameters.PrimaryScreenHeight * (0.67);
            // Set the ContainerMode of docking manager as TDI
            dockingManager.ContainerMode = DocumentContainerMode.TDI;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Save binary state as xml format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveStateBinaryClick(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter1 = new BinaryFormatter();
            dockingManager.SaveDockState(formatter1, StorageFormat.Xml,
                AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
        }

        /// <summary>
        /// Save soap state as xml format 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveStateSoapClick(object sender, RoutedEventArgs e)
        {
            SoapFormatter formatter1 = new SoapFormatter();
            dockingManager.SaveDockState(formatter1, StorageFormat.Xml,
                AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
        }
        /// <summary>
        /// Save binary state in binary format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveToBinStateClick(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter1 = new BinaryFormatter();
            dockingManager.SaveDockState(formatter1, StorageFormat.Binary,
                AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin.bin");
        }
        /// <summary>
        /// Save soap state in binary format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveToBinStateSoapClick(object sender, RoutedEventArgs e)
        {
            SoapFormatter formatter1 = new SoapFormatter();
            dockingManager.SaveDockState(formatter1, StorageFormat.Binary,
                AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin_soap.bin");
        }

        /// <summary>
        /// Save binary state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveToRegStateClick(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter1 = new BinaryFormatter();
            dockingManager.SaveDockState(formatter1);
        }
        /// <summary>
        /// Save isolated storage state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveStateToIsoStorageClick(Object sender, EventArgs e)
        {
            if (null != this.dockingManager)
            {
                this.dockingManager.SaveDockState();
            }
            else
                Debug.Fail("Name isn't alive");
        }

        /// <summary>
        /// Load Isolated storage state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadStateFromIsoStorageClick(Object sender, EventArgs e)
        {
            if (null != this.dockingManager)
            {
                try
                {
                    this.dockingManager.LoadDockState();
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
                Debug.Fail("Name isn't alive");
        }
        /// <summary>
        /// Load state from soap with binary format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadStateBinaryClick(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter1 = new BinaryFormatter();

            try
            {
                dockingManager.LoadDockState(formatter1, StorageFormat.Xml,
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
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

        /// <summary>
        /// Load state from soap with xml format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadStateSoapClick(object sender, RoutedEventArgs e)
        {
            SoapFormatter formatter1 = new SoapFormatter();

            try
            {
                dockingManager.LoadDockState(formatter1, StorageFormat.Xml,
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
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

        /// <summary>
        /// Load state from binary storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadFromBinStateClick(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter1 = new BinaryFormatter();
            try
            {
                dockingManager.LoadDockState(formatter1, StorageFormat.Binary,
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin.bin");
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

        /// <summary>
        /// Load state from soap storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadFromSoapStateClick(object sender, RoutedEventArgs e)
        {
            SoapFormatter formatter1 = new SoapFormatter();
            try
            {
                dockingManager.LoadDockState(formatter1, StorageFormat.Binary,
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin_soap.bin");
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Load state from registry storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadFromRegStateClick(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter1 = new BinaryFormatter();
            try
            {
                dockingManager.LoadDockState(formatter1);
            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Reset the state of dock window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResetStateClick(object sender, RoutedEventArgs e)
        {
            dockingManager.ResetState();
        }

        /// <summary>
        /// Delete the dock state with event args
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteDockStateClick(Object sender, EventArgs e)
        {
            dockingManager.DeleteDockState();
            dockingManager.DeleteDockState
                (AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
            dockingManager.DeleteDockState
                (AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin.bin");
            dockingManager.DeleteDockState
                (AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
            dockingManager.DeleteDockState
                (AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin_soap.bin");
        }

        /// <summary>
        /// Show the inbox dock window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Inbox(object sender, RoutedEventArgs e)
        {
            dockingManager.ActivateWindow("DockInbox");
        }

        /// <summary>
        /// Show the sent items dock window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_SentItems(object sender, RoutedEventArgs e)
        {
            dockingManager.ActivateWindow("DockSentItem1");
        }

        /// <summary>
        /// Show the mail dock window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Mail(object sender, RoutedEventArgs e)
        {
            dockingManager.ActivateWindow("Mail");
        }

        /// <summary>
        /// Delete the dock state with routed event args
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteDockStateClick(object sender, RoutedEventArgs e)
        {
            dockingManager.DeleteDockState();
            dockingManager.DeleteDockState
                (AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
            dockingManager.DeleteDockState
                (AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin.bin");
            dockingManager.DeleteDockState
                (AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
            dockingManager.DeleteDockState
                (AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin_soap.bin");
        }
       
        #endregion

        private void dockingManager_ActiveWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}