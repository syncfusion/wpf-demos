using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockingManagerMVVMCaliburnMicro
{
    public class ErrorListModel
    {
        public String Number { get; set; }
        public String Description { get; set; }
        public String File { get; set; }
        public String Line { get; set; }
        public String Column { get; set; }
        public String Project { get; set; }
        public ErrorListModel()
        {
        }
    }
}
