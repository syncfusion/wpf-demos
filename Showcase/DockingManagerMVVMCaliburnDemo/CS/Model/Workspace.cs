#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DockingAdapterMVVM;

namespace DockingManagerMVVMCaliburnMicro
{
    public class Workspace : NotificationObject, IChildrenElement
    {
        private bool m_CanAutoHide = true;
        public bool CanAutoHide
        {
            get
            {
                return m_CanAutoHide;
            }
            set
            {
                m_CanAutoHide = value;
            }
        }

        private bool m_CanClose = true;
        public bool CanClose
        {
            get
            {
                return m_CanClose;
            }
            set
            {
                m_CanClose = value;
            }
        }

        private bool m_CanDock = true;
        public bool CanDock
        {
            get
            {
                return m_CanDock;
            }
            set
            {
                m_CanDock = value;
            }
        }

        private bool m_CanDocument = true;
        public bool CanDocument
        {
            get
            {
                return m_CanDocument;
            }
            set
            {
                m_CanDocument = value;
            }
        }

        private bool m_CanDrag = true;
        public bool CanDrag
        {
            get
            {
                return m_CanDrag;
            }
            set
            {
                m_CanDrag = value;
            }
        }

        private bool m_CanFloat = true;
        public bool CanFloat
        {
            get
            {
                return m_CanFloat;
            }
            set
            {
                m_CanFloat = value;
            }
        }

        private DockAbility m_DockAbility = DockAbility.All;
        public DockAbility DockAbility
        {
            get
            {
                return m_DockAbility;
            }
            set
            {
                m_DockAbility = value;
            }
        }

        private bool m_DockToFill = false;
        public bool DockToFill
        {
            get
            {
                return m_DockToFill;
            }
            set
            {
                m_DockToFill = value;
            }
        }

        private string m_Header = "";
        public string Header
        {
            get
            {
                return m_Header;
            }
            set
            {
                m_Header = value;
            }
        }

        private string m_Name = "";
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        private bool m_NoDock = false;
        public bool NoDock
        {
            get
            {
                return m_NoDock;
            }
            set
            {
                m_NoDock = value;
            }
        }

        private bool m_NoHeader = false;
        public bool NoHeader
        {
            get
            {
                return m_NoHeader;
            }
            set
            {
                m_NoHeader = value;
            }
        }

        private DockSide m_SideInDockMode = DockSide.Left;
        public DockSide SideInDockMode
        {
            get
            {
                return m_SideInDockMode;
            }
            set
            {
                m_SideInDockMode = value;
            }
        }

        private DockSide m_SideInFloatMode = DockSide.Left;
        public DockSide SideInFloatMode
        {
            get
            {
                return m_SideInFloatMode;
            }
            set
            {
                m_SideInFloatMode = value;
            }
        }

        private DockState m_State = DockState.Dock;
        public DockState State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
            }
        }

        private string m_TargetNameInDockedMode = "";
        public string TargetNameInDockedMode
        {
            get
            {
                return m_TargetNameInDockedMode;
            }
            set
            {
                m_TargetNameInDockedMode = value;
            }
        }

        private string m_TargetNameInFloatMode = "";
        public string TargetNameInFloatMode
        {
            get
            {
                return m_TargetNameInFloatMode;
            }
            set
            {
                m_TargetNameInFloatMode = value;
            }
        }

        private double m_DesiredHeightInDockedMode = 90.0;
        public double DesiredHeightInDockedMode
        {
            get
            {
                return m_DesiredHeightInDockedMode;
            }
            set
            {
                m_DesiredHeightInDockedMode = value;
            }
        }

        private double m_DesiredWidthInDockedMode = 90.0;
        public double DesiredWidthInDockedMode
        {
            get
            {
                return m_DesiredWidthInDockedMode;
            }
            set
            {
                m_DesiredWidthInDockedMode = value;
            }
        }
    }
}
