#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Scroll;

namespace CustomDataTemplateCell
{
    /// <summary>
    /// A cell model for the <see cref="DataTemplateCellRenderer"/>.
    /// </summary>
    public class DataTemplateCellModel : GridCellModel<DataTemplateCellRenderer>
    {
    }

    /// <summary>
    /// A renderer that manages a DataTemplate specified with <see cref="TreeRenderStyleInfo.CellTemplateKey"/>
    /// of the <see cref="TreeRenderStyleInfo"/> inside cells. The <see cref="ContentControl.Content"/>
    /// will be the  <see cref="TreeRenderStyleInfo.CellValue"/> which binds the DataTemplate to the value
    /// of the style.
    /// </summary>
    public class DataTemplateCellRenderer : GridVirtualizingCellRenderer<ContentControl>
    {
        public DataTemplateCellRenderer()
        {
            IsFocusable = true;
            AllowRecycle = true;
        }

        /// <summary>
        /// Called to initialize the content of the cell
        /// using the information from the cell style (value, text,
        /// behavior etc.). You must override this method in your
        /// derived class.
        /// </summary>
        /// <param name="uiElement">The UI element.</param>
        /// <param name="style">The cell style info.</param>
        public override void OnInitializeContent(ContentControl uiElement, GridRenderStyleInfo style)
        {
            base.OnInitializeContent(uiElement, style);
            bool found = false;

            if (style.CellItemTemplateKey != null)
            {
                DataTemplate dt = (DataTemplate)style.GridControl.TryFindResource(style.CellItemTemplateKey);
                found = dt != null;
                if (found)
                    uiElement.ContentTemplate = dt;
            }

            if (!found)
                uiElement.ContentTemplate = style.CellItemTemplate;

            uiElement.Content = style.CellValue;
        }

        public override void CreateRendererElement(ContentControl uiElement, GridRenderStyleInfo style)
        {

            bool found = false;

            if (style.CellItemTemplateKey != null)
            {
                DataTemplate dt = (DataTemplate)style.GridControl.TryFindResource(style.CellItemTemplateKey);
                found = dt != null;
                if (found)
                    uiElement.ContentTemplate = dt;
            }

            if (!found)
                uiElement.ContentTemplate = style.CellItemTemplate;

            uiElement.Content = style.CellValue;
            base.CreateRendererElement(uiElement, style);
        }
        protected override bool ShouldGridTryToHandlePreviewKeyDown(KeyEventArgs e)
        {
            // return false to indicate the CurrentCellUIElement should handle the key
            // and the grid should ignore it.
            bool isControlKey = (e.KeyboardDevice.Modifiers & ModifierKeys.Control) != ModifierKeys.None;
            if (isControlKey)
                return true;

            switch (e.Key)
            {


                case Key.Right:
                case Key.Left:
                case Key.Down:
                case Key.Up:
                    {                        
                        return !CurrentCell.IsEditing;
                    }

                case Key.End:
                case Key.Home:
                    {
                        CurrentCell.BeginEdit(true);
                        return false;
                    }

                case Key.Delete:
                    {
                        CurrentCell.BeginEdit(true);
                        return false;
                    }
                case Key.Enter:
                    {
                        if (this.CurrentCell.IsEditing)
                            CurrentCell.EndEdit();
                        CurrentCell.MoveRight();
                        return true;
                    }

                case Key.Back:
                    {
                        CurrentCell.BeginEdit(true);
                        return false;
                    }
            }

            return base.ShouldGridTryToHandlePreviewKeyDown(e);
        }
        protected override string GetControlTextFromEditorCore(ContentControl uiElement)
        {            
            return uiElement.Content.ToString();
        }
    }

}
