using Syncfusion.Windows.Controls.Gantt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.ganttdemos.wpf
{
    public class ExportToImageViewModel : ProjectGanttTaskRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ExportToImageViewModel()
        {
            _taskCollection = this.GetData();
            _teamDetails = GetTeamInfo();
        }

        private ObservableCollection<TaskDetails> _taskCollection;

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<TaskDetails> TaskCollection
        {
            get
            {
                return _taskCollection;
            }
            set
            {
                _taskCollection = value;
            }
        }

        private ObservableCollection<ExportToImageModel> _teamDetails;

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<ExportToImageModel> TeamDetails
        {
            get
            {
                return _teamDetails;
            }
            set
            {
                _teamDetails = value;
            }
        }

        internal void Dispose()
        {
            foreach(var teamDetail in TeamDetails)
            {
                teamDetail.Dispose();
            }
        }
    }
}