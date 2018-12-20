#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Chart;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace ZoomingAndScrolling
{
    class DemoBehaviors : Behavior<Window1>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);
           
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.combo_zoomin.SelectionChanged += new SelectionChangedEventHandler(combo_zoomin_SelectionChanged);
            this.AssociatedObject.combo_zoomout.SelectionChanged += new SelectionChangedEventHandler(combo_zoomout_SelectionChanged);
            this.AssociatedObject.Combo_Pan.SelectionChanged += new SelectionChangedEventHandler(Combo_Pan_SelectionChanged);
            this.AssociatedObject.Chart1.Areas[0].PrimaryAxis.Changed += new EventHandler(PrimaryAxis_Changed);
            this.AssociatedObject.Chart1.Areas[0].SecondaryAxis.Changed += new EventHandler(SecondaryAxis_Changed);
            this.AssociatedObject.chk_zoombutton1.Checked += new RoutedEventHandler(chk_zoombutton1_Checked);
            this.AssociatedObject.chk_zoombutton1.Unchecked += new RoutedEventHandler(chk_zoombutton1_Unchecked);
        }

        void chk_zoombutton1_Unchecked(object sender, RoutedEventArgs e)
        {
            ChartAreaCommands.CancelZooming.Execute(null, this.AssociatedObject.syncChart);
        }

        void chk_zoombutton1_Checked(object sender, RoutedEventArgs e)
        {
            ChartAreaCommands.SwitchZooming.Execute(null, this.AssociatedObject.syncChart);            
        }

        void check1_Unchecked(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.syncChart.EnableMouseDragZooming = false;
        }

        void check1_Checked(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.syncChart.EnableMouseDragZooming = true;
        }

        void SecondaryAxis_Changed(object sender, EventArgs e)
        {
            if (this.AssociatedObject.combo_zoomfactorY != null)
                this.AssociatedObject.combo_zoomfactorY.SelectedItem = Math.Round(this.AssociatedObject.Chart1.Areas[0].SecondaryAxis.ZoomFactor, 1).ToString();
        }

        void PrimaryAxis_Changed(object sender, EventArgs e)
        {
            if (this.AssociatedObject.combo_zoomfactorX != null)
                this.AssociatedObject.combo_zoomfactorX.SelectedItem = Math.Round(this.AssociatedObject.Chart1.Areas[0].PrimaryAxis.ZoomFactor, 1).ToString();  
        }

        void Combo_Pan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            keyEvent();
        }

        void combo_zoomout_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            keyEvent();
        }

        void combo_zoomin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            keyEvent();
        }

        public void keyEvent()
        {
            this.AssociatedObject.InputBindings.Clear();
            KeyGesture gesture = null;
            KeyGesture gesture1 = null;
            //InputBindings.Clear();
            if (this.AssociatedObject.combo_zoomout != null)
            {
                if(this.AssociatedObject.combo_zoomout.SelectedItem != null)
                switch (this.AssociatedObject.combo_zoomout.SelectedItem.ToString())
                {

                    case "-":
                        gesture = new KeyGesture(Key.OemMinus);
                        gesture1 = new KeyGesture(System.Windows.Input.Key.Subtract);
                        break;
                    case "Alt + O":
                        gesture = new KeyGesture(Key.O, ModifierKeys.Alt);
                        break;
                }

                try
                {
                    if (gesture1 != null)
                    {
                        KeyBinding zoomOutGesture1 = new KeyBinding(ChartAreaCommands.ZoomOut, gesture1) { CommandTarget = this.AssociatedObject.Chart1.Areas[0] };
                        this.AssociatedObject.InputBindings.Add(zoomOutGesture1);
                    }
                    KeyBinding zoomOutGesture = new KeyBinding(ChartAreaCommands.ZoomOut, gesture) { CommandTarget = this.AssociatedObject.Chart1.Areas[0] };
                    this.AssociatedObject.InputBindings.Add(zoomOutGesture);

                }
                catch (Exception) { }
            }
            KeyGesture gesture2 = null;
            KeyGesture gesture3 = null;
            if (this.AssociatedObject.combo_zoomin != null)
            {
                switch (this.AssociatedObject.combo_zoomin.SelectedItem.ToString())
                {

                    case "+":
			            gesture2 = new KeyGesture(Key.OemPlus, ModifierKeys.Shift);
                        gesture3 = new KeyGesture(System.Windows.Input.Key.Add);
                        break;
                    case "Alt + I":
                        gesture2 = new KeyGesture(Key.I, ModifierKeys.Alt);
                        break;
                }

                try
                {
                    KeyBinding zoomInGesture = new KeyBinding(ChartAreaCommands.ZoomIn, gesture2) { CommandTarget = this.AssociatedObject.Chart1.Areas[0] };
                    if (gesture3 != null)
                    {
                        KeyBinding zoomInGesture1 = new KeyBinding(ChartAreaCommands.ZoomIn, gesture3) { CommandTarget = this.AssociatedObject.Chart1.Areas[0] };
                        this.AssociatedObject.InputBindings.Add(zoomInGesture1);
                    }
                    this.AssociatedObject.InputBindings.Add(zoomInGesture);

                }
                catch (Exception) { }
            }
            KeyGesture gesture4 = null;
            if (this.AssociatedObject.Combo_Pan != null)
            {
                if(this.AssociatedObject.Combo_Pan.SelectedItem != null)
                switch (this.AssociatedObject.Combo_Pan.SelectedItem.ToString())
                {
                    default:
                    case ",":
                        gesture4 = new KeyGesture(Key.OemComma);
                        break;
                    case "Alt + P":
                        gesture4 = new KeyGesture(Key.P, ModifierKeys.Alt);
                        break;
                }

                KeyBinding pan = new KeyBinding(ChartAreaCommands.ZoomPanning, gesture4) { CommandTarget = this.AssociatedObject.Chart1.Areas[0] };
                this.AssociatedObject.InputBindings.Add(pan);
            }
        }
    }
}
