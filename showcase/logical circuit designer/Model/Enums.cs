#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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

namespace syncfusion.logicalcircuitdesigner.wpf.Model
{
    public enum BinaryState
    {
        Zero = 0,
        One = 1,
    }

    public static class Constants
    {
        //Connector style
        public const string DefaultConnectorStyle = "DefaultConnectorStyle";
        public const string ActiveConnectorStyle = "ActiveConnectorStyle";

        //Output constants
        public const string DefaultLightBulb = "LightBulbNode";
        public const string ActiveLightBulb = "LightBulbOn";

        //Input constants
        public const string DefaultToggleSwitch = "Toggle_switchNode";
        public const string ActiveToogleSwitch = "ToggleSwitchOn";
        public const string DefaultPushButton = "Push_buttonNode";
        public const string ActivePushButton = "PushButtonON";
        public const string DefaultClockSwitch = "ClockNode";
        public const string ActiveClockSwitch = "ClockNodeON";

        //Gate constants
        public const string AndGate = "ANDGateNode";
        public const string NANDGate = "NANDGateNode";
        public const string NOTGate = "NOTGateNode";
        public const string BufferGate = "BufferNode";
        public const string ORGate = "ORGateNode";
        public const string NORGate = "NORGateNode";
        public const string XORGate = "XORGateNode";
        public const string XNORGate = "XNORNode";
        public const string TriState = "Tri-StateNode";
        public const string BusGate = "BusNode";

        //Flip flop gates
        public const string SRFlipFlop = "SRFlip-FlopNode";
        public const string DFlipFlop = "DFlip-FlopNode";
        public const string JKFlipFlop = "JKFlip-FlopNode";
        public const string TFlipFlop = "TFlip-FlopNode";


        public const string Timer = "Timer";
        
    }
}
