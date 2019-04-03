#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITest.Common;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Windows.Automation;

using ControlType = Microsoft.VisualStudio.TestTools.UITesting.ControlType;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
namespace Syncfusion.Chart.WPF.UITest
{
    internal class ChartPropertyProvider : UITestPropertyProvider
    {
        public override int GetControlSupportLevel(UITestControl uiTestControl)
        {
            if (!isInThisProvider && IsSupported(uiTestControl))
            {
                return (int)ControlSupport.ControlSpecificSupport;
            }

            return (int)ControlSupport.NoSupport;
        }        
        public override ICollection<string> GetPropertyNames(UITestControl uiTestControl)
        {
            return GetAllPropertiesMap(uiTestControl).Keys;
        }

        public override UITestPropertyDescriptor GetPropertyDescriptor(UITestControl uiTestControl, string propertyName)
        {
            var map = GetAllPropertiesMap(uiTestControl);
            if (map.ContainsKey(propertyName))
            {
                return map[propertyName];
            }

            return null;
        }

        public override object GetPropertyValue(UITestControl uiTestControl, string propertyName)
        {
            if (ExtraPropertiesMap.ContainsKey(propertyName) &&
                (ExtraPropertiesMap[propertyName].Attributes & UITestPropertyAttributes.Readable) == UITestPropertyAttributes.Readable)
            {
                return GetPropertyValueInternal(uiTestControl, propertyName);
            }

            isInThisProvider = true;
            try
            {
                return GetCopiedControl(uiTestControl).GetProperty(propertyName);
            }
            finally
            {
                isInThisProvider = false;
            }
        }

        public override void SetPropertyValue(UITestControl uiTestControl, string propertyName, object propertyValue)
        {
            isInThisProvider = true;
            try
            {
                GetCopiedControl(uiTestControl).SetProperty(propertyName, propertyValue);
            }
            finally
            {
                isInThisProvider = false;
            }
        }

        public override Type GetSpecializedClass(UITestControl uiTestControl)
        {
            return typeof(ChartElement);
        }

        public override Type GetPropertyNamesClassType(UITestControl uiTestControl)
        {
            return typeof(ChartElement.PropertyNames);
        }

        public override string[] GetPredefinedSearchProperties(Type specializedClassType)
        {
            return new string[] { UITestControl.PropertyNames.ControlType };
        }

        public override string GetPropertyForAction(UITestControl uiTestControl, UITestAction action)
        {
            throw new NotSupportedException();
        }

        public override string[] GetPropertyForControlState(UITestControl uiTestControl, ControlStates uiState, out bool[] stateValues)
        {
            stateValues = null;
            return null;
        }

        #region Private Members

        private static bool IsSupported(UITestControl uiTestControl)
        {
            return (uiTestControl is ChartElement) ||
                   (string.Equals(uiTestControl.TechnologyName, "UIA", StringComparison.OrdinalIgnoreCase) &&
                        (uiTestControl.ControlType == ControlType.Custom || uiTestControl.ControlType == ControlType.Pane || uiTestControl.ControlType == ControlType.ListItem));
        }

        private object GetPropertyValueInternal(UITestControl uiTestControl, string propertyName)
        {
            AutomationElement a = uiTestControl.NativeElement as AutomationElement;

            if (a.Current.ItemStatus == null)//|| a.Current.ItemStatus.Length < 7)
                return null;

            String[] automationProperties = a.Current.ItemStatus.Split(new char[] { ';' });
            if ((automationProperties.Length > 0) && automationProperties[0] != string.Empty && string.Equals(propertyName, ChartElement.PropertyNames.Background, StringComparison.OrdinalIgnoreCase))
            {
                return automationProperties[0];
            }

