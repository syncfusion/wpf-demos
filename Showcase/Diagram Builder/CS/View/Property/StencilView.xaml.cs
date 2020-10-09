// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StencilView.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Created view for stencil.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using DiagramBuilder.Utility;
    using DiagramBuilder.ViewModel;

    using Syncfusion.UI.Xaml.Diagram.Stencil;

    /// <summary>
    ///     Created view for stencil.
    /// </summary>
    public sealed partial class StencilView : UserControl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StencilView" /> class.
        /// </summary>
        public StencilView()
        {
            this.InitializeComponent();
            this.HeaderVisibility = new Command(this.OnHeaderVisibilityCommand);
            this.ShowSymbolGroup = new Command(this.OnShowSymbolGroupCommand);
        }

        /// <summary>
        ///     Gets or sets the header visibility.
        /// </summary>
        public ICommand HeaderVisibility { get; set; }

        /// <summary>
        ///     Gets or sets the show symbol group command.
        /// </summary>
        public ICommand ShowSymbolGroup { get; set; }

        /// <summary>
        /// This method controls the visibility of the stencil header.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnHeaderVisibilityCommand(object param)
        {
            if (this.stencil.DataContext != null)
            {
                if (param.ToString().Equals("Expand"))
                {
                    this.stencil.HeaderVisibility = Visibility.Visible;
                    SymbolFilterProvider all = new SymbolFilterProvider
                                                   {
                                                       SymbolFilter = (this.stencil.DataContext as StencilVm).Filter,
                                                       Content = "All"
                                                   };
                    (this.stencil.DataContext as StencilVm).SelectedFilter = all;
                }
                else if (param.ToString().Equals("Collapse"))
                {
                    this.stencil.HeaderVisibility = Visibility.Collapsed;
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider
                                                           {
                                                               SymbolFilter =
                                                                   (this.stencil.DataContext as StencilVm).Filter,
                                                               Content = "Basic Shapes"
                                                           };
                    (this.stencil.DataContext as StencilVm).SelectedFilter = basicShapes;
                }
            }
        }

        /// <summary>
        /// This method controls the symbolgroup view.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnShowSymbolGroupCommand(object param)
        {
            if (this.stencil.DataContext != null)
            {
                if (param.ToString().Equals("Basic Shapes"))
                {
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider
                                                           {
                                                               SymbolFilter =
                                                                   (this.stencil.DataContext as StencilVm).Filter,
                                                               Content = "Basic Shapes"
                                                           };
                    (this.stencil.DataContext as StencilVm).SelectedFilter = basicShapes;
                }
                else if (param.ToString().Equals("Flow Shapes"))
                {
                    SymbolFilterProvider flowShapes = new SymbolFilterProvider
                                                          {
                                                              SymbolFilter =
                                                                  (this.stencil.DataContext as StencilVm).Filter,
                                                              Content = "Flow Shapes"
                                                          };
                    (this.stencil.DataContext as StencilVm).SelectedFilter = flowShapes;
                }
                else if (param.ToString().Equals("BPMN Shapes"))
                {
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider
                                                           {
                                                               SymbolFilter =
                                                                   (this.stencil.DataContext as StencilVm).Filter,
                                                               Content = "BPMN Shapes"
                                                           };
                    (this.stencil.DataContext as StencilVm).SelectedFilter = basicShapes;
                }
                else if (param.ToString().Equals("Electrical"))
                {
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider
                                                           {
                                                               SymbolFilter =
                                                                   (this.stencil.DataContext as StencilVm).Filter,
                                                               Content = "Electrical"
                                                           };
                    (this.stencil.DataContext as StencilVm).SelectedFilter = basicShapes;
                }
                else if (param.ToString().Equals("Arrow"))
                {
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider
                                                           {
                                                               SymbolFilter =
                                                                   (this.stencil.DataContext as StencilVm).Filter,
                                                               Content = "Arrow"
                                                           };
                    (this.stencil.DataContext as StencilVm).SelectedFilter = basicShapes;
                }
            }
        }
    }
}