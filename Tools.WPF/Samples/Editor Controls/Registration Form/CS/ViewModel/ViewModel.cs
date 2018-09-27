using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Syncfusion.Windows.Shared;

namespace EditorControlsDemo
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            ModelPerson = new Person();

        }

        private Person _modelPerson;
        public Person ModelPerson
        {
            get { return _modelPerson; }
            set
            {
                _modelPerson = value;
                this.RaisePropertyChanged(() => this.ModelPerson);
            }
        }


        private ICommand registerCommand;
        public ICommand RegisterCommand
        {
            get
            {
                if (registerCommand == null)
                {
                    registerCommand = new DelegateCommand<object>(SaveAll);
                }
                return registerCommand;
            }

        }
        public void SaveAll(object param)
        {
            ModelPerson.Fo();
        }


    }

}


