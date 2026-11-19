namespace syncfusion.visualstudiodemo.wpf
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

        string Header { get; set; }

        string Name { get; set; }

        bool NoDock { get; set; }

        bool NoHeader { get; set; }

        DockSide SideInDockMode { get; set; }

        DockSide SideInFloatMode { get; set; }

        DockState State { get; set; }

        string TargetNameInDockedMode { get; set; }

        string TargetNameInFloatMode { get; set; }
    }
}
