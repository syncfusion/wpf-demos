using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Xml;
using System.ComponentModel;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Threading;

namespace AutoHideDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Private Members

        /// <summary>
        /// Private Members
        /// </summary>
        private const String DefaultName = "Default";
        private const String BlendName = "Blend";
        private const String Office2007Blue = "Office2007Blue";
        private const String Office2007Black = "Office2007Black";
        private const String Office2007Silver = "Office2007Silver";
        private Random rand;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for window1.
        /// </summary>

        public Window1()
        {
            InitializeComponent();
            InitializeLog();
        }
        /// <summary>
        /// Initialization while creating object
        /// </summary>  
        public void InitializeLog()
        {
            // Define the Height and Width of the window
            window1.Width = System.Windows.SystemParameters.PrimaryScreenWidth * (0.67);
            window1.Height = System.Windows.SystemParameters.PrimaryScreenHeight * (0.67);
            // Set the random number
            rand = new Random(300);
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// GetIndent method
        /// </summary>
        /// <param name="level"></param>

        string GetIndent(int level)
        {
            string str = "";
            for (int i = 0; i < level; i++)
            {
                str += "  ";
            }
            return str;
        }
        /// <summary>
        /// Set format size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private string FormatSize(Size size)
        {
            return size.Width.ToString(".000") + ";" + size.Height.ToString(".000");
        }
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }
        /// <summary>
        /// Onclosing the dock window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            this.dockingManager.PersistState = false;
            base.OnClosing(e);
        }
        /// <summary>
        /// Close the tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Active(object sender, RoutedEventArgs e)
        {
            CloseAll.IsChecked = false;
            this.dockingManager.CloseTabs = CloseTabsMode.CloseActive;
            UpdateDefault(CloseAll.Parent as MenuItem, 0);
        }

        /// <summary>
        /// Close all the tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_All(object sender, RoutedEventArgs e)
        {
            CloseActive1.IsChecked = false;
            this.dockingManager.CloseTabs = CloseTabsMode.CloseAll;
            UpdateDefault(CloseActive1.Parent as MenuItem, 0);
        }
        /// <summary>
        /// Set visibility
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enable_VisibilityClick(object sender, RoutedEventArgs e)
        {
            Disable_Visibility1.IsChecked = false;
            dockingManager.AutoHideVisibility = true;
            UpdateDefault(Disable_Visibility1.Parent as MenuItem, 0);
        }
        /// <summary>
        /// set autohide visibility
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Disable_VisibilityClick(object sender, RoutedEventArgs e)
        {
            Enable_Visibility1.IsChecked = false;
            dockingManager.AutoHideVisibility = false;
            UpdateDefault(Enable_Visibility1.Parent as MenuItem, 0);
        }
        /// <summary>
        /// Set AutoHide tabs mode as AutoHideGroup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Auto_HideAll(object sender, RoutedEventArgs e)
        {
            AutoHideActive1.IsChecked = false;
            this.dockingManager.AutoHideTabsMode = AutoHideTabsMode.AutoHideGroup;
            UpdateDefault(AutoHideActive1.Parent as MenuItem, 1);
        }
        /// <summary>
        /// Set AutoHide tab mode as AutoHideActive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Auto_HideActive(object sender, RoutedEventArgs e)
        {
            AutoHideAll1.IsChecked = false;
            this.dockingManager.AutoHideTabsMode = AutoHideTabsMode.AutoHideActive;
            UpdateDefault(AutoHideAll1.Parent as MenuItem, 1);
        }

        /// <summary>
        /// Set animation delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SetCustomDelay();
            }
        }

        /// <summary>
        /// open the sample window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_SampleWindows(object sender, RoutedEventArgs e)
        {
            dockingManager.ActivateWindow("ListBox1");
        }
        /// <summary>
        /// open the tab window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_TaWindows(object sender, RoutedEventArgs e)
        {
            dockingManager.ActivateWindow("ListBox11");
        }
        /// <summary>
        /// open the dock window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_DockWindow1(object sender, RoutedEventArgs e)
        {
            dockingManager.ActivateWindow("ListBox2");
        }
        /// <summary>
        /// Set the TabStrip placement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_StripPlacement(object sender, RoutedEventArgs e)
        {
            //Dock Tab Alignment
            MenuItem mi = (MenuItem)e.OriginalSource;
            string g = mi.Header.ToString();
            for (int i = 0; i < TabStripPacementItem.Items.Count; i++)
            {
                MenuItem mitem = (MenuItem)TabStripPacementItem.Items[i];
                if (mitem.Header.ToString().Equals(g))
                    mitem.IsChecked = true;
                else
                    mitem.IsChecked = false;
            }
            // Set tabstrip placement as bottom
            if (g.StartsWith("Bottom"))
                this.dockingManager.DockTabAlignment = Dock.Bottom;
            // Set tabstrip placement as Top
            else if (g.StartsWith("Top"))
                this.dockingManager.DockTabAlignment = Dock.Top;
            // Set tabstrip placement as Left
            else if (g.StartsWith("Left"))
                this.dockingManager.DockTabAlignment = Dock.Left;
            // Set tabstrip placement as Right
            else if (g.StartsWith("Right"))
                this.dockingManager.DockTabAlignment = Dock.Right;

        }

        /// <summary>
        /// Set animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Animation(object sender, RoutedEventArgs e)
        {
            MenuItem mi = (MenuItem)e.OriginalSource;
            string g = mi.Header.ToString();
            for (int i = 0; i < AnimationType.Items.Count; i++)
            {
                MenuItem mitem = (MenuItem)AnimationType.Items[i];
                if (mitem.Header.ToString().Equals(g))
                    mitem.IsChecked = true;
                else
                    mitem.IsChecked = false;
            }
            // Set animation type as slide
            if (g.StartsWith("Slide"))
                this.dockingManager.AutoHideAnimationMode = AutoHideAnimationMode.Slide;
            // Set animation type as scale
            else if (g.StartsWith("Scale"))
                this.dockingManager.AutoHideAnimationMode = AutoHideAnimationMode.Scale;
            // Set animation type as fade
            else if (g.StartsWith("Fade"))
                this.dockingManager.AutoHideAnimationMode = AutoHideAnimationMode.Fade;
        }


        /// <summary>
        /// Set animation speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Animaiton_Contol(object sender, RoutedEventArgs e)
        {

            MenuItem mi = (MenuItem)e.OriginalSource;
            string g = mi.Header.ToString();
            for (int i = 0; i < AnimationControl.Items.Count; i++)
            {
                MenuItem mitem = (MenuItem)AnimationControl.Items[i];
                if (mitem.Header.ToString().Equals(g))
                    mitem.IsChecked = true;
                else
                    mitem.IsChecked = false;
            }
            // Set animation speed as very slow
            if (g.StartsWith("Very Slow"))
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(30000000)));
            // Set animation speed as slow
            else if (g.StartsWith("Slow"))
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(10000000)));
            // Set animation speed as normal
            else if (g.StartsWith("Normal"))
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(5000000)));
            // Set animation speed as fast
            else if (g.StartsWith("Fast"))
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(1000000)));
            // Set animation speed as very fast
            else if (g.StartsWith("Very Fast"))
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(10000)));
            if (custom != null)
            {
                custom.IsChecked = false;
                custom.IsCheckable = false;
            }
        }
        /// <summary>
        /// Updates the default values for menuitems
        /// </summary>
        /// <param name="items"></param>
        /// <param name="position"></param>
        private void UpdateDefault(MenuItem items, int position)
        {
            foreach (MenuItem item in items.Items)
            {
                if (item.IsChecked)
                {
                    return;
                }
            }
            (items.Items[position] as MenuItem).IsChecked = true;
        }
        #endregion

        private void dockingManager_ActiveWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateEnableState();
        }

        private void colorPicker_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
                DockingManager.SetSideTabItemBackground(this.dockingManager.ActiveWindow as DependencyObject, new SolidColorBrush((Color)e.NewValue));
        }

        private void UpdateEnableState()
        {
            if (dockingManager.ActiveWindow != null && sidepanelcolor != null && sidepanelcolor.Items.Count > 0)
            {
                if (DockingManager.GetState(dockingManager.ActiveWindow) != DockState.AutoHidden)
                {
                        (sidepanelcolor.Items[0] as MenuItem).IsEnabled = false;
                        (sidepanelcolor.Items[1] as MenuItem).IsEnabled = false;
                }
                else
                {
                    foreach (MenuItem items in sidepanelcolor.Items)
                    {
                        items.IsEnabled = true;
                    }
                }
            }
        }

        private void foregroundColorPicker_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue !=null)
                DockingManager.SetSideTabItemForeground(this.dockingManager.ActiveWindow as DependencyObject, new SolidColorBrush((Color)e.NewValue));
        }

        private void panelBackgroundColorPicker_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
                this.dockingManager.SidePanelBackground = new SolidColorBrush((Color)e.NewValue);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetCustomDelay();
        }

        private void SetCustomDelay()
        {
            
            long l;
            if (long.TryParse(textBox1.Text, out l))
            {
                l = l * 10000;
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(l)));
            }
            else
            {
                DockingManager.SetAnimationDelay(dockingManager, new Duration(TimeSpan.FromMilliseconds(200)));
            }

            if (AnimationControl != null && AnimationControl.Items.Count > 0)
            {
                foreach (MenuItem item in AnimationControl.Items)
                {
                    if (item.IsCheckable && item.IsChecked)
                    {
                        item.IsChecked = false;
                    }
                }
                if (custom != null)
                {
                    custom.IsCheckable = true;
                    custom.IsChecked = true;
                }
            }
        }
    }
}



