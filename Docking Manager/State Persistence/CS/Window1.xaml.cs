#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
#if !NETCORE
using System.Runtime.Serialization.Formatters.Soap;
#endif
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
           
            this.DataContext = this;

#if NETCORE
            SaveXMlFormatSoap.Visibility = Visibility.Collapsed;
            SaveBinaryFormatSoap.Visibility = Visibility.Collapsed;
            LoadXMlFormatSoap.Visibility = Visibility.Collapsed;
            LoadBinaryFormatSoap.Visibility = Visibility.Collapsed;
            codeText.DocumentSource = "../../../Window1.xaml.cs";
            codeText1.DocumentSource = "../../../Window1.xaml";
#else
            codeText.DocumentSource = "../../Window1.xaml.cs";
            codeText1.DocumentSource = "../../Window1.xaml";
#endif
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

        private ICommand cmd;

        public ICommand SaveCommand
        {
            get
            {
                cmd = new DelegateCommand(Selected, CanSelect);
                return cmd;
            }
        }

        private bool CanSelect(object arg)
        {
            return true;
        }

        /// <summary>
        /// Helps to perform save and load operation of Docking Manager.
        /// </summary>
        /// <param name="obj"></param>
        private void Selected(object obj)
        {
            if (obj != null)
            {
                MenuItem menuItem = (obj as MenuItem);

                if (menuItem.Name == "SaveXMlFormat")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    dockingManager.SaveDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
                }
#if !NETCORE
                else if (menuItem.Name == "SaveXMlFormatSoap")
                {
                    SoapFormatter formatter1 = new SoapFormatter();
                    dockingManager.SaveDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
                }
#endif
                else if (menuItem.Name == "SaveBinaryFormat")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    dockingManager.SaveDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin.bin");
                }
#if !NETCORE
                else if (menuItem.Name == "SaveBinaryFormatSoap")
                {
                    SoapFormatter formatter1 = new SoapFormatter();
                    dockingManager.SaveDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin_soap.bin");
                }
#endif
                else if (menuItem.Name == "LoadXMlFormat")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();

                    try
                    {
                        dockingManager.LoadDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
#if !NETCORE
                else if (menuItem.Name == "LoadXMlFormatSoap")
                {
                    SoapFormatter formatter1 = new SoapFormatter();

                    try
                    {
                        dockingManager.LoadDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
#endif
                else if (menuItem.Name == "LoadBinaryFormat")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    try
                    {
                        dockingManager.LoadDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin.bin");
                    }
                    catch (SerializationException ex)
                    {
                        MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
#if !NETCORE
                else if (menuItem.Name == "LoadBinaryFormatSoap")
                {
                    SoapFormatter formatter1 = new SoapFormatter();
                    try
                    {
                        dockingManager.LoadDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin_soap.bin");
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
#endif
                else if (menuItem.Name == "layout1")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
#if NETCORE
                    dockingManager.LoadDockState(formatter1, StorageFormat.Xml, "../../../Layout1.xml");
#else
                    dockingManager.LoadDockState(formatter1, StorageFormat.Xml, "../../Layout1.xml");
#endif
                }
                else if (menuItem.Name == "layout2")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
#if NETCORE
                    dockingManager.LoadDockState(formatter1, StorageFormat.Xml, "../../../Layout2.xml");
#else
                    dockingManager.LoadDockState(formatter1, StorageFormat.Xml, "../../Layout2.xml");
#endif
                }
                else if (menuItem.Name == "layout3")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
#if NETCORE
                    dockingManager.LoadDockState(formatter1, StorageFormat.Xml, "../../../Layout3.xml");
#else
                    dockingManager.LoadDockState(formatter1, StorageFormat.Xml, "../../Layout3.xml");
#endif
                }
                else if (menuItem.Name == "resetLayout")
                {
                    dockingManager.ResetState();
                }
            }
        }
#endregion


    }
}