#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public partial class DockingManagerlikeVisualStudioViewModel
    { 

    //String variables that storing the default and current run and edit mode layout XML file path
    private string currentEditLayout = @"Assets/DockingManager/DockingManagerlikeVisualStudio/Layouts/CurrentEditLayout.xml";
    private string defaultEditLayout = @"Assets/DockingManager/DockingManagerlikeVisualStudio/Layouts/DefaultEditLayout.xml";
    private string currentRunLayout = @"Assets/DockingManager/DockingManagerlikeVisualStudio/Layouts/CurrentRunLayout.xml";
    private string defaultRunLayout = @"Assets/DockingManager/DockingManagerlikeVisualStudio/Layouts/DefaultRunLayout.xml";

        /// <summary>
        /// Enum for active mode
        /// </summary>
        public enum VisualStudioMode
        {
            EditMode,
            RunMode
        }
        

        /// <summary>
        /// Get the layout windows from the saved XML file.
        /// </summary>
        /// <param name="layoutPath">Path of the loading XML file</param>
        /// <returns></returns>
        private List<string> GetSavedWindowList(string layoutPath)
        {
            List<string> savedControlNameList = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(layoutPath);
            XmlNodeList nodes = xmlDoc.DocumentElement.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                if (node.HasChildNodes)
                {
                    //Adding the windows name to the list
                    savedControlNameList.Add(node.SelectSingleNode("Name").InnerText);
                }
            }
            return savedControlNameList;
        }

        /// <summary>
        /// Check and get the missed windows list
        /// </summary>
        /// <param name="contentControl">Instance of DockingManager</param>
        /// <param name="savedControlList">List of windows name from saved layouts</param>
        private List<string> FindMissingChidren(DockingManager contentControl, List<string> savedControlList)
        {
            var missedChildrens = new List<string>();
            if (contentControl != null && savedControlList != null)
            {
                foreach (string savedChild in savedControlList)
                {
                    foreach (FrameworkElement element in contentControl.Children)
                    {
                        if (element.Name == savedChild)
                        {
                            break;
                        }
                    }
                    missedChildrens.Add(savedChild);
                }
            }
            return missedChildrens;
        }

        /// <summary>
        /// Adding the missed windows that is not available in DockingManager
        /// </summary>
        /// <param name="missedChildrens">It contains the missed children list.</param>
        private void AddMissedChildrensIntoDockingManager(List<string> missedChildrens, DockingManager dockingManager)
        {
            if (missedChildrens.Count > 0)
            {
                foreach (string children in missedChildrens)
                {
                    ContentControl dummyChild = new ContentControl();
                    dummyChild.Name = children;
                    dockingManager.Children.Add(dummyChild);
                }
            }
        }

        //Save the Previous mode layout and loads the current mode layout
        private void Switch(VisualStudioMode mode)
        {
            string currentLayoutPath;
            string defaultLayoutPath;
            if (mode == VisualStudioMode.EditMode)
            {
                currentLayoutPath = currentEditLayout;
                defaultLayoutPath = defaultEditLayout;
            }
            else
            {
                currentLayoutPath = currentRunLayout;
                defaultLayoutPath = defaultRunLayout;
            }

            XmlDocument document = new XmlDocument();
            document.Load(currentLayoutPath);

            if (document.ChildNodes[1].ChildNodes.Count < 1)
            {
                //Load the default layout
                Load(defaultLayoutPath, DockingManager);

                //Save the default layout as current layout
                Save(currentLayoutPath, DockingManager);
            }
            else
            {
                //Load currently saved layout
                Load(currentLayoutPath, DockingManager);
            }
        }

        /// <summary>
        /// To save the previous mode layout
        /// </summary>
        /// <param name="saveLayoutPath">Path of the saving layout file</param>
        private void Save(string saveLayoutPath, DockingManager dockingManager)
        {
#if !NET6_0_OR_GREATER
            BinaryFormatter formatter = new BinaryFormatter();
            dockingManager.SaveDockState(formatter, StorageFormat.Xml, saveLayoutPath);
#else
            dockingManager.SaveDockState(saveLayoutPath);
#endif
        }

        /// <summary>
        /// Load the current mode layout
        /// </summary>
        /// <param name="loadLayoutPath">Path of the loading layout path</param>
        private void Load(string loadLayoutPath, DockingManager dockingManager)
        {
            //Check and load the missed windows from saved layout
            if (!dockingManager.LoadDockState(loadLayoutPath))
            {
                var savedWindows = GetSavedWindowList(loadLayoutPath);
                var missingChildren = FindMissingChidren(dockingManager, savedWindows);
                AddMissedChildrensIntoDockingManager(missingChildren, dockingManager);
            }
#if !NET6_0_OR_GREATER
            BinaryFormatter formatter = new BinaryFormatter();
            dockingManager.LoadDockState(formatter, StorageFormat.Xml, loadLayoutPath);
#else
            dockingManager.LoadDockState(loadLayoutPath);
#endif
        }

        /// <summary>
        /// Replace the default layout to current layout when "Reset Layout" menu item is clicked. 
        /// </summary>
        /// <param name="currentLayoutPath">The current active mode layout path.</param>
        /// <param name="defaultLayoutPath">The default layout path of the active mode.</param>
        public void ResetToDefaultLayout(string currentLayoutPath, string defaultLayoutPath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(defaultLayoutPath);

            //Save the default layout into Current mode layout file 
            document.Save(currentLayoutPath);
        }
    }
}
