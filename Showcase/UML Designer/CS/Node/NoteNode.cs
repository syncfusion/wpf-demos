#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramDesigner
{
    public class NoteNode : INotifyPropertyChanged,INode
    {
        private string m_Note = "Note";

        public string Note
        {
            get { return m_Note; }
            set
            {
                if (m_Note != value)
                {
                    m_Note = value;
                    OnPropertyChanged("Note");
                }
            }
        }

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

        private string m_Background = "#FF25A0DA";

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
