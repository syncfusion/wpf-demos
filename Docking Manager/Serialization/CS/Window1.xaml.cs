#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;

namespace DockingLayoutDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
#region Constructor
        /// <summary>
        /// Constructor for window1.
        /// </summary>
        public Window1()
        {
            InitializeComponent();            
           
            this.DataContext = this;
        }

        #region SaveCommand
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
            XmlWriter writer = XmlWriter.Create("DockStates.xml");

            dockingManager.SaveDockState(writer);

            writer.Close();
        }
        #endregion

        #region LoadCommand
        private ICommand loadcmd;

        public ICommand LoadCommand
        {
            get
            {
                loadcmd = new DelegateCommand(Load, CanLoad);
                return loadcmd;
            }
        }

        private bool CanLoad(object arg)
        {
            return true;
        }

        /// <summary>
        /// Helps to perform save and load operation of Docking Manager.
        /// </summary>
        /// <param name="obj"></param>
        private void Load(object obj)
        {
            XmlReader reader = XmlReader.Create("DockStates.xml");

            dockingManager.LoadDockState(reader);

            reader.Close();
        }
        #endregion

        #region AddCommand
        private ICommand addCmd;

        public ICommand AddCommand
        {
            get
            {
                addCmd = new DelegateCommand(Add, CanAdd);
                return addCmd;
            }
        }

        private bool CanAdd(object arg)
        {
            return true;
        }

        /// <summary>
        /// Helps to perform save and load operation of Docking Manager.
        /// </summary>
        /// <param name="obj"></param>
        private void Add(object obj)
        {
            int count = 1;
            ContentControl contentControl = new ContentControl();
            contentControl.Name = "newChild" + count;
            DockingManager.SetHeader(contentControl, "New Child " + count);
            DockingManager.SetDesiredWidthInDockedMode(contentControl, 200);
            dockingManager.Children.Add(contentControl);
            count++;
        }

        #endregion

        #endregion

        private void dockingManager_DockStateChanged(FrameworkElement sender, DockStateEventArgs e)
        {
            if(e.NewState == DockState.Hidden)
            {
                dockingManager.Children.Remove(sender);
            }
        }
    }
}