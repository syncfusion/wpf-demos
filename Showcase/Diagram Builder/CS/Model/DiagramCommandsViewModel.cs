#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Syncfusion.Windows.Shared;

namespace DiagramBuilder.Model
{
    public class DiagramCommandsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DiagramTabViewModel> DiagramTabs { get; set; }

        DiagramTabViewModel brainstormingTab;

        private void PopulateTabs()
        {
            #region Home

            DiagramTabViewModel homeTab = new DiagramTabViewModel();
            homeTab.Header = "HOME";
            homeTab.DiagramGroups = new ObservableCollection<DiagramBarViewModel>();

            #region Clipboard

            DiagramBarViewModel clipboard = new DiagramBarViewModel();
            clipboard.Header = "Clibboard";
            clipboard.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

            #region Paste
            DiagramButtonViewModel paste = new DiagramButtonViewModel();
            paste.DisplayControl = Controls.Button;
            paste.Label = "Paste";
            paste.SmallIcon = ICons.Paste.ToImageSource();
            paste.ToolTipMessage = "Add Content on the Clipboard to your document";
            clipboard.DiagramButtons.Add(paste);
            #endregion

            #region Cut
            DiagramButtonViewModel cut = new DiagramButtonViewModel();
            cut.DisplayControl = Controls.Button;
            cut.Label = "Cut";
            cut.SmallIcon = ICons.Cut.ToImageSource();
            cut.ToolTipMessage = "Remove the selection and put it on the clipboard so you paste it somewhere else";
            clipboard.DiagramButtons.Add(cut);
            #endregion

            #region Copy
            DiagramButtonViewModel copy = new DiagramButtonViewModel();
            copy.DisplayControl = Controls.Button;
            copy.Label = "Copy";
            copy.SmallIcon = ICons.Copy.ToImageSource();
            copy.ToolTipMessage = "Put a copy of the selection on the clipboard so you paste it somewhere else";
            clipboard.DiagramButtons.Add(copy);
            #endregion
        
            homeTab.DiagramGroups.Add(clipboard);

            #endregion

            #region Font

            DiagramBarViewModel font = new DiagramBarViewModel();
            font.Header = "Font";
            font.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();
   
            #region FontFamily
            DiagramButtonViewModel fontfamily = new DiagramButtonViewModel();
            fontfamily.DisplayControl = Controls.FontFamily;
            fontfamily.Label = "FontFamily";
            fontfamily.SmallIcon = ICons.Cut.ToImageSource();
            fontfamily.ToolTipMessage = "Pick a new Font for your text";
            font.DiagramButtons.Add(fontfamily);
            #endregion

            #region FontSize
            DiagramButtonViewModel fontsize = new DiagramButtonViewModel();
            fontsize.DisplayControl = Controls.FontSize;
            fontsize.Label = "FontSize";
            fontsize.SmallIcon = ICons.Cut.ToImageSource();
            fontsize.ToolTipMessage = "Change the size of your text";
            font.DiagramButtons.Add(fontsize);
            #endregion

            #region GrowFont
            DiagramButtonViewModel growfont = new DiagramButtonViewModel();
            growfont.DisplayControl = Controls.Button;
            growfont.Label = "GrowFont";
            growfont.SmallIcon = ICons.GrowFont.ToImageSource();
            growfont.ToolTipMessage = "Make your text a bit bigger";
            font.DiagramButtons.Add(growfont);
            #endregion

            #region DecreaseFont
            DiagramButtonViewModel decreasefont = new DiagramButtonViewModel();
            decreasefont.DisplayControl = Controls.Button;
            decreasefont.Label = "DecreaseFont";
            decreasefont.SmallIcon = ICons.DecreaseFont.ToImageSource();
            decreasefont.ToolTipMessage = "Make your text a bit smaller";
            font.DiagramButtons.Add(decreasefont);
            #endregion

            #region Bold
            DiagramButtonViewModel bold = new DiagramButtonViewModel();
            bold.DisplayControl = Controls.ToggleButton;
            bold.Label = "Bold";
            bold.SmallIcon = ICons.Bold.ToImageSource();
            bold.ToolTipMessage = "Make your text Bold";
            font.DiagramButtons.Add(bold);
            #endregion

            #region Italic
            DiagramButtonViewModel italic = new DiagramButtonViewModel();
            italic.DisplayControl = Controls.ToggleButton;
            italic.Label = "Italic";
            italic.SmallIcon = ICons.Italic.ToImageSource();
            italic.ToolTipMessage = "Italicize your text";
            font.DiagramButtons.Add(italic);
            #endregion

            #region Underline
            DiagramButtonViewModel underline = new DiagramButtonViewModel();
            underline.DisplayControl = Controls.ToggleButton;
            underline.Label = "Underline";
            underline.SmallIcon = ICons.Underline.ToImageSource();
            underline.ToolTipMessage = "Underline your text";
            font.DiagramButtons.Add(underline);
            #endregion


            #region Strike
            DiagramButtonViewModel strike = new DiagramButtonViewModel();
            strike.DisplayControl = Controls.ToggleButton;
            strike.Label = "Strike";
            strike.SmallIcon = ICons.Strike.ToImageSource();
            strike.ToolTipMessage = "Cross something out by drawing a line through it";
            font.DiagramButtons.Add(strike);
            #endregion

            #region Label
            DiagramButtonViewModel label = new DiagramButtonViewModel();
            label.DisplayControl = Controls.ColorPicker;
            label.Label = "Label";
            label.SmallIcon = ICons.Label.ToImageSource();
            label.ToolTipMessage = "Change the color of your text";
            font.DiagramButtons.Add(label);
            #endregion

            #region RotateText
            DiagramButtonViewModel rotatetext = new DiagramButtonViewModel();
            rotatetext.DisplayControl = Controls.ToggleButton;
            rotatetext.Label = "RotateText";
            rotatetext.SmallIcon = ICons.RotateText.ToImageSource();
            rotatetext.ToolTipMessage = "Rotate Text 90 degrees to left";
            font.DiagramButtons.Add(rotatetext);
            #endregion

            homeTab.DiagramGroups.Add(font);

            #endregion

            #region Paragraph

            DiagramBarViewModel paragraph = new DiagramBarViewModel();
            paragraph.Header = "Paragraph";
            paragraph.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

            #region Top
            DiagramButtonViewModel top = new DiagramButtonViewModel();
            top.DisplayControl = Controls.ToggleButton;
            top.Label = "Top";
            top.SmallIcon = ICons.Top.ToImageSource();
            top.ToolTipMessage = "Align text to the top of the text block";
            paragraph.DiagramButtons.Add(top);
            #endregion

            #region Middle
            DiagramButtonViewModel middle = new DiagramButtonViewModel();
            middle.DisplayControl = Controls.ToggleButton;
            middle.Label = "Middle";
            middle.SmallIcon = ICons.TopLeft.ToImageSource();
            middle.ToolTipMessage = "Align text so that it is centered between top and bottom of the text block";
            paragraph.DiagramButtons.Add(middle);
            #endregion

            #region Bottom
            DiagramButtonViewModel bottom = new DiagramButtonViewModel();
            bottom.DisplayControl = Controls.ToggleButton;
            bottom.Label = "Bottom";
            bottom.SmallIcon = ICons.Bottom.ToImageSource();
            bottom.ToolTipMessage = "Align text to the bottom of the text block";
            paragraph.DiagramButtons.Add(bottom);
            #endregion

            #region Left
            DiagramButtonViewModel left = new DiagramButtonViewModel();
            left.DisplayControl = Controls.ToggleButton;
            left.Label = "Left";
            left.SmallIcon = ICons.Left.ToImageSource();
            left.ToolTipMessage = "Align your content to the left";
            paragraph.DiagramButtons.Add(left);
            #endregion

            #region Center
            DiagramButtonViewModel center = new DiagramButtonViewModel();
            center.DisplayControl = Controls.ToggleButton;
            center.Label = "Center";
            center.SmallIcon = ICons.Center.ToImageSource();
            center.ToolTipMessage = "Center your content";
            paragraph.DiagramButtons.Add(center);
            #endregion

            #region Right
            DiagramButtonViewModel right = new DiagramButtonViewModel();
            right.DisplayControl = Controls.ToggleButton;
            right.Label = "Right";
            right.SmallIcon = ICons.Right.ToImageSource();
            right.ToolTipMessage = "Align your content to the right";
            paragraph.DiagramButtons.Add(right);
            #endregion

            homeTab.DiagramGroups.Add(paragraph);

            #endregion

            #region Tools

            DiagramBarViewModel tools = new DiagramBarViewModel();
            tools.Header = "Tools";
            tools.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

            #region Pointer Tool
            DiagramButtonViewModel pointertool = new DiagramButtonViewModel();
            pointertool.DisplayControl = Controls.ToggleButton;
            pointertool.Label = "Pointer Tool";
            pointertool.SmallIcon = ICons.PointerTool.ToImageSource();
            pointertool.ToolTipMessage = "Select,move and resize objects.";
            tools.DiagramButtons.Add(pointertool);
            #endregion

            #region Text
            DiagramButtonViewModel text = new DiagramButtonViewModel();
            text.DisplayControl = Controls.ToggleButton;
            text.Label = "Text";
            text.SmallIcon = ICons.Text.ToImageSource();
            text.ToolTipMessage = "Add a text shape or select existing text";
            tools.DiagramButtons.Add(text);
            #endregion

            #region Connector
            DiagramButtonViewModel connector = new DiagramButtonViewModel();
            connector.DisplayControl = Controls.ToggleButton;
            connector.Label = "Connector";
            connector.SmallIcon = ICons.Connector.ToImageSource();
            connector.ToolTipMessage = "Draw connectors between objects.";
            tools.DiagramButtons.Add(connector);
            #endregion

            #region DrawingTool
            DiagramButtonViewModel drawingtool = new DiagramButtonViewModel();
            drawingtool.DisplayControl = Controls.SplitButton;
            drawingtool.Label = "DrawingTool";
            drawingtool.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Rectangle
            DiagramDropdownViewModel rectangle = new DiagramDropdownViewModel();
            rectangle.Header = "Rectangle";
            rectangle.ToolTipMessage = "Drag to draw a rectangle";
            rectangle.SmallIcon = ICons.DrawingTool_Rectangle.ToImageSource();
            drawingtool.Items.Add(rectangle);
            #endregion

            #region Ellipse
            DiagramDropdownViewModel ellipse = new DiagramDropdownViewModel();
            ellipse.Header = "Ellipse";
            ellipse.ToolTipMessage = "Drag to draw a ellipse";
            ellipse.SmallIcon = ICons.DrawingTool_Ellipse.ToImageSource();
            drawingtool.Items.Add(ellipse);
            #endregion

            #region Line
            DiagramDropdownViewModel line = new DiagramDropdownViewModel();
            line.Header = "Line";
            line.ToolTipMessage = "Drag to draw a straight line";
            line.SmallIcon = ICons.DrawingTool_StraightLine.ToImageSource();
            drawingtool.Items.Add(line);
            #endregion

            #region PolyLine
            DiagramDropdownViewModel polyline = new DiagramDropdownViewModel();
            polyline.Header = "PolyLine";
            polyline.ToolTipMessage = "Drag to draw a polyline";
            polyline.SmallIcon = ICons.Polyline.ToImageSource();
            drawingtool.Items.Add(polyline);
            #endregion

            #region FreeHand
            DiagramDropdownViewModel freehand = new DiagramDropdownViewModel();
            freehand.Header = "FreeHand";
            freehand.ToolTipMessage = "Drag to draw a freehand";
            freehand.SmallIcon = ICons.ConnectorType_CubicBeier.ToImageSource();
            drawingtool.Items.Add(freehand);
            #endregion

            drawingtool.SmallIcon = ICons.Left.ToImageSource();
            drawingtool.ToolTipMessage = "Use basic drawing tools such as rectangle,ellipse and line.";
            tools.DiagramButtons.Add(drawingtool);
            #endregion

            #region Port
            DiagramButtonViewModel port = new DiagramButtonViewModel();
            port.DisplayControl = Controls.ToggleButton;
            port.Label = "Port";
            port.SmallIcon = ICons.Port.ToImageSource();
            port.ToolTipMessage = "Add or delete Ports on the shapes";
            tools.DiagramButtons.Add(port);        
            #endregion

            #region SelectText
            DiagramButtonViewModel selecttext = new DiagramButtonViewModel();
            selecttext.DisplayControl = Controls.ToggleButton;
            selecttext.Label = "SelectText";
            selecttext.SmallIcon = ICons.SelectText.ToImageSource();
            selecttext.ToolTipMessage = "Select annotation on the shapes";
            tools.DiagramButtons.Add(selecttext);
            #endregion

            homeTab.DiagramGroups.Add(tools);

            #endregion

            #region Shape Styles

            DiagramBarViewModel shapestyles = new DiagramBarViewModel();
            shapestyles.Header = "Shape Styles";
            shapestyles.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

            #region Quick Style
            DiagramButtonViewModel quickstyle = new DiagramButtonViewModel();
            quickstyle.DisplayControl = Controls.Galary;
            quickstyle.Label = "Quick Style";
            quickstyle.GalaryItems = new ObservableCollection<string>()
            {
                    "SubtleEffectAccent1", "SubtleEffectAccent2", "SubtleEffectAccent3", "SubtleEffectAccent4", "SubtleEffectAccent5", "SubtleEffectAccent6", "SubtleEffectAccent7",
                   "RefinedEffectAccent1", "RefinedEffectAccent2", "RefinedEffectAccent3", "RefinedEffectAccent4", "RefinedEffectAccent5", "RefinedEffectAccent6", "RefinedEffectAccent7",
                   "BalancedEffectAccent1", "BalancedEffectAccent2", "BalancedEffectAccent3", "BalancedEffectAccent4", "BalancedEffectAccent5", "BalancedEffectAccent6", "BalancedEffectAccent7",
                   "ModerateEffectAccent1", "ModerateEffectAccent2", "ModerateEffectAccent3", "ModerateEffectAccent4", "ModerateEffectAccent5", "ModerateEffectAccent6", "ModerateEffectAccent7",
                   "FocusedEffectAccent1", "FocusedEffectAccent2", "FocusedEffectAccent3", "FocusedEffectAccent4", "FocusedEffectAccent5", "FocusedEffectAccent6", "FocusedEffectAccent7",
                   "IntenseEffectAccent1", "IntenseEffectAccent2", "IntenseEffectAccent3", "IntenseEffectAccent4", "IntenseEffectAccent5", "IntenseEffectAccent6", "IntenseEffectAccent7",
            };
            quickstyle.GalaryLineItems = new ObservableCollection<string>()
            {
                "SubtleEffectAccent1Line", "SubtleEffectAccent2Line", "SubtleEffectAccent3Line", "SubtleEffectAccent4Line", "SubtleEffectAccent5Line", "SubtleEffectAccent6Line", "SubtleEffectAccent7Line",
                   "ModerateEffectAccent1Line", "ModerateEffectAccent2Line", "ModerateEffectAccent3Line", "ModerateEffectAccent4Line", "ModerateEffectAccent5Line", "ModerateEffectAccent6Line", "ModerateEffectAccent7Line",
                   "IntenseEffectAccent1Line", "IntenseEffectAccent2Line", "IntenseEffectAccent3Line", "IntenseEffectAccent4Line", "IntenseEffectAccent5Line", "IntenseEffectAccent6Line", "IntenseEffectAccent7Line",
            };
            quickstyle.SmallIcon = ICons.Orientation.ToImageSource();
            quickstyle.ToolTipMessage = "Apply a visual effect to the selected shape such as shadow,glow,reflection";
            shapestyles.DiagramButtons.Add(quickstyle);
            #endregion

            # region Fill
            DiagramButtonViewModel fill = new DiagramButtonViewModel();
            fill.DisplayControl = Controls.ColorPicker;
            fill.Label = "Fill";
            fill.SmallIcon = ICons.Fill.ToImageSource();
            fill.ToolTipMessage = "Fill the selected shape with a solid color,gradient or pattern.";
            shapestyles.DiagramButtons.Add(fill);
            #endregion

            #region Stroke
            DiagramButtonViewModel stroke = new DiagramButtonViewModel();
            stroke.DisplayControl = Controls.ColorPicker;
            stroke.Label = "Stroke";
            stroke.SmallIcon = ICons.Fill.ToImageSource();
            stroke.ToolTipMessage = "Specify the color, width and line style for the selected shape";
            shapestyles.DiagramButtons.Add(stroke);
            #endregion

            homeTab.DiagramGroups.Add(shapestyles);

            #endregion

            #region Arrange

            DiagramBarViewModel arrange = new DiagramBarViewModel();
            arrange.Header = "Arrange";
            arrange.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

            #region Align
            DiagramButtonViewModel align = new DiagramButtonViewModel();
            align.DisplayControl = Controls.SplitButton;
            align.Label = "Align";
            align.SmallIcon = ICons.Align.ToImageSource();
            align.ToolTipMessage = "Position shapes on the page by changing their alignment.";
            align.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Align Left
            DiagramDropdownViewModel alignleft = new DiagramDropdownViewModel();
            alignleft.Header = "Align Left";
            alignleft.SmallIcon = ICons.AlignLeft.ToImageSource();
            align.Items.Add(alignleft);
            #endregion

            #region Align Center
            DiagramDropdownViewModel aligncenter = new DiagramDropdownViewModel();
            aligncenter.Header = "Align Center";
            aligncenter.SmallIcon = ICons.AlignCenter.ToImageSource();
            align.Items.Add(aligncenter);
            #endregion

            #region Align Right
            DiagramDropdownViewModel alignright = new DiagramDropdownViewModel();
            alignright.Header = "Align Right";
            alignright.SmallIcon = ICons.AlignRight.ToImageSource();
            align.Items.Add(alignright);
            #endregion

            #region Align Top
            DiagramDropdownViewModel aligntop = new DiagramDropdownViewModel();
            aligntop.Header = "Align Top";
            aligntop.SmallIcon = ICons.AlignTop.ToImageSource();
            align.Items.Add(aligntop);
            #endregion

            #region Align Bottom
            DiagramDropdownViewModel alignbottom = new DiagramDropdownViewModel();
            alignbottom.Header = "Align Bottom";
            alignbottom.SmallIcon = ICons.AlignBottom.ToImageSource();
            align.Items.Add(alignbottom);
            #endregion

            #region Align Middle
            DiagramDropdownViewModel alignmiddle = new DiagramDropdownViewModel();
            alignmiddle.Header = "Align Middle";
            alignmiddle.SmallIcon = ICons.AlignMiddle.ToImageSource();
            align.Items.Add(alignmiddle);
            #endregion

            arrange.DiagramButtons.Add(align);
            #endregion

            #region Position
            DiagramButtonViewModel position = new DiagramButtonViewModel();
            position.DisplayControl = Controls.SplitButton;
            position.Label = "Position";
            position.SmallIcon = ICons.Position.ToImageSource();
            position.ToolTipMessage = "Position shapes on the page by changing their alignment,spacing and rotation";
            position.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Space Across
            DiagramDropdownViewModel spaceacross = new DiagramDropdownViewModel();
            spaceacross.Header = "Space Across";
            spaceacross.SmallIcon = ICons.SpaceAcross.ToImageSource();
            position.Items.Add(spaceacross);
            #endregion

            #region Space Down
            DiagramDropdownViewModel spacedown = new DiagramDropdownViewModel();
            spacedown.Header = "Space Down";
            spacedown.SmallIcon = ICons.SpaceDown.ToImageSource();
            position.Items.Add(spacedown);
            #endregion

            #region Flip Horizontal
            DiagramDropdownViewModel fliphorizontal = new DiagramDropdownViewModel();
            fliphorizontal.Header = "Flip Horizontal";
            fliphorizontal.SmallIcon = ICons.SpaceDown.ToImageSource();
            position.Items.Add(fliphorizontal);
            #endregion

            #region Flip Vertical
            DiagramDropdownViewModel flipvertical = new DiagramDropdownViewModel();
            flipvertical.Header = "Flip Vertical";
            flipvertical.SmallIcon = ICons.SpaceDown.ToImageSource();
            position.Items.Add(flipvertical);
            #endregion

            arrange.DiagramButtons.Add(position);
            #endregion

            #region Bring to Front
            DiagramButtonViewModel bringtofront = new DiagramButtonViewModel();
            bringtofront.DisplayControl = Controls.SplitButton;
            bringtofront.Label = "Bring to Front";
            bringtofront.SmallIcon = ICons.BringToFront.ToImageSource();
            bringtofront.ToolTipMessage = "Bring the selected object in front of all other objects";
            bringtofront.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Bring to Front
            DiagramDropdownViewModel bring_to_front = new DiagramDropdownViewModel();
            bring_to_front.Header = "Bring to Front";
            bring_to_front.SmallIcon = ICons.BringToFront.ToImageSource();
            bring_to_front.ToolTipMessage = "Bring the selected object in front of all other objects";
            bringtofront.Items.Add(bring_to_front);
            #endregion

            #region Bring Forward
            DiagramDropdownViewModel bringforward = new DiagramDropdownViewModel();
            bringforward.Header = "Bring Forward";
            bringforward.SmallIcon = ICons.BringForward.ToImageSource();
            bringforward.ToolTipMessage = "Bring the selected object forward one level so that it's hidden behind fewer objects";
            bringtofront.Items.Add(bringforward);
            #endregion

            arrange.DiagramButtons.Add(bringtofront);
            #endregion

            #region Send to Back
            DiagramButtonViewModel sendtoback = new DiagramButtonViewModel();
            sendtoback.DisplayControl = Controls.SplitButton;
            sendtoback.Label = "Send to Back";
            sendtoback.SmallIcon = ICons.SendToBack.ToImageSource();
            sendtoback.ToolTipMessage = "Send the selected object behind all other objects";
            sendtoback.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Bring to Front
            DiagramDropdownViewModel send_to_back = new DiagramDropdownViewModel();
            send_to_back.Header = "Send to Back";
            send_to_back.SmallIcon = ICons.SendToBack.ToImageSource();
            send_to_back.ToolTipMessage = "Send the selected object behind all other objects";
            sendtoback.Items.Add(send_to_back);
            #endregion

            #region Send Backward
            DiagramDropdownViewModel sendbackward = new DiagramDropdownViewModel();
            sendbackward.Header = "Send Backward";
            sendbackward.SmallIcon = ICons.SendBackward.ToImageSource();
            sendbackward.ToolTipMessage = "Send the selected object back one level so that it's hidden behind more objects";
            sendtoback.Items.Add(sendbackward);
            #endregion

            arrange.DiagramButtons.Add(sendtoback);
            #endregion

            #region Group
            DiagramButtonViewModel group = new DiagramButtonViewModel();
            group.DisplayControl = Controls.SplitButton;
            group.Label = "Group";
            group.SmallIcon = ICons.Group.ToImageSource();
            group.ToolTipMessage = "Join objects together to move and format them as if they were a single object";
            group.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Group
            DiagramDropdownViewModel groups = new DiagramDropdownViewModel();
            groups.Header = "Group";
            groups.SmallIcon = ICons.Group.ToImageSource();
            groups.ToolTipMessage = "Join objects together to move and format them as if they were a single object";
            group.Items.Add(groups);
            #endregion

            #region UnGroup
            DiagramDropdownViewModel ungroup = new DiagramDropdownViewModel();
            ungroup.Header = "UnGroup";
            ungroup.SmallIcon = ICons.UnGroup.ToImageSource();
            ungroup.ToolTipMessage = "Break the connection between joined objects so that you can move them individually";
            group.Items.Add(ungroup);
            #endregion

            arrange.DiagramButtons.Add(group);
            #endregion

            homeTab.DiagramGroups.Add(arrange);

            #endregion

            #region Editing

            DiagramBarViewModel editing = new DiagramBarViewModel();
            editing.Header = "Editing";
            editing.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

            #region Select
            DiagramButtonViewModel select = new DiagramButtonViewModel();
            select.DisplayControl = Controls.SplitButton;
            select.Label = "Select";
            select.SmallIcon = ICons.Select.ToImageSource();
            select.ToolTipMessage = "Select text or objects in your document";
            select.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Select All
            DiagramDropdownViewModel selectall = new DiagramDropdownViewModel();
            selectall.Header = "Select All";
            selectall.SmallIcon = ICons.SelectAll.ToImageSource();
            selectall.ToolTipMessage = "Select all text and objects";
            select.Items.Add(selectall);
            #endregion

            #region Select Connectors
            DiagramDropdownViewModel selectconnectors = new DiagramDropdownViewModel();
            selectconnectors.Header = "Select Connectors";
            selectconnectors.SmallIcon = ICons.SelectConnector.ToImageSource();
            selectconnectors.ToolTipMessage = "Select only the Connectors available in the diagram";
            select.Items.Add(selectconnectors);
            #endregion

            #region Select Nodes
            DiagramDropdownViewModel selectnodes = new DiagramDropdownViewModel();
            selectnodes.Header = "Select Nodes";
            selectnodes.SmallIcon = ICons.SelectNode.ToImageSource();
            selectnodes.ToolTipMessage = "Select only the Nodes available in the diagram";
            select.Items.Add(selectnodes);
            #endregion

            editing.DiagramButtons.Add(select);
            #endregion

            homeTab.DiagramGroups.Add(editing);

            #endregion

            DiagramTabs.Add(homeTab);
            #endregion

            #region Design

            DiagramTabViewModel designtab = new DiagramTabViewModel();
            designtab.Header = "DESIGN";
            designtab.DiagramGroups = new ObservableCollection<DiagramBarViewModel>();

            #region Page Setup
            DiagramBarViewModel pagesetup = new DiagramBarViewModel();
            pagesetup.Header = "Page Setup";
            pagesetup.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

            #region Orientation
            DiagramButtonViewModel orientation = new DiagramButtonViewModel();
            orientation.DisplayControl = Controls.SplitButton;
            orientation.Label = "Orientation";
            orientation.SmallIcon = ICons.Orientation.ToImageSource();
            orientation.ToolTipMessage = "switch page between potrait and landscape layouts";
            orientation.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Portrait
            DiagramDropdownViewModel portrait = new DiagramDropdownViewModel();
            portrait.Header = "Portrait";
            portrait.SmallIcon = ICons.Potrait.ToImageSource();
            orientation.Items.Add(portrait);
            #endregion

            #region Landscape
            DiagramDropdownViewModel landscape = new DiagramDropdownViewModel();
            landscape.Header = "Landscape";
            landscape.SmallIcon = ICons.Landscape.ToImageSource();
            orientation.Items.Add(landscape);
            #endregion

            pagesetup.DiagramButtons.Add(orientation);
            #endregion

            #region Size
            DiagramButtonViewModel size = new DiagramButtonViewModel();
            size.DisplayControl = Controls.SplitButton;
            size.Label = "Size";
            size.SmallIcon = ICons.Size.ToImageSource();
            size.ToolTipMessage = "Choose a page size";
            size.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Letter
            DiagramDropdownViewModel letter = new DiagramDropdownViewModel();
            letter.Header = "Letter";
            letter.SmallIcon = ICons.Letter.ToImageSource();
            size.Items.Add(letter);
            #endregion

            #region Folio
            DiagramDropdownViewModel folio = new DiagramDropdownViewModel();
            folio.Header = "Folio";
            folio.SmallIcon = ICons.Ledger.ToImageSource();
            size.Items.Add(folio);
            #endregion

            #region Legal
            DiagramDropdownViewModel legal = new DiagramDropdownViewModel();
            legal.Header = "Legal";
            legal.SmallIcon = ICons.Legal.ToImageSource();
            size.Items.Add(legal);
            #endregion

            #region Ledger
            DiagramDropdownViewModel ledger = new DiagramDropdownViewModel();
            ledger.Header = "Ledger";
            ledger.SmallIcon = ICons.Ledger.ToImageSource();
            size.Items.Add(ledger);
            #endregion

            #region A5
            DiagramDropdownViewModel A5 = new DiagramDropdownViewModel();
            A5.Header = "A5";
            A5.SmallIcon = ICons.A5.ToImageSource();
            size.Items.Add(A5);
            #endregion

            #region A4
            DiagramDropdownViewModel A4 = new DiagramDropdownViewModel();
            A4.Header = "A4";
            A4.SmallIcon = ICons.A4.ToImageSource();
            size.Items.Add(A4);
            #endregion

            #region A3
            DiagramDropdownViewModel A3 = new DiagramDropdownViewModel();
            A3.Header = "A3";
            A3.SmallIcon = ICons.Letter.ToImageSource();
            size.Items.Add(A3);
            #endregion

            #region A2
            DiagramDropdownViewModel A2 = new DiagramDropdownViewModel();
            A2.Header = "A2";
            A2.SmallIcon = ICons.Legal.ToImageSource();
            size.Items.Add(A2);
            #endregion

            #region A1
            DiagramDropdownViewModel A1 = new DiagramDropdownViewModel();
            A1.Header = "A1";
            A1.SmallIcon = ICons.A5.ToImageSource();
            size.Items.Add(A1);
            #endregion

            #region A0
            DiagramDropdownViewModel A0 = new DiagramDropdownViewModel();
            A0.Header = "A0";
            A0.SmallIcon = ICons.A4.ToImageSource();
            size.Items.Add(A0);
            #endregion

            pagesetup.DiagramButtons.Add(size);
            #endregion

            #region Connectors
            DiagramButtonViewModel connectors = new DiagramButtonViewModel();
            connectors.DisplayControl = Controls.SplitButton;
            connectors.Label = "Connectors";
            connectors.SmallIcon = ICons.ConnectorType.ToImageSource();
            connectors.ToolTipMessage = "Change the appearence of connectors in the diagram";
            connectors.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region Orthogonal
            DiagramDropdownViewModel orthogonal = new DiagramDropdownViewModel();
            orthogonal.Header = "Orthogonal";
            orthogonal.SmallIcon = ICons.ConnectorType_Orthogonal.ToImageSource();
            connectors.Items.Add(orthogonal);
            #endregion

            #region Straight Line
            DiagramDropdownViewModel straightline = new DiagramDropdownViewModel();
            straightline.Header = "Straight Line";
            straightline.SmallIcon = ICons.ConnectorType_StraightLine.ToImageSource();
            connectors.Items.Add(straightline);
            #endregion

            #region Cubic Bezier
            DiagramDropdownViewModel cubicbezier = new DiagramDropdownViewModel();
            cubicbezier.Header = "Cubic Bezier";
            cubicbezier.SmallIcon = ICons.ConnectorType_CubicBeier.ToImageSource();
            connectors.Items.Add(cubicbezier);
            #endregion

            pagesetup.DiagramButtons.Add(connectors);
            #endregion

            designtab.DiagramGroups.Add(pagesetup);
            #endregion

            DiagramTabs.Add(designtab);
            #endregion

            #region View

            DiagramTabViewModel viewtab = new DiagramTabViewModel();
            viewtab.Header = "VIEW";
            viewtab.DiagramGroups = new ObservableCollection<DiagramBarViewModel>();

            #region Show
            DiagramBarViewModel show = new DiagramBarViewModel();
            show.Header = "Show";
            show.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

            #region Ruler
            DiagramButtonViewModel ruler = new DiagramButtonViewModel();
            ruler.DisplayControl = Controls.CheckBox;
            ruler.Label = "Ruler";
            ruler.Identifier = "Ruler";
            ruler.ToolTipMessage = "View the rulers used to measure and line up objects in the document";
            show.DiagramButtons.Add(ruler);
            #endregion

            #region Grid
            DiagramButtonViewModel grid = new DiagramButtonViewModel();
            grid.DisplayControl = Controls.CheckBox;
            grid.Label = "Grid";
            grid.Identifier = "Grid";
            grid.ToolTipMessage = "The gridlines make it easy for you to align objects with text,other objects or a particular object";
            show.DiagramButtons.Add(grid);
            #endregion

            #region Page Breaks
            DiagramButtonViewModel pagebreaks = new DiagramButtonViewModel();
            pagebreaks.DisplayControl = Controls.CheckBox;
            pagebreaks.Label = "Page Breaks";
            pagebreaks.Identifier = "PageBreaks";
            pagebreaks.ToolTipMessage = "Turn on Page breaks to see what will be printed on each page of your document";
            show.DiagramButtons.Add(pagebreaks);
            #endregion

            #region Multiple Pages
            DiagramButtonViewModel multiplepages = new DiagramButtonViewModel();
            multiplepages.DisplayControl = Controls.CheckBox;
            multiplepages.Label = "Multiple Pages";
            multiplepages.Identifier = "MultiplePage";
            multiplepages.ToolTipMessage = "Helps you to create multiple pages depends on page width and page height";
            show.DiagramButtons.Add(multiplepages);
            #endregion

            #region Snap To Grid
            DiagramButtonViewModel snaptogrid = new DiagramButtonViewModel();
            snaptogrid.DisplayControl = Controls.CheckBox;
            snaptogrid.Label = "Snap To Grid";
            snaptogrid.Identifier = "SnapToGrid";
            snaptogrid.ToolTipMessage = "Helps to snap objects with respect to grid lines in the Diagram";
            show.DiagramButtons.Add(snaptogrid);
            #endregion

            #region Snap To Object
            DiagramButtonViewModel snaptoobject = new DiagramButtonViewModel();
            snaptoobject.DisplayControl = Controls.CheckBox;
            snaptoobject.Label = "Snap To Object";
            snaptoobject.Identifier = "SnapToObject";
            snaptoobject.ToolTipMessage = "Turn on guideline that help align objects in the document. Guidelines are dragged out from the horizontal and vertical ruler";
            show.DiagramButtons.Add(snaptoobject);
            #endregion

            #region TaskPanes
            DiagramButtonViewModel taskpanes = new DiagramButtonViewModel();
            taskpanes.DisplayControl = Controls.SplitButton;
            taskpanes.Label = "Task Panes";
            taskpanes.SmallIcon = ICons.TaskPanes.ToImageSource();
            taskpanes.ToolTipMessage = "Show windows to view shapes and shape data";
            taskpanes.Items = new ObservableCollection<DiagramDropdownViewModel>();

            #region PanZoom
            DiagramDropdownViewModel panzoom = new DiagramDropdownViewModel();
            panzoom.Header = "PanZoom";
            panzoom.SmallIcon = ICons.PanZoom.ToImageSource();
            taskpanes.Items.Add(panzoom);
            #endregion

            #region SizeandPosition
            DiagramDropdownViewModel sizeandposition = new DiagramDropdownViewModel();
            sizeandposition.Header = "SizeandPosition";
            sizeandposition.SmallIcon = ICons.SizeandPosition.ToImageSource();
            taskpanes.Items.Add(sizeandposition);
            #endregion

            show.DiagramButtons.Add(taskpanes);
            #endregion

            viewtab.DiagramGroups.Add(show);
            #endregion

            #region Zoom
            DiagramBarViewModel zoom = new DiagramBarViewModel();
            zoom.Header = "Zoom";
            zoom.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

            #region Zoom
            DiagramButtonViewModel zom = new DiagramButtonViewModel();
            zom.Label = "Zoom";
            zom.SmallIcon = ICons.Zoom.ToImageSource();
            zom.ToolTipMessage = "Zoom to the level that's right for you. For zoomier zooming,use the controls in the status bar";
            zom.DisplayControl = Controls.Button;
            zoom.DiagramButtons.Add(zom);
            #endregion

            #region FitToPage
            DiagramButtonViewModel fittopage = new DiagramButtonViewModel();
            fittopage.Label = "FitToPage";
            fittopage.SmallIcon = ICons.FitToPage.ToImageSource();
            fittopage.ToolTipMessage = "Fit page to current window";
            fittopage.DisplayControl = Controls.Button;
            zoom.DiagramButtons.Add(fittopage);
            #endregion

            #region FitToWidth
            DiagramButtonViewModel fittowidth = new DiagramButtonViewModel();
            fittowidth.Label = "FitToWidth";
            fittowidth.SmallIcon = ICons.Pagewidth.ToImageSource();
            fittowidth.ToolTipMessage = "Fit page to current width";
            fittowidth.DisplayControl = Controls.Button;
            zoom.DiagramButtons.Add(fittowidth);
            #endregion

            viewtab.DiagramGroups.Add(zoom);
            #endregion

            DiagramTabs.Add(viewtab);
            #endregion
        }

