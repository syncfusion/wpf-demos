using System.Windows.Input;
using Syncfusion.Windows.Shared;

namespace syncfusion.editordemos.wpf
{
    public class RegistrationFormViewModel : NotificationObject
    {
        public RegistrationFormViewModel()
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


