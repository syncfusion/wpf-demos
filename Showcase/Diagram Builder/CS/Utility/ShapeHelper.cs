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
            GeometryDictionary.Add(ICons.Cut, "pack://application:,,,/DiagramBuilder;component/Resources/Cut.png");
            GeometryDictionary.Add(ICons.Copy, "pack://application:,,,/DiagramBuilder;component/Resources/Copy.png");
            GeometryDictionary.Add(ICons.Paste, "pack://application:,,,/DiagramBuilder;component/Resources/Paste.png");
            GeometryDictionary.Add(ICons.Bold, "pack://application:,,,/DiagramBuilder;component/Resources/bold.png");
            GeometryDictionary.Add(
                ICons.Italic,
                "pack://application:,,,/DiagramBuilder;component/Resources/italic.png");
            GeometryDictionary.Add(
                ICons.Center,
                "pack://application:,,,/DiagramBuilder;component/Resources/Align-center.png");
            GeometryDictionary.Add(
                ICons.Left,
                "pack://application:,,,/DiagramBuilder;component/Resources/Align-left.png");
            GeometryDictionary.Add(
                ICons.Right,
                "pack://application:,,,/DiagramBuilder;component/Resources/Align-right.png");
            GeometryDictionary.Add(
                ICons.BottomRight,
                "pack://application:,,,/DiagramBuilder;component/Resources/Bottomright.png");
            GeometryDictionary.Add(
                ICons.TopLeft,
                "pack://application:,,,/DiagramBuilder;component/Resources/Align-middle.png");
            GeometryDictionary.Add(
                ICons.TopRight,
                "pack://application:,,,/DiagramBuilder;component/Resources/Bottom.png");
            GeometryDictionary.Add(
                ICons.BottomLeft,
                "pack://application:,,,/DiagramBuilder;component/Resources/Bottomleft.png");
            GeometryDictionary.Add(
                ICons.Top,
                "pack://application:,,,/DiagramBuilder;component/Resources/Align-top.png");
            GeometryDictionary.Add(
                ICons.Bottom,
                "pack://application:,,,/DiagramBuilder;component/Resources/Align-bottom.png");
            GeometryDictionary.Add(
                ICons.PointerTool,
                "pack://application:,,,/DiagramBuilder;component/Resources/pointer.png");
            GeometryDictionary.Add(
                ICons.Select,
                "pack://application:,,,/DiagramBuilder;component/Resources/select1.png");
            GeometryDictionary.Add(
                ICons.Position,
                "pack://application:,,,/DiagramBuilder;component/Resources/position-icon.png");
            GeometryDictionary.Add(
                ICons.Connector,
                "pack://application:,,,/DiagramBuilder;component/Resources/connector.png");
            GeometryDictionary.Add(ICons.Port, "pack://application:,,,/DiagramBuilder;component/Resources/Port.png");
            GeometryDictionary.Add(
                ICons.SelectText,
                "pack://application:,,,/DiagramBuilder;component/Resources/SelectText.png");
            GeometryDictionary.Add(
                ICons.RotateText,
                "pack://application:,,,/DiagramBuilder;component/Resources/RotateText.png");
            GeometryDictionary.Add(ICons.Text, "pack://application:,,,/DiagramBuilder;component/Resources/Text.png");
            GeometryDictionary.Add(ICons.Zoom, "pack://application:,,,/DiagramBuilder;component/Resources/Zoom-1.png");
            GeometryDictionary.Add(
                ICons.FitToPage,
                "pack://application:,,,/DiagramBuilder;component/Resources/fullscreen-16x16-2.png");
            GeometryDictionary.Add(
                ICons.Pagewidth,
                "pack://application:,,,/DiagramBuilder;component/Resources/Pagewidth.png");
            GeometryDictionary.Add(
                ICons.Label,
                "pack://application:,,,/DiagramBuilder;component/Resources/FontColor.png");
            GeometryDictionary.Add(
                ICons.Fill,
                "pack://application:,,,/DiagramBuilder;component/Resources/shape-fill.png");
            GeometryDictionary.Add(
                ICons.Stroke,
                "pack://application:,,,/DiagramBuilder;component/Resources/shape-fill.png");
            GeometryDictionary.Add(
                ICons.Align,
                "pack://application:,,,/DiagramBuilder;component/Resources/Align_Split.png");
            GeometryDictionary.Add(
                ICons.AlignLeft,
                "pack://application:,,,/DiagramBuilder;component/Resources/AlignLeft.png");
            GeometryDictionary.Add(
                ICons.AlignCenter,
                "pack://application:,,,/DiagramBuilder;component/Resources/AlignCenter.png");
            GeometryDictionary.Add(
                ICons.AlignRight,
                "pack://application:,,,/DiagramBuilder;component/Resources/AlignRight.png");
            GeometryDictionary.Add(
                ICons.AlignTop,
                "pack://application:,,,/DiagramBuilder;component/Resources/AlignTop.png");
            GeometryDictionary.Add(
                ICons.AlignMiddle,
                "pack://application:,,,/DiagramBuilder;component/Resources/AlignMiddle.png");
            GeometryDictionary.Add(
                ICons.AlignBottom,
                "pack://application:,,,/DiagramBuilder;component/Resources/AlignBottom.png");
            GeometryDictionary.Add(ICons.Group, "pack://application:,,,/DiagramBuilder;component/Resources/Group.png");
            GeometryDictionary.Add(
                ICons.UnGroup,
                "pack://application:,,,/DiagramBuilder;component/Resources/UnGroup.png");
            GeometryDictionary.Add(
                ICons.BringToFront,
                "pack://application:,,,/DiagramBuilder;component/Resources/BringToFront.png");
            GeometryDictionary.Add(
                ICons.SendToBack,
                "pack://application:,,,/DiagramBuilder;component/Resources/SendToBack.png");
            GeometryDictionary.Add(
                ICons.BringForward,
                "pack://application:,,,/DiagramBuilder;component/Resources/BringForward.png");
            GeometryDictionary.Add(
                ICons.SendBackward,
                "pack://application:,,,/DiagramBuilder;component/Resources/SendBackward.png");
            GeometryDictionary.Add(ICons.Size, "pack://application:,,,/DiagramBuilder;component/Resources/Size.png");
            GeometryDictionary.Add(
                ICons.NewPage,
                "pack://application:,,,/DiagramBuilder;component/Resources/New-page.png");
            GeometryDictionary.Add(
                ICons.DuplicatePage,
                "pack://application:,,,/DiagramBuilder;component/Resources/duplicate.png");
            GeometryDictionary.Add(
                ICons.Pictures,
                "pack://application:,,,/DiagramBuilder;component/Resources/Pictures.png");
            GeometryDictionary.Add(
                ICons.Orientation,
                "pack://application:,,,/DiagramBuilder;component/Resources/Orientation.png");
            GeometryDictionary.Add(
                ICons.Potrait,
                "pack://application:,,,/DiagramBuilder;component/Resources/Landscape.png");
            GeometryDictionary.Add(
                ICons.Landscape,
                "pack://application:,,,/DiagramBuilder;component/Resources/Portrait.png");
            GeometryDictionary.Add(ICons.A4, "pack://application:,,,/DiagramBuilder;component/Resources/A4.png");
            GeometryDictionary.Add(ICons.A5, "pack://application:,,,/DiagramBuilder;component/Resources/A5.png");
            GeometryDictionary.Add(
                ICons.Letter,
                "pack://application:,,,/DiagramBuilder;component/Resources/letter.png");
            GeometryDictionary.Add(
                ICons.Ledger,
                "pack://application:,,,/DiagramBuilder;component/Resources/Ledger.png");
            GeometryDictionary.Add(ICons.Legal, "pack://application:,,,/DiagramBuilder;component/Resources/Legal.png");

            GeometryDictionary.Add(
                ICons.Underline,
                "pack://application:,,,/DiagramBuilder;component/Resources/Underline16.png");
            GeometryDictionary.Add(
                ICons.GrowFont,
                "pack://application:,,,/DiagramBuilder;component/Resources/GrowFont16.png");
            GeometryDictionary.Add(
                ICons.DecreaseFont,
                "pack://application:,,,/DiagramBuilder;component/Resources/ShrinkFont16.png");
            GeometryDictionary.Add(
                ICons.Strike,
                "pack://application:,,,/DiagramBuilder;component/Resources/Strike.png");

            GeometryDictionary.Add(
                ICons.SelectAll,
                "pack://application:,,,/DiagramBuilder;component/Resources/Select-all.png");
            GeometryDictionary.Add(
                ICons.SelectNode,
                "pack://application:,,,/DiagramBuilder;component/Resources/select-nodes.png");
            GeometryDictionary.Add(
                ICons.SelectConnector,
                "pack://application:,,,/DiagramBuilder;component/Resources/select-connectors.png");

            GeometryDictionary.Add(
                ICons.SpaceAcross,
                "pack://application:,,,/DiagramBuilder;component/Resources/SpaceAcross.png");
            GeometryDictionary.Add(
                ICons.SpaceDown,
                "pack://application:,,,/DiagramBuilder;component/Resources/SpaceDown.png");
            GeometryDictionary.Add(
                ICons.DrawingTool_Ellipse,
                "pack://application:,,,/DiagramBuilder;component/Resources/DrawTool_Ellipse.png");
            GeometryDictionary.Add(
                ICons.DrawingTool_Rectangle,
                "pack://application:,,,/DiagramBuilder;component/Resources/DrawTool_Rectangle.png");
            GeometryDictionary.Add(
                ICons.DrawingTool_StraightLine,
                "pack://application:,,,/DiagramBuilder;component/Resources/DrawTool_StraightLine.png");
            GeometryDictionary.Add(
                ICons.Polyline,
                "pack://application:,,,/DiagramBuilder;component/Resources/Polyline.png");

            GeometryDictionary.Add(
                ICons.ConnectorType,
                "pack://application:,,,/DiagramBuilder;component/Resources/Connectors.png");
            GeometryDictionary.Add(
                ICons.ConnectorType_Orthogonal,
                "pack://application:,,,/DiagramBuilder;component/Resources/Orthogonal.png");
            GeometryDictionary.Add(
                ICons.ConnectorType_StraightLine,
                "pack://application:,,,/DiagramBuilder;component/Resources/StraightLine.png");
            GeometryDictionary.Add(
                ICons.ConnectorType_CubicBeier,
                "pack://application:,,,/DiagramBuilder;component/Resources/CubicBezier.png");

            GeometryDictionary.Add(
                ICons.TaskPanes,
                "pack://application:,,,/DiagramBuilder;component/Resources/Taskpane.png");
            GeometryDictionary.Add(
                ICons.PanZoom,
                "pack://application:,,,/DiagramBuilder;component/Resources/PanZoom.png");
            GeometryDictionary.Add(
                ICons.SizeandPosition,
                "pack://application:,,,/DiagramBuilder;component/Resources/SizeandPosition.png");
            GeometryDictionary.Add(
                ICons.Subtopic,
                "pack://application:,,,/DiagramBuilder;component/Resources/Subtopic.png");
            GeometryDictionary.Add(
                ICons.MultipleSubtopics,
                "pack://application:,,,/DiagramBuilder;component/Resources/MultipleSubtopics.png");
            GeometryDictionary.Add(ICons.Peer, "pack://application:,,,/DiagramBuilder;component/Resources/Peer.png");
            GeometryDictionary.Add(
                ICons.ChangeTopic,
                "pack://application:,,,/DiagramBuilder;component/Resources/ChangeTopic.png");
            GeometryDictionary.Add(
                ICons.DiagramStyle,
                "pack://application:,,,/DiagramBuilder;component/Resources/DiagramStyle.png");
            GeometryDictionary.Add(
                ICons.ExportData,
                "pack://application:,,,/DiagramBuilder;component/Resources/ExportData.png");
            GeometryDictionary.Add(
                ICons.ImportData,
                "pack://application:,,,/DiagramBuilder;component/Resources/ImportData.png");

            GeometryDictionary.Add(ICons.VerticalCenter, "pack://application:,,,/DiagramBuilder;component/Resources/VerticalCenter.png");
            GeometryDictionary.Add(ICons.VerticalLeft, "pack://application:,,,/DiagramBuilder;component/Resources/VerticalLeft.png");
            GeometryDictionary.Add(ICons.VerticalRight, "pack://application:,,,/DiagramBuilder;component/Resources/VerticalRight.png");
            GeometryDictionary.Add(ICons.HorizontalCenter, "pack://application:,,,/DiagramBuilder;component/Resources/HorizontalCenter.png");
            GeometryDictionary.Add(ICons.HorizontalLeft, "pack://application:,,,/DiagramBuilder;component/Resources/HorizontalLeft.png");
            GeometryDictionary.Add(ICons.HorizontalRight, "pack://application:,,,/DiagramBuilder;component/Resources/HorizontalRight.png");
            GeometryDictionary.Add(ICons.Change, "pack://application:,,,/DiagramBuilder;component/Resources/Change.png");
            GeometryDictionary.Add(ICons.Delete, "pack://application:,,,/DiagramBuilder;component/Resources/Delete.png");
            GeometryDictionary.Add(ICons.Insert, "pack://application:,,,/DiagramBuilder;component/Resources/Insert.png");
            GeometryDictionary.Add(ICons.ShowHide, "pack://application:,,,/DiagramBuilder;component/Resources/Show-Hide.png");
            GeometryDictionary.Add(ICons.ShowHideSubordinates, "pack://application:,,,/DiagramBuilder;component/Resources/Show-HideSubordinates.png");
            GeometryDictionary.Add(ICons.SpaceIncrease, "pack://application:,,,/DiagramBuilder;component/Resources/SpacingIncrease.png");
            GeometryDictionary.Add(ICons.SpaceDecrease, "pack://application:,,,/DiagramBuilder;component/Resources/Spacingless.png");


            GeometryDictionary.Add(ICons.Layout, "pack://application:,,,/DiagramBuilder;component/Resources/Layout.png");
            GeometryDictionary.Add(ICons.Relayout, "pack://application:,,,/DiagramBuilder;component/Resources/Relayout.png");



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