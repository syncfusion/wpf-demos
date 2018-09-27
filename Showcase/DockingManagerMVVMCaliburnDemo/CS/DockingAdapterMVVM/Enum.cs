using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockingAdapterMVVM
{
    public enum DockState
    {
        Dock,
        Document,
        Float,
        AutoHidden,
        Hidden
    }

    public enum DockSide
    {
        Bottom,
        Left,
        None,
        Right,
        Tabbed,
        Top
    }

    public enum DockAbility
    {
        All,
        Bottom,
        Horizontal,
        Left,
        None,
        Right,
        Tabbed,
        Top,
        Vertical
    }
}
