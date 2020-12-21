#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace syncfusion.spellcheckerdemo.wpf
{
    public class TextSpellEditor:IEditorProperties
    {
        TextBox textbox;
        public TextSpellEditor(Control control)
        {
            ControlToSpellCheck = control;
        }
        public Control ControlToSpellCheck
        {
            get
            {
                return textbox;
            }
            set
            {
                textbox = value as TextBox;
            }
        }

        public string SelectedText
        {
            get
            {
                return textbox.SelectedText;
            }
            set
            {
                textbox.SelectedText = value;
            }
        }

        public string Text
        {
            get
            {
                return textbox.Text;
            }
            set
            {
                textbox.Text = value;
            }
        }

        public void Select(int selectionStart, int selectionLength)
        {
            textbox.Select(selectionStart, selectionLength);
        }

        public bool HasMoreTextToCheck()
        {
            return false;
        }

        public void Focus()
        {
            textbox.Focus();
        }

        public void UpdateTextField()
        {
            throw new NotImplementedException();
        }
    }
}
