#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.Practices.Composite.Presentation.Events;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Represents the Account selected event.
    /// </summary>
    public class Events : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the Stock selected event.
    /// </summary>
    public class StockSelectedEvent : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the Animation Activation event.
    /// </summary>
    public class AnimationEvents : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the Animation type selected event.
    /// </summary>
    public class AnimationTypesEvents : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the Dashboard View Animation Activation event.
    /// </summary>
    public class DashboardAnimationEvents : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the ThreeD View Mode Activation event.
    /// </summary>
    public class ThreeDEvent : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the Selected View Activation event.
    /// </summary>
    public class SelectedViewEvents : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the Stock LiveUpdate event.
    /// </summary>
    public class StartStopUpdateEvent : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the Stock LiveUpdate event.
    /// </summary>
    public class ShowHideGroupingEvent : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the SkinChanged event.
    /// </summary>
    public class SkinChangedEvent : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the ChartTypeChanged event.
    /// </summary>
    public class ChartTypesEvent : CompositePresentationEvent<string>
    {
    }
}