            if ((automationProperties.Length > 1) && automationProperties[1] != string.Empty && string.Equals(propertyName, ChartElement.PropertyNames.Foreground, StringComparison.OrdinalIgnoreCase))
            {
                return automationProperties[1];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.ChartVisualStyle, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 2) && automationProperties[2] != string.Empty)
            {
                return automationProperties[2];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.Dock, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 3) && automationProperties[3] != string.Empty)
            {
                return automationProperties[3];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.RowsCount, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 4) && automationProperties[4] != string.Empty)
            {
                return automationProperties[4];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.ColumnsCount, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 5) && automationProperties[5] != string.Empty)
            {
                return automationProperties[5];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.LegendPanel, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 6) && automationProperties[6] != string.Empty)
            {
                return automationProperties[6];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.IsContextMenuEnabled, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 7) && automationProperties[7] != string.Empty)
            {

                return automationProperties[7];
            }

            if (string.Equals(propertyName, ChartElement.PropertyNames.Orientation, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 8) && automationProperties[8] != string.Empty)
            {
                return automationProperties[8];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.OpposedPosition, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 9) && automationProperties[9] != string.Empty)
            {
                return automationProperties[9];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.ValueType, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 10) && automationProperties[10] != string.Empty)
            {
                return automationProperties[10];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.Type, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 11) && automationProperties[11] != string.Empty)
            {
                return automationProperties[11];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.IsIndexed, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 12) && automationProperties[12] != string.Empty)
            {
                return automationProperties[12];
            }
            if (string.Equals(propertyName, ChartElement.PropertyNames.Interior, StringComparison.OrdinalIgnoreCase) && (automationProperties.Length > 13) && automationProperties[13] != string.Empty)
            {
                return automationProperties[13];
            }
            else
            {
                throw new NotSupportedException();
            }

        }

        private static Dictionary<string, UITestPropertyDescriptor> GetAllPropertiesMap(UITestControl control)
        {
            if (allPropertiesMap == null)
            {
                allPropertiesMap = new Dictionary<string, UITestPropertyDescriptor>(StringComparer.OrdinalIgnoreCase);

                bool initializedByMe = false;
                if (!Playback.IsInitialized)
                {
                    Playback.Initialize();
                    initializedByMe = true;
                }

                try
                {
                    UITestPropertyProvider provider = Playback.GetCorePropertyProvider(control);
                    foreach (var property in provider.GetPropertyNames(control))
                    {
                        var descriptor = provider.GetPropertyDescriptor(control, property);
                        allPropertiesMap.Add(property, descriptor);
                    }
                }
                finally
                {
                    if (initializedByMe)
                    {
                        Playback.Cleanup();
                    }
                }

                foreach (var item in ExtraPropertiesMap)
                {
                    allPropertiesMap.Add(item.Key, item.Value);
                }
            }

            return allPropertiesMap;
        }

        public static UITestControl GetCopiedControl(UITestControl control)
        {
            UITestControl winControl = new UITestControl();
            winControl.CopyFrom(control);
            return winControl;
        }

        private static Dictionary<string, UITestPropertyDescriptor> ExtraPropertiesMap
        {
            get
            {
                if (extraPropertiesMap == null)
                {
                    UITestPropertyAttributes read = UITestPropertyAttributes.Readable | UITestPropertyAttributes.DoNotGenerateProperties;
                    extraPropertiesMap = new Dictionary<string, UITestPropertyDescriptor>(StringComparer.OrdinalIgnoreCase);
                    extraPropertiesMap.Add(ChartElement.PropertyNames.Background, new UITestPropertyDescriptor(typeof(string), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.Foreground, new UITestPropertyDescriptor(typeof(string), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.Orientation, new UITestPropertyDescriptor(typeof(Orientation), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.ChartVisualStyle, new UITestPropertyDescriptor(typeof(Enum), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.Dock, new UITestPropertyDescriptor(typeof(Dock), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.RowsCount, new UITestPropertyDescriptor(typeof(int), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.ColumnsCount, new UITestPropertyDescriptor(typeof(int), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.LegendPanel, new UITestPropertyDescriptor(typeof(string), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.IsContextMenuEnabled, new UITestPropertyDescriptor(typeof(string), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.ValueType, new UITestPropertyDescriptor(typeof(string), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.OpposedPosition, new UITestPropertyDescriptor(typeof(string), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.Type, new UITestPropertyDescriptor(typeof(string), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.IsIndexed, new UITestPropertyDescriptor(typeof(string), read));
                    extraPropertiesMap.Add(ChartElement.PropertyNames.Interior, new UITestPropertyDescriptor(typeof(string), read));
                }

                return extraPropertiesMap;
            }
        }

        private static Dictionary<string, UITestPropertyDescriptor> allPropertiesMap;
        private static Dictionary<string, UITestPropertyDescriptor> extraPropertiesMap;
        private bool isInThisProvider;

        #endregion
    }
}