        public void PopulateBrainstorming()
        {
            if (!DiagramTabs.Contains(brainstormingTab))
            {
                #region Brainstorming

                brainstormingTab = new DiagramTabViewModel();
                brainstormingTab.Header = "BRAINSTORMING";
                brainstormingTab.DiagramGroups = new ObservableCollection<DiagramBarViewModel>();

                #region AddTopics
                DiagramBarViewModel addtopics = new DiagramBarViewModel();
                addtopics.Header = "AddTopics";
                addtopics.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

                #region SubTopic
                DiagramButtonViewModel subtopic = new DiagramButtonViewModel();
                subtopic.Label = "SubTopic";
                subtopic.ToolTipMessage = "Add a sub topic to the selected topic. (Alt + B)";
                subtopic.SmallIcon = ICons.Subtopic.ToImageSource();
                subtopic.DisplayControl = Controls.Button;
                addtopics.DiagramButtons.Add(subtopic);
                #endregion

                #region Peer
                DiagramButtonViewModel peer = new DiagramButtonViewModel();
                peer.Label = "Peer";
                peer.ToolTipMessage = "Add a peer topic. (Alt + P)";
                peer.SmallIcon = ICons.Peer.ToImageSource();
                peer.DisplayControl = Controls.Button;
                addtopics.DiagramButtons.Add(peer);
                #endregion

                #region MultipleSubtopics
                DiagramButtonViewModel multiplesubtopics = new DiagramButtonViewModel();
                multiplesubtopics.Label = "MultipleSubtopics";
                multiplesubtopics.ToolTipMessage = "Show the Add Multiple Subtopics dialog box to add text for multiple subtopics to the selected topic shape. (Alt + U)";
                multiplesubtopics.SmallIcon = ICons.MultipleSubtopics.ToImageSource();
                multiplesubtopics.DisplayControl = Controls.Button;
                addtopics.DiagramButtons.Add(multiplesubtopics);
                #endregion

                brainstormingTab.DiagramGroups.Add(addtopics);
                #endregion

                #region Styles
                DiagramBarViewModel styles = new DiagramBarViewModel();
                styles.Header = "Styles";
                styles.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

                #region Change Topic
                DiagramButtonViewModel changetopic = new DiagramButtonViewModel();
                changetopic.Label = "ChangeTopic";
                changetopic.ToolTipMessage = "Change the shape of the selected topic shapes to one of several choices, including rectangle or cloud.";
                changetopic.SmallIcon = ICons.ChangeTopic.ToImageSource();
                changetopic.DisplayControl = Controls.Button;
                styles.DiagramButtons.Add(changetopic);
                #endregion

                #region DiagramStyle
                DiagramButtonViewModel diagramstyle = new DiagramButtonViewModel();
                diagramstyle.Label = "DiagramStyle";
                diagramstyle.ToolTipMessage = "Assign visual styles and shapes types to different levels in the brainstorming diagram.";
                diagramstyle.SmallIcon = ICons.DiagramStyle.ToImageSource();
                diagramstyle.DisplayControl = Controls.Button;
                styles.DiagramButtons.Add(diagramstyle);
                #endregion

                brainstormingTab.DiagramGroups.Add(styles);
                #endregion

                #region Manage
                DiagramBarViewModel manage = new DiagramBarViewModel();
                manage.Header = "Manage";
                manage.DiagramButtons = new ObservableCollection<DiagramButtonViewModel>();

                #region Import
                DiagramButtonViewModel import = new DiagramButtonViewModel();
                import.Label = "Import";
                import.ToolTipMessage = "Import an outline in XML format as a brainstorming diagram.";
                import.SmallIcon = ICons.ImportData.ToImageSource();
                import.DisplayControl = Controls.Button;
                manage.DiagramButtons.Add(import);
                #endregion

                #region export
                DiagramButtonViewModel export = new DiagramButtonViewModel();
                export.Label = "Export";
                export.ToolTipMessage = "Export a brainstorming diagram in XML format.";
                export.SmallIcon = ICons.ExportData.ToImageSource();
                export.DisplayControl = Controls.Button;
                manage.DiagramButtons.Add(export);
                #endregion

                

                brainstormingTab.DiagramGroups.Add(manage);
                #endregion

                DiagramTabs.Add(brainstormingTab);
                #endregion
            }
        }

        public void RemoveBrainstorming()
        {
            if (brainstormingTab != null && DiagramTabs.Contains(brainstormingTab))
            {
                DiagramTabs.Remove(brainstormingTab);
            }
        }

        public DiagramCommandsViewModel()
        {
            DiagramTabs = new ObservableCollection<DiagramTabViewModel>();
            PopulateTabs();
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

    }
    
    public class DiagramCommandViewModel : INotifyPropertyChanged
    {
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
