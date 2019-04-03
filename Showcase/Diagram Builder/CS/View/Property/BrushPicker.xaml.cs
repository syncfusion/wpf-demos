#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Controls.Primitives;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using Syncfusion.Windows.Controls.Input;
using System.Windows.Input;
using Syncfusion.Windows.Tools.Controls;
using DiagramBuilder.ViewModel;
using Syncfusion.UI.Xaml.Diagram;

namespace DiagramBuilder.View
{
    public sealed partial class BrushPicker : UserControl
    {
        public BrushPicker()
        {
            this.InitializeComponent();

        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(BrushPicker), new PropertyMetadata(Colors.Transparent, OnColorChanged));

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BrushPicker brush = d as BrushPicker;

            if ((brush.Brush as SolidColorBrush).Color != brush.Color)
            {
                //DiagramVM diagram = (brush.Tag as DiagramBuilderVM).SelectedDiagram as DiagramVM;
                //GroupTransactions group = new GroupTransactions();
                //group.ContinuousUndoRedo = ContinuousUndoRedo.Start;
                //diagram.HistoryManager.BeginComposite(diagram.HistoryManager, group);
                brush.Brush = new SolidColorBrush(brush.Color);

                var converter = new System.Windows.Media.BrushConverter();

                Brush brushS = (Brush)converter.ConvertFromString(e.NewValue.ToString());
                if ((brush.DataContext as DiagramButtonViewModel).Label == "Label")
                {
                    ((brush.Tag as DiagramBuilderVM).SelectedDiagram.SelectedItems as SelectorVM).LabelForeground = (brushS as SolidColorBrush);
                }
                else if ((brush.DataContext as DiagramButtonViewModel).Label == "Fill")
                {
                    ((brush.Tag as DiagramBuilderVM).SelectedDiagram.SelectedItems as SelectorVM).Fill = (brushS as SolidColorBrush);
                }
                else if ((brush.DataContext as DiagramButtonViewModel).Label == "Stroke")
                {
                    ((brush.Tag as DiagramBuilderVM).SelectedDiagram.SelectedItems as SelectorVM).Stroke = (brushS as SolidColorBrush);
                }

                brush.PickerTemp.IsDropDownOpen = false;
                //GroupTransactions group1 = new GroupTransactions();
                //group1.ContinuousUndoRedo = ContinuousUndoRedo.End;
                //diagram.HistoryManager.EndComposite(diagram.HistoryManager, group1);
            }
        }


        public Brush Brush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Brush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register("Brush", typeof(Brush), typeof(BrushPicker), new PropertyMetadata(new SolidColorBrush(Colors.Black), OnBrushChanged));


        private static void OnBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BrushPicker brush = d as BrushPicker;
            if (brush.Brush != null)
            {
                if ((brush.Brush as SolidColorBrush).Color != brush.Color)
                {
                    brush.Color = (brush.Brush as SolidColorBrush).Color;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.PickerTemp.IsDropDownOpen)
                this.PickerTemp.IsDropDownOpen = false;
            else
                this.PickerTemp.IsDropDownOpen = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var element = (sender as Button);
            if (element.Name == "label")
            {
                ((this.Tag as DiagramBuilderVM).SelectedDiagram.SelectedItems as SelectorVM).LabelForeground = (this.Brush as SolidColorBrush);
            }
            else if (element.Name == "fill")
            {
                ((this.Tag as DiagramBuilderVM).SelectedDiagram.SelectedItems as SelectorVM).Fill = (this.Brush as SolidColorBrush);
            }
            else if (element.Name == "line")
            {
                ((this.Tag as DiagramBuilderVM).SelectedDiagram.SelectedItems as SelectorVM).Stroke = (this.Brush as SolidColorBrush);
            }
        }
    }

    //public class SfColorPicker : SfColorPalette
    //{
    //    public SfColorPicker()
    //    {

    //    }

    //    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    //    {
    //        //base.OnPropertyChanged(e);
    //    }

    //    public Color Color
    //    {
    //        get { return (Color)GetValue(ColorProperty); }
    //        set { SetValue(ColorProperty, value); }
    //    }

    //    // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
    //    public static readonly DependencyProperty ColorProperty =
    //        DependencyProperty.Register("Color", typeof(Color), typeof(SfColorPicker), new PropertyMetadata(Colors.Black));


    //}

    class ListViewCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(ListViewCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            RibbonMenuItem listview = depObj as RibbonMenuItem;
            ColorPickerPalette colorpicker = depObj as ColorPickerPalette;
            if (listview != null)
            {
                listview.Click += listview_Click;
            } 
            if (colorpicker != null)
            {
                colorpicker.MoreColorWindowOpening += Colorpicker_MoreColorWindowOpening;
            }
        }

        private static void Colorpicker_MoreColorWindowOpening(object sender, MoreColorCancelEventArgs args)
        {
            ColorPickerPalette colorpicker = sender as ColorPickerPalette;
            if (colorpicker.Parent is StackPanel && (colorpicker.Parent as StackPanel).Parent is Popup)
                ((colorpicker.Parent as StackPanel).Parent as Popup).IsOpen = false;
        }

        private static void listview_Click(object sender, RoutedEventArgs e)
        {
            RibbonMenuItem listview = sender as RibbonMenuItem;
            if (listview != null)
            {

                ICommand command = listview.GetValue(CommandProperty) as ICommand;

                if (command != null)
                {
                    command.Execute(listview.Header);
                }
            }
        }


        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }
}
