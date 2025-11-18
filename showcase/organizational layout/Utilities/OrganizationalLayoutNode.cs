#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.UI.Xaml.Diagram;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.organizationallayout.wpf
{
    public class organizationallayoutNode : NodeViewModel
    {
        private CustomContent _customContent;
        private string _templatename = "ImageTopTemplate";

        public organizationallayoutNode() : base()
        {
            
        }
        

        [DataMember]
        public CustomContent CustomContent
        {
            get { return _customContent; }
            set
            {
                if (_customContent != value)
                {
                    _customContent = value;
                    Content = CustomContent;
                    OnPropertyChanged("Content");
                }
            }
        }

        [DataMember]
        public string TemplateName
        {
            get { return _templatename; }
            set
            {
                if (_templatename != value)
                {
                    _templatename = value;
                    OnPropertyChanged("TemplateName");
                }
            }
        }       
    }

    [DataContract]
    public class CustomContent : INotifyPropertyChanged
    {

        private double _imagevisibility = 100;

        [DataMember]
        public double ImageVisibility
        {
            get { return _imagevisibility; }
            set
            {
                if (_imagevisibility != value)
                {
                    _imagevisibility = value;
                    OnPropertyChanged("ImageVisibility");
                }
            }
        }

        private SolidColorBrush strokeColor = new SolidColorBrush(Colors.Gray);

        [DataMember]
        public SolidColorBrush StrokeColor
        {
            get
            {
                return strokeColor;
            }
            set
            {
                if (strokeColor != value)
                {
                    this.strokeColor = value;
                    this.OnPropertyChanged("StrokeColor");
                }
            }
        }

        private SolidColorBrush fillColor = new SolidColorBrush(Colors.White);

        [DataMember]
        public SolidColorBrush FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                if (fillColor != value)
                {
                    this.fillColor = value;
                    this.OnPropertyChanged("FillColor");
                }
            }
        }

        private SolidColorBrush prevfillColor = new SolidColorBrush(Colors.White);

        [DataMember]
        public SolidColorBrush PrevFillColor
        {
            get
            {
                return prevfillColor;
            }
            set
            {
                if (prevfillColor != value)
                {
                    this.prevfillColor = value;
                    this.OnPropertyChanged("PrevFillColor");
                }
            }
        }

        private SolidColorBrush selectionColor = new SolidColorBrush(Colors.Red);

        [DataMember]
        public SolidColorBrush SelectionColor
        {
            get
            {
                return selectionColor;
            }
            set
            {
                if (selectionColor != value)
                {
                    this.selectionColor = value;
                    this.OnPropertyChanged("SelectionColor");
                }
            }
        }


        private string _name = "Name";

        private bool _NameSelected = true;
        [DataMember]
        public bool NameSelected
        {
            get { return _NameSelected; }
            set
            {
                _NameSelected = value;
                OnPropertyChanged("NameSelected");
            }

        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private bool _RoleSelected = true;
        [DataMember]
        public bool RoleSelected
        {
            get { return _RoleSelected; }
            set
            {
                _RoleSelected = value;
                OnPropertyChanged("RoleSelected");
            }

        }

        private string _role = "Designation";

        [DataMember]
        public string Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged("Role");
                }
            }
        }

        private bool _EMPIDSelected = false;
        [DataMember]
        public bool EMPIDSelected
        {
            get { return _EMPIDSelected; }
            set
            {
                _EMPIDSelected = value;
                OnPropertyChanged("EMPIDSelected");
            }

        }

        private string _empid = "Emp ID";

        [DataMember]
        public string EmployeeID
        {
            get { return _empid; }
            set
            {
                if (_empid != value)
                {
                    _empid = value;
                    OnPropertyChanged("EmployeeID");
                }
            }
        }


        private bool _TeamSelected = false;
        [DataMember]
        public bool TeamSelected
        {
            get { return _TeamSelected; }
            set
            {
                _TeamSelected = value;
                OnPropertyChanged("TeamSelected");
            }

        }

        private string _team = "Team";

        [DataMember]
        public string Team
        {
            get { return _team; }
            set
            {
                if (_team != value)
                {
                    _team = value;
                    OnPropertyChanged("Team");
                }
            }
        }

        private bool _MailSelected = false;
        [DataMember]
        public bool MailSelected
        {
            get { return _MailSelected; }
            set
            {
                _MailSelected = value;
                OnPropertyChanged("MailSelected");
            }

        }

        private string _email = "Email";

        [DataMember]
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private bool _PhoneSelected = false;
        [DataMember]
        public bool PhoneSelected
        {
            get { return _PhoneSelected; }
            set
            {
                _PhoneSelected = value;
                OnPropertyChanged("PhoneSelected");
            }

        }

        private string _phonenumber = "Phone Number";

        [DataMember]
        public string PhoneNumber
        {
            get { return _phonenumber; }
            set
            {
                if (_phonenumber != value)
                {
                    _phonenumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        private bool _DirectControlSelected = false;
        [DataMember]
        public bool DirectControlSelected
        {
            get { return _DirectControlSelected; }
            set
            {
                _DirectControlSelected = value;
                OnPropertyChanged("DirectControlSelected");
            }

        }

        private string _directcontrol = "DirectControl";

        [DataMember]
        public string DirectControl
        {
            get { return _directcontrol; }
            set
            {
                if (_directcontrol != value)
                {
                    _directcontrol = value;
                    OnPropertyChanged("DirectControl");
                }
            }
        }

        private bool _TierSelected = false;
        [DataMember]
        public bool TierSelected
        {
            get { return _TierSelected; }
            set
            {
                _TierSelected = value;
                OnPropertyChanged("TierSelected");
            }

        }


        private string _tier = "Tier";

        [DataMember]
        public string Tier
        {
            get { return _tier; }
            set
            {
                if (_tier != value)
                {
                    _tier = value;
                    OnPropertyChanged("Tier");
                }
            }
        }

        private string _image = "/Asset/male.png";

        [DataMember]
        public string Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

        private object _templatecolor = "#FF4F88BB";

        [DataMember]
        public object Templatecolor
        {
            get { return _templatecolor; }
            set
            {
                if (_templatecolor != value)
                {
                    _templatecolor = value;
                    OnPropertyChanged("Templatecolor");
                }
            }
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
