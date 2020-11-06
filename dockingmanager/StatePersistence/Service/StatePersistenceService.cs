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
using Syncfusion.Windows.Tools.Controls;
#if !NET50
using System.Runtime.Serialization.Formatters.Soap;
#endif
using System.Runtime.Serialization;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class StatePersistenceService : IStatePersistenceService
    {
        private DockingManager dockingManager;

        public StatePersistenceService(DockingManager dockingManager)
        {
            this.dockingManager = dockingManager;
        }

        public bool LoadDockState(IFormatter serializer, StorageFormat format, string path)
        {
            return this.dockingManager.LoadDockState(serializer, format, path);
        }

        public bool ResetState()
        {
            return this.dockingManager.ResetState();
        }

        public void SaveDockState(IFormatter serializer, StorageFormat format, string path)
        {
            this.dockingManager.SaveDockState(serializer, format, path);
        }
    }
}
