using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace SfAutoCompleteDemo
{
    public class ViewModel : NotificationObject
    {
        #region Properties      
       

        private AutoCompleteMode autoCompleteMode = AutoCompleteMode.SuggestAppend;

        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return autoCompleteMode;
            }
            set
            {
                autoCompleteMode = value;
                RaisePropertyChanged("AutoCompleteMode");
            }
        }

        private ObservableCollection<Person> images;

        public ObservableCollection<Person> Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value;
            }
        }

        #endregion

        public ViewModel()
        {
            Images = new ObservableCollection<Person>();
            Images.Add(new Person("Eric Joplin", "/Assets/Emp_02.png", 0.0, "Chairman", "Management", "27/09/1973", "Boston", "+800 9899 9929", "ericjoplin@syncfusion.com", "#FFA400", "#E78E00"));
            Images.Add(new Person("Paul Vent", "/Assets/Emp_04.png", 0.0, "Chief Executive Officer", "Management", "27/09/1975", "New York", "+800 9899 9930", "paulvent@syncfusion.com", "#6DA4A3", "#4E7F7D"));
            Images.Add(new Person("Clara Venus", "/Assets/Emp_06.png", 0.0, "Chief Executive Assistant", "Management", "27/09/1978", "California", "+800 9899 9931", "claravenus@syncfusion.com", "#A45378", "#883F64"));
            Images.Add(new Person("Maria Even", "/Assets/Emp_11.png", 0.0, "Executive Manager", "Operational Unit", "27/09/1970", "New York", "+800 9899 9932", "mariaeven@syncfusion.com", "#DA9545", "#BB7731"));
            Images.Add(new Person("Mark Zuen", "/Assets/Emp_13.png", 0.0, "Senior Executive", "Operational Unit", "27/09/1983", "Boston", "+800 9899 9933", "markzuen@syncfusion.com", "#AC3832", "#8B2826"));
            Images.Add(new Person("Robin Rane", "/Assets/Emp_16.png", 0.0, "Manager", "Customer Service", "27/09/1985", "New Jersey", "+800 9899 9934", "robinrane@syncfusion.com", "#31A1FF", "#2394E1"));
            Images.Add(new Person("Chris Marker", "/Assets/Emp_21.png", 0.0, "Team Manager", "Customer Service", "27/09/1963", "California", "+800 9899 9935", "chrismarker@syncfusion.com", "#5B5BA9", "#484892"));
            Images.Add(new Person("Seria Sum", "/Assets/Emp_23.png", 0.0, "Coordinator", "Customer Service", "27/09/1961", "New York", "+800 9899 9936", "seriasum@syncfusion.com", "#597C2A", "#46601D"));
            Images.Add(new Person("Mathew Fleming", "/Assets/Emp_25.png", 0.0, "Recruitment Manager", "Human Resource", "27/09/1986", "Boston", "+800 9899 9937", "mathewdfleming@syncfusion.com", "#BCCBD3", "#8BA0A9"));
            Images.Add(new Person("Steven Joplin", "/Assets/Emp_02.png", 0.0, "Chairman", "Management", "27/09/1973", "Boston", "+800 9899 9929", "ericjosplin@syncfusion.com", "#FFA400", "#E78E00"));
            Images.Add(new Person("Carl Vent", "/Assets/Emp_04.png", 0.0, "Chief Executive Officer", "Management", "27/09/1975", "New York", "+800 9899 9930", "paulavent@syncfusion.com", "#6DA4A3", "#4E7F7D"));
            Images.Add(new Person("James Venus", "/Assets/Emp_06.png", 0.0, "Chief Executive Assistant", "Management", "27/09/1978", "California", "+800 9899 9931", "clarahvenus@syncfusion.com", "#A45378", "#883F64"));
            Images.Add(new Person("Maria Strauss", "/Assets/Emp_11.png", 0.0, "Executive Manager", "Operational Unit", "27/09/1970", "New York", "+800 9899 9932", "mariaveven@syncfusion.com", "#DA9545", "#BB7731"));
            Images.Add(new Person("Kate Zuen", "/Assets/Emp_13.png", 0.0, "Senior Executive", "Operational Unit", "27/09/1983", "Boston", "+800 9899 9933", "markrzuen@syncfusion.com", "#AC3832", "#8B2826"));
            Images.Add(new Person("Niko Rane", "/Assets/Emp_16.png", 0.0, "Manager", "Customer Service", "27/09/1985", "New Jersey", "+800 9899 9934", "robinxrane@syncfusion.com", "#31A1FF", "#2394E1"));
            Images.Add(new Person("Chris gayle", "/Assets/Emp_21.png", 0.0, "Team Manager", "Customer Service", "27/09/1963", "California", "+800 9899 9935", "chriswmarker@syncfusion.com", "#5B5BA9", "#484892"));
            Images.Add(new Person("Sloth Sum", "/Assets/Emp_23.png", 0.0, "Coordinator", "Customer Service", "27/09/1961", "New York", "+800 9899 9936", "seriaqsum@syncfusion.com", "#597C2A", "#46601D"));
            Images.Add(new Person("Thomas Fleming", "/Assets/Emp_25.png", 0.0, "Recruitment Manager", "Human Resource", "27/09/1986", "Boston", "+800 9899 9937", "mathewsfleming@syncfusion.com", "#BCCBD3", "#8BA0A9"));
        }
      
    }
}
