using Syncfusion.Windows.Shared;
using System.Collections.Generic;
using System.Windows.Media;

namespace PMMLWPFSampleBrowser
{
    /// <summary>
    /// Hold the Model information
    /// </summary>
    public class Model : NotificationObject
    {
        public string Name { get; set; }

        public bool IsExpanded { get; set; }

        public string Tag { get; set; }

        public List<Sample> SampleCollection { get; set; }
    }
}