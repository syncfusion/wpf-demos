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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace UMLDiagramDesigner
{
    public class InterfaceNode : INotifyPropertyChanged, INode
    {
        public InterfaceNode()
        {
            Properties = new ObservableCollection<Property>();
            Functions = new ObservableCollection<Property>();
            this.AddProperty = new DelegateCommand<InterfaceNode>(OnAddProperty);
            this.DeleteProperty = new DelegateCommand<Property>(OnDeleteProperty);
            this.AddFunction = new DelegateCommand<InterfaceNode>(OnAddFunction);
            this.DeleteFunction = new DelegateCommand<Property>(OnDeleteFunction);
        }

        private string m_Name;
        private ObservableCollection<Property> m_Properties;
        private ObservableCollection<Property> m_Functions;
        private ICommand m_AddProperty;
        private ICommand m_DeleteProperty;
        private ICommand m_AddFunction;
        private ICommand m_DeleteFunction;
        private string m_Background = "#FF25A0DA";

        private double m_X;

        public double X
        {
            get { return m_X; }
            set
            {
                if (m_X != value)
                {
                    m_X = value;
                    OnPropertyChanged("X");
                }
            }
        }

        private double m_Y;

        public double Y
        {
            get { return m_Y; }
            set
            {
                if (m_Y != value)
                {
                    m_Y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        public string ID { get; set; }

        public string Name
        {
            get { return m_Name; }
            set
            {
                if (m_Name != value)
                {
                    m_Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private bool m_IsPropertiesEnabled = true;

        public bool IsPropertiesEnabled
        {
            get { return m_IsPropertiesEnabled; }
            set
            {
                if (m_IsPropertiesEnabled != value)
                {
                    m_IsPropertiesEnabled = value;
                    OnPropertyChanged("IsPropertiesEnabled");
                }
            }
        }

        private bool m_IsOperationsEnabled = true;

        public bool IsOperationsEnabled
        {
            get { return m_IsOperationsEnabled; }
            set
            {
                if (m_IsOperationsEnabled != value)
                {
                    m_IsOperationsEnabled = value;
                    OnPropertyChanged("IsOperationsEnabled");
                }
            }
        }

        public string Background
        {
            get { return m_Background; }
            set
            {
                if (m_Background != value)
                {
                    m_Background = value;
                    OnPropertyChanged("Background");
                }
            }
        }

        public ObservableCollection<Property> Properties
        {
            get { return m_Properties; }
            set
            {
                if (m_Properties != value)
                {
                    m_Properties = value;
                    OnPropertyChanged("Properties");
                }
            }
        }

        public ObservableCollection<Property> Functions
        {
            get { return m_Functions; }
            set
            {
                if (m_Functions != value)
                {
                    m_Functions = value;
                    OnPropertyChanged("Funtions");
                }
            }
        }

        [XmlIgnore]
        public ICommand AddProperty
        {
            get { return m_AddProperty; }
            set
            {
                if (m_AddProperty != value)
                {
                    m_AddProperty = value;
                    OnPropertyChanged("AddProperty");
                }
            }
        }

        private void OnAddProperty(InterfaceNode newProperty)
        {
            Properties.Add(new Property { Name = "+Property1" });
        }

        [XmlIgnore]
        public ICommand DeleteProperty
        {
            get { return m_DeleteProperty; }
            set
            {
                if (m_DeleteProperty != value)
                {
                    m_DeleteProperty = value;
                    OnPropertyChanged("DeleteProperty");
                }
            }
        }

        private void OnDeleteProperty(Property existingProperty)
        {
            int index = Properties.IndexOf(existingProperty);
            Properties.RemoveAt(index);
        }

        [XmlIgnore]
        public ICommand AddFunction
        {
            get { return m_AddFunction; }
            set
            {
                if (m_AddFunction != value)
                {
                    m_AddFunction = value;
                    OnPropertyChanged("AddFunction");
                }
            }
        }

        private void OnAddFunction(InterfaceNode newProperty)
        {
            Functions.Add(new Property { Name = "Function1()" });
        }

        [XmlIgnore]
        public ICommand DeleteFunction
        {
            get { return m_DeleteFunction; }
            set
            {
                if (m_DeleteFunction != value)
                {
                    m_DeleteFunction = value;
                    OnPropertyChanged("DeleteFunction");
                }
            }
        }

        private void OnDeleteFunction(Property existingProperty)
        {
            int index = Functions.IndexOf(existingProperty);
            Functions.RemoveAt(index);
        }

        protected virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
