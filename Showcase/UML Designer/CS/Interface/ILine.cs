using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramDesigner
{
    public interface ILine
    {
        string HeadID { get; set; }
        string TailID { get; set; }
    }
}
