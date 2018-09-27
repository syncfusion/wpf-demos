using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramDesigner
{
    public enum LineType
    {
        Inheritance,
        AggregateOrAssociate,
        Note,
        None
    }

    public enum Inheritance
    {
        Generalization,
        Realization
    }

    public enum Aggregation
    {
        Basic,
        Composition,
        None
    }

    public enum Association
    {
        UniDirectional,
        BiDirectional
    }
}
