#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
    public interface IStatePersistenceService 
    {
        void SaveDockState(IFormatter serializer, StorageFormat format, string path);     
        bool LoadDockState(IFormatter serializer, StorageFormat format, string path);
        bool ResetState();
    }
}
