#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DiagramBuilder.Utility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DiagramBuilder.ViewModel
{

    public class DiagramTabViewModel
    {
        public DiagramTabViewModel()
        {


        }
        public string Header { get; set; }
        public int TabPosition { get; set; }
        public ObservableCollection<DiagramBarViewModel> DiagramGroups { get; set; }
    }

    public class DiagramBarViewModel
    {
        public DiagramBarViewModel()
        {

        }

        public int BarPosition { get; set; }
        public string Header { get; set; }
        public double BarWidth { get; set; }
        public ObservableCollection<DiagramButtonViewModel> DiagramButtons { get; set; }
    }

    public class DiagramButtonViewModel
    {
        public DiagramButtonViewModel()
        {

        }
        public int ElementPosition { get; set; }
        public string Label { get; set; }
        public string Identifier { get; set; }
        public string ToolTipText { get; set; }
        public string ToolTipMessage { get; set; }
        public Groups GroupName { get; set; }
        public Tabs TabName { get; set; }

        public ICommand Command { get; set; }

        public string CommandParameter { get; set; }

        public string SmallIcon { get; set; }

        public Controls DisplayControl { get; set; }

        public ICommand DataCommand { get; set; }

        public DiagramVM SelectedDiagram { get; set; }

        public bool? Toggle { get; set; }

        public ObservableCollection<DiagramDropdownViewModel> Items { get; set; }

        public ObservableCollection<string> ItemString { get; set; }

        public ObservableCollection<string> GalaryItems { get; set; }
        public ObservableCollection<string> GalaryLineItems { get; set; } 
    }

    public class DiagramDropdownViewModel
    {
        public DiagramDropdownViewModel()
        {

        }

        public string Header { get; set; }

        public string SmallIcon { get; set; }

        public string ToolTipText { get; set; }

        public string ToolTipMessage { get; set; }

    }

    public class DiagramButton : RibbonButton
    {
        public DiagramButton()
        {

        }
        public DiagramBuilderVM ParentVM
        {
            get { return (DiagramBuilderVM)GetValue(ParentVMProperty); }
            set { SetValue(ParentVMProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentVM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParentVMProperty =
            DependencyProperty.Register("ParentVM", typeof(DiagramBuilderVM), typeof(DiagramButton), new PropertyMetadata(null));
    }

    public class DiagramToggleButton : RibbonToggleButton
    {
        public DiagramToggleButton()
        {

        }

        public DiagramBuilderVM ParentVM
        {
            get { return (DiagramBuilderVM)GetValue(ParentVMProperty); }
            set { SetValue(ParentVMProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentVM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParentVMProperty =
            DependencyProperty.Register("ParentVM", typeof(DiagramBuilderVM), typeof(DiagramToggleButton), new PropertyMetadata(null));
    }

    public class DisplayControlSelector : DataTemplateSelector
    {
        public DataTemplate ButtonDataTemplate { get; set; }
        public DataTemplate ToggleButtonDataTemplate { get; set; }
        public DataTemplate FontFamilyComboboxDataTemplate { get; set; }
        public DataTemplate ComboboxDataTemplate { get; set; }
        public DataTemplate FontSizeComboboxDataTemplate { get; set; }
        public DataTemplate SplitButtonDataTemplate { get; set; }
        public DataTemplate ColorPickerDataTemplate { get; set; }
        public DataTemplate CheckBoxDataTemplate { get; set; }
        public DataTemplate GalaryDataTemplate { get; set; }

Dictionary<string, DataTemplate> datatemp = null;

        public override DataTemplate SelectTemplate(object item,
                                                DependencyObject container)
        {

            PopulateCollection();

            DiagramButtonViewModel db = item as DiagramButtonViewModel;
            var results = datatemp.Where(x => x.Key == db.DisplayControl.ToString()).Select(g => g.Value).Distinct();
            return results.FirstOrDefault();
        }

        private void PopulateCollection()
        {
            datatemp = new Dictionary<string, DataTemplate>();
            datatemp.Add("Button", ButtonDataTemplate);
            datatemp.Add("ToggleButton", ToggleButtonDataTemplate);
            datatemp.Add("FontFamily", FontFamilyComboboxDataTemplate);
            datatemp.Add("FontSize", FontSizeComboboxDataTemplate);
            datatemp.Add("ColorPicker", ColorPickerDataTemplate);
            datatemp.Add("CheckBox", CheckBoxDataTemplate);
            datatemp.Add("SplitButton", SplitButtonDataTemplate);
            datatemp.Add("Galary", GalaryDataTemplate);
    }
}

    public class DisplayGroupSelector : DataTemplateSelector
    {       

        public DataTemplate ClipBoardDataTemplate { get; set; }
        public DataTemplate FontDataTemplate { get; set; }
        public DataTemplate ParagraphDataTemplate { get; set; }
        public DataTemplate AlignmentDataTemplate { get; set; }
        public DataTemplate ToolsDataTemplate { get; set; }
        public DataTemplate ShapeStyleDataTemplate { get; set; }
        public DataTemplate ArrangeDataTemplate { get; set; }
        public DataTemplate EditingDataTemplate { get; set; }
        public DataTemplate ShowDataTemplate { get; set; }
        Dictionary<string, DataTemplate> datatemp = null;

        public override DataTemplate SelectTemplate(object item,
                                                DependencyObject container)
        {

            PopulateCollection();

            DiagramBarViewModel db = item as DiagramBarViewModel;
            return datatemp[db.Header.ToString()];
        }

        private void PopulateCollection()
        {
            datatemp = new Dictionary<string, DataTemplate>();
            datatemp.Add(Groups.Clipboard.ToString(), ClipBoardDataTemplate);
            datatemp.Add(Groups.Font.ToString(), FontDataTemplate);
            datatemp.Add(Groups.Paragraph.ToString(), ParagraphDataTemplate);
            datatemp.Add(Groups.Alignment.ToString(), AlignmentDataTemplate);
            datatemp.Add(Groups.Tools.ToString(), ToolsDataTemplate);
            datatemp.Add(Groups.ShapeStyle.ToString(), ShapeStyleDataTemplate);
            datatemp.Add(Groups.Editing.ToString(), EditingDataTemplate);
            datatemp.Add(Groups.Arrange.ToString(), ArrangeDataTemplate);
            datatemp.Add(Groups.Show.ToString(), ShowDataTemplate);
            //datatemp.Add("Button", ButtonDataTemplate);
            //datatemp.Add("BoldButton", BoldButtonDataTemplate);
            //datatemp.Add("ItalicButton", ItalicButtonDataTemplate);
            //datatemp.Add("FontFamily", FontFamilyComboboxDataTemplate);

            //datatemp.Add("FontSize", FontSizeComboboxDataTemplate);

            //datatemp.Add("ColorPicker", ColorPickerDataTemplate);

            //datatemp.Add("TopLeftAlignment", TopLeftAlignmentDataTemplate);
            //datatemp.Add("TopAlignment", TopAlignmentDataTemplate);
            //datatemp.Add("TopRightAlignment", TopRightAlignmentDataTemplate);

            //datatemp.Add("LeftAlignment", LeftAlignmentDataTemplate);
            //datatemp.Add("CenterAlignment", CenterAlignmentDataTemplate);
            //datatemp.Add("RightAlignment", RightAlignmentDataTemplate);


            //datatemp.Add("BottomLeftAlignment", BottomLeftAlignmentDataTemplate);
            //datatemp.Add("BottomAlignment", BottomAlignmentDataTemplate);
            //datatemp.Add("BottomRightAlignment", BottomRightAlignmentDataTemplate);
            //datatemp.Add("CheckBox", CheckBoxDataTemplate);
        }

       
    }


}
