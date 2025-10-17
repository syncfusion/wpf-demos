using System;

namespace syncfusion.visualstudiodemo.wpf
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
