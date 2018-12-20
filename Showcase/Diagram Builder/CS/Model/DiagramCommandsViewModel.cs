#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DiagramBuilder.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DiagramBuilder.Utility;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.Tools;
using System.Windows.Input;

namespace DiagramBuilder.Model
{
    public class DiagramCommandsViewModel : INotifyPropertyChanged
    {
        public DiagramCommandsViewModel(DiagramBuilderVM db)
        {
            PopulateCommands(db);
        }

        public void PopulateCommands(DiagramBuilderVM db)
        {
            DiagramVM dvm = db.SelectedDiagram;
            IGraphInfo gi = (dvm.Info as IGraphInfo);


            DiagramCommands = new ObservableCollection<DiagramCommandViewModel>()            
            {   
                AddViewmodel("Cut","Remove the selection and put it on the clipboard so you paste it somewhere else",Groups.Clipboard,Tabs.HOME,ICons.Cut.ToImageSource(),Controls.Button),
                 AddViewmodel("Paste","Add Content on the Clipboard to your document",Groups.Clipboard,Tabs.HOME,ICons.Paste.ToImageSource(),Controls.Button),
                 AddViewmodel("Copy","Put a copy of the selection on the clipboard so you paste it somewhere else",Groups.Clipboard,Tabs.HOME,ICons.Copy.ToImageSource(),Controls.Button),

                AddViewmodel("FontFamily","Pick a new Font for your text",Groups.Font,Tabs.HOME,ICons.Cut.ToImageSource(),Controls.FontFamily),
                AddViewmodel("FontSize","Change the size of your text",Groups.Font,Tabs.HOME,ICons.Cut.ToImageSource(),Controls.FontSize),
                AddViewmodel("GrowFont","Make your text a bit bigger",Groups.Font,Tabs.HOME,ICons.GrowFont.ToImageSource(),Controls.Button),
                AddViewmodel("DecreaseFont","Make your text a bit smaller",Groups.Font,Tabs.HOME,ICons.DecreaseFont.ToImageSource(),Controls.Button),
                AddViewmodel("Bold","Make your text Bold",Groups.Font,Tabs.HOME,ICons.Bold.ToImageSource(),Controls.ToggleButton),                      
                AddViewmodel("Italic","Italicize your text",Groups.Font,Tabs.HOME,ICons.Italic.ToImageSource(),Controls.ToggleButton), 
                AddViewmodel("Underline","Underline your text",Groups.Font,Tabs.HOME,ICons.Underline.ToImageSource(),Controls.ToggleButton),
                AddViewmodel("Strike","Cross something out by drawing a line through it",Groups.Font,Tabs.HOME,ICons.Strike.ToImageSource(),Controls.ToggleButton),
                AddViewmodel("Label","Change the color of your text",Groups.Font,Tabs.HOME,ICons.Label.ToImageSource(),Controls.ColorPicker),
                AddViewmodel("RotateText","Rotate Text 90 degrees to left",Groups.Font,Tabs.HOME,ICons.RotateText.ToImageSource(),Controls.ToggleButton ),
               


                AddViewmodel("Top","Align text to the top of the text block",Groups.Paragraph,Tabs.HOME,ICons.Top.ToImageSource(),Controls.ToggleButton),
                AddViewmodel("Middle","Align text so that it is centered between top and bottom of the text block",Groups.Paragraph,Tabs.HOME,ICons.TopLeft.ToImageSource(),Controls.ToggleButton),
                AddViewmodel("Bottom","Align text to the bottom of the text block",Groups.Paragraph,Tabs.HOME,ICons.Bottom.ToImageSource(),Controls.ToggleButton),

                AddViewmodel("Left","Align your content to the left",Groups.Paragraph,Tabs.HOME,ICons.Left.ToImageSource(),Controls.ToggleButton),
                AddViewmodel("Center","Center your content",Groups.Paragraph,Tabs.HOME,ICons.Center.ToImageSource(),Controls.ToggleButton),
                AddViewmodel("Right","Align your content to the right",Groups.Paragraph,Tabs.HOME,ICons.Right.ToImageSource(),Controls.ToggleButton),

                AddViewmodel("Pointer Tool","Select,move and resize objects.",Groups.Tools,Tabs.HOME,ICons.PointerTool.ToImageSource(),Controls.ToggleButton ),
                AddViewmodel("Text","Add a text shape or select existing text",Groups.Tools,Tabs.HOME,ICons.Text.ToImageSource(),Controls.ToggleButton ),
                AddViewmodel("Connector","Draw connectors between objects.",Groups.Tools,Tabs.HOME,ICons.Connector.ToImageSource(),Controls.ToggleButton ),
                AddViewmodel("DrawingTool","Use basic drawing tools such as rectangle,ellipse and line.",Groups.Tools,Tabs.HOME,ICons.DrawingTool_Rectangle.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Rectangle",ToolTipMessage="Drag to draw a rectangle", SmallIcon = ICons.DrawingTool_Rectangle.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Ellipse",ToolTipMessage="Drag to draw an ellipse", SmallIcon = ICons.DrawingTool_Ellipse.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Line",ToolTipMessage="Drag to draw a straight line", SmallIcon = ICons.DrawingTool_StraightLine.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "PolyLine",ToolTipMessage="Drag to draw a polyline", SmallIcon = ICons.Polyline.ToImageSource() },
                    new DiagramDropdownViewModel(){Header = "FreeHand",ToolTipMessage="Drag to draw a FreeHand", SmallIcon = ICons.ConnectorType_CubicBeier.ToImageSource() },
               }), 

                AddViewmodel("Port","Add or delete Ports on the shapes",Groups.Tools,Tabs.HOME,ICons.Port.ToImageSource(),Controls.ToggleButton ),
                AddViewmodel("SelectText","Select annotation on the shapes",Groups.Tools,Tabs.HOME,ICons.SelectText.ToImageSource(),Controls.ToggleButton ),

                AddViewmodel("Quick Style","Apply a visual effect to the selected shape such as shadow,glow,reflection",Groups.ShapeStyle,Tabs.HOME, ICons.Orientation.ToImageSource(),Controls.Galary,items1:new ObservableCollection<string>()
                {
                   "SubtleEffectAccent1", "SubtleEffectAccent2", "SubtleEffectAccent3", "SubtleEffectAccent4", "SubtleEffectAccent5", "SubtleEffectAccent6", "SubtleEffectAccent7",
                   "RefinedEffectAccent1", "RefinedEffectAccent2", "RefinedEffectAccent3", "RefinedEffectAccent4", "RefinedEffectAccent5", "RefinedEffectAccent6", "RefinedEffectAccent7",
                   "BalancedEffectAccent1", "BalancedEffectAccent2", "BalancedEffectAccent3", "BalancedEffectAccent4", "BalancedEffectAccent5", "BalancedEffectAccent6", "BalancedEffectAccent7",
                   "ModerateEffectAccent1", "ModerateEffectAccent2", "ModerateEffectAccent3", "ModerateEffectAccent4", "ModerateEffectAccent5", "ModerateEffectAccent6", "ModerateEffectAccent7",
                   "FocusedEffectAccent1", "FocusedEffectAccent2", "FocusedEffectAccent3", "FocusedEffectAccent4", "FocusedEffectAccent5", "FocusedEffectAccent6", "FocusedEffectAccent7",
                   "IntenseEffectAccent1", "IntenseEffectAccent2", "IntenseEffectAccent3", "IntenseEffectAccent4", "IntenseEffectAccent5", "IntenseEffectAccent6", "IntenseEffectAccent7",
                },
                lineitems:new ObservableCollection<string>()
                {
                   "SubtleEffectAccent1Line", "SubtleEffectAccent2Line", "SubtleEffectAccent3Line", "SubtleEffectAccent4Line", "SubtleEffectAccent5Line", "SubtleEffectAccent6Line", "SubtleEffectAccent7Line",
                   "ModerateEffectAccent1Line", "ModerateEffectAccent2Line", "ModerateEffectAccent3Line", "ModerateEffectAccent4Line", "ModerateEffectAccent5Line", "ModerateEffectAccent6Line", "ModerateEffectAccent7Line",
                   "IntenseEffectAccent1Line", "IntenseEffectAccent2Line", "IntenseEffectAccent3Line", "IntenseEffectAccent4Line", "IntenseEffectAccent5Line", "IntenseEffectAccent6Line", "IntenseEffectAccent7Line",
                }),
               AddViewmodel("Fill","Fill the selected shape with a solid color,gradient or pattern.",Groups.ShapeStyle,Tabs.HOME,ICons.Fill.ToImageSource(),Controls.ColorPicker),
               AddViewmodel("Stroke","Specify the color, width and line style for the selected shape",Groups.ShapeStyle,Tabs.HOME,ICons.Fill.ToImageSource(),Controls.ColorPicker),

               AddViewmodel("NewPage","Insert different kinds of pages into the diagram, such as background page",Groups.Pages,Tabs.INSERT,ICons.NewPage.ToImageSource(),Controls.SplitButton,items: new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Blank Page",ToolTipMessage="Insert a new blank page into the diagram", SmallIcon = ICons.NewPage.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Duplicate Page", ToolTipMessage="Insert a duplicate of the current page into the diagram",SmallIcon = ICons.DuplicatePage.ToImageSource() },
               }
               ),

