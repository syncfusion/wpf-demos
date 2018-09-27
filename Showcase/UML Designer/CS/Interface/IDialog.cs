using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramDesigner
{
    public interface IDialog
    {
        DialogResult DialogResult { get; set; }

        Task<DialogResult> ShowDialog();

        event EventHandler DialogResultChanged;
    }
}
