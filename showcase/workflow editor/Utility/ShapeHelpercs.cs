#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;
using SPath = System.Windows.Shapes.Path;
namespace syncfusion.workfloweditor.wpf
{
    /// <summary>
    /// Specifies the shapes.
    /// </summary>
    public enum Shapes
    {

        Arrow,

        Tick,

        Decorator,

        None,

        /// <summary>
        /// Rectangle shape
        /// </summary>
        Rectangle,

        /// <summary>
        /// Star shape
        /// </summary>
        Star,

        /// <summary>
        /// Hexagon shape
        /// </summary>
        Hexagon,

        /// <summary>
        /// Octagon shape
        /// </summary>
        Octagon,

        /// <summary>
        /// Pentagon shape
        /// </summary>
        Pentagon,

        /// <summary>
        /// Heptagon shape
        /// </summary>
        Heptagon,

        /// <summary>
        /// Triangle shape
        /// </summary>
        Triangle,

        /// <summary>
        /// Ellipse shape
        /// </summary>
        Ellipse,

        /// <summary>
        /// Plus shape
        /// </summary>
        Plus,

        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        RoundedRectangle,

        /// <summary>
        /// Rounded Square
        /// </summary>
        RoundedSquare,

        /// <summary>
        /// Right Triangle
        /// </summary>
        RightTriangle,

        /// <summary>
        /// ThreeDBox shape
        /// </summary>
        ThreeDBox,

        /// <summary>
        /// FlowChart Process shape
        /// </summary>
        FlowChart_Process,

        /// <summary>
        /// FlowChart Start shape
        /// </summary>
        FlowChart_Start,

        /// <summary>
        /// FlowChart Decision shape
        /// </summary>
        FlowChart_Decision,

        /// <summary>
        /// FlowChart_Predefined shape
        /// </summary>
        FlowChart_Predefined,

        /// <summary>
        /// FlowChart_StoredData shape
        /// </summary>
        FlowChart_StoredData,

        /// <summary>
        /// FlowChart_Document shape
        /// </summary>
        FlowChart_Document,

        /// <summary>
        /// FlowChart_Data shape
        /// </summary>
        FlowChart_Data,

        /// <summary>
        /// FlowChart_InternalStorage shape
        /// </summary>
        FlowChart_InternalStorage,

        /// <summary>
        /// FlowChart_PaperTape shape
        /// </summary>
        FlowChart_PaperTape,

        /// <summary>
        /// FlowChart_SequentialData shape
        /// </summary>
        FlowChart_SequentialData,

        /// <summary>
        /// FlowChart_DirectData shape
        /// </summary>
        FlowChart_DirectData,

        /// <summary>
        /// FlowChart_ManualInput shape
        /// </summary>
        FlowChart_ManualInput,

        /// <summary>
        /// FlowChart_Card shape
        /// </summary>
        FlowChart_Card,

        /// <summary>
        /// FlowChart_Delay shape
        /// </summary>
        FlowChart_Delay,

        /// <summary>
        /// FlowChart_Terminator shape
        /// </summary>
        FlowChart_Terminator,

        /// <summary>
        /// FlowChart_Display shape
        /// </summary>
        FlowChart_Display,

        /// <summary>
        /// FlowChart_LoopLimit shape
        /// </summary>
        FlowChart_LoopLimit,

        /// <summary>
        /// FlowChart_Preparation shape
        /// </summary>
        FlowChart_Preparation,

        /// <summary>
        /// FlowChart_ManualOperation shape
        /// </summary>
        FlowChart_ManualOperation,

        /// <summary>
        /// FlowChart_OffPageReference shape
        /// </summary>
        FlowChart_OffPageReference,

        /// <summary>
        /// FlowChart_Star shape
        /// </summary>
        FlowChart_Star,

        Basic,
        Composition,
        UniDirectional,
        Inherit
    }

    internal static class ShapeHelper
    {
        private static Dictionary<Shapes, string> GeometryDictionary = new Dictionary<Shapes, string>();

        static ShapeHelper()
        {
            GeometryDictionary.Add(Shapes.Rectangle, "M0,0 L0,1 1,1 1,0z");
            GeometryDictionary.Add(Shapes.FlowChart_Start, "M 10,20 A 20,20 0 1 1 50,20 A 20,20 0 1 1 10,20");
            GeometryDictionary.Add(Shapes.FlowChart_Decision, "M 0,20 L 30 0 L 60,20 L 30,40 Z");
            GeometryDictionary.Add(Shapes.FlowChart_Predefined, "M 50,0 V 40 M 10,0 V 40 M 0 0 H 60 V 40 H 0 Z");
            GeometryDictionary.Add(Shapes.FlowChart_Card, "M 0 10 L 10,0 H 60 V 40 H 0 Z");
            GeometryDictionary.Add(Shapes.Ellipse, "M305.772,123.75C305.772,191.819095416645,237.434535075173,247,153.136,247C68.837464924827,247,0.5,191.819095416645,0.5,123.75C0.5,55.6809045833547,68.837464924827,0.5,153.136,0.5C237.434535075173,0.5,305.772,55.6809045833547,305.772,123.75z");
            GeometryDictionary.Add(Shapes.FlowChart_Preparation, "M 0,20 L 10,0  H 50 L 60,20 L 50,40 H10 Z");
            GeometryDictionary.Add(Shapes.RightTriangle, "M200,200L200,397.5 397.5,399.5z");
            GeometryDictionary.Add(Shapes.Star, "M 9,2 11,7 17,7 12,10 14,15 9,12 4,15 6,10 1,7 7,7 Z");
            GeometryDictionary.Add(Shapes.Basic, "M50,0 L100,50 L50,100 L0,50 z");
            GeometryDictionary.Add(Shapes.Composition, "M50,0 L100,50 L50,100 L0,50 z");
            GeometryDictionary.Add(Shapes.UniDirectional, "M0,0 L60,25 L0,50");
            GeometryDictionary.Add(Shapes.Inherit, "M2,0.5 L51.5,50 L2,99.5 L0.5,98 L0.5,2 z");
            GeometryDictionary.Add(Shapes.Arrow, "M41.58,0 L52.2686,10.6886 L41.58,21.3773 L41.58,13.8557 L6.49995,13.8557 L6.49995,7.85574 L41.58,7.85574 z");
            GeometryDictionary.Add(Shapes.Tick,"M1088.92,-800.625 L1099.34,-789.7 L1121,-815");
            GeometryDictionary.Add(Shapes.Decorator, "M0,0 L60,25 L0,50");
        }

        public static Geometry ToGeometry(this Shapes source)
        {
            if (source == Shapes.None)
            {
                return null;
            }
            return Clone(GeometryDictionary[source]);
        }

        private static PathGeometry Clone(string data)
        {
            SPath p = new SPath();
            p.Data = Geometry.Parse(data);
            PathGeometry geo = p.Data as PathGeometry;
            return geo;
        }
    }
}
