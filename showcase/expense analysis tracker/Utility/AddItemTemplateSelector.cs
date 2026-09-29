using System.Windows;
using System.Windows.Controls;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// A custom <see cref="DataTemplateSelector"/> that selects a data template based on the type of item being displayed.
    /// </summary>
    public class AddItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the data template used to display existing items.
        /// </summary>
        public DataTemplate ViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the data template used to display items for adding new budgets or goals.
        /// </summary>
        public DataTemplate AddTemplate { get; set; }

        /// <summary>
        /// Select a  data template based on the type of the item
        /// </summary>
        /// <param name="item">The data object for which to select the template.</param>
        /// <param name="container">The container which the template will be applied.</param>
        /// <returns>The appropiate <see cref="DataTemplate"/> based on the item type.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is AddBudget || item is AddGoal)
            {
                return AddTemplate;
            }
            else
            {
                return ViewTemplate;
            }
        }
    }

    /// <summary>
    /// A custom <see cref="DataTemplateSelector"/> that selects a data template based on the value of a financial item.
    /// </summary>
    public class IncomeExpenseTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the data template used  for income items (positive value).
        /// </summary>
        public DataTemplate IncomeTemplate { get; set; }

        /// <summary>
        /// Gets or sets the data template used for expense items (Zero or negative values).
        /// </summary>
        public DataTemplate ExpenseTemplate { get; set; }

        /// <summary>
        /// Selects the appropiate data template based on the item's value.
        /// </summary>
        /// <param name="item">The item to evaluate, expected to be of type <c>double</c>.</param>
        /// <param name="container">The container in which the template will be applied.</param>
        /// <returns><see cref="IncomeTemplate"/> if the value is greater than zero; <see cref="ExpenseTemplate"/> if the value is zero or less; otherwise returns null.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is double)
            {
                if ((double)item > 0)
                {
                    return IncomeTemplate;
                }
                else
                {
                    return ExpenseTemplate;
                }
            }
            return null;
        }
    }

}