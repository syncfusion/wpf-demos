#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.gridcontroldemos.wpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Syncfusion.Windows.Controls.Grid;
    using System.Windows.Input;
    public class CustomeDropDownCellModel : GridCellDropDownCellModel<CustomDropDownRenderer>
    {
    }
    public class CustomDropDownRenderer : GridCellDropDownCellRenderer<CustomeDropDown>
    {
        private CustomeDropDownCellModel CustomDropDownModel
        {
            get
            {
                return this.CellModel as CustomeDropDownCellModel;
            }
        }

        public override void OnInitializeContent(CustomeDropDown dropDownControl, GridRenderStyleInfo style)
        {
            if (dropDownControl.ListBoxPart != null)
            {
                dropDownControl.ListBoxPart.SelectionChanged -= this.OnComboBoxSelectionChanged;
            }

            base.OnInitializeContent(dropDownControl, style);
        }

        protected override void ArrangeUIElement(Syncfusion.Windows.Controls.Cells.ArrangeCellArgs aca, CustomeDropDown uiElement, GridRenderStyleInfo style)
        {
            base.ArrangeUIElement(aca, uiElement, style);
            var dropDownControl = uiElement;
            if (style.ItemsSource != null)
            {
                dropDownControl.ListBoxPart.ItemsSource = this.CustomDropDownModel.GetDataSource(style);
                dropDownControl.ListBoxPart.DisplayMemberPath = style.HasDisplayMember ? style.DisplayMember : string.Empty;
                dropDownControl.ListBoxPart.SelectedValue = this.GetControlValue(style);
                if (style.HasValueMember)
                {
                    dropDownControl.ListBoxPart.SelectedValuePath = style.ValueMember;
                }
            }

            uiElement.ListBoxPart.SelectionChanged += this.OnComboBoxSelectionChanged;
        }

        protected override void SetSelectedIndex(int index)
        {
            if (index != this.CurrentCellUIElement.ListBoxPart.SelectedIndex)
            {
                this.CurrentCellUIElement.ListBoxPart.SelectedIndex = index;
            }
        }

        private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var item = e.AddedItems[0].ToString();
                this.CustomDropDownModel.ListModel.CurrentIndex = this.CustomDropDownModel.FindValue(this.CurrentStyle, item);
                if (!this.AlreadyTextChanged)
                {
                    this.CurrentCellUIElement.TextBoxPart.Text = item;
                }
            }
        }

        protected override bool ShouldGridTryToHandlePreviewKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            
            switch(e.Key)
            {
                case Key.Up:
                if (this.IsDroppedDown)
                    {
                    if (this.CurrentCellUIElement.ListBoxPart.SelectedIndex > 0)
                        {
                        this.CurrentCellUIElement.ListBoxPart.SelectedIndex = this.CurrentCellUIElement.ListBoxPart.SelectedIndex - 1;
                        this.CurrentCellUIElement.ListBoxPart.ScrollIntoView(this.CurrentCellUIElement.ListBoxPart.Items[this.CurrentCellUIElement.ListBoxPart.SelectedIndex]);
                        e.Handled = true;
                        }
                    return false;
                    }
                else
                    return true;
                case Key.Down:
                if (this.IsDroppedDown)
                    {
                    if (this.CurrentCellUIElement.ListBoxPart.SelectedIndex < this.CurrentCellUIElement.ListBoxPart.Items.Count)
                        {
                        this.CurrentCellUIElement.ListBoxPart.SelectedIndex = this.CurrentCellUIElement.ListBoxPart.SelectedIndex + 1;
                        this.CurrentCellUIElement.ListBoxPart.ScrollIntoView(this.CurrentCellUIElement.ListBoxPart.Items[this.CurrentCellUIElement.ListBoxPart.SelectedIndex]);
                        e.Handled = true;
                       
                        }
                    return false;
                    }
                else
                    return true;
               

            }
            
            
            return base.ShouldGridTryToHandlePreviewKeyDown(e);            
        }

        public override void RaiseGridCellClick(int rowIndex, int colIndex, Syncfusion.Windows.Controls.Scroll.MouseControllerEventArgs e)
        {
            base.RaiseGridCellClick(rowIndex, colIndex, e);
            var v = this.CurrentCell.Renderer;
            if (!this.CurrentCell.IsEditing)
                this.CurrentCell.BeginEdit();
            if (v.HasCurrentCellState && v.CurrentCellUIElement != null)
            {
                this.GridControl.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        ((CustomDropDownRenderer)v).CurrentCellUIElement.IsDropDownOpen = !((CustomDropDownRenderer)v).CurrentCellUIElement.IsDropDownOpen;
                    }));
            }

        }
    }
}
