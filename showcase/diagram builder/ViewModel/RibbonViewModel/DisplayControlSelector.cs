// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayControlSelector.cs" company="">
//   
// </copyright>
// <summary>
//   The display control selector.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    ///     The display control selector.
    /// </summary>
    public class DisplayControlSelector : DataTemplateSelector
    {
        /// <summary>
        ///     The dataTemp.
        /// </summary>
        private Dictionary<string, DataTemplate> dataTemp;

        /// <summary>
        ///     Gets or sets the button data template.
        /// </summary>
        public DataTemplate ButtonDataTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the check box data template.
        /// </summary>
        public DataTemplate CheckBoxDataTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the color picker data template.
        /// </summary>
        public DataTemplate ColorPickerDataTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the font family combobox data template.
        /// </summary>
        public DataTemplate FontFamilyComboboxDataTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the font size combobox data template.
        /// </summary>
        public DataTemplate FontSizeComboboxDataTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the galary data template.
        /// </summary>
        public DataTemplate GalleryDataTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the split button data template.
        /// </summary>
        public DataTemplate SplitButtonDataTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the toggle button data template.
        /// </summary>
        public DataTemplate ToggleButtonDataTemplate { get; set; }

        /// <summary>
        /// Represents the selected template.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The <see cref="DataTemplate"/>.
        /// </returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            this.PopulateCollection();

            DiagramButtonViewModel db = item as DiagramButtonViewModel;
            IEnumerable<DataTemplate> results = this.dataTemp.Where(x => x.Key == db.DisplayControl.ToString())
                .Select(g => g.Value).Distinct();
            return results.FirstOrDefault();
        }

        /// <summary>
        ///     The populate collection.
        /// </summary>
        private void PopulateCollection()
        {
            this.dataTemp = new Dictionary<string, DataTemplate>();
            this.dataTemp.Add("Button", this.ButtonDataTemplate);
            this.dataTemp.Add("ToggleButton", this.ToggleButtonDataTemplate);
            this.dataTemp.Add("FontFamily", this.FontFamilyComboboxDataTemplate);
            this.dataTemp.Add("FontSize", this.FontSizeComboboxDataTemplate);
            this.dataTemp.Add("ColorPicker", this.ColorPickerDataTemplate);
            this.dataTemp.Add("CheckBox", this.CheckBoxDataTemplate);
            this.dataTemp.Add("SplitButton", this.SplitButtonDataTemplate);
            this.dataTemp.Add("Gallery", this.GalleryDataTemplate);
        }
    }
}