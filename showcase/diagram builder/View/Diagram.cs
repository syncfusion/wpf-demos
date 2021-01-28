// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Diagram.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the view class of diagram.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;

    using Brainstorming.View;
    using Brainstorming.ViewModel;

    using DiagramBuilder.ViewModel;

    using FlowChart.View;
    using FlowChart.ViewModel;

    using Microsoft.Win32;
    using OrganizationChart.View;
    using OrganizationChart.ViewModel;
    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;

    using QuickCommand = Syncfusion.UI.Xaml.Diagram.QuickCommand;

    /// <summary>
    ///     Represents the view class of diagram.
    /// </summary>
    internal class Diagram : SfDiagram
    {
        /// <summary>
        ///     Represents the dummy visibility property.
        /// </summary>
        public static readonly DependencyProperty DummyVisibilityProperty = DependencyProperty.Register(
            "LocalVisibility",
            typeof(Visibility),
            typeof(Diagram),
            new PropertyMetadata(Visibility.Collapsed, OnVisibilityChanged));

        /// <summary>
        ///     Represents the diagram type property.
        /// </summary>
        public static readonly DependencyProperty DiagramTypeProperty = DependencyProperty.Register(
            "DiagramType",
            typeof(DiagramType),
            typeof(Diagram),
            new PropertyMetadata(null));

        /// <summary>
        ///     Represents the isselected property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
            "IsSelected",
            typeof(bool),
            typeof(Diagram),
            new PropertyMetadata(false));

        /// <summary>
        ///     Represents the page dummy property.
        /// </summary>
        public static readonly DependencyProperty PageDummyProperty = DependencyProperty.Register(
            "PageDummy",
            typeof(PageVM),
            typeof(Diagram),
            new PropertyMetadata(null));

        /// <summary>
        ///     Represents the title property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(Diagram),
            new PropertyMetadata(string.Empty));

        /// <summary>
        ///     Represents the isexport property.
        /// </summary>
        public static readonly DependencyProperty IsExportProperty = DependencyProperty.Register(
            "IsExport",
            typeof(bool),
            typeof(Diagram),
            new PropertyMetadata(false, IsExported));

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...

        // Using a DependencyProperty as the backing store for PageDummy.  This enables animation, styling, binding, etc...

        // Using a DependencyProperty as the backing store for IsExport.  This enables animation, styling, binding, etc...

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...

        /// <summary>
        ///     The extension.
        /// </summary>
        private string Extension;

        /// <summary>
        ///     The quickcommands_ delete.
        /// </summary>
        private QuickCommandViewModel QuickCommands_Delete;

        /// <summary>
        ///     The quickcommands_ left.
        /// </summary>
        private QuickCommandViewModel QuickCommands_Left;

        /// <summary>
        ///     The quickcommands_ right.
        /// </summary>
        private QuickCommandViewModel QuickCommands_Right;

        /// <summary>
        /// The quickcommands_add
        /// </summary>
        private QuickCommandViewModel Quickcommands_Add;


        /// <summary>
        ///     Initializes a new instance of the <see cref="Diagram" /> class.
        /// </summary>
        public Diagram()
        {
            Binding bind = new Binding();
            bind.Path = new PropertyPath("Visibility");
            bind.Source = this;
            bind.Mode = BindingMode.OneWay;
            bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            this.SetBinding(DummyVisibilityProperty, bind);

            this.KnownTypes = this.GetKnownTypes;

            this.SetValue(SelectedItemsProperty, DependencyProperty.UnsetValue);
            this.SetValue(ExportSettingsProperty, DependencyProperty.UnsetValue);
            this.SetValue(PrintingServiceProperty, DependencyProperty.UnsetValue);
            this.SetValue(PreviewSettingsProperty, DependencyProperty.UnsetValue);
            this.SetValue(PageSettingsProperty, DependencyProperty.UnsetValue);
            this.SetValue(ScrollSettingsProperty, DependencyProperty.UnsetValue);

            this.Loaded += this.Diagram_Loaded;
            this.Unloaded += this.Diagram_Unloaded;
            this.Page.Loaded += this.Page_Loaded;
            this.LostKeyboardFocus += Diagram_LostKeyboardFocus;            

            FitToPageParameter fitToPage = new FitToPageParameter
                                               {
                                                   FitToPage = FitToPage.FitToPage, Region = Region.PageSettings
                                               };
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(fitToPage);
        }

        private void Diagram_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.OldFocus is Diagram && e.NewFocus is System.Windows.Controls.ScrollViewer)
            {
                (sender as Control).Focus();
                e.Handled = true;
            }
        }

        /// <summary>
        ///     Gets or sets the diagram type.
        /// </summary>
        [DataMember]
        public DiagramType DiagramType
        {
            get
            {
                return (DiagramType)this.GetValue(DiagramTypeProperty);
            }

            set
            {
                this.SetValue(DiagramTypeProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether diagram can be exported or not.
        /// </summary>
        public bool IsExport
        {
            get
            {
                return (bool)this.GetValue(IsExportProperty);
            }

            set
            {
                this.SetValue(IsExportProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether element can be selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return (bool)this.GetValue(IsSelectedProperty);
            }

            set
            {
                this.SetValue(IsSelectedProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the page dummy.
        /// </summary>
        [DataMember]
        public PageVM PageDummy
        {
            get
            {
                return (PageVM)this.GetValue(PageDummyProperty);
            }

            set
            {
                this.SetValue(PageDummyProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        [DataMember]
        public string Title
        {
            get
            {
                return (string)this.GetValue(TitleProperty);
            }

            set
            {
                this.SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        ///     Represents the knowntypes of the diagram elements properties for serialization.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerable" />.
        /// </returns>
        public IEnumerable<Type> GetKnownTypes()
        {
            List<Type> known = new List<Type>
                                   {
                                       typeof(FontStyle),
                                       typeof(TextAlignment),
                                       typeof(HorizontalAlignment),
                                       typeof(VerticalAlignment),
                                       typeof(Visibility),
                                       typeof(ConnectType),
                                       typeof(ConnectorType),
                                       typeof(Thickness),
                                       typeof(DoubleCollection),
                                       typeof(FontWeight),
                                       typeof(PageVM),
                                       typeof(DiagramType),
                                       typeof(CustomContent)
                                   };
            foreach (Type item in known)
            {
                yield return item;
            }
        }

        /// <summary>
        ///     Overridden to apply templates to the diagraaming elements.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        /// <summary>
        /// Creates or identifies the <see cref="Connector"/> that is used to display the given <see cref="IConnector"/>.
        /// </summary>
        /// <param name="item">
        /// The object that is actually display in the diagram.
        /// </param>
        /// <returns>
        /// The element that is used to display the given item.
        /// </returns>
        protected override Connector GetConnectorForItemOverride(object item)
        {
            if (this.DataContext != null && this.DataContext is OrganizationChartDiagramVM)
            {
                return new OrganizationChartConnectorView();
            }
            else
            {
                return new ConnectorView();
            }
        }

        /// <summary>
        /// Creates a new instance of <see cref="IConnector"/>.
        /// </summary>
        /// <param name="desiredType">
        /// Desired type of IConnector.
        /// </param>
        /// <returns>
        /// Returns a instance of IConnector based on the desired type.
        /// </returns>
        protected override object GetNewConnector(Type desiredType)
        {
            if (this.DataContext != null && this.DataContext is OrganizationChartDiagramVM)
            {
                return new OrganizationChartConnectorVM();
            }
            else
            {
                return new ConnectorVM();
            }
        }

        /// <summary>
        /// Creates a new instance of <see cref="IGroup"/>.
        /// </summary>
        /// <param name="desiredType">
        /// Desired type of IGroup.
        /// </param>
        /// <returns>
        /// Returns a instance of IGroup based on the desired type.
        /// </returns>
        protected override object GetNewGroup(Type desiredType)
        {
            return new GroupVM();
        }

        /// <summary>
        /// Creates a new instance of <see cref="INode"/>.
        /// </summary>
        /// <param name="desiredType">
        /// Desired type of INode.
        /// </param>
        /// <returns>
        /// Returns a instance of INode based on the desired type.
        /// </returns>
        protected override object GetNewNode(Type desiredType)
        {
            return new NodeVM();
        }

        /// <summary>
        /// Creates or identifies the <see cref="Node"/> that is used to display the given <see cref="INode"/>.
        /// </summary>
        /// <param name="item">
        /// The object that is actually display in the diagram.
        /// </param>
        /// <returns>
        /// The element that is used to display the given item.
        /// </returns>
        protected override Node GetNodeForItemOverride(object item)
        {
            if (this.DataContext != null && this.DataContext is BrainstormingVM)
            {
                return new BrainstormingNodeView();
            }

            else if (this.DataContext != null && this.DataContext is OrganizationChartDiagramVM)
            {
                return new OrganizationChartNodeView();
            }

            return new NodeView();
        }

        /// <summary>
        /// Creates or identifies the <see cref="Syncfusion.UI.Xaml.Diagram.QuickCommand"/> that is used to display the given
        ///     view model.
        /// </summary>
        /// <param name="item">
        /// The quickcommand that is actually display in the diagram.
        /// </param>
        /// <returns>
        /// The element that is used to display the given item.
        /// </returns>
        protected override QuickCommand GetQuickCommandForItemOverride(object item)
        {
            if (this.DataContext != null && this.DataContext is BrainstormingVM)
            {
                return new Brainstorming.View.QuickCommand();
            }
            else if (this.DataContext != null && this.DataContext is OrganizationChartDiagramVM)
            {
                return new OrganizationChart.View.QuickCommand();
            }

            return base.GetQuickCommandForItemOverride(item);
        }

        /// <summary>
        /// Creates or identifies the <see cref="Selector"/> that is used to display the given
        ///     <see cref="SelectorViewModel"/>.
        /// </summary>
        /// <param name="item">
        /// The object that is actually display the given Selector.
        /// </param>
        /// <returns>
        /// The element that is used to display the given item.
        /// </returns>
        protected override Selector GetSelectorForItemOverride(object item)
        {
            if (this.DataContext != null && this.DataContext is BrainstormingVM)
            {
                BrainstormingSelector selector = new BrainstormingSelector();
                selector.Visibility = Visibility.Collapsed;
                Panel.SetZIndex(selector, 1000000);
                return selector;
            }

            if (this.DataContext != null && this.DataContext is FlowDiagramVm)
            {
                CustomSelector selector = new CustomSelector();
                selector.Visibility = Visibility.Collapsed;
                Panel.SetZIndex(selector, 1000000);
                return selector;
            }

            else if (this.DataContext != null && this.DataContext is OrganizationChartDiagramVM)
            {
                OrganizationChartSelector selector = new OrganizationChartSelector();
                selector.Visibility = Visibility.Collapsed;
                Canvas.SetZIndex(selector, 1000000);
                return selector;
            }

            return base.GetSelectorForItemOverride(item);
        }

        /// <summary>
        /// This method is used to set or customize the Tool action for the diagram elements.
        /// </summary>
        /// <param name="args">
        /// Instance of <see cref="SetToolArgs"/>
        /// </param>
        protected override void SetTool(SetToolArgs args)
        {
            if (args.Source is NodePortVM && this.Tool != Tool.ContinuesDraw && this.Tool != Tool.DrawOnce)
            {
                args.Action = ActiveTool.Drag;
            }
            else
            {
                base.SetTool(args);
            }
        }

        /// <summary>
        /// This method is used to export the diagram as an Image.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void IsExported(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                (d as Diagram).OnExported();
            }

            if (((d as Diagram).DataContext as DiagramVM).IsExport)
                ((d as Diagram).DataContext as DiagramVM).IsExport = false;
        }

        /// <summary>
        /// Add the customized quick command to the node.
        /// </summary>
        /// <param name="margin">
        /// The margin is used to add some blank space in any one of its four sides.
        /// </param>
        /// <param name="offset">
        /// The offset is used to align the QuickCommand based on fractions.
        /// </param>
        /// <param name="content">
        /// The content is used to customize the appearance of the QuickCommand.
        /// </param>
        /// <param name="command">
        /// Gets or sets the command to invoke when this quickcommand is pressed.
        /// </param>
        /// <returns>
        /// The <see cref="QuickCommandViewModel"/>.
        /// </returns>
        private QuickCommandViewModel AddQuickCommand(Thickness margin, Point offset, string content, ICommand command)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/syncfusion.diagrambuilder.Wpf;component/Theme/DiagramBuilderUI.xaml", UriKind.RelativeOrAbsolute)
            };

            QuickCommandViewModel quickCommand = new QuickCommandViewModel
                                                     {
                                                         Margin = margin,
                                                         OffsetX = offset.X,
                                                         OffsetY = offset.Y,
                                                         Command = command,
                                                         HorizontalAlignment = HorizontalAlignment.Center,
                                                         VerticalAlignment = VerticalAlignment.Center,
                                                         VisibilityMode = VisibilityMode.Node,
                                                         Content = this.GetTemplate(content),
                                                         Shape =
                                                             "F1M23.467,11.733C23.467,18.213 18.214,23.466 11.734,23.466 5.253,23.466 0,18.213 0,11.733 0,5.253 5.253,0 11.734,0 18.214,0 23.467,5.253 23.467,11.733",
                                                         ShapeStyle =
                                                             resourceDictionary[
                                                                 "QuickCommandstyle"] as Style,
                                                         ContentTemplate =
                                                             resourceDictionary[
                                                                 "quickCommandContentTemplate"] as DataTemplate
                                                     };
            ((this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).Add(quickCommand);
            return quickCommand;
        }

        /// <summary>
        /// This method is used to notify when the diagram is loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as SfDiagram).Constraints = (sender as SfDiagram).Constraints | GraphConstraints.Undoable;
            this.CommandManager.View = this;
            if ((this.DataContext as IDiagramViewModel).FirstLoad != null)
            {
                (this.DataContext as IDiagramViewModel).FirstLoad.Execute(null);
            }

            this.SetBinding(
                SnapSettingsProperty,
                new Binding { Path = new PropertyPath("SnapSettings"), Mode = BindingMode.TwoWay });
            if (this.DataContext is BrainstormingVM)
            {
                this.SetBinding(
                    CommandManagerProperty,
                    new Binding { Path = new PropertyPath("CommandManager"), Mode = BindingMode.TwoWay });
            }

            this.SetBinding(
                ConstraintsProperty,
                new Binding { Path = new PropertyPath("Constraints"), Mode = BindingMode.TwoWay });

            if (this.DataContext is BrainstormingVM)
            {
                BrainstormingVM dataContext = this.DataContext as BrainstormingVM;
                ((this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).Clear();
                dataContext.QuickCommands_Left = this.QuickCommands_Left = this.AddQuickCommand(
                                                     new Thickness(-18, 0, 0, 0),
                                                     new Point(0, 0.5),
                                                     "Left",
                                                     dataContext.AddLeftChildCommand);
                dataContext.QuickCommands_Right = this.QuickCommands_Right = this.AddQuickCommand(
                                                      new Thickness(18, 0, 0, 0),
                                                      new Point(1, 0.5),
                                                      "Right",
                                                      dataContext.AddRightChildCommand);
                dataContext.QuickCommands_Delete = this.QuickCommands_Delete = this.AddQuickCommand(
                                                       new Thickness(22, 0, 0, 0),
                                                       new Point(1, 0.5),
                                                       "Delete",
                                                       dataContext.DeleteChildCommand);
                this.QuickCommands_Delete.VisibilityMode = VisibilityMode.Connector;
                (this.SelectedItems as SelectorViewModel).SelectorConstraints &= ~SelectorConstraints.Rotator;
                if (dataContext.Rootnode != null)
                {
                    dataContext.Rootnode.Constraints.Remove(NodeConstraints.ExcludeFromLayout);
                    dataContext.Updatebowtielayout("left");
                    dataContext.Updatebowtielayout("right");
                    dataContext.Rootnode.IsSelected = true;
                }
            }

            else if (DataContext is OrganizationChartDiagramVM)
            {
                OrganizationChartDiagramVM dataContext = (DataContext as OrganizationChartDiagramVM);
                ((SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).Clear();
                dataContext.Quickcommands_Add = Quickcommands_Add = AddQuickCommand(new Thickness(20, 0, 0, 0), new Point(1, 0), "Add", dataContext.AddChildCommand);                
                dataContext.Quickcommands_Delete = QuickCommands_Delete = AddQuickCommand(new Thickness(20, 20, 0, 0), new Point(1, 1), "Delete", dataContext.DeleteCommand);
                (SelectedItems as SelectorViewModel).SelectorConstraints &= ~SelectorConstraints.Rotator;
            }

            foreach(Window win in Application.Current.Windows)
            {
                if(win.DataContext is DiagramBuilderVM)
                {
                    (win.DataContext as DiagramBuilderVM).IsLoaded = true;
                }
            }
        }

        /// <summary>
        /// This method is used to notify when the diagram is unloaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Diagram_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= this.Diagram_Unloaded;
            this.KnownTypes = null;
        }

        /// <summary>
        /// This method returns the template of the quickcommand.
        /// </summary>
        /// <param name="item">
        /// The object that is actually display in the diagram.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object GetTemplate(string item)
        {
            object s = null;
            if (item == "Delete")
            {
                s =
                    "M1.0000023,3 L7.0000024,3 7.0000024,8.75 C7.0000024,9.4399996 6.4400025,10 5.7500024,10 L2.2500024,10 C1.5600024,10 1.0000023,9.4399996 1.0000023,8.75 z M2.0699998,0 L5.9300004,0 6.3420029,0.99999994 8.0000001,0.99999994 8.0000001,2 0,2 0,0.99999994 1.6580048,0.99999994 z";
            }
            else if (item == "Edit")
            {
                s = "M14.5,0.5C22.232,0.5 28.5,6.768 28.5,14.5C28.5,20.5406 24.6743,25.6877 19.3137,27.6505L19.2503,27.6728L18.9902,27.7644C17.5807,28.2414 16.0706,28.5 14.5,28.5C6.768,28.5 0.5,22.232 0.5,14.5C0.5, 8.58019 4.17419,3.51855 9.36655,1.47109C10.9561,0.844312 12.6878,0.5 14.5,0.5z";
            }
            else
            {
                s =
                    "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z";
            }

            return s;
        }

        /// <summary>
        /// This method updates the extension of the saved file.
        /// </summary>
        /// <param name="p">
        /// The p value is the extension string.
        /// </param>
        private void InvokeSave(string p)
        {
            this.Extension = p;
        }

        /// <summary>
        ///     The on exported method will export the diagram as image.
        /// </summary>
        private void OnExported()
        {
            string s = this.SaveFile(this.Extension);
            if (!string.IsNullOrEmpty(s))
            {
                ExportSettings es = new ExportSettings();

                // Method to Export the SfDiagram
                if ("XPS File(*.xps)|*.xps" == this.Extension)
                {
                    es.FileName = s;
                    es.IsSaveToXps = true;
                    this.ExportSettings = es;
                }
                else
                {
                    es.FileName = s;
                    this.ExportSettings = es;
                }

                // (this.ExportSettings as ExportSettings).ExportBitmapEncoder = guid;
                this.Export();
            }
        }

        /// <summary>
        /// The page_ loaded method will handle the commands. .
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.SelectedItems is FlowChartSelectorVm)
            {
                (this.SelectedItems as SelectorVM).Commands = null;
            }
        }

        /// <summary>
        /// The save file method will return the file name.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string SaveFile(string filter)
        {
            SaveFileDialog m_SaveFileDialog = new SaveFileDialog();
            m_SaveFileDialog = new SaveFileDialog();
            m_SaveFileDialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|Gif File(*.gif)|*.gif |JPEG File(*.jpeg)|*.jpeg |Png File(*.png)|*.png |Tiff File(*.tiff)|*.tiff |WDP File(*.wdp)|*.wdp|XPS File(*.xps)|*.xps";
            m_SaveFileDialog.FileName = "DiagramExport";
            m_SaveFileDialog.ShowDialog();
            string name = m_SaveFileDialog.FileName;
            string extension = Path.GetExtension(name);
            this.InvokeSave(extension);
            if (m_SaveFileDialog.FileName == name)
            {
                name = m_SaveFileDialog.FileName;
            }

            return name;
        }

#if !SyncfusionFramework4_5_1

        // We need to set the Keyboaed focus when Diagram is getting visible.
        /// <summary>
        ///     Gets the dummy visibility.
        /// </summary>
        public Visibility DummyVisibility
        {
            get
            {
                return (Visibility)this.GetValue(DummyVisibilityProperty);
            }

            private set
            {
                this.SetValue(DummyVisibilityProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for LocalVisibility.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The on visibility changed method will set the keyboard focus.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Keyboard.Focus(d as Diagram);
        }

#endif
    }
}