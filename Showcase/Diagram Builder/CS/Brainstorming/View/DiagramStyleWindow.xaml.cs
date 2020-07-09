// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramStyleWindow.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for DiagramStyleWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.View
{
    using System.Windows;

    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Interaction logic for DiagramStyleWindow.xaml
    /// </summary>
    public partial class DiagramStyleWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DiagramStyleWindow" /> class.
        /// </summary>
        public DiagramStyleWindow()
        {
            this.InitializeComponent();
            this.diagramcontrol.PageSettings = new PageSettings() { PageWidth = 400, PageHeight = 400 };
            FitToPageParameter fitToPage = new FitToPageParameter
                                               {
                                                   FitToPage = FitToPage.FitToPage, Region = Region.PageSettings
                                               };
            IGraphInfo graphInfo = this.diagramcontrol.Info as IGraphInfo;
            if (graphInfo != null)
            {
                graphInfo.Commands.FitToPage.Execute(fitToPage);
            }
        }
    }
}