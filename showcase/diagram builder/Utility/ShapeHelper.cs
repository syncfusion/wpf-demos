// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShapeHelper.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the shapehelper class which contains predefined icons for the items in the ribbon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System.Collections.Generic;

    /// <summary>
    ///     Represents the shapehelper class which contains predefined icons for the items in the ribbon.
    /// </summary>
    internal static class ShapeHelper
    {
        /// <summary>
        ///     Represents the geometry dictionary.
        /// </summary>
        public static Dictionary<ICons, string> GeometryDictionary = new Dictionary<ICons, string>();

        /// <summary>
        ///     Initializes static members of the <see cref="ShapeHelper" /> class.
        /// </summary>
        static ShapeHelper()
        {
            GeometryDictionary.Add(ICons.Cut, "/syncfusion.diagrambuilder.wpf;component/Resources/Cut.png");
            GeometryDictionary.Add(ICons.Copy, "/syncfusion.diagrambuilder.wpf;component/Resources/Copy.png");
            GeometryDictionary.Add(ICons.Paste, "/syncfusion.diagrambuilder.wpf;component/Resources/Paste.png");
            GeometryDictionary.Add(ICons.Bold, "/syncfusion.diagrambuilder.wpf;component/Resources/bold.png");
            GeometryDictionary.Add(
                ICons.Italic,
                "/syncfusion.diagrambuilder.wpf;component/Resources/italic.png");
            GeometryDictionary.Add(
                ICons.Center,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Align-center.png");
            GeometryDictionary.Add(
                ICons.Left,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Align-left.png");
            GeometryDictionary.Add(
                ICons.Right,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Align-right.png");
            GeometryDictionary.Add(
                ICons.BottomRight,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Bottomright.png");
            GeometryDictionary.Add(
                ICons.TopLeft,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Align-middle.png");
            GeometryDictionary.Add(
                ICons.TopRight,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Bottom.png");
            GeometryDictionary.Add(
                ICons.BottomLeft,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Bottomleft.png");
            GeometryDictionary.Add(
                ICons.Top,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Align-top.png");
            GeometryDictionary.Add(
                ICons.Bottom,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Align-bottom.png");
            GeometryDictionary.Add(
                ICons.PointerTool,
                "/syncfusion.diagrambuilder.wpf;component/Resources/pointer.png");
            GeometryDictionary.Add(
                ICons.Select,
                "/syncfusion.diagrambuilder.wpf;component/Resources/select1.png");
            GeometryDictionary.Add(
                ICons.Position,
                "/syncfusion.diagrambuilder.wpf;component/Resources/position-icon.png");
            GeometryDictionary.Add(
                ICons.Connector,
                "/syncfusion.diagrambuilder.wpf;component/Resources/connector.png");
            GeometryDictionary.Add(ICons.Port, "/syncfusion.diagrambuilder.wpf;component/Resources/Port.png");
            GeometryDictionary.Add(
                ICons.SelectText,
                "/syncfusion.diagrambuilder.wpf;component/Resources/SelectText.png");
            GeometryDictionary.Add(
                ICons.RotateText,
                "/syncfusion.diagrambuilder.wpf;component/Resources/RotateText.png");
            GeometryDictionary.Add(ICons.Text, "/syncfusion.diagrambuilder.wpf;component/Resources/Text.png");
            GeometryDictionary.Add(ICons.Zoom, "/syncfusion.diagrambuilder.wpf;component/Resources/Zoom-1.png");
            GeometryDictionary.Add(
                ICons.FitToPage,
                "/syncfusion.diagrambuilder.wpf;component/Resources/fullscreen-16x16-2.png");
            GeometryDictionary.Add(
                ICons.Pagewidth,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Pagewidth.png");
            GeometryDictionary.Add(
                ICons.Label,
                "/syncfusion.diagrambuilder.wpf;component/Resources/FontColor.png");
            GeometryDictionary.Add(
                ICons.Fill,
                "/syncfusion.diagrambuilder.wpf;component/Resources/shape-fill.png");
            GeometryDictionary.Add(
                ICons.Stroke,
                "/syncfusion.diagrambuilder.wpf;component/Resources/shape-fill.png");
            GeometryDictionary.Add(
                ICons.Align,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Align_Split.png");
            GeometryDictionary.Add(
                ICons.AlignLeft,
                "/syncfusion.diagrambuilder.wpf;component/Resources/AlignLeft.png");
            GeometryDictionary.Add(
                ICons.AlignCenter,
                "/syncfusion.diagrambuilder.wpf;component/Resources/AlignCenter.png");
            GeometryDictionary.Add(
                ICons.AlignRight,
                "/syncfusion.diagrambuilder.wpf;component/Resources/AlignRight.png");
            GeometryDictionary.Add(
                ICons.AlignTop,
                "/syncfusion.diagrambuilder.wpf;component/Resources/AlignTop.png");
            GeometryDictionary.Add(
                ICons.AlignMiddle,
                "/syncfusion.diagrambuilder.wpf;component/Resources/AlignMiddle.png");
            GeometryDictionary.Add(
                ICons.AlignBottom,
                "/syncfusion.diagrambuilder.wpf;component/Resources/AlignBottom.png");
            GeometryDictionary.Add(ICons.Group, "/syncfusion.diagrambuilder.wpf;component/Resources/Group.png");
            GeometryDictionary.Add(
                ICons.UnGroup,
                "/syncfusion.diagrambuilder.wpf;component/Resources/UnGroup.png");
            GeometryDictionary.Add(
                ICons.BringToFront,
                "/syncfusion.diagrambuilder.wpf;component/Resources/BringToFront.png");
            GeometryDictionary.Add(
                ICons.SendToBack,
                "/syncfusion.diagrambuilder.wpf;component/Resources/SendToBack.png");
            GeometryDictionary.Add(
                ICons.BringForward,
                "/syncfusion.diagrambuilder.wpf;component/Resources/BringForward.png");
            GeometryDictionary.Add(
                ICons.SendBackward,
                "/syncfusion.diagrambuilder.wpf;component/Resources/SendBackward.png");
            GeometryDictionary.Add(ICons.Size, "/syncfusion.diagrambuilder.wpf;component/Resources/Size.png");
            GeometryDictionary.Add(
                ICons.NewPage,
                "/syncfusion.diagrambuilder.wpf;component/Resources/New-page.png");
            GeometryDictionary.Add(
                ICons.DuplicatePage,
                "/syncfusion.diagrambuilder.wpf;component/Resources/duplicate.png");
            GeometryDictionary.Add(
                ICons.Pictures,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Pictures.png");
            GeometryDictionary.Add(
                ICons.Orientation,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Orientation.png");
            GeometryDictionary.Add(
                ICons.Potrait,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Landscape.png");
            GeometryDictionary.Add(
                ICons.Landscape,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Portrait.png");
            GeometryDictionary.Add(ICons.A4, "/syncfusion.diagrambuilder.wpf;component/Resources/A4.png");
            GeometryDictionary.Add(ICons.A5, "/syncfusion.diagrambuilder.wpf;component/Resources/A5.png");
            GeometryDictionary.Add(
                ICons.Letter,
                "/syncfusion.diagrambuilder.wpf;component/Resources/letter.png");
            GeometryDictionary.Add(
                ICons.Ledger,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Ledger.png");
            GeometryDictionary.Add(ICons.Legal, "/syncfusion.diagrambuilder.wpf;component/Resources/Legal.png");

            GeometryDictionary.Add(
                ICons.Underline,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Underline16.png");
            GeometryDictionary.Add(
                ICons.GrowFont,
                "/syncfusion.diagrambuilder.wpf;component/Resources/GrowFont16.png");
            GeometryDictionary.Add(
                ICons.DecreaseFont,
                "/syncfusion.diagrambuilder.wpf;component/Resources/ShrinkFont16.png");
            GeometryDictionary.Add(
                ICons.Strike,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Strike.png");

            GeometryDictionary.Add(
                ICons.SelectAll,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Select-all.png");
            GeometryDictionary.Add(
                ICons.SelectNode,
                "/syncfusion.diagrambuilder.wpf;component/Resources/select-nodes.png");
            GeometryDictionary.Add(
                ICons.SelectConnector,
                "/syncfusion.diagrambuilder.wpf;component/Resources/select-connectors.png");

            GeometryDictionary.Add(
                ICons.SpaceAcross,
                "/syncfusion.diagrambuilder.wpf;component/Resources/SpaceAcross.png");
            GeometryDictionary.Add(
                ICons.SpaceDown,
                "/syncfusion.diagrambuilder.wpf;component/Resources/SpaceDown.png");
            GeometryDictionary.Add(
                ICons.DrawingTool_Ellipse,
                "/syncfusion.diagrambuilder.wpf;component/Resources/DrawTool_Ellipse.png");
            GeometryDictionary.Add(
                ICons.DrawingTool_Rectangle,
                "/syncfusion.diagrambuilder.wpf;component/Resources/DrawTool_Rectangle.png");
            GeometryDictionary.Add(
                ICons.DrawingTool_StraightLine,
                "/syncfusion.diagrambuilder.wpf;component/Resources/DrawTool_StraightLine.png");
            GeometryDictionary.Add(
                ICons.Polyline,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Polyline.png");

            GeometryDictionary.Add(
                ICons.ConnectorType,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Connectors.png");
            GeometryDictionary.Add(
                ICons.ConnectorType_Orthogonal,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Orthogonal.png");
            GeometryDictionary.Add(
                ICons.ConnectorType_StraightLine,
                "/syncfusion.diagrambuilder.wpf;component/Resources/StraightLine.png");
            GeometryDictionary.Add(
                ICons.ConnectorType_CubicBeier,
                "/syncfusion.diagrambuilder.wpf;component/Resources/CubicBezier.png");

            GeometryDictionary.Add(
                ICons.TaskPanes,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Taskpane.png");
            GeometryDictionary.Add(
                ICons.PanZoom,
                "/syncfusion.diagrambuilder.wpf;component/Resources/PanZoom.png");
            GeometryDictionary.Add(
                ICons.SizeandPosition,
                "/syncfusion.diagrambuilder.wpf;component/Resources/SizeandPosition.png");
            GeometryDictionary.Add(
                ICons.Subtopic,
                "/syncfusion.diagrambuilder.wpf;component/Resources/Subtopic.png");
            GeometryDictionary.Add(
                ICons.MultipleSubtopics,
                "/syncfusion.diagrambuilder.wpf;component/Resources/MultipleSubtopics.png");
            GeometryDictionary.Add(ICons.Peer, "/syncfusion.diagrambuilder.wpf;component/Resources/Peer.png");
            GeometryDictionary.Add(
                ICons.ChangeTopic,
                "/syncfusion.diagrambuilder.wpf;component/Resources/ChangeTopic.png");
            GeometryDictionary.Add(
                ICons.DiagramStyle,
                "/syncfusion.diagrambuilder.wpf;component/Resources/DiagramStyle.png");
            GeometryDictionary.Add(
                ICons.ExportData,
                "/syncfusion.diagrambuilder.wpf;component/Resources/ExportData.png");
            GeometryDictionary.Add(
                ICons.ImportData,
                "/syncfusion.diagrambuilder.wpf;component/Resources/ImportData.png");

            GeometryDictionary.Add(ICons.VerticalCenter, "/syncfusion.diagrambuilder.wpf;component/Resources/VerticalCenter.png");
            GeometryDictionary.Add(ICons.VerticalLeft, "/syncfusion.diagrambuilder.wpf;component/Resources/VerticalLeft.png");
            GeometryDictionary.Add(ICons.VerticalRight, "/syncfusion.diagrambuilder.wpf;component/Resources/VerticalRight.png");
            GeometryDictionary.Add(ICons.HorizontalCenter, "/syncfusion.diagrambuilder.wpf;component/Resources/HorizontalCenter.png");
            GeometryDictionary.Add(ICons.HorizontalLeft, "/syncfusion.diagrambuilder.wpf;component/Resources/HorizontalLeft.png");
            GeometryDictionary.Add(ICons.HorizontalRight, "/syncfusion.diagrambuilder.wpf;component/Resources/HorizontalRight.png");
            GeometryDictionary.Add(ICons.Change, "/syncfusion.diagrambuilder.wpf;component/Resources/Change.png");
            GeometryDictionary.Add(ICons.Delete, "/syncfusion.diagrambuilder.wpf;component/Resources/Delete.png");
            GeometryDictionary.Add(ICons.Insert, "/syncfusion.diagrambuilder.wpf;component/Resources/Insert.png");
            GeometryDictionary.Add(ICons.ShowHide, "/syncfusion.diagrambuilder.wpf;component/Resources/Show-Hide.png");
            GeometryDictionary.Add(ICons.ShowHideSubordinates, "/syncfusion.diagrambuilder.wpf;component/Resources/Show-HideSubordinates.png");
            GeometryDictionary.Add(ICons.SpaceIncrease, "/syncfusion.diagrambuilder.wpf;component/Resources/SpacingIncrease.png");
            GeometryDictionary.Add(ICons.SpaceDecrease, "/syncfusion.diagrambuilder.wpf;component/Resources/Spacingless.png");


            GeometryDictionary.Add(ICons.Layout, "/syncfusion.diagrambuilder.wpf;component/Resources/Layout.png");
            GeometryDictionary.Add(ICons.Relayout, "/syncfusion.diagrambuilder.wpf;component/Resources/Relayout.png");



        }

        /// <summary>
        /// This method will set the icon as image source.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToImageSource(this ICons source)
        {
            if (source == ICons.None)
            {
                return null;
            }

            return GeometryDictionary[source];
        }
    }
}