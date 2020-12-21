#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.calculatedemos.wpf
{
    /// <summary>
    /// A class that allows you to quickly add calculation support for controls on a form, or usercontrol.
    /// </summary>
    public class CalcQuick : CalcQuickBase
    {
        #region code that handle Controls as key objects

        /// <summary>
        /// A Virtual method that registers an array of controls as formula objects in this CalcQuick instance.
        /// </summary>
        /// <param name="controls">The control array.</param>
        public virtual void RegisterControlArray(Control[] controls)
        {
            foreach (Control c in controls)
            {
                RegisterControl(c);
            }

            base.AutoCalc = true;
        }


        /// <summary>
        /// Have a textbox to handle the textchanged event 
        /// </summary>
        public event TextChangedEventHandler TextChanged;

        /// <summary>
        /// Used to register a control as a calculation object in this CalcQuick instance.
        /// </summary>
        /// <param name="c">The control to register.</param>
        /// <remarks>
        /// To reference this calculation object from another calculation in this CalcQuick
        /// object, you use the Control.Name string. The value of this calculation object is
        /// bound to the Control.Text property. 
        /// </remarks>
        protected virtual void RegisterControl(Control c)
        {
            ////Subscribe once.
            if (this.NameToControlMap.Count == 0)
            {
                this.ValueSet += new QuickValueSetEventHandler(CalcQuickValueSet);
            }

            if (this.ControlModifiedFlags.ContainsKey(c) ||
                this.NameToControlMap.ContainsKey(c.Name))
            {
                throw new ArgumentException(string.Format(this.Engine.FormulaErrorStrings[this.Engine.already_registered], c.Name));
            }

            this.ControlModifiedFlags.Add(c, false);
            NameToControlMap.Add(c.Name.ToUpper(), c);

            if (c.GetType() == typeof(ComboBox))
            {
                //There we will raise the textchanged event of the combobox
                (c as ComboBox).SelectionChanged += new SelectionChangedEventHandler(CalcQuick_SelectionChanged);
            }
            else if (c.GetType() == typeof(TextBox))
            {
                //There we will raise the textchanged event of the combobox
                (c as TextBox).TextChanged += new TextChangedEventHandler(tb_TextChanged);
            }
            c.MouseLeave += new MouseEventHandler(CalcQuick_MouseLeave);
        }

        void CalcQuick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null && !this.ignoreChanges
            && this.ControlModifiedFlags.ContainsKey(sender))
            {
                this.ControlModifiedFlags[sender] = true;
            }
        }

        void CalcQuick_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Control c = sender as Control;
                if (this.ControlModifiedFlags.ContainsKey(c))
                {
                    if ((bool)this.ControlModifiedFlags[sender])
                    {
                        if (c.GetType() == typeof(TextBox))
                            this[c.Name] = (c as TextBox).Text;
                        else if (c.GetType() == typeof(ComboBox))
                            this[c.Name] = (c as ComboBox).Text;
                        ////triggers a possible recalculate
                        this.ControlModifiedFlags[c] = false;
                    }
                }
            }
        }

        void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Just raise the textChanged Event of the combo if something it is 
            //subscribed to our event
            if (TextChanged != null)
            {
                TextChanged(sender, e);
            }
            if (sender != null && !this.ignoreChanges
             && this.ControlModifiedFlags.ContainsKey(sender))
            {
                this.ControlModifiedFlags[sender] = true;
            }
        }

        ////Used to autoset the value back to the control.
        private void CalcQuickValueSet(object sender, QuickValueSetEventArgs e)
        {
            if (NameToControlMap.ContainsKey(e.Key))
            {
                Control c = this.NameToControlMap[e.Key] as Control;
                if (c.GetType() == typeof(TextBox))
                    (c as TextBox).Text = e.Value;
                else if (c.GetType() == typeof(ComboBox))
                    (c as ComboBox).Text = e.Value;
            }
        }

        ////When using controls as keys, this event is
        ////used to mark a control as modified.
        private void control_TextChanged(object sender, EventArgs e)
        {
            if (sender != null && !this.ignoreChanges
                && this.ControlModifiedFlags.ContainsKey(sender))
            {
                this.ControlModifiedFlags[sender] = true;
            }
        }

        ////When using controls as keys, this event is 
        ////used to trigger an autochange if needed.
        private void control_Leave(object sender, EventArgs e)
        {
            if (sender != null)
            {
                Control c = sender as Control;
                if (this.ControlModifiedFlags.ContainsKey(c))
                {
                    if ((bool)this.ControlModifiedFlags[sender])
                    {
                        this[c.Name] = c.DataContext.ToString(); ////triggers a possible recalculate
                        this.ControlModifiedFlags[c] = false;
                    }
                }
            }
        }

        #endregion
    }
}
