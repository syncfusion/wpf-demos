using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace WindowsExplorerDemo
{
    public interface IFile 
    {
        string Name { get; set; }

        DateTime DateModified { get; set; }

        string FileType { get; set; }

        double Size { get; set; }

        object Info { get; set; }

        ImageSource Icon { get; set; }

        bool IsSelected { get; set; }
    }
}
