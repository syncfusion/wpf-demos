#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.MindMapDiagram.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows.Media;

namespace Syncfusion.UI.Xaml.MindMapDiagram
{
    public class MindMapDiagram : SfDiagram
    {
        private MindMapViewModel viewModel;
        QuickCommandViewModel Quickcommands_Delete;
        QuickCommandViewModel Quickcommands_Left;
        QuickCommandViewModel Quickcommands_Right;
        static MindMapDiagram()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MindMapDiagram), new FrameworkPropertyMetadata(typeof(MindMapDiagram)));
        }
        public MindMapDiagram()
        {
            ViewModel = new MindMapViewModel();
            SetValue(SelectedItemsProperty, DependencyProperty.UnsetValue);
            SetValue(ExportSettingsProperty, DependencyProperty.UnsetValue);
            SetValue(PrintingServiceProperty, DependencyProperty.UnsetValue);
            SetValue(PreviewSettingsProperty, DependencyProperty.UnsetValue);
            SetValue(PageSettingsProperty, DependencyProperty.UnsetValue);
            this.Loaded += MindMapDiagram_Loaded;
            this.KnownTypes = new GetTypes(GetKnownTypes);
            this.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF5F5F5"));
        }

        private void MindMapDiagram_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetBinding(SnapSettingsProperty,
               new Binding()
               {
                   Path = new PropertyPath("SnapSettings"),
                   Mode = BindingMode.TwoWay
               });
            this.SetBinding(CommandManagerProperty,
             new Binding()
             {
                 Path = new PropertyPath("CommandManager"),
                 Mode = BindingMode.TwoWay
             });
            this.SetBinding(ConstraintsProperty,
             new Binding()
             {
                 Path = new PropertyPath("Constraints"),
                 Mode = BindingMode.TwoWay
             });
            ((SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).Clear();
            ViewModel.Quickcommands_Left = Quickcommands_Left = AddQuickCommand(new Thickness(-18, 0, 0, 0), new Point(0, 0.5), "Left", ViewModel.AddLeftChildCommand);
            ViewModel.Quickcommands_Right = Quickcommands_Right = AddQuickCommand(new Thickness(18, 0, 0, 0), new Point(1, 0.5), "Right", ViewModel.AddRightChildCommand);
            ViewModel.Quickcommands_Delete = Quickcommands_Delete = AddQuickCommand(new Thickness(22, 0, 0, 0), new Point(1, 0.5), "Delete", ViewModel.DeleteChildCommand);
            Quickcommands_Delete.VisibilityMode = VisibilityMode.Connector;
            FitToPageParameter fitToPage = new FitToPageParameter() { FitToPage = FitToPage.FitToPage, Region = Region.PageSettings };
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(fitToPage);
        }

        #region Public Properties
        public MindMapViewModel ViewModel
        {
            get { return viewModel; }
            set
            {
                if (viewModel != value)
                {
                    viewModel = value;
                    OnPropertyChanged("ViewModel");
                }
            }
        }

        #endregion
        #region Override Methods
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
        }
        protected override UI.Xaml.Diagram.Selector GetSelectorForItemOverride(object item)
        {
            return new Selector();
        }
        protected override QuickCommand GetQuickCommandForItemOverride(object item)
        {
            return new Syncfusion.UI.Xaml.MindMapDiagram.View.QuickCommand();
        }
        protected override Syncfusion.UI.Xaml.Diagram.Node GetNodeForItemOverride(object item)
        {
            if (item is Syncfusion.UI.Xaml.MindMapDiagram.ViewModel.Root)
            {
                return new Syncfusion.UI.Xaml.MindMapDiagram.View.Root();
            }
            else
            {
                return new Syncfusion.UI.Xaml.MindMapDiagram.View.Child();
            }
        }
        #endregion
        #region Private Methods
        private IEnumerable<Type> GetKnownTypes()
        {
            List<Type> known = new List<Type>()
            {
                typeof(FontStyle),
                typeof(TextAlignment),
                typeof(HorizontalAlignment),
                typeof(VerticalAlignment),
                typeof(Visibility),
                typeof(Direction),
                typeof(ConnectorType),
                typeof(Thickness),
                typeof(DoubleCollection),
                typeof(FontWeight),
                typeof(Syncfusion.UI.Xaml.MindMapDiagram.ViewModel.Child),
                typeof(Syncfusion.UI.Xaml.MindMapDiagram.ViewModel.RootChild),
                typeof(Syncfusion.UI.Xaml.MindMapDiagram.ViewModel.Root),
                typeof(TextWrapping)
            };
            foreach (var item in known)
            {
                yield return item;
            }
        }
        public Style GetQuickCommandShapeStyle()
        {
            const string cTemplate = "<Style TargetType=\"Path\"" +
                      " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" >" +
                      " <Setter Property=\"Fill\" Value=\"#5B5B5B\">" +
                       " </Setter>" +
                       " <Setter Property=\"Stroke\" Value=\"#D4D4D4\">" +
                       " </Setter>" +
                       " <Setter Property=\"StrokeThickness\" Value=\"1\">" +
                       " </Setter>" +
                       " </Style>";

            return LoadXaml(cTemplate) as Style;
        }
        object LoadXaml(string xaml)
        {
            return XamlReader.Parse(xaml);
        }
        private QuickCommandViewModel AddQuickCommand(Thickness margin, Point offset, string content, ICommand command)
        {
            QuickCommandViewModel quickCommand = new QuickCommandViewModel()
            {
                Margin = margin,
                OffsetX = offset.X,
                OffsetY = offset.Y,
                Command = command,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                VisibilityMode = VisibilityMode.Node,
                Content = GetTemplate(content),
                Shape = "F1M23.467,11.733C23.467,18.213 18.214,23.466 11.734,23.466 5.253,23.466 0,18.213 0,11.733 0,5.253 5.253,0 11.734,0 18.214,0 23.467,5.253 23.467,11.733",
                ShapeStyle = GetQuickCommandShapeStyle(),
                ContentTemplate = GetQuickCommandContentTemplate()
            };
            ((this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).Add(quickCommand);
            return quickCommand;
        }
        public DataTemplate GetQuickCommandContentTemplate()
        {
            const string cTemplate = "<DataTemplate" +
                      " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" >" +
                      " <Path StrokeThickness =\"1\" Width =\"7.5\" Height=\"7.5\" Stretch =\"Uniform\" HorizontalAlignment = \"Center\" VerticalAlignment = \"Center\" " +
                           " RenderTransformOrigin = \"0.5,0.5\" Fill =\"{Binding Path=Tag, RelativeSource={RelativeSource Mode=TemplatedParent}}\" Data =\"{Binding Path=Content, RelativeSource={RelativeSource Mode=TemplatedParent}}\">" +
                       " </Path>" +
                       " </DataTemplate>";

            return LoadXaml(cTemplate) as DataTemplate;
        }
        private object GetTemplate(string item)
        {
            object s = null;
            if (item == "Delete")
            {
                s = "M1.0000023,3 L7.0000024,3 7.0000024,8.75 C7.0000024,9.4399996 6.4400025,10 5.7500024,10 L2.2500024,10 C1.5600024,10 1.0000023,9.4399996 1.0000023,8.75 z M2.0699998,0 L5.9300004,0 6.3420029,0.99999994 8.0000001,0.99999994 8.0000001,2 0,2 0,0.99999994 1.6580048,0.99999994 z";
            }
            else
            {
                s = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z";
            }
            return s;
        }
        #endregion
    }
}