               AddViewmodel("Pictures","Insert pictures from your computer or from other computers that you are connected to",Groups.Illustrations,Tabs.INSERT,ICons.Pictures.ToImageSource(),Controls.Button),

               AddViewmodel("Align","Position shapes on the page by changing their alignment.",Groups.Arrange,Tabs.HOME,ICons.Align.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Align Left",SmallIcon = ICons.AlignLeft.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Align Center",SmallIcon = ICons.AlignCenter.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Align Right",SmallIcon = ICons.AlignRight.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Align Top",SmallIcon = ICons.AlignTop.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Align Bottom",SmallIcon = ICons.AlignBottom.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Align Middle",SmallIcon = ICons.AlignMiddle.ToImageSource() },
               }),
               AddViewmodel("Position","Position shapes on the page by changing their alignment,spacing and rotation",Groups.Arrange,Tabs.HOME,ICons.Position.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Space Across", SmallIcon = ICons.SpaceAcross.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Space Down", SmallIcon = ICons.SpaceDown.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Flip Horizontal", SmallIcon = ICons.SpaceDown.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Flip Vertical", SmallIcon = ICons.SpaceDown.ToImageSource() },
               }),
               AddViewmodel("Bring to Front","Bring the selected object in front of all other objects",Groups.Arrange,Tabs.HOME,ICons.BringToFront.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Bring to Front",ToolTipMessage="Bring the selected object in front of all other objects", SmallIcon = ICons.BringToFront.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Bring Forward",ToolTipMessage="Bring the selected object forward one level so that it's hidden behind fewer objects", SmallIcon = ICons.BringForward.ToImageSource() },
               }),
               AddViewmodel("Send to Back","Send the selected object behind all other objects",Groups.Arrange,Tabs.HOME,ICons.SendToBack.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Send to Back",ToolTipMessage="Send the selected object behind all other objects", SmallIcon = ICons.SendToBack.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Send Backward",ToolTipMessage="Send the selected object back one level so that it's hidden behind more objects", SmallIcon = ICons.SendBackward.ToImageSource() },
               }),   
               AddViewmodel("Group","Join objects together to move and format them as if they were a single object",Groups.Arrange,Tabs.HOME,ICons.Group.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Group", ToolTipMessage="Join objects together to move and format them as if they were a single object", SmallIcon = ICons.Group.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "UnGroup",ToolTipMessage="Break the connection between joined objects so that you can move them individually", SmallIcon = ICons.UnGroup.ToImageSource() },
               }),
               AddViewmodel("Select","Select text or objects in your document",Groups.Editing,Tabs.HOME,ICons.Select.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Select All",ToolTipMessage="Select all text and objects", SmallIcon = ICons.SelectAll.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Select Nodes",ToolTipMessage="Select only the Nodes available in the diagram",SmallIcon = ICons.SelectNode.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Select Connectors",ToolTipMessage="Select only the Connectors available in the diagram", SmallIcon = ICons.SelectConnector.ToImageSource() },
               }),  

               AddViewmodel("Orientation","switch page between potrait and landscape layouts",Groups.PageSetup,Tabs.DESIGN,ICons.Orientation.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Portrait", SmallIcon = ICons.Potrait.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Landscape", SmallIcon = ICons.Landscape.ToImageSource() },
               }),

               AddViewmodel("Size","Choose a page size",Groups.PageSetup,Tabs.DESIGN,ICons.Size.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Letter", SmallIcon = ICons.Letter.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Folio", SmallIcon = ICons.Ledger.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Legal", SmallIcon = ICons.Legal.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Ledger", SmallIcon = ICons.Ledger.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "A5", SmallIcon = ICons.A5.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "A4", SmallIcon = ICons.A4.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "A3", SmallIcon = ICons.Letter.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "A2", SmallIcon = ICons.Legal.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "A1", SmallIcon = ICons.A5.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "A0", SmallIcon = ICons.A4.ToImageSource() },
               }),

               AddViewmodel("Connectors","Change the appearence of connectors in the diagram",Groups.PageSetup,Tabs.DESIGN,ICons.ConnectorType.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "Orthogonal", SmallIcon = ICons.ConnectorType_Orthogonal.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Straight Line", SmallIcon = ICons.ConnectorType_StraightLine.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "Cubic Bezier", SmallIcon = ICons.ConnectorType_CubicBeier.ToImageSource() },
               }),

              AddViewmodel("Ruler","Ruler","View the rulers used to measure and line up objects in the document",Groups.Show,Tabs.VIEW,ICons.Cut.ToImageSource(),Controls.CheckBox),
              AddViewmodel("Grid","Grid","The gridlines make it easy for you to align objects with text,other objects or a particular object",Groups.Show,Tabs.VIEW,ICons.Cut.ToImageSource(),Controls.CheckBox),
              AddViewmodel("Page Breaks","PageBreaks","Turn on Page breaks to see what will be printed on each page of your document",Groups.Show,Tabs.VIEW,ICons.Cut.ToImageSource(),Controls.CheckBox),
              AddViewmodel("Multiple Pages","MultiplePage","Helps you to create multiple pages depends on page width and page height",Groups.Show,Tabs.VIEW,ICons.Cut.ToImageSource(),Controls.CheckBox),
              AddViewmodel("Snap To Object","SnapToObject","Turn on guideline that help align objects in the document. Guidelines are dragged out from the horizontal and vertical ruler",Groups.Show,Tabs.VIEW,ICons.Cut.ToImageSource(),Controls.CheckBox),
              AddViewmodel("Snap To Grid","SnapToGrid","Helps to snap objects with respect to grid lines in the Diagram",Groups.Show,Tabs.VIEW,ICons.Cut.ToImageSource(),Controls.CheckBox),

              AddViewmodel("TaskPanes","Show windows to view shapes and shape data",Groups.Show,Tabs.VIEW,ICons.TaskPanes.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
               {
                   new DiagramDropdownViewModel(){Header = "PanZoom", SmallIcon = ICons.PanZoom.ToImageSource() },
                   new DiagramDropdownViewModel(){Header = "SizeandPosition", SmallIcon = ICons.SizeandPosition.ToImageSource() },
               }),

              AddViewmodel("Zoom","Zoom to the level that's right for you. For zoomier zooming,use the controls in the status bar",Groups.Zoom,Tabs.VIEW,ICons.Zoom.ToImageSource(),Controls.Button),
              AddViewmodel("FitToPage","Fit page to current window",Groups.Zoom,Tabs.VIEW,ICons.FitToPage.ToImageSource(),Controls.Button),
              AddViewmodel("FitToWidth","Fit page to current width",Groups.Zoom,Tabs.VIEW,ICons.Pagewidth.ToImageSource(),Controls.Button),


              // AddViewmodel(1,0,0,"Cut",Groups.ClipBoard,Tabs.Home,ICons.Cut.ToImageSource(),Controls.Button),
              //    AddViewmodel(0,0,0,"Paste",Groups.ClipBoard,Tabs.Home,ICons.Paste.ToImageSource(),Controls.Button),
              //   AddViewmodel(2,0,0,"Copy",Groups.ClipBoard,Tabs.Home,ICons.Copy.ToImageSource(),Controls.Button),

              //  AddViewmodel(0,1,0,"FontFamily",Groups.Font,Tabs.Home,ICons.Cut.ToImageSource(),Controls.FontFamily),
              //  AddViewmodel(1,1,0,"FontSize",Groups.Font,Tabs.Home,ICons.Cut.ToImageSource(),Controls.FontSize),
              //  AddViewmodel(2,1,0,"Bold",Groups.Font,Tabs.Home,ICons.Bold.ToImageSource(),Controls.ToggleButton), 
                 
              //  AddViewmodel(3,1,0,"Italic",Groups.Font,Tabs.Home,ICons.Italic.ToImageSource(),Controls.ToggleButton), 
              //  AddViewmodel(4,1,0,"Label",Groups.Font,Tabs.Home,ICons.Label.ToImageSource(),Controls.ColorPicker),

              //  //AddViewmodel("Underline",Groups.Font,Tabs.Home,ICons.Cut.ToImageSource(),Controls.Button),    

              //  AddViewmodel(0,2,0, "Top",Groups.Paragraph,Tabs.Home,ICons.Top.ToImageSource(),Controls.ToggleButton),
              //  AddViewmodel(1,2,0, "Middle",Groups.Paragraph,Tabs.Home,ICons.TopLeft.ToImageSource(),Controls.ToggleButton),
              //  AddViewmodel(2,2,0,"Bottom",Groups.Paragraph,Tabs.Home,ICons.Bottom.ToImageSource(),Controls.ToggleButton),

              //  AddViewmodel(3,2,0,"Left",Groups.Paragraph,Tabs.Home,ICons.Left.ToImageSource(),Controls.ToggleButton),
              //  AddViewmodel(4,2,0,"Center",Groups.Paragraph,Tabs.Home,ICons.Center.ToImageSource(),Controls.ToggleButton),
              //  AddViewmodel(5,2,0,"Right",Groups.Paragraph,Tabs.Home,ICons.Right.ToImageSource(),Controls.ToggleButton),

              //  AddViewmodel(0,3,0,"PointerTool",Groups.Tools,Tabs.Home,ICons.PointerTool.ToImageSource(),Controls.ToggleButton ),
              //  AddViewmodel(1,3,0,"Text",Groups.Tools,Tabs.Home,ICons.Text.ToImageSource(),Controls.ToggleButton ),
              //  AddViewmodel(2,3,0,"Connector",Groups.Tools,Tabs.Home,ICons.Connector.ToImageSource(),Controls.ToggleButton ),

              //  AddViewmodel(0,4,0,"Quick Style",Groups.ShapeStyle,Tabs.Home, ICons.Orientation.ToImageSource(),Controls.Galary,items1:new ObservableCollection<string>()
              //  {
              //     "OutLineBlack", "OutLineBlue", "OutLineRed", "OutLineOliveGreen", "OutLinePurple", "OutLineAqua", "OutLineOrange", "FillBlack", "FillBlue", "FillRed", "FillOliveGreen", "FillPurple","FillAqua", "FillOrange", "OutLineFillBlack", "OutLineFillBlue", "OutLineFillRed", "OutLineFillOliveGreen", "OutLineFillPurple", "OutLineFillAqua", "OutLineFillOrange", "SubtleEffectBlack", "SubtleEffectBlue", "SubtleEffectRed", "SubtleEffectOliveGreen", "SubtleEffectPurple", "SubtleEffectAqua", "SubtleEffectOrange", "ModerateEffectBlack", "ModerateEffectBlue", "ModerateEffectRed", "ModerateEffectOliveGreen", "ModerateEffectPurple", "ModerateEffectAqua", "ModerateEffectOrange"
              //  }),
              //  AddViewmodel(1,4,0,"Fill",Groups.ShapeStyle,Tabs.Home,ICons.Fill.ToImageSource(),Controls.ColorPicker),
              //  AddViewmodel(2,4,0,"Stroke",Groups.ShapeStyle,Tabs.Home,ICons.Fill.ToImageSource(),Controls.ColorPicker),

              // AddViewmodel(0,3,0,"NewPage",Groups.Pages,Tabs.Insert,ICons.NewPage.ToImageSource(),Controls.SplitButton,items: new ObservableCollection<DiagramDropdownViewModel>()
              // {
              //     new DiagramDropdownViewModel(){Header = "Blank Page", SmallIcon = ICons.NewPage.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "Duplicate Page", SmallIcon = ICons.NewPage.ToImageSource() },
              // }
              // ),
               
              // AddViewmodel(0,1,1,"Pictures",Groups.Illustrations,Tabs.Insert,ICons.Pictures.ToImageSource(),Controls.Button),

              // AddViewmodel(0,5,0, "Align",Groups.Arrange,Tabs.Home,ICons.Align.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
              // {
              //     new DiagramDropdownViewModel(){Header = "AlignLeft", SmallIcon = ICons.AlignLeft.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "AlignCenter", SmallIcon = ICons.AlignCenter.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "AlignRight", SmallIcon = ICons.AlignRight.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "AlignTop", SmallIcon = ICons.AlignTop.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "AlignBottom", SmallIcon = ICons.AlignBottom.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "AlignMiddle", SmallIcon = ICons.AlignMiddle.ToImageSource() },
              // }),
              // AddViewmodel(0,5,0,"Group",Groups.Arrange,Tabs.Home,ICons.Group.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
              // {
              //     new DiagramDropdownViewModel(){Header = "Group", SmallIcon = ICons.Group.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "UnGroup", SmallIcon = ICons.UnGroup.ToImageSource() },
              // }),
              // AddViewmodel(1,5,0,"BringToFront",Groups.Arrange,Tabs.Home,ICons.BringToFront.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
              // {
              //     new DiagramDropdownViewModel(){Header = "BringToFront", SmallIcon = ICons.BringToFront.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "BringForward", SmallIcon = ICons.BringForward.ToImageSource() },
              // }),
              // AddViewmodel(2,5,0,"SendToBack",Groups.Arrange,Tabs.Home,ICons.SendToBack.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
              // {
              //     new DiagramDropdownViewModel(){Header = "SendToBack", SmallIcon = ICons.SendToBack.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "SendBackward", SmallIcon = ICons.SendBackward.ToImageSource() },
              // }),  
              // AddViewmodel(0,6,0,"Select",Groups.Editing,Tabs.Home,ICons.PointerTool.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
              // {
              //     new DiagramDropdownViewModel(){Header = "SelectAll", SmallIcon = ICons.SendToBack.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "SelectNode", SmallIcon = ICons.SendBackward.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "SelectConnector", SmallIcon = ICons.SendBackward.ToImageSource() },
              // }),  

              // AddViewmodel(0,0,1, "Orientation",Groups.PageSetup,Tabs.Design,ICons.Orientation.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
              // {
              //     new DiagramDropdownViewModel(){Header = "Portrait", SmallIcon = ICons.Potrait.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "Landscape", SmallIcon = ICons.Landscape.ToImageSource() },
              // }),

              // AddViewmodel(1,0,1, "Size",Groups.PageSetup,Tabs.Design,ICons.Size.ToImageSource(),Controls.SplitButton,items:new ObservableCollection<DiagramDropdownViewModel>()
              // {
              //     new DiagramDropdownViewModel(){Header = "Letter", SmallIcon = ICons.Letter.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "Folio", SmallIcon = ICons.Ledger.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "Legal", SmallIcon = ICons.Legal.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "Ledger", SmallIcon = ICons.Ledger.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "A5", SmallIcon = ICons.A5.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "A4", SmallIcon = ICons.A4.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "A3", SmallIcon = ICons.Letter.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "A2", SmallIcon = ICons.Legal.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "A1", SmallIcon = ICons.A5.ToImageSource() },
              //     new DiagramDropdownViewModel(){Header = "A0", SmallIcon = ICons.A4.ToImageSource() },
              // }),

              //AddViewmodel(0,0,2, "Ruler",Groups.Show,Tabs.View,ICons.Cut.ToImageSource(),Controls.CheckBox),
              //AddViewmodel(1,0,2,"Grid",Groups.Show,Tabs.View,ICons.Cut.ToImageSource(),Controls.CheckBox),
              //AddViewmodel(2,0,2,"PageBreaks",Groups.Show,Tabs.View,ICons.Cut.ToImageSource(),Controls.CheckBox),
              //AddViewmodel(3,0,2,"MultiplePage",Groups.Show,Tabs.View,ICons.Cut.ToImageSource(),Controls.CheckBox),
              //AddViewmodel(4,0,2,"SnapToObject",Groups.Show,Tabs.View,ICons.Cut.ToImageSource(),Controls.CheckBox),
              //AddViewmodel(5,0,2,"SnapToGrid",Groups.Show,Tabs.View,ICons.Cut.ToImageSource(),Controls.CheckBox),

              //AddViewmodel(0,1,2,"Zoom",Groups.Zoom,Tabs.View,ICons.Zoom.ToImageSource(),Controls.Button),
              //AddViewmodel(1,1,2,"FitToPage",Groups.Zoom,Tabs.View,ICons.FitToPage.ToImageSource(),Controls.Button),
            
            };

            IEnumerable<IGrouping<Tabs, IGrouping<Groups, DiagramCommandViewModel>>> groups = from item in DiagramCommands
                                                                                              group item by item.TabName into results
                                                                                              from item1 in
                                                                                                  (from item2 in results group item2 by item2.GroupName)
                                                                                              group item1 by results.Key;


            PopulateTabs(groups);

            //PopulateRibbon(DiagramCommands);
        }

        //private void PopulateRibbon(ObservableCollection<DiagramCommandViewModel> DiagramCommands)
        //{
        //    DiagramTabs=new ObservableCollection<DiagramTabViewModel>();
        //    Dictionary<int,DiagramTabViewModel> list=new Dictionary<int, DiagramTabViewModel>();
        //    foreach (DiagramCommandViewModel vm in DiagramCommands)
        //    {
        //        DiagramTabViewModel dt = null;
        //        if (list.ContainsKey(dt.TabPosition))
        //            dt = new DiagramTabViewModel();
        //        dt.TabPosition = vm.TabPosition;
        //        list.Add(dt.TabPosition, dt);

        //       DiagramTabs.Add(dt);
        //       dt.DiagramGroups = new ObservableCollection<DiagramBarViewModel>();
        //        DiagramBarViewModel db = null;
        //        switch (vm.BarPosition)
        //        {
        //            case 0:
        //                db = new DiagramBarViewModel();
        //                db.BarPosition = vm.BarPosition;
        //                break;
        //            case 1:
        //                  db = new DiagramBarViewModel();
        //                db.BarPosition = vm.BarPosition;
        //                break;
        //            case 2:
        //                 db = new DiagramBarViewModel();
        //                db.BarPosition = vm.BarPosition;
        //                break;
        //            case 3:
        //                 db = new DiagramBarViewModel();
        //                db.BarPosition = vm.BarPosition;
        //                break;
        //            case 4:
        //                 db = new DiagramBarViewModel();
        //                db.BarPosition = vm.BarPosition;
        //                break;
        //            case 5:
        //                  db = new DiagramBarViewModel();
        //                db.BarPosition = vm.BarPosition;
        //                break;
        //        }
        //    }
        //}

        private DiagramCommandViewModel AddViewmodel(string p,string p2, Groups groups, Tabs tabs, string icon, Controls controls,
            ObservableCollection<DiagramDropdownViewModel> items = null, ObservableCollection<string> items1 = null,
            ObservableCollection<string> lineitems = null)
        {
            DiagramCommandViewModel dcvm = new DiagramCommandViewModel()
            {
                Label = p,
                ToolTipMessage=p2,
                ToolTipText = p,
                GroupName = groups,
                TabName = tabs,
                SmallIcon = icon,
                DisplayControl = controls,
                Items = items,
                Identifier=p,
                //ElementPosition = position,
                //BarPosition = barposition,
                //TabPosition = tabposition
            };
            if (items1 != null)
            {
                dcvm.GalaryItems = items1;
            }
            dcvm.GalaryLineItems = lineitems;
            return dcvm;
        }
        private DiagramCommandViewModel AddViewmodel(string p,string p1,string p2, Groups groups, Tabs tabs, string icon, Controls controls,
          ObservableCollection<DiagramDropdownViewModel> items = null, ObservableCollection<string> items1 = null,
          ObservableCollection<string> lineitems = null)
        {
            DiagramCommandViewModel dcvm = new DiagramCommandViewModel()
            {
                Label = p,
                Identifier = p1,
                ToolTipText = p,
                ToolTipMessage=p2,
                GroupName = groups,
                TabName = tabs,
                SmallIcon = icon,
                DisplayControl = controls,
                Items = items,
               
                //ElementPosition = position,
                //BarPosition = barposition,
                //TabPosition = tabposition
            };
            if (items1 != null)
            {
                dcvm.GalaryItems = items1;
            }
            dcvm.GalaryLineItems = lineitems;
            return dcvm;
        }
        private void PopulateTabs(IEnumerable<IGrouping<Tabs, IGrouping<Groups, DiagramCommandViewModel>>> groups)
        {
            DiagramTabs = new ObservableCollection<DiagramTabViewModel>();

            foreach (var firstgroups in groups)
            {
                DiagramTabViewModel vm = new DiagramTabViewModel();
                vm.Header = firstgroups.Key.ToString();
                DiagramTabs.Add(vm);
                vm.DiagramGroups = new ObservableCollection<DiagramBarViewModel>();
                foreach (var secondgroup in firstgroups)
                {
                    DiagramBarViewModel dbvm = new DiagramBarViewModel();
                    if (secondgroup.Key == Groups.ShapeStyle)
                    {
                        dbvm.Header = "Shape Styles";
                    }
                    else if (secondgroup.Key == Groups.PageSetup)
                    {
                        dbvm.Header = "Page Setup";
                    }
                    else
                    {
                        dbvm.Header = secondgroup.Key.ToString();
                    }
                    dbvm.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();
                    vm.DiagramGroups.Add(dbvm);
                    foreach (DiagramCommandViewModel thirdgroup in secondgroup)
                    {
                        DiagramButtonViewModel db = new DiagramButtonViewModel();
                        db.Label = thirdgroup.Label;
                        db.Identifier = thirdgroup.Identifier;
                        db.ToolTipText = thirdgroup.ToolTipText;
                        db.GroupName = thirdgroup.GroupName;
                        db.ToolTipMessage = thirdgroup.ToolTipMessage;
                        db.TabName = thirdgroup.TabName;
                        db.SmallIcon = thirdgroup.SmallIcon;
                        db.DisplayControl = thirdgroup.DisplayControl;
                        db.Items = thirdgroup.Items;
                        db.GalaryItems = thirdgroup.GalaryItems;
                        db.GalaryLineItems = thirdgroup.GalaryLineItems;
                        dbvm.DiagramButtons.Add(db);
                    }
                }
            }
        }

        public ObservableCollection<DiagramCommandViewModel> DiagramCommands { get; set; }
        public ObservableCollection<DiagramTabViewModel> DiagramTabs { get; set; }
        public DiagramBuilderVM DataCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class DiagramCommandViewModel : INotifyPropertyChanged
    {
        // Summary:
        //     Gets or sets the collapse label.
        public string CollapseLabel { get; set; }

        public CornerRadius CornerRadius { get; set; }
        public Stretch IconStretch { get; set; }

        public bool IsLargeImageVisible { get; set; }

        public bool IsMenuItem { get; set; }

        public bool IsMultiLine { get; set; }

        public bool IsSelected { get; set; }
        public bool IsSmallImageVisible { get; set; }

        public bool? IsToggle { get; set; }

        public string Label { get; set; }

        public string Identifier { get; set; }

        public ImageSource LargeIcon { get; set; }

        public SizeForm SizeForm { get; set; }

        public string SmallIcon { get; set; }

        public bool SplitLabelIntoTwoLine { get; set; }

        public string ToolTipText { get; set; }

        public string ToolTipMessage { get; set; }

        public Groups GroupName { get; set; }
        public Tabs TabName { get; set; }

        public Controls DisplayControl { get; set; }

        public DiagramVM SelectedDiagram { get; set; }

        public ICommand action { get; set; }

        public ObservableCollection<DiagramDropdownViewModel> Items { get; set; }


        public ObservableCollection<string> GalaryItems { get; set; }
        public ObservableCollection<string> GalaryLineItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public int ElementPosition { get; set; }
        public int BarPosition { get; set; }
        public int TabPosition { get; set; }
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }

 
}
