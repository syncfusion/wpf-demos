using System;

namespace syncfusion.weatheranalysis.wpf
{
    public class SelectionChangedEventArgs<T> : EventArgs
    {
        public T Payload { get; set; }
    }
}
