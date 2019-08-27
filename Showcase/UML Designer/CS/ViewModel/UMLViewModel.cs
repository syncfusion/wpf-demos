#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DiagramFrontPageUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UMLDiagramDesigner
{
    public class UMLViewModel :DiagramCommonViewModel
    {
        private ICommand m_Undo;

        public ICommand Undo
        {
            get { return m_Undo; }
            set
            {
                if (m_Undo != value)
                {
                    m_Undo = value;
                    OnPropertyChanged("Undo");
                }
            }
        }

        private ICommand m_Redo;

        public ICommand Redo
        {
            get { return m_Redo; }
            set
            {
                if (m_Redo != value)
                {
                    m_Redo = value;
                    OnPropertyChanged("Redo");
                }
            }
        }

        private ICommand m_Clear;

        public ICommand Clear
        {
            get { return m_Clear; }
            set
            {
                if (m_Clear != value)
                {
                    m_Clear = value;
                    OnPropertyChanged("Clear");
                }
            }
        }

        private ICommand m_AddINodeType;

        public ICommand AddINodeType
        {
            get { return m_AddINodeType; }
            set
            {
                if (m_AddINodeType != value)
                {
                    m_AddINodeType = value;
                    OnPropertyChanged("AddINodeType");
                }
            }
        }

        private ICommand m_Back;

        public ICommand Back
        {
            get { return m_Back; }
            set
            {
                if (m_Back != value)
                {
                    m_Back = value;
                    OnPropertyChanged("Back");
                }
            }
        }

        private ICommand m_Save;

        public ICommand Save
        {
            get { return m_Save; }
            set
            {
                if (m_Save != value)
                {
                    m_Save = value;
                    OnPropertyChanged("Save");
                }
            }
        }

        private ICommand m_Load;

        public ICommand Load
        {
            get { return m_Load; }
            set
            {
                if (m_Load != value)
                {
                    m_Load = value;
                    OnPropertyChanged("Load");
                }
            }
        }

        private ICommand m_Split;

        public ICommand Split
        {
            get { return m_Split; }
            set
            {
                if (m_Split != value)
                {
                    m_Split = value;
                    OnPropertyChanged("Split");
                }
            }
        }

        private ICommand m_Delete;

        public ICommand Delete
        {
            get { return m_Delete; }
            set
            {
                if (m_Delete != value)
                {
                    m_Delete = value;
                    OnPropertyChanged("Delete");
                }
            }
        }

        private ICommand m_ShowProperties;

        public ICommand ShowProperties
        {
            get { return m_ShowProperties; }
            set
            {
                if (m_ShowProperties != value)
                {
                    m_ShowProperties = value;
                    OnPropertyChanged("ShowProperties");
                }
            }
        }

        private ICommand m_Connector;

        public ICommand Connector
        {
            get { return m_Connector; }
            set
            {
                if (m_Connector != value)
                {
                    m_Connector = value;
                    OnPropertyChanged("Connector");
                }
            }
        }

        private string m_CurrentlyLoaded;

        public string CurrentlyLoaded
        {
            get { return m_CurrentlyLoaded; }
            set
            {
                if (m_CurrentlyLoaded != value)
                {
                    m_CurrentlyLoaded = value;
                    OnPropertyChanged("CurrentlyLoaded");
                }
            }
        }

        private object _SelectedObject;

        public object SelectedObject
        {
            get
            {
                return _SelectedObject;
            }
            set
            {
                _SelectedObject = value;
                OnPropertyChanged("SelectedObject");
                OnPropertyChanged("Connector");
                OnPropertyChanged("ShowProperties");
                OnPropertyChanged("Delete");
                OnPropertyChanged("Split");
            }
        }

        private ICommand m_GoBack;

        public ICommand GoBack
        {
            get { return m_GoBack; }
            set
            {
                if (m_GoBack != value)
                {
                    m_GoBack = value;
                    OnPropertyChanged("GoBack");
                }
            }
        }

        private ICommand m_PageEditing;

        public ICommand PageEditing
        {
            get { return m_PageEditing; }
            set
            {
                if (m_PageEditing != value)
                {
                    m_PageEditing = value;
                    OnPropertyChanged("PageEditing");
                }
            }
        }

        private ICommand m_ZoomEnabled;

        public ICommand ZoomEnabled
        {
            get { return m_ZoomEnabled; }
            set
            {
                if (m_ZoomEnabled != value)
                {
                    m_ZoomEnabled = value;
                    OnPropertyChanged("ZoomEnabled");
                }
            }
        }

        private ICommand m_PanEnabled;

        public ICommand PanEnabled
        {
            get { return m_PanEnabled; }
            set
            {
                if (m_PanEnabled != value)
                {
                    m_PanEnabled = value;
                    OnPropertyChanged("PanEnabled");
                }
            }
        }

        private bool isedit=true;

        public bool IsPageEdit
        {
            get
            {
                return isedit;
            }
            set
            {
                if (isedit != value)
                {
                    isedit = value;
                    OnPropertyChanged("IsPageEdit");
                }
            }
        }

        private bool _mIsZoomEnabled = true;

        public bool IsZoomEnabled
        {
            get
            {
                return _mIsZoomEnabled;
            }
            set
            {
                if (_mIsZoomEnabled != value)
                {
                    _mIsZoomEnabled = value;
                    OnPropertyChanged("IsZoomEnabled");
                }
            }
        }


        private bool ispan = true;

        public bool IsPanEnabled
        {
            get
            {
                return ispan;
            }
            set
            {
                if (ispan != value)
                {
                    ispan = value;
                    OnPropertyChanged("IsPanEnabled");
                }
            }
        }
    }
}
