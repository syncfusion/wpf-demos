#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Diagnostics;

namespace VirtualizedCell
{
    public class VirtualizedCellModel : GridCellModel<VirtualizedCellRenderer>
    {
    }

    public class VirtualizedCellRenderer : GridVirtualizingCellRenderer<TextBox>
    {

        // The Virtualized Cell will display "Edit Me!" when
        // it is a live UIElement editor. If text is just
        // rendered in OnRender it will display "Render".
        //
        // When you hover the mouse over a cell it will become
        // a live UIElement editor and not render the cell anymore.
        // You can click inside it and edit its contents.
        // 
        // When you scroll a cell outside view it will be switched
        // back to a rendered cell.
        //
        // This approach improves scrolling speed since rendering
        // text directly is faster then placing a UIElement as soon
        // a cell becomes visible.
        //
        // You can disable this mechanism by setting "SupportsRenderOptimization = false" in the ctor.

        public VirtualizedCellRenderer()
        {
            SupportsRenderOptimization = true;
            AllowRecycle = true;
            IsControlTextShown = true;
            IsFocusable = true;
        }

        protected override void OnRender(DrawingContext dc, RenderCellArgs rca, GridRenderStyleInfo cellInfo)
        {
            if (rca.CellUIElements != null)
                return;

            // Will only get hit if SupportsRenderOptimization is true, otherwise rca.CellVisuals is never null.
            string s = String.Format("Render{0}/{1}", rca.RowIndex, rca.ColumnIndex);
            GridTextBoxPaint.DrawText(dc, rca.CellRect, s, cellInfo);
        }

        /// <summary>
        /// Called to initialize the content of the cell
        /// using the information from the cell style (value, text,
        /// behavior etc.). You must override this method in your
        /// derived class.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <param name="style">The cell style info.</param>
        public override void OnInitializeContent(TextBox textBox, GridRenderStyleInfo style)
        {
            base.OnInitializeContent(textBox, style);
            this.InitDefaultProperties(textBox, style);
        }

        private void InitDefaultProperties(TextBox textBox, GridRenderStyleInfo style)
        {
            Thickness margins = style.TextMargins.ToThickness();

            // TextBoxView always has a minimum margin of 2 for left and right.
            // Margin is hardcoded below so that TextBox behavior is properly emulated.
            margins.Left = Math.Max(0, margins.Left - 2);
            margins.Right = Math.Max(0, margins.Right - 2);

            textBox.Padding = margins;
            textBox.BorderThickness = new Thickness(0);
            VirtualizingCellsControl.SetWantsMouseInput(textBox, true);

            textBox.Text = GetControlText(style);
        }

        public override void CreateRendererElement(TextBox textBox, GridRenderStyleInfo style)
        {
            base.CreateRendererElement(textBox, style);
            this.InitDefaultProperties(textBox, style);
        }

        protected override string GetControlTextFromEditorCore(TextBox uiElement)
        {
            return uiElement.Text;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            ControlText = GetControlText(CurrentStyle);
        }

        protected override void OnWireUIElement(TextBox textBox)
        {
            base.OnWireUIElement(textBox);
            textBox.TextChanged += new TextChangedEventHandler(textBox_TextChanged);
        }

        /// <summary>
        /// Unwire previously wired events from textBox. 
        /// </summary>
        /// <param name="textBox"></param>
        protected override void OnUnwireUIElement(TextBox textBox)
        {
            base.OnUnwireUIElement(textBox);
            textBox.TextChanged -= new TextChangedEventHandler(textBox_TextChanged);
        }

        void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!this.IsInArrange && IsCurrentCell(textBox))
            {
                TraceUtil.TraceCurrentMethodInfo(textBox.Text);
                if (!SetControlText(textBox.Text))
                    RefreshContent(); // reverses change.
            }
        }

        protected override void OnGridPreviewTextInput(TextCompositionEventArgs e)
        {
            CurrentCell.ScrollInView();
            CurrentCell.BeginEdit(true);
        }

        protected override bool ShouldGridTryToHandlePreviewKeyDown(KeyEventArgs e)
        {
            if (CurrentCellUIElement != null && CurrentCellUIElement.IsFocused && e.Key != Key.Escape)
                return false;

            return true;
        }

    }

}
