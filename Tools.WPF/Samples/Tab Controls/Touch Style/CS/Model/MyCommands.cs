using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using Syncfusion.Windows.Shared;

namespace TabControlTouchDemo
{
    public class MyCommands
    {
        public static readonly ICommand CloseCommand = new DelegateCommand<object>(o => ((Window)o).Close());
        public static readonly ICommand MinimizeCommand = new DelegateCommand<object>(o => ((Window)o).WindowState = WindowState.Minimized);
    }
}
