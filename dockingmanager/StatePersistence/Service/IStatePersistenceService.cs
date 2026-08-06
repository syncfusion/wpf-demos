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
#if !NET6_0_OR_GREATER
        void SaveDockState(IFormatter serializer, StorageFormat format, string path);     
        bool LoadDockState(IFormatter serializer, StorageFormat format, string path);
#else
        void SaveDockState(string path);
        bool LoadDockState(string path);
#endif
        bool ResetState();
    }
}
