#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DockingAdapterMVVM
{
    public interface IChildrenElement
    {
        bool CanAutoHide { get; set; }

        bool CanClose { get; set; }

        bool CanDock { get; set; }

        bool CanDocument { get; set; }

        bool CanDrag { get; set; }

        bool CanFloat { get; set; }

        double DesiredHeightInDockedMode { get; set; }

        double DesiredWidthInDockedMode { get; set; }

        DockAbility DockAbility { get; set; }

        bool DockToFill { get; set; }

        string Header{get;set;}

        string Name { get; set; }

        bool NoDock { get; set; }

        bool NoHeader { get; set; }

        DockSide SideInDockMode { get; set; }

        DockSide SideInFloatMode { get; set; }

        DockState State { get; set; }

        string TargetNameInDockedMode { get; set; }

        string TargetNameInFloatMode{get;set;}
    }
}
