#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

#if NET50
            if (arg != null)
            {
                string parameter = arg.ToString();
                if(parameter == "SaveXMlFormatSoap" || parameter == "SaveBinaryFormatSoap" || parameter == "LoadXMlFormatSoap" || parameter == "LoadBinaryFormatSoap")
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
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.SaveDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
                }
#if !NET50
                else if (parameter == "SaveXMlFormatSoap")
                {
                    SoapFormatter formatter1 = new SoapFormatter();
                    this.StatePersistenceService.SaveDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
                }
#endif
                else if (parameter == "SaveBinaryFormat")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.SaveDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin.bin");
                }
#if !NET50
                else if (parameter == "SaveBinaryFormatSoap")
                {
                    SoapFormatter formatter1 = new SoapFormatter();
                    this.StatePersistenceService.SaveDockState(formatter1, StorageFormat.Binary, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_bin_soap.bin");
                }
#endif
                else if (parameter == "LoadXMlFormat")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();

                    try
                    {
                        this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml.xml");
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
#if !NET50
                else if (parameter == "LoadXMlFormatSoap")
                {
                    SoapFormatter formatter1 = new SoapFormatter();

                    try
                    {
                        this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\docking_xml_soap.xml");
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
#if !NET50
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
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, @"Assets/DockingManager/StatePersistence/Layout1.xml");
                }
                else if (parameter == "layout2")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, @"Assets/DockingManager/StatePersistence/Layout2.xml");
                }
                else if (parameter == "layout3")
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    this.StatePersistenceService.LoadDockState(formatter1, StorageFormat.Xml, @"Assets/DockingManager/StatePersistence/Layout3.xml");
                }
                else if (parameter == "resetLayout")
                {
                    this.StatePersistenceService.ResetState();
                }
            }
        }
    }
}
