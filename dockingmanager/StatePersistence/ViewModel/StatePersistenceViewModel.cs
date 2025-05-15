#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using Syncfusion.Windows.Shared;
#if !NET50
using System.Runtime.Serialization.Formatters.Soap;
#endif
using System.Runtime.Serialization;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class StatePersistenceViewModel : demoscommon.wpf.NotificationObject
    {
        private const string AttentionHeader = "Attention";
        private ICommand cmd;

        public ICommand SaveCommand
        {
            get
            {
                cmd = new demoscommon.wpf.DelegateCommand(Selected, CanSelect);
                return cmd;
            }
        }

        private StatePersistenceService StatePersistenceService;

        public StatePersistenceViewModel(StatePersistenceService service)
        {
            this.StatePersistenceService = service;
        }

        private bool CanSelect(object arg)
        {

#if NET6_0_OR_GREATER
            if (arg != null)
            {
                string parameter = arg.ToString();
                if(parameter == "SaveBinaryFormat" || parameter == "SaveBinaryFormatSoap" || parameter == "LoadBinaryFormat" || parameter == "LoadBinaryFormatSoap")
                {
                    return false;
                }
            }
#endif
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
                string parameter = obj.ToString();

                if (parameter == "SaveXMlFormat")
                {
#if !NET6_0_OR_GREATER
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.SaveDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
#else
                    this.StatePersistenceService.SaveDockState(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
#endif
                }

                else if (parameter == "SaveXMlFormatSoap")
                {
#if !NET6_0_OR_GREATER
                    SoapFormatter formatter1 = new SoapFormatter();
                    this.StatePersistenceService.SaveDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
#else
                    this.StatePersistenceService.SaveDockState(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
#endif
                }
#if !NET6_0_OR_GREATER
                else if (parameter == "SaveBinaryFormat")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.SaveDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin.bin");
                }
#endif
#if !NET6_0_OR_GREATER
                else if (parameter == "SaveBinaryFormatSoap")
                {
                    SoapFormatter formatter1 = new SoapFormatter();
                    this.StatePersistenceService.SaveDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin_soap.bin");
                }
#endif
                else if (parameter == "LoadXMlFormat")
                {
                    try
                    {
#if !NET6_0_OR_GREATER
                        BinaryFormatter formatter1 = new BinaryFormatter();
                        this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
#else
                        this.StatePersistenceService.LoadDockState(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
#endif
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

                else if (parameter == "LoadXMlFormatSoap")
                {
                    try
                    {
#if !NET6_0_OR_GREATER
                    SoapFormatter formatter1 = new SoapFormatter();

                        this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
#else
                        this.StatePersistenceService.LoadDockState(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
#endif
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
#if !NET6_0_OR_GREATER
                else if (parameter == "LoadBinaryFormat")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    try
                    {
                        this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin.bin");
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
#endif

#if !NET6_0_OR_GREATER
                else if (parameter == "LoadBinaryFormatSoap")
                {
                    SoapFormatter formatter1 = new SoapFormatter();
                    try
                    {
                        this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin_soap.bin");
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show(ex.Message, AttentionHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
#endif
                else if (parameter == "layout1")
                {
#if !NET6_0_OR_GREATER
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, @"Assets/DockingManager/StatePersistence/Layout1.xml");
#else
                    this.StatePersistenceService.LoadDockState(@"Assets/DockingManager/StatePersistence/Layout1.xml");
#endif
                }
                else if (parameter == "layout2")
                {
#if !NET6_0_OR_GREATER
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, @"Assets/DockingManager/StatePersistence/Layout2.xml");
#else
                    this.StatePersistenceService.LoadDockState(@"Assets/DockingManager/StatePersistence/Layout2.xml");
#endif
                }
                else if (parameter == "layout3")
                {
#if !NET6_0_OR_GREATER
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, @"Assets/DockingManager/StatePersistence/Layout3.xml");
#else
                    this.StatePersistenceService.LoadDockState(@"Assets/DockingManager/StatePersistence/Layout3.xml");
#endif
                }
                else if (parameter == "resetLayout")
                {
                    this.StatePersistenceService.ResetState();
                }
            }
        }
    }
}
