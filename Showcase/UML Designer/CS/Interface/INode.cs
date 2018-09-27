using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramDesigner
{
    public interface INode
    {
        string ID { get; set; }
        double X { get; set; }
        double Y { get; set; }
    }
}
