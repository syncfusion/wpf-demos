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
using Syncfusion.Windows.Tools;

namespace DragandDropDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            EventLog();
        }
        #endregion

        #region EventLog

        public void EventLog()
        {
            TreeViewAdv1.DragStart += new DragTreeViewItemAdvHandler(TreeViewAdv_DragStart);
            TreeViewAdv2.DragStart += new DragTreeViewItemAdvHandler(TreeViewAdv_DragStart);
            TreeViewAdv2.DragLeave += new DragEventHandler(TreeViewAdv1_DragLeave);
            TreeViewAdv1.DragLeave +=new DragEventHandler(TreeViewAdv1_DragLeave);
            TreeViewAdv1.DragEnd += new DragTreeViewItemAdvHandler(TreeViewAdv1_DragEnd);
            TreeViewAdv2.DragEnd += new DragTreeViewItemAdvHandler(TreeViewAdv1_DragEnd);
            TreeViewAdv1.Drop += new DragEventHandler(TreeViewAdv1_Drop);
            TreeViewAdv2.Drop += new DragEventHandler(TreeViewAdv1_Drop);
            
        }

        public void AddLog(string eventlog)
        {
            Sblayout.EventLogs.Add(eventlog);
        }

        #endregion

        #region Events

        void TreeViewAdv1_Drop(object sender, DragEventArgs e)
        {
            if(e.Source is TreeViewItemAdv)
                AddLog("Dropped into TreeViewItem  ( " + (e.Source as TreeViewItemAdv).Header + " )");
        else
            if(e.Source is TreeViewAdv)
                AddLog("Dropped into ( " + (e.Source as TreeViewAdv).Name + " )");
        }

        void TreeViewAdv1_DragEnd(object sender, DragTreeViewItemAdvEventArgs e)
        {
            AddLog("DragEnd ( " + (e.OriginalSource as TreeViewAdv).Name + " )");
        }

        void TreeViewAdv1_DragLeave(object sender, DragEventArgs e)
        {

            if (e.Source is TreeViewItemAdv)
                AddLog("DragLeave  TreeViewItem  ( " + (e.Source as TreeViewItemAdv).Header + " )");
            else
                if (e.Source is TreeViewAdv)
                    AddLog("DragLeave ( " + (e.Source as TreeViewAdv).Name + " )");
        }

        void TreeViewAdv_DragStart(object sender, DragTreeViewItemAdvEventArgs e)
        {
            AddLog("DragStarted from ( " + (e.OriginalSource as TreeViewAdv ).Name+" )" );
        }


        #endregion


    }
}
