// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the custom viewmodel class of NodeVM
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.Windows;

    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Represents the custom viewmodel class of NodeVM
    /// </summary>
    public class GroupVM : NodeVM, IGroup
    {
        /// <summary>
        ///     The _m connectors.
        /// </summary>
        private object _mConnectors;

        /// <summary>
        ///     The _m groups.
        /// </summary>
        private object _mGroups;

        /// <summary>
        ///     The _m nodes.
        /// </summary>
        private object _mNodes;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GroupVM" /> class.
        /// </summary>
        public GroupVM()
        {
            // WPF-51024 NRE occurs when we execute group command in DiagramBuilder.
            this.Nodes = new NodeCollection();
            this.Connectors = new ConnectorCollection();
            this.Groups = new GroupCollection();
        }

    /// <summary>
    ///     Gets or sets the connectors.
    /// </summary>
    public object Connectors
        {
            get
            {
                return this._mConnectors;
            }

            set
            {
                if (this._mConnectors != value)
                {
                    this._mConnectors = value;
                    this.OnPropertyChanged(GroupConstants.Connectors);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the groups.
        /// </summary>
        public object Groups
        {
            get
            {
                return this._mGroups;
            }

            set
            {
                if (this._mGroups != value)
                {
                    this._mGroups = value;
                    this.OnPropertyChanged(GroupConstants.Groups);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the nodes.
        /// </summary>
        public object Nodes
        {
            get
            {
                return this._mNodes;
            }

            set
            {
                if (this._mNodes != value)
                {
                    this._mNodes = value;
                    this.OnPropertyChanged(GroupConstants.Nodes);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the padding value.
        /// </summary>
        public Thickness Padding { get; set; }
    }
}