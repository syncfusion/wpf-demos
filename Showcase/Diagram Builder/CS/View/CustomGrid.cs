// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomGrid.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the custom class for grid to customize its appearance.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using DiagramBuilder.ViewModel;

    /// <summary>
    ///     Represents the custom class for grid to customize its appearance.
    /// </summary>
    public class CustomGrid : Grid, INotifyPropertyChanged
    {
        /// <summary>
        ///     The _mHeader.
        /// </summary>
        private string _mHeader;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomGrid" /> class.
        /// </summary>
        public CustomGrid()
        {
            RowDefinition rd = new RowDefinition { Height = GridLength.Auto };
            RowDefinition rd1 = new RowDefinition { Height = GridLength.Auto };
            RowDefinition rd2 = new RowDefinition { Height = GridLength.Auto };

            this.RowDefinitions.Add(rd1);
            this.RowDefinitions.Add(rd);
            this.RowDefinitions.Add(rd2);

            ColumnDefinition cd = new ColumnDefinition { Width = GridLength.Auto };
            ColumnDefinition cd1 = new ColumnDefinition { Width = GridLength.Auto };
            ColumnDefinition cd2 = new ColumnDefinition { Width = GridLength.Auto };
            ColumnDefinition cd3 = new ColumnDefinition { Width = GridLength.Auto };

            this.ColumnDefinitions.Add(cd);
            this.ColumnDefinitions.Add(cd1);
            this.ColumnDefinitions.Add(cd2);
            this.ColumnDefinitions.Add(cd3);
            this.Loaded += this.CustomGrid_Loaded;
        }

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Gets or sets the header.
        /// </summary>
        public string Header
        {
            get
            {
                return this._mHeader;
            }

            set
            {
                if (this._mHeader != value)
                {
                    this._mHeader = value;
                    this.OnChanges("Header");
                }
            }
        }

        /// <summary>
        /// Overridden to apply customization to the grid.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        /// <summary>
        /// This method invokes when the custom grid_ is loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CustomGrid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (UIElement child in this.Children)
            {
                var contentPresenter = child as ContentPresenter;
                var diagramButtonViewModel = contentPresenter.Content as DiagramButtonViewModel;
                if (diagramButtonViewModel.Label == "Fill")
                {
                    SetRow(child, 0);
                    SetColumn(child, 1);
                }
                else if (diagramButtonViewModel.Label == "Stroke")
                {
                    SetRow(child, 1);
                    SetColumn(child, 1);
                }
                else if (diagramButtonViewModel.Label == "Quick Style")
                {
                    SetRow(child, 0);
                    SetColumn(child, 0);
                    SetRowSpan(child, 2);
                }
                else if (diagramButtonViewModel.Label == "Cut")
                {
                    SetRow(child, 0);
                    SetColumn(child, 1);
                }
                else if (diagramButtonViewModel.Label == "Copy")
                {
                    SetRow(child, 1);
                    SetColumn(child, 1);
                }
                else if (diagramButtonViewModel.Label == "Paste")
                {
                    SetRow(child, 0);
                    SetColumn(child, 0);
                    SetRowSpan(child, 2);
                }
                else if (diagramButtonViewModel.Label == "BringToFront")
                {
                    SetRow(child, 0);
                    SetColumn(child, 2);
                }
                else if (diagramButtonViewModel.Label == "SendToBack")
                {
                    SetRow(child, 1);
                    SetColumn(child, 2);
                }
                else if (diagramButtonViewModel.Label == "Group")
                {
                    SetRow(child, 2);
                    SetColumn(child, 2);
                }
                else if (diagramButtonViewModel.Label == "Align")
                {
                    SetRow(child, 0);
                    SetColumn(child, 0);
                    SetRowSpan(child, 2);
                }
                else if (diagramButtonViewModel.Label == "Position")
                {
                    SetRow(child, 0);
                    SetColumn(child, 1);
                    SetRowSpan(child, 2);
                }
                else if (diagramButtonViewModel.Label == "Pointer Tool")
                {
                    SetRow(child, 0);
                    SetColumn(child, 0);
                }
                else if (diagramButtonViewModel.Label == "Connector")
                {
                    SetRow(child, 1);
                    SetColumn(child, 0);
                }
                else if (diagramButtonViewModel.Label == "Text")
                {
                    SetRow(child, 2);
                    SetColumn(child, 0);
                }
                else if (diagramButtonViewModel.Identifier == "Ruler")
                {
                    SetRow(child, 0);
                    SetColumn(child, 0);
                }
                else if (diagramButtonViewModel.Identifier == "Grid")
                {
                    SetRow(child, 0);
                    SetColumn(child, 1);
                }
                else if (diagramButtonViewModel.Identifier == "PageBreaks")
                {
                    SetRow(child, 0);
                    SetColumn(child, 2);
                }
                else if (diagramButtonViewModel.Identifier == "MultiplePage")
                {
                    SetRow(child, 1);
                    SetColumn(child, 0);
                }
                else if (diagramButtonViewModel.Identifier == "SnapToObject")
                {
                    SetRow(child, 1);
                    SetColumn(child, 1);
                }
                else if (diagramButtonViewModel.Identifier == "SnapToGrid")
                {
                    SetRow(child, 1);
                    SetColumn(child, 2);
                }
                else if (diagramButtonViewModel.Label == "Task Panes")
                {
                    SetRow(child, 0);
                    SetColumn(child, 3);
                    SetRowSpan(child, 2);
                }
            }
        }

        /// <summary>
        /// Occurs when the property changes.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        private void OnChanges(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}